﻿Public Class frm_desarrollo
    'Inicializamos variables
    Dim listaAutos As New List(Of Automovil), listaAlfombras As New List(Of Alfombra), listaCarrocerias As New List(Of Carroceria)
    Dim contadorAutos = 0, contadorAutosBorrados = 0
    Dim evento As String
    Dim reloj = 0.0R
    Dim tiempoSimulacion As Double, tiempoDesde As Double, tiempoHasta As Double

    Dim llegadaAuto_RND = -1.0
    Dim llegadaAuto_tiempoEntreLlegadas = -1.0
    Dim llegadaAuto_horaLlegada = -1.0

    Dim tipoAuto_RND = -1.0
    Dim tipoAuto_tipo = -1.0

    Dim finQuitarAlfombra_tiempo = -1.0 'es 2 min
    Dim finQuitarAlfombra_horaFin = -1.0

    Dim finLavado1_RND = -1.0
    Dim finLavado1_tiempoLavado = -1.0
    Dim finLavado1_horaFin = -1.0

    Dim finLavado2_RND = -1.0
    Dim finLavado2_tiempoLavado = -1.0
    Dim finLavado2_horaFin = -1.0

    Dim finSecado1_numK = -1.0
    Dim finSecado1_tiempoSecado = -1.0
    Dim finSecado1_horaFin = -1.0

    Dim finSecado2_numK = -1.0
    Dim finSecado2_tiempoSecado = -1.0
    Dim finSecado2_horaFin = -1.0

    Dim finAspirado_RND = -1.0
    Dim finAspirado_tiempoAspirado = -1.0
    Dim finAspirado_horaFin = -1.0

    Dim finPonerAlfombra_tiempo = -1.0 'es 3 min
    Dim finPonerAlfombra_horaFin = -1.0

    Dim empQA_estado = "L"
    Dim empQA_cola = 0
    Dim empQA_colaLista As New List(Of Automovil)

    Dim areaAspirado_estado = "L"
    Dim areaAspirado_cola = 0
    Dim areaAspirado_listaCola As New List(Of Alfombra)

    Dim espacioLavado1_estado = "L"
    Dim espacioLavado1_carroceria As New Carroceria
    Dim espacioLavado2_estado = "L"
    Dim espacioLavado2_carroceria As New Carroceria
    Dim espaciosLavadoSecado_cola = 0
    Dim espaciosLavadoSecado_colaLista As New List(Of Carroceria)

    Dim secadora_estado = "L"

    Dim empPA_estado = "L"
    Dim empPA_cola = 0
    Dim empPA_colaLista As New List(Of Automovil)

    Dim acu_tiempoAtencion = 0 'acumulador del tiempo que tarda un auto desde que llega hasta que se va
    Dim pro_tiempoAtencion = 0 'promedio del tiempo que tarda un auto desde que llega hasta que se va
    Dim contador_autosBorrados = 0

    Dim acu_tiempoSecadora = 0 'acumulador del tiempo que se utiliza la secadora
    Dim pro_tiempoSecadora = 0 'promedio del tiempo que se utiliza la secadora

    Dim random As New Random()

    Dim tablaDatos As New DataTable("tablaDatos")
    'Fin inicializacion

    Private Sub frm_desarrollo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Maximizamos ventana
        'Me.WindowState = FormWindowState.Maximized
        'Creamos el datatable con las columnas basicas
        crearTablaDatos()
        tiempoSimulacion = frm_inicio.tiempoSimulacion
        tiempoDesde = frm_inicio.tiempoDesde
        tiempoHasta = frm_inicio.tiempoHasta
        lbl_tiempoSim.Text = tiempoSimulacion.ToString + " minutos"
        Show()
        Try
            Do While (reloj < tiempoSimulacion)

                If (reloj = 0) Then 'primera iteracion
                    evento = "Inicio"
                    determinarLlegadaAuto()
                End If

                If (reloj = llegadaAuto_horaLlegada) Then
                    contadorAutos += 1
                    evento = "Llegada Auto " & contadorAutos
                    'crear un auto
                    Dim autoNuevo As New Automovil()
                    determinarTipoAuto(autoNuevo)
                    autoNuevo.num = contadorAutos
                    autoNuevo.tiempoLlegada = reloj
                    listaAutos.Add(autoNuevo)
                    If (empQA_estado = "L") Then
                        empQA_estado = "O"
                        empQA_colaLista.Add(autoNuevo)
                        autoNuevo.estado = "Siendo QA"
                        determinarFinQA()
                    ElseIf (empQA_estado = "O") Then
                        empQA_colaLista.Add(autoNuevo)
                        empQA_cola += 1
                        autoNuevo.estado = "Esperando QA"
                    End If

                    'Sumamos las columnas del auto, la alfombra y la carroceria
                    tablaDatos.Columns.Add("Estado Auto" & contadorAutos, GetType(String))
                    tablaDatos.Columns.Add("Tipo Auto" & contadorAutos, GetType(String))
                    tablaDatos.Columns.Add("Estado Alfombra" & contadorAutos, GetType(String))
                    tablaDatos.Columns.Add("Estado Carroceria" & contadorAutos, GetType(String))

                    'otra llegada
                    determinarLlegadaAuto()

                    'blanqueamos otros campos
                    finQuitarAlfombra_tiempo = -1
                    finAspirado_RND = -1
                    finAspirado_tiempoAspirado = -1
                    finLavado1_RND = -1
                    finLavado1_tiempoLavado = -1
                    finLavado2_RND = -1
                    finLavado2_tiempoLavado = -1
                    finSecado1_numK = -1
                    finSecado2_numK = -1
                    finPonerAlfombra_tiempo = -1
                End If

                If (reloj = finQuitarAlfombra_horaFin) Then
                    evento = "Fin QA"
                    Dim autoDesarmado = empQA_colaLista.First
                    If (empQA_cola = 0) Then
                        empQA_estado = "L"
                        empQA_colaLista.Remove(empQA_colaLista.First())
                        finQuitarAlfombra_horaFin = -1.0
                        finQuitarAlfombra_tiempo = -1.0
                    ElseIf (empQA_cola > 0) Then
                        empQA_colaLista.Remove(empQA_colaLista.First())
                        empQA_cola -= 1
                        determinarFinQA()
                        empQA_colaLista.First.estado = "Siendo QA"
                    End If
                    autoDesarmado.estado = "Desarmado"

                    'creamos una alfombra a partir de este auto
                    Dim alfombraNueva As New Alfombra()
                    alfombraNueva.auto = autoDesarmado
                    listaAlfombras.Add(alfombraNueva)
                    If (areaAspirado_estado = "L") Then
                        areaAspirado_estado = "O"
                        alfombraNueva.estado = "Siendo AA"
                        areaAspirado_listaCola.Add(alfombraNueva)
                        determinarFinAA()
                    ElseIf (areaAspirado_estado = "O") Then
                        areaAspirado_cola += 1
                        alfombraNueva.estado = "Esperando AA"
                        areaAspirado_listaCola.Add(alfombraNueva)
                    End If


                    'creamos una carroceria a partir de este auto
                    Dim carroceriaNueva As New Carroceria()
                    carroceriaNueva.auto = autoDesarmado
                    listaCarrocerias.Add(carroceriaNueva)
                    If (espacioLavado1_estado = "L" And espacioLavado2_estado = "L") Then 'Ambos EL libres, ocupamos uno aleatoriamente
                        Dim numRandom = Math.Round(random.NextDouble(), 4)
                        If (numRandom <= 0.49) Then 'EL1 libre
                            espacioLavado1_estado = "O"
                            espacioLavado1_carroceria = carroceriaNueva
                            carroceriaNueva.estado = "Siendo L"
                            determinarFinLavado1()
                        ElseIf (numRandom >= 0.5) Then 'EL2 libre
                            espacioLavado2_estado = "O"
                            espacioLavado2_carroceria = carroceriaNueva
                            carroceriaNueva.estado = "Siendo L"
                            determinarFinLavado2()
                        End If
                    ElseIf (espacioLavado1_estado = "L" Or espacioLavado2_estado = "L") Then 'Alguno de los dos EL libres
                        If (espacioLavado1_estado = "L") Then 'EL1 libre
                            espacioLavado1_estado = "O"
                            espacioLavado1_carroceria = carroceriaNueva
                            carroceriaNueva.estado = "Siendo L"
                            determinarFinLavado1()
                        ElseIf (espacioLavado2_estado = "L") Then 'EL2 libre
                            espacioLavado2_estado = "O"
                            espacioLavado2_carroceria = carroceriaNueva
                            carroceriaNueva.estado = "Siendo L"
                            determinarFinLavado2()
                        End If
                    ElseIf (espacioLavado1_estado = "O" And espacioLavado2_estado = "O") Then 'Ambos EL ocupados, agregamos a la cola
                        espaciosLavadoSecado_cola += 1
                        espaciosLavadoSecado_colaLista.Add(carroceriaNueva)
                        carroceriaNueva.estado = "Esperando L"
                    End If

                    'blanqueamos campos
                    tipoAuto_RND = -1
                    tipoAuto_tipo = -1
                    llegadaAuto_RND = -1
                    llegadaAuto_tiempoEntreLlegadas = -1
                    finSecado1_numK = -1
                    finSecado2_numK = -1
                    finPonerAlfombra_tiempo = -1
                End If

                If (reloj = finAspirado_horaFin) Then
                    evento = "Fin AA"
                    'Vamos a determinar si la carroceria del auto ya esta seca (esperando alfombra) o no
                    For Each carroceria As Carroceria In listaCarrocerias
                        If (carroceria.auto.num = areaAspirado_listaCola.First.auto.num And carroceria.estado = "Esperando Alfombra") Then
                            If (empPA_estado = "L") Then
                                empPA_estado = "O"
                                empPA_colaLista.Add(carroceria.auto)
                                carroceria.estado = "Siendo PA"
                                areaAspirado_listaCola.First.estado = "Siendo PA"
                                determinarFinPA()
                            ElseIf (empPA_estado = "O") Then
                                empPA_cola += 1
                                empPA_colaLista.Add(carroceria.auto) 'tmb puede ser areaaspirado_listacola.first.auto ya que apuntan al mismo
                                carroceria.estado = "Esperando PA"
                                areaAspirado_listaCola.First.estado = "Esperando PA"
                            End If
                        ElseIf (carroceria.auto.num = areaAspirado_listaCola.First.auto.num And carroceria.estado <> "Esperando Alfombra") Then
                            areaAspirado_listaCola.First.estado = "Esperando Carroceria"
                        End If
                    Next
                    If (areaAspirado_cola = 0) Then
                        areaAspirado_estado = "L"
                        areaAspirado_listaCola.Remove(areaAspirado_listaCola.First)
                        finAspirado_horaFin = -1.0
                        finAspirado_RND = -1.0
                        finAspirado_tiempoAspirado = -1.0
                    ElseIf (areaAspirado_cola > 0) Then
                        areaAspirado_cola -= 1
                        areaAspirado_listaCola.Remove(areaAspirado_listaCola.First)
                        areaAspirado_listaCola.First.estado = "Siendo AA"
                        determinarFinAA()
                    End If

                    'blanqueamos campos
                    tipoAuto_RND = -1
                    tipoAuto_tipo = -1
                    llegadaAuto_RND = -1
                    llegadaAuto_tiempoEntreLlegadas = -1
                    finLavado1_RND = -1
                    finLavado1_tiempoLavado = -1
                    finLavado2_RND = -1
                    finLavado2_tiempoLavado = -1
                    finSecado1_numK = -1
                    finSecado2_numK = -1
                End If

                If (reloj = finLavado1_horaFin) Then
                    evento = "Fin Lavado 1"
                    finLavado1_horaFin = -1
                    finLavado1_RND = -1
                    finLavado1_tiempoLavado = -1
                    espacioLavado1_carroceria.humedad = 100.0R
                    If (secadora_estado = "L") Then
                        espacioLavado1_carroceria.estado = "Secando Maq"
                        secadora_estado = "Secando 1"
                        determinarFinSecadoMaquina1(espacioLavado1_carroceria.humedad, espacioLavado1_carroceria.auto.numK)
                    ElseIf (secadora_estado = "Secando 2") Then
                        espacioLavado1_carroceria.estado = "Secando Sola"
                        determinarFinSecadoSolo1(espacioLavado1_carroceria.humedad, espacioLavado1_carroceria.auto.numK)
                    End If

                    'blanqueamos campos
                    tipoAuto_RND = -1
                    tipoAuto_tipo = -1
                    llegadaAuto_RND = -1
                    llegadaAuto_tiempoEntreLlegadas = -1
                    finQuitarAlfombra_tiempo = -1
                    finLavado2_RND = -1
                    finLavado2_tiempoLavado = -1
                    finSecado2_numK = -1
                    finPonerAlfombra_tiempo = -1
                    finAspirado_RND = -1
                    finAspirado_tiempoAspirado = -1
                End If

                If (reloj = finLavado2_horaFin) Then
                    evento = "Fin Lavado 2"
                    finLavado2_horaFin = -1
                    finLavado2_RND = -1
                    finLavado2_tiempoLavado = -1
                    espacioLavado2_carroceria.humedad = 100.0R
                    If (secadora_estado = "L") Then
                        espacioLavado2_carroceria.estado = "Secando Maq"
                        secadora_estado = "Secando 2"
                        determinarFinSecadoMaquina2(espacioLavado2_carroceria.humedad, espacioLavado2_carroceria.auto.numK)
                    ElseIf (secadora_estado = "Secando 1") Then
                        espacioLavado2_carroceria.estado = "Secando Sola"
                        determinarFinSecadoSolo2(espacioLavado2_carroceria.humedad, espacioLavado2_carroceria.auto.numK)
                    End If

                    'blanqueamos campos
                    tipoAuto_RND = -1
                    tipoAuto_tipo = -1
                    llegadaAuto_RND = -1
                    llegadaAuto_tiempoEntreLlegadas = -1
                    finQuitarAlfombra_tiempo = -1
                    finLavado1_RND = -1
                    finLavado1_tiempoLavado = -1
                    finSecado1_numK = -1
                    finPonerAlfombra_tiempo = -1
                    finAspirado_RND = -1
                    finAspirado_tiempoAspirado = -1
                End If

                If (reloj = finSecado1_horaFin) Then
                    evento = "Fin Secado 1"
                    espacioLavado1_carroceria.humedad = 0.0R
                    If (espacioLavado2_estado = "O") Then
                        If (espacioLavado2_carroceria.estado = "Secando Sola" And espacioLavado1_carroceria.estado = "Secando Maq") Then  'La carroceria en el espacio 1 tiene la secadora y hay una carroceria en el otro EL secandose sola
                            secadora_estado = "Secando 2"
                            espacioLavado2_carroceria.estado = "Secando Maq"
                            Dim tiempoSecadoAnterior As Double
                            Dim horaFinSecadoAnterior As Double
                            Dim tiempoAnterior As Double
                            Dim tiempoTranscurrido As Double
                            'With tablaDatos
                            '    tiempoSecadoAnterior = .Rows(.Rows.Count - 1)(22)
                            '    horaFinSecadoAnterior = .Rows(.Rows.Count - 1)(23)
                            'End With
                            tiempoSecadoAnterior = finSecado2_tiempoSecado
                            horaFinSecadoAnterior = finSecado2_horaFin
                            tiempoAnterior = horaFinSecadoAnterior - tiempoSecadoAnterior
                            tiempoTranscurrido = reloj - tiempoAnterior
                            Dim humedadActual = determinarHumedadActual(espacioLavado2_carroceria.auto.numK, tiempoTranscurrido)
                            determinarFinSecadoMaquina2(humedadActual, espacioLavado2_carroceria.auto.numK)
                        ElseIf (espacioLavado2_carroceria.estado = "Siendo L" And espacioLavado1_carroceria.estado = "Secando Maq") Then
                            secadora_estado = "L"
                        End If
                    ElseIf (espacioLavado2_estado = "L") Then
                        secadora_estado = "L"
                    End If
                    'Vamos a determinar si la alfombra del auto ya se aspiró (esperando carroceria) o no
                    For Each alfombra As Alfombra In listaAlfombras
                        If (alfombra.auto.num = espacioLavado1_carroceria.auto.num And alfombra.estado = "Esperando Carroceria") Then
                            If (empPA_estado = "L") Then
                                empPA_estado = "O"
                                empPA_colaLista.Add(alfombra.auto)
                                alfombra.estado = "Siendo PA"
                                espacioLavado1_carroceria.estado = "Siendo PA"
                                determinarFinPA()
                            ElseIf (empPA_estado = "O") Then
                                empPA_cola += 1
                                empPA_colaLista.Add(alfombra.auto) 'tmb puede ser espaciolavado1_carroceria.auto ya que apuntan al mismo auto
                                alfombra.estado = "Esperando PA"
                                espacioLavado1_carroceria.estado = "Esperando PA"
                            End If
                        ElseIf (alfombra.auto.num = espacioLavado1_carroceria.auto.num And alfombra.estado <> "Esperando Carroceria") Then
                            espacioLavado1_carroceria.estado = "Esperando Alfombra"
                        End If
                    Next
                    If (espaciosLavadoSecado_cola = 0) Then
                        espacioLavado1_carroceria = Nothing
                        espacioLavado1_estado = "L"
                    ElseIf (espaciosLavadoSecado_cola > 0) Then
                        espacioLavado1_carroceria = espaciosLavadoSecado_colaLista.First
                        espaciosLavadoSecado_colaLista.Remove(espaciosLavadoSecado_colaLista.First)
                        espaciosLavadoSecado_cola -= 1
                        espacioLavado1_carroceria.estado = "Siendo L"
                        determinarFinLavado1()
                    End If

                    'Hacemos estadistica del porcentaje de uso de secadora
                    acu_tiempoSecadora += finSecado1_tiempoSecado

                    'blanqueamos campos
                    tipoAuto_RND = -1
                    tipoAuto_tipo = -1
                    llegadaAuto_RND = -1
                    llegadaAuto_tiempoEntreLlegadas = -1
                    finQuitarAlfombra_tiempo = -1
                    finLavado2_RND = -1
                    finLavado2_tiempoLavado = -1
                    finSecado1_numK = -1.0
                    finSecado1_tiempoSecado = -1.0
                    finSecado1_horaFin = -1.0
                    finAspirado_RND = -1
                    finAspirado_tiempoAspirado = -1
                End If

                If (reloj = finSecado2_horaFin) Then
                    evento = "Fin Secado 2"
                    espacioLavado2_carroceria.humedad = 0.0R
                    'Recalcular tiempo de secado en caso que corresponda
                    If (espacioLavado1_estado = "O") Then
                        If (espacioLavado1_carroceria.estado = "Secando Sola" And espacioLavado2_carroceria.estado = "Secando Maq") Then  'La carroceria en el espacio 2 tiene la secadora y hay una carroceria en el otro EL secandose sola
                            secadora_estado = "Secando 1"
                            espacioLavado1_carroceria.estado = "Secando Maq"
                            Dim tiempoSecadoAnterior As Double
                            Dim horaFinSecadoAnterior As Double
                            Dim tiempoAnterior As Double
                            Dim tiempoTranscurrido As Double
                            'With tablaDatos
                            '    tiempoSecadoAnterior = .Rows(.Rows.Count - 1)(19)
                            '    horaFinSecadoAnterior = .Rows(.Rows.Count - 1)(20)
                            'End With
                            tiempoSecadoAnterior = finSecado1_tiempoSecado
                            horaFinSecadoAnterior = finSecado1_horaFin
                            tiempoAnterior = horaFinSecadoAnterior - tiempoSecadoAnterior
                            tiempoTranscurrido = reloj - tiempoAnterior
                            Dim humedadActual = determinarHumedadActual(espacioLavado1_carroceria.auto.numK, tiempoTranscurrido)
                            determinarFinSecadoMaquina1(humedadActual, espacioLavado1_carroceria.auto.numK)
                        ElseIf (espacioLavado1_carroceria.estado = "Siendo L" And espacioLavado2_carroceria.estado = "Secando Maq") Then
                            secadora_estado = "L"
                        End If
                    ElseIf (espacioLavado1_estado = "L") Then
                        secadora_estado = "L"
                    End If
                    'Vamos a determinar si la alfombra del auto ya se aspiró (esperando carroceria) o no
                    For Each alfombra As Alfombra In listaAlfombras
                        If (alfombra.auto.num = espacioLavado2_carroceria.auto.num And alfombra.estado = "Esperando Carroceria") Then
                            If (empPA_estado = "L") Then
                                empPA_estado = "O"
                                empPA_colaLista.Add(alfombra.auto)
                                alfombra.estado = "Siendo PA"
                                espacioLavado2_carroceria.estado = "Siendo PA"
                                determinarFinPA()
                            ElseIf (empPA_estado = "O") Then
                                empPA_cola += 1
                                empPA_colaLista.Add(alfombra.auto) 'tmb puede ser espaciolavado2_carroceria.auto ya que apuntan al mismo
                                alfombra.estado = "Esperando PA"
                                espacioLavado2_carroceria.estado = "Esperando PA"
                            End If
                        ElseIf (alfombra.auto.num = espacioLavado2_carroceria.auto.num And alfombra.estado <> "Esperando Carroceria") Then
                            espacioLavado2_carroceria.estado = "Esperando Alfombra"
                        End If
                    Next
                    If (espaciosLavadoSecado_cola = 0) Then 'SI NO HAY COLA EN LOS ESPACIOS DE LAVADO
                        espacioLavado2_carroceria = Nothing
                        espacioLavado2_estado = "L"
                    ElseIf (espaciosLavadoSecado_cola > 0) Then 'SI HAY COLA EN LOS ESPACIOS DE LAVADO
                        espacioLavado2_carroceria = espaciosLavadoSecado_colaLista.First
                        espaciosLavadoSecado_colaLista.Remove(espaciosLavadoSecado_colaLista.First)
                        espaciosLavadoSecado_cola -= 1
                        espacioLavado2_carroceria.estado = "Siendo L"
                        determinarFinLavado2()
                    End If

                    'Hacemos estadistica del porcentaje de uso de secadora
                    acu_tiempoSecadora += finSecado2_tiempoSecado

                    'blanqueamos campos
                    tipoAuto_RND = -1
                    tipoAuto_tipo = -1
                    llegadaAuto_RND = -1
                    llegadaAuto_tiempoEntreLlegadas = -1
                    finQuitarAlfombra_tiempo = -1
                    finLavado1_RND = -1
                    finLavado1_tiempoLavado = -1
                    finSecado2_numK = -1.0
                    finSecado2_tiempoSecado = -1.0
                    finSecado2_horaFin = -1.0
                    finAspirado_RND = -1
                    finAspirado_tiempoAspirado = -1
                End If

                If (reloj = finPonerAlfombra_horaFin) Then
                    evento = "Fin PA"
                    'Eliminamos el auto, la alfombra y la carroceria del sistema
                    empPA_colaLista.First.estado = "FINALIZADO"
                    empPA_colaLista.First.tipo = "FINALIZADO"
                    For Each alfombra As Alfombra In listaAlfombras
                        If (alfombra.auto.num = empPA_colaLista.First.num) Then
                            alfombra.estado = "FINALIZADO"
                        End If
                    Next
                    For Each carroceria As Carroceria In listaCarrocerias
                        If (carroceria.auto.num = empPA_colaLista.First.num) Then
                            carroceria.estado = "FINALIZADO"
                        End If
                    Next
                    'Estadistica de tiempo de atencion promedio
                    acu_tiempoAtencion += Math.Round((reloj - empPA_colaLista.First.tiempoLlegada), 4)
                    contador_autosBorrados += 1
                    pro_tiempoAtencion = acu_tiempoAtencion / contador_autosBorrados
                    empPA_colaLista.Remove(empPA_colaLista.First)
                    If (empPA_cola = 0) Then
                        empPA_estado = "L"
                        finPonerAlfombra_horaFin = -1.0
                        finPonerAlfombra_tiempo = -1.0
                    ElseIf (empPA_cola > 0) Then
                        empPA_cola -= 1
                        For Each alfombra As Alfombra In listaAlfombras
                            If (alfombra.auto.num = empPA_colaLista.First.num) Then
                                alfombra.estado = "Siendo PA"
                            End If
                        Next
                        For Each carroceria As Carroceria In listaCarrocerias
                            If (carroceria.auto.num = empPA_colaLista.First.num) Then
                                carroceria.estado = "Siendo PA"
                            End If
                        Next
                        determinarFinPA()
                    End If

                    'blanqueamos campos
                    tipoAuto_RND = -1
                    tipoAuto_tipo = -1
                    llegadaAuto_RND = -1
                    llegadaAuto_tiempoEntreLlegadas = -1
                    finQuitarAlfombra_tiempo = -1
                    finLavado1_RND = -1
                    finLavado1_tiempoLavado = -1
                    finLavado2_RND = -1
                    finLavado2_tiempoLavado = -1
                    finSecado1_numK = -1
                    finSecado2_numK = -1.0
                    finAspirado_RND = -1
                    finAspirado_tiempoAspirado = -1
                End If

                '--FIN ENTRADAS AL SISTEMA. COMIENZAN LAS OPERACIONES CON LA MATRIZ--

                'Sumamos filas dentro del intervalo al Datatable

                Dim filaArray = New Object() {evento, reloj, llegadaAuto_RND, llegadaAuto_tiempoEntreLlegadas, llegadaAuto_horaLlegada, tipoAuto_RND, tipoAuto_tipo, finQuitarAlfombra_tiempo, finQuitarAlfombra_horaFin, finAspirado_RND, finAspirado_tiempoAspirado, finAspirado_horaFin, finLavado1_RND, finLavado1_tiempoLavado, finLavado1_horaFin, finLavado2_RND, finLavado2_tiempoLavado, finLavado2_horaFin, finSecado1_numK, finSecado1_tiempoSecado, finSecado1_horaFin, finSecado2_numK, finSecado2_tiempoSecado, finSecado2_horaFin, finPonerAlfombra_tiempo, finPonerAlfombra_horaFin, empQA_estado, empQA_cola, areaAspirado_estado, areaAspirado_cola, espacioLavado1_estado, espacioLavado2_estado, espaciosLavadoSecado_cola, secadora_estado, empPA_estado, empPA_cola, acu_tiempoAtencion, acu_tiempoSecadora}
                Dim filaNueva As New ArrayList(filaArray)
                Dim banderaHayQueBorrarAuto = -1
                If (contadorAutosBorrados > 0) Then
                    For i As Integer = 0 To (contadorAutosBorrados - 1)
                        filaNueva.Add("")
                        filaNueva.Add("")
                        filaNueva.Add("")
                        filaNueva.Add("")
                    Next
                End If
                If (contadorAutos > 0) Then
                    For i As Integer = 0 To (contadorAutos - 1 - contadorAutosBorrados)
                        If (listaAutos(i).estado <> "FINALIZADO") Then
                            filaNueva.Add(listaAutos(i).estado)
                            filaNueva.Add(listaAutos(i).tipo)
                            If (listaAlfombras.Count > 0) Then
                                For j As Integer = 0 To (listaAlfombras.Count - 1)
                                    If (listaAlfombras(j).auto.num = listaAutos(i).num) Then
                                        filaNueva.Add(listaAlfombras(j).estado)
                                        filaNueva.Add(listaCarrocerias(j).estado)
                                    End If
                                Next
                            End If
                        Else
                            filaNueva.Add("/////")
                            filaNueva.Add("/////")
                            filaNueva.Add("/////")
                            filaNueva.Add("/////")
                            banderaHayQueBorrarAuto = i
                        End If
                    Next
                End If
                'Borramos auto de la lista en caso que ya haya finalizado en la simulacion, y su alfombra y carroceria si corresponde
                If (banderaHayQueBorrarAuto <> -1) Then
                    contadorAutosBorrados += 1
                    Dim banderaHayQueBorrarAlfombra = -1
                    If (listaAlfombras.Count > 0) Then
                        For j As Integer = 0 To (listaAlfombras.Count - 1)
                            If (listaAlfombras(j).auto.num = listaAutos(banderaHayQueBorrarAuto).num) Then
                                banderaHayQueBorrarAlfombra = j
                            End If
                        Next
                    End If
                    listaAutos.RemoveAt(banderaHayQueBorrarAuto)
                    If (banderaHayQueBorrarAlfombra <> -1) Then
                        listaAlfombras.RemoveAt(banderaHayQueBorrarAlfombra)
                        listaCarrocerias.RemoveAt(banderaHayQueBorrarAlfombra)
                    End If
                End If

                'sumamos ultima fila
                If (reloj >= tiempoDesde And reloj <= tiempoHasta) Then
                    tablaDatos.Rows.Add(CType(filaNueva.ToArray(GetType(Object)), Object()))
                End If

                'calcular proximo evento
                calcularProximoEvento()
            Loop

            'Bindeamos el datatable con todos los datos a la grilla
            dgv_matriz.DataSource = tablaDatos
            cambiarColorColumnas()
            lbl_autos.Text = contadorAutosBorrados
            lbl_promTiempoAtencion.Text = Math.Round(pro_tiempoAtencion, 4).ToString + " minutos"
            lbl_porcUsoSecadora.Text = Math.Round(acu_tiempoSecadora / tiempoSimulacion * 100, 4).ToString + "%"
        Catch ex As Exception
            Throw ex
            'Dim trace = New System.Diagnostics.StackTrace(ex, True)
            'MsgBox(ex.Message & vbCrLf & "Error in ClaimFlag10 - Line number:" & trace.GetFrame(0).GetFileLineNumber().ToString)
            'Debug.WriteLine(ex.Message & vbCrLf & "Error in ClaimFlag10 - Line number:" & trace.GetFrame(0).GetFileLineNumber().ToString)
        End Try
    End Sub

    Private Sub determinarFinPA()
        finPonerAlfombra_tiempo = 3
        finPonerAlfombra_horaFin = reloj + finPonerAlfombra_tiempo
    End Sub

    Private Function determinarHumedadActual(numK As Double, tiempoTranscurrido As Double) As Double
        Dim tiempoInicial As Double
        Dim humedadInicial As Double
        Dim tiempoSiguiente As Double
        Dim humedadSiguiente As Double
        Dim h = 0.0001R

        tiempoInicial = 0.0R
        humedadInicial = 100 'El auto se empezo a secar solo y luego se desocupa la secadora
        Do While (tiempoInicial < tiempoTranscurrido)
            tiempoSiguiente += h
            humedadSiguiente = humedadInicial + h * (-numK * humedadInicial)
            tiempoInicial = tiempoSiguiente
            humedadInicial = humedadSiguiente
        Loop
        Return humedadInicial
    End Function

    Private Sub determinarFinSecadoMaquina1(humedad As Double, numK As Double)
        Dim tiempoInicial As Double
        Dim humedadInicial As Double
        Dim tiempoSiguiente As Double
        Dim humedadSiguiente As Double
        Dim h = 0.0001R

        tiempoInicial = 0.0R
        humedadInicial = humedad
        Do While (humedadInicial > 0.0)
            tiempoSiguiente += h
            humedadSiguiente = humedadInicial + h * ((-5) * Math.Pow(tiempoInicial, 2) + 2.0R * humedadInicial - 200.0R)
            tiempoInicial = tiempoSiguiente
            humedadInicial = humedadSiguiente
        Loop
        finSecado1_numK = numK
        finSecado1_tiempoSecado = Math.Round(tiempoInicial, 4)
        finSecado1_horaFin = Math.Round(reloj + tiempoInicial, 4)
    End Sub

    Private Sub determinarFinSecadoSolo1(humedad As Double, numK As Double)
        Dim tiempoInicial As Double
        Dim humedadInicial As Double
        Dim tiempoSiguiente As Double
        Dim humedadSiguiente As Double
        Dim h = 0.0001R

        tiempoInicial = 0.0R
        humedadInicial = humedad
        Do While (Math.Round(humedadInicial, 0) > 0.0)
            tiempoSiguiente += h
            humedadSiguiente = humedadInicial + h * ((-numK) * humedadInicial)
            tiempoInicial = tiempoSiguiente
            humedadInicial = humedadSiguiente
        Loop
        finSecado1_numK = numK
        finSecado1_tiempoSecado = Math.Round(tiempoInicial, 4)
        finSecado1_horaFin = Math.Round(reloj + tiempoInicial, 4)
    End Sub

    Private Sub determinarFinSecadoMaquina2(humedad As Double, numK As Double)
        Dim tiempoInicial As Double
        Dim humedadInicial As Double
        Dim tiempoSiguiente As Double
        Dim humedadSiguiente As Double
        Dim h = 0.0001R

        tiempoInicial = 0.0R
        humedadInicial = humedad
        Do While (humedadInicial > 0.0)
            tiempoSiguiente += h
            humedadSiguiente = humedadInicial + h * ((-5) * Math.Pow(tiempoInicial, 2) + 2.0R * humedadInicial - 200.0R)
            tiempoInicial = tiempoSiguiente
            humedadInicial = humedadSiguiente
        Loop
        finSecado2_numK = numK
        finSecado2_tiempoSecado = Math.Round(tiempoInicial, 4)
        finSecado2_horaFin = Math.Round(reloj + tiempoInicial, 4)
    End Sub

    Private Sub determinarFinSecadoSolo2(humedad As Double, numK As Double)
        Dim tiempoInicial As Double
        Dim humedadInicial As Double
        Dim tiempoSiguiente As Double
        Dim humedadSiguiente As Double
        Dim h = 0.0001R

        tiempoInicial = 0.0R
        humedadInicial = humedad
        Do While (Math.Round(humedadInicial, 0) > 0.0)
            tiempoSiguiente += h
            humedadSiguiente = humedadInicial + h * ((-numK) * humedadInicial)
            tiempoInicial = tiempoSiguiente
            humedadInicial = humedadSiguiente
        Loop
        finSecado2_numK = numK
        finSecado2_tiempoSecado = Math.Round(tiempoInicial, 4)
        finSecado2_horaFin = Math.Round(reloj + tiempoInicial, 4)
    End Sub

    Private Sub determinarFinAA()
        Do While (finAspirado_RND = -1 Or finAspirado_RND = 1)
            finAspirado_RND = Math.Round(random.NextDouble(), 4)
        Loop
        finAspirado_tiempoAspirado = finAspirado_RND * 2 + 3
        finAspirado_horaFin = Math.Round(reloj + finAspirado_tiempoAspirado, 4)
    End Sub

    Private Sub determinarFinLavado1()
        Do While (finLavado1_RND = -1 Or finLavado1_RND = 1)
            finLavado1_RND = Math.Round(random.NextDouble(), 4)
        Loop
        finLavado1_tiempoLavado = finLavado1_RND * 6 + 6
        finLavado1_horaFin = Math.Round(reloj + finLavado1_tiempoLavado, 4)
    End Sub

    Private Sub determinarFinLavado2()
        Do While (finLavado2_RND = -1 Or finLavado2_RND = 1)
            finLavado2_RND = Math.Round(random.NextDouble(), 4)
        Loop
        finLavado2_tiempoLavado = finLavado2_RND * 6 + 6
        finLavado2_horaFin = Math.Round(reloj + finLavado2_tiempoLavado, 4)
    End Sub

    Private Sub determinarLlegadaAuto()
        Do While (llegadaAuto_RND = -1 Or llegadaAuto_RND = 1)
            llegadaAuto_RND = Math.Round(random.NextDouble(), 2)
        Loop
        llegadaAuto_tiempoEntreLlegadas = Math.Round((-10 * Math.Log(1 - llegadaAuto_RND)), 4)
        llegadaAuto_horaLlegada = Math.Round(reloj + llegadaAuto_tiempoEntreLlegadas, 4)
    End Sub

    Private Sub determinarFinQA()
        finQuitarAlfombra_tiempo = 2.0R
        finQuitarAlfombra_horaFin = Math.Round(reloj + finQuitarAlfombra_tiempo, 4)
    End Sub

    Private Sub determinarTipoAuto(auto As Automovil)
        Do While (tipoAuto_RND = -1 Or tipoAuto_RND = 1)
            tipoAuto_RND = Math.Round(random.NextDouble(), 4)
        Loop
        If (tipoAuto_RND >= 0 And tipoAuto_RND <= 0.19) Then
            auto.tipo = "Pequeño"
            auto.numK = 0.75
        ElseIf (tipoAuto_RND >= 0.2 And tipoAuto_RND <= 0.69) Then
            auto.tipo = "Mediano"
            auto.numK = 0.5
        ElseIf (tipoAuto_RND >= 0.7 And tipoAuto_RND <= 0.99) Then
            auto.tipo = "PickUp"
            auto.numK = 0.25
        End If
        tipoAuto_tipo = auto.tipo
    End Sub


    Private Sub calcularProximoEvento()
        Dim vectorTiemposEventos(7) As Double
        vectorTiemposEventos(0) = llegadaAuto_horaLlegada
        vectorTiemposEventos(1) = finQuitarAlfombra_horaFin
        vectorTiemposEventos(2) = finAspirado_horaFin
        vectorTiemposEventos(3) = finLavado1_horaFin
        vectorTiemposEventos(4) = finLavado2_horaFin
        vectorTiemposEventos(5) = finSecado1_horaFin
        vectorTiemposEventos(6) = finSecado2_horaFin
        vectorTiemposEventos(7) = finPonerAlfombra_horaFin
        Array.Sort(vectorTiemposEventos)
        If (vectorTiemposEventos(0) <> 0 And reloj < vectorTiemposEventos(0)) Then
            reloj = vectorTiemposEventos(0)
        ElseIf (vectorTiemposEventos(1) <> 0 And reloj < vectorTiemposEventos(1)) Then
            reloj = vectorTiemposEventos(1)
        ElseIf (vectorTiemposEventos(2) <> 0 And reloj < vectorTiemposEventos(2)) Then
            reloj = vectorTiemposEventos(2)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(3)) Then
            reloj = vectorTiemposEventos(3)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(4)) Then
            reloj = vectorTiemposEventos(4)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(5)) Then
            reloj = vectorTiemposEventos(5)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(6)) Then
            reloj = vectorTiemposEventos(6)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(7)) Then
            reloj = vectorTiemposEventos(7)
        End If
    End Sub

    Public Sub crearTablaDatos()
        'son 38 columnas las basicas
        tablaDatos.Columns.Add("Evento", GetType(String))
        tablaDatos.Columns.Add("Tiempo Sistema", GetType(String))
        tablaDatos.Columns.Add("RND(LA)", GetType(String))
        tablaDatos.Columns.Add("T.Entre Llegadas(LA)", GetType(String))
        tablaDatos.Columns.Add("H. Llegada(LA)", GetType(String))
        tablaDatos.Columns.Add("RND(Tipo)", GetType(String))
        tablaDatos.Columns.Add("Tipo", GetType(String))
        tablaDatos.Columns.Add("T.(QA)", GetType(String))
        tablaDatos.Columns.Add("H. Fin(QA)", GetType(String))
        tablaDatos.Columns.Add("RND(AA)", GetType(String))
        tablaDatos.Columns.Add("T.Aspirado (AA)", GetType(String))
        tablaDatos.Columns.Add("H. Fin Aspirado(AA)", GetType(String))
        tablaDatos.Columns.Add("RND(FL1)", GetType(String))
        tablaDatos.Columns.Add("T. Lavado(FL1)", GetType(String))
        tablaDatos.Columns.Add("H. Fin Lavado(FL1)", GetType(String))
        tablaDatos.Columns.Add("RND(FL2)", GetType(String))
        tablaDatos.Columns.Add("T. Lavado(FL2)", GetType(String))
        tablaDatos.Columns.Add("H. Fin Lavado(FL2)", GetType(String))
        tablaDatos.Columns.Add("K(FS1)", GetType(String))
        tablaDatos.Columns.Add("T. Secado(FS1)", GetType(String))
        tablaDatos.Columns.Add("H. Fin Secado(FS1)", GetType(String))
        tablaDatos.Columns.Add("K(FS2)", GetType(String))
        tablaDatos.Columns.Add("T. Secado(FS2)", GetType(String))
        tablaDatos.Columns.Add("H. Fin Secado(FS2)", GetType(String))
        tablaDatos.Columns.Add("T.(PA)", GetType(String))
        tablaDatos.Columns.Add("H. Fin(PA)", GetType(String))
        tablaDatos.Columns.Add("Estado (QA)", GetType(String))
        tablaDatos.Columns.Add("Cola (QA)", GetType(String))
        tablaDatos.Columns.Add("Estado (AA)", GetType(String))
        tablaDatos.Columns.Add("Cola (AA)", GetType(String))
        tablaDatos.Columns.Add("Estado (EL1)", GetType(String))
        tablaDatos.Columns.Add("Estado (EL2)", GetType(String))
        tablaDatos.Columns.Add("Cola (EL)", GetType(String))
        tablaDatos.Columns.Add("Estado (S)", GetType(String))
        tablaDatos.Columns.Add("Estado (PA)", GetType(String))
        tablaDatos.Columns.Add("Cola (PA)", GetType(String))
        tablaDatos.Columns.Add("Acu T. Atencion", GetType(String))
        tablaDatos.Columns.Add("Acu T. Secadora", GetType(String))
    End Sub

    Private Sub cambiarColorColumnas()
        dgv_matriz.Columns(4).DefaultCellStyle.BackColor = Color.LightBlue
        dgv_matriz.Columns(8).DefaultCellStyle.BackColor = Color.LightBlue
        dgv_matriz.Columns(11).DefaultCellStyle.BackColor = Color.LightBlue
        dgv_matriz.Columns(14).DefaultCellStyle.BackColor = Color.LightBlue
        dgv_matriz.Columns(17).DefaultCellStyle.BackColor = Color.LightBlue
        dgv_matriz.Columns(20).DefaultCellStyle.BackColor = Color.LightBlue
        dgv_matriz.Columns(23).DefaultCellStyle.BackColor = Color.LightBlue
        dgv_matriz.Columns(25).DefaultCellStyle.BackColor = Color.LightBlue
    End Sub

   
    Private Sub dgv_matriz_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_matriz.SelectionChanged
        If (dgv_matriz.SelectedCells.Count <> 0) Then
            lbl_relojCeldaSelec.Text = dgv_matriz.Rows((dgv_matriz.SelectedCells(0).RowIndex)).Cells(1).Value
            lbl_eventoCelSelec.Text = dgv_matriz.Rows((dgv_matriz.SelectedCells(0).RowIndex)).Cells(0).Value
        End If
    End Sub

    Private Sub bnt_abreviaciones_Click(sender As Object, e As EventArgs) Handles bnt_abreviaciones.Click
        frm_abreviaciones.Show()
    End Sub
End Class
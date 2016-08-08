Public Class frm_desarrollo
    'Inicializamos variables
    Dim listaAutos As List(Of Automovil), listaAlfombras As List(Of Alfombra), listaCarrocerias As List(Of Carroceria)
    Dim contadorAutos = 0, contadorAlfombras = 0, contadorCarrocerias = 0
    Dim evento As String
    Dim reloj = 0.0R

    Dim llegadaAuto_RND = -1.0R
    Dim llegadaAuto_tiempoEntreLlegadas = -1.0R
    Dim llegadaAuto_horaLlegada = -1.0R

    Dim tipoAuto_RND = -1.0R
    Dim tipoAuto_tipo = -1.0R

    Dim finQuitarAlfombra_tiempo = -1.0R 'es 2 min
    Dim finQuitarAlfombra_horaFin = -1.0R

    Dim finLavado1_RND = -1.0R
    Dim finLavado1_tiempoLavado = -1.0R
    Dim finLavado1_horaFin = -1.0R

    Dim finLavado2_RND = -1.0R
    Dim finLavado2_tiempoLavado = -1.0R
    Dim finLavado2_horaFin = -1.0R

    Dim finSecado1_numK = -1.0R
    Dim finSecado1_tiempoSecado = -1.0R
    Dim finSecado1_horaFin = -1.0R

    Dim finSecado2_numK = -1.0R
    Dim finSecado2_tiempoSecado = -1.0R
    Dim finSecado2_horaFin = -1.0R

    Dim finAspirado_RND = -1.0R
    Dim finAspirado_tiempoAspirado = -1.0R
    Dim finAspirado_horaFin = -1.0R

    Dim finPonerAlfombra_tiempo = -1.0R 'es 3 min
    Dim finPonerAlfombra_horaFin = -1.0R

    Dim empQA_estado = "L"
    Dim empQA_cola = -1.0R
    Dim empQA_colaLista As List(Of Automovil)

    Dim areaAspirado_estado = "L"
    Dim areaAspirado_cola = -1.0R
    Dim areaAspirado_listaCola As List(Of Alfombra)

    Dim espacioLavado1_estado = "L"
    Dim espacioLavado1_carroceria As Carroceria
    Dim espacioLavado2_estado = "L"
    Dim espacioLavado2_carroceria As Carroceria
    Dim espaciosLavadoSecado_cola = -1.0R
    Dim espaciosLavadoSecado_colaLista As List(Of Carroceria)

    Dim secadora_estado = "L"

    Dim empPA_estado = "L"
    Dim empPA_cola = -1.0R
    Dim empPA_colaLista As ArrayList

    Dim random As New Random()
    'Fin inicializacion

    Private Sub frm_desarrollo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Maximizamos ventana
        'Me.WindowState = FormWindowState.Maximized
        'Cambiamos tamaños de columnas
        col_rndLA.Width = 50
        col_rndTipo.Width = 50
        col_tentrellegLA.Width = 70
        col_hllegadaLA.Width = 70
        col_rndTipo.Width = 50
        col_tipo.Width = 70
        col_tiempoQA.Width = 50
        col_hfinQA.Width = 70

        dgv_matriz.Rows.Add(New Object() {"inicio", reloj, llegadaAuto_RND, llegadaAuto_tiempoEntreLlegadas, llegadaAuto_horaLlegada, tipoAuto_RND, tipoAuto_tipo, finQuitarAlfombra_tiempo, finQuitarAlfombra_tiempo, finAspirado_RND, finAspirado_tiempoAspirado, finAspirado_horaFin, finLavado1_RND, finLavado1_tiempoLavado, finLavado1_horaFin, finLavado2_RND, finLavado2_tiempoLavado, finLavado2_horaFin, finSecado1_numK, finSecado1_tiempoSecado, finSecado1_horaFin, finSecado2_numK, finSecado2_tiempoSecado, finSecado2_horaFin, finPonerAlfombra_tiempo, finPonerAlfombra_horaFin, empQA_estado, empQA_cola, areaAspirado_estado, areaAspirado_cola, espacioLavado1_estado, espacioLavado2_estado, espaciosLavadoSecado_cola, secadora_estado, empPA_estado, empPA_cola})
        'Do While (reloj < frm_inicio.txt_tiempoSim.Text)
        ' loop
        If (reloj = 0) Then 'primera iteracion
            determinarLlegadaAuto()
        End If

        If (reloj = llegadaAuto_horaLlegada) Then
            contadorAutos += 1
            evento = "Lleg Auto"
            'crear un auto
            Dim autoNuevo As New Automovil()
            determinarTipoAuto()
            autoNuevo.num = contadorAutos
            autoNuevo.tipo = tipoAuto_tipo
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

            'otra llegada
            determinarLlegadaAuto()
        End If

        If (reloj = finQuitarAlfombra_horaFin) Then
            evento = "Fin QA"
            Dim autoDesarmado = empQA_colaLista.First
            If (empQA_cola = 0) Then
                empQA_estado = "L"
                empQA_colaLista.Remove(empQA_colaLista.First())
                finQuitarAlfombra_horaFin = -1.0R
                finQuitarAlfombra_tiempo = -1.0R
            ElseIf (empQA_cola > 0) Then
                empQA_colaLista.Remove(empQA_colaLista.First())
                empQA_cola -= 1
                determinarFinQA()
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
            If (espacioLavado1_estado = "L" Or espacioLavado2_estado = "L") Then 'Alguno de los dos EL libres
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
            End If
            If (espacioLavado1_estado = "L" And espacioLavado2_estado = "L") Then 'Ambos EL libres, ocupamos uno aleatoriamente
                Dim numRandom = Math.Round(random.NextDouble(), 2)
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
            End If
            If (espacioLavado1_estado = "O" And espacioLavado2_estado = "O") Then 'Ambos EL ocupados, agregamos a la cola
                espaciosLavadoSecado_cola += 1
                espaciosLavadoSecado_colaLista.Add(carroceriaNueva)
                carroceriaNueva.estado = "Esperando L"
            End If
        End If

        'Dim numRandom = Math.Round(random.NextDouble(), 2) 'Usar para el evento de fin lavado
        'If (numRandom <= 0.49) Then 'EL1 Ocupado
        '    espacioLavado1_estado = "O"
        '    espacioLavado1_carroceria = carroceriaNueva
        '    determinarFinLavado1()
        'ElseIf (numRandom >= 0.5) Then 'EL2 libre
        '    espacioLavado2_estado = "O"
        '    espacioLavado2_carroceria = carroceriaNueva
        '    determinarFinLavado2()
        'End If

        If (reloj = finAspirado_horaFin) Then
            evento = "Fin AA"
            If (areaAspirado_cola = 0) Then
                areaAspirado_estado = "L"
                areaAspirado_listaCola.First.estado = "E Carroceria"
                areaAspirado_listaCola.Remove(areaAspirado_listaCola.First)
                finAspirado_horaFin = -1.0R
                finAspirado_RND = -1.0R
                finAspirado_tiempoAspirado = -1.0R
            ElseIf (areaAspirado_cola > 0) Then
                areaAspirado_cola -= 1
                areaAspirado_listaCola.First.estado = "E Carroceria"
                areaAspirado_listaCola.Remove(areaAspirado_listaCola.First)
                determinarFinAA()
            End If
        End If

        If (reloj = finLavado1_horaFin) Then
            evento = "Fin LC1"
            Dim carroceriaLavada = espacioLavado1_carroceria
            carroceriaLavada.humedad = 100.0R
            If (espaciosLavadoSecado_cola = 0) Then
                espacioLavado1_carroceria = Nothing
                finLavado1_horaFin = -1.0R
                finLavado1_RND = -1.0R
                finLavado1_tiempoLavado = -1.0R
            ElseIf (espaciosLavadoSecado_cola > 0) Then
                espaciosLavadoSecado_cola -= 1
                espacioLavado1_carroceria = espaciosLavadoSecado_colaLista.First
                espaciosLavadoSecado_colaLista.Remove(espaciosLavadoSecado_colaLista.First)
                determinarFinLavado1()
            End If

            Dim numK As Double
            If (carroceriaLavada.auto.tipo = "Pequeño") Then
                numK = 0.75R
            ElseIf (carroceriaLavada.auto.tipo = "Mediano") Then
                numK = 0.5R
            ElseIf (carroceriaLavada.auto.tipo = "PickUp") Then
                numK = 0.25R
            End If
            If (secadora_estado = "L") Then
                carroceriaLavada.estado = "Secando Maq"
                secadora_estado = "Secando 1"
                determinarFinSecadoMaquina1(carroceriaLavada.humedad, numK)
            ElseIf (secadora_estado = "Secando 2") Then
                carroceriaLavada.estado = "Secando Sola"
                determinarFinSecadoSolo1(carroceriaLavada.humedad, numK)
            End If
        End If

        If (reloj = finLavado2_horaFin) Then
            evento = "Fin LC1"
            Dim carroceriaLavada = espacioLavado2_carroceria
            carroceriaLavada.humedad = 100.0R
            If (espaciosLavadoSecado_cola = 0) Then
                espacioLavado2_carroceria = Nothing
                finLavado2_horaFin = -1.0R
                finLavado2_RND = -1.0R
                finLavado2_tiempoLavado = -1.0R
            ElseIf (espaciosLavadoSecado_cola > 0) Then
                espaciosLavadoSecado_cola -= 1
                espacioLavado2_carroceria = espaciosLavadoSecado_colaLista.First
                espaciosLavadoSecado_colaLista.Remove(espaciosLavadoSecado_colaLista.First)
                determinarFinLavado2()
            End If

            Dim numK As Double
            If (carroceriaLavada.auto.tipo = "Pequeño") Then
                numK = 0.75R
            ElseIf (carroceriaLavada.auto.tipo = "Mediano") Then
                numK = 0.5R
            ElseIf (carroceriaLavada.auto.tipo = "PickUp") Then
                numK = 0.25R
            End If
            If (secadora_estado = "L") Then
                carroceriaLavada.estado = "Secando Maq"
                secadora_estado = "Secando 2"
                determinarFinSecadoMaquina1(carroceriaLavada.humedad, numK)
            ElseIf (secadora_estado = "Secando 1") Then
                carroceriaLavada.estado = "Secando Sola"
                determinarFinSecadoSolo2(carroceriaLavada.humedad, numK)
            End If
        End If

        If (reloj = finSecado1_horaFin) Then
            If (espacioLavado1_carroceria.estado = "Secando Sola") Then 'La carroceria no tiene la maquina de secado
                espacioLavado1_carroceria.estado = "Esperando A"
            ElseIf (espacioLavado1_estado = "Secando Maq") Then 'La carroceria tiene la maquina de secado
                espacioLavado1_carroceria.estado = "Esperando A"
                If (espacioLavado2_carroceria.estado = "Secando Sola") Then 'Hay una carroceria en el otro EL secandose sola
                    secadora_estado = "Secando 2"
                    espacioLavado2_carroceria.estado = "Secando Maq"
                    'TO DO : CALCULAR LA HUMEDAD ACTUAL DE ESA CARROCERIA Y RECALCULAR TIEMPO DE SECADO PASANDO POR PARAMETRO LA HUMEDAD ACTUAL
                    'NOTA: EL ESTADO DEL 'EL' LO CAMBIAMOS UNA VEZ QUE YA SE HAYA SECADO Y NO HAYA COLA
                End If
            End If
        End If

        'calcular proximo evento
        reloj = calcularProximoEvento(reloj, llegadaAuto_horaLlegada, finQuitarAlfombra_horaFin, finAspirado_horaFin, finLavado1_horaFin, finLavado2_horaFin, finSecado1_horaFin, finSecado2_horaFin, finPonerAlfombra_horaFin)

        'sumar fila
        dgv_matriz.Rows.Add(New Object() {"inicio", reloj, llegadaAuto_RND, llegadaAuto_tiempoEntreLlegadas, llegadaAuto_horaLlegada, tipoAuto_RND, tipoAuto_tipo, finQuitarAlfombra_tiempo, finQuitarAlfombra_tiempo, finAspirado_RND, finAspirado_tiempoAspirado, finAspirado_horaFin, finLavado1_RND, finLavado1_tiempoLavado, finLavado1_horaFin, finLavado2_RND, finLavado2_tiempoLavado, finLavado2_horaFin, finSecado1_numK, finSecado1_tiempoSecado, finSecado1_horaFin, finSecado2_numK, finSecado2_tiempoSecado, finSecado2_horaFin, finPonerAlfombra_tiempo, finPonerAlfombra_horaFin, empQA_estado, empQA_cola, areaAspirado_estado, areaAspirado_cola, espacioLavado1_estado, espacioLavado2_estado, espaciosLavadoSecado_cola, secadora_estado, empPA_estado, empPA_cola})
    End Sub

    Private Sub determinarFinSecadoMaquina1(humedad As Double, numK As Double)
        Dim tiempoInicial As Double
        Dim humedadInicial As Double
        Dim tiempoSiguiente As Double
        Dim humedadSiguiente As Double
        Dim h = 0.01R

        tiempoInicial = 0.0R
        humedadInicial = humedad
        Do While (humedad > Math.Round(0.0R, 2))
            tiempoSiguiente += h
            humedadSiguiente = humedadInicial + h * ((-Math.Pow(tiempoInicial, 2)) + 2.0R * humedadInicial - 200.0R)
            tiempoInicial = tiempoSiguiente
            humedadInicial = humedadSiguiente
        Loop
        finSecado1_numK = numK
        finSecado1_tiempoSecado = tiempoInicial
        finSecado1_horaFin = reloj + tiempoInicial
    End Sub

    Private Sub determinarFinSecadoSolo1(humedad As Double, numK As Double)
        Dim tiempoInicial As Double
        Dim humedadInicial As Double
        Dim tiempoSiguiente As Double
        Dim humedadSiguiente As Double
        Dim h = 0.01R

        tiempoInicial = 0.0R
        humedadInicial = humedad
        Do While (humedad > Math.Round(0.0R, 2))
            tiempoSiguiente += h
            humedadSiguiente = humedadInicial + h * (-numK * humedadInicial)
            tiempoInicial = tiempoSiguiente
            humedadInicial = humedadSiguiente
        Loop
        finSecado1_numK = numK
        finSecado1_tiempoSecado = tiempoInicial
        finSecado1_horaFin = reloj + tiempoInicial
    End Sub

    Private Sub determinarFinSecadoMaquina2(humedad As Double, numK As Double)
        Dim tiempoInicial As Double
        Dim humedadInicial As Double
        Dim tiempoSiguiente As Double
        Dim humedadSiguiente As Double
        Dim h = 0.01R

        tiempoInicial = 0.0R
        humedadInicial = humedad
        Do While (humedad > Math.Round(0.0R, 2))
            tiempoSiguiente += h
            humedadSiguiente = humedadInicial + h * ((-Math.Pow(tiempoInicial, 2)) + 2.0R * humedadInicial - 200.0R)
            tiempoInicial = tiempoSiguiente
            humedadInicial = humedadSiguiente
        Loop
        finSecado2_numK = numK
        finSecado2_tiempoSecado = tiempoInicial
        finSecado2_horaFin = reloj + tiempoInicial
    End Sub

    Private Sub determinarFinSecadoSolo2(humedad As Double, numK As Double)
        Dim tiempoInicial As Double
        Dim humedadInicial As Double
        Dim tiempoSiguiente As Double
        Dim humedadSiguiente As Double
        Dim h = 0.01R

        tiempoInicial = 0.0R
        humedadInicial = humedad
        Do While (humedad > Math.Round(0.0R, 2))
            tiempoSiguiente += h
            humedadSiguiente = humedadInicial + h * (-numK * humedadInicial)
            tiempoInicial = tiempoSiguiente
            humedadInicial = humedadSiguiente
        Loop
        finSecado2_numK = numK
        finSecado2_tiempoSecado = tiempoInicial
        finSecado2_horaFin = reloj + tiempoInicial
    End Sub

    Private Sub determinarFinAA()
        finAspirado_RND = Math.Round(random.NextDouble(), 2)
        finAspirado_tiempoAspirado = finAspirado_RND * 2 + 3
        finAspirado_horaFin = reloj + finAspirado_horaFin
    End Sub

    Private Sub determinarFinLavado1()
        finLavado1_RND = Math.Round(random.NextDouble(), 2)
        finLavado1_tiempoLavado = finLavado1_RND * 6 + 6
        finLavado1_horaFin = reloj + finLavado1_tiempoLavado
    End Sub

    Private Sub determinarFinLavado2()
        finLavado2_RND = Math.Round(random.NextDouble(), 2)
        finLavado2_tiempoLavado = finLavado2_RND * 6 + 6
        finLavado2_horaFin = reloj + finLavado2_tiempoLavado
    End Sub

    Private Sub determinarLlegadaAuto()
        llegadaAuto_RND = Math.Round(random.NextDouble(), 2)
        llegadaAuto_tiempoEntreLlegadas = (-10 * Math.Log(1 - llegadaAuto_RND))
        llegadaAuto_horaLlegada = reloj + llegadaAuto_tiempoEntreLlegadas
    End Sub

    Private Sub determinarFinQA()
        finQuitarAlfombra_tiempo = 2
        finQuitarAlfombra_horaFin = reloj + 2
    End Sub

    Private Sub determinarTipoAuto()
        tipoAuto_RND = Math.Round(random.NextDouble(), 2)
        If (tipoAuto_RND >= 0 And tipoAuto_RND <= 19) Then
            tipoAuto_tipo = "Pequeño"
        ElseIf (tipoAuto_RND >= 20 And tipoAuto_RND <= 69) Then
            tipoAuto_tipo = "Mediano"
        ElseIf (tipoAuto_RND >= 70 And tipoAuto_RND <= 99) Then
            tipoAuto_tipo = "PickUp"
        End If
    End Sub

    Private Function calcularProximoEvento(reloj As Double, llegadaAuto As Double, finQA As Double, finAA As Double, finLavado1 As Double, finLavado2 As Double, finSecado1 As Double, finSecado2 As Double, finPA As Double) As Double
        'llegadaCliente = 0, finAtencionAprendiz = 1, finAtencionVeteA = 2, finAtencionVeteB = 3
        Dim resultado As Double = 0
        Dim vectorTiemposEventos(7) As Double
        vectorTiemposEventos(0) = llegadaAuto
        vectorTiemposEventos(1) = finQA
        vectorTiemposEventos(2) = finAA
        vectorTiemposEventos(3) = finLavado1
        vectorTiemposEventos(4) = finLavado2
        vectorTiemposEventos(5) = finSecado1
        vectorTiemposEventos(6) = finSecado2
        vectorTiemposEventos(7) = finPA
        Array.Sort(vectorTiemposEventos)
        If (vectorTiemposEventos(0) <> 0 And reloj < vectorTiemposEventos(0)) Then
            resultado = vectorTiemposEventos(0)
        ElseIf (vectorTiemposEventos(1) <> 0 And reloj < vectorTiemposEventos(1)) Then
            resultado = vectorTiemposEventos(1)
        ElseIf (vectorTiemposEventos(2) <> 0 And reloj < vectorTiemposEventos(2)) Then
            resultado = vectorTiemposEventos(2)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(3)) Then
            resultado = vectorTiemposEventos(3)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(4)) Then
            resultado = vectorTiemposEventos(4)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(5)) Then
            resultado = vectorTiemposEventos(5)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(6)) Then
            resultado = vectorTiemposEventos(6)
        ElseIf (vectorTiemposEventos(3) <> 0 And reloj < vectorTiemposEventos(7)) Then
            resultado = vectorTiemposEventos(7)
        End If
        Return resultado
    End Function

End Class
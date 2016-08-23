Public Class frm_inicio
    Public tiempoSimulacion As Double

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (datosValidos()) Then
            tiempoSimulacion = txt_tiempoSim.Text
            frm_desarrollo.Show()
        End If
    End Sub

    Private Sub txt_tiempoSim_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_tiempoSim.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
        If (e.KeyChar = ".") Then
            For Each letter As Char In txt_tiempoSim.Text
                If (letter = ".") Then
                    e.Handled = True
                End If
            Next
        End If
    End Sub

    Private Sub txt_desde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_desde.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
        If (e.KeyChar = ".") Then
            For Each letter As Char In txt_desde.Text
                If (letter = ".") Then
                    e.Handled = True
                End If
            Next
        End If
    End Sub


    Private Sub txt_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_hasta.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If
        If (e.KeyChar = ".") Then
            For Each letter As Char In txt_hasta.Text
                If (letter = ".") Then
                    e.Handled = True
                End If
            Next
        End If
    End Sub

    Private Function datosValidos() As Boolean

        Dim mensajes As String = ""
        If txt_tiempoSim.Text = "" Then
            mensajes += "El tiempo de simulación no puede estar vacío"
        End If
        If txt_desde.Text = "" Then
            mensajes += vbCrLf + "El tiempo 'desde' no puede estar vacío"
        End If
        If txt_hasta.Text = "" Then
            mensajes += vbCrLf + "El tiempo 'hasta' no puede estar vacío"
        End If
        If (txt_desde.Text <> "" And txt_hasta.Text <> "") Then
            If (Convert.ToDouble(txt_desde.Text) >= Convert.ToDouble(txt_hasta.Text)) Then
                mensajes += vbCrLf + "El tiempo 'desde' debe ser menor al tiempo 'hasta'"
            End If
        End If
        If (txt_hasta.Text <> "" And txt_desde.Text <> "" And txt_tiempoSim.Text <> "") Then
            Dim hasta = Convert.ToDouble(txt_hasta.Text)
            Dim desde = Convert.ToDouble(txt_desde.Text)
            If ((hasta - desde) > Convert.ToDouble(txt_tiempoSim.Text)) Then
                mensajes += vbCrLf + "El intervalo no puede ser mayor al tiempo de simulación"
            End If
        End If
        If mensajes = "" Then
            lbl_mensajes.Text = ""
            Return True
        ElseIf mensajes <> "" Then
            lbl_mensajes.Text = mensajes
        End If
        Return False
    End Function

End Class

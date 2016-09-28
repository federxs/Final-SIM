Public Class frm_inicio
    Public tiempoSimulacion As Double, tiempoDesde As Double, tiempoHasta As Double

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click
        If (datosValidos()) Then
            tiempoSimulacion = Convert.ToDouble(txt_tiempoSim.Text)
            tiempoHasta = Convert.ToDouble(txt_hasta.Text)
            tiempoDesde = Convert.ToDouble(txt_desde.Text)
            frm_desarrollo.Show()
        End If
    End Sub

    Private Sub txt_tiempoSim_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_tiempoSim.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",")
        End If
        If (txt_tiempoSim.Text.Length <> 0 And txt_tiempoSim.Text.Contains(","c)) Then
            Dim split As String() = txt_tiempoSim.Text.Split(","c)
            If (split(1).Length >= 4 And (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",")) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar = ",") Then
            For Each letter As Char In txt_tiempoSim.Text
                If (letter = ",") Then
                    e.Handled = True
                End If
            Next
        End If
    End Sub

    Private Sub txt_desde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_desde.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",")
        End If
        If (txt_desde.Text.Length <> 0 And txt_desde.Text.Contains(","c)) Then
            Dim split As String() = txt_desde.Text.Split(","c)
            If (split(1).Length >= 4 And (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",")) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar = ",") Then
            For Each letter As Char In txt_desde.Text
                If (letter = ",") Then
                    e.Handled = True
                End If
            Next
        End If
    End Sub


    Private Sub txt_hasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_hasta.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",")
        End If
        If (txt_hasta.Text.Length <> 0 And txt_hasta.Text.Contains(","c)) Then
            Dim split As String() = txt_hasta.Text.Split(","c)
            If (split(1).Length >= 4 And (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",")) Then
                e.Handled = True
            End If
        End If
        If (e.KeyChar = ",") Then
            For Each letter As Char In txt_hasta.Text
                If (letter = ",") Then
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
        If (txt_desde.Text <> "" And txt_hasta.Text <> "" And txt_tiempoSim.Text <> "") Then
            If (Convert.ToDouble(txt_desde.Text) >= Convert.ToDouble(txt_hasta.Text)) Then
                mensajes += vbCrLf + "El tiempo 'desde' debe ser menor al tiempo 'hasta'"
            End If
            If (Convert.ToDouble(txt_hasta.Text) > Convert.ToDouble(txt_tiempoSim.Text)) Then
                mensajes += vbCrLf + "El tiempo 'hasta' debe ser menor al tiempo de simulación"
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

    Private Sub btn_consigna_Click(sender As Object, e As EventArgs) Handles btn_consigna.Click
        frm_consigna.Show()
    End Sub

End Class

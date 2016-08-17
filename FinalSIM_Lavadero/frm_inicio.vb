Public Class frm_inicio
    Public tiempoSimulacion As Double

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tiempoSimulacion = txt_tiempoSim.Text
        frm_desarrollo.Show()
    End Sub

End Class

Public Class frm_inicio

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_desarrollo.Show()
    End Sub

    Private Sub frm_inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frm_desarrollo.Show()
    End Sub
End Class

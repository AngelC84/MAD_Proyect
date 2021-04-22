Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Prueba As New EnlaceBD
        Prueba.Test()

    End Sub
    Private Sub Close_Login_Click(sender As Object, e As EventArgs) Handles Close_Login.Click
        Me.Close()
    End Sub
End Class

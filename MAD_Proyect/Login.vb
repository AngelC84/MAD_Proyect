Public Class Login
    Public Property Modo As Boolean
    Public Property RFC_EMP As String

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Prueba As New EnlaceBD
        ComboBox1.SelectedIndex = 0
        Prueba.Test()

    End Sub
    Private Sub Close_Login_Click(sender As Object, e As EventArgs) Handles Close_Login.Click
        Me.Close()
    End Sub

    Private Sub INGRESAR_LOG_Click(sender As Object, e As EventArgs) Handles INGRESAR_LOG.Click
        Dim enlace As New EnlaceBD
        Dim Nombre_Usuario As String
        Dim Contraseña As String
        Dim result As Integer

        If (TextBox_Contraseña.Text <> "") And
           (TextBox_Usuario.Text <> "") Then

            Contraseña = TextBox_Contraseña.Text
            Nombre_Usuario = TextBox_Usuario.Text

            result = enlace.LOGIN(Nombre_Usuario, Contraseña)
            If (result = 1) Then

                If (ComboBox1.SelectedIndex = 0) Then

                    If (3 = enlace.LOGINPermiso(Nombre_Usuario)) Then
                        Administrador.Show()
                        Me.Close()
                    Else
                        MsgBox("No es tu sesion, !!ACCESO DENEGADO!!")
                    End If

                ElseIf (ComboBox1.SelectedIndex = 1) Then

                    If (2 = enlace.LOGINPermiso(Nombre_Usuario)) Then
                        Dim aux As String
                        'aux = enlace.Getrfcemp(email_emp)
                        EmpleadoGral.CURP = enlace.GetEmpleadoGral(Nombre_Usuario)
                        aux = EmpleadoGral.CURP
                        EmpleadoGral.Show()
                        Me.Hide()
                        ' Me.Close()
                    Else
                        MsgBox("No es tu sesion, !!ACCESO DENEGADO!!")
                    End If

                ElseIf (ComboBox1.SelectedIndex = 2) Then
                    If (enlace.LOGINPermiso(Nombre_Usuario) = 1) Then
                        Pago_de_Recibos.CURP = enlace.LOGINCliente(Nombre_Usuario)
                        Pago_de_Recibos.Show()
                        Me.Hide()
                        'Me.Close()
                    Else
                        MsgBox("No es tu sesion, !!ACCESO DENEGADO!!")
                    End If
                End If
            Else
                MsgBox("Usuario y/o Contraseña incorrectos, !!ACCESO DENEGADO!!")
            End If

        Else
            MsgBox("Faltan campos por llenar, !!ACCESO DENEGADO!!")
        End If
    End Sub
End Class

Imports System.IO

Public Class Login
    Public Property Modo As Boolean
    Public Property RFC_EMP As String
    Public Property Intentos_Login As New Dictionary(Of String, Integer)

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Prueba As New EnlaceBD
        ComboBox1.SelectedIndex = 0
        Prueba.Test()
        Dim Datos As String() = LeerUsuarioGuardado()
        TextBox_Usuario.Text = Datos(0)
        TextBox_Contraseña.Text = Datos(1)

    End Sub

    Private Sub Close_Login_Click(sender As Object, e As EventArgs) Handles Close_Login.Click
        Me.Close()
    End Sub

    Private Sub Recordar_Contraseña(Nombre_Usuario As String, Contrasena As String)
        Using writer As StreamWriter = New StreamWriter("Guardar.txt")
            writer.WriteLine(Nombre_Usuario)
            writer.WriteLine(Contrasena)
        End Using
    End Sub


    Private Function LeerUsuarioGuardado() As String()
        Dim Datos As New List(Of String)

        Using reader As StreamReader = New StreamReader("Guardar.txt")
            While reader.Peek >= 0
                Datos.Add(reader.ReadLine())
            End While

        End Using
        Return Datos.ToArray

    End Function

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
                        If (CheckBox_RecordarCont.Checked) Then
                            Recordar_Contraseña(Nombre_Usuario, Contraseña)
                        End If

                        Administrador.Show()
                            Me.Hide()
                        Else
                            MsgBox("No es tu sesion, !!ACCESO DENEGADO!!")
                    End If

                ElseIf (ComboBox1.SelectedIndex = 1) Then

                    If (2 = enlace.LOGINPermiso(Nombre_Usuario)) Then

                        If (enlace.GetEmpleadInActivLogin(Nombre_Usuario) = 1) Then

                            If (CheckBox_RecordarCont.Checked) Then
                                Recordar_Contraseña(Nombre_Usuario, Contraseña)
                            End If
                            Dim aux As String
                            'aux = enlace.Getrfcemp(email_emp)
                            EmpleadoGral.CURP = enlace.GetEmpleadoGral(Nombre_Usuario)
                            aux = EmpleadoGral.CURP
                            EmpleadoGral.Show()
                            Me.Hide()
                        Else
                            MsgBox("El usuario a sido Bloqueado o Eliminado, !!ACCESO DENEGADO!!")

                        End If

                    Else
                        MsgBox("No es tu sesion, !!ACCESO DENEGADO!!")
                    End If

                ElseIf (ComboBox1.SelectedIndex = 2) Then
                    If (enlace.LOGINPermiso(Nombre_Usuario) = 1) Then

                        If (enlace.GetClienteInActivLogin(Nombre_Usuario) = 1) Then
                            If (CheckBox_RecordarCont.Checked) Then
                                Recordar_Contraseña(Nombre_Usuario, Contraseña)
                            End If

                            Pago_de_Recibos.CURP = enlace.LOGINCliente(Nombre_Usuario)
                            Pago_de_Recibos.Show()
                            Me.Hide()
                        Else
                            MsgBox("El usuario a sido Bloqueado o Eliminado, !!ACCESO DENEGADO!!")
                        End If

                    Else
                        MsgBox("No es tu sesion, !!ACCESO DENEGADO!!")
                    End If
                End If
            Else

                If (result = 3) Then

                    If (Intentos_Login.ContainsKey(Nombre_Usuario)) Then
                        Intentos_Login(Nombre_Usuario) += 1
                        If (Intentos_Login.Item(Nombre_Usuario) = 3) Then
                            enlace.DesactivarUsuario(Nombre_Usuario)
                        End If
                    Else
                        Intentos_Login.Add(Nombre_Usuario, 1)
                    End If
                End If
                MsgBox("Usuario y/o Contraseña incorrectos, !!ACCESO DENEGADO!!")
            End If

        Else
            MsgBox("Faltan campos por llenar, !!ACCESO DENEGADO!!")
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class

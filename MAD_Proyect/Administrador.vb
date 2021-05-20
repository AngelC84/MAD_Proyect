Public Class Administrador

    Private Property tablaempl As New DataTable
    Private Property tablaInAct As New DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

        Dim enlace As New EnlaceBD
        'Dim tablaempl As New DataTable
        Dim Activo_Empl As String
        Dim Index As Integer

        Activo_Empl = ListBox2.DataSource.Rows(ListBox2.SelectedIndex).Item(0)
        tablaInAct = enlace.GetEmpleadInactiv()

        Index = ListBox2.SelectedIndex

    End Sub

    Private Sub TextBox_Nombre_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Nombre.TextChanged

    End Sub

    Private Sub TextBox_Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Nombre.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button_Alta_Click(sender As Object, e As EventArgs) Handles Button_Alta.Click

        Dim enlace As New EnlaceBD

        Dim ger As Integer

        Dim CURP As String
        Dim fecha_nac As Date
        Dim Nombre As String
        Dim RFC As String
        Dim Fecha_Alta_Mod As Date
        Dim Nomb_Us As String
        Dim Cont_Us As String

        Dim result As Boolean = False


        If (TextBox_CURP.Text <> "") And (TextBox_Nombre.Text <> "") And (TextBox_RFC.Text <> "") And (TextBox_NombUS.Text <> "") And (TextBox_ContUS.Text <> "") Then

            ger = 0

            CURP = TextBox_CURP.Text
            fecha_nac = DateTimePicker1.Value
            Nombre = TextBox_Nombre.Text
            RFC = TextBox_RFC.Text
            Fecha_Alta_Mod = DateTimePicker2.Value
            Nomb_Us = TextBox_NombUS.Text
            Cont_Us = TextBox_ContUS.Text

            result = enlace.Reg_Empleado(CURP, fecha_nac, Nombre, RFC, Fecha_Alta_Mod, Nomb_Us, Cont_Us)

        Else
            MsgBox("Faltan datos por registrar, !!REVISA!!")
        End If


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim enlace As New EnlaceBD
        'Dim tablaempl As New DataTable
        Dim CURP_Empleado As String
        Dim Index As Integer

        CURP_Empleado = ListBox1.DataSource.Rows(ListBox1.SelectedIndex).Item(0)
        tablaempl = enlace.getdataEmplead()


        Index = ListBox1.SelectedIndex

        If (tablaempl.Rows.Count > 0) Then
            TextBox_CURP.Text = tablaempl.Rows(Index).Item(0)
            DateTimePicker1.Value = tablaempl.Rows(Index).Item(1)
            TextBox_Nombre.Text = tablaempl.Rows(Index).Item(2)
            TextBox_RFC.Text = tablaempl.Rows(Index).Item(3)
            DateTimePicker2.Value = tablaempl.Rows(Index).Item(4)
            TextBox_NombUS.Text = tablaempl.Rows(Index).Item(5)
            TextBox_ContUS.Text = tablaempl.Rows(Index).Item(6)
        End If


        ' ListBox1.DataSource = tablaempl  Cuando se requiere actualizar la lista en momento
        ' ListBox1.DisplayMember = "Nombre"
        ' ListBox1.ValueMember = "CURP"


    End Sub

    Private Sub Administrador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim enlace As New EnlaceBD
        Dim tablaaux As New DataTable
        Dim tablaInAct As New DataTable


        tablaaux = enlace.getdataEmplead()
        If (tablaaux.Rows.Count > 0) Then
            ListBox1.DataSource = tablaaux
            ListBox1.DisplayMember = "Nombre"
            ListBox1.ValueMember = "CURP"
        End If

        tablaInAct = enlace.GetEmpleadInactiv()
        If (tablaInAct.Rows.Count > 0) Then
            ListBox2.DataSource = tablaInAct
            ListBox2.DisplayMember = "Nombre"
        End If


    End Sub


    Private Sub Button_UPD_Click(sender As Object, e As EventArgs) Handles Button_UPD.Click

        Dim enlace As New EnlaceBD

        Dim ger As Integer

        Dim CURP As String
        Dim fecha_nac As Date
        Dim Nombre As String
        Dim RFC As String
        Dim Fecha_Alta_Mod As Date
        Dim Cont_Us As String

        Dim result As Boolean = False
        Dim Empleado As Integer = 0

        If (TextBox_CURP.Text <> "") And (TextBox_Nombre.Text <> "") And (TextBox_RFC.Text <> "") And (TextBox_NombUS.Text <> "") And (TextBox_ContUS.Text <> "") Then

            ger = 0

            Nombre = ListBox1.DataSource.Rows(ListBox1.SelectedIndex).Item(0)


            CURP = TextBox_CURP.Text
            fecha_nac = DateTimePicker1.Value
            Nombre = TextBox_Nombre.Text
            RFC = TextBox_RFC.Text
            Fecha_Alta_Mod = DateTimePicker2.Value
            Cont_Us = TextBox_ContUS.Text


            result = enlace.Upd_Empleado(CURP, fecha_nac, Nombre, RFC, Fecha_Alta_Mod, Cont_Us)

        Else
            MsgBox("Faltan datos por registrar, !!REVISA!!")
        End If



    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim enlace As New EnlaceBD
        Dim Nombre As String

        Dim result As Boolean = False

        Nombre = ListBox2.DataSource.Rows(ListBox2.SelectedIndex).Item(0)
        result = enlace.Activar_Empleado(Nombre)

    End Sub

    Private Sub TextBox_RFC_TextChanged(sender As Object, e As EventArgs) Handles TextBox_RFC.TextChanged
        TextBox_RFC.MaxLength = 13
    End Sub

    Private Sub TextBox_CURP_TextChanged(sender As Object, e As EventArgs) Handles TextBox_CURP.TextChanged
        TextBox_CURP.MaxLength = 18
    End Sub
End Class
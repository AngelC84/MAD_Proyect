Public Class EmpleadoGral

    'Public Property Modo As Boolean
    Private Property tablacliente As New DataTable
    Private Property tablaInAct As New DataTable

    Public Property CURP As String

    Private Sub Boton_Contratos_Click(sender As Object, e As EventArgs) Handles Boton_Contratos.Click
        ' Contratos.Modo = True
        Contratos.Show()
        Me.Hide()

    End Sub

    Private Sub Boton_Cargas_Click(sender As Object, e As EventArgs) Handles Boton_Cargas.Click
        ' Contratos.Modo = True
        Cargas.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_ReporteTarifasyConsum_Click(sender As Object, e As EventArgs) Handles Boton_ReporteTarifasyConsum.Click
        ' Contratos.Modo = True
        Reporte_Tarifas_y_Consumos.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_ReporteGeneral_Click(sender As Object, e As EventArgs) Handles Boton_ReporteGeneral.Click
        ' Contratos.Modo = True
        Reporte_General.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_ConsumoHistorico_Click(sender As Object, e As EventArgs) Handles Boton_ConsumoHistorico.Click
        ' Contratos.Modo = True
        Consumo_Historico.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_GenerarReciboyConsulta_Click(sender As Object, e As EventArgs) Handles Boton_GenerarReciboyConsulta.Click
        ' Contratos.Modo = True
        GenerarReciboyConsulta.Show()
        Me.Hide()
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

    Private Sub TextBox_Medidor_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_NumServic_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox_NumServic_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub EmpleadoGral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim enlace As New EnlaceBD
        Dim tablaaux As New DataTable
        Dim tablaInAct As New DataTable

        tablaaux = enlace.getdataCliente()
        If (tablaaux.Rows.Count > 0) Then
            ListBox_Clientes.DataSource = tablaaux
            ListBox_Clientes.DisplayMember = "Nombre"
            ListBox_Clientes.ValueMember = "CURP"
        End If

        tablaInAct = enlace.GetClienteInactiv()
        If (tablaInAct.Rows.Count > 0) Then
            ListBox2.DataSource = tablaInAct
            ListBox2.DisplayMember = "Nombre"
        End If

    End Sub

    Private Sub Button_Alta_Cliente_Click(sender As Object, e As EventArgs) Handles Button_Alta_Cliente.Click
        Dim enlace As New EnlaceBD

        Dim ger As Integer

        Dim CURP As String
        Dim fecha_nac As Date
        Dim Nombre As String
        Dim Fecha_Alta_Mod As Date
        Dim Genero As String
        Dim email As String
        Dim Nomb_Us As String
        Dim Cont_Us As String

        Dim result As Boolean = False


        If (TextBox_CURP.Text <> "") And (TextBox_Nombre.Text <> "") And (ComboBox_Genero.SelectedIndex > -1) And (TextBox_email.Text <> "") And (TextBox_Usuario.Text <> "") And (TextBox_Contra.Text <> "") Then

            ger = 0

            CURP = TextBox_CURP.Text
            fecha_nac = DateTimePicker1.Value
            Nombre = TextBox_Nombre.Text
            Fecha_Alta_Mod = DateTimePicker2.Value
            Genero = ComboBox_Genero.SelectedItem
            email = TextBox_email.Text
            Nomb_Us = TextBox_Usuario.Text
            Cont_Us = TextBox_Contra.Text

            result = enlace.Reg_Cliente(CURP, fecha_nac, Nombre, Fecha_Alta_Mod, Genero, email, Nomb_Us, Cont_Us)
            MsgBox("Creado exitosamente")
        Else
            MsgBox("Faltan datos por registrar, !!REVISA!!")
        End If
    End Sub

    Private Sub ListBox_Clientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Clientes.SelectedIndexChanged
        Dim enlace As New EnlaceBD
        Dim CURP_Cliente As String
        Dim Index As Integer

        CURP_Cliente = ListBox_Clientes.DataSource.Rows(ListBox_Clientes.SelectedIndex).Item(0)
        tablacliente = enlace.getdataCliente()

        Index = ListBox_Clientes.SelectedIndex

        If (tablacliente.Rows.Count > 0) Then

            TextBox_CURP.Text = tablacliente.Rows(Index).Item(0)
            DateTimePicker1.Value = tablacliente.Rows(Index).Item(1)
            TextBox_Nombre.Text = tablacliente.Rows(Index).Item(2)
            DateTimePicker2.Value = tablacliente.Rows(Index).Item(3)
            ComboBox_Genero.SelectedIndex = ComboBox_Genero.FindStringExact(tablacliente.Rows(Index).Item(4).ToString())
            TextBox_email.Text = tablacliente.Rows(Index).Item(5)
            TextBox_Usuario.Text = tablacliente.Rows(Index).Item(6)
            TextBox_Contra.Text = tablacliente.Rows(Index).Item(7)

        End If

    End Sub

    Private Sub Button_Upd_Cliente_Click(sender As Object, e As EventArgs) Handles Button_Upd_Cliente.Click

        Dim enlace As New EnlaceBD
        Dim ger As Integer

        Dim CURP As String
        Dim fecha_nac As Date
        Dim Nombre As String
        Dim Fecha_Alta_Mod As Date
        Dim Genero As String
        Dim email As String
        Dim Cont_Us As String

        Dim result As Boolean = False
        Dim Empleado As Integer = 0

        If (TextBox_CURP.Text <> "") And (TextBox_Nombre.Text <> "") And (ComboBox_Genero.SelectedIndex > -1) And (TextBox_email.Text <> "") And (TextBox_Usuario.Text <> "") And (TextBox_Contra.Text <> "") Then

            ger = 0

            Nombre = ListBox_Clientes.DataSource.Rows(ListBox_Clientes.SelectedIndex).Item(0)

            CURP = TextBox_CURP.Text
            fecha_nac = DateTimePicker1.Value
            Nombre = TextBox_Nombre.Text
            Fecha_Alta_Mod = DateTimePicker2.Value
            Genero = ComboBox_Genero.SelectedItem
            email = TextBox_email.Text
            Cont_Us = TextBox_Contra.Text


            result = enlace.Upd_Cliente(CURP, fecha_nac, Nombre, Fecha_Alta_Mod, Genero, email, Cont_Us)

        Else
            MsgBox("Faltan datos por registrar, !!REVISA!!")
        End If

    End Sub

    Private Sub Button_Bajas_Cliente_Click(sender As Object, e As EventArgs) Handles Button_Bajas_Cliente.Click
        Dim enlace As New EnlaceBD
        Dim CURP As String

        Dim result As Boolean = False

        'Nombre = ListBox_Clientes.DataSource.Rows(ListBox_Clientes.SelectedIndex).Item(0)

        CURP = ListBox_Clientes.SelectedValue


        If (Windows.Forms.DialogResult.Yes = MsgBox("Seguro quieres eliminar este Cliente, Se eliminaran toda su infromacion", MessageBoxButtons.YesNo)) Then

            result = enlace.Eliminar_Cliente(CURP)
        Else
            MsgBox("Operacion Cancelada")

        End If

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Dim enlace As New EnlaceBD
        'Dim tablaempl As New DataTable
        Dim Activo_Clien As String
        Dim Index As Integer

        Activo_Clien = ListBox2.DataSource.Rows(ListBox2.SelectedIndex).Item(0)
        tablaInAct = enlace.GetClienteInactiv()

        Index = ListBox2.SelectedIndex
    End Sub

    Private Sub Button_Desbloqueo_Click(sender As Object, e As EventArgs) Handles Button_Desbloqueo.Click
        Dim enlace As New EnlaceBD
        Dim Nombre As String

        Dim result As Boolean = False

        Nombre = ListBox2.DataSource.Rows(ListBox2.SelectedIndex).Item(0)
        result = enlace.ClienteActivo(Nombre)

        MsgBox("Operacion completada")
    End Sub

    Private Sub TextBox_Nombre_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Nombre.TextChanged

    End Sub

    Private Sub TextBox_CURP_TextChanged(sender As Object, e As EventArgs) Handles TextBox_CURP.TextChanged
        TextBox_CURP.MaxLength = 18

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
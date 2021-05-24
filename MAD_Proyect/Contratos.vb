Public Class Contratos


    Private Property tablaInAct As New DataTable



    Private Sub Gestion_Boton_Click(sender As Object, e As EventArgs) Handles Gestion_Boton.Click
        EmpleadoGral.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_Cargas_Click(sender As Object, e As EventArgs) Handles Boton_Cargas.Click
        Cargas.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_GenerarReciboyConsulta_Click(sender As Object, e As EventArgs) Handles Boton_GenerarReciboyConsulta.Click
        GenerarReciboyConsulta.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_ReporteTarifasyConsum_Click(sender As Object, e As EventArgs) Handles Boton_ReporteTarifasyConsum.Click
        Reporte_Tarifas_y_Consumos.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_ReporteGeneral_Click(sender As Object, e As EventArgs) Handles Boton_ReporteGeneral.Click
        Reporte_General.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_ConsumoHistorico_Click(sender As Object, e As EventArgs) Handles Boton_ConsumoHistorico.Click
        Consumo_Historico.Show()
        Me.Hide()
    End Sub



    Private Sub Contratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim enlace As New EnlaceBD
        Dim tablaaux As New DataTable

        tablaaux = enlace.getdataCliente()
        If (tablaaux.Rows.Count > 0) Then
            ListBox_Cliente.DataSource = tablaaux
            ListBox_Cliente.DisplayMember = "CURP"
            'ListBox_Cliente.DisplayMember = "Nombre"
            'ListBox_Cliente.ValueMember = "CURP"

        End If
    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim enlace As New EnlaceBD
        Dim Cliente As String
        Dim Servicio As Integer
        Dim Domicilio As String
        Dim Fecha As Date
        Dim result As Boolean = False

        If (TextBox_Domicilio.Text <> "") And (ListBox_Cliente.SelectedIndex > -1) Then


            Cliente = ListBox_Cliente.GetItemText(ListBox_Cliente.SelectedItem)


            ' ListBox_Cliente.ValueMember
            Servicio = ComboBox2.SelectedIndex
            Domicilio = TextBox_Domicilio.Text
            Fecha = DateTimePicker2.Value

            result = enlace.Reg_Contrato(Cliente, Servicio, Domicilio, Fecha)
            MsgBox("Creado exitosamente")
        Else
            MsgBox("Faltan datos por registrar, !!REVISA!!")
        End If



    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


End Class
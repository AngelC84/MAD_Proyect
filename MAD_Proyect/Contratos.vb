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

    Private Sub TextBox_Domicilio_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Domicilio.TextChanged

    End Sub

    Private Sub Contratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim enlace As New EnlaceBD
        Dim tablaInAct As New DataTable
        Dim tablaaux As New DataTable

        tablaInAct = enlace.GetClienteInactiv()
        If (tablaInAct.Rows.Count > 0) Then
            ListBox2.DataSource = tablaInAct
            ListBox2.DisplayMember = "Nombre"
        End If

        tablaaux = enlace.getdataCliente()
        If (tablaaux.Rows.Count > 0) Then
            ListBox_Cliente.DataSource = tablaaux
            ListBox_Cliente.DisplayMember = "Nombre"
            ListBox_Cliente.ValueMember = "CURP"
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

    End Sub
End Class
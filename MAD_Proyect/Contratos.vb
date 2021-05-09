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
        Dim tablaaux As New DataTable

        tablaaux = enlace.getdataCliente()
        If (tablaaux.Rows.Count > 0) Then
            ListBox_Cliente.DataSource = tablaaux
            ListBox_Cliente.DisplayMember = "Nombre"
            ListBox_Cliente.ValueMember = "CURP"
        End If
    End Sub



End Class
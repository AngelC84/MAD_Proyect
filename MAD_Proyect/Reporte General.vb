Public Class Reporte_General
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Button_Gestion_Click(sender As Object, e As EventArgs) Handles Button_Gestion.Click
        EmpleadoGral.Show()
        Me.Hide()
    End Sub

    Private Sub Button_Contratos_Click(sender As Object, e As EventArgs) Handles Button_Contratos.Click
        Contratos.Show()
        Me.Hide()
    End Sub

    Private Sub Button_Cargas_Click(sender As Object, e As EventArgs) Handles Button_Cargas.Click
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

    Private Sub Boton_ConsumoHistorico_Click(sender As Object, e As EventArgs) Handles Boton_ConsumoHistorico.Click
        Consumo_Historico.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim enlace As New EnlaceBD
        Dim tabla As New DataTable
        tabla = enlace.getRecibos
        DataGridView1.DataSource = tabla
    End Sub
End Class
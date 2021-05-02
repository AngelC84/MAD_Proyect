Public Class Reporte_Tarifas_y_Consumos
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

    Private Sub Boton_ReporteGeneral_Click(sender As Object, e As EventArgs) Handles Boton_ReporteGeneral.Click
        Reporte_General.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_ConsumoHistorico_Click(sender As Object, e As EventArgs) Handles Boton_ConsumoHistorico.Click
        Consumo_Historico.Show()
        Me.Hide()
    End Sub

    Private Sub Reporte_Tarifas_y_Consumos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim enlace As New EnlaceBD
        Dim anios As New List(Of Integer)
        Dim aniosconsul As New List(Of Integer)


        For anio As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year
            anios.Add(anio)
        Next anio

        ComboBox3.DataSource = anios
        DataGridView_Tarifa.AllowUserToAddRows = False
        DataGridView_Tarifa.AllowUserToAddRows = False

        For anio As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year
            aniosconsul.Add(anio)
        Next anio

        ComboBox1.DataSource = aniosconsul
        DataGridView_Consumo.AllowUserToAddRows = False
        DataGridView_Consumo.AllowUserToAddRows = False

    End Sub

    Private Sub Button_Consul_Tarifa_Click(sender As Object, e As EventArgs) Handles Button_Consul_Tarifa.Click
        Dim enlace As New EnlaceBD
        Dim TablaGridTarifa As New DataTable
        Dim anio As Integer

        anio = ComboBox3.SelectedItem

        TablaGridTarifa = enlace.getInfoTarifa(anio)
        DataGridView_Tarifa.DataSource = TablaGridTarifa


    End Sub

    Private Sub Button_Cons_Consumo_Click(sender As Object, e As EventArgs) Handles Button_Cons_Consumo.Click
        Dim enlace As New EnlaceBD
        Dim TablaGridConsumo As New DataTable
        Dim anio As Integer

        anio = ComboBox1.SelectedItem

        TablaGridConsumo = enlace.getInfoConsumo(anio)
        DataGridView_Consumo.DataSource = TablaGridConsumo

    End Sub
End Class
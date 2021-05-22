Public Class Pago_de_Recibos

    Public Property CURP As String

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Sub Boton_GenerarReciboyConsulta_Click(sender As Object, e As EventArgs) Handles Boton_GenerarReciboyConsulta.Click
        GenerarReciboyConsulta.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_ConsumoHistorico_Click(sender As Object, e As EventArgs) Handles Boton_ConsumoHistorico.Click
        Consumo_Historico.Show()
        Me.Hide()
    End Sub

    Private Sub Pago_de_Recibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ListBox_RECIBOS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_RECIBOS.SelectedIndexChanged

        'Dim enlace As New EnlaceBD
        'Dim Medidor As String
        'Dim Index As Integer
        'Dim tablaaux As New DataTable
        'Dim Nombre_Usuario As String
        'Dim serv As Boolean

        'tablaaux = enlace.getdataRecibo(Nombre_Usuario)

        'Medidor = ListBox_RECIBOS.DataSource.Rows(ListBox_RECIBOS.SelectedIndex).Item(4)


        'Index = ListBox_RECIBOS.SelectedIndex

        'If (tablaaux.Rows.Count > 0) Then

        '    Domicilio_Label.Text = tablaaux.Rows(Index).Item(0)
        '    Cliente_Label.Text = tablaaux.Rows(Index).Item(3)
        '    Fecha_Label.Text = tablaaux.Rows(Index).Item(2)
        '    serv = Val(tablaaux.Rows(Index).Item(1))


    End Sub


End Class
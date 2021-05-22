Public Class Pago_de_Recibos

    Public Property CURP As String
    Public Property Cliente As DataTable
    Public Property Usuario As DataTable
    Public Property Contrato As DataTable
    Public Property Recibo As DataTable
    Public Property Pagados As DataTable


    Private Sub Boton_GenerarReciboyConsulta_Click(sender As Object, e As EventArgs) Handles Boton_GenerarReciboyConsulta.Click
        GenerarReciboyConsulta.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_ConsumoHistorico_Click(sender As Object, e As EventArgs) Handles Boton_ConsumoHistorico.Click
        Consumo_Historico.Show()
        Me.Hide()
    End Sub

    Private Sub Pago_de_Recibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim enlace As New EnlaceBD
        Usuario = enlace.SortUsuario
        Dim Nombre As String
        Nombre = Usuario.Rows(0).Item(0)
        Cliente = enlace.SortCliente(Nombre)
        CURP = Cliente.Rows(0).Item(0)
        Contrato = enlace.getContratosCliente(CURP)
        Recibo = enlace.getRecibodataCURPactivo(CURP)
        Pagados = enlace.getRecibodataCURPinactivo(CURP)
        If (Recibo.Rows.Count > 0) Then
            ListBox_RECIBOS.DataSource = Recibo
            ListBox_RECIBOS.DisplayMember = "Id_Recibo"


        End If

        If (Pagados.Rows.Count > 0) Then
            ListBox_RecibosPagados.DataSource = Pagados
            ListBox_RecibosPagados.DisplayMember = "Id_Recibo"


        End If

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub ListBox_RECIBOS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_RECIBOS.SelectedIndexChanged

        Dim enlace As New EnlaceBD
        Dim Medidor As String


        Dim Nombre_Usuario As String
        Dim serv As Boolean


        Dim Index As Integer
        Index = ListBox_RECIBOS.SelectedIndex
        If (Recibo.Rows.Count > 0) Then
            Consumo_Label.Text = Recibo.Rows(Index).Item(2)
            Tarifa_Label.Text = Recibo.Rows(Index).Item(3)
            Subtotal_Label.Text = Recibo.Rows(Index).Item(4)
            Total_Label.Text = Recibo.Rows(Index).Item(5)
            Pendiente_Label.Text = Recibo.Rows(Index).Item(6)

        End If





    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim resulty As Boolean
        Dim enlace As New EnlaceBD
        resulty = enlace.ActivarLogin(Usuario.Rows(0).Item(0), 0)
        Close()

    End Sub

    Private Sub TextBox_Nombre_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Nombre.TextChanged
        Dim Value As Integer
        Dim Importe As Integer
        Dim Index As Integer
        Index = ListBox_RECIBOS.SelectedIndex

        Value = Val(Recibo.Rows(Index).Item(6))
        Importe = Val(TextBox_Nombre.Text)

        If (Importe > Value) Then
            MsgBox("ERROR ,Importe mas alto que el pago pendiente")
            TextBox_Nombre.Clear()
        End If
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Dim enlace As New EnlaceBD
        Dim pendiente As Integer
        Dim Importe_pago As Integer
        Dim Index As Integer
        Dim result As Boolean
        Index = ListBox_RECIBOS.SelectedIndex

        pendiente = Val(Recibo.Rows(Index).Item(6))
        Importe_pago = Val(TextBox_Nombre.Text)
        If (Importe_pago = 0) Then
            MsgBox("ERROR ,Importe invalido")
            TextBox_Nombre.Clear()
        End If
        If (Importe_pago = pendiente) Then
            result = enlace.updateReciboPago(0, 1, Recibo.Rows(Index).Item(0))
            MsgBox("Pago aceptado")
        ElseIf (Importe_pago < pendiente And Importe_pago > 0) Then
            pendiente = pendiente - Importe_pago
            result = enlace.updateReciboPago(pendiente, 0, Recibo.Rows(Index).Item(0))
            MsgBox("Pago aceptado")
        End If

    End Sub
    Private Sub TextBox_Nombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Nombre.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub Todos_Click(sender As Object, e As EventArgs) Handles Todos.Click
        Dim Index As Integer
        Dim result As Boolean
        Dim enlace As New EnlaceBD
        Dim i As Integer
        i = 0
        Index = ListBox_RECIBOS.SelectedIndex
        If (Recibo.Rows.Count > 0) Then
            While (i < Recibo.Rows.Count > 0)
                result = enlace.updateReciboPago(0, 1, Recibo.Rows(i).Item(0))
            End While
        End If
        MsgBox("Pago aceptado")

    End Sub


End Class
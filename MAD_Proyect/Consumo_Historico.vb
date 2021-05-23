Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data

Public Class Consumo_Historico
    Private Sub Button_Gestion_Click(sender As Object, e As EventArgs) Handles Button_Gestion.Click
        EmpleadoGral.Show()
        Me.Hide()
    End Sub

    Private Sub Boton_Contratos_Click(sender As Object, e As EventArgs) Handles Boton_Contratos.Click
        Contratos.Show()
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

    Private Sub Button_Pagar_Click(sender As Object, e As EventArgs) Handles Button_Pagar.Click
        Pago_de_Recibos.Show()
        Me.Hide()
    End Sub

    Private Sub Consumo_Historico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim enlace As New EnlaceBD
        Dim anios As New List(Of Integer)
        Dim aniosconsul As New List(Of Integer)


        For anio As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year
            anios.Add(anio)
        Next anio

        ComboBox3.DataSource = anios
        DataGridView_Consumo.AllowUserToAddRows = False
        DataGridView_Consumo.AllowUserToAddRows = False

        ComboBox3.SelectedIndex = 0
        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub Button_Consultar_Click(sender As Object, e As EventArgs) Handles Button_Consultar.Click
        Dim enlace As New EnlaceBD
        Dim TablaGridConsHist As New DataTable
        Dim anio As Integer
        Dim Numero_Medidor As Integer? = Nothing
        Dim Numero_de_Servicio As Integer

        anio = ComboBox3.SelectedItem
        If (TextBox_NumMed.Text <> Nothing) Then
            Numero_Medidor = Integer.Parse(TextBox_NumMed.Text)
        End If

        Numero_de_Servicio = ComboBox1.SelectedIndex

        TablaGridConsHist = enlace.getInfoConsumoHistorico(anio, Numero_Medidor, Numero_de_Servicio)
        DataGridView_Consumo.DataSource = TablaGridConsHist


    End Sub
    Public Function GetColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.ColumnCount - 1) {}
        For i As Integer = 0 To dg.ColumnCount - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function

    Public Sub ExportarDatosConsumHistPDF(ByVal document As Document)

        Dim enlace As New EnlaceBD
        Dim anio As Integer
        Dim Numero_Medidor As Integer
        Dim Numero_de_Servicio As Integer
        Dim tablaaux As New DataTable
        anio = Conversion.Int(ComboBox3.SelectedItem)
        tablaaux = enlace.getInfoConsumoHistorico(anio, Numero_Medidor, Numero_de_Servicio)


        Dim datatable As New PdfPTable(DataGridView_Consumo.ColumnCount)
        datatable.DefaultCell.Padding = 3
        Dim headerwidths As Single() = GetColumnasSize(DataGridView_Consumo)
        datatable.SetWidths(headerwidths)
        datatable.WidthPercentage = 100
        datatable.DefaultCell.BorderWidth = 2
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER

        Dim encabezado As New Paragraph("Consumo Historico", New Font(Font.Name = "Tahoma", 20, Font.Bold))
        Dim texto As New Phrase("El Consumo Historico es del año :" + anio.ToString(), New Font(Font.Name = "Tahoma", 14, Font.Bold))

        For i As Integer = 0 To DataGridView_Consumo.ColumnCount - 1
            datatable.AddCell(DataGridView_Consumo.Columns(i).HeaderText)
        Next
        datatable.HeaderRows = 1
        datatable.DefaultCell.BorderWidth = 1

        For i As Integer = 0 To DataGridView_Consumo.RowCount - 1
            For j As Integer = 0 To DataGridView_Consumo.ColumnCount - 1
                datatable.AddCell(DataGridView_Consumo(j, i).Value.ToString())
            Next
            datatable.CompleteRow()
        Next

        document.Add(encabezado)
        document.Add(texto)
        document.Add(datatable)

    End Sub

    Private Sub Button_ConsumHist_pdf_Click(sender As Object, e As EventArgs) Handles Button_ConsumHist_pdf.Click
        Try
            Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
            Dim filename As String = "Consumo Historico.pdf"
            Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            PdfWriter.GetInstance(doc, file)
            doc.Open()
            ExportarDatosConsumHistPDF(doc)
            doc.Close()
            Process.Start(filename)

        Catch ex As Exception
            MessageBox.Show("No fue posible generar el PDF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_ConsumHist_CSV_Click(sender As Object, e As EventArgs) Handles Button_ConsumHist_CSV.Click

        Dim enlace As New EnlaceBD
        Dim tabla As New DataTable
        Dim tablaaux As New DataTable
        Dim i As Integer
        Dim cuerda As String
        Dim anio As Integer
        Dim Numero_Medidor As Integer?
        Dim Numero_de_Servicio As Integer

        anio = ComboBox3.SelectedItem
        If (TextBox_NumMed.Text <> Nothing) Then
            Numero_Medidor = Integer.Parse(TextBox_NumMed.Text)
        End If

        Numero_de_Servicio = ComboBox1.SelectedIndex

        ' anio = Conversion.Int(ComboBox3.SelectedItem)
        tabla = enlace.getInfoConsumoHistorico(anio, Numero_Medidor, Numero_de_Servicio)


        cuerda = "Reporte de Consumo Historico del año" + "_" + anio.ToString() + "_" + ".csv"

        Dim fileCSV As String = cuerda
        If File.Exists(fileCSV) Then
            My.Computer.FileSystem.DeleteFile(fileCSV)
        End If

        Dim CSV As StreamWriter = New StreamWriter(fileCSV, True)
        CSV.WriteLine(" Periodo de Facturacion , Consumo de kW , Importe , Pago , Pago Pendiente ")

        tablaaux = enlace.getInfoConsumoHistorico(anio, Numero_Medidor, Numero_de_Servicio)

        i = tabla.Rows().Count

        For Fila As Integer = 0 To i - 1 Step 1
            CSV.WriteLine(tablaaux.Rows(Fila).Item(0) & "," & tablaaux.Rows(Fila).Item(1) & "," & tablaaux.Rows(Fila).Item(2) & "," & tablaaux.Rows(Fila).Item(3) & "," & tablaaux.Rows(Fila).Item(4))
        Next

        CSV.Close()
        Process.Start(cuerda)

    End Sub

    Private Sub TextBox_NumMed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_NumMed.KeyPress
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
End Class
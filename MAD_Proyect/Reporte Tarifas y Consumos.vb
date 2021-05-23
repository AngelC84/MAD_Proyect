Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data

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


        For ano As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year
            anios.Add(ano)
        Next ano

        ComboBox3.DataSource = anios
        DataGridView_Tarifa.AllowUserToAddRows = False
        DataGridView_Tarifa.AllowUserToAddRows = False

        For ano As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year
            aniosconsul.Add(ano)
        Next ano

        ComboBox1.DataSource = aniosconsul
        DataGridView_Consumo.AllowUserToAddRows = False
        DataGridView_Consumo.AllowUserToAddRows = False

    End Sub

    Private Sub Button_Consul_Tarifa_Click(sender As Object, e As EventArgs) Handles Button_Consul_Tarifa.Click
        Dim enlace As New EnlaceBD
        Dim TablaGridTarifa As New DataTable
        Dim ano As Integer

        ano = ComboBox3.SelectedItem

        TablaGridTarifa = enlace.getInfoTarifa(ano)
        DataGridView_Tarifa.DataSource = TablaGridTarifa


    End Sub

    Private Sub Button_Cons_Consumo_Click(sender As Object, e As EventArgs) Handles Button_Cons_Consumo.Click
        Dim enlace As New EnlaceBD
        Dim TablaGridConsumo As New DataTable
        Dim ano As Integer

        ano = ComboBox1.SelectedItem

        TablaGridConsumo = enlace.getInfoConsumo(ano)
        DataGridView_Consumo.DataSource = TablaGridConsumo

    End Sub
    Public Function GetColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.ColumnCount - 1) {}
        For i As Integer = 0 To dg.ColumnCount - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function

    Public Sub ExportarDatosPDF(ByVal document As Document)

        Dim enlace As New EnlaceBD
        Dim ano As Integer
        Dim tablaaux As New DataTable
        ano = Conversion.Int(ComboBox3.SelectedItem)
        tablaaux = enlace.getInfoTarifa(ano)


        Dim datatable As New PdfPTable(DataGridView_Tarifa.ColumnCount)
        datatable.DefaultCell.Padding = 3
        Dim headerwidths As Single() = GetColumnasSize(DataGridView_Tarifa)
        datatable.SetWidths(headerwidths)
        datatable.WidthPercentage = 100
        datatable.DefaultCell.BorderWidth = 2
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER

        Dim encabezado As New Paragraph("Reporte de Tarifas", New Font(Font.Name = "Tahoma", 20, Font.Bold))
        Dim texto As New Phrase("El reporte de Tarifas es del año :" + ano.ToString(), New Font(Font.Name = "Tahoma", 14, Font.Bold))

        For i As Integer = 0 To DataGridView_Tarifa.ColumnCount - 1
            datatable.AddCell(DataGridView_Tarifa.Columns(i).HeaderText)
        Next
        datatable.HeaderRows = 1
        datatable.DefaultCell.BorderWidth = 1

        For i As Integer = 0 To DataGridView_Tarifa.RowCount - 1
            For j As Integer = 0 To DataGridView_Tarifa.ColumnCount - 1
                datatable.AddCell(DataGridView_Tarifa(j, i).Value.ToString())
            Next
            datatable.CompleteRow()
        Next

        document.Add(encabezado)
        document.Add(texto)
        document.Add(datatable)

    End Sub


    Private Sub Button_Tarifa_PDF_Click(sender As Object, e As EventArgs) Handles Button_Tarifa_PDF.Click

        Try
            Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
            Dim filename As String = "Reporte de Tarifas.pdf"
            Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            PdfWriter.GetInstance(doc, file)
            doc.Open()
            ExportarDatosPDF(doc)
            doc.Close()
            Process.Start(filename)

        Catch ex As Exception
            MessageBox.Show("No fue posible generar el PDF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Public Sub ExportarDatosConsumoPDF(ByVal document As Document)

        Dim enlace As New EnlaceBD
        Dim ano As Integer
        Dim tablaaux As New DataTable
        ano = Conversion.Int(ComboBox1.SelectedItem)
        tablaaux = enlace.getInfoConsumo(ano)


        Dim datatable As New PdfPTable(DataGridView_Consumo.ColumnCount)
        datatable.DefaultCell.Padding = 3
        Dim headerwidths As Single() = GetColumnasSize(DataGridView_Consumo)
        datatable.SetWidths(headerwidths)
        datatable.WidthPercentage = 100
        datatable.DefaultCell.BorderWidth = 2
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER

        Dim encabezado As New Paragraph("Reporte de Consumo", New Font(Font.Name = "Tahoma", 20, Font.Bold))
        Dim texto As New Phrase("El reporte de Consumo es del año :" + ano.ToString(), New Font(Font.Name = "Tahoma", 14, Font.Bold))

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

    Private Sub Button_Consumo_Pdf_Click(sender As Object, e As EventArgs) Handles Button_Consumo_Pdf.Click
        Try
            Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
            Dim filename As String = "Reporte de Consumos.pdf"
            Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            PdfWriter.GetInstance(doc, file)
            doc.Open()
            ExportarDatosConsumoPDF(doc)
            doc.Close()
            Process.Start(filename)

        Catch ex As Exception
            MessageBox.Show("No fue posible generar el PDF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button_Tarifa_CSV_Click(sender As Object, e As EventArgs) Handles Button_Tarifa_CSV.Click

        Dim enlace As New EnlaceBD
        Dim tabla As New DataTable
        Dim tablaaux As New DataTable
        Dim i As Integer
        Dim cuerda As String
        Dim ano As Integer


        ano = Conversion.Int(ComboBox3.SelectedItem)
        tabla = enlace.getInfoTarifa(ano)



        cuerda = "Reporte de tarifa del año" + "_" + ano.ToString() + "_" + ".csv"

        Dim fileCSV As String = cuerda
        If File.Exists(fileCSV) Then
            My.Computer.FileSystem.DeleteFile(fileCSV)
        End If

        Dim CSV As StreamWriter = New StreamWriter(fileCSV, True)
        CSV.WriteLine(" Anio , Mes , Tarifa Basica , Tarifa Intermedia , Tarifa Excedente")

        tablaaux = enlace.getInfoTarifa(ano)

        i = tabla.Rows().Count

        For Fila As Integer = 0 To i - 1 Step 1
            Dim fechaaux As Integer
            Dim fechamonth As String
            fechamonth = tabla.Rows(Fila).Item(1).ToString
            fechaaux = Conversion.Int(ComboBox3.SelectedItem)
            CSV.WriteLine(fechaaux & "," & fechamonth & "," & tablaaux.Rows(Fila).Item(2) & "," & tablaaux.Rows(Fila).Item(3) & "," & tablaaux.Rows(Fila).Item(4))
        Next

        CSV.Close()
        Process.Start(cuerda)

    End Sub

    Private Sub Button_Consumo_CSV_Click(sender As Object, e As EventArgs) Handles Button_Consumo_CSV.Click


        Dim enlace As New EnlaceBD
        Dim tabla As New DataTable
        Dim tablaaux As New DataTable
        Dim i As Integer
        Dim cuerda As String
        Dim ano As Integer

        ano = Conversion.Int(ComboBox1.SelectedItem)
        tabla = enlace.getInfoConsumo(ano)

        cuerda = "Reporte de Consumo del año" + "_" + ano.ToString() + "_" + ".csv"

        Dim fileCSV As String = cuerda
        If File.Exists(fileCSV) Then
            My.Computer.FileSystem.DeleteFile(fileCSV)
        End If

        Dim CSV As StreamWriter = New StreamWriter(fileCSV, True)
        CSV.WriteLine(" Anio , Mes , Numero de Medidor , kW Basica , kW Intermedia , kW Excedente")

        tablaaux = enlace.getInfoConsumo(ano)

        i = tabla.Rows().Count

        For Fila As Integer = 0 To i - 1 Step 1
            Dim fechaaux As Integer
            Dim fechamonth As String
            fechamonth = tabla.Rows(Fila).Item(1).ToString
            fechaaux = Conversion.Int(ComboBox1.SelectedItem)
            CSV.WriteLine(fechaaux & "," & fechamonth & "," & tablaaux.Rows(Fila).Item(2) & "," & tablaaux.Rows(Fila).Item(3) & "," & tablaaux.Rows(Fila).Item(4) & "," & tablaaux.Rows(Fila).Item(5))
        Next

        CSV.Close()
        Process.Start(cuerda)

    End Sub
End Class
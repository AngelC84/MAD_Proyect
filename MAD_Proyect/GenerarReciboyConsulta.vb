Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class GenerarReciboyConsulta
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

    Private Sub Button_Pagar_Click(sender As Object, e As EventArgs) Handles Button_Pagar.Click
        Pago_de_Recibos.Show()
        Me.Hide()
    End Sub

    Private Sub GenerarReciboyConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim enlace As New EnlaceBD
        Dim tablaaux As New DataTable
        ' Dim enlace As New EnlaceBD
        Dim anios As New List(Of Integer)

        tablaaux = enlace.getdataContrato()

        'Mes = Val(TextBox_Mes.Text)

        For anio As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year
            anios.Add(anio)
        Next anio

        ComboBox4.DataSource = anios

        If (tablaaux.Rows.Count > 0) Then
            ListBox_Contratos.DataSource = tablaaux
            ListBox_Contratos.DisplayMember = "Numero_Medidor"
        End If

        If (tablaaux.Rows.Count > 0) Then
            ComboBox2.DataSource = tablaaux
            ComboBox2.DisplayMember = "Numero_Medidor"
        End If

        ComboBox4.SelectedIndex = 0
        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub ListBox_Contratos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox_Contratos.SelectedIndexChanged
        Dim enlace As New EnlaceBD
        Dim Medidor As String
        Dim Index As Integer
        Dim tablaaux As New DataTable
        Dim serv As Boolean
        tablaaux = enlace.getdataContrato()
        Medidor = ListBox_Contratos.DataSource.Rows(ListBox_Contratos.SelectedIndex).Item(4)


        Index = ListBox_Contratos.SelectedIndex

        If (tablaaux.Rows.Count > 0) Then

            Domicilio_Label.Text = tablaaux.Rows(Index).Item(0)
            Cliente_Label.Text = tablaaux.Rows(Index).Item(3)
            Fecha_Label.Text = tablaaux.Rows(Index).Item(2)
            serv = Val(tablaaux.Rows(Index).Item(1))
            If (serv) Then
                Servicio_Label.Text = "Industrial"
            Else
                Servicio_Label.Text = "Domestico"
            End If


            '  DateTimePicker1.Value = tablacliente.Rows(Index).Item(1)
            'TextBox_Nombre.Text = tablacliente.Rows(Index).Item(2)
            '  DateTimePicker2.Value = tablacliente.Rows(Index).Item(3)
            'ComboBox_Genero.SelectedIndex = ComboBox_Genero.FindStringExact(tablacliente.Rows(Index).Item(4).ToString())
            ' TextBox_email.Text = tablacliente.Rows(Index).Item(5)
            ' TextBox_Usuario.Text = tablacliente.Rows(Index).Item(6)
            ' TextBox_Contra.Text = tablacliente.Rows(Index).Item(7)

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim enlace As New EnlaceBD
        Dim result As Boolean = False
        Dim tarifa As New DataTable
        Dim contratos As New DataTable
        Dim consumo As New DataTable

        consumo = enlace.getSortedConsumo()
        Dim counting As Integer
        counting = consumo.Rows.Count
        Dim indi As Integer
        indi = 0
        Dim Cliente As String
        Dim Id_tarifa As Int32
        Dim subtotal As Double
        Dim mes As Int16
        Dim ano As Int16
        Dim mesC As Int16
        Dim anoC As Int16
        Dim total As Double

        Dim servicio As Boolean
        Dim odd As Integer
        Dim tarifaIn As Boolean
        Dim consumobimestral As Integer
        Dim bimestre As Int16
        bimestre = 0
        While (counting > indi)



            mesC = consumo.Rows(indi).Item(2)

            anoC = consumo.Rows(indi).Item(1)
            contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
            servicio = Val(contratos.Rows(0).Item(1))
            mes = Month(contratos.Rows(0).Item(2))
            ano = Year(contratos.Rows(0).Item(2))
            odd = mes Mod 2
            If (servicio) Then
                bimestre = 0
                tarifa = enlace.getSortedTarifaInd(consumo.Rows(indi).Item(2), consumo.Rows(indi).Item(1))
                If tarifa.Rows.Count <= 0 Then
                    MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                    tarifaIn = False
                    indi = indi + 1
                Else
                    tarifaIn = Val(tarifa.Rows(0).Item(6))
                End If

                If (tarifaIn) Then
                    contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))


                    subtotal = Val(consumo.Rows(indi).Item(4))

                    If (consumo.Rows(indi).Item(4) < tarifa.Rows(0).Item(7)) Then

                        subtotal = consumo.Rows(indi).Item(4) * tarifa.Rows(0).Item(3)

                    ElseIf (consumo.Rows(indi).Item(4) < tarifa.Rows(0).Item(8)) Then

                        subtotal = consumo.Rows(indi).Item(4) * tarifa.Rows(0).Item(4)

                    Else
                        subtotal = consumo.Rows(indi).Item(4) * tarifa.Rows(0).Item(5)
                    End If
                    Cliente = contratos.Rows(0).Item(3)
                    total = subtotal * 1.16
                    result = enlace.Reg_Recibo(consumo.Rows(indi).Item(4), consumo.Rows(indi).Item(3), 1, Cliente, tarifa.Rows(0).Item(0), subtotal, total, total)
                    indi = indi + 1

                Else
                    MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                    indi = indi + 1

                End If


            Else
                While bimestre < 2 And servicio = False
                    If (bimestre = 0) Then
                        If consumo.Rows.Count <= 0 Then
                            MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                            tarifaIn = False
                            contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                            servicio = Val(contratos.Rows(0).Item(1))
                            bimestre = bimestre + 1
                            indi = indi + 1

                        Else
                            consumobimestral = consumobimestral + consumo.Rows(indi).Item(4)
                            bimestre = bimestre + 1
                            indi = indi + 1

                        End If

                    ElseIf (bimestre = 1) Then
                        bimestre = bimestre + 1
                        If consumo.Rows.Count <= 0 Then
                            MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                            tarifaIn = False
                            contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                            servicio = Val(contratos.Rows(0).Item(1))
                            indi = indi + 1

                        ElseIf counting > indi Then


                            consumobimestral = consumobimestral + consumo.Rows(indi).Item(4)

                            tarifa = enlace.getSortedTarifa(consumo.Rows(indi).Item(2), consumo.Rows(indi).Item(1))
                            If tarifa.Rows.Count <= 0 Then
                                MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                                tarifaIn = False
                                contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                                servicio = Val(contratos.Rows(0).Item(1))
                                indi = indi + 1

                            Else
                                tarifaIn = Val(tarifa.Rows(0).Item(6))
                                If (tarifaIn = False) Then
                                    contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))

                                    ' subtotal = Val(consumo.Rows(indi).Item(4))

                                    If (consumo.Rows(indi).Item(4) < tarifa.Rows(0).Item(7)) Then

                                        subtotal = consumobimestral + consumo.Rows(indi).Item(4) * tarifa.Rows(0).Item(3)

                                    ElseIf (consumo.Rows(indi).Item(4) < tarifa.Rows(0).Item(8)) Then

                                        subtotal = consumobimestral + consumo.Rows(indi).Item(4) * tarifa.Rows(0).Item(4)

                                    Else
                                        subtotal = consumobimestral + consumo.Rows(indi).Item(4) * tarifa.Rows(0).Item(5)
                                    End If
                                    Cliente = contratos.Rows(0).Item(3)
                                    total = subtotal * 1.16
                                    result = enlace.Reg_Recibo(consumobimestral, consumo.Rows(indi).Item(3), 0, Cliente, tarifa.Rows(0).Item(0), subtotal, total, total)
                                    indi = indi + 1
                                    consumobimestral = 0

                                    If counting > indi Then


                                        contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                                        servicio = Val(contratos.Rows(0).Item(1))
                                    End If

                                Else
                                    MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                                    indi = indi + 1

                                    If counting > indi Then
                                        contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                                        servicio = Val(contratos.Rows(0).Item(1))
                                    End If

                                End If

                            End If



                        End If


                    End If



                End While


            End If



        End While

        'If (servicio) Then

        '    tarifa = enlace.getSortedTarifa(consumo.Rows(indi).Item(2), consumo.Rows(0).Item(1))



        'End If

        'While (counting > indi)

        '    


        '    If (servicio) Then

        '        tarifa = enlace.getSortedTarifa(consumo.Rows(indi).Item(2), consumo.Rows(indi).Item(1))
        '        Dim buli As Boolean
        '        buli = Val(tarifa.Rows(indi).Item(6))
        '        If buli Then



        '            subtotal = Val(consumo.Rows(indi).Item(4))
        '            If (consumo.Rows(indi).Item(4) < tarifa.Rows(indi).Item(7)) Then

        '                subtotal = consumo.Rows(indi).Item(4) * tarifa.Rows(indi).Item(3)

        '            ElseIf (consumo.Rows(indi).Item(4) < tarifa.Rows(indi).Item(8)) Then

        '                subtotal = consumo.Rows(indi).Item(4) * tarifa.Rows(indi).Item(4)

        '            Else
        '                subtotal = consumo.Rows(indi).Item(4) * tarifa.Rows(indi).Item(5)
        '            End If
        '            Cliente = contratos.Rows(Index).Item(3)
        '            total = subtotal * 1.16
        '            result = enlace.Reg_Recibo(consumo.Rows(indi).Item(4), consumo.Rows(indi).Item(3), 1, Cliente, tarifa.Rows(indi).Item(0), subtotal, total, total)
        '            MsgBox("Recibo generado exitosamente")
        '            indi = indi + 1








        '        End If

        '        End If


        'End While







        'tarifa = enlace.getSortedTarifa(consumo.Rows(indi).Item(2), consumo.Rows(0).Item(1))

        'Cliente = contratos.Rows(Index).Item(3)

        'Id_tarifa = Val(tarifa.Rows(0).Item(0))









        'odd = mes Mod 2








        'If (servicio) Then

        '    

        'Else
        '    If (odd = 0) Then

        '    End If
        'End If


        'DataGridView1.DataSource = consumo

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub TextBox_Mes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Mes.KeyPress
        TextBox_Mes.MaxLength = 2
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Mes_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Mes.TextChanged
        If (Val(TextBox_Mes.Text) = 0) Then

            MsgBox("mes invalido")
        ElseIf (Val(TextBox_Mes.Text) > 12) Then
            TextBox_Mes.Clear()
            MsgBox("mes invalido")
        End If
    End Sub

    Private Sub TextBox_NumMed_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Recibo_PDF_Click(sender As Object, e As EventArgs) Handles Recibo_PDF.Click, Consulta.Click

        Dim enlace As New EnlaceBD
        Dim tablaaux As New DataTable
        Dim ano As Integer
        Dim mes As Integer? = Nothing
        Dim Numero_Medidor As Integer? = Nothing
        Dim Numero_de_Servicio As Integer
        Dim Numero_Medidor2 As String
        Dim ano2 As String
        Dim mes2 As String
        Dim curp As String


        Dim trans As New clsConversion
        Dim Nombre_Usuario As String
        Dim serv As Boolean
        Dim Medidor As String
        Dim consumo As Integer
        Dim numero As String




        If (ComboBox2.Text <> Nothing) Then
            Numero_Medidor = Integer.Parse(ComboBox2.Text)
        End If

        If (ComboBox4.Text <> Nothing) Then
            ano = Integer.Parse(ComboBox4.Text)
        End If

        If (TextBox_Mes.Text <> Nothing) Then
            mes = Integer.Parse(TextBox_Mes.Text)
        End If


        tablaaux = enlace.ReciboPDFV(ano, mes, Numero_Medidor, Numero_de_Servicio)


        Dim Index As Integer


        Dim Tarifa As New DataTable
        Dim Recibo As New DataTable
        Dim Contrato As New DataTable

        Contrato = enlace.getSortedContrato(Numero_Medidor)
        Recibo = enlace.getRecibodataCURPactivo(Contrato.Rows(0).Item(3))


        If (Recibo.Rows.Count > 0) Then
            'Consumo_Label.Text = Recibo.Rows(Index).Item(2)

            'Tarifa = enlace.getTarifaSortID(Recibo.Rows(Index).Item(3))
            'consumo = Val(Recibo.Rows(Index).Item(2))
            'Dim basico As Integer
            'Dim medium As Integer
            'basico = Val(Tarifa.Rows(0).Item(7))
            'medium = Val(Tarifa.Rows(0).Item(7))
            'If (consumo < basico) Then
            '    Tarifa_Label.Text = "Consumo Basico"
            '    Tasa_Label.Text = Tarifa.Rows(0).Item(3)
            'ElseIf (consumo < medium) Then
            '    Tarifa_Label.Text = "Consumo Medio"
            '    Tasa_Label.Text = Tarifa.Rows(0).Item(4)
            'Else
            '    Tarifa_Label.Text = "Consumo Excedente"
            '    Tasa_Label.Text = Tarifa.Rows(0).Item(5)
        End If


        Dim cuerda As String
        Dim Servicio As String = " "

        If (Numero_de_Servicio = 0) Then
            Servicio = "Domestico"
        ElseIf (Numero_de_Servicio = 1) Then
            Servicio = "Industrial"
        End If


        mes2 = mes
        ano2 = ano
        Numero_Medidor2 = Numero_Medidor

        cuerda = "Recibo de Luz" + "_" + Numero_Medidor2 + "_" + ano2 + "_" + mes2 + ".pdf"

        Dim pdfDoc As New Document(iTextSharp.text.PageSize.A4, 15.0F, 15.0F, 30.0F, 30.0F)
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(cuerda, FileMode.Create))


        Dim Fot8 As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL))
        Dim FontB8 As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD))
        Dim FontB12 As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 16, iTextSharp.text.Font.BOLD))
        Dim CVacio As PdfPCell = New PdfPCell(New Phrase(""))
        CVacio.Border = 0
        pdfDoc.Open()



        Dim Table1 As PdfPTable = New PdfPTable(3)
        Dim Col1 As PdfPCell
        Dim Col2 As PdfPCell
        Dim Col3 As PdfPCell
        Dim Col4 As PdfPCell
        Dim Col5 As PdfPCell
        Dim Col6 As PdfPCell
        Dim ILine As Integer
        Dim iFila As Integer
        Table1.WidthPercentage = 95

        Dim widths As Single() = New Single() {8.0F, 8.0F, 8.0}
        Table1.SetWidths(widths)

        'Encabezado -------------------------------------------------------

        Dim imagenURL As String = "CFE.bmp"
        Dim imagenBMP As iTextSharp.text.Image
        imagenBMP = iTextSharp.text.Image.GetInstance(imagenURL)
        imagenBMP.ScaleToFit(110.0F, 140.0F)
        imagenBMP.SpacingBefore = 20.0F
        imagenBMP.SpacingAfter = 10.0F
        imagenBMP.SetAbsolutePosition(40, 780)
        pdfDoc.Add(imagenBMP)

        Table1.AddCell(CVacio)
        Col2 = New PdfPCell(New Phrase("Nombre del Cliente:", FontB8))
        Col2.Border = 0
        Table1.AddCell(Col2)
        'Table1.AddCell(CVacio)

        Col3 = New PdfPCell(New Phrase("TOTAL A PAGAR:", FontB8))
        Col3.Border = 0
        Table1.AddCell(Col3)
        Table1.AddCell(CVacio)

        Col2 = New PdfPCell(New Phrase("Domicilio del Cliente:", FontB8))
        Col2.Border = 0
        Table1.AddCell(Col2)
        Table1.AddCell(CVacio)
        pdfDoc.Add(Table1)

        'PintaLinea(0.5, 30, 733, 530, 733)
        pdfDoc.Add(New Paragraph(" "))
        pdfDoc.Add(New Paragraph(" "))
        pdfDoc.Add(New Paragraph(" "))




        'CLIENTE -----------------------------------------
        Dim Table2 As PdfPTable = New PdfPTable(3)
        Dim widths2 As Single() = New Single() {3.0F, 3.0F, 3.0}
        Table2.WidthPercentage = 95
        Table2.SetWidths(widths2)

        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)

        Col1 = New PdfPCell(New Phrase("Numero de Servicio:", FontB8))
        Col1.Border = 0

        Table2.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("Numero de Medidor:", FontB8))
        Col2.Border = 0

        Table2.AddCell(Col2)
        Col3 = New PdfPCell(New Phrase("Periodo Facturado:", FontB8))
        Col3.Border = 0

        Table2.AddCell(Col3)
        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)
        pdfDoc.Add(Table2)

        pdfDoc.Add(New Paragraph(" "))
        pdfDoc.Add(New Paragraph(" "))
        pdfDoc.Add(New Paragraph(" "))


        '---------------------------------GENERAR GASTO

        Dim Table3 As PdfPTable = New PdfPTable(6)
        Dim widths3 As Single() = New Single() {3.0F, 3.0F, 3.0, 3.0F, 3.0F, 3.0}
        Table3.WidthPercentage = 95
        Table3.SetWidths(widths3)

        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)

        Col1 = New PdfPCell(New Phrase("Concepto", FontB8))

        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("Lectura Actual", FontB8))

        Table3.AddCell(Col2)
        Col3 = New PdfPCell(New Phrase("Lectura Anterior", FontB8))

        Table3.AddCell(Col3)
        Col4 = New PdfPCell(New Phrase("Total Periodo", FontB8))

        Table3.AddCell(Col4)
        Col5 = New PdfPCell(New Phrase("Precio", FontB8))

        Table3.AddCell(Col5)
        Col6 = New PdfPCell(New Phrase("Subtotal", FontB8))

        Table3.AddCell(Col6)


        Col1 = New PdfPCell(New Phrase("Energia (kWh)", FontB8))
        Col1.Border = 0

        Table3.AddCell(Col1)

        Table3.AddCell(CVacio)
        Table3.AddCell(CVacio)
        Table3.AddCell(CVacio)
        Table3.AddCell(CVacio)
        Table3.AddCell(CVacio)


        Col1 = New PdfPCell(New Phrase("Basico", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase("Intermedio", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase("Suma", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)

        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)
        pdfDoc.Add(Table3)

        pdfDoc.Add(New Paragraph(" "))
        pdfDoc.Add(New Paragraph(" "))
        pdfDoc.Add(New Paragraph(" "))
        pdfDoc.Add(New Paragraph(" "))



        '-----------------------------------TOTALES

        Dim Table4 As PdfPTable = New PdfPTable(5)
        Dim widths4 As Single() = New Single() {4.0F, 4.0F, 4.0, 4.0F, 4.0F, 4.0}
        Table3.WidthPercentage = 95
        Table3.SetWidths(widths3)

        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)
        'Table2.AddCell(CVacio)

        Col1 = New PdfPCell(New Phrase("Energia", FontB8))

        Table4.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("IVA 16%", FontB8))

        Table4.AddCell(Col2)
        Col3 = New PdfPCell(New Phrase("Pendiente de Pago", FontB8))

        Table4.AddCell(Col3)
        Col4 = New PdfPCell(New Phrase("Su Pago", FontB8))

        Table4.AddCell(Col4)
        Col5 = New PdfPCell(New Phrase("Total", FontB8))

        Table4.AddCell(Col6)

        pdfDoc.Add(Table4)

        pdfDoc.Add(New Paragraph(" "))
        pdfDoc.Add(New Paragraph(" "))




        'Col1 = New PdfPCell(New Phrase(enlace.ObtenerCliente(curp), FontB12))
        'Col1.Border = 0
        'Table1.AddCell(CVacio)
        'Table1.AddCell(Col1)
        'Table1.AddCell(CVacio)

        'Table1.WidthPercentage = 95
        'widths = New Single() {3.33F, 3.33F, 3.33F, 3.33F, 3.33F, 3.33F}
        'Col1 = New PdfPCell(New Phrase(tablaaux.Columns(0).ColumnName, FontB8))
        'Table1.AddCell(Col1)


        'For Each row In tablaaux.Rows
        '    Col1 = New PdfPCell(New Phrase(row.Item(0).ToString, Fot8))
        '    Table1.AddCell(Col1)
        'Next

        'Dim Tabla2 As PdfPTable = New PdfPTable(3)
        'Tabla2.WidthPercentage = 95

        'Dim widthss As Single() = New Single() {6.66F, 6.66F, 6.66F}

        'Dim widthsss As Single() = New Single() {20.0F}
        'Tabla2.SetWidths(widthss)
        'Col1.Border = 0
        'Tabla2.AddCell(CVacio)
        'Tabla2.AddCell(Col1)
        'Tabla2.AddCell(CVacio)

        'pdfDoc.Add(Tabla2)
        'pdfDoc.Add(New Paragraph(" "))

        ''If (Numero_de_Servicio = 0) Then
        ''    Servicio = "Servicio Domestico"
        ''ElseIf (Numero_de_Servicio = 1) Then
        ''    Servicio = "Servicio Industrial"
        ''End If

        'Dim parraf As New Paragraph(Numero_de_Servicio)
        'parraf.Alignment = Element.ALIGN_CENTER
        'pdfDoc.Add(parraf)
        'parraf = New Paragraph(ano)
        'parraf.Alignment = Element.ALIGN_CENTER
        'pdfDoc.Add(parraf)
        'pdfDoc.Add(New Paragraph(" "))


        'Tabla2 = New PdfPTable(6)
        'Tabla2.WidthPercentage = 95
        'widthsss = New Single() {3.33F, 3.33F, 3.33F, 3.33F, 3.33F, 3.33F}
        'Tabla2.SetWidths(widthsss)
        'Col1 = New PdfPCell(New Phrase(tablaaux.Columns(0).ColumnName, FontB8))
        'Tabla2.AddCell(Col1)
        'Col1 = New PdfPCell(New Phrase(tablaaux.Columns(1).ColumnName, FontB8))
        'Tabla2.AddCell(Col1)
        'Col1 = New PdfPCell(New Phrase(tablaaux.Columns(2).ColumnName, FontB8))
        'Tabla2.AddCell(Col1)
        'Col1 = New PdfPCell(New Phrase(tablaaux.Columns(3).ColumnName, FontB8))
        'Tabla2.AddCell(Col1)
        'Col1 = New PdfPCell(New Phrase(tablaaux.Columns(4).ColumnName, FontB8))
        'Tabla2.AddCell(Col1)
        'Col1 = New PdfPCell(New Phrase(tablaaux.Columns(5).ColumnName, FontB8))
        'Tabla2.AddCell(Col1)


        'For Each row In tablaaux.Rows
        '    Col1 = New PdfPCell(New Phrase(row.Item(0).ToString, Fot8))
        '    Tabla2.AddCell(Col1)
        '    Col1 = New PdfPCell(New Phrase(row.Item(1).ToString, Fot8))
        '    Tabla2.AddCell(Col1)
        '    Col1 = New PdfPCell(New Phrase(row.Item(2).ToString, Fot8))
        '    Tabla2.AddCell(Col1)
        '    Col1 = New PdfPCell(New Phrase(Servicio, Fot8))
        '    Tabla2.AddCell(Col1)
        '    Col1 = New PdfPCell(New Phrase(row.Item(4).ToString, Fot8))
        '    Tabla2.AddCell(Col1)
        '    Col1 = New PdfPCell(New Phrase(row.Item(5).ToString, Fot8))
        '    Tabla2.AddCell(Col1)
        'Next


        'pdfDoc.Add(Tabla2)
        pdfDoc.Close()
        Process.Start(cuerda)
    End Sub


End Class
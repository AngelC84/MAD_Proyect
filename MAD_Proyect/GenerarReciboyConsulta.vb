Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO


Public Class GenerarReciboyConsulta
    Public Property CURP As String
    Public Property Usuario As DataTable
    Public Property Cliente As DataTable
    Public Property Recibo As DataTable

    Public Property Tarifa As DataTable

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
        Dim anios As New List(Of Integer)


        tablaaux = enlace.getdataContrato()



        If (tablaaux.Rows.Count > 0) Then
            ListBox_Contratos.DataSource = tablaaux
            ListBox_Contratos.DisplayMember = "Numero_Medidor"
        End If


        ComboBox1.SelectedIndex = 0


        '---------------------------------------

        ''numero = trans.ConvertNumberToWords(Recibo.Rows(Index).Item(5))
        'Totes_label.Text = numero
        'Subtotal_Label.Text = Recibo.Rows(Index).Item(4)
        'Total_Label.Text = Recibo.Rows(Index).Item(5)
        'Pendiente_Label.Text = Recibo.Rows(Index).Item(6)


    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
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

            Label16_Domicilio.Text = tablaaux.Rows(Index).Item(0)
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

        Dim tarifaIn As Boolean

        Dim bimestre As Int16
        bimestre = 0
        Dim mesBox As Integer
        Dim anoBox As Integer
        Dim Medidor As Integer
        While (counting > indi)




            mesC = consumo.Rows(indi).Item(2)
            mesBox = consumo.Rows(indi).Item(2)
            anoBox = consumo.Rows(indi).Item(1)
            anoC = consumo.Rows(indi).Item(1)
            contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))




            servicio = Val(contratos.Rows(0).Item(1))
            mes = Month(contratos.Rows(0).Item(2))
            ano = Year(contratos.Rows(0).Item(2))
            Medidor = consumo.Rows(indi).Item(3)




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




                    Dim basico As Decimal
                    Dim medio As Decimal
                    Dim excedente As Decimal
                    Dim pBasico As Decimal
                    Dim pMedio As Decimal
                    Dim pExcedente As Decimal
                    Dim watts As Decimal
                    basico = tarifa.Rows(0).Item(7)
                    medio = tarifa.Rows(0).Item(8)
                    pBasico = tarifa.Rows(0).Item(3)
                    pMedio = tarifa.Rows(0).Item(4)
                    pExcedente = tarifa.Rows(0).Item(5)

                    Dim diff1 As Decimal

                    diff1 = medio - basico
                    excedente = tarifa.Rows(0).Item(9)
                    watts = consumo.Rows(indi).Item(4)
                    Dim tir As Decimal
                    Dim ter As Decimal
                    Dim tar As Decimal
                    tir = 0
                    ter = 0
                    tar = 0
                    If (watts > medio) Then 'Excedente
                        tir = basico * pBasico
                        ter = diff1 * pMedio
                        tar = (watts - (diff1 + basico)) * pExcedente
                        subtotal = tir + ter + tar
                    ElseIf (watts <= medio And watts > basico) Then 'Medio
                        tir = basico * pBasico
                        ter = (watts - basico) * pMedio

                        subtotal = tir + ter
                    ElseIf (watts <= basico) Then 'Basico
                        tir = watts * pBasico
                        subtotal = tir

                    End If
                    Cliente = contratos.Rows(0).Item(3)
                    total = subtotal * 1.16
                    Dim Contrato As New DataTable
                    Dim con As New Decimal
                    Contrato = enlace.getSortedContrato(Medidor)
                    con = Contrato.Rows(0).Item(5) + consumo.Rows(indi).Item(4)
                    result = enlace.altContrato(Medidor, con)

                    result = enlace.Reg_Recibo(consumo.Rows(indi).Item(4), consumo.Rows(indi).Item(3), 1, Cliente, tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(indi).Item(0))
                    indi = indi + 1

                Else
                    MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                    indi = indi + 1

                End If


            Else
                If servicio = False Then
                    Dim odd As Decimal
                    odd = mes Mod 2
                    Dim oddbox As Integer
                    oddbox = mesBox Mod 2
                    Dim previous As Integer
                    Dim previousyear As Integer
                    Dim consumobimestral As Integer
                    If (odd > 0) Then

                        If (oddbox > 0) Then
                            indi = indi + 1
                        Else

                            If (mesBox = 1) Then
                                previous = 12
                                previousyear = anoBox - 1
                            Else
                                previous = mesBox - 1
                                previousyear = anoBox
                            End If
                            consumo = enlace.getConsumobyDate(Medidor, previous, previousyear)
                            If (consumo.Rows.Count < 1) Then

                                indi = indi + 1
                            Else
                                consumobimestral = consumobimestral + consumo.Rows(indi).Item(4)

                                result = enlace.altConsumo(consumo.Rows(indi).Item(0))
                                consumo = enlace.getConsumobyDate(Medidor, mesBox, anoBox)
                                consumobimestral = consumobimestral + consumo.Rows(indi).Item(4)

                                tarifa = enlace.getSortedTarifa(mesBox, anoBox)
                                If (tarifa.Rows.Count < 1) Then
                                    MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                                    indi = indi + 1

                                Else


                                    Dim subtotalbasico As Decimal
                                    Dim subtotalmedio As Decimal
                                    Dim subtotalexcedente As Decimal
                                    Dim thisConsumo As Decimal

                                    If (consumobimestral < tarifa.Rows(0).Item(7)) Then

                                        subtotal = consumobimestral * tarifa.Rows(0).Item(3)


                                    ElseIf (consumobimestral < tarifa.Rows(0).Item(8)) Then

                                        subtotalbasico = tarifa.Rows(0).Item(3) * tarifa.Rows(0).Item(7)

                                        thisConsumo = consumobimestral - tarifa.Rows(0).Item(7)

                                        subtotalmedio = tarifa.Rows(0).Item(4) * thisConsumo

                                        subtotal = subtotalbasico + subtotalmedio

                                    Else
                                        subtotalbasico = tarifa.Rows(0).Item(3) * tarifa.Rows(0).Item(7)
                                        subtotalmedio = tarifa.Rows(0).Item(4) * tarifa.Rows(0).Item(8)

                                        thisConsumo = consumobimestral - tarifa.Rows(0).Item(8)
                                        subtotalexcedente = thisConsumo * tarifa.Rows(0).Item(5)

                                        subtotal = subtotalbasico + subtotalmedio + subtotalexcedente

                                    End If
                                    total = subtotal * 1.16
                                    result = enlace.Reg_Recibo(consumobimestral, Medidor, 0, contratos.Rows(0).Item(3), tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(0).Item(0))
                                    Dim Contrato As New DataTable
                                    Dim con As New Decimal
                                    Contrato = enlace.getSortedContrato(Medidor)
                                    con = Contrato.Rows(0).Item(5) + consumobimestral
                                    result = enlace.altContrato(Medidor, con)
                                    indi = indi + 1

                                End If

                            End If

                        End If
                    ElseIf (odd = 0) Then

                        If (oddbox = 0) Then
                            indi = indi + 1

                        Else

                            If (mesBox = 1) Then
                                previous = 12
                                previousyear = anoBox - 1
                            Else
                                previous = mesBox - 1
                                previousyear = anoBox
                            End If
                            consumo = enlace.getConsumobyDate(Medidor, previous, previousyear)
                            If (consumo.Rows.Count < 1) Then
                                indi = indi + 1

                            Else
                                consumobimestral = consumobimestral + consumo.Rows(0).Item(4)

                                result = enlace.altConsumo(consumo.Rows(0).Item(0))
                                consumo = enlace.getConsumobyDate(Medidor, mesBox, anoBox)
                                consumobimestral = consumobimestral + consumo.Rows(0).Item(4)

                                tarifa = enlace.getSortedTarifa(mesBox, anoBox)
                                If (tarifa.Rows.Count < 1) Then
                                    MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                                    indi = indi + 1

                                Else


                                    Dim subtotalbasico As Decimal
                                    Dim subtotalmedio As Decimal
                                    Dim subtotalexcedente As Decimal
                                    Dim thisConsumo As Decimal

                                    If (consumobimestral < tarifa.Rows(0).Item(7)) Then

                                        subtotal = consumobimestral * tarifa.Rows(0).Item(3)


                                    ElseIf (consumobimestral < tarifa.Rows(0).Item(8)) Then

                                        subtotalbasico = tarifa.Rows(0).Item(3) * tarifa.Rows(0).Item(7)

                                        thisConsumo = consumobimestral - tarifa.Rows(0).Item(7)

                                        subtotalmedio = tarifa.Rows(0).Item(4) * thisConsumo

                                        subtotal = subtotalbasico + subtotalmedio

                                    Else
                                        subtotalbasico = tarifa.Rows(0).Item(3) * tarifa.Rows(0).Item(7)
                                        subtotalmedio = tarifa.Rows(0).Item(4) * tarifa.Rows(0).Item(8)

                                        thisConsumo = consumobimestral - tarifa.Rows(0).Item(8)
                                        subtotalexcedente = thisConsumo * tarifa.Rows(0).Item(5)

                                        subtotal = subtotalbasico + subtotalmedio + subtotalexcedente

                                    End If
                                    total = subtotal * 1.16
                                    result = enlace.altContrato(Medidor, consumobimestral)
                                    result = enlace.Reg_Recibo(consumobimestral, Medidor, 0, contratos.Rows(0).Item(3), tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(0).Item(0))
                                    indi = indi + 1

                                End If

                            End If

                        End If







                    End If













                    'If (bimestre = 0) Then
                    '    If consumo.Rows.Count <= 0 Then
                    '        MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                    '        tarifaIn = False
                    '        contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                    '        servicio = Val(contratos.Rows(0).Item(1))
                    '        bimestre = bimestre + 1
                    '        indi = indi + 1

                    '    Else
                    '        consumobimestral = consumobimestral + consumo.Rows(indi).Item(4)
                    '        Dim done As Boolean
                    '        done = enlace.altConsumo(consumo.Rows(indi).Item(0))
                    '        bimestre = bimestre + 1
                    '        indi = indi + 1

                    '    End If

                    'ElseIf (bimestre = 1) Then
                    '    bimestre = bimestre + 1
                    '    If consumo.Rows.Count <= 0 Then
                    '        MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                    '        tarifaIn = False
                    '        contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                    '        servicio = Val(contratos.Rows(0).Item(1))
                    '        indi = indi + 1

                    '    ElseIf counting > indi Then


                    '        consumobimestral = consumobimestral + consumo.Rows(indi).Item(4)

                    '        tarifa = enlace.getSortedTarifa(consumo.Rows(indi).Item(2), consumo.Rows(indi).Item(1))
                    '        If tarifa.Rows.Count <= 0 Then
                    '            MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                    '            tarifaIn = False
                    '            contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                    '            servicio = Val(contratos.Rows(0).Item(1))
                    '            indi = indi + 1

                    '        Else
                    '            tarifaIn = Val(tarifa.Rows(0).Item(6))
                    '            If (tarifaIn = False) Then
                    '                contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))

                    '                ' subtotal = Val(consumo.Rows(indi).Item(4))

                    '                If (consumo.Rows(indi).Item(4) < tarifa.Rows(0).Item(7)) Then

                    '                    subtotal = consumobimestral + consumo.Rows(indi).Item(4) * tarifa.Rows(0).Item(3)

                    '                ElseIf (consumo.Rows(indi).Item(4) < tarifa.Rows(0).Item(8)) Then

                    '                    subtotal = consumobimestral + consumo.Rows(indi).Item(4) * tarifa.Rows(0).Item(4)

                    '                Else
                    '                    subtotal = consumobimestral + consumo.Rows(indi).Item(4) * tarifa.Rows(0).Item(5)
                    '                End If
                    '                Cliente = contratos.Rows(0).Item(3)
                    '                total = subtotal * 1.16
                    '                result = enlace.Reg_Recibo(consumobimestral, consumo.Rows(indi).Item(3), 0, Cliente, tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(indi).Item(0))
                    '                indi = indi + 1
                    '                consumobimestral = 0

                    '                If counting > indi Then


                    '                    contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                    '                    servicio = Val(contratos.Rows(0).Item(1))
                    '                End If

                    '            Else
                    '                MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                    '                indi = indi + 1

                    '                If counting > indi Then
                    '                    contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                    '                    servicio = Val(contratos.Rows(0).Item(1))
                    '                End If

                    '            End If

                    '        End If



                    '    End If


                    'End If



                End If


            End If



        End While

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

    Private Sub Recibo_PDF_Click(sender As Object, e As EventArgs) Handles Recibo_PDF.Click


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

        If (TextBox_AnoConsulta.Text <> Nothing) Then
            ano = Integer.Parse(TextBox_AnoConsulta.Text)
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


        'Dim enlace As New EnlaceBD
        'Dim tablaaux As New DataTable
        'Dim ano As Integer
        'Dim mes As Integer? = Nothing
        'Dim Numero_Medidor As Integer? = Nothing
        'Dim Numero_de_Servicio As Integer
        'Dim Numero_Medidor2 As String
        'Dim ano2 As String
        'Dim mes2 As String
        'Dim curp As String


        'Dim trans As New clsConversion
        'Dim Nombre_Usuario As String
        'Dim serv As Boolean
        'Dim Medidor As String
        'Dim consumo As Integer
        'Dim numero As String




        'If (ComboBox2.Text <> Nothing) Then
        '    Numero_Medidor = Integer.Parse(ComboBox2.Text)
        'End If

        'If (ComboBox4.Text <> Nothing) Then
        '    ano = Integer.Parse(ComboBox4.Text)
        'End If

        'If (TextBox_Mes.Text <> Nothing) Then
        '    mes = Integer.Parse(TextBox_Mes.Text)
        'End If


        'tablaaux = enlace.ReciboPDFV(ano, mes, Numero_Medidor, Numero_de_Servicio)


        'Dim Index As Integer


        'Dim Tarifa As New DataTable
        'Dim Recibo As New DataTable
        'Dim Contrato As New DataTable

        'Contrato = enlace.getSortedContrato(Numero_Medidor)
        'Recibo = enlace.getRecibodataCURPactivo(Contrato.Rows(0).Item(3))


        'If (Recibo.Rows.Count > 0) Then
        '    'Consumo_Label.Text = Recibo.Rows(Index).Item(2)

        '    'Tarifa = enlace.getTarifaSortID(Recibo.Rows(Index).Item(3))
        '    'consumo = Val(Recibo.Rows(Index).Item(2))
        '    'Dim basico As Integer
        '    'Dim medium As Integer
        '    'basico = Val(Tarifa.Rows(0).Item(7))
        '    'medium = Val(Tarifa.Rows(0).Item(7))
        '    'If (consumo < basico) Then
        '    '    Tarifa_Label.Text = "Consumo Basico"
        '    '    Tasa_Label.Text = Tarifa.Rows(0).Item(3)
        '    'ElseIf (consumo < medium) Then
        '    '    Tarifa_Label.Text = "Consumo Medio"
        '    '    Tasa_Label.Text = Tarifa.Rows(0).Item(4)
        '    'Else
        '    '    Tarifa_Label.Text = "Consumo Excedente"
        '    '    Tasa_Label.Text = Tarifa.Rows(0).Item(5)
        'End If


        '    Dim cuerda As String
        '    Dim Servicio As String = " "

        'If (Numero_de_Servicio = 0) Then
        '    Servicio = "Domestico"
        'ElseIf (Numero_de_Servicio = 1) Then
        '    Servicio = "Industrial"
        'End If


        'mes2 = mes
        'ano2 = ano
        'Numero_Medidor2 = Numero_Medidor

        'cuerda = "Recibo de Luz" + "_" + Numero_Medidor2 + "_" + ano2 + "_" + mes2 + ".pdf"

        'Dim pdfDoc As New Document(iTextSharp.text.PageSize.A4, 15.0F, 15.0F, 30.0F, 30.0F)
        'Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(cuerda, FileMode.Create))


        'Dim Fot8 As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL))
        'Dim FontB8 As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD))
        'Dim FontB12 As New Font(FontFactory.GetFont(FontFactory.HELVETICA, 16, iTextSharp.text.Font.BOLD))
        'Dim CVacio As PdfPCell = New PdfPCell(New Phrase(""))
        'CVacio.Border = 0
        'pdfDoc.Open()

        'Dim Table1 As PdfPTable = New PdfPTable(3)
        'Dim Col1 As PdfPCell
        'Dim Col2 As PdfPCell
        'Dim Col3 As PdfPCell
        'Dim Col4 As PdfPCell
        'Dim Col5 As PdfPCell
        'Dim Col6 As PdfPCell
        'Dim ILine As Integer
        'Dim iFila As Integer
        'Table1.WidthPercentage = 95

        'Dim widths As Single() = New Single() {4.0F, 8.0F, 8.0F}
        'Table1.SetWidths(widths)
        '    Col1 = New PdfPCell(New Phrase(enlace.ObtenerCliente(curp), FontB12))
        '    Col1.Border = 0
        'Table1.AddCell(CVacio)
        'Table1.AddCell(Col1)
        'Table1.AddCell(CVacio)

        'Table1.WidthPercentage = 95
        'widths = New Single() {3.33F, 3.33F, 3.33F, 3.33F, 3.33F, 3.33F}
        'Col1 = New PdfPCell(New Phrase(tablaaux.Columns(0).ColumnName, FontB8))
        'Table1.AddCell(Col1)



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
        'pdfDoc.Close()
        'Process.Start(cuerda)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.MaxLength = 2

        If (Val(TextBox1.Text) = 0) Then

            MsgBox("mes invalido")
        ElseIf (Val(TextBox1.Text) > 12) Then
            TextBox1.Clear()
            MsgBox("mes invalido")
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.MaxLength = 4
        If (Val(TextBox2.Text) = 0) Then

            MsgBox("Año invalido")
        ElseIf (Val(TextBox2.Text) > 2050) Then
            TextBox2.Clear()
            MsgBox("Año invalido")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim enlace As New EnlaceBD
        Dim Contrato As New DataTable
        Dim Medidor As Integer
        Dim fecha As Date
        Dim ano As Integer
        Dim mes As Integer
        Dim anoBox As Integer
        Dim mesBox As Integer
        Dim servicio As Boolean
        Medidor = ListBox_Contratos.Text
        Contrato = enlace.getSortedContrato(Medidor)
        servicio = Contrato.Rows(0).Item(1)
        fecha = Contrato.Rows(0).Item(2)
        ano = Year(fecha)
        mes = Month(fecha)

        If (Val(TextBox1.Text) = 0 Or Val(TextBox2.Text) = 0) Then
            MsgBox("Campos vacios error")

        Else
            mesBox = Val(TextBox1.Text)
            anoBox = Val(TextBox2.Text)
            If (ano > anoBox) Then
                MsgBox("aÃ±o invalido")
                TextBox2.Clear()
            ElseIf (ano = anoBox And mes > mesBox) Then
                MsgBox("Mes invalido")
                TextBox1.Clear()
            ElseIf (servicio) Then
                Dim consumo As New DataTable
                consumo = enlace.getConsumobyDate(Medidor, mesBox, anoBox)
                If (consumo.Rows.Count < 1) Then
                    MsgBox("consumo invalido o inexistente")
                Else
                    Dim tarifa As New DataTable
                    tarifa = enlace.getSortedTarifaInd(mesBox, anoBox)
                    If (tarifa.Rows.Count < 1) Then
                        MsgBox("tarifa invalida o inexistente")

                    Else


                        Dim subtotal As Decimal
                        Dim total As Decimal
                        Dim basico As Decimal
                        Dim medio As Decimal
                        Dim excedente As Decimal
                        Dim pBasico As Decimal
                        Dim pMedio As Decimal
                        Dim pExcedente As Decimal
                        Dim watts As Decimal
                        basico = tarifa.Rows(0).Item(7)
                        medio = tarifa.Rows(0).Item(8)
                        pBasico = tarifa.Rows(0).Item(3)
                        pMedio = tarifa.Rows(0).Item(4)
                        pExcedente = tarifa.Rows(0).Item(5)

                        Dim diff1 As Decimal

                        diff1 = medio - basico
                        excedente = tarifa.Rows(0).Item(9)
                        watts = consumo.Rows(0).Item(4)
                        Dim tir As Decimal
                        Dim ter As Decimal
                        Dim tar As Decimal
                        tir = 0
                        ter = 0
                        tar = 0
                        If (watts > medio) Then 'Excedente
                            tir = basico * pBasico
                            ter = diff1 * pMedio
                            tar = (watts - (diff1 + basico)) * pExcedente
                            subtotal = tir + ter + tar
                        ElseIf (watts <= medio And watts > basico) Then 'Medio
                            tir = basico * pBasico
                            ter = (watts - basico) * pMedio

                            subtotal = tir + ter
                        ElseIf (watts <= basico) Then 'Basico
                            tir = watts * pBasico
                            subtotal = tir

                        End If
                        total = subtotal * 1.16
                        Dim result As Boolean
                        Dim con As New Decimal
                        Contrato = enlace.getSortedContrato(Medidor)
                        con = Contrato.Rows(0).Item(5) + consumo.Rows(0).Item(4)

                        result = enlace.altContrato(Medidor, con)

                        result = enlace.Reg_Recibo(consumo.Rows(0).Item(4), Medidor, 1, Contrato.Rows(0).Item(3), tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(0).Item(0))



                    End If
                End If



            ElseIf (servicio = False) Then
                Dim odd As Decimal
                odd = mes Mod 2
                Dim oddbox As Integer
                oddbox = mesBox Mod 2
                Dim previous As Integer
                Dim previousyear As Integer
                Dim consumobimestral As Integer
                If (odd > 0) Then

                    If (oddbox > 0) Then
                        MsgBox("Servicio domestico se cobra bimestralmente, error")
                    Else
                        Dim consumo As New DataTable
                        If (mesBox = 1) Then
                            previous = 12
                            previousyear = anoBox - 1
                        Else
                            previous = mesBox - 1
                            previousyear = anoBox
                        End If
                        consumo = enlace.getConsumobyDate(Medidor, previous, previousyear)
                        If (consumo.Rows.Count < 1) Then
                            MsgBox(" error, no existe consumo en mes previo")
                        Else
                            consumobimestral = consumobimestral + consumo.Rows(0).Item(4)
                            Dim result As Boolean
                            result = enlace.altConsumo(consumo.Rows(0).Item(0))
                            consumo = enlace.getConsumobyDate(Medidor, mesBox, anoBox)
                            consumobimestral = consumobimestral + consumo.Rows(0).Item(4)
                            Dim tarifa As New DataTable
                            tarifa = enlace.getSortedTarifa(mesBox, anoBox)
                            If (tarifa.Rows.Count < 1) Then
                                MsgBox("no existe tarifa para este mes")
                            Else
                                Dim subtotal As Decimal
                                Dim subtotalbasico As Decimal
                                Dim subtotalmedio As Decimal
                                Dim subtotalexcedente As Decimal
                                Dim thisConsumo As Decimal
                                Dim total As Decimal
                                If (consumobimestral < tarifa.Rows(0).Item(7)) Then

                                    subtotal = consumobimestral * tarifa.Rows(0).Item(3)


                                ElseIf (consumobimestral < tarifa.Rows(0).Item(8)) Then

                                    subtotalbasico = tarifa.Rows(0).Item(3) * tarifa.Rows(0).Item(7)

                                    thisConsumo = consumobimestral - tarifa.Rows(0).Item(7)

                                    subtotalmedio = tarifa.Rows(0).Item(4) * thisConsumo

                                    subtotal = subtotalbasico + subtotalmedio

                                Else
                                    subtotalbasico = tarifa.Rows(0).Item(3) * tarifa.Rows(0).Item(7)
                                    subtotalmedio = tarifa.Rows(0).Item(4) * tarifa.Rows(0).Item(8)

                                    thisConsumo = consumobimestral - tarifa.Rows(0).Item(8)
                                    subtotalexcedente = thisConsumo * tarifa.Rows(0).Item(5)

                                    subtotal = subtotalbasico + subtotalmedio + subtotalexcedente

                                End If
                                total = subtotal * 1.16
                                Dim con As New Decimal
                                Contrato = enlace.getSortedContrato(Medidor)
                                con = Contrato.Rows(0).Item(5) + consumobimestral

                                result = enlace.altContrato(Medidor, con)
                                result = enlace.Reg_Recibo(consumobimestral, Medidor, 0, Contrato.Rows(0).Item(3), tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(0).Item(0))
                            End If

                        End If

                    End If
                ElseIf (odd = 0) Then

                    If (oddbox = 0) Then
                        MsgBox("Servicio domestico se cobra bimestralmente, error")
                    Else
                        Dim consumo As New DataTable
                        If (mesBox = 1) Then
                            previous = 12
                            previousyear = anoBox - 1
                        Else
                            previous = mesBox - 1
                            previousyear = anoBox
                        End If
                        consumo = enlace.getConsumobyDate(Medidor, previous, previousyear)
                        If (consumo.Rows.Count < 1) Then
                            MsgBox(" error, no existe consumo en mes previo")
                        Else
                            consumobimestral = consumobimestral + consumo.Rows(0).Item(4)
                            Dim result As Boolean
                            result = enlace.altConsumo(consumo.Rows(0).Item(0))
                            consumo = enlace.getConsumobyDate(Medidor, mesBox, anoBox)
                            consumobimestral = consumobimestral + consumo.Rows(0).Item(4)
                            Dim tarifa As New DataTable
                            tarifa = enlace.getSortedTarifa(mesBox, anoBox)
                            If (tarifa.Rows.Count < 1) Then
                                MsgBox("no existe tarifa para este mes")
                            Else
                                Dim subtotal As Decimal

                                Dim total As Decimal
                                Dim basico As Decimal
                                Dim medio As Decimal
                                Dim excedente As Decimal
                                Dim pBasico As Decimal
                                Dim pMedio As Decimal
                                Dim pExcedente As Decimal
                                Dim watts As Decimal
                                basico = tarifa.Rows(0).Item(7)
                                medio = tarifa.Rows(0).Item(8)
                                pBasico = tarifa.Rows(0).Item(3)
                                pMedio = tarifa.Rows(0).Item(4)
                                pExcedente = tarifa.Rows(0).Item(5)

                                Dim diff1 As Decimal

                                diff1 = medio - basico
                                excedente = tarifa.Rows(0).Item(9)
                                watts = consumobimestral
                                Dim tir As Decimal
                                Dim ter As Decimal
                                Dim tar As Decimal
                                tir = 0
                                ter = 0
                                tar = 0
                                If (watts > medio) Then 'Excedente
                                    tir = basico * pBasico
                                    ter = diff1 * pMedio
                                    tar = (watts - (diff1 + basico)) * pExcedente
                                    subtotal = tir + ter + tar
                                ElseIf (watts <= medio And watts > basico) Then 'Medio
                                    tir = basico * pBasico
                                    ter = (watts - basico) * pMedio

                                    subtotal = tir + ter
                                ElseIf (watts <= basico) Then 'Basico
                                    tir = watts * pBasico
                                    subtotal = tir

                                End If
                                total = subtotal * 1.16
                                Dim con As New Decimal
                                Contrato = enlace.getSortedContrato(Medidor)
                                con = Contrato.Rows(0).Item(5) + consumobimestral

                                result = enlace.altContrato(Medidor, con)
                                result = enlace.Reg_Recibo(consumobimestral, Medidor, 0, Contrato.Rows(0).Item(3), tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(0).Item(0))
                            End If

                        End If

                    End If







                End If




            End If

        End If



    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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

        Dim tarifaIn As Boolean

        Dim bimestre As Int16
        bimestre = 0
        Dim mesBox As Integer
        Dim anoBox As Integer
        Dim Medidor As Integer
        While (counting > indi)




            mesC = consumo.Rows(indi).Item(2)
            mesBox = consumo.Rows(indi).Item(2)
            anoBox = consumo.Rows(indi).Item(1)
            anoC = consumo.Rows(indi).Item(1)
            contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))

            servicio = Val(contratos.Rows(0).Item(1))
            mes = Month(contratos.Rows(0).Item(2))
            ano = Year(contratos.Rows(0).Item(2))
            Medidor = consumo.Rows(indi).Item(3)




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


                    Dim basico As Decimal
                    Dim medio As Decimal
                    Dim excedente As Decimal
                    Dim pBasico As Decimal
                    Dim pMedio As Decimal
                    Dim pExcedente As Decimal
                    Dim watts As Decimal
                    basico = tarifa.Rows(0).Item(7)
                    medio = tarifa.Rows(0).Item(8)
                    pBasico = tarifa.Rows(0).Item(3)
                    pMedio = tarifa.Rows(0).Item(4)
                    pExcedente = tarifa.Rows(0).Item(5)

                    Dim diff1 As Decimal

                    diff1 = medio - basico
                    excedente = tarifa.Rows(0).Item(9)
                    watts = consumo.Rows(indi).Item(4)
                    Dim tir As Decimal
                    Dim ter As Decimal
                    Dim tar As Decimal
                    tir = 0
                    ter = 0
                    tar = 0
                    If (watts > medio) Then 'Excedente
                        tir = basico * pBasico
                        ter = medio * pMedio
                        tar = (watts - (medio + basico))
                        tar = tar * pExcedente
                        subtotal = tir + ter + tar
                    ElseIf (watts <= medio And watts > basico) Then 'Medio
                        tir = basico * pBasico
                        ter = (watts - basico) * pMedio

                        subtotal = tir + ter
                    ElseIf (watts <= basico) Then 'Basico
                        tir = watts * pBasico
                        subtotal = tir

                    End If
                    Cliente = contratos.Rows(0).Item(3)
                    total = subtotal * 1.16
                    Dim Contrato As New DataTable
                    Dim con As New Decimal
                    Contrato = enlace.getSortedContrato(Medidor)
                    con = Contrato.Rows(0).Item(5) + consumo.Rows(indi).Item(4)

                    result = enlace.altContrato(Medidor, con)
                    result = enlace.Reg_Recibo(consumo.Rows(indi).Item(4), consumo.Rows(indi).Item(3), 1, Cliente, tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(indi).Item(0))
                    indi = indi + 1

                Else
                    MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                    indi = indi + 1

                End If
            End If
            indi = indi + 1

        End While
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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

        Dim tarifaIn As Boolean

        Dim bimestre As Int16
        bimestre = 0
        Dim mesBox As Integer
        Dim anoBox As Integer
        Dim Medidor As Integer
        While (counting > indi)




            mesC = consumo.Rows(indi).Item(2)
            mesBox = consumo.Rows(indi).Item(2)
            anoBox = consumo.Rows(indi).Item(1)
            anoC = consumo.Rows(indi).Item(1)
            contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
            servicio = Val(contratos.Rows(0).Item(1))
            mes = Month(contratos.Rows(0).Item(2))
            ano = Year(contratos.Rows(0).Item(2))
            Medidor = consumo.Rows(indi).Item(3)

            If servicio = False Then
                Dim odd As Decimal
                odd = mes Mod 2
                Dim oddbox As Integer
                oddbox = mesBox Mod 2
                Dim previous As Integer
                Dim previousyear As Integer
                Dim consumobimestral As Integer
                If (odd > 0) Then

                    If (oddbox > 0) Then
                        indi = indi + 1
                    Else

                        If (mesBox = 1) Then
                            previous = 12
                            previousyear = anoBox - 1
                        Else
                            previous = mesBox - 1
                            previousyear = anoBox
                        End If
                        consumo = enlace.getConsumobyDate(Medidor, previous, previousyear)
                        If (consumo.Rows.Count < 1) Then

                            indi = indi + 1
                        Else
                            consumobimestral = consumobimestral + consumo.Rows(0).Item(4)

                            result = enlace.altConsumo(consumo.Rows(0).Item(0))
                            consumo = enlace.getConsumobyDate(Medidor, mesBox, anoBox)
                            consumobimestral = consumobimestral + consumo.Rows(0).Item(4)

                            tarifa = enlace.getSortedTarifa(mesBox, anoBox)
                            If (tarifa.Rows.Count < 1) Then
                                MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                                indi = indi + 1

                            Else

                                Dim basico As Decimal
                                Dim medio As Decimal
                                Dim excedente As Decimal
                                Dim pBasico As Decimal
                                Dim pMedio As Decimal
                                Dim pExcedente As Decimal
                                Dim watts As Decimal
                                basico = tarifa.Rows(0).Item(7)
                                medio = tarifa.Rows(0).Item(8)
                                pBasico = tarifa.Rows(0).Item(3)
                                pMedio = tarifa.Rows(0).Item(4)
                                pExcedente = tarifa.Rows(0).Item(5)

                                Dim diff1 As Decimal

                                diff1 = medio - basico
                                excedente = tarifa.Rows(0).Item(9)
                                watts = consumobimestral
                                Dim tir As Decimal
                                Dim ter As Decimal
                                Dim tar As Decimal
                                tir = 0
                                ter = 0
                                tar = 0
                                If (watts > medio) Then 'Excedente
                                    tir = basico * pBasico
                                    ter = medio * pMedio
                                    tar = (watts - (medio + basico))
                                    tar = tar * pExcedente
                                    subtotal = tir + ter + tar
                                ElseIf (watts <= medio And watts > basico) Then 'Medio
                                    tir = basico * pBasico
                                    ter = (watts - basico) * pMedio

                                    subtotal = tir + ter
                                ElseIf (watts <= basico) Then 'Basico
                                    tir = watts * pBasico
                                    subtotal = tir

                                End If
                                total = subtotal * 1.16
                                Dim Contrato As New DataTable
                                Dim con As New Decimal
                                Contrato = enlace.getSortedContrato(Medidor)
                                con = Contrato.Rows(0).Item(5) + consumobimestral

                                result = enlace.altContrato(Medidor, con)
                                result = enlace.Reg_Recibo(consumobimestral, Medidor, 0, contratos.Rows(0).Item(3), tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(0).Item(0))
                                indi = indi + 1

                            End If

                        End If

                    End If
                ElseIf (odd = 0) Then

                    If (oddbox = 0) Then
                        indi = indi + 1

                    Else

                        If (mesBox = 1) Then
                            previous = 12
                            previousyear = anoBox - 1
                        Else
                            previous = mesBox - 1
                            previousyear = anoBox
                        End If
                        consumo = enlace.getConsumobyDate(Medidor, previous, previousyear)
                        If (consumo.Rows.Count < 1) Then
                            indi = indi + 1

                        Else
                            consumobimestral = consumobimestral + consumo.Rows(0).Item(4)

                            result = enlace.altConsumo(consumo.Rows(0).Item(0))
                            consumo = enlace.getConsumobyDate(Medidor, mesBox, anoBox)
                            consumobimestral = consumobimestral + consumo.Rows(0).Item(4)

                            tarifa = enlace.getSortedTarifa(mesBox, anoBox)
                            If (tarifa.Rows.Count < 1) Then
                                MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                                indi = indi + 1

                            Else

                                Dim basico As Decimal
                                Dim medio As Decimal
                                Dim excedente As Decimal
                                Dim pBasico As Decimal
                                Dim pMedio As Decimal
                                Dim pExcedente As Decimal
                                Dim watts As Decimal
                                basico = tarifa.Rows(0).Item(7)
                                medio = tarifa.Rows(0).Item(8)
                                pBasico = tarifa.Rows(0).Item(3)
                                pMedio = tarifa.Rows(0).Item(4)
                                pExcedente = tarifa.Rows(0).Item(5)

                                Dim diff1 As Decimal

                                diff1 = medio - basico
                                excedente = tarifa.Rows(0).Item(9)
                                watts = consumobimestral
                                Dim tir As Decimal
                                Dim ter As Decimal
                                Dim tar As Decimal
                                tir = 0
                                ter = 0
                                tar = 0
                                If (watts > medio) Then 'Excedente
                                    tir = basico * pBasico
                                    ter = diff1 * pMedio
                                    tar = (watts - (diff1 + basico)) * pExcedente
                                    subtotal = tir + ter + tar
                                ElseIf (watts <= medio And watts > basico) Then 'Medio
                                    tir = basico * pBasico
                                    ter = (watts - basico) * pMedio

                                    subtotal = tir + ter
                                ElseIf (watts <= basico) Then 'Basico
                                    tir = watts * pBasico
                                    subtotal = tir

                                End If
                                total = subtotal * 1.16
                                Dim Contrato As New DataTable
                                Dim con As New Decimal
                                Contrato = enlace.getSortedContrato(Medidor)
                                con = Contrato.Rows(0).Item(5) + consumobimestral

                                result = enlace.altContrato(Medidor, con)
                                result = enlace.Reg_Recibo(consumobimestral, Medidor, 0, contratos.Rows(0).Item(3), tarifa.Rows(0).Item(0), subtotal, total, total, consumo.Rows(0).Item(0))
                                indi = indi + 1

                            End If

                        End If

                    End If







                End If














            End If

            indi = indi + 1




        End While
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19_TotalNum.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        Dim trans As New clsConversion
        Dim enlace As New EnlaceBD
        Dim Medidor As Integer
        Dim Index As Integer
        Dim tablaaux As New DataTable
        Dim NombreClient As New DataTable
        Dim contratos As New DataTable

        'Dim CURP As New DataTable
        Dim Texto As New Integer
        Dim serv As Boolean
        Dim numero As String
        Dim consumo As Integer

        'Dim Servicio As New Integer

        'Servicio = ComboBox1.SelectedItem.ToString
        'tablaaux = enlace.ReciboServicio(Servicio)

        Texto = Val(ComboBox2.Text)

        If Texto > 0 Then


            Medidor = Texto
            contratos = enlace.getSortedContrato(Medidor)
            CURP = contratos.Rows(0).Item(3)
            Index = ComboBox2.SelectedIndex
            NombreClient = enlace.GetClienteNomb(CURP)
            Label9_Nombre.Text = NombreClient.Rows(0).Item(0)
            Label16_Domicilio.Text = contratos.Rows(0).Item(0)
            Domicilio_Label.Text = contratos.Rows(0).Item(0)


        End If

    End Sub

    Public Class clsConversion

        Dim mOnesArray(8) As String
        Dim mOneTensArray(9) As String
        Dim mTensArray(7) As String
        Dim mPlaceValues(4) As String


        Public Sub New()

            mOnesArray(0) = "uno"
            mOnesArray(1) = "dos"
            mOnesArray(2) = "tres"
            mOnesArray(3) = "cuatro"
            mOnesArray(4) = "cinco"
            mOnesArray(5) = "seis"
            mOnesArray(6) = "siete"
            mOnesArray(7) = "ocho"
            mOnesArray(8) = "nueve"

            mOneTensArray(0) = "diez"
            mOneTensArray(1) = "once"
            mOneTensArray(2) = "doce"
            mOneTensArray(3) = "trece"
            mOneTensArray(4) = "catorce"
            mOneTensArray(5) = "quince"
            mOneTensArray(6) = "dieciseis"
            mOneTensArray(7) = "diecisiete"
            mOneTensArray(8) = "dieciocho"
            mOneTensArray(9) = "diecinueve"

            mTensArray(0) = "veinte"
            mTensArray(1) = "treinta"
            mTensArray(2) = "cuarenta"
            mTensArray(3) = "cincuenta"
            mTensArray(4) = "sesenta"
            mTensArray(5) = "setenta"
            mTensArray(6) = "ochenta"
            mTensArray(7) = "noventa"

            mPlaceValues(0) = "cientos"
            mPlaceValues(1) = "mil"
            mPlaceValues(2) = "millon"
            mPlaceValues(3) = "billon"
            mPlaceValues(4) = "trillon"

        End Sub


        Protected Function GetOnes(ByVal OneDigit As Integer) As String

            GetOnes = ""

            If OneDigit = 0 Then
                Exit Function
            End If

            GetOnes = mOnesArray(OneDigit - 1)

        End Function


        Protected Function GetTens(ByVal TensDigit As Integer) As String

            GetTens = ""

            If TensDigit = 0 Or TensDigit = 1 Then
                Exit Function
            End If

            GetTens = mTensArray(TensDigit - 2)

        End Function


        Public Function ConvertNumberToWords(ByVal NumberValue As String) As String

            Dim Delimiter As String = " "
            Dim TensDelimiter As String = "-"
            Dim mNumberValue As String = ""
            Dim mNumbers As String = ""
            Dim mNumWord As String = ""
            Dim mFraction As String = ""
            Dim mNumberStack() As String
            Dim j As Integer = 0
            Dim i As Integer = 0
            Dim mOneTens As Boolean = False

            ConvertNumberToWords = ""

            ' validate input
            Try
                j = CDbl(NumberValue)
            Catch ex As Exception
                ConvertNumberToWords = "Invalid input."
                Exit Function
            End Try

            ' get fractional part {if any}
            If InStr(NumberValue, ".") = 0 Then
                ' no fraction
                mNumberValue = NumberValue
            Else
                mNumberValue = Microsoft.VisualBasic.Left(NumberValue, InStr(NumberValue, ".") - 1)
                mFraction = Mid(NumberValue, InStr(NumberValue, ".")) ' + 1)
                mFraction = Math.Round(CSng(mFraction), 2) * 100

                If CInt(mFraction) = 0 Then
                    mFraction = ""
                Else
                    mFraction = "&& " & mFraction & "/100"
                End If
            End If
            mNumbers = mNumberValue.ToCharArray

            ' move numbers to stack/array backwards
            For j = mNumbers.Length - 1 To 0 Step -1
                ReDim Preserve mNumberStack(i)

                mNumberStack(i) = mNumbers(j)
                i += 1
            Next

            For j = mNumbers.Length - 1 To 0 Step -1
                Select Case j
                    Case 0, 3, 6, 9, 12
                        ' ones  value
                        If Not mOneTens Then
                            mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter
                        End If

                        Select Case j
                            Case 3
                                ' thousands
                                mNumWord &= mPlaceValues(1) & Delimiter

                            Case 6
                                ' millions
                                mNumWord &= mPlaceValues(2) & Delimiter

                            Case 9
                                ' billions
                                mNumWord &= mPlaceValues(3) & Delimiter

                            Case 12
                                ' trillions
                                mNumWord &= mPlaceValues(4) & Delimiter
                        End Select


                    Case Is = 1, 4, 7, 10, 13
                        ' tens value
                        If Val(mNumberStack(j)) = 0 Then
                            mNumWord &= GetOnes(Val(mNumberStack(j - 1))) & Delimiter
                            mOneTens = True
                            Exit Select
                        End If

                        If Val(mNumberStack(j)) = 1 Then
                            mNumWord &= mOneTensArray(Val(mNumberStack(j - 1))) & Delimiter
                            mOneTens = True
                            Exit Select
                        End If

                        mNumWord &= GetTens(Val(mNumberStack(j)))

                        ' this places the tensdelimiter; check for succeeding 0
                        If Val(mNumberStack(j - 1)) <> 0 Then
                            mNumWord &= TensDelimiter
                        End If
                        mOneTens = False

                    Case Else
                        ' hundreds value 
                        mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter

                        If Val(mNumberStack(j)) <> 0 Then
                            mNumWord &= mPlaceValues(0) & Delimiter
                        End If
                End Select
            Next

            Return mNumWord & mFraction

        End Function




    End Class

    Private Sub Consulta_Click(sender As Object, e As EventArgs) Handles Consulta.Click

        Dim trans As New clsConversion
        Dim enlace As New EnlaceBD
        Dim Medidor As Integer
        Dim Index As Integer
        Dim tablaaux As New DataTable
        Dim Tarifa As New DataTable
        Dim Recibo As New DataTable
        Dim contratos As New DataTable
        Dim NombreClient As New DataTable
        'Dim CURP As New DataTable

        Dim serv As Boolean
        Dim numero As String
        Dim consumo As Integer
        Dim ano As Integer
        Dim mes As Integer
        Dim IVA As Decimal

        Medidor = Val(ComboBox2.Text)

        contratos = enlace.getSortedContrato(Medidor)
        Index = ComboBox2.SelectedIndex
        NombreClient = enlace.GetClienteNomb(CURP)

        CURP = contratos.Rows(0).Item(3)

        Recibo = enlace.getRecibodataCURPactivo(CURP)
        NombreClient = enlace.GetClienteNomb(CURP)
        If (Recibo.Rows.Count > 0) Then

            mes = Val(TextBox_Mes.Text)
            ano = Val(TextBox_AnoConsulta.Text)

            If (ComboBox1.SelectedIndex = 0) Then
                Tarifa = enlace.getSortedTarifa(mes, ano)
                Label24_Servicio.Text = "Domestico"
            Else
                Tarifa = enlace.getSortedTarifaInd(mes, ano)
                Label24_Servicio.Text = "Industrial"

            End If

            Recibo = enlace.getdataReciboINFO(Tarifa.Rows(0).Item(0), CURP)

            If (Recibo.Rows.Count > 0) Then
                Label25_Medidor.Text = ComboBox2.Text
                Label26_PeriodoFact.Text = TextBox_Mes.Text
                Label9_PeriodoFact2.Text = TextBox_AnoConsulta.Text

                numero = trans.ConvertNumberToWords(Recibo.Rows(0).Item(10))
                Label19_TotalNum.Text = numero
                Label20_TotalPagar.Text = (Recibo.Rows(0).Item(10))
                Label57_Total.Text = (Recibo.Rows(0).Item(10))

                'Consumos
                Label37_LectAct.Text = (contratos.Rows(0).Item(5))





                If (Recibo.Rows(0).Item(4) > Tarifa.Rows(0).Item(7)) Then

                    Label40_TotalBasic.Text = (Tarifa.Rows(0).Item(7))
                    Label43_PreciBasic.Text = (Tarifa.Rows(0).Item(7)) * (Tarifa.Rows(0).Item(3))

                    If (Recibo.Rows(0).Item(4) > Tarifa.Rows(0).Item(8)) Then
                        Dim Tar As Decimal
                        Dim Ter As Decimal

                        Ter = (Tarifa.Rows(0).Item(8)) - (Tarifa.Rows(0).Item(7))

                        Label41_TotalInter.Text = Ter

                        Tar = Recibo.Rows(0).Item(4) - Tarifa.Rows(0).Item(8)

                        Label16_Excedente.Text = Tar

                        Label45_SubInter.Text = Ter * Tarifa.Rows(0).Item(4)
                        Label47_Total.Text = Tar * Tarifa.Rows(0).Item(5)

                    Else

                        Dim Inter As Decimal
                        Inter = (Recibo.Rows(0).Item(4)) - (Tarifa.Rows(0).Item(7))
                        Label41_TotalInter.Text = Inter

                        Label45_SubInter.Text = Inter * Tarifa.Rows(0).Item(4)

                    End If

                Else
                    Label40_TotalBasic.Text = (Recibo.Rows(0).Item(4))
                    Label43_PreciBasic.Text = (Recibo.Rows(0).Item(4)) * (Tarifa.Rows(0).Item(3))

                End If


                Label46_SubBasic.Text = (Tarifa.Rows(0).Item(3))
                Label44_PreciInter.Text = (Tarifa.Rows(0).Item(4))
                Label16_PrecioExced.Text = (Tarifa.Rows(0).Item(5))

                'Subtotal
                Label39_TotalP.Text = (Recibo.Rows(0).Item(4))
                Label53_Energia.Text = (Recibo.Rows(0).Item(9))
                IVA = Recibo.Rows(0).Item(9) * 0.16
                Label54_IVA.Text = IVA
                Label55_Adeudo.Text = (Recibo.Rows(0).Item(11))
            Else

                MsgBox("ERROR")
            End If


        Else

            MsgBox("ERROR")




        End If


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim enlace As New EnlaceBD

        Dim tablaaux As New DataTable
        Dim anios As New List(Of Integer)
        Dim Servicio As New Integer

        Servicio = ComboBox1.SelectedItem.ToString
        tablaaux = enlace.ReciboServicio(Servicio)

        If (tablaaux.Rows.Count > 0) Then
            ComboBox2.DataSource = tablaaux
            ComboBox2.DisplayMember = "Numero_Medidor"
        End If



    End Sub


    Private Sub TextBox_AnoConsulta_TextChanged(sender As Object, e As EventArgs) Handles TextBox_AnoConsulta.TextChanged
        TextBox_AnoConsulta.MaxLength = 4
        If (Val(TextBox_AnoConsulta.Text) = 0) Then

            MsgBox("Año invalido")
        ElseIf (Val(TextBox_AnoConsulta.Text) > 2050) Then
            TextBox_AnoConsulta.Clear()
            MsgBox("Año invalido")
        End If
    End Sub
End Class

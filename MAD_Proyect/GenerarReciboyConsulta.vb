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

        tablaaux = enlace.getdataContrato()


        If (tablaaux.Rows.Count > 0) Then
            ListBox_Contratos.DataSource = tablaaux
            ListBox_Contratos.DisplayMember = "Numero_Medidor"


        End If


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

        DataGridView1.DataSource = consumo

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
                            indi = indi + 1
                            contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                            servicio = Val(contratos.Rows(0).Item(1))
                            bimestre = bimestre + 1
                        Else
                            consumobimestral = consumobimestral + consumo.Rows(indi).Item(4)
                            indi = indi + 1
                            bimestre = bimestre + 1
                        End If

                    ElseIf (bimestre = 1) Then
                        If consumo.Rows.Count <= 0 Then
                            MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                            tarifaIn = False
                            indi = indi + 1
                            contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                            servicio = Val(contratos.Rows(0).Item(1))
                            bimestre = bimestre + 1
                        Else
                            consumobimestral = consumobimestral + consumo.Rows(indi).Item(4)
                            bimestre = bimestre + 1
                            tarifa = enlace.getSortedTarifa(consumo.Rows(indi).Item(2), consumo.Rows(indi).Item(1))
                            If tarifa.Rows.Count <= 0 Then
                                MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                                tarifaIn = False
                                indi = indi + 1
                                contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                                servicio = Val(contratos.Rows(0).Item(1))
                                bimestre = bimestre + 1
                            Else
                                tarifaIn = Val(tarifa.Rows(0).Item(6))
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
                                    contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                                    servicio = Val(contratos.Rows(0).Item(1))
                                    bimestre = bimestre + 1

                                Else
                                    MsgBox("No existe tarifa aplicable para uno de los consumos registrados asi que se saltara al siguiente")
                                    indi = indi + 1
                                    contratos = enlace.getSortedContrato(consumo.Rows(indi).Item(3))
                                    servicio = Val(contratos.Rows(0).Item(1))
                                    bimestre = bimestre + 1
                                End If

                            End If

                            If (bimestre = 2) Then
                                bimestre = 0
                            End If

                        End If


                    End If



                End While


            End If









            indi = indi + 1


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
End Class
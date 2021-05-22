Imports System.IO
Public Class Cargas
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Gestion_Cliente_Button_Click(sender As Object, e As EventArgs) Handles Gestion_Cliente_Button.Click
        EmpleadoGral.Show()
        Me.Hide()
    End Sub

    Private Sub Button_Contrato_Click(sender As Object, e As EventArgs) Handles Button_Contrato.Click
        Contratos.Show()
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



    Private Sub CrearTarifa_Click(sender As Object, e As EventArgs) Handles CrearTarifa.Click


        Dim enlace As New EnlaceBD

        Dim precioBajo As Decimal
        Dim precioMedio As Decimal
        Dim precioExcedente As Decimal
        Dim consumoBajo As Integer
        Dim consumoMedio As Integer
        Dim consumoExcedente As Integer

        Dim uso As Integer
        Dim Mes As Integer
        Dim Ano As Integer


        Dim result As Boolean = False


        If (TextBox_PrecioBajo.Text <> "") And (TextBox_PrecioExcedente.Text <> "") And (ComboBox_Uso.SelectedIndex > -1) And (TextBox_PrecioMedio.Text <> "") And (TextBox_ConsumoBasico.Text <> "") And (TextBox_ConsumoMedio.Text <> "") And (TextBox_ConsumoExcedente.Text <> "") Then

            uso = ComboBox_Uso.SelectedIndex


            precioBajo = Val(TextBox_PrecioBajo.Text)
            precioExcedente = Val(TextBox_PrecioExcedente.Text)
            precioMedio = Val(TextBox_PrecioMedio.Text)
            consumoBajo = Val(TextBox_ConsumoBasico.Text)
            consumoMedio = Val(TextBox_ConsumoMedio.Text)
            consumoExcedente = Val(TextBox_ConsumoExcedente.Text)
            Mes = Val(TextBox_Mes.Text)
            Ano = Val(TextBox_Ano.Text)

            result = enlace.Reg_Tarifa(precioBajo, precioMedio, precioExcedente, Mes, Ano, consumoBajo, consumoMedio, consumoExcedente, uso)
            MsgBox("Creado exitosamente")
        Else
            MsgBox("Faltan datos por registrar, !!REVISA!!")
        End If
    End Sub

    Private Sub TextBox_PrecioBajo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_PrecioBajo.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub
    Private Sub TextBox_Mes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Mes.KeyPress
        TextBox_Mes.MaxLength = 2
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If




    End Sub
    Private Sub TextBox_Ano_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Ano.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        TextBox_Ano.MaxLength = 4

    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        TextBox1.MaxLength = 4

    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        TextBox2.MaxLength = 2

    End Sub
    Private Sub TextBox_PrecioExcedente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_PrecioExcedente.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub
    Private Sub TextBox_PrecioMedio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_PrecioMedio.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox_ConsumoBasico_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_ConsumoBasico.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox_ConsumoMedio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_ConsumoBasico.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox_ConsumoExcedente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_ConsumoExcedente.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextWatts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextWatts.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim enlace As New EnlaceBD

        Dim Mes As Int32
        Dim ano As Int32
        Dim Watts As Int32
        Dim Medidor As Integer
        Dim result As Boolean = False

        If (TextWatts.Text <> "") And (ComboBox1.SelectedIndex > -1) Then
            Mes = Val(TextBox2.Text)
            ano = Val(TextBox1.Text)
            Medidor = Val(ComboBox1.GetItemText(ComboBox1.SelectedItem))
            Watts = Val(TextWatts.Text)




            result = enlace.Reg_Consumo(Medidor, Watts, Mes, ano)
            MsgBox("Creado exitosamente")
        Else
            MsgBox("Faltan datos por registrar, !!REVISA!!")
        End If




    End Sub

    Public Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim enlace As New EnlaceBD
        Dim result As Boolean = False
        Dim thedatatable As New DataTable
        With thedatatable


            .Columns.Add("Ano", System.Type.GetType("System.Int32"))
            .Columns.Add("Mes", System.Type.GetType("System.Int32"))
            .Columns.Add("Numero_Medidor", System.Type.GetType("System.Int32"))
            .Columns.Add("Watts", System.Type.GetType("System.Int32"))



        End With





        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFilePath As String = ""

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFilePath = fd.FileName
        End If

        Dim reader As StreamReader = New StreamReader(strFilePath)
        Dim sline As String = ""
        Try
            Dim j As Integer = 0
            Dim i As Integer

            If reader.EndOfStream Then
                MessageBox.Show("The CSV file is empty, please update",
                                "Error", MessageBoxButtons.OK)
                Application.Exit()
            End If

            While Not reader.EndOfStream
                'Dim s As String = reader.ReadLine()
                Dim lineContents() As String = Split(reader.ReadLine(), ",")
                Dim NoOfCol As Integer

                j = j + 1
                If j = 1 Then
                    NoOfCol = lineContents.Length
                End If
                If NoOfCol = lineContents.Length Then
                    For i = 0 To lineContents.Length - 1
                        'Dim str As String = lineContents(i)
                        If Trim(lineContents(i)).Length = 0 Then
                            'alert user here.... and exit???
                            Dim Response As DialogResult =
                               MessageBox.Show("Null value found at row " & j &
                                ", column " & (i + 1) & vbCrLf &
                                "Do you want to Continue?",
                                "CSV File Confirmation", MessageBoxButtons.YesNo)
                            If Response = DialogResult.No Then
                                Application.Exit()
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("Error: Row " & j &
                      " has invalid number of columns",
                      "CSV File Error", MessageBoxButtons.OK)
                    Application.Exit()
                End If

            End While
        Finally
        End Try
        Dim reader2 As StreamReader = New StreamReader(strFilePath)
        Do
            sline = reader2.ReadLine
            If sline Is Nothing Then Exit Do
            Dim thecolumns() As String = sline.Split(",")
            Dim newrow As DataRow = thedatatable.NewRow


            newrow("Watts") = thecolumns(0)
            newrow("Numero_Medidor") = thecolumns(1)
            newrow("ano") = thecolumns(2)
            newrow("mes") = thecolumns(3)

            thedatatable.Rows.Add(newrow)

        Loop
        result = enlace.Reg_ConsumoMasivo(thedatatable)
        MsgBox("Creado exitosamente")




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim enlace As New EnlaceBD
        Dim result As Boolean = False


        Dim thedatatable As New DataTable
        With thedatatable

            .Columns.Add("ano", System.Type.GetType("System.Int32"))

            .Columns.Add("mes", System.Type.GetType("System.Int32"))

            .Columns.Add("Precio_Bajo", System.Type.GetType("System.Decimal"))
            .Columns.Add("Precio_Medio", System.Type.GetType("System.Decimal"))
            .Columns.Add("Precio_Excedente", System.Type.GetType("System.Decimal"))

            .Columns.Add("Uso", System.Type.GetType("System.Int32"))
            .Columns.Add("Consumo_Bajo", System.Type.GetType("System.Int32"))
            .Columns.Add("Consumo_Medio", System.Type.GetType("System.Int32"))
            .Columns.Add("Consumo_Excedente", System.Type.GetType("System.Int32"))

        End With




        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFilePath As String = ""

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFilePath = fd.FileName
        End If

        Dim reader As StreamReader = New StreamReader(strFilePath)
        Dim sline As String = ""
        Try
            Dim j As Integer = 0
            Dim i As Integer

            If reader.EndOfStream Then
                MessageBox.Show("The CSV file is empty, please update",
                                "Error", MessageBoxButtons.OK)
                Application.Exit()
            End If

            While Not reader.EndOfStream
                'Dim s As String = reader.ReadLine()
                Dim lineContents() As String = Split(reader.ReadLine(), ",")
                Dim NoOfCol As Integer

                j = j + 1
                If j = 1 Then
                    NoOfCol = lineContents.Length
                End If
                If NoOfCol = lineContents.Length Then
                    For i = 0 To lineContents.Length - 1
                        'Dim str As String = lineContents(i)
                        If Trim(lineContents(i)).Length = 0 Then
                            'alert user here.... and exit???
                            Dim Response As DialogResult =
                               MessageBox.Show("Null value found at row " & j &
                                ", column " & (i + 1) & vbCrLf &
                                "Do you want to Continue?",
                                "CSV File Confirmation", MessageBoxButtons.YesNo)
                            If Response = DialogResult.No Then
                                Application.Exit()
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("Error: Row " & j &
                      " has invalid number of columns",
                      "CSV File Error", MessageBoxButtons.OK)
                    Application.Exit()
                End If

            End While
        Finally
        End Try

        Dim reader2 As StreamReader = New StreamReader(strFilePath)
        Do
            sline = reader2.ReadLine
            If sline Is Nothing Then Exit Do
            Dim thecolumns() As String = sline.Split(",")
            Dim newrow As DataRow = thedatatable.NewRow

            newrow("Precio_Excedente") = thecolumns(1)
            newrow("mes") = thecolumns(2)
            newrow("Precio_Bajo") = thecolumns(4)
            newrow("Precio_Medio") = thecolumns(0)
            newrow("ano") = thecolumns(3)



            newrow("Uso") = thecolumns(5)
            newrow("Consumo_Bajo") = thecolumns(6)
            newrow("Consumo_Medio") = thecolumns(7)
            newrow("Consumo_Excedente") = thecolumns(8)




            thedatatable.Rows.Add(newrow)

        Loop
        result = enlace.Reg_TarifaMasivo(thedatatable)
        MsgBox("Creado exitosamente")

    End Sub

    Private Sub TextBox_Mes_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Mes.TextChanged
        If (Val(TextBox_Mes.Text) = 0) Then

            MsgBox("mes invalido")
        ElseIf (Val(TextBox_Mes.Text) > 12) Then
            TextBox_Mes.Clear()
            MsgBox("mes invalido")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub TextBox_Ano_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Ano.TextChanged

        If (Val(TextBox_Ano.Text) = 0) Then

            MsgBox("Año invalido")
        ElseIf (Val(TextBox_Ano.Text) > 2050) Then
            TextBox_Ano.Clear()
            MsgBox("Año invalido")
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If (Val(TextBox2.Text) = 0) Then

            MsgBox("mes invalido")
        ElseIf (Val(TextBox2.Text) > 12) Then
            TextBox2.Clear()
            MsgBox("mes invalido")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If (Val(TextBox1.Text) = 0) Then

            MsgBox("Año invalido")
        ElseIf (Val(TextBox1.Text) > 2050) Then
            TextBox1.Clear()
            MsgBox("Año invalido")
        End If
    End Sub

    Private Sub Cargas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim enlace As New EnlaceBD
        Dim tablaaux As New DataTable

        tablaaux = enlace.getdataContrato()
        If (tablaaux.Rows.Count > 0) Then
            ComboBox1.DataSource = tablaaux
            ComboBox1.DisplayMember = "Numero_Medidor"
            'ListBox_Cliente.DisplayMember = "Nombre"
            'ListBox_Cliente.ValueMember = "CURP"

        End If
    End Sub
End Class
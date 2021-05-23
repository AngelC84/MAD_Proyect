Public Class Pago_de_Recibos

    Public Property CURP As String
    Public Property Cliente As DataTable
    Public Property Usuario As DataTable
    Public Property Contrato As DataTable
    Public Property Recibo As DataTable
    Public Property Pagados As DataTable
    Public Property Tarifa As DataTable


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
        Dim trans As New clsConversion
        Dim enlace As New EnlaceBD
        Dim Medidor As String
        Dim consumo As Integer
        Dim numero As String
        Dim Nombre_Usuario As String
        Dim serv As Boolean


        Dim Index As Integer
        Index = ListBox_RECIBOS.SelectedIndex
        If (Recibo.Rows.Count > 0) Then
            Consumo_Label.Text = Recibo.Rows(Index).Item(2)

            Tarifa = enlace.getTarifaSortID(Recibo.Rows(Index).Item(3))
            consumo = Val(Recibo.Rows(Index).Item(2))
            Dim basico As Integer
            Dim medium As Integer
            basico = Val(Tarifa.Rows(0).Item(7))
            medium = Val(Tarifa.Rows(0).Item(7))
            If (consumo < basico) Then
                Tarifa_Label.Text = "Consumo Basico"
                Tasa_Label.Text = Tarifa.Rows(0).Item(3)
            ElseIf (consumo < medium) Then
                Tarifa_Label.Text = "Consumo Medio"
                Tasa_Label.Text = Tarifa.Rows(0).Item(4)
            Else
                Tarifa_Label.Text = "Consumo Excedente"
                Tasa_Label.Text = Tarifa.Rows(0).Item(5)
            End If

            numero = trans.ConvertNumberToWords(Recibo.Rows(Index).Item(5))
            Totes_label.Text = numero
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
            While (i < Recibo.Rows.Count)
                result = enlace.updateReciboPago(0, 1, Recibo.Rows(i).Item(0))
                i = i + 1
            End While
        End If
        MsgBox("Pago aceptado")




    End Sub

End Class



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
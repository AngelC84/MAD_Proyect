Imports System.Data
Imports System.Data.SqlClient
Public Class EnlaceBD
    Private aux As String
    Private conexion As SqlConnection
    'Private conexionNomina As SqlConnection
    Private tabla As DataTable = New DataTable
    Private adaptador As SqlDataAdapter = New SqlDataAdapter
    Private comandosql As SqlCommand = New SqlCommand

    Private Sub conectar()
        'Dim DBConnection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("SQL").ConnectionString)        
        conexion = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("desarrollo").ConnectionString)

    End Sub

    Private Sub desconectar()
        conexion.Close()
    End Sub

    Public ReadOnly Property obtenertabla() As DataTable
        Get
            Return tabla
        End Get
    End Property

    Public Function Test()
        conectar()
        desconectar()

    End Function


    Public Function Reg_Empleado(ByVal CURP As String,
                           ByVal fecha_nac As Date,
                           ByVal Nombre As String,
                           ByVal RFC As String,
                           ByVal Fecha_Alta_Mod As Date,
                           ByVal Nomb_Us As String,
                           ByVal Cont_Us As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("EmpleadoReg", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 18)
            parametro1.Value = CURP
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Fecha_Nacimiento", SqlDbType.Date, 15)
            parametro2.Value = fecha_nac
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 50)
            parametro3.Value = Nombre
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 12)
            parametro4.Value = RFC
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Fecha_de_Alta_Modificacion", SqlDbType.Date, 15)
            parametro5.Value = Fecha_Alta_Mod
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
            parametro6.Value = Nomb_Us
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50)
            parametro7.Value = Cont_Us
            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function



    Public Function Reg_Cliente(ByVal CURP As String,
                           ByVal fecha_nac As Date,
                           ByVal Nombre As String,
                           ByVal Fecha_Alta_Mod As Date,
                           ByVal Genero As String,
                           ByVal email As String,
                           ByVal Nomb_Us As String,
                           ByVal Cont_Us As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("ClientesReg", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 18)
            parametro1.Value = CURP
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Fecha_Nacimiento", SqlDbType.Date, 15)
            parametro2.Value = fecha_nac
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 50)
            parametro3.Value = Nombre
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Fecha_de_Alta_Modificacion", SqlDbType.Date, 15)
            parametro4.Value = Fecha_Alta_Mod
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Genero ", SqlDbType.VarChar, 20)
            parametro5.Value = Genero
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@email ", SqlDbType.VarChar, 30)
            parametro6.Value = email
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
            parametro7.Value = Nomb_Us
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50)
            parametro8.Value = Cont_Us
            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function














    '-----------------------
    Public Function Reg_Tarifa(ByVal PrecioBajo As Decimal,
                           ByVal PrecioMedio As Decimal,
                           ByVal PrecioExcedente As Decimal,
                           ByVal Mes As Integer,
                               ByVal Ano As Integer,
                           ByVal ConsumoBajo As Integer,
                           ByVal ConsumoMedio As Integer,
                           ByVal ConsumoExcedente As Integer,
                           ByVal Uso As Integer) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("TarifaReg", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@PrecioBajo", SqlDbType.Float)
            parametro1.Value = PrecioBajo
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@PrecioMedio", SqlDbType.Float)
            parametro2.Value = PrecioMedio
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@PrecioExcedente", SqlDbType.Float)
            parametro3.Value = PrecioExcedente
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@mes", SqlDbType.Int)
            parametro4.Value = Mes
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@ano", SqlDbType.Int)
            parametro5.Value = Ano
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@Uso ", SqlDbType.Bit)
            parametro6.Value = Uso
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@ConsumoBajo ", SqlDbType.Int)
            parametro7.Value = ConsumoBajo
            Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@ConsumoMedio", SqlDbType.Int)
            parametro8.Value = ConsumoMedio
            Dim parametro9 As SqlParameter = comandosql.Parameters.Add("@ConsumoExcedente", SqlDbType.Int)
            parametro9.Value = ConsumoExcedente

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function


    Public Function Reg_Contrato(ByVal Cliente As String,
                           ByVal Servicio As Integer,
                           ByVal Domicilio As String,
                           ByVal Fecha As Date) As Boolean
        Dim estado As Boolean = True

        Try
            conectar()
            comandosql = New SqlCommand("regContrato", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@curp", SqlDbType.VarChar, 18)
            parametro1.Value = Cliente
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Servicio", SqlDbType.Bit)
            parametro2.Value = Servicio
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@fecha", SqlDbType.SmallDateTime, 8)
            parametro3.Value = Fecha
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Domicilio", SqlDbType.VarChar, 18)
            parametro4.Value = Domicilio


            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function

    Public Function Reg_Consumo(ByVal Medidor As Integer,
                           ByVal Watts As Integer,
                           ByVal Periodo As Date
                          ) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("regConsumo", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@NumeroMedidor", SqlDbType.Int)
            parametro1.Value = Medidor
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Watts", SqlDbType.Int)
            parametro2.Value = Watts
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Periodo", SqlDbType.Date, 15)
            parametro3.Value = Periodo



            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function


    Public Function Reg_ConsumoMasivo(ByVal Consumo As DataTable) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("regConsumoMasivo", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.AddWithValue("@tblConsumo", Consumo)
            parametro1.Value = Consumo
            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function

    Public Function Reg_TarifaMasivo(ByVal Tarifa As DataTable) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("regTarifaMasivo", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.AddWithValue("@tblTarifa", Tarifa)
            parametro1.Value = Tarifa
            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function















    Public Function getdataEmplead() As DataTable
        Dim nuevatablaEmpl As New DataTable
        Dim Qry As String


        Try
            conectar()
            Qry = "getdataEmplead"
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand = comandosql
            adaptador.Fill(nuevatablaEmpl)

        Catch ex As Exception
        Finally
            desconectar()
        End Try
        Return nuevatablaEmpl
    End Function

    Public Function getdataCliente() As DataTable
        Dim nuevatablaEmpl As New DataTable
        Dim Qry As String


        Try
            conectar()
            Qry = "getdataClientes"
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand = comandosql
            adaptador.Fill(nuevatablaEmpl)

        Catch ex As Exception
        Finally
            desconectar()
        End Try
        Return nuevatablaEmpl
    End Function

    '------------------

    Public Function GetEmpleadInactiv() As DataTable
        Dim nuevatablaEmpl As New DataTable
        Dim Qry As String


        Try
            conectar()
            Qry = "GetEmpleadInActiv"
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand = comandosql
            adaptador.Fill(nuevatablaEmpl)

        Catch ex As Exception
        Finally
            desconectar()
        End Try
        Return nuevatablaEmpl
    End Function

    Public Function GetClienteInactiv() As DataTable
        Dim nuevatablaEmpl As New DataTable
        Dim Qry As String


        Try
            conectar()
            Qry = "GetClienteInActiv"
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            adaptador.SelectCommand = comandosql
            adaptador.Fill(nuevatablaEmpl)

        Catch ex As Exception
        Finally
            desconectar()
        End Try
        Return nuevatablaEmpl
    End Function

    '------------------------------------------

    Public Function Activar_Empleado(ByVal Nombre As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("EmpleadoActivo", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 50)
            parametro1.Value = Nombre

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function


    Public Function ClienteActivo(ByVal Nombre As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("ClienteActivo", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 50)
            parametro1.Value = Nombre

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function

    Public Function Eliminar_Cliente(ByVal CURP As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("EliminarCliente", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 18)
            parametro1.Value = CURP

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function
    '------------------------------------------------------


    Public Function Upd_Empleado(ByVal CURP As String,
                           ByVal fecha_nac As Date,
                           ByVal Nombre As String,
                           ByVal RFC As String,
                           ByVal Fecha_Alta_Mod As Date,
                           ByVal Cont_Us As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("EmpleadoUpd", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 18)
            parametro1.Value = CURP
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Fecha_Nacimiento", SqlDbType.Date, 15)
            parametro2.Value = fecha_nac
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 50)
            parametro3.Value = Nombre
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 12)
            parametro4.Value = RFC
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Fecha_de_Alta_Modificacion", SqlDbType.Date, 15)
            parametro5.Value = Fecha_Alta_Mod
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50)
            parametro6.Value = Cont_Us
            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function

    Public Function Upd_Cliente(ByVal CURP As String,
                           ByVal fecha_nac As Date,
                           ByVal Nombre As String,
                           ByVal Fecha_Alta_Mod As Date,
                           ByVal Genero As String,
                           ByVal email As String,
                           ByVal Cont_Us As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("ClienteUpd", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 18)
            parametro1.Value = CURP
            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Fecha_Nacimiento", SqlDbType.Date, 15)
            parametro2.Value = fecha_nac
            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 50)
            parametro3.Value = Nombre
            Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Fecha_de_Alta_Modificacion", SqlDbType.Date, 15)
            parametro4.Value = Fecha_Alta_Mod
            Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@Genero ", SqlDbType.VarChar, 20)
            parametro5.Value = Genero
            Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@email ", SqlDbType.VarChar, 30)
            parametro6.Value = email
            Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 50)
            parametro7.Value = Cont_Us
            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function

    '-------------------------REPORTE TARIFA -----------------------

    Public Function getInfoTarifa(ByVal anio As Integer) As DataTable
        Dim tablaaux As New DataTable
        Dim Qry As String
        Qry = "GetDatoTarifas"
        Try
            conectar()
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@anio", SqlDbType.Int, 8)
            parametro1.Value = anio

            conexion.Open()
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tablaaux)

        Catch ex As Exception
        Finally
            desconectar()
        End Try
        Return tablaaux
    End Function

    '-------------------------REPORTE CONSUMO -----------------------
    Public Function getInfoConsumo(ByVal anio As Integer) As DataTable
        Dim tablaaux As New DataTable
        Dim Qry As String
        Qry = "GetDatoConsumo"
        Try
            conectar()
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@anio", SqlDbType.Int, 8)
            parametro1.Value = anio

            conexion.Open()
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tablaaux)

        Catch ex As Exception
        Finally
            desconectar()
        End Try
        Return tablaaux
    End Function

    '----------------------- CONSUMO HISTORICO ---------------------
    Public Function getInfoConsumoHistorico(ByVal anio As Integer,
                                            Numero_Medidor As Integer,
                                            Numero_de_Servicio As Integer) As DataTable
        Dim tablaaux As New DataTable
        Dim Qry As String
        Qry = "ConsumoHistorico"
        Try
            conectar()
            comandosql = New SqlCommand(Qry, conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@anio", SqlDbType.Int, 8)
            parametro1.Value = anio

            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Numero_Medidor", SqlDbType.Int, 8)
            parametro2.Value = Numero_Medidor

            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Numero_de_Servicio", SqlDbType.Int, 8)
            parametro3.Value = Numero_de_Servicio

            conexion.Open()
            adaptador.SelectCommand = comandosql
            adaptador.Fill(tablaaux)

        Catch ex As Exception
        Finally
            desconectar()
        End Try
        Return tablaaux

    End Function

    '-------------------LOGIN --------------
    Public Function LOGIN(
                             ByVal Nombre_Usuario As String,
                             ByVal Contraseña As String) As Integer
        'Agregar frecuencia de pago escogida'
        Dim estado As Boolean = True
        Dim aux As New DataTable
        Dim ID As Integer

        Try
            conectar()
            comandosql = New SqlCommand("LoginEmp", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
            parametro1.Value = Nombre_Usuario

            Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Contraseña", SqlDbType.VarChar, 15)
            parametro2.Value = Contraseña

            adaptador.SelectCommand = comandosql
            adaptador.Fill(aux)
            ID = aux.Rows(0).Item(0)

        Catch ex As Exception
            ID = -1
        Finally
            desconectar()
        End Try
        Return ID

    End Function




    Public Function LOGINPermiso(
                         ByVal Nombre_Usuario As String) As Integer
        'Agregar frecuencia de pago escogida'
        Dim estado As Boolean = True
        Dim aux As New DataTable
        Dim permiso As Integer

        Try
            conectar()
            comandosql = New SqlCommand("LoginPermiso", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
            parametro1.Value = Nombre_Usuario

            adaptador.SelectCommand = comandosql
            adaptador.Fill(aux)
            permiso = aux.Rows(0).Item(0)

        Catch ex As Exception
            permiso = -1
        Finally
            desconectar()
        End Try
        Return permiso

    End Function

    Public Function LOGINCliente(
                            ByVal Nombre_Usuario As String) As Integer
        'Agregar frecuencia de pago escogida'
        Dim estado As Boolean = True
        Dim aux As New DataTable
        Dim id As Integer

        Try
            conectar()
            comandosql = New SqlCommand("ClienteLogin", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
            parametro1.Value = Nombre_Usuario

            adaptador.SelectCommand = comandosql
            adaptador.Fill(aux)
            id = aux.Rows(0).Item(0)

        Catch ex As Exception
            id = -1
        Finally
            desconectar()
        End Try
        Return id

    End Function


    Public Function DesactivarUsuario(ByVal Nombre_Usuario As String) As Boolean
        Dim estado As Boolean = True
        Try
            conectar()
            comandosql = New SqlCommand("DesactivarLogin", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
            parametro1.Value = Nombre_Usuario

            conexion.Open()
            adaptador.InsertCommand = comandosql
            comandosql.ExecuteNonQuery()

        Catch ex As Exception
            estado = False
        Finally
            desconectar()

        End Try
        Return estado
    End Function


    Public Function GetEmpleadInActivLogin(
                         ByVal Nombre_Usuario As String) As Integer
        'Agregar frecuencia de pago escogida'
        Dim estado As Boolean = True
        Dim aux As New DataTable
        Dim permiso As Integer
        Dim permiso2 As Boolean

        Try
            conectar()
            comandosql = New SqlCommand("GetEmpleadInActivLogin", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
            parametro1.Value = Nombre_Usuario

            adaptador.SelectCommand = comandosql
            adaptador.Fill(aux)
            permiso2 = aux.Rows(0).Item(0)
            If (permiso2) Then
                permiso = 1
            Else
                permiso = 0
            End If

        Catch ex As Exception
            permiso = -1

        Finally
            desconectar()
        End Try
        Return permiso

    End Function

    Public Function GetClienteInActivLogin(
                         ByVal Nombre_Usuario As String) As Integer
        'Agregar frecuencia de pago escogida'
        Dim estado As Boolean = True
        Dim aux As New DataTable
        Dim permiso As Integer
        Dim permiso2 As Boolean

        Try
            conectar()
            comandosql = New SqlCommand("GetClienteInActivLogin", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
            parametro1.Value = Nombre_Usuario

            adaptador.SelectCommand = comandosql
            adaptador.Fill(aux)
            permiso2 = aux.Rows(0).Item(0)
            If (permiso2) Then
                permiso = 1
            Else
                permiso = 0
            End If

        Catch ex As Exception
            permiso = -1

        Finally
            desconectar()
        End Try
        Return permiso

    End Function

    '-------------------------------------------------------

    Public Function GetEmpleadoGral(
                            ByVal Nombre_Usuario As String) As String

        Dim estado As Boolean = True
        Dim aux As New DataTable
        Dim ID As String
        Try
            conectar()
            comandosql = New SqlCommand("GetEmpleadoGral", conexion)
            comandosql.CommandType = CommandType.StoredProcedure

            Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 50)
            parametro1.Value = Nombre_Usuario

            adaptador.SelectCommand = comandosql
            adaptador.Fill(aux)
            ID = aux.Rows(0).Item(0)

        Catch ex As Exception
            ID = "ERROR"
        Finally
            desconectar()
        End Try
        Return ID

    End Function

    '-------------------------------

    'Public Function Autentificar(ByVal User As String, ByVal Pass As String) As Boolean
    '    Dim estado As Boolean = False
    '    Dim qry As String
    '    Try
    '        conectar()
    '        'Dim conect As New SqlConnection("data source=SrvNomina;Initial Catalog=Eslabon;User ID=intra;Password=intra")

    '        comandosql = New SqlCommand("sp_ConsultaEmpleado_pUP", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pEmpleado", SqlDbType.Int, 8)
    '        parametro1.Value = CInt(User)
    '        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pClave", SqlDbType.VarChar, 4)
    '        parametro2.Value = Pass
    '        Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pOpcion", SqlDbType.TinyInt, 1)
    '        parametro3.Value = 1

    '        comandosql.CommandTimeout = 9000
    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)

    '        If tabla.Rows.Count > 0 Then

    '            If tabla.Rows(0).Item("NumError") = 0 Then

    '                'Session("UserName") = tabla.Rows(0).Item("Nombre_Completo").ToString.ToLower

    '                Dim tabla2 As DataTable = New DataTable
    '                comandosql = New SqlCommand("Mi_Pagina_Datos_Generales_pUP", conexion)
    '                comandosql.CommandType = CommandType.StoredProcedure

    '                Dim parametro01 As SqlParameter = comandosql.Parameters.Add("@pEmpleado", SqlDbType.Int, 8)
    '                parametro01.Value = CInt(User)
    '                comandosql.CommandTimeout = 9000
    '                adaptador.SelectCommand = comandosql
    '                adaptador.Fill(tabla2)
    '                If tabla2.Rows.Count > 0 Then
    '                    ' -- Gerentes de Tienda
    '                    If tabla2.Rows(0).Item("jerarquia") >= 90 And tabla2.Rows(0).Item("Sucursal") <= 1000 Then
    '                        estado = True
    '                    Else
    '                        ' -- Menor jerarquía que gerente
    '                        If tabla2.Rows(0).Item("jerarquia") < 90 Then
    '                            estado = False
    '                        Else
    '                            ' -- Mayor jerarquía que gerentes
    '                            If tabla2.Rows(0).Item("jerarquia") >= 90 Then

    '                                estado = True
    '                            End If
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Autentificar = estado
    'End Function

    'Public Function Autentificar_OLD(ByVal User As String, ByVal Pass As String) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand("sps_Sys_ValidaUsuario", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@strNomUsuario", SqlDbType.VarChar, 20)
    '        parametro1.Value = User
    '        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@strClave", SqlDbType.VarChar, 20)
    '        parametro2.Value = Pass

    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)
    '        estado = (tabla.Rows.Count > 0)
    '        'estado = 1
    '    Catch ex As SqlException
    '        estado = False
    '        estado = False
    '    Finally
    '        desconectar()

    '    End Try
    '    Autentificar_OLD = estado
    'End Function
    'Public Function ValidaUsuario(ByVal User As String, ByVal Pass As String) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand("sps_Sys_ValidaUsuario", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@strNomUsuario", SqlDbType.VarChar, 20)
    '        parametro1.Value = User
    '        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@strClave", SqlDbType.VarChar, 20)
    '        parametro2.Value = Pass

    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)


    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function
    'Public Function AgregaInventario(ByVal dFecha As Date, ByVal strCliente As String, ByVal strNoParte As String,
    '                                 ByVal strProducto As String, ByVal iPiezasAlm As Integer, ByVal iPiezasCuar As _
    '                                 Integer, ByVal iPiezasTot As Integer) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand("sp", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Fecha", SqlDbType.SmallDateTime, 15)
    '        parametro1.Value = dFecha
    '        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Cliente", SqlDbType.VarChar, 60)
    '        parametro2.Value = strCliente
    '        Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@NoParte", SqlDbType.VarChar, 20)
    '        parametro3.Value = strNoParte
    '        Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@Producto", SqlDbType.VarChar, 50)
    '        parametro4.Value = strProducto
    '        Dim parametro5 As SqlParameter = comandosql.Parameters.Add("@PiezasAlm", SqlDbType.Int, 8)
    '        parametro5.Value = iPiezasAlm
    '        Dim parametro6 As SqlParameter = comandosql.Parameters.Add("@PiezasCuar", SqlDbType.Int, 8)
    '        parametro6.Value = iPiezasCuar
    '        Dim parametro7 As SqlParameter = comandosql.Parameters.Add("@PiezasTot", SqlDbType.Int, 8)
    '        parametro7.Value = iPiezasTot
    '        Dim parametro8 As SqlParameter = comandosql.Parameters.Add("@strUsuario", SqlDbType.VarChar, 20)
    '        'If Session("UserID") Is Nothing Then
    '        'parametro8.Value = "generic user"
    '        'Else
    '        'parametro8.Value = Session("UserID")
    '        'End If

    '        conexion.Open()
    '        adaptador.InsertCommand = comandosql
    '        comandosql.ExecuteNonQuery()

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function
    'Public Function LimpiaInventarioMes(ByVal dFecha As Date) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand("sp_Delete", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Fecha", SqlDbType.SmallDateTime, 15)
    '        parametro1.Value = dFecha

    '        conexion.Open()
    '        adaptador.DeleteCommand = comandosql
    '        comandosql.ExecuteNonQuery()

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function
    'Public Function Add_Puesto(ByVal opc As String,
    '                                ByVal puesto As String,
    '                                ByVal nivel As Decimal) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand("sp_Puestos", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
    '        parametro1.Value = opc
    '        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 20)
    '        parametro2.Value = puesto
    '        Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@Nivel", SqlDbType.Decimal, 5)
    '        parametro3.Value = nivel

    '        conexion.Open()
    '        adaptador.InsertCommand = comandosql
    '        comandosql.ExecuteNonQuery()

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function
    'Public Function ConsultaInventarioInicial(ByVal dFecha As Date, ByVal strCliente As String) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand("sp", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Fecha", SqlDbType.SmallDateTime, 15)
    '        parametro1.Value = dFecha
    '        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@Cliente", SqlDbType.VarChar, 60)
    '        parametro2.Value = strCliente

    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function
    'Public Function ConsultaTonelaje() As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand("sp", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function
    'Public Function GeneraAnalisis1(ByVal dFechaI As Date, ByVal dFechaF As Date, ByVal Tienda As Integer, ByVal Depto As String) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand("dbo.cumhoGeneraAnalisis1", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@FechaIni", SqlDbType.SmallDateTime, 15)
    '        parametro1.Value = dFechaI
    '        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@FechaFin", SqlDbType.SmallDateTime, 15)
    '        parametro2.Value = dFechaF
    '        Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pTienda", SqlDbType.Int, 8)
    '        parametro3.Value = Tienda
    '        Dim parametro4 As SqlParameter = comandosql.Parameters.Add("@pDepto", SqlDbType.VarChar, 10)
    '        parametro4.Value = Depto

    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function

    'Public Function ObtenTiendas(ByVal Tienda As Integer) As Boolean
    '    Dim estado As Boolean = True
    '    Dim Qry As String = ""

    '    Qry = "SELECT Id, Nombre FROM Tienda"
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand(Qry, conexion)
    '        comandosql.CommandType = CommandType.Text

    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function

    'Public Function ObtenDeptos(ByVal tienda As Integer) As Boolean
    '    Dim estado As Boolean = True
    '    Dim Qry As String
    '    Qry = "sp_Deptos"
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand(Qry, conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function
    'Public Function Get_Puestos() As DataTable
    '    Dim Qry As String
    '    Dim data As New DataTable

    '    Try

    '        conectar()

    '        Qry = "sp_Puestos"
    '        comandosql = New SqlCommand(Qry, conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1)
    '        parametro1.Value = "X"


    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(data)

    '    Catch ex As SqlException

    '    Finally
    '        desconectar()
    '    End Try
    '    Return data

    'End Function
    'Public Function ObtenDatosArchivo(ByVal CveOperacion As String, ByVal TipoPago As Integer, ByVal DiaPago As String) As Boolean
    '    Dim estado As Boolean = True
    '    Dim qry As String
    '    'qry = "dbo.CtlInt_PagoNomina_pUP"
    '    qry = "dbo.sp_pruebas"
    '    Try
    '        conectar()
    '        comandosql = New SqlCommand(qry, conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pCveOperacion", SqlDbType.VarChar, 4)
    '        parametro1.Value = CveOperacion
    '        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pTipoPago", SqlDbType.SmallInt, 4)
    '        parametro2.Value = TipoPago
    '        If CveOperacion <> "HEDS" Then
    '            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pDiaPago", SqlDbType.VarChar, 15)
    '            parametro3.Value = DiaPago
    '        End If
    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function
    'Public Function ObtenDatosPago(ByVal CveOperacion As String, ByVal TipoPago As Integer, ByVal DiaPago As String) As Boolean
    '    Dim estado As Boolean = True

    '    Try
    '        conectar()
    '        comandosql = New SqlCommand("dbo.sp_Pruebas", conexion)
    '        comandosql.CommandType = CommandType.StoredProcedure

    '        Dim parametro1 As SqlParameter = comandosql.Parameters.Add("@pCveOperacion", SqlDbType.VarChar, 4)
    '        parametro1.Value = CveOperacion
    '        Dim parametro2 As SqlParameter = comandosql.Parameters.Add("@pTipoPago", SqlDbType.SmallInt, 4)
    '        parametro2.Value = TipoPago
    '        If CveOperacion = "DETS" Then
    '            Dim parametro3 As SqlParameter = comandosql.Parameters.Add("@pDiaPago", SqlDbType.VarChar, 15)
    '            parametro3.Value = DiaPago
    '        End If
    '        adaptador.SelectCommand = comandosql
    '        adaptador.Fill(tabla)

    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        desconectar()
    '    End Try
    '    Return estado
    'End Function
End Class

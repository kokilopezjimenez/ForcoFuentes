Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Enterprise.InfoStore
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine.ReportDocument
Imports System.Threading





Module modRutinas
    Public indice As Integer = 0                    'Ulilizada como �ndice.
    Public DBConnGlobal As SqlConnection            'Utilizada como Conexi�n Global.
    Public transaccionGlobal As SqlTransaction      'Utilizada como una transacci�n SQL.
    Public strNombreUsuario As String               'Nombre de usuario en string.
    Public strUser As String                        'Nombre del usuario publico.
    Public nUserID As Integer                       'Id del usuario.
    Public strDepto As String                       'Nombre del area en la tabla de usuarios.
    Public nUser As Integer                         'Codigo del usuario en la tabla de usuarios.
    Public nDepto As Integer                        'Codigo del area en la tabla de usuarios.
    Public intEmpresa As Integer                    'Id de Empresa para usar en consultas.
    Public EmpresaNombre As String                  'Nombre de la Empresa en string.
    Public EmpresaLogo As String                    'Logo de la empresa.
    Public ImagenFooter As String                   'Ruta del footer de la imagen.
    Public EmpresaMoneda As Integer                 'Entero que representa un tipo de moneda.
    Public strSQL As String                         'Utilizada para contener consultas SQL.
    Public strQuery As String                       'Utilizada para contener consultas SQL.
    Public strLlave As String                       'Contiene campo llave.
    Public strValorAnterior As String               'Valor anterior de una variable.
    Public strValorActual As String                 'Valor actual de una variable que se compara con ValorAnterior.

    Public strConexion As String                    'Lee de archivo Server.ini de conexion para base de datos.
    Public strServidor As String                    'Lee de archivo Server.ini contiene IP o Nombre M�quina Base de Datos.
    Public strBaseDatos As String                   'Lee de archivo Server.ini String de conexi�n Base de Datos.
    Public strUserSql As String                     'Lee de archivo Server.ini String que contiene usuario Str de SQL. 
    Public strKey As String                         'Lee de archivo Server.ini Guarda llave en str.
    '--
    Public dsValorAnterior As New DataSet           'Conjunto de Datos que es retornado.
    Public dblTipoCambio As Double                  'Tipo de cambio en Double.
    Public dblValorMinimo As Double = 0.00001       'Valor m�nimo.
    '--
    Public alProveedores As New ArrayList           'Arreglo que contiene los proveedores.
    Public arrCampos As New ArrayList               'Arreglo de Campos.
    Public arrTipos As New ArrayList                'Arreglo de Tipos.
    Public arrValorAnterior As New ArrayList        'Arreglo de valores anteriores.
    Public arrValorActual As New ArrayList          'Arreglo de valor actual.
    '--
    Public lngRegistros As Long                     'Contador de Registros o Cantidad de Registros.
    Public intStatus As Integer                     'Estado en tipo int.
    Public intReporte As Integer                    'Tipo int Reporte.
    Public intProceso As Integer                    'Tipo int Proceso.
    '--
    Public strCampo As String                       'Se utiliza en varias funciones para enviar un campo de tabla como par�metro.
    Public nValor As Integer = 0                    'Guarda un valor num�rico.
    Public strFiltro As String = ""                 'Se utilizar en varias funciones para enviar un filtro para una consulta. 
    Dim filtro As String                            'Para guardar filtros de consultas.
    Public varNumSPID As Integer                    'Guarda el numero de un Stored Procedure ID.
    Public nPeriodo As Integer                      'Guarda per�odos en valor n�mericos.
    Public strPeriodo As String                     'Guarda per�odos en string.
    Public nRecargoPeriodo As Double                'Numero de regargo de per�odo.
    Public nPerRecargo As Double                    'Numero de regargo de per�odo.
    '-- 
    Public bolFound As Boolean                      'Booleano valor de Encontrado o no Encontrado.
    Public strNameReporte As String                 'Nombre de Reporte.
    Public strNameFuenteDatos As String             'Fuente de Datos de Reporte.
    '-- 
    Public vcCode As String                         'String del c�digo.
    Public vcData As String                         'String de Data.
    Public vnCantidad As Double                     'Guarda Cantidad de Registros de una consulta. 
    Public vnCantidad2 As Double                    'Guarda Cantidad de Registros de una consulta.
    Public vnCode As Integer                        'Guarda C�digo Num�rico.
    Public vnPrecioUnitario As Double               'Guarda Precio Unitario.
    Public vnDescuento As Double                    'Para descuento en entradas.
    Public bolIVA As Boolean                        'Booleano si tiene IVA.
    Public vnIva As Double                          'Valor del IVA.

    Public vnSolicitado As Double                   'Cantidada solicitada en decimal.
    Public vnEntregado As Double                    'Cantidad entregada en decimal.
    Public vnCosto As Double                        'Costo en decimal.

    Public vnTipoSalida As Integer                  'TipoSalida.
    Public vnTipoAjuste As Integer                  'Variable tipo de Ajuste en entero.
    Public bolLogin As Boolean = False              'Validacion del forms login.
    '-- 
    Public bolPermiteRegFechaAnterior As Boolean = False   'Permite Fecha Anterior.
    Public bolPermiteBotDebitoDirecto As Boolean = False   'Permite hacer debito directo. 

    Public dtmFechaLastRecibo As Date                      'Fecha de �ltimo recibo. 
    Public dtmFechaLastRoc As Date                         'Fecha de �ltimo recibo.

    Public bolCargado As Boolean = False                   'Booleano Cargado.
    Public vnProducto As Integer                           'Entero de Producto. 
    Public vnLote As Integer                               'Entero de Lote.
    Public strTitulo As String                             'Titulo en String.
    Public vnTipoCliente As Integer                        'Entero de Tipo de Cliente.


    '***************************AREA DE FUNCIONES Y PROCEDIMIENTOS*******************************

    'Dependiendo del usuario y el modulo
    'que se env�e revisa si un usuario tiene 
    'derechos para un m�dulo.
    'Fecha       :    26 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    LDCOM_MUNDOMAGICO.
    'Tablas      :    GEN_USUARIOSMODULOS.

    Function funModulo(ByVal strUser As String, ByVal strModulo As String)

        strSQL = "SELECT COUNT(*) FROM GEN_USUARIOSMODULOS WHERE STRUSER = '" & strUser &
                 "' AND STRMODULO = '" & strModulo & "'"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funModulo = IIf(cmd.ExecuteScalar >= 1, True, False)
        db.Close()

    End Function


    'Devuelve el tipo de cambio del dia strFecha.
    'Fecha       :    26 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    LDCOM_MUNDOMAGICO.
    'Tablas      :    GEN_USUARIOSMODULOS.

    Function funTipoCambio(ByVal strFecha As Date)

        Dim strSQL = "SELECT VALOR FROM TCDOLAR WHERE FECHA ='" & strFecha & "'"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funTipoCambio = cmd.ExecuteScalar
        db.Close()

    End Function



    'La tabla Gen_Parametros no tiene valores
    'en esta base FACTURA_TIENDA, no se usa este
    'procedimiento en este programa app_TE_Tiendas.
    'Fecha       :    26 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    FACTURA_TIENDA.
    'Tablas      :    GEN_PARAMETROS.
    Public Function funGetParametro(ByVal strVariable)

        strSQL = "SELECT TVALOR FROM GEN_PARAMETROS WHERE TVARIABLE = '" &
                strVariable & "'"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funGetParametro = cmd.ExecuteScalar
        db.Close()

    End Function



    'La tabla Gen_Parametros no tiene valores
    'en esta base FACTURA_TIENDA, no se usa este
    'procedimiento en este programa app_TE_Tiendas.
    'Fecha       :    26 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    FACTURA_TIENDA.
    'Tablas      :    GEN_PARAMETROS.

    Public Function funGetParametroPorEmpresa(ByVal strVariable As String, ByVal nEmpresa As Integer)
        strSQL = "SELECT TVALOR FROM GEN_PARAMETROS WHERE TVARIABLE = '" & _
                strVariable & "' AND nEmpresa = " & nEmpresa
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funGetParametroPorEmpresa = cmd.ExecuteScalar
        db.Close()
    End Function


    'El procedimiento abr� el archivo Server.ini en
    'el Path de la aplicaci�n para leer los par�metros
    'de la base de datos donde se tiene que conectar
    'y los retorna en un string = strConexion.
    'Fecha       :    26 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Cualquier Base de Datos.
    'Tablas      :    Ninguna.

    Public Function funConexion() As String

        If Len(Trim(strConexion)) = 0 Then
            If File.Exists(Application.StartupPath & "\Server.ini") Then
                Dim ConnectionFile As New System.IO.StreamReader(Application.StartupPath & "\Server.ini")
                strServidor = ConnectionFile.ReadLine.ToString()
                strUserSql = ConnectionFile.ReadLine.ToString()
                strKey = ConnectionFile.ReadLine.ToString()
                strBaseDatos = ConnectionFile.ReadLine.ToString()
                strConexion = "server=" & strServidor & ";Initial Catalog=" & strBaseDatos & ";User Id=" & strUserSql & ";Password=" & strKey & ";"
            Else
                MsgBox("No se encontr� el archivo: Server.ini", MsgBoxStyle.Information)
                Return "Nothing"
                strConexion = "Nothing"
                Exit Function
            End If
        End If
        Return strConexion
    End Function


    'Obtiene la fecha actual en cualquier base de datos y lo retorna a 
    'un objeto Date por medio de esta funci�n Convert.ToDateTime
    'Fecha       :    26 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Cualquier Base de Datos.
    'Tablas      :    Ninguna.
    Function funFechaServerTransaccion()
        Dim strSQL As String = "SELECT GETDATE()"
        Dim cmd As New SqlCommand(strSQL, DBConnGlobal)
        cmd.Transaction = transaccionGlobal
        funFechaServerTransaccion = Convert.ToDateTime(cmd.ExecuteScalar)
    End Function


    'Obtiene la fecha actual en cualquier base de datos y lo retorna a 
    'un objeto Date por medio de esta funci�n Convert.ToDateTime
    'Fecha       :    26 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Cualquier Base de Datos.
    'Tablas      :    Ninguna.
    Function funFechaServer()
        Dim strSQL As String = "SELECT GETDATE()"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funFechaServer = Convert.ToDateTime(cmd.ExecuteScalar)
        db.Close()
    End Function



    'Inserta en la tabla Trace que es una especie 
    'de catalogo de tablas donde se guardan un valor
    'anterior y un valor actual.
    'Fecha       :    26 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    FACTURA_TIENDA.
    'Tablas      :    TRACE.
    Function funSetTrace(ByVal strTable As String,
                        ByVal strKey As String,
                        ByVal strField As String,
                        ByVal strOldValue As String,
                        ByVal strNewValue As String,
                        Optional ByVal nCabecera As Integer = 0) As Boolean
        'actualiza la pista de auditor�a
        If strOldValue <> strNewValue Then
            Dim strSQL = "INSERT INTO TRACE(nTraceRecNo, strUsuario, strTabla, strCampo, " &
                         "strValorAnterior, strValorActual, nCabecera) VALUES ( '" &
                strKey & "', '" &
                strUser & "', '" &
                strTable & "', '" &
                strField & "', '" &
                strOldValue & "', '" &
                strNewValue & "', '" &
                nCabecera & "')"

            Try
                If DBConnGlobal.State = ConnectionState.Open Then
                Else
                    DBConnGlobal = New SqlConnection(funConexion())
                    DBConnGlobal.Open()
                End If
            Catch ex As Exception
                DBConnGlobal = New SqlConnection(funConexion())
                DBConnGlobal.Open()
            End Try

            Dim cmd As New SqlCommand(strSQL, DBConnGlobal)
            cmd.Connection = DBConnGlobal
            cmd.Transaction = transaccionGlobal
            cmd.ExecuteNonQuery()
            funSetTrace = True
        End If
    End Function



    'Busca en una tabla que viene por par�metro
    'un campo que viene por par�metro y busca en ese
    'campo un valor que tambi�n viene por par�metro.
    'Fecha       :    27 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    No especificada.
    'Tablas      :    No especificada.
    Function funValorAnterior(ByVal strRecno As String,
                                ByVal strTabla As String,
                                ByVal strCampo As String) As Boolean

        Dim strSQL = "SELECT * FROM " & strTabla & " WHERE " & strCampo & " = " & strRecno
        Dim cmd As New SqlDataAdapter(strSQL, DBConnGlobal)
        dsValorAnterior.Clear()
        cmd.SelectCommand.Connection = DBConnGlobal
        cmd.SelectCommand.Transaction = transaccionGlobal
        cmd.Fill(dsValorAnterior, "Tabla")

    End Function


    'Hace un inner join entre una tabla que pasa como
    'par�metro en strTabla, hace un inner join con
    'la tabla trace y adem�s hace una union con otra consulta. 
    'dependiendo de ciertos valores.
    'Fecha       :    27 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    FACTURA_TIENDA.
    'Tablas      :    Inv_Proveedores, Inv_Inventario, INV_DESTINOS, TRACE .

    Function funGetTrace(ByVal strID As String,
                        ByVal strTabla As String,
                        ByVal strTabla2 As String,
                        ByVal strCampo As String,
                        ByVal strCampo2 As String,
                        ByRef ds As DataSet,
                        Optional ByVal bolEmpresa As Boolean = False) As Boolean

        'Si strTabla son esas Tablas.                  
        If strTabla = "Inv_Proveedores" _
            Or strTabla = "Inv_Inventario" _
            Or strTabla = "INV_DESTINOS" _
            Or bolEmpresa Then 'Hace un INNER JOIN con la tabla Trace
            strSQL = "SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " &
            "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo AS Registro " &
            "FROM " & strTabla & " tbl INNER JOIN Trace T " &
            "ON tbl." & strCampo2 & " = T.nTraceRecNo " &
            "WHERE strTabla = '" & strTabla & "' " &
            "AND tbl." & strCampo & " = " & strID
        Else 'Sino son esas tablas
            strSQL = "SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " &
            "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo AS Registro " &
            "FROM " & strTabla & " tbl INNER JOIN Trace T " &
            "ON tbl." & strCampo2 & " = T.nTraceRecNo " &
            "WHERE strTabla = '" & strTabla & "' " &
            "AND tbl." & strCampo & " = " & strID & " " &
            "AND tbl.nEmpresa = " & intEmpresa '& " " & _
        End If

        If strTabla2 = "" Then 'Si strTabla2 no contiene nada
            strSQL += " ORDER BY T.nRecNo, T.dtmFecha"
        Else
            If strTabla2 <> "Ban_SolicitudesCKDetalles" _
            And strTabla2 <> "Cont_ComprobantesDetalle" Then 'Adem�s si strTabla y strTabla2 no son esas tablas hace una uni�n
                strSQL += " UNION SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " &
                "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo  AS Registro " &
                "FROM " & strTabla2 & " tbl INNER JOIN Trace T " &
                "ON tbl." & strCampo2 & " = T.nTraceRecNo " &
                "WHERE strTabla = '" & strTabla2 & "' " &
                "AND tbl." & strCampo & " = " & strID & " " &
                "AND tbl.nEmpresa = " & intEmpresa & " " &
                "ORDER BY T.nRecNo, T.dtmFecha"
            Else 'Hace otra ipo de Union con otras columnas y par�metros.
                strSQL += " UNION SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " &
                "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo  AS Registro " &
                "FROM " & strTabla2 & " tbl INNER JOIN Trace T " &
                "ON tbl." & strCampo2 & " = T.nTraceRecNo " &
                "WHERE strTabla = '" & strTabla2 & "' " &
                "AND T.nCabecera = " & strID & " " &
                "AND tbl.nEmpresa = " & intEmpresa & " " &
                "ORDER BY T.nRecNo, T.dtmFecha"
            End If

        End If

        Debug.Print(vbCr)
        Debug.Print(strSQL)
        Dim DBConn As New SqlConnection(funConexion())
        Dim cmd As New SqlDataAdapter(strSQL, DBConn)
        cmd.Fill(ds, "Tabla")
        DBConn.Close()
        funGetTrace = True 'Retorna true a la funci�n
    End Function




    'Hace un inner join entre una tabla que pasa como
    'par�metro en strTabla2, hace un inner join con
    'la tabla trace.
    'dependiendo de ciertos valores.
    'Fecha       :    27 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    FACTURA_TIENDA.
    'Tablas      :    TRACE .

    Function funGetTraceUnion(ByVal strID As String, ByVal strTabla As String, ByVal strTabla2 As String, ByVal strCampo As String, ByVal strCampo2 As String, ByRef ds As DataSet) As Boolean

        If strTabla2 = "" Then
            strSQL = strSQL & " ORDER BY T.nRecNo, T.dtmFecha"
        Else
            strSQL = strSQL & " UNION SELECT T.strTabla AS Tabla, T.strCampo AS Campo, T.strValorAnterior AS [Valor Anterior], " & _
            "T.strValorActual AS [Valor Actual], T.strUsuario AS Usuario, T.dtmFecha AS Fecha, T.nRecNo " & _
            "FROM " & strTabla2 & " tbl INNER JOIN Trace T " & _
            "ON tbl." & strCampo2 & " = T.nTraceRecNo " & _
            "WHERE strTabla = '" & strTabla2 & "' " & _
            "AND tbl." & strCampo & " = " & strID & " " & _
            "AND tbl.nEmpresa = " & intEmpresa & " " & _
            "ORDER BY T.nRecNo, T.dtmFecha"
        End If

        Dim DBConn As SqlConnection
        DBConn = New SqlConnection(funConexion())
        Dim cmd As New SqlDataAdapter(strSQL, DBConn)
        cmd.Fill(ds, "Tabla")
        DBConn.Close()
        funGetTraceUnion = True
    End Function


    'Le cambia las propiedades a un DataGridView
    'que se pasa por parametro, se cambia color, estilo de borde,
    'que no permita insertar registros o borrarlos directamente.
    'Fecha       :    27 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Public Sub DataGridRowStyle(ByRef dgv As DataGridView)
        With dgv
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(227, 241, 254)
            .RowTemplate.Height = 15
            .BackgroundColor = Color.FromArgb(227, 241, 254)
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue
            .GridColor = Color.SteelBlue
            .BorderStyle = BorderStyle.Fixed3D
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowTemplate.Resizable = DataGridViewTriState.False
            .RowHeadersWidth = 25
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .CellBorderStyle = DataGridViewCellBorderStyle.None
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        End With
    End Sub

    'Le cambia las propiedades a un DataGridView
    'que se pasa por parametro, se cambia color, estilo de borde,
    'que no permita insertar registros o borrarlos directamente.
    'Fecha       :    27 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Public Sub DataGridRowStyle1(ByRef dgv As DataGridView)
        dgv.RowsDefaultCellStyle.BackColor = Color.White
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
        dgv.BackgroundColor = Color.WhiteSmoke
    End Sub

    'Le cambia el color a una forma y a todos los controles
    'que tiene el form.
    'Fecha       :    27 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Public Function ColorFondoFormulario(ByRef Form As Form) As Color
        Form.BackColor = Color.FromArgb(227, 241, 254)

        For i As Integer = 0 To Form.Controls.Count - 1
            If TypeOf Form.Controls(i) Is StatusStrip Then
                CType(Form.Controls(i), StatusStrip).BackColor = Color.FromArgb(227, 241, 254)
            End If
        Next

        Return Form.BackColor
    End Function

    'Retorna el string que est� despues de la 
    'posici�n donde se encuentra el \.
    'Fecha       :    27 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Function funFileName(ByVal strNombre As String) As String
        Dim strNombre2 As String = Mid(strNombre, InStrRev(strNombre, "\") + 1)
        Return strNombre2
    End Function

    'Le pone los par�metros a un tipo comando
    'que es tipeado Stored Procedure y que llama a spParametrosAdd.
    'Despu�s pone los par�metros y les asigna los valores 
    'y los tipos que vienen como par�metros a la funci�n.
    'Fecha       :    28 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Public Sub ParametrosAdd(ByVal nEmpresa As Integer,
                        ByVal strVariable As String,
                        ByVal strValor As String)

        Dim cmd As SqlCommand = New SqlCommand("spParametrosAdd", DBConnGlobal)
        cmd.CommandType = CommandType.StoredProcedure

        Dim _nEmpresa As New SqlParameter("@nEmpresa", SqlDbType.Int)
        _nEmpresa.Value = nEmpresa
        cmd.Parameters.Add(_nEmpresa)

        Dim _strVariable As New SqlParameter("@strVariable", SqlDbType.NVarChar)
        _strVariable.Value = strVariable
        cmd.Parameters.Add(_strVariable)

        Dim _strValor As New SqlParameter("@strValor", SqlDbType.NVarChar)
        _strValor.Value = strValor
        cmd.Parameters.Add(_strValor)

        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()

    End Sub



    'Revisa si KeyAscii tiene n�meros decimales
    'o si es el valor cero.
    'Fecha       :    28 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Function SoloNumeros(ByVal Keyascii As Short) As Short

        If InStr("1234567890.", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select

    End Function

    'Revisa si keyascii es un numero entero
    'sino retorna 0.
    'Fecha       :    28 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.
    Function SoloNumerosEnteros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumerosEnteros = 0
        Else
            SoloNumerosEnteros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumerosEnteros = Keyascii
            Case 13
                SoloNumerosEnteros = Keyascii
        End Select
    End Function

    'Concatena strUser que es usuario o login del sistema,
    'la fecha del sistema Visual Basic o Windows y el strNombre
    'que es pasado por par�metro.
    'Fecha       :    28 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Function funMakeFileName(ByVal strNombre As String)
        Dim strFileName As String
        strFileName = strUser & "_" & Microsoft.VisualBasic.DateAndTime.Timer & "_" & strNombre
        Return strFileName
    End Function


    'Borra del startup path de la aplicaci�n
    'm�s el directorio DatosXML m�s los archivos que
    'tengan el nombre del usuario.xml.
    'Fecha       :    28 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Function funCleanTempFiles()
        On Error Resume Next
        strSQL = Application.StartupPath & "\DatosXml\" & strUser & "*.xml"
        Kill(strSQL)
        Return True
    End Function


    'Asigna a la variable el tipo que se env�a como par�metro.
    'Dependiendo intCmd (el comando) la variable
    'cmd le pone el par�metro y el tipo y hace
    'el objeto un un adaptador o un comando.
    'Fecha       :    28 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Function funSqlParametro(ByVal strVariable As String,
                ByVal varValor As String,
                ByVal varTipo As SqlDbType,
                ByVal cmd As Object,
                ByVal intCmd As Integer)

        Dim varParametro As New SqlParameter(strVariable, varTipo)
        varParametro.Value = varValor

        '1=SqlDataAdapter, 2=SqlCommand
        If intCmd = 1 Then
            CType(cmd, SqlDataAdapter).SelectCommand.Parameters.Add(varParametro)
        Else
            CType(cmd, SqlCommand).Parameters.Add(varParametro)
        End If

        Return True
    End Function


    'Env�a una variable strValor de tipo objeto 
    'y primero verifica si es nulo y devuelve 0
    'sino verifica si es num�rico el valor
    'sino es nun�rico devuelve cero y si es num�rico 
    'retorna el valor de tipo double.
    'Fecha       :    30 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Function funNull2Val(ByVal strValor As Object) As Double
        If IsDBNull(strValor) Then
            Return 0
        Else
            Dim strTemp = Trim(Convert.ToString(strValor))
            If IsNumeric(strTemp) Then
                Return CDbl(strTemp)
            Else
                Return 0
            End If
        End If
    End Function



    'Env�a una variable strFecha 
    'que primero verifica si es nulo o si tiene largo = 0 y 
    'devuelve "" sino revisa si es una fecha y le da un 
    'formato de Short Date y lo retorna.
    'Fecha       :    30 de Noviembre del 2018.
    'Autor       :    Jorge L�pez Jim�nez.
    'Tipo Doc    :    Primera Documentaci�n.
    'Ubicaci�n   :    modRutinas.vb.
    'Tipo Objeto :    M�dulo de Procedimientos.
    'Nombre      :    modRutinas.vb.
    'Base        :    Ninguna.
    'Tablas      :    Ninguna.

    Function funNull2Date(ByVal strFecha) As String
        If IsDBNull(strFecha) Then
            Return ""
        Else
            If Len(Trim(CStr(strFecha))) = 0 Then
                Return ""
            ElseIf IsDate(strFecha) Then
                Return FormatDateTime(CDate(strFecha).Date, DateFormat.ShortDate)
            Else
                Return ""
            End If
        End If
    End Function


    Function funNull2Boolean(ByVal strValor) As Boolean
        If IsDBNull(strValor) Then
            Return False
        Else
            Return CBool(strValor)
        End If
    End Function

    Function funRunSQL(ByVal strSQL As String)
        'Ejecuta bien una instrucciones INSERT y/o UPDATE, las otras hay que revisar
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        cmd.ExecuteNonQuery()
        db.Close()
        Return True
    End Function

    Function funAddCampo(ByVal strCampo As String, _
                         ByVal strValorActual As String, _
                         Optional ByVal strValorAnterior As String = "")

        arrCampos.Add(strCampo)
        'arrTipos.Add(xTipo)
        arrValorAnterior.Add(strValorAnterior)
        arrValorActual.Add(strValorActual)
        Return True
    End Function

    Function funParametrosGrabacion(ByVal strTabla As String, _
                                    ByVal strCampoLlave As String, _
                                    ByVal nTipo As Integer, _
                                    Optional ByVal nRecno As Integer = 0, _
                                    Optional ByVal nPista As Integer = 1)
        'nTipo = 1-Nuevo, 2-Edici�n
        Dim I As Integer
        Dim nCambios As Integer
        If nTipo = 1 Then
            nCambios = 1
            strSQL = "INSERT INTO " & strTabla & "("
            For I = 0 To arrCampos.Count - 1
                strSQL += IIf(I >= 1, ",", "")
                strSQL += arrCampos(I)
            Next
            strSQL += ") VALUES ("
            For I = 0 To arrCampos.Count - 1
                strSQL += IIf(I >= 1, ",", "")
                strSQL += "'" & Trim(arrValorActual(I)) & "'"
            Next
            strSQL += ") "
            Debug.Print(strSQL)
        Else
            nCambios = 0
            strSQL = "UPDATE " & strTabla & " SET "
            For I = 0 To arrCampos.Count - 1
                If arrValorActual(I) <> arrValorAnterior(I) Then
                    strSQL += IIf(nCambios >= 1, ",", "")
                    strSQL += arrCampos(I) & " = '" & Trim(arrValorActual(I)) & "'"
                    nCambios += 1
                End If
            Next
            strSQL += " WHERE " & strCampoLlave & " = " & nRecno
            Debug.Print(strSQL)
        End If
        If nCambios >= 1 Then
            funRunSQL(strSQL)
            If nPista = 1 Then
                For I = 0 To arrCampos.Count - 1
                    If nRecno > 0 Then
                        funSetTrace(strTabla, nRecno, arrCampos(I), arrValorAnterior(I), arrValorActual(I))
                    End If
                Next
            End If
        End If

        arrCampos.Clear()
        arrValorAnterior.Clear()
        arrValorActual.Clear()
        Return True
    End Function

    Function funFillDataSet(ByVal strSql As String) As DataSet
        Dim ds As New DataSet()
        Dim DBConn As New SqlConnection(funConexion())
        Dim DBCommand As New SqlDataAdapter(strSql, DBConn)
        DBCommand.SelectCommand.CommandType = CommandType.Text
        DBCommand.Fill(ds, "Tabla")
        DBConn.Close()
        Return ds
    End Function

    Public Function funFillDataSetTransaccion(ByVal strSql As String) As DataSet
        Dim DBCommand As SqlDataAdapter
        Dim ds As New DataSet()

        DBCommand = New SqlDataAdapter(strSql, DBConnGlobal)
        DBCommand.SelectCommand.CommandType = CommandType.Text
        DBCommand.SelectCommand.Connection = DBConnGlobal
        DBCommand.SelectCommand.Transaction = transaccionGlobal
        DBCommand.Fill(ds, "Tabla")
        Return ds
    End Function

    Function AddCheckColumn(ByVal Grid As DataGridView, _
                               ByVal strNombre As String, _
                               ByVal strHeader As String, _
                               ByVal intPosicion As Integer)

        Dim column As New DataGridViewCheckBoxColumn()
        With column
            .HeaderText = strHeader
            .Name = strNombre
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            '.CellTemplate.Style.BackColor = Color.Beige
        End With
        Grid.Columns.Insert(intPosicion, column)
        Return True
    End Function

    Function funParametrosGrabacionTransaccion( _
                        ByVal strTabla As String, _
                        ByVal strCampoLlave As String, _
                        ByVal nTipo As Integer, _
                        Optional ByVal nRecno As Integer = 0, _
                        Optional ByVal nCabecera As Integer = 0, _
                        Optional ByVal nPista As Integer = 1)

        'nTipo = 1-Nuevo, 2-Edici�n
        Dim I As Integer
        Dim nCambios As Integer
        If nTipo = 1 Then
            nCambios = 1
            strSQL = "INSERT INTO " & strTabla & "("
            For I = 0 To arrCampos.Count - 1
                strSQL += IIf(I >= 1, ",", "")
                strSQL += arrCampos(I)
            Next
            strSQL += ") VALUES ("
            For I = 0 To arrCampos.Count - 1
                strSQL += IIf(I >= 1, ",", "")
                strSQL += "'" & Trim(arrValorActual(I)) & "'"
            Next
            strSQL += ") "
            Debug.Print(strSQL)
        Else
            nCambios = 0
            strSQL = "UPDATE " & strTabla & " SET "
            For I = 0 To arrCampos.Count - 1
                If arrValorActual(I) <> arrValorAnterior(I) Then
                    strSQL += IIf(nCambios >= 1, ",", "")
                    strSQL += arrCampos(I) & " = '" & Trim(arrValorActual(I)) & "'"
                    nCambios += 1
                End If
            Next

            'If nRecno <> 0 Then
            '    strSQL += " WHERE " & strCampoLlave & " = " & nRecno
            'Else
            strSQL += " WHERE " & strCampoLlave
            'End If

            Debug.Print(strSQL)
        End If

        If nCambios = 0 Then 'NO HAY NINGUN CAMBIO
        Else
            funRunSQLTransaccion(strSQL)
            If nPista = 1 Then ' Solo graba pista cuando es 1
                If nTipo = 2 Then
                    For I = 0 To arrCampos.Count - 1
                        funSetTrace(strTabla, nRecno, arrCampos(I), Mid(arrValorAnterior(I), 1, 150), Mid(arrValorActual(I), 1, 150), nCabecera)
                    Next
                End If
            End If
        End If

        arrCampos.Clear()
        arrValorAnterior.Clear()
        arrValorActual.Clear()
        Return True
    End Function

    Function funRunSQLTransaccion(ByVal strSQL As String)
        Dim cmd As New SqlCommand(strSQL, DBConnGlobal)
        cmd.Connection = DBConnGlobal
        cmd.Transaction = transaccionGlobal
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Function funGetValorTransaccion(ByVal strQuery As String)
        'Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strQuery, DBConnGlobal)
        'db.Open()

        'DBCommand.SelectCommand.Connection = DBConnGlobal
        'DBCommand.SelectCommand.Transaction = transaccionGlobal
        cmd.Transaction = transaccionGlobal
        funGetValorTransaccion = cmd.ExecuteScalar
        'db.Close()
    End Function

    Function funGetValor(ByVal strQuery As String)
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strQuery, db)
        db.Open()
        funGetValor = cmd.ExecuteScalar
        db.Close()
    End Function

    Public Sub LimpiarCampos()
        arrCampos.Clear()
        arrValorAnterior.Clear()
        arrValorActual.Clear()
    End Sub

    Public Function IP() As String
        Dim Host As String

        Host = Dns.GetHostName

        Dim IPs As IPHostEntry = Dns.GetHostEntry(Host)
        'Dim Direcciones As IPAddress() = IPs.AddressList
        Return IPs.HostName 'Direcciones(0).ToString()

    End Function

    Public Function funIndice() As Integer
        indice += 1
        Return indice
    End Function

    Function funTipoCambioTwo(ByVal dtm As DateTime, ByVal Moneda As Integer) As Double
        Dim strSQL As String
        If Moneda = 2 Then
            dtm = FormatDateTime(dtm, DateFormat.ShortDate)
            strSQL = "SELECT VALOR FROM TCDOLAR WHERE FECHA = '" & dtm & "'"
            funTipoCambioTwo = funGetValor(strSQL)
        ElseIf Moneda = 3 Then
            dtm = FormatDateTime(dtm, DateFormat.ShortDate)
            strSQL = "SELECT EUROS FROM TCDOLAR WHERE FECHA = '" & dtm & "'"
            funTipoCambioTwo = funNull2Val(funGetValor(strSQL))
        End If
        Return funTipoCambioTwo
    End Function
    Public Function AbrirConexionGlobal()
        DBConnGlobal = New SqlConnection(funConexion())
        DBConnGlobal.Open()
        transaccionGlobal = DBConnGlobal.BeginTransaction

        Return True
    End Function

    Function funSPID()
        '- Retorna el ID del proceso que se esta ejecutando, lo usaremos para identificar
        '-  la session abierta por el usuario
        Dim strSQL As String = "SELECT @@SPID"
        Dim db As New SqlConnection(funConexion())
        Dim cmd As New SqlCommand(strSQL, db)
        db.Open()
        funSPID = cmd.ExecuteScalar
        db.Close()
    End Function

    Function funFechaEfectiva(ByVal strFecha As String)
        'Devuelve la fecha efectiva de una fecha
        Dim strResultado As String

        strQuery = "SELECT ISNULL(MAX(STRDATA), '') FROM GEN_CURSO_LECTIVO WHERE NEMPRESA = " & intEmpresa & _
                   " AND '" & strFecha & "' >= CONVERT(DATETIME, CONVERT(NVARCHAR(10), DTMINICIO, 103)) " & _
                   " AND  '" & strFecha & "' <= CONVERT(DATETIME, CONVERT(NVARCHAR(10), DTMFINAL, 103)) "

        strResultado = funGetValor(strQuery)

        Return IIf(Len(Trim(strResultado)) >= 1, strResultado, "")

    End Function

    Function funGetTablaDeTablas(ByVal nTabla As Integer, _
                              Optional ByVal nGrupo As Integer = 0, _
                              Optional ByVal bFiltrarStatus As Boolean = True, _
                              Optional ByVal bRecnoEsClave As Boolean = False) As DataTable

        If bRecnoEsClave Then
            strSQL = " SELECT NRECNO AS NID, NCODTBL, NGRUPO, STRDESCRIPCION, STRCONCEPTO" & _
                       " FROM TABLADETABLAS" & _
                       " WHERE NID >= 1 " & _
                       " AND NCODTBL = " & nTabla & _
                       " AND NEMPRESA = " & intEmpresa
        Else
            'DEFAULT
            strSQL = " SELECT NRECNO, NCODTBL, NID, NGRUPO, STRDESCRIPCION, STRCONCEPTO" & _
                       " FROM TABLADETABLAS" & _
                       " WHERE NID >= 1 " & _
                       " AND NCODTBL = " & nTabla & _
                       " AND NEMPRESA = " & intEmpresa
        End If
        If bFiltrarStatus Then
            strSQL += " AND NESTATUS = 1"
        End If
        If nGrupo >= 1 Then
            strSQL += " AND NGRUPO = " & nGrupo
        End If
        strSQL += " ORDER BY STRDESCRIPCION"
        Dim dtTabla As DataTable = funFillDataSet(strSQL).Tables(0)
        Return dtTabla
    End Function

    Function funCTxt(ByVal stReplace As String) As String
        '-- Limpia apostrofes de un TextBox
        Dim StNewString As String
        StNewString = Replace(stReplace, "'", "''")
        Return StNewString
    End Function

    Public Function funFechaSql(ByVal Fecha As String, Optional ByVal bSoloFecha As Boolean = False) As String
        'Devuelve un string de Fecha en el formato yyyymmdd
        Dim strResultado As String = ""
        If IsDate(Fecha) Then
            strResultado = CDate(Fecha).Year &
                            Format(CDate(Fecha).Month, "00") &
                            Format(CDate(Fecha).Day, "00")
            If bSoloFecha = False Then
                strResultado += Space(1) &
                            Format(CDate(Fecha).Hour, "00") & ":" &
                            Format(CDate(Fecha).Minute, "00") & ":" &
                            Format(CDate(Fecha).Second, "00") & "." &
                            Format(CDate(Fecha).Millisecond, "000")
            End If
        End If
        Return strResultado
    End Function

End Module
﻿Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmFactura_Data
    Dim varToday As Date
    Dim ds As New DataSet
    Dim bolInicio As Boolean
    Dim i As Integer
    Dim nTipoMovGrid As Integer
    Dim r As Integer
    Dim intTipoRegistro As Integer
    Public vnOrden As Integer '- Numero de Orden para nuevos numeros y busqueda
    Public vnRecno, nTipo, vnNumero, vnConcepto, vnTipoMovimiento As Integer
    Dim vnProveedor As Integer
    Public vcRazon_Social As String
    Dim vnTotalMercanciaGravada As Double
    Dim vnTotalMercanciaExentas As Double
    Dim vnTotalVenta As Double
    Dim vnTotalVentaNeta As Double
    Dim vnTotalImpuesto As Double
    Dim vnTotalComprobante As Double
    Dim vnTotalDescuento As Double
    '--
    Dim vnTotalServGravados As Double
    Dim vnTotalServExentos As Double


    Private Sub frmFactura_Data_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        bolInicio = True
        If nTipo = 1 Then
            funCargaCombos()
            'funUpdateGrid()
            'Me.lkConcepto.EditValue = 9
            'Me.lkVenta.EditValue = 2
            'Me.lkClienteTipo.EditValue = 2
            '-- Obtenemos el nuevo numero de movimiento de inventario
            'Me.lblNumero.Text = funNuevoMovInventario(Me.lkConcepto.EditValue)
            'vnNumero = funNuevoMovInventario(Me.lkConcepto.EditValue)
            '-- Obtener el tipo de movimiento
            'funGetTipoMovimiento()
        Else
            funCargaCombos()
            funCargaData()
            'Me.lkConcepto.EditValue = vnConcepto
            Me.lkCliente.EditValue = vnProveedor
            'funUpdateGrid()
            'Me.lkConcepto.Enabled = False
            'Me.txtNotas.Enabled = False
            'Me.txtReferencia.Enabled = False
            Me.bbSave.Enabled = False
            'Me.bbAdd.Enabled = False
            'Me.bbEdit.Enabled = False
            Me.dtpFecha.Enabled = False
            '-- 
            'Me.txtReferencia.Enabled = False
            'Me.txtFactura.Enabled = False
            'Me.dtpOrden.Enabled = False
            'Me.dtpFactura.Enabled = False
            Me.lkCliente.Enabled = False
            'Me.dtpRecibe.Enabled = False
            'Me.txtRecibido.Enabled = False
            'Me.txtAutorizado.Enabled = False
            '-- Me.cbDescuento.Enabled = False
            'funCalculoTotalProducto()
        End If
        bolInicio = False
    End Sub

    Private Sub funCargaCombos()

        '-- Combo Proveedores
        strSQL = "SELECT nPersona AS nCodigo, strFullName AS strDescripcion " &
                    " FROM Gen_Cliente_Venta"
        '--
        funCargarlue(Me.lkCliente, strSQL)
        '-- Tipo de Cliente
        strSQL = "SELECT nCode AS nCodigo, strData AS strDescripcion " &
                    " FROM CAT_Cliente_Precio"
        '--
        'funCargarlue(Me.lkClienteTipo, strSQL)
        '--
    End Sub

    Private Function funDesactivar()
        Me.bbSave.Enabled = False
        'Me.bbAdd.Enabled = False
        'Me.bbEdit.Enabled = False
        'Me.txtNotas.Enabled = False
        'Me.gcDetalle.Enabled = False
        Return True
    End Function

    Private Sub lkCliente_EditValueChanged(sender As Object, e As EventArgs) Handles lkCliente.EditValueChanged
        If Me.bolInicio = False Then
            funCarga_Cliente()
        End If
    End Sub

    Private Sub funCarga_Cliente()
        '-- 
        strSQL = "SELECT * FROM Gen_Cliente_Venta " &
                    "WHERE nPersona = " & Me.lkCliente.EditValue & " " &
                    "ORDER BY nPersona"
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.lblCedula.Text = ds.Tables("Tabla").Rows(0)("strCedula").ToString
            Me.lblTelefono.Text = ds.Tables("Tabla").Rows(0)("strTelefono").ToString
            Me.lblCorreo.Text = ds.Tables("Tabla").Rows(0)("strCorreo").ToString
            Me.lblDireccion.Text = ds.Tables("Tabla").Rows(0)("strDomicilio").ToString
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub


    Private Sub funCargaData()
        '-- GB-2012-01-12: Filtramos el registro de la cabezera
        strSQL = "SELECT * FROM Inv_Movto_Inventario " &
                    "WHERE nNumero = " & Me.vnNumero & " " &
                    "AND nConcepto = " & Me.vnConcepto & " " &
                    "AND nEmpresa = " & intEmpresa & " " &
                    "ORDER BY nNumero"
        '-- Cargamos el DS
        ds = funFillDataSet(strSQL)
        '-- Verificamos si existen registros
        If ds.Tables("Tabla").Rows.Count >= 1 Then
            '-- Cargamos datos
            Me.dtpFecha.Value = ds.Tables("Tabla").Rows(0)("dtmFechaDoc").ToString
            Me.vnConcepto = funNull2Val(ds.Tables("Tabla").Rows(0)("nConcepto"))
            'Me.lblNumero.Text = funNull2Val(ds.Tables("Tabla").Rows(0)("nNumero"))
            'Me.txtReferencia.Text = ds.Tables("Tabla").Rows(0)("strReferencia").ToString
            'Me.txtNotas.Text = ds.Tables("Tabla").Rows(0)("strNota").ToString
            '-- 
            'Me.txtReferencia.Text = ds.Tables("Tabla").Rows(0)("strOrden").ToString
            'Me.txtFactura.Text = ds.Tables("Tabla").Rows(0)("strFactura").ToString
            'Me.dtpOrden.Value = ds.Tables("Tabla").Rows(0)("dtmOrden").ToString
            'Me.dtpFactura.Value = ds.Tables("Tabla").Rows(0)("dtmFactura").ToString
            'vnProveedor = CInt(funNull2Val(ds.Tables("Tabla").Rows(0)("nOrigenDestino")))
            '-- 2012-02-21 Agregamos: strPersonaRecibe, strPersonaAutoriza, dtmRecibido
            'Me.dtpRecibe.Value = ds.Tables("Tabla").Rows(0)("dtmRecibido").ToString
            'Me.txtRecibido.Text = ds.Tables("Tabla").Rows(0)("strPersonaRecibe").ToString
            'Me.txtAutorizado.Text = ds.Tables("Tabla").Rows(0)("strPersonaAutoriza").ToString
        Else
            MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Información")
        End If
        '--
    End Sub

    Private Sub bClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bClose.ItemClick
        Me.Close()
    End Sub

    Private Sub frmFactura_Data_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        '--
        Select Case e.KeyCode
            Case Keys.F1
                'subAdd()
            Case Keys.F2
                'subEdit()
            Case Keys.F3
                'subKardex()
        End Select
    End Sub


    Private Sub bbSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        'If Validar() = True Then
        '    If MessageBox.Show("¿ Desea Grabar los datos ahora ...?", "ATENCION !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
        '        Guardar()
        '    End If
        'End If
        clsFactura.funGetFacturaElectronica_Tienda(CDbl(Me.txtSucursal.Text), CDbl(Me.txtCaja.Text), CDbl(Me.txtFactura.Text), Me.lkCliente.EditValue)
        Me.Close()
    End Sub

End Class
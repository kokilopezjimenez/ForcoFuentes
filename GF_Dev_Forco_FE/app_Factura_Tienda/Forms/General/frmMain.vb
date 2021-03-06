Option Explicit On
Imports System.Data
Imports System.Data.SqlClient

Public Class frmMain
    Dim Usuarios As New SGA.clsUsuarios
    Dim ds As DataSet
    Public strModulo As String
    Public bolSolicitudCheque As Boolean
    Dim j, x As Integer

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        funCleanTempFiles()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '--
        Try
            '-- Pasamos los rotulos de la barra de status
            strTitulo = ""
            Me.ssUser.Text = strUser
            Me.ssServidor.Text = strServidor
            Me.ssBaseDatos.Text = strBaseDatos
            If strModulo = "" Then
                strModulo = GetSetting(Application.ProductName, "Menu", "Modulo", "")
            End If
            'If strModulo = "" Then
            'Me.NavBarControl1.Groups("navCatalogo").Expanded = True
            'Else
            'Me.NavBarControl1.Groups(strModulo).Expanded = True
            'End If
            '-- Seleccionamos la Empresa
            strSQL = "SELECT TOP 1 STRDESCRIPCION FROM TABLADETABLAS WHERE NCODTBL = 1 AND NID = " & intEmpresa
            EmpresaNombre = funGetValor(strSQL)
            Me.ssEmpresa.Text = EmpresaNombre
            '-- Texto de Ubicaci�n acutal de la barra de menu
            Me.ssModulo.Text = Me.NavBarControl1.ActiveGroup.Caption
            '-- Seleccinamos el Area 
            strSQL = "SELECT TOP 1 STRDESCRIPCION FROM TABLADETABLAS WHERE NCODTBL = 10 AND NID = " & nDepto
            Me.ssArea.Text = funGetValor(strSQL)
            '--
            funRecorreMenuOutlook()
            funActivarMenuUsuario()
            funActivarMenuUsuarioprin()
            '--
            'subFullVisibleFalse()
            '--
            'If intEmpresa = 2 Then
            '    Me.nav2Orden.Enabled = True
            '    Me.navEntrada.Visible = False
            '    Me.navFactura.Visible = False
            '    Me.navInventario.Visible = True
            '    Me.navCatalogo.Visible = True
            '    Me.nav2EntradaPro.Enabled = True
            '    Me.nav2EntradaPT.Enabled = False
            '    Me.nav2Inicial.Enabled = False
            '    Me.nav2Receta.Enabled = False
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '--
    End Sub

    Function funRecorreMenuOutlook()
        funRunSQL("TRUNCATE TABLE GEN_MENU")
        Dim NVALORMENU As Integer
        For i As Integer = 0 To NavBarControl1.Groups.Count - 1
            NVALORMENU = i
            For k As Integer = 0 To NavBarControl1.Groups(i).ItemLinks.Count - 1

                NavBarControl1.Groups(i).ItemLinks.Item(k).Item.Visible = False
                Dim strMenu As String = NavBarControl1.Groups(i).Name
                Dim strSubMenu As String = NavBarControl1.Groups(i).ItemLinks.Item(k).ItemName
                strSQL = String.Format("INSERT INTO GEN_MENU ( cMenu, cSubMenu, nIdMenu ) VALUES  ( '{0}', '{1}', '{2}')", strMenu, strSubMenu, NVALORMENU)
                funRunSQL(strSQL)
            Next
        Next
        Return True
    End Function

    Function funActivarMenuUsuario()
        strSQL = String.Format("SELECT  * FROM dbo.Gen_RolMenu" & _
                            " WHERE nRolId IN ( SELECT  NID " & _
                            " FROM FUNROLESPORUSUARIO({0}, {1}) WHERE STATUS = 1 )" & _
                            " AND NSTATUS = 1", _
                            intEmpresa, nUserID)
        Dim dsRoles As DataSet = funFillDataSet(strSQL)

        For i As Integer = 0 To dsRoles.Tables(0).Rows.Count - 1
            Dim dr As DataRow = dsRoles.Tables(0).Rows(i)
            For j As Integer = 0 To NavBarControl1.Groups.Count - 1

                For k As Integer = 0 To NavBarControl1.Groups(j).ItemLinks.Count - 1
                    If NavBarControl1.Groups(j).ItemLinks.Item(k).ItemName = dr.Item("STRMENU").ToString Then
                        NavBarControl1.Groups(j).ItemLinks.Item(k).Item.Visible = True
                    End If
                Next
            Next
        Next
        Return True
    End Function

    Function funActivarMenuUsuarioprin()
        strSQL = String.Format(" SELECT  dbo.Gen_Menu.cMenu, dbo.Gen_Menu.nIdMenu FROM dbo.Gen_RolMenu GRM " & _
                             " INNER JOIN dbo.Gen_Menu ON dbo.Gen_Menu.cSubMenu=GRM.strMenu " & _
                             " WHERE nRolId IN ( SELECT  NID FROM FUNROLESPORUSUARIO({0}, {1}) WHERE STATUS = 1 ) " & _
                             " AND GRM.NSTATUS = 1  GROUP BY nIdMenu,cMenu", _
                             intEmpresa, nUserID)
        Dim dsRoles As DataSet = funFillDataSet(strSQL)


        For j As Integer = 0 To NavBarControl1.Groups.Count - 1
            NavBarControl1.Groups(j).Visible = False
            For i As Integer = 0 To dsRoles.Tables(0).Rows.Count - 1
                Dim dr As DataRow = dsRoles.Tables(0).Rows(i)

                If NavBarControl1.Groups(j).Name = dr.Item("cMenu").ToString Then
                    NavBarControl1.Groups(j).Visible = True
                End If
            Next
        Next
        Return True
    End Function
    Private Sub NavBarControl1_ActiveGroupChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarGroupEventArgs) Handles NavBarControl1.ActiveGroupChanged
        If Me.ssUser.Text = "statusUser" Then
            Exit Sub
        End If
        Me.ssModulo.Text = Me.NavBarControl1.ActiveGroup.Caption
        If Me.NavBarControl1.ActiveGroup.Name <> "" Then
            SaveSetting(Application.ProductName, "Menu", "Modulo", Me.NavBarControl1.ActiveGroup.Name)
        End If
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("�Desea cerrar el programa ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Cerrar el programa") = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub nav2Empresa_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        CambiarEmpresa()
    End Sub

    Private Sub CambiarEmpresa()
        If Me.MdiChildren.Length() = 0 Then
            Dim f As New frmCambiarEmpresa
            f.ShowDialog()
        Else
            If MsgBox("Debe cerrar todos los formularios abiertos antes de cambiar de empresa." & Chr(13) & "�Desea cerrarlos ahora mismo?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Atenci�n") = MsgBoxResult.Yes Then
                For i As Integer = 0 To Me.MdiChildren.Length - 1
                    Me.ActiveMdiChild.Close()
                Next
                Dim f As New frmCambiarEmpresa
                f.ShowDialog()
            End If
        End If
        Me.ssEmpresa.Text = EmpresaNombre
    End Sub

    Private Sub MostrarForm(ByVal f As Object)
        f.MdiParent = Me
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub nav2StatusInventario_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        '-- 111: Status Movimiento del Inventario
        Dim f As New frmTablaDeTablas
        f.nValor = 111
        f.ShowDialog()
    End Sub

    Private Sub nav2Producto_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        'Me.MostrarForm(My.Forms.frmProducto_Open)
    End Sub

    Private Sub nav2General_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        Dim f As New frmTablaDeTablas
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub nav2Persona_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        '-- Proveedores
        'Me.MostrarForm(My.Forms.frmProveedor_Open)
    End Sub

    Private Sub nav2Salida_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Salida.LinkClicked
        '-- Me.MostrarForm(My.Forms.frmFactura_Open)
        '-- Me.MostrarForm(My.Forms.frmSalida_Open)
        '-- vnTipoSalida = 11
        vnTipoSalida = 9
        Me.MostrarForm(My.Forms.frmFactura_Open)
    End Sub


    Private Sub nav2Salida2_LinkClicked(sender As System.Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        '-- Me.MostrarForm(My.Forms.frmFactura_Open)
        '-- Me.MostrarForm(My.Forms.frmSalida_Open)
        vnTipoSalida = 12
        Me.MostrarForm(My.Forms.frmFactura_Open)
    End Sub


    Private Sub nav2Usuarios_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Usuarios.LinkClicked
        Using f As New frmUserOpen() With {.StartPosition = FormStartPosition.CenterScreen}
            f.ShowDialog()
        End Using
    End Sub

    Private Sub nav2Cliente_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nav2Cliente.LinkClicked
        '-- Clientes
        Me.MostrarForm(My.Forms.frmCliente_Open)
    End Sub

    Private Sub nav2Familia_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        '-- Clientes
        'Me.MostrarForm(My.Forms.frmFamilia_Open)
    End Sub


    Private Function funPrintLocal(ByVal strReporte As String, ByVal strFuenteDatos As String)
        'If ds.Tables("Tabla").Rows.Count >= 1 Then
        '--
        Me.Cursor = Cursors.WaitCursor
        bolPrintTitulo = True
        funImprimirNew(strReporte, 0, 0, 0, 0, 0, 0, strFuenteDatos)
        bolPrintTitulo = False
        Me.Cursor = Cursors.Default
        'Else
        'MsgBox("No Existen Registros ... !!!", MsgBoxStyle.Critical, "Informaci�n")
        'End If
        Return True
    End Function
End Class


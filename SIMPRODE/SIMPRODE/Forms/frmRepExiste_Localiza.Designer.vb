﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRepExiste_Localiza
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepExiste_Localiza))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.bbExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.bbDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.bbAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.gcLista = New DevExpress.XtraGrid.GridControl()
        Me.gvLista = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colOpt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colData = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.bbRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.gcDetalle2 = New DevExpress.XtraGrid.GridControl()
        Me.gvDetalle2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.bbClear = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gcLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.gcDetalle2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.MaxItemId = 0
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(961, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 627)
        Me.barDockControlBottom.Size = New System.Drawing.Size(961, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 627)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(961, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 627)
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ApplicationButtonText = Nothing
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.bClose, Me.bbPrint, Me.bbExcel})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 27
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage2})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowCategoryInCaption = False
        Me.RibbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[True]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(961, 93)
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'bClose
        '
        Me.bClose.Caption = "Cerrar"
        Me.bClose.Id = 21
        Me.bClose.LargeGlyph = CType(resources.GetObject("bClose.LargeGlyph"), System.Drawing.Image)
        Me.bClose.Name = "bClose"
        '
        'bbPrint
        '
        Me.bbPrint.Caption = "Ver"
        Me.bbPrint.Id = 25
        Me.bbPrint.LargeGlyph = CType(resources.GetObject("bbPrint.LargeGlyph"), System.Drawing.Image)
        Me.bbPrint.Name = "bbPrint"
        '
        'bbExcel
        '
        Me.bbExcel.Caption = "Excel"
        Me.bbExcel.Id = 26
        Me.bbExcel.LargeGlyph = CType(resources.GetObject("bbExcel.LargeGlyph"), System.Drawing.Image)
        Me.bbExcel.Name = "bbExcel"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2})
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "Catálogo de Cuentas"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bbExcel)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.bClose)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.ShowCaptionButton = False
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl1.Controls.Add(Me.bbDelete)
        Me.GroupControl1.Controls.Add(Me.bbAdd)
        Me.GroupControl1.Controls.Add(Me.gcLista)
        Me.GroupControl1.Location = New System.Drawing.Point(2, 94)
        Me.GroupControl1.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(312, 532)
        Me.GroupControl1.TabIndex = 407
        Me.GroupControl1.Text = ":: Filtro ::"
        '
        'bbDelete
        '
        Me.bbDelete.Image = CType(resources.GetObject("bbDelete.Image"), System.Drawing.Image)
        Me.bbDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.bbDelete.Location = New System.Drawing.Point(30, 1)
        Me.bbDelete.Name = "bbDelete"
        Me.bbDelete.Size = New System.Drawing.Size(23, 19)
        Me.bbDelete.TabIndex = 628
        Me.bbDelete.Text = "6"
        Me.bbDelete.ToolTip = "Desmarcar Todos !!!"
        Me.bbDelete.ToolTipTitle = "Personas"
        '
        'bbAdd
        '
        Me.bbAdd.Image = CType(resources.GetObject("bbAdd.Image"), System.Drawing.Image)
        Me.bbAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.bbAdd.Location = New System.Drawing.Point(4, 1)
        Me.bbAdd.Name = "bbAdd"
        Me.bbAdd.Size = New System.Drawing.Size(23, 19)
        Me.bbAdd.TabIndex = 627
        Me.bbAdd.Text = "6"
        Me.bbAdd.ToolTip = "Marcar Todos !!!"
        Me.bbAdd.ToolTipTitle = "Personas"
        '
        'gcLista
        '
        Me.gcLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcLista.Location = New System.Drawing.Point(2, 21)
        Me.gcLista.MainView = Me.gvLista
        Me.gcLista.MenuManager = Me.RibbonControl1
        Me.gcLista.Name = "gcLista"
        Me.gcLista.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gcLista.Size = New System.Drawing.Size(308, 509)
        Me.gcLista.TabIndex = 0
        Me.gcLista.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvLista})
        '
        'gvLista
        '
        Me.gvLista.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colOpt, Me.colData})
        Me.gvLista.GridControl = Me.gcLista
        Me.gvLista.Name = "gvLista"
        Me.gvLista.OptionsView.ShowGroupPanel = False
        '
        'colOpt
        '
        Me.colOpt.Caption = "Opcion"
        Me.colOpt.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.colOpt.FieldName = "optSelection"
        Me.colOpt.Name = "colOpt"
        Me.colOpt.Visible = True
        Me.colOpt.VisibleIndex = 0
        Me.colOpt.Width = 45
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'colData
        '
        Me.colData.Caption = "Posición"
        Me.colData.FieldName = "POSICION"
        Me.colData.Name = "colData"
        Me.colData.Visible = True
        Me.colData.VisibleIndex = 1
        Me.colData.Width = 250
        '
        'bbRefresh
        '
        Me.bbRefresh.Appearance.Options.UseTextOptions = True
        Me.bbRefresh.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.bbRefresh.Image = CType(resources.GetObject("bbRefresh.Image"), System.Drawing.Image)
        Me.bbRefresh.Location = New System.Drawing.Point(321, 94)
        Me.bbRefresh.Name = "bbRefresh"
        Me.bbRefresh.Size = New System.Drawing.Size(88, 23)
        Me.bbRefresh.TabIndex = 447
        Me.bbRefresh.Text = "Consultar"
        '
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl2.Controls.Add(Me.gcDetalle2)
        Me.GroupControl2.Location = New System.Drawing.Point(316, 123)
        Me.GroupControl2.LookAndFeel.SkinName = "Office 2016 Dark"
        Me.GroupControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(649, 503)
        Me.GroupControl2.TabIndex = 446
        Me.GroupControl2.Text = ":: Listado de Artículos ::"
        '
        'gcDetalle2
        '
        Me.gcDetalle2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDetalle2.Location = New System.Drawing.Point(2, 21)
        Me.gcDetalle2.MainView = Me.gvDetalle2
        Me.gcDetalle2.Name = "gcDetalle2"
        Me.gcDetalle2.Size = New System.Drawing.Size(645, 480)
        Me.gcDetalle2.TabIndex = 0
        Me.gcDetalle2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetalle2, Me.GridView4, Me.GridView5})
        '
        'gvDetalle2
        '
        Me.gvDetalle2.GridControl = Me.gcDetalle2
        Me.gvDetalle2.Name = "gvDetalle2"
        Me.gvDetalle2.OptionsView.ShowGroupPanel = False
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.gcDetalle2
        Me.GridView4.Name = "GridView4"
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.gcDetalle2
        Me.GridView5.Name = "GridView5"
        '
        'bbClear
        '
        Me.bbClear.Appearance.Options.UseTextOptions = True
        Me.bbClear.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.bbClear.Image = CType(resources.GetObject("bbClear.Image"), System.Drawing.Image)
        Me.bbClear.Location = New System.Drawing.Point(415, 94)
        Me.bbClear.Name = "bbClear"
        Me.bbClear.Size = New System.Drawing.Size(88, 23)
        Me.bbClear.TabIndex = 454
        Me.bbClear.Text = "Limpiar"
        '
        'frmRepExiste_Localiza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(961, 627)
        Me.Controls.Add(Me.bbClear)
        Me.Controls.Add(Me.bbRefresh)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepExiste_Localiza"
        Me.Text = ":: Existencia Por Localización - CEDI ::"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gcLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.gcDetalle2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents bClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents bbExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents bbDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bbAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcLista As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvLista As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colOpt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colData As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bbRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcDetalle2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDetalle2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bbClear As DevExpress.XtraEditors.SimpleButton
End Class

﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnMensajeRechazados = New System.Windows.Forms.Button()
        Me.btnVerificarEstado = New System.Windows.Forms.Button()
        Me.lblVerificarEstado = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 55)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(582, 457)
        Me.DataGridView1.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(618, 55)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(575, 457)
        Me.DataGridView2.TabIndex = 2
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 3600000
        '
        'btnMensajeRechazados
        '
        Me.btnMensajeRechazados.Location = New System.Drawing.Point(618, 26)
        Me.btnMensajeRechazados.Name = "btnMensajeRechazados"
        Me.btnMensajeRechazados.Size = New System.Drawing.Size(185, 23)
        Me.btnMensajeRechazados.TabIndex = 3
        Me.btnMensajeRechazados.Text = "Actualizar Mensaje Rechazados"
        Me.btnMensajeRechazados.UseVisualStyleBackColor = True
        '
        'btnVerificarEstado
        '
        Me.btnVerificarEstado.Location = New System.Drawing.Point(1008, 12)
        Me.btnVerificarEstado.Name = "btnVerificarEstado"
        Me.btnVerificarEstado.Size = New System.Drawing.Size(185, 23)
        Me.btnVerificarEstado.TabIndex = 4
        Me.btnVerificarEstado.Text = "Verificar Estado"
        Me.btnVerificarEstado.UseVisualStyleBackColor = True
        '
        'lblVerificarEstado
        '
        Me.lblVerificarEstado.AutoSize = True
        Me.lblVerificarEstado.Location = New System.Drawing.Point(1008, 36)
        Me.lblVerificarEstado.Name = "lblVerificarEstado"
        Me.lblVerificarEstado.Size = New System.Drawing.Size(16, 13)
        Me.lblVerificarEstado.TabIndex = 5
        Me.lblVerificarEstado.Text = "..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1205, 513)
        Me.Controls.Add(Me.lblVerificarEstado)
        Me.Controls.Add(Me.btnVerificarEstado)
        Me.Controls.Add(Me.btnMensajeRechazados)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturación Electrónica - Paletas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnMensajeRechazados As Button
    Friend WithEvents btnVerificarEstado As Button
    Friend WithEvents lblVerificarEstado As Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CReport
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ctlRptView = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'ctlRptView
        '
        Me.ctlRptView.ActiveViewIndex = -1
        Me.ctlRptView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ctlRptView.DisplayGroupTree = False
        Me.ctlRptView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctlRptView.Location = New System.Drawing.Point(0, 0)
        Me.ctlRptView.Name = "ctlRptView"
        Me.ctlRptView.SelectionFormula = ""
        Me.ctlRptView.Size = New System.Drawing.Size(995, 660)
        Me.ctlRptView.TabIndex = 0
        Me.ctlRptView.ViewTimeSelectionFormula = ""
        '
        'CReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 660)
        Me.Controls.Add(Me.ctlRptView)
        Me.Name = "CReport"
        Me.Text = "CReport"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents ctlRptView As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

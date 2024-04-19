<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcカードNODnp1356
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LblカードNo = New 共通Windowsコントロール.usrLbl
        Me.TxtカードNo = New 共通Windowsコントロール.usrTxt
        Me.SuspendLayout()
        '
        'LblカードNo
        '
        Me.LblカードNo.AutoSize = True
        Me.LblカードNo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblカードNo.Isクリア = False
        Me.LblカードNo.Location = New System.Drawing.Point(0, 7)
        Me.LblカードNo.Name = "LblカードNo"
        Me.LblカードNo.pClearValue = ""
        Me.LblカードNo.pID = ""
        Me.LblカードNo.Size = New System.Drawing.Size(14, 13)
        Me.LblカードNo.TabIndex = 4
        Me.LblカードNo.Text = "0"
        Me.LblカードNo.エラー表示用項目名 = ""
        '
        'TxtカードNo
        '
        Me.TxtカードNo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtカードNo.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtカードNo.Isクリア = True
        Me.TxtカードNo.Location = New System.Drawing.Point(0, 4)
        Me.TxtカードNo.MaxLength = 16
        Me.TxtカードNo.Name = "TxtカードNo"
        Me.TxtカードNo.pAutoFocus = True
        Me.TxtカードNo.pAutoSelect = True
        Me.TxtカードNo.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.TxtカードNo.pClearText = ""
        Me.TxtカードNo.pClearValue = ""
        Me.TxtカードNo.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.TxtカードNo.pFromCtl = Nothing
        Me.TxtカードNo.pFromToErrText = ""
        Me.TxtカードNo.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.TxtカードNo.pID = ""
        Me.TxtカードNo.pMaxByte = 0
        Me.TxtカードNo.Size = New System.Drawing.Size(125, 20)
        Me.TxtカードNo.TabIndex = 1
        Me.TxtカードNo.Text = "1234567890123456"
        Me.TxtカードNo.エラー表示用項目名 = ""
        '
        'UcカードNO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LblカードNo)
        Me.Controls.Add(Me.TxtカードNo)
        Me.Name = "UcカードNO"
        Me.Size = New System.Drawing.Size(129, 29)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents LblカードNo As 共通Windowsコントロール.usrLbl
    Public WithEvents TxtカードNo As 共通Windowsコントロール.usrTxt

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcTextLabel
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
        Me.ラベル = New 共通Windowsコントロール.usrLbl
        Me.テキスト = New 共通Windowsコントロール.usrTxt
        Me.SuspendLayout()
        '
        'ラベル
        '
        Me.ラベル.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ラベル.Isクリア = False
        Me.ラベル.Location = New System.Drawing.Point(0, 0)
        Me.ラベル.Name = "ラベル"
        Me.ラベル.pClearValue = ""
        Me.ラベル.pID = ""
        Me.ラベル.Size = New System.Drawing.Size(45, 20)
        Me.ラベル.TabIndex = 1
        Me.ラベル.エラー表示用項目名 = ""
        '
        'テキスト
        '
        Me.テキスト.BackColor = System.Drawing.SystemColors.Window
        Me.テキスト.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.テキスト.Isクリア = True
        Me.テキスト.Location = New System.Drawing.Point(0, 0)
        Me.テキスト.MaxLength = 16
        Me.テキスト.Name = "テキスト"
        Me.テキスト.pAutoFocus = True
        Me.テキスト.pAutoSelect = True
        Me.テキスト.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.テキスト.pClearText = ""
        Me.テキスト.pClearValue = ""
        Me.テキスト.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.テキスト.pFromCtl = Nothing
        Me.テキスト.pFromToErrText = ""
        Me.テキスト.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.テキスト.pID = ""
        Me.テキスト.pMaxByte = 0
        Me.テキスト.Size = New System.Drawing.Size(211, 20)
        Me.テキスト.TabIndex = 0
        Me.テキスト.エラー表示用項目名 = ""
        '
        'UcTextLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ラベル)
        Me.Controls.Add(Me.テキスト)
        Me.Name = "UcTextLabel"
        Me.Size = New System.Drawing.Size(129, 29)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents ラベル As 共通Windowsコントロール.usrLbl
    Public WithEvents テキスト As 共通Windowsコントロール.usrTxt

End Class

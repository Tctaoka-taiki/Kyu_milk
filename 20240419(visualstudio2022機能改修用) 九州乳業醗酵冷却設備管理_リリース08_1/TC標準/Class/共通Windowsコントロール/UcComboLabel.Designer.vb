<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcComboLabel
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
        Me.コンボ = New 共通Windowsコントロール.usrCmb
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
        'コンボ
        '
        Me.コンボ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.コンボ.DropDownWidth = 82
        Me.コンボ.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.コンボ.FormattingEnabled = True
        Me.コンボ.Isクリア = True
        Me.コンボ.Location = New System.Drawing.Point(0, 0)
        Me.コンボ.Name = "コンボ"
        Me.コンボ.pAutoFocus = True
        Me.コンボ.pAutoSelect = True
        Me.コンボ.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.コンボ.pClearIndex = -1
        Me.コンボ.pClearValue = ""
        Me.コンボ.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.コンボ.エラー表示用項目名 = ""
        Me.コンボ.pFromCtl = Nothing
        Me.コンボ.pFromToErrText = ""
        Me.コンボ.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.コンボ.pID = ""
        Me.コンボ.pMaxByte = 0
        Me.コンボ.Size = New System.Drawing.Size(82, 21)
        Me.コンボ.TabIndex = 2
        '
        'UcComboLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.コンボ)
        Me.Controls.Add(Me.ラベル)
        Me.Name = "UcComboLabel"
        Me.Size = New System.Drawing.Size(129, 29)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents ラベル As 共通Windowsコントロール.usrLbl
    Public WithEvents コンボ As 共通Windowsコントロール.usrCmb

End Class

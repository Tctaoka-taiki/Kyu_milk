<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Uc部署
    Inherits UcメンテベースEx

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
        Me.Grp部署 = New System.Windows.Forms.GroupBox
        Me.Txt電話番号 = New 共通Windowsコントロール.usrTxt
        Me.Lbl企業名 = New 共通Windowsコントロール.usrLbl
        Me.Cmb企業名 = New 共通Windowsコントロール.usrCmb
        Me.UsrLbl5 = New 共通Windowsコントロール.usrLbl
        Me.Cmb許可パターン = New 共通Windowsコントロール.usrCmb
        Me.Lbl部署ID = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl11 = New 共通Windowsコントロール.usrLbl
        Me.Txt部署ｶﾅ名 = New 共通Windowsコントロール.usrTxt
        Me.Txt部署コード = New 共通Windowsコントロール.usrTxt
        Me.Txt部署名 = New 共通Windowsコントロール.usrTxt
        Me.Grp部署.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grp部署
        '
        Me.Grp部署.Controls.Add(Me.Txt電話番号)
        Me.Grp部署.Controls.Add(Me.Lbl企業名)
        Me.Grp部署.Controls.Add(Me.Cmb企業名)
        Me.Grp部署.Controls.Add(Me.UsrLbl5)
        Me.Grp部署.Controls.Add(Me.Cmb許可パターン)
        Me.Grp部署.Controls.Add(Me.Lbl部署ID)
        Me.Grp部署.Controls.Add(Me.UsrLbl11)
        Me.Grp部署.Controls.Add(Me.Txt部署ｶﾅ名)
        Me.Grp部署.Controls.Add(Me.Txt部署コード)
        Me.Grp部署.Controls.Add(Me.Txt部署名)
        Me.Grp部署.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grp部署.Location = New System.Drawing.Point(0, 0)
        Me.Grp部署.Name = "Grp部署"
        Me.Grp部署.Size = New System.Drawing.Size(395, 115)
        Me.Grp部署.TabIndex = 4
        Me.Grp部署.TabStop = False
        Me.Grp部署.Text = "クラス情報"
        '
        'Txt電話番号
        '
        Me.Txt電話番号.BackColor = System.Drawing.SystemColors.Window
        Me.Txt電話番号.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt電話番号.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Txt電話番号.Isクリア = True
        Me.Txt電話番号.Location = New System.Drawing.Point(304, 32)
        Me.Txt電話番号.Name = "Txt電話番号"
        Me.Txt電話番号.pAutoFocus = False
        Me.Txt電話番号.pAutoSelect = False
        Me.Txt電話番号.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.Txt電話番号.pClearText = Nothing
        Me.Txt電話番号.pClearValue = Nothing
        Me.Txt電話番号.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.Txt電話番号.pFromCtl = Nothing
        Me.Txt電話番号.pFromToErrText = Nothing
        Me.Txt電話番号.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.Txt電話番号.pID = ""
        Me.Txt電話番号.pMaxByte = 0
        Me.Txt電話番号.Size = New System.Drawing.Size(29, 19)
        Me.Txt電話番号.TabIndex = 5
        Me.Txt電話番号.Visible = False
        Me.Txt電話番号.エラー表示用項目名 = Nothing
        '
        'Lbl企業名
        '
        Me.Lbl企業名.AutoSize = True
        Me.Lbl企業名.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl企業名.Isクリア = False
        Me.Lbl企業名.Location = New System.Drawing.Point(143, 23)
        Me.Lbl企業名.Name = "Lbl企業名"
        Me.Lbl企業名.pClearValue = ""
        Me.Lbl企業名.pID = ""
        Me.Lbl企業名.Size = New System.Drawing.Size(145, 12)
        Me.Lbl企業名.TabIndex = 1
        Me.Lbl企業名.Text = "XXXXXXXXXXXXXXXXXXXX"
        Me.Lbl企業名.エラー表示用項目名 = ""
        '
        'Cmb企業名
        '
        Me.Cmb企業名.BackColor = System.Drawing.SystemColors.Window
        Me.Cmb企業名.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb企業名.DropDownWidth = 146
        Me.Cmb企業名.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb企業名.FormattingEnabled = True
        Me.Cmb企業名.Isクリア = True
        Me.Cmb企業名.Location = New System.Drawing.Point(143, 18)
        Me.Cmb企業名.Name = "Cmb企業名"
        Me.Cmb企業名.pAutoFocus = True
        Me.Cmb企業名.pAutoSelect = True
        Me.Cmb企業名.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.Numonly
        Me.Cmb企業名.pClearIndex = -1
        Me.Cmb企業名.pClearValue = Nothing
        Me.Cmb企業名.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.Cmb企業名.pFromCtl = Nothing
        Me.Cmb企業名.pFromToErrText = ""
        Me.Cmb企業名.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.Cmb企業名.pID = ""
        Me.Cmb企業名.pMaxByte = 0
        Me.Cmb企業名.Size = New System.Drawing.Size(146, 20)
        Me.Cmb企業名.TabIndex = 1
        Me.Cmb企業名.エラー表示用項目名 = "学年"
        '
        'UsrLbl5
        '
        Me.UsrLbl5.AutoSize = True
        Me.UsrLbl5.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl5.Isクリア = False
        Me.UsrLbl5.Location = New System.Drawing.Point(12, 22)
        Me.UsrLbl5.Name = "UsrLbl5"
        Me.UsrLbl5.pClearValue = ""
        Me.UsrLbl5.pID = ""
        Me.UsrLbl5.Size = New System.Drawing.Size(125, 12)
        Me.UsrLbl5.TabIndex = 129
        Me.UsrLbl5.Text = "学年　　　　　　　："
        Me.UsrLbl5.エラー表示用項目名 = ""
        '
        'Cmb許可パターン
        '
        Me.Cmb許可パターン.BackColor = System.Drawing.SystemColors.Window
        Me.Cmb許可パターン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb許可パターン.DropDownWidth = 61
        Me.Cmb許可パターン.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb許可パターン.FormattingEnabled = True
        Me.Cmb許可パターン.Isクリア = True
        Me.Cmb許可パターン.Location = New System.Drawing.Point(156, 62)
        Me.Cmb許可パターン.Name = "Cmb許可パターン"
        Me.Cmb許可パターン.pAutoFocus = True
        Me.Cmb許可パターン.pAutoSelect = True
        Me.Cmb許可パターン.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.Numonly
        Me.Cmb許可パターン.pClearIndex = -1
        Me.Cmb許可パターン.pClearValue = Nothing
        Me.Cmb許可パターン.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.Cmb許可パターン.pFromCtl = Nothing
        Me.Cmb許可パターン.pFromToErrText = ""
        Me.Cmb許可パターン.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.Cmb許可パターン.pID = ""
        Me.Cmb許可パターン.pMaxByte = 0
        Me.Cmb許可パターン.Size = New System.Drawing.Size(61, 20)
        Me.Cmb許可パターン.TabIndex = 6
        Me.Cmb許可パターン.Visible = False
        Me.Cmb許可パターン.エラー表示用項目名 = Nothing
        '
        'Lbl部署ID
        '
        Me.Lbl部署ID.AutoSize = True
        Me.Lbl部署ID.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl部署ID.Isクリア = False
        Me.Lbl部署ID.Location = New System.Drawing.Point(72, 62)
        Me.Lbl部署ID.Name = "Lbl部署ID"
        Me.Lbl部署ID.pClearValue = ""
        Me.Lbl部署ID.pID = ""
        Me.Lbl部署ID.Size = New System.Drawing.Size(65, 12)
        Me.Lbl部署ID.TabIndex = 125
        Me.Lbl部署ID.Text = "9999999999"
        Me.Lbl部署ID.Visible = False
        Me.Lbl部署ID.エラー表示用項目名 = ""
        '
        'UsrLbl11
        '
        Me.UsrLbl11.AutoSize = True
        Me.UsrLbl11.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl11.Isクリア = False
        Me.UsrLbl11.Location = New System.Drawing.Point(12, 43)
        Me.UsrLbl11.Name = "UsrLbl11"
        Me.UsrLbl11.pClearValue = ""
        Me.UsrLbl11.pID = ""
        Me.UsrLbl11.Size = New System.Drawing.Size(125, 12)
        Me.UsrLbl11.TabIndex = 124
        Me.UsrLbl11.Text = "クラス　　　　　　："
        Me.UsrLbl11.エラー表示用項目名 = ""
        '
        'Txt部署ｶﾅ名
        '
        Me.Txt部署ｶﾅ名.BackColor = System.Drawing.SystemColors.Window
        Me.Txt部署ｶﾅ名.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt部署ｶﾅ名.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.Txt部署ｶﾅ名.Isクリア = True
        Me.Txt部署ｶﾅ名.Location = New System.Drawing.Point(223, 65)
        Me.Txt部署ｶﾅ名.Name = "Txt部署ｶﾅ名"
        Me.Txt部署ｶﾅ名.pAutoFocus = False
        Me.Txt部署ｶﾅ名.pAutoSelect = False
        Me.Txt部署ｶﾅ名.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.Txt部署ｶﾅ名.pClearText = Nothing
        Me.Txt部署ｶﾅ名.pClearValue = Nothing
        Me.Txt部署ｶﾅ名.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.Txt部署ｶﾅ名.pFromCtl = Nothing
        Me.Txt部署ｶﾅ名.pFromToErrText = Nothing
        Me.Txt部署ｶﾅ名.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.Txt部署ｶﾅ名.pID = ""
        Me.Txt部署ｶﾅ名.pMaxByte = 0
        Me.Txt部署ｶﾅ名.Size = New System.Drawing.Size(53, 19)
        Me.Txt部署ｶﾅ名.TabIndex = 4
        Me.Txt部署ｶﾅ名.Visible = False
        Me.Txt部署ｶﾅ名.エラー表示用項目名 = Nothing
        '
        'Txt部署コード
        '
        Me.Txt部署コード.BackColor = System.Drawing.SystemColors.Window
        Me.Txt部署コード.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt部署コード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Txt部署コード.Isクリア = True
        Me.Txt部署コード.Location = New System.Drawing.Point(304, 17)
        Me.Txt部署コード.Name = "Txt部署コード"
        Me.Txt部署コード.pAutoFocus = False
        Me.Txt部署コード.pAutoSelect = False
        Me.Txt部署コード.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.NumLetter
        Me.Txt部署コード.pClearText = Nothing
        Me.Txt部署コード.pClearValue = Nothing
        Me.Txt部署コード.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.Txt部署コード.pFromCtl = Nothing
        Me.Txt部署コード.pFromToErrText = Nothing
        Me.Txt部署コード.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.Txt部署コード.pID = ""
        Me.Txt部署コード.pMaxByte = 0
        Me.Txt部署コード.Size = New System.Drawing.Size(29, 19)
        Me.Txt部署コード.TabIndex = 2
        Me.Txt部署コード.Visible = False
        Me.Txt部署コード.エラー表示用項目名 = Nothing
        '
        'Txt部署名
        '
        Me.Txt部署名.BackColor = System.Drawing.SystemColors.Window
        Me.Txt部署名.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt部署名.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.Txt部署名.Isクリア = True
        Me.Txt部署名.Location = New System.Drawing.Point(143, 40)
        Me.Txt部署名.Name = "Txt部署名"
        Me.Txt部署名.pAutoFocus = False
        Me.Txt部署名.pAutoSelect = False
        Me.Txt部署名.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.Txt部署名.pClearText = Nothing
        Me.Txt部署名.pClearValue = Nothing
        Me.Txt部署名.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.Txt部署名.pFromCtl = Nothing
        Me.Txt部署名.pFromToErrText = Nothing
        Me.Txt部署名.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.Txt部署名.pID = ""
        Me.Txt部署名.pMaxByte = 20
        Me.Txt部署名.Size = New System.Drawing.Size(146, 19)
        Me.Txt部署名.TabIndex = 3
        Me.Txt部署名.エラー表示用項目名 = "クラス"
        '
        'Uc部署
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Grp部署)
        Me.Name = "Uc部署"
        Me.Size = New System.Drawing.Size(395, 115)
        Me.Grp部署.ResumeLayout(False)
        Me.Grp部署.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grp部署 As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl部署ID As usrLbl
    Friend WithEvents UsrLbl11 As usrLbl
    Friend WithEvents Txt部署ｶﾅ名 As usrTxt
    Friend WithEvents Txt部署名 As usrTxt
    Friend WithEvents Cmb許可パターン As usrCmb
    Friend WithEvents Lbl企業名 As usrLbl
    Friend WithEvents Cmb企業名 As usrCmb
    Friend WithEvents UsrLbl5 As usrLbl
    Friend WithEvents Txt電話番号 As usrTxt
    Friend WithEvents Txt部署コード As usrTxt

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg01999_入庫棚設定
    Inherits 入退室管理.CMdiChildDialog

    'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
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
        Me.UsrLbl1 = New 共通Windowsコントロール.usrLbl
        Me.txt連 = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl19 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl20 = New 共通Windowsコントロール.usrLbl
        Me.lbl列 = New 共通Windowsコントロール.usrLbl
        Me.txt段 = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl4 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl5 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl6 = New 共通Windowsコントロール.usrLbl
        Me.txtSEQ = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl
        Me.lblライン = New 共通Windowsコントロール.usrLbl
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Location = New System.Drawing.Point(12, 180)
        Me.btnF1.TabIndex = 100
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(133, 180)
        Me.btnF2.Size = New System.Drawing.Size(24, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(163, 180)
        Me.btnF3.Size = New System.Drawing.Size(24, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(193, 180)
        Me.btnF4.Size = New System.Drawing.Size(24, 58)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(223, 180)
        Me.btnF5.Size = New System.Drawing.Size(24, 58)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(253, 180)
        Me.btnF6.Size = New System.Drawing.Size(24, 58)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(282, 180)
        Me.btnF7.Size = New System.Drawing.Size(24, 58)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(314, 180)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.TabIndex = 101
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & " クリア"
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(345, 180)
        Me.btnF9.Size = New System.Drawing.Size(24, 58)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(386, 180)
        Me.btnF10.Size = New System.Drawing.Size(24, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(419, 180)
        Me.btnF11.Size = New System.Drawing.Size(24, 58)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(461, 180)
        Me.btnF12.TabIndex = 102
        Me.btnF12.Text = "F12" & Global.Microsoft.VisualBasic.ChrW(13) & " ｷｬﾝｾﾙ"
        '
        'UsrLbl1
        '
        Me.UsrLbl1.AutoSize = True
        Me.UsrLbl1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl1.Isクリア = False
        Me.UsrLbl1.Location = New System.Drawing.Point(227, 110)
        Me.UsrLbl1.Name = "UsrLbl1"
        Me.UsrLbl1.pClearValue = ""
        Me.UsrLbl1.pID = ""
        Me.UsrLbl1.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl1.TabIndex = 41
        Me.UsrLbl1.Text = "-"
        Me.UsrLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl1.エラー表示用項目名 = ""
        '
        'txt連
        '
        Me.txt連.BackColor = System.Drawing.SystemColors.Window
        Me.txt連.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt連.Isクリア = True
        Me.txt連.Location = New System.Drawing.Point(260, 107)
        Me.txt連.MaxLength = 2
        Me.txt連.Name = "txt連"
        Me.txt連.pAutoFocus = True
        Me.txt連.pAutoSelect = True
        Me.txt連.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt連.pClearText = ""
        Me.txt連.pClearValue = ""
        Me.txt連.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt連.pFromCtl = Nothing
        Me.txt連.pFromToErrText = ""
        Me.txt連.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt連.pID = ""
        Me.txt連.pMaxByte = 2
        Me.txt連.Size = New System.Drawing.Size(32, 26)
        Me.txt連.TabIndex = 1
        Me.txt連.エラー表示用項目名 = ""
        '
        'UsrLbl19
        '
        Me.UsrLbl19.AutoSize = True
        Me.UsrLbl19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl19.Isクリア = False
        Me.UsrLbl19.Location = New System.Drawing.Point(40, 70)
        Me.UsrLbl19.Name = "UsrLbl19"
        Me.UsrLbl19.pClearValue = ""
        Me.UsrLbl19.pID = ""
        Me.UsrLbl19.Size = New System.Drawing.Size(47, 19)
        Me.UsrLbl19.TabIndex = 79
        Me.UsrLbl19.Text = "SEQ"
        Me.UsrLbl19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl19.エラー表示用項目名 = ""
        '
        'UsrLbl20
        '
        Me.UsrLbl20.AutoSize = True
        Me.UsrLbl20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl20.Isクリア = False
        Me.UsrLbl20.Location = New System.Drawing.Point(175, 70)
        Me.UsrLbl20.Name = "UsrLbl20"
        Me.UsrLbl20.pClearValue = ""
        Me.UsrLbl20.pID = ""
        Me.UsrLbl20.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl20.TabIndex = 80
        Me.UsrLbl20.Text = "："
        Me.UsrLbl20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl20.エラー表示用項目名 = ""
        '
        'lbl列
        '
        Me.lbl列.AutoSize = True
        Me.lbl列.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl列.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl列.Isクリア = False
        Me.lbl列.Location = New System.Drawing.Point(201, 110)
        Me.lbl列.Name = "lbl列"
        Me.lbl列.pClearValue = ""
        Me.lbl列.pID = ""
        Me.lbl列.Size = New System.Drawing.Size(20, 19)
        Me.lbl列.TabIndex = 81
        Me.lbl列.Text = "9"
        Me.lbl列.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl列.エラー表示用項目名 = ""
        '
        'txt段
        '
        Me.txt段.BackColor = System.Drawing.SystemColors.Window
        Me.txt段.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt段.Isクリア = True
        Me.txt段.Location = New System.Drawing.Point(345, 107)
        Me.txt段.MaxLength = 2
        Me.txt段.Name = "txt段"
        Me.txt段.pAutoFocus = True
        Me.txt段.pAutoSelect = True
        Me.txt段.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt段.pClearText = ""
        Me.txt段.pClearValue = ""
        Me.txt段.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt段.pFromCtl = Nothing
        Me.txt段.pFromToErrText = ""
        Me.txt段.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt段.pID = ""
        Me.txt段.pMaxByte = 1
        Me.txt段.Size = New System.Drawing.Size(32, 26)
        Me.txt段.TabIndex = 103
        Me.txt段.エラー表示用項目名 = ""
        '
        'UsrLbl4
        '
        Me.UsrLbl4.AutoSize = True
        Me.UsrLbl4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl4.Isクリア = False
        Me.UsrLbl4.Location = New System.Drawing.Point(312, 110)
        Me.UsrLbl4.Name = "UsrLbl4"
        Me.UsrLbl4.pClearValue = ""
        Me.UsrLbl4.pID = ""
        Me.UsrLbl4.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl4.TabIndex = 104
        Me.UsrLbl4.Text = "-"
        Me.UsrLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl4.エラー表示用項目名 = ""
        '
        'UsrLbl5
        '
        Me.UsrLbl5.AutoSize = True
        Me.UsrLbl5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl5.Isクリア = False
        Me.UsrLbl5.Location = New System.Drawing.Point(175, 110)
        Me.UsrLbl5.Name = "UsrLbl5"
        Me.UsrLbl5.pClearValue = ""
        Me.UsrLbl5.pID = ""
        Me.UsrLbl5.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl5.TabIndex = 108
        Me.UsrLbl5.Text = "："
        Me.UsrLbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl5.エラー表示用項目名 = ""
        '
        'UsrLbl6
        '
        Me.UsrLbl6.AutoSize = True
        Me.UsrLbl6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl6.Isクリア = False
        Me.UsrLbl6.Location = New System.Drawing.Point(40, 110)
        Me.UsrLbl6.Name = "UsrLbl6"
        Me.UsrLbl6.pClearValue = ""
        Me.UsrLbl6.pID = ""
        Me.UsrLbl6.Size = New System.Drawing.Size(105, 19)
        Me.UsrLbl6.TabIndex = 107
        Me.UsrLbl6.Text = "入庫棚ロケ"
        Me.UsrLbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl6.エラー表示用項目名 = ""
        '
        'txtSEQ
        '
        Me.txtSEQ.BackColor = System.Drawing.SystemColors.Window
        Me.txtSEQ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtSEQ.Isクリア = True
        Me.txtSEQ.Location = New System.Drawing.Point(201, 67)
        Me.txtSEQ.MaxLength = 2
        Me.txtSEQ.Name = "txtSEQ"
        Me.txtSEQ.pAutoFocus = True
        Me.txtSEQ.pAutoSelect = True
        Me.txtSEQ.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txtSEQ.pClearText = ""
        Me.txtSEQ.pClearValue = ""
        Me.txtSEQ.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txtSEQ.pFromCtl = Nothing
        Me.txtSEQ.pFromToErrText = ""
        Me.txtSEQ.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txtSEQ.pID = ""
        Me.txtSEQ.pMaxByte = 3
        Me.txtSEQ.Size = New System.Drawing.Size(46, 26)
        Me.txtSEQ.TabIndex = 109
        Me.txtSEQ.エラー表示用項目名 = ""
        '
        'UsrLbl2
        '
        Me.UsrLbl2.AutoSize = True
        Me.UsrLbl2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl2.Isクリア = False
        Me.UsrLbl2.Location = New System.Drawing.Point(40, 35)
        Me.UsrLbl2.Name = "UsrLbl2"
        Me.UsrLbl2.pClearValue = ""
        Me.UsrLbl2.pID = ""
        Me.UsrLbl2.Size = New System.Drawing.Size(58, 19)
        Me.UsrLbl2.TabIndex = 110
        Me.UsrLbl2.Text = "ライン"
        Me.UsrLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl2.エラー表示用項目名 = ""
        '
        'UsrLbl3
        '
        Me.UsrLbl3.AutoSize = True
        Me.UsrLbl3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl3.Isクリア = False
        Me.UsrLbl3.Location = New System.Drawing.Point(175, 35)
        Me.UsrLbl3.Name = "UsrLbl3"
        Me.UsrLbl3.pClearValue = ""
        Me.UsrLbl3.pID = ""
        Me.UsrLbl3.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl3.TabIndex = 111
        Me.UsrLbl3.Text = "："
        Me.UsrLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl3.エラー表示用項目名 = ""
        '
        'lblライン
        '
        Me.lblライン.AutoSize = True
        Me.lblライン.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblライン.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblライン.Isクリア = False
        Me.lblライン.Location = New System.Drawing.Point(201, 35)
        Me.lblライン.Name = "lblライン"
        Me.lblライン.pClearValue = ""
        Me.lblライン.pID = ""
        Me.lblライン.Size = New System.Drawing.Size(100, 19)
        Me.lblライン.TabIndex = 112
        Me.lblライン.Text = "NNNNNNN"
        Me.lblライン.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblライン.エラー表示用項目名 = ""
        '
        'Dlg01999_入庫棚設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(600, 253)
        Me.Controls.Add(Me.lblライン)
        Me.Controls.Add(Me.UsrLbl3)
        Me.Controls.Add(Me.UsrLbl2)
        Me.Controls.Add(Me.txtSEQ)
        Me.Controls.Add(Me.UsrLbl5)
        Me.Controls.Add(Me.UsrLbl6)
        Me.Controls.Add(Me.txt段)
        Me.Controls.Add(Me.UsrLbl4)
        Me.Controls.Add(Me.lbl列)
        Me.Controls.Add(Me.UsrLbl20)
        Me.Controls.Add(Me.UsrLbl19)
        Me.Controls.Add(Me.txt連)
        Me.Controls.Add(Me.UsrLbl1)
        Me.Name = "Dlg01999_入庫棚設定"
        Me.Text = "入庫登録"
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl1, 0)
        Me.Controls.SetChildIndex(Me.txt連, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl19, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl20, 0)
        Me.Controls.SetChildIndex(Me.lbl列, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl4, 0)
        Me.Controls.SetChildIndex(Me.txt段, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl6, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl5, 0)
        Me.Controls.SetChildIndex(Me.txtSEQ, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl2, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl3, 0)
        Me.Controls.SetChildIndex(Me.lblライン, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UsrLbl1 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt連 As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl19 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl20 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl列 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt段 As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl4 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl5 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl6 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txtSEQ As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl2 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lblライン As 共通Windowsコントロール.usrLbl

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg01999_棚メンテナンス禁止棚
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
        Me.UsrLbl4 = New 共通Windowsコントロール.usrLbl
        Me.txt段 = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl6 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl5 = New 共通Windowsコントロール.usrLbl
        Me.lbl棚区分 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl12 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl14 = New 共通Windowsコントロール.usrLbl
        Me.txt列 = New 共通Windowsコントロール.usrTxt
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Location = New System.Drawing.Point(12, 140)
        Me.btnF1.TabIndex = 100
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(133, 140)
        Me.btnF2.Size = New System.Drawing.Size(24, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(163, 140)
        Me.btnF3.Size = New System.Drawing.Size(24, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(193, 140)
        Me.btnF4.Size = New System.Drawing.Size(24, 58)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(223, 140)
        Me.btnF5.Size = New System.Drawing.Size(24, 58)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(253, 140)
        Me.btnF6.Size = New System.Drawing.Size(24, 58)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(282, 140)
        Me.btnF7.Size = New System.Drawing.Size(24, 58)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(314, 140)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.TabIndex = 101
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & " クリア"
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(345, 140)
        Me.btnF9.Size = New System.Drawing.Size(24, 58)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(386, 140)
        Me.btnF10.Size = New System.Drawing.Size(24, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(419, 140)
        Me.btnF11.Size = New System.Drawing.Size(24, 58)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(461, 140)
        Me.btnF12.TabIndex = 102
        Me.btnF12.Text = "F12" & Global.Microsoft.VisualBasic.ChrW(13) & " ｷｬﾝｾﾙ"
        '
        'UsrLbl1
        '
        Me.UsrLbl1.AutoSize = True
        Me.UsrLbl1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl1.Isクリア = False
        Me.UsrLbl1.Location = New System.Drawing.Point(235, 35)
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
        Me.txt連.Location = New System.Drawing.Point(258, 32)
        Me.txt連.MaxLength = 2
        Me.txt連.Name = "txt連"
        Me.txt連.pAutoFocus = True
        Me.txt連.pAutoPad = False
        Me.txt連.pAutoSelect = True
        Me.txt連.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.Numonly
        Me.txt連.pClearText = ""
        Me.txt連.pClearValue = ""
        Me.txt連.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt連.pFromCtl = Nothing
        Me.txt連.pFromToErrText = ""
        Me.txt連.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt連.pID = ""
        Me.txt連.pMaxByte = 2
        Me.txt連.pPadWord = ""
        Me.txt連.Size = New System.Drawing.Size(32, 26)
        Me.txt連.TabIndex = 2
        Me.txt連.エラー表示用項目名 = ""
        '
        'UsrLbl4
        '
        Me.UsrLbl4.AutoSize = True
        Me.UsrLbl4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl4.Isクリア = False
        Me.UsrLbl4.Location = New System.Drawing.Point(294, 35)
        Me.UsrLbl4.Name = "UsrLbl4"
        Me.UsrLbl4.pClearValue = ""
        Me.UsrLbl4.pID = ""
        Me.UsrLbl4.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl4.TabIndex = 104
        Me.UsrLbl4.Text = "-"
        Me.UsrLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl4.エラー表示用項目名 = ""
        '
        'txt段
        '
        Me.txt段.BackColor = System.Drawing.SystemColors.Window
        Me.txt段.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt段.Isクリア = True
        Me.txt段.Location = New System.Drawing.Point(317, 32)
        Me.txt段.MaxLength = 1
        Me.txt段.Name = "txt段"
        Me.txt段.pAutoFocus = True
        Me.txt段.pAutoPad = False
        Me.txt段.pAutoSelect = True
        Me.txt段.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.Numonly
        Me.txt段.pClearText = ""
        Me.txt段.pClearValue = ""
        Me.txt段.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt段.pFromCtl = Nothing
        Me.txt段.pFromToErrText = ""
        Me.txt段.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt段.pID = ""
        Me.txt段.pMaxByte = 1
        Me.txt段.pPadWord = ""
        Me.txt段.Size = New System.Drawing.Size(32, 26)
        Me.txt段.TabIndex = 3
        Me.txt段.エラー表示用項目名 = ""
        '
        'UsrLbl6
        '
        Me.UsrLbl6.AutoSize = True
        Me.UsrLbl6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl6.Isクリア = False
        Me.UsrLbl6.Location = New System.Drawing.Point(40, 35)
        Me.UsrLbl6.Name = "UsrLbl6"
        Me.UsrLbl6.pClearValue = ""
        Me.UsrLbl6.pID = ""
        Me.UsrLbl6.Size = New System.Drawing.Size(105, 19)
        Me.UsrLbl6.TabIndex = 107
        Me.UsrLbl6.Text = "入庫棚ロケ"
        Me.UsrLbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl6.エラー表示用項目名 = ""
        '
        'UsrLbl5
        '
        Me.UsrLbl5.AutoSize = True
        Me.UsrLbl5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl5.Isクリア = False
        Me.UsrLbl5.Location = New System.Drawing.Point(175, 35)
        Me.UsrLbl5.Name = "UsrLbl5"
        Me.UsrLbl5.pClearValue = ""
        Me.UsrLbl5.pID = ""
        Me.UsrLbl5.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl5.TabIndex = 108
        Me.UsrLbl5.Text = "："
        Me.UsrLbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl5.エラー表示用項目名 = ""
        '
        'lbl棚区分
        '
        Me.lbl棚区分.AutoSize = True
        Me.lbl棚区分.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl棚区分.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl棚区分.Isクリア = False
        Me.lbl棚区分.Location = New System.Drawing.Point(201, 71)
        Me.lbl棚区分.Name = "lbl棚区分"
        Me.lbl棚区分.pClearValue = ""
        Me.lbl棚区分.pID = ""
        Me.lbl棚区分.Size = New System.Drawing.Size(0, 19)
        Me.lbl棚区分.TabIndex = 131
        Me.lbl棚区分.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl棚区分.エラー表示用項目名 = ""
        '
        'UsrLbl12
        '
        Me.UsrLbl12.AutoSize = True
        Me.UsrLbl12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl12.Isクリア = False
        Me.UsrLbl12.Location = New System.Drawing.Point(175, 71)
        Me.UsrLbl12.Name = "UsrLbl12"
        Me.UsrLbl12.pClearValue = ""
        Me.UsrLbl12.pID = ""
        Me.UsrLbl12.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl12.TabIndex = 127
        Me.UsrLbl12.Text = "："
        Me.UsrLbl12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl12.エラー表示用項目名 = ""
        '
        'UsrLbl14
        '
        Me.UsrLbl14.AutoSize = True
        Me.UsrLbl14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl14.Isクリア = False
        Me.UsrLbl14.Location = New System.Drawing.Point(40, 71)
        Me.UsrLbl14.Name = "UsrLbl14"
        Me.UsrLbl14.pClearValue = ""
        Me.UsrLbl14.pID = ""
        Me.UsrLbl14.Size = New System.Drawing.Size(69, 19)
        Me.UsrLbl14.TabIndex = 123
        Me.UsrLbl14.Text = "棚区分"
        Me.UsrLbl14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl14.エラー表示用項目名 = ""
        '
        'txt列
        '
        Me.txt列.BackColor = System.Drawing.SystemColors.Window
        Me.txt列.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt列.Isクリア = True
        Me.txt列.Location = New System.Drawing.Point(201, 32)
        Me.txt列.MaxLength = 1
        Me.txt列.Name = "txt列"
        Me.txt列.pAutoFocus = True
        Me.txt列.pAutoPad = False
        Me.txt列.pAutoSelect = True
        Me.txt列.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.Numonly
        Me.txt列.pClearText = ""
        Me.txt列.pClearValue = ""
        Me.txt列.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt列.pFromCtl = Nothing
        Me.txt列.pFromToErrText = ""
        Me.txt列.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt列.pID = ""
        Me.txt列.pMaxByte = 1
        Me.txt列.pPadWord = ""
        Me.txt列.Size = New System.Drawing.Size(32, 26)
        Me.txt列.TabIndex = 1
        Me.txt列.エラー表示用項目名 = ""
        '
        'Dlg01999_棚メンテナンス禁止棚
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(600, 210)
        Me.Controls.Add(Me.txt列)
        Me.Controls.Add(Me.lbl棚区分)
        Me.Controls.Add(Me.UsrLbl12)
        Me.Controls.Add(Me.UsrLbl14)
        Me.Controls.Add(Me.UsrLbl1)
        Me.Controls.Add(Me.txt連)
        Me.Controls.Add(Me.UsrLbl4)
        Me.Controls.Add(Me.txt段)
        Me.Controls.Add(Me.UsrLbl6)
        Me.Controls.Add(Me.UsrLbl5)
        Me.Name = "Dlg01999_棚メンテナンス禁止棚"
        Me.Text = "禁止棚設定"
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl5, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl6, 0)
        Me.Controls.SetChildIndex(Me.txt段, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl4, 0)
        Me.Controls.SetChildIndex(Me.txt連, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl1, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl14, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl12, 0)
        Me.Controls.SetChildIndex(Me.lbl棚区分, 0)
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.txt列, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UsrLbl1 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt連 As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl4 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt段 As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl6 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl5 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl棚区分 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl12 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl14 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt列 As 共通Windowsコントロール.usrTxt

End Class

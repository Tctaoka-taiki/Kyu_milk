<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg01023_温度
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
        Me.lbl品種 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl12 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl1 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl20 = New 共通Windowsコントロール.usrLbl
        Me.txt指定日 = New 共通Windowsコントロール.usrTxt
        Me.txt指定月 = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl15 = New 共通Windowsコントロール.usrLbl
        Me.txt指定年 = New 共通Windowsコントロール.usrTxt
        Me.lbl賞味期限 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl10 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl
        Me.cmb設備名称 = New 共通Windowsコントロール.usrCmb
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Location = New System.Drawing.Point(12, 141)
        Me.btnF1.TabIndex = 100
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "決定"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(133, 141)
        Me.btnF2.Size = New System.Drawing.Size(24, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(163, 141)
        Me.btnF3.Size = New System.Drawing.Size(24, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(193, 141)
        Me.btnF4.Size = New System.Drawing.Size(24, 58)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(223, 141)
        Me.btnF5.Size = New System.Drawing.Size(24, 58)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(253, 141)
        Me.btnF6.Size = New System.Drawing.Size(24, 58)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(282, 141)
        Me.btnF7.Size = New System.Drawing.Size(24, 58)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(314, 141)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.TabIndex = 101
        Me.btnF8.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(345, 141)
        Me.btnF9.Size = New System.Drawing.Size(24, 58)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(386, 141)
        Me.btnF10.Size = New System.Drawing.Size(24, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(419, 141)
        Me.btnF11.Size = New System.Drawing.Size(24, 58)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(520, 141)
        Me.btnF12.TabIndex = 102
        Me.btnF12.Text = "F12" & Global.Microsoft.VisualBasic.ChrW(13) & " ｷｬﾝｾﾙ"
        '
        'lbl品種
        '
        Me.lbl品種.AutoSize = True
        Me.lbl品種.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl品種.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl品種.Isクリア = False
        Me.lbl品種.Location = New System.Drawing.Point(239, 35)
        Me.lbl品種.Name = "lbl品種"
        Me.lbl品種.pClearValue = ""
        Me.lbl品種.pID = ""
        Me.lbl品種.Size = New System.Drawing.Size(0, 19)
        Me.lbl品種.TabIndex = 53
        Me.lbl品種.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl品種.エラー表示用項目名 = ""
        '
        'UsrLbl12
        '
        Me.UsrLbl12.AutoSize = True
        Me.UsrLbl12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl12.Isクリア = False
        Me.UsrLbl12.Location = New System.Drawing.Point(175, 35)
        Me.UsrLbl12.Name = "UsrLbl12"
        Me.UsrLbl12.pClearValue = ""
        Me.UsrLbl12.pID = ""
        Me.UsrLbl12.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl12.TabIndex = 47
        Me.UsrLbl12.Text = "："
        Me.UsrLbl12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl12.エラー表示用項目名 = ""
        '
        'UsrLbl1
        '
        Me.UsrLbl1.AutoSize = True
        Me.UsrLbl1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl1.Isクリア = False
        Me.UsrLbl1.Location = New System.Drawing.Point(40, 35)
        Me.UsrLbl1.Name = "UsrLbl1"
        Me.UsrLbl1.pClearValue = ""
        Me.UsrLbl1.pID = ""
        Me.UsrLbl1.Size = New System.Drawing.Size(89, 19)
        Me.UsrLbl1.TabIndex = 41
        Me.UsrLbl1.Text = "設備名称"
        Me.UsrLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl1.エラー表示用項目名 = ""
        '
        'UsrLbl20
        '
        Me.UsrLbl20.AutoSize = True
        Me.UsrLbl20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl20.Isクリア = False
        Me.UsrLbl20.Location = New System.Drawing.Point(175, 35)
        Me.UsrLbl20.Name = "UsrLbl20"
        Me.UsrLbl20.pClearValue = ""
        Me.UsrLbl20.pID = ""
        Me.UsrLbl20.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl20.TabIndex = 80
        Me.UsrLbl20.Text = "："
        Me.UsrLbl20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl20.エラー表示用項目名 = ""
        '
        'txt指定日
        '
        Me.txt指定日.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定日.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定日.Isクリア = True
        Me.txt指定日.Location = New System.Drawing.Point(346, 67)
        Me.txt指定日.MaxLength = 2
        Me.txt指定日.Name = "txt指定日"
        Me.txt指定日.pAutoFocus = True
        Me.txt指定日.pAutoPad = False
        Me.txt指定日.pAutoSelect = True
        Me.txt指定日.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定日.pClearText = ""
        Me.txt指定日.pClearValue = ""
        Me.txt指定日.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定日.pFromCtl = Nothing
        Me.txt指定日.pFromToErrText = ""
        Me.txt指定日.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定日.pID = ""
        Me.txt指定日.pMaxByte = 2
        Me.txt指定日.pPadWord = "0"
        Me.txt指定日.Size = New System.Drawing.Size(40, 26)
        Me.txt指定日.TabIndex = 4
        Me.txt指定日.エラー表示用項目名 = ""
        '
        'txt指定月
        '
        Me.txt指定月.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定月.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定月.Isクリア = True
        Me.txt指定月.Location = New System.Drawing.Point(282, 67)
        Me.txt指定月.MaxLength = 2
        Me.txt指定月.Name = "txt指定月"
        Me.txt指定月.pAutoFocus = True
        Me.txt指定月.pAutoPad = False
        Me.txt指定月.pAutoSelect = True
        Me.txt指定月.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定月.pClearText = ""
        Me.txt指定月.pClearValue = ""
        Me.txt指定月.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定月.pFromCtl = Nothing
        Me.txt指定月.pFromToErrText = ""
        Me.txt指定月.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定月.pID = ""
        Me.txt指定月.pMaxByte = 2
        Me.txt指定月.pPadWord = "0"
        Me.txt指定月.Size = New System.Drawing.Size(40, 26)
        Me.txt指定月.TabIndex = 3
        Me.txt指定月.エラー表示用項目名 = ""
        '
        'UsrLbl15
        '
        Me.UsrLbl15.AutoSize = True
        Me.UsrLbl15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl15.Isクリア = False
        Me.UsrLbl15.Location = New System.Drawing.Point(324, 70)
        Me.UsrLbl15.Name = "UsrLbl15"
        Me.UsrLbl15.pClearValue = ""
        Me.UsrLbl15.pID = ""
        Me.UsrLbl15.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl15.TabIndex = 109
        Me.UsrLbl15.Text = "/"
        Me.UsrLbl15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl15.エラー表示用項目名 = ""
        '
        'txt指定年
        '
        Me.txt指定年.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定年.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定年.Isクリア = True
        Me.txt指定年.Location = New System.Drawing.Point(201, 67)
        Me.txt指定年.MaxLength = 4
        Me.txt指定年.Name = "txt指定年"
        Me.txt指定年.pAutoFocus = True
        Me.txt指定年.pAutoPad = False
        Me.txt指定年.pAutoSelect = True
        Me.txt指定年.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定年.pClearText = ""
        Me.txt指定年.pClearValue = ""
        Me.txt指定年.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定年.pFromCtl = Nothing
        Me.txt指定年.pFromToErrText = ""
        Me.txt指定年.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定年.pID = ""
        Me.txt指定年.pMaxByte = 4
        Me.txt指定年.pPadWord = "0"
        Me.txt指定年.Size = New System.Drawing.Size(59, 26)
        Me.txt指定年.TabIndex = 2
        Me.txt指定年.エラー表示用項目名 = ""
        '
        'lbl賞味期限
        '
        Me.lbl賞味期限.AutoSize = True
        Me.lbl賞味期限.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl賞味期限.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl賞味期限.Isクリア = False
        Me.lbl賞味期限.Location = New System.Drawing.Point(261, 70)
        Me.lbl賞味期限.Name = "lbl賞味期限"
        Me.lbl賞味期限.pClearValue = ""
        Me.lbl賞味期限.pID = ""
        Me.lbl賞味期限.Size = New System.Drawing.Size(20, 19)
        Me.lbl賞味期限.TabIndex = 108
        Me.lbl賞味期限.Text = "/"
        Me.lbl賞味期限.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl賞味期限.エラー表示用項目名 = ""
        '
        'UsrLbl10
        '
        Me.UsrLbl10.AutoSize = True
        Me.UsrLbl10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl10.Isクリア = False
        Me.UsrLbl10.Location = New System.Drawing.Point(175, 70)
        Me.UsrLbl10.Name = "UsrLbl10"
        Me.UsrLbl10.pClearValue = ""
        Me.UsrLbl10.pID = ""
        Me.UsrLbl10.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl10.TabIndex = 107
        Me.UsrLbl10.Text = "："
        Me.UsrLbl10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl10.エラー表示用項目名 = ""
        '
        'UsrLbl3
        '
        Me.UsrLbl3.AutoSize = True
        Me.UsrLbl3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl3.Isクリア = False
        Me.UsrLbl3.Location = New System.Drawing.Point(40, 70)
        Me.UsrLbl3.Name = "UsrLbl3"
        Me.UsrLbl3.pClearValue = ""
        Me.UsrLbl3.pID = ""
        Me.UsrLbl3.Size = New System.Drawing.Size(69, 19)
        Me.UsrLbl3.TabIndex = 106
        Me.UsrLbl3.Text = "指定日"
        Me.UsrLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl3.エラー表示用項目名 = ""
        '
        'cmb設備名称
        '
        Me.cmb設備名称.BackColor = System.Drawing.SystemColors.Window
        Me.cmb設備名称.DropDownWidth = 242
        Me.cmb設備名称.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.cmb設備名称.FormattingEnabled = True
        Me.cmb設備名称.Isクリア = True
        Me.cmb設備名称.Items.AddRange(New Object() {"醗酵倉庫", "冷却倉庫", "急冷室"})
        Me.cmb設備名称.Location = New System.Drawing.Point(201, 32)
        Me.cmb設備名称.Name = "cmb設備名称"
        Me.cmb設備名称.pAutoFocus = True
        Me.cmb設備名称.pAutoSelect = True
        Me.cmb設備名称.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.cmb設備名称.pClearIndex = -1
        Me.cmb設備名称.pClearValue = ""
        Me.cmb設備名称.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.cmb設備名称.pFromCtl = Nothing
        Me.cmb設備名称.pFromToErrText = ""
        Me.cmb設備名称.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.cmb設備名称.pID = ""
        Me.cmb設備名称.pMaxByte = 0
        Me.cmb設備名称.Size = New System.Drawing.Size(242, 27)
        Me.cmb設備名称.TabIndex = 1
        Me.cmb設備名称.エラー表示用項目名 = ""
        '
        'Dlg01023_温度
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(647, 215)
        Me.Controls.Add(Me.cmb設備名称)
        Me.Controls.Add(Me.UsrLbl20)
        Me.Controls.Add(Me.lbl品種)
        Me.Controls.Add(Me.UsrLbl12)
        Me.Controls.Add(Me.UsrLbl1)
        Me.Controls.Add(Me.txt指定日)
        Me.Controls.Add(Me.txt指定月)
        Me.Controls.Add(Me.UsrLbl15)
        Me.Controls.Add(Me.txt指定年)
        Me.Controls.Add(Me.lbl賞味期限)
        Me.Controls.Add(Me.UsrLbl10)
        Me.Controls.Add(Me.UsrLbl3)
        Me.Name = "Dlg01023_温度"
        Me.Text = "温度問合せ設定"
        Me.Controls.SetChildIndex(Me.UsrLbl3, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl10, 0)
        Me.Controls.SetChildIndex(Me.lbl賞味期限, 0)
        Me.Controls.SetChildIndex(Me.txt指定年, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl15, 0)
        Me.Controls.SetChildIndex(Me.txt指定月, 0)
        Me.Controls.SetChildIndex(Me.txt指定日, 0)
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
        Me.Controls.SetChildIndex(Me.UsrLbl12, 0)
        Me.Controls.SetChildIndex(Me.lbl品種, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl20, 0)
        Me.Controls.SetChildIndex(Me.cmb設備名称, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl品種 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl12 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl1 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl20 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt指定日 As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt指定月 As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl15 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt指定年 As 共通Windowsコントロール.usrTxt
    Friend WithEvents lbl賞味期限 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl10 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents cmb設備名称 As 共通Windowsコントロール.usrCmb

End Class

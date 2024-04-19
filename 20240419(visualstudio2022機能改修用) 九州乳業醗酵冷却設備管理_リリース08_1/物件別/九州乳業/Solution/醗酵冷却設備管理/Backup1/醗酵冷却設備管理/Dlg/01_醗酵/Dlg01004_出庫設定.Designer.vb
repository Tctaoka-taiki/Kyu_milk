<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg01004_出庫設定
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
        Me.UsrLbl19 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl20 = New 共通Windowsコントロール.usrLbl
        Me.txtサンプルNo = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl
        Me.txtロットNo = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl1 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl4 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl5 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl6 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl7 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl8 = New 共通Windowsコントロール.usrLbl
        Me.lbl品種名 = New 共通Windowsコントロール.usrLbl
        Me.lbl所定醗酵時間 = New 共通Windowsコントロール.usrLbl
        Me.lbl醗酵経過時間 = New 共通Windowsコントロール.usrLbl
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Location = New System.Drawing.Point(12, 235)
        Me.btnF1.TabIndex = 100
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(133, 235)
        Me.btnF2.Size = New System.Drawing.Size(24, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(163, 235)
        Me.btnF3.Size = New System.Drawing.Size(24, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(193, 235)
        Me.btnF4.Size = New System.Drawing.Size(24, 58)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(223, 235)
        Me.btnF5.Size = New System.Drawing.Size(24, 58)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(253, 235)
        Me.btnF6.Size = New System.Drawing.Size(24, 58)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(282, 235)
        Me.btnF7.Size = New System.Drawing.Size(24, 58)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(314, 235)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.TabIndex = 101
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & " クリア"
        Me.btnF8.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(345, 235)
        Me.btnF9.Size = New System.Drawing.Size(24, 58)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(386, 235)
        Me.btnF10.Size = New System.Drawing.Size(24, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(419, 235)
        Me.btnF11.Size = New System.Drawing.Size(24, 58)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(461, 235)
        Me.btnF12.TabIndex = 102
        Me.btnF12.Text = "F12" & Global.Microsoft.VisualBasic.ChrW(13) & " ｷｬﾝｾﾙ"
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
        Me.UsrLbl19.Size = New System.Drawing.Size(107, 19)
        Me.UsrLbl19.TabIndex = 79
        Me.UsrLbl19.Text = "サンプルNo"
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
        'txtサンプルNo
        '
        Me.txtサンプルNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtサンプルNo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtサンプルNo.Isクリア = True
        Me.txtサンプルNo.Location = New System.Drawing.Point(201, 67)
        Me.txtサンプルNo.MaxLength = 2
        Me.txtサンプルNo.Name = "txtサンプルNo"
        Me.txtサンプルNo.pAutoFocus = True
        Me.txtサンプルNo.pAutoPad = False
        Me.txtサンプルNo.pAutoSelect = True
        Me.txtサンプルNo.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txtサンプルNo.pClearText = ""
        Me.txtサンプルNo.pClearValue = ""
        Me.txtサンプルNo.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txtサンプルNo.pFromCtl = Nothing
        Me.txtサンプルNo.pFromToErrText = ""
        Me.txtサンプルNo.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txtサンプルNo.pID = ""
        Me.txtサンプルNo.pMaxByte = 3
        Me.txtサンプルNo.pPadWord = ""
        Me.txtサンプルNo.Size = New System.Drawing.Size(46, 26)
        Me.txtサンプルNo.TabIndex = 2
        Me.txtサンプルNo.エラー表示用項目名 = ""
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
        Me.UsrLbl2.Size = New System.Drawing.Size(78, 19)
        Me.UsrLbl2.TabIndex = 110
        Me.UsrLbl2.Text = "ロットNo"
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
        'txtロットNo
        '
        Me.txtロットNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtロットNo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtロットNo.Isクリア = True
        Me.txtロットNo.Location = New System.Drawing.Point(201, 35)
        Me.txtロットNo.MaxLength = 6
        Me.txtロットNo.Name = "txtロットNo"
        Me.txtロットNo.pAutoFocus = True
        Me.txtロットNo.pAutoPad = False
        Me.txtロットNo.pAutoSelect = True
        Me.txtロットNo.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txtロットNo.pClearText = ""
        Me.txtロットNo.pClearValue = ""
        Me.txtロットNo.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txtロットNo.pFromCtl = Nothing
        Me.txtロットNo.pFromToErrText = ""
        Me.txtロットNo.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txtロットNo.pID = ""
        Me.txtロットNo.pMaxByte = 6
        Me.txtロットNo.pPadWord = ""
        Me.txtロットNo.Size = New System.Drawing.Size(91, 26)
        Me.txtロットNo.TabIndex = 1
        Me.txtロットNo.エラー表示用項目名 = ""
        '
        'UsrLbl1
        '
        Me.UsrLbl1.AutoSize = True
        Me.UsrLbl1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl1.Isクリア = False
        Me.UsrLbl1.Location = New System.Drawing.Point(175, 105)
        Me.UsrLbl1.Name = "UsrLbl1"
        Me.UsrLbl1.pClearValue = ""
        Me.UsrLbl1.pID = ""
        Me.UsrLbl1.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl1.TabIndex = 113
        Me.UsrLbl1.Text = "："
        Me.UsrLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl1.エラー表示用項目名 = ""
        '
        'UsrLbl4
        '
        Me.UsrLbl4.AutoSize = True
        Me.UsrLbl4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl4.Isクリア = False
        Me.UsrLbl4.Location = New System.Drawing.Point(40, 105)
        Me.UsrLbl4.Name = "UsrLbl4"
        Me.UsrLbl4.pClearValue = ""
        Me.UsrLbl4.pID = ""
        Me.UsrLbl4.Size = New System.Drawing.Size(69, 19)
        Me.UsrLbl4.TabIndex = 112
        Me.UsrLbl4.Text = "品種名"
        Me.UsrLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl4.エラー表示用項目名 = ""
        '
        'UsrLbl5
        '
        Me.UsrLbl5.AutoSize = True
        Me.UsrLbl5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl5.Isクリア = False
        Me.UsrLbl5.Location = New System.Drawing.Point(175, 140)
        Me.UsrLbl5.Name = "UsrLbl5"
        Me.UsrLbl5.pClearValue = ""
        Me.UsrLbl5.pID = ""
        Me.UsrLbl5.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl5.TabIndex = 115
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
        Me.UsrLbl6.Location = New System.Drawing.Point(40, 140)
        Me.UsrLbl6.Name = "UsrLbl6"
        Me.UsrLbl6.pClearValue = ""
        Me.UsrLbl6.pID = ""
        Me.UsrLbl6.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl6.TabIndex = 114
        Me.UsrLbl6.Text = "所定醗酵時間"
        Me.UsrLbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl6.エラー表示用項目名 = ""
        '
        'UsrLbl7
        '
        Me.UsrLbl7.AutoSize = True
        Me.UsrLbl7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl7.Isクリア = False
        Me.UsrLbl7.Location = New System.Drawing.Point(175, 175)
        Me.UsrLbl7.Name = "UsrLbl7"
        Me.UsrLbl7.pClearValue = ""
        Me.UsrLbl7.pID = ""
        Me.UsrLbl7.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl7.TabIndex = 117
        Me.UsrLbl7.Text = "："
        Me.UsrLbl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl7.エラー表示用項目名 = ""
        '
        'UsrLbl8
        '
        Me.UsrLbl8.AutoSize = True
        Me.UsrLbl8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl8.Isクリア = False
        Me.UsrLbl8.Location = New System.Drawing.Point(40, 175)
        Me.UsrLbl8.Name = "UsrLbl8"
        Me.UsrLbl8.pClearValue = ""
        Me.UsrLbl8.pID = ""
        Me.UsrLbl8.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl8.TabIndex = 116
        Me.UsrLbl8.Text = "醗酵経過時間"
        Me.UsrLbl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl8.エラー表示用項目名 = ""
        '
        'lbl品種名
        '
        Me.lbl品種名.AutoSize = True
        Me.lbl品種名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl品種名.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl品種名.Isクリア = False
        Me.lbl品種名.Location = New System.Drawing.Point(201, 105)
        Me.lbl品種名.Name = "lbl品種名"
        Me.lbl品種名.pClearValue = ""
        Me.lbl品種名.pID = ""
        Me.lbl品種名.Size = New System.Drawing.Size(0, 19)
        Me.lbl品種名.TabIndex = 118
        Me.lbl品種名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl品種名.エラー表示用項目名 = ""
        '
        'lbl所定醗酵時間
        '
        Me.lbl所定醗酵時間.AutoSize = True
        Me.lbl所定醗酵時間.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl所定醗酵時間.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl所定醗酵時間.Isクリア = False
        Me.lbl所定醗酵時間.Location = New System.Drawing.Point(201, 140)
        Me.lbl所定醗酵時間.Name = "lbl所定醗酵時間"
        Me.lbl所定醗酵時間.pClearValue = ""
        Me.lbl所定醗酵時間.pID = ""
        Me.lbl所定醗酵時間.Size = New System.Drawing.Size(0, 19)
        Me.lbl所定醗酵時間.TabIndex = 119
        Me.lbl所定醗酵時間.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl所定醗酵時間.エラー表示用項目名 = ""
        '
        'lbl醗酵経過時間
        '
        Me.lbl醗酵経過時間.AutoSize = True
        Me.lbl醗酵経過時間.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl醗酵経過時間.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl醗酵経過時間.Isクリア = False
        Me.lbl醗酵経過時間.Location = New System.Drawing.Point(201, 175)
        Me.lbl醗酵経過時間.Name = "lbl醗酵経過時間"
        Me.lbl醗酵経過時間.pClearValue = ""
        Me.lbl醗酵経過時間.pID = ""
        Me.lbl醗酵経過時間.Size = New System.Drawing.Size(0, 19)
        Me.lbl醗酵経過時間.TabIndex = 120
        Me.lbl醗酵経過時間.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl醗酵経過時間.エラー表示用項目名 = ""
        '
        'Dlg01004_出庫設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(600, 305)
        Me.Controls.Add(Me.lbl醗酵経過時間)
        Me.Controls.Add(Me.lbl所定醗酵時間)
        Me.Controls.Add(Me.lbl品種名)
        Me.Controls.Add(Me.UsrLbl7)
        Me.Controls.Add(Me.UsrLbl8)
        Me.Controls.Add(Me.UsrLbl5)
        Me.Controls.Add(Me.UsrLbl6)
        Me.Controls.Add(Me.UsrLbl1)
        Me.Controls.Add(Me.UsrLbl4)
        Me.Controls.Add(Me.UsrLbl3)
        Me.Controls.Add(Me.UsrLbl2)
        Me.Controls.Add(Me.txtサンプルNo)
        Me.Controls.Add(Me.UsrLbl20)
        Me.Controls.Add(Me.UsrLbl19)
        Me.Controls.Add(Me.txtロットNo)
        Me.Name = "Dlg01004_出庫設定"
        Me.Text = "出庫開始"
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.txtロットNo, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl19, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl20, 0)
        Me.Controls.SetChildIndex(Me.txtサンプルNo, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl2, 0)
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl3, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl4, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl1, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl6, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl5, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl8, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl7, 0)
        Me.Controls.SetChildIndex(Me.lbl品種名, 0)
        Me.Controls.SetChildIndex(Me.lbl所定醗酵時間, 0)
        Me.Controls.SetChildIndex(Me.lbl醗酵経過時間, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UsrLbl19 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl20 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txtサンプルNo As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl2 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txtロットNo As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl1 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl4 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl5 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl6 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl7 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl8 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl品種名 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl所定醗酵時間 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl醗酵経過時間 As 共通Windowsコントロール.usrLbl

End Class

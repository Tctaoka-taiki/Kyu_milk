<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg01999_冷却出庫設定
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
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl
        Me.txtロットNo = New 共通Windowsコントロール.usrTxt
        Me.lbl醗酵経過時間 = New 共通Windowsコントロール.usrLbl
        Me.lbl所定醗酵時間 = New 共通Windowsコントロール.usrLbl
        Me.lbl品種名 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl7 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl8 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl5 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl6 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl1 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl4 = New 共通Windowsコントロール.usrLbl
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Location = New System.Drawing.Point(12, 211)
        Me.btnF1.TabIndex = 100
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(133, 211)
        Me.btnF2.Size = New System.Drawing.Size(24, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(163, 211)
        Me.btnF3.Size = New System.Drawing.Size(24, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(193, 211)
        Me.btnF4.Size = New System.Drawing.Size(24, 58)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(223, 211)
        Me.btnF5.Size = New System.Drawing.Size(24, 58)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(253, 211)
        Me.btnF6.Size = New System.Drawing.Size(24, 58)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(282, 211)
        Me.btnF7.Size = New System.Drawing.Size(24, 58)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(314, 211)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.TabIndex = 101
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & " クリア"
        Me.btnF8.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(345, 211)
        Me.btnF9.Size = New System.Drawing.Size(24, 58)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(386, 211)
        Me.btnF10.Size = New System.Drawing.Size(24, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(419, 211)
        Me.btnF11.Size = New System.Drawing.Size(24, 58)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(461, 211)
        Me.btnF12.TabIndex = 102
        Me.btnF12.Text = "F12" & Global.Microsoft.VisualBasic.ChrW(13) & " ｷｬﾝｾﾙ"
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
        Me.txtロットNo.pAutoPad = True
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
        Me.txtロットNo.pPadWord = "0"
        Me.txtロットNo.Size = New System.Drawing.Size(91, 26)
        Me.txtロットNo.TabIndex = 1
        Me.txtロットNo.エラー表示用項目名 = ""
        '
        'lbl醗酵経過時間
        '
        Me.lbl醗酵経過時間.AutoSize = True
        Me.lbl醗酵経過時間.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl醗酵経過時間.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl醗酵経過時間.Isクリア = False
        Me.lbl醗酵経過時間.Location = New System.Drawing.Point(201, 140)
        Me.lbl醗酵経過時間.Name = "lbl醗酵経過時間"
        Me.lbl醗酵経過時間.pClearValue = ""
        Me.lbl醗酵経過時間.pID = ""
        Me.lbl醗酵経過時間.Size = New System.Drawing.Size(0, 19)
        Me.lbl醗酵経過時間.TabIndex = 129
        Me.lbl醗酵経過時間.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl醗酵経過時間.エラー表示用項目名 = ""
        '
        'lbl所定醗酵時間
        '
        Me.lbl所定醗酵時間.AutoSize = True
        Me.lbl所定醗酵時間.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl所定醗酵時間.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl所定醗酵時間.Isクリア = False
        Me.lbl所定醗酵時間.Location = New System.Drawing.Point(201, 105)
        Me.lbl所定醗酵時間.Name = "lbl所定醗酵時間"
        Me.lbl所定醗酵時間.pClearValue = ""
        Me.lbl所定醗酵時間.pID = ""
        Me.lbl所定醗酵時間.Size = New System.Drawing.Size(0, 19)
        Me.lbl所定醗酵時間.TabIndex = 128
        Me.lbl所定醗酵時間.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl所定醗酵時間.エラー表示用項目名 = ""
        '
        'lbl品種名
        '
        Me.lbl品種名.AutoSize = True
        Me.lbl品種名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl品種名.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl品種名.Isクリア = False
        Me.lbl品種名.Location = New System.Drawing.Point(201, 70)
        Me.lbl品種名.Name = "lbl品種名"
        Me.lbl品種名.pClearValue = ""
        Me.lbl品種名.pID = ""
        Me.lbl品種名.Size = New System.Drawing.Size(0, 19)
        Me.lbl品種名.TabIndex = 127
        Me.lbl品種名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl品種名.エラー表示用項目名 = ""
        '
        'UsrLbl7
        '
        Me.UsrLbl7.AutoSize = True
        Me.UsrLbl7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl7.Isクリア = False
        Me.UsrLbl7.Location = New System.Drawing.Point(175, 140)
        Me.UsrLbl7.Name = "UsrLbl7"
        Me.UsrLbl7.pClearValue = ""
        Me.UsrLbl7.pID = ""
        Me.UsrLbl7.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl7.TabIndex = 126
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
        Me.UsrLbl8.Location = New System.Drawing.Point(40, 140)
        Me.UsrLbl8.Name = "UsrLbl8"
        Me.UsrLbl8.pClearValue = ""
        Me.UsrLbl8.pID = ""
        Me.UsrLbl8.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl8.TabIndex = 125
        Me.UsrLbl8.Text = "冷却経過時間"
        Me.UsrLbl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl8.エラー表示用項目名 = ""
        '
        'UsrLbl5
        '
        Me.UsrLbl5.AutoSize = True
        Me.UsrLbl5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl5.Isクリア = False
        Me.UsrLbl5.Location = New System.Drawing.Point(175, 105)
        Me.UsrLbl5.Name = "UsrLbl5"
        Me.UsrLbl5.pClearValue = ""
        Me.UsrLbl5.pID = ""
        Me.UsrLbl5.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl5.TabIndex = 124
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
        Me.UsrLbl6.Location = New System.Drawing.Point(40, 105)
        Me.UsrLbl6.Name = "UsrLbl6"
        Me.UsrLbl6.pClearValue = ""
        Me.UsrLbl6.pID = ""
        Me.UsrLbl6.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl6.TabIndex = 123
        Me.UsrLbl6.Text = "所定冷却時間"
        Me.UsrLbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl6.エラー表示用項目名 = ""
        '
        'UsrLbl1
        '
        Me.UsrLbl1.AutoSize = True
        Me.UsrLbl1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl1.Isクリア = False
        Me.UsrLbl1.Location = New System.Drawing.Point(175, 70)
        Me.UsrLbl1.Name = "UsrLbl1"
        Me.UsrLbl1.pClearValue = ""
        Me.UsrLbl1.pID = ""
        Me.UsrLbl1.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl1.TabIndex = 122
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
        Me.UsrLbl4.Location = New System.Drawing.Point(40, 70)
        Me.UsrLbl4.Name = "UsrLbl4"
        Me.UsrLbl4.pClearValue = ""
        Me.UsrLbl4.pID = ""
        Me.UsrLbl4.Size = New System.Drawing.Size(69, 19)
        Me.UsrLbl4.TabIndex = 121
        Me.UsrLbl4.Text = "品種名"
        Me.UsrLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl4.エラー表示用項目名 = ""
        '
        'Dlg01999_冷却出庫設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(600, 281)
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
        Me.Controls.Add(Me.txtロットNo)
        Me.Name = "Dlg01999_冷却出庫設定"
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
    Friend WithEvents UsrLbl2 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txtロットNo As 共通Windowsコントロール.usrTxt
    Friend WithEvents lbl醗酵経過時間 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl所定醗酵時間 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl品種名 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl7 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl8 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl5 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl6 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl1 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl4 As 共通Windowsコントロール.usrLbl

End Class

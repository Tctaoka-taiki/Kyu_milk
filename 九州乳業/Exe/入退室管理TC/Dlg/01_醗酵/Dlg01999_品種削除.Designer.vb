﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg01999_品種削除
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
        Me.txt品種 = New 共通Windowsコントロール.usrTxt
        Me.lbl品種 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl10 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl11 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl12 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl8 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl13 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl14 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl22 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl23 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl4 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl5 = New 共通Windowsコントロール.usrLbl
        Me.lbl製品区分 = New 共通Windowsコントロール.usrLbl
        Me.lbl品種名 = New 共通Windowsコントロール.usrLbl
        Me.lbl所定発酵時間 = New 共通Windowsコントロール.usrLbl
        Me.lbl所定冷却時間 = New 共通Windowsコントロール.usrLbl
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Location = New System.Drawing.Point(12, 234)
        Me.btnF1.TabIndex = 100
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(133, 234)
        Me.btnF2.Size = New System.Drawing.Size(24, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(163, 234)
        Me.btnF3.Size = New System.Drawing.Size(24, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(193, 234)
        Me.btnF4.Size = New System.Drawing.Size(24, 58)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(223, 234)
        Me.btnF5.Size = New System.Drawing.Size(24, 58)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(253, 234)
        Me.btnF6.Size = New System.Drawing.Size(24, 58)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(282, 234)
        Me.btnF7.Size = New System.Drawing.Size(24, 58)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(373, 234)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.TabIndex = 101
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & " クリア"
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(345, 234)
        Me.btnF9.Size = New System.Drawing.Size(24, 58)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(386, 234)
        Me.btnF10.Size = New System.Drawing.Size(24, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(419, 234)
        Me.btnF11.Size = New System.Drawing.Size(24, 58)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(520, 234)
        Me.btnF12.TabIndex = 102
        Me.btnF12.Text = "F12" & Global.Microsoft.VisualBasic.ChrW(13) & " ｷｬﾝｾﾙ"
        '
        'txt品種
        '
        Me.txt品種.BackColor = System.Drawing.SystemColors.Window
        Me.txt品種.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt品種.Isクリア = True
        Me.txt品種.Location = New System.Drawing.Point(201, 32)
        Me.txt品種.MaxLength = 2
        Me.txt品種.Name = "txt品種"
        Me.txt品種.pAutoFocus = True
        Me.txt品種.pAutoPad = False
        Me.txt品種.pAutoSelect = True
        Me.txt品種.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.Numonly
        Me.txt品種.pClearText = ""
        Me.txt品種.pClearValue = ""
        Me.txt品種.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt品種.pFromCtl = Nothing
        Me.txt品種.pFromToErrText = ""
        Me.txt品種.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt品種.pID = ""
        Me.txt品種.pMaxByte = 2
        Me.txt品種.pPadWord = ""
        Me.txt品種.Size = New System.Drawing.Size(32, 26)
        Me.txt品種.TabIndex = 1
        Me.txt品種.エラー表示用項目名 = ""
        '
        'lbl品種
        '
        Me.lbl品種.AutoSize = True
        Me.lbl品種.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl品種.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl品種.Isクリア = False
        Me.lbl品種.Location = New System.Drawing.Point(239, 70)
        Me.lbl品種.Name = "lbl品種"
        Me.lbl品種.pClearValue = ""
        Me.lbl品種.pID = ""
        Me.lbl品種.Size = New System.Drawing.Size(0, 19)
        Me.lbl品種.TabIndex = 131
        Me.lbl品種.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl品種.エラー表示用項目名 = ""
        '
        'UsrLbl10
        '
        Me.UsrLbl10.AutoSize = True
        Me.UsrLbl10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl10.Isクリア = False
        Me.UsrLbl10.Location = New System.Drawing.Point(175, 175)
        Me.UsrLbl10.Name = "UsrLbl10"
        Me.UsrLbl10.pClearValue = ""
        Me.UsrLbl10.pID = ""
        Me.UsrLbl10.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl10.TabIndex = 129
        Me.UsrLbl10.Text = "："
        Me.UsrLbl10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl10.エラー表示用項目名 = ""
        '
        'UsrLbl11
        '
        Me.UsrLbl11.AutoSize = True
        Me.UsrLbl11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl11.Isクリア = False
        Me.UsrLbl11.Location = New System.Drawing.Point(175, 105)
        Me.UsrLbl11.Name = "UsrLbl11"
        Me.UsrLbl11.pClearValue = ""
        Me.UsrLbl11.pID = ""
        Me.UsrLbl11.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl11.TabIndex = 128
        Me.UsrLbl11.Text = "："
        Me.UsrLbl11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl11.エラー表示用項目名 = ""
        '
        'UsrLbl12
        '
        Me.UsrLbl12.AutoSize = True
        Me.UsrLbl12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl12.Isクリア = False
        Me.UsrLbl12.Location = New System.Drawing.Point(175, 70)
        Me.UsrLbl12.Name = "UsrLbl12"
        Me.UsrLbl12.pClearValue = ""
        Me.UsrLbl12.pID = ""
        Me.UsrLbl12.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl12.TabIndex = 127
        Me.UsrLbl12.Text = "："
        Me.UsrLbl12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl12.エラー表示用項目名 = ""
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
        Me.UsrLbl8.TabIndex = 125
        Me.UsrLbl8.Text = "所定冷却時間"
        Me.UsrLbl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl8.エラー表示用項目名 = ""
        '
        'UsrLbl13
        '
        Me.UsrLbl13.AutoSize = True
        Me.UsrLbl13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl13.Isクリア = False
        Me.UsrLbl13.Location = New System.Drawing.Point(40, 105)
        Me.UsrLbl13.Name = "UsrLbl13"
        Me.UsrLbl13.pClearValue = ""
        Me.UsrLbl13.pID = ""
        Me.UsrLbl13.Size = New System.Drawing.Size(69, 19)
        Me.UsrLbl13.TabIndex = 124
        Me.UsrLbl13.Text = "品種名"
        Me.UsrLbl13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl13.エラー表示用項目名 = ""
        '
        'UsrLbl14
        '
        Me.UsrLbl14.AutoSize = True
        Me.UsrLbl14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl14.Isクリア = False
        Me.UsrLbl14.Location = New System.Drawing.Point(40, 70)
        Me.UsrLbl14.Name = "UsrLbl14"
        Me.UsrLbl14.pClearValue = ""
        Me.UsrLbl14.pID = ""
        Me.UsrLbl14.Size = New System.Drawing.Size(89, 19)
        Me.UsrLbl14.TabIndex = 123
        Me.UsrLbl14.Text = "製品区分"
        Me.UsrLbl14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl14.エラー表示用項目名 = ""
        '
        'UsrLbl22
        '
        Me.UsrLbl22.AutoSize = True
        Me.UsrLbl22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl22.Isクリア = False
        Me.UsrLbl22.Location = New System.Drawing.Point(175, 140)
        Me.UsrLbl22.Name = "UsrLbl22"
        Me.UsrLbl22.pClearValue = ""
        Me.UsrLbl22.pID = ""
        Me.UsrLbl22.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl22.TabIndex = 143
        Me.UsrLbl22.Text = "："
        Me.UsrLbl22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl22.エラー表示用項目名 = ""
        '
        'UsrLbl23
        '
        Me.UsrLbl23.AutoSize = True
        Me.UsrLbl23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl23.Isクリア = False
        Me.UsrLbl23.Location = New System.Drawing.Point(40, 140)
        Me.UsrLbl23.Name = "UsrLbl23"
        Me.UsrLbl23.pClearValue = ""
        Me.UsrLbl23.pID = ""
        Me.UsrLbl23.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl23.TabIndex = 142
        Me.UsrLbl23.Text = "所定発酵時間"
        Me.UsrLbl23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl23.エラー表示用項目名 = ""
        '
        'UsrLbl4
        '
        Me.UsrLbl4.AutoSize = True
        Me.UsrLbl4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl4.Isクリア = False
        Me.UsrLbl4.Location = New System.Drawing.Point(175, 35)
        Me.UsrLbl4.Name = "UsrLbl4"
        Me.UsrLbl4.pClearValue = ""
        Me.UsrLbl4.pID = ""
        Me.UsrLbl4.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl4.TabIndex = 150
        Me.UsrLbl4.Text = "："
        Me.UsrLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl4.エラー表示用項目名 = ""
        '
        'UsrLbl5
        '
        Me.UsrLbl5.AutoSize = True
        Me.UsrLbl5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl5.Isクリア = False
        Me.UsrLbl5.Location = New System.Drawing.Point(40, 35)
        Me.UsrLbl5.Name = "UsrLbl5"
        Me.UsrLbl5.pClearValue = ""
        Me.UsrLbl5.pID = ""
        Me.UsrLbl5.Size = New System.Drawing.Size(76, 19)
        Me.UsrLbl5.TabIndex = 149
        Me.UsrLbl5.Text = "品種CD"
        Me.UsrLbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl5.エラー表示用項目名 = ""
        '
        'lbl製品区分
        '
        Me.lbl製品区分.AutoSize = True
        Me.lbl製品区分.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl製品区分.Isクリア = False
        Me.lbl製品区分.Location = New System.Drawing.Point(201, 70)
        Me.lbl製品区分.Name = "lbl製品区分"
        Me.lbl製品区分.pClearValue = ""
        Me.lbl製品区分.pID = ""
        Me.lbl製品区分.Size = New System.Drawing.Size(77, 19)
        Me.lbl製品区分.TabIndex = 2
        Me.lbl製品区分.Text = "UsrLbl1"
        Me.lbl製品区分.エラー表示用項目名 = ""
        '
        'lbl品種名
        '
        Me.lbl品種名.AutoSize = True
        Me.lbl品種名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl品種名.Isクリア = False
        Me.lbl品種名.Location = New System.Drawing.Point(201, 105)
        Me.lbl品種名.Name = "lbl品種名"
        Me.lbl品種名.pClearValue = ""
        Me.lbl品種名.pID = ""
        Me.lbl品種名.Size = New System.Drawing.Size(77, 19)
        Me.lbl品種名.TabIndex = 3
        Me.lbl品種名.Text = "UsrLbl2"
        Me.lbl品種名.エラー表示用項目名 = ""
        '
        'lbl所定発酵時間
        '
        Me.lbl所定発酵時間.AutoSize = True
        Me.lbl所定発酵時間.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl所定発酵時間.Isクリア = False
        Me.lbl所定発酵時間.Location = New System.Drawing.Point(201, 140)
        Me.lbl所定発酵時間.Name = "lbl所定発酵時間"
        Me.lbl所定発酵時間.pClearValue = ""
        Me.lbl所定発酵時間.pID = ""
        Me.lbl所定発酵時間.Size = New System.Drawing.Size(77, 19)
        Me.lbl所定発酵時間.TabIndex = 4
        Me.lbl所定発酵時間.Text = "UsrLbl6"
        Me.lbl所定発酵時間.エラー表示用項目名 = ""
        '
        'lbl所定冷却時間
        '
        Me.lbl所定冷却時間.AutoSize = True
        Me.lbl所定冷却時間.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl所定冷却時間.Isクリア = False
        Me.lbl所定冷却時間.Location = New System.Drawing.Point(201, 175)
        Me.lbl所定冷却時間.Name = "lbl所定冷却時間"
        Me.lbl所定冷却時間.pClearValue = ""
        Me.lbl所定冷却時間.pID = ""
        Me.lbl所定冷却時間.Size = New System.Drawing.Size(77, 19)
        Me.lbl所定冷却時間.TabIndex = 5
        Me.lbl所定冷却時間.Text = "UsrLbl7"
        Me.lbl所定冷却時間.エラー表示用項目名 = ""
        '
        'Dlg01999_品種削除
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(647, 305)
        Me.Controls.Add(Me.lbl所定冷却時間)
        Me.Controls.Add(Me.lbl所定発酵時間)
        Me.Controls.Add(Me.lbl品種名)
        Me.Controls.Add(Me.lbl製品区分)
        Me.Controls.Add(Me.UsrLbl4)
        Me.Controls.Add(Me.UsrLbl5)
        Me.Controls.Add(Me.UsrLbl22)
        Me.Controls.Add(Me.UsrLbl23)
        Me.Controls.Add(Me.txt品種)
        Me.Controls.Add(Me.lbl品種)
        Me.Controls.Add(Me.UsrLbl10)
        Me.Controls.Add(Me.UsrLbl11)
        Me.Controls.Add(Me.UsrLbl12)
        Me.Controls.Add(Me.UsrLbl8)
        Me.Controls.Add(Me.UsrLbl13)
        Me.Controls.Add(Me.UsrLbl14)
        Me.Name = "Dlg01999_品種削除"
        Me.Text = "品種データ削除"
        Me.Controls.SetChildIndex(Me.UsrLbl14, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl13, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl8, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl12, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl11, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl10, 0)
        Me.Controls.SetChildIndex(Me.lbl品種, 0)
        Me.Controls.SetChildIndex(Me.txt品種, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl23, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl22, 0)
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
        Me.Controls.SetChildIndex(Me.UsrLbl5, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl4, 0)
        Me.Controls.SetChildIndex(Me.lbl製品区分, 0)
        Me.Controls.SetChildIndex(Me.lbl品種名, 0)
        Me.Controls.SetChildIndex(Me.lbl所定発酵時間, 0)
        Me.Controls.SetChildIndex(Me.lbl所定冷却時間, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt品種 As 共通Windowsコントロール.usrTxt
    Friend WithEvents lbl品種 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl10 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl11 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl12 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl8 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl13 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl14 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl22 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl23 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl4 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl5 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl製品区分 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl品種名 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl所定発酵時間 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl所定冷却時間 As 共通Windowsコントロール.usrLbl

End Class

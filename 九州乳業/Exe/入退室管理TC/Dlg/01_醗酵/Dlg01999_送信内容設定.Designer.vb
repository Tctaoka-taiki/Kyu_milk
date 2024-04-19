<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg01999_送信内容設定
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
        Me.UsrLbl19 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl20 = New 共通Windowsコントロール.usrLbl
        Me.cmb送信ステータス = New 共通Windowsコントロール.usrCmb
        Me.chk自動モード = New 共通Windowsコントロール.UsrChk
        Me.chk読出専用モード = New 共通Windowsコントロール.UsrChk
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Location = New System.Drawing.Point(12, 117)
        Me.btnF1.TabIndex = 100
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(133, 117)
        Me.btnF2.Size = New System.Drawing.Size(24, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(163, 117)
        Me.btnF3.Size = New System.Drawing.Size(24, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(193, 117)
        Me.btnF4.Size = New System.Drawing.Size(24, 58)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(223, 117)
        Me.btnF5.Size = New System.Drawing.Size(24, 58)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(253, 117)
        Me.btnF6.Size = New System.Drawing.Size(24, 58)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(282, 117)
        Me.btnF7.Size = New System.Drawing.Size(24, 58)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(314, 117)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.TabIndex = 101
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & " クリア"
        Me.btnF8.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(345, 117)
        Me.btnF9.Size = New System.Drawing.Size(24, 58)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(386, 117)
        Me.btnF10.Size = New System.Drawing.Size(24, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(419, 117)
        Me.btnF11.Size = New System.Drawing.Size(24, 58)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(461, 117)
        Me.btnF12.TabIndex = 102
        Me.btnF12.Text = "F12" & Global.Microsoft.VisualBasic.ChrW(13) & " ｷｬﾝｾﾙ"
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
        Me.lbl品種.TabIndex = 53
        Me.lbl品種.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl品種.エラー表示用項目名 = ""
        '
        'UsrLbl19
        '
        Me.UsrLbl19.AutoSize = True
        Me.UsrLbl19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl19.Isクリア = False
        Me.UsrLbl19.Location = New System.Drawing.Point(40, 35)
        Me.UsrLbl19.Name = "UsrLbl19"
        Me.UsrLbl19.pClearValue = ""
        Me.UsrLbl19.pID = ""
        Me.UsrLbl19.Size = New System.Drawing.Size(138, 19)
        Me.UsrLbl19.TabIndex = 79
        Me.UsrLbl19.Text = "送信ステータス"
        Me.UsrLbl19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl19.エラー表示用項目名 = ""
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
        'cmb送信ステータス
        '
        Me.cmb送信ステータス.BackColor = System.Drawing.SystemColors.Window
        Me.cmb送信ステータス.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb送信ステータス.DropDownWidth = 121
        Me.cmb送信ステータス.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.cmb送信ステータス.FormattingEnabled = True
        Me.cmb送信ステータス.Isクリア = True
        Me.cmb送信ステータス.Location = New System.Drawing.Point(201, 32)
        Me.cmb送信ステータス.Name = "cmb送信ステータス"
        Me.cmb送信ステータス.pAutoFocus = True
        Me.cmb送信ステータス.pAutoSelect = True
        Me.cmb送信ステータス.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.cmb送信ステータス.pClearIndex = -1
        Me.cmb送信ステータス.pClearValue = ""
        Me.cmb送信ステータス.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.cmb送信ステータス.pFromCtl = Nothing
        Me.cmb送信ステータス.pFromToErrText = ""
        Me.cmb送信ステータス.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.cmb送信ステータス.pID = ""
        Me.cmb送信ステータス.pMaxByte = 0
        Me.cmb送信ステータス.Size = New System.Drawing.Size(121, 27)
        Me.cmb送信ステータス.TabIndex = 103
        Me.cmb送信ステータス.エラー表示用項目名 = ""
        '
        'chk自動モード
        '
        Me.chk自動モード.AutoSize = True
        Me.chk自動モード.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.chk自動モード.Isクリア = False
        Me.chk自動モード.Location = New System.Drawing.Point(372, 34)
        Me.chk自動モード.Name = "chk自動モード"
        Me.chk自動モード.pClearValue = System.Windows.Forms.CheckState.Unchecked
        Me.chk自動モード.pID = ""
        Me.chk自動モード.Size = New System.Drawing.Size(179, 23)
        Me.chk自動モード.TabIndex = 104
        Me.chk自動モード.Text = "自動送受信モード"
        Me.chk自動モード.UseVisualStyleBackColor = True
        Me.chk自動モード.エラー表示用項目名 = ""
        '
        'chk読出専用モード
        '
        Me.chk読出専用モード.AutoSize = True
        Me.chk読出専用モード.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.chk読出専用モード.Isクリア = False
        Me.chk読出専用モード.Location = New System.Drawing.Point(372, 63)
        Me.chk読出専用モード.Name = "chk読出専用モード"
        Me.chk読出専用モード.pClearValue = System.Windows.Forms.CheckState.Unchecked
        Me.chk読出専用モード.pID = ""
        Me.chk読出専用モード.Size = New System.Drawing.Size(159, 23)
        Me.chk読出専用モード.TabIndex = 105
        Me.chk読出専用モード.Text = "読出専用モード"
        Me.chk読出専用モード.UseVisualStyleBackColor = True
        Me.chk読出専用モード.エラー表示用項目名 = ""
        '
        'Dlg01999_送信内容設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(600, 187)
        Me.Controls.Add(Me.chk読出専用モード)
        Me.Controls.Add(Me.chk自動モード)
        Me.Controls.Add(Me.cmb送信ステータス)
        Me.Controls.Add(Me.UsrLbl20)
        Me.Controls.Add(Me.UsrLbl19)
        Me.Controls.Add(Me.lbl品種)
        Me.Name = "Dlg01999_送信内容設定"
        Me.Text = "送信内容設定"
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
        Me.Controls.SetChildIndex(Me.lbl品種, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl19, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl20, 0)
        Me.Controls.SetChildIndex(Me.cmb送信ステータス, 0)
        Me.Controls.SetChildIndex(Me.chk自動モード, 0)
        Me.Controls.SetChildIndex(Me.chk読出専用モード, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl品種 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl19 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl20 As 共通Windowsコントロール.usrLbl
    Friend WithEvents cmb送信ステータス As 共通Windowsコントロール.usrCmb
    Friend WithEvents chk自動モード As 共通Windowsコントロール.UsrChk
    Friend WithEvents chk読出専用モード As 共通Windowsコントロール.UsrChk

End Class

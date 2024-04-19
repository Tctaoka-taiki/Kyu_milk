<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg01024_作業履歴問合せ
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
        Me.txt指定日FR = New 共通Windowsコントロール.usrTxt
        Me.txt指定月FR = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl15 = New 共通Windowsコントロール.usrLbl
        Me.txt指定年FR = New 共通Windowsコントロール.usrTxt
        Me.lbl賞味期限 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl10 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl
        Me.cmbPLC = New 共通Windowsコントロール.usrCmb
        Me.txt指定分FR = New 共通Windowsコントロール.usrTxt
        Me.txt指定時FR = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl18 = New 共通Windowsコントロール.usrLbl
        Me.txt指定分TO = New 共通Windowsコントロール.usrTxt
        Me.txt指定時TO = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl
        Me.txt指定日TO = New 共通Windowsコントロール.usrTxt
        Me.txt指定月TO = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl4 = New 共通Windowsコントロール.usrLbl
        Me.txt指定年TO = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl5 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl6 = New 共通Windowsコントロール.usrLbl
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Location = New System.Drawing.Point(12, 178)
        Me.btnF1.TabIndex = 100
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "決定"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(133, 178)
        Me.btnF2.Size = New System.Drawing.Size(24, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(163, 178)
        Me.btnF3.Size = New System.Drawing.Size(24, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(193, 178)
        Me.btnF4.Size = New System.Drawing.Size(24, 58)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(223, 178)
        Me.btnF5.Size = New System.Drawing.Size(24, 58)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(253, 178)
        Me.btnF6.Size = New System.Drawing.Size(24, 58)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(282, 178)
        Me.btnF7.Size = New System.Drawing.Size(24, 58)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(314, 178)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.TabIndex = 101
        Me.btnF8.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(345, 178)
        Me.btnF9.Size = New System.Drawing.Size(24, 58)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(386, 178)
        Me.btnF10.Size = New System.Drawing.Size(24, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(419, 178)
        Me.btnF11.Size = New System.Drawing.Size(24, 58)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(520, 178)
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
        Me.UsrLbl1.Size = New System.Drawing.Size(49, 19)
        Me.UsrLbl1.TabIndex = 41
        Me.UsrLbl1.Text = "設備"
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
        'txt指定日FR
        '
        Me.txt指定日FR.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定日FR.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定日FR.Isクリア = True
        Me.txt指定日FR.Location = New System.Drawing.Point(346, 67)
        Me.txt指定日FR.MaxLength = 2
        Me.txt指定日FR.Name = "txt指定日FR"
        Me.txt指定日FR.pAutoFocus = True
        Me.txt指定日FR.pAutoPad = False
        Me.txt指定日FR.pAutoSelect = True
        Me.txt指定日FR.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定日FR.pClearText = ""
        Me.txt指定日FR.pClearValue = ""
        Me.txt指定日FR.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定日FR.pFromCtl = Nothing
        Me.txt指定日FR.pFromToErrText = ""
        Me.txt指定日FR.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定日FR.pID = ""
        Me.txt指定日FR.pMaxByte = 2
        Me.txt指定日FR.pPadWord = "0"
        Me.txt指定日FR.Size = New System.Drawing.Size(40, 26)
        Me.txt指定日FR.TabIndex = 4
        Me.txt指定日FR.エラー表示用項目名 = ""
        '
        'txt指定月FR
        '
        Me.txt指定月FR.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定月FR.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定月FR.Isクリア = True
        Me.txt指定月FR.Location = New System.Drawing.Point(282, 67)
        Me.txt指定月FR.MaxLength = 2
        Me.txt指定月FR.Name = "txt指定月FR"
        Me.txt指定月FR.pAutoFocus = True
        Me.txt指定月FR.pAutoPad = False
        Me.txt指定月FR.pAutoSelect = True
        Me.txt指定月FR.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定月FR.pClearText = ""
        Me.txt指定月FR.pClearValue = ""
        Me.txt指定月FR.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定月FR.pFromCtl = Nothing
        Me.txt指定月FR.pFromToErrText = ""
        Me.txt指定月FR.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定月FR.pID = ""
        Me.txt指定月FR.pMaxByte = 2
        Me.txt指定月FR.pPadWord = "0"
        Me.txt指定月FR.Size = New System.Drawing.Size(40, 26)
        Me.txt指定月FR.TabIndex = 3
        Me.txt指定月FR.エラー表示用項目名 = ""
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
        'txt指定年FR
        '
        Me.txt指定年FR.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定年FR.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定年FR.Isクリア = True
        Me.txt指定年FR.Location = New System.Drawing.Point(201, 67)
        Me.txt指定年FR.MaxLength = 4
        Me.txt指定年FR.Name = "txt指定年FR"
        Me.txt指定年FR.pAutoFocus = True
        Me.txt指定年FR.pAutoPad = False
        Me.txt指定年FR.pAutoSelect = True
        Me.txt指定年FR.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定年FR.pClearText = ""
        Me.txt指定年FR.pClearValue = ""
        Me.txt指定年FR.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定年FR.pFromCtl = Nothing
        Me.txt指定年FR.pFromToErrText = ""
        Me.txt指定年FR.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定年FR.pID = ""
        Me.txt指定年FR.pMaxByte = 4
        Me.txt指定年FR.pPadWord = "0"
        Me.txt指定年FR.Size = New System.Drawing.Size(59, 26)
        Me.txt指定年FR.TabIndex = 2
        Me.txt指定年FR.エラー表示用項目名 = ""
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
        Me.UsrLbl3.Size = New System.Drawing.Size(89, 19)
        Me.UsrLbl3.TabIndex = 106
        Me.UsrLbl3.Text = "指定日時"
        Me.UsrLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl3.エラー表示用項目名 = ""
        '
        'cmbPLC
        '
        Me.cmbPLC.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPLC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPLC.DropDownWidth = 185
        Me.cmbPLC.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.cmbPLC.FormattingEnabled = True
        Me.cmbPLC.Isクリア = True
        Me.cmbPLC.Items.AddRange(New Object() {"醗酵", "冷却"})
        Me.cmbPLC.Location = New System.Drawing.Point(201, 32)
        Me.cmbPLC.Name = "cmbPLC"
        Me.cmbPLC.pAutoFocus = True
        Me.cmbPLC.pAutoSelect = True
        Me.cmbPLC.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.cmbPLC.pClearIndex = -1
        Me.cmbPLC.pClearValue = ""
        Me.cmbPLC.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.cmbPLC.pFromCtl = Nothing
        Me.cmbPLC.pFromToErrText = ""
        Me.cmbPLC.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.cmbPLC.pID = ""
        Me.cmbPLC.pMaxByte = 0
        Me.cmbPLC.Size = New System.Drawing.Size(185, 27)
        Me.cmbPLC.TabIndex = 1
        Me.cmbPLC.エラー表示用項目名 = ""
        '
        'txt指定分FR
        '
        Me.txt指定分FR.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定分FR.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定分FR.Isクリア = True
        Me.txt指定分FR.Location = New System.Drawing.Point(461, 67)
        Me.txt指定分FR.MaxLength = 2
        Me.txt指定分FR.Name = "txt指定分FR"
        Me.txt指定分FR.pAutoFocus = True
        Me.txt指定分FR.pAutoPad = True
        Me.txt指定分FR.pAutoSelect = True
        Me.txt指定分FR.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定分FR.pClearText = ""
        Me.txt指定分FR.pClearValue = ""
        Me.txt指定分FR.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定分FR.pFromCtl = Nothing
        Me.txt指定分FR.pFromToErrText = ""
        Me.txt指定分FR.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定分FR.pID = ""
        Me.txt指定分FR.pMaxByte = 2
        Me.txt指定分FR.pPadWord = "0"
        Me.txt指定分FR.Size = New System.Drawing.Size(40, 26)
        Me.txt指定分FR.TabIndex = 6
        Me.txt指定分FR.エラー表示用項目名 = ""
        '
        'txt指定時FR
        '
        Me.txt指定時FR.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定時FR.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定時FR.Isクリア = True
        Me.txt指定時FR.Location = New System.Drawing.Point(403, 67)
        Me.txt指定時FR.MaxLength = 2
        Me.txt指定時FR.Name = "txt指定時FR"
        Me.txt指定時FR.pAutoFocus = True
        Me.txt指定時FR.pAutoPad = True
        Me.txt指定時FR.pAutoSelect = True
        Me.txt指定時FR.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定時FR.pClearText = ""
        Me.txt指定時FR.pClearValue = ""
        Me.txt指定時FR.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定時FR.pFromCtl = Nothing
        Me.txt指定時FR.pFromToErrText = ""
        Me.txt指定時FR.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定時FR.pID = ""
        Me.txt指定時FR.pMaxByte = 2
        Me.txt指定時FR.pPadWord = "0"
        Me.txt指定時FR.Size = New System.Drawing.Size(40, 26)
        Me.txt指定時FR.TabIndex = 5
        Me.txt指定時FR.エラー表示用項目名 = ""
        '
        'UsrLbl18
        '
        Me.UsrLbl18.AutoSize = True
        Me.UsrLbl18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl18.Isクリア = False
        Me.UsrLbl18.Location = New System.Drawing.Point(445, 70)
        Me.UsrLbl18.Name = "UsrLbl18"
        Me.UsrLbl18.pClearValue = ""
        Me.UsrLbl18.pID = ""
        Me.UsrLbl18.Size = New System.Drawing.Size(14, 19)
        Me.UsrLbl18.TabIndex = 112
        Me.UsrLbl18.Text = ":"
        Me.UsrLbl18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl18.エラー表示用項目名 = ""
        '
        'txt指定分TO
        '
        Me.txt指定分TO.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定分TO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定分TO.Isクリア = True
        Me.txt指定分TO.Location = New System.Drawing.Point(574, 109)
        Me.txt指定分TO.MaxLength = 2
        Me.txt指定分TO.Name = "txt指定分TO"
        Me.txt指定分TO.pAutoFocus = True
        Me.txt指定分TO.pAutoPad = True
        Me.txt指定分TO.pAutoSelect = True
        Me.txt指定分TO.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定分TO.pClearText = ""
        Me.txt指定分TO.pClearValue = ""
        Me.txt指定分TO.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定分TO.pFromCtl = Nothing
        Me.txt指定分TO.pFromToErrText = ""
        Me.txt指定分TO.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定分TO.pID = ""
        Me.txt指定分TO.pMaxByte = 2
        Me.txt指定分TO.pPadWord = "0"
        Me.txt指定分TO.Size = New System.Drawing.Size(40, 26)
        Me.txt指定分TO.TabIndex = 11
        Me.txt指定分TO.エラー表示用項目名 = ""
        '
        'txt指定時TO
        '
        Me.txt指定時TO.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定時TO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定時TO.Isクリア = True
        Me.txt指定時TO.Location = New System.Drawing.Point(516, 109)
        Me.txt指定時TO.MaxLength = 2
        Me.txt指定時TO.Name = "txt指定時TO"
        Me.txt指定時TO.pAutoFocus = True
        Me.txt指定時TO.pAutoPad = True
        Me.txt指定時TO.pAutoSelect = True
        Me.txt指定時TO.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定時TO.pClearText = ""
        Me.txt指定時TO.pClearValue = ""
        Me.txt指定時TO.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定時TO.pFromCtl = Nothing
        Me.txt指定時TO.pFromToErrText = ""
        Me.txt指定時TO.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定時TO.pID = ""
        Me.txt指定時TO.pMaxByte = 2
        Me.txt指定時TO.pPadWord = "0"
        Me.txt指定時TO.Size = New System.Drawing.Size(40, 26)
        Me.txt指定時TO.TabIndex = 10
        Me.txt指定時TO.エラー表示用項目名 = ""
        '
        'UsrLbl2
        '
        Me.UsrLbl2.AutoSize = True
        Me.UsrLbl2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl2.Isクリア = False
        Me.UsrLbl2.Location = New System.Drawing.Point(558, 112)
        Me.UsrLbl2.Name = "UsrLbl2"
        Me.UsrLbl2.pClearValue = ""
        Me.UsrLbl2.pID = ""
        Me.UsrLbl2.Size = New System.Drawing.Size(14, 19)
        Me.UsrLbl2.TabIndex = 120
        Me.UsrLbl2.Text = ":"
        Me.UsrLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl2.エラー表示用項目名 = ""
        '
        'txt指定日TO
        '
        Me.txt指定日TO.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定日TO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定日TO.Isクリア = True
        Me.txt指定日TO.Location = New System.Drawing.Point(459, 109)
        Me.txt指定日TO.MaxLength = 2
        Me.txt指定日TO.Name = "txt指定日TO"
        Me.txt指定日TO.pAutoFocus = True
        Me.txt指定日TO.pAutoPad = False
        Me.txt指定日TO.pAutoSelect = True
        Me.txt指定日TO.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定日TO.pClearText = ""
        Me.txt指定日TO.pClearValue = ""
        Me.txt指定日TO.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定日TO.pFromCtl = Nothing
        Me.txt指定日TO.pFromToErrText = ""
        Me.txt指定日TO.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定日TO.pID = ""
        Me.txt指定日TO.pMaxByte = 2
        Me.txt指定日TO.pPadWord = "0"
        Me.txt指定日TO.Size = New System.Drawing.Size(40, 26)
        Me.txt指定日TO.TabIndex = 9
        Me.txt指定日TO.エラー表示用項目名 = ""
        '
        'txt指定月TO
        '
        Me.txt指定月TO.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定月TO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定月TO.Isクリア = True
        Me.txt指定月TO.Location = New System.Drawing.Point(395, 109)
        Me.txt指定月TO.MaxLength = 2
        Me.txt指定月TO.Name = "txt指定月TO"
        Me.txt指定月TO.pAutoFocus = True
        Me.txt指定月TO.pAutoPad = False
        Me.txt指定月TO.pAutoSelect = True
        Me.txt指定月TO.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定月TO.pClearText = ""
        Me.txt指定月TO.pClearValue = ""
        Me.txt指定月TO.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定月TO.pFromCtl = Nothing
        Me.txt指定月TO.pFromToErrText = ""
        Me.txt指定月TO.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定月TO.pID = ""
        Me.txt指定月TO.pMaxByte = 2
        Me.txt指定月TO.pPadWord = "0"
        Me.txt指定月TO.Size = New System.Drawing.Size(40, 26)
        Me.txt指定月TO.TabIndex = 8
        Me.txt指定月TO.エラー表示用項目名 = ""
        '
        'UsrLbl4
        '
        Me.UsrLbl4.AutoSize = True
        Me.UsrLbl4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl4.Isクリア = False
        Me.UsrLbl4.Location = New System.Drawing.Point(437, 112)
        Me.UsrLbl4.Name = "UsrLbl4"
        Me.UsrLbl4.pClearValue = ""
        Me.UsrLbl4.pID = ""
        Me.UsrLbl4.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl4.TabIndex = 117
        Me.UsrLbl4.Text = "/"
        Me.UsrLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl4.エラー表示用項目名 = ""
        '
        'txt指定年TO
        '
        Me.txt指定年TO.BackColor = System.Drawing.SystemColors.Window
        Me.txt指定年TO.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt指定年TO.Isクリア = True
        Me.txt指定年TO.Location = New System.Drawing.Point(314, 109)
        Me.txt指定年TO.MaxLength = 4
        Me.txt指定年TO.Name = "txt指定年TO"
        Me.txt指定年TO.pAutoFocus = True
        Me.txt指定年TO.pAutoPad = False
        Me.txt指定年TO.pAutoSelect = True
        Me.txt指定年TO.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt指定年TO.pClearText = ""
        Me.txt指定年TO.pClearValue = ""
        Me.txt指定年TO.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt指定年TO.pFromCtl = Nothing
        Me.txt指定年TO.pFromToErrText = ""
        Me.txt指定年TO.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt指定年TO.pID = ""
        Me.txt指定年TO.pMaxByte = 4
        Me.txt指定年TO.pPadWord = "0"
        Me.txt指定年TO.Size = New System.Drawing.Size(59, 26)
        Me.txt指定年TO.TabIndex = 7
        Me.txt指定年TO.エラー表示用項目名 = ""
        '
        'UsrLbl5
        '
        Me.UsrLbl5.AutoSize = True
        Me.UsrLbl5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl5.Isクリア = False
        Me.UsrLbl5.Location = New System.Drawing.Point(374, 112)
        Me.UsrLbl5.Name = "UsrLbl5"
        Me.UsrLbl5.pClearValue = ""
        Me.UsrLbl5.pID = ""
        Me.UsrLbl5.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl5.TabIndex = 116
        Me.UsrLbl5.Text = "/"
        Me.UsrLbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl5.エラー表示用項目名 = ""
        '
        'UsrLbl6
        '
        Me.UsrLbl6.AutoSize = True
        Me.UsrLbl6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl6.Isクリア = False
        Me.UsrLbl6.Location = New System.Drawing.Point(261, 112)
        Me.UsrLbl6.Name = "UsrLbl6"
        Me.UsrLbl6.pClearValue = ""
        Me.UsrLbl6.pID = ""
        Me.UsrLbl6.Size = New System.Drawing.Size(29, 19)
        Me.UsrLbl6.TabIndex = 121
        Me.UsrLbl6.Text = "～"
        Me.UsrLbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl6.エラー表示用項目名 = ""
        '
        'Dlg01024_作業履歴問合せ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(647, 248)
        Me.Controls.Add(Me.UsrLbl6)
        Me.Controls.Add(Me.txt指定分TO)
        Me.Controls.Add(Me.txt指定時TO)
        Me.Controls.Add(Me.UsrLbl2)
        Me.Controls.Add(Me.txt指定日TO)
        Me.Controls.Add(Me.txt指定月TO)
        Me.Controls.Add(Me.UsrLbl4)
        Me.Controls.Add(Me.txt指定年TO)
        Me.Controls.Add(Me.UsrLbl5)
        Me.Controls.Add(Me.txt指定分FR)
        Me.Controls.Add(Me.txt指定時FR)
        Me.Controls.Add(Me.UsrLbl18)
        Me.Controls.Add(Me.cmbPLC)
        Me.Controls.Add(Me.UsrLbl20)
        Me.Controls.Add(Me.lbl品種)
        Me.Controls.Add(Me.UsrLbl12)
        Me.Controls.Add(Me.UsrLbl1)
        Me.Controls.Add(Me.txt指定日FR)
        Me.Controls.Add(Me.txt指定月FR)
        Me.Controls.Add(Me.UsrLbl15)
        Me.Controls.Add(Me.txt指定年FR)
        Me.Controls.Add(Me.lbl賞味期限)
        Me.Controls.Add(Me.UsrLbl10)
        Me.Controls.Add(Me.UsrLbl3)
        Me.Name = "Dlg01024_作業履歴問合せ"
        Me.Text = "作業履歴問合せ設定"
        Me.Controls.SetChildIndex(Me.UsrLbl3, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl10, 0)
        Me.Controls.SetChildIndex(Me.lbl賞味期限, 0)
        Me.Controls.SetChildIndex(Me.txt指定年FR, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl15, 0)
        Me.Controls.SetChildIndex(Me.txt指定月FR, 0)
        Me.Controls.SetChildIndex(Me.txt指定日FR, 0)
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
        Me.Controls.SetChildIndex(Me.cmbPLC, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl18, 0)
        Me.Controls.SetChildIndex(Me.txt指定時FR, 0)
        Me.Controls.SetChildIndex(Me.txt指定分FR, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl5, 0)
        Me.Controls.SetChildIndex(Me.txt指定年TO, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl4, 0)
        Me.Controls.SetChildIndex(Me.txt指定月TO, 0)
        Me.Controls.SetChildIndex(Me.txt指定日TO, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl2, 0)
        Me.Controls.SetChildIndex(Me.txt指定時TO, 0)
        Me.Controls.SetChildIndex(Me.txt指定分TO, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl6, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl品種 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl12 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl1 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl20 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt指定日FR As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt指定月FR As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl15 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt指定年FR As 共通Windowsコントロール.usrTxt
    Friend WithEvents lbl賞味期限 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl10 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents cmbPLC As 共通Windowsコントロール.usrCmb
    Friend WithEvents txt指定分FR As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt指定時FR As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl18 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt指定分TO As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt指定時TO As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl2 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt指定日TO As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt指定月TO As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl4 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt指定年TO As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl5 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl6 As 共通Windowsコントロール.usrLbl

End Class

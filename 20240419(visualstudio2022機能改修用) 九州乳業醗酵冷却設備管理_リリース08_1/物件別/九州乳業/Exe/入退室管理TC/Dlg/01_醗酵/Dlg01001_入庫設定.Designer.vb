<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dlg01001_入庫設定
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
        Me.lbl賞味期限 = New 共通Windowsコントロール.usrLbl()
        Me.lbl品種 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl9 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl10 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl11 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl12 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl6 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl1 = New 共通Windowsコントロール.usrLbl()
        Me.txt品種 = New 共通Windowsコントロール.usrTxt()
        Me.txtロットNo = New 共通Windowsコントロール.usrTxt()
        Me.txt賞味期限年 = New 共通Windowsコントロール.usrTxt()
        Me.UsrLbl15 = New 共通Windowsコントロール.usrLbl()
        Me.txt賞味期限月 = New 共通Windowsコントロール.usrTxt()
        Me.txt賞味期限日 = New 共通Windowsコントロール.usrTxt()
        Me.txt醗酵開始日 = New 共通Windowsコントロール.usrTxt()
        Me.txt醗酵開始月 = New 共通Windowsコントロール.usrTxt()
        Me.UsrLbl16 = New 共通Windowsコントロール.usrLbl()
        Me.txt醗酵開始年 = New 共通Windowsコントロール.usrTxt()
        Me.UsrLbl17 = New 共通Windowsコントロール.usrLbl()
        Me.txt醗酵開始分 = New 共通Windowsコントロール.usrTxt()
        Me.txt醗酵開始時 = New 共通Windowsコントロール.usrTxt()
        Me.UsrLbl18 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl19 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl20 = New 共通Windowsコントロール.usrLbl()
        Me.lblライン名称 = New 共通Windowsコントロール.usrLbl()
        Me.lblロットNo = New 共通Windowsコントロール.usrLbl()
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Location = New System.Drawing.Point(12, 273)
        Me.btnF1.TabIndex = 100
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(133, 273)
        Me.btnF2.Size = New System.Drawing.Size(24, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(163, 273)
        Me.btnF3.Size = New System.Drawing.Size(24, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(193, 273)
        Me.btnF4.Size = New System.Drawing.Size(24, 58)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(223, 273)
        Me.btnF5.Size = New System.Drawing.Size(24, 58)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(253, 273)
        Me.btnF6.Size = New System.Drawing.Size(24, 58)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(282, 273)
        Me.btnF7.Size = New System.Drawing.Size(24, 58)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(375, 273)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.TabIndex = 101
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & " クリア"
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(345, 273)
        Me.btnF9.Size = New System.Drawing.Size(24, 58)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(386, 273)
        Me.btnF10.Size = New System.Drawing.Size(24, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(419, 273)
        Me.btnF11.Size = New System.Drawing.Size(24, 58)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(522, 273)
        Me.btnF12.TabIndex = 102
        '
        'lbl賞味期限
        '
        Me.lbl賞味期限.AutoSize = True
        Me.lbl賞味期限.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl賞味期限.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl賞味期限.Isクリア = False
        Me.lbl賞味期限.Location = New System.Drawing.Point(261, 140)
        Me.lbl賞味期限.Name = "lbl賞味期限"
        Me.lbl賞味期限.pClearValue = ""
        Me.lbl賞味期限.pID = ""
        Me.lbl賞味期限.Size = New System.Drawing.Size(20, 19)
        Me.lbl賞味期限.TabIndex = 55
        Me.lbl賞味期限.Text = "/"
        Me.lbl賞味期限.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl賞味期限.エラー表示用項目名 = ""
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
        'UsrLbl9
        '
        Me.UsrLbl9.AutoSize = True
        Me.UsrLbl9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl9.Isクリア = False
        Me.UsrLbl9.Location = New System.Drawing.Point(175, 175)
        Me.UsrLbl9.Name = "UsrLbl9"
        Me.UsrLbl9.pClearValue = ""
        Me.UsrLbl9.pID = ""
        Me.UsrLbl9.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl9.TabIndex = 50
        Me.UsrLbl9.Text = "："
        Me.UsrLbl9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl9.エラー表示用項目名 = ""
        '
        'UsrLbl10
        '
        Me.UsrLbl10.AutoSize = True
        Me.UsrLbl10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl10.Isクリア = False
        Me.UsrLbl10.Location = New System.Drawing.Point(175, 140)
        Me.UsrLbl10.Name = "UsrLbl10"
        Me.UsrLbl10.pClearValue = ""
        Me.UsrLbl10.pID = ""
        Me.UsrLbl10.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl10.TabIndex = 49
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
        Me.UsrLbl11.TabIndex = 48
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
        Me.UsrLbl12.TabIndex = 47
        Me.UsrLbl12.Text = "："
        Me.UsrLbl12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl12.エラー表示用項目名 = ""
        '
        'UsrLbl6
        '
        Me.UsrLbl6.AutoSize = True
        Me.UsrLbl6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl6.Isクリア = False
        Me.UsrLbl6.Location = New System.Drawing.Point(40, 175)
        Me.UsrLbl6.Name = "UsrLbl6"
        Me.UsrLbl6.pClearValue = ""
        Me.UsrLbl6.pID = ""
        Me.UsrLbl6.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl6.TabIndex = 44
        Me.UsrLbl6.Text = "醗酵開始時刻"
        Me.UsrLbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl6.エラー表示用項目名 = ""
        '
        'UsrLbl3
        '
        Me.UsrLbl3.AutoSize = True
        Me.UsrLbl3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl3.Isクリア = False
        Me.UsrLbl3.Location = New System.Drawing.Point(40, 140)
        Me.UsrLbl3.Name = "UsrLbl3"
        Me.UsrLbl3.pClearValue = ""
        Me.UsrLbl3.pID = ""
        Me.UsrLbl3.Size = New System.Drawing.Size(89, 19)
        Me.UsrLbl3.TabIndex = 43
        Me.UsrLbl3.Text = "賞味期限"
        Me.UsrLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl3.エラー表示用項目名 = ""
        '
        'UsrLbl2
        '
        Me.UsrLbl2.AutoSize = True
        Me.UsrLbl2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl2.Isクリア = False
        Me.UsrLbl2.Location = New System.Drawing.Point(40, 105)
        Me.UsrLbl2.Name = "UsrLbl2"
        Me.UsrLbl2.pClearValue = ""
        Me.UsrLbl2.pID = ""
        Me.UsrLbl2.Size = New System.Drawing.Size(78, 19)
        Me.UsrLbl2.TabIndex = 42
        Me.UsrLbl2.Text = "ロットNo"
        Me.UsrLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl2.エラー表示用項目名 = ""
        '
        'UsrLbl1
        '
        Me.UsrLbl1.AutoSize = True
        Me.UsrLbl1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl1.Isクリア = False
        Me.UsrLbl1.Location = New System.Drawing.Point(40, 70)
        Me.UsrLbl1.Name = "UsrLbl1"
        Me.UsrLbl1.pClearValue = ""
        Me.UsrLbl1.pID = ""
        Me.UsrLbl1.Size = New System.Drawing.Size(49, 19)
        Me.UsrLbl1.TabIndex = 41
        Me.UsrLbl1.Text = "品種"
        Me.UsrLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl1.エラー表示用項目名 = ""
        '
        'txt品種
        '
        Me.txt品種.BackColor = System.Drawing.SystemColors.Window
        Me.txt品種.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt品種.Isクリア = True
        Me.txt品種.Location = New System.Drawing.Point(201, 67)
        Me.txt品種.MaxLength = 2
        Me.txt品種.Name = "txt品種"
        Me.txt品種.pAutoFocus = True
        Me.txt品種.pAutoPad = False
        Me.txt品種.pAutoSelect = True
        Me.txt品種.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
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
        'txtロットNo
        '
        Me.txtロットNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtロットNo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtロットNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtロットNo.Isクリア = True
        Me.txtロットNo.Location = New System.Drawing.Point(248, 102)
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
        Me.txtロットNo.pMaxByte = 3
        Me.txtロットNo.pPadWord = "0"
        Me.txtロットNo.Size = New System.Drawing.Size(44, 26)
        Me.txtロットNo.TabIndex = 2
        Me.txtロットNo.エラー表示用項目名 = ""
        '
        'txt賞味期限年
        '
        Me.txt賞味期限年.BackColor = System.Drawing.SystemColors.Window
        Me.txt賞味期限年.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt賞味期限年.Isクリア = True
        Me.txt賞味期限年.Location = New System.Drawing.Point(201, 137)
        Me.txt賞味期限年.MaxLength = 4
        Me.txt賞味期限年.Name = "txt賞味期限年"
        Me.txt賞味期限年.pAutoFocus = True
        Me.txt賞味期限年.pAutoPad = True
        Me.txt賞味期限年.pAutoSelect = True
        Me.txt賞味期限年.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt賞味期限年.pClearText = ""
        Me.txt賞味期限年.pClearValue = ""
        Me.txt賞味期限年.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt賞味期限年.pFromCtl = Nothing
        Me.txt賞味期限年.pFromToErrText = ""
        Me.txt賞味期限年.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt賞味期限年.pID = ""
        Me.txt賞味期限年.pMaxByte = 4
        Me.txt賞味期限年.pPadWord = "0"
        Me.txt賞味期限年.Size = New System.Drawing.Size(59, 26)
        Me.txt賞味期限年.TabIndex = 3
        Me.txt賞味期限年.エラー表示用項目名 = ""
        '
        'UsrLbl15
        '
        Me.UsrLbl15.AutoSize = True
        Me.UsrLbl15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl15.Isクリア = False
        Me.UsrLbl15.Location = New System.Drawing.Point(324, 140)
        Me.UsrLbl15.Name = "UsrLbl15"
        Me.UsrLbl15.pClearValue = ""
        Me.UsrLbl15.pID = ""
        Me.UsrLbl15.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl15.TabIndex = 64
        Me.UsrLbl15.Text = "/"
        Me.UsrLbl15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl15.エラー表示用項目名 = ""
        '
        'txt賞味期限月
        '
        Me.txt賞味期限月.BackColor = System.Drawing.SystemColors.Window
        Me.txt賞味期限月.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt賞味期限月.Isクリア = True
        Me.txt賞味期限月.Location = New System.Drawing.Point(282, 137)
        Me.txt賞味期限月.MaxLength = 2
        Me.txt賞味期限月.Name = "txt賞味期限月"
        Me.txt賞味期限月.pAutoFocus = True
        Me.txt賞味期限月.pAutoPad = True
        Me.txt賞味期限月.pAutoSelect = True
        Me.txt賞味期限月.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt賞味期限月.pClearText = ""
        Me.txt賞味期限月.pClearValue = ""
        Me.txt賞味期限月.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt賞味期限月.pFromCtl = Nothing
        Me.txt賞味期限月.pFromToErrText = ""
        Me.txt賞味期限月.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt賞味期限月.pID = ""
        Me.txt賞味期限月.pMaxByte = 2
        Me.txt賞味期限月.pPadWord = "0"
        Me.txt賞味期限月.Size = New System.Drawing.Size(40, 26)
        Me.txt賞味期限月.TabIndex = 4
        Me.txt賞味期限月.エラー表示用項目名 = ""
        '
        'txt賞味期限日
        '
        Me.txt賞味期限日.BackColor = System.Drawing.SystemColors.Window
        Me.txt賞味期限日.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt賞味期限日.Isクリア = True
        Me.txt賞味期限日.Location = New System.Drawing.Point(346, 137)
        Me.txt賞味期限日.MaxLength = 2
        Me.txt賞味期限日.Name = "txt賞味期限日"
        Me.txt賞味期限日.pAutoFocus = True
        Me.txt賞味期限日.pAutoPad = True
        Me.txt賞味期限日.pAutoSelect = True
        Me.txt賞味期限日.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt賞味期限日.pClearText = ""
        Me.txt賞味期限日.pClearValue = ""
        Me.txt賞味期限日.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt賞味期限日.pFromCtl = Nothing
        Me.txt賞味期限日.pFromToErrText = ""
        Me.txt賞味期限日.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt賞味期限日.pID = ""
        Me.txt賞味期限日.pMaxByte = 2
        Me.txt賞味期限日.pPadWord = "0"
        Me.txt賞味期限日.Size = New System.Drawing.Size(40, 26)
        Me.txt賞味期限日.TabIndex = 5
        Me.txt賞味期限日.エラー表示用項目名 = ""
        '
        'txt醗酵開始日
        '
        Me.txt醗酵開始日.BackColor = System.Drawing.SystemColors.Window
        Me.txt醗酵開始日.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt醗酵開始日.Isクリア = True
        Me.txt醗酵開始日.Location = New System.Drawing.Point(346, 172)
        Me.txt醗酵開始日.MaxLength = 2
        Me.txt醗酵開始日.Name = "txt醗酵開始日"
        Me.txt醗酵開始日.pAutoFocus = True
        Me.txt醗酵開始日.pAutoPad = True
        Me.txt醗酵開始日.pAutoSelect = True
        Me.txt醗酵開始日.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt醗酵開始日.pClearText = ""
        Me.txt醗酵開始日.pClearValue = ""
        Me.txt醗酵開始日.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt醗酵開始日.pFromCtl = Nothing
        Me.txt醗酵開始日.pFromToErrText = ""
        Me.txt醗酵開始日.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt醗酵開始日.pID = ""
        Me.txt醗酵開始日.pMaxByte = 2
        Me.txt醗酵開始日.pPadWord = "0"
        Me.txt醗酵開始日.Size = New System.Drawing.Size(40, 26)
        Me.txt醗酵開始日.TabIndex = 122
        Me.txt醗酵開始日.エラー表示用項目名 = ""
        '
        'txt醗酵開始月
        '
        Me.txt醗酵開始月.BackColor = System.Drawing.SystemColors.Window
        Me.txt醗酵開始月.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt醗酵開始月.Isクリア = True
        Me.txt醗酵開始月.Location = New System.Drawing.Point(282, 172)
        Me.txt醗酵開始月.MaxLength = 2
        Me.txt醗酵開始月.Name = "txt醗酵開始月"
        Me.txt醗酵開始月.pAutoFocus = True
        Me.txt醗酵開始月.pAutoPad = True
        Me.txt醗酵開始月.pAutoSelect = True
        Me.txt醗酵開始月.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt醗酵開始月.pClearText = ""
        Me.txt醗酵開始月.pClearValue = ""
        Me.txt醗酵開始月.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt醗酵開始月.pFromCtl = Nothing
        Me.txt醗酵開始月.pFromToErrText = ""
        Me.txt醗酵開始月.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt醗酵開始月.pID = ""
        Me.txt醗酵開始月.pMaxByte = 2
        Me.txt醗酵開始月.pPadWord = "0"
        Me.txt醗酵開始月.Size = New System.Drawing.Size(40, 26)
        Me.txt醗酵開始月.TabIndex = 121
        Me.txt醗酵開始月.エラー表示用項目名 = ""
        '
        'UsrLbl16
        '
        Me.UsrLbl16.AutoSize = True
        Me.UsrLbl16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl16.Isクリア = False
        Me.UsrLbl16.Location = New System.Drawing.Point(324, 175)
        Me.UsrLbl16.Name = "UsrLbl16"
        Me.UsrLbl16.pClearValue = ""
        Me.UsrLbl16.pID = ""
        Me.UsrLbl16.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl16.TabIndex = 69
        Me.UsrLbl16.Text = "/"
        Me.UsrLbl16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl16.エラー表示用項目名 = ""
        '
        'txt醗酵開始年
        '
        Me.txt醗酵開始年.BackColor = System.Drawing.SystemColors.Window
        Me.txt醗酵開始年.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt醗酵開始年.Isクリア = True
        Me.txt醗酵開始年.Location = New System.Drawing.Point(201, 172)
        Me.txt醗酵開始年.MaxLength = 4
        Me.txt醗酵開始年.Name = "txt醗酵開始年"
        Me.txt醗酵開始年.pAutoFocus = True
        Me.txt醗酵開始年.pAutoPad = True
        Me.txt醗酵開始年.pAutoSelect = True
        Me.txt醗酵開始年.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt醗酵開始年.pClearText = ""
        Me.txt醗酵開始年.pClearValue = ""
        Me.txt醗酵開始年.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt醗酵開始年.pFromCtl = Nothing
        Me.txt醗酵開始年.pFromToErrText = ""
        Me.txt醗酵開始年.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt醗酵開始年.pID = ""
        Me.txt醗酵開始年.pMaxByte = 4
        Me.txt醗酵開始年.pPadWord = "0"
        Me.txt醗酵開始年.Size = New System.Drawing.Size(59, 26)
        Me.txt醗酵開始年.TabIndex = 120
        Me.txt醗酵開始年.エラー表示用項目名 = ""
        '
        'UsrLbl17
        '
        Me.UsrLbl17.AutoSize = True
        Me.UsrLbl17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl17.Isクリア = False
        Me.UsrLbl17.Location = New System.Drawing.Point(261, 175)
        Me.UsrLbl17.Name = "UsrLbl17"
        Me.UsrLbl17.pClearValue = ""
        Me.UsrLbl17.pID = ""
        Me.UsrLbl17.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl17.TabIndex = 67
        Me.UsrLbl17.Text = "/"
        Me.UsrLbl17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl17.エラー表示用項目名 = ""
        '
        'txt醗酵開始分
        '
        Me.txt醗酵開始分.BackColor = System.Drawing.SystemColors.Window
        Me.txt醗酵開始分.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt醗酵開始分.Isクリア = True
        Me.txt醗酵開始分.Location = New System.Drawing.Point(461, 172)
        Me.txt醗酵開始分.MaxLength = 2
        Me.txt醗酵開始分.Name = "txt醗酵開始分"
        Me.txt醗酵開始分.pAutoFocus = True
        Me.txt醗酵開始分.pAutoPad = True
        Me.txt醗酵開始分.pAutoSelect = True
        Me.txt醗酵開始分.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt醗酵開始分.pClearText = ""
        Me.txt醗酵開始分.pClearValue = ""
        Me.txt醗酵開始分.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt醗酵開始分.pFromCtl = Nothing
        Me.txt醗酵開始分.pFromToErrText = ""
        Me.txt醗酵開始分.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt醗酵開始分.pID = ""
        Me.txt醗酵開始分.pMaxByte = 2
        Me.txt醗酵開始分.pPadWord = "0"
        Me.txt醗酵開始分.Size = New System.Drawing.Size(40, 26)
        Me.txt醗酵開始分.TabIndex = 10
        Me.txt醗酵開始分.エラー表示用項目名 = ""
        '
        'txt醗酵開始時
        '
        Me.txt醗酵開始時.BackColor = System.Drawing.SystemColors.Window
        Me.txt醗酵開始時.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txt醗酵開始時.Isクリア = True
        Me.txt醗酵開始時.Location = New System.Drawing.Point(403, 172)
        Me.txt醗酵開始時.MaxLength = 2
        Me.txt醗酵開始時.Name = "txt醗酵開始時"
        Me.txt醗酵開始時.pAutoFocus = True
        Me.txt醗酵開始時.pAutoPad = True
        Me.txt醗酵開始時.pAutoSelect = True
        Me.txt醗酵開始時.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.txt醗酵開始時.pClearText = ""
        Me.txt醗酵開始時.pClearValue = ""
        Me.txt醗酵開始時.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.txt醗酵開始時.pFromCtl = Nothing
        Me.txt醗酵開始時.pFromToErrText = ""
        Me.txt醗酵開始時.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.txt醗酵開始時.pID = ""
        Me.txt醗酵開始時.pMaxByte = 2
        Me.txt醗酵開始時.pPadWord = "0"
        Me.txt醗酵開始時.Size = New System.Drawing.Size(40, 26)
        Me.txt醗酵開始時.TabIndex = 9
        Me.txt醗酵開始時.エラー表示用項目名 = ""
        '
        'UsrLbl18
        '
        Me.UsrLbl18.AutoSize = True
        Me.UsrLbl18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl18.Isクリア = False
        Me.UsrLbl18.Location = New System.Drawing.Point(445, 175)
        Me.UsrLbl18.Name = "UsrLbl18"
        Me.UsrLbl18.pClearValue = ""
        Me.UsrLbl18.pID = ""
        Me.UsrLbl18.Size = New System.Drawing.Size(14, 19)
        Me.UsrLbl18.TabIndex = 72
        Me.UsrLbl18.Text = ":"
        Me.UsrLbl18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl18.エラー表示用項目名 = ""
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
        Me.UsrLbl19.Size = New System.Drawing.Size(58, 19)
        Me.UsrLbl19.TabIndex = 79
        Me.UsrLbl19.Text = "ライン"
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
        'lblライン名称
        '
        Me.lblライン名称.AutoSize = True
        Me.lblライン名称.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblライン名称.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblライン名称.Isクリア = False
        Me.lblライン名称.Location = New System.Drawing.Point(201, 35)
        Me.lblライン名称.Name = "lblライン名称"
        Me.lblライン名称.pClearValue = ""
        Me.lblライン名称.pID = ""
        Me.lblライン名称.Size = New System.Drawing.Size(87, 19)
        Me.lblライン名称.TabIndex = 81
        Me.lblライン名称.Text = "NNNNNN"
        Me.lblライン名称.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblライン名称.エラー表示用項目名 = ""
        '
        'lblロットNo
        '
        Me.lblロットNo.AutoSize = True
        Me.lblロットNo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblロットNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblロットNo.Isクリア = False
        Me.lblロットNo.Location = New System.Drawing.Point(201, 105)
        Me.lblロットNo.Name = "lblロットNo"
        Me.lblロットNo.pClearValue = ""
        Me.lblロットNo.pID = ""
        Me.lblロットNo.Size = New System.Drawing.Size(48, 19)
        Me.lblロットNo.TabIndex = 103
        Me.lblロットNo.Text = "NNN"
        Me.lblロットNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblロットNo.エラー表示用項目名 = ""
        '
        'Dlg01001_入庫設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(647, 343)
        Me.Controls.Add(Me.lblロットNo)
        Me.Controls.Add(Me.lblライン名称)
        Me.Controls.Add(Me.UsrLbl20)
        Me.Controls.Add(Me.UsrLbl19)
        Me.Controls.Add(Me.txt醗酵開始分)
        Me.Controls.Add(Me.txt醗酵開始時)
        Me.Controls.Add(Me.UsrLbl18)
        Me.Controls.Add(Me.txt醗酵開始日)
        Me.Controls.Add(Me.txt醗酵開始月)
        Me.Controls.Add(Me.UsrLbl16)
        Me.Controls.Add(Me.txt醗酵開始年)
        Me.Controls.Add(Me.UsrLbl17)
        Me.Controls.Add(Me.txt賞味期限日)
        Me.Controls.Add(Me.txt賞味期限月)
        Me.Controls.Add(Me.UsrLbl15)
        Me.Controls.Add(Me.txt賞味期限年)
        Me.Controls.Add(Me.txt品種)
        Me.Controls.Add(Me.lbl賞味期限)
        Me.Controls.Add(Me.lbl品種)
        Me.Controls.Add(Me.UsrLbl9)
        Me.Controls.Add(Me.UsrLbl10)
        Me.Controls.Add(Me.UsrLbl11)
        Me.Controls.Add(Me.UsrLbl12)
        Me.Controls.Add(Me.UsrLbl6)
        Me.Controls.Add(Me.UsrLbl3)
        Me.Controls.Add(Me.UsrLbl2)
        Me.Controls.Add(Me.UsrLbl1)
        Me.Controls.Add(Me.txtロットNo)
        Me.Name = "Dlg01001_入庫設定"
        Me.Text = "入庫登録"
        Me.Controls.SetChildIndex(Me.txtロットNo, 0)
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
        Me.Controls.SetChildIndex(Me.UsrLbl2, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl3, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl6, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl12, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl11, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl10, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl9, 0)
        Me.Controls.SetChildIndex(Me.lbl品種, 0)
        Me.Controls.SetChildIndex(Me.lbl賞味期限, 0)
        Me.Controls.SetChildIndex(Me.txt品種, 0)
        Me.Controls.SetChildIndex(Me.txt賞味期限年, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl15, 0)
        Me.Controls.SetChildIndex(Me.txt賞味期限月, 0)
        Me.Controls.SetChildIndex(Me.txt賞味期限日, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl17, 0)
        Me.Controls.SetChildIndex(Me.txt醗酵開始年, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl16, 0)
        Me.Controls.SetChildIndex(Me.txt醗酵開始月, 0)
        Me.Controls.SetChildIndex(Me.txt醗酵開始日, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl18, 0)
        Me.Controls.SetChildIndex(Me.txt醗酵開始時, 0)
        Me.Controls.SetChildIndex(Me.txt醗酵開始分, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl19, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl20, 0)
        Me.Controls.SetChildIndex(Me.lblライン名称, 0)
        Me.Controls.SetChildIndex(Me.lblロットNo, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl賞味期限 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl品種 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl9 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl10 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl11 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl12 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl6 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl2 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl1 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt品種 As 共通Windowsコントロール.usrTxt
    Friend WithEvents txtロットNo As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt賞味期限年 As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl15 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt賞味期限月 As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt賞味期限日 As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt醗酵開始日 As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt醗酵開始月 As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl16 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt醗酵開始年 As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl17 As 共通Windowsコントロール.usrLbl
    Friend WithEvents txt醗酵開始分 As 共通Windowsコントロール.usrTxt
    Friend WithEvents txt醗酵開始時 As 共通Windowsコントロール.usrTxt
    Friend WithEvents UsrLbl18 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl19 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl20 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lblライン名称 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lblロットNo As usrLbl
End Class

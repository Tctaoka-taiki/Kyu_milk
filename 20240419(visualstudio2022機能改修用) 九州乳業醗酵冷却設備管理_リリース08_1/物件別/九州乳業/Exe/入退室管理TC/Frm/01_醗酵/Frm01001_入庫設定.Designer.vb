<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm01001_入庫設定
    Inherits 入退室管理.CMdiChildFrm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.UsrLbl1 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl4 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl5 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl6 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl7 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl8 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl9 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl10 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl11 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl12 = New 共通Windowsコントロール.usrLbl()
        Me.lbl所定冷却時間 = New 共通Windowsコントロール.usrLbl()
        Me.lbl所定醗酵時間 = New 共通Windowsコントロール.usrLbl()
        Me.lbl醗酵開始時刻 = New 共通Windowsコントロール.usrLbl()
        Me.lbl賞味期限 = New 共通Windowsコントロール.usrLbl()
        Me.lblロットNo = New 共通Windowsコントロール.usrLbl()
        Me.lbl品種CD = New 共通Windowsコントロール.usrLbl()
        Me.dgvサンプル = New 共通Windowsコントロール.UsrDataGridView()
        Me.ColサンプルNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col指定数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col受入数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsrLbl15 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl16 = New 共通Windowsコントロール.usrLbl()
        Me.lblライン名称 = New 共通Windowsコントロール.usrLbl()
        Me.lbl品種名 = New 共通Windowsコントロール.usrLbl()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UsrLbl13 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl14 = New 共通Windowsコントロール.usrLbl()
        Me.lblロット完了中 = New 共通Windowsコントロール.usrLbl()
        Me.pnlメッセージ = New System.Windows.Forms.Panel()
        Me.lbl発酵終了時刻 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl18 = New 共通Windowsコントロール.usrLbl()
        Me.UsrLbl19 = New 共通Windowsコントロール.usrLbl()
        CType(Me.dgvサンプル, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlメッセージ.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(127, 551)
        Me.btnF2.Size = New System.Drawing.Size(115, 58)
        Me.btnF2.Text = "F2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "削除"
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(242, 551)
        Me.btnF3.Size = New System.Drawing.Size(115, 58)
        Me.btnF3.Text = "F3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ﾛｯﾄ完了"
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(357, 551)
        Me.btnF4.Size = New System.Drawing.Size(115, 58)
        Me.btnF4.Text = "F4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ｻﾝﾌﾟﾙ変更"
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(461, 551)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(510, 551)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(559, 551)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(608, 551)
        Me.btnF8.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(656, 551)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(705, 551)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(754, 551)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(877, 551)
        '
        'UsrLbl1
        '
        Me.UsrLbl1.AutoSize = True
        Me.UsrLbl1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl1.Isクリア = False
        Me.UsrLbl1.Location = New System.Drawing.Point(35, 70)
        Me.UsrLbl1.Name = "UsrLbl1"
        Me.UsrLbl1.pClearValue = ""
        Me.UsrLbl1.pID = ""
        Me.UsrLbl1.Size = New System.Drawing.Size(98, 19)
        Me.UsrLbl1.TabIndex = 20
        Me.UsrLbl1.Text = "品種コード"
        Me.UsrLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl1.エラー表示用項目名 = ""
        '
        'UsrLbl2
        '
        Me.UsrLbl2.AutoSize = True
        Me.UsrLbl2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl2.Isクリア = False
        Me.UsrLbl2.Location = New System.Drawing.Point(35, 140)
        Me.UsrLbl2.Name = "UsrLbl2"
        Me.UsrLbl2.pClearValue = ""
        Me.UsrLbl2.pID = ""
        Me.UsrLbl2.Size = New System.Drawing.Size(78, 19)
        Me.UsrLbl2.TabIndex = 22
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
        Me.UsrLbl3.Location = New System.Drawing.Point(35, 175)
        Me.UsrLbl3.Name = "UsrLbl3"
        Me.UsrLbl3.pClearValue = ""
        Me.UsrLbl3.pID = ""
        Me.UsrLbl3.Size = New System.Drawing.Size(89, 19)
        Me.UsrLbl3.TabIndex = 23
        Me.UsrLbl3.Text = "賞味期限"
        Me.UsrLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl3.エラー表示用項目名 = ""
        '
        'UsrLbl4
        '
        Me.UsrLbl4.AutoSize = True
        Me.UsrLbl4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl4.Isクリア = False
        Me.UsrLbl4.Location = New System.Drawing.Point(35, 280)
        Me.UsrLbl4.Name = "UsrLbl4"
        Me.UsrLbl4.pClearValue = ""
        Me.UsrLbl4.pID = ""
        Me.UsrLbl4.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl4.TabIndex = 26
        Me.UsrLbl4.Text = "所定冷却時間"
        Me.UsrLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl4.エラー表示用項目名 = ""
        '
        'UsrLbl5
        '
        Me.UsrLbl5.AutoSize = True
        Me.UsrLbl5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl5.Isクリア = False
        Me.UsrLbl5.Location = New System.Drawing.Point(35, 245)
        Me.UsrLbl5.Name = "UsrLbl5"
        Me.UsrLbl5.pClearValue = ""
        Me.UsrLbl5.pID = ""
        Me.UsrLbl5.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl5.TabIndex = 25
        Me.UsrLbl5.Text = "所定醗酵時間"
        Me.UsrLbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl5.エラー表示用項目名 = ""
        '
        'UsrLbl6
        '
        Me.UsrLbl6.AutoSize = True
        Me.UsrLbl6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl6.Isクリア = False
        Me.UsrLbl6.Location = New System.Drawing.Point(35, 210)
        Me.UsrLbl6.Name = "UsrLbl6"
        Me.UsrLbl6.pClearValue = ""
        Me.UsrLbl6.pID = ""
        Me.UsrLbl6.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl6.TabIndex = 24
        Me.UsrLbl6.Text = "醗酵開始時刻"
        Me.UsrLbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl6.エラー表示用項目名 = ""
        '
        'UsrLbl7
        '
        Me.UsrLbl7.AutoSize = True
        Me.UsrLbl7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl7.Isクリア = False
        Me.UsrLbl7.Location = New System.Drawing.Point(170, 280)
        Me.UsrLbl7.Name = "UsrLbl7"
        Me.UsrLbl7.pClearValue = ""
        Me.UsrLbl7.pID = ""
        Me.UsrLbl7.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl7.TabIndex = 32
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
        Me.UsrLbl8.Location = New System.Drawing.Point(170, 245)
        Me.UsrLbl8.Name = "UsrLbl8"
        Me.UsrLbl8.pClearValue = ""
        Me.UsrLbl8.pID = ""
        Me.UsrLbl8.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl8.TabIndex = 31
        Me.UsrLbl8.Text = "："
        Me.UsrLbl8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl8.エラー表示用項目名 = ""
        '
        'UsrLbl9
        '
        Me.UsrLbl9.AutoSize = True
        Me.UsrLbl9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl9.Isクリア = False
        Me.UsrLbl9.Location = New System.Drawing.Point(170, 210)
        Me.UsrLbl9.Name = "UsrLbl9"
        Me.UsrLbl9.pClearValue = ""
        Me.UsrLbl9.pID = ""
        Me.UsrLbl9.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl9.TabIndex = 30
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
        Me.UsrLbl10.Location = New System.Drawing.Point(170, 175)
        Me.UsrLbl10.Name = "UsrLbl10"
        Me.UsrLbl10.pClearValue = ""
        Me.UsrLbl10.pID = ""
        Me.UsrLbl10.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl10.TabIndex = 29
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
        Me.UsrLbl11.Location = New System.Drawing.Point(170, 105)
        Me.UsrLbl11.Name = "UsrLbl11"
        Me.UsrLbl11.pClearValue = ""
        Me.UsrLbl11.pID = ""
        Me.UsrLbl11.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl11.TabIndex = 28
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
        Me.UsrLbl12.Location = New System.Drawing.Point(170, 70)
        Me.UsrLbl12.Name = "UsrLbl12"
        Me.UsrLbl12.pClearValue = ""
        Me.UsrLbl12.pID = ""
        Me.UsrLbl12.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl12.TabIndex = 27
        Me.UsrLbl12.Text = "："
        Me.UsrLbl12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl12.エラー表示用項目名 = ""
        '
        'lbl所定冷却時間
        '
        Me.lbl所定冷却時間.AutoSize = True
        Me.lbl所定冷却時間.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl所定冷却時間.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl所定冷却時間.Isクリア = False
        Me.lbl所定冷却時間.Location = New System.Drawing.Point(196, 280)
        Me.lbl所定冷却時間.Name = "lbl所定冷却時間"
        Me.lbl所定冷却時間.pClearValue = ""
        Me.lbl所定冷却時間.pID = ""
        Me.lbl所定冷却時間.Size = New System.Drawing.Size(42, 19)
        Me.lbl所定冷却時間.TabIndex = 38
        Me.lbl所定冷却時間.Text = "999"
        Me.lbl所定冷却時間.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl所定冷却時間.エラー表示用項目名 = ""
        '
        'lbl所定醗酵時間
        '
        Me.lbl所定醗酵時間.AutoSize = True
        Me.lbl所定醗酵時間.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl所定醗酵時間.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl所定醗酵時間.Isクリア = False
        Me.lbl所定醗酵時間.Location = New System.Drawing.Point(196, 245)
        Me.lbl所定醗酵時間.Name = "lbl所定醗酵時間"
        Me.lbl所定醗酵時間.pClearValue = ""
        Me.lbl所定醗酵時間.pID = ""
        Me.lbl所定醗酵時間.Size = New System.Drawing.Size(42, 19)
        Me.lbl所定醗酵時間.TabIndex = 37
        Me.lbl所定醗酵時間.Text = "999"
        Me.lbl所定醗酵時間.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl所定醗酵時間.エラー表示用項目名 = ""
        '
        'lbl醗酵開始時刻
        '
        Me.lbl醗酵開始時刻.AutoSize = True
        Me.lbl醗酵開始時刻.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl醗酵開始時刻.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl醗酵開始時刻.Isクリア = False
        Me.lbl醗酵開始時刻.Location = New System.Drawing.Point(196, 210)
        Me.lbl醗酵開始時刻.Name = "lbl醗酵開始時刻"
        Me.lbl醗酵開始時刻.pClearValue = ""
        Me.lbl醗酵開始時刻.pID = ""
        Me.lbl醗酵開始時刻.Size = New System.Drawing.Size(224, 19)
        Me.lbl醗酵開始時刻.TabIndex = 36
        Me.lbl醗酵開始時刻.Text = "YYYY/MM/DD hh:mm:ss"
        Me.lbl醗酵開始時刻.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl醗酵開始時刻.エラー表示用項目名 = ""
        '
        'lbl賞味期限
        '
        Me.lbl賞味期限.AutoSize = True
        Me.lbl賞味期限.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl賞味期限.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl賞味期限.Isクリア = False
        Me.lbl賞味期限.Location = New System.Drawing.Point(196, 175)
        Me.lbl賞味期限.Name = "lbl賞味期限"
        Me.lbl賞味期限.pClearValue = ""
        Me.lbl賞味期限.pID = ""
        Me.lbl賞味期限.Size = New System.Drawing.Size(135, 19)
        Me.lbl賞味期限.TabIndex = 35
        Me.lbl賞味期限.Text = "YYYY/MM/DD"
        Me.lbl賞味期限.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl賞味期限.エラー表示用項目名 = ""
        '
        'lblロットNo
        '
        Me.lblロットNo.AutoSize = True
        Me.lblロットNo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblロットNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblロットNo.Isクリア = False
        Me.lblロットNo.Location = New System.Drawing.Point(196, 140)
        Me.lblロットNo.Name = "lblロットNo"
        Me.lblロットNo.pClearValue = ""
        Me.lblロットNo.pID = ""
        Me.lblロットNo.Size = New System.Drawing.Size(81, 19)
        Me.lblロットNo.TabIndex = 34
        Me.lblロットNo.Text = "XXXXXX"
        Me.lblロットNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblロットNo.エラー表示用項目名 = ""
        '
        'lbl品種CD
        '
        Me.lbl品種CD.AutoSize = True
        Me.lbl品種CD.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl品種CD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl品種CD.Isクリア = False
        Me.lbl品種CD.Location = New System.Drawing.Point(196, 70)
        Me.lbl品種CD.Name = "lbl品種CD"
        Me.lbl品種CD.pClearValue = ""
        Me.lbl品種CD.pID = ""
        Me.lbl品種CD.Size = New System.Drawing.Size(64, 19)
        Me.lbl品種CD.TabIndex = 33
        Me.lbl品種CD.Text = "99999"
        Me.lbl品種CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl品種CD.エラー表示用項目名 = ""
        '
        'dgvサンプル
        '
        Me.dgvサンプル.AllowUserToAddRows = False
        Me.dgvサンプル.AllowUserToDeleteRows = False
        Me.dgvサンプル.AllowUserToResizeColumns = False
        Me.dgvサンプル.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvサンプル.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvサンプル.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvサンプル.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColサンプルNo, Me.Col指定数, Me.Col受入数})
        Me.dgvサンプル.Isクリア = True
        Me.dgvサンプル.Location = New System.Drawing.Point(559, 36)
        Me.dgvサンプル.Name = "dgvサンプル"
        Me.dgvサンプル.pIs固定行表示 = False
        Me.dgvサンプル.Row = -1
        Me.dgvサンプル.RowHeadersVisible = False
        Me.dgvサンプル.RowTemplate.Height = 21
        Me.dgvサンプル.Size = New System.Drawing.Size(433, 415)
        Me.dgvサンプル.TabIndex = 41
        Me.dgvサンプル.エラー表示用項目名 = ""
        Me.dgvサンプル.件数表示ラベル = Nothing
        '
        'ColサンプルNo
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColサンプルNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColサンプルNo.HeaderText = "サンプルNo"
        Me.ColサンプルNo.Name = "ColサンプルNo"
        Me.ColサンプルNo.Width = 130
        '
        'Col指定数
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col指定数.DefaultCellStyle = DataGridViewCellStyle3
        Me.Col指定数.HeaderText = "指定数"
        Me.Col指定数.Name = "Col指定数"
        Me.Col指定数.Width = 150
        '
        'Col受入数
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col受入数.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col受入数.HeaderText = "受入数"
        Me.Col受入数.Name = "Col受入数"
        Me.Col受入数.Width = 150
        '
        'UsrLbl15
        '
        Me.UsrLbl15.AutoSize = True
        Me.UsrLbl15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl15.Isクリア = False
        Me.UsrLbl15.Location = New System.Drawing.Point(36, 36)
        Me.UsrLbl15.Name = "UsrLbl15"
        Me.UsrLbl15.pClearValue = ""
        Me.UsrLbl15.pID = ""
        Me.UsrLbl15.Size = New System.Drawing.Size(58, 19)
        Me.UsrLbl15.TabIndex = 42
        Me.UsrLbl15.Text = "ライン"
        Me.UsrLbl15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl15.エラー表示用項目名 = ""
        '
        'UsrLbl16
        '
        Me.UsrLbl16.AutoSize = True
        Me.UsrLbl16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl16.Isクリア = False
        Me.UsrLbl16.Location = New System.Drawing.Point(170, 36)
        Me.UsrLbl16.Name = "UsrLbl16"
        Me.UsrLbl16.pClearValue = ""
        Me.UsrLbl16.pID = ""
        Me.UsrLbl16.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl16.TabIndex = 43
        Me.UsrLbl16.Text = "："
        Me.UsrLbl16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl16.エラー表示用項目名 = ""
        '
        'lblライン名称
        '
        Me.lblライン名称.AutoSize = True
        Me.lblライン名称.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblライン名称.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblライン名称.Isクリア = False
        Me.lblライン名称.Location = New System.Drawing.Point(196, 36)
        Me.lblライン名称.Name = "lblライン名称"
        Me.lblライン名称.pClearValue = ""
        Me.lblライン名称.pID = ""
        Me.lblライン名称.Size = New System.Drawing.Size(64, 19)
        Me.lblライン名称.TabIndex = 44
        Me.lblライン名称.Text = "99999"
        Me.lblライン名称.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblライン名称.エラー表示用項目名 = ""
        '
        'lbl品種名
        '
        Me.lbl品種名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl品種名.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl品種名.Isクリア = False
        Me.lbl品種名.Location = New System.Drawing.Point(196, 105)
        Me.lbl品種名.Name = "lbl品種名"
        Me.lbl品種名.pClearValue = ""
        Me.lbl品種名.pID = ""
        Me.lbl品種名.Size = New System.Drawing.Size(357, 19)
        Me.lbl品種名.TabIndex = 45
        Me.lbl品種名.Text = "ああああああああああああああああああああ"
        Me.lbl品種名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl品種名.エラー表示用項目名 = ""
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'UsrLbl13
        '
        Me.UsrLbl13.AutoSize = True
        Me.UsrLbl13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl13.Isクリア = False
        Me.UsrLbl13.Location = New System.Drawing.Point(35, 105)
        Me.UsrLbl13.Name = "UsrLbl13"
        Me.UsrLbl13.pClearValue = ""
        Me.UsrLbl13.pID = ""
        Me.UsrLbl13.Size = New System.Drawing.Size(69, 19)
        Me.UsrLbl13.TabIndex = 46
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
        Me.UsrLbl14.Location = New System.Drawing.Point(170, 140)
        Me.UsrLbl14.Name = "UsrLbl14"
        Me.UsrLbl14.pClearValue = ""
        Me.UsrLbl14.pID = ""
        Me.UsrLbl14.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl14.TabIndex = 47
        Me.UsrLbl14.Text = "："
        Me.UsrLbl14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl14.エラー表示用項目名 = ""
        '
        'lblロット完了中
        '
        Me.lblロット完了中.BackColor = System.Drawing.Color.Red
        Me.lblロット完了中.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblロット完了中.ForeColor = System.Drawing.Color.White
        Me.lblロット完了中.Isクリア = False
        Me.lblロット完了中.Location = New System.Drawing.Point(14, 13)
        Me.lblロット完了中.Name = "lblロット完了中"
        Me.lblロット完了中.pClearValue = ""
        Me.lblロット完了中.pID = ""
        Me.lblロット完了中.Size = New System.Drawing.Size(445, 74)
        Me.lblロット完了中.TabIndex = 48
        Me.lblロット完了中.Text = "ロット完了中"
        Me.lblロット完了中.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblロット完了中.エラー表示用項目名 = ""
        '
        'pnlメッセージ
        '
        Me.pnlメッセージ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlメッセージ.Controls.Add(Me.lblロット完了中)
        Me.pnlメッセージ.Location = New System.Drawing.Point(304, 210)
        Me.pnlメッセージ.Name = "pnlメッセージ"
        Me.pnlメッセージ.Size = New System.Drawing.Size(475, 100)
        Me.pnlメッセージ.TabIndex = 49
        Me.pnlメッセージ.Visible = False
        '
        'lbl発酵終了時刻
        '
        Me.lbl発酵終了時刻.AutoSize = True
        Me.lbl発酵終了時刻.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl発酵終了時刻.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl発酵終了時刻.Isクリア = False
        Me.lbl発酵終了時刻.Location = New System.Drawing.Point(196, 315)
        Me.lbl発酵終了時刻.Name = "lbl発酵終了時刻"
        Me.lbl発酵終了時刻.pClearValue = ""
        Me.lbl発酵終了時刻.pID = ""
        Me.lbl発酵終了時刻.Size = New System.Drawing.Size(42, 19)
        Me.lbl発酵終了時刻.TabIndex = 52
        Me.lbl発酵終了時刻.Text = "999"
        Me.lbl発酵終了時刻.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl発酵終了時刻.エラー表示用項目名 = ""
        '
        'UsrLbl18
        '
        Me.UsrLbl18.AutoSize = True
        Me.UsrLbl18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl18.Isクリア = False
        Me.UsrLbl18.Location = New System.Drawing.Point(170, 315)
        Me.UsrLbl18.Name = "UsrLbl18"
        Me.UsrLbl18.pClearValue = ""
        Me.UsrLbl18.pID = ""
        Me.UsrLbl18.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl18.TabIndex = 51
        Me.UsrLbl18.Text = "："
        Me.UsrLbl18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl18.エラー表示用項目名 = ""
        '
        'UsrLbl19
        '
        Me.UsrLbl19.AutoSize = True
        Me.UsrLbl19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl19.Isクリア = False
        Me.UsrLbl19.Location = New System.Drawing.Point(35, 315)
        Me.UsrLbl19.Name = "UsrLbl19"
        Me.UsrLbl19.pClearValue = ""
        Me.UsrLbl19.pID = ""
        Me.UsrLbl19.Size = New System.Drawing.Size(129, 19)
        Me.UsrLbl19.TabIndex = 50
        Me.UsrLbl19.Text = "醗酵終了時刻"
        Me.UsrLbl19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl19.エラー表示用項目名 = ""
        '
        'Frm01001_入庫設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.lbl発酵終了時刻)
        Me.Controls.Add(Me.UsrLbl18)
        Me.Controls.Add(Me.UsrLbl19)
        Me.Controls.Add(Me.pnlメッセージ)
        Me.Controls.Add(Me.UsrLbl14)
        Me.Controls.Add(Me.UsrLbl13)
        Me.Controls.Add(Me.lbl品種名)
        Me.Controls.Add(Me.lblライン名称)
        Me.Controls.Add(Me.UsrLbl16)
        Me.Controls.Add(Me.UsrLbl15)
        Me.Controls.Add(Me.dgvサンプル)
        Me.Controls.Add(Me.lbl所定冷却時間)
        Me.Controls.Add(Me.lbl所定醗酵時間)
        Me.Controls.Add(Me.lbl醗酵開始時刻)
        Me.Controls.Add(Me.lbl賞味期限)
        Me.Controls.Add(Me.lblロットNo)
        Me.Controls.Add(Me.lbl品種CD)
        Me.Controls.Add(Me.UsrLbl7)
        Me.Controls.Add(Me.UsrLbl8)
        Me.Controls.Add(Me.UsrLbl9)
        Me.Controls.Add(Me.UsrLbl10)
        Me.Controls.Add(Me.UsrLbl11)
        Me.Controls.Add(Me.UsrLbl12)
        Me.Controls.Add(Me.UsrLbl4)
        Me.Controls.Add(Me.UsrLbl5)
        Me.Controls.Add(Me.UsrLbl6)
        Me.Controls.Add(Me.UsrLbl3)
        Me.Controls.Add(Me.UsrLbl2)
        Me.Controls.Add(Me.UsrLbl1)
        Me.Name = "Frm01001_入庫設定"
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl1, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl2, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl3, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl6, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl5, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl4, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl12, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl11, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl10, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl9, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl8, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl7, 0)
        Me.Controls.SetChildIndex(Me.lbl品種CD, 0)
        Me.Controls.SetChildIndex(Me.lblロットNo, 0)
        Me.Controls.SetChildIndex(Me.lbl賞味期限, 0)
        Me.Controls.SetChildIndex(Me.lbl醗酵開始時刻, 0)
        Me.Controls.SetChildIndex(Me.lbl所定醗酵時間, 0)
        Me.Controls.SetChildIndex(Me.lbl所定冷却時間, 0)
        Me.Controls.SetChildIndex(Me.dgvサンプル, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl15, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl16, 0)
        Me.Controls.SetChildIndex(Me.lblライン名称, 0)
        Me.Controls.SetChildIndex(Me.lbl品種名, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl13, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl14, 0)
        Me.Controls.SetChildIndex(Me.pnlメッセージ, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl19, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl18, 0)
        Me.Controls.SetChildIndex(Me.lbl発酵終了時刻, 0)
        CType(Me.dgvサンプル, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlメッセージ.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UsrLbl1 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl2 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl4 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl5 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl6 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl7 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl8 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl9 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl10 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl11 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl12 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl所定冷却時間 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl所定醗酵時間 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl醗酵開始時刻 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl賞味期限 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lblロットNo As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl品種CD As 共通Windowsコントロール.usrLbl
    Friend WithEvents dgvサンプル As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents UsrLbl15 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl16 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lblライン名称 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl品種名 As 共通Windowsコントロール.usrLbl
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents UsrLbl13 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl14 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lblロット完了中 As 共通Windowsコントロール.usrLbl
    Friend WithEvents pnlメッセージ As System.Windows.Forms.Panel
    Friend WithEvents ColサンプルNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col指定数 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col受入数 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl発酵終了時刻 As usrLbl
    Friend WithEvents UsrLbl18 As usrLbl
    Friend WithEvents UsrLbl19 As usrLbl
End Class

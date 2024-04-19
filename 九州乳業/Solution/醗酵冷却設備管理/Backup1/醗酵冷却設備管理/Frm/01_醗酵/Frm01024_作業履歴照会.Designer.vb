<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm01024_作業履歴照会
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lbl設備名称 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl16 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl15 = New 共通Windowsコントロール.usrLbl
        Me.lbl指定日時F = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl
        Me.dgv作業履歴 = New 共通Windowsコントロール.UsrDataGridView
        Me.lbl指定日時T = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl4 = New 共通Windowsコントロール.usrLbl
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col作業 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col日時 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColロットNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col品種名 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Colクレート数 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col倉庫温度 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgv作業履歴, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "問合せ"
        '
        'btnF2
        '
        Me.btnF2.Size = New System.Drawing.Size(115, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(254, 551)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(303, 551)
        Me.btnF4.Visible = False
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(352, 551)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(401, 551)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(450, 551)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(522, 551)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前項"
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(636, 551)
        Me.btnF9.Size = New System.Drawing.Size(115, 58)
        Me.btnF9.Text = "F9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次項"
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(750, 551)
        Me.btnF10.Size = New System.Drawing.Size(115, 58)
        Me.btnF10.Text = "F10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "印刷"
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(645, 551)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(877, 551)
        '
        'lbl設備名称
        '
        Me.lbl設備名称.AutoSize = True
        Me.lbl設備名称.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl設備名称.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl設備名称.Isクリア = False
        Me.lbl設備名称.Location = New System.Drawing.Point(91, 9)
        Me.lbl設備名称.Name = "lbl設備名称"
        Me.lbl設備名称.pClearValue = ""
        Me.lbl設備名称.pID = ""
        Me.lbl設備名称.Size = New System.Drawing.Size(64, 19)
        Me.lbl設備名称.TabIndex = 47
        Me.lbl設備名称.Text = "99999"
        Me.lbl設備名称.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl設備名称.エラー表示用項目名 = ""
        '
        'UsrLbl16
        '
        Me.UsrLbl16.AutoSize = True
        Me.UsrLbl16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl16.Isクリア = False
        Me.UsrLbl16.Location = New System.Drawing.Point(65, 9)
        Me.UsrLbl16.Name = "UsrLbl16"
        Me.UsrLbl16.pClearValue = ""
        Me.UsrLbl16.pID = ""
        Me.UsrLbl16.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl16.TabIndex = 46
        Me.UsrLbl16.Text = "："
        Me.UsrLbl16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl16.エラー表示用項目名 = ""
        '
        'UsrLbl15
        '
        Me.UsrLbl15.AutoSize = True
        Me.UsrLbl15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl15.Isクリア = False
        Me.UsrLbl15.Location = New System.Drawing.Point(12, 9)
        Me.UsrLbl15.Name = "UsrLbl15"
        Me.UsrLbl15.pClearValue = ""
        Me.UsrLbl15.pID = ""
        Me.UsrLbl15.Size = New System.Drawing.Size(49, 19)
        Me.UsrLbl15.TabIndex = 45
        Me.UsrLbl15.Text = "設備"
        Me.UsrLbl15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl15.エラー表示用項目名 = ""
        '
        'lbl指定日時F
        '
        Me.lbl指定日時F.AutoSize = True
        Me.lbl指定日時F.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl指定日時F.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl指定日時F.Isクリア = False
        Me.lbl指定日時F.Location = New System.Drawing.Point(294, 9)
        Me.lbl指定日時F.Name = "lbl指定日時F"
        Me.lbl指定日時F.pClearValue = ""
        Me.lbl指定日時F.pID = ""
        Me.lbl指定日時F.Size = New System.Drawing.Size(199, 19)
        Me.lbl指定日時F.TabIndex = 50
        Me.lbl指定日時F.Text = "YYYY/MM/DD hh:mm"
        Me.lbl指定日時F.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl指定日時F.エラー表示用項目名 = ""
        '
        'UsrLbl2
        '
        Me.UsrLbl2.AutoSize = True
        Me.UsrLbl2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl2.Isクリア = False
        Me.UsrLbl2.Location = New System.Drawing.Point(268, 9)
        Me.UsrLbl2.Name = "UsrLbl2"
        Me.UsrLbl2.pClearValue = ""
        Me.UsrLbl2.pID = ""
        Me.UsrLbl2.Size = New System.Drawing.Size(20, 19)
        Me.UsrLbl2.TabIndex = 49
        Me.UsrLbl2.Text = "："
        Me.UsrLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl2.エラー表示用項目名 = ""
        '
        'UsrLbl3
        '
        Me.UsrLbl3.AutoSize = True
        Me.UsrLbl3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl3.Isクリア = False
        Me.UsrLbl3.Location = New System.Drawing.Point(174, 9)
        Me.UsrLbl3.Name = "UsrLbl3"
        Me.UsrLbl3.pClearValue = ""
        Me.UsrLbl3.pID = ""
        Me.UsrLbl3.Size = New System.Drawing.Size(89, 19)
        Me.UsrLbl3.TabIndex = 48
        Me.UsrLbl3.Text = "指定日時"
        Me.UsrLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl3.エラー表示用項目名 = ""
        '
        'dgv作業履歴
        '
        Me.dgv作業履歴.AllowUserToAddRows = False
        Me.dgv作業履歴.AllowUserToDeleteRows = False
        Me.dgv作業履歴.AllowUserToResizeColumns = False
        Me.dgv作業履歴.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv作業履歴.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv作業履歴.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv作業履歴.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNo, Me.Col作業, Me.Col日時, Me.ColロットNo, Me.ColSNo, Me.Col品種名, Me.Colクレート数, Me.Col倉庫温度})
        Me.dgv作業履歴.Isクリア = True
        Me.dgv作業履歴.Location = New System.Drawing.Point(16, 42)
        Me.dgv作業履歴.Name = "dgv作業履歴"
        Me.dgv作業履歴.pIs固定行表示 = False
        Me.dgv作業履歴.ReadOnly = True
        Me.dgv作業履歴.Row = -1
        Me.dgv作業履歴.RowHeadersVisible = False
        Me.dgv作業履歴.RowTemplate.Height = 21
        Me.dgv作業履歴.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv作業履歴.Size = New System.Drawing.Size(980, 503)
        Me.dgv作業履歴.TabIndex = 51
        Me.dgv作業履歴.エラー表示用項目名 = ""
        Me.dgv作業履歴.件数表示ラベル = Nothing
        '
        'lbl指定日時T
        '
        Me.lbl指定日時T.AutoSize = True
        Me.lbl指定日時T.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl指定日時T.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl指定日時T.Isクリア = False
        Me.lbl指定日時T.Location = New System.Drawing.Point(534, 9)
        Me.lbl指定日時T.Name = "lbl指定日時T"
        Me.lbl指定日時T.pClearValue = ""
        Me.lbl指定日時T.pID = ""
        Me.lbl指定日時T.Size = New System.Drawing.Size(199, 19)
        Me.lbl指定日時T.TabIndex = 52
        Me.lbl指定日時T.Text = "YYYY/MM/DD hh:mm"
        Me.lbl指定日時T.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl指定日時T.エラー表示用項目名 = ""
        '
        'UsrLbl4
        '
        Me.UsrLbl4.AutoSize = True
        Me.UsrLbl4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl4.Isクリア = False
        Me.UsrLbl4.Location = New System.Drawing.Point(499, 9)
        Me.UsrLbl4.Name = "UsrLbl4"
        Me.UsrLbl4.pClearValue = ""
        Me.UsrLbl4.pID = ""
        Me.UsrLbl4.Size = New System.Drawing.Size(29, 19)
        Me.UsrLbl4.TabIndex = 53
        Me.UsrLbl4.Text = "～"
        Me.UsrLbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl4.エラー表示用項目名 = ""
        '
        'ColNo
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColNo.HeaderText = "No"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.ReadOnly = True
        Me.ColNo.Width = 80
        '
        'Col作業
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col作業.DefaultCellStyle = DataGridViewCellStyle3
        Me.Col作業.HeaderText = "作業"
        Me.Col作業.Name = "Col作業"
        Me.Col作業.ReadOnly = True
        '
        'Col日時
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col日時.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col日時.HeaderText = "時間"
        Me.Col日時.Name = "Col日時"
        Me.Col日時.ReadOnly = True
        Me.Col日時.Width = 210
        '
        'ColロットNo
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColロットNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColロットNo.HeaderText = "ロットNo"
        Me.ColロットNo.Name = "ColロットNo"
        Me.ColロットNo.ReadOnly = True
        Me.ColロットNo.Width = 110
        '
        'ColSNo
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColSNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColSNo.HeaderText = "SNo"
        Me.ColSNo.Name = "ColSNo"
        Me.ColSNo.ReadOnly = True
        Me.ColSNo.Width = 80
        '
        'Col品種名
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col品種名.DefaultCellStyle = DataGridViewCellStyle7
        Me.Col品種名.HeaderText = "品種名"
        Me.Col品種名.Name = "Col品種名"
        Me.Col品種名.ReadOnly = True
        Me.Col品種名.Width = 200
        '
        'Colクレート数
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Colクレート数.DefaultCellStyle = DataGridViewCellStyle8
        Me.Colクレート数.HeaderText = "ｸﾚｰﾄ数"
        Me.Colクレート数.Name = "Colクレート数"
        Me.Colクレート数.ReadOnly = True
        Me.Colクレート数.Width = 80
        '
        'Col倉庫温度
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col倉庫温度.DefaultCellStyle = DataGridViewCellStyle9
        Me.Col倉庫温度.HeaderText = "倉庫温度"
        Me.Col倉庫温度.Name = "Col倉庫温度"
        Me.Col倉庫温度.ReadOnly = True
        '
        'Frm01024_作業履歴照会
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.UsrLbl4)
        Me.Controls.Add(Me.lbl指定日時T)
        Me.Controls.Add(Me.dgv作業履歴)
        Me.Controls.Add(Me.lbl設備名称)
        Me.Controls.Add(Me.UsrLbl16)
        Me.Controls.Add(Me.UsrLbl3)
        Me.Controls.Add(Me.lbl指定日時F)
        Me.Controls.Add(Me.UsrLbl2)
        Me.Controls.Add(Me.UsrLbl15)
        Me.Name = "Frm01024_作業履歴照会"
        Me.Text = "メインメニュー"
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl15, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl2, 0)
        Me.Controls.SetChildIndex(Me.lbl指定日時F, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl3, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl16, 0)
        Me.Controls.SetChildIndex(Me.lbl設備名称, 0)
        Me.Controls.SetChildIndex(Me.dgv作業履歴, 0)
        Me.Controls.SetChildIndex(Me.lbl指定日時T, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl4, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        CType(Me.dgv作業履歴, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl設備名称 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl16 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl15 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl指定日時F As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl2 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents dgv作業履歴 As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents lbl指定日時T As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl4 As 共通Windowsコントロール.usrLbl
    Friend WithEvents ColNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col作業 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col日時 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColロットNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col品種名 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colクレート数 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col倉庫温度 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

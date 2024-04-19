<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm01023_温度実績問合せ
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
        Me.lbl指定日 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl
        Me.dgv温度データ = New 共通Windowsコントロール.UsrDataGridView
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col時間 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col00分 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col10分 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col20分 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col30分 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col40分 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col50分 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgv温度データ, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnF8.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(636, 551)
        Me.btnF9.Size = New System.Drawing.Size(115, 58)
        Me.btnF9.Text = "F9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次項"
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(750, 551)
        Me.btnF10.Size = New System.Drawing.Size(115, 58)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(812, 573)
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
        Me.lbl設備名称.Location = New System.Drawing.Point(133, 9)
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
        Me.UsrLbl16.Location = New System.Drawing.Point(107, 9)
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
        Me.UsrLbl15.Size = New System.Drawing.Size(89, 19)
        Me.UsrLbl15.TabIndex = 45
        Me.UsrLbl15.Text = "該当設備"
        Me.UsrLbl15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl15.エラー表示用項目名 = ""
        '
        'lbl指定日
        '
        Me.lbl指定日.AutoSize = True
        Me.lbl指定日.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl指定日.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl指定日.Isクリア = False
        Me.lbl指定日.Location = New System.Drawing.Point(516, 9)
        Me.lbl指定日.Name = "lbl指定日"
        Me.lbl指定日.pClearValue = ""
        Me.lbl指定日.pID = ""
        Me.lbl指定日.Size = New System.Drawing.Size(135, 19)
        Me.lbl指定日.TabIndex = 50
        Me.lbl指定日.Text = "YYYY/MM/DD"
        Me.lbl指定日.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl指定日.エラー表示用項目名 = ""
        '
        'UsrLbl2
        '
        Me.UsrLbl2.AutoSize = True
        Me.UsrLbl2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl2.Isクリア = False
        Me.UsrLbl2.Location = New System.Drawing.Point(490, 9)
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
        Me.UsrLbl3.Location = New System.Drawing.Point(415, 9)
        Me.UsrLbl3.Name = "UsrLbl3"
        Me.UsrLbl3.pClearValue = ""
        Me.UsrLbl3.pID = ""
        Me.UsrLbl3.Size = New System.Drawing.Size(69, 19)
        Me.UsrLbl3.TabIndex = 48
        Me.UsrLbl3.Text = "指定日"
        Me.UsrLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl3.エラー表示用項目名 = ""
        '
        'dgv温度データ
        '
        Me.dgv温度データ.AllowUserToAddRows = False
        Me.dgv温度データ.AllowUserToDeleteRows = False
        Me.dgv温度データ.AllowUserToResizeColumns = False
        Me.dgv温度データ.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv温度データ.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv温度データ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv温度データ.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNo, Me.Col時間, Me.Col00分, Me.Col10分, Me.Col20分, Me.Col30分, Me.Col40分, Me.Col50分})
        Me.dgv温度データ.Isクリア = True
        Me.dgv温度データ.Location = New System.Drawing.Point(16, 42)
        Me.dgv温度データ.Name = "dgv温度データ"
        Me.dgv温度データ.pIs固定行表示 = False
        Me.dgv温度データ.ReadOnly = True
        Me.dgv温度データ.Row = -1
        Me.dgv温度データ.RowHeadersVisible = False
        Me.dgv温度データ.RowTemplate.Height = 21
        Me.dgv温度データ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv温度データ.Size = New System.Drawing.Size(980, 503)
        Me.dgv温度データ.TabIndex = 51
        Me.dgv温度データ.エラー表示用項目名 = ""
        Me.dgv温度データ.件数表示ラベル = Nothing
        '
        'ColNo
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColNo.HeaderText = "No"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.ReadOnly = True
        Me.ColNo.Width = 50
        '
        'Col時間
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col時間.DefaultCellStyle = DataGridViewCellStyle3
        Me.Col時間.HeaderText = "時間"
        Me.Col時間.Name = "Col時間"
        Me.Col時間.ReadOnly = True
        '
        'Col00分
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col00分.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col00分.HeaderText = "00分"
        Me.Col00分.Name = "Col00分"
        Me.Col00分.ReadOnly = True
        Me.Col00分.Width = 120
        '
        'Col10分
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col10分.DefaultCellStyle = DataGridViewCellStyle5
        Me.Col10分.HeaderText = "10分"
        Me.Col10分.Name = "Col10分"
        Me.Col10分.ReadOnly = True
        Me.Col10分.Width = 120
        '
        'Col20分
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col20分.DefaultCellStyle = DataGridViewCellStyle6
        Me.Col20分.HeaderText = "20分"
        Me.Col20分.Name = "Col20分"
        Me.Col20分.ReadOnly = True
        Me.Col20分.Width = 120
        '
        'Col30分
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col30分.DefaultCellStyle = DataGridViewCellStyle7
        Me.Col30分.HeaderText = "30分"
        Me.Col30分.Name = "Col30分"
        Me.Col30分.ReadOnly = True
        Me.Col30分.Width = 120
        '
        'Col40分
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col40分.DefaultCellStyle = DataGridViewCellStyle8
        Me.Col40分.HeaderText = "40分"
        Me.Col40分.Name = "Col40分"
        Me.Col40分.ReadOnly = True
        Me.Col40分.Width = 120
        '
        'Col50分
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col50分.DefaultCellStyle = DataGridViewCellStyle9
        Me.Col50分.HeaderText = "50分"
        Me.Col50分.Name = "Col50分"
        Me.Col50分.ReadOnly = True
        Me.Col50分.Width = 120
        '
        'Frm01023_温度実績問合せ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.dgv温度データ)
        Me.Controls.Add(Me.lbl設備名称)
        Me.Controls.Add(Me.UsrLbl16)
        Me.Controls.Add(Me.UsrLbl3)
        Me.Controls.Add(Me.lbl指定日)
        Me.Controls.Add(Me.UsrLbl2)
        Me.Controls.Add(Me.UsrLbl15)
        Me.Name = "Frm01023_温度実績問合せ"
        Me.Text = "メインメニュー"
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl15, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl2, 0)
        Me.Controls.SetChildIndex(Me.lbl指定日, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl3, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl16, 0)
        Me.Controls.SetChildIndex(Me.lbl設備名称, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        Me.Controls.SetChildIndex(Me.dgv温度データ, 0)
        CType(Me.dgv温度データ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl設備名称 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl16 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl15 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lbl指定日 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl2 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents dgv温度データ As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents ColNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col時間 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col00分 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col10分 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col20分 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col30分 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col40分 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col50分 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

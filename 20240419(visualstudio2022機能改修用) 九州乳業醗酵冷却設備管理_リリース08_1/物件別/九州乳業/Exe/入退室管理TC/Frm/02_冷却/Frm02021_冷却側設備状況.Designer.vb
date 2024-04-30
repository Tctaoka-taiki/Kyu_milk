<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm00003_冷却側設備状況
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv設備状況 = New 共通Windowsコントロール.UsrDataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col設備名称 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col信号 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col荷 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col品種 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col棚番地 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col作業 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColロットNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col品番 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv設備状況, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Size = New System.Drawing.Size(137, 58)
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ﾄﾗｯｷﾝｸﾞ削除"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(368, 551)
        Me.btnF2.Size = New System.Drawing.Size(25, 58)
        Me.btnF2.Visible = False
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(399, 551)
        Me.btnF3.Size = New System.Drawing.Size(25, 58)
        Me.btnF3.Visible = False
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(430, 551)
        Me.btnF4.Size = New System.Drawing.Size(25, 58)
        Me.btnF4.Visible = False
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
        Me.btnF8.Location = New System.Drawing.Point(520, 551)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前項"
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(634, 551)
        Me.btnF9.Size = New System.Drawing.Size(115, 58)
        Me.btnF9.Text = "F9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次項"
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(755, 582)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(804, 582)
        Me.btnF11.Visible = False
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(877, 551)
        '
        'dgv設備状況
        '
        Me.dgv設備状況.AllowUserToAddRows = False
        Me.dgv設備状況.AllowUserToDeleteRows = False
        Me.dgv設備状況.AllowUserToResizeColumns = False
        Me.dgv設備状況.AllowUserToResizeRows = False
        Me.dgv設備状況.CausesValidation = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv設備状況.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv設備状況.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv設備状況.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNo, Me.Col設備名称, Me.col信号, Me.Col荷, Me.Col品種, Me.Col数, Me.ColSno, Me.Col棚番地, Me.Col作業, Me.ColロットNo, Me.Col品番})
        Me.dgv設備状況.Isクリア = True
        Me.dgv設備状況.Location = New System.Drawing.Point(12, 12)
        Me.dgv設備状況.MultiSelect = False
        Me.dgv設備状況.Name = "dgv設備状況"
        Me.dgv設備状況.pIs固定行表示 = False
        Me.dgv設備状況.ReadOnly = True
        Me.dgv設備状況.Row = -1
        Me.dgv設備状況.RowHeadersVisible = False
        Me.dgv設備状況.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgv設備状況.RowTemplate.Height = 21
        Me.dgv設備状況.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv設備状況.Size = New System.Drawing.Size(980, 529)
        Me.dgv設備状況.TabIndex = 1
        Me.dgv設備状況.エラー表示用項目名 = ""
        Me.dgv設備状況.件数表示ラベル = Nothing
        '
        'Timer1
        '
        '
        'ColNo
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColNo.HeaderText = "No"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.ReadOnly = True
        Me.ColNo.Width = 37
        '
        'Col設備名称
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col設備名称.DefaultCellStyle = DataGridViewCellStyle3
        Me.Col設備名称.HeaderText = "設備名称"
        Me.Col設備名称.Name = "Col設備名称"
        Me.Col設備名称.ReadOnly = True
        Me.Col設備名称.Width = 129
        '
        'col信号
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.col信号.DefaultCellStyle = DataGridViewCellStyle4
        Me.col信号.HeaderText = "信号"
        Me.col信号.Name = "col信号"
        Me.col信号.ReadOnly = True
        Me.col信号.Width = 64
        '
        'Col荷
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col荷.DefaultCellStyle = DataGridViewCellStyle5
        Me.Col荷.HeaderText = "荷"
        Me.Col荷.Name = "Col荷"
        Me.Col荷.ReadOnly = True
        Me.Col荷.Width = 34
        '
        'Col品種
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col品種.DefaultCellStyle = DataGridViewCellStyle6
        Me.Col品種.HeaderText = "品種名"
        Me.Col品種.Name = "Col品種"
        Me.Col品種.ReadOnly = True
        Me.Col品種.Width = 237
        '
        'Col数
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col数.DefaultCellStyle = DataGridViewCellStyle7
        Me.Col数.HeaderText = "ｸﾚｰﾄ数"
        Me.Col数.Name = "Col数"
        Me.Col数.ReadOnly = True
        Me.Col数.Width = 82
        '
        'ColSno
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColSno.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColSno.HeaderText = "SNo"
        Me.ColSno.Name = "ColSno"
        Me.ColSno.ReadOnly = True
        Me.ColSno.Width = 44
        '
        'Col棚番地
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col棚番地.DefaultCellStyle = DataGridViewCellStyle9
        Me.Col棚番地.HeaderText = "棚番地"
        Me.Col棚番地.Name = "Col棚番地"
        Me.Col棚番地.ReadOnly = True
        Me.Col棚番地.Width = 82
        '
        'Col作業
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col作業.DefaultCellStyle = DataGridViewCellStyle10
        Me.Col作業.HeaderText = "作業"
        Me.Col作業.Name = "Col作業"
        Me.Col作業.ReadOnly = True
        Me.Col作業.Width = 62
        '
        'ColロットNo
        '
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColロットNo.DefaultCellStyle = DataGridViewCellStyle11
        Me.ColロットNo.HeaderText = "ロットNo"
        Me.ColロットNo.Name = "ColロットNo"
        Me.ColロットNo.ReadOnly = True
        Me.ColロットNo.Width = 88
        '
        'Col品番
        '
        DataGridViewCellStyle12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col品番.DefaultCellStyle = DataGridViewCellStyle12
        Me.Col品番.HeaderText = "品番"
        Me.Col品番.Name = "Col品番"
        Me.Col品番.ReadOnly = True
        '
        'Frm00003_冷却側設備状況
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.dgv設備状況)
        Me.Name = "Frm00003_冷却側設備状況"
        Me.Text = "メインメニュー"
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.dgv設備状況, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        CType(Me.dgv設備状況, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv設備状況 As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ColNo As DataGridViewTextBoxColumn
    Friend WithEvents Col設備名称 As DataGridViewTextBoxColumn
    Friend WithEvents col信号 As DataGridViewTextBoxColumn
    Friend WithEvents Col荷 As DataGridViewTextBoxColumn
    Friend WithEvents Col品種 As DataGridViewTextBoxColumn
    Friend WithEvents Col数 As DataGridViewTextBoxColumn
    Friend WithEvents ColSno As DataGridViewTextBoxColumn
    Friend WithEvents Col棚番地 As DataGridViewTextBoxColumn
    Friend WithEvents Col作業 As DataGridViewTextBoxColumn
    Friend WithEvents ColロットNo As DataGridViewTextBoxColumn
    Friend WithEvents Col品番 As DataGridViewTextBoxColumn
End Class

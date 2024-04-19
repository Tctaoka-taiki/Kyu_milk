<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm02001_冷却完了出庫設定
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv生産データ = New 共通Windowsコントロール.UsrDataGridView
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColロットNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col品種 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col所定冷却時間 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col冷却経過時間 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col状況 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col出荷対象 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "出庫開始"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(126, 551)
        Me.btnF2.Size = New System.Drawing.Size(115, 58)
        Me.btnF2.Text = "F2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "出庫中断"
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
        Me.btnF8.Location = New System.Drawing.Point(499, 551)
        Me.btnF8.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(547, 551)
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(596, 551)
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
        'dgv生産データ
        '
        Me.dgv生産データ.AllowUserToAddRows = False
        Me.dgv生産データ.AllowUserToDeleteRows = False
        Me.dgv生産データ.AllowUserToResizeColumns = False
        Me.dgv生産データ.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv生産データ.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv生産データ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv生産データ.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNo, Me.ColロットNo, Me.Col品種, Me.Col所定冷却時間, Me.Col冷却経過時間, Me.Col状況, Me.Col出荷対象})
        Me.dgv生産データ.Isクリア = True
        Me.dgv生産データ.Location = New System.Drawing.Point(12, 12)
        Me.dgv生産データ.Name = "dgv生産データ"
        Me.dgv生産データ.pIs固定行表示 = False
        Me.dgv生産データ.ReadOnly = True
        Me.dgv生産データ.Row = -1
        Me.dgv生産データ.RowHeadersVisible = False
        Me.dgv生産データ.RowTemplate.Height = 21
        Me.dgv生産データ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv生産データ.Size = New System.Drawing.Size(980, 533)
        Me.dgv生産データ.TabIndex = 41
        Me.dgv生産データ.エラー表示用項目名 = ""
        Me.dgv生産データ.件数表示ラベル = Nothing
        '
        'Timer1
        '
        Me.Timer1.Interval = 15000
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
        'ColロットNo
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColロットNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColロットNo.HeaderText = "ﾛｯﾄNo"
        Me.ColロットNo.Name = "ColロットNo"
        Me.ColロットNo.ReadOnly = True
        Me.ColロットNo.Width = 85
        '
        'Col品種
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col品種.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col品種.HeaderText = "品種名"
        Me.Col品種.Name = "Col品種"
        Me.Col品種.ReadOnly = True
        Me.Col品種.Width = 318
        '
        'Col所定冷却時間
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col所定冷却時間.DefaultCellStyle = DataGridViewCellStyle5
        Me.Col所定冷却時間.HeaderText = "所定冷却時間"
        Me.Col所定冷却時間.Name = "Col所定冷却時間"
        Me.Col所定冷却時間.ReadOnly = True
        Me.Col所定冷却時間.Width = 165
        '
        'Col冷却経過時間
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col冷却経過時間.DefaultCellStyle = DataGridViewCellStyle6
        Me.Col冷却経過時間.HeaderText = "冷却経過時間"
        Me.Col冷却経過時間.Name = "Col冷却経過時間"
        Me.Col冷却経過時間.ReadOnly = True
        Me.Col冷却経過時間.Width = 165
        '
        'Col状況
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col状況.DefaultCellStyle = DataGridViewCellStyle7
        Me.Col状況.HeaderText = "状況"
        Me.Col状況.Name = "Col状況"
        Me.Col状況.ReadOnly = True
        Me.Col状況.Width = 170
        '
        'Col出荷対象
        '
        Me.Col出荷対象.HeaderText = "出荷対象"
        Me.Col出荷対象.Name = "Col出荷対象"
        Me.Col出荷対象.ReadOnly = True
        Me.Col出荷対象.Visible = False
        Me.Col出荷対象.Width = 200
        '
        'Frm02001_冷却完了出庫設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.dgv生産データ)
        Me.Name = "Frm02001_冷却完了出庫設定"
        Me.Text = "メインメニュー"
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.dgv生産データ, 0)
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv生産データ As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ColNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColロットNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col品種 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col所定冷却時間 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col冷却経過時間 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col状況 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col出荷対象 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

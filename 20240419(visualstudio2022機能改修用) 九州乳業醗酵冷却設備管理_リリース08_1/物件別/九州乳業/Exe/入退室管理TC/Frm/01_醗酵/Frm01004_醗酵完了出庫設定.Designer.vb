<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm01004_醗酵完了出庫設定
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
        Me.dgv生産データ = New 共通Windowsコントロール.UsrDataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColロットNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColサンプルNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col品種名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col所定醗酵時間 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col醗酵経過時間 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col状況 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col棚数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col総クレート数 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "出庫開始"
        '
        'btnF2
        '
        Me.btnF2.Location = New System.Drawing.Point(127, 551)
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
        Me.btnF8.Location = New System.Drawing.Point(520, 551)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前項"
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(635, 551)
        Me.btnF9.Size = New System.Drawing.Size(115, 58)
        Me.btnF9.Text = "F9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次項"
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(785, 551)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(828, 551)
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
        Me.dgv生産データ.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNo, Me.ColロットNo, Me.ColサンプルNo, Me.Col品種名, Me.Col所定醗酵時間, Me.Col醗酵経過時間, Me.Col状況, Me.Col棚数, Me.Col総クレート数})
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
        Me.ColNo.Width = 30
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
        'ColサンプルNo
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColサンプルNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColサンプルNo.HeaderText = "SNo"
        Me.ColサンプルNo.Name = "ColサンプルNo"
        Me.ColサンプルNo.ReadOnly = True
        Me.ColサンプルNo.Width = 40
        '
        'Col品種名
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col品種名.DefaultCellStyle = DataGridViewCellStyle5
        Me.Col品種名.HeaderText = "品種名"
        Me.Col品種名.Name = "Col品種名"
        Me.Col品種名.ReadOnly = True
        Me.Col品種名.Width = 268
        '
        'Col所定醗酵時間
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col所定醗酵時間.DefaultCellStyle = DataGridViewCellStyle6
        Me.Col所定醗酵時間.HeaderText = "所定醗酵時間"
        Me.Col所定醗酵時間.Name = "Col所定醗酵時間"
        Me.Col所定醗酵時間.ReadOnly = True
        Me.Col所定醗酵時間.Width = 125
        '
        'Col醗酵経過時間
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col醗酵経過時間.DefaultCellStyle = DataGridViewCellStyle7
        Me.Col醗酵経過時間.HeaderText = "醗酵経過時間"
        Me.Col醗酵経過時間.Name = "Col醗酵経過時間"
        Me.Col醗酵経過時間.ReadOnly = True
        Me.Col醗酵経過時間.Width = 125
        '
        'Col状況
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col状況.DefaultCellStyle = DataGridViewCellStyle8
        Me.Col状況.HeaderText = "状況"
        Me.Col状況.Name = "Col状況"
        Me.Col状況.ReadOnly = True
        Me.Col状況.Width = 90
        '
        'Col棚数
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col棚数.DefaultCellStyle = DataGridViewCellStyle9
        Me.Col棚数.FillWeight = 80.0!
        Me.Col棚数.HeaderText = "棚数"
        Me.Col棚数.Name = "Col棚数"
        Me.Col棚数.ReadOnly = True
        Me.Col棚数.Width = 70
        '
        'Col総クレート数
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col総クレート数.DefaultCellStyle = DataGridViewCellStyle10
        Me.Col総クレート数.FillWeight = 80.0!
        Me.Col総クレート数.HeaderText = "総クレート数"
        Me.Col総クレート数.Name = "Col総クレート数"
        Me.Col総クレート数.ReadOnly = True
        Me.Col総クレート数.Width = 125
        '
        'Frm01004_醗酵完了出庫設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.dgv生産データ)
        Me.Name = "Frm01004_醗酵完了出庫設定"
        Me.Text = "メインメニュー"
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.dgv生産データ, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv生産データ As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ColNo As DataGridViewTextBoxColumn
    Friend WithEvents ColロットNo As DataGridViewTextBoxColumn
    Friend WithEvents ColサンプルNo As DataGridViewTextBoxColumn
    Friend WithEvents Col品種名 As DataGridViewTextBoxColumn
    Friend WithEvents Col所定醗酵時間 As DataGridViewTextBoxColumn
    Friend WithEvents Col醗酵経過時間 As DataGridViewTextBoxColumn
    Friend WithEvents Col状況 As DataGridViewTextBoxColumn
    Friend WithEvents Col棚数 As DataGridViewTextBoxColumn
    Friend WithEvents Col総クレート数 As DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class _Frm01005_醗酵棚指定出庫設定
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv生産データ = New 共通Windowsコントロール.UsrDataGridView
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col棚番地 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColロットNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColサンプルNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col品種 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col状況 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録"
        '
        'btnF2
        '
        Me.btnF2.Size = New System.Drawing.Size(115, 58)
        Me.btnF2.Text = "F2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "削除"
        '
        'btnF3
        '
        Me.btnF3.Location = New System.Drawing.Point(254, 551)
        Me.btnF3.Size = New System.Drawing.Size(115, 58)
        Me.btnF3.Text = "F3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "開始"
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(375, 551)
        Me.btnF4.Size = New System.Drawing.Size(115, 58)
        Me.btnF4.Text = "F4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "中断"
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(494, 551)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(543, 551)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(592, 551)
        Me.btnF7.Visible = False
        '
        'btnF8
        '
        Me.btnF8.Location = New System.Drawing.Point(608, 551)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前項"
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(729, 551)
        Me.btnF9.Size = New System.Drawing.Size(115, 58)
        Me.btnF9.Text = "F9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次項"
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(738, 551)
        Me.btnF10.Visible = False
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(787, 551)
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
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv生産データ.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgv生産データ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv生産データ.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNo, Me.Col棚番地, Me.ColロットNo, Me.ColサンプルNo, Me.Col品種, Me.Col状況})
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
        'ColNo
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColNo.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColNo.HeaderText = "No"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.ReadOnly = True
        Me.ColNo.Width = 50
        '
        'Col棚番地
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col棚番地.DefaultCellStyle = DataGridViewCellStyle10
        Me.Col棚番地.HeaderText = "棚番地"
        Me.Col棚番地.Name = "Col棚番地"
        Me.Col棚番地.ReadOnly = True
        Me.Col棚番地.Width = 85
        '
        'ColロットNo
        '
        DataGridViewCellStyle11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColロットNo.DefaultCellStyle = DataGridViewCellStyle11
        Me.ColロットNo.HeaderText = "ﾛｯﾄNo"
        Me.ColロットNo.Name = "ColロットNo"
        Me.ColロットNo.ReadOnly = True
        Me.ColロットNo.Width = 78
        '
        'ColサンプルNo
        '
        DataGridViewCellStyle12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColサンプルNo.DefaultCellStyle = DataGridViewCellStyle12
        Me.ColサンプルNo.HeaderText = "SNo"
        Me.ColサンプルNo.Name = "ColサンプルNo"
        Me.ColサンプルNo.ReadOnly = True
        Me.ColサンプルNo.Width = 50
        '
        'Col品種
        '
        DataGridViewCellStyle13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col品種.DefaultCellStyle = DataGridViewCellStyle13
        Me.Col品種.HeaderText = "品種名"
        Me.Col品種.Name = "Col品種"
        Me.Col品種.ReadOnly = True
        Me.Col品種.Width = 330
        '
        'Col状況
        '
        DataGridViewCellStyle14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col状況.DefaultCellStyle = DataGridViewCellStyle14
        Me.Col状況.HeaderText = "状況"
        Me.Col状況.Name = "Col状況"
        Me.Col状況.ReadOnly = True
        Me.Col状況.Width = 360
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'Frm01005_醗酵棚指定出庫設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.dgv生産データ)
        Me.Name = "Frm01005_醗酵棚指定出庫設定"
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
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.dgv生産データ, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv生産データ As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ColNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col棚番地 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColロットNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColサンプルNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col品種 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col状況 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

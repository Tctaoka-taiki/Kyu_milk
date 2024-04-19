<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm01013_醗酵棚問合せメンテナンス
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv生産データ = New 共通Windowsコントロール.UsrDataGridView
        Me.Col棚番地 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColロットNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColサンプルNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col品種名 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col賞味期限 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col状況 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col開始時刻 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col所定醗酵時間 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col醗酵経過時間 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnF1
        '
        Me.btnF1.Text = "F1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "登録"
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
        Me.btnF3.Text = "F3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "修正"
        '
        'btnF4
        '
        Me.btnF4.Location = New System.Drawing.Point(357, 551)
        Me.btnF4.Size = New System.Drawing.Size(115, 58)
        Me.btnF4.Text = "F4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "禁止棚"
        '
        'btnF5
        '
        Me.btnF5.Location = New System.Drawing.Point(500, 551)
        Me.btnF5.Visible = False
        '
        'btnF6
        '
        Me.btnF6.Location = New System.Drawing.Point(549, 551)
        Me.btnF6.Visible = False
        '
        'btnF7
        '
        Me.btnF7.Location = New System.Drawing.Point(598, 551)
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
        Me.btnF10.Location = New System.Drawing.Point(750, 551)
        Me.btnF10.Size = New System.Drawing.Size(115, 58)
        Me.btnF10.Text = "F10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "印刷"
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(793, 551)
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv生産データ.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv生産データ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv生産データ.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col棚番地, Me.ColロットNo, Me.ColサンプルNo, Me.Col品種名, Me.Col賞味期限, Me.Col状況, Me.Col開始時刻, Me.Col所定醗酵時間, Me.Col醗酵経過時間})
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
        'Col棚番地
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col棚番地.DefaultCellStyle = DataGridViewCellStyle2
        Me.Col棚番地.HeaderText = "棚番地"
        Me.Col棚番地.Name = "Col棚番地"
        Me.Col棚番地.ReadOnly = True
        Me.Col棚番地.Width = 85
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
        Me.ColサンプルNo.Width = 50
        '
        'Col品種名
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col品種名.DefaultCellStyle = DataGridViewCellStyle5
        Me.Col品種名.HeaderText = "品種名"
        Me.Col品種名.Name = "Col品種名"
        Me.Col品種名.ReadOnly = True
        Me.Col品種名.Width = 141
        '
        'Col賞味期限
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col賞味期限.DefaultCellStyle = DataGridViewCellStyle6
        Me.Col賞味期限.HeaderText = "賞味期限"
        Me.Col賞味期限.Name = "Col賞味期限"
        Me.Col賞味期限.ReadOnly = True
        Me.Col賞味期限.Width = 135
        '
        'Col状況
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col状況.DefaultCellStyle = DataGridViewCellStyle7
        Me.Col状況.HeaderText = "ｸﾚｰﾄ数"
        Me.Col状況.Name = "Col状況"
        Me.Col状況.ReadOnly = True
        Me.Col状況.Width = 78
        '
        'Col開始時刻
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col開始時刻.DefaultCellStyle = DataGridViewCellStyle8
        Me.Col開始時刻.HeaderText = "醗酵開始時刻"
        Me.Col開始時刻.Name = "Col開始時刻"
        Me.Col開始時刻.ReadOnly = True
        Me.Col開始時刻.Width = 205
        '
        'Col所定醗酵時間
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col所定醗酵時間.DefaultCellStyle = DataGridViewCellStyle9
        Me.Col所定醗酵時間.HeaderText = "所定時間"
        Me.Col所定醗酵時間.Name = "Col所定醗酵時間"
        Me.Col所定醗酵時間.ReadOnly = True
        Me.Col所定醗酵時間.Width = 90
        '
        'Col醗酵経過時間
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col醗酵経過時間.DefaultCellStyle = DataGridViewCellStyle10
        Me.Col醗酵経過時間.HeaderText = "経過時間"
        Me.Col醗酵経過時間.Name = "Col醗酵経過時間"
        Me.Col醗酵経過時間.ReadOnly = True
        Me.Col醗酵経過時間.Width = 90
        '
        'Frm01013_醗酵棚問合せメンテナンス
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.dgv生産データ)
        Me.Name = "Frm01013_醗酵棚問合せメンテナンス"
        Me.Text = "メインメニュー"
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.dgv生産データ, 0)
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv生産データ As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents Col棚番地 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColロットNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColサンプルNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col品種名 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col賞味期限 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col状況 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col開始時刻 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col所定醗酵時間 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col醗酵経過時間 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

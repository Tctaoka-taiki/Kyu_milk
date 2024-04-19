<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm01014_醗酵在庫問合せ
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
        Me.dgv生産データ = New 共通Windowsコントロール.UsrDataGridView
        Me.lbl品種名 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl16 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl15 = New 共通Windowsコントロール.usrLbl
        Me.lblロットNo = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl
        Me.ColNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColロットNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColサンプルNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col品種名 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Colロケ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col状況 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col所定醗酵時間 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col醗酵経過時間 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnF8.Location = New System.Drawing.Point(520, 551)
        Me.btnF8.Size = New System.Drawing.Size(115, 58)
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "前項"
        Me.btnF8.Visible = False
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(634, 551)
        Me.btnF9.Size = New System.Drawing.Size(115, 58)
        Me.btnF9.Text = "F9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "次項"
        Me.btnF9.Visible = False
        '
        'btnF10
        '
        Me.btnF10.Location = New System.Drawing.Point(748, 551)
        Me.btnF10.Size = New System.Drawing.Size(115, 58)
        Me.btnF10.Text = "F10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "印刷"
        '
        'btnF11
        '
        Me.btnF11.Location = New System.Drawing.Point(691, 593)
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
        Me.dgv生産データ.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNo, Me.ColロットNo, Me.ColサンプルNo, Me.Col品種名, Me.Colロケ, Me.Col状況, Me.Col所定醗酵時間, Me.Col醗酵経過時間})
        Me.dgv生産データ.Isクリア = True
        Me.dgv生産データ.Location = New System.Drawing.Point(12, 42)
        Me.dgv生産データ.Name = "dgv生産データ"
        Me.dgv生産データ.pIs固定行表示 = False
        Me.dgv生産データ.ReadOnly = True
        Me.dgv生産データ.Row = -1
        Me.dgv生産データ.RowHeadersVisible = False
        Me.dgv生産データ.RowTemplate.Height = 21
        Me.dgv生産データ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv生産データ.Size = New System.Drawing.Size(980, 503)
        Me.dgv生産データ.TabIndex = 41
        Me.dgv生産データ.エラー表示用項目名 = ""
        Me.dgv生産データ.件数表示ラベル = Nothing
        '
        'lbl品種名
        '
        Me.lbl品種名.AutoSize = True
        Me.lbl品種名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl品種名.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl品種名.Isクリア = False
        Me.lbl品種名.Location = New System.Drawing.Point(129, 9)
        Me.lbl品種名.Name = "lbl品種名"
        Me.lbl品種名.pClearValue = ""
        Me.lbl品種名.pID = ""
        Me.lbl品種名.Size = New System.Drawing.Size(64, 19)
        Me.lbl品種名.TabIndex = 47
        Me.lbl品種名.Text = "99999"
        Me.lbl品種名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl品種名.エラー表示用項目名 = ""
        '
        'UsrLbl16
        '
        Me.UsrLbl16.AutoSize = True
        Me.UsrLbl16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl16.Isクリア = False
        Me.UsrLbl16.Location = New System.Drawing.Point(103, 9)
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
        Me.UsrLbl15.Size = New System.Drawing.Size(69, 19)
        Me.UsrLbl15.TabIndex = 45
        Me.UsrLbl15.Text = "品種名"
        Me.UsrLbl15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl15.エラー表示用項目名 = ""
        '
        'lblロットNo
        '
        Me.lblロットNo.AutoSize = True
        Me.lblロットNo.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblロットNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblロットNo.Isクリア = False
        Me.lblロットNo.Location = New System.Drawing.Point(532, 9)
        Me.lblロットNo.Name = "lblロットNo"
        Me.lblロットNo.pClearValue = ""
        Me.lblロットNo.pID = ""
        Me.lblロットNo.Size = New System.Drawing.Size(64, 19)
        Me.lblロットNo.TabIndex = 50
        Me.lblロットNo.Text = "99999"
        Me.lblロットNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblロットNo.エラー表示用項目名 = ""
        '
        'UsrLbl2
        '
        Me.UsrLbl2.AutoSize = True
        Me.UsrLbl2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UsrLbl2.Isクリア = False
        Me.UsrLbl2.Location = New System.Drawing.Point(506, 9)
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
        Me.UsrLbl3.Size = New System.Drawing.Size(78, 19)
        Me.UsrLbl3.TabIndex = 48
        Me.UsrLbl3.Text = "ロットNo"
        Me.UsrLbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsrLbl3.エラー表示用項目名 = ""
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
        Me.Col品種名.Width = 298
        '
        'Colロケ
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Colロケ.DefaultCellStyle = DataGridViewCellStyle6
        Me.Colロケ.HeaderText = "棚番地"
        Me.Colロケ.Name = "Colロケ"
        Me.Colロケ.ReadOnly = True
        Me.Colロケ.Width = 85
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
        'Col所定醗酵時間
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col所定醗酵時間.DefaultCellStyle = DataGridViewCellStyle8
        Me.Col所定醗酵時間.HeaderText = "所定醗酵時間"
        Me.Col所定醗酵時間.Name = "Col所定醗酵時間"
        Me.Col所定醗酵時間.ReadOnly = True
        Me.Col所定醗酵時間.Width = 155
        '
        'Col醗酵経過時間
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col醗酵経過時間.DefaultCellStyle = DataGridViewCellStyle9
        Me.Col醗酵経過時間.HeaderText = "醗酵経過時間"
        Me.Col醗酵経過時間.Name = "Col醗酵経過時間"
        Me.Col醗酵経過時間.ReadOnly = True
        Me.Col醗酵経過時間.Width = 155
        '
        'Frm01014_醗酵在庫問合せ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.lbl品種名)
        Me.Controls.Add(Me.UsrLbl16)
        Me.Controls.Add(Me.lblロットNo)
        Me.Controls.Add(Me.UsrLbl2)
        Me.Controls.Add(Me.UsrLbl3)
        Me.Controls.Add(Me.UsrLbl15)
        Me.Controls.Add(Me.dgv生産データ)
        Me.Name = "Frm01014_醗酵在庫問合せ"
        Me.Text = "メインメニュー"
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.dgv生産データ, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl15, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl3, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl2, 0)
        Me.Controls.SetChildIndex(Me.lblロットNo, 0)
        Me.Controls.SetChildIndex(Me.UsrLbl16, 0)
        Me.Controls.SetChildIndex(Me.lbl品種名, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv生産データ As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents lbl品種名 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl16 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl15 As 共通Windowsコントロール.usrLbl
    Friend WithEvents lblロットNo As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl2 As 共通Windowsコントロール.usrLbl
    Friend WithEvents UsrLbl3 As 共通Windowsコントロール.usrLbl
    Friend WithEvents ColNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColロットNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColサンプルNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col品種名 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colロケ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col状況 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col所定醗酵時間 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col醗酵経過時間 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm01011_醗酵マスター設定
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgv生産データ = New 共通Windowsコントロール.UsrDataGridView
        Me.ColロットNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColサンプルNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col品種名 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Col賞味期限 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmb製品区分 = New 共通Windowsコントロール.usrCmb
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
        Me.btnF4.Location = New System.Drawing.Point(375, 551)
        Me.btnF4.Size = New System.Drawing.Size(115, 58)
        Me.btnF4.Visible = False
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
        Me.btnF8.Text = "F8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "製品切替"
        '
        'btnF9
        '
        Me.btnF9.Location = New System.Drawing.Point(729, 551)
        Me.btnF9.Visible = False
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
        Me.dgv生産データ.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColロットNo, Me.ColサンプルNo, Me.Col品種名, Me.Col賞味期限})
        Me.dgv生産データ.Isクリア = True
        Me.dgv生産データ.Location = New System.Drawing.Point(12, 45)
        Me.dgv生産データ.Name = "dgv生産データ"
        Me.dgv生産データ.pIs固定行表示 = False
        Me.dgv生産データ.ReadOnly = True
        Me.dgv生産データ.Row = -1
        Me.dgv生産データ.RowHeadersVisible = False
        Me.dgv生産データ.RowTemplate.Height = 21
        Me.dgv生産データ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv生産データ.Size = New System.Drawing.Size(980, 500)
        Me.dgv生産データ.TabIndex = 41
        Me.dgv生産データ.エラー表示用項目名 = ""
        Me.dgv生産データ.件数表示ラベル = Nothing
        '
        'ColロットNo
        '
        DataGridViewCellStyle19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColロットNo.DefaultCellStyle = DataGridViewCellStyle19
        Me.ColロットNo.HeaderText = "品種CD"
        Me.ColロットNo.Name = "ColロットNo"
        Me.ColロットNo.ReadOnly = True
        Me.ColロットNo.Width = 120
        '
        'ColサンプルNo
        '
        DataGridViewCellStyle20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.ColサンプルNo.DefaultCellStyle = DataGridViewCellStyle20
        Me.ColサンプルNo.HeaderText = "品種名"
        Me.ColサンプルNo.Name = "ColサンプルNo"
        Me.ColサンプルNo.ReadOnly = True
        Me.ColサンプルNo.Width = 330
        '
        'Col品種名
        '
        DataGridViewCellStyle21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col品種名.DefaultCellStyle = DataGridViewCellStyle21
        Me.Col品種名.HeaderText = "所定発酵時間"
        Me.Col品種名.Name = "Col品種名"
        Me.Col品種名.ReadOnly = True
        Me.Col品種名.Width = 250
        '
        'Col賞味期限
        '
        DataGridViewCellStyle22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Col賞味期限.DefaultCellStyle = DataGridViewCellStyle22
        Me.Col賞味期限.HeaderText = "所定冷却時間"
        Me.Col賞味期限.Name = "Col賞味期限"
        Me.Col賞味期限.ReadOnly = True
        Me.Col賞味期限.Width = 250
        '
        'cmb製品区分
        '
        Me.cmb製品区分.BackColor = System.Drawing.SystemColors.Window
        Me.cmb製品区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb製品区分.DropDownWidth = 276
        Me.cmb製品区分.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold)
        Me.cmb製品区分.FormattingEnabled = True
        Me.cmb製品区分.Isクリア = True
        Me.cmb製品区分.Items.AddRange(New Object() {"ハード", "プレーン"})
        Me.cmb製品区分.Location = New System.Drawing.Point(12, 12)
        Me.cmb製品区分.Name = "cmb製品区分"
        Me.cmb製品区分.pAutoFocus = True
        Me.cmb製品区分.pAutoSelect = True
        Me.cmb製品区分.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.cmb製品区分.pClearIndex = -1
        Me.cmb製品区分.pClearValue = ""
        Me.cmb製品区分.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Nomal
        Me.cmb製品区分.pFromCtl = Nothing
        Me.cmb製品区分.pFromToErrText = ""
        Me.cmb製品区分.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.cmb製品区分.pID = ""
        Me.cmb製品区分.pMaxByte = 0
        Me.cmb製品区分.Size = New System.Drawing.Size(276, 27)
        Me.cmb製品区分.TabIndex = 42
        Me.cmb製品区分.エラー表示用項目名 = ""
        '
        'Frm01011_醗酵マスター設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 652)
        Me.Controls.Add(Me.cmb製品区分)
        Me.Controls.Add(Me.dgv生産データ)
        Me.Name = "Frm01011_醗酵マスター設定"
        Me.Text = "メインメニュー"
        Me.Controls.SetChildIndex(Me.btnF1, 0)
        Me.Controls.SetChildIndex(Me.btnF2, 0)
        Me.Controls.SetChildIndex(Me.btnF3, 0)
        Me.Controls.SetChildIndex(Me.btnF4, 0)
        Me.Controls.SetChildIndex(Me.btnF5, 0)
        Me.Controls.SetChildIndex(Me.btnF6, 0)
        Me.Controls.SetChildIndex(Me.btnF9, 0)
        Me.Controls.SetChildIndex(Me.btnF7, 0)
        Me.Controls.SetChildIndex(Me.btnF11, 0)
        Me.Controls.SetChildIndex(Me.btnF12, 0)
        Me.Controls.SetChildIndex(Me.btnF10, 0)
        Me.Controls.SetChildIndex(Me.dgv生産データ, 0)
        Me.Controls.SetChildIndex(Me.cmb製品区分, 0)
        Me.Controls.SetChildIndex(Me.btnF8, 0)
        CType(Me.dgv生産データ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv生産データ As 共通Windowsコントロール.UsrDataGridView
    Friend WithEvents cmb製品区分 As 共通Windowsコントロール.usrCmb
    Friend WithEvents ColロットNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColサンプルNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col品種名 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col賞味期限 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

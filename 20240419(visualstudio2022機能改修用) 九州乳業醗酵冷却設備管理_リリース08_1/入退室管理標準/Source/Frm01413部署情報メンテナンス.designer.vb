<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm01413部署情報メンテナンス
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
        Me.btnマスタメンテメニュー = New 共通Windowsコントロール.usrBtn
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Lbl件数 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl1 = New 共通Windowsコントロール.usrLbl
        Me.UsrDataGridView1 = New 共通Windowsコントロール.UsrDataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.btn削除 = New 共通Windowsコントロール.usrBtn
        Me.btn変更 = New 共通Windowsコントロール.usrBtn
        Me.btn追加 = New 共通Windowsコントロール.usrBtn
        Me.BtnCSV出力 = New 共通Windowsコントロール.usrBtn
        Me.GroupBox6.SuspendLayout()
        CType(Me.UsrDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnマスタメンテメニュー
        '
        Me.btnマスタメンテメニュー.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnマスタメンテメニュー.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnマスタメンテメニュー.Location = New System.Drawing.Point(783, 601)
        Me.btnマスタメンテメニュー.Name = "btnマスタメンテメニュー"
        Me.btnマスタメンテメニュー.pFuncKey = "F12"
        Me.btnマスタメンテメニュー.Size = New System.Drawing.Size(75, 50)
        Me.btnマスタメンテメニュー.TabIndex = 5
        Me.btnマスタメンテメニュー.Text = "F12 戻る"
        Me.btnマスタメンテメニュー.UseVisualStyleBackColor = True
        Me.btnマスタメンテメニュー.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Lbl件数)
        Me.GroupBox6.Controls.Add(Me.UsrLbl1)
        Me.GroupBox6.Controls.Add(Me.UsrDataGridView1)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(853, 583)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "クラス情報一覧"
        '
        'Lbl件数
        '
        Me.Lbl件数.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl件数.AutoSize = True
        Me.Lbl件数.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Lbl件数.Isクリア = True
        Me.Lbl件数.Location = New System.Drawing.Point(805, 33)
        Me.Lbl件数.Name = "Lbl件数"
        Me.Lbl件数.pClearValue = "-----"
        Me.Lbl件数.pID = ""
        Me.Lbl件数.Size = New System.Drawing.Size(42, 13)
        Me.Lbl件数.TabIndex = 6
        Me.Lbl件数.Text = "-----"
        Me.Lbl件数.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Lbl件数.エラー表示用項目名 = ""
        '
        'UsrLbl1
        '
        Me.UsrLbl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsrLbl1.AutoSize = True
        Me.UsrLbl1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl1.Isクリア = False
        Me.UsrLbl1.Location = New System.Drawing.Point(755, 33)
        Me.UsrLbl1.Name = "UsrLbl1"
        Me.UsrLbl1.pClearValue = ""
        Me.UsrLbl1.pID = ""
        Me.UsrLbl1.Size = New System.Drawing.Size(44, 13)
        Me.UsrLbl1.TabIndex = 5
        Me.UsrLbl1.Text = "件数 : "
        Me.UsrLbl1.エラー表示用項目名 = ""
        '
        'UsrDataGridView1
        '
        Me.UsrDataGridView1.AllowUserToAddRows = False
        Me.UsrDataGridView1.AllowUserToDeleteRows = False
        Me.UsrDataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsrDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UsrDataGridView1.Isクリア = True
        Me.UsrDataGridView1.Location = New System.Drawing.Point(7, 49)
        Me.UsrDataGridView1.MultiSelect = False
        Me.UsrDataGridView1.Name = "UsrDataGridView1"
        Me.UsrDataGridView1.pIs固定行表示 = False
        Me.UsrDataGridView1.ReadOnly = True
        Me.UsrDataGridView1.Row = -1
        Me.UsrDataGridView1.RowTemplate.Height = 21
        Me.UsrDataGridView1.Size = New System.Drawing.Size(840, 528)
        Me.UsrDataGridView1.TabIndex = 2
        Me.UsrDataGridView1.エラー表示用項目名 = ""
        Me.UsrDataGridView1.件数表示ラベル = Me.Lbl件数
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(960, 497)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "登録企業名一覧情報"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(960, 497)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "登録企業名一覧情報"
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(960, 497)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "登録企業名一覧情報"
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(960, 497)
        Me.GroupBox5.TabIndex = 27
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "登録企業名一覧情報"
        '
        'btn削除
        '
        Me.btn削除.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn削除.Location = New System.Drawing.Point(227, 601)
        Me.btn削除.Name = "btn削除"
        Me.btn削除.pFuncKey = "F4"
        Me.btn削除.Size = New System.Drawing.Size(75, 50)
        Me.btn削除.TabIndex = 3
        Me.btn削除.Text = "F4 削除"
        Me.btn削除.UseVisualStyleBackColor = True
        '
        'btn変更
        '
        Me.btn変更.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn変更.Location = New System.Drawing.Point(79, 601)
        Me.btn変更.Name = "btn変更"
        Me.btn変更.pFuncKey = "F2"
        Me.btn変更.Size = New System.Drawing.Size(75, 50)
        Me.btn変更.TabIndex = 1
        Me.btn変更.Text = "F2 変更"
        Me.btn変更.UseVisualStyleBackColor = True
        '
        'btn追加
        '
        Me.btn追加.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn追加.Location = New System.Drawing.Point(153, 601)
        Me.btn追加.Name = "btn追加"
        Me.btn追加.pFuncKey = "F3"
        Me.btn追加.Size = New System.Drawing.Size(75, 50)
        Me.btn追加.TabIndex = 2
        Me.btn追加.Text = "F3 追加"
        Me.btn追加.UseVisualStyleBackColor = True
        '
        'BtnCSV出力
        '
        Me.BtnCSV出力.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCSV出力.Location = New System.Drawing.Point(473, 601)
        Me.BtnCSV出力.Name = "BtnCSV出力"
        Me.BtnCSV出力.pFuncKey = "F8"
        Me.BtnCSV出力.Size = New System.Drawing.Size(77, 50)
        Me.BtnCSV出力.TabIndex = 4
        Me.BtnCSV出力.Text = "F8 CSV出力"
        Me.BtnCSV出力.UseVisualStyleBackColor = True
        '
        'Frm01413部署情報メンテナンス
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(865, 652)
        Me.Controls.Add(Me.btn削除)
        Me.Controls.Add(Me.btn変更)
        Me.Controls.Add(Me.btn追加)
        Me.Controls.Add(Me.BtnCSV出力)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnマスタメンテメニュー)
        Me.Name = "Frm01413部署情報メンテナンス"
        Me.Text = "クラス情報メンテナンス"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.UsrDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnマスタメンテメニュー As usrBtn
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents UsrDataGridView1 As UsrDataGridView
    Friend WithEvents Lbl件数 As usrLbl
    Friend WithEvents UsrLbl1 As usrLbl
    Friend WithEvents btn削除 As 共通Windowsコントロール.usrBtn
    Friend WithEvents btn変更 As 共通Windowsコントロール.usrBtn
    Friend WithEvents btn追加 As 共通Windowsコントロール.usrBtn
    Friend WithEvents BtnCSV出力 As 共通Windowsコントロール.usrBtn

End Class

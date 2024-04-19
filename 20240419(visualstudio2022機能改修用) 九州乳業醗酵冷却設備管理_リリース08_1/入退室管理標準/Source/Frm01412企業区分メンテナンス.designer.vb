<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0142企業区分メンテナンス
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
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Lbl件数 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl1 = New 共通Windowsコントロール.usrLbl
        Me.UsrDataGridView企業区分 = New 共通Windowsコントロール.UsrDataGridView
        Me.BtnCSV出力 = New 共通Windowsコントロール.usrBtn
        Me.btn変更 = New 共通Windowsコントロール.usrBtn
        Me.btn追加 = New 共通Windowsコントロール.usrBtn
        Me.btn削除 = New 共通Windowsコントロール.usrBtn
        Me.GroupBox8.SuspendLayout()
        CType(Me.UsrDataGridView企業区分, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnマスタメンテメニュー.TabIndex = 6
        Me.btnマスタメンテメニュー.Text = "F12 戻る"
        Me.btnマスタメンテメニュー.UseVisualStyleBackColor = True
        Me.btnマスタメンテメニュー.Visible = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.Controls.Add(Me.Lbl件数)
        Me.GroupBox8.Controls.Add(Me.UsrLbl1)
        Me.GroupBox8.Controls.Add(Me.UsrDataGridView企業区分)
        Me.GroupBox8.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(853, 583)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "大区分情報一覧"
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
        Me.Lbl件数.TabIndex = 4
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
        Me.UsrLbl1.TabIndex = 3
        Me.UsrLbl1.Text = "件数 : "
        Me.UsrLbl1.エラー表示用項目名 = ""
        '
        'UsrDataGridView企業区分
        '
        Me.UsrDataGridView企業区分.AllowUserToAddRows = False
        Me.UsrDataGridView企業区分.AllowUserToDeleteRows = False
        Me.UsrDataGridView企業区分.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsrDataGridView企業区分.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UsrDataGridView企業区分.Isクリア = True
        Me.UsrDataGridView企業区分.Location = New System.Drawing.Point(7, 49)
        Me.UsrDataGridView企業区分.MultiSelect = False
        Me.UsrDataGridView企業区分.Name = "UsrDataGridView企業区分"
        Me.UsrDataGridView企業区分.pIs固定行表示 = False
        Me.UsrDataGridView企業区分.ReadOnly = True
        Me.UsrDataGridView企業区分.Row = -1
        Me.UsrDataGridView企業区分.RowTemplate.Height = 21
        Me.UsrDataGridView企業区分.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UsrDataGridView企業区分.Size = New System.Drawing.Size(840, 528)
        Me.UsrDataGridView企業区分.TabIndex = 2
        Me.UsrDataGridView企業区分.エラー表示用項目名 = ""
        Me.UsrDataGridView企業区分.件数表示ラベル = Me.Lbl件数
        '
        'BtnCSV出力
        '
        Me.BtnCSV出力.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnCSV出力.Location = New System.Drawing.Point(227, 601)
        Me.BtnCSV出力.Name = "BtnCSV出力"
        Me.BtnCSV出力.pFuncKey = "F8"
        Me.BtnCSV出力.Size = New System.Drawing.Size(75, 50)
        Me.BtnCSV出力.TabIndex = 5
        Me.BtnCSV出力.Text = "F8 CSV出力"
        Me.BtnCSV出力.UseVisualStyleBackColor = True
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
        'Frm0142企業区分メンテナンス
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(865, 652)
        Me.Controls.Add(Me.btn削除)
        Me.Controls.Add(Me.btn追加)
        Me.Controls.Add(Me.btn変更)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.btnマスタメンテメニュー)
        Me.Controls.Add(Me.BtnCSV出力)
        Me.Name = "Frm0142企業区分メンテナンス"
        Me.Text = "大区分情報メンテナンス"
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.UsrDataGridView企業区分, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnマスタメンテメニュー As usrBtn
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents UsrDataGridView企業区分 As UsrDataGridView
    Friend WithEvents Lbl件数 As usrLbl
    Friend WithEvents UsrLbl1 As usrLbl
    Friend WithEvents BtnCSV出力 As 共通Windowsコントロール.usrBtn
    Friend WithEvents btn変更 As 共通Windowsコントロール.usrBtn
    Friend WithEvents btn追加 As 共通Windowsコントロール.usrBtn
    Friend WithEvents btn削除 As 共通Windowsコントロール.usrBtn

End Class

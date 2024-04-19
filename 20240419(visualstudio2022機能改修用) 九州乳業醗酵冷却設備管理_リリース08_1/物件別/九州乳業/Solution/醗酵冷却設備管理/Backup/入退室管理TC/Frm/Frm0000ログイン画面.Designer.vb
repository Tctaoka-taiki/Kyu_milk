<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0000ログイン画面
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.UsrLbl1 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl
        Me.UsrLbl3 = New 共通Windowsコントロール.usrLbl
        Me.LblNAME = New 共通Windowsコントロール.usrLbl
        Me.TxtCODE = New 共通Windowsコントロール.usrTxt
        Me.btnログイン = New 共通Windowsコントロール.usrBtn
        Me.Usr終了 = New 共通Windowsコントロール.usrBtn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtPASS = New 共通Windowsコントロール.usrTxt
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(246, 71)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(512, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'UsrLbl1
        '
        Me.UsrLbl1.AutoSize = True
        Me.UsrLbl1.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl1.Isクリア = False
        Me.UsrLbl1.Location = New System.Drawing.Point(39, 37)
        Me.UsrLbl1.Name = "UsrLbl1"
        Me.UsrLbl1.pClearValue = ""
        Me.UsrLbl1.pID = ""
        Me.UsrLbl1.Size = New System.Drawing.Size(85, 15)
        Me.UsrLbl1.TabIndex = 1
        Me.UsrLbl1.Text = "管理者コード"
        Me.UsrLbl1.エラー表示用項目名 = ""
        '
        'UsrLbl2
        '
        Me.UsrLbl2.AutoSize = True
        Me.UsrLbl2.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl2.Isクリア = False
        Me.UsrLbl2.Location = New System.Drawing.Point(39, 65)
        Me.UsrLbl2.Name = "UsrLbl2"
        Me.UsrLbl2.pClearValue = ""
        Me.UsrLbl2.pID = ""
        Me.UsrLbl2.Size = New System.Drawing.Size(67, 15)
        Me.UsrLbl2.TabIndex = 2
        Me.UsrLbl2.Text = "管理者名"
        Me.UsrLbl2.エラー表示用項目名 = ""
        '
        'UsrLbl3
        '
        Me.UsrLbl3.AutoSize = True
        Me.UsrLbl3.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl3.Isクリア = False
        Me.UsrLbl3.Location = New System.Drawing.Point(39, 92)
        Me.UsrLbl3.Name = "UsrLbl3"
        Me.UsrLbl3.pClearValue = ""
        Me.UsrLbl3.pID = ""
        Me.UsrLbl3.Size = New System.Drawing.Size(64, 15)
        Me.UsrLbl3.TabIndex = 3
        Me.UsrLbl3.Text = "パスワード"
        Me.UsrLbl3.エラー表示用項目名 = ""
        '
        'LblNAME
        '
        Me.LblNAME.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LblNAME.Isクリア = False
        Me.LblNAME.Location = New System.Drawing.Point(219, 62)
        Me.LblNAME.Name = "LblNAME"
        Me.LblNAME.pClearValue = ""
        Me.LblNAME.pID = ""
        Me.LblNAME.Size = New System.Drawing.Size(120, 21)
        Me.LblNAME.TabIndex = 4
        Me.LblNAME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblNAME.エラー表示用項目名 = ""
        '
        'TxtCODE
        '
        Me.TxtCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtCODE.Enabled = False
        Me.TxtCODE.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TxtCODE.Isクリア = True
        Me.TxtCODE.Location = New System.Drawing.Point(219, 34)
        Me.TxtCODE.Name = "TxtCODE"
        Me.TxtCODE.pAutoFocus = False
        Me.TxtCODE.pAutoSelect = False
        Me.TxtCODE.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.NumLetter
        Me.TxtCODE.pClearText = Nothing
        Me.TxtCODE.pClearValue = Nothing
        Me.TxtCODE.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Hissu
        Me.TxtCODE.pFromCtl = Nothing
        Me.TxtCODE.pFromToErrText = Nothing
        Me.TxtCODE.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.TxtCODE.pID = ""
        Me.TxtCODE.pMaxByte = 6
        Me.TxtCODE.Size = New System.Drawing.Size(120, 22)
        Me.TxtCODE.TabIndex = 1
        Me.TxtCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtCODE.エラー表示用項目名 = Nothing
        '
        'btnログイン
        '
        Me.btnログイン.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnログイン.Location = New System.Drawing.Point(369, 131)
        Me.btnログイン.Name = "btnログイン"
        Me.btnログイン.pFuncKey = Nothing
        Me.btnログイン.Size = New System.Drawing.Size(87, 50)
        Me.btnログイン.TabIndex = 6
        Me.btnログイン.Text = "ログイン"
        Me.btnログイン.UseVisualStyleBackColor = True
        '
        'Usr終了
        '
        Me.Usr終了.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Usr終了.Location = New System.Drawing.Point(505, 362)
        Me.Usr終了.Name = "Usr終了"
        Me.Usr終了.pFuncKey = Nothing
        Me.Usr終了.Size = New System.Drawing.Size(228, 53)
        Me.Usr終了.TabIndex = 3
        Me.Usr終了.Text = "システム終了"
        Me.Usr終了.UseVisualStyleBackColor = True
        Me.Usr終了.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPASS)
        Me.GroupBox1.Controls.Add(Me.TxtCODE)
        Me.GroupBox1.Controls.Add(Me.btnログイン)
        Me.GroupBox1.Controls.Add(Me.UsrLbl1)
        Me.GroupBox1.Controls.Add(Me.UsrLbl2)
        Me.GroupBox1.Controls.Add(Me.UsrLbl3)
        Me.GroupBox1.Controls.Add(Me.LblNAME)
        Me.GroupBox1.Location = New System.Drawing.Point(271, 169)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(462, 187)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'TxtPASS
        '
        Me.TxtPASS.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPASS.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.TxtPASS.Isクリア = True
        Me.TxtPASS.Location = New System.Drawing.Point(219, 89)
        Me.TxtPASS.Name = "TxtPASS"
        Me.TxtPASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.TxtPASS.pAutoFocus = False
        Me.TxtPASS.pAutoSelect = False
        Me.TxtPASS.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.NumLetter
        Me.TxtPASS.pClearText = Nothing
        Me.TxtPASS.pClearValue = Nothing
        Me.TxtPASS.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Hissu
        Me.TxtPASS.pFromCtl = Nothing
        Me.TxtPASS.pFromToErrText = Nothing
        Me.TxtPASS.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.TxtPASS.pID = ""
        Me.TxtPASS.pMaxByte = 6
        Me.TxtPASS.Size = New System.Drawing.Size(120, 22)
        Me.TxtPASS.TabIndex = 5
        Me.TxtPASS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtPASS.エラー表示用項目名 = Nothing
        '
        'Frm0000ログイン画面
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 674)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Usr終了)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Frm0000ログイン画面"
        Me.ShowInTaskbar = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents UsrLbl1 As usrLbl
    Friend WithEvents UsrLbl2 As usrLbl
    Friend WithEvents UsrLbl3 As usrLbl
    Friend WithEvents LblNAME As usrLbl
    Friend WithEvents TxtCODE As usrTxt
    Friend WithEvents btnログイン As usrBtn
    Friend WithEvents Usr終了 As usrBtn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPASS As usrTxt

End Class

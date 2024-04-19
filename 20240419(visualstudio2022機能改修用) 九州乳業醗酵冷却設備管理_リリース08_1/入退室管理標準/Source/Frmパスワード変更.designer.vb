<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmパスワード変更
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Txt変更後パスワード = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl6 = New 共通Windowsコントロール.usrLbl
        Me.Txt変更前パスワード = New 共通Windowsコントロール.usrTxt
        Me.UsrLbl2 = New 共通Windowsコントロール.usrLbl
        Me.btnメニュー = New 共通Windowsコントロール.usrBtn
        Me.btnクリア = New 共通Windowsコントロール.usrBtn
        Me.btn変更 = New 共通Windowsコントロール.usrBtn
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Txt変更後パスワード)
        Me.GroupBox1.Controls.Add(Me.UsrLbl6)
        Me.GroupBox1.Controls.Add(Me.Txt変更前パスワード)
        Me.GroupBox1.Controls.Add(Me.UsrLbl2)
        Me.GroupBox1.Location = New System.Drawing.Point(113, 121)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 387)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Txt変更後パスワード
        '
        Me.Txt変更後パスワード.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt変更後パスワード.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt変更後パスワード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Txt変更後パスワード.Isクリア = True
        Me.Txt変更後パスワード.Location = New System.Drawing.Point(343, 184)
        Me.Txt変更後パスワード.Name = "Txt変更後パスワード"
        Me.Txt変更後パスワード.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Txt変更後パスワード.pAutoFocus = False
        Me.Txt変更後パスワード.pAutoSelect = False
        Me.Txt変更後パスワード.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.Txt変更後パスワード.pClearText = Nothing
        Me.Txt変更後パスワード.pClearValue = Nothing
        Me.Txt変更後パスワード.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Hissu
        Me.Txt変更後パスワード.pFromCtl = Nothing
        Me.Txt変更後パスワード.pFromToErrText = Nothing
        Me.Txt変更後パスワード.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.Txt変更後パスワード.pID = ""
        Me.Txt変更後パスワード.pMaxByte = 0
        Me.Txt変更後パスワード.Size = New System.Drawing.Size(178, 22)
        Me.Txt変更後パスワード.TabIndex = 1
        Me.Txt変更後パスワード.エラー表示用項目名 = Nothing
        '
        'UsrLbl6
        '
        Me.UsrLbl6.AutoSize = True
        Me.UsrLbl6.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl6.Isクリア = False
        Me.UsrLbl6.Location = New System.Drawing.Point(224, 190)
        Me.UsrLbl6.Name = "UsrLbl6"
        Me.UsrLbl6.pClearValue = ""
        Me.UsrLbl6.pID = ""
        Me.UsrLbl6.Size = New System.Drawing.Size(113, 12)
        Me.UsrLbl6.TabIndex = 78
        Me.UsrLbl6.Text = "変更後パスワード："
        Me.UsrLbl6.エラー表示用項目名 = ""
        '
        'Txt変更前パスワード
        '
        Me.Txt変更前パスワード.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Txt変更前パスワード.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Txt変更前パスワード.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Txt変更前パスワード.Isクリア = True
        Me.Txt変更前パスワード.Location = New System.Drawing.Point(343, 154)
        Me.Txt変更前パスワード.Name = "Txt変更前パスワード"
        Me.Txt変更前パスワード.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.Txt変更前パスワード.pAutoFocus = False
        Me.Txt変更前パスワード.pAutoSelect = False
        Me.Txt変更前パスワード.pCharType = 共通Windowsコントロール.MCtl.gEnmCharType.All
        Me.Txt変更前パスワード.pClearText = Nothing
        Me.Txt変更前パスワード.pClearValue = Nothing
        Me.Txt変更前パスワード.pCondition = 共通Windowsコントロール.MCtl.gEnm入力条件.Hissu
        Me.Txt変更前パスワード.pFromCtl = Nothing
        Me.Txt変更前パスワード.pFromToErrText = Nothing
        Me.Txt変更前パスワード.pFromToSearch = 共通Windowsコントロール.MCtl.gEnmFromTo.None
        Me.Txt変更前パスワード.pID = ""
        Me.Txt変更前パスワード.pMaxByte = 0
        Me.Txt変更前パスワード.Size = New System.Drawing.Size(178, 22)
        Me.Txt変更前パスワード.TabIndex = 0
        Me.Txt変更前パスワード.エラー表示用項目名 = Nothing
        '
        'UsrLbl2
        '
        Me.UsrLbl2.AutoSize = True
        Me.UsrLbl2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.UsrLbl2.Isクリア = False
        Me.UsrLbl2.Location = New System.Drawing.Point(224, 160)
        Me.UsrLbl2.Name = "UsrLbl2"
        Me.UsrLbl2.pClearValue = ""
        Me.UsrLbl2.pID = ""
        Me.UsrLbl2.Size = New System.Drawing.Size(113, 12)
        Me.UsrLbl2.TabIndex = 77
        Me.UsrLbl2.Text = "変更前パスワード："
        Me.UsrLbl2.エラー表示用項目名 = ""
        '
        'btnメニュー
        '
        Me.btnメニュー.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnメニュー.Location = New System.Drawing.Point(783, 601)
        Me.btnメニュー.Name = "btnメニュー"
        Me.btnメニュー.pFuncKey = "F12"
        Me.btnメニュー.Size = New System.Drawing.Size(75, 50)
        Me.btnメニュー.TabIndex = 8
        Me.btnメニュー.Text = "F12 戻る"
        Me.btnメニュー.UseVisualStyleBackColor = True
        '
        'btnクリア
        '
        Me.btnクリア.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnクリア.Location = New System.Drawing.Point(521, 601)
        Me.btnクリア.Name = "btnクリア"
        Me.btnクリア.pFuncKey = "F9"
        Me.btnクリア.Size = New System.Drawing.Size(75, 50)
        Me.btnクリア.TabIndex = 6
        Me.btnクリア.Text = "F9 クリア"
        Me.btnクリア.UseVisualStyleBackColor = True
        '
        'btn変更
        '
        Me.btn変更.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn変更.Location = New System.Drawing.Point(197, 601)
        Me.btn変更.Name = "btn変更"
        Me.btn変更.pFuncKey = "F5"
        Me.btn変更.Size = New System.Drawing.Size(75, 50)
        Me.btn変更.TabIndex = 5
        Me.btn変更.Text = "F5 変更" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn変更.UseVisualStyleBackColor = True
        '
        'Frmパスワード変更
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(865, 652)
        Me.Controls.Add(Me.btnクリア)
        Me.Controls.Add(Me.btnメニュー)
        Me.Controls.Add(Me.btn変更)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Frmパスワード変更"
        Me.Text = "パスワード変更"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnメニュー As usrBtn
    Friend WithEvents Txt変更後パスワード As usrTxt
    Friend WithEvents UsrLbl6 As usrLbl
    Friend WithEvents Txt変更前パスワード As usrTxt
    Friend WithEvents UsrLbl2 As usrLbl
    Friend WithEvents btnクリア As usrBtn
    Friend WithEvents btn変更 As 共通Windowsコントロール.usrBtn

End Class

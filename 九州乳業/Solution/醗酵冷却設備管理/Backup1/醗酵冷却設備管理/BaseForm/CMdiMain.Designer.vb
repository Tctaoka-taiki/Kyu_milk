<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CMdiMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer
    Friend WithEvents tmrNow As System.Windows.Forms.Timer
    Friend WithEvents Menuメニュー As System.Windows.Forms.MenuStrip


    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CMdiMain))
        Me.tmrNow = New System.Windows.Forms.Timer(Me.components)
        Me.Menuメニュー = New System.Windows.Forms.MenuStrip
        Me.システムToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.メニュー切替ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblBottom = New System.Windows.Forms.Label
        Me.lbl現在時刻 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbl画面タイトル = New 共通Windowsコントロール.usrLbl
        Me.Timerシリアル通信状況監視 = New System.Windows.Forms.Timer(Me.components)
        Me.UCシリアルポート醗酵 = New 入退室管理.UCシリアルポート
        Me.UCシリアルポート冷却 = New 入退室管理.UCシリアルポート
        Me.Menuメニュー.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrNow
        '
        '
        'Menuメニュー
        '
        Me.Menuメニュー.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Menuメニュー.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.システムToolStripMenuItem})
        Me.Menuメニュー.Location = New System.Drawing.Point(0, 0)
        Me.Menuメニュー.Name = "Menuメニュー"
        Me.Menuメニュー.Size = New System.Drawing.Size(1016, 26)
        Me.Menuメニュー.TabIndex = 2
        Me.Menuメニュー.Text = "MenuStrip1"
        '
        'システムToolStripMenuItem
        '
        Me.システムToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.メニュー切替ToolStripMenuItem})
        Me.システムToolStripMenuItem.Name = "システムToolStripMenuItem"
        Me.システムToolStripMenuItem.Size = New System.Drawing.Size(68, 22)
        Me.システムToolStripMenuItem.Text = "システム"
        '
        'メニュー切替ToolStripMenuItem
        '
        Me.メニュー切替ToolStripMenuItem.Name = "メニュー切替ToolStripMenuItem"
        Me.メニュー切替ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.メニュー切替ToolStripMenuItem.Text = "メニュー切替"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBottom.Controls.Add(Me.SplitContainer1)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 707)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(1016, 27)
        Me.pnlBottom.TabIndex = 18
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblBottom)
        Me.SplitContainer1.Panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lbl現在時刻)
        Me.SplitContainer1.Size = New System.Drawing.Size(1012, 23)
        Me.SplitContainer1.SplitterDistance = 650
        Me.SplitContainer1.TabIndex = 3
        '
        'lblBottom
        '
        Me.lblBottom.AutoSize = True
        Me.lblBottom.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblBottom.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblBottom.Location = New System.Drawing.Point(0, 0)
        Me.lblBottom.Name = "lblBottom"
        Me.lblBottom.Size = New System.Drawing.Size(0, 15)
        Me.lblBottom.TabIndex = 2
        Me.lblBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl現在時刻
        '
        Me.lbl現在時刻.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl現在時刻.Location = New System.Drawing.Point(53, 4)
        Me.lbl現在時刻.Name = "lbl現在時刻"
        Me.lbl現在時刻.Size = New System.Drawing.Size(302, 16)
        Me.lbl現在時刻.TabIndex = 0
        Me.lbl現在時刻.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.lbl画面タイトル)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1016, 51)
        Me.Panel1.TabIndex = 20
        '
        'lbl画面タイトル
        '
        Me.lbl画面タイトル.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl画面タイトル.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl画面タイトル.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl画面タイトル.ForeColor = System.Drawing.Color.White
        Me.lbl画面タイトル.Isクリア = False
        Me.lbl画面タイトル.Location = New System.Drawing.Point(4, 4)
        Me.lbl画面タイトル.Name = "lbl画面タイトル"
        Me.lbl画面タイトル.pClearValue = ""
        Me.lbl画面タイトル.pID = ""
        Me.lbl画面タイトル.Size = New System.Drawing.Size(1009, 46)
        Me.lbl画面タイトル.TabIndex = 0
        Me.lbl画面タイトル.Text = "NNNNNNNNNNNNNNNNNN"
        Me.lbl画面タイトル.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl画面タイトル.エラー表示用項目名 = ""
        '
        'Timerシリアル通信状況監視
        '
        Me.Timerシリアル通信状況監視.Interval = 3000
        '
        'UCシリアルポート醗酵
        '
        Me.UCシリアルポート醗酵.pRcvStatus = "0"
        Me.UCシリアルポート醗酵.pRCV文字列 = ""
        Me.UCシリアルポート醗酵.pSEND文字列 = ""
        Me.UCシリアルポート醗酵.pポートID = "1"
        Me.UCシリアルポート醗酵.p受信状態 = False
        '
        'UCシリアルポート冷却
        '
        Me.UCシリアルポート冷却.pRcvStatus = "0"
        Me.UCシリアルポート冷却.pRCV文字列 = ""
        Me.UCシリアルポート冷却.pSEND文字列 = ""
        Me.UCシリアルポート冷却.pポートID = "2"
        Me.UCシリアルポート冷却.p受信状態 = False
        '
        'CMdiMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.Menuメニュー)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.Menuメニュー
        Me.MaximizeBox = False
        Me.Name = "CMdiMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.Menuメニュー.ResumeLayout(False)
        Me.Menuメニュー.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lbl現在時刻 As System.Windows.Forms.Label
    Friend WithEvents lblBottom As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Timerシリアル通信状況監視 As System.Windows.Forms.Timer
    Friend WithEvents UCシリアルポート醗酵 As 入退室管理.UCシリアルポート
    Friend WithEvents UCシリアルポート冷却 As 入退室管理.UCシリアルポート
    Friend WithEvents lbl画面タイトル As 共通Windowsコントロール.usrLbl
    Friend WithEvents システムToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents メニュー切替ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

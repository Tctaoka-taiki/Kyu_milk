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
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.リーダーライター接続ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BluePorter起動ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmシステム終了 = New System.Windows.Forms.ToolStripMenuItem
        Me.編集ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsm切り取り = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmコピー = New System.Windows.Forms.ToolStripMenuItem
        Me.tsm貼り付け = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowsListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsm重ねて表示 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsm並べて表示 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsm上下に並べて表示 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsm左右に並べて表示 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsm画面を閉じる = New System.Windows.Forms.ToolStripMenuItem
        Me.tsm全て閉じる = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ヘルプToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmヘルプ = New System.Windows.Forms.ToolStripMenuItem
        Me.データ更新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.セキュリティデータ転送ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lblBottom = New System.Windows.Forms.Label
        Me.lbl現在時刻 = New System.Windows.Forms.Label
        Me.TSBtn画面印刷 = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Menuメニュー.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrNow
        '
        '
        'Menuメニュー
        '
        Me.Menuメニュー.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Menuメニュー.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.編集ToolStripMenuItem, Me.WindowsListToolStripMenuItem, Me.ヘルプToolStripMenuItem, Me.データ更新ToolStripMenuItem})
        Me.Menuメニュー.Location = New System.Drawing.Point(0, 0)
        Me.Menuメニュー.Name = "Menuメニュー"
        Me.Menuメニュー.Size = New System.Drawing.Size(1016, 24)
        Me.Menuメニュー.TabIndex = 2
        Me.Menuメニュー.Text = "MenuStrip1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.リーダーライター接続ToolStripMenuItem, Me.BluePorter起動ToolStripMenuItem, Me.tsmシステム終了})
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(55, 20)
        Me.ToolStripMenuItem2.Text = "システム"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(159, 6)
        '
        'リーダーライター接続ToolStripMenuItem
        '
        Me.リーダーライター接続ToolStripMenuItem.Name = "リーダーライター接続ToolStripMenuItem"
        Me.リーダーライター接続ToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.リーダーライター接続ToolStripMenuItem.Text = "R/W再接続"
        '
        'BluePorter起動ToolStripMenuItem
        '
        Me.BluePorter起動ToolStripMenuItem.Name = "BluePorter起動ToolStripMenuItem"
        Me.BluePorter起動ToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.BluePorter起動ToolStripMenuItem.Text = "BluePorter-V起動"
        '
        'tsmシステム終了
        '
        Me.tsmシステム終了.Name = "tsmシステム終了"
        Me.tsmシステム終了.Size = New System.Drawing.Size(162, 22)
        Me.tsmシステム終了.Text = "システム終了"
        '
        '編集ToolStripMenuItem
        '
        Me.編集ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsm切り取り, Me.tsmコピー, Me.tsm貼り付け})
        Me.編集ToolStripMenuItem.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem"
        Me.編集ToolStripMenuItem.Size = New System.Drawing.Size(41, 22)
        Me.編集ToolStripMenuItem.Text = "編集"
        Me.編集ToolStripMenuItem.Visible = False
        '
        'tsm切り取り
        '
        Me.tsm切り取り.Image = CType(resources.GetObject("tsm切り取り.Image"), System.Drawing.Image)
        Me.tsm切り取り.Name = "tsm切り取り"
        Me.tsm切り取り.Size = New System.Drawing.Size(112, 22)
        Me.tsm切り取り.Text = "切り取り"
        '
        'tsmコピー
        '
        Me.tsmコピー.Image = CType(resources.GetObject("tsmコピー.Image"), System.Drawing.Image)
        Me.tsmコピー.Name = "tsmコピー"
        Me.tsmコピー.Size = New System.Drawing.Size(112, 22)
        Me.tsmコピー.Text = "コピー"
        '
        'tsm貼り付け
        '
        Me.tsm貼り付け.Image = CType(resources.GetObject("tsm貼り付け.Image"), System.Drawing.Image)
        Me.tsm貼り付け.Name = "tsm貼り付け"
        Me.tsm貼り付け.Size = New System.Drawing.Size(112, 22)
        Me.tsm貼り付け.Text = "貼り付け"
        '
        'WindowsListToolStripMenuItem
        '
        Me.WindowsListToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsm重ねて表示, Me.tsm並べて表示, Me.tsm上下に並べて表示, Me.tsm左右に並べて表示, Me.ToolStripSeparator3, Me.tsm画面を閉じる, Me.tsm全て閉じる, Me.ToolStripSeparator1})
        Me.WindowsListToolStripMenuItem.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.WindowsListToolStripMenuItem.Name = "WindowsListToolStripMenuItem"
        Me.WindowsListToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.WindowsListToolStripMenuItem.Text = "ウィンドウ"
        '
        'tsm重ねて表示
        '
        Me.tsm重ねて表示.Name = "tsm重ねて表示"
        Me.tsm重ねて表示.Size = New System.Drawing.Size(158, 22)
        Me.tsm重ねて表示.Text = "重ねて表示"
        Me.tsm重ねて表示.Visible = False
        '
        'tsm並べて表示
        '
        Me.tsm並べて表示.Name = "tsm並べて表示"
        Me.tsm並べて表示.Size = New System.Drawing.Size(158, 22)
        Me.tsm並べて表示.Text = "並べて表示"
        Me.tsm並べて表示.Visible = False
        '
        'tsm上下に並べて表示
        '
        Me.tsm上下に並べて表示.Name = "tsm上下に並べて表示"
        Me.tsm上下に並べて表示.Size = New System.Drawing.Size(158, 22)
        Me.tsm上下に並べて表示.Text = "上下に並べて表示"
        Me.tsm上下に並べて表示.Visible = False
        '
        'tsm左右に並べて表示
        '
        Me.tsm左右に並べて表示.Name = "tsm左右に並べて表示"
        Me.tsm左右に並べて表示.Size = New System.Drawing.Size(158, 22)
        Me.tsm左右に並べて表示.Text = "左右に並べて表示"
        Me.tsm左右に並べて表示.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(155, 6)
        '
        'tsm画面を閉じる
        '
        Me.tsm画面を閉じる.Name = "tsm画面を閉じる"
        Me.tsm画面を閉じる.Size = New System.Drawing.Size(158, 22)
        Me.tsm画面を閉じる.Text = "画面を閉じる"
        Me.tsm画面を閉じる.Visible = False
        '
        'tsm全て閉じる
        '
        Me.tsm全て閉じる.Name = "tsm全て閉じる"
        Me.tsm全て閉じる.Size = New System.Drawing.Size(158, 22)
        Me.tsm全て閉じる.Text = "全画面を閉じる"
        Me.tsm全て閉じる.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(155, 6)
        '
        'ヘルプToolStripMenuItem
        '
        Me.ヘルプToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmヘルプ})
        Me.ヘルプToolStripMenuItem.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ヘルプToolStripMenuItem.Name = "ヘルプToolStripMenuItem"
        Me.ヘルプToolStripMenuItem.Size = New System.Drawing.Size(46, 22)
        Me.ヘルプToolStripMenuItem.Text = "ヘルプ"
        Me.ヘルプToolStripMenuItem.Visible = False
        '
        'tsmヘルプ
        '
        Me.tsmヘルプ.Image = CType(resources.GetObject("tsmヘルプ.Image"), System.Drawing.Image)
        Me.tsmヘルプ.Name = "tsmヘルプ"
        Me.tsmヘルプ.Size = New System.Drawing.Size(115, 22)
        Me.tsmヘルプ.Text = "バージョン"
        '
        'データ更新ToolStripMenuItem
        '
        Me.データ更新ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.セキュリティデータ転送ToolStripMenuItem})
        Me.データ更新ToolStripMenuItem.Name = "データ更新ToolStripMenuItem"
        Me.データ更新ToolStripMenuItem.Size = New System.Drawing.Size(80, 22)
        Me.データ更新ToolStripMenuItem.Text = "データ更新"
        Me.データ更新ToolStripMenuItem.Visible = False
        '
        'セキュリティデータ転送ToolStripMenuItem
        '
        Me.セキュリティデータ転送ToolStripMenuItem.Name = "セキュリティデータ転送ToolStripMenuItem"
        Me.セキュリティデータ転送ToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.セキュリティデータ転送ToolStripMenuItem.Text = "セキュリティデータ転送"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "メンテ2.ico")
        Me.ImageList1.Images.SetKeyName(1, "コンピュータ２.ico")
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
        Me.lbl現在時刻.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!)
        Me.lbl現在時刻.Location = New System.Drawing.Point(0, 0)
        Me.lbl現在時刻.Name = "lbl現在時刻"
        Me.lbl現在時刻.Size = New System.Drawing.Size(302, 16)
        Me.lbl現在時刻.TabIndex = 0
        Me.lbl現在時刻.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TSBtn画面印刷
        '
        Me.TSBtn画面印刷.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSBtn画面印刷.Image = CType(resources.GetObject("TSBtn画面印刷.Image"), System.Drawing.Image)
        Me.TSBtn画面印刷.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSBtn画面印刷.Name = "TSBtn画面印刷"
        Me.TSBtn画面印刷.Size = New System.Drawing.Size(100, 22)
        Me.TSBtn画面印刷.Text = "ハードコピー"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSBtn画面印刷})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1016, 25)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'CMdiMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Menuメニュー)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.Menuメニュー
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
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WindowsListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 編集ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsm切り取り As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmコピー As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsm貼り付け As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ヘルプToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmヘルプ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsm重ねて表示 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsm上下に並べて表示 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsm左右に並べて表示 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmシステム終了 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tsm全て閉じる As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsm画面を閉じる As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsm並べて表示 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lbl現在時刻 As System.Windows.Forms.Label
    Friend WithEvents TSBtn画面印刷 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents リーダーライター接続ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BluePorter起動ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents データ更新ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents セキュリティデータ転送ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblBottom As System.Windows.Forms.Label
End Class

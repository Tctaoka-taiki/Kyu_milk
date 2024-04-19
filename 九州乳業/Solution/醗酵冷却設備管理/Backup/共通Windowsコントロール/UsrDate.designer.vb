<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrDate
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    ' コード エディタは使用しないでください。
    Friend WithEvents lblSura2 As System.Windows.Forms.Label
    Friend WithEvents lblSura1 As System.Windows.Forms.Label
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblSura2 = New System.Windows.Forms.Label
        Me.lblSura1 = New System.Windows.Forms.Label
        Me.txtDay = New System.Windows.Forms.TextBox
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSura2
        '
        Me.lblSura2.AutoSize = True
        Me.lblSura2.BackColor = System.Drawing.SystemColors.Window
        Me.lblSura2.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSura2.Location = New System.Drawing.Point(61, 2)
        Me.lblSura2.Name = "lblSura2"
        Me.lblSura2.Size = New System.Drawing.Size(14, 13)
        Me.lblSura2.TabIndex = 10
        Me.lblSura2.Text = "/"
        Me.lblSura2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSura1
        '
        Me.lblSura1.AutoSize = True
        Me.lblSura1.BackColor = System.Drawing.SystemColors.Window
        Me.lblSura1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSura1.Location = New System.Drawing.Point(32, 2)
        Me.lblSura1.Name = "lblSura1"
        Me.lblSura1.Size = New System.Drawing.Size(14, 13)
        Me.lblSura1.TabIndex = 9
        Me.lblSura1.Text = "/"
        Me.lblSura1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDay
        '
        Me.txtDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDay.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDay.Location = New System.Drawing.Point(76, 2)
        Me.txtDay.MaxLength = 2
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(17, 13)
        Me.txtDay.TabIndex = 2
        Me.txtDay.Text = "DD"
        '
        'txtMonth
        '
        Me.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMonth.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(46, 2)
        Me.txtMonth.MaxLength = 2
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(15, 13)
        Me.txtMonth.TabIndex = 1
        Me.txtMonth.Text = "MM"
        '
        'txtYear
        '
        Me.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtYear.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtYear.Location = New System.Drawing.Point(4, 2)
        Me.txtYear.MaxLength = 4
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(29, 13)
        Me.txtYear.TabIndex = 0
        Me.txtYear.Text = "YYYY"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtYear)
        Me.Panel1.Controls.Add(Me.lblSura1)
        Me.Panel1.Controls.Add(Me.lblSura2)
        Me.Panel1.Controls.Add(Me.txtDay)
        Me.Panel1.Controls.Add(Me.txtMonth)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(100, 20)
        Me.Panel1.TabIndex = 13
        '
        'usrDate
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.Panel1)
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Name = "usrDate"
        Me.Size = New System.Drawing.Size(102, 20)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

End Class

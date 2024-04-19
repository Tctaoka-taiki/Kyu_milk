<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CMdiChildDialog
    Inherits ì¸ëﬁé∫ä«óù.CMdiChildFrm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CMdiChildDialog))
        Me.SuspendLayout()
        '
        'btnF12
        '
        Me.btnF12.Text = "F12" & Global.Microsoft.VisualBasic.ChrW(13) & " ñﬂÇÈ"
        '
        'CMdiChildDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.ClientSize = New System.Drawing.Size(1004, 631)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CMdiChildDialog"
        Me.ResumeLayout(False)

    End Sub

End Class

Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace Extentions

    Public Class usrLblGrd
        Inherits System.Windows.Forms.Label

        Public Sub New()
            MyBase.BackColor = Color.Transparent
            Me._GradientMode = LinearGradientMode.Vertical
        End Sub

        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            If Me.BackColor = Color.Transparent OrElse Me.BackColor2 = Color.Transparent Then
                MyBase.OnPaintBackground(pevent)
            End If

            Using lgb As New LinearGradientBrush(Me.ClientRectangle, Me.BackColor, Me.BackColor2, Me.GradientMode)
                pevent.Graphics.FillRectangle(lgb, Me.ClientRectangle)
            End Using
        End Sub

#Region " BackColor "

        Private _BackColor As Color
        Public Shadows Property BackColor() As Color
            Get
                If Me._BackColor <> Color.Empty Then
                    Return Me._BackColor
                End If
                If Me.Parent IsNot Nothing Then
                    Return Me.Parent.BackColor
                End If

                Return Control.DefaultBackColor
            End Get
            Set(ByVal value As Color)
                Me._BackColor = value
                Me.Invalidate()
            End Set
        End Property

        Public Overrides Sub ResetBackColor()
            Me.BackColor = Color.Empty
        End Sub

        Private Function ShouldSerializeBackColor() As Boolean
            Return Me._BackColor <> Color.Empty
        End Function

#End Region

#Region " BackColor2 "

        Private _BackColor2 As Color
        <Category("表示")> _
        <Description("コンポーネントの背景色のグラデーションの終了色です。")> _
        Public Property BackColor2() As Color
            Get
                If Me._BackColor2 <> Color.Empty Then
                    Return Me._BackColor2
                End If
                If Me.Parent IsNot Nothing Then
                    Return Me.Parent.BackColor
                End If

                Return Control.DefaultBackColor
            End Get
            Set(ByVal value As Color)
                Me._BackColor2 = value
                Me.Invalidate()
            End Set
        End Property

        Public Sub ResetBackColor2()
            Me.BackColor2 = Color.Empty
        End Sub

        Private Function ShouldSerializeBackColor2() As Boolean
            Return Me._BackColor2 <> Color.Empty
        End Function

#End Region

        Private _GradientMode As LinearGradientMode
        <Category("表示")> _
        <DefaultValue(GetType(LinearGradientMode), "Horizontal")> _
        <Description("コンポーネントの背景色のグラデーションの方向です。")> _
        Public Property GradientMode() As LinearGradientMode
            Get
                Return Me._GradientMode
            End Get
            Set(ByVal value As LinearGradientMode)
                'Me._GradientMode = value
                Me._GradientMode = LinearGradientMode.Vertical
                Me.Invalidate()
            End Set
        End Property

    End Class

End Namespace


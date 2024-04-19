Public Class UcTextLabel
    Implements IUserControl
    Implements IEnterキー制御
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    ''' <summary>
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>
    ''' デザイナーで「Text」プロパティが表示の仕方がわからないため、こちらからセットできるようにしている。
    ''' </remarks>
    Public Property pText() As String
        Get
            Return テキスト.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            テキスト.Text = value
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            Return テキスト.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            テキスト.Text = value
        End Set
    End Property

    Private mIsクリア As Boolean = True
    Public Property Isクリア() As Boolean Implements IUserControl.Isクリア
        Get
            Return mIsクリア
        End Get
        Set(ByVal value As Boolean)
            mIsクリア = value
            テキスト.Isクリア = value
            ラベル.Isクリア = value
        End Set
    End Property

    Public ReadOnly Property Is空欄() As Boolean
        Get
            Return (テキスト.TextLength = 0)
        End Get
    End Property

    Private mUIモード As enmUIモード = enmUIモード.編集
    Public Property モード() As enmUIモード
        Get
            Return mUIモード
        End Get
        Set(ByVal value As enmUIモード)
            mUIモード = value
            Select Case value
                Case enmUIモード.編集
                    テキスト.Visible = True

                    ラベル.Visible = False

                Case enmUIモード.表示
                    テキスト.Visible = False

                    ラベル.Visible = True
            End Select
        End Set
    End Property

    Private menmCondition As gEnm入力条件 = gEnm入力条件.Nomal
    Public Property pCondition() As gEnm入力条件
        Get
            Return menmCondition
        End Get
        Set(ByVal Value As gEnm入力条件)
            menmCondition = Value
            テキスト.pCondition = Value
        End Set
    End Property

    Private mエラーメッセージ As String = ""
    Public Property pErrText() As String Implements IUserControl.エラー表示用項目名
        Get
            Return mエラーメッセージ
        End Get
        Set(ByVal Value As String)
            mエラーメッセージ = Value
        End Set
    End Property

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
    Private Sub UcカードNO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pCondition = gEnm入力条件.Nomal
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果

        Try
            With Me
                If .pCondition = gEnm入力条件.Hissu Or _
                    (.pCondition <> gEnm入力条件.Hissu And Not .Is空欄) Then
                End If
            End With
        Finally
            If Not 入力チェック.ErrorContol Is Nothing And Isエラーフォーカス Then
                入力チェック.ErrorContol.Focus()
            End If
        End Try

        入力チェック.Is正常 = True

    End Function

    Public Sub クリア() Implements IUserControl.クリア
        If Isクリア Then
            テキスト.クリア()
            ラベル.クリア()
        End If
    End Sub


    '#####################################################################################
    '「テキスト」に対するイベント
    '#####################################################################################
    Private Sub テキスト_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles テキスト.Resize
        ラベル.Width = テキスト.Width
        ラベル.Height = テキスト.Height
    End Sub
    Private Sub テキスト_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles テキスト.TextChanged
        ラベル.Text = テキスト.Text
    End Sub

    '#####################################################################################
    'UcTextLabelに対するイベント
    '#####################################################################################
    Private Sub UcTextLabel_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Resize
        テキスト.Width = Width
        テキスト.Height = Height
        '高さは、テキストに合わせる
        If Height <> テキスト.Height Then
            Height = テキスト.Height
        End If
    End Sub

    Private Sub UcTextLabel_FontChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FontChanged
        テキスト.Font = Font
        ラベル.Font = Font
    End Sub
    Private Sub UcTextLabel_BackColorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.BackColorChanged
        テキスト.BackColor = BackColor
        ラベル.BackColor = BackColor
    End Sub
    Private Sub UcTextLabel_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        テキスト.Width = Width
        テキスト.Height = Height
        '高さは、テキストに合わせる
        If Height <> テキスト.Height Then
            Height = テキスト.Height
        End If
    End Sub

    Private Sub UcTextLabel_ForeColorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ForeColorChanged
        テキスト.ForeColor = ForeColor
        ラベル.ForeColor = ForeColor
        MyBase.Text = "aa"
    End Sub

End Class

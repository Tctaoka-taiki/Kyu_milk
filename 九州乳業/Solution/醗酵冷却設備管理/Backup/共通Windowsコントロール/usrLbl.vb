'*******************************************************************************
' @(h)  UsrLbl.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrLbl                             System.Windows.Forms.Labelを継承
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ForeColor = System.Drawing.SystemColors.ControlText
'       TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************

Public Class usrLbl
    Inherits System.Windows.Forms.Label
    Implements IUserControl

    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Private mエラー表示用項目名 As String = ""
    Private mstrID As String = ""
    Private mstrClearValue As String = ""
    Private mIsクリア As Boolean

    'Private mblnNumDisply As Boolean
    'Private mstrNumFormat As String = "#,##0"

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    ''' <summary>
    ''' pID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pID() As String
        Get
            Return mstrID
        End Get
        Set(ByVal Value As String)
            mstrID = Value
        End Set
    End Property

    ''' <summary>
    ''' pClearValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pClearValue() As String
        Get
            Return mstrClearValue
        End Get
        Set(ByVal Value As String)
            mstrClearValue = Value
        End Set
    End Property

    ''' <summary>
    ''' pIsClear
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Isクリア() As Boolean Implements IUserControl.Isクリア
        Get
            Return mIsクリア
        End Get
        Set(ByVal Value As Boolean)
            mIsクリア = Value
        End Set
    End Property

    '#Region "pIsNumDisplyプロパティー"
    '    '---------------------------------------------------------------------------
    '    ' @(f)
    '    ' 機　能　：pIsNumDisplyプロパティー
    '    ' 引　数　：
    '    ' 戻り値　：
    '    ' 機能説明：Textプロパティーをセットするときにフォーマットして設定するかどうか
    '    ' 備　考　：
    '    '---------------------------------------------------------------------------
    '#End Region
    '    Public Property pIsNumDisply() As Boolean
    '        Get
    '            Return mblnNumDisply
    '        End Get
    '        Set(ByVal Value As Boolean)
    '            mblnNumDisply = Value
    '            If Value Then
    '                Me.TextAlign = ContentAlignment.MiddleRight
    '            Else
    '                Me.TextAlign = ContentAlignment.MiddleLeft
    '            End If
    '            Me.text = Me.text
    '        End Set
    '    End Property

    '#Region "pFormatNumプロパティー"
    '    '---------------------------------------------------------------------------
    '    ' @(f)
    '    ' 機　能　：pFormatNumプロパティー
    '    ' 引　数　：
    '    ' 戻り値　：
    '    ' 機能説明：textプロパティに設定するときのフォーマット
    '    ' 備　考　：
    '    '---------------------------------------------------------------------------
    '#End Region
    '    Public Property pFormatNum() As String
    '        Get
    '            Return mstrNumFormat
    '        End Get
    '        Set(ByVal Value As String)
    '            mstrNumFormat = Value
    '            Me.text = Me.text
    '        End Set
    '    End Property

    '    Public Overrides Property text() As String
    '        Get
    '            Return MyBase.Text
    '        End Get
    '        Set(ByVal value As String)
    '            If Me.mblnNumDisply Then
    '                If IsNumeric(value) Then
    '                    MyBase.Text = Format(CDbl(value), Me.mstrNumFormat)
    '                Else
    '                    MyBase.Text = value
    '                End If
    '            Else
    '                MyBase.Text = value
    '            End If
    '        End Set
    '    End Property

    Public Property エラー表示用項目名() As String Implements IUserControl.エラー表示用項目名
        Get
            Return mエラー表示用項目名
        End Get
        Set(ByVal value As String)
            mエラー表示用項目名 = value
        End Set
    End Property

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Public Sub New()
        MyBase.New()

        'フォント
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    End Sub

    Public Sub クリア() Implements IUserControl.クリア
        If Isクリア Then
            Text = pClearValue
        End If
    End Sub

    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果
        入力チェック.Is正常 = True
    End Function
End Class

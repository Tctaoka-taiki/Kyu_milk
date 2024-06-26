'*******************************************************************************
' @(h)  UsrOpt.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrOpt                             System.Windows.Forms.RadioButtonを継承
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************

Public Class usrOpt
    Inherits System.Windows.Forms.RadioButton
    Implements IUserControl
    Implements IEnterキー制御

    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Private mstrID As String = ""
    Private mblnClear As Boolean
    Private mblnClearValue As Boolean

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
    Public Property pClearValue() As Boolean
        Get
            Return mblnClearValue
        End Get
        Set(ByVal Value As Boolean)
            mblnClearValue = Value
        End Set
    End Property

    Public Property Isクリア() As Boolean Implements IUserControl.Isクリア
        Get
            Return mblnClear
        End Get
        Set(ByVal Value As Boolean)
            mblnClear = Value
        End Set
    End Property

    Private mエラー表示用項目名 As String = ""
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
    'コンストラクタ
    Public Sub New()
        MyBase.New()

        'フォント
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    End Sub

    Public Sub クリア() Implements IUserControl.クリア
        If Isクリア Then
            Checked = pClearValue
        End If
    End Sub

    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果
        入力チェック.Is正常 = True
    End Function
End Class

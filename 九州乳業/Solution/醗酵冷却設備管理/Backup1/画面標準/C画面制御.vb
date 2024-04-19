''' <summary>
''' Windows画面アプリに共通する機能を実装するクラス
''' </summary>
''' <remarks></remarks>
Public Class C画面制御
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Public Shared gdp As Cdp
    Private Const MSG警告_DB接続エラー As String = "データベースの接続に失敗しました。"
    Public Const パスフレーズ As String = "12345"

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    Private m初期画面ID As C子画面
    Public Property 初期画面ID() As C子画面
        Get
            Return m初期画面ID
        End Get
        Set(ByVal value As C子画面)
            m初期画面ID = value
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
    Public Overridable Sub 画面初期化処理()

    End Sub

    Public Overridable Function 画面名取得(ByVal strID As String) As String
        Return "画面名未定義"
    End Function

    Public Overridable Function 子フォーム生成(ByVal strFormID As C子画面) As Form
        Return Nothing
    End Function

    Public Overridable Sub 初期表示子フォームを開く(ByVal strFormID As String)

    End Sub

    Public Shared Function DB接続処理() As Boolean
        Try
            With CUsrctl.gDp
                .gBln接続Close()
                ''接続が繋がるまで設定リトライ数する
                Dim int接続リトライ数 As Integer = 0
                Do
                    If .gBlnDB接続 = False Then
                        If int接続リトライ数 = .再接続試行回数 Then
                            '設定リトライ数に達したらエラーメッセージ
                            Call CMsg.gMsg_エラー(MSG警告_DB接続エラー)
                            Return False
                        Else
                            '設定リトライ数前ならスリープ
                            '3000ミリ秒停止
                            System.Threading.Thread.Sleep(3000)
                            int接続リトライ数 += 1
                        End If
                    Else
                        Return True
                    End If
                Loop
            End With
        Catch ex As Exception
            Call CMsg.gMsg_エラー(MSG警告_DB接続エラー)
            Return False
        End Try
    End Function
End Class

Public Class C子画面
    Private m画面名 As String
    Public Property 画面名() As String
        Get
            Return m画面名
        End Get
        Set(ByVal value As String)
            m画面名 = value
        End Set
    End Property
    Public Sub New(ByVal 画面名 As String)
        m画面名 = 画面名
    End Sub
End Class

Public Interface I子画面
    'Property 画面タイトル()
    Property 画面名() As String
    Property Mdi親画面() As Form
    Property 画面モード() As String
    Sub 共通画面初期設定()
    Sub 表示()
End Interface


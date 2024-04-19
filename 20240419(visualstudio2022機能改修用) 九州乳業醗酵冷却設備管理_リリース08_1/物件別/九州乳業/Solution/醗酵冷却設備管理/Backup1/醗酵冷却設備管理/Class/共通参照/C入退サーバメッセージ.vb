Public Class C入退サーバメッセージ
    Public Class メッセージベース
        Public Class 要求
            Sub New()

            End Sub
            ''' <summary>
            ''' 応答メッセージキュー名
            ''' </summary>
            ''' <remarks></remarks>
            Private _応答メッセージキュー名 As String
            Public Property 応答メッセージキュー名() As String
                Get
                    Return _応答メッセージキュー名
                End Get
                Set(ByVal value As String)
                    _応答メッセージキュー名 = value
                End Set
            End Property
        End Class
        Public Class 応答(Of T, E)
            Sub New()

            End Sub
            ''' <summary>
            ''' 入場状態設定応答
            ''' </summary>
            ''' <remarks></remarks>
            Private _エラーコード As E
            Public Property 応答コード() As E
                Get
                    Return _エラーコード
                End Get
                Set(ByVal value As E)
                    _エラーコード = value
                End Set
            End Property

            ''' <summary>
            ''' 設定された要求
            ''' </summary>
            ''' <remarks></remarks>
            Private _要求 As T
            Public Property 要求() As T
                Get
                    Return _要求
                End Get
                Set(ByVal value As T)
                    _要求 = value
                End Set
            End Property
        End Class
    End Class

    ''' <summary>
    ''' 入場状態設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Class 入場状態設定

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum E処理結果 As Integer
            正常 = 0                    '正常に処理されました
            ステータス不正 = 1          'PLCが指定されたステータス状態ではなかった
            タグID不正 = 2              '指定されたタグIDはセキュリティ情報に存在しません
            セキュリティデータなし = 2  'サーバにセキュリティデータがない（一度も転送していない）
            ＰＬＣ未接続 = -1       'ＰＬＣ未接続
        End Enum


        ''' <summary>
        ''' 要求
        ''' </summary>
        ''' <remarks></remarks>
        Public Class 入場状態設定要求

            Inherits メッセージベース.要求

            ''' <summary>
            ''' タグID
            ''' </summary>
            ''' <remarks></remarks>
            Private _タグID As Byte()
            Public Property タグID() As Byte()
                Get
                    Return _タグID
                End Get
                Set(ByVal value As Byte())
                    _タグID = value
                End Set
            End Property

            ''' <summary>
            ''' 入場状態を示すBoolean値(False:入場 True:退場)
            ''' </summary>
            ''' <remarks></remarks>
            Private _入場状態 As Boolean
            Public Property 入場状態() As Boolean
                Get
                    Return _入場状態
                End Get
                Set(ByVal value As Boolean)
                    _入場状態 = value
                End Set
            End Property

        End Class

        ''' <summary>
        ''' 応答
        ''' </summary>
        ''' <remarks></remarks>
        Public Class 入場状態設定応答

            Inherits メッセージベース.応答(Of 入場状態設定要求, E処理結果)
        End Class

    End Class

    ''' <summary>
    ''' ゲート開
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ゲート開閉

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum E処理結果 As Integer
            正常 = 0                '正常に処理されました
            ゲート番号不正 = 1      'ゲート番号が不正です
            ＰＬＣ未接続 = -1       'ＰＬＣ未接続
        End Enum


        ''' <summary>
        ''' 要求
        ''' </summary>
        ''' <remarks></remarks>
        Public Class ゲート開閉要求

            Inherits メッセージベース.要求

            ''' <summary>
            ''' ゲート番号
            ''' </summary>
            ''' <remarks></remarks>
            Private _ゲート番号 As Integer
            Public Property ゲート番号() As Integer
                Get
                    Return _ゲート番号
                End Get
                Set(ByVal value As Integer)
                    _ゲート番号 = value
                End Set
            End Property

            ''' <summary>
            ''' ゲート開
            ''' </summary>
            ''' <remarks></remarks>
            Private _ゲート開 As Boolean
            Public Property ゲート開() As Boolean
                Get
                    Return _ゲート開
                End Get
                Set(ByVal value As Boolean)
                    _ゲート開 = value
                End Set
            End Property

        End Class

        ''' <summary>
        ''' 応答
        ''' </summary>
        ''' <remarks></remarks>
        Public Class ゲート開閉応答

            Inherits メッセージベース.応答(Of ゲート開閉要求, E処理結果)
        End Class

    End Class
    Public Class 状況確認
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum E処理結果 As Integer
            正常 = 0                '正常に処理されました
            ＰＬＣ通信エラー = 1    'ＰＬＣと通信出来なかった
        End Enum


        ''' <summary>
        ''' 要求
        ''' </summary>
        ''' <remarks></remarks>
        Public Class 状況確認要求
            Inherits メッセージベース.要求
        End Class
        ''' <summary>
        ''' 応答
        ''' </summary>
        ''' <remarks></remarks>
        Public Class 状況確認応答

            Inherits メッセージベース.応答(Of 状況確認要求, E処理結果)

            ''' <summary>
            ''' アンチパスバック有効
            ''' </summary>
            ''' <remarks></remarks>
            Private _アンチパスバック有効 As Boolean
            Public Property アンチパスバック有効() As Boolean
                Get
                    Return _アンチパスバック有効
                End Get
                Set(ByVal value As Boolean)
                    _アンチパスバック有効 = value
                End Set
            End Property

            ''' <summary>
            ''' 入口ゲートの開放状態
            ''' </summary>
            ''' <remarks></remarks>
            Private _入口開放状態 As Boolean
            Public Property 入口開放状態() As Boolean
                Get
                    Return _入口開放状態
                End Get
                Set(ByVal value As Boolean)
                    _入口開放状態 = value
                End Set
            End Property

            ''' <summary>
            ''' 出口ゲートの開放状態
            ''' </summary>
            ''' <remarks></remarks>
            Private _出口開放状態 As Boolean
            Public Property 出口開放状態() As Boolean
                Get
                    Return _出口開放状態
                End Get
                Set(ByVal value As Boolean)
                    _出口開放状態 = value
                End Set
            End Property
        End Class
    End Class
    Public Class アンチパスバック設定
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum E処理結果 As Integer
            正常 = 0                '正常に処理されました
            ＰＬＣ通信エラー = 1    'ＰＬＣと通信出来なかった
            既に指定の状態です = 2  '既に指定の状態です
        End Enum

        Public Class アンチパスバック設定要求

            Inherits メッセージベース.要求

            ''' <summary>
            ''' アンチパスバック有効
            ''' </summary>
            ''' <remarks></remarks>
            Private _アンチパスバック有効 As Boolean
            Public Property アンチパスバック有効() As Boolean
                Get
                    Return _アンチパスバック有効
                End Get
                Set(ByVal value As Boolean)
                    _アンチパスバック有効 = value
                End Set
            End Property
        End Class

        Public Class アンチパスバック設定応答

            Inherits メッセージベース.応答(Of アンチパスバック設定要求, E処理結果)

        End Class

    End Class

    Public Class セキュリティデータ転送
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum E処理結果 As Integer
            正常 = 0                '正常に処理されました
            ＰＬＣ通信エラー = -1    'ＰＬＣと通信出来なかった
            タイムアウト発生 = -2    'セキュリティデータ転送でタイムアウトが発生した
        End Enum

        Public Class セキュリティデータ転送要求

            Inherits メッセージベース.要求
        End Class

        Public Class セキュリティデータ転送応答

            Inherits メッセージベース.応答(Of セキュリティデータ転送要求, E処理結果)

        End Class

    End Class
End Class

Imports System.ComponentModel

Public Class Settings

    ''' <summary>
    ''' デバイス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class デバイス

        Private _デバイス文字列 As String
        Public Property デバイス文字列() As String
            Get
                Return _デバイス文字列
            End Get
            Set(ByVal value As String)
                _デバイス文字列 = value
            End Set
        End Property

        Private _値 As Integer
        Public Property 値() As Integer
            Get
                Return _値
            End Get
            Set(ByVal value As Integer)
                _値 = value
            End Set
        End Property


        Private _件数 As Integer
        Public Property 件数() As Integer
            Get
                Return _件数
            End Get
            Set(ByVal value As Integer)
                _件数 = value
            End Set
        End Property

        Private _タグ As String
        Public Property タグ() As String
            Get
                Return _タグ
            End Get
            Set(ByVal value As String)
                _タグ = value
            End Set
        End Property

        Private _デバイス間隔 As Integer
        Public Property デバイス間隔() As Integer
            Get
                Return _デバイス間隔
            End Get
            Set(ByVal value As Integer)
                _デバイス間隔 = value
            End Set
        End Property

        Private _ブロック数 As Integer
        Public Property ブロック数() As Integer
            Get
                Return _ブロック数
            End Get
            Set(ByVal value As Integer)
                _ブロック数 = value
            End Set
        End Property

        Sub New()
        End Sub
        Sub New(ByVal デバイス文字列 As String, ByVal 値 As Integer, ByVal タグ As String, Optional ByVal 件数 As Integer = 0, Optional ByVal デバイス間隔 As Integer = 0, Optional ByVal ブロック数 As Integer = 0)
            Me.デバイス文字列 = デバイス文字列
            Me._値 = 値
            Me._件数 = 件数
            Me._タグ = タグ
            Me._デバイス間隔 = デバイス間隔
            Me._ブロック数 = ブロック数
        End Sub

        ''' <summary>
        ''' 初期設定をデバイスに変換する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Convertデバイス() As CMX.Device
            Return CMX.GetDeviceArray(New CMX.Device(デバイス文字列, タグ), CUShort(値))(0)
        End Function
        ''' <summary>
        ''' 初期設定をデバイスにリストに変換する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConvertデバイスList() As List(Of CMX.Device)
            Dim orgDev As CMX.Device = Convertデバイス()
            Dim devList As New List(Of CMX.Device)

            '件数指定がない場合
            If 件数 = 0 Then
                devList.Add(orgDev)
                Return devList
            End If

            'ブロック指定がない場合
            If ブロック数 = 0 Then
                For i As Integer = 0 To 件数 - 1
                    Dim newDev As CMX.Device = CType(orgDev.Clone, CMX.Device)
                    newDev.DeviceNo = orgDev.DeviceNo + ((i * CInt(IIf(デバイス間隔 = 0, 1, デバイス間隔))))
                    newDev.Tag = orgDev.Tag + i.ToString
                    devList.Add(newDev)
                Next
                Return devList
            End If

            'ブロック数指定がある場合は、デバイス間隔指定もあるはず
            For i As Integer = 0 To 件数 - 1
                For j As Integer = 0 To ブロック数 - 1
                    Dim newDev As CMX.Device = CType(orgDev.Clone, CMX.Device)
                    newDev.DeviceNo = orgDev.DeviceNo + ((i * デバイス間隔) + j)
                    newDev.Tag = orgDev.Tag + i.ToString + "-" + j.ToString
                    devList.Add(newDev)
                Next
            Next
            Return devList
        End Function
    End Class

    ''' <summary>
    ''' 初期化用デバイス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class 初期化デバイス
        Inherits デバイス

        Private _Isダブルワード As Boolean
        Public Property Isダブルワード() As Boolean
            Get
                Return _Isダブルワード
            End Get
            Set(ByVal value As Boolean)
                _Isダブルワード = value
            End Set
        End Property

        Private _要素数 As Integer
        Public Property 要素数() As Integer
            Get
                Return _要素数
            End Get
            Set(ByVal value As Integer)
                _要素数 = value
            End Set
        End Property

        Sub New()
        End Sub
        Sub New(ByVal デバイス文字列 As String, ByVal 要素数 As Integer, ByVal タグ As String, ByVal 値 As Int16)
            MyBase.デバイス文字列 = デバイス文字列
            MyBase.値 = 値
            MyBase.タグ = タグ
            Me._要素数 = 要素数
            Me._Isダブルワード = False
        End Sub
        Sub New(ByVal デバイス文字列 As String, ByVal 要素数 As Integer, ByVal タグ As String, ByVal 値 As Int32)
            MyBase.デバイス文字列 = デバイス文字列
            MyBase.値 = 値
            MyBase.タグ = タグ
            Me._要素数 = 要素数
            Me._Isダブルワード = True
        End Sub

        ''' <summary>
        ''' 初期設定をデバイス配列に変換する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Convert初期設定デバイス() As CMX.Device()
            If Isダブルワード Then
                Return CMX.GetDeviceArray(New CMX.Device(デバイス文字列, タグ), 値)
            Else
                Return CMX.GetDeviceArray(New CMX.Device(デバイス文字列, タグ), CUShort(値))
            End If
        End Function
    End Class

    Public Class Plc
        Public Sub New()
        End Sub
        Public Sub New(ByVal 拠点名 As String, ByVal 論理局番 As Integer, ByVal デバイス初期設定 As 初期化デバイス() _
                    , ByVal エラー情報 As デバイス(), ByVal センサ情報 As デバイス() _
                    , ByVal アンチパスバック有効 As デバイス, ByVal リセット要求 As デバイス _
                    , ByVal リセット応答 As デバイス, ByVal セキュリティデータ書込要求 As デバイス _
                    , ByVal セキュリティデータ書込応答 As デバイス, ByVal 認識情報転送データあり As デバイス _
                    , ByVal 認識情報読出要求 As デバイス, ByVal 認識情報読出応答 As デバイス _
                    , ByVal 認証ログ件数 As デバイス, ByVal 認証ログ局番 As デバイス _
                    , ByVal 認証ログアンテナ As デバイス, ByVal 認証ログタグID As デバイス _
                    , ByVal 認証ログステータス As デバイス, ByVal 認証ログ認証入出区分 As デバイス _
                    , ByVal 認証ログ年月 As デバイス, ByVal 認証ログ日時 As デバイス _
                    , ByVal 認証ログ分秒 As デバイス _
                    )
            Me._拠点名 = 拠点名
            Me._論理局番 = 論理局番
            Me._デバイス初期設定 = デバイス初期設定
            Me._エラー情報 = エラー情報
            Me._センサ情報 = センサ情報
            Me._アンチパスバック有効 = アンチパスバック有効
            Me._リセット要求 = リセット要求
            Me._リセット応答 = リセット応答
            Me._セキュリティデータ書込要求 = セキュリティデータ書込要求
            Me._セキュリティデータ書込応答 = セキュリティデータ書込応答
            Me._認識情報転送データあり = 認識情報転送データあり
            Me._認識情報読出要求 = 認識情報読出要求
            Me._認識情報読出応答 = 認識情報読出応答
            Me._認証ログ件数 = 認証ログ件数
            Me._認証ログ局番 = 認証ログ局番
            Me._認証ログアンテナ = 認証ログアンテナ
            Me._認証ログタグID = 認証ログタグID
            Me._認証ログステータス = 認証ログステータス
            Me._認証ログ認証入出区分 = 認証ログ認証入出区分
            Me._認証ログ年月 = 認証ログ年月
            Me._認証ログ日時 = 認証ログ日時
            Me._認証ログ分秒 = 認証ログ分秒
        End Sub

        Private _拠点名 As String
        Public Property 拠点名() As String
            Get
                Return _拠点名
            End Get
            Set(ByVal value As String)
                _拠点名 = value
            End Set
        End Property

        Private _論理局番 As Integer
        Public Property 論理局番() As Integer
            Get
                Return _論理局番
            End Get
            Set(ByVal value As Integer)
                _論理局番 = value
            End Set
        End Property


        Private _デバイス初期設定 As 初期化デバイス()
        Public Property デバイス初期設定() As 初期化デバイス()
            Get
                Return _デバイス初期設定
            End Get
            Set(ByVal value As 初期化デバイス())
                _デバイス初期設定 = value
            End Set
        End Property

        Private _エラー情報 As デバイス()
        Public Property エラー情報() As デバイス()
            Get
                Return _エラー情報
            End Get
            Set(ByVal value As デバイス())
                _エラー情報 = value
            End Set
        End Property

        Private _センサ情報 As デバイス()
        Public Property センサ情報() As デバイス()
            Get
                Return _センサ情報
            End Get
            Set(ByVal value As デバイス())
                _センサ情報 = value
            End Set
        End Property

        Private _アンチパスバック有効 As デバイス
        Public Property アンチパスバック有効() As デバイス
            Get
                Return _アンチパスバック有効
            End Get
            Set(ByVal value As デバイス)
                _アンチパスバック有効 = value
            End Set
        End Property

        Private _リセット要求 As デバイス
        Public Property リセット要求() As デバイス
            Get
                Return _リセット要求
            End Get
            Set(ByVal value As デバイス)
                _リセット要求 = value
            End Set
        End Property

        Private _リセット応答 As デバイス
        Public Property リセット応答() As デバイス
            Get
                Return _リセット応答
            End Get
            Set(ByVal value As デバイス)
                _リセット応答 = value
            End Set
        End Property

        Private _セキュリティデータ書込要求 As デバイス
        Public Property セキュリティデータ書込要求() As デバイス
            Get
                Return _セキュリティデータ書込要求
            End Get
            Set(ByVal value As デバイス)
                _セキュリティデータ書込要求 = value
            End Set
        End Property

        Private _セキュリティデータ書込応答 As デバイス
        Public Property セキュリティデータ書込応答() As デバイス
            Get
                Return _セキュリティデータ書込応答
            End Get
            Set(ByVal value As デバイス)
                _セキュリティデータ書込応答 = value
            End Set
        End Property

        Private _認識情報転送データあり As デバイス
        Public Property 認識情報転送データあり() As デバイス
            Get
                Return _認識情報転送データあり
            End Get
            Set(ByVal value As デバイス)
                _認識情報転送データあり = value
            End Set
        End Property

        Private _認識情報読出要求 As デバイス
        Public Property 認識情報読出要求() As デバイス
            Get
                Return _認識情報読出要求
            End Get
            Set(ByVal value As デバイス)
                _認識情報読出要求 = value
            End Set
        End Property

        Private _認識情報読出応答 As デバイス
        Public Property 認識情報読出応答() As デバイス
            Get
                Return _認識情報読出応答
            End Get
            Set(ByVal value As デバイス)
                _認識情報読出応答 = value
            End Set
        End Property

        Private _認証ログ件数 As デバイス
        Public Property 認証ログ件数() As デバイス
            Get
                Return _認証ログ件数
            End Get
            Set(ByVal value As デバイス)
                _認証ログ件数 = value
            End Set
        End Property

        Private _認証ログ局番 As デバイス
        Public Property 認証ログ局番() As デバイス
            Get
                Return _認証ログ局番
            End Get
            Set(ByVal value As デバイス)
                _認証ログ局番 = value
            End Set
        End Property

        Private _認証ログアンテナ As デバイス
        Public Property 認証ログアンテナ() As デバイス
            Get
                Return _認証ログアンテナ
            End Get
            Set(ByVal value As デバイス)
                _認証ログアンテナ = value
            End Set
        End Property

        Private _認証ログタグID As デバイス
        Public Property 認証ログタグID() As デバイス
            Get
                Return _認証ログタグID
            End Get
            Set(ByVal value As デバイス)
                _認証ログタグID = value
            End Set
        End Property

        Private _認証ログステータス As デバイス
        Public Property 認証ログステータス() As デバイス
            Get
                Return _認証ログステータス
            End Get
            Set(ByVal value As デバイス)
                _認証ログステータス = value
            End Set
        End Property

        Private _認証ログ認証入出区分 As デバイス
        Public Property 認証ログ認証入出区分() As デバイス
            Get
                Return _認証ログ認証入出区分
            End Get
            Set(ByVal value As デバイス)
                _認証ログ認証入出区分 = value
            End Set
        End Property

        Private _認証ログ年月 As デバイス
        Public Property 認証ログ年月() As デバイス
            Get
                Return _認証ログ年月
            End Get
            Set(ByVal value As デバイス)
                _認証ログ年月 = value
            End Set
        End Property

        Private _認証ログ日時 As デバイス
        Public Property 認証ログ日時() As デバイス
            Get
                Return _認証ログ日時
            End Get
            Set(ByVal value As デバイス)
                _認証ログ日時 = value
            End Set
        End Property

        Private _認証ログ分秒 As デバイス
        Public Property 認証ログ分秒() As デバイス
            Get
                Return _認証ログ分秒
            End Get
            Set(ByVal value As デバイス)
                _認証ログ分秒 = value
            End Set
        End Property


        ''' <summary>
        ''' タグ名から初期化パラメータを取得する
        ''' </summary>
        ''' <param name="タグ"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetIniParamByTag(ByVal タグ As String) As Settings.初期化デバイス
            Return デバイス初期設定(GetIniIndexByTag(タグ))
        End Function

        ''' <summary>
        ''' タグ名から初期化パラメータを取得する
        ''' </summary>
        ''' <param name="タグ"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetIniIndexByTag(ByVal タグ As String) As Integer
            Dim dev As Settings.初期化デバイス = Nothing
            Dim i As Integer
            For i = 0 To デバイス初期設定.Length - 1
                If デバイス初期設定(i).タグ = タグ Then
                    Exit For
                End If
            Next
            Return i
        End Function
    End Class

    Private x As New 初期化デバイス()

    Public APL_DB接続文字列 As String = "Data Source=FA-06024PNA\SQLEXPRESS;Initial Catalog=TCNYUTAI_DB;User ID=TCNYUTAI_LOGIN;Password=oresama"
    Public APL_ＤＢバックアップファイル名 As String() = {"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Backup\TCNYUTAI_DB.bak"}
    Public APL_ＤＢ名 As String = "TCNYUTAI_DB"

    Public APL_ログ保存フォルダ As String = ".\Log"
    Public APL_ログファイルベース名 As String = "APL"
    Public APL_ログ保存日数 As Integer = 1

    Public APL_日締め時間 As String = "03:00"
    Public APL_時刻同期間隔秒 As Integer = 3600

    Public APL_アラームバルーン表示秒 As Integer = 20
    Public APL_アラーム読み出し間隔 As Integer = 10000  '10秒

    Public APL_要求受信キュー名 As String = ".\Private$\NyutaiREQ"
    Public APL_応答受信キュー名 As String = ".\Private$\NyutaiANS"

    Public APL_センサ読み出し間隔 As Integer = 10000  '10秒

    Public APL_入退ログ保存日数 As Integer = 200
    Public APL_入退履歴保存日数 As Integer = 200

    Public APL_アンチパスバック転送有効 As Boolean = False

    Public Const PLC_最大管理件数 As Integer = 10000
    Public Const PLC_セキュリティデータレジスタ開始位置 As Integer = 0
    Public Const PLC_入場状態レジスタ開始位置 As Integer = PLC_セキュリティデータレジスタ開始位置 + (PLC_最大管理件数 * 10) + 20
    Public Const PLC_ログ１格納レジスタ As Integer = PLC_入場状態レジスタ開始位置 + PLC_最大管理件数 * 1
    Public Const PLC_ログ１最大件数 As Integer = 100
    Public Const PLC_ログ２格納レジスタ As Integer = PLC_ログ１格納レジスタ + PLC_ログ１最大件数 * 15
    Public Const PLC_ログ２最大件数 As Integer = 100
    Public Const PLC_認識情報レジスタ開始位置 As Integer = PLC_ログ２格納レジスタ + PLC_ログ２最大件数 * 15
    Public Const PLC_認識情報最大件数 As Integer = 1000

    Public PlcArray As Plc() = { _
        New Plc( _
                "正門/桜門", _
                1, _
                New 初期化デバイス() { _
                    New 初期化デバイス("D0003", 1, "ＯＫＬＥＤ点灯時間(×10ms)", 50S), _
                    New 初期化デバイス("D0004", 1, "ＯＫブザー鳴動時間(×10ms)", 50S), _
                    New 初期化デバイス("D0005", 1, "ＮＧＬＥＤ点灯時間(×10ms)", 500S), _
                    New 初期化デバイス("D0006", 1, "ＮＧブザー鳴動時間(×10ms)", 500S), _
                    New 初期化デバイス("D0008", 1, "セキュリティデータレジスタ開始位置", PLC_セキュリティデータレジスタ開始位置), _
                    New 初期化デバイス("D0010", 1, "セキュリティデータ登録最大件数", PLC_最大管理件数), _
                    New 初期化デバイス("D0012", 1, "入場状態レジスタ開始位置", PLC_入場状態レジスタ開始位置), _
                    New 初期化デバイス("D0014", 1, "ログ１格納レジスタ開始位置", PLC_ログ１格納レジスタ), _
                    New 初期化デバイス("D0016", 1, "ログ１格納最大件数", PLC_ログ１最大件数), _
                    New 初期化デバイス("D0018", 1, "ログ２格納レジスタ開始位置", PLC_ログ２格納レジスタ), _
                    New 初期化デバイス("D0020", 1, "ログ２格納最大件数", PLC_ログ２最大件数), _
                    New 初期化デバイス("D0022", 1, "認識情報レジスタ開始位置", PLC_認識情報レジスタ開始位置), _
                    New 初期化デバイス("D0024", 1, "認識情報レジスタ最大件数", PLC_認識情報最大件数), _
                    New 初期化デバイス("D0027", 1, "前回タグ削除時間(×10ms)", 200S), _
                    New 初期化デバイス("D0028", 1, "前回タグ削除モード", 1S)}, _
                New デバイス() { _
                    New デバイス("B130", 0, "ＣＰＵ ＲＵＮ"), _
                    New デバイス("B132", 1, "バッテリ低下"), _
                    New デバイス("B150", 1, "#１コンバータ異常（正門車両A）"), _
                    New デバイス("B151", 1, "#２コンバータ異常（正門車両B）"), _
                    New デバイス("B152", 1, "#３コンバータ異常（正門歩行者A）"), _
                    New デバイス("B153", 1, "#４コンバータ異常（正門歩行者B）"), _
                    New デバイス("B154", 1, "#５コンバータ異常（桜門歩行者A）"), _
                    New デバイス("B155", 1, "#６コンバータ異常（桜門歩行者B）"), _
                    New デバイス("B160", 1, "CC-Link#１リンク異常（正門車両A）"), _
                    New デバイス("B161", 1, "CC-Link#２リンク異常（正門車両B）"), _
                    New デバイス("B162", 1, "CC-Link#３リンク異常（正門歩行者A）"), _
                    New デバイス("B163", 1, "CC-Link#４リンク異常（正門歩行者B）"), _
                    New デバイス("B164", 1, "CC-Link#５リンク異常（桜門歩行者A）"), _
                    New デバイス("B165", 1, "CC-Link#６リンク異常（桜門歩行者B）"), _
                    New デバイス("B16A", 1, "CC-Linkマスタ#１異常")}, _
                New デバイス() _
                { _
                        New デバイス("D70", 0, "正門車両A"), _
                        New デバイス("D71", 0, "正門車両B"), _
                        New デバイス("D72", 0, "正門歩行者A"), _
                        New デバイス("D73", 0, "正門歩行者B"), _
                        New デバイス("D74", 0, "桜門歩行者A"), _
                        New デバイス("D75", 0, "桜門歩行者B")}, _
                New デバイス("D0006", 0, "アンチパスバック有効"), _
                New デバイス("B002", 1, "リセット要求"), _
                New デバイス("B102", 1, "リセット応答"), _
                New デバイス("B003", 1, "セキュリティデータ書込要求"), _
                New デバイス("B103", 1, "セキュリティデータ書込応答"), _
                New デバイス("B100", 1, "認識情報転送データあり"), _
                New デバイス("B104", 1, "認識情報読出要求"), _
                New デバイス("B004", 1, "認識情報読出応答"), _
                New デバイス("D518", 1, "認証ログ件数"), _
                New デバイス("D520", 1, "認証ログ局番", 10, 15), _
                New デバイス("D521", 1, "認証ログアンテナ", 10, 15), _
                New デバイス("D522", 1, "認証ログタグID", 10, 15, 8), _
                New デバイス("D530", 1, "認証ログステータス", 10, 15), _
                New デバイス("D531", 1, "認証ログ入出区分", 10, 15), _
                New デバイス("D532", 1, "認証ログ年月", 10, 15), _
                New デバイス("D533", 1, "認証ログ日時", 10, 15), _
                New デバイス("D534", 1, "認証ログ分秒", 10, 15) _
            )}


    'Public PLC_論理局番 As Integer = 12
    '''' <summary>
    '''' 初期設定書き込みデバイス
    '''' </summary>
    '''' <remarks></remarks>
    'Public PLC_デバイス初期設定 As 初期化デバイス() = { _
    '        New 初期化デバイス("D0003", 1, "ＯＫＬＥＤ点灯時間(×10ms)", 50S), _
    '        New 初期化デバイス("D0004", 1, "ＯＫブザー鳴動時間(×10ms)", 50S), _
    '        New 初期化デバイス("D0005", 1, "ＮＧＬＥＤ点灯時間(×10ms)", 500S), _
    '        New 初期化デバイス("D0006", 1, "ＮＧブザー鳴動時間(×10ms)", 500S), _
    '        New 初期化デバイス("D0008", 1, "セキュリティデータレジスタ開始位置", PLC_セキュリティデータレジスタ開始位置), _
    '        New 初期化デバイス("D0010", 1, "セキュリティデータ登録最大件数", PLC_最大管理件数), _
    '        New 初期化デバイス("D0012", 1, "入場状態レジスタ開始位置", PLC_入場状態レジスタ開始位置), _
    '        New 初期化デバイス("D0014", 1, "ログ１格納レジスタ開始位置", PLC_ログ１格納レジスタ), _
    '        New 初期化デバイス("D0016", 1, "ログ１格納最大件数", PLC_ログ１最大件数), _
    '        New 初期化デバイス("D0018", 1, "ログ２格納レジスタ開始位置", PLC_ログ２格納レジスタ), _
    '        New 初期化デバイス("D0020", 1, "ログ２格納最大件数", PLC_ログ２最大件数), _
    '        New 初期化デバイス("D0022", 1, "認識情報レジスタ開始位置", PLC_認識情報レジスタ開始位置), _
    '        New 初期化デバイス("D0024", 1, "認識情報レジスタ最大件数", PLC_認識情報最大件数), _
    '        New 初期化デバイス("D0027", 1, "前回タグ削除時間(×10ms)", 200S), _
    '        New 初期化デバイス("D0028", 1, "前回タグ削除モード", 1S), _
    '        New 初期化デバイス("D0060", 1, "扉開継続時間（×100ms）（通用口）", 300S), _
    '        New 初期化デバイス("D0061", 1, "扉開継続時間（×100ms）（支店入口）", 300S), _
    '        New 初期化デバイス("D0062", 1, "扉開継続時間（×100ms）（エントランス）", 300S), _
    '        New 初期化デバイス("D0063", 1, "扉開継続時間（×100ms）（４Ｆ）", 6000S), _
    '        New 初期化デバイス("D0064", 1, "扉開継続時間（×100ms）（５Ｆ）", 6000S), _
    '        New 初期化デバイス("D0065", 1, "扉開継続時間（×100ms）（６Ｆ）", 6000S), _
    '        New 初期化デバイス("D0066", 1, "扉開継続時間（×100ms）（７Ｆ）", 6000S), _
    '        New 初期化デバイス("D0067", 1, "扉開継続時間（×100ms）（８Ｆ）", 6000S), _
    '        New 初期化デバイス("D0080", 1, "開鍵継続時間（×100ms）（通用口）", 100S), _
    '        New 初期化デバイス("D0081", 1, "開鍵継続時間（×100ms）（支店入口）", 100S), _
    '        New 初期化デバイス("D0082", 1, "開鍵継続時間（×100ms）（エントランス）", 100S), _
    '        New 初期化デバイス("D0083", 1, "開鍵継続時間（×100ms）（４Ｆ）", 100S), _
    '        New 初期化デバイス("D0084", 1, "開鍵継続時間（×100ms）（５Ｆ）", 100S), _
    '        New 初期化デバイス("D0085", 1, "開鍵継続時間（×100ms）（６Ｆ）", 100S), _
    '        New 初期化デバイス("D0086", 1, "開鍵継続時間（×100ms）（７Ｆ）", 100S), _
    '        New 初期化デバイス("D0087", 1, "開鍵継続時間（×100ms）（８Ｆ）", 100S) _
    '    }

    'Public PLC_エラー情報 As デバイス() = { _
    '        New デバイス("B130", 0, "ＣＰＵ ＲＵＮ"), _
    '        New デバイス("B132", 1, "バッテリ低下"), _
    '        New デバイス("B150", 1, "#１コンバータ異常（通用口）"), _
    '        New デバイス("B151", 1, "#２コンバータ異常（支店入口）"), _
    '        New デバイス("B152", 1, "#３コンバータ異常（エントランス）"), _
    '        New デバイス("B153", 1, "#４コンバータ異常（４Ｆ）"), _
    '        New デバイス("B154", 1, "#５コンバータ異常（５Ｆ）"), _
    '        New デバイス("B155", 1, "#６コンバータ異常（６Ｆ）"), _
    '        New デバイス("B156", 1, "#７コンバータ異常（７Ｆ）"), _
    '        New デバイス("B157", 1, "#８コンバータ異常（８Ｆ）"), _
    '        New デバイス("B160", 1, "CC-Link#１リンク異常（通用口）"), _
    '        New デバイス("B161", 1, "CC-Link#２リンク異常（支店入口）"), _
    '        New デバイス("B162", 1, "CC-Link#３リンク異常（エントランス）"), _
    '        New デバイス("B163", 1, "CC-Link#４リンク異常（４Ｆ）"), _
    '        New デバイス("B164", 1, "CC-Link#５リンク異常（５Ｆ）"), _
    '        New デバイス("B165", 1, "CC-Link#６リンク異常（６Ｆ）"), _
    '        New デバイス("B166", 1, "CC-Link#７リンク異常（７Ｆ）"), _
    '        New デバイス("B167", 1, "CC-Link#８リンク異常（８Ｆ）"), _
    '        New デバイス("B16A", 1, "CC-Linkマスタ#１異常（１Ｆ）"), _
    '        New デバイス("B16B", 1, "CC-Linkマスタ#２異常（１Ｆ以外）"), _
    '        New デバイス("B170", 1, "＃１錠故障（通用口）"), _
    '        New デバイス("B171", 1, "＃２錠故障（支店入口）"), _
    '        New デバイス("B172", 1, "＃３錠故障（エントランス）"), _
    '        New デバイス("B173", 1, "＃４錠故障（４Ｆ）"), _
    '        New デバイス("B174", 1, "＃５錠故障（５Ｆ）"), _
    '        New デバイス("B175", 1, "＃６錠故障（６Ｆ）"), _
    '        New デバイス("B176", 1, "＃７錠故障（７Ｆ）"), _
    '        New デバイス("B177", 1, "＃８錠故障（８Ｆ）") _
    '    }

    '''' <summary>
    '''' アンチパスバック有効
    '''' </summary>
    '''' <remarks></remarks>
    'Public PLC_アンチパスバック有効 As デバイス = New デバイス("D0006", 0, "アンチパスバック有効")

    '''' <summary>
    '''' リセットデバイス
    '''' </summary>
    '''' <remarks></remarks>
    'Public PLC_リセット要求 As デバイス = New デバイス("B002", 1, "リセット要求")
    'Public PLC_リセット応答 As デバイス = New デバイス("B102", 1, "リセット応答")

    '''' <summary>
    '''' 認証データ書き込みデバイス
    '''' </summary>
    '''' <remarks></remarks>
    'Public PLC_セキュリティデータ書込要求 As デバイス = New デバイス("B003", 1, "セキュリティデータ書込要求")
    'Public PLC_セキュリティデータ書込応答 As デバイス = New デバイス("B103", 1, "セキュリティデータ書込応答")

    '''' <summary>
    '''' 認識情報転送デバイス
    '''' </summary>
    '''' <remarks></remarks>
    'Public PLC_認識情報転送データあり As デバイス = New デバイス("B100", 1, "認識情報転送データあり")
    'Public PLC_認識情報読出要求 As デバイス = New デバイス("B104", 1, "認識情報読出要求")
    'Public PLC_認識情報読出応答 As デバイス = New デバイス("B004", 1, "認識情報読出応答")

    ''''' <summary>
    ''''' ログ情報格納エリア切替デバイス
    ''''' </summary>
    ''''' <remarks></remarks>
    ''Public PLC_ログ情報格納エリア切替要求 As デバイス = New デバイス("B005", 1, "ログ情報格納エリア切替要求")
    ''Public PLC_ログ情報格納エリア切替応答 As デバイス = New デバイス("B105", 1, "ログ情報格納エリア切替応答")

    ''''' <summary>
    ''''' ログ情報格納エリア切替デバイス
    ''''' </summary>
    ''''' <remarks></remarks>
    ''Public PLC_ログ情報格納エリア初期化要求 As デバイス = New デバイス("B006", 1, "ログ情報格納エリア初期化要求")
    ''Public PLC_ログ情報格納エリア初期化応答 As デバイス = New デバイス("B106", 1, "ログ情報格納エリア初期化応答")

    ''''' <summary>
    ''''' 時刻同期デバイス
    ''''' </summary>
    ''''' <remarks></remarks>
    ''Public PLC_時刻同期要求 As デバイス = New デバイス("B007", 1, "時刻同期要求")
    ''Public PLC_時刻同期応答 As デバイス = New デバイス("B107", 1, "時刻同期応答")

    ''''' <summary>
    ''''' 認証情報検証デバイス
    ''''' </summary>
    ''''' <remarks></remarks>
    ''Public PLC_セキュリティデータ検証要求 As デバイス = New デバイス("B110", 1, "セキュリティデータ検証要求", 32)
    ''Public PLC_セキュリティデータ検証応答 As デバイス = New デバイス("B10", 1, "セキュリティデータ検証応答", 32)

    '''' <summary>
    '''' 認証ログ
    '''' </summary>
    '''' <remarks></remarks>
    'Public PLC_認証ログ件数 As デバイス = New デバイス("D518", 1, "認証ログ件数")
    'Public PLC_認証ログ局番 As デバイス = New デバイス("D520", 1, "認証ログ局番", 10, 15)
    'Public PLC_認証ログアンテナ As デバイス = New デバイス("D521", 1, "認証ログアンテナ", 10, 15)
    'Public PLC_認証ログタグID As デバイス = New デバイス("D522", 1, "認証ログタグID", 10, 15, 8)
    'Public PLC_認証ログステータス As デバイス = New デバイス("D530", 1, "認証ログステータス", 10, 15)
    'Public PLC_認証ログ認証入出区分 As デバイス = New デバイス("D531", 1, "認証ログ入出区分", 10, 15)
    'Public PLC_認証ログ年月 As デバイス = New デバイス("D532", 1, "認証ログ年月", 10, 15)
    'Public PLC_認証ログ日時 As デバイス = New デバイス("D533", 1, "認証ログ日時", 10, 15)
    'Public PLC_認証ログ分秒 As デバイス = New デバイス("D534", 1, "認証ログ分秒", 10, 15)

    ''''' <summary>
    ''''' ゲート開
    ''''' </summary>
    ''''' <remarks></remarks>
    ''Public PLC_入口ゲート開 As デバイス = New デバイス("B030", 1, "入口ゲート開")
    ''Public PLC_出口ゲート開 As デバイス = New デバイス("B031", 1, "出口ゲート開")

    'Public PLC_センサ情報 As デバイス() = { _
    '                            New デバイス("D70", 0, "入退モード（１Ｆ通用口）"), _
    '                            New デバイス("D71", 0, "入退モード（支店入口）"), _
    '                            New デバイス("D72", 0, "入退モード（エントランス）"), _
    '                            New デバイス("D73", 0, "入退モード（４Ｆ）"), _
    '                            New デバイス("D74", 0, "入退モード（５Ｆ）"), _
    '                            New デバイス("D75", 0, "入退モード（６Ｆ）"), _
    '                            New デバイス("D76", 0, "入退モード（７Ｆ）"), _
    '                            New デバイス("D77", 0, "入退モード（８Ｆ）") _
    '    }
End Class

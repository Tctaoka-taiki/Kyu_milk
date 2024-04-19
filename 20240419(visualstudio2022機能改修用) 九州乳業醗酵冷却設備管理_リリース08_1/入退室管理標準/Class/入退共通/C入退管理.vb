Public Class C入退管理
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    ''SQLSVクラス
    'Public gDp As CSdp
    Public Shared DIコンテナ As 共通.IDIコンテナ = New CDIコンテナ三菱UHF

    ''エラーログクラス
    'Public Shared gclaLOG As New CLog(CLog.Enmログ種別.アプリケーション)

    '#####################################################################################
    'プロパティー
    '#####################################################################################

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Protected Sub New()
    End Sub

    Public Shared Function 入場状態設定応答_ローカルキュー名取得() As String
        Return ".\Private$\入場状態設定_応答"
    End Function
    Public Shared Function 入場状態設定応答_グローバルキュー名取得() As String
        Return "FormatName:DIRECT=OS:" & Environment.MachineName & "\Private$\入場状態設定_応答"
    End Function
    Public Shared Function 入場状態設定要求キュー名取得() As String
        Return CUtil.設定関連.設定文字列読込("入退サーバ.入場状態設定要求キュー名")
    End Function


    Public Shared Function ゲート開閉要求キュー名取得() As String
        Return CUtil.設定関連.設定文字列読込("入退サーバ.ゲート開閉要求キュー名")
    End Function
    Public Shared Function ゲート開閉応答ローカルキュー名取得() As String
        Return ".\Private$\ゲート開閉_応答"
    End Function
    Public Shared Function ゲート開閉応答グローバルキュー名取得() As String
        Return "FormatName:DIRECT=OS:" & Environment.MachineName & "\Private$\ゲート開閉_応答"
    End Function


    Public Shared Function アンチパスバック設定要求キュー名取得() As String
        Return CUtil.設定関連.設定文字列読込("入退サーバ.アンチパスバック設定要求キュー名")
    End Function
    Public Shared Function アンチパスバック設定応答ローカルキュー名取得() As String
        Return ".\Private$\アンチパスバック設定_応答"
    End Function
    Public Shared Function アンチパスバック設定応答グローバルキュー名取得() As String
        Return "FormatName:DIRECT=OS:" & Environment.MachineName & "\Private$\アンチパスバック設定_応答"
    End Function

    Public Interface I要求応答

    End Interface


End Class

'TODO アプリケーション固有の定義となるため定義方法の別案を考える
'Public Enum enm画面ID
'End Enum
Public Enum enm処理区分
    追加
    変更
    削除
    表示
End Enum

Public Enum enmUIモード
    表示
    編集
End Enum

Public Enum enmSQL種別
    一覧表示
    一覧CSV
End Enum

Public Module M定数

#Region "定義定数"
    ''システム
    Public Const ENMSYSTEM As gEnumシステム区分 = gEnumシステム区分.E1_情報

    ''フラグ(文字)
    Public Const STRFLGON As String = "1"
    Public Const STRFLGOFF As String = "0"
    ''フラグ(数値)
    'Public Const INTFLGON As Integer = 1
    'Public Const INTFLGOFF As Integer = 0

    ''有無(未済)の表示
    Public Const STR_有 As String = "●"
    Public Const STR_無 As String = "　"
    Public Const STR_部 As String = "▲"
    '有無(未済)コンボの表示名と値
    'Public Const STR_CMB無有 As String = "無(未),有(済)"
    'Public Const STR_CMB無有値 As String = STR_無 & "," & STR_有

    'Public Const FORMAT_数量_小数1 As String = "#,##0.0"
    'Public Const FORMAT_数量_小数2 As String = "#,##0.00"
    'Public Const FORMAT_数量_小数3 As String = "#,##0.000"
    'Public Const FORMAT_整数 As String = "#,##0"

    Public Const FORMAT_日付 As String = "yyyy/MM/dd"
    Public Const FORMAT_日時 As String = "yyyy/MM/dd HH:mm:ss"
    Public Const FORMAT_時分 As String = "HH:mm"
    Public Const FORMAT_時分秒 As String = "HH:mm:ss"

    Public Const FORMAT_日時14 As String = "yyyyMMddHHmmss"
#End Region

#Region "定数定義(データ長)"
    '共通項目 --------------------------------------------------
    Public Const LEN_日付 As Integer = 8
    Public Const LEN_数量 As Integer = 5
    Public Const LEN_郵便番号 As Integer = 8
    Public Const LEN_電話番号 As Integer = 20
    Public Const LEN_内線番号 As Integer = 20
    Public Const LEN_処理区分 As Integer = 1
    Public Const LEN_社員番号 As Integer = 6
    Public Const LEN_企業区分コード As Integer = 12
    Public Const LEN_企業コード As Integer = 12
    Public Const LEN_事業所コード As Integer = 12
    Public Const LEN_部署コード As Integer = 12
    Public Const LEN_企業区分名 As Integer = 32
    Public Const LEN_管理者名 As Integer = 32
    Public Const LEN_管理者コード As Integer = 32
    Public Const LEN_クラブ名 As Integer = 32

    ''システム --------------------------------------------------
    Public Const LEN_担当者CD As Integer = 6
    Public Const LEN_担当者名 As Integer = 20
    Public Const LEN_パスワード As Integer = 8
    Public Const LEN_端末名 As Integer = 32
    Public Const LEN_機器ID As Integer = 5

    ''マスタ ----------------------------------------------------


#End Region

#Region "定数定義(最小値・最大値)"
    'Public Const MIN_数量 As Integer = 0
    'Public Const MAX_数量 As Integer = 9999999
#End Region

#Region "定数定義(MSG_)"
    Public Const MSG_処理中 As String = "・・・しばらくお待ちください。"
    Public Const MSG_検索中 As String = "検索中" & M定数.MSG_処理中
    Public Const MSG_登録中 As String = "登録中" & M定数.MSG_処理中
    Public Const MSG_削除中 As String = "削除中" & M定数.MSG_処理中
    Public Const MSG_実行中 As String = "実行中" & M定数.MSG_処理中
    Public Const MSG_発行中 As String = "発行中" & M定数.MSG_処理中
    Public Const MSG_確定中 As String = "確定可能データ検索中" & M定数.MSG_処理中
    Public Const MSG_更新中 As String = "更新中" & M定数.MSG_処理中

    Public Const MSG_確認 As String = "よろしいですか？"
    Public Const MSG_登録確認 As String = "データを登録します。" & MSG_確認
    Public Const MSG_削除確認 As String = "データを削除します。" & MSG_確認
    Public Const MSG_選択データ削除確認 As String = "選択データを削除します。" & M定数.MSG_確認
    Public Const MSG_実行確認 As String = "処理を実行します。" & M定数.MSG_確認
    Public Const MSG_発行確認 As String = "を発行します。" & M定数.MSG_確認
    Public Const MSG_ラベル発行確認 As String = "ラベルを発行します。" & MSG_確認
    Public Const MSG_リスト発行確認 As String = "リストを発行します。" & MSG_確認

    Public Const MSG_該当データなし As String = "該当データはありません。"
    Public Const MSG_該当データ件数 As String = "該当データ件数は, #,##0件です。"

    Public Const MSG_登録結果 As String = "データを登録しました。"
    Public Const MSG_削除結果 As String = "データを削除しました。"

    '注意系
    Public Const MSG_登録済 As String = "すでに登録済です。"
    Public Const MSG_複数選択不可 As String = "データが複数選択されています。"
    Public Const MSG_データ未選択 As String = "データを選択して下さい。"
    Public Const MSG_未指定 As String = "を指定して下さい。"
    Public Const MSG_不正 As String = "に誤りがあります。"
    Public Const MSG_範囲不正 As String = "の範囲に誤りがあります。"
    Public Const MSG_桁数不正 As String = "の桁数が不正です。"
    Public Const MSG_TAG読込エラー As String = "カード読込エラー発生。"

#End Region

#Region "列挙型定義"
    ''編集での画面移動モード
    Public Enum gEnumMoveMode
        新規登録
        編集
        参照新規
        照会新規
        詳細新規
        照会編集
        詳細編集
    End Enum

    ''DPシステム区分
    Public Enum gEnumシステム区分
        E1_情報 = 1
        E3_無線 = 3
    End Enum

    ''DP画面使用ランク
    'Public Enum gEnum画面使用ランク
    '    E0_使用不可 = 0
    '    E1_参照 = 1
    '    E2_操作可 = 2
    'End Enum

    ''DPシステム状態
    'Public Enum gEnumシステム状態
    '    E0_日締め済 = 0
    '    E1_業務中 = 1
    '    E2_業務終了 = 2
    '    E3_日締め中 = 3
    'End Enum

#End Region

#Region "色宣言"
    ''グリッドの場合、スタイルの名前と色変数のセットで宣言
    Public Const COLORNAME_白 As String = "白"
    'Public COLOR_白 As Color = System.Drawing.Color.White

    ''担当者マスタ
    'Public Const COLORNAME_情報 As String = "情報"
    'Public Const COLORNAME_設備 As String = "設備"
    'Public Const COLORNAME_無線 As String = "無線"
    'Public COLOR_情報 As Color = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
    'Public COLOR_設備 As Color = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    'Public COLOR_無線 As Color = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
#End Region

End Module

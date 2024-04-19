' TODO アプリケーション固有の定義となるが、標準側でも使用するため、定義方法の別案を考える
Public Enum enm画面ID
    登録者情報照会
    登録者情報メンテナンス
End Enum

Public Enum enmメンテ処理対象
    企業区分 = 1
    企業 = 2
    部署 = 3
    ゲート = 4
    パターン = 5
    事業所 = 6
    管理者 = 7
    管理者機能 = 8
    クラブ = 9
End Enum

Public Enum enm入出区分
    入口 = 0
    出口 = 1
End Enum

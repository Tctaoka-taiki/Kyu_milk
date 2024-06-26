Public Module MCtl
    '#####################################################################################
    '型
    '#####################################################################################
    Public Enum gEnmCharType
        Numonly     '数字のみ
        Letter      '文字のみ & スペース
        NumLetter   '文字＆数字 & スペース
        All         '入力制限なし
        WildNumonly     '数字のみ + *
        WildLetter      '文字のみ & スペース + *
        WildNumLetter   '文字＆数字  & スペース+ *
        NumLetter非日本語   '文字＆数字 & スペース

    End Enum

    Public Enum gEnm入力条件
        Nomal       '入力許可
        Fuka        '入力不可
        Hissu       '必須入力
        Impact      '強調(目立つ色を使用する)
    End Enum

    Public Enum gEnmFromTo
        None    ''なし
        Num     ''数値
        Letter  ''文字
    End Enum

    '#####################################################################################
    'メンバ変数
    '#####################################################################################

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

End Module

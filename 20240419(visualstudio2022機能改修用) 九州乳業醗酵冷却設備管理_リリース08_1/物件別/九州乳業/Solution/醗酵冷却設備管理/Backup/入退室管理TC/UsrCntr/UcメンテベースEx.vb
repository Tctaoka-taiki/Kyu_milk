﻿Public Class UcメンテベースEx
    Inherits Ucメンテベース

    '#####################################################################################
    '型
    '#####################################################################################

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
    Protected Overrides Function CreateSQLオブジェクト() As CSql
        Return New CSqlEx
    End Function
End Class

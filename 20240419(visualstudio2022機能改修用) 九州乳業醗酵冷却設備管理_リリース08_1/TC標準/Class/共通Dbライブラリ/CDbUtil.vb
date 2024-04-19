﻿Imports System.Data.Common

Public Class CDbUtil
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
    ''' <summary>
    ''' 空文字列はDbNullに置き換えて返す
    ''' </summary>
    ''' <param name="変換前文字列">変換前文字列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function 空文字列ToDBNull(ByVal 変換前文字列 As String) As Object
        Return IIf(変換前文字列 = "", DBNull.Value, 変換前文字列)
    End Function
End Class

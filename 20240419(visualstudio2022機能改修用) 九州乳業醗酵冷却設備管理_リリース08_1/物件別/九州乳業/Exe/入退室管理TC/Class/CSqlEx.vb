Public Class CSqlEx
    Inherits CSql

    '#####################################################################################
    '型
    '#####################################################################################
    Const 列名_タグID As String = "タグID"
    Const 列名_カードNO As String = "カードNO"
    Const 列名_更新日時 As String = "更新日時"

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
    Public Sub gSubWhere氏名検索条件(ByVal 検索列名1 As String, ByVal 検索列名2 As String, ByVal 条件文字列 As String)
        Dim str氏名検索条件 As String = 条件文字列.Trim
        If str氏名検索条件 <> "" Then
            gSubWhere("(" & あいまい検索条件対応SQL句取得(検索列名1 & " + " & 検索列名2, str氏名検索条件) & _
                        " OR " & あいまい検索条件対応SQL句取得(検索列名1, str氏名検索条件) & _
                        " OR " & あいまい検索条件対応SQL句取得(検索列名2, str氏名検索条件) & _
                        ")")
        End If
    End Sub

    ''' <summary>
    ''' 更新日時取得用
    ''' </summary>
    ''' <param name="元列名"></param>
    ''' <param name="表示列名"></param>
    ''' <remarks></remarks>
    Public Sub gSubSelect日時文字列(Optional ByVal 元列名 As String = "更新日時", Optional ByVal 表示列名 As String = "更新日時", Optional ByVal IsNullToEmpty As Boolean = False)
        If IsNullToEmpty Then
            gSubSelect("ISNULL(convert(nvarchar," & 元列名 & ",121),'') " & 表示列名)
        Else
            gSubSelect("convert(nvarchar," & 元列名 & ",121) " & 表示列名)
        End If
    End Sub

    Public Sub gSubSelectYYYYMMDDHHMMSS(ByVal 元列名 As String, Optional ByVal 表示列名 As String = "", Optional ByVal Isスラッシュあり As Boolean = True)
        Dim 区切り文字 As String = ""
        If Isスラッシュあり Then
            区切り文字 = "/"
        End If
        gSubSelect("replace(substring(convert(nvarchar," & 元列名 & ",020),1,19),'-','" & 区切り文字 & "') " & 表示列名)
    End Sub

    Public Sub gSubSelectYYYYMMDD(ByVal 元列名 As String, Optional ByVal 表示列名 As String = "", Optional ByVal Isスラッシュあり As Boolean = True, Optional ByVal IsNullToEmpty As Boolean = False)
        Dim 区切り文字 As String = ""
        If Isスラッシュあり Then
            区切り文字 = "/"
        End If
        If IsNullToEmpty Then
            gSubSelect("ISNULL(replace(substring(convert(nvarchar," & 元列名 & ",020),1,10),'-','" & 区切り文字 & "'),'') " & 表示列名)
        Else
            gSubSelect("replace(substring(convert(nvarchar," & 元列名 & ",020),1,10),'-','" & 区切り文字 & "') " & 表示列名)
        End If
    End Sub

    Public Sub gSubSelectYYMMDDHHMMSS(ByVal 元列名 As String, Optional ByVal 表示列名 As String = "", Optional ByVal Isスラッシュあり As Boolean = True)
        Dim 区切り文字 As String = ""
        If Isスラッシュあり Then
            区切り文字 = "/"
        End If
        gSubSelect("replace(substring(convert(nvarchar," & 元列名 & ",020),3,17),'-','" & 区切り文字 & "') " & 表示列名)
    End Sub

    ''' <summary>
    ''' 比較条件用日時文字列をセットする
    ''' </summary>
    ''' <param name="列名"></param>
    ''' <param name="値文字列"></param>
    ''' <remarks>依存:SQLServer</remarks>
    Public Sub gSubWhere日時文字列(ByVal 列名 As String, ByVal 値文字列 As String)
        gSubWhere("convert(nvarchar," & 列名 & ",121) = '" & 値文字列 & "'")
    End Sub

    Public Sub gSubWhere日時文字列YYYYMMDD(ByVal 列名 As String, ByVal 値文字列 As String, Optional ByVal 条件記号 As String = "=", Optional ByVal IsNull値含む As Boolean = False)
        If 値文字列 <> "" Then
            If IsNull値含む Then
                gSubWhere("(replace(substring(convert(nvarchar," & 列名 & ",020),1,10),'-','') " & 条件記号 & "'" & 値文字列 & "' or " & 列名 & " is null)")
            Else
                gSubWhere("replace(substring(convert(nvarchar," & 列名 & ",020),1,10),'-','')", 値文字列, 条件記号)
            End If
        End If
    End Sub
    Public Sub gSubWhere更新日時(ByVal 値文字列 As String)
        gSubWhere日時文字列(列名_更新日時, 値文字列)
    End Sub
End Class

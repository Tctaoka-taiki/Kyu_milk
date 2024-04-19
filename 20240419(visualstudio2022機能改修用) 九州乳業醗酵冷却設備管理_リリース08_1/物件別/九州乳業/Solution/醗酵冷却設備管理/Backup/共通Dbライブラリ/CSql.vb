Imports System.Text

''' <summary>
''' SQL文生成クラス
''' </summary>
''' <remarks></remarks>
Public Class CSql
    '#####################################################################################
    '型
    '#####################################################################################
    ''SQLValueSetCLASS
    Private Class CSql値セット
        Private mstrValue As String
        Private mIsシングルクォーテーションあり As Boolean

        Friend Sub New()
        End Sub

        Friend Property pStrValue() As String
            Get
                If mstrValue = "" Then
                    Return "NULL"
                Else
                    If Me.mIsシングルクォーテーションあり Then
                        Return "'" & Me.mstrValue & "'"
                    Else
                        Return Me.mstrValue
                    End If
                End If
            End Get
            Set(ByVal Value As String)
                Me.mstrValue = Value
            End Set
        End Property
        Friend Property pIsシングルクォーテーションあり() As Boolean
            Get
                Return Me.mIsシングルクォーテーションあり
            End Get
            Set(ByVal Value As Boolean)
                Me.mIsシングルクォーテーションあり = Value
            End Set
        End Property
    End Class

    ''複数の条件をつなげるときの列挙型
    Public Enum EnmWhere
        WhereAnd        '  "WHERE(HAVING)"または"AND" 
        WhereOr         '  "WHERE(HAVING)"または"OR"
        WhereNot
        OrStart         '  "WHERE(HAVING) ("　または　"OR (" ではじまる
        OrEnd           '  WHERE(HAVING)区の最後を  ")"  でおわる
    End Enum

    ''ワイルド検索列挙型
    Public Enum EnmWild
        NoWild
        Wild
        LocationWild
    End Enum
    ''SQL文の取得時のタイプ
    Public Enum SQL_TYPE
        SQL_SELECT
        SQL_SELECTINSERT
        SQL_INSERT
        SQL_UPDATE
        SQL_DELETE
        SQL_PACKAGE
        SQL_PRINT
    End Enum

    ''SQLクリア列挙
    Public Enum SQL_CLEAR
        C_Table
        C_Column
        C_Value
        C_Select
        C_From
        C_Where
        C_GroubBy
        C_OrderBy
        C_Having
        C_PakName
        C_PakReturnName
    End Enum

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    ''SQL作成配列変数
    Private marrColumn As New ArrayList
    Private marrValue As New ArrayList
    Private marrSelect As New ArrayList
    Private marrFrom As New ArrayList
    Private marrWhere As New ArrayList
    Private marrGroupBy As New ArrayList
    Private marrOrderBy As New ArrayList
    Private marrHaving As New ArrayList

    ''プロパティ変数
    Private mSQLTYPE As SQL_TYPE = SQL_TYPE.SQL_SELECT
    Private mstrTable As String
    Private mstrPacName As String
    Private mstrPacReturnName As String

    Public Shared デフォルトあいまい検索モード As String = ""
    Public あいまい検索モード As String = ""

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    ''プロパティー----------------------------------------------------------------------------
    Public WriteOnly Property pSQL取得タイプ() As SQL_TYPE
        Set(ByVal Value As SQL_TYPE)
            Me.mSQLTYPE = Value
        End Set
    End Property

    Public Property pパッケージ名() As String
        Get
            Return Me.mstrPacName
        End Get
        Set(ByVal Value As String)
            Me.mstrPacName = Value
        End Set
    End Property

    Public Property pパッケージの戻り名() As String
        Get
            Return Me.mstrPacReturnName
        End Get
        Set(ByVal Value As String)
            Me.mstrPacReturnName = Value
        End Set
    End Property

    Public Property pテーブル名() As String
        Get
            Return Me.mstrTable
        End Get
        Set(ByVal Value As String)
            Me.mstrTable = Value
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
    ''コンストラクタ--------------------------------------------------------------------------
    Public Sub New()
        あいまい検索モード = デフォルトあいまい検索モード
    End Sub

    Private Function mStrSELECT文の取得() As String
        With New StringBuilder
            If Me.marrSelect.Count = 0 Then Return "err not select field"
            If Me.marrFrom.Count = 0 Then Return "err not from table"

            ''SELECT
            .Append(Me.mStrArraySQL(Me.marrSelect, "SELECT" & vbCrLf & "  ", " ,"))

            ''FROM
            .Append(Me.mStrArraySQL(Me.marrFrom, " FROM" & vbCrLf & "  ", " ,"))

            ''WHERE
            If Me.marrWhere.Count > 0 Then
                .Append(Me.mStrArraySQL(Me.marrWhere, "", ""))
            End If

            ''Group By
            If Me.marrGroupBy.Count > 0 Then
                .Append(Me.mStrArraySQL(Me.marrGroupBy, " GROUP BY" & vbCrLf & "  ", " ,"))
            End If

            ''Having
            If Me.marrHaving.Count > 0 Then
                .Append(Me.mStrArraySQL(Me.marrHaving, "", ""))
            End If

            ''Order By
            If Me.marrOrderBy.Count > 0 Then
                .Append(Me.mStrArraySQL(Me.marrOrderBy, " ORDER BY" & vbCrLf & "  ", " ,"))
            End If

            Return .ToString
        End With

    End Function

    ''' <summary>
    ''' SELECTINSERT文の取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function mStrSelectInsert() As String
        Dim strSQL As New StringBuilder

        With strSQL
            If Me.pテーブル名 = "" Then Return "err not selectinsert table"
            If Me.marrColumn.Count = 0 Then Return "err not selectinsert column"
            If Me.marrColumn.Count <> Me.marrSelect.Count Then Return "err column:" & CStr(Me.marrColumn.Count) & " select:" & CStr(Me.marrSelect.Count)

            ''INSERT
            .Append("INSERT INTO " & Me.pテーブル名 & vbCrLf)
            .Append("(" & vbCrLf)

            ''Column
            .Append(Me.mStrArraySQL(Me.marrColumn, "  ", " ,"))

            .Append(")" & vbCrLf)

            'select
            .Append("(" & vbCrLf)
            .Append(Me.mStrSELECT文の取得)
            .Append(")" & vbCrLf)

            Return .ToString
        End With

    End Function

    ''' <summary>
    ''' INSERT文の取得
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function mStrInsert() As String
        Dim strSQL As New StringBuilder
        With strSQL
            If Me.pテーブル名 = "" Then Return "err not insert table"
            If Me.marrColumn.Count = 0 Then Return "err not insert column"
            If Me.marrValue.Count = 0 Then Return "err not insert value"
            If Me.marrColumn.Count <> Me.marrValue.Count Then Return "err column:" & CStr(Me.marrColumn.Count) & " value:" & CStr(Me.marrValue.Count)

            ''INSERT
            .Append("INSERT INTO " & Me.pテーブル名 & vbCrLf)
            .Append("(" & vbCrLf)

            ''Column
            .Append(Me.mStrArraySQL(Me.marrColumn, "  ", " ,"))

            .Append(")" & vbCrLf)

            'Value
            .Append("VALUES(" & vbCrLf)
            .Append("  " & CType(Me.marrValue.Item(0), CSql値セット).pStrValue & vbCrLf)
            For i As Integer = 1 To Me.marrValue.Count - 1
                .Append(" ," & CType(Me.marrValue.Item(i), CSql値セット).pStrValue & vbCrLf)
            Next

            .Append(")" & vbCrLf)

            Return .ToString
        End With

    End Function

    Private Function mUPDATE文の取得() As String
        Dim strSQL As New StringBuilder
        Dim i As Integer

        With strSQL
            If Me.pテーブル名 = "" Then Return "err not update table"
            If Me.marrColumn.Count = 0 Then Return "err not insert column"
            If Me.marrValue.Count = 0 Then Return "err not insert value"
            If Me.marrColumn.Count <> Me.marrValue.Count Then Return "err column:" & CStr(Me.marrColumn.Count) & " value:" & CStr(Me.marrValue.Count)

            ''Update
            .Append("UPDATE " & Me.pテーブル名 & " SET" & vbCrLf)

            ''ColumnValue
            .Append("  " & CStr(Me.marrColumn.Item(0)) & " = ")
            .Append(CType(Me.marrValue.Item(0), CSql値セット).pStrValue & vbCrLf)

            For i = 1 To Me.marrValue.Count - 1
                .Append(" ," & CStr(Me.marrColumn.Item(i)) & " = ")
                .Append(CType(Me.marrValue.Item(i), CSql値セット).pStrValue & vbCrLf)
            Next

            ''WHERE
            If Me.marrWhere.Count > 0 Then
                .Append(Me.mStrArraySQL(Me.marrWhere, "", ""))
            End If

            Return .ToString
        End With

    End Function

    Private Function mDELETE文の取得() As String
        Dim strSQL As New StringBuilder

        With strSQL
            If Me.pテーブル名 = "" Then Return "err not delete table"

            ''DELETE
            .Append("DELETE FROM " & Me.pテーブル名 & vbCrLf)

            ''WHERE
            If Me.marrWhere.Count > 0 Then
                .Append(Me.mStrArraySQL(Me.marrWhere, "", ""))
            End If

            Return .ToString
        End With

    End Function

    Private Function mPACKAGE文の取得() As String
        Dim strSQL As New StringBuilder
        Dim i As Integer

        With strSQL
            If Me.pパッケージ名 = "" Then Return "err not packagename"

            .Append("BEGIN ")
            If Me.pパッケージの戻り名 <> "" Then
                .Append(":" & Me.pパッケージの戻り名 & " := ")
            End If
            .Append(Me.pパッケージ名)

            If Me.marrValue.Count > 0 Then

                .Append("(")

                .Append("  " & CType(Me.marrValue.Item(0), CSql値セット).pStrValue)
                For i = 1 To Me.marrValue.Count - 1
                    .Append(" ," & CType(Me.marrValue.Item(i), CSql値セット).pStrValue)
                Next

                .Append("); END;")

            Else
                .Append("; END;")
            End If
            Return .ToString
        End With

    End Function

#Region "配列変数からSQL文の取得"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：mStrArraySQL
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：配列変数からSQL文の取得
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Function mStrArraySQL(ByVal objArr As ArrayList, ByVal str1 As String, ByVal strElse As String) As String
        With New StringBuilder
            .Append(str1 & CStr(objArr.Item(0)) & vbCrLf)
            For i As Integer = 1 To objArr.Count - 1
                .Append(strElse & CStr(objArr.Item(i)) & vbCrLf)
            Next
            Return .ToString
        End With
    End Function

    ''外部関数(Function)----------------------------------------------------------------------------
    Public Function gSQL文の取得() As String
        Select Case Me.mSQLTYPE
            Case SQL_TYPE.SQL_SELECT
                Return Me.mStrSELECT文の取得
            Case SQL_TYPE.SQL_SELECTINSERT
                Return Me.mStrSelectInsert
            Case SQL_TYPE.SQL_INSERT
                Return Me.mStrInsert
            Case SQL_TYPE.SQL_UPDATE
                Return Me.mUPDATE文の取得
            Case SQL_TYPE.SQL_DELETE
                Return Me.mDELETE文の取得
            Case SQL_TYPE.SQL_PRINT
                Return Me.mStrSELECT文の取得
            Case SQL_TYPE.SQL_PACKAGE
                Return Me.mPACKAGE文の取得
            Case Else
                Return ""
        End Select
    End Function

    Public Function gWHERE句の取得() As String
        If Me.marrWhere.Count > 0 Then
            Return Me.mStrArraySQL(Me.marrWhere, "", "")
        Else
            Return ""
        End If
    End Function

    ''外部関数(Sub)----------------------------------------------------------------------------
#Region "セットされたSQLのクリア"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubClearSQL
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：セットされたSQLのクリア
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Overloads Sub gSubClearSQL()
        Me.pSQL取得タイプ = SQL_TYPE.SQL_SELECT

        Me.pテーブル名 = ""

        Me.pパッケージ名 = ""
        Me.pパッケージの戻り名 = ""

        Me.marrColumn.Clear()
        Me.marrValue.Clear()
        Me.marrSelect.Clear()
        Me.marrFrom.Clear()
        Me.marrWhere.Clear()
        Me.marrGroupBy.Clear()
        Me.marrOrderBy.Clear()
        Me.marrHaving.Clear()
    End Sub

    ''セットされたSQLを個別にクリア
    Public Overloads Sub gSubClearSQL(ByVal enmSQLCLEAR As SQL_CLEAR)
        Select Case enmSQLCLEAR
            Case SQL_CLEAR.C_Table
                Me.pテーブル名 = ""
            Case SQL_CLEAR.C_Column
                Me.marrColumn.Clear()
            Case SQL_CLEAR.C_Value
                Me.marrValue.Clear()
            Case SQL_CLEAR.C_PakName
                Me.pパッケージ名 = ""
            Case SQL_CLEAR.C_PakReturnName
                Me.pパッケージの戻り名 = ""
            Case SQL_CLEAR.C_Select
                Me.marrSelect.Clear()
            Case SQL_CLEAR.C_From
                Me.marrFrom.Clear()
            Case SQL_CLEAR.C_Where
                Me.marrWhere.Clear()
            Case SQL_CLEAR.C_GroubBy
                Me.marrGroupBy.Clear()
            Case SQL_CLEAR.C_OrderBy
                Me.marrOrderBy.Clear()
            Case SQL_CLEAR.C_Having
                Me.marrHaving.Clear()
            Case Else
        End Select
    End Sub

#Region "Valueのセット"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubValue
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：Valueのセット
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Overloads Sub gSubValue(ByVal strValue As String, ByVal blnSingle As Boolean)
        Call Me.gSubValue(strValue, blnSingle, 0)
    End Sub
    ''intByteFullで指定したバイト数になるようにstrValueに空白をうめる
    Public Overloads Sub gSubValue(ByVal strValue As String, ByVal blnSingle As Boolean, ByVal intByteFull As Integer)
        Dim objSqlValueSet As New CSql値セット
        Dim strBuff As String

        strBuff = strValue
        If intByteFull > 0 Then
            Dim intByte As Integer
            intByte = System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(strBuff)
            If intByteFull - intByte > 0 Then
                strBuff = strBuff & Space(intByteFull - intByte)
            End If
        End If

        With objSqlValueSet
            .pStrValue = strBuff
            .pIsシングルクォーテーションあり = blnSingle
        End With

        Me.marrValue.Add(objSqlValueSet)
    End Sub

#Region "Columnのセット"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubColumn
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：Columnのセット
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubColumn(ByVal ParamArray strColumn() As String)
        Dim strbuff As String
        For Each strbuff In strColumn
            Me.marrColumn.Add(strbuff)
        Next
    End Sub

#Region "列名、値、シングル有無のセット"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubColumnValue
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：列名、値、シングル有無のセット
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Overloads Sub gSubColumnValue(ByVal strColumn As String, ByVal strValue As String, ByVal blnSingle As Boolean)
        Call Me.gSubColumn(strColumn)
        Me.gSubValue(strValue, blnSingle, 0)
    End Sub
    ''intByteFullで指定したバイト数になるようにstrValueに空白をうめる
    Public Overloads Sub gSubColumnValue(ByVal strColumn As String, ByVal strValue As String, ByVal blnSingle As Boolean, ByVal intByteFull As Integer)
        Call Me.gSubColumn(strColumn)
        Me.gSubValue(strValue, blnSingle, intByteFull)
    End Sub
    Public Sub 埋込SQL列(ByVal 列名 As String)
        gSubColumnValue(列名, "@" & 列名, False)
    End Sub

#Region "SELECT区のセット"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubSelect
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：SELECT区のセット
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSelect(ByVal ParamArray strSelect() As String)
        Dim strbuff As String
        For Each strbuff In strSelect
            Me.marrSelect.Add(strbuff)
        Next
    End Sub

#Region "FROM区のセット"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubFROM
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：FROM区のセット
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Overloads Sub gSubFrom(ByVal ParamArray strFrom() As String)
        Dim strbuff As String
        For Each strbuff In strFrom
            Me.marrFrom.Add(strbuff)
        Next
    End Sub

    ''SQLクラスのSelectをFromに別名をつけてセット
    Public Overloads Sub gSubFrom(ByVal objSQL As CSql, ByVal strName As String)
        Me.marrFrom.Add("(" & objSQL.gSQL文の取得 & ")" & strName)
    End Sub

#Region "WHERE区のセット"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubWHERE
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：WHERE区のセット
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    ''WHERE区を"WHERE または AND で設定する
    Public Overloads Sub gSubWhere(ByVal strWhere As String)
        Call Me.gSubWhere(strWhere, True)
    End Sub

    ''WHERE区を"WHERE または (AND,OR) で設定する
    Public Overloads Sub gSubWhere(ByVal strWhere As String, ByVal blnAnd As Boolean)
        Dim strBuffWhere As String
        If Me.marrWhere.Count = 0 Then
            strBuffWhere = " WHERE" & vbCrLf & "  " & strWhere
        Else
            If blnAnd Then
                strBuffWhere = " AND" & vbCrLf & "  " & strWhere
            Else
                strBuffWhere = " OR" & vbCrLf & "  " & strWhere
            End If
        End If
        Me.marrWhere.Add(strBuffWhere)
    End Sub
    ''引数で指定
    Public Overloads Sub gSubWhere(ByVal strColumn As String, ByVal 条件値 As String, Optional ByVal strMatch As String = "=", Optional ByVal enmWild As EnmWild = EnmWild.NoWild, Optional ByVal blnNumCtl As Boolean = False, Optional ByVal strClearNumData As String = "0", Optional ByVal blnNumField As Boolean = False, Optional ByVal intByteFull As Integer = 0, Optional ByVal blnSingle As Boolean = True, Optional ByVal enmWhere As EnmWhere = EnmWhere.WhereAnd)
        Call Me.mSubWhereHaving(True, Me.marrWhere, strColumn, 条件値, strMatch, enmWild, blnNumCtl, strClearNumData, blnNumField, intByteFull, blnSingle, enmWhere)
    End Sub

#Region "WhereHavingの作成"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：mSubWhereHaving
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：WhereHaving区のセット
    ' 備　考　：intByteFullを指定したバイト数になるように空白をうめる
    '---------------------------------------------------------------------------
#End Region
    Private Sub mSubWhereHaving(ByVal blnWhere As Boolean, ByVal objArr As ArrayList, ByVal strColumn As String, ByVal 条件値 As String, ByVal strMatch As String, ByVal enmWild As EnmWild, ByVal blnNumCtl As Boolean, ByVal strClearNumData As String, ByVal blnNumField As Boolean, ByVal intByteFull As Integer, ByVal blnSingle As Boolean, ByVal enmWhere As EnmWhere)
        Dim strSQL As String
        Dim strBuffColumn As String
        Dim strBuffSingle As String
        Dim strBuffData As String
        Dim 条件記号 As String = ""
        Dim strBuffWhere As String = ""
        Dim strBuffWhereEnd As String = ""

        If 条件値 Is Nothing Then
            Exit Sub
        End If

        ''後方空白削除はしない(スペースのフィールドがあるため)
        strBuffData = 条件値

        ''NumCtlの時
        If blnNumCtl Then
            If strBuffData = strClearNumData Then
                Exit Sub
            End If
        End If

        ''検索条件なし
        If strBuffData.Replace("*", "") = "" Then
            Exit Sub
        End If

        ''NumFieldの時
        If blnNumField Then
            strBuffSingle = ""

            ''カンマを除く
            strBuffData = strBuffData.Replace(",", "")

            ''先頭0をのぞく
            Do While strBuffData.Length > 1
                ''先頭が0
                If strBuffData.Substring(0, 1) = "0" Then
                    strBuffData = strBuffData.Substring(1)
                    ''先頭が*
                ElseIf strBuffData.Substring(0, 1) = "*" Then
                    Exit Do
                Else
                    Exit Do
                End If
            Loop
        Else
            ''シングル
            If blnSingle Then
                strBuffSingle = "'"
            Else
                strBuffSingle = ""
            End If
        End If

        Select Case enmWild
            ''ワイルドなし
            Case enmWild.NoWild
                条件記号 = strMatch

                ''ワイルドあり
            Case enmWild.Wild
                条件記号 = strMatch
                If あいまい検索モード = "強制" Then
                    条件記号 = "LIKE"
                    If InStr(strBuffData, "*") > 0 Then
                        strBuffData = strBuffData.Replace("*", "%")   '*から%に変換
                    Else
                        strBuffData = "%" & strBuffData & "%"
                    End If
                Else
                    If InStr(strBuffData, "*") > 0 Then
                        条件記号 = "LIKE"
                        strBuffData = strBuffData.Replace("*", "%")   '*から%に変換
                    End If
                End If
            Case Else

        End Select

        ''数値フィールドのワイルド
        If blnNumField Then
            ''数値ワイルド
            If 条件記号 = "LIKE" Then
                If enmWild = enmWild.Wild Then
                    strBuffColumn = "TO_CHAR(" & strColumn & ")"    'TODO ORACLE依存
                    strBuffSingle = "'"
                Else
                    strBuffColumn = strColumn
                End If
            Else
                strBuffColumn = strColumn
            End If
        Else
            strBuffColumn = strColumn
        End If

        ''CHA型で末尾に空白のいる検索
        If 条件記号 <> "LIKE" Then
            If intByteFull > 0 Then
                Dim intByte As Integer
                intByte = System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(strBuffData)
                If intByteFull - intByte > 0 Then
                    strBuffData = strBuffData & Space(intByteFull - intByte)
                End If
            End If
        End If

        ''WHEREの作成
        Select Case enmWhere
            Case enmWhere.WhereAnd, enmWhere.WhereOr, enmWhere.WhereNot, enmWhere.OrEnd
                If objArr.Count = 0 Then
                    If blnWhere Then
                        strBuffWhere = " WHERE " & vbCrLf & "  "
                    Else
                        strBuffWhere = " HAVING " & vbCrLf & "  "
                    End If
                Else
                    Select Case enmWhere
                        Case enmWhere.WhereAnd
                            strBuffWhere = " AND" & vbCrLf & "  "
                        Case enmWhere.WhereOr
                            strBuffWhere = " OR" & vbCrLf & "  "
                        Case enmWhere.WhereNot
                            strBuffWhere = " AND Not" & vbCrLf & "  "
                        Case enmWhere.OrEnd
                            strBuffWhere = " AND" & vbCrLf & "  "
                            strBuffWhereEnd = ")"
                    End Select
                End If

            Case enmWhere.OrStart
                If objArr.Count = 0 Then
                    If blnWhere Then
                        strBuffWhere = " WHERE" & vbCrLf & "  ("
                    Else
                        strBuffWhere = " HAVING" & vbCrLf & "  ("
                    End If
                Else
                    strBuffWhere = " OR" & vbCrLf & "  ("
                End If

            Case Else
        End Select

        ''作成
        strSQL = strBuffWhere _
                & strBuffColumn _
                & Space(1) & 条件記号 _
                & Space(1) & strBuffSingle & strBuffData & strBuffSingle _
                & strBuffWhereEnd

        objArr.Add(strSQL)
    End Sub

#Region "GROUPBY区のセット"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubGROUPBY
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：GROUPBY区のセット
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubGroupBy(ByVal ParamArray strGroupBy() As String)
        Dim strbuff As String
        For Each strbuff In strGroupBy
            Me.marrGroupBy.Add(strbuff)
        Next
    End Sub

#Region "ORDER BY句のセット(昇順ASC;降順DESC)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubORDERBY
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：ORDER BY句のセット
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Overloads Sub gSubOrderBy(ByVal ParamArray strOrderBy() As String)
        Dim strbuff As String
        For Each strbuff In strOrderBy
            Me.marrOrderBy.Add(strbuff)
        Next
    End Sub
    ''昇順、降順を指定してセット
    Public Overloads Sub gSubOrderBy(ByVal strOrderBy As String, ByVal blnAsc As Boolean)
        If blnAsc Then
            ''昇順
            Me.marrOrderBy.Add(strOrderBy & " ASC")
        Else
            ''降順
            Me.marrOrderBy.Add(strOrderBy & " DESC")
        End If
    End Sub

    ''' <summary>
    ''' あいまい検索条件対応SQL句を取得する
    ''' </summary>
    ''' <param name="列名"></param>
    ''' <param name="条件値"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' あいまい検索モード ＝ "強制"の場合、常に「LIKE」で条件検索する
    ''' あいまい検索モード ≠ "強制"の場合、
    ''' 条件値に「*」が含まれるか否かにより、「=」と「LIKE」を自動的に切り替える
    ''' </remarks>
    Public Function あいまい検索条件対応SQL句取得(ByVal 列名 As String, ByVal 条件値 As String) As String
        Dim 条件記号 As String = "="
        If デフォルトあいまい検索モード = "強制" Then
            条件記号 = "LIKE"
            If InStr(条件値, "*") > 0 Then
                If InStr(条件値, "*") > 0 Then
                    条件値 = 条件値.Replace("*", "%")   '*から%に変換
                End If
            Else
                条件値 = "%" & 条件値 & "%"
            End If
        Else
            If InStr(条件値, "*") > 0 Then
                条件記号 = "LIKE"
                条件値 = 条件値.Replace("*", "%")   '*から%に変換
            End If
        End If
        Return 列名 & " " & 条件記号 & " '" & 条件値 & "' "
    End Function

    Public Sub gSubWhereあいまい検索(ByVal 列名 As String, ByVal 値 As String)
        値 = 値.Trim
        If 値.Trim <> "" Then
            gSubWhere(列名, 値, , CSql.EnmWild.Wild)
        End If
    End Sub

End Class

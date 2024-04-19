Imports System.Data.Common

''' <summary>
''' Db拡張例外
''' </summary>
''' <remarks></remarks>
Public Class DbExceptionEx
    Inherits DbException

    Public Const 不明エラー番号 As Integer = 99999

    Public ReadOnly Property エラー番号() As Integer
        Get
            If TypeOf InnerException Is System.Data.SqlClient.SqlException Then
                Return CType(InnerException, System.Data.SqlClient.SqlException).Number
            Else
                Return 不明エラー番号
            End If
        End Get
    End Property

    Private m例外発生時SQL As String
    Public ReadOnly Property SQL() As String
        Get
            Return m例外発生時SQL
        End Get
    End Property

    Public Sub New(ByVal 例外発生時SQL As String, ByVal 例外 As DbException)
        MyBase.New(例外.Message, 例外)
        m例外発生時SQL = 例外発生時SQL
    End Sub
End Class

''' <summary>
''' DB処理共通クラス
''' </summary>
''' <remarks></remarks>
Public MustInherit Class Cdp
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Public gdb接続 As DbConnection
    Protected m実行レコード件数 As Integer
    Protected mトランザクション As DbTransaction
    Protected 直前発生例外 As DbExceptionEx

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    Protected mblnTrans As Boolean
    Public ReadOnly Property pIsトランザクション() As Boolean
        Get
            Return Me.mblnTrans
        End Get
    End Property

    Private mホスト名 As String
    Public Property ホスト名() As String
        Get
            Return Me.mホスト名
        End Get
        Set(ByVal Value As String)
            Me.mホスト名 = Value
        End Set
    End Property

    Private mデータベース名 As String
    Public Property データベース名() As String
        Get
            Return Me.mデータベース名
        End Get
        Set(ByVal Value As String)
            Me.mデータベース名 = Value
        End Set
    End Property

    Private mユーザ名 As String
    Public Property ユーザ名() As String
        Get
            Return Me.mユーザ名
        End Get
        Set(ByVal Value As String)
            Me.mユーザ名 = Value
        End Set
    End Property

    Private mstrパスワード As String
    Public Property パスワード() As String
        Get
            Return Me.mstrパスワード
        End Get
        Set(ByVal Value As String)
            Me.mstrパスワード = Value
        End Set
    End Property

    Private mカタログ As String
    Public Property カタログ() As String
        Get
            Return Me.mカタログ
        End Get
        Set(ByVal Value As String)
            Me.mカタログ = Value
        End Set
    End Property

    Private mint再接続試行回数 As Integer
    Public Property 再接続試行回数() As Integer
        Get
            Return Me.mint再接続試行回数
        End Get
        Set(ByVal Value As Integer)
            Me.mint再接続試行回数 = Value
        End Set
    End Property

    Public ReadOnly Property pInt実行レコード件数() As Integer
        Get
            Return m実行レコード件数
        End Get
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
    Public Sub New()
        Me.gdb接続 = 新規接続()
    End Sub

    Protected Overridable Function 新規接続() As DbConnection
        Throw New Exception("未実装")
    End Function

    Public Sub New(ByVal strHost As String, ByVal strUsr As String, ByVal strPass As String, ByVal strCatalog As String)
        Me.ホスト名 = strHost
        Me.ユーザ名 = strUsr
        Me.パスワード = strPass
        Me.カタログ = strCatalog

        Me.gdb接続 = 新規接続()
    End Sub

    Public Function gBlnDB接続() As Boolean
        Try
            If Me.gdb接続 Is Nothing Then
                Me.mトランザクション = Nothing
                Me.gdb接続 = Nothing
                Me.gdb接続 = 新規接続()
            Else
                Select Case Me.gdb接続.State
                    Case ConnectionState.Open
                        Return True
                    Case Else
                End Select
            End If

            Me.gdb接続.ConnectionString = "server=" & Me.ホスト名 & ";database=" & Me.データベース名 & ";uid=" & Me.ユーザ名 & ";pwd=" & Me.パスワード
            'Me.msdpCon.ConnectionString = "User ID=" & Me.pStrUsrName & ";Password=" & Me.pStrPass & ";data source=""" & Me.pStrHostName & """;initial catalog=" & Me.pStrCatalog
            Me.gdb接続.Open()
            Return True

        Catch ex As DbException

        Finally

        End Try
    End Function

    Public Sub gSubトランザクション開放()
        If Not Me.mトランザクション Is Nothing Then
            Me.mトランザクション.Dispose()
            Me.mトランザクション = Nothing
        End If
        Me.mblnTrans = False
    End Sub

    Public Overloads Function gObjReadScalar(ByVal strSQL As String, Optional ByVal objDefoult As Object = "", Optional ByVal blnDBClose As Boolean = False) As Object
        ''接続
        If Not Me.gBlnDB接続() Then
            Return False
        End If

        Dim sdpCmd As DbCommand = gdb接続.CreateCommand

        Try
            Return Me.gObjReadScalar(strSQL, sdpCmd, objDefoult)
        Finally
            Me.gSubDpCommand開放(sdpCmd, blnDBClose)
        End Try
    End Function

    Public Sub gSubDpCommand開放(ByVal コマンド As DbCommand, Optional ByVal blnDBClose As Boolean = False)
        If Not コマンド Is Nothing Then
            コマンド.Parameters.Clear()
            コマンド.Dispose()
            コマンド = Nothing
        End If
        If blnDBClose Then
            Call Me.gBln接続Close()
        End If
    End Sub

    Public Overridable Function gBln接続Close() As Boolean
        Try
            If Not gdb接続 Is Nothing Then
                If gdb接続.State <> ConnectionState.Closed Then
                    gdb接続.Close()
                End If
            End If
            Return True

        Catch ex As DbException
            Call Me.mSub例外発行(ex)
        Finally

        End Try
    End Function
    Public Function gBln接続開放() As Boolean
        Try
            If Not gdb接続 Is Nothing Then
                Call gBln接続Close()
                gdb接続.Close()
                gdb接続.Dispose()
                gdb接続 = Nothing
            End If
            Return True

        Catch ex As DbException
            Call Me.mSub例外発行(ex)
        Finally

        End Try
    End Function

    Protected Sub mSub例外発行(ByVal ex As DbException, Optional ByVal strErrSQL As String = "")
        Throw New DbExceptionEx(strErrSQL, ex)
    End Sub

    Public Sub gSubトランザクション開始()
        ''接続
        If Not Me.gBlnDB接続() Then
            Exit Sub
        End If

        Call Me.gSubトランザクション開放()
        Me.mトランザクション = Me.gdb接続.BeginTransaction
        Me.mblnTrans = True
    End Sub

    Public Sub gSubトランザクション終了(ByVal blnCommit As Boolean)
        Try
            If Me.mトランザクション Is Nothing Then
                Exit Sub
            End If

            If blnCommit Then
                Me.mトランザクション.Commit()
            Else
                Me.mトランザクション.Rollback()
            End If

        Finally
            Call Me.gSubトランザクション開放()
        End Try
    End Sub

    Public Function ExecuteScalarによる件数取得(ByVal dpCmd As DbCommand, Optional ByVal strSQL As String = Nothing, Optional ByVal デフォルト値 As Long = 0) As Long
        Try
            ''接続
            If Not Me.gBlnDB接続() Then
                Return デフォルト値
            Else
                With dpCmd
                    .Connection = Me.gdb接続
                    If Not strSQL Is Nothing Then
                        .CommandText = strSQL
                    End If
                    .CommandType = CommandType.Text
                    Dim 結果 As Object = .ExecuteScalar
                    If 結果 Is Nothing Then
                        Return デフォルト値
                    ElseIf IsDBNull(結果) Then
                        Return デフォルト値
                    Else
                        Return CLng(結果)
                    End If
                End With
            End If
        Catch ex As DbException
            Call Me.mSub例外発行(ex, strSQL)
            Return デフォルト値
        End Try
    End Function

    Public Overloads Function gObjReadScalar(ByVal strSQL As String, ByVal コマンド As DbCommand, Optional ByVal デフォルト値 As Object = "") As Object
        Dim objRet As Object

        Try
            ''接続
            If Not Me.gBlnDB接続() Then
                Return デフォルト値
            Else
                With コマンド
                    .Connection = Me.gdb接続
                    .CommandText = strSQL
                    .CommandType = CommandType.Text
                    If Me.mblnTrans Then
                        .Transaction = Me.mトランザクション
                    End If
                    objRet = .ExecuteScalar
                    If objRet Is Nothing Then
                        Return デフォルト値
                    ElseIf IsDBNull(objRet) Then
                        Return デフォルト値
                    Else
                        Return objRet
                    End If
                End With
            End If
        Catch ex As DbException
            Call Me.mSub例外発行(ex, strSQL)
            Return デフォルト値
        End Try
    End Function

    Public Overloads Function gBlnExecute(ByVal strSQL As String, ByVal コマンド As DbCommand, Optional ByVal blnTrans As Boolean = False, Optional ByVal blnClose As Boolean = False) As Boolean
        ''接続
        If Not Me.gBlnDB接続() Then
            Return False
        End If

        If blnTrans Then
            Call Me.gSubトランザクション開始()
        End If

        Dim blnRet As Boolean
        Try
            With コマンド
                .Connection = Me.gdb接続
                .CommandText = strSQL
                .CommandType = CommandType.Text
                If Me.mblnTrans Then
                    .Transaction = Me.mトランザクション
                End If
                Me.m実行レコード件数 = 0    '次の文で例外が発生した場合を想定して０を代入しておく？
                Me.m実行レコード件数 = .ExecuteNonQuery()
            End With

            blnRet = True
            Return True
        Catch ex As DbException
            Call Me.mSub例外発行(ex, strSQL)
        Finally
            If blnTrans Then
                Call Me.gSubトランザクション終了(blnRet)
            End If

            If blnClose Then
                Call Me.gBln接続Close()
            End If
        End Try
    End Function

    Public Overloads Function gBlnExecute(ByVal strSQL As String, Optional ByVal blnTrans As Boolean = False, Optional ByVal blnClose As Boolean = False) As Boolean
        ''接続
        If Not Me.gBlnDB接続() Then
            Return False
        End If

        Dim コマンド As DbCommand = Me.gdb接続.CreateCommand
        Try
            Return Me.gBlnExecute(strSQL, コマンド, blnTrans, blnClose)
        Finally
            Me.gSubDpCommand開放(コマンド, blnClose)
        End Try
    End Function

    Public Function gIntSQLCount(ByVal strSQL As String, Optional ByVal blnDBClose As Boolean = False) As Integer
        ''接続
        If Not Me.gBlnDB接続() Then
            Return -1
        End If

        '件数抽出SQL文生成
        Dim intPoint As Integer = InStr(strSQL, "ORDER BY")
        Dim strBuff As String
        If intPoint > 0 Then
            strBuff = strSQL.Substring(0, intPoint - 1)
        Else
            strBuff = strSQL
        End If

        'SQLserverはサブクエリに名前を指定する必要がある（件
        strBuff = "SELECT COUNT(*) AS 件数 FROM (" & strBuff & ") AS 件"

        'データ件数抽出
        Dim intRet As Integer = CInt(Me.gObjReadScalar(strBuff))
        Return intRet

    End Function

    Public Overloads Function gBlnReader(ByVal strSQL As String, ByRef reader As DbDataReader, ByVal コマンド As DbCommand) As Boolean
#If SQL Then
        Debug.WriteLine(strSQL)
#End If

        Try
            ''接続
            If Not Me.gBlnDB接続() Then
                Return False
            End If

            With コマンド
                .Connection = Me.gdb接続
                .CommandText = strSQL
                .CommandType = CommandType.Text
                reader = .ExecuteReader
            End With

            Return True
        Catch ex As DbException
            Call Me.mSub例外発行(ex, strSQL)
        Finally

        End Try
    End Function

    Public Overloads Function gBlnReader(ByVal strSQL As String, ByRef reader As DbDataReader) As Boolean
        ''接続
        If Not Me.gBlnDB接続() Then
            Return False
        End If

        Dim コマンド As DbCommand = Me.gdb接続.CreateCommand

        '2009/12/15 commandtimeout設定(3分)
        コマンド.CommandTimeout = 180

        Try
            Return Me.gBlnReader(strSQL, reader, コマンド)
        Finally
            Me.gSubDpCommand開放(コマンド, False)
        End Try
    End Function

    Public Sub gSubReaderClose(ByRef reader As DbDataReader, Optional ByVal blnDBClose As Boolean = False)
        If Not reader Is Nothing Then
            reader.Close()
            reader = Nothing
        End If
        If blnDBClose Then
            Call Me.gBln接続Close()
        End If
    End Sub

    Public Overridable Function AddWithValue(ByVal コマンド As DbCommand, ByVal パラメータ名 As String, ByVal 値 As Object) As DbParameter
        Return Nothing
    End Function

    Public Overridable Function アダプタを生成して返す(ByVal sql As String) As DbDataAdapter
        Return Nothing
    End Function

    Public Function gBlnデータテーブルの取得(ByVal strSQL As String, ByRef dt As DataTable, Optional ByVal blnDBClose As Boolean = False) As Boolean
#If SQL Then
        Debug.WriteLine(strSQL)
#End If
        Try
            ''接続
            If Not gBlnDB接続() Then
                Return False
            End If

            アダプタを生成して返す(strSQL).Fill(dt)

            If blnDBClose Then
                Call Me.gBln接続Close()
            End If

            Return True
        Catch ex As DbException
            Call Me.mSub例外発行(ex, strSQL)
        Finally

        End Try
    End Function
End Class

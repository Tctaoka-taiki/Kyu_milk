Option Strict On

Imports System.IO
Imports System.Xml

''' <summary>
''' ログレベル
''' </summary>
''' <remarks></remarks>
Public Enum enuログレベル
    ''' <summary></summary>
    ''' <remarks></remarks>
    LEVEL_OFF = 0
    ''' <summary></summary>
    ''' <remarks></remarks>
    LEVEL_TRACE = 1
    ''' <summary></summary>
    ''' <remarks></remarks>
    LEVEL_INFO = 2
    ''' <summary></summary>
    ''' <remarks></remarks>
    LEVEL_WARN = 3
    ''' <summary>エラー</summary>
    ''' <remarks></remarks>
    LEVEL_ERROR = 4
End Enum

Public Class CLogUtil
    '-------------------------------------------------------------------------------------
    '列挙の定義
    '-------------------------------------------------------------------------------------

    '-------------------------------------------------------------------------------------
    'メンバ変数の定義
    '-------------------------------------------------------------------------------------
    Public Shared デフォルト As Cログ管理 = New Cログ管理

    '-------------------------------------------------------------------------------------
    'メソッドの定義
    '-------------------------------------------------------------------------------------
    '''' <summary>設定ファイル読み込み</summary>
    '''' <remarks>parameter.xmlファイルから設定内容を読み込みます。</remarks>
    'Public Shared Sub 設定ファイル読み込み(ByVal path As String)
    '    Dim document As XmlDocument = New XmlDocument

    '    document.Load(path)

    '    '<Log>
    '    With document.GetElementsByTagName("Log").Item(0)
    '        'ErrorLog設定
    '        LogUtil.画面ログレベル_ = LogUtil.ConvertToErrorLogLevel(.Attributes("LogLevelScreen").Value)
    '        LogUtil.ファイルログレベル_ = LogUtil.ConvertToErrorLogLevel(.Attributes("LogLevelFile").Value)
    '        LogUtil.エラーログパス = .Attributes("ErrorLogPath").Value
    '    End With
    'End Sub

    ''' <summary>エラーログレベル変換</summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function エラーログレベル変換(ByVal value As String) As enuログレベル
        Select Case value
            Case "0"
                Return enuログレベル.LEVEL_OFF
            Case "1"
                Return enuログレベル.LEVEL_TRACE
            Case "2"
                Return enuログレベル.LEVEL_INFO
            Case "3"
                Return enuログレベル.LEVEL_WARN
            Case "4"
                Return enuログレベル.LEVEL_ERROR
        End Select
    End Function
End Class

Public Class Cログ管理
    Private Shared ログパス As String = "c:\default_common.log.txt"
    ''' <summary>共通ログリスト</summary>
    ''' <remarks></remarks>
    Public listCommonLog As System.Collections.ArrayList = New System.Collections.ArrayList()
    Public リスト最大件数_ As Integer = 100

    Private 画面ログレベル_ As enuログレベル
    Private ファイルログレベル_ As enuログレベル

    Private Function GetLogPath(ByVal prefix As String) As String
        Return prefix & Format(Now, "yyyyMMdd") & ".txt"
    End Function

    ''' <summary>エラーログ出力</summary>
    ''' <param name="screenLevel">エラーログレベル(画面出力)</param>
    ''' <param name="fileLevel">エラーログレベル(ファイル出力)</param>
    ''' <param name="logMessage"></param>
    ''' <remarks></remarks>
    Public Sub Writeエラーログ(ByVal screenLevel As enuログレベル, ByVal fileLevel As enuログレベル, ByVal logMessage As String)
        Dim dateNow As Date = DateTime.Now
        'OFF設定でない場合
        '呼び出しFile出力レベル
        If fileLevel >= ファイルログレベル_ Then
            'ロックします
            SyncLock Me
                Using w As StreamWriter = File.AppendText(GetLogPath(ログパス))
                    'DateTime.Now.ToLongTimeString() & DateTime.Now.ToLongDateString()
                    w.WriteLine(メッセージヘッダ部取得(dateNow, fileLevel) & logMessage)
                    w.Flush()
                    w.Close()
                End Using
            End SyncLock
        End If

        '呼び出し画面出力レベル
        If screenLevel >= 画面ログレベル_ Then
            'ロックします
            SyncLock listCommonLog
                With listCommonLog
                    .Insert(0, メッセージヘッダ部取得(dateNow, screenLevel) & logMessage)
                    If .Count > リスト最大件数_ Then
                        .RemoveAt(.Count - 1)
                    End If
                End With
            End SyncLock
        End If
    End Sub

    ''' <summary>メッセージヘッダ部取得</summary>
    ''' <param name="dateNow"></param>
    ''' <param name="errorLevel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function メッセージヘッダ部取得(ByVal dateNow As Date, ByVal errorLevel As enuログレベル) As String
        Select Case errorLevel
            Case enuログレベル.LEVEL_ERROR
                Return "[" & dateNow & "] [ERROR]"
            Case enuログレベル.LEVEL_WARN
                Return "[" & dateNow & "] [WORNING]"
            Case enuログレベル.LEVEL_INFO
                Return "[" & dateNow & "] [INFO]"
            Case enuログレベル.LEVEL_TRACE
                Return "[" & dateNow & "] [TRACE]"
            Case enuログレベル.LEVEL_OFF
                Return "[" & dateNow & "] [OFF]"
            Case Else
                Return "[" & dateNow & "] [-----]"
        End Select
    End Function

    ''' <summary>例外ログ出力</summary>
    ''' <param name="screenLevel">エラーログレベル(画面出力)</param>
    ''' <param name="fileLevel">エラーログレベル(ファイル出力)</param>
    ''' <param name="logMessage"></param>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Public Sub Write例外ログ(ByVal screenLevel As enuログレベル, ByVal fileLevel As enuログレベル, ByVal logMessage As String, ByVal ex As Exception)
        Dim message As String = "例外[メッセージ=" & logMessage & "]" & ControlChars.CrLf
        message = message & InnerExceptionを含めた例外メッセージ取得(ex)

        Writeエラーログ(screenLevel, fileLevel, message)
    End Sub

    ''' <summary>例外ログ出力</summary>
    ''' <param name="screenLevel">エラーログレベル(画面出力)</param>
    ''' <param name="fileLevel">エラーログレベル(ファイル出力)</param>
    ''' <param name="ex">例外オブジェクト</param>
    ''' <remarks></remarks>
    Public Sub Write例外ログ(ByVal screenLevel As enuログレベル, ByVal fileLevel As enuログレベル, ByVal ex As Exception)
        Dim message As String = "例外" & ControlChars.CrLf
        message = message & InnerExceptionを含めた例外メッセージ取得(ex)

        Writeエラーログ(screenLevel, fileLevel, message)
    End Sub

    Private Function InnerExceptionを含めた例外メッセージ取得(ByVal ex As Exception) As String
        Dim メッセージ As String = ""
        メッセージ = メッセージ & "GetType=" & ex.GetType.FullName & ControlChars.CrLf
        'If TypeOf ex Is tems_com.Tachibana.Tems.SqlException Then
        '    message = message & "SqlString=" & CType(ex, tems_com.Tachibana.Tems.SqlException).SqlString & ControlChars.CrLf
        'End If
        メッセージ = メッセージ & "message=" & ex.Message & ControlChars.CrLf
        メッセージ = メッセージ & ex.StackTrace & ControlChars.CrLf
        If Not ex.InnerException Is Nothing Then
            メッセージ = メッセージ & "InnerException->" & ControlChars.CrLf
            メッセージ = メッセージ & InnerExceptionを含めた例外メッセージ取得(ex.InnerException)
        End If
        Return メッセージ
    End Function

    ''' <summary>トレースログ出力</summary>
    ''' <param name="message">書き込むメッセージ</param>
    ''' <remarks></remarks>
    Public Sub Writeトレースログ(ByVal message As String)
        'System.Diagnostics.Debug.Write("[" & Now & "] [DEBUG]" & message & vbCrLf)
        Writeエラーログ(enuログレベル.LEVEL_TRACE, enuログレベル.LEVEL_TRACE, message)
    End Sub
End Class
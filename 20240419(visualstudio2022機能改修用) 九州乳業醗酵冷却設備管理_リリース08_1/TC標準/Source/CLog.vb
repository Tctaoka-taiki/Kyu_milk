Imports Microsoft.VisualBasic.Logging

Public Class CLog
    Inherits FileLogTraceListener

    Public Event WritedLine(ByVal datetime As Date, ByVal category As String, ByVal message As String, ByVal logtype As EventLogEntryType)

    Private Const DATE_TIME_FORMAT As String = "yy/MM/dd HH:mm:ss:ff >>"
    Sub New()
        MyBase.New()
        MyBase.AutoFlush = True
    End Sub

    Sub New(ByVal name As String)
        MyBase.New(name)
        MyBase.AutoFlush = True
    End Sub


    Public Overloads Sub WriteLine(ByVal category As String, ByVal message As String, ByVal logtype As EventLogEntryType)
        Dim dt As Date = Now()
        Dim typ As String = ""
        Select Case logtype
            Case EventLogEntryType.Error
                typ = "(×)"
            Case EventLogEntryType.FailureAudit
                typ = "(△)"
            Case EventLogEntryType.Information
                typ = "(ｉ)"
            Case EventLogEntryType.SuccessAudit
                typ = "(○)"
            Case EventLogEntryType.Warning
                typ = "(！)"
        End Select
        WriteLine(Format(dt, DATE_TIME_FORMAT) + typ + "[" + category + "]" + message)

        'イベントログにも書き込む
        EventLog.WriteEntry(category, message, logtype)

        'イベント発生
        RaiseEvent WritedLine(dt, category, message, logtype)
    End Sub

End Class

Option Strict On

' 以下の名前空間をインポートする
Imports System.Diagnostics
Imports System.Runtime.InteropServices

Public Class CMyProcess

    <DllImport("USER32.DLL", CharSet:=CharSet.Auto)> _
    Private Shared Function ShowWindow( _
        ByVal hWnd As System.IntPtr, _
        ByVal nCmdShow As Integer) As Integer
    End Function

    <DllImport("USER32.DLL", CharSet:=CharSet.Auto)> _
    Private Shared Function SetForegroundWindow( _
        ByVal hWnd As System.IntPtr) As Boolean
    End Function

    Private Const SW_NORMAL As Integer = 1

    ''' ------------------------------------------------------------------------------------
    ''' <summary>
    '''     同名のプロセスが起動中の場合、メイン ウィンドウをアクティブにします。</summary>
    ''' <returns>
    '''     既に起動中であれば true。それ以外は false。</returns>
    ''' ------------------------------------------------------------------------------------
    Public Shared Function ShowPrevProcess() As Boolean
        Dim hThisProcess As Process = Process.GetCurrentProcess()
        Dim hProcesses As Process() = Process.GetProcessesByName(hThisProcess.ProcessName)
        Dim iThisProcessId As Integer = hThisProcess.Id

        For Each hProcess As Process In hProcesses
            If hProcess.Id <> iThisProcessId Then
                Call ShowWindow(hProcess.MainWindowHandle, SW_NORMAL)
                Call SetForegroundWindow(hProcess.MainWindowHandle)
                Return True
            End If
        Next hProcess

        Return False
    End Function

End Class

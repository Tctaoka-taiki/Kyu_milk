Public Class Shutdown
    Private Const EWX_LOGOFF As Long = &H0
    Private Const EWX_SHUTDOWN As Long = &H1
    Private Const EWX_REBOOT As Long = &H2
    Private Const EWX_FORCE As Long = &H4
    Private Const EWX_POWEROFF As Long = &H8
    Private Const EWX_FORCEIFHUNG As Long = &H10
    Private Const EWX_RESTARTAPPS As Long = &H40

    Private Const SHTDN_REASON_FLAG_PLANNED As Long = &H80000000

    Public Enum ShutdownConstants As Integer
        ''' <summary>
        ''' 呼び出し側のプロセスのセキュリティコンテキストで実行されているすべてのプロセスを終了し、現在のユーザーをログオフさせます。
        ''' </summary>
        ''' <remarks></remarks>
        shutdownLogOff = EWX_LOGOFF
        ''' <summary>
        ''' システムをシャットダウンして、電源を切っても安全な状態にします。すべてのバッファをディスクへフラッシュし（バッファの内容をディスクに書き込み）、動作していたすべてのプロセスを停止します。
        ''' </summary>
        ''' <remarks></remarks>
        shutdownNoPowerOff = EWX_SHUTDOWN
        ''' <summary>
        ''' システムをシャットダウンした後、システムを再起動します。 
        ''' </summary>
        ''' <remarks></remarks>
        shutdownReboot = EWX_REBOOT
        ''' <summary>
        ''' システムをシャットダウンした後、電源を切ります。システムは、パワーオフ機能をサポートしていなければなりません。 
        ''' </summary>
        ''' <remarks></remarks>
        shutdownPowerOff = EWX_POWEROFF
    End Enum

    Public Enum ShutdownForceFlags As Integer
        ''' <summary>
        ''' 通常の処理です。
        ''' </summary>
        ''' <remarks></remarks>
        shutdownNone = 0
        ''' <summary>
        ''' プロセスを強制的に終了させます。このフラグを指定すると、システムは、現在実行されているアプリケーションへ WM_QUERYENDSESSION メッセージや WM_ENDSESSION メッセージを送信しません。この結果、アプリケーションがデータを失う可能性もあります。したがって、このフラグは、緊急時にのみ指定してください。
        ''' </summary>
        ''' <remarks></remarks>
        shutdownForce = EWX_FORCE
        ''' <summary>
        ''' Windows 2000：プロセスが WM_QUERYENDSESSION または WM_ENDSESSION メッセージに応答しない場合、それらのプロセスを終了させます。EWX_FORCE フラグを指定すると、EWX_FORCEIFHUNG フラグは無視されます。
        ''' </summary>
        ''' <remarks></remarks>
        shutdownForceIfHung = EWX_FORCEIFHUNG
    End Enum

    <System.Runtime.InteropServices.DllImport("kernel32.dll")> _
    Private Shared Function GetCurrentProcess() As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("advapi32.dll", SetLastError:=True)> _
    Private Shared Function OpenProcessToken(ByVal ProcessHandle As IntPtr, _
        ByVal DesiredAccess As Integer, _
        ByRef TokenHandle As IntPtr) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("advapi32.dll", SetLastError:=True, _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function LookupPrivilegeValue(ByVal lpSystemName As String, _
        ByVal lpName As String, _
        ByRef lpLuid As Long) As Boolean
    End Function

    <System.Runtime.InteropServices.StructLayout( _
        System.Runtime.InteropServices.LayoutKind.Sequential, Pack:=1)> _
    Private Structure TOKEN_PRIVILEGES
        Public PrivilegeCount As Integer
        Public Luid As Long
        Public Attributes As Integer
    End Structure

    <System.Runtime.InteropServices.DllImport("advapi32.dll", SetLastError:=True)> _
    Private Shared Function AdjustTokenPrivileges(ByVal TokenHandle As IntPtr, _
        ByVal DisableAllPrivileges As Boolean, _
        ByRef NewState As TOKEN_PRIVILEGES, _
        ByVal BufferLength As Integer, _
        ByVal PreviousState As IntPtr, _
        ByVal ReturnLength As IntPtr) As Boolean
    End Function

    'シャットダウンするためのセキュリティ特権を有効にする
    Private Shared Sub AdjustToken()
        Const TOKEN_ADJUST_PRIVILEGES As Integer = &H20
        Const TOKEN_QUERY As Integer = &H8
        Const SE_PRIVILEGE_ENABLED As Integer = &H2
        Const SE_SHUTDOWN_NAME As String = "SeShutdownPrivilege"

        If Environment.OSVersion.Platform <> PlatformID.Win32NT Then
            Return
        End If

        Dim procHandle As IntPtr = GetCurrentProcess()

        'トークンを取得する
        Dim tokenHandle As IntPtr
        OpenProcessToken(procHandle, _
            TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, tokenHandle)
        'LUIDを取得する
        Dim tp As New TOKEN_PRIVILEGES()
        tp.Attributes = SE_PRIVILEGE_ENABLED
        tp.PrivilegeCount = 1
        LookupPrivilegeValue(Nothing, SE_SHUTDOWN_NAME, tp.Luid)
        '特権を有効にする
        AdjustTokenPrivileges(tokenHandle, False, tp, 0, IntPtr.Zero, IntPtr.Zero)
    End Sub

    <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function ExitWindowsEx(ByVal uFlags As Integer, _
        ByVal dwReserved As Integer) As Boolean
    End Function

    Public Shared Sub ShutdownWindows(ByVal ShutdownConstants As ShutdownConstants, ByVal ShutdownForceFlags As ShutdownForceFlags)
        Dim shutdownMode As Integer = 0

        If System.Environment.OSVersion.Platform = PlatformID.Win32NT Then
            AdjustToken()
        End If
        'ShutdownConstants = ShutdownConstants Or ShutdownForceFlags.shutdownForce 
        ExitWindowsEx(ShutdownConstants Or ShutdownForceFlags, SHTDN_REASON_FLAG_PLANNED)
    End Sub
End Class

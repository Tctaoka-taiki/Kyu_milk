Imports System.Threading
Imports System.Runtime.InteropServices

Public Class CUtil画面標準
    '#####################################################################################
    '型
    '#####################################################################################
    Private Const SRCCOPY As Integer = &HCC0020

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    ' ［閉じる］ボタンを無効化するための値
    Protected Shared SC_CLOSE As Integer = &HF060
    Protected Shared MF_BYCOMMAND As Integer = &H0

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
    Private Sub New()
    End Sub

    ' Win32 APIのインポート
    <DllImport("USER32.DLL")> _
    Private Shared Function GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Integer) As IntPtr
    End Function

    <DllImport("USER32.DLL")> _
    Private Shared Function RemoveMenu(ByVal hMenu As IntPtr, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("gdi32.dll")> _
    Private Shared Function BitBlt(ByVal hdcDest As IntPtr, _
        ByVal nXDest As Integer, ByVal nYDest As Integer, _
        ByVal nWidth As Integer, ByVal nHeight As Integer, _
        ByVal hdcSrc As IntPtr, _
        ByVal nXSrc As Integer, ByVal nYSrc As Integer, _
        ByVal dwRop As Integer) As Boolean
    End Function


    Public Shared Sub コントロールボックスの閉じるボタンの無効化(ByVal hWnd As System.IntPtr)
        Dim hMenu As IntPtr = GetSystemMenu(hWnd, 0)
        RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND)
    End Sub

    ''' <summary>未処理例外をキャッチするイベント・ハンドラ（Windowsアプリケーション用）</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
        Dim ex As Exception = CType(e.Exception, Exception)
        If Not ex Is Nothing Then
            ''With New SendMail
            ''    Dim message As String = ""
            ''    message = message & "【例外終了報告】" & ControlChars.CrLf
            ''    message = message & "【エラー内容】" & ControlChars.CrLf
            ''    message = message & "【スタックトレース】" & ControlChars.CrLf

            ''    .Read(Util.GetAppPath & "\..\" & "parameter.xml")
            ''    .send(.GetMailAddressList("end_by_exception"), "例外終了報告！！！！！！", message)
            ''End With

            Try
                CLogUtil.デフォルト.Write例外ログ(enuログレベル.LEVEL_ERROR, enuログレベル.LEVEL_ERROR, "Application_ThreadExceptionによる例外通知です。", ex)
            Catch ex2 As Exception
                'なにもしません
            End Try
            'Util.SendExceptionMail(ex)
            エラーメッセージ表示処理(ex, "Application_ThreadExceptionによる例外通知です。")
        End If
    End Sub

    ''' <summary>未処理例外をキャッチするイベント・ハンドラ（主にコンソール・アプリケーション用）</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Sub Application_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Dim ex As Exception = CType(e.ExceptionObject, Exception)
        If Not ex Is Nothing Then
            Try
                CLogUtil.デフォルト.Write例外ログ(enuログレベル.LEVEL_ERROR, enuログレベル.LEVEL_ERROR, "Application_UnhandledExceptionによる例外通知です。", ex)
            Catch ex2 As Exception
                'なにもしません
            End Try
            'Util.SendExceptionMail(ex)
            エラーメッセージ表示処理(ex, "Application_UnhandledExceptionによる例外通知です。")
        End If
    End Sub

    ''' <summary>エラーメッセージ表示処理</summary>
    ''' <param name="ex"></param>
    ''' <param name="extraMessage"></param>
    ''' <remarks>ユーザー・フレンドリなダイアログを表示するメソッド</remarks>
    Public Shared Sub エラーメッセージ表示処理(ByVal ex As Exception, ByVal extraMessage As String)
        MessageBox.Show(extraMessage & vbLf & "――――――――" & vbLf & vbLf & _
         "エラーが発生しました。管理者にお知らせください" & vbLf & vbLf & _
         "【エラー内容】" & vbLf & ex.Message & vbLf & vbLf & _
         "【スタックトレース】" & vbLf & ex.StackTrace, "エラー発生", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Sub ハードコピー画面保存()
        With New SaveFileDialog
            ''ファイルダイアログ
            .Filter = "Jpg files (*.Jpg)|*.Jpg"

            ' ［Alt］キー＋［Print Screen］キーの送信
            SendKeys.SendWait("%{PRTSC}")

            ' クリップボードに格納された画像の取得
            Dim data As IDataObject = Clipboard.GetDataObject()
            If data.GetDataPresent(DataFormats.Bitmap) = True Then

                .DefaultExt = "bmp"

                If .ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                    Dim bmp As Bitmap = CType(data.GetData(DataFormats.Bitmap), Bitmap)

                    '' 取得した画像の保存
                    bmp.Save(.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                    '既定のファイル名の拡張子を指定する
                End If
            End If
        End With
    End Sub

    'フォームのイメージを取得する
    Public Shared Function フォームのイメージを取得する(ByVal ctrl As Control) As Bitmap
        Dim g As Graphics = ctrl.CreateGraphics()
        Dim img As New Bitmap(ctrl.ClientRectangle.Width, _
            ctrl.ClientRectangle.Height, g)
        Dim memg As Graphics = Graphics.FromImage(img)
        Dim dc1 As IntPtr = g.GetHdc()
        Dim dc2 As IntPtr = memg.GetHdc()
        BitBlt(dc2, 0, 0, img.Width, img.Height, dc1, 0, 0, SRCCOPY)
        g.ReleaseHdc(dc1)
        memg.ReleaseHdc(dc2)
        memg.Dispose()
        g.Dispose()
        Return img
    End Function
End Class


Imports System.Threading
Imports System.Data.SqlClient
Imports System.Data.Common

Public Class CMdiMain
    Inherits System.Windows.Forms.Form

    '#####################################################################################
    '型
    '#####################################################################################
    Private Enum Enmメニュー表示区分
        Enm無 = 0
        Enm親 = 1
        Enm子 = 2
    End Enum

    ''キーボード操作
    Private Const KEYEVENTF_KEYUP As Integer = &H2
    Private Const KEYEVENTF_KEYCTRL As Integer = &HA2
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)


    Public gMainMnuName As String   'メインメニュー名の保存
    ''フラグ
    Public Const gStrFlgON As String = "1"
    Public Const gStrFlgOFF As String = "0"

    Private Const mCStrTimeFormat As String = "yyyy/MM/dd(ddd) HH:mm:ss" '時刻表示
    Private Const mCStrTimeInterval As String = "1000" '時間間隔

    Private mIsボタンイベント有効 As Boolean = True

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    '時間表示
    Private mStrTimeFormat As String
    Private mIntTimeInterval As Integer

    'メッセージ
    Private mMSG確認_システム終了 As String = "システムを終了します。よろしいですか？"
    Private mMSG注意_起動済み As String = "すでに起動しています。"
    Private mMSG画面情報取得エラー As String = "DP画面IDの取得に失敗しました。"
    Private mMSG画面名取得エラー As String = "画面名が登録されていません。"
    Private mMSG画面ランク取得エラー As String = "画面ランクが登録されていません。"

    Public 画面制御 As C画面制御

    Public gStrログイン管理者ID As String = ""
    Public gStrログイン管理者コード As String = ""
    Public gStrログイン管理者名 As String = ""
    Public gStrエリア名称 As String = CUtil.設定関連.設定文字列読込("エリア名称", "世田谷")
    Public gStrエリアID As String = CUtil.設定関連.設定文字列読込("エリアID", "1")
    Private gstr入園保護者監視用 As String = CUtil.設定関連.設定文字列読込("入園保護者監視用", "")

    '2010 morichika 最新在場保護者情報
    Private mStr最新在場保護者情報 As String = ""

    '2011 morichika
    Public gStr園ID As String = CUtil.設定関連.設定文字列読込("園ID", "1")


    Private Enum EnmCol入園保護者情報
        入園時間
        保護者名
        園児名
        ゲート情報
        cols
    End Enum

    Private mグリッド As UsrDataGridView
    Public Property pグリッド() As UsrDataGridView
        Get
            Return mグリッド
        End Get
        Set(ByVal Value As UsrDataGridView)
            mグリッド = Value
        End Set
    End Property

    Private m園児 As DataTable
    Public Property 園児() As DataTable
        Get
            Return m園児
        End Get
        Set(ByVal value As DataTable)
            m園児 = value
        End Set
    End Property

    '#####################################################################################
    'プロパティー
    '#####################################################################################

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
    Private Sub CMdiMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ''アプリケーションバージョン表示(バージョンを変更する場合はAssemblyInfo.vbの一番したのAssemblyVersionを変更してください。)
            Me.Text = Me.Text & "  (Ver." & Application.ProductVersion & ")"

            ''表示設定
            Me.mStrTimeFormat = CUtil.設定関連.設定文字列読込("時刻表示書式", mCStrTimeFormat)
            Me.mIntTimeInterval = CType(CUtil.設定関連.設定文字列読込("時刻間隔", mCStrTimeInterval), Integer)
            Me.tmrNow.Interval = mIntTimeInterval
            If tmrNow.Interval > 0 Then
                'lblTime.Text = Format(Now, mStrTimeFormat)
                tmrNow.Enabled = True
            Else
                tmrNow.Enabled = False
            End If

            ''画面サイズ
            'Me.Width = System.Windows.Forms.Screen.GetBounds(Me).Width
            'Me.Height = System.Windows.Forms.Screen.GetBounds(Me).Height


        Catch ex As Exception
            Call MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try

        '接続開始2007/08/29 morichika 
        If C画面制御.DB接続処理() Then
        Else
            End
        End If

        ''タイトルにユーザー名を表示
        Me.Text = Me.Text & "    " & CUsrctl.gDp.ユーザ名

    
        '表示開始
        '一旦全画面を表示
        Try
            Me.gSubMDI子フォームを開く(C画面制御入退室管理.ログイン)
    
  
        Catch ex As Exception
            Call Me.mSubエラー表示(ex)
        End Try

    End Sub

    Public Sub MdiMain_Closing(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim intCancel As Boolean = eventArgs.Cancel

        ''システム終了確認
        If MessageBox.Show(Me.mMSG確認_システム終了, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            ''システム終了中止
            intCancel = True

            ''システム終了
        Else
            If CUtil.設定関連.設定文字列読込("自動終了", "0") = "1" Then
                Shell(Application.StartupPath & "\shutdown.exe /p/w1")
            End If

            ''子フォームをすべて閉じる
            Call Me.gSubMDI子フォームをすべて閉じる()

            End
        End If
        GoTo EventExitSub
EventExitSub:
        eventArgs.Cancel = intCancel
    End Sub

#Region "時刻表示"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：時刻表示
    ' 戻り値　：なし
    ' 引　数　：なし
    ' 機能説明：現在時刻を表示する。
    ' 備　考　：時刻表示時間間隔と表示フォーマットは初期設定.INIにて指定可能。
    '---------------------------------------------------------------------------
#End Region
    Private Sub tmrNow_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrNow.Tick
        Try
            ''タイマ停止
            tmrNow.Enabled = False

            ''時刻表示
            Me.lbl現在時刻.Text = Format(Now, mStrTimeFormat)

            ''タイマ開始
            tmrNow.Enabled = True

        Catch ex As Exception
            Call Me.mSubエラー表示(ex)
        End Try
    End Sub

#Region "Windowツール"
    Private Sub tsm重ねて表示_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm重ねて表示.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub tsm並べて表示_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm並べて表示.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub 上下に並べて表示ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm上下に並べて表示.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub 左右に並べて表示ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm左右に並べて表示.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub tsm全て閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm全て閉じる.Click
        For Each ObjMdiChild As Form In Me.MdiChildren
            Call ObjMdiChild.Close()
        Next
    End Sub

    Private Sub tsm画面を閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm画面を閉じる.Click
        For Each ObjMdiChild As Form In Me.MdiChildren
            If Me.ActiveMdiChild.Name = ObjMdiChild.Name Then
                Call ObjMdiChild.Close()
                Exit For
            End If
        Next
    End Sub
#End Region

#Region "編集ツール"
    Private Sub tsm切り取り_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm切り取り.Click
        Call keybd_event(KEYEVENTF_KEYCTRL, 0, 0, 0)
        Call keybd_event(Asc("X"), 0, 0, 0)
        Call keybd_event(Asc("X"), 0, KEYEVENTF_KEYUP, 0)
        Call keybd_event(KEYEVENTF_KEYCTRL, 0, KEYEVENTF_KEYUP, 0)
    End Sub

    Private Sub tsmコピー_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmコピー.Click
        Call keybd_event(KEYEVENTF_KEYCTRL, 0, 0, 0)
        Call keybd_event(Asc("C"), 0, 0, 0)
        Call keybd_event(Asc("C"), 0, KEYEVENTF_KEYUP, 0)
        Call keybd_event(KEYEVENTF_KEYCTRL, 0, KEYEVENTF_KEYUP, 0)
    End Sub

    Private Sub tsm貼り付け_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsm貼り付け.Click
        Call keybd_event(KEYEVENTF_KEYCTRL, 0, 0, 0)
        Call keybd_event(Asc("V"), 0, 0, 0)
        Call keybd_event(Asc("V"), 0, KEYEVENTF_KEYUP, 0)
        Call keybd_event(KEYEVENTF_KEYCTRL, 0, KEYEVENTF_KEYUP, 0)
    End Sub
#End Region

#Region "画面ハードコピー"
    Friend WithEvents printPreviewDialog1 As PrintPreviewDialog
    'フォームのイメージを保存する変数
    Private memoryImage As Bitmap

    '' フォームのイメージを印刷する
    Public Sub PrintForm(ByVal frm As Form)
        'フォームのイメージを取得する
        memoryImage = CUtil画面標準.フォームのイメージを取得する(frm)
        'フォームのイメージを印刷する
        Dim PrintDocument1 As New System.Drawing.Printing.PrintDocument
        '横書き
        PrintDocument1.DefaultPageSettings.Landscape = True

        AddHandler PrintDocument1.PrintPage, _
            AddressOf PrintDocument1_PrintPage

        ' PrintPreviewDialogオブジェクトの生成
        printPreviewDialog1 = New PrintPreviewDialog
        ' Documentプロパティの設定
        printPreviewDialog1.Document = PrintDocument1
        printPreviewDialog1.ShowDialog()

        memoryImage.Dispose()

    End Sub

    'PrintDocument1のPrintPageイベントハンドラ
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, _
            ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        With e
            Dim RateX As Single = CSng(.MarginBounds.Width / memoryImage.Width)
            Dim RateY As Single = CSng(.MarginBounds.Height / memoryImage.Height)
            ' 拡大・縮小ともに小さいほうの係数を採用
            Dim Rate As Single = Math.Min(RateX, RateY)

            Dim Rect As RectangleF = New RectangleF(0, 0, memoryImage.Width * Rate, memoryImage.Height * Rate)

            .Graphics.DrawImage(memoryImage, Rect)
        End With
    End Sub

#End Region
    Private Sub tsmファイルへ保存_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mSubフォーム表示(ByVal str表示画面名称 As String)
        '表示済みフォームをアクティブにする
        Me.gBln子フォームアクティブ化(str表示画面名称)
    End Sub

    Private Sub TSBtn画面印刷_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBtn画面印刷.Click
        'PrintForm(Me)
        CUtil画面標準.ハードコピー画面保存()
    End Sub

    Private Sub tsmシステム終了_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmシステム終了.Click

        If CMsg.gMsg_YesNo("アプリケーションを終了してもよろしいですか？") = Windows.Forms.DialogResult.Yes Then
            'ログイン状態の場合、ログアウト履歴
            'If Me.gStrログイン管理者ID <> "" Then
            '    ログイン履歴追加(False)
            'End If
            'システム終了
            End
        End If
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    ' コンストラクタ（初期化処理などを呼び出す）
    Public Sub New()
        MyBase.New()
        'ThreadExceptionイベント・ハンドラを登録します
        AddHandler Application.ThreadException, AddressOf CUtil画面標準.Application_ThreadException

        'UnhandledExceptionイベント・ハンドラを登録します
        AddHandler Thread.GetDomain().UnhandledException, AddressOf CUtil画面標準.Application_UnhandledException

        '起動済の場合は終了
        If Is二重起動() Then
            Call MessageBox.Show("すでに起動しています。", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If

        C入退管理Ex.ログファイル設定()

        '画面制御 = New C画面制御入退室管理
        Dim t As Type = Type.GetType(CUtil.設定関連.設定文字列読込("画面制御クラス"))
        画面制御 = CType(Activator.CreateInstance(t), C画面制御)

        画面制御.画面初期化処理()

        ' 初期化処理
        InitializeComponent()

        CUtil画面標準.コントロールボックスの閉じるボタンの無効化(Me.Handle)

        Menuメニュー.MdiWindowListItem = WindowsListToolStripMenuItem
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strFormID"></param>
    ''' <param name="blnClose">子フォームをすべて閉じてから開く</param>
    ''' <remarks></remarks>
    Public Sub gSubMDI子フォームを開く(ByVal strFormID As C子画面, Optional ByVal blnClose As Boolean = True)
        Try
            'If strFormID = gStrFlgOFF Then
            '    Exit Sub
            'End If

            Me.gSub処理中設定(Me, True)

            '子フォーム設定表示()
            Dim 子画面 As Object = 画面制御.子フォーム生成(strFormID)
            With CType(子画面, I子画面)
                'lbl画面タイトル.Text = strFormID.画面名 '画面制御.画面名取得(strFormID)

                ' ''子フォーム全消去
                'If blnClose Then
                '    Call gSubMDI子フォームをすべて閉じる()
                'End If

                .画面名 = strFormID.画面名
                .Mdi親画面 = Me
                .共通画面初期設定()
                With CType(子画面, CMdiChild)
                    .Activate()
                End With
                Me.Height -= 1
                Me.Height += 1
                .表示()
                Me.Height -= 1
                Me.Height += 1
            End With

        Catch ex As Exception
            Call Me.mSubエラー表示(ex)
        Finally
            Me.gSub処理中設定(Me, False)
        End Try
    End Sub

    Private Function Is二重起動() As Boolean
        Return (CMyProcess.ShowPrevProcess() And CUtil.設定関連.設定文字列読込("二重起動禁止") = "True")
        'Return UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0
    End Function

    Private Sub mSubエラー表示(ByVal ex As Exception)
        Call MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''共通関数(Public)-------------------------------------------------------------------
#Region "処理中設定"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：処理中設定
    ' 引　数　：bln処理中:TRUE=処理中 FALSE=処理中解除,strMsg:ガイダンスメッセージ
    ' 戻り値　：
    ' 機能説明：処理中設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSub処理中設定(ByVal objFrm As Form, ByVal bln処理中 As Boolean, Optional ByVal strMsg As String = Nothing)
        'Dim objChildFrm As Form

        Try
            ''処理中カーソル
            If bln処理中 Then
                Me.Cursor = Cursors.WaitCursor
                objFrm.Cursor = Cursors.WaitCursor
            Else
                Me.Cursor = Cursors.Default
                objFrm.Cursor = Cursors.Default
            End If

            ''子フォーム処理中
            'For Each objChildFrm In Me.MdiChildren
            '    objChildFrm.Enabled = Not bln処理中
            '    If bln処理中 Then
            '        objChildFrm.Cursor = Cursors.WaitCursor
            '    Else
            '        objChildFrm.Cursor = Cursors.Default
            '    End If
            'Next

            ''メッセージ
            If Not strMsg Is Nothing Then
                Me.lblBottom.Text = strMsg
            End If

        Catch ex As Exception
            Call Me.mSubエラー表示(ex)
        Finally
            Application.DoEvents()
        End Try
    End Sub

    Public Sub gSubMDI子フォームをすべて閉じる()
        Try
            For Each 子フォーム As Form In Me.MdiChildren
                ''ここでVisibleをTrueにしないとCloseイベントがはしらない
                子フォーム.Visible = True

                子フォーム.Close()
            Next

        Catch ex As Exception
            Call Me.mSubエラー表示(ex)
        End Try
    End Sub

    ''' <summary>
    ''' 子フォーム取得
    ''' </summary>
    ''' <param name="strFormID"></param>
    ''' <param name="objFrm"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gBln子フォーム取得(ByVal strFormID As String, ByRef objFrm As Form) As Boolean
        For Each 子フォーム As Form In Me.MdiChildren
            If 子フォーム.Name = strFormID Then
                objFrm = 子フォーム
                Return True
            End If
        Next
    End Function

    ''' <summary>
    ''' 子フォームアクティブ化
    ''' </summary>
    ''' <param name="strFormID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gBln子フォームアクティブ化(ByVal strFormID As String) As Boolean
        For Each 子フォーム As Form In Me.MdiChildren
            If 子フォーム.Name = strFormID Then
                'lbl画面タイトル.Text = 画面制御.画面名取得(strFormID)
                子フォーム.Visible = True
                子フォーム.Enabled = True
                子フォーム.Activate()
                Return True
            End If
        Next

        Return False
    End Function


    ''' <summary>
    ''' 子フォーム有無
    ''' </summary>
    ''' <param name="strFormID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gBln子フォーム有無(ByVal strFormID As String) As Boolean
        For Each 子フォーム As Form In Me.MdiChildren
            If 子フォーム.Name = strFormID Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub 全画面クリア()
        Dim objChildFrm As CMdiChild

        Try
            '子フォーム処理中
            For Each objChildFrm In Me.MdiChildren
                objChildFrm.画面クリア(objChildFrm)
            Next
        Catch ex As Exception
            Call Me.mSubエラー表示(ex)
        Finally
            Application.DoEvents()
        End Try
    End Sub

    <System.Runtime.InteropServices.DllImport("winmm.dll", _
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
    Private Shared Function mciSendString(ByVal command As String, _
        ByVal buffer As System.Text.StringBuilder, _
        ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function

    Private aliasName As String = "MediaFile"

    Private Sub mSub履歴情報表示()
        '3行分のみの処理とします
        Try
            '初期化
            CUsrctl.gSubコントロールの初期化(pグリッド)

            Dim reader As DbDataReader = Nothing
            ''表示
            Dim intCNT As Integer = 1
            Try
                If CUsrctl.gDp.gBlnReader(m最新履歴表示用SQL取得, reader) Then
                    'カウンタクリア
                    intCNT = 1
                    While reader.Read
                        '.Rows.Count += 1
                        Dim 行データ As Object() = New Object(3) {}

                        '2010/11/1 morichika
                        ''3行分処理 ⇒ 4行分処理
                        For i As Integer = 0 To 3
                            Dim value As Object = reader.GetValue(i)
                            If pグリッド.Columns(i).GetType Is GetType(DataGridViewCheckBoxColumn) Then
                                If value.ToString = "1" Then
                                    行データ(i) = True
                                Else
                                    行データ(i) = False
                                End If
                            Else
                                Dim テスト As Boolean = False
                                If テスト Then

                                ElseIf TypeOf value Is Byte() Then
                                    行データ(i) = CUtil.バイト配列ToHexString(CType(value, Byte())) 'ctlFlx(.Rows.Count - 1, i) = CUtil.バイト配列ToHexString(CType(value, Byte()))
                                Else
                                    行データ(i) = value.ToString 'ctlFlx(.Rows.Count - 1, i) = value
                                End If

                            End If
                        Next

                        pグリッド.Rows.Add(行データ)

                        If intCNT = 1 Then
                            '2010/6/3 morichika
                            If reader.GetValue(0).ToString <> mStr最新在場保護者情報 Then

                                'アラームの再生
                                Dim cmd As String
                                '再生するファイル名
                                Dim fileName As String = My.Application.Info.DirectoryPath & "\保護者入場音.wav"

                                '閉じる
                                cmd = "close " + aliasName
                                mciSendString(cmd, Nothing, 0, IntPtr.Zero)

                                'ファイルを開く
                                cmd = "open """ + fileName + """ type mpegvideo alias " + aliasName
                                If mciSendString(cmd, Nothing, 0, IntPtr.Zero) <> 0 Then

                                End If

                                '再生する
                                cmd = "play " + aliasName
                                mciSendString(cmd, Nothing, 0, IntPtr.Zero)

                                ''３秒間のWAIT
                                'System.Threading.Thread.Sleep(3000)

                                ''再生しているWAVEを停止する
                                'cmd = "stop " + aliasName
                                'mciSendString(cmd, Nothing, 0, IntPtr.Zero)


                                mStr最新在場保護者情報 = reader.GetValue(0).ToString
                            End If
                        End If

                        If intCNT = 25 Then
                            Exit While
                        Else
                            intCNT += 1
                        End If

                    End While

                End If

                '2010/11/1 morichika
                '世田谷　駐車場の場合は、表示色を青とする
                Dim j As Integer = 0
                Dim k As Integer = 0
                For j = 0 To pグリッド.RowCount - 1
                    If pグリッド.セル文字列(j, EnmCol入園保護者情報.ゲート情報) = "世田谷駐車場口A" Then
                        For k = 0 To pグリッド.Rows(j).Cells.Count - 1
                            pグリッド.Rows(j).Cells(k).Style.BackColor = Color.Pink
                        Next

                    ElseIf pグリッド.セル文字列(j, EnmCol入園保護者情報.ゲート情報) = "世田谷駐車場口B" Then
                        For k = 0 To pグリッド.Rows(j).Cells.Count - 1
                            pグリッド.Rows(j).Cells(k).Style.BackColor = Color.Pink
                        Next

                    Else

                    End If
                Next

                '非選択状態とする
                pグリッド.ClearSelection()

            Finally
                CUsrctl.gDp.gSubReaderClose(reader)
            End Try

        Catch ex As Exception

        Finally
        End Try
    End Sub

    Private Function m最新履歴表示用SQL取得() As String

        With New CSqlEx
            '---------------------------
            ''DR入退ログ_モニター専用Ver
            '---------------------------
            '.gSubClearSQL()
            ''SELECT
            '.gSubSelect("substring(convert(nvarchar,日時,020),12,8)")
            '.gSubSelect("ISNULL(姓漢字,'') + ISNULL(名漢字,'') 氏名")
            ''FROM
            '.gSubFrom("DR入退場ログ_モニター専用")
            ''WHERE
            ''該当園の情報のみ表示
            '.gSubWhere("DR入退場ログ_モニター専用.ゲート名漢字 = '" & gstr入園保護者監視用 & "'")
            ''当日の入場履歴のみ表示
            '.gSubWhere日時文字列YYYYMMDD("日時", Format(Now, "yyyyMMdd"), "=")

            ''ステータス異常のものは非表示
            '.gSubWhere("ステータス = 0")
            '.gSubOrderBy("日時 DESC")

            ''---------------
            ''DR在場者情報Ver
            ''---------------
            '.gSubClearSQL()
            '.gSubSelect("substring(convert(nvarchar,DR在場保護者情報.日時,020),12,8)")
            '.gSubSelect("ISNULL(DMユーザ.姓漢字,'') + ISNULL(DMユーザ.名漢字,'') 氏名")
            '.gSubSelect("ISNULL(DM園児.姓ひら,'') + ISNULL(DM園児.名ひら,'') 園児氏名")

            ''.gSubFrom("DR在場保護者情報 left join DMユーザ on DR在場保護者情報.ユーザID = DMユーザ.ユーザID")

            ''.gSubFrom("DR在場保護者情報 left join DMユーザ on DR在場保護者情報.ユーザID = DMユーザ.ユーザID" & ControlChars.CrLf _
            ''   & " LEFT JOIN DR保護者園児割当 ON DMユーザ.ユーザID = DR保護者園児割当.保護者ユーザID" & ControlChars.CrLf _
            ''   & " LEFT JOIN DM園児 ON DR保護者園児割当.園児ユーザID = DM園児.ユーザID" & ControlChars.CrLf)

            '.gSubFrom("DR在場保護者情報 left join DMユーザ on DR在場保護者情報.ユーザID = DMユーザ.ユーザID" & ControlChars.CrLf _
            '   & " LEFT JOIN DR保護者園児割当 ON DMユーザ.ユーザID = DR保護者園児割当.保護者ユーザID" & ControlChars.CrLf)

            '.gSubFrom("DM園児")
            '.gSubFrom("DMエリア")
            '.gSubWhere("DMエリア.エリアID = DR在場保護者情報.エリアID")
            '.gSubWhere("DR保護者園児割当.園児ユーザID = DM園児.ユーザID")
            '.gSubWhere("DR在場保護者情報.エリアID", gStrエリアID)
            ''当日の在場履歴のみ表示
            '.gSubWhere日時文字列YYYYMMDD("DR在場保護者情報.日時", Format(Now, "yyyyMMdd"), "=")
            '.gSubOrderBy("DR在場保護者情報.日時 DESC")

            '---------------
            'DR在場者&降園履歴情報Ver
            '---------------
            .gSubClearSQL()
            .gSubSelect("ユーザID")
            .gSubFrom("DR登降園履歴")
            .gSubWhere("登降区分 = 'true'")
            .gSubWhere日時文字列YYYYMMDD("日時", Format(Now, "yyyyMMdd"), "=")

            Dim strユーザデータ As String = .gSQL文の取得

            .gSubClearSQL()
            .gSubSelect("substring(convert(nvarchar,DR在場保護者情報.日時,020),12,8)")
            .gSubSelect("ISNULL(DMユーザ.姓漢字,'') + ISNULL(DMユーザ.名漢字,'') 氏名")
            .gSubSelect("ISNULL(DM園児.姓ひら,'') + ISNULL(DM園児.名ひら,'') 園児氏名")
            '2010/11/1 morichika
            .gSubSelect("DR入退場履歴.ゲート名漢字")

            '.gSubFrom("DR在場保護者情報 left join DMユーザ on DR在場保護者情報.ユーザID = DMユーザ.ユーザID")

            '.gSubFrom("DR在場保護者情報 left join DMユーザ on DR在場保護者情報.ユーザID = DMユーザ.ユーザID" & ControlChars.CrLf _
            '   & " LEFT JOIN DR保護者園児割当 ON DMユーザ.ユーザID = DR保護者園児割当.保護者ユーザID" & ControlChars.CrLf _
            '   & " LEFT JOIN DM園児 ON DR保護者園児割当.園児ユーザID = DM園児.ユーザID" & ControlChars.CrLf)

            .gSubFrom("DR在場保護者情報 left join DMユーザ on DR在場保護者情報.ユーザID = DMユーザ.ユーザID" & ControlChars.CrLf _
               & " LEFT JOIN DR保護者園児割当 ON DMユーザ.ユーザID = DR保護者園児割当.保護者ユーザID" & ControlChars.CrLf)

            .gSubFrom("DM園児 left join (" & strユーザデータ & ") 降園園児 ON DM園児.ユーザID = 降園園児.ユーザID")
            .gSubFrom("DMエリア")
            .gSubFrom("DR入退場履歴")
            .gSubWhere("DMエリア.エリアID = DR在場保護者情報.エリアID")
            .gSubWhere("DR保護者園児割当.園児ユーザID = DM園児.ユーザID")
            .gSubWhere("DR在場保護者情報.エリアID", gStrエリアID)
            '当日の在場履歴のみ表示 ※設定時間以後の在場情報のみとする
            .gSubWhere日時文字列YYYYMMDD("DR在場保護者情報.日時", Format(Now, "yyyyMMdd"), "=")

            '当日の降園履歴がある場合は非表示
            .gSubWhere("降園園児.ユーザID is NULL")

            '駐車場情報対応
            .gSubWhere("DR在場保護者情報.日時 = DR入退場履歴.日時")
            .gSubWhere("DR在場保護者情報.ユーザID = DR入退場履歴.ユーザID")

            .gSubOrderBy("DR在場保護者情報.日時 DESC")

            Return .gSQL文の取得
        End With
    End Function

    Private Function Is該当曜日のクラブ割当がある(ByVal ユーザID As String, ByVal 曜日ID As String) As Boolean
        With New CSqlEx
            .gSubSelect("COUNT(*)")
            .gSubFrom("DR園児クラブ割当")
            .gSubWhere("ユーザID", ユーザID, , , , , , , False)
            .gSubWhere("曜日ID", 曜日ID, , , , , , , False)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                Return True
            End If
        End With
    End Function

End Class

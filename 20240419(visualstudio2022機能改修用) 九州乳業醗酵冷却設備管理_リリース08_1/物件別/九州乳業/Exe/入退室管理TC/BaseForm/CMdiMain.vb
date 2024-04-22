
Imports System.Threading
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.IO.Ports
Imports System.Text

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
    Public mInt醗酵冷却モード As Integer = 0

    'メッセージ
    Private mMSG確認_システム終了 As String = "システムを終了します。よろしいですか？"
    Private mMSG注意_起動済み As String = "すでに起動しています。"
    Private mMSG画面情報取得エラー As String = "DP画面IDの取得に失敗しました。"
    Private mMSG画面名取得エラー As String = "画面名が登録されていません。"
    Private mMSG画面ランク取得エラー As String = "画面ランクが登録されていません。"

    Public 画面制御 As C画面制御

    Private mグリッド As UsrDataGridView
    Public Property pグリッド() As UsrDataGridView
        Get
            Return mグリッド
        End Get
        Set(ByVal Value As UsrDataGridView)
            mグリッド = Value
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

        'DB接続
        If C画面制御.DB接続処理() Then

        Else
            End
        End If

        ''タイトルにユーザー名を表示
        Me.Text = Me.Text & "    " & CUsrctl.gDp.ユーザ名


        '表示開始
        '一旦全画面を表示
        mInt醗酵冷却モード = CUtil.設定関連.設定文字列読込("APL_MODE", 0)

        Try
            If mInt醗酵冷却モード = 0 Then
                Me.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)

            Else
                Me.gSubMDI子フォームを開く(C画面制御オーダー別.冷却メインメニュー)

            End If

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
                'Shell(Application.StartupPath & "\shutdown.exe /p/w1")
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

    Private Sub mSubフォーム表示(ByVal str表示画面名称 As String)
        '表示済みフォームをアクティブにする
        Me.gBln子フォームアクティブ化(str表示画面名称)
    End Sub

    Private Sub TSBtn画面印刷_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'PrintForm(Me)
        CUtil画面標準.ハードコピー画面保存()
    End Sub

    Private Sub tsmシステム終了_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CMsg.gMsg_YesNo("アプリケーションを終了してもよろしいですか？") = Windows.Forms.DialogResult.Yes Then
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

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strFormID"></param>
    ''' <param name="blnClose">子フォームをすべて閉じてから開く</param>
    ''' <remarks></remarks>
    Public Sub gSubMDI子フォームを開く(ByVal strFormID As C子画面, Optional ByVal blnClose As Boolean = True, Optional ByVal str画面モード As String = "0")
        Try
            'If strFormID = gStrFlgOFF Then
            '    Exit Sub
            'End If

            Me.gSub処理中設定(Me, True)

            '子フォーム設定表示()
            Dim 子画面 As Object = 画面制御.子フォーム生成(strFormID)
            With CType(子画面, I子画面)
                lbl画面タイトル.Text = strFormID.画面名 '画面制御.画面名取得(strFormID)

                ''子フォーム全消去
                If blnClose Then
                    Call gSubMDI子フォームをすべて閉じる()
                End If
                .画面名 = strFormID.画面名
                .Mdi親画面 = Me
                .共通画面初期設定()
                .画面モード = str画面モード
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

    Public Sub mSubエラー表示(ByVal ex As Exception)
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

    <System.Runtime.InteropServices.DllImport("winmm.dll",
        CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function mciSendString(ByVal command As String,
        ByVal buffer As System.Text.StringBuilder,
        ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function

    Private aliasName As String = "MediaFile"

    Public Function intデバイスステータス(ByVal int倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal ビットNo As Integer) As Integer
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("ステータス")
                .gSubFrom("DSデバイス")
                .gSubWhere("倉庫区分", int倉庫区分, , , , , , , False)
                .gSubWhere("デバイスNo", デバイスNo, , , , , , , False)
                .gSubWhere("ビットNo", ビットNo, , , , , , , False)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Dim value As Object = reader.GetValue(0)
                        Return value.ToString
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Public Function str品種名取得(ByVal str製品区分 As String, ByVal str品種CD As String) As String
        Dim reader As DbDataReader = Nothing
        Dim str品種名 As String = ""
        Try

            With New CSqlEx
                .gSubSelect("A.品種名")
                .gSubSelect("A.所定醗酵時間")
                .gSubSelect("A.所定冷却時間")
                .gSubFrom("DM品種 A")
                If str製品区分 <> 9 Then
                    .gSubWhere("A.製品区分", str製品区分)
                End If
                .gSubWhere("A.品種CD", str品種CD)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        str品種名 = reader.GetValue(0)
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Return str品種名
    End Function
    Public Function str所定賞味期間取得(ByVal str製品区分 As String, ByVal str品種CD As String) As String
        Dim reader As DbDataReader = Nothing
        Dim str所定賞味期間 As String = ""
        Try

            With New CSqlEx
                .gSubSelect("A.品種名")
                .gSubSelect("A.所定醗酵時間")
                .gSubSelect("A.所定冷却時間")
                .gSubSelect("A.所定賞味期間")
                .gSubFrom("DM品種 A")
                If str製品区分 <> 9 Then
                    .gSubWhere("A.製品区分", str製品区分)
                End If
                .gSubWhere("A.品種CD", str品種CD)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        str所定賞味期間 = reader.GetValue(3)
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Return str所定賞味期間
    End Function
    Public Function blnON状態(ByVal 倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal ビットNo As Integer) As Boolean
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("ステータス")
                .gSubFrom("DSデバイス")
                .gSubWhere("倉庫区分", 倉庫区分, , , , , , , False)
                .gSubWhere("デバイスNo", デバイスNo, , , , , , , False)
                .gSubWhere("ビットNo", ビットNo, , , , , , , False)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If reader.GetValue(0) = 1 Then
                            Return True
                        Else
                            Return False
                        End If
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function


    Public Function blnロット完了状態(ByVal ラインNo As Integer) As String
        Dim reader As DbDataReader = Nothing
        Dim blnロット完了 As Boolean = False
        Try

            With New CSqlEx
                .gSubSelect("A.ロット完了")
                .gSubFrom("DN製造製品 A")
                .gSubWhere("A.製造ライン", ラインNo, , , , , , , False)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        blnロット完了 = reader.GetValue(0)
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Return blnロット完了
    End Function

    Public Sub Updateロット完了(ByVal blnON As Boolean, ByVal ラインNo As Integer)
        Try
            'トラッキングデータを更新する
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DN製造製品"
                .gSubColumnValue("ロット完了", Int(blnON), False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubWhere("製造ライン", ラインNo, , , , , , , False)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Public Sub 帳票出力(ByVal レポート As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal 名称 As String, ByVal strSQL As String, Optional ByVal str条件 As String = "")
        Try
            ''処理中設定
            Call Me.gSub処理中設定(Me, True, M定数.MSG_処理中)

            Call Application.DoEvents()

            Dim reader As DbDataReader = Nothing

            Try
                ''データ抽出
                If Not CUsrctl.gDp.gBlnReader(strSQL, reader) Then
                    Exit Sub
                End If

                If Not reader.Read Then
                    CMsg.gMsg_注意("出力する情報がありません")
                    Exit Sub
                End If

                'DataReaderを元にデータテーブルを作成する
                Dim テーブル As New DataTable

                For i As Integer = 0 To reader.FieldCount - 1
                    テーブル.Columns.Add(reader.GetName(i))
                Next

                ''明細書き込み
                Do
                    Dim コピー先の行 As DataRow = テーブル.NewRow
                    For i As Integer = 0 To reader.FieldCount - 1
                        If IsDBNull(reader(i)) Then
                            コピー先の行(i) = ""
                        Else
                            コピー先の行(i) = CStr(reader(i)).Trim
                        End If

                    Next
                    テーブル.Rows.Add(コピー先の行)

                Loop While reader.Read

                With New CReport
                    レポート.SetDataSource(テーブル)
                    レポート.DataDefinition.FormulaFields.Item("UnboundString1").Text = "'" & 名称 & "'"
                    If str条件 <> "" Then
                        レポート.DataDefinition.FormulaFields.Item("UnboundString2").Text = "'" & str条件 & "'"
                    End If

                    .Text = 名称
                    .印刷実行(レポート, False)
                End With

            Catch ex As Exception
                Call CMsg.gMsg_エラー(ex.ToString)
                レポート.Clone()

            Finally
                CUsrctl.gDp.gSubReaderClose(reader)
            End Try

        Catch ex As Exception
            Call CMsg.gMsg_エラー(ex.ToString)

        Finally
            ''処理中解除
            Me.gSub処理中設定(Me, False, "")
        End Try
    End Sub

    Private Sub メニュー切替ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles メニュー切替ToolStripMenuItem.Click
        'モードの切り替え
        If lbl画面タイトル.Text = "醗酵メインメニュー" Then
            Try
                Me.gSubMDI子フォームを開く(C画面制御オーダー別.冷却メインメニュー)

            Catch ex As Exception
                Call Me.mSubエラー表示(ex)
            End Try

        Else
            Try
                Me.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)

            Catch ex As Exception
                Call Me.mSubエラー表示(ex)
            End Try

        End If

    End Sub
End Class

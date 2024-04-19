Imports System.Data.Common

Public Class CMdiChild
    Implements I子画面

    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Public gMdiMain As CMdiMain         '親フォームの参照

    ''プロパティーの変数
    Private mctlInitialFocus As Control

    '#####################################################################################
    'プロパティー
    '#####################################################################################

    Private m処理区分 As enm処理区分
    Public Property 処理区分() As enm処理区分
        Get
            Return m処理区分
        End Get
        Set(ByVal value As enm処理区分)
            m処理区分 = value
        End Set
    End Property

    Private mグリッド As UsrDataGridView
    Public Property pグリッド() As UsrDataGridView
        Get
            Return mグリッド
        End Get
        Set(ByVal Value As UsrDataGridView)
            mグリッド = Value
        End Set
    End Property

    Public Property 画面名() As String Implements 画面標準.I子画面.画面名
        Get
            Return Me.Name
        End Get
        Set(ByVal value As String)
            Me.Name = value
        End Set
    End Property

    Public Property Mdi親画面() As System.Windows.Forms.Form Implements 画面標準.I子画面.Mdi親画面
        Get
            Return MdiParent
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            MdiParent = value
        End Set
    End Property

    Public m画面モード As String
    Public Property 画面モード() As String Implements 画面標準.I子画面.画面モード
        Get
            Return m画面モード
        End Get
        Set(ByVal value As String)
            m画面モード = value
        End Set
    End Property

#Region "初期フォーカスをセットするコントロール"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pInitialFocus
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：フォームロード後にフォーカスをセットするコントロール
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pInitialFocus() As Control
        Get
            Return Me.mctlInitialFocus
        End Get
        Set(ByVal Value As Control)
            Me.mctlInitialFocus = Value
        End Set
    End Property

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
#Region "KeyDownイベント"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：KeyDown
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：エンターキーで次のコントロールへ、ファンクションキー操作
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Protected Sub CMdiChild_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim ctlObj As Control
        Dim strKey As String

        Try
            If e.KeyCode = Keys.Enter Then
                ' ''エンターキーを各画面で処理する場合はオーバーライドする。
                If Me.iRBlnKeyEnter(sender, e) Then
                    e.Handled = True
                End If
            Else
                ''ファンクションキー動作
                Select Case e.KeyCode
                    Case Keys.F1 To Keys.F12
                        strKey = e.KeyCode.ToString
                        If e.Shift Then
                            strKey = "S" & strKey
                        End If

                        For Each ctlObj In Me.Controls
                            If TypeOf ctlObj Is usrBtn Then
                                If CType(ctlObj, usrBtn).pFuncKey = strKey Then
                                    If ctlObj.Visible And ctlObj.Enabled Then
                                        Call CType(ctlObj, usrBtn).PerformClick()
                                    End If
                                    e.Handled = True
                                    Exit Sub
                                End If
                            End If
                        Next
                        e.Handled = True
                    Case Else
                End Select
            End If
        Catch ex As Exception
            Call C入退管理Ex._Log.WriteLine(ex.StackTrace)
        End Try
    End Sub

#Region "CMdiChild_KeyPress"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：KeyPress
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：小文字を大文字に変換
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Private Sub CMdiChild_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'If Char.IsLetter(e.KeyChar) Then
        '    If Char.IsLower(e.KeyChar) Then
        '        e.Handled = True
        '        SendKeys.Send(CStr(Char.ToUpper(e.KeyChar)))
        '    End If
        'End If
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Public Sub 共通画面初期設定() Implements 画面標準.I子画面.共通画面初期設定
        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .ControlBox = False
            .MaximizeBox = False
            .MinimizeBox = False
            .ShowInTaskbar = False

            'サイズはINIファイルから設定できるようにする
            'Dim intX As Integer = CInt(CUtil.設定関連.設定文字列読込("画面サイズX", "1005"))
            'Dim intY As Integer = CInt(CUtil.設定関連.設定文字列読込("画面サイズY", "626"))

            '.Size = New Size(intX, intY)

            '.StartPosition = FormStartPosition.Manual
            '.StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .gMdiMain = CType(.ParentForm, CMdiMain)
        End With
    End Sub

    Private Sub CMdiChild_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '有効btn設定(Me.Name)
    End Sub

    Private Sub btn無効化(ByVal str処理区分 As String)
        Dim objControl1 As Control
        Dim objControl2 As Control

        '子フォーム処理中
        For Each objControl1 In Me.Controls

            If TypeOf objControl1 Is 共通Windowsコントロール.usrBtn Then
                objControl1.Enabled = False

                Select Case str処理区分
                    Case "0" 'すべて使用不可

                    Case "1"    '表示のみ
                        Select Case objControl1.Name
                            Case "btn検索"
                                objControl1.Enabled = True
                            Case "btn詳細"
                                objControl1.Enabled = True
                            Case "btnF2"
                                If Me.Name = "登録者情報照会" Then
                                    objControl1.Enabled = True
                                End If
                            Case "btnクリア"
                                objControl1.Enabled = True
                            Case "btnモニター機能"
                                objControl1.Enabled = True

                            Case "btn再表示"
                                objControl1.Enabled = True

                        End Select

                    Case "2"    '表示・印刷のみ
                        Select Case objControl1.Name
                            Case "btn検索"
                                objControl1.Enabled = True
                            Case "btn詳細"
                                objControl1.Enabled = True
                            Case "btnF2"
                                If Me.Name = "登録者情報照会" Then
                                    objControl1.Enabled = True
                                End If
                            Case "btnクリア"
                                objControl1.Enabled = True
                            Case "btn印刷"
                                objControl1.Enabled = True
                            Case "btnCSV出力"
                                objControl1.Enabled = True
                            Case "btnモニター機能"
                                objControl1.Enabled = True

                            Case "btn再表示"
                                objControl1.Enabled = True
                        End Select

                    Case "3"    'すべて
                        objControl1.Enabled = True

                End Select
            End If

            If TypeOf objControl1 Is GroupBox Then
                For Each objControl2 In CType(objControl1, GroupBox).Controls
                    If TypeOf objControl2 Is 共通Windowsコントロール.usrBtn Then
                        objControl2.Enabled = False

                        Select Case str処理区分
                            Case "0" 'すべて使用不可

                            Case "1"    '表示のみ
                                Select Case objControl2.Name
                                    Case "btn検索"
                                        objControl2.Enabled = True
                                    Case "btn詳細"
                                        objControl2.Enabled = True
                                    Case "btnF2"
                                        If Me.Name = "登録者情報照会" Then
                                            objControl2.Enabled = True
                                        End If
                                    Case "btnクリア"
                                        objControl2.Enabled = True
                                    Case "btnモニター機能"
                                        objControl1.Enabled = True

                                    Case "btn再表示"
                                        objControl1.Enabled = True
                                End Select

                            Case "2"    '表示・印刷のみ
                                Select Case objControl2.Name
                                    Case "btn検索"
                                        objControl2.Enabled = True
                                    Case "btn詳細"
                                        objControl2.Enabled = True
                                    Case "btnF2"
                                        If Me.Name = "登録者情報照会" Then
                                            objControl1.Enabled = True
                                        End If
                                    Case "btnクリア"
                                        objControl2.Enabled = True
                                    Case "btn印刷"
                                        objControl2.Enabled = True
                                    Case "btnCSV出力"
                                        objControl2.Enabled = True
                                    Case "btnモニター機能"
                                        objControl1.Enabled = True

                                    Case "btn再表示"
                                        objControl1.Enabled = True
                                End Select

                            Case "3"    'すべて
                                objControl2.Enabled = True

                        End Select
                    End If
                Next
            End If
            
        Next

    End Sub

    Public Overridable Sub gRSubF再表示(Optional ByVal blnボタン設定 As Boolean = True, Optional ByVal bln初期化 As Boolean = True)
        Dim reader As DbDataReader = Nothing

        Try
            If bln初期化 = True Then
                ''表示前処理(通常はpFlxGridのクリアと条件別グリッドの設定)
                Call Me.iRSub表示前処理(Me.pグリッド)
            End If

            If CUsrctl.gDp.gBlnReader(Me.iRStr表示SQL, reader) Then
                ''表示
                If Not pグリッド Is Nothing Then
                    pグリッド.表示(reader)
                    If Not pグリッド.件数表示ラベル Is Nothing Then
                        pグリッド.件数表示ラベル.Text = pグリッド.RowCount.ToString
                    End If
                End If
            End If
        Finally
            ''ボタン設定
            If blnボタン設定 Then
                Call Me.gRSubボタン設定()
            End If

            CUsrctl.gDp.gSubReaderClose(reader)

        End Try
        If pグリッド.Rows.Count = 0 Then
            '09/01/19 morichika
            '該当データなし情報は非表示
            'CMsg.gMsg_情報(MSG_該当データなし)
        End If
    End Sub

    Public Overridable Function mbln表示件数() As Boolean
        Dim reader As DbDataReader = Nothing
        Try
            If CUsrctl.gDp.gBlnReader(Me.iRStr表示SQL, reader) Then

                If reader Is Nothing Then
                    Exit Function
                End If

                Dim intRowCount As Integer
                While reader.Read

                    intRowCount += 1

                End While

                If intRowCount >= 5000 And intRowCount < 10000 Then
                    If CMsg.gMsg_YesNo("表示件数が5000件以上となりますが表示しますか？") = Windows.Forms.DialogResult.No Then
                        Call Me.gRSubボタン設定()
                        Return False
                    End If
                ElseIf intRowCount >= 10000 Then
                    If CMsg.gMsg_YesNo("表示件数が10000件以上となりますが表示しますか？") = Windows.Forms.DialogResult.No Then
                        Call Me.gRSubボタン設定()
                        Return False
                    End If
                End If

                Return True
            End If
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Protected Overridable Sub iRSub表示前処理(ByVal flx As UsrDataGridView)
        CUsrctl.gSubコントロールの初期化(flx)
    End Sub

    Protected Overridable Function iRStr表示SQL(Optional ByVal enmSqlType As CSql.SQL_TYPE = CSql.SQL_TYPE.SQL_SELECT) As String
        Return ""
    End Function

    ''' <summary>
    ''' ボタンの有効無効設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub gRSubボタン設定()
    End Sub

#Region "フォーカスセット"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：フォーカスセット
    ' 引　数　：ctlSet:コントロール
    ' 戻り値　：
    ' 機能説明：ctlSetのインデクッス順にセットできるコントロールをしらべてフォーカスをセットする。
    ' 備　考　：タブコントロールの場合はタブページをアクティブにする
    ' 　　　　：UsrFlx時は表示行がなければセットされない
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSetFocus(ByVal ParamArray ctlSet() As Control)
        Dim i As Integer

        For i = 0 To UBound(ctlSet)
            If CUsrctlベース.Isフォーカスセット可能(ctlSet(i)) Then
                Call Me.mSubフォーカスのセット(ctlSet(i))
                Exit Sub
            End If
        Next
    End Sub

    ''内部関数(Sub)----------------------------------------------------------------------------
    ''' <summary>
    ''' フォーカスのセット
    ''' </summary>
    ''' <param name="ctlSet">コントロール</param>
    ''' <remarks>複合コントロールの場合はiSubFocusを呼び出す</remarks>
    Private Sub mSubフォーカスのセット(ByVal ctlSet As Control)
        ctlSet.Focus()
    End Sub

    Protected Overloads Sub iSubFCSV(ByVal reader As DbDataReader, ByVal blnHedda As Boolean)
        Try
            Call Me.gMdiMain.gSub処理中設定(Me, True, M定数.MSG_実行中)

            With New CCsv出力
                .出力(reader, blnHedda)
            End With
        Finally
            Me.gMdiMain.gSub処理中設定(Me, False, "")
            Call Me.gSubSetFocus(Me.pInitialFocus)
        End Try
    End Sub

    Protected Overloads Sub iSubFCSV(ByVal strSQL As String, ByVal blnヘッダ As Boolean)
        Try
            Call Me.gMdiMain.gSub処理中設定(Me, True, M定数.MSG_実行中)

            With New CCsv出力
                .出力(strSQL, blnヘッダ)
            End With
        Finally
            Me.gMdiMain.gSub処理中設定(Me, False, "")
            Call Me.gSubSetFocus(Me.pInitialFocus)
        End Try
    End Sub

    Protected Overloads Sub iSubFCSV(ByVal グリッド As DataGridView, ByVal Isヘッダ出力あり As Boolean)
        Try
            Call Me.gMdiMain.gSub処理中設定(Me, True, M定数.MSG_実行中)

            With New CCsv出力
                .出力(グリッド, Isヘッダ出力あり)
            End With
        Finally
            Me.gMdiMain.gSub処理中設定(Me, False, "")
            Call Me.gSubSetFocus(Me.pInitialFocus)
        End Try
    End Sub

    Public Sub グリッドを元にCSV出力()
        Try
            ''処理中設定
            Call Me.gMdiMain.gSub処理中設定(Me, True, M定数.MSG_処理中)

            iSubFCSV(pグリッド, True)
        Catch ex As Exception

        Finally
            ''処理中解除
            Me.gMdiMain.gSub処理中設定(Me, False, "")
        End Try
    End Sub

    Public Sub グリッドを元に印刷実行(ByVal レポート As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal 名称 As String)
        Try
            ''処理中設定
            Call Me.gMdiMain.gSub処理中設定(Me, True, M定数.MSG_処理中)

            With New CReport
                'Dim oリスト As New 在場者リスト
                レポート.SetDataSource(pグリッド.グリッドを元にデータテーブルを作成する)
                .Text = 名称
                .印刷実行(レポート)
            End With

        Catch ex As Exception

        Finally
            ''処理中解除
            Me.gMdiMain.gSub処理中設定(Me, False, "")

        End Try
    End Sub

    Public Overridable Function 削除処理() As Boolean
        CMsg.gMsg_注意("未実装処理")
    End Function

    Public Overridable Function 削除チェック処理() As Boolean
        'CMsg.gMsg_注意("未実装処理")
        Return True
    End Function

    Public Sub 標準削除処理()
        If pグリッド.Row < 0 Then
            CMsg.gMsg_注意(MSG_データ未選択)
            Exit Sub
        End If
        If CUsrctl.gMsg_更新処理確認(enm処理区分.削除) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim Isコミット As Boolean = False
        Try

            If Not 削除チェック処理() Then
                Exit Sub
            End If

            CUsrctl.gDp.gSubトランザクション開始()  'トランザクション開始

            If Not 削除処理() Then
                Exit Sub
            End If

            Isコミット = True

        Finally
            CUsrctl.gDp.gSubトランザクション終了(Isコミット)
        End Try

        If Isコミット Then
            CMsg.gMsg_削除完了メッセージ()
        End If

        Call Me.gRSubボタン設定()
        Me.gRSubF再表示()
    End Sub

    'オーバーライド可能宣言---------------------------------------------------------------
    ''' <summary>
    ''' エンターキーの処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks>エンターキーのときにタブキーを送り次のコントロールへ(グリッドは処理しない)
    '''  エンターキーの動作を各画面で行う場合はオーバーライドする</remarks>
    Protected Overridable Function iRBlnKeyEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean
        If TypeOf Me.ActiveControl Is TabControl _
            Or TypeOf Me.ActiveControl Is IEnterキー制御 Then
            SendKeys.Send("{TAB}")
            Return True
        End If
    End Function

    Public Sub 表示() Implements 画面標準.I子画面.表示
        Show()
    End Sub

    Public Overridable Sub 画面クリア(ByVal objform As Form)
        Dim objControl1 As Control
        Dim objControl2 As Control

        Try
            '子フォーム処理中
            For Each objControl1 In objform.Controls

                If TypeOf objControl1 Is usrCmb Then
                    CType(objControl1, usrCmb).クリア()
                End If

                If TypeOf objControl1 Is UsrDataGridView Then
                    CType(objControl1, UsrDataGridView).クリア()
                End If

                If TypeOf objControl1 Is usrTxt Then
                    CType(objControl1, usrTxt).クリア()
                End If

                If TypeOf objControl1 Is usrDate Then
                    CType(objControl1, usrDate).クリア()
                End If

                '表示件数の初期化
                If TypeOf objControl1 Is usrLbl Then
                    If objControl1.Name = "Lbl件数" Then
                        objControl1.Text = "-----"
                    End If
                End If

                If TypeOf objControl1 Is GroupBox Then
                    For Each objControl2 In CType(objControl1, GroupBox).Controls
                        If TypeOf objControl2 Is usrCmb Then
                            CType(objControl2, usrCmb).クリア()
                        End If

                        If TypeOf objControl2 Is UsrDataGridView Then
                            CType(objControl2, UsrDataGridView).クリア()
                        End If

                        If TypeOf objControl2 Is usrTxt Then
                            CType(objControl2, usrTxt).クリア()
                        End If

                        If TypeOf objControl2 Is usrDate Then
                            CType(objControl2, usrDate).クリア()
                        End If

                        '表示件数の初期化
                        If TypeOf objControl2 Is usrLbl Then
                            If objControl2.Name = "Lbl件数" Then
                                objControl2.Text = "-----"
                            End If
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            'Call Me.mSubエラー表示(ex)
        Finally
            Application.DoEvents()
        End Try
    End Sub

End Class

Public Class CCsv出力
    Public ダイアログ As New SaveFileDialog
    Public Sub New()
        ダイアログ.Filter = "csv files (*.csv)|*.csv"
    End Sub

    Private Sub ヘッダ書込(ByVal sw As System.IO.StreamWriter, ByVal reader As DbDataReader)
        Dim strCSV As String = ""
        For i As Integer = 0 To reader.FieldCount - 1
            strCSV = strCSV & "," & reader.GetName(i)
        Next
        sw.WriteLine(strCSV.Substring(1))
    End Sub
    Private Sub ヘッダ書込(ByVal sw As System.IO.StreamWriter, ByVal グリッド As DataGridView)
        Dim strCSV As String = ""
        For Each 列 As DataGridViewColumn In グリッド.Columns
            If 列.Visible Then
                strCSV = strCSV & "," & 列.Name
            End If
        Next
        sw.WriteLine(strCSV.Substring(1))
    End Sub
    Private Sub ヘッダ書込(ByVal sw As System.IO.StreamWriter, ByVal List As ArrayList)
        Dim strCSV As String = ""
        Dim i As Integer
        For i = 0 To List.Count - 1
            strCSV = strCSV & "," & List(i).ToString
        Next
        sw.WriteLine(strCSV.Substring(1))
    End Sub
    Public Sub 出力(ByVal sql As String, ByVal Isヘッダ出力あり As Boolean)
        Dim reader As DbDataReader = Nothing
        Try
            ''データ抽出
            If Not CUsrctl.gDp.gBlnReader(sql, reader) Then
                Exit Sub
            End If
            出力(reader, Isヘッダ出力あり)
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub
    Public Sub 出力(ByVal reader As DbDataReader, ByVal Isヘッダ出力あり As Boolean)
        If Not reader.Read Then
            Exit Sub
        End If

        If ダイアログ.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Call Application.DoEvents()

            Dim fs As New System.IO.FileStream(ダイアログ.FileName, System.IO.FileMode.OpenOrCreate)
            Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(932))
            'JISの場合は下記のようにする    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(50220))
            'EUCの場合は下記のようにする    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(51932))
            Try
                If Isヘッダ出力あり Then
                    ヘッダ書込(sw, reader)
                End If

                ''明細書き込み
                Do
                    Dim strCSV As String = ""
                    For i As Integer = 0 To reader.FieldCount - 1
                        If IsDBNull(reader(i)) Then
                            strCSV = strCSV & ",Null"
                        Else
                            strCSV = strCSV & "," & CStr(reader(i)).Trim
                        End If
                    Next
                    sw.WriteLine(strCSV.Substring(1))

                Loop While reader.Read
            Finally
                sw.Close()
            End Try

            CMsg.gMsg_情報("CSV出力しました。")
        End If
    End Sub

    Public Sub 出力(ByVal グリッド As DataGridView, ByVal Isヘッダ出力あり As Boolean)
        If ダイアログ.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Call Application.DoEvents()
            Dim fs As New System.IO.FileStream(ダイアログ.FileName, IO.FileMode.Create)
            Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(932))
            'JISの場合は下記のようにする    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(50220))
            'EUCの場合は下記のようにする    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(51932))
            Try
                If Isヘッダ出力あり Then
                    ヘッダ書込(sw, グリッド)
                End If

                ''明細書き込み
                For Each 行 As DataGridViewRow In グリッド.Rows
                    Dim strCSV As String = ""
                    For Each 列 As DataGridViewColumn In グリッド.Columns
                        If 列.Visible Then
                            If IsDBNull(行.Cells(列.Name)) Then
                                strCSV = strCSV & ",Null"
                            Else
                                strCSV = strCSV & "," & CStr(行.Cells(列.Name).Value).Trim
                            End If
                        End If
                    Next
                    sw.WriteLine(strCSV.Substring(1))
                Next
                CMsg.gMsg_情報("CSV出力しました。")
            Finally
                sw.Close()
            End Try
        End If
    End Sub

    Public Sub 出力_ヘッダのみ(ByVal List As ArrayList, ByVal filename As String)
            Call Application.DoEvents()
        Dim fs As New System.IO.FileStream(filename, IO.FileMode.Create)
        Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(932))
        'JISの場合は下記のようにする    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(50220))
        'EUCの場合は下記のようにする    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(51932))
        Try
            ヘッダ書込(sw, List)

        Finally
            sw.Close()
        End Try

    End Sub

    Public Sub 出力(ByVal reader As DbDataReader, ByVal filename As String)
        If Not reader.Read Then
            Exit Sub
        End If

        Call Application.DoEvents()

        Dim fs As New System.IO.FileStream(filename, System.IO.FileMode.OpenOrCreate)
        Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(932))
        'JISの場合は下記のようにする    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(50220))
        'EUCの場合は下記のようにする    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(51932))
        Try
            ヘッダ書込(sw, reader)

            ''明細書き込み
            Do
                Dim strCSV As String = ""
                For i As Integer = 0 To reader.FieldCount - 1
                    If IsDBNull(reader(i)) Then
                        strCSV = strCSV & ",Null"
                    Else
                        strCSV = strCSV & "," & CStr(reader(i)).Trim
                    End If
                Next
                sw.WriteLine(strCSV.Substring(1))

            Loop While reader.Read
        Finally
            sw.Close()
        End Try

    End Sub
End Class

Imports CrystalDecisions.CrystalReports.Engine
Public Class CReport
    '#####################################################################################
    '型
    '#####################################################################################
    ''データ渡し構造体
    Private Structure mstructureField
        Public strFieldName As String
        Public strFieldValue As String
        Public blnNum As Boolean
    End Structure
    ''ソート構造体
    Private Structure mSortStructure
        Public intSortIndex As Integer
        Public blnSortASC As Boolean
        Public strSortName As String
    End Structure

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    ''プロパティー用変数
    Private mReportPath As String
    Private mReportKey As String
    Private mReportSelection As String = ""
    Private mPrinterName As String = ""

    ''データ渡しQue
    Private mqueField As New Queue

    ''ソート用Que
    Private mSortQue As New Queue

    Private mMSGレポートパス取得エラー As String = "INIファイルからレポート情報を取得できませんでした。"

    '#####################################################################################
    'プロパティー
    '#####################################################################################
#Region "pReportKey"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pReportKey
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：INIファイルのレポートファイルパスのKEY
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property pReportKey() As String
        Get
            pReportKey = Me.mReportKey
        End Get
        Set(ByVal Value As String)
            Me.mReportKey = Value
        End Set
    End Property

#Region "pReportSelection"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pReportSelection
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：レポート抽出条件の設定
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property セレクション設定() As String
        Get
            セレクション設定 = Me.mReportSelection
        End Get
        Set(ByVal Value As String)
            Me.mReportSelection = Value
        End Set
    End Property

#Region "pPrinterName"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：pPrinterName
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：出力先プリンタ名
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Property プリンタ名() As String
        Get
            プリンタ名 = Me.mPrinterName
        End Get
        Set(ByVal Value As String)
            Me.mPrinterName = Value
        End Set
    End Property

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
    Private Sub CReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ctlRptView.RefreshReport()
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################

#Region "印刷処理(ODP)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gBlnPrint
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：印刷処理
    ' 備　考　：データテーブルを使い出力
    '---------------------------------------------------------------------------
#End Region
    Public Overloads Function gBln印刷実行(ByVal dt As DataTable) As Boolean
        Dim blnPre As Boolean
        blnPre = CBool(CUtil.設定関連.設定文字列読込("PrintPreview", "0"))
        Return Me.gBln印刷実行(dt, blnPre)
    End Function

#Region "印刷処理(ODP)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gBlnPrint
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：印刷処理
    ' 備　考　：pReportPath,pReportSelection,gSubSort設定後呼び出す。
    '---------------------------------------------------------------------------
#End Region
    Public Overloads Function gBln印刷実行(ByVal dt As DataTable, ByVal blnPre As Boolean) As Boolean
        Dim objLogOnInfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim objTable As CrystalDecisions.CrystalReports.Engine.Table
        Dim objReportDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        Dim objSort As mSortStructure
        Dim objFieldDef As CrystalDecisions.CrystalReports.Engine.FieldDefinition
        Dim strPath As String

        Dim objField As mstructureField

        Call Application.DoEvents()

        ''レポートファイルパス取得

        ''ppReportKeyからレポートファイル名取得
        If CUtil.設定関連.設定文字列読込(Me.pReportKey, "") = "" Then
            Call MessageBox.Show(Me.mMSGレポートパス取得エラー, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        ''レポートパス設定
        strPath = Application.StartupPath & CUtil.設定関連.設定文字列読込(Me.pReportKey, "")

        ''フォームタイトル設定
        Me.Text = Me.pReportKey

        ''レポートロード
        objReportDoc.Load(strPath, CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)

        ''ビューワーにレポートをセット
        Me.CtlRptView.ReportSource = objReportDoc

        '’2006/10/19morichika
        ''データセット
        objReportDoc.SetDataSource(dt)

        ''セレクション設定
        If Me.セレクション設定 <> "" Then
            objReportDoc.RecordSelectionFormula = Me.セレクション設定
        End If

        '2006/10/25 morichika
        ''フィールドを送る
        Do Until Me.mqueField.Count = 0
            ''キューからとりだす
            objField = CType(Me.mqueField.Dequeue, mstructureField)
            If objField.blnNum Then
                objReportDoc.DataDefinition.FormulaFields(objField.strFieldName).Text = objField.strFieldValue
            Else
                objReportDoc.DataDefinition.FormulaFields(objField.strFieldName).Text = "'" & objField.strFieldValue & "'"
            End If
        Loop

        ''表示順設定
        Do Until Me.mSortQue.Count = 0
            ''キューからとりだす
            objSort = CType(Me.mSortQue.Dequeue, CReport.mSortStructure)
            ''ソートインデックにソートフィールドを設定
            If objSort.strSortName <> "" Then
                objFieldDef = objReportDoc.DataDefinition.FormulaFields(objSort.strSortName)
                objReportDoc.DataDefinition.SortFields(objSort.intSortIndex).Field = objFieldDef
            End If
            ''昇順降順
            If objSort.blnSortASC Then
                objReportDoc.DataDefinition.SortFields(objSort.intSortIndex).SortDirection = CrystalDecisions.[Shared].SortDirection.AscendingOrder
            Else
                objReportDoc.DataDefinition.SortFields(objSort.intSortIndex).SortDirection = CrystalDecisions.[Shared].SortDirection.DescendingOrder
            End If
        Loop

        '参照テーブル接続設定
        For Each objTable In objReportDoc.Database.Tables
            ' TableLogOnInfo オブジェクトを取得します。
            objLogOnInfo = objTable.LogOnInfo
            ' サーバーまたは ODBC データ ソース名、データベース名、
            ' ユーザー ID、およびパスワードを設定します。
            'logOnInfo.ConnectionInfo.ServerName = "izmic"
            'logOnInfo.ConnectionInfo.DatabaseName = "izmic"
            'logOnInfo.ConnectionInfo.UserID = "izmic"
            objLogOnInfo.ConnectionInfo.Password = CUtil.設定関連.設定文字列読込("Printパスワード", "ftmr")
            ' テーブルに接続情報を適用します。
            objTable.ApplyLogOnInfo(objLogOnInfo)
        Next

        ''プリンタの設定
        プリンタの設定(objReportDoc, Me.プリンタ名)

        ''プレビュー表示
        'If cBas.gStrParameterStr("PrintPreview", "1") = "1" Then
        If blnPre = True Then
            Me.Show()
            objReportDoc.Close()

        Else
            Do
                Try
                    ''印刷開始
                    objReportDoc.PrintToPrinter(1, False, 0, 0)
                    objReportDoc.Close()
                    Return True
                Catch engEx As EngineException
                    If MessageBox.Show(engEx.Message, "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
                        Return False
                    End If
                End Try
            Loop
        End If

        Return True
    End Function

    Public Sub プリンタの設定(ByVal レポートドキュメント As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal プリンタ名 As String)
        If プリンタ名 <> "" Then
            ''セットするプリンタがあるか
            Dim blnRet As Boolean
            Dim strBuff As String

            For Each strBuff In Printing.PrinterSettings.InstalledPrinters
                If strBuff = プリンタ名 Then
                    レポートドキュメント.PrintOptions.PrinterName = Me.プリンタ名
                    blnRet = True
                    Exit For
                End If
            Next

            ''設定プリンタがないとき
            If blnRet = False Then
                Call MessageBox.Show(Me.プリンタ名 & " が見つかりませんでした。通常使うプリンタで印刷します。", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Public Enum EnmStyle
        None            '処理無し
        DateStyle       '単体日付未入力時は空白にする
        LocationStyle   '単体ロケーション未入力時は空白にする
    End Enum

    ''外部関数(Sub)----------------------------------------------------------------------------
#Region "レポートのフィールドに値をセットする。(オーバーロード)"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：gSubField
    ' 引　数　：strFieldName     レポート側のデータを送るフィールド名
    ' 　　　　：strFieldValue    送るデータ(enmStyleの値でデータを編集する)
    ' 　　　　：blnNum           数値フィールド
    ' 戻り値　：
    ' 機能説明：レポートのフィールドに値をセットする。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Overloads Sub gSubField(ByVal strFieldName As String, ByVal strFieldValue As String, Optional ByVal blnNum As Boolean = False, Optional ByVal enmStyle As EnmStyle = EnmStyle.None)
        Dim objField As New mstructureField

        Select Case enmStyle
            Case enmStyle.DateStyle
                If strFieldValue.Replace("/", "").Trim = "" Then
                    strFieldValue = ""
                End If
            Case enmStyle.LocationStyle
                If strFieldValue.Replace("-", "").Trim = "" Then
                    strFieldValue = ""
                End If
            Case Else

        End Select

        ''フィールドデータをキューに追加
        With objField
            .strFieldName = strFieldName
            .strFieldValue = strFieldValue
            .blnNum = blnNum
        End With
        Me.mqueField.Enqueue(objField)
    End Sub

    Public Sub 印刷実行(ByVal レポートドキュメント As CrystalDecisions.CrystalReports.Engine.ReportDocument, Optional ByVal blnMSG As Boolean = True)
        If CUtil.設定関連.設定Boolean値読込("印刷.プレビュー表示") Then
            ctlRptView.ReportSource = レポートドキュメント
            Dim result As DialogResult = Me.ShowDialog()
        Else
            レポートドキュメント.PrintToPrinter(1, False, 0, 0)
            If blnMSG = True Then
                CMsg.gMsg_情報("出力しました。")

            End If
        End If
    End Sub

#Region "リスト発行"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：iRSubリスト発行
    ' 引　数　：
    ' 戻り値　：
    ' 機能説明：リスト発行
    ' 備　考　：iSubF表示で表示されるデータの印刷時につかえる。
    '           iRSubリスト発行詳細設定をオーバーライドして、レポートに文字をおくれます。
    '---------------------------------------------------------------------------
#End Region
    Protected Overloads Function iBlnリスト発行(ByVal レポートキー As String, ByVal sql As String, Optional ByVal blnPre As Boolean = False) As Boolean
        Me.pReportKey = レポートキー
        ''データテーブル取得
        Dim dt As New DataTable(pReportKey)
        If CType(CUsrctl.gDp, CSdp).gBlnデータテーブルの取得(sql, dt) Then
            If dt.Rows.Count = 0 Then
                Call CMsg.gMsg_注意(M定数.MSG_該当データなし)
            Else
                ''プリンタの設定
                プリンタ名 = CUtil.設定関連.設定文字列読込("プリンタ", "")

                ''リスト発行時の詳細の設定
                Call iRSubリスト発行詳細設定(Me)

                ''リスト発行(ODBC)
                'If Not claReport.gBlnPrint() Then
                '    Return False
                'End If

                If blnPre = False Then
                    ''リスト発行(ODP)
                    If Not gBln印刷実行(dt) Then
                        Return False
                    End If
                Else
                    If Not gBln印刷実行(dt, True) Then
                        Return False
                    End If
                End If

                'claReport.Dispose()
                Close()
            End If
        End If
        Return True
    End Function

#Region "iRSubリスト発行詳細設定"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：iRSubリスト発行詳細設定
    ' 引　数　：objReport
    ' 戻り値　：
    ' 機能説明：リスト発行時の詳細設定がある場合はオーバーライドする
    ' 備　考　：オーバーライド可
    '---------------------------------------------------------------------------
#End Region
    Protected Overridable Sub iRSubリスト発行詳細設定(ByRef objReport As CReport)
    End Sub

End Class
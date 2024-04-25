
Imports System.Data.Common

Public Class Dlg01999_棚メンテナンス修正

    Dim int製品区分 As Integer = 99
    Dim int品種CD As Integer
    '---------------------------------
    '2014/9 Morichika
    Dim int出庫中断_醗酵 As Integer = 0
    Dim int出庫中断_冷却 As Integer = 0
    '---------------------------------
    '2024/4 田岡
    Dim strユニットSEQ As String
    Private Sub Dlg01999_棚メンテナンス修正_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初期表示
        Select Case m画面モード
            Case 0  '醗酵
                lbl醗酵冷却開始時刻タイトル.Text = "醗酵開始時刻"
            Case 1  '冷却
                lbl醗酵冷却開始時刻タイトル.Text = "冷却開始時刻"
        End Select

       画面初期化
        Me.btnF1.Enabled = False
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If CMsg.gMsg_YesNo("棚在庫情報の修正を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '入力情報をDN製造製品に更新
        Updateトラッキングデータ()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Me.txt列.Text = ""
        Me.txt連.Text = ""
        Me.txt段.Text = ""
        画面初期化()
        Me.txt列.Focus()

    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub 対象ロケ情報_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt列.TextChanged, txt連.TextChanged, txt段.TextChanged
        '未入力状態であれば行わない
        If Trim(Me.txt列.Text) = "" Or Trim(Me.txt連.Text) = "" Or Trim(Me.txt段.Text) = "" Then
            Exit Sub
        End If

        ロケ情報表示()
    End Sub

    Public Sub Updateトラッキングデータ()
        '実際には現在のデータを削除した後、再度新しいデータを作成する
        '削除
        Try
            With New CSql
                .gSubClearSQL()
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
                .pテーブル名 = "DNトラッキング"
                .gSubWhere("列", txt列.Text, , , , , , , False)
                .gSubWhere("連", txt連.Text, , , , , , , False)
                .gSubWhere("段", txt段.Text, , , , , , , False)
                Select Case m画面モード
                    Case 0  '醗酵
                        .gSubWhere("ステータス < 10 ")

                    Case 1  '冷却
                        .gSubWhere("ステータス >= 20")
                        .gSubWhere("ステータス <= 31")

                End Select
                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try


        '作成
        Try
            With New CSql
                Dim i As Integer
                Dim int受入数 As Integer = 0
                Dim intユニット列数 As Integer = Val(Me.lblユニット列数.Text)
                For i = 1 To intユニット列数
                    If int製品区分 = 0 Then 'ハード
                        If i <> intユニット列数 Then
                            int受入数 = 13
                        Else
                            int受入数 = Val(Me.txtクレート数.Text) - 13 * (intユニット列数 - 1)
                        End If
                    Else    'プレーン
                        If i <> intユニット列数 Then
                            int受入数 = 7
                        Else
                            int受入数 = Val(Me.txtクレート数.Text) - 7 * (intユニット列数 - 1)
                        End If
                    End If

                    .gSubClearSQL()
                    .pSQL取得タイプ = CSql.SQL_TYPE.SQL_INSERT
                    .pテーブル名 = "DNトラッキング"
                    If int製品区分 = 0 Then 'ハード
                        .gSubColumnValue("製造ライン", 0, True)
                    Else    'プレーン
                        .gSubColumnValue("製造ライン", 1, True)
                    End If
                    .gSubColumnValue("ロットNo", Me.txtロットNo.Text, True)
                    .gSubColumnValue("サンプルNo", Me.txtサンプルNo.Text, False)
                    .gSubColumnValue("品種CD", Me.txt品種.Text, False)
                    int品種CD = Convert.ToInt32(Me.txt品種.Text)
                    .gSubColumnValue("受入数", int受入数, False)
                    .gSubColumnValue("賞味期限", Me.txt賞味期限年.Text & "/" & Me.txt醗酵開始月.Text & "/" & Me.txt醗酵開始日.Text & " 00:00:00", True)

                    Select Case m画面モード
                        Case 0  '醗酵
                            .gSubColumnValue("醗酵開始時刻", Me.txt醗酵開始年.Text & "/" & Me.txt醗酵開始月.Text & "/" & Me.txt醗酵開始日.Text & " " & Me.txt醗酵開始時.Text & ":" & Me.txt醗酵開始分.Text & ":00", True)
                            .gSubColumnValue("ステータス", 6, False)

                        Case 1
                            .gSubColumnValue("冷却開始時刻", Me.txt醗酵開始年.Text & "/" & Me.txt醗酵開始月.Text & "/" & Me.txt醗酵開始日.Text & " " & Me.txt醗酵開始時.Text & ":" & Me.txt醗酵開始分.Text & ":00", True)
                            .gSubColumnValue("ステータス", 27, False)
                    End Select
                    .gSubColumnValue("ユニットSEQ", strユニットSEQ, False)
                    .gSubColumnValue("列", Me.txt列.Text, False)
                    .gSubColumnValue("連", Me.txt連.Text, False)
                    .gSubColumnValue("段", Me.txt段.Text, False)
                    .gSubColumnValue("更新プログラム", Name, True)

                    '---------------------------------
                    '2014/9 Morichika
                    .gSubColumnValue("出庫中断", int出庫中断_醗酵, False)
                    .gSubColumnValue("出庫中断_冷", int出庫中断_冷却, False)
                    '---------------------------------

                    If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                        Exit Sub
                    End If
                Next

            End With

            'インサート後に最大のユニットSEQでUPDATEする
            'With New CSql
            '    .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
            '    .pテーブル名 = "DNトラッキング"
            '    .gSubColumnValue("ユニットSEQ", int未使用ユニットSEQ(), False)
            '    .gSubWhere("列", Me.txt列.Text, , , , , , , , )
            '    .gSubWhere("連", Me.txt連.Text, , , , , , , , )
            '    .gSubWhere("段", Me.txt段.Text, , , , , , , , )

            '    Select Case m画面モード
            '        Case 0  '醗酵
            '            .gSubWhere("ステータス", 6, , , , , , , , )

            '        Case 1
            '            .gSubWhere("ステータス", 27, , , , , , , , )

            '    End Select
            '    If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
            '        Exit Sub
            '    End If
            'End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub ロケ情報表示()
        Dim reader As DbDataReader = Nothing
        画面初期化()

        Try
            With New CSqlEx
                .gSubSelect("MAX(A.ロットNo COLLATE Japanese_CS_AS_KS_WS) as ロットNo")
                .gSubSelect("MAX(A.サンプルNo) as サンプルNo")
                .gSubSelect("MAX(B.品種名) as 品種名")
                .gSubSelect("SUM(A.受入数) as クレート数")
                .gSubSelect("MAX(A.賞味期限) as 賞味期限")
                Select Case m画面モード
                    Case 0  '醗酵
                        .gSubSelect("MAX(A.醗酵開始時刻) as 開始時刻")

                    Case 1  '冷却
                        .gSubSelect("MAX(A.冷却開始時刻) as 開始時刻")

                End Select
                .gSubSelect("count(A.ロットNo COLLATE Japanese_CS_AS_KS_WS) as ユニット列数")
                .gSubSelect("MAX(B.製品区分) as 製品区分")
                .gSubSelect("MAX(B.品種CD) as 品種CD")
                '---------------------------------
                '2014/9 Morichika
                .gSubSelect("MAX(A.出庫中断) as 出庫中断_醗")
                .gSubSelect("MAX(A.出庫中断_冷) as 出庫中断_冷")
                '---------------------------------
                '2024/9田岡
                .gSubSelect("MAX(A.ユニットSEQ) as ユニットSEQ")
                '---------------------------------
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                '---------------------------------
                Select Case m画面モード
                    Case 0  '醗酵
                        .gSubWhere("ステータス < 10 ")

                    Case 1  '冷却
                        .gSubWhere("ステータス >= 20")
                        .gSubWhere("ステータス <= 31")

                End Select
                '---------------------------------
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubWhere("A.列", Me.txt列.Text, , , , , , , False)
                .gSubWhere("A.連", Me.txt連.Text, , , , , , , False)
                .gSubWhere("A.段", Me.txt段.Text, , , , , , , False)
                .gSubGroupBy("A.ユニットSEQ")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        int製品区分 = reader.GetValue(7)
                        int品種CD = reader.GetValue(8)
                        Me.txtロットNo.Text = reader.GetValue(0)
                        Me.txtサンプルNo.Text = reader.GetValue(1)
                        Me.lbl品種.Text = reader.GetValue(2)
                        Me.txt品種.Text = reader.GetValue(8)
                        Me.txtクレート数.Text = reader.GetValue(3)
                        Me.txt賞味期限年.Text = (reader.GetValue(4)).ToString().Substring(0, 4)
                        Me.txt賞味期限月.Text = (reader.GetValue(4)).ToString().Substring(5, 2)
                        Me.txt賞味期限日.Text = (reader.GetValue(4)).ToString().Substring(8, 2)
                        'Me.lbl醗酵開始時刻.Text = reader.GetValue(5)
                        Dim str醗酵開始時刻 As String = reader.GetValue(5).ToString
                        Me.txt醗酵開始年.Text = Mid(str醗酵開始時刻, 1, 4)
                        Me.txt醗酵開始月.Text = Mid(str醗酵開始時刻, 6, 2)
                        Me.txt醗酵開始日.Text = Mid(str醗酵開始時刻, 9, 2)
                        str醗酵開始時刻 = Trim(Mid(str醗酵開始時刻, 11))
                        If str醗酵開始時刻.Length = 7 Then
                            Me.txt醗酵開始時.Text = Mid(str醗酵開始時刻, 1, 1).PadLeft(2, "0"c)
                            Me.txt醗酵開始分.Text = Mid(str醗酵開始時刻, 3, 2)
                        Else
                            Me.txt醗酵開始時.Text = Mid(str醗酵開始時刻, 1, 2)
                            Me.txt醗酵開始分.Text = Mid(str醗酵開始時刻, 4, 2)
                        End If
                        Me.lblユニット列数.Text = reader.GetValue(6)
                        '---------------------------------
                        '2014/9 Morichika
                        int出庫中断_醗酵 = reader.GetValue(9)
                        int出庫中断_冷却 = reader.GetValue(10)
                        '---------------------------------
                        '---------------------------------
                        '2024/9田岡
                        strユニットSEQ = reader.GetValue(11)
                        '---------------------------------
                        Me.txtクレート数.Enabled = True
                        Me.txt醗酵開始年.Enabled = True
                        Me.txt醗酵開始月.Enabled = True
                        Me.txt醗酵開始日.Enabled = True
                        Me.txt醗酵開始時.Enabled = True
                        Me.txt醗酵開始分.Enabled = True
                        Me.btnF1.Enabled = True
                        Me.txt賞味期限年.Enabled = True
                        Me.txt賞味期限月.Enabled = True
                        Me.txt賞味期限日.Enabled = True
                        Me.txtサンプルNo.Enabled = True
                        Me.txtロットNo.Enabled = True
                        Me.txt品種.Enabled = True
                        Exit Sub
                    End While
                End If
            End With

            int製品区分 = 99
            int品種CD = Nothing
            strユニットSEQ = Nothing
            Me.txtクレート数.Enabled = False
            Me.txt醗酵開始年.Enabled = False
            Me.txt醗酵開始月.Enabled = False
            Me.txt醗酵開始日.Enabled = False
            Me.txt醗酵開始時.Enabled = False
            Me.txt醗酵開始分.Enabled = False
            Me.btnF1.Enabled = False
            Me.txt賞味期限年.Enabled = False
            Me.txt賞味期限月.Enabled = False
            Me.txt賞味期限日.Enabled = False
            Me.txtサンプルNo.Enabled = False
            Me.txtロットNo.Enabled = False
            Me.txt品種.Enabled = False
            CMsg.gMsg_エラー("在庫情報がありません。")
            Me.txt列.Focus()
            Me.txt列.Text = ""
            Me.txt連.Text = ""
            Me.txt段.Text = ""

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub 画面初期化()
        Me.txtクレート数.Enabled = False
        Me.txt醗酵開始年.Enabled = False
        Me.txt醗酵開始月.Enabled = False
        Me.txt醗酵開始日.Enabled = False
        Me.txt醗酵開始時.Enabled = False
        Me.txt醗酵開始分.Enabled = False
        Me.txt賞味期限年.Enabled = False
        Me.txt賞味期限月.Enabled = False
        Me.txt賞味期限日.Enabled = False
        Me.txtサンプルNo.Enabled = False
        Me.txtロットNo.Enabled = False
        Me.txt品種.Enabled = False
        Me.btnF1.Enabled = False
        Me.txtクレート数.Text = ""
        Me.txtサンプルNo.Text = ""
        Me.lblユニット列数.Text = ""
        Me.txtロットNo.Text = ""
        Me.txt賞味期限年.Text = ""
        Me.txt賞味期限月.Text = ""
        Me.txt賞味期限日.Text = ""
        Me.txt醗酵開始年.Text = ""
        Me.txt醗酵開始月.Text = ""
        Me.txt醗酵開始日.Text = ""
        Me.txt醗酵開始時.Text = ""
        Me.txt醗酵開始分.Text = ""
        Me.lbl品種.Text = ""
        Me.txt品種.Text = ""
    End Sub

    Private Sub txtクレート数_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtクレート数.TextChanged
        If Trim(Me.txtクレート数.Text) = "" Then
            Me.txtクレート数.Text = ""
            Me.lblユニット列数.Text = ""
            Exit Sub
        End If

        '初期化
        Me.lblユニット列数.Text = ""
        Dim 入力値 As Integer = Me.txtクレート数.Text
        If int製品区分 = 0 Then 'ハード

            If 入力値 > 39 Then
                CMsg.gMsg_エラー("ハードのユニットは最大で39クレートです。")
                Me.txtクレート数.Text = ""
                Exit Sub
            End If

            Me.lblユニット列数.Text = Math.Ceiling(Val(txtクレート数.Text) / 13)

        Else    'プレーン
            If 入力値 > 21 Then
                CMsg.gMsg_エラー("プレーンユニットは最大で21クレートです。")
                Me.txtクレート数.Text = ""
                Exit Sub
            End If

            Me.lblユニット列数.Text = Math.Ceiling(Val(txtクレート数.Text) / 7)

        End If
    End Sub

    Private Function int未使用ユニットSEQ() As String
        Dim reader As DbDataReader = Nothing
        Dim 未使用ユニットSEQ As Integer = 1
        Try
            With New CSqlEx
                .gSubSelect("isnull(MAX(A.ユニットSEQ),0)")
                .gSubFrom("DNトラッキング A")
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        未使用ユニットSEQ = reader.GetValue(0) + 1
                    End While
                End If

            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Return 未使用ユニットSEQ
    End Function

    Private Sub UsrTxt2_TextChanged(sender As Object, e As EventArgs) Handles txt賞味期限日.TextChanged

    End Sub

    Private Sub UsrTxt3_TextChanged(sender As Object, e As EventArgs) Handles txt賞味期限月.TextChanged

    End Sub

    Private Sub UsrLbl7_Click(sender As Object, e As EventArgs) Handles UsrLbl7.Click

    End Sub

    Private Sub UsrTxt4_TextChanged(sender As Object, e As EventArgs) Handles txt賞味期限年.TextChanged

    End Sub

    Private Sub UsrLbl15_Click(sender As Object, e As EventArgs) Handles UsrLbl15.Click

    End Sub

    Private Sub txt品種_TextChanged(sender As Object, e As EventArgs) Handles txt品種.TextChanged
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("MAX(B.品種名) as 品種名")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                .gSubWhere(Me.txt品種.Text & " = B.品種CD")
                .gSubWhere("A.列", Me.txt列.Text, , , , , , , False)
                .gSubWhere("A.連", Me.txt連.Text, , , , , , , False)
                .gSubWhere("A.段", Me.txt段.Text, , , , , , , False)
                .gSubGroupBy("A.ユニットSEQ")
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Me.lbl品種.Text = reader.GetValue(0)
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub
End Class

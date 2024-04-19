
Imports System.Data.Common
Public Class Dlg01999_棚メンテナンス登録
    Private Sub Dlg01999_棚メンテナンス登録_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case m画面モード
            Case 0  '醗酵
                lbl醗酵冷却開始時刻タイトル.Text = "醗酵開始時刻"
            Case 1  '冷却
                lbl醗酵冷却開始時刻タイトル.Text = "冷却開始時刻"
        End Select

        '初期表示
        Me.txt醗酵冷却開始年.Text = Now.Year.ToString
        Me.txt醗酵冷却開始月.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt醗酵冷却開始日.Text = Now.Day.ToString.PadLeft(2, "0"c)
        Me.txt醗酵冷却開始時.Text = Now.Hour.ToString.PadLeft(2, "0"c)
        Me.txt醗酵冷却開始分.Text = Now.Minute.ToString.PadLeft(2, "0"c)

        Me.txt賞味期限年.Text = Now.Year.ToString
        Me.txt賞味期限月.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt賞味期限日.Text = Now.Day.ToString.PadLeft(2, "0"c)

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If Trim(Me.txt列.Text) = "" Or Trim(Me.txt連.Text) = "" Or Trim(Me.txt段.Text) = "" Then
            MessageBox.Show("段情報が正しくありません。")
            Me.txt列.Focus()
            Exit Sub
        End If

        If Not bln棚状況() Then
            Exit Sub
        End If

        If Not bln棚使用状況() Then
            Exit Sub
        End If

        If Me.lbl製品区分.Text = "99" Or Me.txt品種.Text = "" Then
            MessageBox.Show("品種コードが正しくありません。")
            Me.txt品種.Focus()
            Exit Sub
        End If

        Dim str醗酵開始日時 As String = Me.txt醗酵冷却開始年.Text.PadLeft(4, "0"c) & "/" & Me.txt醗酵冷却開始月.Text.PadLeft(2, "0"c) & "/" & Me.txt醗酵冷却開始日.Text.PadLeft(2, "0"c) & " " & Me.txt醗酵冷却開始時.Text.PadLeft(2, "0"c) & ":" & Me.txt醗酵冷却開始分.Text.PadLeft(2, "0"c) & ":00"
        If Not IsDate(str醗酵開始日時) Then
            Select Case m画面モード
                Case 0  '醗酵
                    MessageBox.Show("醗酵開始日時が正しくありません。")
                Case 1  '冷却
                    MessageBox.Show("冷却開始日時が正しくありません。")
            End Select

            Me.txt醗酵冷却開始年.Focus()
            Exit Sub
        End If

        Dim str賞味期限日時 As String = Me.txt賞味期限年.Text.PadLeft(4, "0"c) & "/" & Me.txt賞味期限月.Text.PadLeft(2, "0"c) & "/" & Me.txt賞味期限日.Text.PadLeft(2, "0"c) & " 00:00:00"
        If Not IsDate(str賞味期限日時) Then
            MessageBox.Show("賞味期限が正しくありません。")
            Me.txt賞味期限年.Focus()
            Exit Sub
        End If

        If Me.txtロットNo.Text = "" Then
            MessageBox.Show("ロットNoが未入力です。")
            Me.txtロットNo.Focus()
            Exit Sub

        ElseIf Me.txtロットNo.Text = "000000" Then
            If CMsg.gMsg_YesNo("ロットNo:000000でよろしいですか？") = Windows.Forms.DialogResult.No Then
                Me.txtロットNo.Text = ""
                Me.txtロットNo.Focus()
                Exit Sub

            End If
        Else
            'ロットNoが既に利用されている場合、品種が同じかどうかをチェックする
            If blnロット重複有り_トラッキング() Then
                '品種が違う場合はエラー
                If Not blnロットおよび品種重複有り_トラッキング() Then
                    MessageBox.Show("入力されたロットNoは異なる品種で利用中です。")
                    Me.txtロットNo.Focus()
                    Exit Sub

                End If

            End If
            If blnロット重複有り_製造製品() Then
                '品種が違う場合はエラー
                MessageBox.Show("入力されたロットNoは現在、異なる品種で入庫設定されています。")
                Me.txtロットNo.Focus()
                Exit Sub

            End If
        End If

        If Me.txtサンプルNo.Text = "" Or Val(Me.txtサンプルNo.Text) = 0 Then
            MessageBox.Show("サンプルNoが未入力です。")
            Me.txtサンプルNo.Focus()
            Exit Sub

        End If

        If Me.txtクレート数.Text = "" Or Val(Me.txtクレート数.Text) = 0 Then
            MessageBox.Show("クレート数が未入力です。")
            Me.txtクレート数.Focus()
            Exit Sub

        End If

        If CMsg.gMsg_YesNo("棚在庫情報の登録を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '入力情報をDN製造製品に更新
        Insertトラッキングデータ()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Sub Insertトラッキングデータ()
        Try
            With New CSql
                Dim i As Integer
                Dim int受入数 As Integer = 0
                Dim intユニット列数 As Integer = Val(Me.lblユニット列数.Text)
                For i = 1 To intユニット列数
                    If Me.lbl製品区分.Text = 0 Then 'ハード
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
                    If Me.lbl製品区分.Text = 0 Then 'ハード
                        .gSubColumnValue("製造ライン", 0, True)
                    Else    'プレーン
                        .gSubColumnValue("製造ライン", 1, True)
                    End If
                    .gSubColumnValue("ロットNo", Me.txtロットNo.Text, True)
                    .gSubColumnValue("サンプルNo", Me.txtサンプルNo.Text, False)
                    .gSubColumnValue("品種CD", Me.txt品種.Text, False)
                    .gSubColumnValue("受入数", int受入数, False)
                    .gSubColumnValue("賞味期限", Me.txt賞味期限年.Text & "/" & Me.txt賞味期限月.Text & "/" & Me.txt賞味期限日.Text & " 00:00:00", True)
                    Select Case m画面モード
                        Case 0  '醗酵
                            .gSubColumnValue("醗酵開始時刻", Me.txt醗酵冷却開始年.Text & "/" & Me.txt醗酵冷却開始月.Text & "/" & Me.txt醗酵冷却開始日.Text & " " & Me.txt醗酵冷却開始時.Text & ":" & Me.txt醗酵冷却開始分.Text & ":00", True)
                            .gSubColumnValue("ステータス", 6, False)
                        Case 1  '冷却
                            .gSubColumnValue("冷却開始時刻", Me.txt醗酵冷却開始年.Text & "/" & Me.txt醗酵冷却開始月.Text & "/" & Me.txt醗酵冷却開始日.Text & " " & Me.txt醗酵冷却開始時.Text & ":" & Me.txt醗酵冷却開始分.Text & ":00", True)
                            .gSubColumnValue("ステータス", 27, False)
                    End Select

                    .gSubColumnValue("列", Me.txt列.Text, False)
                    .gSubColumnValue("連", Me.txt連.Text, False)
                    .gSubColumnValue("段", Me.txt段.Text, False)
                    .gSubColumnValue("更新プログラム", Name, True)

                    If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                        Exit Sub
                    End If
                Next

            End With

            'インサート後に最大のユニットSEQでUPDATEする
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("ユニットSEQ", int未使用ユニットSEQ(), False)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubWhere("列", Me.txt列.Text, , , , , , , , )
                .gSubWhere("連", Me.txt連.Text, , , , , , , , )
                .gSubWhere("段", Me.txt段.Text, , , , , , , , )
                Select Case m画面モード
                    Case 0  '醗酵
                        .gSubWhere("ステータス", 6, , , , , , , , )
                    Case 1  '冷却
                        .gSubWhere("ステータス", 27, , , , , , , , )
                End Select

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With

        Catch ex As Exception
        Finally
        End Try
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

    Private Sub txt品種_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt品種.TextChanged
        Try
            If Trim(Me.txt品種.Text) = "" Then
                Me.lbl品種.Text = ""
                Me.lbl製品区分.Text = "99"
                Exit Sub
            End If

            '入力されている品種CDを元に品種名を表示する
            Me.lbl品種.Text = CMdiMain.str品種名取得(9, Me.txt品種.Text)
            Me.lbl製品区分.Text = int製品区分取得()

        Catch ex As Exception
            Me.lbl品種.Text = ""
            Me.lbl製品区分.Text = "99"
        End Try

    End Sub

    Private Sub txtクレート数_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtクレート数.TextChanged
        If Trim(Me.txtクレート数.Text) = "" Then
            Me.txtクレート数.Text = ""
            Me.lblユニット列数.Text = ""
            Exit Sub
        End If

        If Me.lbl製品区分.Text = "99" Or Me.txt品種.Text = "" Then
            MessageBox.Show("予め品種を決定してください。")
            Me.txt品種.Focus()
            Exit Sub
        End If

        '初期化
        Me.lblユニット列数.Text = ""
        Dim 入力値 As Integer = Me.txtクレート数.Text
        If Me.lbl製品区分.Text = 0 Then 'ハード

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

    Private Function bln棚状況() As Integer
        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("棚区分")
                .gSubFrom("DM棚")
                .gSubWhere("列", Me.txt列.Text, , , , , , , False)
                .gSubWhere("連", Me.txt連.Text, , , , , , , False)
                .gSubWhere("段", Me.txt段.Text, , , , , , , False)
                Select Case m画面モード
                    Case 0  '醗酵
                        .gSubWhere("倉庫区分", 0, , , , , , , False)
                    Case 1  '冷却
                        .gSubWhere("倉庫区分", 1, , , , , , , False)
                End Select
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Select Case reader.GetValue(0)
                            Case 0
                                Return True
                            Case 1
                                CMsg.gMsg_エラー("ステーション棚には入庫できません。")
                                Me.txt列.Focus()
                                Return False

                            Case 2
                                '禁止棚への登録は可能
                                'CMsg.gMsg_エラー("禁止棚には入庫できません。")
                                'Me.txt列.Focus()
                                Return True

                            Case 3
                                CMsg.gMsg_エラー("棚情報が存在しません。")
                                Me.txt列.Focus()
                                Return False

                            Case Else
                                CMsg.gMsg_エラー("棚情報が存在しません。")
                                Me.txt列.Focus()
                                Return False

                        End Select
                    End While
                End If
            End With

            CMsg.gMsg_エラー("棚情報が存在しません。")
            Return False

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Private Function bln棚使用状況() As Integer
        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("count(ロットNo COLLATE Japanese_CS_AS_KS_WS)")
                .gSubFrom("DNトラッキング")
                .gSubWhere("列", Me.txt列.Text, , , , , , , False)
                .gSubWhere("連", Me.txt連.Text, , , , , , , False)
                .gSubWhere("段", Me.txt段.Text, , , , , , , False)
                Select Case m画面モード
                    Case 0  '醗酵
                        .gSubWhere("ステータス < 10")
                    Case 1  '冷却
                        .gSubWhere("ステータス >= 27")
                        .gSubWhere("ステータス <= 30")
                End Select
                .gSubGroupBy("列,連,段")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If Val(reader.GetValue(0).ToString) > 0 Then
                            CMsg.gMsg_エラー("既に利用中の棚です。")
                            Me.txt列.Focus()
                            Return False
                        Else
                            Return True
                        End If
                    End While
                End If
            End With

            Return True

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Private Function int製品区分取得() As Integer
        Dim reader As DbDataReader = Nothing
        Dim 製品区分 As Integer = 99

        Try

            With New CSqlEx
                .gSubSelect("製品区分")
                .gSubFrom("DM品種")
                .gSubWhere("品種CD", Me.txt品種.Text, , , , , , , False)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        製品区分 = reader.GetValue(0)
                    End While
                End If
            End With

            Return 製品区分

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Private Function int未使用ユニットSEQ() As String
        Dim reader As DbDataReader = Nothing
        'Dim 未使用ユニットSEQ As Integer = 1
        'Try
        '    With New CSqlEx
        '        .gSubSelect("isnull(MAX(A.ユニットSEQ),0)")
        '        .gSubFrom("DNトラッキング A")
        '        If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
        '            While reader.Read
        '                未使用ユニットSEQ = reader.GetValue(0) + 1
        '            End While
        '        End If

        '    End With
        'Catch ex As Exception
        'Finally
        '    CUsrctl.gDp.gSubReaderClose(reader)
        'End Try

        'Return 未使用ユニットSEQ

        '20130807
        'ユニットSEQは1 + 日付(Day) + 連番≪99DD999≫のフォーマットとする
        Dim strSEQヘッダー As String = "99" & Now.Day.ToString.PadLeft(2, "0"c)
        Dim 検索範囲FROMユニットSEQ As Integer = Int(strSEQヘッダー) * 1000 + 1
        Dim 検索範囲TOユニットSEQ As Integer = Int(strSEQヘッダー) * 1000 + 999
        Dim 未使用最少ユニットSEQ As Integer = Int(strSEQヘッダー) * 1000 + 1

        Try
            With New CSqlEx
                .gSubSelect("MAX(A.ユニットSEQ)")
                .gSubFrom("DNトラッキング A")
                .gSubWhereあいまい検索("ユニットSEQ", strSEQヘッダー)
                .gSubWhere("ユニットSEQ BETWEEN " & 検索範囲FROMユニットSEQ & " AND " & 検索範囲TOユニットSEQ)
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If reader.GetValue(0).ToString <> "" Then
                            '安全を見て＋１０とする
                            未使用最少ユニットSEQ = reader.GetValue(0) + 10
                        End If
                    End While
                End If

            End With
        Catch ex As Exception

        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
        Return 未使用最少ユニットSEQ
    End Function

    Private Sub txt段_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt段.Leave
        If Trim(Me.txt列.Text) = "" Or Trim(Me.txt連.Text) = "" Or Trim(Me.txt段.Text) = "" Then
            Exit Sub
        End If

        If Not bln棚状況() Then
            Exit Sub
        End If

        If Not bln棚使用状況() Then
            Exit Sub
        End If

    End Sub

    Private Sub 画面初期化()
        Me.txtクレート数.Text = ""
        Me.txtサンプルNo.Text = ""
        Me.lblユニット列数.Text = ""
        Me.txtロットNo.Text = ""
        '初期表示
        Me.txt醗酵冷却開始年.Text = Now.Year.ToString
        Me.txt醗酵冷却開始月.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt醗酵冷却開始日.Text = Now.Day.ToString.PadLeft(2, "0"c)
        Me.txt醗酵冷却開始時.Text = Now.Hour.ToString.PadLeft(2, "0"c)
        Me.txt醗酵冷却開始分.Text = Now.Minute.ToString.PadLeft(2, "0"c)

        Me.txt賞味期限年.Text = Now.Year.ToString
        Me.txt賞味期限月.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt賞味期限日.Text = Now.Day.ToString.PadLeft(2, "0"c)
        Me.lbl品種.Text = ""
    End Sub

    Private Function blnロット重複有り_トラッキング() As Boolean
        With New CSqlEx
            .gSubSelect("COUNT(*)")
            .gSubFrom("DNトラッキング")
            .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Private Function blnロットおよび品種重複有り_トラッキング() As Boolean
        With New CSqlEx
            .gSubSelect("COUNT(*)")
            .gSubFrom("DNトラッキング")
            .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)
            .gSubWhere("品種CD", Me.txt品種.Text, , , , , , , False)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Private Function blnロット重複有り_製造製品() As Boolean
        With New CSqlEx
            .gSubSelect("COUNT(*)")
            .gSubFrom("DN製造製品")
            .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Private Function blnロットおよび品種重複有り_製造製品() As Boolean
        With New CSqlEx
            .gSubSelect("COUNT(*)")
            .gSubFrom("DN製造製品")
            .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)
            .gSubWhere("品種CD", Me.txt品種.Text, , , , , , , False)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

End Class

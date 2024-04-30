
Imports System.Data.Common
Public Class Dlg01999_冷却出庫設定
    Private Sub Dlg01999_冷却出庫設定_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case m画面モード
            Case 0  '開始設定
                Me.Text = "出庫設定"
                Me.btnF1.Text = "F1" & vbCrLf & "開始"

            Case 1  '中断設定
                Me.Text = "中断設定"
                Me.btnF1.Text = "F1" & vbCrLf & "中断"

        End Select
        If txtロットNo.Text <> String.Empty Then
            トラッキングデータ表示()
        End If
    End Sub
    Dim int中断区分 As Integer = 0
    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If Trim(Me.txtロットNo.Text) = "" Then
            CMsg.gMsg_情報("ロットNoが入力されていません。")
            Me.txtロットNo.Focus()
            Exit Sub
        End If

        If Not bln登録前チェック() Then
            Me.txtロットNo.Focus()
            Exit Sub
        End If

        Select Case m画面モード
            Case 0  '開始設定
                If CMsg.gMsg_YesNo("出庫設定を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                '入力情報のチェック
                Updateトラッキング_出庫指示()

            Case 1  '中断設定
                If int中断区分 = 0 Then
                    If CMsg.gMsg_YesNo("中断設定を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If

                    Updateトラッキング_出庫中断指示()
                Else
                    'すでに確認済なのでMSGは要らない
                    Updateトラッキング_出庫中断解除指示()

                End If

        End Select
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Function bln登録前チェック() As Boolean
        '0:処理なし
        '1:出庫開始
        '2:出庫再開/中断
        Dim reader As DbDataReader = Nothing
        int中断区分 = 0
        Try
            With New CSqlEx
                .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("A.サンプルNo")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("MAX(B.所定冷却時間)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,冷却開始時刻,GETDATE()))")
                .gSubSelect("MAX(A.ステータス)")
                .gSubSelect("MAX(A.出庫中断_冷)")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                '.gSubWhere("A.ステータス >= 27 ")
                '.gSubWhere("A.ステータス <= 30 ")
                .gSubWhere("A.ロットNo COLLATE Japanese_CS_AS_KS_WS", txtロットNo.Text, , , , , , , True)
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubGroupBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubGroupBy("A.サンプルNo")
                .gSubOrderBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubOrderBy("A.サンプルNo")

                Dim CNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Dim 所定冷却時間 As Integer = reader.GetValue(3)
                        Dim 冷却経過時間 As Integer = reader.GetValue(4)

                        '出庫中断中アイテムの場合
                        If m画面モード = 0 Then
                            If reader.GetValue(6) = True Then
                                If CMsg.gMsg_YesNo("現在、出庫中断中です。" & vbCrLf & "出庫を開始しますか？") = Windows.Forms.DialogResult.Yes Then
                                    Return True
                                Else
                                    Return False
                                End If
                                Exit Function
                            End If

                        Else
                            If reader.GetValue(6) = 1 Then
                                If CMsg.gMsg_YesNo("現在、出庫中断中です。" & vbCrLf & "中断を解除しますか？") = Windows.Forms.DialogResult.Yes Then
                                    int中断区分 = 1
                                    Return True
                                Else
                                    Return False
                                End If
                            End If
                        End If

                        If m画面モード = 0 Then
                            Select Case reader.GetValue(5)
                                Case 27
                                    Return True

                                Case 28
                                    CMsg.gMsg_情報("既に出庫指示済です。")
                                    Return False
                                Case 29, 30
                                    CMsg.gMsg_情報("既に出庫中です。")
                                    Return False
                            End Select

                        Else
                            Select Case reader.GetValue(5)
                                Case 27, 28
                                    Return True
                                Case 29, 30
                                    CMsg.gMsg_情報("既に出庫中です。")
                                    Return False
                            End Select

                        End If
                        CNT += 1
                    End While

                    If CNT = 0 Then
                        CMsg.gMsg_情報("入力された情報が存在しません。")
                        Return False
                    End If
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
        Return True
    End Function

    Private Sub Updateトラッキング_出庫指示()
        Try
            'トラッキングデータを出荷指示状態に更新する（中断データは再開する）
            '⇒SVソフトにて冷却経過時間に関わらず出荷が実施される
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("出庫順", "NULL", False)
                .gSubColumnValue("出庫指示", 1, False)
                .gSubColumnValue("出庫中断_冷", 0, False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubWhere("ステータス", 27, , , , , , , False)
                .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub Updateトラッキング_出庫中断指示()
        '該当のトラッキングデータにおける出荷中断FLGをONする。
        'すでに出荷指示のかかっているデータ（ST:30）がある場合は、
        '出荷中のユニットとそれとペアになるものを除いて中断する
        '出荷指示のかかったデータの有無を確認

        Dim reader As DbDataReader = Nothing
        Dim int中断不可SEQ As Integer = Nothing
        Try
            With New CSqlEx
                .gSubSelect("TOP 1 A.ユニットSEQ")
                .gSubSelect("MAX(A.出庫順) as 出庫順")
                .gSubFrom("DNトラッキング A")
                .gSubWhere("A.ステータス = 28")
                .gSubWhere("A.ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)
                .gSubGroupBy("A.ユニットSEQ")
                .gSubGroupBy("出庫順")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Dim str最少出庫順 As String = reader.GetValue(1).ToString
                        If str最少出庫順 = "" Then
                            '未引当状態なのですべて出荷可
                        ElseIf Val(str最少出庫順) = 99 Then
                            'すべて出荷可
                        ElseIf Val(str最少出庫順) Mod 2 = 1 Then
                            '既にペア側（偶数番号）が出荷状態なので本SEQに関しては中断出来ない
                            int中断不可SEQ = reader.GetValue(0)
                        Else
                            'すべて出荷可
                        End If
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Try
            '入庫済分
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("ステータス", 27, False)
                .gSubColumnValue("出庫順", "NULL", False)
                .gSubColumnValue("出庫指示", 0, False)
                .gSubColumnValue("出庫中断_冷", 1, False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubWhere("(ステータス = 27 OR ステータス = 28)")
                If int中断不可SEQ <> Nothing Then
                    .gSubWhere("ユニットSEQ", int中断不可SEQ, "<>", , , , , , False)
                End If
                .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try

        Try
            '入庫前済分
            'トラッキングへの影響を考慮し、更新日時はそのままとします。
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("出庫中断_冷", 1, False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubWhere("ステータス < 27")
                .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try

    End Sub

    Private Sub Updateトラッキング_出庫中断解除指示()
        '該当のトラッキングデータにおける出荷中断FLGをOFFする。
        Dim reader As DbDataReader = Nothing
        '入庫済分
        Try
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("ステータス", 27, False)
                .gSubColumnValue("出庫順", "NULL", False)
                .gSubColumnValue("出庫指示", 0, False)
                .gSubColumnValue("出庫中断_冷", 0, False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubWhere("(ステータス = 27)")
                .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try

        '入庫前済分
        Try
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("出庫中断_冷", 0, False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubWhere("(ステータス < 27)")
                .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try

    End Sub

    Private Sub txtロットNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtロットNo.Leave
        If Trim(Me.txtロットNo.Text) = "" Then
            Exit Sub
        End If

        '情報表示
        トラッキングデータ表示()
    End Sub

    Private Sub トラッキングデータ表示()
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("A.サンプルNo")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("MAX(B.所定冷却時間)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,冷却開始時刻,GETDATE()))")
                .gSubSelect("MAX(A.ステータス)")
                .gSubSelect("MAX(A.出庫中断_冷)")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                '.gSubWhere("A.ステータス >= 27 ")
                '.gSubWhere("A.ステータス <= 30 ")
                .gSubWhere("A.ロットNo COLLATE Japanese_CS_AS_KS_WS", txtロットNo.Text, , , , , , , True)
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubGroupBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubGroupBy("A.サンプルNo")
                .gSubOrderBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubOrderBy("A.サンプルNo")

                Dim CNT As Integer = 0
                lbl品種名.Text = ""
                lbl所定醗酵時間.Text = ""
                lbl醗酵経過時間.Text = ""

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        lbl品種名.Text = reader.GetValue(2)
                        lbl所定醗酵時間.Text = reader.GetValue(3) & "分"
                        lbl醗酵経過時間.Text = reader.GetValue(4) & "分"
                        Me.btnF1.Enabled = True

                        CNT += 1
                    End While

                    If CNT = 0 Then
                        CMsg.gMsg_情報("入力された情報が存在しません。")
                        Me.btnF1.Enabled = False
                    End If
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub
End Class

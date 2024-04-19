
Imports System.Data.Common
Public Class Dlg02999_出庫設定
    Private Sub Dlg01999_出庫設定_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.m画面モード = 0 Then
            Me.Text = "出庫設定"
        Else
            Me.Text = "出庫中断設定"
        End If
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        '入力情報のチェック
        Select Case int登録前チェック()
            Case 1
                Updateトラッキング_クレーン()
                DialogResult = Windows.Forms.DialogResult.OK

            Case 2
                Updateトラッキング_クレーン出庫中断状態更新(m画面モード)
                DialogResult = Windows.Forms.DialogResult.OK

            Case Else

        End Select
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Function int登録前チェック() As Integer
        '0:処理なし
        '1:出庫開始
        '2:出庫再開/中断
        Dim reader As DbDataReader = Nothing
        Dim intRET As Integer = 0
        Try
            With New CSqlEx
                .gSubSelect("A.ロットNo")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("MAX(B.所定冷却時間)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,冷却開始時刻,GETDATE()))")
                .gSubSelect("MAX(A.ステータス)")
                .gSubSelect("A.出庫中断")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                .gSubWhere("A.ステータス >= 27 ")
                .gSubWhere("A.ステータス <= 30 ")
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubGroupBy("A.ロットNo")
                .gSubGroupBy("A.出庫中断")
                .gSubOrderBy("A.ロットNo")

                Dim CNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Dim 所定冷却時間 As Integer = reader.GetValue(2)
                        Dim 冷却経過時間 As Integer = reader.GetValue(3)

                        '出庫中断中アイテムの場合
                        If m画面モード = 0 Then
                            If reader.GetValue(5) = True Then
                                If CMsg.gMsg_YesNo("現在、出庫中断中です。" & vbCrLf & "出庫を再開しますか？") Then
                                    intRET = 2
                                    Return intRET
                                Else
                                End If
                                Exit Function
                            End If

                        Else
                            If reader.GetValue(5) = 1 Then
                                CMsg.gMsg_情報("既に出庫中断中です。")
                                Exit Function
                            End If
                        End If

                        If m画面モード = 0 Then
                            Select Case reader.GetValue(4)
                                Case 27
                                    If 所定冷却時間 > 冷却経過時間 Then
                                        If CMsg.gMsg_YesNo("所定冷却時間に達していません。" & vbCrLf & "出庫を続行しますか？") Then
                                            intRET = 1
                                        Else

                                        End If
                                    Else
                                        '出庫開始
                                        intRET = 1
                                    End If
                                Case 28
                                    CMsg.gMsg_情報("既に出庫指示済です。")
                                Case 29, 30
                                    CMsg.gMsg_情報("既に出庫中です。")
                            End Select

                        Else
                            Select Case reader.GetValue(4)
                                Case 27, 28 '出庫前、未出荷状態であればストップ可能
                                    intRET = 2
                                Case 29, 30 '１ユニットでも出荷されれば中止できません⇒MAX(ステータス）が対象となる
                                    CMsg.gMsg_情報("既に出庫中です。")
                            End Select

                        End If
                        CNT += 1
                    End While

                    If CNT = 0 Then
                        CMsg.gMsg_情報("入力された情報が存在しません。")
                    End If
                End If
            End With

            Return intRET
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Private Sub Updateトラッキング_クレーン()
        Try
            'トラッキングデータを更新する（パレタイズを考慮した出荷順の更新）
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("ステータス", 28, False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubWhere("ステータス", 28, , , , , , , False)
                .gSubWhere("ロットNo", Me.txtロットNo.Text, , , , , , , True)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub Updateトラッキング_クレーン出庫中断状態更新(ByVal 画面モード As Integer)
        Try
            'トラッキングデータを更新する
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                If 画面モード = 0 Then
                    .gSubColumnValue("出庫中断", 0, False)
                Else
                    .gSubColumnValue("出庫中断", 1, False)
                End If
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubWhere("(ステータス >= 27 OR ステータス <= 28)")
                .gSubWhere("ロットNo", Me.txtロットNo.Text, , , , , , , True)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub
End Class

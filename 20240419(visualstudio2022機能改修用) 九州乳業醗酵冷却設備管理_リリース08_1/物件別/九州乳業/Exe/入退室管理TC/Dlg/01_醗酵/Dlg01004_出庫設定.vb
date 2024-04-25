
Imports System.Data.Common
Public Class Dlg01004_出庫設定
    Private Sub Dlg01004_出庫設定_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.m画面モード = 0 Then
            Me.Text = "出庫設定"
            Me.btnF1.Text = "F1" & vbCrLf & "開始"
        Else
            Me.Text = "出庫中断設定"
            Me.btnF1.Text = "F1" & vbCrLf & "中断"
        End If
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If Trim(Me.txtロットNo.Text) = "" Then
            CMsg.gMsg_情報("ロットNoが入力されていません。")
            Me.txtロットNo.Focus()
            Exit Sub
        End If
        If Trim(Me.txtサンプルNo.Text) = "" Then
            CMsg.gMsg_情報("サンプルNoが入力されていません。")
            Me.txtサンプルNo.Focus()
            Exit Sub
        End If

        '入力情報のチェック
        Select Case int登録前チェック()
            Case 1
                If CMsg.gMsg_YesNo("出庫設定を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                Updateトラッキング_クレーン()
                DialogResult = Windows.Forms.DialogResult.OK

            Case 2
                '---------------------------
                '2014/9 Morichika
                If m画面モード = 1 Then
                    '中断設定を実行
                    If CMsg.gMsg_YesNo("中断設定を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                Else
                    '中断解除を実行
                    If CMsg.gMsg_YesNo("中断解除を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
                '---------------------------

                Updateトラッキング_クレーン出庫中断状態更新(m画面モード)
                DialogResult = Windows.Forms.DialogResult.OK

            Case Else
                '0:処理なし
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
                .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("A.サンプルNo")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("MAX(B.所定醗酵時間)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,醗酵開始時刻,GETDATE()))")
                .gSubSelect("MAX(A.ステータス)")
                .gSubSelect("MAX(A.出庫中断)")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                .gSubWhere("A.ステータス >= 6 ")
                .gSubWhere("A.ステータス <= 9 ")
                .gSubWhere("A.ロットNo COLLATE Japanese_CS_AS_KS_WS", txtロットNo.Text, , , , , , , True)
                .gSubWhere("A.サンプルNo", txtサンプルNo.Text, , , , , , , False)
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubGroupBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubGroupBy("A.サンプルNo")
                .gSubOrderBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubOrderBy("A.サンプルNo")

                Dim CNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Dim 所定醗酵時間 As Integer = reader.GetValue(3)
                        Dim 醗酵経過時間 As Integer = reader.GetValue(4)

                        '出庫中断中アイテムの場合
                        If m画面モード = 0 Then
                            If reader.GetValue(6) = 1 Then
                                '---------------------------
                                '2014/9 Morichika
                                '---------------------------
                                If CMsg.gMsg_YesNo("現在、出庫中断中です。" & vbCrLf & "中断を解除して出庫を開始しますか？") = Windows.Forms.DialogResult.Yes Then
                                    intRET = 2
                                    Return intRET
                                Else
                                End If
                                Exit Function
                            End If

                        Else
                            If reader.GetValue(6) = 1 Then
                                CMsg.gMsg_情報("既に出庫中断中です。")
                                Exit Function
                            End If
                        End If

                        If m画面モード = 0 Then
                            Select Case reader.GetValue(5)
                                Case 6
                                    If 所定醗酵時間 > 醗酵経過時間 Then
                                        If CMsg.gMsg_YesNo("所定発酵時間に達していません。" & vbCrLf & "出庫を続行しますか？") = Windows.Forms.DialogResult.Yes Then
                                            intRET = 1
                                        Else

                                        End If
                                    Else
                                        '出庫開始
                                        intRET = 1
                                    End If
                                Case 7
                                    CMsg.gMsg_情報("既に出庫指示済です。")
                                Case 8, 9
                                    CMsg.gMsg_情報("既に出庫中です。")
                            End Select

                        Else
                            Select Case reader.GetValue(5)
                                Case 6
                                    CMsg.gMsg_情報("出荷開始されていません。")
                                Case 7
                                    intRET = 2
                                Case 8, 9
                                    intRET = 2
                                    'CMsg.gMsg_情報("既に出庫中です。")
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
            'トラッキングデータを更新する
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("ステータス", 7, False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubWhere("ステータス", 6, , , , , , , False)
                .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)
                .gSubWhere("サンプルNo", Val(Me.txtサンプルNo.Text), , , , , , , False)

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
                .gSubWhere("ステータス", 7, , , , , , , False, CSql.EnmWhere.OrStart)
                .gSubWhere("ステータス", 8, , , , , , , False, CSql.EnmWhere.WhereOr)
                .gSubWhere("ステータス", 9, , , , , , , False, CSql.EnmWhere.OrEndOr)
                .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)
                .gSubWhere("サンプルNo", Me.txtサンプルNo.Text, , , , , , , False)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub txtロットNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtロットNo.Leave
        If Trim(Me.txtサンプルNo.Text) = "" Or Trim(Me.txtロットNo.Text) = "" Then
            Exit Sub
        End If

        '情報表示
        トラッキングデータ表示()
    End Sub

    Private Sub txtサンプルNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtサンプルNo.TextChanged
        If Trim(Me.txtロットNo.Text) = "" Then
            Exit Sub
        ElseIf Me.txtサンプルNo.Text = "" Then
            Exit Sub
        End If

        '情報表示
        トラッキングデータ表示()

    End Sub

    Private Sub txtサンプルNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtサンプルNo.Leave
        If Trim(Me.txtサンプルNo.Text) = "" Or Trim(Me.txtロットNo.Text) = "" Then
            Exit Sub
        End If

        '情報表示
        トラッキングデータ表示()

    End Sub

    Private Sub トラッキングデータ表示()
        Dim reader As DbDataReader = Nothing
        Dim intRET As Integer = 0
        Try
            With New CSqlEx
                .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("A.サンプルNo")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("MAX(B.所定醗酵時間)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,醗酵開始時刻,GETDATE()))")
                .gSubSelect("MAX(A.ステータス)")
                .gSubSelect("MAX(A.出庫中断)")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                .gSubWhere("A.ステータス >= 6 ")
                .gSubWhere("A.ステータス <= 9 ")
                .gSubWhere("A.ロットNo COLLATE Japanese_CS_AS_KS_WS", txtロットNo.Text, , , , , , , True)
                .gSubWhere("A.サンプルNo", txtサンプルNo.Text, , , , , , , False)
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubGroupBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubGroupBy("A.サンプルNo")
                .gSubOrderBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubOrderBy("A.サンプルNo")

                Dim CNT As Integer = 0
                Me.lbl品種名.Text = ""
                Me.lbl所定醗酵時間.Text = ""
                Me.lbl醗酵経過時間.Text = ""
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Me.lbl品種名.Text = reader.GetValue(2)
                        Me.lbl所定醗酵時間.Text = reader.GetValue(3) & "分"
                        Me.lbl醗酵経過時間.Text = reader.GetValue(4) & "分"
                        Me.btnF1.Enabled = True
                        CNT += 1
                    End While

                    If CNT = 0 Then
                        Me.btnF1.Enabled = False
                        CMsg.gMsg_情報("入力された情報が存在しません。")
                    End If
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

End Class

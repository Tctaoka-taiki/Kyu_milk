
Imports System.Data.Common

Public Class Dlg01999_品種削除
    Private Sub Dlg01999_品種削除_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初期表示
        画面初期化()

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        'チェック（入庫設定、トラッキング）
        If bln品種CDを利用している() Then
            Exit Sub
        End If

        If CMsg.gMsg_YesNo("削除を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '入力情報をDN製造製品に更新
        Delete品種データ()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Sub Delete品種データ()
        Try
            With New CSql
                .gSubClearSQL()
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
                .pテーブル名 = "DM品種"
                .gSubWhere("品種CD", Me.txt品種.Text, , , , , , , False)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With

        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Me.txt品種.Text = ""
        
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Public Function bln品種名が存在する(ByVal str品種名 As String) As Boolean
        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("COUNT(A.品種CD)")
                .gSubFrom("DM品種 A")
                .gSubWhere("A.品種名", str品種名)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If reader.GetValue(0) > 0 Then
                            Return True
                        Else
                            Return False
                        End If
                    End While
                End If
            End With
            Return False
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Private Sub txt品種_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt品種.TextChanged
        If txt品種.Text = "" Then
            画面初期化()
            Exit Sub
        End If

        '画面表示
        情報表示()
    End Sub

    Private Sub 情報表示()
        Dim reader As DbDataReader = Nothing
        画面初期化()

        Try
            With New CSqlEx
                .gSubSelect("製品区分")
                .gSubSelect("品種名")
                .gSubSelect("所定醗酵時間")
                .gSubSelect("所定冷却時間")
                .gSubSelect("所定賞味期間")
                .gSubFrom("DM品種")
                .gSubWhere("品種CD", Me.txt品種.Text, , , , , , , False)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If reader.GetValue(0).ToString = 0 Then
                            Me.lbl製品区分.Text = "ハード"
                        Else
                            Me.lbl製品区分.Text = "プレーン"
                        End If
                        Me.lbl品種名.Text = reader.GetValue(1)
                        Me.lbl所定発酵時間.Text = reader.GetValue(2) & "分"
                        Me.lbl所定冷却時間.Text = reader.GetValue(3) & "分"
                        Me.lbl所定賞味期間.Text = reader.GetValue(4) & "日"
                        Me.btnF1.Enabled = True
                        Exit Sub
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub 画面初期化()
        Me.lbl製品区分.Text = ""
        Me.lbl品種名.Text = ""
        Me.lbl所定発酵時間.Text = ""
        Me.lbl所定冷却時間.Text = ""
        Me.lbl所定賞味期間.Text = ""
        Me.btnF1.Enabled = False
    End Sub

    Private Function bln品種CDを利用している() As Boolean
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("COUNT(*)")
                .gSubFrom("DNトラッキング A")
                .gSubWhere("A.品種CD", Me.txt品種.Text)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If reader.GetValue(0) > 0 Then
                            CMsg.gMsg_エラー("現在トラッキングデータとして利用している品種CDは削除出来ません。")
                            Return True
                        End If
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Try
            With New CSqlEx
                .gSubSelect("COUNT(*)")
                .gSubFrom("DN製造製品 A")
                .gSubWhere("A.品種CD", Me.txt品種.Text)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If reader.GetValue(0) > 0 Then
                            CMsg.gMsg_エラー("現在入庫設定として利用している品種CDは削除出来ません。")
                            Return True
                        End If
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Return False
    End Function
End Class

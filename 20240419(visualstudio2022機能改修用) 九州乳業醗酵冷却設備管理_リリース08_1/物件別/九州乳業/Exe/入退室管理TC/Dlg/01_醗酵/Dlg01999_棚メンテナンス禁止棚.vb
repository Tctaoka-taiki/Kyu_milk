
Imports System.Data.Common

Public Class Dlg01999_棚メンテナンス禁止棚

    Dim int更新区分 As Integer = 99  '0:禁止棚更新、1:利用可能棚更新

    Private Sub Dlg01999_棚メンテナンス禁止棚_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初期表示
        画面初期化()
        Me.btnF1.Enabled = False
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If int更新区分 = 0 Then
            If CMsg.gMsg_YesNo("禁止棚に変更してもよろしいですか？") = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

        Else
            If CMsg.gMsg_YesNo("利用可能棚に変更してもよろしいですか？") = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

        End If

        '入力情報をDN製造製品に更新
        Update棚データ()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Me.txt列.Text = ""
        Me.txt連.Text = ""
        Me.txt段.Text = ""
        画面初期化()

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

    Public Sub Update棚データ()
        '実際には現在のデータを削除した後、再度新しいデータを作成する
        '削除
        Try
            With New CSql
                .gSubClearSQL()
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DM棚"
                If int更新区分 = 0 Then
                    .gSubColumnValue("棚区分", 2, False)
                Else
                    .gSubColumnValue("棚区分", 0, False)
                End If
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubWhere("列", txt列.Text, , , , , , , False)
                .gSubWhere("連", txt連.Text, , , , , , , False)
                .gSubWhere("段", txt段.Text, , , , , , , False)
                Select Case m画面モード
                    Case 0  '醗酵
                        .gSubWhere("倉庫区分 = 0 ")

                    Case 1  '冷却
                        .gSubWhere("倉庫区分 = 1 ")

                End Select

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub ロケ情報表示()
        Dim reader As DbDataReader = Nothing
        画面初期化()

        Try
            With New CSqlEx
                .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubFrom("DNトラッキング A")
                '---------------------------------
                Select Case m画面モード
                    Case 0  '醗酵
                        .gSubWhere("ステータス < 10 ")

                    Case 1  '冷却
                        .gSubWhere("ステータス >= 20")
                        .gSubWhere("ステータス <= 31")

                End Select
                '---------------------------------
                .gSubWhere("A.列", Me.txt列.Text, , , , , , , False)
                .gSubWhere("A.連", Me.txt連.Text, , , , , , , False)
                .gSubWhere("A.段", Me.txt段.Text, , , , , , , False)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        '在庫情報があっても禁止可能とする
                        'CMsg.gMsg_エラー("在庫情報があります。")
                        'Me.txt列.Focus()
                        'Me.txt列.Text = ""
                        'Me.txt連.Text = ""
                        'Me.txt段.Text = ""
                        'Me.lbl棚区分.Text = ""
                        'Me.btnF1.Enabled = False
                        'Exit Sub
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Try
            With New CSqlEx
                .gSubSelect("A.棚区分")
                .gSubFrom("DM棚 A")
                Select Case m画面モード
                    Case 0  '醗酵
                        .gSubWhere("A.倉庫区分 = 0")

                    Case 1  '冷却
                        .gSubWhere("A.倉庫区分 = 1")

                End Select
                .gSubWhere("A.列", Me.txt列.Text, , , , , , , False)
                .gSubWhere("A.連", Me.txt連.Text, , , , , , , False)
                .gSubWhere("A.段", Me.txt段.Text, , , , , , , False)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Select Case reader.GetValue(0)
                            Case 0
                                Me.lbl棚区分.Text = "利用可能棚"
                                Me.btnF1.Enabled = True
                                Me.btnF1.Text = "F1" & vbCrLf & "禁止"
                                int更新区分 = 0
                                Exit Sub

                            Case 1
                                CMsg.gMsg_エラー("ステーション棚は変更できません。")
                                Me.txt列.Focus()
                                Me.txt列.Text = ""
                                Me.txt連.Text = ""
                                Me.txt段.Text = ""
                                Me.lbl棚区分.Text = ""
                                Me.btnF1.Text = ""
                                Me.btnF1.Enabled = False
                                Exit Sub

                            Case 2
                                Me.lbl棚区分.Text = "禁止棚"
                                Me.btnF1.Enabled = True
                                Me.btnF1.Text = "F1" & vbCrLf & "利用可"
                                int更新区分 = 1
                                Exit Sub

                            Case Else   '不明
                                CMsg.gMsg_エラー("棚情報がありません。")
                                Me.txt列.Focus()
                                Me.txt列.Text = ""
                                Me.txt連.Text = ""
                                Me.txt段.Text = ""
                                Me.lbl棚区分.Text = ""
                                Me.btnF1.Text = ""
                                Me.btnF1.Enabled = False
                                Exit Sub

                        End Select
                    End While

                    CMsg.gMsg_エラー("棚情報がありません。")
                    Me.txt列.Focus()
                    Me.txt列.Text = ""
                    Me.txt連.Text = ""
                    Me.txt段.Text = ""
                    Me.lbl棚区分.Text = ""
                    Me.btnF1.Text = ""
                    Me.btnF1.Enabled = False
                    Exit Sub
                End If
            End With

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub 画面初期化()
        Me.lbl棚区分.Text = ""
    End Sub

End Class


Imports System.Data.Common

Public Class Dlg01999_醗酵側棚指定登録

    Private Sub Dlg01999_醗酵側棚指定登録_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.btnF1.Enabled = False
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Dim strMSG As String = ""
        Select Case m画面モード
            Case 0  '登録
                strMSG = "この棚番地を出荷登録してもよろしいですか？"

            Case 1  '削除
                strMSG = "この棚番地の出荷登録を削除してもよろしいですか？"

            Case 2  '開始
                strMSG = "この棚番地を出荷開始してもよろしいですか？"

            Case 3  '中断
                strMSG = "この棚番地の出荷を中断してもよろしいですか？"

        End Select

        If CMsg.gMsg_YesNo(strMSG) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '入力情報をDN製造製品に更新
        Updateトラッキング棚出庫データ()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Me.txt列.Text = ""
        Me.txt連.Text = ""
        Me.txt段.Text = ""
        Me.btnF1.Enabled = False

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

    Public Sub Updateトラッキング棚出庫データ()
        Try
            With New CSql
                .gSubClearSQL()
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubColumnValue("更新プログラム", Name, True)
                Select Case m画面モード
                    Case 0  '登録
                        .gSubColumnValue("棚指定出庫", 1, False)
                        .gSubWhere("ステータス = 6")
                        .gSubWhere("棚指定出庫 = 0")

                    Case 1  '削除
                        .gSubColumnValue("棚指定出庫", 0, False)
                        .gSubWhere("ステータス = 6")
                        .gSubWhere("棚指定出庫 = 1")

                    Case 2  '開始
                        .gSubColumnValue("ステータス", 7, False)
                        .gSubWhere("ステータス = 6")
                        .gSubWhere("棚指定出庫 = 1")

                    Case 3  '中断
                        .gSubColumnValue("ステータス", 6, False)
                        .gSubWhere("ステータス = 7")
                        .gSubWhere("棚指定出庫 = 1")

                End Select
                .gSubWhere("列", txt列.Text, , , , , , , False)
                .gSubWhere("連", txt連.Text, , , , , , , False)
                .gSubWhere("段", txt段.Text, , , , , , , False)

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

        Me.btnF1.Enabled = False
        Try
            Dim CNT As Integer = 0
            Dim strErrMsg As String = ""
            With New CSqlEx
                .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubFrom("DNトラッキング A")
                '---------------------------------
                Select Case m画面モード
                    Case 0  '登録
                        .gSubWhere("ステータス = 6")
                        .gSubWhere("棚指定出庫 = 0")
                        strErrMsg = "この棚番地には在庫がありません。"

                    Case 1  '削除
                        .gSubWhere("ステータス = 6")
                        .gSubWhere("棚指定出庫 = 1")
                        strErrMsg = "この棚番地は現在出庫登録中ではありません。"

                    Case 2  '開始
                        .gSubWhere("ステータス = 6")
                        .gSubWhere("棚指定出庫 = 1")
                        strErrMsg = "この棚番地は現在出庫登録中ではありません。"

                    Case 3  '中断
                        .gSubWhere("ステータス = 7")
                        .gSubWhere("棚指定出庫 = 1")
                        strErrMsg = "この棚番地は現在出庫開始中ではありません。"

                End Select
                '---------------------------------
                .gSubWhere("A.列", Me.txt列.Text, , , , , , , False)
                .gSubWhere("A.連", Me.txt連.Text, , , , , , , False)
                .gSubWhere("A.段", Me.txt段.Text, , , , , , , False)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        CNT += 1
                    End While
                End If

            End With

            If CNT = 0 Then
                CMsg.gMsg_エラー(strErrMsg)
            Else
                Me.btnF1.Enabled = True
            End If

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

End Class

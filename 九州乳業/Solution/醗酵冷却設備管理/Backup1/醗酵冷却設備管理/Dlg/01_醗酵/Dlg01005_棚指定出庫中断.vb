
Imports System.Data.Common

Public Class Dlg01005_棚指定出庫中断
    Private Sub Dlg01005_棚指定出中断_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初期表示
        Select Case m画面モード
            Case 0  '醗酵
                lbl醗酵冷却開始時刻タイトル.Text = "醗酵開始時刻"
            Case 1  '冷却
                lbl醗酵冷却開始時刻タイトル.Text = "冷却開始時刻"
        End Select

        Me.btnF1.Enabled = False
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If CMsg.gMsg_YesNo("棚指定出庫を中断してもよろしいですか？") = Windows.Forms.DialogResult.No Then
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
        Try
            With New CSql

                Select Case m画面モード
                    Case 0
                        .gSubClearSQL()
                        .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                        .pテーブル名 = "DNトラッキング"
                        .gSubColumnValue("ステータス", 6, False)
                        .gSubWhere("列", txt列.Text, , , , , , , False)
                        .gSubWhere("連", txt連.Text, , , , , , , False)
                        .gSubWhere("段", txt段.Text, , , , , , , False)
                        .gSubWhere("ステータス = 7 ")

                    Case 1
                        .gSubClearSQL()
                        .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                        .pテーブル名 = "DNトラッキング"
                        .gSubColumnValue("ステータス", 27, False)
                        .gSubColumnValue("出庫順", "NULL", False)
                        .gSubWhere("列", txt列.Text, , , , , , , False)
                        .gSubWhere("連", txt連.Text, , , , , , , False)
                        .gSubWhere("段", txt段.Text, , , , , , , False)
                        .gSubWhere("ステータス = 28")

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
                .gSubSelect("MAX(A.ロットNo COLLATE Japanese_CS_AS_KS_WS) as ロットNo")
                .gSubSelect("MAX(A.サンプルNo) as サンプルNo")
                .gSubSelect("MAX(B.品種名) as 品種名")
                .gSubSelect("SUM(A.受入数) as クレート数")
                .gSubSelect("MAX(A.賞味期限) as 賞味期限")
                Select Case m画面モード
                    Case 0
                        .gSubSelect("MAX(A.醗酵開始時刻) as 開始時刻")
                    Case 1
                        .gSubSelect("MAX(A.冷却開始時刻) as 開始時刻")
                End Select
                .gSubSelect("count(A.ロットNo COLLATE Japanese_CS_AS_KS_WS) as ユニット列数")
                .gSubSelect("MAX(A.棚指定出庫) as 棚指定出庫")
                .gSubSelect("MAX(A.ステータス) as ステータス")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                '---------------------------------
                Select Case m画面モード
                    Case 0      '醗酵倉庫内のトラッキングを対象とする
                        .gSubWhere("A.ステータス >= 7")
                        .gSubWhere("A.ステータス <= 10")

                    Case 1      '冷却倉庫内のトラッキングを対象とする
                        .gSubWhere("ステータス = 28")
                End Select
                '---------------------------------
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubWhere("A.列", Me.txt列.Text, , , , , , , False)
                .gSubWhere("A.連", Me.txt連.Text, , , , , , , False)
                .gSubWhere("A.段", Me.txt段.Text, , , , , , , False)
                .gSubGroupBy("A.ユニットSEQ")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If reader.GetValue(0).ToString = "" Then
                            CMsg.gMsg_エラー("在庫情報がありません")
                            Me.txt列.Focus()
                            Me.txt列.Text = ""
                            Me.txt連.Text = ""
                            Me.txt段.Text = ""

                            Me.btnF1.Enabled = False
                            Exit Sub
                        Else
                            If reader.GetValue(7).ToString = 0 Then
                                CMsg.gMsg_エラー("棚指定出荷登録されていません")
                                Me.txt列.Focus()
                                Me.txt列.Text = ""
                                Me.txt連.Text = ""
                                Me.txt段.Text = ""

                                Me.btnF1.Enabled = False
                                Exit Sub
                            Else
                                Select Case reader.GetValue(8).ToString
                                    Case 6
                                        CMsg.gMsg_エラー("棚指定出荷が開始されていません")
                                        Me.btnF1.Enabled = False
                                    Case 7
                                        Me.lblロットNo.Text = reader.GetValue(0)
                                        Me.lblサンプルNo.Text = reader.GetValue(1)
                                        Me.lbl品種.Text = reader.GetValue(2)
                                        Me.lblクレート数.Text = reader.GetValue(3)
                                        Me.lbl賞味期限.Text = reader.GetValue(4)
                                        Me.lbl醗酵冷却開始時刻.Text = reader.GetValue(5)
                                        Me.lblユニット列数.Text = reader.GetValue(6)
                                        Me.btnF1.Enabled = True
                                    Case 8 To 10
                                        CMsg.gMsg_エラー("既に出庫中です")
                                        Me.btnF1.Enabled = False

                                    Case 27
                                        CMsg.gMsg_エラー("棚指定出荷が開始されていません")
                                        Me.btnF1.Enabled = False
                                    Case 28
                                        Me.lblロットNo.Text = reader.GetValue(0)
                                        Me.lblサンプルNo.Text = reader.GetValue(1)
                                        Me.lbl品種.Text = reader.GetValue(2)
                                        Me.lblクレート数.Text = reader.GetValue(3)
                                        Me.lbl賞味期限.Text = reader.GetValue(4)
                                        Me.lbl醗酵冷却開始時刻.Text = reader.GetValue(5)
                                        Me.lblユニット列数.Text = reader.GetValue(6)
                                        Me.btnF1.Enabled = True
                                    Case 29 To 31
                                        CMsg.gMsg_エラー("既に出庫中です")
                                        Me.btnF1.Enabled = False
                                End Select
                            End If
                            Exit Sub
                        End If
                    End While
                End If
            End With

            Me.btnF1.Enabled = False
            CMsg.gMsg_エラー("在庫情報が存在しません。")
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
        Me.lblクレート数.Text = ""
        Me.lblサンプルNo.Text = ""
        Me.lblユニット列数.Text = ""
        Me.lblロットNo.Text = ""
        Me.lbl賞味期限.Text = ""
        Me.lbl醗酵冷却開始時刻.Text = ""
        Me.lbl品種.Text = ""

    End Sub
End Class

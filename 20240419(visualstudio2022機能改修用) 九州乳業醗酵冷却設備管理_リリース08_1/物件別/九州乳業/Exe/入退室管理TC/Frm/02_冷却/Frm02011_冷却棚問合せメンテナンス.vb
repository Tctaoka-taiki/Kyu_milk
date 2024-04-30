
Imports System.Data.Common
Public Class Frm02011_冷却棚問合せメンテナンス
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################

    '#####################################################################################
    'プロパティー
    '#####################################################################################

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Dim intカレント行 As Integer = 0
    Private Sub Frm02011_冷却棚問合せメンテナンス_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        倉庫情報表示()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim dlg As New Dlg01999_棚メンテナンス登録
            With dlg
                .m画面モード = 1
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Try
            Dim dlg As New Dlg01999_棚メンテナンス削除
            With dlg
                .m画面モード = 1
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Try
            Dim dlg As New Dlg01999_棚メンテナンス修正
            With dlg
                .m画面モード = 1
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Try
            Dim dlg As New Dlg01999_棚メンテナンス禁止棚
            With dlg
                .m画面モード = 1
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.冷却メインメニュー)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub 倉庫情報表示()
        Me.dgv生産データ.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("B.品種CD")
                .gSubSelect("MAX(A.列) as 列")
                .gSubSelect("MAX(A.連) as 連")
                .gSubSelect("MAX(A.段) as 段")
                .gSubSelect("MAX(A.ロットNo COLLATE Japanese_CS_AS_KS_WS) as ロットNo")
                .gSubSelect("MAX(A.サンプルNo) as サンプルNo")
                .gSubSelect("MAX(B.品種名) as 品種名")
                .gSubSelect("SUM(A.受入数) as クレート数")
                .gSubSelect("MAX(A.賞味期限) as 賞味期限")
                .gSubSelect("MAX(A.冷却開始時刻) as 開始時刻")
                .gSubSelect("MAX(B.所定冷却時間) as 所定時刻")
                .gSubSelect("MAX(DATEDIFF(MINUTE,A.冷却開始時刻,GETDATE())) as 経過時刻")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                '---------------------------------
                '冷却倉庫内のトラッキングを対象とする
                .gSubWhere("A.ステータス >= 27 ")
                .gSubWhere("A.ステータス <= 29 ")
                '---------------------------------
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubGroupBy("B.品種CD,A.ユニットSEQ")

                Dim strトラッキング状況SQL As String = .gSQL文の取得
                .gSubClearSQL()
                .gSubSelect("A.列")
                .gSubSelect("A.連")
                .gSubSelect("A.段")
                .gSubSelect("B.ロットNo")
                .gSubSelect("B.サンプルNo")
                .gSubSelect("B.品種名")
                .gSubSelect("B.賞味期限")
                .gSubSelect("B.クレート数")
                .gSubSelect("B.開始時刻")
                .gSubSelect("B.所定時刻")
                .gSubSelect("B.経過時刻")
                .gSubSelect("A.棚区分")
                .gSubSelect("B.品種CD")
                .gSubFrom("DM棚 A LEFT JOIN (" & strトラッキング状況SQL & ")B ON A.列=B.列 AND A.連=B.連 AND A.段=B.段")
                .gSubWhere("A.倉庫区分", 1, , , , , , , False)
                .gSubWhere("A.棚区分<>1")   'ステーションは対象外
                .gSubWhere("A.棚区分<>3")   '棚無しは対象外
                .gSubOrderBy("IIF(B.品種CD IS NOT NULL, 0, 1),B.品種CD,開始時刻,列,連,段")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    '合計表示行の作成
                    Dim i As Integer = 0

                    While reader.Read
                        Me.dgv生産データ.Rows.Add()
                        Me.dgv生産データ.Item(0, i).Value = reader.GetValue(0) & "-" & reader.GetValue(1).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(2)
                        Me.dgv生産データ.Item(1, i).Value = reader.GetValue(3)
                        Me.dgv生産データ.Item(2, i).Value = reader.GetValue(4)
                        Me.dgv生産データ.Item(3, i).Value = reader.GetValue(5)
                        Me.dgv生産データ.Item(4, i).Value = Mid(reader.GetValue(6).ToString, 1, 10)
                        Me.dgv生産データ.Item(5, i).Value = reader.GetValue(7)
                        Me.dgv生産データ.Item(6, i).Value = reader.GetValue(8)
                        If reader.GetValue(9).ToString <> "" Then
                            Me.dgv生産データ.Item(7, i).Value = reader.GetValue(9) & "分"
                        End If
                        If reader.GetValue(10).ToString <> "" Then
                            Me.dgv生産データ.Item(8, i).Value = reader.GetValue(10) & "分"
                        End If
                        If reader.GetValue(11) = 2 Then  '禁止棚（赤字反転）
                            Me.dgv生産データ.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        End If
                        i += 1
                    End While

                End If
            End With
        Catch ex As Exception
        Finally
            intカレント行 = 0
            Me.dgv生産データ.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Dim int直前ページ送り区分 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        If Me.dgv生産データ.Rows.Count < 0 Then
            Exit Sub
        End If


        If int直前ページ送り区分 = 0 Then
            intカレント行 = intカレント行 - 24
        Else
            intカレント行 = intカレント行 - 47
        End If

        If intカレント行 < 0 Then
            intカレント行 = 0

        ElseIf intカレント行 > Me.dgv生産データ.Rows.Count - 1 Then
            intカレント行 = Me.dgv生産データ.Rows.Count - 1

        End If

        Me.dgv生産データ.CurrentCell = dgv生産データ(0, intカレント行)
        Me.dgv生産データ.CurrentCell = Nothing

        int直前ページ送り区分 = 0
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If Me.dgv生産データ.Rows.Count < 0 Then
            Exit Sub
        End If

        If int直前ページ送り区分 = 1 Then
            intカレント行 = intカレント行 + 24
        Else
            intカレント行 = intカレント行 + 47
        End If

        If intカレント行 > Me.dgv生産データ.Rows.Count - 1 Then
            intカレント行 = Me.dgv生産データ.Rows.Count - 1
        End If

        Me.dgv生産データ.CurrentCell = dgv生産データ(0, intカレント行)
        Me.dgv生産データ.CurrentCell = Nothing

        int直前ページ送り区分 = 1
    End Sub

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        If Me.dgv生産データ.Rows.Count <= 0 Then
            CMsg.gMsg_注意("情報がありません。")
            Exit Sub
        End If
        If CMsg.gMsg_YesNo("棚在庫実績リストを出力してもよろしいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        'グリッドデータを印刷テーブルに登録
        Dim i As Integer = 0
        For i = 0 To Me.dgv生産データ.Rows.Count - 1
            'INSERT 処理
            Try
                With New CSql
                    .gSubClearSQL()
                    .pSQL取得タイプ = CSql.SQL_TYPE.SQL_INSERT
                    .pテーブル名 = "DP印刷"
                    .gSubColumnValue("棚番地", Me.dgv生産データ.Item(0, i).Value.ToString, True)
                    If Me.dgv生産データ.Item(1, i).Value.ToString <> "" Then
                        .gSubColumnValue("ロットNo", Me.dgv生産データ.Item(1, i).Value.ToString, True)
                        .gSubColumnValue("サンプルNo", Me.dgv生産データ.Item(2, i).Value.ToString, False)
                        .gSubColumnValue("品種名", Me.dgv生産データ.Item(3, i).Value.ToString, True)
                        .gSubColumnValue("賞味期限", Me.dgv生産データ.Item(4, i).Value.ToString, True)
                        .gSubColumnValue("受入数", Me.dgv生産データ.Item(5, i).Value.ToString, False)
                        .gSubColumnValue("冷却開始時刻", Me.dgv生産データ.Item(6, i).Value.ToString, True)
                        .gSubColumnValue("所定冷却時間", Me.dgv生産データ.Item(7, i).Value.ToString, True)
                        .gSubColumnValue("冷却経過時間", Me.dgv生産データ.Item(8, i).Value.ToString, True)
                    End If


                    If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                        Exit Sub
                    End If
                End With

            Catch ex As Exception
            Finally
            End Try
        Next

        '印刷データ
        With New CSqlEx
            .gSubSelect("A.棚番地")
            .gSubSelect("A.ロットNo")
            .gSubSelect("A.サンプルNo")
            .gSubSelect("A.品種名")
            .gSubSelect("A.賞味期限")
            .gSubSelect("A.受入数")
            .gSubSelect("A.冷却開始時刻")
            .gSubSelect("A.所定冷却時間")
            .gSubSelect("A.冷却経過時間")
            .gSubFrom("DP印刷 A")
            .gSubOrderBy("管理No")

            CMdiMain.帳票出力(New 棚在庫実績_冷却, "***棚在庫実績（冷却）***", .gSQL文の取得, "")
        End With

        ''印刷データの削除
        Try
            With New CSql
                .gSubClearSQL()
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
                .pテーブル名 = "DP印刷"
                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try

    End Sub
End Class

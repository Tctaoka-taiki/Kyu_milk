
Imports System.Data.Common
Public Class Frm01014_醗酵在庫問合せ
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
    Private Sub Frm01002_醗酵完了出庫設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblロットNo.Text = ""
        Me.lbl品種名.Text = ""

    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim 対象品種CD As String = ""
            Dim 対象ロットNo As String = ""

            Dim dlg As New Dlg01003_製品表示設定
            With dlg
                .ShowDialog()
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    対象品種CD = .txt品種.Text
                    対象ロットNo = .txtロットNo.Text
                    Me.lblロットNo.Text = 対象ロットNo
                    Me.lbl品種名.Text = .lbl品種.Text
                    '画面の再表示
                    醗酵生産品情報(対象品種CD, 対象ロットNo)
                End If
            End With

        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub 醗酵生産品情報(ByVal 品種CD As String, ByVal ロットNo As String)
        Me.dgv生産データ.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("MAX(A.ロットNo COLLATE Japanese_CS_AS_KS_WS)")
                .gSubSelect("MAX(A.サンプルNo)")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("MAX(A.列)")
                .gSubSelect("MAX(A.連)")
                .gSubSelect("MAX(A.段)")
                .gSubSelect("SUM(A.受入数)")
                .gSubSelect("MAX(B.所定醗酵時間)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,醗酵開始時刻,GETDATE()))")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                '---------------------------------
                '醗酵倉庫内のトラッキングを対象とする
                .gSubWhere("A.ステータス >= 6 ")
                .gSubWhere("A.ステータス <= 10 ")
                '---------------------------------
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubWhere("A.品種CD", 品種CD)

                .gSubWhereあいまい検索("A.ロットNo COLLATE Japanese_CS_AS_KS_WS", ロットNo)
                .gSubGroupBy("A.ユニットSEQ")
                .gSubOrderBy("MAX(A.ロットNo COLLATE Japanese_CS_AS_KS_WS)")
                .gSubOrderBy("MAX(A.サンプルNo)")

                Dim i As Integer = 1
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    '合計表示行の作成
                    Dim 合計受入数 As Integer = 0
                    Me.dgv生産データ.Rows.Add()

                    While reader.Read
                        Me.dgv生産データ.Rows.Add()
                        Me.dgv生産データ.Item(0, i).Value = i
                        Me.dgv生産データ.Item(1, i).Value = reader.GetValue(0)
                        Me.dgv生産データ.Item(2, i).Value = reader.GetValue(1)
                        Me.dgv生産データ.Item(3, i).Value = reader.GetValue(2)
                        Me.dgv生産データ.Item(4, i).Value = reader.GetValue(3) & "-" & reader.GetValue(4).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(5)
                        Me.dgv生産データ.Item(5, i).Value = reader.GetValue(6)
                        合計受入数 += reader.GetValue(6)
                        Dim 所定醗酵時間 As Integer = reader.GetValue(7)
                        Dim 醗酵経過時間 As Integer = reader.GetValue(8)
                        Me.dgv生産データ.Item(6, i).Value = 所定醗酵時間 & "分"
                        Me.dgv生産データ.Item(7, i).Value = 醗酵経過時間 & "分"
                        i += 1
                    End While

                    If i > 1 Then
                        Me.dgv生産データ.Rows(0).DefaultCellStyle.BackColor = Color.Yellow
                        Me.dgv生産データ.Item(5, 0).Value = 合計受入数
                    Else
                        'データが無い場合は、クリアする
                        CMsg.gMsg_情報("該当データがありません。")
                        Me.dgv生産データ.Rows.Clear()
                    End If

                End If
            End With
        Catch ex As Exception
        Finally
            Dim intカレント行 As Integer = 0
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
        If CMsg.gMsg_YesNo("在庫実績リストを出力してもよろしいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        'グリッドデータを印刷テーブルに登録
        Dim i As Integer = 0
        '合計値情報は含めない
        For i = 1 To Me.dgv生産データ.Rows.Count - 1
            'INSERT 処理
            Try
                With New CSql
                    .gSubClearSQL()
                    .pSQL取得タイプ = CSql.SQL_TYPE.SQL_INSERT
                    .pテーブル名 = "DP印刷"
                    .gSubColumnValue("ロットNo", Me.dgv生産データ.Item(1, i).Value, True)
                    .gSubColumnValue("サンプルNo", Me.dgv生産データ.Item(2, i).Value, False)
                    .gSubColumnValue("品種名", Me.dgv生産データ.Item(3, i).Value, True)
                    .gSubColumnValue("棚番地", Me.dgv生産データ.Item(4, i).Value, True)
                    .gSubColumnValue("受入数", Me.dgv生産データ.Item(5, i).Value, False)
                    .gSubColumnValue("所定醗酵時間", Me.dgv生産データ.Item(6, i).Value, True)
                    .gSubColumnValue("醗酵経過時間", Me.dgv生産データ.Item(7, i).Value, True)

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
            .gSubSelect("A.ロットNo")
            .gSubSelect("A.サンプルNo")
            .gSubSelect("A.品種名")
            .gSubSelect("A.棚番地")
            .gSubSelect("A.受入数")
            .gSubSelect("A.所定醗酵時間")
            .gSubSelect("A.醗酵経過時間")
            .gSubFrom("DP印刷 A")
            .gSubOrderBy("管理No")

            Dim str条件 As String = "品種CD:" & Me.lbl品種名.Text.PadRight(20, " "c) & "ロットNo:" & Me.lblロットNo.Text.PadRight(10, " "c) & "　クレート合計:" & Me.dgv生産データ.Item(5, 0).Value
            CMdiMain.帳票出力(New 在庫実績_醗酵, "***在庫実績（醗酵）***", .gSQL文の取得, str条件)
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

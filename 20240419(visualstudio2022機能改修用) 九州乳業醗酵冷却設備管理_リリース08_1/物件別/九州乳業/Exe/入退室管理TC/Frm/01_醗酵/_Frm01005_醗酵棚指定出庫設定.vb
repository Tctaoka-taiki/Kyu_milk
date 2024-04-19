
Imports System.Data.Common
Public Class _Frm01005_醗酵棚指定出庫設定
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
    Private Sub Frm01003_醗酵棚指定出庫設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        醗酵生産品情報()

        Me.Timer1.Start()
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)


        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub 醗酵生産品情報()
        Me.dgv生産データ.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("A.ロットNo")
                .gSubSelect("A.サンプルNo")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("MAX(B.所定醗酵時間)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,醗酵開始時刻,GETDATE()))")
                .gSubSelect("MAX(A.ステータス)")
                .gSubSelect("A.出庫中断")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                .gSubWhere("A.ステータス >= 6 ")
                .gSubWhere("A.ステータス <= 9 ")
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubGroupBy("A.ロットNo")
                .gSubGroupBy("A.サンプルNo")
                .gSubGroupBy("A.出庫中断")
                .gSubOrderBy("A.ロットNo")
                .gSubOrderBy("A.サンプルNo")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Me.dgv生産データ.Rows.Add()
                        Me.dgv生産データ.Item(0, i).Value = i + 1
                        Me.dgv生産データ.Item(1, i).Value = reader.GetValue(0)
                        Me.dgv生産データ.Item(2, i).Value = reader.GetValue(1)
                        Me.dgv生産データ.Item(3, i).Value = reader.GetValue(2)
                        Dim 所定醗酵時間 As Integer = reader.GetValue(3)
                        Dim 醗酵経過時間 As Integer = reader.GetValue(4)
                        Me.dgv生産データ.Item(4, i).Value = 所定醗酵時間 & "分"
                        Me.dgv生産データ.Item(5, i).Value = 醗酵経過時間 & "分"

                        Select Case reader.GetValue(5)
                            Case 6
                                If 所定醗酵時間 > 醗酵経過時間 Then
                                    Me.dgv生産データ.Item(6, i).Value = ""
                                Else
                                    Me.dgv生産データ.Item(6, i).Value = "醗酵完了"
                                End If
                            Case 7
                                Me.dgv生産データ.Item(6, i).Value = "出庫待ち"
                            Case 8, 9
                                Me.dgv生産データ.Item(6, i).Value = "出庫中"
                        End Select

                        If reader.GetValue(6) = True Then
                            Me.dgv生産データ.Item(6, i).Value = "中断中"
                        End If
                        i += 1
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            Dim intカレント行 As Integer = 0
            Me.dgv生産データ.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01999_出庫設定
            With dlg
                .m画面モード = 0    '出庫設定モード
                .ShowDialog()
            End With

            '画面の再表示
            醗酵生産品情報()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01999_出庫設定
            With dlg
                .m画面モード = 1    '出庫中断設定モード
                .ShowDialog()
            End With

            '画面の再表示
            醗酵生産品情報()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try

    End Sub
    Private Sub Updateトラッキング_クレーン(ByVal ロットNo As String, ByVal サンプルNo As Integer)
        Try
            'トラッキングデータを更新する
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DNトラッキング"
                .gSubColumnValue("ステータス", 7, False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubWhere("ステータス", 6, , , , , , , False)
                .gSubWhere("ロットNo", ロットNo, , , , , , , False)
                .gSubWhere("サンプルNo", サンプルNo, , , , , , , False)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '画面の再表示
        醗酵生産品情報()
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
End Class

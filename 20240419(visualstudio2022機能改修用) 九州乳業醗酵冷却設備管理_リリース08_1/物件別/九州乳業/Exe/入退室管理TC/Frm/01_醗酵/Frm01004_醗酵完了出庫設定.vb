
Imports System.Data.Common
Public Class Frm01004_醗酵完了出庫設定
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
    Dim フォーカス As String = "ハード"
    Private Sub Frm01002_醗酵完了出庫設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Try
            CMdiMain.gSub処理中設定(Me, True)


            Me.dgv生産データハード.Rows.Clear()
            Me.dgv生産データプレーン.Rows.Clear()

            Dim reader As DbDataReader = Nothing
            Try

                With New CSqlEx
                    .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubSelect("A.サンプルNo")
                    .gSubSelect("MAX(B.品種名)")
                    .gSubSelect("MAX(B.所定醗酵時間)")
                    .gSubSelect("MAX(DATEDIFF(MINUTE,醗酵開始時刻,GETDATE()))")
                    .gSubSelect("MAX(A.ステータス)")
                    .gSubSelect("MAX(A.出庫中断)")
                    .gSubSelect("Count(DISTINCT A.ユニットSEQ)")
                    .gSubSelect("Count(A.管理No)")
                    .gSubFrom("DNトラッキング A")
                    .gSubFrom("DM品種 B")
                    .gSubWhere("A.ステータス >= 6 ")
                    .gSubWhere("A.ステータス <= 9 ")
                    .gSubWhere("A.品種CD = B.品種CD")
                    .gSubWhere("B.製品区分 = 0")
                    .gSubGroupBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubGroupBy("A.サンプルNo")
                    .gSubOrderBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubOrderBy("A.サンプルNo")

                    Dim i As Integer = 0
                    If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                        While reader.Read
                            Me.dgv生産データハード.Rows.Add()
                            Me.dgv生産データハード.Item(0, i).Value = i + 1
                            Me.dgv生産データハード.Item(1, i).Value = reader.GetValue(0)
                            Me.dgv生産データハード.Item(2, i).Value = reader.GetValue(1)
                            Me.dgv生産データハード.Item(3, i).Value = reader.GetValue(2)
                            Dim 所定醗酵時間 As Integer = reader.GetValue(3)
                            Dim 醗酵経過時間 As Integer = reader.GetValue(4)
                            Me.dgv生産データハード.Item(4, i).Value = 所定醗酵時間 & "分"
                            Me.dgv生産データハード.Item(5, i).Value = 醗酵経過時間 & "分"

                            Select Case reader.GetValue(5)
                                Case 6
                                    If 所定醗酵時間 > 醗酵経過時間 Then
                                        Me.dgv生産データハード.Item(6, i).Value = ""
                                    Else
                                        Me.dgv生産データハード.Item(6, i).Value = "醗酵完了"
                                    End If
                                Case 7
                                    Me.dgv生産データハード.Item(6, i).Value = "出庫待ち"
                                Case 8, 9
                                    Me.dgv生産データハード.Item(6, i).Value = "出庫中"
                            End Select

                            If reader.GetValue(6) = 1 Then
                                Me.dgv生産データハード.Item(6, i).Value = "中断中"
                            End If
                            Me.dgv生産データハード.Item(7, i).Value = reader.GetValue(7)
                            Me.dgv生産データハード.Item(8, i).Value = reader.GetValue(8)
                            i += 1
                        End While
                    End If
                End With
                intカレント行 = 0
                Me.dgv生産データハード.CurrentCell = Nothing
                CUsrctl.gDp.gSubReaderClose(reader)

                With New CSqlEx
                    .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubSelect("A.サンプルNo")
                    .gSubSelect("MAX(B.品種名)")
                    .gSubSelect("MAX(B.所定醗酵時間)")
                    .gSubSelect("MAX(DATEDIFF(MINUTE,醗酵開始時刻,GETDATE()))")
                    .gSubSelect("MAX(A.ステータス)")
                    .gSubSelect("MAX(A.出庫中断)")
                    .gSubSelect("Count(DISTINCT A.ユニットSEQ)")
                    .gSubSelect("Count(A.管理No)")
                    .gSubFrom("DNトラッキング A")
                    .gSubFrom("DM品種 B")
                    .gSubWhere("A.ステータス >= 6 ")
                    .gSubWhere("A.ステータス <= 9 ")
                    .gSubWhere("A.品種CD = B.品種CD")
                    .gSubWhere("B.製品区分 = 1")
                    .gSubGroupBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubGroupBy("A.サンプルNo")
                    .gSubOrderBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubOrderBy("A.サンプルNo")

                    Dim i As Integer = 0
                    If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                        While reader.Read
                            Me.dgv生産データプレーン.Rows.Add()
                            Me.dgv生産データプレーン.Item(0, i).Value = i + 1
                            Me.dgv生産データプレーン.Item(1, i).Value = reader.GetValue(0)
                            Me.dgv生産データプレーン.Item(2, i).Value = reader.GetValue(1)
                            Me.dgv生産データプレーン.Item(3, i).Value = reader.GetValue(2)
                            Dim 所定醗酵時間 As Integer = reader.GetValue(3)
                            Dim 醗酵経過時間 As Integer = reader.GetValue(4)
                            Me.dgv生産データプレーン.Item(4, i).Value = 所定醗酵時間 & "分"
                            Me.dgv生産データプレーン.Item(5, i).Value = 醗酵経過時間 & "分"

                            Select Case reader.GetValue(5)
                                Case 6
                                    If 所定醗酵時間 > 醗酵経過時間 Then
                                        Me.dgv生産データプレーン.Item(6, i).Value = ""
                                    Else
                                        Me.dgv生産データプレーン.Item(6, i).Value = "醗酵完了"
                                    End If
                                Case 7
                                    Me.dgv生産データプレーン.Item(6, i).Value = "出庫待ち"
                                Case 8, 9
                                    Me.dgv生産データプレーン.Item(6, i).Value = "出庫中"
                            End Select

                            If reader.GetValue(6) = 1 Then
                                Me.dgv生産データプレーン.Item(6, i).Value = "中断中"
                            End If
                            Me.dgv生産データプレーン.Item(7, i).Value = reader.GetValue(7)
                            Me.dgv生産データプレーン.Item(8, i).Value = reader.GetValue(8)
                            i += 1
                        End While
                    End If
                End With
            Catch ex As Exception
            Finally

                Me.dgv生産データプレーン.CurrentCell = Nothing
                CUsrctl.gDp.gSubReaderClose(reader)
            End Try
        Catch ex As Exception
        Finally
            CMdiMain.gSub処理中設定(Me, False)
        End Try

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01004_出庫設定
            With dlg
                .m画面モード = 0    '出庫設定モード
                .btnF1.Enabled = False
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
            Dim dlg As New Dlg01004_出庫設定
            With dlg
                .m画面モード = 1    '出庫中断設定モード
                .btnF1.Enabled = False
                .ShowDialog()
            End With

            '画面の再表示
            醗酵生産品情報()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '画面の再表示
        醗酵生産品情報()
    End Sub

    Dim int直前ページ送り区分 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click


        If フォーカス Is "ハード" Then
            If Me.dgv生産データハード.Rows.Count < 0 Then
                Exit Sub
            End If


            If int直前ページ送り区分 = 0 Then
                intカレント行 = intカレント行 - 10
            Else
                intカレント行 = intカレント行 - 19
            End If

            If intカレント行 < 0 Then
                intカレント行 = 0

            ElseIf intカレント行 > Me.dgv生産データハード.Rows.Count - 1 Then
                intカレント行 = Me.dgv生産データハード.Rows.Count - 1

            End If

            Me.dgv生産データハード.CurrentCell = dgv生産データハード(0, intカレント行)
            Me.dgv生産データハード.CurrentCell = Nothing

            int直前ページ送り区分 = 0
        ElseIf フォーカス Is "プレーン" Then
            If Me.dgv生産データプレーン.Rows.Count < 0 Then
                Exit Sub
            End If


            If int直前ページ送り区分 = 0 Then
                intカレント行 = intカレント行 - 10
            Else
                intカレント行 = intカレント行 - 19
            End If

            If intカレント行 < 0 Then
                intカレント行 = 0

            ElseIf intカレント行 > Me.dgv生産データプレーン.Rows.Count - 1 Then
                intカレント行 = Me.dgv生産データプレーン.Rows.Count - 1

            End If

            Me.dgv生産データプレーン.CurrentCell = dgv生産データプレーン(0, intカレント行)
            Me.dgv生産データプレーン.CurrentCell = Nothing

            int直前ページ送り区分 = 0
        End If

    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If フォーカス Is "ハード" Then
            If Me.dgv生産データハード.Rows.Count < 0 Then
                Exit Sub
            End If

            If int直前ページ送り区分 = 1 Then
                intカレント行 = intカレント行 + 10
            Else
                intカレント行 = intカレント行 + 19
            End If

            If intカレント行 > Me.dgv生産データハード.Rows.Count - 1 Then
                intカレント行 = Me.dgv生産データハード.Rows.Count - 1
            End If

            Me.dgv生産データハード.CurrentCell = dgv生産データハード(0, intカレント行)
            Me.dgv生産データハード.CurrentCell = Nothing

            int直前ページ送り区分 = 1
        ElseIf フォーカス Is "プレーン" Then
            If Me.dgv生産データプレーン.Rows.Count < 0 Then
                Exit Sub
            End If

            If int直前ページ送り区分 = 1 Then
                intカレント行 = intカレント行 + 10
            Else
                intカレント行 = intカレント行 + 19
            End If

            If intカレント行 > Me.dgv生産データプレーン.Rows.Count - 1 Then
                intカレント行 = Me.dgv生産データプレーン.Rows.Count - 1
            End If

            Me.dgv生産データプレーン.CurrentCell = dgv生産データプレーン(0, intカレント行)
            Me.dgv生産データプレーン.CurrentCell = Nothing

            int直前ページ送り区分 = 1
        End If
    End Sub

    Private Sub dgv生産データハード_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv生産データハード.DoubleClick
        If Me.dgv生産データハード.RowCount <= 0 Then
            Exit Sub
        End If

        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01004_出庫設定
            With dlg
                .m画面モード = 0    '出庫設定モード
                .txtロットNo.Text = Me.dgv生産データハード.Item(1, Me.dgv生産データハード.CurrentRow.Index).Value
                .txtサンプルNo.Text = Me.dgv生産データハード.Item(2, Me.dgv生産データハード.CurrentRow.Index).Value
                .lbl品種名.Text = Me.dgv生産データハード.Item(3, Me.dgv生産データハード.CurrentRow.Index).Value
                .lbl所定醗酵時間.Text = Me.dgv生産データハード.Item(4, Me.dgv生産データハード.CurrentRow.Index).Value
                .lbl醗酵経過時間.Text = Me.dgv生産データハード.Item(5, Me.dgv生産データハード.CurrentRow.Index).Value
                .btnF1.Focus()

                .ShowDialog()
            End With

            '画面の再表示
            醗酵生産品情報()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try

    End Sub
    Private Sub dgv生産データプレーン_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv生産データプレーン.DoubleClick
        If Me.dgv生産データプレーン.RowCount <= 0 Then
            Exit Sub
        End If

        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01004_出庫設定
            With dlg
                .m画面モード = 0    '出庫設定モード
                .txtロットNo.Text = Me.dgv生産データプレーン.Item(1, Me.dgv生産データプレーン.CurrentRow.Index).Value
                .txtサンプルNo.Text = Me.dgv生産データプレーン.Item(2, Me.dgv生産データプレーン.CurrentRow.Index).Value
                .lbl品種名.Text = Me.dgv生産データプレーン.Item(3, Me.dgv生産データプレーン.CurrentRow.Index).Value
                .lbl所定醗酵時間.Text = Me.dgv生産データプレーン.Item(4, Me.dgv生産データプレーン.CurrentRow.Index).Value
                .lbl醗酵経過時間.Text = Me.dgv生産データプレーン.Item(5, Me.dgv生産データプレーン.CurrentRow.Index).Value
                .btnF1.Focus()

                .ShowDialog()
            End With

            '画面の再表示
            醗酵生産品情報()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try

    End Sub

    Private Sub dgv生産データハード_Enter(sender As Object, e As EventArgs) Handles dgv生産データハード.Enter
        フォーカス = "ハード"
    End Sub

    Private Sub dgv生産データプレーン_Enter(sender As Object, e As EventArgs) Handles dgv生産データプレーン.Enter
        フォーカス = "プレーン"
    End Sub
End Class

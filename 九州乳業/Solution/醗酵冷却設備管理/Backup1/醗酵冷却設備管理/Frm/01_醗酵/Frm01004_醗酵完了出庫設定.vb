
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


            Me.dgv生産データ.Rows.Clear()

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
                    .gSubFrom("DNトラッキング A")
                    .gSubFrom("DM品種 B")
                    .gSubWhere("A.ステータス >= 6 ")
                    .gSubWhere("A.ステータス <= 9 ")
                    .gSubWhere("A.品種CD = B.品種CD")
                    .gSubGroupBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubGroupBy("A.サンプルNo")
                    .gSubOrderBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
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

                            If reader.GetValue(6) = 1 Then
                                Me.dgv生産データ.Item(6, i).Value = "中断中"
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

    Private Sub dgv生産データ_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv生産データ.DoubleClick
        If Me.dgv生産データ.RowCount <= 0 Then
            Exit Sub
        End If

        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01004_出庫設定
            With dlg
                .m画面モード = 0    '出庫設定モード
                .txtロットNo.Text = Me.dgv生産データ.Item(1, Me.dgv生産データ.CurrentRow.Index).Value
                .txtサンプルNo.Text = Me.dgv生産データ.Item(2, Me.dgv生産データ.CurrentRow.Index).Value
                .lbl品種名.Text = Me.dgv生産データ.Item(3, Me.dgv生産データ.CurrentRow.Index).Value
                .lbl所定醗酵時間.Text = Me.dgv生産データ.Item(4, Me.dgv生産データ.CurrentRow.Index).Value
                .lbl醗酵経過時間.Text = Me.dgv生産データ.Item(5, Me.dgv生産データ.CurrentRow.Index).Value
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
End Class

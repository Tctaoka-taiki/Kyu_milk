
Imports System.Data.Common

Public Class Frm02001_冷却完了出庫設定
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

    Private Sub Frm02001_冷却完了出庫設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        冷却生産品情報()

        Me.Timer1.Start()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Me.Timer1.Stop()

        Try
            '
            Dim dlg As New Dlg01999_冷却出庫設定
            With dlg
                .m画面モード = 0
                .btnF1.Enabled = False
                .ShowDialog()

            End With

            '画面の再表示
            冷却生産品情報()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Me.Timer1.Stop()

        Try
            '
            Dim dlg As New Dlg01999_冷却出庫設定
            With dlg
                .m画面モード = 1
                .btnF1.Enabled = False
                .ShowDialog()

            End With

            '画面の再表示
            冷却生産品情報()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.冷却メインメニュー)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '画面の再表示
        冷却生産品情報()
    End Sub

    Private Sub 冷却生産品情報()
        Me.dgv生産データ.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("MAX(B.所定冷却時間)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,冷却開始時刻,GETDATE()))")
                .gSubSelect("MAX(A.ステータス)")
                .gSubSelect("MAX(A.出庫中断_冷)")
                .gSubSelect("MAX(A.出庫指示)")
                .gSubSelect("Count(DISTINCT A.ユニットSEQ)")
                .gSubSelect("SUM(A.受入数)")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                .gSubWhere("A.ステータス >= 27 ")
                .gSubWhere("A.ステータス <= 30 ")
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubGroupBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubOrderBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Me.dgv生産データ.Rows.Add()
                        Me.dgv生産データ.Item(0, i).Value = i + 1
                        Me.dgv生産データ.Item(1, i).Value = reader.GetValue(0)
                        Me.dgv生産データ.Item(2, i).Value = reader.GetValue(1)
                        Dim 所定冷却時間 As Integer = reader.GetValue(2)
                        Dim 冷却経過時間 As Integer = reader.GetValue(3)
                        Me.dgv生産データ.Item(3, i).Value = 所定冷却時間 & "分"
                        Me.dgv生産データ.Item(4, i).Value = 冷却経過時間 & "分"

                        Me.dgv生産データ.Item(6, i).Value = "0"
                        Select Case reader.GetValue(4)
                            Case 27
                                If 所定冷却時間 > 冷却経過時間 Then
                                    Me.dgv生産データ.Item(5, i).Value = ""
                                Else
                                    Me.dgv生産データ.Item(5, i).Value = "冷却完了"
                                    Me.dgv生産データ.Item(6, i).Value = "1"
                                End If

                                If reader.GetValue(6) = 1 Then
                                    Me.dgv生産データ.Item(5, i).Value = "出庫待ち"

                                End If

                            Case 28
                                Me.dgv生産データ.Item(5, i).Value = "出庫待ち"
                            Case 29, 30
                                Me.dgv生産データ.Item(5, i).Value = "出庫中"
                        End Select
                        If reader.GetValue(5) = 1 Then
                            Me.dgv生産データ.Item(5, i).Value = "中断中"

                        End If
                        Me.dgv生産データ.Item(7, i).Value = reader.GetValue(7)
                        Me.dgv生産データ.Item(8, i).Value = reader.GetValue(8)
                        i += 1
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            Me.dgv生産データ.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub dgv生産データ_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv生産データ.DoubleClick
        Me.Timer1.Stop()

        Try
            If Me.dgv生産データ.Item(5, Me.dgv生産データ.CurrentRow.Index).Value = "出庫待ち" Then
                Dim dlg As New Dlg01999_冷却出庫設定
                With dlg
                    .m画面モード = 1    '出庫中断設定モード
                    .btnF1.Enabled = False
                    .txtロットNo.Text = Me.dgv生産データ.Item(1, Me.dgv生産データ.CurrentRow.Index).Value
                    .ShowDialog()
                End With
            Else
                Dim dlg As New Dlg01999_冷却出庫設定
                With dlg
                    .m画面モード = 0
                    .txtロットNo.Text = Me.dgv生産データ.Item(1, Me.dgv生産データ.CurrentRow.Index).Value
                    .lbl品種名.Text = Me.dgv生産データ.Item(2, Me.dgv生産データ.CurrentRow.Index).Value
                    .lbl所定醗酵時間.Text = Me.dgv生産データ.Item(3, Me.dgv生産データ.CurrentRow.Index).Value
                    .lbl醗酵経過時間.Text = Me.dgv生産データ.Item(4, Me.dgv生産データ.CurrentRow.Index).Value
                    .btnF1.Enabled = True
                    .ShowDialog()

                End With
            End If
        Catch ex As Exception
        Finally
            '画面の再表示
            冷却生産品情報()
            Me.Timer1.Start()
        End Try
    End Sub
End Class

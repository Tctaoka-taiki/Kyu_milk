
Imports System.Data.Common

Public Class Frm02002_冷却棚指定出庫設定
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
    Private Sub Frm02002_冷却棚指定出庫設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        倉庫情報表示()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        倉庫情報表示()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Timer1.Stop()

        Try
            Dim dlg As New Dlg01005_棚指定出庫登録
            With dlg
                .m画面モード = 1
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Timer1.Stop()
        Try
            Dim dlg As New Dlg01005_棚指定出庫削除
            With dlg
                .m画面モード = 1
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Timer1.Stop()
        Try
            Dim dlg As New Dlg01005_棚指定出庫開始
            With dlg
                .m画面モード = 1
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Timer1.Stop()
        Try
            Dim dlg As New Dlg01005_棚指定出庫中断
            With dlg
                .m画面モード = 1
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally
            Timer1.Start()
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
                .gSubSelect("MAX(A.列) as 列")
                .gSubSelect("MAX(A.連) as 連")
                .gSubSelect("MAX(A.段) as 段")
                .gSubSelect("MAX(A.ロットNo COLLATE Japanese_CS_AS_KS_WS) as ロットNo")
                .gSubSelect("MAX(A.サンプルNo) as サンプルNo")
                .gSubSelect("MAX(B.品種名) as 品種名")
                .gSubSelect("MAX(A.賞味期限) as 賞味期限")
                .gSubSelect("SUM(A.受入数) as クレート数")
                .gSubSelect("MAX(A.冷却開始時刻) as 開始時刻")
                .gSubSelect("MAX(B.所定冷却時間) as 所定時刻")
                .gSubSelect("MAX(A.ステータス) as ステータス")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                '---------------------------------
                '醗酵倉庫内のトラッキングを対象とする
                '27:在庫中(---)
                '28:出荷指示確定状態（開始）
                '29,30:出荷中(出庫中)
                '31:出庫ST(完了)
                .gSubWhere("(A.ステータス >= 27 AND A.ステータス <= 31)")
                .gSubWhere("A.棚指定出庫 = 1")
                '---------------------------------
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubGroupBy("A.ユニットSEQ")
                .gSubOrderBy("列,連,段")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
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
                        Select Case reader.GetValue(10)
                            Case 27
                                Me.dgv生産データ.Item(8, i).Value = ""
                            Case 28
                                Me.dgv生産データ.Item(8, i).Value = "開始"
                            Case 29, 30
                                Me.dgv生産データ.Item(8, i).Value = "出庫中"
                            Case 31
                                Me.dgv生産データ.Item(8, i).Value = "完了"
                        End Select
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

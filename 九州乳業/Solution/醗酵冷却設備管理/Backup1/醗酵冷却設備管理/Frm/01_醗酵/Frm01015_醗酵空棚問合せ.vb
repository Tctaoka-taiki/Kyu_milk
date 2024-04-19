
Imports System.Data.Common
Public Class Frm01015_醗酵空棚問合せ
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

    Private Sub Frm00009_空棚問合せ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '初期化
        画面初期化()

        'データ更新
        棚状況表示(1)
        棚状況表示(2)

        Timer1.Start()
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub 画面初期化()
        Dim i As Integer
        Dim j As Integer
        For i = 0 To 3
            dgv列1.Rows.Add()
            dgv列1(0, i).Value = "段" & (4 - i)
            For j = 1 To 28
                dgv列1.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv列1.Columns(j).Width = 30
                dgv列1(j, i).Value = "□"
            Next
        Next
        dgv列1.CurrentCell = Nothing

        For i = 0 To 3
            dgv列2.Rows.Add()
            dgv列2(0, i).Value = "段" & (4 - i)
            For j = 1 To 28
                dgv列2.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv列2.Columns(j).Width = 30
                dgv列2(j, i).Value = "□"
            Next
        Next
        dgv列2.CurrentCell = Nothing

    End Sub

    Private Sub 棚状況表示(ByVal int列 As Integer)
        Dim reader As DbDataReader = Nothing
        Try
            '禁止棚、ST情報の表示
            With New CSqlEx
                .gSubSelect("A.連")
                .gSubSelect("A.段")
                .gSubSelect("A.棚区分")
                .gSubFrom("DM棚 A")
                .gSubWhere("A.倉庫区分 = 0")
                .gSubWhere("A.列", int列, , , , , , , , )
                .gSubOrderBy("A.連")
                .gSubOrderBy("A.段 DESC")

                Dim 連 As Integer
                Dim 段 As Integer
                Dim 棚区分 As String
                Dim 表示データ As String = ""
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        連 = reader.GetValue(0)
                        段 = reader.GetValue(1)

                        棚区分 = reader.GetValue(2)
                        Select Case 棚区分
                            Case 0
                                '一旦無条件で、□を表示
                                表示データ = "□"
                            Case 1
                                表示データ = "Ｓ"
                            Case 2
                                表示データ = "＊"
                            Case 3
                                表示データ = "△"
                        End Select

                        Select Case int列
                            Case 1
                                dgv列1.Item(連, 4 - 段).Value = 表示データ

                            Case 2
                                dgv列2.Item(連, 4 - 段).Value = 表示データ

                        End Select

                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Try
            '棚利用状況の表示
            With New CSqlEx
                .gSubSelect("A.連")
                .gSubSelect("A.段")
                .gSubFrom("DNトラッキング A")
                .gSubWhere("A.ステータス >= 6")
                .gSubWhere("A.ステータス < 20")
                .gSubWhere("A.列", int列, , , , , , , , )
                .gSubOrderBy("A.連")
                .gSubOrderBy("A.段 DESC")

                Dim 連 As Integer
                Dim 段 As Integer
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        連 = reader.GetValue(0)
                        段 = reader.GetValue(1)

                        Select Case int列
                            Case 1
                                dgv列1.Item(連, 4 - 段).Value = "■"

                            Case 2
                                dgv列2.Item(連, 4 - 段).Value = "■"

                        End Select

                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'データ更新
        棚状況表示(1)
        棚状況表示(2)
    End Sub
End Class

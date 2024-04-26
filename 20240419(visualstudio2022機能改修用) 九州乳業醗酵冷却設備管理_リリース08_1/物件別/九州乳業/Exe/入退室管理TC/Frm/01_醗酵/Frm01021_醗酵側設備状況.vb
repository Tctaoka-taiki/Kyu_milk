
Imports System.Data.Common
Public Class Frm00003_醗酵側設備状況
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Dim dbl発酵室温度傾き As Double = CUtil.設定関連.設定文字列読込("発酵室温度傾き", 1)
    Dim dbl発酵室温度切片 As Double = CUtil.設定関連.設定文字列読込("発酵室温度切片", 0)
    Dim dbl急冷室温度傾き As Double = CUtil.設定関連.設定文字列読込("急冷室温度傾き", 1)
    Dim dbl急冷室温度切片 As Double = CUtil.設定関連.設定文字列読込("急冷室温度切片", 0)
    Dim dbl冷却室温度傾き As Double = CUtil.設定関連.設定文字列読込("冷却室温度傾き", 1)
    Dim dbl冷却室温度切片 As Double = CUtil.設定関連.設定文字列読込("冷却室温度切片", 0)

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

    Private Sub Frm00002_設備状況_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To 17
            dgv設備状況.Rows.Add()
        Next

        For i = 0 To 2
            dgv設備状況共通.Rows.Add()
            dgv設備状況共通(0, i).Value = i + 21
            dgv設備状況共通(1, i).Value = str設備名称(i + 10)
        Next


        dgv設備状況.CurrentCell = Nothing
        dgv設備状況共通.CurrentCell = Nothing
        Me.cmbライン.Text = "プレーン１・ハード２"
        設備状況更新()
        Timer1.Interval = 2000
        Timer1.Start()

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Timer1.Stop()

            Dim dlg As New Dlg01999_トラッキング削除
            With dlg
                .m画面モード = 0
                .ShowDialog()
            End With

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Dim intSelectIDX As Integer = Me.cmbライン.SelectedIndex
        If intSelectIDX = 1 Then
            intSelectIDX = 0
        Else
            intSelectIDX += 1
        End If
        Me.cmbライン.SelectedIndex = intSelectIDX

    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)


        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        設備状況更新()
    End Sub

    Private Sub cmbライン_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbライン.SelectedIndexChanged

        設備状況更新()
    End Sub

    Private Sub 設備状況更新()
        Dim デバイスOFFSET As Integer
        Dim 製造ライン As Integer = 0

        Try

            Select Case Me.cmbライン.Text
                Case "ハード１"
                    Dim n As Integer
                    For n = 9 To 17
                        Me.dgv設備状況.Item(0, n).Value = ""
                        Me.dgv設備状況.Item(1, n).Value = ""
                        Me.dgv設備状況.Item(2, n).Value = ""
                        Me.dgv設備状況.Item(3, n).Value = ""
                        Me.dgv設備状況.Item(9, n).Value = ""
                    Next
                    デバイスOFFSET = 6000
                    製造ライン = 0
                    Dim i As Integer = 0
                    For i = 0 To 8
                        dgv設備状況(0, i).Value = i + 1
                        dgv設備状況(1, i).Value = str設備名称(i + 1)
                    Next
                    For i = 0 To 17
                        Me.dgv設備状況.Item(4, i).Value = ""
                        Me.dgv設備状況.Item(5, i).Value = ""
                        Me.dgv設備状況.Item(6, i).Value = ""
                        Me.dgv設備状況.Item(7, i).Value = ""
                        Me.dgv設備状況.Item(8, i).Value = ""
                        Me.dgv設備状況.Item(9, i).Value = ""
                    Next
                    表示処理(デバイスOFFSET, 製造ライン, 0)
                Case "プレーン１・ハード２"
                    デバイスOFFSET = 6004
                    製造ライン = 1
                    Dim i As Integer = 0
                    For i = 0 To 8
                        dgv設備状況(0, i).Value = i + 11
                        dgv設備状況(1, i).Value = str設備名称(i + 1)
                    Next
                    For i = 0 To 8
                        Me.dgv設備状況.Item(4, i).Value = ""
                        Me.dgv設備状況.Item(5, i).Value = ""
                        Me.dgv設備状況.Item(6, i).Value = ""
                        Me.dgv設備状況.Item(7, i).Value = ""
                        Me.dgv設備状況.Item(8, i).Value = ""
                        Me.dgv設備状況.Item(9, i).Value = ""
                    Next
                    表示処理(デバイスOFFSET, 製造ライン, 0)
                    デバイスOFFSET = 6010
                    製造ライン = 2
                    i = 0
                    For i = 0 To 8
                        dgv設備状況(0, i + 9).Value = i + 31
                        dgv設備状況(1, i + 9).Value = str設備名称(i + 1)
                    Next
                    For i = 9 To 17
                        Me.dgv設備状況.Item(4, i).Value = ""
                        Me.dgv設備状況.Item(5, i).Value = ""
                        Me.dgv設備状況.Item(6, i).Value = ""
                        Me.dgv設備状況.Item(7, i).Value = ""
                        Me.dgv設備状況.Item(8, i).Value = ""
                        Me.dgv設備状況.Item(9, i).Value = ""
                    Next
                    表示処理(デバイスOFFSET, 製造ライン, 9)
                    'Case "プレーン１"
                    '    デバイスOFFSET = 6004
                    '    製造ライン = 1
                    '    Dim i As Integer = 0
                    '    For i = 0 To 8
                    '        dgv設備状況(0, i).Value = i + 11
                    '        dgv設備状況(1, i).Value = str設備名称(i + 1)
                    '    Next
                    'Case "ハード２"
                    '    デバイスOFFSET = 6010
                    '    製造ライン = 2
                    '    Dim i As Integer = 0
                    '    For i = 0 To 8
                    '        dgv設備状況(0, i).Value = i + 31
                    '        dgv設備状況(1, i).Value = str設備名称(i + 1)
                    '    Next
            End Select



            '設備温度表示
            lbl醗酵倉庫温度.Text = Format(Int((Dbl温度データ取得(0, 6009) - dbl発酵室温度切片) / dbl発酵室温度傾き * 10) / 10, "0.0")
            lbl冷却倉庫温度.Text = Format(Int((Dbl温度データ取得(1, 6009) - dbl冷却室温度切片) / dbl冷却室温度傾き * 10) / 10, "0.0")
            lbl急冷室温度.Text = Format(Int((Dbl温度データ取得(1, 6010) - dbl急冷室温度切片) / dbl急冷室温度傾き * 10) / 10, "0.0")

        Catch ex As Exception

        End Try

    End Sub
    Private Sub 表示処理(ByVal デバイスOFFSET As Integer, ByVal 製造ライン As Integer, ByVal 開始行数 As Integer)
        '段積機
        信号情報更新_ライン別(0, デバイスOFFSET + 1, 0, 開始行数)
        荷情報更新_ライン別(0, デバイスOFFSET + 1, 2, 0, 開始行数)

        'コンベヤ
        信号情報更新_ライン別(0, デバイスOFFSET + 2, 1, 開始行数)

        荷情報更新_ライン別(0, デバイスOFFSET + 2, 4, 3, 開始行数)
        荷情報更新_ライン別(0, デバイスOFFSET + 2, 3, 4, 開始行数)
        荷情報更新_ライン別(0, デバイスOFFSET + 2, 2, 5, 開始行数)

        '入庫ST
        信号情報更新_ライン別(0, デバイスOFFSET + 3, 6, 開始行数)
        信号情報更新_ライン別(0, デバイスOFFSET + 3, 7, 開始行数)
        信号情報更新_ライン別(0, デバイスOFFSET + 3, 8, 開始行数)

        荷情報更新_ライン別(0, デバイスOFFSET + 3, 4, 6, 開始行数)
        荷情報更新_ライン別(0, デバイスOFFSET + 3, 3, 7, 開始行数)
        荷情報更新_ライン別(0, デバイスOFFSET + 3, 2, 8, 開始行数)

        'クレーン(不明)
        クレーン信号情報更新(0, 5002, 0)

        '出庫ST
        信号情報更新_共通(0, 6008, 1)
        荷情報更新_共通(0, 6008, 2, 1)

        '冷却室前
        信号情報更新_共通(1, 6000, 2)
        荷情報更新_共通(1, 6000, 2, 2)

        'トラッキングデータ表示
        トラッキング情報更新(製造ライン, 開始行数)
    End Sub
    Private Sub トラッキング情報更新(ByVal 製造ライン As Integer, ByVal 開始行数 As Integer)
        Dim i As Integer = 0

        For i = 0 To 2
            Me.dgv設備状況共通.Item(4, i).Value = ""
            Me.dgv設備状況共通.Item(5, i).Value = ""
            Me.dgv設備状況共通.Item(6, i).Value = ""
            Me.dgv設備状況共通.Item(7, i).Value = ""
            Me.dgv設備状況共通.Item(8, i).Value = ""
        Next

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("A.ステータス")
                .gSubSelect("B.品種名")
                .gSubSelect("A.受入数")
                .gSubSelect("A.サンプルNo")
                .gSubSelect("A.STNO")
                .gSubSelect("A.列")
                .gSubSelect("A.連")
                .gSubSelect("A.段")
                .gSubSelect("A.ロットNo")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                .gSubWhere("A.製造ライン", 製造ライン, , , , , , , False)
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubWhere("A.ステータス < 5")
                .gSubOrderBy("A.更新日時")

                Dim コンベヤCNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read

                        Select Case reader.GetValue(0)
                            Case 0  '段積機データ
                                Me.dgv設備状況.Item(4, 0 + 開始行数).Value = reader.GetValue(1)
                                Me.dgv設備状況.Item(5, 0 + 開始行数).Value = reader.GetValue(2)
                                Me.dgv設備状況.Item(6, 0 + 開始行数).Value = reader.GetValue(3)
                                Me.dgv設備状況.Item(9, 0 + 開始行数).Value = reader.GetValue(8)

                            Case 1  'コンベヤデータ ※複数データがストックされる場合がある
                                Me.dgv設備状況.Item(4, 5 - コンベヤCNT + 開始行数).Value = reader.GetValue(1)
                                Me.dgv設備状況.Item(5, 5 - コンベヤCNT + 開始行数).Value = reader.GetValue(2)
                                Me.dgv設備状況.Item(6, 5 - コンベヤCNT + 開始行数).Value = reader.GetValue(3)
                                Me.dgv設備状況.Item(9, 5 - コンベヤCNT + 開始行数).Value = reader.GetValue(8)

                                コンベヤCNT += 1
                            Case 2
                                Select Case reader.GetValue(4)
                                    Case 3
                                        Me.dgv設備状況.Item(4, 8 + 開始行数).Value = reader.GetValue(1)
                                        Me.dgv設備状況.Item(5, 8 + 開始行数).Value = reader.GetValue(2)
                                        Me.dgv設備状況.Item(6, 8 + 開始行数).Value = reader.GetValue(3)
                                        Me.dgv設備状況.Item(9, 8 + 開始行数).Value = reader.GetValue(8)
                                    Case 2
                                        Me.dgv設備状況.Item(4, 7 + 開始行数).Value = reader.GetValue(1)
                                        Me.dgv設備状況.Item(5, 7 + 開始行数).Value = reader.GetValue(2)
                                        Me.dgv設備状況.Item(6, 7 + 開始行数).Value = reader.GetValue(3)
                                        Me.dgv設備状況.Item(9, 7 + 開始行数).Value = reader.GetValue(8)
                                    Case 1
                                        Me.dgv設備状況.Item(4, 6 + 開始行数).Value = reader.GetValue(1)
                                        Me.dgv設備状況.Item(5, 6 + 開始行数).Value = reader.GetValue(2)
                                        Me.dgv設備状況.Item(6, 6 + 開始行数).Value = reader.GetValue(3)
                                        Me.dgv設備状況.Item(9, 6 + 開始行数).Value = reader.GetValue(8)
                                End Select

                            Case 3 'クレーン指示予約
                                Select Case reader.GetValue(4)
                                    Case 3
                                        Me.dgv設備状況.Item(4, 8 + 開始行数).Value = reader.GetValue(1)
                                        Me.dgv設備状況.Item(5, 8 + 開始行数).Value = reader.GetValue(2)
                                        Me.dgv設備状況.Item(6, 8 + 開始行数).Value = reader.GetValue(3)
                                        Me.dgv設備状況.Item(7, 8 + 開始行数).Value = reader.GetValue(5) & "-" & reader.GetValue(6).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(7)
                                        Me.dgv設備状況.Item(9, 8 + 開始行数).Value = reader.GetValue(8)
                                    Case 2
                                        Me.dgv設備状況.Item(4, 7 + 開始行数).Value = reader.GetValue(1)
                                        Me.dgv設備状況.Item(5, 7 + 開始行数).Value = reader.GetValue(2)
                                        Me.dgv設備状況.Item(6, 7 + 開始行数).Value = reader.GetValue(3)
                                        Me.dgv設備状況.Item(9, 7 + 開始行数).Value = reader.GetValue(8)
                                    Case 1
                                        Me.dgv設備状況.Item(4, 6 + 開始行数).Value = reader.GetValue(1)
                                        Me.dgv設備状況.Item(5, 6 + 開始行数).Value = reader.GetValue(2)
                                        Me.dgv設備状況.Item(6, 6 + 開始行数).Value = reader.GetValue(3)
                                        Me.dgv設備状況.Item(9, 6 + 開始行数).Value = reader.GetValue(8)
                                End Select

                            Case 4  'クレーン指示送信中
                                Select Case reader.GetValue(4)
                                    Case 3
                                        Me.dgv設備状況.Item(4, 8 + 開始行数).Value = reader.GetValue(1)
                                        Me.dgv設備状況.Item(5, 8 + 開始行数).Value = reader.GetValue(2)
                                        Me.dgv設備状況.Item(6, 8 + 開始行数).Value = reader.GetValue(3)
                                        Me.dgv設備状況.Item(7, 8 + 開始行数).Value = reader.GetValue(5) & "-" & reader.GetValue(6).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(7)
                                        Me.dgv設備状況.Item(9, 8 + 開始行数).Value = reader.GetValue(8)
                                    Case 2
                                        Me.dgv設備状況.Item(4, 7 + 開始行数).Value = reader.GetValue(1)
                                        Me.dgv設備状況.Item(5, 7 + 開始行数).Value = reader.GetValue(2)
                                        Me.dgv設備状況.Item(6, 7 + 開始行数).Value = reader.GetValue(3)
                                        Me.dgv設備状況.Item(9, 7 + 開始行数).Value = reader.GetValue(8)
                                    Case 1
                                        Me.dgv設備状況.Item(4, 6 + 開始行数).Value = reader.GetValue(1)
                                        Me.dgv設備状況.Item(5, 6 + 開始行数).Value = reader.GetValue(2)
                                        Me.dgv設備状況.Item(6, 6 + 開始行数).Value = reader.GetValue(3)
                                        Me.dgv設備状況.Item(9, 6 + 開始行数).Value = reader.GetValue(8)
                                End Select
                        End Select
                    End While
                End If
            End With

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Try
            With New CSqlEx
                .gSubSelect("A.ステータス")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("SUM(A.受入数)")
                .gSubSelect("A.サンプルNo")
                .gSubSelect("A.列")
                .gSubSelect("A.連")
                .gSubSelect("A.段")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubWhere("A.ステータス >= 5")
                .gSubGroupBy("A.ステータス")
                .gSubGroupBy("A.サンプルNo")
                .gSubGroupBy("A.列")
                .gSubGroupBy("A.連")
                .gSubGroupBy("A.段")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Select Case reader.GetValue(0)
                            Case 5  'クレーンデータ
                                Me.dgv設備状況共通.Item(4, 0).Value = reader.GetValue(1)
                                Me.dgv設備状況共通.Item(5, 0).Value = reader.GetValue(2)
                                Me.dgv設備状況共通.Item(6, 0).Value = reader.GetValue(3)
                                Me.dgv設備状況共通.Item(7, 0).Value = reader.GetValue(4) & "-" & reader.GetValue(5).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(6)
                                Me.dgv設備状況共通.Item(8, 0).Value = "入庫"

                            Case 9  'クレーンデータ
                                Me.dgv設備状況共通.Item(4, 0).Value = reader.GetValue(1)
                                Me.dgv設備状況共通.Item(5, 0).Value = reader.GetValue(2)
                                Me.dgv設備状況共通.Item(6, 0).Value = reader.GetValue(3)
                                Me.dgv設備状況共通.Item(7, 0).Value = reader.GetValue(4) & "-" & reader.GetValue(5).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(6)
                                Me.dgv設備状況共通.Item(8, 0).Value = "出庫"

                            Case 10  '出庫STデータ
                                Me.dgv設備状況共通.Item(4, 1).Value = reader.GetValue(1)
                                Me.dgv設備状況共通.Item(5, 1).Value = reader.GetValue(2)
                                Me.dgv設備状況共通.Item(6, 1).Value = reader.GetValue(3)

                            Case 20  '急冷室前データ
                                Me.dgv設備状況共通.Item(4, 2).Value = reader.GetValue(1)
                                Me.dgv設備状況共通.Item(5, 2).Value = reader.GetValue(2)
                                Me.dgv設備状況共通.Item(6, 2).Value = reader.GetValue(3)
                        End Select
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub クレーン信号情報更新(ByVal 倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal Row As Integer)
        If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 5) = 1 Then
            dgv設備状況共通.Item(2, Row).Value = "異常"
        Else
            If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 7) = 1 Then
                dgv設備状況共通.Item(2, Row).Value = "自動"
            Else
                dgv設備状況共通.Item(2, Row).Value = "手動"
            End If
        End If
    End Sub

    Private Sub 信号情報更新_ライン別(ByVal 倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal Row As Integer, ByVal 開始行数 As Integer)
        If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 0) = 1 Then
            dgv設備状況.Item(2, Row + 開始行数).Value = "異常"
        Else
            If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 1) = 1 Then
                dgv設備状況.Item(2, Row + 開始行数).Value = "自動"
            Else
                dgv設備状況.Item(2, Row + 開始行数).Value = "手動"
            End If
        End If
    End Sub

    Private Sub 荷情報更新_ライン別(ByVal 倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal ビットNo As Integer, ByVal Row As Integer, ByVal 開始行数 As Integer)
        If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, ビットNo) = 1 Then
            dgv設備状況.Item(3, Row + 開始行数).Value = "有"
        Else
            dgv設備状況.Item(3, Row + 開始行数).Value = ""
        End If
    End Sub

    Private Sub 信号情報更新_共通(ByVal 倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal Row As Integer)
        If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 0) = 1 Then
            dgv設備状況共通.Item(2, Row).Value = "異常"
        Else
            If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 1) = 1 Then
                dgv設備状況共通.Item(2, Row).Value = "自動"
            Else
                dgv設備状況共通.Item(2, Row).Value = "手動"
            End If
        End If
    End Sub

    Private Sub 荷情報更新_共通(ByVal 倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal ビットNo As Integer, ByVal Row As Integer)
        If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, ビットNo) = 1 Then
            dgv設備状況共通.Item(3, Row).Value = "有"
        Else
            dgv設備状況共通.Item(3, Row).Value = ""
        End If
    End Sub

    Private Function str設備名称(ByVal no As Integer) As String
        Dim 設備名称 As String
        Select Case no
            Case 1
                設備名称 = "段積機"
            Case 2
                設備名称 = "コンベヤ"
            Case 7
                設備名称 = "入庫ST１"
            Case 8
                設備名称 = "入庫ST２"
            Case 9
                設備名称 = "入庫ST３"
            Case 10
                設備名称 = "クレーン"
            Case 11
                設備名称 = "出庫ST"
            Case 12
                設備名称 = "冷却室前"
            Case Else
                設備名称 = ""
        End Select

        Return 設備名称
    End Function

    Private Function Dbl温度データ取得(ByVal int倉庫区分 As Integer, ByVal intOFFSET As Integer) As Double
        Dim i As Integer
        Dim BitData As String = ""
        Dim 温度データ As Double = 0

        BitData = ""
        For i = 0 To 15
            BitData = Int(CMdiMain.blnON状態(int倉庫区分, intOFFSET, i)) & BitData
        Next

        温度データ = Convert.ToInt32(BitData, 2)

        Return 温度データ
    End Function
End Class

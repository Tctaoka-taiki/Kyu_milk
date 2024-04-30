
Imports System.Data.Common
Public Class Frm00003_冷却側設備状況
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

    Private Sub Frm00002_設備状況_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To 31
            dgv設備状況.Rows.Add()
            dgv設備状況(0, i).Value = i + 1
            dgv設備状況(1, i).Value = str設備名称(i + 1)
        Next

        設備状況更新()
        Timer1.Interval = 2000
        Timer1.Start()
        dgv設備状況.CurrentCell = Nothing

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Timer1.Stop()

            Dim dlg As New Dlg01999_トラッキング削除
            With dlg
                .m画面モード = 1
                .ShowDialog()
            End With

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Me.dgv設備状況.CurrentCell = dgv設備状況(0, 0)
        Me.dgv設備状況.CurrentCell = Nothing
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        Me.dgv設備状況.CurrentCell = dgv設備状況(0, 31)
        Me.dgv設備状況.CurrentCell = Nothing
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.冷却メインメニュー)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub 設備状況更新()
        Dim デバイスOFFSET As Integer = 6000
        Dim 製造ライン As Integer = 0

        '冷却前室
        信号情報更新(1, デバイスOFFSET, 0)
        荷情報更新(1, デバイスOFFSET, 2, 0)

        '冷却コンベヤ
        信号情報更新(1, デバイスOFFSET + 1, 1)

        荷情報更新(1, デバイスOFFSET + 1, 11, 12)
        荷情報更新(1, デバイスOFFSET + 1, 10, 13)
        荷情報更新(1, デバイスOFFSET + 1, 9, 14)
        荷情報更新(1, デバイスOFFSET + 1, 8, 15)
        荷情報更新(1, デバイスOFFSET + 1, 7, 16)
        荷情報更新(1, デバイスOFFSET + 1, 6, 17)
        荷情報更新(1, デバイスOFFSET + 1, 5, 18)
        荷情報更新(1, デバイスOFFSET + 1, 4, 19)
        荷情報更新(1, デバイスOFFSET + 1, 3, 20)
        荷情報更新(1, デバイスOFFSET + 1, 2, 21)

        '入庫ST
        信号情報更新(1, デバイスOFFSET + 2, 22)
        荷情報更新(1, デバイスOFFSET + 2, 4, 22)

        'クレーン
        クレーン信号情報更新(1, 5002, 23)

        '出庫ST
        信号情報更新(1, 6003, 24)
        荷情報更新(1, 6003, 2, 24)

        '出庫コンベヤ
        信号情報更新(1, 6004, 25)
        荷情報更新(1, 6004, 2, 25)

        '出庫前室
        信号情報更新(1, 6005, 26)
        荷情報更新(1, 6005, 2, 26)

        '搬送コンベヤ
        信号情報更新(1, 6006, 27)
        荷情報更新(1, 6006, 2, 27)

        'パレタイザ前
        信号情報更新(1, 6007, 28)
        荷情報更新(1, 6007, 2, 28)

        'パレタイザ１
        信号情報更新(1, 6007, 29)
        荷情報更新(1, 6007, 2, 29)

        'パレタイザ２
        信号情報更新(1, 6007, 30)
        荷情報更新(1, 6007, 2, 30)

        '受渡コンベヤ
        信号情報更新(1, 6008, 31)
        荷情報更新(1, 6008, 2, 31)

        'トラッキングデータ表示
        トラッキング情報更新()
    End Sub

    Private Sub 信号情報更新(ByVal 倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal Row As Integer)
        If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 0) = 1 Then
            dgv設備状況.Item(2, Row).Value = "異常"
        Else
            If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 1) = 1 Then
                dgv設備状況.Item(2, Row).Value = "自動"
            Else
                dgv設備状況.Item(2, Row).Value = "手動"
            End If
        End If
    End Sub

    Private Sub トラッキング情報更新()
        Dim i As Integer = 0
        For i = 0 To 31
            Me.dgv設備状況.Item(4, i).Value = ""
            Me.dgv設備状況.Item(5, i).Value = ""
            Me.dgv設備状況.Item(6, i).Value = ""
            Me.dgv設備状況.Item(7, i).Value = ""
            Me.dgv設備状況.Item(8, i).Value = ""
        Next

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("MAX(A.ステータス)")
                .gSubSelect("MAX(B.品種名)")
                .gSubSelect("SUM(A.受入数)")
                .gSubSelect("MAX(A.サンプルNo)")
                .gSubSelect("MAX(A.列)")
                .gSubSelect("MAX(A.連)")
                .gSubSelect("MAX(A.段)")
                .gSubSelect("A.ロットNo")
                .gSubSelect("A.管理No")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DM品種 B")
                .gSubGroupBy("A.ユニットSEQ,A.ロットNo,A.管理No")
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubWhere("A.ステータス >= 20")
                .gSubOrderBy("MAX(A.冷却開始時刻)")

                Dim 急冷コンベヤ表示カウント As Integer = 0
                Dim 受渡コンベヤ総数 As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Select Case reader.GetValue(0)
                            Case 20  '急冷室前データ
                                mSub設備状況表示(0, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 21  '急冷コンベヤデータ
                                mSub設備状況表示(21 - 急冷コンベヤ表示カウント, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))
                                急冷コンベヤ表示カウント += 1

                            Case 22, 23, 24, 25 '入庫ST&クレーン指示予約
                                mSub設備状況表示(22, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))
                                Me.dgv設備状況.Item(7, 22).Value = reader.GetValue(4) & "-" & reader.GetValue(5) & "-" & reader.GetValue(6)

                            Case 26, 30 'クレーン動作中
                                mSub設備状況表示(23, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))
                                Me.dgv設備状況.Item(7, 23).Value = reader.GetValue(4) & "-" & reader.GetValue(5) & "-" & reader.GetValue(6)
                                Select Case reader.GetValue(0)
                                    Case 26
                                        Me.dgv設備状況.Item(8, 23).Value = "入庫"
                                    Case 30
                                        Me.dgv設備状況.Item(8, 23).Value = "出庫"

                                End Select

                            Case 27, 28, 29 '入庫完了～出庫指示中

                            Case 31 '出庫ST
                                mSub設備状況表示(24, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 32 '出庫コンベヤ
                                mSub設備状況表示(25, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 33 '出庫前室
                                mSub設備状況表示(26, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 34 '搬送コンベヤ
                                mSub設備状況表示(27, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 35 'パレタイザ前
                                mSub設備状況表示(28, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 36 'パレタイザ１
                                mSub設備状況表示(29, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 37 'パレタイザ２
                                mSub設備状況表示(30, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 38 '受渡しコンベヤ
                                受渡コンベヤ総数 += Int(reader.GetValue(2).ToString)
                                mSub設備状況表示(31, reader.GetValue(1), 受渡コンベヤ総数, reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                        End Select
                    End While
                End If
            End With

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub mSub設備状況表示(ByVal intRow As Integer, ByVal data1 As String, ByVal data2 As String, ByVal data3 As String, ByVal data4 As String, ByVal data5 As String, ByVal data6 As String)
        Me.dgv設備状況.Item(4, intRow).Value = data1
        Me.dgv設備状況.Item(5, intRow).Value = data2
        Me.dgv設備状況.Item(6, intRow).Value = data3
        'Me.dgv設備状況.Item(8, intRow).Value = data4
        Me.dgv設備状況.Item(9, intRow).Value = data5
        Me.dgv設備状況.Item(10, intRow).Value = data6

    End Sub
    Private Sub クレーン信号情報更新(ByVal 倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal Row As Integer)
        If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 5) = 1 Then
            dgv設備状況.Item(2, Row).Value = "異常"
        Else
            If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, 7) = 1 Then
                dgv設備状況.Item(2, Row).Value = "自動"
            Else
                dgv設備状況.Item(2, Row).Value = "手動"
            End If
        End If
    End Sub

    Private Sub 荷情報更新(ByVal 倉庫区分 As Integer, ByVal デバイスNo As Integer, ByVal ビットNo As Integer, ByVal Row As Integer)
        If CMdiMain.intデバイスステータス(倉庫区分, デバイスNo, ビットNo) = 1 Then
            dgv設備状況.Item(3, Row).Value = "有"
        Else
            dgv設備状況.Item(3, Row).Value = ""
        End If
    End Sub

    Private Function str設備名称(ByVal no As Integer) As String
        Dim 設備名称 As String
        Select Case no
            Case 1
                設備名称 = "冷却前室"
            Case 2
                設備名称 = "冷却コンベヤ"
            Case 23
                設備名称 = "入庫ST"
            Case 24
                設備名称 = "クレーン"
            Case 25
                設備名称 = "出庫ST"
            Case 26
                設備名称 = "出庫コンベヤ"
            Case 27
                設備名称 = "出庫前室"
            Case 28
                設備名称 = "搬送コンベヤ"
            Case 29
                設備名称 = "パレタイザ前"
            Case 30
                設備名称 = "パレタイザ１"
            Case 31
                設備名称 = "パレタイザ２"
            Case 32
                設備名称 = "受渡コンベヤ"
            Case Else
                設備名称 = ""
        End Select

        Return 設備名称
    End Function

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        設備状況更新()

    End Sub
End Class

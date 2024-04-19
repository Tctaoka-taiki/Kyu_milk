
Imports System.Data.Common
Public Class Frm01024_作業履歴照会
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
    Dim intカレント行 As Integer = 0
    Private Sub Frm01024_作業履歴照会_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl指定日時F.Text = ""
        Me.lbl指定日時T.Text = ""
        Me.lbl設備名称.Text = ""

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
            Dim 対象設備 As String = ""
            Dim 対象指定日FR As String = ""
            Dim 対象指定日TO As String = ""

            Dim dlg As New Dlg01024_作業履歴問合せ
            With dlg
                .ShowDialog()
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    対象設備 = .cmbPLC.Text
                    If .txt指定年FR.Text <> "" And .txt指定月FR.Text <> "" And .txt指定日FR.Text <> "" Then
                        対象指定日FR = .txt指定年FR.Text.PadLeft(4, "0"c) & "/" & .txt指定月FR.Text.PadLeft(2, "0"c) & "/" & .txt指定日FR.Text.PadLeft(2, "0"c) & " " & .txt指定時FR.Text.PadLeft(2, "0"c) & ":" & .txt指定分FR.Text.PadLeft(2, "0"c) & ":00"
                    End If
                    If .txt指定年TO.Text <> "" And .txt指定月TO.Text <> "" And .txt指定日TO.Text <> "" Then
                        対象指定日TO = .txt指定年TO.Text.PadLeft(4, "0"c) & "/" & .txt指定月TO.Text.PadLeft(2, "0"c) & "/" & .txt指定日TO.Text.PadLeft(2, "0"c) & " " & .txt指定時TO.Text.PadLeft(2, "0"c) & ":" & .txt指定分TO.Text.PadLeft(2, "0"c) & ":00"
                    End If
                    Me.lbl指定日時F.Text = 対象指定日FR
                    Me.lbl指定日時T.Text = 対象指定日TO
                    Me.lbl設備名称.Text = 対象設備
                    Me.lbl設備名称.Text = 対象設備

                    '画面の再表示
                    作業履歴情報表示(対象設備, 対象指定日FR, 対象指定日TO)
                End If
            End With

        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub 作業履歴情報表示(ByVal 設備名称 As String, ByVal 指定日FR As String, ByVal 指定日TO As String)
        Dim 傾き値1 As Double
        Dim 切片1 As Double
        Dim 傾き値2 As Double
        Dim 切片2 As Double
        Select Case 設備名称
            Case "醗酵"
                傾き値1 = dbl発酵室温度傾き
                切片1 = dbl発酵室温度切片

                傾き値2 = dbl急冷室温度傾き
                切片2 = dbl急冷室温度切片

            Case "冷却"
                傾き値1 = dbl急冷室温度傾き
                切片1 = dbl急冷室温度切片

                傾き値2 = dbl冷却室温度傾き
                切片2 = dbl冷却室温度切片
        End Select

        Me.dgv作業履歴.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.作業区分")
                .gSubSelect("A.登録日時")
                .gSubSelect("A.ロットNo")
                .gSubSelect("A.サンプルNo")
                .gSubSelect("B.品種名")
                .gSubSelect("A.受入数")
                .gSubSelect("A.温度信号")
                .gSubFrom("DL作業履歴 A")
                .gSubFrom("DM品種 B")
                Select Case 設備名称
                    Case "醗酵"
                        .gSubWhere("A.倉庫区分=0")
                    Case "冷却"
                        .gSubWhere("A.倉庫区分=1")
                End Select
                .gSubWhere("A.登録日時", 指定日FR, ">=", , , , , , True)
                .gSubWhere("A.登録日時", 指定日TO, "<=", , , , , , True)
                .gSubWhere("A.品種CD = B.品種CD")
                .gSubOrderBy("A.登録日時")

                Dim i As Integer = 0
                Dim 作業内容 As String = ""
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Me.dgv作業履歴.Rows.Add()
                        Me.dgv作業履歴.Item(0, i).Value = i + 1
                        Select Case reader.GetValue(0)
                            Case 0
                                作業内容 = "搬入"
                            Case 1
                                作業内容 = "搬出"
                            Case 2
                                作業内容 = "登録"
                            Case 3
                                作業内容 = "削除"
                        End Select
                        Me.dgv作業履歴.Item(1, i).Value = 作業内容
                        Me.dgv作業履歴.Item(2, i).Value = reader.GetValue(1)
                        Me.dgv作業履歴.Item(3, i).Value = reader.GetValue(2)
                        Me.dgv作業履歴.Item(4, i).Value = reader.GetValue(3)
                        Me.dgv作業履歴.Item(5, i).Value = reader.GetValue(4)
                        Me.dgv作業履歴.Item(6, i).Value = reader.GetValue(5)
                        Select Case 作業内容
                            Case "搬入"
                                Me.dgv作業履歴.Item(7, i).Value = Int(CInt("&H" & reader.GetValue(6).ToString) - 切片1 / 傾き値1 * 10) / 10 & "℃"
                            Case "搬出"
                                Me.dgv作業履歴.Item(7, i).Value = Int(CInt("&H" & reader.GetValue(6).ToString) - 切片2 / 傾き値2 * 10) / 10 & "℃"
                            Case Else   '他の場合、温度非表示

                        End Select

                        i += 1

                        If i + 1 = 5000 Then
                            CMsg.gMsg_情報("データ表示は最大5000件までとします。")
                            Exit While
                        End If
                    End While

                    If i > 0 Then

                    Else
                        'データが無い場合は、クリアする
                        CMsg.gMsg_情報("該当データがありません。")
                        Me.lbl指定日時F.Text = ""
                        Me.lbl指定日時T.Text = ""
                        Me.lbl設備名称.Text = ""
                        Me.dgv作業履歴.Rows.Clear()
                    End If

                End If
            End With
        Catch ex As Exception
        Finally
            Dim intカレント行 As Integer = 0
            Me.dgv作業履歴.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Dim int直前ページ送り区分 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        If Me.dgv作業履歴.Rows.Count <= 0 Then
            Exit Sub
        End If


        If int直前ページ送り区分 = 0 Then
            intカレント行 = intカレント行 - 24
        Else
            intカレント行 = intカレント行 - 47
        End If

        If intカレント行 < 0 Then
            intカレント行 = 0

        ElseIf intカレント行 > Me.dgv作業履歴.Rows.Count - 1 Then
            intカレント行 = Me.dgv作業履歴.Rows.Count - 1

        End If

        Me.dgv作業履歴.CurrentCell = dgv作業履歴(0, intカレント行)
        Me.dgv作業履歴.CurrentCell = Nothing

        int直前ページ送り区分 = 0
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If Me.dgv作業履歴.Rows.Count <= 0 Then
            Exit Sub
        End If

        If int直前ページ送り区分 = 1 Then
            intカレント行 = intカレント行 + 24
        Else
            intカレント行 = intカレント行 + 47
        End If

        If intカレント行 > Me.dgv作業履歴.Rows.Count - 1 Then
            intカレント行 = Me.dgv作業履歴.Rows.Count - 1
        End If

        Me.dgv作業履歴.CurrentCell = dgv作業履歴(0, intカレント行)
        Me.dgv作業履歴.CurrentCell = Nothing

        int直前ページ送り区分 = 1
    End Sub
End Class

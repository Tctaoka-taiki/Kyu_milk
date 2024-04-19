
Imports System.Data.Common
Public Class Frm01023_温度実績問合せ
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
    Private Sub Frm01023_温度実績問合せ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl指定日.Text = ""
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
            Dim 対象指定日 As String = ""

            Dim dlg As New Dlg01023_温度
            With dlg
                .ShowDialog()
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    対象設備 = .cmb設備名称.Text
                    If .txt指定年.Text <> "" And .txt指定月.Text <> "" And .txt指定日.Text <> "" Then
                        対象指定日 = .txt指定年.Text.PadLeft(4, "0"c) & "/" & .txt指定月.Text.PadLeft(2, "0"c) & "/" & .txt指定日.Text.PadLeft(2, "0"c)
                    End If
                    Me.lbl指定日.Text = 対象指定日
                    Me.lbl設備名称.Text = 対象設備
                    '画面の再表示
                    設備温度情報(対象設備, 対象指定日)
                End If
            End With

        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub 設備温度情報(ByVal 設備名称 As String, ByVal 指定日 As String)
        Me.dgv温度データ.Rows.Clear()
        Dim 傾き値 As Double
        Dim 切片 As Double

        Select Case 設備名称
            Case "醗酵倉庫"
                傾き値 = dbl発酵室温度傾き
                切片 = dbl発酵室温度切片
            Case "冷却倉庫"
                傾き値 = dbl冷却室温度傾き
                切片 = dbl冷却室温度切片
            Case "急冷室"
                傾き値 = dbl急冷室温度傾き
                切片 = dbl急冷室温度切片
        End Select
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.時")
                .gSubSelect("MAX(A.温度信号00分)")
                .gSubSelect("MAX(A.温度信号10分)")
                .gSubSelect("MAX(A.温度信号20分)")
                .gSubSelect("MAX(A.温度信号30分)")
                .gSubSelect("MAX(A.温度信号40分)")
                .gSubSelect("MAX(A.温度信号50分)")
                .gSubFrom("DV温度履歴 A")
                Select Case 設備名称
                    Case "醗酵倉庫"
                        .gSubWhere("A.設備区分=0")
                    Case "冷却倉庫"
                        .gSubWhere("A.設備区分=1")
                    Case "急冷室"
                        .gSubWhere("A.設備区分=2")
                End Select
                .gSubWhere("A.年", Mid(指定日, 1, 4))
                .gSubWhere("A.月", Mid(指定日, 6, 2))
                .gSubWhere("A.日", Mid(指定日, 9, 2))
                .gSubGroupBy("A.時")
                .gSubOrderBy("A.時")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Me.dgv温度データ.Rows.Add()
                        Me.dgv温度データ.Item(0, i).Value = i + 1
                        Me.dgv温度データ.Item(1, i).Value = reader.GetValue(0)
                        If Trim(reader.GetValue(1).ToString) <> "" Then
                            Me.dgv温度データ.Item(2, i).Value = Format(Int((CInt("&H" & reader.GetValue(1).ToString) - 切片) / 傾き値 * 10) / 10, "0.0") & "℃"
                        End If
                        If Trim(reader.GetValue(2).ToString) <> "" Then
                            Me.dgv温度データ.Item(3, i).Value = Format(Int((CInt("&H" & reader.GetValue(2).ToString) - 切片) / 傾き値 * 10) / 10, "0.0") & "℃"
                        End If
                        If Trim(reader.GetValue(3).ToString) <> "" Then
                            Me.dgv温度データ.Item(4, i).Value = Format(Int((CInt("&H" & reader.GetValue(3).ToString) - 切片) / 傾き値 * 10) / 10, "0.0") & "℃"
                        End If
                        If Trim(reader.GetValue(4).ToString) <> "" Then
                            Me.dgv温度データ.Item(5, i).Value = Format(Int((CInt("&H" & reader.GetValue(4).ToString) - 切片) / 傾き値 * 10) / 10, "0.0") & "℃"
                        End If
                        If Trim(reader.GetValue(5).ToString) <> "" Then
                            Me.dgv温度データ.Item(6, i).Value = Format(Int((CInt("&H" & reader.GetValue(5).ToString) - 切片) / 傾き値 * 10) / 10, "0.0") & "℃"
                        End If
                        If Trim(reader.GetValue(6).ToString) <> "" Then
                            Me.dgv温度データ.Item(7, i).Value = Format(Int((CInt("&H" & reader.GetValue(6).ToString) - 切片) / 傾き値 * 10) / 10, "0.0") & "℃"
                        End If

                        i += 1
                    End While

                    If i > 0 Then

                    Else
                        'データが無い場合は、クリアする
                        CMsg.gMsg_情報("該当データがありません。")
                        Me.dgv温度データ.Rows.Clear()
                    End If

                End If
            End With
        Catch ex As Exception
        Finally
            Dim intカレント行 As Integer = 0
            Me.dgv温度データ.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Dim int直前ページ送り区分 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        If Me.dgv温度データ.Rows.Count < 0 Then
            Exit Sub
        End If


        If int直前ページ送り区分 = 0 Then
            intカレント行 = intカレント行 - 24
        Else
            intカレント行 = intカレント行 - 47
        End If

        If intカレント行 < 0 Then
            intカレント行 = 0

        ElseIf intカレント行 > Me.dgv温度データ.Rows.Count - 1 Then
            intカレント行 = Me.dgv温度データ.Rows.Count - 1

        End If

        Me.dgv温度データ.CurrentCell = dgv温度データ(0, intカレント行)
        Me.dgv温度データ.CurrentCell = Nothing

        int直前ページ送り区分 = 0
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If Me.dgv温度データ.Rows.Count < 0 Then
            Exit Sub
        End If

        If int直前ページ送り区分 = 1 Then
            intカレント行 = intカレント行 + 24
        Else
            intカレント行 = intカレント行 + 47
        End If

        If intカレント行 > Me.dgv温度データ.Rows.Count - 1 Then
            intカレント行 = Me.dgv温度データ.Rows.Count - 1
        End If

        Me.dgv温度データ.CurrentCell = dgv温度データ(0, intカレント行)
        Me.dgv温度データ.CurrentCell = Nothing

        int直前ページ送り区分 = 1
    End Sub
End Class

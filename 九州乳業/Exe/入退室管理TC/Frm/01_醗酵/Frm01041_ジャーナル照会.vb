
Imports System.Data.Common
Public Class Frm01041_ジャーナル照会
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
    Private Sub Frm01041_ジャーナル照会_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl指定日時F.Text = ""
        Me.lbl指定日時T.Text = ""
        Me.lblデバイス.Text = ""
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
            Dim デバイスNo As String = ""


            Dim dlg As New Dlg01041_ジャーナル問合
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
                    デバイスNo = .txtデバイスNo.Text
                    Me.lbl指定日時F.Text = 対象指定日FR
                    Me.lbl指定日時T.Text = 対象指定日TO
                    Me.lbl設備名称.Text = 対象設備
                    Me.lbl設備名称.Text = 対象設備

                    '画面の再表示
                    ジャーナル情報(対象設備, 対象指定日FR, 対象指定日TO, デバイスNo)
                End If
            End With

        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub ジャーナル情報(ByVal 設備名称 As String, ByVal 指定日FR As String, ByVal 指定日TO As String, ByVal デバイスNo As String)
        Me.dgvジャーナルデータ.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.登録日時")
                .gSubSelect("A.デバイスNo")
                .gSubSelect("A.直前信号")
                .gSubSelect("A.信号")
                .gSubFrom("DLジャーナル履歴 A")
                Select Case 設備名称
                    Case "醗酵"
                        .gSubWhere("A.倉庫区分=0")
                    Case "冷却"
                        .gSubWhere("A.倉庫区分=1")
                End Select
                .gSubWhereあいまい検索("デバイスNo", デバイスNo)
                .gSubWhere("A.登録日時", 指定日FR, ">=", , , , , , True)
                .gSubWhere("A.登録日時", 指定日TO, "<=", , , , , , True)
                .gSubOrderBy("A.登録日時")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Me.dgvジャーナルデータ.Rows.Add()
                        Me.dgvジャーナルデータ.Item(0, i).Value = i + 1
                        Me.dgvジャーナルデータ.Item(1, i).Value = reader.GetValue(0)
                        Me.dgvジャーナルデータ.Item(2, i).Value = reader.GetValue(1)
                        If reader.GetValue(2).ToString <> "" Then
                            Me.dgvジャーナルデータ.Item(3, i).Value = Convert.ToString(Convert.ToInt32(reader.GetValue(2).ToString, 16), 2).PadLeft(16, "0"c)
                        End If
                        If reader.GetValue(3).ToString <> "" Then
                            Me.dgvジャーナルデータ.Item(4, i).Value = Convert.ToString(Convert.ToInt32(reader.GetValue(3).ToString, 16), 2).PadLeft(16, "0"c)
                        End If

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
                        Me.lblデバイス.Text = ""
                        Me.lbl設備名称.Text = ""
                        Me.dgvジャーナルデータ.Rows.Clear()
                    End If

                End If
            End With
        Catch ex As Exception
        Finally
            Dim intカレント行 As Integer = 0
            Me.dgvジャーナルデータ.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Dim int直前ページ送り区分 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        If Me.dgvジャーナルデータ.Rows.Count <= 0 Then
            Exit Sub
        End If


        If int直前ページ送り区分 = 0 Then
            intカレント行 = intカレント行 - 24
        Else
            intカレント行 = intカレント行 - 47
        End If

        If intカレント行 < 0 Then
            intカレント行 = 0

        ElseIf intカレント行 > Me.dgvジャーナルデータ.Rows.Count - 1 Then
            intカレント行 = Me.dgvジャーナルデータ.Rows.Count - 1

        End If

        Me.dgvジャーナルデータ.CurrentCell = dgvジャーナルデータ(0, intカレント行)
        Me.dgvジャーナルデータ.CurrentCell = Nothing

        int直前ページ送り区分 = 0
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If Me.dgvジャーナルデータ.Rows.Count <= 0 Then
            Exit Sub
        End If

        If int直前ページ送り区分 = 1 Then
            intカレント行 = intカレント行 + 24
        Else
            intカレント行 = intカレント行 + 47
        End If

        If intカレント行 > Me.dgvジャーナルデータ.Rows.Count - 1 Then
            intカレント行 = Me.dgvジャーナルデータ.Rows.Count - 1
        End If

        Me.dgvジャーナルデータ.CurrentCell = dgvジャーナルデータ(0, intカレント行)
        Me.dgvジャーナルデータ.CurrentCell = Nothing

        int直前ページ送り区分 = 1
    End Sub
End Class


Imports System.Data.Common
Public Class Frm01022_生産実績問合せ
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
    Private Sub Frm01022_生産実績問合せ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl賞味期限.Text = ""
        Me.lbl品種名.Text = ""

    End Sub


    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim 対象品種CD As String = ""
            Dim 対象賞味期限 As String = ""

            Dim dlg As New Dlg01031_生産問合設定
            With dlg
                .ShowDialog()
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    対象品種CD = .txt品種.Text
                    If .txt賞味期限年.Text <> "" And .txt賞味期限月.Text <> "" And .txt賞味期限日.Text <> "" Then
                        対象賞味期限 = .txt賞味期限年.Text & "/" & .txt賞味期限月.Text & "/" & .txt賞味期限日.Text
                    End If
                    Me.lbl賞味期限.Text = 対象賞味期限
                    Me.lbl品種名.Text = .txt品種.Text
                    '画面の再表示
                    醗酵生産品情報(対象品種CD, 対象賞味期限)
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        If CMsg.gMsg_YesNo("生産実績リストを出力してもよろしいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '生産実績
        With New CSqlEx
            .gSubSelect("CONVERT(VARCHAR,MAX(A.醗酵開始時刻),111) as 醗酵開始時刻")
            .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS as ロットNo")
            .gSubSelect("A.サンプルNo as サンプルNo")
            .gSubSelect("MAX(A.品種CD) as 品種CD")
            .gSubSelect("MAX(A.品種名) as 品種名")
            .gSubSelect("SUM(A.受入数) as 受入数")
            .gSubFrom("DJトラッキング A")
            If Me.lbl品種名.Text <> "" Then
                .gSubWhere("A.品種CD", Me.lbl品種名.Text)

            End If
            If Me.lbl賞味期限.Text <> "" Then
                .gSubWhere("A.賞味期限", Me.lbl賞味期限.Text)

            End If
            .gSubGroupBy("A.ロットNo")
            .gSubGroupBy("A.サンプルNo")
            .gSubOrderBy("MAX(A.醗酵開始時刻)")
            .gSubOrderBy("ロットNo")
            .gSubOrderBy("サンプルNo")

            Dim str条件 As String = "品種CD:" & Me.lbl品種名.Text.PadRight(20, " "c) & "賞味期限:" & Me.lbl賞味期限.Text
            CMdiMain.帳票出力(New 生産実績, "***生産実績***", .gSQL文の取得, str条件)
        End With
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub 醗酵生産品情報(ByVal 品種CD As String, ByVal 賞味期限 As String)
        Me.dgv生産データ.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("CONVERT(VARCHAR,MAX(A.醗酵開始時刻),111) as 醗酵開始時刻")
                .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("A.サンプルNo")
                .gSubSelect("MAX(A.品種名)")
                .gSubSelect("SUM(A.受入数)")
                .gSubFrom("DJトラッキング A")
                If 品種CD <> "" Then
                    .gSubWhere("A.品種CD", 品種CD)

                End If
                If 賞味期限 <> "" Then
                    .gSubWhere("A.賞味期限", 賞味期限)

                End If
                .gSubGroupBy("A.ロットNo  COLLATE Japanese_CS_AS_KS_WS")
                .gSubGroupBy("A.サンプルNo")
                .gSubOrderBy("醗酵開始時刻")
                .gSubGroupBy("醗酵開始時刻")
                .gSubOrderBy("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubOrderBy("A.サンプルNo")

                Dim i As Integer = 1
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    '合計表示行の作成
                    Dim 合計受入数 As Integer = 0
                    Me.dgv生産データ.Rows.Add()

                    While reader.Read
                        Me.dgv生産データ.Rows.Add()
                        Me.dgv生産データ.Item(0, i).Value = i
                        Me.dgv生産データ.Item(1, i).Value = reader.GetValue(0)
                        'Me.dgv生産データ.Item(1, i).Value = Mid(reader.GetValue(0).ToString, 1, 10)
                        Me.dgv生産データ.Item(2, i).Value = reader.GetValue(1)
                        Me.dgv生産データ.Item(3, i).Value = reader.GetValue(2)
                        Me.dgv生産データ.Item(4, i).Value = reader.GetValue(3)
                        Me.dgv生産データ.Item(5, i).Value = reader.GetValue(4)
                        合計受入数 += reader.GetValue(4)
                        i += 1
                    End While

                    If i > 1 Then
                        Me.dgv生産データ.Rows(0).DefaultCellStyle.BackColor = Color.Yellow
                        Me.dgv生産データ.Item(5, 0).Value = 合計受入数
                    Else
                        'データが無い場合は、クリアする
                        CMsg.gMsg_情報("該当データがありません。")
                        Me.dgv生産データ.Rows.Clear()
                    End If

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
        If Me.dgv生産データ.Rows.Count <= 0 Then
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
        If Me.dgv生産データ.Rows.Count <= 0 Then
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

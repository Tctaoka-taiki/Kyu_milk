
Imports System.Data.Common
Public Class Frm01001_入庫設定
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    '時間表示
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

    Dim OFFSET As Integer = 0
    Private Sub Frm01001_入庫設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case m画面モード
            Case 0
                Me.lblライン名称.Text = "ハード１"
                OFFSET = 6000
            Case 1
                Me.lblライン名称.Text = "プレーン１"
                OFFSET = 6004
            Case 2
                Me.lblライン名称.Text = "ハード２"
                OFFSET = 6010
            Case Else
        End Select

        '画面表示
        画面初期化()
        入庫設定表示()
        サンプル情報表示()
        ロット完了表示()
        mSubボタン更新()

        Me.Timer1.Interval = 3000
        Me.Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            CMdiMain.gSub処理中設定(Me, True)

            入庫設定表示()
            サンプル情報表示()
            ロット完了表示()
            mSubボタン更新()
        Catch ex As Exception
        Finally
            CMdiMain.gSub処理中設定(Me, False)
        End Try

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        '画面表示
        画面初期化()

        Dim Dlg As New Dlg01001_入庫設定
        With Dlg
            .m画面モード = m画面モード
            .ShowDialog()
            Me.lblロットNo.Text = .txtロットNo.Text
        End With

        If Me.lblロットNo.Text <> "" Then
            入庫設定表示()
            サンプル情報表示()
            ロット完了表示()
            mSubボタン更新()
        End If
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        If CMsg.gMsg_YesNo("入庫設定を削除してもよろしいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '直前取得
        Dim int段積機載荷状態 As Integer = CMdiMain.intデバイスステータス(0, OFFSET + 1, 2)
        If Me.dgvサンプル.Rows.Count = 0 And int段積機載荷状態 = 0 Then
            'データ削除の実行
            Update入庫設定クリア(m画面モード)
            '画面表示
            入庫設定表示()
            サンプル情報表示()
            ロット完了表示()
            mSubボタン更新()

        Else
            CMsg.gMsg_エラー("既にクレートを引き込んでいます。ロット完了を実施して下さい。")
            Exit Sub
        End If

    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        '該当ラインの確定荷数<>0の場合は、0となるまでロット完を行えない
        If int確定荷数取得() > 0 Then
            CMsg.gMsg_注意("前回ロットの入庫が完了していません。" & vbCrLf & "前回ロットが入庫されるまでお待ちください")
            Exit Sub
        End If

        If CMsg.gMsg_YesNo("ロット完了を実行してもよろしいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Select Case m画面モード
            Case 0
                CMdiMain.Updateロット完了(True, 0)
            Case 1
                CMdiMain.Updateロット完了(True, 1)
            Case 2
                CMdiMain.Updateロット完了(True, 2)
            Case Else
        End Select

        入庫設定表示()
        サンプル情報表示()
        ロット完了表示()
        mSubボタン更新()

    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Dim Dlg As New Dlg01002_指定サンプル数設定
        With Dlg
            .m画面モード = m画面モード
            .ShowDialog()

            '画面表示
            画面初期化()
            If Me.lblロットNo.Text <> "" Then
                入庫設定表示()
                サンプル情報表示()
                ロット完了表示()
                mSubボタン更新()
            End If
        End With
    End Sub
    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub 画面初期化()
        'テキスト初期化
        Me.lbl品種CD.Text = ""
        Me.lbl品種名.Text = ""
        Me.lblロットNo.Text = ""
        Me.lbl賞味期限.Text = ""
        Me.lbl醗酵開始時刻.Text = ""
        Me.lbl所定醗酵時間.Text = ""
        Me.lbl所定冷却時間.Text = ""
        Me.lbl発酵終了時刻.Text = ""
    End Sub

    Private Sub 入庫設定表示()
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.品種CD")
                .gSubSelect("B.品種名")
                .gSubSelect("A.ロットNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("A.賞味期限")
                .gSubSelect("A.醗酵開始時刻")
                .gSubSelect("B.所定醗酵時間")
                .gSubSelect("B.所定冷却時間")
                .gSubFrom("DN製造製品 A")
                .gSubFrom("DM品種 B")
                .gSubWhere("A.製造ライン", m画面モード, , , , , , , False)
                .gSubWhere("A.品種CD = B.品種CD")
                Select Case m画面モード
                    Case 1      'プレーン製品
                        .gSubWhere("B.製品区分 = 1")
                    Case Else   'ハード製品
                        .gSubWhere("B.製品区分 = 0")
                End Select

                Dim CNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Me.lbl品種CD.Text = reader.GetValue(0)
                        Me.lbl品種名.Text = reader.GetValue(1)
                        Me.lblロットNo.Text = reader.GetValue(2)
                        Me.lbl賞味期限.Text = reader.GetValue(3)
                        Me.lbl醗酵開始時刻.Text = reader.GetValue(4).ToString
                        Me.lbl所定醗酵時間.Text = reader.GetValue(5) & "(分)"
                        Me.lbl所定冷却時間.Text = reader.GetValue(6) & "(分)"
                        Me.lbl発酵終了時刻.Text = str発酵終了時刻取得(reader.GetValue(4), reader.GetValue(5).ToString)

                        CNT += 1
                    End While

                    If CNT = 0 Then
                        '表示クリア
                        Me.lbl品種CD.Text = ""
                        Me.lbl品種名.Text = ""
                        Me.lblロットNo.Text = ""
                        Me.lbl賞味期限.Text = ""
                        Me.lbl醗酵開始時刻.Text = ""
                        Me.lbl所定醗酵時間.Text = ""
                        Me.lbl所定冷却時間.Text = ""
                        Me.lbl発酵終了時刻.Text = ""
                    End If

                End If


            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub
    Private Function str発酵終了時刻取得(ByVal 発酵開始時刻 As Date, ByVal 所定発酵時間 As String) As String
        Dim 発酵終了時刻 As Date = 発酵開始時刻.AddMinutes(Convert.ToInt32(所定発酵時間))
        Return 発酵終了時刻.ToString
    End Function
    Private Function int確定荷数取得() As Integer
        Dim reader As DbDataReader = Nothing
        Dim int確定荷数 As Integer = 0
        Try
            With New CSqlEx
                .gSubSelect("A.確定荷数")
                .gSubFrom("DN製造製品 A")
                .gSubWhere("A.製造ライン", m画面モード, , , , , , , False)

                Dim CNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        int確定荷数 = reader.GetValue(0)
                    End While
                End If

                Return int確定荷数
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Private Sub サンプル情報表示()
        Me.dgvサンプル.Rows.Clear()

        If Me.lblロットNo.Text = "" Then
            Exit Sub
        End If

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("A.サンプルNo")
                .gSubSelect("MAX(B.指定数)")
                .gSubSelect("SUM(A.受入数)")
                .gSubFrom("DNトラッキング A")
                .gSubFrom("DN指定サンプル数 B")
                .gSubWhere("A.ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.lblロットNo.Text, , , , , , , True)
                .gSubWhere("A.製造ライン", m画面モード, , , , , , , False)
                .gSubWhere("B.製造ライン = A.製造ライン")
                .gSubWhere("B.サンプルNo = A.サンプルNo")
                .gSubGroupBy("A.サンプルNo")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Me.dgvサンプル.Rows.Add()
                        Me.dgvサンプル.Item(0, i).Value = "サンプル" & reader.GetValue(0)
                        Me.dgvサンプル.Item(1, i).Value = reader.GetValue(1)
                        Me.dgvサンプル.Item(2, i).Value = reader.GetValue(2)
                        i += 1
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            Me.dgvサンプル.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub mSubボタン更新()
        '削除ボタン
        'トラッキングデータが無く、段積機が未積載の場合のみ利用が可能です。
        'ロット完了ボタン
        'トラッキングデータがあるか、段積機が積載中の場合にのみ利用が可能です。
        If Me.lblロットNo.Text <> "" Then   '設定中
            Me.btnF1.Enabled = False
            Me.btnF4.Enabled = True

            Dim int段積機載荷状態 As Integer = CMdiMain.intデバイスステータス(0, OFFSET + 1, 2)
            If Me.dgvサンプル.Rows.Count = 0 And int段積機載荷状態 = 0 Then
                Me.btnF2.Enabled = True
                Me.btnF3.Enabled = False
            Else
                Me.btnF2.Enabled = False
                Me.btnF3.Enabled = True
            End If
        Else
            Me.btnF1.Enabled = True
            Me.btnF2.Enabled = False
            Me.btnF3.Enabled = False
            Me.btnF4.Enabled = False

        End If
    End Sub

    Private Sub ロット完了表示()
        Select Case m画面モード
            Case 0
                If CMdiMain.blnロット完了状態(0) = True Then
                    pnlメッセージ.Visible = True
                Else
                    pnlメッセージ.Visible = False
                End If
            Case 1
                If CMdiMain.blnロット完了状態(1) = True Then
                    pnlメッセージ.Visible = True
                Else
                    pnlメッセージ.Visible = False
                End If
            Case 2
                If CMdiMain.blnロット完了状態(2) = True Then
                    pnlメッセージ.Visible = True
                Else
                    pnlメッセージ.Visible = False
                End If
            Case Else
        End Select
    End Sub

    '≪製造製品データ更新≫
    Public Sub Update入庫設定クリア(ByVal ラインNo As Integer)
        Try
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DN製造製品"
                .gSubColumnValue("品種CD", "NULL", False)
                .gSubColumnValue("ロットNo", "NULL", False)
                .gSubColumnValue("賞味期限", "NULL", False)
                .gSubColumnValue("醗酵開始時刻", "NULL", False)
                .gSubColumnValue("処理サンプルNo", 1, False)
                .gSubColumnValue("ロット完了", "0", False)
                .gSubColumnValue("更新プログラム", Name, True)
                .gSubColumnValue("更新日時", "GETDATE()", False)
                .gSubWhere("製造ライン", ラインNo, , , , , , , False)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

End Class

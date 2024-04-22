
Imports System.Data.Common
Public Class Dlg01001_入庫設定

    Private Sub Dlg01001_入庫設定_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初期値設定
        Me.txt醗酵開始年.Text = Now.Year.ToString
        Me.txt醗酵開始月.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt醗酵開始日.Text = Now.Day.ToString.PadLeft(2, "0"c)
        Me.txt醗酵開始時.Text = "00"
        Me.txt醗酵開始分.Text = "00"

        Me.txt賞味期限年.Text = Now.Year.ToString
        Me.txt賞味期限月.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt賞味期限日.Text = Now.Day.ToString.PadLeft(2, "0"c)


        Select Case m画面モード
            Case 0
                Me.lblライン名称.Text = "ハード１"
                Me.lblロットNo.Text = "100"
            Case 1
                Me.lblライン名称.Text = "プレーン１"
                Me.lblロットNo.Text = "200"
            Case 2
                Me.lblライン名称.Text = "ハード２"
                Me.lblロットNo.Text = "100"
            Case Else
        End Select

        mSubボタン設定()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try

            If Not bln品種有り() Or Me.txt品種.Text = "" Then
                MessageBox.Show("品種コードが正しくありません。")
                Me.txt品種.Focus()
                Exit Sub
            End If

            Dim str醗酵開始日時 As String = Me.txt醗酵開始年.Text.PadLeft(4, "0"c) & "/" & Me.txt醗酵開始月.Text.PadLeft(2, "0"c) & "/" & Me.txt醗酵開始日.Text.PadLeft(2, "0"c) & " " & Me.txt醗酵開始時.Text.PadLeft(2, "0"c) & ":" & Me.txt醗酵開始分.Text.PadLeft(2, "0"c) & ":00"
            If Not IsDate(str醗酵開始日時) Then
                MessageBox.Show("醗酵開始日時が正しくありません。")
                Me.txt醗酵開始年.Focus()
                Exit Sub
            End If

            Dim int醗酵開始日時 As Double = Me.txt醗酵開始年.Text.PadLeft(4, "0"c) & Me.txt醗酵開始月.Text.PadLeft(2, "0"c) & Me.txt醗酵開始日.Text.PadLeft(2, "0"c) & Me.txt醗酵開始時.Text.PadLeft(2, "0"c) & Me.txt醗酵開始分.Text.PadLeft(2, "0"c) & "00"
            Dim int現在時刻 As Double = Val(Now.Year.ToString & Now.Month.ToString.PadLeft(2, "0"c) & Now.Day.ToString.PadLeft(2, "0"c) & Now.Hour.ToString.PadLeft(2, "0"c) & Now.Minute.ToString.PadLeft(2, "0"c) & Now.Second.ToString.PadLeft(2, "0"c))
            If int醗酵開始日時 > int現在時刻 Then
                MessageBox.Show("醗酵開始日時は現在時刻より前にしてください。")
                Me.txt醗酵開始年.Focus()
                Exit Sub

            End If

            Dim str賞味期限日時 As String = Me.txt賞味期限年.Text.PadLeft(4, "0"c) & "/" & Me.txt賞味期限月.Text.PadLeft(2, "0"c) & "/" & Me.txt賞味期限日.Text.PadLeft(2, "0"c) & " 00:00:00"
            If Not IsDate(str賞味期限日時) Then
                MessageBox.Show("賞味期限が正しくありません。")
                Me.txt賞味期限年.Focus()
                Exit Sub
            End If

            If Me.txtロットNo.Text = "" Then
                MessageBox.Show("ロットNoが未入力です。")
                Me.txtロットNo.Focus()
                Exit Sub

            ElseIf Me.txtロットNo.Text = "000" Then
                If CMsg.gMsg_YesNo("ロットNo:" & Me.lblロットNo.Text & "000でよろしいですか？") = Windows.Forms.DialogResult.No Then
                    Me.txtロットNo.Text = ""
                    Me.txtロットNo.Focus()
                    Exit Sub

                End If
            End If

            '0埋め処理
            Me.txtロットNo.Text = Me.txtロットNo.Text.PadLeft(3, "0"c)
            '入力情報のチェック（DN入庫製品に登録済のロットNoは使用できない）
            If blnロット重複有り_トラッキング() Or blnロット重複有り_製造製品() Then
                MessageBox.Show("既に利用させているロットNoです。")
                Me.txtロットNo.Focus()
                Exit Sub
            End If

            If CMsg.gMsg_YesNo("入庫設定を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            '入力情報をDN製造製品に更新
            Update製造製品()

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        '初期値設定
        Me.txt醗酵開始年.Text = Now.Year.ToString
        Me.txt醗酵開始月.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt醗酵開始日.Text = Now.Day.ToString.PadLeft(2, "0"c)
        Me.txt醗酵開始時.Text = "00"
        Me.txt醗酵開始分.Text = "00"

        Me.txt賞味期限年.Text = Now.Year.ToString
        Me.txt賞味期限月.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt賞味期限日.Text = Now.Day.ToString.PadLeft(2, "0"c)

        Me.txt品種.Text = ""
        Me.txtロットNo.Text = ""
        Me.lbl品種.Text = ""
        Me.txt品種.Focus()
    End Sub

    Public Sub Update製造製品()
        Try
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DN製造製品"
                .gSubColumnValue("品種CD", Me.txt品種.Text, True)
                .gSubColumnValue("ロットNo", Me.lblロットNo.Text & Me.txtロットNo.Text, True)
                .gSubColumnValue("賞味期限", Me.txt賞味期限年.Text & "/" & Me.txt賞味期限月.Text & "/" & Me.txt賞味期限日.Text & " 00:00:00", True)
                .gSubColumnValue("醗酵開始時刻", Me.txt醗酵開始年.Text & "/" & Me.txt醗酵開始月.Text & "/" & Me.txt醗酵開始日.Text & " " & Me.txt醗酵開始時.Text & ":" & Me.txt醗酵開始分.Text & ":00", True)
                .gSubColumnValue("更新プログラム", Name, True)
                '以下、初期化
                .gSubColumnValue("処理サンプルNo", 1, False)
                .gSubColumnValue("ロット完了", 0, False)
                .gSubWhere("製造ライン", m画面モード, , , , , , , , )
                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With

            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DN指定サンプル数"
                .gSubColumnValue("指定数", 0, False)
                .gSubWhere("製造ライン", m画面モード, , , , , , , , )
                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub txt品種_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt品種.TextChanged
        If Trim(Me.txt品種.Text) = "" Then
            Me.txt品種.Text = ""
            Exit Sub
        End If
        Dim 現在時刻 As DateTime = DateTime.Now
        '入力されている品種CDを元に品種名を表示する
        Select Case m画面モード
            Case 1      'プレーン製品
                Me.lbl品種.Text = CMdiMain.str品種名取得(1, Me.txt品種.Text)
                Dim 賞味期限 As Date
                Try
                    賞味期限 = DateAdd("d", Convert.ToInt32(CMdiMain.str所定賞味期間取得(1, Me.txt品種.Text)), 現在時刻)
                    Me.txt賞味期限年.Text = 賞味期限.Year.ToString
                    Me.txt賞味期限月.Text = 賞味期限.Month.ToString.PadLeft(2, "0"c)
                    Me.txt賞味期限日.Text = 賞味期限.Day.ToString.PadLeft(2, "0"c)
                Catch ex As Exception
                End Try
            Case Else   'ハード製品
                Me.lbl品種.Text = CMdiMain.str品種名取得(0, Me.txt品種.Text)
                Dim 賞味期限 As Date
                Try
                    賞味期限 = DateAdd("d", Convert.ToInt32(CMdiMain.str所定賞味期間取得(0, Me.txt品種.Text)), 現在時刻)
                    Me.txt賞味期限年.Text = 賞味期限.Year.ToString
                    Me.txt賞味期限月.Text = 賞味期限.Month.ToString.PadLeft(2, "0"c)
                    Me.txt賞味期限日.Text = 賞味期限.Day.ToString.PadLeft(2, "0"c)
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Function blnロット重複有り_製造製品() As Boolean
        With New CSqlEx
            .gSubSelect("COUNT(*)")
            .gSubFrom("DN製造製品")
            .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Private Function blnロット重複有り_トラッキング() As Boolean
        With New CSqlEx
            .gSubSelect("COUNT(*)")
            .gSubFrom("DNトラッキング")
            .gSubWhere("ロットNo COLLATE Japanese_CS_AS_KS_WS", Me.txtロットNo.Text, , , , , , , True)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Private Function bln品種有り() As Boolean
        With New CSqlEx
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM品種")
            .gSubWhere("品種CD", Me.txt品種.Text, , , , , , , False)
            Select Case m画面モード
                Case 1  'プレーン
                    .gSubWhere("製品区分", 1, , , , , , , False)
                Case Else   'ハード
                    .gSubWhere("製品区分", 0, , , , , , , False)
            End Select

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                Return True
            Else
                Return False
            End If
        End With
    End Function

    Private Sub txt品種_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt品種.Leave
        Try
            If Trim(Me.txt品種.Text) = "" Then
                Me.lbl品種.Text = ""
                Exit Sub
            End If

            If Me.lbl品種.Text = "" Then
                CMsg.gMsg_エラー("品種情報が正しくありません")
                Me.txt品種.Text = ""
                Me.txt品種.Focus()
                Exit Sub
            End If

            mSubボタン設定()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtロットNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtロットNo.Leave
        Try
            If Trim(Me.txtロットNo.Text) = "" Then
                Me.txtロットNo.Text = ""
                Exit Sub
            End If

            Me.txtロットNo.Text = Me.txtロットNo.Text.PadLeft(3, "0"c)
            '入力情報のチェック（DN入庫製品に登録済のロットNoは使用できない）
            If blnロット重複有り_トラッキング() Or blnロット重複有り_製造製品() Then
                MessageBox.Show("既に利用させているロットNoです。")
                Me.txtロットNo.Focus()
                Me.btnF1.Enabled = False
                Exit Sub
            End If

            mSubボタン設定()

        Catch ex As Exception
        End Try
    End Sub


    Private Sub mSubボタン設定()
        If Trim(Me.txt品種.Text) <> "" And Trim(Me.txtロットNo.Text) <> "" And _
        Trim(Me.txt賞味期限年.Text) <> "" And Trim(Me.txt賞味期限月.Text) <> "" And Trim(Me.txt賞味期限日.Text) <> "" And _
        Trim(Me.txt醗酵開始年.Text) <> "" And Trim(Me.txt醗酵開始月.Text) <> "" And Trim(Me.txt醗酵開始日.Text) <> "" And Trim(Me.txt醗酵開始時.Text) <> "" And Trim(Me.txt醗酵開始分.Text) <> "" Then
            Me.btnF1.Enabled = True
        Else
            Me.btnF1.Enabled = False
        End If
    End Sub

End Class

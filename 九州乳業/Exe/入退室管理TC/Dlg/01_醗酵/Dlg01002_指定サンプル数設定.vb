
Imports System.Data.Common
Public Class Dlg01002_指定サンプル数設定

    Private Sub Dlg01002_指定サンプル数設定_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初期値設定
        Select Case m画面モード
            Case 0
                Me.lblライン名称.Text = "ハード１"
            Case 1
                Me.lblライン名称.Text = "プレーン１"
            Case 2
                Me.lblライン名称.Text = "ハード２"
            Case Else
        End Select
        入庫設定表示()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        '入力チェック
        If Not bln入力チェック() Then
            CMsg.gMsg_エラー("指定数を入力して下さい。")
            Exit Sub
        End If

        '入力情報をDN指定サンプル数に更新
        Update指定サンプル数()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Function bln入力チェック() As Boolean
        If Me.txtサンプルNo1.Text = "" Then
            Me.txtサンプルNo1.Focus()
            Return False
        ElseIf Me.txtサンプルNo2.Text = "" Then
            Me.txtサンプルNo2.Focus()
            Return False
        ElseIf Me.txtサンプルNo3.Text = "" Then
            Me.txtサンプルNo3.Focus()
            Return False
        ElseIf Me.txtサンプルNo4.Text = "" Then
            Me.txtサンプルNo4.Focus()
            Return False
        ElseIf Me.txtサンプルNo5.Text = "" Then
            Me.txtサンプルNo5.Focus()
            Return False
        ElseIf Me.txtサンプルNo6.Text = "" Then
            Me.txtサンプルNo6.Focus()
            Return False
        ElseIf Me.txtサンプルNo7.Text = "" Then
            Me.txtサンプルNo7.Focus()
            Return False
        ElseIf Me.txtサンプルNo8.Text = "" Then
            Me.txtサンプルNo8.Focus()
            Return False
        ElseIf Me.txtサンプルNo9.Text = "" Then
            Me.txtサンプルNo9.Focus()
            Return False
        ElseIf Me.txtサンプルNo10.Text = "" Then
            Me.txtサンプルNo10.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub 入庫設定表示()
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.品種CD")
                .gSubSelect("B.品種名")
                .gSubSelect("A.ロットNo")
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
                        CNT += 1
                    End While

                    '表示更新
                    If CNT = 0 Then
                        '異常（ﾃﾞｰﾀ無し）
                        'ボタン
                        Me.btnF1.Enabled = False
                    End If

                End If

            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Try
            With New CSqlEx
                .gSubSelect("A.サンプルNo")
                .gSubSelect("A.指定数")
                .gSubFrom("DN指定サンプル数 A")
                .gSubWhere("A.製造ライン", m画面モード, , , , , , , False)
                .gSubOrderBy("A.サンプルNo")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        Select Case reader.GetValue(0)
                            Case 1
                                Me.txtサンプルNo1.Text = reader.GetValue(1)
                            Case 2
                                Me.txtサンプルNo2.Text = reader.GetValue(1)
                            Case 3
                                Me.txtサンプルNo3.Text = reader.GetValue(1)
                            Case 4
                                Me.txtサンプルNo4.Text = reader.GetValue(1)
                            Case 5
                                Me.txtサンプルNo5.Text = reader.GetValue(1)
                            Case 6
                                Me.txtサンプルNo6.Text = reader.GetValue(1)
                            Case 7
                                Me.txtサンプルNo7.Text = reader.GetValue(1)
                            Case 8
                                Me.txtサンプルNo8.Text = reader.GetValue(1)
                            Case 9
                                Me.txtサンプルNo9.Text = reader.GetValue(1)
                            Case 10
                                Me.txtサンプルNo10.Text = reader.GetValue(1)
                            Case Else
                        End Select
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

    Public Sub Update指定サンプル数()
        Try
            Dim i As Integer
            For i = 1 To 10
                With New CSql
                    .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                    .pテーブル名 = "DN指定サンプル数"
                    Select Case i
                        Case 1
                            .gSubColumnValue("指定数", Me.txtサンプルNo1.Text, False)
                            .gSubWhere("サンプルNo", 1, , , , , , , False)
                        Case 2
                            .gSubColumnValue("指定数", Me.txtサンプルNo2.Text, False)
                            .gSubWhere("サンプルNo", 2, , , , , , , False)
                        Case 3
                            .gSubColumnValue("指定数", Me.txtサンプルNo3.Text, False)
                            .gSubWhere("サンプルNo", 3, , , , , , , False)
                        Case 4
                            .gSubColumnValue("指定数", Me.txtサンプルNo4.Text, False)
                            .gSubWhere("サンプルNo", 4, , , , , , , False)
                        Case 5
                            .gSubColumnValue("指定数", Me.txtサンプルNo5.Text, False)
                            .gSubWhere("サンプルNo", 5, , , , , , , False)
                        Case 6
                            .gSubColumnValue("指定数", Me.txtサンプルNo6.Text, False)
                            .gSubWhere("サンプルNo", 6, , , , , , , False)
                        Case 7
                            .gSubColumnValue("指定数", Me.txtサンプルNo7.Text, False)
                            .gSubWhere("サンプルNo", 7, , , , , , , False)
                        Case 8
                            .gSubColumnValue("指定数", Me.txtサンプルNo8.Text, False)
                            .gSubWhere("サンプルNo", 8, , , , , , , False)
                        Case 9
                            .gSubColumnValue("指定数", Me.txtサンプルNo9.Text, False)
                            .gSubWhere("サンプルNo", 9, , , , , , , False)
                        Case 10
                            .gSubColumnValue("指定数", Me.txtサンプルNo10.Text, False)
                            .gSubWhere("サンプルNo", 10, , , , , , , False)

                    End Select
                    .gSubWhere("製造ライン", m画面モード, , , , , , , , )
                    If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                        Exit Sub
                    End If
                End With
            Next
        Catch ex As Exception
        Finally
        End Try
    End Sub
End Class

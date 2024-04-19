
Imports System.Data.Common

Public Class Dlg01999_品種登録
    Private Sub Dlg01999_品種登録_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初期表示
        Me.btnF1.Enabled = False

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        '入力されている品種CDを元に品種名を表示する
        Dim str入力品種情報 As String = CMdiMain.str品種名取得(9, Me.txt品種.Text)

        If str入力品種情報 <> "" Then
            CMsg.gMsg_エラー("入力された品種CDは既に利用されています。" & vbCrLf & "使用中品種名：" & str入力品種情報)
            Me.txt品種.Text = ""
            Me.txt品種.Focus()
            Exit Sub
        End If

        If bln品種名が存在する(Me.txt品種名.Text) Then
            CMsg.gMsg_エラー("入力された品種名は既に利用されています。")
            Me.txt品種名.Text = ""
            Me.txt品種名.Focus()
            Exit Sub
        End If

        If Not IsNumeric(Me.txt所定発酵時間.Text) Or Val(Me.txt所定発酵時間.Text) < 0 Then
            MessageBox.Show("所定発酵時間が正しくありません。")
            Me.txt所定発酵時間.Focus()
            Exit Sub
        End If

        If Not IsNumeric(Me.txt所定冷却時間.Text) Or Val(Me.txt所定冷却時間.Text) < 0 Then
            MessageBox.Show("所定冷却時間が正しくありません。")
            Me.txt所定冷却時間.Focus()
            Exit Sub
        End If

        If CMsg.gMsg_YesNo("登録を行ってもよろしいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '入力情報を登録
        Insert品種データ()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Public Sub Insert品種データ()
        Try
            With New CSql
                .gSubClearSQL()
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_INSERT
                .pテーブル名 = "DM品種"
                .gSubColumnValue("製品区分", Me.cmb製品区分.SelectedIndex, False)
                .gSubColumnValue("品種CD", Me.txt品種.Text, False)
                .gSubColumnValue("品種名", Me.txt品種名.Text, True)
                .gSubColumnValue("所定醗酵時間", Me.txt所定発酵時間.Text, False)
                .gSubColumnValue("所定冷却時間", Me.txt所定冷却時間.Text, False)
                .gSubColumnValue("登録日時", "GETDATE()", False)
                .gSubColumnValue("更新プログラム", Name, True)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With

        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Me.txt品種.Text = ""
        Me.txt品種名.Text = ""
        Me.txt所定発酵時間.Text = ""
        Me.txt所定冷却時間.Text = ""

    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub txt品種_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt品種.Leave
        Try
            If Trim(Me.txt品種.Text) = "" Then
                Me.lbl品種.Text = ""
                Exit Sub
            End If

            '入力されている品種CDを元に品種名を表示する
            Dim str入力品種情報 As String = CMdiMain.str品種名取得(9, Me.txt品種.Text)

            If str入力品種情報 <> "" Then
                CMsg.gMsg_エラー("入力された品種CDは既に利用されています。" & vbCrLf & "使用中品種名：" & str入力品種情報)
                Me.txt品種.Text = ""
                Me.txt品種.Focus()
                Exit Sub
            End If

            mSubボタン設定()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt品種名_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt品種名.Leave
        Try
            If Trim(Me.txt品種.Text) = "" Then
                Me.lbl品種.Text = ""
                Exit Sub
            End If

            Dim 入力品種名 As String = Me.txt品種名.Text
            If bln品種名が存在する(Me.txt品種名.Text) Then
                CMsg.gMsg_エラー("入力された品種名は既に利用されています。")
                Me.txt品種名.Text = ""
                Me.txt品種名.Focus()
                Exit Sub
            End If

            mSubボタン設定()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txt所定時間_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt所定発酵時間.Leave, txt所定冷却時間.Leave
        mSubボタン設定()
    End Sub

    Public Function bln品種名が存在する(ByVal str品種名 As String) As Boolean
        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("COUNT(A.品種CD)")
                .gSubFrom("DM品種 A")
                .gSubWhere("A.品種名", str品種名)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If reader.GetValue(0) > 0 Then
                            Return True
                        Else
                            Return False
                        End If
                    End While
                End If
            End With
            Return False
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Private Sub mSubボタン設定()
        If Trim(Me.txt品種.Text) <> "" And Trim(Me.txt品種名.Text) <> "" And Trim(Me.txt所定発酵時間.Text) <> "" And Trim(Me.txt所定冷却時間.Text) <> "" Then
            Me.btnF1.Enabled = True
        Else
            Me.btnF1.Enabled = False
        End If
    End Sub
End Class

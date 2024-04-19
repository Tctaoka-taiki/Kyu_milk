
Imports System.Data.Common

Public Class Dlg01023_温度

    Private Sub Dlg01023_温度_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.cmb設備名称.Text = "醗酵倉庫"

        Me.txt指定年.Text = Now.Year.ToString
        Me.txt指定月.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt指定日.Text = Now.Day.ToString.PadLeft(2, "0"c)
    End Sub
    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If Trim(cmb設備名称.Text) = "" Then
            MessageBox.Show("設備名称を選択してください。")
            Me.cmb設備名称.Focus()
            Exit Sub
        End If
        If Me.txt指定年.Text = "" And Me.txt指定年.Text = "" And Me.txt指定年.Text = "" Then
            MessageBox.Show("指定日を入力してください。")
            Me.txt指定年.Focus()
            Exit Sub
        Else
            Dim str賞味期限日時 As String = Me.txt指定年.Text.PadLeft(4, "0"c) & "/" & Me.txt指定月.Text.PadLeft(2, "0"c) & "/" & Me.txt指定日.Text.PadLeft(2, "0"c) & " 00:00:00"
            If Not IsDate(str賞味期限日時) Then
                MessageBox.Show("指定日が正しくありません。")
                Me.txt指定年.Focus()
                Exit Sub
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class

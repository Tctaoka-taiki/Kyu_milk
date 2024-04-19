
Imports System.Data.Common

Public Class Dlg01031_生産問合設定

    Private Sub txt品種_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt品種.TextChanged
        If Trim(Me.txt品種.Text) = "" Then
            Me.lbl品種.Text = ""
            Exit Sub
        End If
        '入力されている品種CDを元に品種名を表示する
        Me.lbl品種.Text = CMdiMain.str品種名取得(9, Me.txt品種.Text)
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If Me.txt賞味期限年.Text = "" And Me.txt賞味期限年.Text = "" And Me.txt賞味期限年.Text = "" Then
        Else
            Dim str賞味期限日時 As String = Me.txt賞味期限年.Text.PadLeft(4, "0"c) & "/" & Me.txt賞味期限月.Text.PadLeft(2, "0"c) & "/" & Me.txt賞味期限日.Text.PadLeft(2, "0"c) & " 00:00:00"
            If Not IsDate(str賞味期限日時) Then
                MessageBox.Show("賞味期限が正しくありません。")
                Me.txt賞味期限年.Focus()
                Exit Sub
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class

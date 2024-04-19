
Imports System.Data.Common

Public Class Dlg01003_製品表示設定

    Private Sub txt品種_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt品種.TextChanged
        '入力されている品種CDを元に品種名を表示する
        Me.lbl品種.Text = CMdiMain.str品種名取得(9, Me.txt品種.Text)
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class

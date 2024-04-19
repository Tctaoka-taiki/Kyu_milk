
Imports System.Data.Common
Public Class Dlg01999_送信内容設定


    Private Sub Dlg01999_送信内容設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb送信ステータス.Items.Add("読出D5000")
        Me.cmb送信ステータス.Items.Add("書込D6100")
        Me.cmb送信ステータス.Items.Add("読出D6000")
        Me.cmb送信ステータス.Items.Add("書込D5050")
    End Sub


    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub
End Class

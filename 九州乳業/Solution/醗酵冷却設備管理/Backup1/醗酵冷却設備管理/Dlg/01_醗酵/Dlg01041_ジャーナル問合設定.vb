
Imports System.Data.Common

Public Class Dlg01041_ジャーナル問合

    Private Sub Dlg01041_ジャーナル問合_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.cmbPLC.Text = "醗酵"

        Me.txt指定年FR.Text = Now.Year.ToString
        Me.txt指定月FR.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt指定日FR.Text = Now.Day.ToString.PadLeft(2, "0"c)
        Me.txt指定時FR.Text = Now.Hour.ToString.PadLeft(2, "0"c)
        Me.txt指定分FR.Text = Now.Minute.ToString.PadLeft(2, "0"c)
      
        Me.txt指定年TO.Text = Now.Year.ToString
        Me.txt指定月TO.Text = Now.Month.ToString.PadLeft(2, "0"c)
        Me.txt指定日TO.Text = Now.Day.ToString.PadLeft(2, "0"c)
        Me.txt指定時TO.Text = Now.Hour.ToString.PadLeft(2, "0"c)
        Me.txt指定分TO.Text = Now.Minute.ToString.PadLeft(2, "0"c)
    End Sub
    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If Trim(cmbPLC.Text) = "" Then
            MessageBox.Show("設備名称を選択してください。")
            Me.cmbPLC.Focus()
            Exit Sub
        End If
        If Me.txt指定年FR.Text = "" And Me.txt指定年FR.Text = "" And Me.txt指定年FR.Text = "" Then
            MessageBox.Show("指定日を入力してください。")
            Me.txt指定年FR.Focus()
            Exit Sub
        Else
            Dim str賞味期限日時 As String = Me.txt指定年FR.Text.PadLeft(4, "0"c) & "/" & Me.txt指定月FR.Text.PadLeft(2, "0"c) & "/" & Me.txt指定日FR.Text.PadLeft(2, "0"c) & " 00:00:00"
            If Not IsDate(str賞味期限日時) Then
                MessageBox.Show("指定日が正しくありません。")
                Me.txt指定年FR.Focus()
                Exit Sub
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

End Class

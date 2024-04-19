Public Class Dlg01999_送受信内容表示

    Public 送信HEXデータ As String
    Public OFFSET As Integer
    Private Sub Dlg01999_送信内容表示_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        画面表示()
    End Sub

    Private Sub 画面表示()
        Dim i As Integer
        Dim j As Integer
        Dim デバイス数 As Integer = 送信HEXデータ.Length / 4
        Dim 処理データ As String = ""
        For i = 0 To デバイス数 - 1
            dgvデバイス.Rows.Add()
            dgvデバイス(0, i).Value = OFFSET + i
            処理データ = Mid(送信HEXデータ, (i * 4) + 1, 4)
            Dim BIT As String = Convert.ToString(CInt("&H" & 処理データ), 2).PadLeft(16, "0"c)

            For j = 0 To 15
                dgvデバイス.Columns(j + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvデバイス.Columns(j + 1).Width = 30
                dgvデバイス(j + 1, i).Value = Mid(BIT, j + 1, 1)

            Next
        Next
        dgvデバイス.CurrentCell = Nothing

    End Sub
End Class

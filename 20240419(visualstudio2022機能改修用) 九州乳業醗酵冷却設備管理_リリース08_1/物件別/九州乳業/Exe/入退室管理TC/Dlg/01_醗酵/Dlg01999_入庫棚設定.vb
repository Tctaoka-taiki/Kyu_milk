
Imports System.Data.Common
Public Class Dlg01999_入庫棚設定
    Public int指示作成モード As Integer
    Public str指示データ As String = ""

    Private Sub Dlg01999_入庫棚設定_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case int指示作成モード
            Case 0
                lblライン.Text = "ハード1"
                lbl列.Text = "2"
            Case 1
                lblライン.Text = "プレーン1"
                lbl列.Text = "1"
            Case 2
                lblライン.Text = "ハード2"
                lbl列.Text = "2"
        End Select

        '現在未使用の最少SEQを取得
        Me.txtSEQ.Text = int最少ユニットSEQ()

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        送信データ作成()
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub 送信データ作成()
        ''SEQデータ
        'str指示データ = "00FFQW0D0050500A" & CMdiMain.Hex変換(Int(Me.txtSEQ.Text))
        ''ロケデータ
        ''FROM　入庫ST（固定)
        'Select Case int指示作成モード
        '    Case 0
        '        str指示データ = str指示データ & "100200000000"
        '    Case 1
        '        str指示データ = str指示データ & "100100000000"
        '    Case 2
        '        str指示データ = str指示データ & "100400000000"
        'End Select
        ''TO
        'str指示データ = str指示データ & CMdiMain.Hex変換(Int(Me.lbl列.Text))
        'str指示データ = str指示データ & CMdiMain.Hex変換(Int(Me.txt連.Text))
        'str指示データ = str指示データ & CMdiMain.Hex変換(Int(Me.txt段.Text))
    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Function int最少ユニットSEQ() As String
        Dim reader As DbDataReader = Nothing
        Dim 最少ユニットSEQ As Integer = 1
        Try
            With New CSqlEx
                .gSubSelect("isnull(MAX(A.ユニットSEQ),0)")
                .gSubFrom("DNトラッキング A")
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        最少ユニットSEQ = reader.GetValue(0) + 1
                    End While
                End If

            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Return 最少ユニットSEQ
    End Function
End Class

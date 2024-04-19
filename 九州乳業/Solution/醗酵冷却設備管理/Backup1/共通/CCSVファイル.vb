'Public MustInherit Class CSVファイル処理
Public Class CCSVファイル
    Public Shared Sub ファイル単位処理(ByVal ファイルパス As String, ByVal 行単位処理 As 行単位処理Delegate)
        ファイル単位処理(ファイルパス, System.Text.Encoding.GetEncoding(932), 行単位処理)
    End Sub

    Public Shared Sub ファイル単位処理(ByVal ファイルパス As String, ByVal エンコーディング As System.Text.Encoding, ByVal 行単位処理 As 行単位処理Delegate)
        Dim reader As System.IO.StreamReader = New System.IO.StreamReader(ファイルパス, エンコーディング)
        Do
            Dim 行 As String = reader.ReadLine()
            If 行 = Nothing Then Exit Do
            Dim 配列 As String() = 行.Split(Char.Parse(","))

            行単位処理(配列)
        Loop
        reader.Close()
    End Sub

    'Public MustOverride Sub 行単位処理(ByVal 配列 As String())
    Public Delegate Sub 行単位処理Delegate(ByVal 配列 As String())
End Class

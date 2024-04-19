Namespace セキュリティ管理
    Public Class Cタグ割当
        Public タグID文字列 As String
        Public タグID As Byte()
        Public 許可Dic As New Dictionary(Of Long, C許可)
    End Class

    Public Class C許可
        Public 許可パターンID As Long
        Public ゲートDic As New List(Of Cゲート)
        Public Sub New(ByVal ID As Long)
            許可パターンID = ID
        End Sub
    End Class

    Public Class Cゲート
        Public ゲートID As Long
        Public アンテナ番号 As Long
        Public コンバータ番号 As Long
        Public Sub New()
        End Sub
        Public Sub New(ByVal g As Long, ByVal a As Long, ByVal c As Long)
            ゲートID = g
            アンテナ番号 = a
            コンバータ番号 = c
        End Sub
    End Class
    Public Class Cセキュリティ管理
        Public ゲートDic As New Dictionary(Of Long, Cゲート)
        Public 許可パターンDic As New Dictionary(Of Long, C許可)

        ''' <summary>タグIDがキーで値がCタグ</summary>
        ''' <remarks></remarks>
        Public 許可割当 As New Dictionary(Of Byte(), Cタグ割当)

#Region "ゲート追加"
        Public Sub ゲート追加(ByVal o As Cゲート)
            With ゲートDic
                If .ContainsKey(o.ゲートID) Then
                    .Item(o.ゲートID) = o
                Else
                    .Add(o.ゲートID, o)
                End If
            End With
        End Sub
        Public Sub ゲート追加(ByVal ファイルパス As String)
            CCSVファイル.ファイル単位処理(ファイルパス, AddressOf ゲート追加)
        End Sub
        Private Sub ゲート追加(ByVal 配列 As String())
            If 配列.Length <> 3 Then
                Throw New Exception("項目数の一致しないデータが見つかりました。")
            End If
            Dim ゲート As New Cゲート
            With ゲート
                .ゲートID = Long.Parse(配列(0))
                .コンバータ番号 = Long.Parse(配列(1))
                .アンテナ番号 = Long.Parse(配列(2))
            End With
            ゲート追加(ゲート)
        End Sub
#End Region

#Region "許可パターン追加"
        ''' <summary></summary>
        ''' <param name="許可パターンID"></param>
        ''' <param name="ゲートID"></param>
        ''' <remarks>ゲートは既に追加していることが前提</remarks>
        Public Sub 許可パターン追加(ByVal 許可パターンID As Long, ByVal ゲートID As Long)
            If Not ゲートDic.ContainsKey(ゲートID) Then
                Throw New Exception("ゲートID「" & ゲートID & "」がマスタに存在しません。")
            End If
            'なければ
            If Not 許可パターンDic.ContainsKey(許可パターンID) Then
                '新規
                許可パターンDic.Add(許可パターンID, New C許可(許可パターンID))
            End If
            許可パターンDic(許可パターンID).ゲートDic.Add(ゲートDic(ゲートID)) 'ゲートは既に追加していることが前提
        End Sub
        Public Sub 許可パターン追加(ByVal ファイルパス As String)
            CCSVファイル.ファイル単位処理(ファイルパス, AddressOf 許可パターン追加)
        End Sub
        Private Sub 許可パターン追加(ByVal 配列 As String())
            If 配列.Length <> 2 Then
                Throw New Exception("項目数の一致しないデータが見つかりました。")
            End If
            許可パターン追加(Long.Parse(配列(0)), Long.Parse(配列(1)))
        End Sub
#End Region

#Region "割当追加"
        Public Sub 割当追加(ByVal タグID文字列 As String, ByVal 許可パターンID As Long)
            Dim タグID As Byte() = GetタグID(タグID文字列)
            If Not 許可パターンDic.ContainsKey(許可パターンID) Then
                Throw New Exception("許可パターンID「" & 許可パターンID & "」がマスタに存在しません。")
            End If
            If Not 許可割当.ContainsKey(タグID) Then
                Dim o As New Cタグ割当()
                o.タグID = タグID
                o.タグID文字列 = タグID文字列
                許可割当.Add(タグID, o)
            End If
            許可割当(タグID).許可Dic.Add(許可パターンID, 許可パターンDic(許可パターンID))
        End Sub
        Public Sub 割当追加(ByVal ファイルパス As String)
            CCSVファイル.ファイル単位処理(ファイルパス, AddressOf 割当追加)
        End Sub
        Private Sub 割当追加(ByVal 配列 As String())
            If 配列.Length <> 2 Then
                Throw New Exception("項目数の一致しないデータが見つかりました。")
            End If
            割当追加(配列(0), Long.Parse(配列(1)))
        End Sub
#End Region

        Public Sub test()
            Dim o As New Cセキュリティ管理

            'ゲートデータを読み込んで登録する
            ゲート追加(New Cゲート(1, 1, 1))
            ゲート追加(New Cゲート(2, 1, 2))
            ゲート追加(New Cゲート(3, 1, 3))
            ゲート追加(New Cゲート(4, 1, 4))

            '
            許可パターン追加(1, 1)
            許可パターン追加(2, 1)

            '割当追加
            割当追加("11111", 1)
            割当追加("11112", 2)

        End Sub

        Public Function GetタグID(ByVal タグID文字列 As String) As Byte()
            Return 共通.CUtil.Stringからバイト配列を生成(タグID文字列)
        End Function
        Public Function GetタグID文字列(ByVal タグID As Byte()) As String
            Return Nothing
        End Function
    End Class


End Namespace

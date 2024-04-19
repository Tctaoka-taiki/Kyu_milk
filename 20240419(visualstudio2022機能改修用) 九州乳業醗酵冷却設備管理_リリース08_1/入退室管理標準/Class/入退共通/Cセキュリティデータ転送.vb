Imports 入退共通.セキュリティ管理

Public Class Cセキュリティデータ転送
    Protected _メインログ As Iメインログ

    Public Event セキュリティデータ書き込み完了(ByVal o As Object)
    Public Sub Onセキュリティデータ書き込み完了(ByVal o As Object)
        RaiseEvent セキュリティデータ書き込み完了(o)
    End Sub

    Public Event セキュリティデータ書き込み開始タイムアウト(ByVal o As Object)
    Public Sub Onセキュリティデータ書き込み開始タイムアウト(ByVal o As Object)
        RaiseEvent セキュリティデータ書き込み開始タイムアウト(o)
    End Sub

    Public Event セキュリティデータ書き込み終了タイムアウト(ByVal o As Object)
    Public Sub Onセキュリティデータ書き込み終了タイムアウト(ByVal o As Object)
        RaiseEvent セキュリティデータ書き込み終了タイムアウト(o)
    End Sub

    Public Sub New(ByVal ログ As Iメインログ)
        _メインログ = ログ
    End Sub


    ''' <summary>
    ''' タグID文字列の作成
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function タグID文字列作成(ByVal value As Byte()) As String
        Dim タグID文字列 As String = ""

        For Each b As Byte In value
            タグID文字列 = タグID文字列 + Strings.Right("0" + b.ToString("X"), 2)
        Next
        Return タグID文字列
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="アドレス"></param>
    ''' <param name="タグID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function タグIDデバイスを作成(ByVal アドレス As Integer, ByVal タグID As Byte()) As CMX.Device()
        'タグIDをセット
        Dim dev As New CMX.Device("ZR", アドレス, "認証タグID")
        Dim devArray() As CMX.Device = CMX.GetDeviceRange(dev, 8)

        For i As Integer = 0 To タグID.Length - 1
            'LowとHighが逆です
            devArray(i \ 2).ByteValue((i + 1) Mod 2) = タグID(i)
        Next
        Return devArray
    End Function

    ''' <summary>
    ''' 認証デバイスを作成します
    ''' </summary>
    ''' <param name="アドレス"></param>
    ''' <param name="許可ビット"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function 認証デバイスを作成(ByVal アドレス As Integer, ByVal 許可ビット As UInt32) As CMX.Device()
        Dim dev As New CMX.Device("ZR", アドレス, "許可ビット")
        Dim devArray() As CMX.Device = CMX.GetDeviceRange(dev, 2)

        For j As Integer = 0 To devArray.Length - 1
            Array.Copy(BitConverter.GetBytes(許可ビット), j * 2, devArray(j).ByteValue, 0, 2)
        Next
        Return devArray
    End Function

    ''' <summary>
    ''' セキュリティデータ転送
    ''' </summary>
    ''' <remarks></remarks>
    Public Function セキュリティデータ転送(ByVal セキュリティデータ As Cセキュリティ管理, ByVal plcリスト As CPlcDataリスト, ByVal sss As Settings) As C入退サーバメッセージ.セキュリティデータ転送.E処理結果
        For Each ooo As PlcData In plcリスト
            With ooo
                'ログに表示
                _メインログ.メインログ作成("(" + .Plcオブジェクト.拠点名 + ")セキュリティデータ転送開始", EventLogEntryType.Information)

                '入退レジスタ位置取得
                Dim top As Integer = Convert.ToInt32(.Plcオブジェクト.GetIniParamByTag("入場状態レジスタ開始位置").値)

                '書き込みレジスタ
                Dim devList As New List(Of CMX.Device)

                Dim current As Integer = Convert.ToInt32(.Plcオブジェクト.GetIniParamByTag("セキュリティデータレジスタ開始位置").値)
                '２０ワード移動
                current += 20

                Dim 件数 As Integer = 0
                For Each 割当 As Cタグ割当 In セキュリティデータ.許可割当.Values
                    'タグデバイス作成
                    devList.AddRange(タグIDデバイスを作成(current, 割当.タグID))
                    current += 8

                    '許可情報をセット
                    Dim 許可ビット As UInt32 = 許可パターンビット作成(割当)
                    '許可ビット = &HFFFFFFFFL
                    devList.AddRange(認証デバイスを作成(current, 許可ビット))
                    current += 2

                    If sss.APL_アンチパスバック転送有効 Then
                        '転送済みデータの入退状態取得
                        Dim inOut As Boolean = True '何もない場合は退場状態
                        '新しい転送データを作成
                        Try
                            '新しいデバイスに書き込み設定
                            Dim newIdx As Integer = top + 件数
                            Dim newDev As New CMX.Device("ZR", newIdx, "入退状態" + 件数.ToString)
                            newDev.BoolValue = inOut

                            '書き込みデバイスに追加
                            devList.Add(newDev)
                        Catch ex As Exception
                            'メインログ作成("タグID[" + タグID文字列作成(転送row.タグID) + "]は複数登録されています", EventLogEntryType.Error)
                        End Try

                    End If
                    件数 += 1
                Next

                '登録個数を設定
                With ooo
                    current = Convert.ToInt32(.Plcオブジェクト.GetIniParamByTag("セキュリティデータレジスタ開始位置").値)
                    Dim Rブロック登録個数 As New CMX.Device("ZR", current)
                    Rブロック登録個数.UShortValue = Convert.ToUInt16(件数)
                    devList.Add(Rブロック登録個数)
                End With

                '転送実行前に並べ替え
                devList.Sort()

                'ハンドシェイク開始
                Dim outDev As CMX.Device = .Plcオブジェクト.セキュリティデータ書込要求.Convertデバイス()
                Dim inDev As CMX.Device = .Plcオブジェクト.セキュリティデータ書込応答.Convertデバイス()
                .SecurityHandshake = New CMX.HandShake.ActiveWrite(.Wrap, outDev, inDev, devList)
                .SecurityHandshake.StatusCheckInterval = 100
                .SecurityHandshake.StartTimeoutInterval = 60000 '１分以内にハンドシェイクが開始しない場合は、エラー
                .SecurityHandshake.EndTimeoutInterval = 60000   '開始から１分以内にハンドシェイクが終了しない場合は、エラー
                AddHandler .SecurityHandshake.Complete, AddressOf Onセキュリティデータ書き込み完了
                AddHandler .SecurityHandshake.StartTimeout, AddressOf Onセキュリティデータ書き込み開始タイムアウト
                AddHandler .SecurityHandshake.EndTimeout, AddressOf Onセキュリティデータ書き込み終了タイムアウト
                .SecurityHandshake.Start()
            End With
            '最後のStartが開始され、最初の要求がタイムアウトになる
            System.Windows.Forms.Application.DoEvents()
        Next
        Return C入退サーバメッセージ.セキュリティデータ転送.E処理結果.正常
    End Function

    ''' <summary>
    ''' 許可パターンビット作成
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function 許可パターンビット作成(ByVal o As Cタグ割当) As UInt32
        Dim 許可ビット As UInt32 = 0

        For Each 許可 As C許可 In o.許可Dic.Values
            For Each ゲート As Cゲート In 許可.ゲートDic
                許可ビット = 許可ビット Or CUInt(2 ^ (((ゲート.コンバータ番号 - 1) * 4) + ゲート.アンテナ番号 - 1))
            Next
        Next
        Return 許可ビット
    End Function
End Class

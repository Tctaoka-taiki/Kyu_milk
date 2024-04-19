''' <summary>
''' 入退ステータス
''' </summary>
''' <remarks></remarks>
Public Enum E入退ステータス
    正常 = 0
    ID異常 = 1
    通行不許可 = 2
    タイムアウト = 3
    割り込み通過 = 4
    不正通過 = 5
    入場中に入場 = 6
    退場中に退場 = 7
    タグID未登録 = 8
End Enum

Public Class C認証ログレコード
    Public 日付 As Date
    Public ステータス As E入退ステータス
    Public コンバータ番号 As Integer
    Public 入退区分 As Boolean
    Public タグID(7) As Byte
    Public アンテナ番号 As Integer
    Public 論理局番 As Integer

    Public Function SetValue(ByVal p As PlcData, ByVal current As Integer) As Integer
        With Me
            .論理局番 = p.Plcオブジェクト.論理局番

            'コンバータ番号
            .コンバータ番号 = p.DataList(current).ShortValue
            current += 1

            'アンテナ番号
            .アンテナ番号 = p.DataList(current).ShortValue
            current += 1

            'タグID
            For j As Integer = 0 To 3
                .タグID(j * 2) = p.DataList(current).ByteValue(1)
                .タグID(j * 2 + 1) = p.DataList(current).ByteValue(0)
                current += 1
            Next
            'タグIDのダミー
            current += 4
            'タグIDをひっくり返す
            'Array.Reverse(タグID)

            '入退ステータス
            .ステータス = CType(p.DataList(current).ShortValue, E入退ステータス)
            current += 1

            '入退区分
            .入退区分 = p.DataList(current).BoolValue
            current += 1

            '日時（LowByteとHighByteが逆です）
            .日付 = New Date(2000 + BCDToInt32(p.DataList(current).ByteValue(1)), _
                                BCDToInt32(p.DataList(current).ByteValue(0)), _
                                BCDToInt32(p.DataList(current + 1).ByteValue(1)), _
                                BCDToInt32(p.DataList(current + 1).ByteValue(0)), _
                                BCDToInt32(p.DataList(current + 2).ByteValue(1)), _
                                BCDToInt32(p.DataList(current + 2).ByteValue(0)))

            current += 3
        End With

        Return current
    End Function

    Public Sub 書込み処理(ByVal writer As System.IO.StreamWriter)
        writer.WriteLine(Format(日付, "MM/dd HH:mm:ss") & "," _
                            & コンバータ番号 & "," & アンテナ番号 & "," & タグID.ToString _
                            & "," & 入退区分 & "," & 論理局番 & "," & ステータス)
    End Sub

    ''' <summary>
    ''' ＢＣＤ数値を３２ビット数値に変換
    ''' </summary>
    ''' <param name="bcd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function BCDToInt32(ByVal bcd As Byte) As Integer
        Return Convert.ToInt32(bcd.ToString("X"), 10)
    End Function
End Class

Public Class C認証ログ
    Protected _メインログ As Iメインログ

    Public Sub New(ByVal ログ As Iメインログ)
        _メインログ = ログ
    End Sub

    Public Sub 認証ログCSV書込み処理(ByVal p As PlcData, ByVal write As System.IO.StreamWriter)
        Dim current As Integer = 0
        '最初のデバイスには件数が入っている
        Dim 件数 As Integer = p.DataList(current).ShortValue
        current += 1
        For i As Integer = 0 To 件数 - 1
            Dim レコード As New C認証ログレコード
            current = レコード.SetValue(p, current)
            レコード.書込み処理(write)
        Next
    End Sub

    Public Sub 認証ログ読出し処理(ByVal p As PlcData)
        'ログ件数取得領域
        Dim cntDev As CMX.Device = p.Plcオブジェクト.認証ログ件数.Convertデバイス()
        'ログ件数読み出し
        Try
            p.Wrap.Read(cntDev)
        Catch ex As CMX.CMXException
            _メインログ.メインログ作成(ex.Message, EventLogEntryType.Error)
            Exit Sub
        End Try

        '件数を変更

        With p.Plcオブジェクト
            .認証ログ局番.件数 = cntDev.ShortValue
            .認証ログアンテナ.件数 = cntDev.ShortValue
            .認証ログタグID.件数 = cntDev.ShortValue
            .認証ログステータス.件数 = cntDev.ShortValue
            .認証ログ認証入出区分.件数 = cntDev.ShortValue
            .認証ログ年月.件数 = cntDev.ShortValue
            .認証ログ日時.件数 = cntDev.ShortValue
            .認証ログ分秒.件数 = cntDev.ShortValue
            p.DataList.Clear()
            p.DataList.Add(.認証ログ件数.Convertデバイス())
            p.DataList.AddRange(.認証ログ局番.ConvertデバイスList())
            p.DataList.AddRange(.認証ログアンテナ.ConvertデバイスList())
            p.DataList.AddRange(.認証ログタグID.ConvertデバイスList())
            p.DataList.AddRange(.認証ログステータス.ConvertデバイスList())
            p.DataList.AddRange(.認証ログ認証入出区分.ConvertデバイスList())
            p.DataList.AddRange(.認証ログ年月.ConvertデバイスList())
            p.DataList.AddRange(.認証ログ日時.ConvertデバイスList())
            p.DataList.AddRange(.認証ログ分秒.ConvertデバイスList())
            '読み出し用に並べ替え
            p.DataList.Sort()
        End With

        Try
            '読み出し
            p.Wrap.ReadList(p.DataList)
        Catch ex As CMX.CMXException
            _メインログ.メインログ作成(ex.Message, EventLogEntryType.Error)
            Exit Sub
        End Try
    End Sub
End Class

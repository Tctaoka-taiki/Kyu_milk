Imports System.Xml

''' <summary>
''' 汎用ユーティリティクラス
''' </summary>
''' <remarks></remarks>
Public Class CUtil
    Private Sub New()
    End Sub

    Public Class 設定関連
        Private Sub New()
        End Sub

        Public Shared Function 設定Boolean値読込(ByVal キー名 As String, Optional ByVal デフォルト値 As Boolean = False) As Boolean
            Dim 結果 As Boolean
            If Boolean.TryParse(設定文字列読込(キー名), 結果) Then
                Return 結果
            End If

            Return デフォルト値
        End Function

        Public Shared Function 設定文字列読込(ByVal キー名 As String, Optional ByVal デフォルト値 As String = "") As String
            Try
                Dim アプリケーション設定Reader As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader

                設定文字列読込 = CType(アプリケーション設定Reader.GetValue(キー名, GetType(System.String)), String)
                ''取得できない時はデフォルトを返す
            Catch ex As InvalidOperationException
                設定文字列読込 = デフォルト値
            End Try
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="キー名"></param>
        ''' <param name="値"></param>
        ''' <returns>書込み成功時True</returns>
        ''' <remarks></remarks>
        Public Shared Function 設定文字列書込(ByVal キー名 As String, ByVal 値 As String) As Boolean
            Dim アプリケーションパス As String = System.Reflection.Assembly.Load("入退室管理").Location ' System.Reflection.Assembly.GetExecutingAssembly().Location
            'Dim アプリケーションディレクトリ As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            Dim document As System.Xml.XmlDocument = New XmlDocument
            document.Load(アプリケーションパス & ".config")
            For Each aa As System.Xml.XmlElement In document.GetElementsByTagName("appSettings")
                For Each キー As XmlElement In aa.GetElementsByTagName("add")
                    Dim コレクション As XmlAttributeCollection = キー.Attributes()
                    If キー.GetAttribute("key") = キー名 Then
                        キー.SetAttribute("value", 値)
                        document.Save(アプリケーションパス & ".config")
                        Return True
                    End If
                Next
                'なければキーを追加
                With CType(aa.AppendChild(document.CreateElement("add")), XmlElement)
                    .SetAttribute("key", キー名)
                    .SetAttribute("value", 値)
                    document.Save(アプリケーションパス & ".config")
                    Return True
                End With

            Next
        End Function

    End Class

    Public Shared Function NewByteArrayCopy(ByVal 入力 As Byte(), ByVal 先頭 As Integer, ByVal バイト長 As Integer) As Byte()
        Dim result As Byte() = New Byte(バイト長 - 1) {}
        Array.Copy(入力, 先頭, result, 0, バイト長)
        Return result
    End Function

    Public Shared Function バイト配列ToInteger(ByVal 入力 As Byte(), ByVal 先頭要素 As Integer, ByVal バイト長 As Integer) As Integer
        If バイト長 = 3 Then
            Return 入力(先頭要素) * &H10000 + 入力(先頭要素 + 1) * &H100 + 入力(先頭要素 + 2)
        ElseIf バイト長 = 2 Then
            Return 入力(先頭要素) * &H100 + 入力(先頭要素 + 1)
        Else
            Trace.Fail("未対応")
        End If
    End Function
    Public Shared Function バイト配列ToLong(ByVal 入力 As Byte(), ByVal 先頭要素 As Integer, ByVal バイト長 As Integer) As Long
        If バイト長 = 4 Then
            Return 入力(先頭要素) * &H1000000 + 入力(先頭要素 + 1) * &H10000 + 入力(先頭要素 + 2) * &H100 + 入力(先頭要素 + 3)
        ElseIf バイト長 = 3 Then
            Return 入力(先頭要素) * &H10000 + 入力(先頭要素 + 1) * &H100 + 入力(先頭要素 + 2)
        ElseIf バイト長 = 2 Then
            Return 入力(先頭要素) * &H100 + 入力(先頭要素 + 1)
        Else
            Trace.Fail("未対応")
        End If
    End Function
    Public Shared Sub IntegerToバイト配列(ByVal 出力 As Byte(), ByVal 先頭要素 As Integer, ByVal バイト長 As Integer, ByVal value As Integer)
        If バイト長 = 3 Then
            value -= CInt(Fix(value / &H1000000) * &H1000000)   '念のため４バイトデータの最上位バイトを捨てる

            出力(先頭要素) = CByte(Fix(value / &H10000))
            value -= CInt(Fix(value / &H10000) * &H10000)

            出力(先頭要素 + 1) = CByte(Fix(value / &H100))
            value -= CInt(Fix(value / &H100) * &H100)

            出力(先頭要素 + 2) = CByte(value)

            '別解
            '    データ部(17) = CByte(value >> 16) '１６ビット右シフト
            '    データ部(18) = CByte((value And &HFF00) >> 8)
            '    データ部(19) = CByte(value And &HFF)
        ElseIf バイト長 = 2 Then
            出力(先頭要素) = CByte(Fix(value / &H100))
            出力(先頭要素 + 1) = CByte(value Mod &H100)

            '別解
            'Dim o As Byte() = BitConverter.GetBytes(value)
            'If BitConverter.IsLittleEndian Then
            '    Array.Reverse(o)
            'End If
            '出力(先頭要素) = o(2)
            '出力(先頭要素 + 1) = o(3)
        Else
            Trace.Fail("未対応")
        End If
    End Sub

    Public Shared Function Stringからバイト配列を生成(ByVal value As String) As Byte()
        Dim 出力 As Byte() = New Byte(value.Length \ 2 - 1) {}
        StringToバイト配列(出力, 0, value)
        Return 出力
    End Function

    Public Shared Sub StringToバイト配列(ByVal 出力 As Byte(), ByVal 先頭要素 As Integer, ByVal value As String)
        Dim バイト長 As Integer = value.Length \ 2
        Dim i As Integer
        For i = 0 To バイト長 - 1
            出力(先頭要素 + i) = Convert.ToByte(value.Substring(i * 2, 2), 16)
        Next
    End Sub

    Public Shared Sub LongToバイト配列(ByVal 出力 As Byte(), ByVal 先頭要素 As Integer, ByVal バイト長 As Integer, ByVal value As Long)
        If バイト長 = 4 Then
            出力(先頭要素) = CByte(Fix(value / &H1000000))
            value -= CLng(Fix(value / &H1000000) * &H1000000)

            出力(先頭要素 + 1) = CByte(Fix(value / &H10000))
            value -= CLng(Fix(value / &H10000) * &H10000)

            出力(先頭要素 + 2) = CByte(Fix(value / &H100))
            value -= CLng(Fix(value / &H100) * &H100)

            出力(先頭要素 + 3) = CByte(value)
        ElseIf バイト長 = 3 Then
            value -= CLng(Fix(value / &H1000000) * &H1000000)   '念のため４バイトデータの最上位バイトを捨てる

            出力(先頭要素) = CByte(Fix(value / &H10000))
            value -= CLng(Fix(value / &H10000) * &H10000)

            出力(先頭要素 + 1) = CByte(Fix(value / &H100))
            value -= CLng(Fix(value / &H100) * &H100)

            出力(先頭要素 + 2) = CByte(value)

            '別解
            '    データ部(17) = CByte(value >> 16) '１６ビット右シフト
            '    データ部(18) = CByte((value And &HFF00) >> 8)
            '    データ部(19) = CByte(value And &HFF)
        ElseIf バイト長 = 2 Then
            出力(先頭要素) = CByte(Fix(value / &H100))
            出力(先頭要素 + 1) = CByte(value Mod &H100)

            '別解
            'Dim o As Byte() = BitConverter.GetBytes(value)
            'If BitConverter.IsLittleEndian Then
            '    Array.Reverse(o)
            'End If
            '出力(先頭要素) = o(2)
            '出力(先頭要素 + 1) = o(3)
        Else
            Trace.Fail("未対応")
        End If

    End Sub

    Public Shared Function BCDTo10進数(ByVal data As Byte(), ByVal top As Integer, ByVal 桁 As Integer) As Integer
        If 桁 = 4 Then
            BCDTo10進数 = ((data(top) And &HF0) >> 4) * 1000
            BCDTo10進数 += ((data(top) And &HF)) * 100
            BCDTo10進数 += ((data(top + 1) And &HF0) >> 4) * 10
            BCDTo10進数 += ((data(top + 1) And &HF))
        ElseIf 桁 = 2 Then
            BCDTo10進数 += ((data(top) And &HF0) >> 4) * 10
            BCDTo10進数 += ((data(top) And &HF))
        Else
            Trace.Fail("未対応")
        End If
    End Function

    Public Shared Sub 十進数ToBCD(ByVal value As Integer, ByVal 出力先 As Byte(), ByVal top As Integer, ByVal 桁 As Integer)
        If 桁 = 4 Then
            出力先(top) = CByte(Fix(value / 1000) * &H10)
            value = value Mod 1000
            出力先(top) += CByte(Fix(value / 100))
            value = value Mod 100
            出力先(top + 1) = CByte(Fix(value / 10) * &H10)
            value = value Mod 10
            出力先(top + 1) += CByte(value)
        ElseIf 桁 = 2 Then
            出力先(top) = CByte(Fix(value / 10) * &H10)
            value = value Mod 10
            出力先(top) += CByte(value)
        Else
            Trace.Fail("未対応")
        End If
    End Sub

    Public Shared Sub 十進数文字列ToBCD(ByVal 出力先 As Byte(), ByVal 配列の先頭要素番号 As Integer, ByVal データ As String)
        Dim i As Integer
        Dim index As Integer

        For i = 0 To データ.Length - 1
            index = i \ 2
            If i Mod 2 = 0 Then
                出力先(配列の先頭要素番号 + index) = CByte(データ.Substring(i, 1)) << 4
            Else
                出力先(配列の先頭要素番号 + index) = 出力先(配列の先頭要素番号 + index) Or CByte(データ.Substring(i, 1))
            End If
        Next
    End Sub
    Public Shared Function BCDTo十進数文字列(ByVal 入力 As Byte(), ByVal 配列の先頭要素番号 As Integer, ByVal 桁数 As Integer) As String
        BCDTo十進数文字列 = ""

        Dim i As Integer
        Dim index As Integer

        For i = 0 To 桁数 - 1
            index = i \ 2
            If i Mod 2 = 0 Then
                BCDTo十進数文字列 = BCDTo十進数文字列 & CStr(入力(配列の先頭要素番号 + index) >> 4)
            Else
                BCDTo十進数文字列 = BCDTo十進数文字列 & CStr(入力(配列の先頭要素番号 + index) And &HF)
            End If
        Next
    End Function

    Public Shared Sub DateToバイト配列(ByVal データ部 As Byte(), ByVal top As Integer, ByVal value As Date)
        Dim year As Byte = CByte(value.Year - 2000)
        Dim month As Byte = CByte(value.Month)
        Dim day As Byte = CByte(value.Day)
        Dim hour As Byte = CByte(value.Hour)
        Dim minute As Byte = CByte(value.Minute)
        Dim second As Byte = CByte(value.Second)

        Debug.Print(value.ToString)

        データ部(top) = year << 2
        Debug.Print(変換後(データ部))

        データ部(top) = データ部(top) Or (month >> 2)
        Debug.Print(変換後(データ部))

        データ部(top + 1) = month << 6
        Debug.Print(変換後(データ部))
        データ部(top + 1) = データ部(top + 1) Or (day << 1)
        Debug.Print(変換後(データ部))
        データ部(top + 1) = データ部(top + 1) Or (hour >> 4)
        Debug.Print(変換後(データ部))

        データ部(top + 2) = hour << 4
        Debug.Print(変換後(データ部))
        データ部(top + 2) = データ部(top + 2) Or (minute >> 2)

        データ部(top + 3) = データ部(top + 3) Or (minute << 6)
        Debug.Print(変換後(データ部))
        データ部(top + 3) = データ部(top + 3) Or second
        Debug.Print(変換後(データ部))

    End Sub

    Public Shared Function バイト配列ToDate(ByVal データ部 As Byte(), ByVal top As Integer) As Date
        Dim year As Byte
        Dim month As Byte
        Dim day As Byte
        Dim hour As Byte
        Dim minute As Byte
        Dim second As Byte

        year = (データ部(top) >> 2)
        month = CByte(((データ部(top) And &H3) << 2) Or (データ部(top + 1) >> 6))
        day = CByte((データ部(top + 1) And &H3E) >> 1) '&H3E = 00111110
        hour = CByte(((データ部(top + 1) And 1) << 4) Or ((データ部(top + 2) And &HF0) >> 4))
        minute = CByte(((データ部(top + 2) And &HF) << 2) Or (データ部(top + 3) >> 6))
        second = CByte(データ部(top + 3) And &H3F)

        Dim value As Date = New Date(year + 2000, month, day, hour, minute, second)
        Return value
    End Function

    Public Shared Function バイト配列ToHexString(ByVal data As Byte()) As String
        バイト配列ToHexString = ""
        For Each b As Byte In data
            バイト配列ToHexString = バイト配列ToHexString & Strings.Right("0" & Hex(b), 2)
        Next
    End Function
    Public Shared Function バイト配列ToString(ByVal 入力 As Byte(), ByVal 先頭要素 As Integer, ByVal バイト長 As Integer) As String
        If 先頭要素 < 入力.Length Then
            If バイト長 > 入力.Length Then
                バイト長 = 入力.Length
            End If
            バイト配列ToString = ""
            For i As Integer = 先頭要素 To 先頭要素 + バイト長 - 1
                バイト配列ToString = バイト配列ToString & Strings.Right("0" & Hex(入力(i)), 2)
            Next
        Else
            Return ""
        End If
    End Function

    Private Shared Function 変換後(ByVal data As Byte()) As String
        Return Convert10to2(data(1)) & Convert10to2(data(2)) & Convert10to2(data(3)) & Convert10to2(data(4))
    End Function

    '■機能：10進数を2進数に変換する。
    Private Shared Function Convert10to2(ByVal value As Byte) As String

        Dim lngBit As Long
        Dim strData As String = ""

        Do Until (value < 2 ^ lngBit)
            If (value And CLng(2 ^ lngBit)) <> 0 Then
                strData = "1" & strData
            Else
                strData = "0" & strData
            End If

            lngBit = lngBit + 1
        Loop

        Convert10to2 = Right("00000000" & strData, 8)

    End Function
End Class
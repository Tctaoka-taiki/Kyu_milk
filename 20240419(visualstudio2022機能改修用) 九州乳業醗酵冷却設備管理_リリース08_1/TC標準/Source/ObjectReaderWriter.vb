Public Class ObjectReaderWriter
    ''' <summary>
    ''' XMLファイルに書き込みまれたオブジェクトの情報を読み出します
    ''' </summary>
    ''' <param name="fileName">読み出しファイル名</param>
    ''' <param name="t">オブジェクトの型</param>
    ''' <remarks></remarks>
    Public Shared Function Read(ByVal fileName As String, ByVal t As Type) As Object
        Dim serializer As New System.Xml.Serialization.XmlSerializer(t)
        Dim o As Object

        'ファイルストリームを取得
        Dim fs As New System.IO.FileStream(fileName, System.IO.FileMode.Open)

        'XMLファイルから読み込み、逆シリアル化する
        o = serializer.Deserialize(fs)

        '閉じる
        fs.Close()

        Return o
        'Return x
    End Function

    ''' <summary>
    ''' オブジェクトの情報をシリアライズしてXMLファイルに書き込みます
    ''' </summary>
    ''' <param name="fileName">書き込みファイル名</param>
    ''' <param name="o">書き込むオブジェクト</param>
    ''' <remarks></remarks>
    Public Shared Sub Write(ByVal fileName As String, ByVal o As Object)
        Dim serializer As New System.Xml.Serialization.XmlSerializer(o.GetType)

        'ファイルストリームを取得
        Dim fs As System.IO.FileStream = New System.IO.FileStream(fileName, System.IO.FileMode.Create)

        'シリアル化し、XMLファイルに保存する
        serializer.Serialize(fs, o)

        '閉じる
        fs.Close()
    End Sub

End Class

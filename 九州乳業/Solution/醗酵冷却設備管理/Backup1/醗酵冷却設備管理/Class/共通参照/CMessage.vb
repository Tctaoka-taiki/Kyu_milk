Class CMessage

    Public Shared Function CreateMessageQueue(ByVal QueueName As String) As System.Messaging.MessageQueue
        Dim msgQ As System.Messaging.MessageQueue = Nothing

        'メッセージキューの作成
        msgQ = System.Messaging.MessageQueue.Create(QueueName)

        'ジャーナルの利用を有効にする
        msgQ.UseJournalQueue = True

        Return msgQ
    End Function
    ''' <summary>
    ''' オブジェクトを送信する
    ''' </summary>
    ''' <param name="SendQueueName"></param>
    ''' <param name="SendData"></param>
    ''' <param name="title"></param>
    ''' <remarks></remarks>
    Public Shared Sub Send(ByVal SendQueueName As String, ByVal SendData As Object, ByVal title As String)
        Dim msgQ As System.Messaging.MessageQueue = Nothing

        'メッセージキューの取得
        msgQ = New System.Messaging.MessageQueue(SendQueueName)

        'メッセージの送信
        Dim msg As New System.Messaging.Message
        msg.Formatter = New Messaging.XmlMessageFormatter()
        If title Is Nothing Then
            msg.Label = ""
        Else
            msg.Label = title
        End If
        msg.Body = SendData
        msgQ.Send(msg)
    End Sub

    Public Shared Sub Send(ByVal SendQueueName As String, ByVal SendData As Object)
        Send(SendQueueName, SendData, SendData.GetType.ToString)
    End Sub

    ''' <summary>
    ''' メッセージキューからメッセージを受信する
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '''
    Private Shared Function GetQueue(ByVal QueueName As String) As System.Messaging.MessageQueue
        Dim msgQ As System.Messaging.MessageQueue = Nothing

        'メッセージキューの取得
        msgQ = New System.Messaging.MessageQueue(QueueName)
        msgQ.Path = QueueName
        Return msgQ
    End Function

    ''' <summary>
    ''' メッセージを受信する
    ''' </summary>
    ''' <param name="ReceiveQueueName"></param>
    ''' <param name="AllowAutoCreateQueue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Receive(ByVal ReceiveQueueName As String, ByVal AllowAutoCreateQueue As Boolean) As System.Messaging.Message
        'キュー自動生成
        If AllowAutoCreateQueue Then
            If Not System.Messaging.MessageQueue.Exists(ReceiveQueueName) Then
                CreateMessageQueue(ReceiveQueueName)
            End If
        End If
        'メッセージの受信
        Return GetQueue(ReceiveQueueName).Receive()
    End Function
    ''' <summary>
    ''' メッセージキューから要求を取得する（タイプ指定）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReceiveAny(ByVal ReceiveQueueName As String, ByVal typeArray() As Type, Optional ByVal AllowAutoCreateQueue As Boolean = True) As Object
        'メッセージを受信
        Dim msg As System.Messaging.Message = Receive(ReceiveQueueName, AllowAutoCreateQueue)

        '型変換
        msg.Formatter = New Messaging.XmlMessageFormatter(typeArray)

        Return msg.Body
    End Function

    ''' <summary>
    ''' メッセージキューから要求を取得する（タイプ名指定）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReceiveAny(ByVal ReceiveQueueName As String, ByVal typeNameArray() As String, Optional ByVal AllowAutoCreateQueue As Boolean = True) As Object
        'メッセージを受信
        Dim msg As System.Messaging.Message = Receive(ReceiveQueueName, AllowAutoCreateQueue)

        '型変換
        msg.Formatter = New Messaging.XmlMessageFormatter(typeNameArray)

        Return msg.Body
    End Function

    ''' <summary>
    ''' メッセージキューから要求を取得する（タイプ指定）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Receive(ByVal ReceiveQueueName As String, ByVal type As Type) As Object
        Dim typeArray As Type() = {type}
        Return ReceiveAny(ReceiveQueueName, typeArray)
    End Function

    ''' <summary>
    ''' メッセージキューから要求を取得する（タイプ名指定）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Receive(ByVal ReceiveQueueName As String, ByVal typeName As String) As Object
        Dim typeNameArray As String() = {typeName}
        Return ReceiveAny(ReceiveQueueName, typeNameArray)
    End Function

    ''' <summary>
    ''' メッセージキューから要求を取得する（タイムアウトあり）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReceiveAny(ByVal ReceiveQueueName As String, ByVal typeArray As Type(), ByVal TimeOut As TimeSpan) As Object
        'メッセージの受信
        Dim msg As System.Messaging.Message = GetQueue(ReceiveQueueName).Receive(TimeOut)
        '型変換
        msg.Formatter = New Messaging.XmlMessageFormatter(typeArray)

        Return msg.Body
    End Function

    ''' <summary>
    ''' メッセージキューから要求を取得する（タイムアウトあり）
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Receive(ByVal ReceiveQueueName As String, ByVal type As Type, ByVal TimeOut As TimeSpan) As Object
        Dim typeArray As Type() = {type}
        Return ReceiveAny(ReceiveQueueName, typeArray, TimeOut)
    End Function

    ''' <summary>
    ''' すべてのメッセージキューを取得する
    ''' </summary>
    ''' <param name="ReceiveQueueName"></param>
    ''' <remarks></remarks>
    Public Shared Sub ClearMessage(ByVal ReceiveQueueName As String, Optional ByVal AllowAutoCreateQueue As Boolean = True)
        'キュー自動生成
        If AllowAutoCreateQueue Then
            If Not System.Messaging.MessageQueue.Exists(ReceiveQueueName) Then
                CreateMessageQueue(ReceiveQueueName)
            End If
        End If
        'すべてのメッセージの削除
        GetQueue(ReceiveQueueName).Purge()
    End Sub
End Class

Public Interface IRFIDリーダライタ
    Sub 初期設定()

    ''' <summary>
    ''' タグIDを読み出す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetTagIDs() As List(Of TagID)
    Function GetTagIDs_NoMoreThan(ByVal NumberOfTags As Integer, Optional ByRef NumberOfTagsFound As Integer = Nothing, Optional ByRef NumberOfTagsReturned As Integer = Nothing) As List(Of TagID)
    Sub WriteUserTagID(ByVal TargetTagID As TagID, ByVal Binary As Byte())
End Interface
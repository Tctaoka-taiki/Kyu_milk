Imports System.Text
Imports System.runtime.InteropServices

Public Class 三菱UHFTag
    Inherits Tag
    Private Const SYSTEM_AREA_SIZE As Integer = 12
    Private Const USER_AREA_SIZE As Integer = 0
    Private Const DATA_AREA_SIZE As Integer = 112
    Public Sub New()
        MyBase.New(SYSTEM_AREA_SIZE, USER_AREA_SIZE, DATA_AREA_SIZE)
    End Sub
    ''' <summary>
    ''' インスタンス生成時にタグIDを指定します
    ''' </summary>
    ''' <param name="TagID"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal TagID As Byte())
        Me.New()
        Array.Copy(TagID, MyBase.ID.Binary, SYSTEM_AREA_SIZE + USER_AREA_SIZE)
    End Sub
    ''' <summary>
    ''' インスタンス生成時にタグIDを指定します
    ''' </summary>
    ''' <param name="TagID"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal TagID As String)
        Me.New()
        MyBase.ID.HexString = TagID
    End Sub
End Class


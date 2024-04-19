''' <summary>
''' タグ内データクラス
''' </summary>
''' <remarks></remarks>
Public Class TagData

    Sub New(ByVal Size As Integer)
        Me._Size = Size
        ReDim Me._Binary(Size - 1)
    End Sub

    Private _Size As Integer
    Public Property Size() As Integer
        Get
            Return _Size
        End Get
        Set(ByVal value As Integer)
            _Size = value
        End Set
    End Property

    Private _Binary As Byte()
    Public Property Binary() As Byte()
        Get
            Return _Binary
        End Get
        Set(ByVal value As Byte())
            For i As Integer = 0 To Me._Size - 1
                If i < value.Length Then
                    Me._Binary(i) = value(i)
                Else
                    Me._Binary(i) = 0
                End If
            Next
        End Set
    End Property

    Public Property HexString() As String
        Get
            Dim id As String = ""

            For i As Integer = 0 To Me._Size - 1
                id = id + Right("0" + Me._Binary(i).ToString("X"), 2)
            Next
            Return id.ToUpper
        End Get
        Set(ByVal value As String)
            '後方を強制的にゼロ埋めする
            value = (value + New String("0"c, Me._Size * 2)).Substring(0, Me._Size * 2)
            'If value.Length < (Me._Size * 2) Then
            '    Throw New TagDataEXception("このクラスのHexプロパティには、" + Me._Size.ToString + "文字の１６進文字列を設定してください")
            'End If
            For i As Integer = 0 To Me._Size - 1
                Try
                    Me._Binary(i) = Convert.ToByte(value.Substring(i * 2, 2), 16)
                Catch ex As Exception
                    Throw New TagDataEXception("１６進文字列からバイナリデータへの変換に失敗しました", ex)
                    Return
                End Try
            Next
        End Set
    End Property

    Public Class TagDataEXception
        Inherits Exception
        Sub New(ByVal Message As String)
            MyBase.New(Message)
        End Sub
        Sub New(ByVal Message As String, ByVal iex As Exception)
            MyBase.New(Message, iex)
        End Sub
    End Class

End Class

''' <summary>
''' タグIDクラス
''' </summary>
''' <remarks></remarks>
Public Class TagID

    'コンストラクタ
    Public Sub New(ByVal SystemSize As Integer, ByVal UserSize As Integer)
        Me._SystemArea = New TagData(SystemSize)
        Me._UserArea = New TagData(UserSize)
    End Sub

    Private _SystemArea As TagData
    ''' <summary>
    ''' システム領域ＩＤ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SystemArea() As TagData
        Get
            Return _SystemArea
        End Get
        Set(ByVal value As TagData)
            _SystemArea = value
        End Set
    End Property

    Private _UserArea As TagData
    ''' <summary>
    ''' ユーザ領域ＩＤ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserArea() As TagData
        Get
            Return _UserArea
        End Get
        Set(ByVal value As TagData)
            _UserArea = value
        End Set
    End Property


    ''' <summary>
    ''' タグＩＤの１６進文字列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property HexString() As String
        Get
            Return Me._SystemArea.HexString + Me._UserArea.HexString
        End Get
        Set(ByVal value As String)
            '後方をゼロ埋めする
            value = (value + New String("0"c, (Me._SystemArea.Size + Me._UserArea.Size) * 2).Substring(0, (Me._SystemArea.Size + Me._UserArea.Size) * 2))
            Me._SystemArea.HexString = value.Substring(0, Me._SystemArea.Size * 2)
            Me._UserArea.HexString = value.Substring(Me._SystemArea.Size * 2, Me._UserArea.Size * 2)
        End Set
    End Property

    ''' <summary>
    ''' タグＩＤのバイナリデータ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Binary() As Byte()
        Get
            Dim b(Me._SystemArea.Size + Me._UserArea.Size - 1) As Byte
            Array.Copy(Me._SystemArea.Binary, b, Me._SystemArea.Size)
            Array.Copy(Me._UserArea.Binary, 0, b, Me._SystemArea.Size, Me._UserArea.Size)
            Return b
        End Get
        Set(ByVal value As Byte())
            Array.Copy(value, Me._SystemArea.Binary, Me._SystemArea.Size)
            Array.Copy(value, Me._SystemArea.Size, Me._UserArea.Binary, 0, Me._UserArea.Size)
        End Set
    End Property
End Class

''' <summary>
''' タグクラス
''' </summary>
''' <remarks>ＩＤ部とデータ部が存在し、ＩＤ部もシステム領域とデータ領域に分割される</remarks>
Public Class Tag

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="SystemAreaSize">システムタグＩＤ領域サイズ</param>
    ''' <param name="UserAreaSize">ユーザタグＩＤ領域サイズ</param>
    ''' <param name="DataAreaSize">ユーザデータ領域サイズ</param>
    ''' <remarks></remarks>
    Sub New(ByVal SystemAreaSize As Integer, ByVal UserAreaSize As Integer, ByVal DataAreaSize As Integer)
        Me._ID = New TagID(SystemAreaSize, UserAreaSize)
        Me._Data = New TagData(DataAreaSize)
    End Sub

    Private _ID As TagID
    ''' <summary>
    ''' タグID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ID() As TagID
        Get
            Return _ID
        End Get
        Set(ByVal value As TagID)
            _ID = value
        End Set
    End Property

    Private _Data As TagData
    ''' <summary>
    ''' タグデータ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Data() As TagData
        Get
            Return _Data
        End Get
        Set(ByVal value As TagData)
            _Data = value
        End Set
    End Property

End Class


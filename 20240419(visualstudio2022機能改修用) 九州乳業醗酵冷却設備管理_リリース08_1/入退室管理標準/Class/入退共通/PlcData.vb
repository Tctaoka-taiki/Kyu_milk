Public Class CPlcDataリスト
    Inherits List(Of PlcData)

    Public Function FindBy拠点名(ByVal 拠点名 As String) As PlcData
        For Each p As PlcData In Me
            If p.Plcオブジェクト.拠点名 = 拠点名 Then
                Return p
            End If
        Next
        Return Nothing
    End Function
    Public Function FindByWrap(ByVal o As Object) As PlcData
        For Each p As PlcData In Me
            If p.Wrap Is CType(o, CMX.Wrapper) Then
                Return p
            End If
        Next
        Return Nothing
    End Function
    Public Function FindByDataHandsharePassive(ByVal o As Object) As PlcData
        For Each p As PlcData In Me
            If p.DataHandshake Is CType(o, CMX.HandShake.Passive) Then
                Return p
            End If
        Next
        Return Nothing
    End Function
End Class

Public Class PlcData
    'Private _Wrap As CMX.Wrapper                          'ＭＸコンポーネントラッパ
    'Private _OrgAlarmList As List(Of CMX.Device)            'アラーム受信設定
    'Private _AlarmList As List(Of CMX.Device)               'アラーム受信領域
    'Private _SensorList As List(Of CMX.Device)              '監視センサ状態受信領域
    'Private _OldAlarmList As List(Of CMX.Device)            '一つ前のアラーム受信状態
    'Private _転送dt As New TCNYUTAI_DBDataSet.DC転送済セキュリティ情報DataTable '転送済セキュリティ情報取得用

    '読出しハンドシェイク用
    'Private _DataHandshake As CMX.HandShake.Passive         '読出しハンドシェイク用
    'Private _DataList As List(Of CMX.Device)                '認証ログ受信領域
    ''Private _DataDic As Dictionary(Of String, CMX.Device)   '認証ログディクショナリ

    Private _Wrap As CMX.Wrapper
    Public Property Wrap() As CMX.Wrapper
        Get
            Return _Wrap
        End Get
        Set(ByVal value As CMX.Wrapper)
            _Wrap = value
        End Set
    End Property

    Private _OrgAlarmList As List(Of CMX.Device)
    Public Property OrgAlarmList() As List(Of CMX.Device)
        Get
            Return _OrgAlarmList
        End Get
        Set(ByVal value As List(Of CMX.Device))
            _OrgAlarmList = value
        End Set
    End Property


    Private _AlarmList As List(Of CMX.Device)
    Public Property AlarmList() As List(Of CMX.Device)
        Get
            Return _AlarmList
        End Get
        Set(ByVal value As List(Of CMX.Device))
            _AlarmList = value
        End Set
    End Property


    Private _SensorList As List(Of CMX.Device)
    Public Property SensorList() As List(Of CMX.Device)
        Get
            Return _SensorList
        End Get
        Set(ByVal value As List(Of CMX.Device))
            _SensorList = value
        End Set
    End Property

    Private _OldAlarmList As List(Of CMX.Device)
    Public Property OldAlarmList() As List(Of CMX.Device)
        Get
            Return _OldAlarmList
        End Get
        Set(ByVal value As List(Of CMX.Device))
            _OldAlarmList = value
        End Set
    End Property

    Private _DataHandshake As CMX.HandShake.Passive
    Public Property DataHandshake() As CMX.HandShake.Passive
        Get
            Return _DataHandshake
        End Get
        Set(ByVal value As CMX.HandShake.Passive)
            _DataHandshake = value
        End Set
    End Property

    Private _SecurityHandshake As CMX.HandShake.ActiveWrite
    Public Property SecurityHandshake() As CMX.HandShake.ActiveWrite
        Get
            Return _SecurityHandshake
        End Get
        Set(ByVal value As CMX.HandShake.ActiveWrite)
            _SecurityHandshake = value
        End Set
    End Property

    Private _DataList As List(Of CMX.Device)
    Public Property DataList() As List(Of CMX.Device)
        Get
            Return _DataList
        End Get
        Set(ByVal value As List(Of CMX.Device))
            _DataList = value
        End Set
    End Property

    Public Plcオブジェクト As Settings.Plc
    Public Sub New(ByVal o As Settings.Plc)
        Plcオブジェクト = o
        Wrap = New CMX.Wrapper
        Wrap.ActEasyIF.ActLogicalStationNumber = o.論理局番
    End Sub

End Class


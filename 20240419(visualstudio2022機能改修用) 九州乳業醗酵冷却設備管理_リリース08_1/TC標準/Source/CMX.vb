Imports ACTMULTILib

Public Class CMX

    ''' <summary>
    ''' ＣＰＵ定義
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ECPUTypeCode As Integer
        Q2A = &H11S ' Q2A
        Q2AS1 = &H12S ' Q2AS1
        Q3A = &H13S ' Q3A
        Q4A = &H14S ' Q4A
        Q02 = &H22S ' Q02(H) Q
        Q06 = &H23S ' Q06H   Q
        Q12 = &H24S ' Q12H   Q
        Q25 = &H25S ' Q25H   Q
        Q00J = &H30S ' Q00J   Q
        Q00 = &H31S ' Q00    Q
        Q01 = &H32S ' Q01    Q
        Q12PH = &H41S ' Q12PH Q
        Q25PH = &H42S ' Q25PH Q
        Q12PRH = &H43S ' Q12PRH Q
        Q25PRH = &H44S ' Q25PRH Q
        Q25SS = &H55S ' Q25SS
        Q03UD = &H70S ' Q03UD  Q
        Q04UDH = &H71S ' Q04UDH Q
        Q06UDH = &H72S ' Q06UDH Q
        Q02U = &H83S ' Q02U   Q
        A0J2H = &H102S ' A0J2H
        A1FX = &H103S ' A1FX
        A1S = &H104S ' A1S,A1SJ
        A1SH = &H105S ' A1SH,A1SJH
        A1N = &H106S ' A1(N)
        A2C = &H107S ' A2C,A2CJ
        A2N = &H108S ' A2(N),A2S
        A2SH = &H109S ' A2SH
        A3N = &H10AS ' A3(N)
        A2A = &H10CS ' A2A
        A3A = &H10DS ' A3A
        A2U = &H10ES ' A2U,A2US
        A2USHS1 = &H10FS ' A2USHS1
        A3U = &H110S ' A3U
        A4U = &H111S ' A4U
        Q02_A = &H141S ' Q02(H)
        Q06_A = &H142S ' Q06H
        FX0 = &H201S ' FX0/FX0S
        FX0N = &H202S ' FX0N
        FX1 = &H203S ' FX1
        FX2 = &H204S ' FX2/FX2C
        FX2N = &H205S ' FX2N/FX2NC
        FX1S = &H206S ' FX1S
        FX1N = &H207S ' FX1N
        FX3UU = &H208S ' FX3U/FX3UC
    End Enum

#Region "EventArgs"

    ''' <summary>
    ''' 例外
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CMXException
        Inherits System.Exception
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
    End Class

    ''' <summary>
    ''' イベントパラメータ
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DeviceEventArgs
        Inherits EventArgs

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="Device"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Device As Device)
            _Device = Device
        End Sub

        ''' <summary>
        ''' イベントの発生したデバイス
        ''' </summary>
        ''' <remarks></remarks>
        Private _Device As Device
        Public Property Device() As Device
            Get
                Return _Device
            End Get
            Set(ByVal value As Device)
                _Device = value
            End Set
        End Property

    End Class

#End Region

    ''' <summary>
    ''' デバイス属性
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DeviceAttribute

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="deviceName">デバイス名</param>
        ''' <param name="tag">タグ名</param>
        ''' <param name="isWordDevice">ワードデバイスであることを示す</param>
        ''' <param name="isHexAddress">１６進デバイスであることを示す</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal deviceName As String, ByVal tag As String, Optional ByVal isWordDevice As Boolean = False, Optional ByVal isHexAddress As Boolean = False)
            Me._DeviceName = deviceName
            Me._Tag = tag
            Me._IsWordDevice = isWordDevice
            Me._IsHexAddress = isHexAddress
        End Sub

        ''' <summary>
        ''' デバイス名
        ''' </summary>
        ''' <remarks></remarks>
        Private _DeviceName As String
        Public Property DeviceName() As String
            Get
                Return _DeviceName
            End Get
            Set(ByVal value As String)
                _DeviceName = value
            End Set
        End Property

        ''' <summary>
        ''' ワードデバイスであることを示す
        ''' </summary>
        ''' <remarks></remarks>
        Private _IsWordDevice As Boolean
        Public Property IsWordDevice() As Boolean
            Get
                Return _IsWordDevice
            End Get
            Set(ByVal value As Boolean)
                _IsWordDevice = value
            End Set
        End Property

        ''' <summary>
        ''' アドレスが１６進数で表示されることを示す
        ''' </summary>
        ''' <remarks></remarks>
        Private _IsHexAddress As Boolean
        Public Property IsHexAddress() As Boolean
            Get
                Return _IsHexAddress
            End Get
            Set(ByVal value As Boolean)
                _IsHexAddress = value
            End Set
        End Property


        ''' <summary>
        ''' タグ名
        ''' </summary>
        ''' <remarks></remarks>
        Private _Tag As String
        Public Property tag() As String
            Get
                Return _Tag
            End Get
            Set(ByVal value As String)
                _Tag = value
            End Set
        End Property

    End Class

    ''' <summary>
    ''' デバイス属性配列
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared DeviceAttributeArray As DeviceAttribute() = { _
            New DeviceAttribute("FX", "ファンクション入力"), _
            New DeviceAttribute("FY", "ファンクション出力"), _
            New DeviceAttribute("FD", "ファンクションレジスタ", True), _
            New DeviceAttribute("SM", "特殊リレー"), _
            New DeviceAttribute("SD", "特殊レジスタ", True), _
            New DeviceAttribute("X", "入力リレー", False, True), _
            New DeviceAttribute("Y", "出力リレー", False, True), _
            New DeviceAttribute("M", "内部リレー"), _
            New DeviceAttribute("L", "ラッチリレー"), _
            New DeviceAttribute("F", "アナンシェータ"), _
            New DeviceAttribute("V", "エッジリレー"), _
            New DeviceAttribute("B", "リンクリレー", False, True), _
            New DeviceAttribute("D", "データレジスタ", True), _
            New DeviceAttribute("W", "リンクレジスタ", True, True), _
            New DeviceAttribute("TS", "タイマ接点"), _
            New DeviceAttribute("TC", "タイマコイル"), _
            New DeviceAttribute("TN", "タイマ現在値", True), _
            New DeviceAttribute("CS", "カウンタ接点"), _
            New DeviceAttribute("CC", "カウンタコイル"), _
            New DeviceAttribute("CN", "カウンタ現在値", True), _
            New DeviceAttribute("SS", "積算タイマ接点"), _
            New DeviceAttribute("SC", "積算タイマコイル"), _
            New DeviceAttribute("SN", "積算タイマカウンタ", True), _
            New DeviceAttribute("SB", "リンク特殊リレー", False, True), _
            New DeviceAttribute("SW", "リンク特殊レジスタ", True, True), _
            New DeviceAttribute("S", "ステップリレー", False, True), _
            New DeviceAttribute("A", "アキュムレータ", True), _
            New DeviceAttribute("Z", "インデックスレジスタ", True), _
            New DeviceAttribute("R", "ファイルレジスタ（バンク０）", True), _
            New DeviceAttribute("ZR", "ファイルレジスタ", True) _
        }

    ''' <summary>
    ''' ＣＰＵ形式クラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CPUType
        Sub New(ByVal CPUName As String, ByVal CPUType As ECPUTypeCode)
            _CPUName = CPUName
            _CPUType = CPUType
        End Sub
        ''' <summary>
        ''' ＣＰＵの名称
        ''' </summary>
        ''' <remarks></remarks>
        Private _CPUName As String
        Public Property CPUName() As String
            Get
                Return _CPUName
            End Get
            Set(ByVal value As String)
                _CPUName = value
            End Set
        End Property

        ''' <summary>
        ''' ＣＰＵの型式
        ''' </summary>
        ''' <remarks></remarks>
        Private _CPUType As ECPUTypeCode
        Public Property CPUType() As ECPUTypeCode
            Get
                Return _CPUType
            End Get
            Set(ByVal value As ECPUTypeCode)
                _CPUType = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' デバイスインタフェース
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IDevice
        Property DeviceName() As String
        Property DeviceNo() As Integer
        ReadOnly Property Attribute() As DeviceAttribute
        Function ToString() As String
        Property Tag() As String
    End Interface
    Public Interface IDeviceData(Of T)
        Inherits IDevice
        Property Value() As T
    End Interface

    ''' <summary>
    ''' デバイスアドレスクラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Device
        Implements IDevice
        Implements ICloneable
        Implements IComparable(Of Device)

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' デバイス名とデバイス番号でオブジェクトを生成する
        ''' </summary>
        ''' <param name="DeviceName">デバイス名</param>
        ''' <param name="DeviceNo">デバイス番号</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal deviceName As String, ByVal deviceNo As Integer, Optional ByVal tag As String = "")
            Me.DeviceName = deviceName
            Me.DeviceNo = deviceNo
            Me.Tag = tag
        End Sub

        ''' <summary>
        ''' デバイスを示す文字列でオブジェクトを生成する
        ''' </summary>
        ''' <param name="deviceString"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal deviceString As String, Optional ByVal tag As String = "")
            Dim errorString As String = "デバイス文字列 " + deviceString + " が不正です" + vbCrLf + "16進文字列でデバイス番号を指定している場合は、デバイス番号の前に0を入れてください"
            Dim cArray As Char() = deviceString.ToCharArray()
            Dim pnt As Integer

            For pnt = 0 To cArray.Length - 1
                If IsNumeric(cArray(pnt)) Then
                    Exit For
                End If
            Next

            '数値文字列がなければエラー
            If pnt = cArray.Length Then
                Throw New CMXException(errorString)
                Exit Sub
            End If

            'デバイス名設定
            Me.DeviceName = deviceString.Substring(0, pnt)

            'デバイス番号設定
            Try
                If Me.Attribute.IsHexAddress Then
                    Me.DeviceNo = Convert.ToInt32(deviceString.Substring(pnt), 16)
                Else
                    Me.DeviceNo = Convert.ToInt32(deviceString.Substring(pnt), 10)
                End If
            Catch ex As Exception
                Throw New CMXException(errorString)
            End Try

            'タグ設定
            Me.Tag = tag
        End Sub
        ''' <summary>
        ''' デバイス名
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DeviceName() As String Implements IDevice.DeviceName
            Get
                Return Me._Attribute.DeviceName
            End Get
            Set(ByVal value As String)
                For Each atr As DeviceAttribute In DeviceAttributeArray
                    If atr.DeviceName = value.ToUpper Then
                        Me._Attribute = atr
                        Exit Property
                    End If
                Next
                Throw New CMXException("デバイス名" + value + "はサポートされていません")
            End Set
        End Property

        ''' <summary>
        ''' デバイス番号
        ''' </summary>
        ''' <remarks></remarks>
        Private _DeviceNo As Integer
        Public Property DeviceNo() As Integer Implements IDevice.DeviceNo
            Get
                Return _DeviceNo
            End Get
            Set(ByVal value As Integer)
                _DeviceNo = value
            End Set
        End Property

        ''' <summary>
        ''' デバイス属性
        ''' </summary>
        ''' <remarks></remarks>
        Private _Attribute As DeviceAttribute
        Public ReadOnly Property Attribute() As DeviceAttribute Implements IDevice.Attribute
            Get
                Return _Attribute
            End Get
        End Property


        ''' <summary>
        ''' デバイスをあらわす文字列
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function ToString() As String Implements IDevice.ToString
            If Me._Attribute.IsHexAddress Then
                '１６進アドレスデバイス
                Return Me._Attribute.DeviceName + "0" + Me._DeviceNo.ToString("X")
            Else
                '１０進アドレスデバイス
                Return Me._Attribute.DeviceName + "0" + Me._DeviceNo.ToString()
            End If
        End Function

        ''' <summary>
        ''' タグ
        ''' </summary>
        ''' <remarks></remarks>
        Private _Tag As String
        Public Property Tag() As String Implements IDevice.Tag
            Get
                Return _Tag
            End Get
            Set(ByVal value As String)
                _Tag = value
            End Set
        End Property

        ''' <summary>
        ''' デバイスの値（２バイト)
        ''' </summary>
        ''' <remarks></remarks>
        Private _ByteValue(1) As Byte
        Public Property ByteValue() As Byte()
            Get
                Return _ByteValue
            End Get
            Set(ByVal value As Byte())
                Array.Copy(value, _ByteValue, _ByteValue.Length)
            End Set
        End Property

        ''' <summary>
        ''' 符号つき１６ビット整数の値
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShortValue() As Short
            Get
                Return BitConverter.ToInt16(_ByteValue, 0)
            End Get
            Set(ByVal value As Short)
                _ByteValue = BitConverter.GetBytes(value)
            End Set
        End Property

        ''' <summary>
        ''' 符号なし１６ビット整数の値
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UShortValue() As UShort
            Get
                Return BitConverter.ToUInt16(_ByteValue, 0)
            End Get
            Set(ByVal value As UShort)
                _ByteValue = BitConverter.GetBytes(value)
            End Set
        End Property

        ''' <summary>
        ''' ビットデバイスのBool値
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BoolValue() As Boolean
            Get
                Return CType(IIf(BitConverter.ToInt16(_ByteValue, 0) = 0, False, True), Boolean)
            End Get
            Set(ByVal value As Boolean)
                Dim tmp As Int16
                If value Then
                    tmp = 1
                Else
                    tmp = 0
                End If
                _ByteValue = BitConverter.GetBytes(tmp)
            End Set
        End Property

        ''' <summary>
        ''' デバイスの比較
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CompareTo(ByVal other As Device) As Integer Implements System.IComparable(Of Device).CompareTo
            If other.DeviceName = Me.DeviceName Then
                If other.DeviceNo = Me.DeviceNo Then
                    Return 0
                ElseIf other.DeviceNo < Me.DeviceNo Then
                    Return 1
                Else
                    Return -1
                End If
            ElseIf other.DeviceName < Me.DeviceName Then
                Return 1
            Else
                Return -1
            End If
        End Function

        ''' <summary>
        ''' デバイスのクローン作成
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Clone() As Object Implements ICloneable.Clone
            Dim c As New Device
            c.DeviceName = Me.DeviceName
            c.DeviceNo = Me.DeviceNo
            c.ByteValue = CType(Me.ByteValue.Clone, Byte())
            c.Tag = Me.Tag
            Return c
        End Function
    End Class

    ''' <summary>
    ''' 活用データ型指定付デバイス
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <remarks></remarks>
    Friend Class DeviceData(Of T)
        Inherits Device
        Implements IDeviceData(Of T)

        Sub New(ByVal device As Device)
            If GetType(T) Is GetType(Boolean) Then
            ElseIf GetType(T) Is GetType(UInt16) Then
            ElseIf GetType(T) Is GetType(Int16) Then
            ElseIf GetType(T) Is GetType(BitArray) Then
            Else
                Throw New CMXException(GetType(T).ToString + "型のデバイスは作成できません" + vbCrLf _
                                + "サポートされている型は" + vbCrLf _
                                + vbTab + GetType(Boolean).ToString + vbCrLf _
                                + vbTab + GetType(Int16).ToString + vbCrLf _
                                + vbTab + GetType(UInt16).ToString + vbCrLf _
                                + vbTab + GetType(BitArray).ToString + vbCrLf _
                                + "のみです")
            End If
        End Sub

        ''' <summary>
        ''' デバイスの値
        ''' </summary>
        ''' <remarks></remarks>
        Private _Value As T
        Public Property Value() As T Implements IDeviceData(Of T).Value
            Get
                Return _Value
            End Get
            Set(ByVal value As T)
                _Value = value
            End Set
        End Property

    End Class

    ''' <summary>
    ''' ＭＸコンポーネントラッパークラス
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Wrapper

        ''' <summary>
        ''' ＣＰＵリモート操作
        ''' </summary>
        ''' <remarks></remarks>
        Private Enum ECPUStatus As Integer
            REMOTE_RUN = 0
            REMOTE_STOP = 1
            REMOTE_PAUSE = 2
        End Enum

        ''' <summary>
        ''' イベント
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event OnDeviceEvent(ByVal sender As Object, ByVal e As DeviceEventArgs)

        ''' <summary>
        ''' デバイス書き込み通知イベント
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event DeviceWrited(ByVal sender As Object, ByVal e As DeviceEventArgs)

        ''' <summary>
        ''' デバイス読み出し通知イベント
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event DeviceReaded(ByVal sender As Object, ByVal e As DeviceEventArgs)

        ''' <summary>
        ''' イベント監視デバイス
        ''' </summary>
        ''' <remarks></remarks>
        Private _EventDeviceList As New List(Of Device)

        ''' <summary>
        ''' スレッド排他用オブジェクト
        ''' </summary>
        ''' <remarks></remarks>
        Private _Lock As New Object

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            '_ActEasyIF = New ActEasyIF
            'AddHandler _ActEasyIF.OnDeviceStatus, AddressOf OnDeviceStatus
        End Sub

        ''' <summary>
        ''' インタフェース直接操作
        ''' </summary>
        ''' <remarks></remarks>
        Private WithEvents _ActEasyIF As New ActEasyIF
        Public Property ActEasyIF() As ActEasyIF
            Get
                Return _ActEasyIF
            End Get
            Set(ByVal value As ActEasyIF)
                _ActEasyIF = value
            End Set
        End Property

        ''' <summary>
        ''' オープンステータス
        ''' </summary>
        ''' <remarks></remarks>
        Private _IsOpen As Boolean
        Public Property IsOpen() As Boolean
            Get
                Return _IsOpen
            End Get
            Set(ByVal value As Boolean)
                _IsOpen = value
            End Set
        End Property

        ''' <summary>
        ''' イベント監視周期
        ''' </summary>
        ''' <remarks></remarks>
        Private _EventCycle As Integer = 1
        Public Property EventCycle() As Integer
            Get
                Return _EventCycle
            End Get
            Set(ByVal value As Integer)
                _EventCycle = value
            End Set
        End Property

        ''' <summary>
        ''' イベント監視デバイスを追加する
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Public Sub AddEventDevice(ByVal dev As Device)
            Me._EventDeviceList.Add(dev)
            ResetEventDevice()
        End Sub

        ''' <summary>
        ''' イベント監視デバイスを削除する
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Public Sub RemoveEventDevice(ByVal dev As Device)
            If _EventDeviceList.Remove(dev) Then
                ResetEventDevice()
            End If
        End Sub

        ''' <summary>
        ''' イベント監視デバイスリストを追加する
        ''' </summary>
        ''' <param name="devArray"></param>
        ''' <remarks></remarks>
        Public Sub AddEventDeviceList(ByVal devArray As List(Of Device))
            Me._EventDeviceList.AddRange(devArray)
            ResetEventDevice()
        End Sub

        ''' <summary>
        ''' イベント監視デバイスリストを削除する
        ''' </summary>
        ''' <param name="devArray"></param>
        ''' <remarks></remarks>
        Public Sub RemoveEventDeviceList(ByVal devArray As List(Of Device))
            For Each dev As Device In devArray
                Me._EventDeviceList.Remove(dev)
            Next
            ResetEventDevice()
        End Sub

        ''' <summary>
        ''' イベント監視デバイスを削除する
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearEventDevice()
            Me._EventDeviceList.Clear()
            ResetEventDevice()
        End Sub

        ''' <summary>
        ''' イベント監視を再設定する
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ResetEventDevice()
            DisableEvent()
            EnableEvent()
        End Sub

        ''' <summary>
        ''' 通信回線のオープン
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Open()
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.Open
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""Open""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
        End Sub

        ''' <summary>
        ''' 通信回線のクローズ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Close()
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.Close
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""Close""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
        End Sub

        ''' <summary>
        ''' 電話回線の接続
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Connect()
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.Connect
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""Connect""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
        End Sub

        ''' <summary>
        ''' 電話回線の切断
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Disconnect()
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.Close
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""Disconnect""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
        End Sub

        ''' <summary>
        ''' デバイスリストの一括読み出し
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Public Sub ReadList(ByRef dev As List(Of Device))
            Dim current As Integer = 0
            Dim cnt As Integer

            While current < dev.Count
                '範囲が連続しているかをチェック
                cnt = GetSerialCount(dev, current)
                If cnt = 1 Then
                    '１デバイス読み出し
                    Me.Read(dev(current))
                Else
                    '複数デバイス読み出し
                    Me.ReadList(dev, current, cnt)
                End If
                current += cnt
            End While
        End Sub

        ''' <summary>
        ''' 配列デバイスの連続数を取得する
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <param name="startIndex"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetSerialCount(ByRef dev As List(Of Device), ByVal startIndex As Integer) As Integer
            Dim name As String = dev(startIndex).DeviceName
            Dim address As Integer = dev(startIndex).DeviceNo
            Dim cnt As Integer = 1
            For i As Integer = startIndex + 1 To dev.Count - 1
                If dev(i).DeviceName <> name Then
                    Exit For
                End If
                If dev(i).DeviceNo <> (address + cnt) Then
                    Exit For
                End If
                cnt += 1
            Next
            Return cnt
        End Function

        ''' <summary>
        ''' ビットデバイスの読み出し
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Public Function Read(ByVal dev As Device) As Device
            '開始位置のデバイスで判断する
            If dev.Attribute.IsWordDevice Then
                Me.ReadWord(dev)
            Else
                Me.ReadBit(dev)
            End If
            Return dev
        End Function

        ''' <summary>
        ''' ビットデバイスの読み出し
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Private Function ReadBit(ByVal dev As Device) As Device
            Dim data As Integer
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.GetDevice(dev.ToString, data)
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""GetDevice""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            Dim tmp As New Device(dev.DeviceName, dev.DeviceNo)
            tmp.BoolValue = CBool(data And 1)
            dev.ByteValue = tmp.ByteValue
            RaiseEvent DeviceReaded(Me, New DeviceEventArgs(dev))
            Return dev
        End Function

        ''' <summary>
        ''' ワードデバイスの読み出し
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Private Function ReadWord(ByVal dev As Device) As Device
            Dim data As Integer
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.GetDevice(dev.ToString, data)
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""GetDevice""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            Array.Copy(BitConverter.GetBytes(data), dev.ByteValue, dev.ByteValue.Length)
            RaiseEvent DeviceReaded(Me, New DeviceEventArgs(dev))
            Return dev
        End Function

        ''' <summary>
        ''' ビットデバイスの一括読み出し
        ''' </summary>
        ''' <param name="devArray"></param>
        ''' <param name="startIndex"></param>
        ''' <param name="length"></param>
        ''' <remarks></remarks>
        Private Sub ReadList(ByRef devArray As List(Of Device), ByVal startIndex As Integer, ByVal length As Integer)
            '開始位置のデバイスで判断する
            If devArray(startIndex).Attribute.IsWordDevice Then
                Me.ReadWords(devArray, startIndex, length)
            Else
                Me.ReadBits(devArray, startIndex, length)
            End If
        End Sub

        ''' <summary>
        ''' ビットデバイスの一括読み出し
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <param name="startIndex"></param>
        ''' <param name="length"></param>
        ''' <remarks></remarks>
        Private Sub ReadBits(ByRef dev As List(Of Device), ByVal startIndex As Integer, ByVal length As Integer)
            Dim datas(((length + 15) \ 16) - 1) As Integer
            Dim ret As Integer
            Dim devNo As Integer = (dev(startIndex).DeviceNo \ 16) * 16  '16で割った端数を切り捨て
            Dim devAdr As String = New Device(dev(startIndex).DeviceName, devNo).ToString 'デバイスの先頭アドレス

            SyncLock Me._Lock
                ret = _ActEasyIF.ReadDeviceBlock(devAdr, datas.Length, datas(0))
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""ReadDeviceBlock""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            Dim offset As Integer = dev(startIndex).DeviceNo Mod 16
            For i As Integer = 0 To length - 1
                dev(startIndex + i).BoolValue = CBool(datas(((i + offset) \ 16)) And CInt(2 ^ (i + offset)))
                RaiseEvent DeviceReaded(Me, New DeviceEventArgs(dev(startIndex + i)))
            Next
        End Sub

        ''' <summary>
        ''' ワードデバイスの一括読み出し
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <param name="startIndex"></param>
        ''' <param name="length"></param>
        ''' <remarks></remarks>
        Private Sub ReadWords(ByRef dev As List(Of Device), ByVal startIndex As Integer, ByVal length As Integer)
            Dim datas(length - 1) As Integer
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.ReadDeviceBlock(dev(startIndex).ToString, length, datas(0))
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""ReadDeviceBlock""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            For i As Integer = 0 To length - 1
                With dev(startIndex + i)
                    Array.Copy(BitConverter.GetBytes(datas(i)), .ByteValue, .ByteValue.Length)
                End With
                RaiseEvent DeviceReaded(Me, New DeviceEventArgs(dev(startIndex + i)))
            Next
        End Sub

        ''' <summary>
        ''' デバイスリストの一括書き込み
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Public Sub WriteList(ByRef dev As List(Of Device))
            Dim current As Integer = 0
            Dim cnt As Integer

            While current < dev.Count
                '範囲が連続しているかをチェック
                cnt = GetSerialCount(dev, current)
                If cnt = 1 Then
                    '１デバイス書き込み
                    Me.Write(dev(current))
                Else
                    '複数デバイス書き込み
                    Me.WriteList(dev, current, cnt)
                End If
                current += cnt
            End While
        End Sub

        ''' <summary>
        ''' デバイスの書き込み
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Public Sub Write(ByVal dev As Device)
            '開始位置のデバイスで判断する
            If dev.Attribute.IsWordDevice Then
                Me.WriteWord(dev)
            Else
                Me.WriteBit(dev)
            End If
        End Sub

        ''' <summary>
        ''' ビットデバイスの書き込み
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Private Sub WriteBit(ByVal dev As Device)
            Dim data As Integer = BitConverter.ToInt16(dev.ByteValue, 0)
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.SetDevice(dev.ToString, data)
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""SetDevice""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            RaiseEvent DeviceWrited(Me, New DeviceEventArgs(dev))
        End Sub

        ''' <summary>
        ''' ワードデバイスの書き込み
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <remarks></remarks>
        Private Sub WriteWord(ByVal dev As Device)
            Dim data As Integer = BitConverter.ToInt16(dev.ByteValue, 0)
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.SetDevice(dev.ToString, data)
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""SetDevice""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            RaiseEvent DeviceWrited(Me, New DeviceEventArgs(dev))
        End Sub

        ''' <summary>
        ''' ビットデバイスの一括書き込み
        ''' </summary>
        ''' <param name="devArray"></param>
        ''' <param name="startIndex"></param>
        ''' <param name="length"></param>
        ''' <remarks></remarks>
        Private Sub WriteList(ByRef devArray As List(Of Device), ByVal startIndex As Integer, ByVal length As Integer)
            '開始位置のデバイスで判断する
            If devArray(startIndex).Attribute.IsWordDevice Then
                Me.WriteWordList(devArray, startIndex, length)
            Else
                Me.WriteBitList(devArray, startIndex, length)
            End If
        End Sub

        ''' <summary>
        ''' ビットデバイスの一括書き込み
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <param name="startIndex"></param>
        ''' <param name="length"></param>
        ''' <remarks></remarks>
        Private Sub WriteBitList(ByRef dev As List(Of Device), ByVal startIndex As Integer, ByVal length As Integer)
            Dim datas(((length + 15) \ 16) - 1) As Integer
            For i As Integer = 0 To length - 1
                If dev(startIndex + i).BoolValue Then
                    datas(i \ 16) = datas(i \ 16) Or CInt(2 ^ i)
                End If
            Next
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.WriteDeviceBlock(dev(startIndex).ToString, length, datas(0))
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""WriteDeviceBlock""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            For i As Integer = 0 To length - 1
                RaiseEvent DeviceWrited(Me, New DeviceEventArgs(dev(startIndex + i)))
            Next
        End Sub

        ''' <summary>
        ''' ワードデバイスの一括書き込み
        ''' </summary>
        ''' <param name="dev"></param>
        ''' <param name="startIndex"></param>
        ''' <param name="length"></param>
        ''' <remarks></remarks>
        Private Sub WriteWordList(ByRef dev As List(Of Device), ByVal startIndex As Integer, ByVal length As Integer)
            Dim datas(length - 1) As Integer
            For i As Integer = 0 To length - 1
                datas(i) = BitConverter.ToInt16(dev(startIndex + i).ByteValue, 0)
            Next
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.WriteDeviceBlock(dev(startIndex).ToString, length, datas(0))
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""WriteDeviceBlock""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            For i As Integer = 0 To length - 1
                RaiseEvent DeviceWrited(Me, New DeviceEventArgs(dev(startIndex + i)))
            Next
        End Sub

        ''' <summary>
        ''' ＣＰＵの日付を取得する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCPUDate() As Date
            Dim year As Short
            Dim month As Short
            Dim day As Short
            Dim dayOfWeek As Short
            Dim hour As Short
            Dim minute As Short
            Dim second As Short

            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.GetClockData(year, month, day, dayOfWeek, hour, minute, second)
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""GetClockData""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            Dim d As Date
            Try
                d = New Date(year, month, day, hour, minute, second)
            Catch ex As Exception
                Throw New CMXException("シーケンサの日付が不正です" + year.ToString + "/" + month.ToString + "/" + day.ToString + " " + hour.ToString + ":" + minute.ToString + ":" + second.ToString)
            End Try
            Return d
        End Function

        ''' <summary>
        ''' ＣＰＵの日付を設定する
        ''' </summary>
        ''' <param name="dateTime"></param>
        ''' <remarks></remarks>
        Public Sub SetCPUDate(ByVal dateTime As Date)
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.SetClockData(CShort(dateTime.Year), CShort(dateTime.Month), CShort(dateTime.Day), CShort(dateTime.DayOfWeek), CShort(dateTime.Hour), CShort(dateTime.Minute), CShort(dateTime.Second))
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""SetClockData""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
        End Sub

        ''' <summary>
        ''' ＣＰＵの型式を取得する
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCPUType() As CPUType
            Dim cpuName As String = ""
            Dim cpuTypeCode As Integer
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.GetCpuType(cpuName, cpuTypeCode)
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""GetCpuType""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            Return New CPUType(cpuName, CType(cpuTypeCode, ECPUTypeCode))
        End Function

        ''' <summary>
        ''' リモート実行
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RemoteControl(ByVal operation As ECPUStatus)
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.SetCpuStatus(CType(operation, Integer))
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""SetCpuStatus""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
        End Sub

        ''' <summary>
        ''' リモートＲＵＮの実行
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RemoteRun()
            RemoteControl(ECPUStatus.REMOTE_RUN)
        End Sub

        ''' <summary>
        ''' リモートＳＴＯＰの実行
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RemoteStop()
            RemoteControl(ECPUStatus.REMOTE_STOP)
        End Sub

        ''' <summary>
        ''' リモートＰＡＵＳＥの実行
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RemotePause()
            RemoteControl(ECPUStatus.REMOTE_PAUSE)
        End Sub

        ''' <summary>
        ''' イベントモニタ開始
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub EnableEvent()
            If Me._EventDeviceList.Count = 0 Then
                Return
            End If
            '既にモニタリングしている場合は、一旦停止
            Dim devArrayStr As String = ""
            Dim vals(Me._EventDeviceList.Count - 1) As Integer
            For i As Integer = 0 To Me._EventDeviceList.Count - 1
                devArrayStr = devArrayStr + Me._EventDeviceList(i).ToString + vbLf
                vals(i) = BitConverter.ToInt16(Me._EventDeviceList(i).ByteValue, 0)
            Next
            devArrayStr = devArrayStr.Substring(0, devArrayStr.Length - 1)
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.EntryDeviceStatus(devArrayStr, Me._EventDeviceList.Count, _EventCycle, vals(0))
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""EntryDeviceStatus""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            '_EventEnabled = True
        End Sub

        ''' <summary>
        ''' イベントモニタ停止
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DisableEvent()
            Dim ret As Integer
            SyncLock Me._Lock
                ret = _ActEasyIF.FreeDeviceStatus()
            End SyncLock
            If ret <> 0 Then
                Throw New CMXException("""FreeDeviceStatus""でエラー発生　コード　0x" + ret.ToString("X"))
            End If
            '_EventEnabled = False
        End Sub

        ''' <summary>
        ''' デバイス値変化イベント
        ''' </summary>
        ''' <param name="devicecode"></param>
        ''' <param name="data"></param>
        ''' <param name="result"></param>
        ''' <remarks></remarks>
        Private Sub OnDeviceStatus(ByVal devicecode As String, ByVal data As Integer, ByVal result As Integer) Handles _ActEasyIF.OnDeviceStatus
            'Dim devArray(Me._EventDeviceList.Count - 1) As Device
            'Array.Copy(Me._EventDeviceList.ToArray, devArray, Me._EventDeviceList.Count)

            For Each dev As Device In Me._EventDeviceList
                If dev.ToString = devicecode Then
                    RaiseEvent OnDeviceEvent(Me, New DeviceEventArgs(dev))
                    'イベント処理中にデバイス配列を変更されると、再度イベントを発生してしまう可能性があるためループから抜ける
                    Exit For
                End If
            Next
        End Sub

    End Class

    ''' <summary>
    ''' ＭＸラッパー用ハンドシェイク
    ''' </summary>
    ''' <remarks></remarks>
    Public Class HandShake

        ''' <summary>
        ''' 基本的なハンドシェイク処理
        ''' </summary>
        ''' <remarks></remarks>
        Public MustInherit Class HandShakeBase

            ''' <summary>
            ''' ハンドシェイク開始イベント定義
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Protected Event Starting(ByVal sender As Object)

            ''' <summary>
            ''' 処理開始イベント定義
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Public Event DoWork(ByVal sender As Object)

            ''' <summary>
            ''' ハンドシェイク終了イベント定義
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Public Event Complete(ByVal sender As Object)


            ''' <summary>
            ''' 開始タイムアウト
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Public Event StartTimeout(ByVal sender As Object)

            ''' <summary>
            ''' 終了タイムアウト
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Public Event EndTimeout(ByVal sender As Object)

            ''' <summary>
            ''' エラー発生
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <param name="e"></param>
            ''' <remarks></remarks>
            Public Event Exception(ByVal sender As Object, ByVal e As CMXException)

            ''' <summary>
            ''' コンストラクタ
            ''' </summary>
            ''' <param name="outDevice"></param>
            ''' <param name="inDevice"></param>
            ''' <remarks></remarks>
            Public Sub New(ByVal Wrap As Wrapper, ByVal outDevice As Device, ByVal inDevice As Device)
                Me._Wrap = Wrap
                Me._outDevice = CType(outDevice.Clone, Device)
                Me._inDevice = CType(inDevice.Clone, Device)
            End Sub

            ''' <summary>
            ''' ＭＸコンポーネントラッパー
            ''' </summary>
            ''' <remarks></remarks>
            Private _Wrap As Wrapper
            Public Property Wrap() As Wrapper
                Get
                    Return _Wrap
                End Get
                Set(ByVal value As Wrapper)
                    _Wrap = value
                End Set
            End Property

            ''' <summary>
            ''' 出力信号デバイス
            ''' </summary>
            ''' <remarks></remarks>
            Private _outDevice As Device
            Public Property OutDevice() As Device
                Get
                    Return _outDevice
                End Get
                Set(ByVal value As Device)
                    _outDevice = value
                End Set
            End Property

            ''' <summary>
            ''' 入力信号デバイス
            ''' </summary>
            ''' <remarks></remarks>
            Private _inDevice As Device
            Public Property NewProperty() As Device
                Get
                    Return _inDevice
                End Get
                Set(ByVal value As Device)
                    _inDevice = value
                End Set
            End Property

            ''' <summary>
            ''' 読み出しタイマー
            ''' </summary>
            ''' <remarks></remarks>
            Private _ReadTimer As New Windows.Forms.Timer

            ''' <summary>
            ''' タイムアウトタイマー
            ''' </summary>
            ''' <remarks></remarks>
            Private _TimeoutTimer As New Windows.Forms.Timer

            ''' <summary>
            ''' 読み出し周期
            ''' </summary>
            ''' <remarks></remarks>
            Private _StatusCheckInterval As Integer
            Public Property StatusCheckInterval() As Integer
                Get
                    Return _StatusCheckInterval
                End Get
                Set(ByVal value As Integer)
                    _StatusCheckInterval = value
                End Set
            End Property


            ''' <summary>
            ''' ハンドシェイク開始タイムアウト時間
            ''' </summary>
            ''' <remarks></remarks>
            Private _StartTimeoutInterval As Integer
            Public Property StartTimeoutInterval() As Integer
                Get
                    Return _StartTimeoutInterval
                End Get
                Set(ByVal value As Integer)
                    _StartTimeoutInterval = value
                End Set
            End Property

            ''' <summary>
            ''' ハンドシェイク終了タイムアウト時間
            ''' </summary>
            ''' <remarks></remarks>
            Private _EndTimeoutInterval As Integer
            Public Property EndTimeoutInterval() As Integer
                Get
                    Return _EndTimeoutInterval
                End Get
                Set(ByVal value As Integer)
                    _EndTimeoutInterval = value
                End Set
            End Property

            Private _startTimeoutEnabled As Boolean

            ''' <summary>
            ''' ハンドシェイクを開始
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub Start()
                '開始イベント
                RaiseEvent Starting(Me)

                '読出しタイマを設定
                With Me._ReadTimer
                    AddHandler Me._ReadTimer.Tick, AddressOf OnStartReadTimer
                    .Interval = Me._StatusCheckInterval
                    .Enabled = True
                End With

                'タイムアウトタイマを設定
                If Me._StartTimeoutInterval <> 0 Then
                    With Me._TimeoutTimer
                        AddHandler Me._TimeoutTimer.Tick, AddressOf OnStartTimeoutTimer
                        .Interval = Me._StartTimeoutInterval
                        .Enabled = True
                    End With
                End If
            End Sub

            '読み出しタイマのイベント
            Private Sub OnStartReadTimer(ByVal sender As Object, ByVal e As System.EventArgs)
                Dim dev As Device = CType(Me._inDevice.Clone, Device)
                Dim readDev As Device = Nothing

                Try
                    readDev = Me._Wrap.Read(dev)
                Catch ex As CMXException
                    RaiseEvent Exception(Me, ex)
                    Exit Sub
                End Try

                'デバイスが指定の状態になった
                If readDev.BoolValue = Me._inDevice.BoolValue Then

                    '読み出しタイマを停止
                    With Me._ReadTimer
                        '停止
                        .Enabled = False
                        'ハンドラを解除
                        RemoveHandler .Tick, AddressOf OnStartReadTimer
                    End With

                    'タイムアウトタイマを停止
                    If Me._StartTimeoutInterval <> 0 Then
                        With Me._TimeoutTimer
                            '停止
                            .Enabled = False
                            'ハンドラを解除
                            RemoveHandler .Tick, AddressOf OnStartTimeoutTimer
                        End With
                    End If

                    'ハンドシェイク開始
                    HandshakeStart()
                End If
            End Sub

            'ハンドシェイク開始のタイムアウト
            Private Sub OnStartTimeoutTimer(ByVal sender As Object, ByVal e As System.EventArgs)
                '読み出しタイマ
                With Me._ReadTimer
                    '停止
                    .Enabled = False
                    'ハンドラを解除
                    RemoveHandler .Tick, AddressOf OnStartReadTimer
                End With

                'タイムアウトタイマ
                With Me._TimeoutTimer
                    '停止
                    .Enabled = False
                    'ハンドラを解除
                    RemoveHandler .Tick, AddressOf OnStartTimeoutTimer
                End With

                'タイムアウトイベント発生
                RaiseEvent StartTimeout(Me)
            End Sub

            ''' <summary>
            ''' ハンドシェイク開始処理
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub HandshakeStart()

                '読出しタイマを設定
                With Me._ReadTimer
                    AddHandler Me._ReadTimer.Tick, AddressOf OnEndReadTimer
                    .Interval = _StatusCheckInterval
                    .Enabled = True
                End With

                'タイムアウトタイマを設定
                If _EndTimeoutInterval = 0 Then
                    With Me._TimeoutTimer
                        AddHandler Me._TimeoutTimer.Tick, AddressOf OnEndTimeoutTimer
                        .Interval = _EndTimeoutInterval
                        .Enabled = True
                    End With
                End If

                '呼び出し元に通知
                RaiseEvent DoWork(Me)

            End Sub

            '読み出しタイマのイベント
            Private Sub OnEndReadTimer(ByVal sender As Object, ByVal e As System.EventArgs)
                Dim dev As Device = CType(Me._inDevice.Clone, Device)
                Dim readDev As Device = Nothing

                Try
                    readDev = Me._Wrap.Read(dev)
                Catch ex As CMXException
                    RaiseEvent Exception(Me, ex)
                    Exit Sub
                End Try

                If readDev.BoolValue <> Me._inDevice.BoolValue Then

                    '読み出しタイマ
                    With Me._ReadTimer
                        '停止
                        .Enabled = False
                        'ハンドラを解除
                        RemoveHandler .Tick, AddressOf OnEndReadTimer
                    End With

                    'タイムアウトタイマ
                    If _EndTimeoutInterval = 0 Then
                        With Me._TimeoutTimer
                            '停止
                            .Enabled = False
                            'ハンドラを解除
                            RemoveHandler .Tick, AddressOf OnEndTimeoutTimer
                        End With
                    End If

                    'ハンドシェイク終了
                    HandshakeEnd()
                End If
            End Sub

            'ハンドシェイク開始イベントのタイムアウト
            Private Sub OnEndTimeoutTimer(ByVal sender As Object, ByVal e As System.EventArgs)
                '読み出しタイマ
                With Me._ReadTimer
                    '停止
                    .Enabled = False
                    'ハンドラを解除
                    RemoveHandler .Tick, AddressOf OnEndReadTimer
                End With

                'タイムアウトタイマ
                With Me._TimeoutTimer
                    '停止
                    .Enabled = False
                    'ハンドラを解除
                    RemoveHandler .Tick, AddressOf OnEndTimeoutTimer
                End With

                'タイムアウトイベント発生
                RaiseEvent EndTimeout(Me)
            End Sub

            ''' <summary>
            ''' モニタデバイスイベント処理
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub HandshakeEnd()

                '呼び出し元に通知
                RaiseEvent Complete(Me)

            End Sub

            ''' <summary>
            ''' ＯＮを出力する
            ''' </summary>
            ''' <remarks></remarks>
            Protected Sub OutOn()
                Me._Wrap.Write(Me._outDevice)
            End Sub

            ''' <summary>
            ''' ＯＦＦを出力する
            ''' </summary>
            ''' <remarks></remarks>
            Protected Sub OutOff()
                Dim out As Device = CType(Me._outDevice.Clone, Device)
                out.BoolValue = Not Me._outDevice.BoolValue
                Me._Wrap.Write(out)
            End Sub

        End Class

        ''' <summary>
        ''' 要求型ハンドシェイク
        ''' </summary>
        ''' <remarks></remarks>
        Public Class Active
            Inherits HandShakeBase

            ''' <summary>
            ''' 実行処理
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Public Shadows Event DoWork(ByVal sender As Object)

            ''' <summary>
            ''' 処理をサイクリックに行うかを指定
            ''' </summary>
            ''' <remarks></remarks>
            Private _AutoCyclick As Boolean = False
            Public Property AutoCyclick() As Boolean
                Get
                    Return _AutoCyclick
                End Get
                Set(ByVal value As Boolean)
                    _AutoCyclick = value
                End Set
            End Property

            ''' <summary>
            ''' コンストラクタ
            ''' </summary>
            ''' <param name="MXWrap"></param>
            ''' <param name="outDevice"></param>
            ''' <param name="inDevice"></param>
            ''' <remarks></remarks>
            Public Sub New(ByVal MXWrap As Wrapper, ByVal outDevice As Device, ByVal inDevice As Device)
                MyBase.New(MXWrap, outDevice, inDevice)
                AddHandler MyBase.Starting, AddressOf OnStarting
                AddHandler MyBase.DoWork, AddressOf OnDoWork
                AddHandler MyBase.Complete, AddressOf OnComplete
                AddHandler MyBase.StartTimeout, AddressOf OnStartTimeout
            End Sub

            ''' <summary>
            ''' 開始
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Private Sub OnStarting(ByVal sender As Object)
                'ＯＮを出力
                MyBase.OutOn()
            End Sub

            ''' <summary>
            ''' 処理実行
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Private Sub OnDoWork(ByVal sender As Object)
                Dim out As Device = CType(MyBase.OutDevice.Clone, Device)
                '処理実行
                RaiseEvent DoWork(Me)
                'ＯＦＦを出力
                MyBase.OutOff()
            End Sub

            ''' <summary>
            ''' 終了
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Private Sub OnComplete(ByVal sender As Object)
                '相手側もＯＦＦになった
            End Sub

            ''' <summary>
            ''' 開始タイムアウト処理
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Private Sub OnStartTimeout(ByVal sender As Object)
                'ＯＦＦを出力
                MyBase.OutOff()
            End Sub

        End Class

        ''' <summary>
        ''' 待ち受け型ハンドシェイク
        ''' </summary>
        ''' <remarks></remarks>
        Public Class Passive
            Inherits HandShakeBase

            ''' <summary>
            ''' 実行処理
            ''' </summary>
            ''' <param name="sender">イベント発生元オブジェクト</param>
            ''' <remarks></remarks>
            Public Shadows Event DoWork(ByVal sender As Object)

            ''' <summary>
            ''' 処理をサイクリックに行うかを指定
            ''' </summary>
            ''' <remarks></remarks>
            Private _AutoCyclick As Boolean = False
            Public Property AutoCyclick() As Boolean
                Get
                    Return _AutoCyclick
                End Get
                Set(ByVal value As Boolean)
                    _AutoCyclick = value
                End Set
            End Property

            ''' <summary>
            ''' コンストラクタ
            ''' </summary>
            ''' <param name="MXWrap">オープン済みのＭＸコンポーネントラッパー</param>
            ''' <param name="outDevice">出力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <param name="inDevice">入力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <remarks></remarks>
            Public Sub New(ByVal MXWrap As Wrapper, ByVal outDevice As Device, ByVal inDevice As Device)
                '開始タイムアウトを０（無限）に設定
                MyBase.New(MXWrap, outDevice, inDevice)
                MyBase.StartTimeoutInterval = 0 '無制限

                AddHandler MyBase.Starting, AddressOf OnStarting
                AddHandler MyBase.DoWork, AddressOf OnDoWork
                AddHandler MyBase.Complete, AddressOf OnComplete
                AddHandler MyBase.EndTimeout, AddressOf OnEndTimeout

                'ＯＦＦを出力
                MyBase.OutOff()
            End Sub

            ''' <summary>
            ''' 読み込み開始処理
            ''' </summary>
            ''' <param name="sender">イベント発生元オブジェクト</param>
            ''' <remarks></remarks>
            Private Sub OnStarting(ByVal sender As Object)
                '何もしない
            End Sub

            ''' <summary>
            ''' 処理実行
            ''' </summary>
            ''' <param name="sender">イベント発生元オブジェクト</param>
            ''' <remarks></remarks>
            Private Sub OnDoWork(ByVal sender As Object)
                '処理実行
                RaiseEvent DoWork(Me)
                'ＯＮを出力
                MyBase.OutOn()
            End Sub

            ''' <summary>
            ''' 読み出し終了処理
            ''' </summary>
            ''' <param name="sender">イベント発生元オブジェクト</param>
            ''' <remarks></remarks>
            Private Sub OnComplete(ByVal sender As Object)
                'ＯＦＦを出力
                MyBase.OutOff()
                '自動サイクリックの場合、再起動
                If _AutoCyclick Then
                    MyBase.Start()
                End If
            End Sub

            ''' <summary>
            ''' 終了タイムアウト処理
            ''' </summary>
            ''' <param name="sender">イベント発生元オブジェクト</param>
            ''' <remarks></remarks>
            Private Sub OnEndTimeout(ByVal sender As Object)
                'ＯＦＦを出力
                MyBase.OutOff()
                '自動サイクリックの場合、再起動
                If _AutoCyclick Then
                    MyBase.Start()
                End If
            End Sub
        End Class

        Public Class ActiveWrite
            Inherits Active

            ''' <summary>
            ''' 読み書きデバイス
            ''' </summary>
            ''' <remarks></remarks>
            Private _DeviceList As List(Of Device)
            Public Property DeviceList() As List(Of Device)
                Get
                    Return _DeviceList
                End Get
                Set(ByVal value As List(Of Device))
                    _DeviceList = value
                End Set
            End Property

            ''' <summary>
            ''' コンストラクタ
            ''' </summary>
            ''' <param name="MXWrap">オープン済みのＭＸコンポーネントラッパー</param>
            ''' <param name="outDevice">出力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <param name="inDevice">入力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <remarks></remarks>
            Public Sub New(ByVal MXWrap As Wrapper, ByVal outDevice As Device, ByVal inDevice As Device, ByVal deviceList As List(Of Device), Optional ByVal startTimeout As Integer = 10000, Optional ByVal endTimeout As Integer = 10000, Optional ByVal autoCyclick As Boolean = False)
                MyBase.New(MXWrap, outDevice, inDevice)
                Me._DeviceList = deviceList
                AddHandler MyBase.DoWork, AddressOf OnDoProcess
            End Sub

            ''' <summary>
            ''' 書き込み処理
            ''' </summary>
            ''' <param name="sender">イベント発生元オブジェクト</param>
            ''' <remarks></remarks>
            Private Sub OnDoProcess(ByVal sender As Object)
                'データ書き込み
                MyBase.Wrap.WriteList(Me._DeviceList)
            End Sub

        End Class

        Public Class ActiveRead
            Inherits Active

            ''' <summary>
            ''' 読み書きデバイス
            ''' </summary>
            ''' <remarks></remarks>
            Private _DeviceList As List(Of Device)
            Public Property DeviceList() As List(Of Device)
                Get
                    Return _DeviceList
                End Get
                Set(ByVal value As List(Of Device))
                    _DeviceList = value
                End Set
            End Property

            ''' <summary>
            ''' コンストラクタ
            ''' </summary>
            ''' <param name="MXWrap">オープン済みのＭＸコンポーネントラッパー</param>
            ''' <param name="outDevice">出力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <param name="inDevice">入力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <remarks></remarks>
            Public Sub New(ByVal MXWrap As Wrapper, ByVal outDevice As Device, ByVal inDevice As Device, Optional ByVal startTimeout As Integer = 10000, Optional ByVal endTimeout As Integer = 10000, Optional ByVal autoCyclick As Boolean = False)
                MyBase.New(MXWrap, outDevice, inDevice)
                Me._DeviceList = DeviceList
                AddHandler MyBase.DoWork, AddressOf OnDoWork
            End Sub

            ''' <summary>
            ''' 読み込み処理
            ''' </summary>
            ''' <param name="sender">イベント発生元オブジェクト</param>
            ''' <remarks></remarks>
            Private Sub OnDoWork(ByVal sender As Object)
                'データ読み込み
                MyBase.Wrap.ReadList(Me._DeviceList)
            End Sub

        End Class

        Public Class PassiveWrite
            Inherits Passive

            ''' <summary>
            ''' 読み書きデバイス
            ''' </summary>
            ''' <remarks></remarks>
            Private _DeviceList As List(Of Device)
            Public Property DeviceList() As List(Of Device)
                Get
                    Return _DeviceList
                End Get
                Set(ByVal value As List(Of Device))
                    _DeviceList = value
                End Set
            End Property


            ''' <summary>
            ''' コンストラクタ
            ''' </summary>
            ''' <param name="MXWrap">オープン済みのＭＸコンポーネントラッパー</param>
            ''' <param name="outDevice">出力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <param name="inDevice">入力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <remarks></remarks>
            Public Sub New(ByVal MXWrap As Wrapper, ByVal outDevice As Device, ByVal inDevice As Device, Optional ByVal endTimeout As Integer = 10000, Optional ByVal autoCyclick As Boolean = False)
                MyBase.New(MXWrap, outDevice, inDevice)
                Me._DeviceList = DeviceList
                AddHandler MyBase.DoWork, AddressOf OnDoWork
            End Sub

            ''' <summary>
            ''' 書き込み処理
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <remarks></remarks>
            Private Sub OnDoWork(ByVal sender As Object)
                'データ書き込み
                MyBase.Wrap.WriteList(Me._DeviceList)
            End Sub

        End Class

        Public Class PassiveRead
            Inherits Passive

            ''' <summary>
            ''' 読み書きデバイス
            ''' </summary>
            ''' <remarks></remarks>
            Private _DeviceList As List(Of Device)
            Public Property DeviceList() As List(Of Device)
                Get
                    Return _DeviceList
                End Get
                Set(ByVal value As List(Of Device))
                    _DeviceList = value
                End Set
            End Property

            ''' <summary>
            ''' コンストラクタ
            ''' </summary>
            ''' <param name="MXWrap">オープン済みのＭＸコンポーネントラッパー</param>
            ''' <param name="outDevice">出力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <param name="inDevice">入力するデバイスおよび状態。ＯＮの論理をあらかじめ設定しておく</param>
            ''' <remarks></remarks>
            Public Sub New(ByVal MXWrap As Wrapper, ByVal outDevice As Device, ByVal inDevice As Device, Optional ByVal endTimeout As Integer = 10000, Optional ByVal autoCyclick As Boolean = False)
                MyBase.New(MXWrap, outDevice, inDevice)
                Me._DeviceList = DeviceList
                AddHandler MyBase.DoWork, AddressOf OnDoWork
            End Sub

            ''' <summary>
            ''' 読み込み処理
            ''' </summary>
            ''' <param name="sender">イベント発生元オブジェクト</param>
            ''' <remarks></remarks>
            Private Sub OnDoWork(ByVal sender As Object)
                'データ読み込み
                MyBase.Wrap.ReadList(Me._DeviceList)
            End Sub

        End Class

    End Class

    ''' <summary>
    ''' デバイス範囲作成時のタグの処理
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ETagListingOperation
        複写
        要素番号を追加
        何もしない
    End Enum

    ''' <summary>
    ''' デバイス範囲を作成する
    ''' </summary>
    ''' <param name="srcDev">作成先頭デバイス</param>
    ''' <param name="length">作成デバイスの長さ</param>
    ''' <returns>作成されたデバイス配列</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeviceRange(ByVal srcDev As Device, ByVal length As Integer, Optional ByVal tagOperation As ETagListingOperation = ETagListingOperation.要素番号を追加) As Device()
        Dim deviceArray(length - 1) As Device
        For i As Integer = 0 To length - 1
            deviceArray(i) = New Device(srcDev.DeviceName, srcDev.DeviceNo + i)
            Select Case tagOperation
                Case ETagListingOperation.要素番号を追加
                    deviceArray(i).Tag = srcDev.Tag + i.ToString
                Case ETagListingOperation.複写
                    deviceArray(i).Tag = srcDev.Tag
            End Select
            deviceArray(i).UShortValue = srcDev.UShortValue
        Next
        Return deviceArray
    End Function
    ''' <summary>
    ''' デバイス配列を作成する
    ''' </summary>
    ''' <param name="baseDevice">作成先頭デバイス</param>
    ''' <param name="byteArray">データバイト</param>
    ''' <returns>作成されたデバイス配列</returns>
    ''' <remarks></remarks>
    Private Shared Function GetDeviceArray(ByVal baseDevice As Device, ByVal byteArray As Byte()) As Device()
        Dim cnt As Integer = CInt(byteArray.Length / 2)
        Dim devArray(cnt - 1) As Device
        'デバイス作成
        For i As Integer = 0 To cnt - 1
            If cnt = 1 Then
                devArray(i) = New Device(baseDevice.DeviceName, baseDevice.DeviceNo + i, baseDevice.Tag)
            Else
                devArray(i) = New Device(baseDevice.DeviceName, baseDevice.DeviceNo + i, baseDevice.Tag + i.ToString)
            End If
            devArray(i).UShortValue = BitConverter.ToUInt16(byteArray, i * 2)
        Next
        Return devArray
    End Function
    ''' <summary>
    ''' 符号付き１６ビット（ワード）のデバイスを作成する
    ''' </summary>
    ''' <param name="baseDevice">作成先頭デバイス</param>
    ''' <param name="data">デバイス値</param>
    ''' <returns>作成された１つのデバイス配列</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeviceArray(ByVal baseDevice As Device, ByVal data As Int16) As Device()
        Return GetDeviceArray(baseDevice, BitConverter.GetBytes(data))
    End Function
    ''' <summary>
    ''' 符号なし１６ビット（ワード）のデバイスを作成する
    ''' </summary>
    ''' <param name="baseDevice">作成先頭デバイス</param>
    ''' <param name="data">デバイス値</param>
    ''' <returns>作成された１つのデバイス配列</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeviceArray(ByVal baseDevice As Device, ByVal data As UInt16) As Device()
        Return GetDeviceArray(baseDevice, BitConverter.GetBytes(data))
    End Function
    ''' <summary>
    ''' 符号付き３２ビット（ダブルワード）のデバイスを作成する
    ''' </summary>
    ''' <param name="baseDevice">作成先頭デバイス</param>
    ''' <param name="data">デバイス値</param>
    ''' <returns>作成された２つのデバイス配列</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeviceArray(ByVal baseDevice As Device, ByVal data As Int32) As Device()
        Return GetDeviceArray(baseDevice, BitConverter.GetBytes(data))
    End Function
    ''' <summary>
    ''' 符号なし３２ビット（ダブルワード）のデバイスを作成する
    ''' </summary>
    ''' <param name="baseDevice">作成先頭デバイス</param>
    ''' <param name="data">デバイス値</param>
    ''' <returns>作成された２つのデバイス配列</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeviceArray(ByVal baseDevice As Device, ByVal data As UInt32) As Device()
        Return GetDeviceArray(baseDevice, BitConverter.GetBytes(data))
    End Function
    ''' <summary>
    ''' 符号付き６４ビット（クアッドワード）のデバイスを作成する
    ''' </summary>
    ''' <param name="baseDevice">作成先頭デバイス</param>
    ''' <param name="data">デバイス値</param>
    ''' <returns>作成された４つのデバイス配列</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeviceArray(ByVal baseDevice As Device, ByVal data As Int64) As Device()
        Return GetDeviceArray(baseDevice, BitConverter.GetBytes(data))
    End Function
    ''' <summary>
    ''' 符号なし６４ビット（クアッドワード）のデバイスを作成する
    ''' </summary>
    ''' <param name="baseDevice">作成先頭デバイス</param>
    ''' <param name="data">デバイス値</param>
    ''' <returns>作成された４つのデバイス配列</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDeviceArray(ByVal baseDevice As Device, ByVal data As UInt64) As Device()
        Return GetDeviceArray(baseDevice, BitConverter.GetBytes(data))
    End Function
    ''' <summary>
    ''' デバイス配列から３２ビット符号付きデータを取得
    ''' </summary>
    ''' <param name="deviceArray">作成元デバイス配列（２つ）</param>
    ''' <returns>符号つき３２ビット整数</returns>
    ''' <remarks></remarks>
    Public Shared Function ToInt32(ByVal deviceArray As Device()) As Int32
        Dim byteArray(3) As Byte
        Dim cnt As Integer = CInt(byteArray.Length / 2)

        For i As Integer = 0 To cnt - 1
            Array.Copy(deviceArray(i).ByteValue, 0, byteArray, i * 2, 2)
        Next
        Return BitConverter.ToInt32(byteArray, 0)
    End Function
    ''' <summary>
    ''' デバイス配列から３２ビット符号なしデータを取得
    ''' </summary>
    ''' <param name="deviceArray">作成元デバイス配列（２つ）</param>
    ''' <returns>符号なし３２ビット整数</returns>
    ''' <remarks></remarks>
    Public Shared Function ToUInt32(ByVal deviceArray As Device()) As UInt32
        Dim byteArray(3) As Byte
        Dim cnt As Integer = CInt(byteArray.Length / 2)

        For i As Integer = 0 To cnt - 1
            Array.Copy(deviceArray(i).ByteValue, 0, byteArray, i * 2, 2)
        Next
        Return BitConverter.ToUInt32(byteArray, 0)
    End Function
    ''' <summary>
    ''' デバイス配列から６４ビット符号付きデータを取得
    ''' </summary>
    ''' <param name="deviceArray">作成元デバイス配列（４つ）</param>
    ''' <returns>符号つき６４ビット整数</returns>
    ''' <remarks></remarks>
    Public Shared Function ToInt64(ByVal deviceArray As Device()) As Int64
        Dim byteArray(7) As Byte
        Dim cnt As Integer = CInt(byteArray.Length / 2)

        For i As Integer = 0 To cnt - 1
            Array.Copy(deviceArray(i).ByteValue, 0, byteArray, i * 2, 2)
        Next
        Return BitConverter.ToInt64(byteArray, 0)
    End Function
    ''' <summary>
    ''' デバイス配列から６４ビット符号なしデータを取得
    ''' </summary>
    ''' <param name="deviceArray">作成元デバイス配列（４つ）</param>
    ''' <returns>符号なし６４ビット整数</returns>
    ''' <remarks></remarks>
    Public Shared Function ToUInt64(ByVal deviceArray As Device()) As UInt64
        Dim byteArray(7) As Byte
        Dim cnt As Integer = CInt(byteArray.Length / 2)

        For i As Integer = 0 To cnt - 1
            Array.Copy(deviceArray(i).ByteValue, 0, byteArray, i * 2, 2)
        Next
        Return BitConverter.ToUInt64(byteArray, 0)
    End Function
End Class

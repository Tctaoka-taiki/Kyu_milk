Imports System.Runtime.InteropServices


''' <summary>
''' 三菱電機製ＵＨＦタグクラス
''' </summary>
''' <remarks></remarks>
Public Class MelTag
    Inherits Tag
    Private Const SYSTEM_AREA_SIZE As Integer = 2
    Private Const USER_AREA_SIZE As Integer = 12
    Private Const DATA_AREA_SIZE As Integer = 0
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


''' <summary>
''' 三菱電機製ＵＨＦ対応ＲＦＩＤリーダ・ライタ操作クラス
''' </summary>
''' <remarks></remarks>
Public Class MelUHFTag
    Implements 共通.IRFIDリーダライタ

    Public Sub 初期設定() Implements 共通.IRFIDリーダライタ.初期設定
        If CUtil.設定関連.設定Boolean値読込("RFID.有効") Then
            Try
                'リーダライタ初期設定
                Address = CUtil.設定関連.設定文字列読込("アンテナアドレス")
                AntennaPort = CInt(CUtil.設定関連.設定文字列読込("アンテナポート"))
                System.Threading.Thread.Sleep(100)
                SetPower(MelUHFTag.EPower.DBM_18)
            Catch ex As Exception
                CMsg.gMsg_エラー("リーダライタの初期化に失敗しました。リーダライタが接続され、電源が入っているか確認の上、起動し直してください。")
                'end
                Throw
            End Try
        End If
    End Sub
    Public Function GetTagIDs() As System.Collections.Generic.List(Of 共通.TagID) Implements 共通.IRFIDリーダライタ.GetTagIDs
        Dim NumberOfTagsFound As Integer
        Dim NumberOfTagsReturned As Integer

        Return Me.GetTagIDs(EIdentifyMethod.IDENTIFY_ALL, NumberOfTagsFound, NumberOfTagsReturned)
    End Function

#Region "内部列挙型定義"

    ''' <summary>
    ''' 識別方法列挙型
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum EIdentifyMethod As Integer
        ''' <summary>
        ''' フィールド内にあるすべてのタグを認識したら終了する
        ''' </summary>
        ''' <remarks></remarks>
        IDENTIFY_ALL = 0
        ''' <summary>
        ''' 認識したタグ数が、NumberOfTagsに達したら終了する
        ''' </summary>
        ''' <remarks></remarks>
        IDENTIFY_AT_LEAST = 1
        ''' <summary>
        ''' フィールド内にあるすべてのタグを認識するか、認識したタグ数が、NumberOfTagsに達したら終了する
        ''' </summary>
        ''' <remarks></remarks>
        IDENTIFY_NO_MORE_THAN = 2
        ''' <summary>
        ''' 認識したタグ数が、NumberOfTagsに達したら終了する（タグ数がわかっている場合）
        ''' </summary>
        ''' <remarks></remarks>
        IDENTIFY_EXACTLY = 3
    End Enum

    ''' <summary>
    ''' チャネルキャリアセンス設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum ECarrier As Integer
        CARRIIERSENSE_OFF = 0
        CARRIIERSENSE_ON = 1
    End Enum
#End Region

#Region "外部列挙型定義"
    ''' <summary>
    ''' エラーコード列挙型
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum EErrorCode As Integer
        ''' <summary>
        ''' エラー無し
        ''' </summary>
        ERROR_SUCCESS = 0

        ''' <summary>
        ''' コマンド実行エラー
        ''' </summary>
        ERROR_COMMAND = 1

        ''' <summary>
        ''' キャンセル終了
        ''' </summary>
        ERROR_CANCEL = 2

        ''' <summary>
        ''' 入力パラメータ不正
        ''' </summary>
        ERROR_PARAMETER = 3

        ''' <summary>
        ''' リーダライタ出力不正
        ''' </summary>
        ERROR_RW = 4

        ''' <summary>
        ''' RDCTLリソース不足
        ''' </summary>
        ERROR_RESOURCE = 5

        ''' <summary>
        ''' 通信エラー
        ''' </summary>
        ERROR_COMMUNICATION = 6

        ''' <summary>
        ''' RDCTL内部エラー
        ''' </summary>
        ERROR_INTERNAL = 7
    End Enum

    ''' <summary>
    ''' サブエラーコード列挙型
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ESubErrorCode As Integer

        ''' <summary>
        ''' コマンドがキャンセル終了
        ''' </summary>
        ERROR_CANCEL_COMMAND = 22211

        ''' <summary>
        ''' 入力データが不正
        ''' </summary>
        ERROR_PARAMETER_INPUT_DATA = 22244

        ''' <summary>
        ''' 入力パラメータが不正
        ''' </summary>
        ERROR_PARAMETER_INPUT_PARAMETER = 22261

        ''' <summary>
        ''' リーダライタのレスポンス出力データが不正
        ''' </summary>
        ERROR_RW_RESPONSE_OUTPUT_DATA = 22245

        ''' <summary>
        ''' リーダライタのレスポンス出力型に不正
        ''' </summary>
        ERROR_RW_RESPONSE_OUTPUT_TYPE = 22247

        ''' <summary>
        ''' リーダライタのレスポンスのコマンドコードが不一致
        ''' </summary>
        ERROR_RW_RESPONSE_COMMAND_CODE_MISMATCH = 22248

        ''' <summary>
        ''' 出力パラメータが不正
        ''' </summary>
        ERROR_RW_OUTPUT_PARAMETER = 22262

        ''' <summary>
        ''' バッファ不足
        ''' </summary>
        ERROR_RESOURCE_BUFFER_DEPLETION = 22241

        ''' <summary>
        ''' CreateFileに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_CREATE_FILE = 22832

        ''' <summary>
        ''' HeapCreateに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_HEAP_CREATE = 22837

        ''' <summary>
        ''' HeapAllocに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_HEAP_ALLOC = 22838

        ''' <summary>
        ''' HeapSizeに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_HEAP_SIZE = 22839

        ''' <summary>
        ''' VirtualAllocに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_VIRTUAL_ALLOC = 22890

        ''' <summary>
        ''' VirtualLockに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_VIRTUAL_LOCK = 22892

        ''' <summary>
        ''' CreateMutexに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_CREATE_MUTEX = 22847

        ''' <summary>
        ''' CreateSemaphoreに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_CREATE_SEMAPHORE = 22848

        ''' <summary>
        ''' CreateEventに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_CREATE_EVENT = 22849

        ''' <summary>
        ''' CreateFileMappingに失敗
        ''' </summary>
        ERROR_RESOURCE_FAILURE_CREATE_FILE_MAPPING = 22850

        ''' <summary>
        ''' 通信エラー
        ''' </summary>
        ERROR_COMMUNICATION = 22251

        ''' <summary>
        ''' 通信ポートの確保に失敗
        ''' </summary>
        ERROR_COMMUNICATION_FAILURE_OPEN_PORT = 22252

        ''' <summary>
        ''' コマンド送信に失敗
        ''' </summary>
        ERROR_COMMUNICATION_FAILURE_SEND_COMMAND = 22253

        ''' <summary>
        ''' レスポンス受信に失敗
        ''' </summary>
        ERROR_COMMUNICATION_FAILURE_RECEIVE_RESPONSE = 22254

        ''' <summary>
        ''' 通信ポートの開放に失敗
        ''' </summary>
        ERROR_COMMUNICATION_FAILURE_CLOSE_PORT = 22255

        ''' <summary>
        ''' 受信が完了しなかった
        ''' </summary>
        ERROR_COMMUNICATION_NOT_COMPLIET_RECEIVING = 22256

        ''' <summary>
        ''' 通信ポート番号が不正
        ''' </summary>
        ERROR_COMMUNICATION_IRREGULAR_PORT_NUMBER = 22231

        ''' <summary>
        ''' 内部エラー
        ''' </summary>
        ERROR_INTERNAL = 22210

        ''' <summary>
        ''' サポート外の型を使用
        ''' </summary>
        ERROR_INTERNAL_USE_NONSUPPORT_TYPE = 22240

        ''' <summary>
        ''' 符号化に失敗
        ''' </summary>
        ERROR_INTERNAL_FAILURE_ENCODING = 22242

        ''' <summary>
        ''' データ長に不正
        ''' </summary>
        ERROR_INTERNAL_IRREGULAR_DATA_LENGTH = 22243

        ''' <summary>
        ''' 復号化に失敗
        ''' </summary>
        ERROR_INTERNAL_FAILURE_DECODING = 22246

    End Enum

    ''' <summary>
    ''' 送信電力値
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum EPower As Integer
        DBM_18 = 0
        DBM_20 = 1
        DBM_22 = 2
        DBM_24 = 3
        DBM_26 = 4
        DBM_28 = 5
        DBM_30 = 6
    End Enum

    ''' <summary>
    ''' ステータス取得値
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum EStatus As Integer
        ''' <summary>
        ''' 正常
        ''' </summary>
        ''' <remarks></remarks>
        STATUS_OK = 0
        ''' <summary>
        ''' アンテナ異常
        ''' </summary>
        ''' <remarks></remarks>
        STATUS_ANTENNA_ERROR = 16
        ''' <summary>
        ''' 送信電力異常
        ''' </summary>
        ''' <remarks></remarks>
        STATUS_POWER_ERROR = 32
        ''' <summary>
        ''' ＰＬＬロックオフ異常
        ''' </summary>
        ''' <remarks></remarks>
        STATUS_PLLLOCKOFF_ERROR = 128
    End Enum
#End Region

#Region "構造体定義"

    ''' <summary>
    ''' エラー情報取得構造体
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure MRS_RDCTL_ERROR_INFO
        ''' <summary>
        ''' エラーコード
        ''' </summary>
        ''' <remarks></remarks>
        Public ErrorCode As EErrorCode
        ''' <summary>
        ''' サブエラーコード
        ''' </summary>
        ''' <remarks></remarks>
        Public SubCode As ESubErrorCode
        ''' <summary>
        ''' サブサブエラーコード
        ''' </summary>
        ''' <remarks></remarks>
        Public SubsubCode As Integer
        ''' <summary>
        ''' 行番号
        ''' </summary>
        ''' <remarks></remarks>
        Public FileLine As Integer
        ''' <summary>
        ''' ファイル名
        ''' </summary>
        ''' <remarks></remarks>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=20)> _
        Public FileName As String
    End Structure

    ''' <summary>
    ''' アプリケーションファミリ
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure MRS_RDCTL_AFI_INFO
        Public Enum EApplicationFamily As Integer
            ''' <summary>
            ''' すべてのアプリケーションファミリー
            ''' </summary>
            ''' <remarks></remarks>
            ApplicationFamily_ALL = 0
            ''' <summary>
            ''' EAN,UCC
            ''' </summary>
            ''' <remarks></remarks>
            ApplicationFamily_AFIBlock9 = 9
            ''' <summary>
            ''' ASN MH 10.8.2
            ''' </summary>
            ''' <remarks></remarks>
            ApplicationFamily_AFIBlockA = 10
            ''' <summary>
            ''' ISO/IEC15459
            ''' </summary>
            ''' <remarks></remarks>
            ApplicationFamily_AFIBlockB = 11
            ''' <summary>
            ''' IATA
            ''' </summary>
            ''' <remarks></remarks>
            ApplicationFamily_AFIBlockC = 12
        End Enum
        Public Enum EApplicationSubFamily As Integer
            ''' <summary>
            ''' すべてのアプリケーションファミリー
            ''' </summary>
            ''' <remarks></remarks>
            ApplicationSubFamily_ALL = 0
            ApplicationSubFamily_1 = 1
            ApplicationSubFamily_2 = 2
            ApplicationSubFamily_3 = 3
            ApplicationSubFamily_4 = 4
            ApplicationSubFamily_5 = 5
            ApplicationSubFamily_6 = 6
            ApplicationSubFamily_7 = 7
            ApplicationSubFamily_8 = 8
            ApplicationSubFamily_9 = 9
            ApplicationSubFamily_10 = 10
            ApplicationSubFamily_11 = 11
            ApplicationSubFamily_12 = 12
            ApplicationSubFamily_13 = 13
            ApplicationSubFamily_14 = 14
            ApplicationSubFamily_15 = 15
        End Enum
        Public ApplicationFamily As EApplicationFamily
        Public ApplicationSubFamily As EApplicationSubFamily
    End Structure

    ''' <summary>
    ''' バッファ情報構造体
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure MRS_RDCTL_BUFFER_INFO
        Public Buffer As IntPtr
        Public BufferSize As Integer
        Public WriteSize As Integer
        Public _reserved As Integer
    End Structure

#End Region

#Region "内部インタフェース定義"
    Private Interface MelRFID
        Property ErrorInfo() As MRS_RDCTL_ERROR_INFO
        Function SetTagID( _
                    ByVal Address As String, _
                    ByVal TagID As String, _
                    ByVal WriteTagID As String) As EErrorCode
        Function InventoryTags( _
                    ByVal Address As String, _
                    ByVal RdctlAfiInfo As MRS_RDCTL_AFI_INFO, _
                    ByVal RdctlIdMethod As Integer, _
                    ByVal NumberOfTags As Integer, _
                    ByRef BufferInfo As MRS_RDCTL_BUFFER_INFO, _
                    ByRef NumberOfTagsFound As Integer, _
                    ByRef NumberOfTagsReturned As Integer) As EErrorCode
        Function SetAntennaPort( _
                    ByVal Address As String, _
                    ByVal AntennaPort As Integer) As EErrorCode
        Function SetPower( _
                    ByVal Address As String, _
                    ByVal Power As EPower) As EErrorCode
        Function SetChannel( _
                    ByVal Address As String, _
                    ByVal CarrierSense2 As Boolean, _
                    ByVal CarrierSense3 As Boolean, _
                    ByVal CarrierSense4 As Boolean, _
                    ByVal CarrierSense5 As Boolean, _
                    ByVal CarrierSense6 As Boolean, _
                    ByVal CarrierSense7 As Boolean, _
                    ByVal CarrierSense8 As Boolean) As EErrorCode
        Function GetStatus( _
                    ByVal Address As String, _
                    ByRef Status As EStatus) As EErrorCode
    End Interface
#End Region

#Region "内部クラス定義"

    'ＬＡＮインタフェースのＲＦＩＤ制御
    Private Class CLAN
        Implements MelRFID

        'タグの識別
        Private Declare Function MRS_RDCTL_InventoryTags_CLA Lib "RDCTL.dll" ( _
                    ByVal Address As String, _
                    ByVal RdctlAfiInfo As MRS_RDCTL_AFI_INFO, _
                    ByVal RdctlIdMethod As Integer, _
                    ByVal NumberOfTags As Integer, _
                    ByRef BufferInfo As MRS_RDCTL_BUFFER_INFO, _
                    ByRef NumberOfTagsFound As Integer, _
                    ByRef NumberOfTagsReturned As Integer, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As Integer
        'タグIDの設定
        Private Declare Function MRS_RDCTL_EX_SetTagID_CLA Lib "RDCTL.dll" ( _
                    ByVal Address As String, _
                    ByVal TagID As String, _
                    ByVal WriteTagID As String, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As Integer
        '利用アンテナポートの選択
        Private Declare Function MRS_RDCTL_EX_SetAntennaPort_CLA Lib "RDCTL.dll" ( _
                    ByVal Address As String, _
                    ByVal AntennaPort As Integer, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As EErrorCode
        '送信出力の設定
        Private Declare Function MRS_RDCTL_EX_SetPower_CLA Lib "RDCTL.dll" ( _
                    ByVal Address As String, _
                    ByVal Power As EPower, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As EErrorCode
        'ＬＢＴ使用チャネルの設定
        Private Declare Function MRS_RDCTL_EX_SetChannel_CLA Lib "RDCTL.dll" ( _
                    ByVal Address As String, _
                    ByVal CarrierSense2 As ECarrier, _
                    ByVal CarrierSense3 As ECarrier, _
                    ByVal CarrierSense4 As ECarrier, _
                    ByVal CarrierSense5 As ECarrier, _
                    ByVal CarrierSense6 As ECarrier, _
                    ByVal CarrierSense7 As ECarrier, _
                    ByVal CarrierSense8 As ECarrier, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As EErrorCode
        ' ステータスの取得
        Private Declare Function MRS_RDCTL_EX_GetStatus_CLA Lib "RDCTL.dll" ( _
                            ByVal Address As String, _
                            ByRef Status As EStatus, _
                            ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As EErrorCode
        Private _ErrorInfo As MRS_RDCTL_ERROR_INFO
        Public Property ErrorInfo() As MRS_RDCTL_ERROR_INFO Implements MelRFID.ErrorInfo

            Get
                Return _ErrorInfo
            End Get
            Set(ByVal value As MRS_RDCTL_ERROR_INFO)
                _ErrorInfo = value
            End Set
        End Property
        Public Function SetTagID(ByVal Address As String, ByVal TagID As String, ByVal WriteTagID As String) As EErrorCode Implements MelRFID.SetTagID
            Return CType(MRS_RDCTL_EX_SetTagID_CLA(Address, TagID, WriteTagID, Me._ErrorInfo), EErrorCode)
        End Function

        Public Function InventoryTags(ByVal Address As String, ByVal RdctlAfiInfo As MRS_RDCTL_AFI_INFO, ByVal RdctlIdMethod As Integer, ByVal NumberOfTags As Integer, ByRef BufferInfo As MRS_RDCTL_BUFFER_INFO, ByRef NumberOfTagsFound As Integer, ByRef NumberOfTagsReturned As Integer) As EErrorCode Implements MelRFID.InventoryTags
            Return CType(MRS_RDCTL_InventoryTags_CLA(Address, RdctlAfiInfo, RdctlIdMethod, NumberOfTags, BufferInfo, NumberOfTagsFound, NumberOfTagsReturned, Me._ErrorInfo), EErrorCode)
        End Function

        Public Function SetAntennaPort(ByVal Address As String, ByVal AntennaPort As Integer) As EErrorCode Implements MelRFID.SetAntennaPort
            Return CType(MRS_RDCTL_EX_SetAntennaPort_CLA(Address, AntennaPort, Me._ErrorInfo), EErrorCode)
        End Function

        Public Function SetPower(ByVal Address As String, ByVal Power As EPower) As EErrorCode Implements MelRFID.SetPower
            Return CType(MRS_RDCTL_EX_SetPower_CLA(Address, Power, Me._ErrorInfo), EErrorCode)
        End Function

        Public Function SetChannel(ByVal Address As String, ByVal CarrierSense2 As Boolean, ByVal CarrierSense3 As Boolean, ByVal CarrierSense4 As Boolean, ByVal CarrierSense5 As Boolean, ByVal CarrierSense6 As Boolean, ByVal CarrierSense7 As Boolean, ByVal CarrierSense8 As Boolean) As EErrorCode Implements MelRFID.SetChannel
            Dim cs2, cs3, cs4, cs5, cs6, cs7, cs8 As ECarrier
            If CarrierSense2 Then cs2 = ECarrier.CARRIIERSENSE_ON Else cs2 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense3 Then cs3 = ECarrier.CARRIIERSENSE_ON Else cs3 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense4 Then cs4 = ECarrier.CARRIIERSENSE_ON Else cs4 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense5 Then cs5 = ECarrier.CARRIIERSENSE_ON Else cs5 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense6 Then cs6 = ECarrier.CARRIIERSENSE_ON Else cs6 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense7 Then cs7 = ECarrier.CARRIIERSENSE_ON Else cs7 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense8 Then cs8 = ECarrier.CARRIIERSENSE_ON Else cs8 = ECarrier.CARRIIERSENSE_OFF
            Return CType(MRS_RDCTL_EX_SetChannel_CLA(Address, cs2, cs3, cs4, cs5, cs6, cs7, cs8, Me._ErrorInfo), EErrorCode)
        End Function

        Public Function GetStatus(ByVal Address As String, ByRef Status As EStatus) As EErrorCode Implements MelRFID.GetStatus
            Return CType(MRS_RDCTL_EX_GetStatus_CLA(Address, Status, Me._ErrorInfo), EErrorCode)
        End Function
    End Class

    'ＲＳ２３２ＣインタフェースのＲＦＩＤ制御
    Private Class CRS
        Implements MelRFID

        'タグの識別
        Private Declare Function MRS_RDCTL_InventoryTags_CRS Lib "RDCTL.dll" ( _
                    ByVal CommNo As Integer, _
                    ByVal RdctlAfiInfo As MRS_RDCTL_AFI_INFO, _
                    ByVal RdctlIdMethod As Integer, _
                    ByVal NumberOfTags As Integer, _
                    ByRef BufferInfo As MRS_RDCTL_BUFFER_INFO, _
                    ByRef NumberOfTagsFound As Integer, _
                    ByRef NumberOfTagsReturned As Integer, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As Integer
        'タグIDの設定
        Private Declare Function MRS_RDCTL_EX_SetTagID_CRS Lib "RDCTL.dll" ( _
                    ByVal CommNo As Integer, _
                    ByVal TagID As String, _
                    ByVal WriteTagID As String, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As Integer
        '利用アンテナポートの選択
        Private Declare Function MRS_RDCTL_EX_SetAntennaPort_CRS Lib "RDCTL.dll" ( _
                    ByVal CommNo As Integer, _
                    ByVal AntennaPort As Integer, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As EErrorCode
        '送信出力の設定
        Private Declare Function MRS_RDCTL_SetPower_CRS Lib "RDCTL.dll" ( _
                    ByVal CommNo As Integer, _
                    ByVal Power As EPower, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As EErrorCode
        'ＬＢＴ使用チャネルの設定
        Private Declare Function MRS_RDCTL_EX_SetChannel_CRS Lib "RDCTL.dll" ( _
                    ByVal CommNo As Integer, _
                    ByVal CarrierSense2 As ECarrier, _
                    ByVal CarrierSense3 As ECarrier, _
                    ByVal CarrierSense4 As ECarrier, _
                    ByVal CarrierSense5 As ECarrier, _
                    ByVal CarrierSense6 As ECarrier, _
                    ByVal CarrierSense7 As ECarrier, _
                    ByVal CarrierSense8 As ECarrier, _
                    ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As EErrorCode
        ' ステータスの取得
        Private Declare Function MRS_RDCTL_EX_GetStatus_CRS Lib "RDCTL.dll" ( _
                            ByVal CommNo As Integer, _
                            ByRef Status As EStatus, _
                            ByRef ErrorInfo As MRS_RDCTL_ERROR_INFO) As EErrorCode
        Private _ErrorInfo As MRS_RDCTL_ERROR_INFO
        Public Property ErrorInfo() As MRS_RDCTL_ERROR_INFO Implements MelRFID.ErrorInfo
            Get
                Return _ErrorInfo
            End Get
            Set(ByVal value As MRS_RDCTL_ERROR_INFO)
                _ErrorInfo = value
            End Set
        End Property
        Public Function SetTagID(ByVal Address As String, ByVal TagID As String, ByVal WriteTagID As String) As EErrorCode Implements MelRFID.SetTagID
            Dim commNo As Integer = CInt(Address.ToString.Substring(3))
            Return CType(MRS_RDCTL_EX_SetTagID_CRS(commNo, TagID, WriteTagID, Me._ErrorInfo), EErrorCode)
        End Function

        Public Function InventoryTags(ByVal Address As String, ByVal RdctlAfiInfo As MRS_RDCTL_AFI_INFO, ByVal RdctlIdMethod As Integer, ByVal NumberOfTags As Integer, ByRef BufferInfo As MRS_RDCTL_BUFFER_INFO, ByRef NumberOfTagsFound As Integer, ByRef NumberOfTagsReturned As Integer) As EErrorCode Implements MelRFID.InventoryTags
            Dim commNo As Integer = CInt(Address.ToString.Substring(3))
            Return CType(MRS_RDCTL_InventoryTags_CRS(commNo, RdctlAfiInfo, RdctlIdMethod, NumberOfTags, BufferInfo, NumberOfTagsFound, NumberOfTagsReturned, Me._ErrorInfo), EErrorCode)
        End Function

        Public Function SetAntennaPort(ByVal Address As String, ByVal AntennaPort As Integer) As EErrorCode Implements MelRFID.SetAntennaPort
            Dim commNo As Integer = CInt(Address.ToString.Substring(3))
            Return CType(MRS_RDCTL_EX_SetAntennaPort_CRS(commNo, AntennaPort, Me._ErrorInfo), EErrorCode)
        End Function

        Public Function SetPower(ByVal Address As String, ByVal Power As EPower) As EErrorCode Implements MelRFID.SetPower
            Dim commNo As Integer = CInt(Address.ToString.Substring(3))
            Return CType(MRS_RDCTL_SetPower_CRS(commNo, Power, Me._ErrorInfo), EErrorCode)
        End Function
        Public Function SetChannel(ByVal Address As String, ByVal CarrierSense2 As Boolean, ByVal CarrierSense3 As Boolean, ByVal CarrierSense4 As Boolean, ByVal CarrierSense5 As Boolean, ByVal CarrierSense6 As Boolean, ByVal CarrierSense7 As Boolean, ByVal CarrierSense8 As Boolean) As EErrorCode Implements MelRFID.SetChannel
            Dim cs2, cs3, cs4, cs5, cs6, cs7, cs8 As ECarrier
            If CarrierSense2 Then cs2 = ECarrier.CARRIIERSENSE_ON Else cs2 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense3 Then cs3 = ECarrier.CARRIIERSENSE_ON Else cs3 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense4 Then cs4 = ECarrier.CARRIIERSENSE_ON Else cs4 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense5 Then cs5 = ECarrier.CARRIIERSENSE_ON Else cs5 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense6 Then cs6 = ECarrier.CARRIIERSENSE_ON Else cs6 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense7 Then cs7 = ECarrier.CARRIIERSENSE_ON Else cs7 = ECarrier.CARRIIERSENSE_OFF
            If CarrierSense8 Then cs8 = ECarrier.CARRIIERSENSE_ON Else cs8 = ECarrier.CARRIIERSENSE_OFF
            Dim commNo As Integer = CInt(Address.ToString.Substring(3))
            Return CType(MRS_RDCTL_EX_SetChannel_CRS(commNo, cs2, cs3, cs4, cs5, cs6, cs7, cs8, Me._ErrorInfo), EErrorCode)
        End Function

        Public Function GetStatus(ByVal Address As String, ByRef Status As EStatus) As EErrorCode Implements MelRFID.GetStatus
            Dim commNo As Integer = CInt(Address.ToString.Substring(3))
            Return CType(MRS_RDCTL_EX_GetStatus_CRS(commNo, Status, Me._ErrorInfo), EErrorCode)
        End Function
    End Class
#End Region

#Region "外部クラス定義"
    Public Class MelRFIDException
        Inherits Exception

        Public Sub New(ByVal ErrorInfo As MRS_RDCTL_ERROR_INFO)
            MyBase.New(ErrorInfo.ErrorCode.ToString)
            _errorInfo = ErrorInfo
        End Sub

        Sub New(ByVal Message As String)
            MyBase.New(Message)
        End Sub
        Private _errorInfo As MRS_RDCTL_ERROR_INFO
        Public Property ErrorInfo() As MRS_RDCTL_ERROR_INFO
            Get
                Return _errorInfo
            End Get
            Set(ByVal value As MRS_RDCTL_ERROR_INFO)
                _errorInfo = value
            End Set
        End Property

    End Class

#End Region

#Region "内部変数定義"
    Private _MelRFID As MelRFID = Nothing
#End Region

#Region "プロパティ"


    Private _address As String = "COM1"
    ''' <summary>
    ''' リーダとの通信方法アドレスを示す文字列
    ''' リーダ・ライタのＩＰアドレスまたはＣＯＭ１などのポート名を指定します
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
            '最初にCOMという文字列があり、COMを除いた文字列が、数値か？
            If value.ToUpper.IndexOf("COM") = 0 AndAlso IsNumeric(value.Substring(3)) Then
                '２３２Ｃインタフェース
                Me._MelRFID = New CRS
            Else
                'その他はＬＡＮインタフェース
                Me._MelRFID = New CLAN
            End If
        End Set
    End Property


    Private _antennaPort As Integer = 1
    ''' <summary>
    ''' 利用アンテナのポート番号（1～４）
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AntennaPort() As Integer
        Get
            Return _antennaPort
        End Get
        Set(ByVal value As Integer)
            Dim RetErrCode As EErrorCode = Me._MelRFID.SetAntennaPort(Me._address, value)
            If RetErrCode = EErrorCode.ERROR_SUCCESS Then
                'アンテナポートが設定できたら変更する
                Me._antennaPort = value
            Else
                'エラーを発生させる
                Dim ex As New MelRFIDException(Me._MelRFID.ErrorInfo)
                Throw ex
            End If
        End Set
    End Property

    Private _SystemAreaSafe As Boolean = True
    ''' <summary>
    ''' システム領域を保護するフラグ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SystemAreaSafe() As Boolean
        Get
            Return _SystemAreaSafe
        End Get
        Set(ByVal value As Boolean)
            _SystemAreaSafe = value
        End Set
    End Property

#End Region

#Region "内部メソッド"

    ''' <summary>
    ''' オペレーティングフィールド内にあるRFIDタグを識別します
    ''' </summary>
    ''' <param name="IdentifyMethod">識別メソッド</param>
    ''' <param name="NumberOfTagsFound">タグ認識数</param>
    ''' <param name="NumberOfTagsReturned">タグID読出数</param>
    ''' <param name="NumberOfTags">タグ読み出し件数指定</param>
    ''' <returns>読み出したタグのクラス</returns>
    ''' <remarks></remarks>
    Private Function GetTagIDs(ByVal IdentifyMethod As EIdentifyMethod, ByRef NumberOfTagsFound As Integer _
                                , ByRef NumberOfTagsReturned As Integer, Optional ByVal NumberOfTags As Integer = 200) As List(Of TagID)

        Dim RdctlAfiInfo As MRS_RDCTL_AFI_INFO
        Dim BufferInfo As MRS_RDCTL_BUFFER_INFO
        Dim tmp As String()
        Dim TagIDs As New List(Of TagID)

        '識別対象ファミリを設定
        RdctlAfiInfo.ApplicationFamily = MRS_RDCTL_AFI_INFO.EApplicationFamily.ApplicationFamily_ALL
        RdctlAfiInfo.ApplicationSubFamily = MRS_RDCTL_AFI_INFO.EApplicationSubFamily.ApplicationSubFamily_ALL

        'バッファ確保
        BufferInfo.Buffer = Marshal.AllocCoTaskMem(29 * NumberOfTags + 1)
        BufferInfo.BufferSize = 29 * NumberOfTags + 1

        Dim RetErrCode As EErrorCode = Me._MelRFID.InventoryTags(Me._address, RdctlAfiInfo, IdentifyMethod, NumberOfTags, _
                                                            BufferInfo, NumberOfTagsFound, NumberOfTagsReturned)

        If RetErrCode = EErrorCode.ERROR_SUCCESS Then
            'タグIDの取り出し　NULL[chr(0]のデータを区切る
            tmp = Split(Marshal.PtrToStringAnsi(BufferInfo.Buffer, BufferInfo.WriteSize), Chr(0))
            '[データ][nohing][データ][nothing][データ][nothing][nothing]とデータが入り、必ずゴミ配列が２つ入るのでリサイズ
            ReDim Preserve tmp(NumberOfTagsReturned - 1)
            For i As Integer = 0 To tmp.Length - 1
                Dim id As New TagID(2, 12)
                id.HexString = tmp(i)
                TagIDs.Add(id)
            Next
            'バッファ開放
            Marshal.FreeCoTaskMem(BufferInfo.Buffer)
        Else
            'バッファ開放
            Marshal.FreeCoTaskMem(BufferInfo.Buffer)
            'エラーを発生させる
            Dim ex As New MelRFIDException(Me._MelRFID.ErrorInfo)
            Throw ex
        End If

        Return TagIDs

    End Function
#End Region

#Region "外部メソッド"
    ''' <summary>
    ''' すべてのタグを識別します
    ''' </summary>
    ''' <param name="NumberOfTagsFound">タグ認識数</param>
    ''' <param name="NumberOfTagsReturned">タグID読出数</param>
    ''' <returns>読み出したタグのクラス</returns>
    ''' <remarks></remarks>
    Public Function GetTagIDs_All(Optional ByRef NumberOfTagsFound As Integer = Nothing, Optional ByRef NumberOfTagsReturned As Integer = Nothing) As List(Of TagID)
        Return GetTagIDs(EIdentifyMethod.IDENTIFY_ALL, NumberOfTagsFound, NumberOfTagsReturned)
    End Function
    ''' <summary>
    ''' 認識したタグ数が、NumberOfTagsに達したら終了します
    ''' </summary>
    ''' <param name="NumberOfTagsFound">タグ認識数</param>
    ''' <param name="NumberOfTagsReturned">タグID読出数</param>
    ''' <returns>読み出しタグリスト</returns>
    ''' <remarks></remarks>
    Public Function GetTagIDs_AtLeast(ByVal NumberOfTags As Integer, Optional ByRef NumberOfTagsFound As Integer = Nothing, Optional ByRef NumberOfTagsReturned As Integer = Nothing) As List(Of TagID)
        Return GetTagIDs(EIdentifyMethod.IDENTIFY_AT_LEAST, NumberOfTagsFound, NumberOfTagsReturned, NumberOfTags)
    End Function
    ''' <summary>
    ''' 認識したタグ数が、NumberOfTagsに達するか、フィールド内のすべてのタグを識別したら終了します
    ''' </summary>
    ''' <param name="NumberOfTagsFound">タグ認識数</param>
    ''' <param name="NumberOfTagsReturned">タグID読出数</param>
    ''' <returns>読み出しタグリスト</returns>
    ''' <remarks></remarks>
    Public Function GetTagIDs_NoMoreThan(ByVal NumberOfTags As Integer, Optional ByRef NumberOfTagsFound As Integer = Nothing, Optional ByRef NumberOfTagsReturned As Integer = Nothing) As List(Of TagID) Implements 共通.IRFIDリーダライタ.GetTagIDs_NoMoreThan
        Return GetTagIDs(EIdentifyMethod.IDENTIFY_NO_MORE_THAN, NumberOfTagsFound, NumberOfTagsReturned, NumberOfTags)
    End Function
    ''' <summary>
    ''' 認識したタグ数が、NumberOfTagsに達したら終了します
    ''' tadasi,
    ''' フィールド内にあるタグ数がわかっていること
    ''' </summary>
    ''' <param name="NumberOfTagsFound">タグ認識数</param>
    ''' <param name="NumberOfTagsReturned">タグID読出数</param>
    ''' <returns>読み出しタグリスト</returns>
    ''' <remarks></remarks>
    Public Function GetTagIDs_Exactly(ByVal NumberOfTags As Integer, Optional ByRef NumberOfTagsFound As Integer = Nothing, Optional ByRef NumberOfTagsReturned As Integer = Nothing) As List(Of TagID)
        Return GetTagIDs(EIdentifyMethod.IDENTIFY_EXACTLY, NumberOfTagsFound, NumberOfTagsReturned, NumberOfTags)
    End Function
    ''' <summary>
    ''' タグIDを変更する
    ''' </summary>
    ''' <param name="TargetTagID">書き換え対象のタグID</param>
    ''' <param name="HexString">書き換え後の１６進文字列タグID</param>
    ''' <remarks></remarks>
    Public Sub WriteTagID(ByVal TargetTagID As TagID, ByVal HexString As String)
        Dim writeTag As New MelTag(HexString)

        'システム領域は書き換えない（元のデータをコピー）
        If Me._SystemAreaSafe Then
            For i As Integer = 0 To TargetTagID.SystemArea.Size - 1
                writeTag.ID.SystemArea.Binary(i) = TargetTagID.SystemArea.Binary(i)
            Next
        End If
        Dim RetErrCode As EErrorCode = Me._MelRFID.SetTagID(Me._address, TargetTagID.HexString, writeTag.ID.HexString)
        If RetErrCode <> EErrorCode.ERROR_SUCCESS Then
            'エラーを発生させる
            Dim ex As New MelRFIDException(Me._MelRFID.ErrorInfo)
            Throw ex
        End If
    End Sub

    ''' <summary>
    ''' タグIDを変更する
    ''' </summary>
    ''' <param name="TargetTagID">書き換え対象のタグID</param>
    ''' <param name="Binary">書き換え後のタグID</param>
    ''' <remarks></remarks>
    Public Sub WriteTagID(ByVal TargetTagID As TagID, ByVal Binary As Byte())
        Dim writeTag As New MelTag(Binary)

        If Me._SystemAreaSafe Then
            'システム領域は書き換えない
            If Me._SystemAreaSafe Then
                For i As Integer = 0 To TargetTagID.SystemArea.Size - 1
                    writeTag.ID.SystemArea.Binary(i) = TargetTagID.SystemArea.Binary(i)
                Next
            End If
        End If
        Dim RetErrCode As EErrorCode = Me._MelRFID.SetTagID(Me._address, TargetTagID.HexString, writeTag.ID.HexString)
        If RetErrCode <> EErrorCode.ERROR_SUCCESS Then
            'エラーを発生させる
            Dim ex As New MelRFIDException(Me._MelRFID.ErrorInfo)
            Throw ex
        End If
    End Sub

    ''' <summary>
    ''' ユーザ領域のタグIDを変更する
    ''' </summary>
    ''' <param name="TargetTagID">書き換え対象のタグID</param>
    ''' <param name="HexString">書き換え後の１６進文字列タグID</param>
    ''' <remarks></remarks>
    Public Sub WriteUserTagID(ByVal TargetTagID As TagID, ByVal HexString As String)
        Dim writeTag As New MelTag()

        'システム領域は書き換えない
        For i As Integer = 0 To TargetTagID.SystemArea.Size - 1
            writeTag.ID.SystemArea.Binary(i) = TargetTagID.SystemArea.Binary(i)
        Next
        'データを変更
        writeTag.ID.UserArea.HexString = HexString
        Dim RetErrCode As EErrorCode = Me._MelRFID.SetTagID(Me._address, TargetTagID.HexString, writeTag.ID.HexString)
        If RetErrCode <> EErrorCode.ERROR_SUCCESS Then
            'エラーを発生させる
            Dim ex As New MelRFIDException(Me._MelRFID.ErrorInfo)
            Throw ex
        End If
    End Sub

    ''' <summary>
    ''' ユーザ領域のタグIDを変更する
    ''' </summary>
    ''' <param name="TargetTagID">書き換え対象のタグID</param>
    ''' <param name="Binary">書き換え後のタグID</param>
    ''' <remarks></remarks>
    Public Sub WriteUserTagID(ByVal TargetTagID As TagID, ByVal Binary As Byte()) Implements 共通.IRFIDリーダライタ.WriteUserTagID
        Dim writeTag As New MelTag()

        'システム領域は書き換えない
        For i As Integer = 0 To TargetTagID.SystemArea.Size - 1
            writeTag.ID.SystemArea.Binary(i) = TargetTagID.SystemArea.Binary(i)
        Next
        'データを変更（コピー）
        Array.Copy(Binary, writeTag.ID.UserArea.Binary, Binary.Length)
        Dim RetErrCode As EErrorCode = Me._MelRFID.SetTagID(Me._address, TargetTagID.HexString, writeTag.ID.HexString)
        If RetErrCode <> EErrorCode.ERROR_SUCCESS Then
            'エラーを発生させる
            Dim ex As New MelRFIDException(Me._MelRFID.ErrorInfo)
            Throw ex
        End If
    End Sub

    ''' <summary>
    ''' 送信電力値設定
    ''' </summary>
    ''' <param name="Power">送信電力値</param>
    ''' <remarks></remarks>
    Public Sub SetPower(ByVal Power As EPower)
        Dim RetErrCode As EErrorCode = Me._MelRFID.SetPower(Me._address, Power)
        If RetErrCode <> EErrorCode.ERROR_SUCCESS Then
            'エラーを発生させる
            Dim ex As New MelRFIDException(Me._MelRFID.ErrorInfo)
            Throw ex
        End If
    End Sub
    ''' <summary>
    ''' リーダ・ライタ装置のＬＢＴ使用チャネルの設定を行う
    ''' </summary>
    ''' <param name="CarrierSense2">２チャネルをキャリアセンスの対象とするか</param>
    ''' <param name="CarrierSense3">３チャネルをキャリアセンスの対象とするか</param>
    ''' <param name="CarrierSense4">４チャネルをキャリアセンスの対象とするか</param>
    ''' <param name="CarrierSense5">５チャネルをキャリアセンスの対象とするか</param>
    ''' <param name="CarrierSense6">６チャネルをキャリアセンスの対象とするか</param>
    ''' <param name="CarrierSense7">７チャネルをキャリアセンスの対象とするか</param>
    ''' <param name="CarrierSense8">８チャネルをキャリアセンスの対象とするか</param>
    ''' <remarks></remarks>
    Public Sub SetCarrierSense(ByVal CarrierSense2 As Boolean, ByVal CarrierSense3 As Boolean, ByVal CarrierSense4 As Boolean, _
                        ByVal CarrierSense5 As Boolean, ByVal CarrierSense6 As Boolean, ByVal CarrierSense7 As Boolean, ByVal CarrierSense8 As Boolean)
        Dim RetErrCode As EErrorCode = Me._MelRFID.SetChannel(Me._address, CarrierSense2, CarrierSense3, CarrierSense4, CarrierSense5, CarrierSense6, CarrierSense7, CarrierSense8)
        If RetErrCode <> EErrorCode.ERROR_SUCCESS Then
            'エラーを発生させる
            Dim ex As New MelRFIDException(Me._MelRFID.ErrorInfo)
            Throw ex
        End If
    End Sub
    Public Sub GetStatus(ByRef Status As EStatus)
        Dim RetErrCode As EErrorCode = Me._MelRFID.GetStatus(Me._address, Status)
        If RetErrCode <> EErrorCode.ERROR_SUCCESS Then
            'エラーを発生させる
            Dim ex As New MelRFIDException(Me._MelRFID.ErrorInfo)
            Throw ex
        End If
    End Sub

#End Region

End Class
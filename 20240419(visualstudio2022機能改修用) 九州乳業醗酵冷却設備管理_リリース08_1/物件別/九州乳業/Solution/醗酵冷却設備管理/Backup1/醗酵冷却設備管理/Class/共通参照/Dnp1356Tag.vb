Imports System.Text
Imports System.runtime.InteropServices


Public Class Dnp1356Tag
    Inherits Tag
    Private Const SYSTEM_AREA_SIZE As Integer = 8
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

''' <summary>
''' ＤＮＰ製ＨＲＷ－ＤＳＵ０１リーダ、ライタ処理
''' </summary>
''' <remarks></remarks>
Public Class CHRW_DSU01
    '定数
    '他の定数値はRX5300DLL.hをご参照ください。
    Private Const MAX_IDENT As Integer = 4          '最大認識タグ数
    Private Const TAGID_LEN As Integer = 16         'タグUIDレングス
    Private Const TAGDATA As Integer = 2048         'タグ書込みデータ数
    Private Const COMAND_SND_DATA As Integer = 35   'コマンド送信データ
    Private Const COMAND_RCV_DATA As Integer = 35   'コマンド受信データ
    Private Const DLL_NAME As String = "RX5300DLL.dll" 'DLL名
    'ブザー用
    Private Const OF_BUZZER As Integer = 0          'ブザーを鳴らさない
    Private Const ON_BUZZER As Integer = 1          'ブザーを鳴す
    'LOOP用
    Private Const STOP_LOOP As Integer = 1          'ループ制御用(初期値設定用)
    Private Const OF_LOOP As Integer = 0            'ループ指定用(ループしない
    Private Const ON_LOOP As Integer = 1            'ループ指定用(ループする


    'エラーメッセージ定義
    'エラー値はRX5300DLL.hをご参照下さい。
    Private Shared ErrMsg() As String = { _
                                        "正常終了しました", _
                                        "受信バイト数異状", _
                                        "ブロック数異状", _
                                        "アドレスブロック数異状", _
                                        "LOOP設定異状", _
                                        "コマンド異状", _
                                        "コマンドパラメータ異状", _
                                        "CRLFが認識できない", _
                                        "外部通信受信異状", _
                                        "Inventory実行エラー", _
                                        "コマンド実行エラー", _
                                        "認識タグ２個以上", _
                                        "", _
                                        "", _
                                        "TAGコマンド実行エラー", _
                                        "レスポンス・フラグエラー", _
                                        "接続エラー", _
                                        "コマンド送信失敗", _
                                        "コマンド受信失敗", _
                                        "シリアル番号取得失敗", _
                                        "タグリード取得失敗", _
                                        "タグライト取得失敗", _
                                        "UID取得失敗", _
                                        "タグコマンド実行失敗", _
                                        "ブザーコマンド失敗", _
                                        "センサコマンド失敗", _
                                        "リードコンフィグ失敗", _
                                        "ループスタート失敗", _
                                        "タイムアウト受信エラー", _
                                        "パラメータエラー", _
                                        "その他エラー", _
                                        "タグタイプチェックエラー" _
                                       }

    ''' <summary>
    ''' USB情報構造体
    '''  送信タイムアウト値
    '''  受信タイムアウト値
    '''  シリアル番号
    '''  USBハンドル
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_USB_INFO
        Public iSndTime As UInt32
        Public iRcvTime As UInt32
        <MarshalAs(UnmanagedType.LPStr)> _
        Public buf As String
        Public pHandle As System.IntPtr
    End Structure


    ''' <summary>
    ''' タグ情報構造体
    '''  タグID
    '''  タグ情報
    ''' </summary>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Private Structure tag_TAGINFO
        Public iTagStatus As UInt32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=TAGID_LEN + 1)> _
        Public chaTagId As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=TAGDATA + 1)> _
        Public chaTagData As String
    End Structure


    ''' <summary>
    ''' [IN]TAGコマンド用構造体
    '''  TAGコマンド送信データ
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_IN_TA
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=COMAND_SND_DATA + 1)> _
        Public saCmdData As String
    End Structure
    ''' <summary>
    ''' [OUT]TAGコマンド用構造体
    '''  TAGコマンド受信データ
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_OUT_TA
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=COMAND_RCV_DATA + 1)> _
        Public saRcvData As String
    End Structure


    ''' <summary>
    ''' [OUT]OUT_GU用構造体
    '''  取得タグ数
    '''  タグ情報構造体配列[MAX_IDENT]
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_OUT_GU
        Public byTagIdNum As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_IDENT)> _
        Public s_TAGINFO() As tag_TAGINFO
    End Structure

    ''' <summary>
    ''' [IN]タグ情報読取り用構造体
    '''  読取開始アドレス
    '''  読取ブロック数
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_IN_MR
        Public byStartAddr As Byte
        Public byReadLeng As Byte
    End Structure
    ''' <summary>
    ''' [OUT]タグ情報読取り用構造体
    '''  取得タグ数
    '''  読込み成功タグ数
    '''  タグ情報構造体配列[MAX_IDENT]
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_OUT_MR
        Public byTagIdNum As Byte
        Public byTagReadNum As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_IDENT)> _
        Public s_TAGINFO() As tag_TAGINFO
    End Structure

    ''' <summary>
    ''' [IN]タグ書込み用構造体
    '''  読取開始アドレス
    '''  読取ブロック数
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_IN_MW
        Public byStartAddr As Byte
        Public byReadLeng As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_IDENT)> _
        Public s_TAGINFO() As tag_TAGINFO
    End Structure
    ''' <summary>
    ''' [OUT]タグ情報書込み用構造体
    '''  取得タグ数
    '''  読込み成功タグ数
    '''  タグ情報構造体配列[MAX_IDENT]
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_OUT_MW
        Public byTagIdNum As Byte
        Public byTagWriteNum As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_IDENT)> _
        Public s_TAGINFO() As tag_TAGINFO
    End Structure

    ''' <summary>
    ''' ブザー情報用コマンド
    '''  ブザーフラグ　ON_BUZZER/OF_BUZZER
    '''  ブザーを鳴らす時間(0x0～0xF)
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_BUZZER
        Public byBuzzerFlg As Byte
        Public byTime As Byte
    End Structure

    ''' <summary>
    ''' ループ設定構造体
    '''  ループフラグ　ON_LOOP/OF_LOOP
    '''  ループ制御フラグ　初期値としてSTOP_LOOPを設定してください(DLL内部用)
    '''  ループステータス　現在ループしている種別です(値はRX5300DLL.h参照)
    '''  ループハンドル　　メッセージ送出先 画面ハンドル
    '''  ループハンドル　　(DLL内部用)　
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_LOOP
        Public byLoopFlg As Byte
        Public byLoopCtrlFlg As Byte
        Public byLoopStatus As Byte
        Public hw As System.IntPtr
        Public hTh As System.IntPtr
    End Structure

    ''' <summary>
    ''' プロパティ構造体
    '''  この構造体を各関数を呼び出す為の引数とします。
    '''  RX_Init_PROPERTY関数でこの構造体を初期化することが出来ます。
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_PROPERTY
        Public s_USB_INFO As tag_USB_INFO
        Public s_BUZZER As tag_BUZZER
        Public s_LOOP As tag_LOOP
        Public s_IN_MR As tag_IN_MR
        Public s_IN_MW As tag_IN_MW
        Public s_IN_TA As tag_IN_TA
        Public s_OUT_GU As tag_OUT_GU
        Public s_OUT_MR As tag_OUT_MR
        Public s_OUT_MW As tag_OUT_MW
        Public s_OUT_TA As tag_OUT_TA
    End Structure

    ''' <summary>
    ''' PROPERTY構造体の初期化を行います
    ''' </summary>
    ''' <param name="s_PROPERTY">[in]関数属性構造体</param>
    Private Declare Function RX_Init_PROPERTY Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer


    ''' <summary>
    ''' USBシリアル番号を取得します
    ''' </summary>
    ''' <param name="lpBuf">[out]取得したシリアル番号</param>
    Private Declare Function RX_GetSerialNo Lib "RX5300DLL.dll" (ByVal lpBuf As StringBuilder) As Integer

    ''' <summary>
    ''' USBをオープンします
    ''' </summary>
    ''' <param name="s_USB_INFO">USB情報構造体</param>
    Private Declare Function RX_OpenUSB Lib "RX5300DLL.dll" (ByRef s_USB_INFO As tag_USB_INFO) As Integer

    ''' <summary>
    ''' USBをクローズします
    ''' </summary>
    ''' <param name="s_USB_INFO">USB情報構造体</param>
    Private Declare Function RX_CloseUSB Lib "RX5300DLL.dll" (ByRef s_USB_INFO As tag_USB_INFO) As Integer

    ''' <summary>
    ''' ブザーを鳴らします
    ''' </summary>
    ''' <param name="s_USB_INFO">USB情報構造体</param>
    ''' <param name="byTime">鳴らす時間(0h～1h)</param>
    Private Declare Function RX_BuzzerCommand Lib "RX5300DLL.dll" (ByRef s_USB_INFO As tag_USB_INFO, ByVal byTime As System.Byte) As Integer

    ''' <summary>
    ''' 最大４枚のUIDを取得します
    ''' </summary>
    ''' <param name="s_PROPERTY"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Declare Function RX_GetUID Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' TAGコマンドの実行
    ''' </summary>
    Private Declare Function RX_TagCommand Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' タグ情報読込み関数
    ''' </summary>
    ''' <param name="s_PROPERTY">[in]関数属性構造体</param>
    Private Declare Function RX_MultiRead Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' タグ情報書込み関数
    ''' </summary>
    ''' <param name="s_PROPERTY">[in]関数属性構造体</param>
    Private Declare Function RX_MultiWrite Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' 実行中のLoopを停止します。
    ''' 呼び出す際はs_PROPERTYの値を新たに変更する必要はありません。
    ''' そのままs_PROPERTYを渡してください
    ''' </summary>
    ''' <param name="s_PROPERTY">[in]関数属性構造体</param>
    Private Declare Function RX_LoopStop Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' エラーメッセージ表示
    ''' </summary>
    ''' <param name="ErrNo">エラー番号</param>
    Public Shared Function showErrMsg(ByVal ErrNo As Integer) As String

        '30以上のコードを取得した場合は"その他エラー"とする。
        If ErrNo > 30 Then
            ErrNo = 29
        End If

        'エラーメッセージを表示します。
        Return ErrMsg(ErrNo)
    End Function

    ''' <summary>
    ''' 制御用構造体
    ''' </summary>
    ''' <remarks></remarks>
    Private _Prop As tag_PROPERTY
    Sub New()
        'USBのシリアル番号を取得する
        Dim buf As StringBuilder = New System.Text.StringBuilder(9)
        Dim ret As Integer
        ret = RX_GetSerialNo(buf)

        RX_Init_PROPERTY(Me._Prop)
        With Me._Prop
            Me.SendTimeput = 1000                   '送信タイムアウト設定
            Me.ReceiveTimeout = 1000                '受信タイムアウト設定
            .s_USB_INFO.buf = buf.ToString()        'シリアル番号
            .s_LOOP.hw = Nothing                    '連続LOOPイベント受信用画面ハンドラ設定
            .s_LOOP.hTh = Nothing                   'NULLで初期化しておいてください
            .s_LOOP.byLoopCtrlFlg = STOP_LOOP       'STOP_LOOPで初期化しておいてください
            Me.BuzzerTime = 2                       'ブザー鳴らす時間
        End With
    End Sub

    ''' <summary>
    ''' 送信タイムアウト
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SendTimeput() As UInteger
        Get
            Return Me._Prop.s_USB_INFO.iSndTime
        End Get
        Set(ByVal value As UInteger)
            Me._Prop.s_USB_INFO.iSndTime = value
        End Set
    End Property

    ''' <summary>
    ''' 受信タイムアウト
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ReceiveTimeout() As UInteger
        Get
            Return Me._Prop.s_USB_INFO.iRcvTime
        End Get
        Set(ByVal value As UInteger)
            Me._Prop.s_USB_INFO.iRcvTime = value
        End Set
    End Property


    ''' <summary>
    ''' ブザーの長さ
    ''' </summary>
    ''' <remarks></remarks>
    Public Property BuzzerTime() As Byte
        Get
            Return Me._Prop.s_BUZZER.byTime
        End Get
        Set(ByVal value As Byte)
            If value > 15 Then
                Throw New Exception("ブザーの長さは1～15で設定してください")
            End If
            Me._Prop.s_BUZZER.byTime = value               'ブザー鳴らす時間
            If value = 0 Then
                Me._Prop.s_BUZZER.byBuzzerFlg = OF_BUZZER      'ブザー設定 
            Else
                Me._Prop.s_BUZZER.byBuzzerFlg = ON_BUZZER      'ブザー設定 
            End If
        End Set
    End Property


    ''' <summary>
    ''' タグIDを読み出す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTagIDs() As List(Of TagID)
        'UID取得関数実行
        Dim ret As Integer = RX_GetUID(Me._Prop)
        Dim tagIds As New List(Of TagID)
        For i As Integer = 0 To Me._Prop.s_OUT_GU.byTagIdNum - 1
            Dim tag As New TagID(8, 0)
            tag.HexString = Me._Prop.s_OUT_GU.s_TAGINFO(0).chaTagId
            tagIds.Add(tag)
        Next

        Return tagIds
    End Function
End Class

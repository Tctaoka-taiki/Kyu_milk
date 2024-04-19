Imports System.Text
Imports System.IO.Ports
Imports System.Windows.Forms.Control

Public Class UCシリアルポート
    Inherits System.IO.Ports.SerialPort

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Private mstrポートID As String = ""
    Private mbln受信状態 As Boolean = False
    Public mstrSEND文字列 As String = ""
    Public mstrRCV文字列 As String = ""
    Private mstrRcvStatus As Integer
    Private RcvData As String = ""
    Private args(0) As Object
    Private args1(0) As Object
    '#####################################################################################
    'プロパティー
    '#####################################################################################
    ''プロパティー-------------------------------------------------------------------
    ''' <summary>
    ''' pポートID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pポートID() As String
        Get
            Return mstrポートID
        End Get
        Set(ByVal Value As String)
            mstrポートID = Value
        End Set
    End Property
    ''' <summary>
    ''' pRcvStatus
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property p受信状態() As Boolean
        Get
            Return mbln受信状態
        End Get
        Set(ByVal Value As Boolean)
            mbln受信状態 = Value
        End Set
    End Property
    ''' <summary>
    ''' pRcvStatus
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pRcvStatus() As String
        Get
            Return mstrRcvStatus
        End Get
        Set(ByVal Value As String)
            mstrRcvStatus = Value
        End Set
    End Property
    ''' <summary>
    ''' pSEND文字列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pSEND文字列() As String
        Get
            Return mstrSEND文字列
        End Get
        Set(ByVal Value As String)
            mstrSEND文字列 = Value
        End Set
    End Property
    ''' <summary>
    ''' pRCV文字列
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pRCV文字列() As String
        Get
            Return mstrRCV文字列
        End Get
        Set(ByVal Value As String)
            mstrRCV文字列 = Value
        End Set
    End Property
    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Sub SerialPortOpenClose()

        If Me.IsOpen = True Then

            'シリアルポートをクローズする.
            Me.Close()

        Else

            '設定ファイルから接続ポートを指定する。
            Me.PortName = CUtil.設定関連.設定文字列読込("シリアル通信用ポート" & mstrポートID, "COM1")

            'ボーレートをセットする. (ボーレート = 9600bps)
            Me.BaudRate = CUtil.設定関連.設定文字列読込("シリアル通信用ボーレート" & mstrポートID, "9600")

            'データビットをセットする. (データビット = 8ビット)
            Me.DataBits = CUtil.設定関連.設定文字列読込("シリアル通信用データビット" & mstrポートID, "8")

            'パリティビットをセットする. (パリティビット = なし)
            Me.Parity = Parity.None

            'ストップビットをセットする. (ストップビット = 1ビット)
            Me.StopBits = StopBits.One

            'フロー制御を設置する.（フロー制御 = なし）
            Me.Handshake = Handshake.None

            '文字コードをセットする.
            Me.Encoding = Encoding.Unicode

            Try
                'シリアルポートをオープンする.
                Me.Open()

            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function blnデータ送信(ByVal 送信内容 As String) As Boolean
        Dim WriteBuff As Byte()
        WriteBuff = _
                 System.Text.Encoding.ASCII.GetBytes(送信内容)

        Try
            '受信状態の初期化
            Me.mbln受信状態 = False

            'シリアルポートからテキストを送信する.
            Me.Write(WriteBuff, 0, WriteBuff.GetLength(0))
            '送信データを入力するテキストボックスをクリアする.

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return True
    End Function
End Class

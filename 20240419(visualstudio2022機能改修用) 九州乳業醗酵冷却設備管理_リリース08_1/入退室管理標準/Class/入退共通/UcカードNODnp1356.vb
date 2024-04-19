Public Class UcカードNODnp1356
    Implements IUserControl
    Implements IEnterキー制御
    '#####################################################################################
    '型
    '#####################################################################################
    Public Const LEN_バイト数 As Integer = 8
    Public Const LEN_バイト文字列数 As Integer = LEN_バイト数 * 2

    '#####################################################################################
    'メンバ変数
    '#####################################################################################

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    Private mIsクリア As Boolean = True
    Public Property Isクリア() As Boolean Implements IUserControl.Isクリア
        Get
            Return mIsクリア
        End Get
        Set(ByVal value As Boolean)
            mIsクリア = value
            TxtカードNo.Isクリア = value
            LblカードNo.Isクリア = value
        End Set
    End Property

    Public ReadOnly Property Is空欄() As Boolean
        Get
            Return (TxtカードNo.TextLength = 0)
        End Get
    End Property
    Public ReadOnly Property Is有効タグID() As Boolean
        Get
            Return (TxtカードNo.TextLength = LEN_バイト文字列数)
        End Get
    End Property

    Public Property カードNO() As String
        Get
            Return TxtカードNo.Text
        End Get
        Set(ByVal value As String)
            TxtカードNo.Text = value
            LblカードNo.Text = value
        End Set
    End Property

    Private mUIモード As enmUIモード = enmUIモード.編集
    Public Property モード() As enmUIモード
        Get
            Return mUIモード
        End Get
        Set(ByVal value As enmUIモード)
            mUIモード = value
            Select Case value
                Case enmUIモード.編集
                    TxtカードNo.Visible = True

                    LblカードNo.Visible = False

                Case enmUIモード.表示
                    TxtカードNo.Visible = False

                    LblカードNo.Visible = True
            End Select
        End Set
    End Property

    Private m再発行UIモード As enmUIモード = enmUIモード.表示
    Public Property 再発行編集モード() As enmUIモード
        Get
            Return m再発行UIモード
        End Get
        Set(ByVal value As enmUIモード)
            m再発行UIモード = value
            Select Case value
                Case enmUIモード.編集
                    TxtカードNo.Visible = True

                    LblカードNo.Visible = False

                Case enmUIモード.表示
                    TxtカードNo.Visible = False

                    LblカードNo.Visible = True
            End Select
        End Set
    End Property

    Private menmCondition As gEnm入力条件 = gEnm入力条件.Nomal
    Public Property pCondition() As gEnm入力条件
        Get
            Return menmCondition
        End Get
        Set(ByVal Value As gEnm入力条件)
            menmCondition = Value
            TxtカードNo.pCondition = Value
        End Set
    End Property

    Private mエラーメッセージ As String = ""
    Public Property pErrText() As String Implements IUserControl.エラー表示用項目名
        Get
            Return mエラーメッセージ
        End Get
        Set(ByVal Value As String)
            mエラーメッセージ = Value
        End Set
    End Property

    Public Property タグIDHexString() As String
        Get
            Return カードNO
        End Get
        Set(ByVal value As String)
            カードNO = value
        End Set
    End Property

    Private mRFIDリーダライタ As IRFIDリーダライタ
    Public Property RFIDリーダライタ() As IRFIDリーダライタ
        Get
            Return mRFIDリーダライタ
        End Get
        Set(ByVal value As IRFIDリーダライタ)
            mRFIDリーダライタ = value
        End Set
    End Property

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
    Private Sub UcカードNO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pCondition = gEnm入力条件.Nomal
        カードNO = ""
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Public Function タグID配列() As Byte()
        If Is有効タグID Then
            Return CUtil.Stringからバイト配列を生成(カードNO)
        Else
            Return Nothing
        End If
    End Function

    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果

        Try
            With Me
                If .pCondition = gEnm入力条件.Hissu Or _
                    (.pCondition <> gEnm入力条件.Hissu And Not .Is空欄) Then
                    With .TxtカードNo
                        If .TextLength <> LEN_バイト文字列数 Then
                            If .エラー表示用項目名 = "" Then
                                Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_桁数不正)
                            Else
                                Call CMsg.gMsg_注意(.エラー表示用項目名 & M定数.MSG_桁数不正)
                            End If
                            入力チェック.ErrorContol = Me.TxtカードNo
                            Return 入力チェック
                        End If
                    End With
                End If
            End With
        Finally
            If Not 入力チェック.ErrorContol Is Nothing And Isエラーフォーカス Then
                入力チェック.ErrorContol.Focus()
            End If
        End Try

        入力チェック.Is正常 = True

    End Function

    Public Function タグ読込表示() As String
        タグ読込表示 = ""

        Try
            With タグ読込のみ()
                If .Count = 1 Then
                    '正常
                    タグ読込表示 = .Item(0).HexString
                    カードNO = タグ読込表示
                ElseIf .Count = 0 Then
                    '読み込み失敗
                    Call CMsg.gMsg_注意("カードが見つかりませんでした")
                ElseIf .Count > 1 Then
                    '複数読み込みはエラーとする。
                End If
            End With
        Catch ex As Exception
            Debug.WriteLine(ex.StackTrace)
            Call CMsg.gMsg_注意("カード読込に失敗しました。")
        End Try
    End Function
    Public Function タグ読込のみ() As List(Of TagID)
        Dim コマンド発行待ち時間 As Integer = CInt(CUtil.設定関連.設定文字列読込("RFID.コマンド発行待ち時間"))
        Dim 再試行回数 As Integer = CInt(CUtil.設定関連.設定文字列読込("RFID.コマンド再試行回数"))
        For i As Integer = 0 To 再試行回数
            System.Threading.Thread.Sleep(コマンド発行待ち時間)
            Try
                Debug.WriteLine("タグ読込のみ" & (i + 1) & "回目")
                Return RFIDリーダライタ.GetTagIDs()
            Catch ex As Exception
                If i = 再試行回数 Then
                    Throw
                End If
            End Try
        Next
        Return Nothing  '実際は未到達
    End Function

    Public Sub タグ書込()
    End Sub

    Public Sub クリア() Implements IUserControl.クリア
        If Isクリア Then
            TxtカードNo.クリア()
            LblカードNo.クリア()
        End If
    End Sub

    Public Sub カードNOをコピーFrom(ByVal コピー元 As UcカードNODnp1356)
        With コピー元
            カードNO = .カードNO
        End With
    End Sub
End Class

Public Class UcカードNO三菱UHF
    Implements IUserControl
    Implements IEnterキー制御
    '#####################################################################################
    '型
    '#####################################################################################
    Public Const LEN_中央部1 As Integer = 1
    Public Const LEN_中央部2 As Integer = 5
    Public Const LEN_右部 As Integer = 6

    Private Const 三洋化成PREFIX As String = "3000"


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

    Private mRFIDリーダライタ As IRFIDリーダライタ
    Public Property RFIDリーダライタ() As IRFIDリーダライタ
        Get
            Return mRFIDリーダライタ
        End Get
        Set(ByVal value As IRFIDリーダライタ)
            mRFIDリーダライタ = value
        End Set
    End Property

    Public ReadOnly Property Is空欄() As Boolean
        Get
            Return (TxtカードNo中央部1.TextLength = 0 And TxtカードNo中央部2.TextLength = 0 And TxtカードNo右部.TextLength = 0)
        End Get
    End Property
    Public ReadOnly Property Is有効タグID() As Boolean
        Get
            Return (TxtカードNo中央部1.TextLength = LEN_中央部1 And TxtカードNo中央部2.TextLength = LEN_中央部2 And TxtカードNo右部.TextLength = LEN_右部)
        End Get
    End Property

    Public Property カードNO中央部1() As String
        Get
            Return TxtカードNo中央部1.Text
        End Get
        Set(ByVal value As String)
            TxtカードNo中央部1.Text = value
            LblカードNo中央部1.Text = value
        End Set
    End Property


    Public Property カードNO中央部2() As String
        Get
            Return TxtカードNo中央部2.Text
        End Get
        Set(ByVal value As String)
            TxtカードNo中央部2.Text = value
            LblカードNo中央部2.Text = value
        End Set
    End Property

    Public Property カードNo右部() As String
        Get
            Return TxtカードNo右部.Text
        End Get
        Set(ByVal value As String)
            TxtカードNo右部.Text = value
            LblカードNo右部.Text = value
        End Set
    End Property

    Public ReadOnly Property カードNO() As String
        Get
            If Me.Is有効タグID Then
                Return 三洋化成PREFIX & "-" & カードNO中央部1 & "-" & カードNO中央部2 & "-" & カードNo右部
            Else
                Return 三洋化成PREFIX & "-X-XXXXX-XXXXXX"
            End If
        End Get
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
                    TxtカードNo中央部2.Visible = True
                    TxtカードNo右部.Visible = True

                    LblカードNo中央部2.Visible = False
                    LblカードNo右部.Visible = False

                Case enmUIモード.表示
                    TxtカードNo中央部2.Visible = False
                    TxtカードNo右部.Visible = False

                    LblカードNo中央部2.Visible = True
                    LblカードNo右部.Visible = True
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
                    TxtカードNo中央部1.Visible = True

                    LblカードNo中央部1.Visible = False

                Case enmUIモード.表示
                    TxtカードNo中央部1.Visible = False

                    LblカードNo中央部1.Visible = True
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
            TxtカードNo中央部1.pCondition = Value
            TxtカードNo中央部2.pCondition = Value
            TxtカードNo右部.pCondition = Value
        End Set
    End Property

    Public Property タグIDHexString() As String
        Get
            If Me.Is有効タグID Then
                Return 三洋化成PREFIX & CUtil.バイト配列ToHexString(System.Text.ASCIIEncoding.ASCII.GetBytes(カードNO中央部1 & カードNO中央部2 & カードNo右部))
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            Try
                Dim t As New MelTag
                t.ID.HexString = value
                Dim ユーザエリア As Byte() = t.ID.UserArea.Binary
                カードNO中央部1 = System.Text.ASCIIEncoding.ASCII.GetString(ユーザエリア, 0, LEN_中央部1)
                カードNO中央部2 = System.Text.ASCIIEncoding.ASCII.GetString(ユーザエリア, LEN_中央部1, LEN_中央部2)
                カードNo右部 = System.Text.ASCIIEncoding.ASCII.GetString(ユーザエリア, LEN_中央部1 + LEN_中央部2, LEN_右部)
            Catch ex As Exception
                Debug.WriteLine(ex.StackTrace)
            End Try
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
        カードNO中央部1 = ""
        カードNO中央部2 = ""
        カードNo右部 = ""
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果

        Try
            With Me
                If .pCondition = gEnm入力条件.Hissu Or _
                    (.pCondition <> gEnm入力条件.Hissu And Not .Is空欄) Then
                    With .TxtカードNo中央部1
                        If .TextLength <> LEN_中央部1 Then
                            If .エラー表示用項目名 = "" Then
                                Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_桁数不正)
                            Else
                                Call CMsg.gMsg_注意(.エラー表示用項目名 & M定数.MSG_桁数不正)
                            End If
                            入力チェック.ErrorContol = Me.TxtカードNo中央部1
                            Return 入力チェック
                        End If
                    End With

                    With .TxtカードNo中央部2
                        If .TextLength <> LEN_中央部2 Then
                            If .エラー表示用項目名 = "" Then
                                Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_桁数不正)
                            Else
                                Call CMsg.gMsg_注意(.エラー表示用項目名 & M定数.MSG_桁数不正)
                            End If
                            入力チェック.ErrorContol = Me.TxtカードNo中央部2
                            Return 入力チェック
                        End If
                    End With

                    With .TxtカードNo右部
                        If .TextLength <> LEN_右部 Then
                            If .エラー表示用項目名 = "" Then
                                Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_桁数不正)
                            Else
                                Call CMsg.gMsg_注意(.エラー表示用項目名 & M定数.MSG_桁数不正)
                            End If
                            入力チェック.ErrorContol = Me.TxtカードNo右部
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

    Public Sub クリア() Implements IUserControl.クリア
        If Isクリア Then
            TxtカードNo右部.クリア()
            TxtカードNo中央部1.クリア()
            TxtカードNo中央部2.クリア()
        End If
    End Sub

    Private Function タグIDユーザエリア配列() As Byte()
        If Is有効タグID Then
            '書込テスト
            Dim 書込文字列 As String = TxtカードNo中央部1.Text & TxtカードNo中央部2.Text & TxtカードNo右部.Text
            Dim ユーザエリアバイト長 As Integer = System.Text.ASCIIEncoding.ASCII.GetByteCount(書込文字列.ToCharArray())
            Dim 書込バイト配列 As Byte() = New Byte(ユーザエリアバイト長 - 1) {}
            Dim bytesEncodedCount As Integer = System.Text.ASCIIEncoding.ASCII.GetBytes(書込文字列, 0, ユーザエリアバイト長, 書込バイト配列, 0)
            Return 書込バイト配列
        Else
            Return Nothing
        End If
    End Function

    Public Function タグID配列() As Byte()
        If Is有効タグID Then
            '書込テスト
            Dim 書込文字列 As String = TxtカードNo中央部1.Text & TxtカードNo中央部2.Text & TxtカードNo右部.Text
            Dim ユーザエリアバイト長 As Integer = System.Text.ASCIIEncoding.ASCII.GetByteCount(書込文字列.ToCharArray())
            Dim 書込バイト配列 As Byte() = New Byte(2 + ユーザエリアバイト長 - 1) {}
            書込バイト配列(0) = &H30
            書込バイト配列(1) = &H0
            Dim bytesEncodedCount As Integer = System.Text.ASCIIEncoding.ASCII.GetBytes(書込文字列, 0, ユーザエリアバイト長, 書込バイト配列, 2)
            Return 書込バイト配列
        Else
            Return Nothing
        End If
    End Function

    Public Function タグ読込表示() As String
        タグ読込表示 = ""

        Try
            With タグ読込のみ()
                If .Count = 1 Then
                    '正常
                    タグ読込表示 = .Item(0).UserArea.HexString
                    Dim str As String = System.Text.ASCIIEncoding.ASCII.GetString(.Item(0).UserArea.Binary)
                    カードNO中央部1 = str.Substring(0, LEN_中央部1)
                    カードNO中央部2 = str.Substring(1, LEN_中央部2)
                    カードNo右部 = str.Substring(LEN_中央部1 + LEN_中央部2, LEN_右部)
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

    Public Function タグ読込および値セット() As List(Of TagID)
        Try
            タグ読込および値セット = タグ読込のみ()
            With タグ読込および値セット
                If .Count = 1 Then
                    '正常
                    Dim str As String = System.Text.ASCIIEncoding.ASCII.GetString(.Item(0).UserArea.Binary)
                    カードNO中央部1 = str.Substring(0, LEN_中央部1)
                    カードNO中央部2 = str.Substring(1, LEN_中央部2)
                    カードNo右部 = str.Substring(LEN_中央部1 + LEN_中央部2, LEN_右部)
                ElseIf .Count = 0 Then
                    '読み込み失敗
                    Call CMsg.gMsg_注意("カードが見つかりませんでした")
                ElseIf .Count > 1 Then
                    '複数読み込みはエラーとする。
                End If
            End With
        Catch ex As Exception
            タグ読込および値セット = New List(Of TagID)
            Debug.WriteLine(ex.StackTrace)
            Call CMsg.gMsg_注意("カード読込に失敗しました。")
        End Try
    End Function

    Public Function タグ読込のみ() As List(Of TagID)
        'Dim ctl As New MelUHFTag
        'ctl.Address = MFile.gStrParameterStr("アンテナアドレス")
        'ctl.AntennaPort = CInt(MFile.gStrParameterStr("アンテナポート"))

        Dim コマンド発行待ち時間 As Integer = CInt(CUtil.設定関連.設定文字列読込("RFID.コマンド発行待ち時間"))
        Dim 再試行回数 As Integer = CInt(CUtil.設定関連.設定文字列読込("RFID.コマンド再試行回数"))
        For i As Integer = 0 To 再試行回数
            System.Threading.Thread.Sleep(コマンド発行待ち時間)
            Try
                Debug.WriteLine("タグ読込のみ" & (i + 1) & "回目")
                Return C入退管理.DIコンテナ.GetRFIDリーダライタ.GetTagIDs_NoMoreThan(1)
            Catch ex As Exception
                If i = 再試行回数 Then
                    Throw
                End If
            End Try
        Next
        Return Nothing  '実際は未到達
    End Function

    Public Sub タグ書込()
        'Dim ctl As New MelUHFTag
        'ctl.Address = MFile.gStrParameterStr("アンテナアドレス")
        'ctl.AntennaPort = CInt(MFile.gStrParameterStr("アンテナポート"))

        Dim tagIDs As List(Of TagID) = Nothing
        'Dim tagIDs As List(Of TagID) = ctl.GetTagIDs_NoMoreThan(1)

        With Nothing
            Dim コマンド発行待ち時間 As Integer = CInt(CUtil.設定関連.設定文字列読込("RFID.コマンド発行待ち時間"))
            Dim 再試行回数 As Integer = CInt(CUtil.設定関連.設定文字列読込("RFID.コマンド再試行回数"))
            Dim Is成功 As Boolean = False
            For i As Integer = 0 To 再試行回数
                System.Threading.Thread.Sleep(コマンド発行待ち時間)
                Try
                    Debug.WriteLine("タグ書込.事前読込" & (i + 1) & "回目")
                    tagIDs = RFIDリーダライタ.GetTagIDs_NoMoreThan(1)
                    Is成功 = True
                Catch ex As Exception
                    If i = 再試行回数 Then
                        'Throw New Exception("書込対象カードの書込前読み出し処理に失敗しました。", ex)
                        Throw
                    End If
                End Try
                If Is成功 Then
                    Exit For
                End If
            Next
        End With

        With tagIDs
            If .Count = 1 Then
                '正常
            ElseIf .Count = 0 Then
                '読み込み失敗
                Call CMsg.gMsg_注意("カードが見つかりませんでした")
                Throw New Exception("カードが見つかりませんでした")
            ElseIf .Count > 1 Then
                '複数読み込みはエラーとする。
                Throw New Exception("複数のカードがアンテナエリアに存在するため書込できませんでした。")
            End If
        End With

        'System.Threading.Thread.Sleep(コマンド発行待ち時間)
        'ここではシステムエリアも含めて書込を呼び出す
        '実際には保護機能により、ユーザエリアのみ上書き

        'ctl.WriteTagID(tagIDs(0), Me.タグID配列)
        'ctl.WriteUserTagID(tagIDs(0), Me.タグIDユーザエリア配列)
        With Nothing
            Dim コマンド発行待ち時間 As Integer = CInt(CUtil.設定関連.設定文字列読込("RFID.コマンド発行待ち時間"))
            Dim 書込コマンド発行待ち時間 As Integer = CInt(CUtil.設定関連.設定文字列読込("RFID.書込コマンド発行待ち時間"))
            Dim 再試行回数 As Integer = CInt(CUtil.設定関連.設定文字列読込("RFID.コマンド再試行回数"))
            Dim Is成功 As Boolean = False

            For i As Integer = 0 To 再試行回数
                System.Threading.Thread.Sleep(書込コマンド発行待ち時間)
                Try
                    Debug.WriteLine("タグ書込.書込" & (i + 1) & "回目")
                    C入退管理.DIコンテナ.GetRFIDリーダライタ.WriteUserTagID(tagIDs(0), Me.タグIDユーザエリア配列)
                    Is成功 = True
                Catch ex As Exception
                    If i = 再試行回数 Then
                        'Throw New Exception("書込対象カードの書込前読み出し処理に失敗しました。", ex)
                        Throw
                    End If
                End Try
                If Is成功 Then
                    Exit For
                End If
            Next
        End With
    End Sub

    Public Sub 再発行回数加算()
        Try
            Dim 回数 As Integer = CInt(TxtカードNo中央部1.Text)
            回数 += 1
            If 回数 > 9 Then
                回数 = 0
            End If
            TxtカードNo中央部1.Text = 回数.ToString
        Catch ex As Exception
            '例外発生時はなにもしない
        End Try
    End Sub

    Public Sub カードNOをコピーFrom(ByVal コピー元 As UcカードNO三菱UHF)
        With コピー元
            カードNO中央部1 = .カードNO中央部1
            カードNO中央部2 = .カードNO中央部2
            カードNo右部 = .カードNo右部
        End With
    End Sub
End Class

'*******************************************************************************
' @(h)  UsrTxt.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrTxt                             System.Windows.Forms.TextBoxを継承
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************

Public Class usrTxt
    Inherits System.Windows.Forms.TextBox
    Implements IUserControl
    Implements IEnterキー制御

    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Private mstrID As String = ""
    Private mstrClearValue As String = ""
    Private mIsクリア As Boolean = True

    Private mblnAutoFocus As Boolean = True
    Private mblnAutoSelect As Boolean = True
    Private mintMaxByte As Integer
    Private menmCharType As gEnmCharType = gEnmCharType.All
    Private menmCondition As gEnm入力条件 = gEnm入力条件.Nomal

    Private mblnAutoPad As Boolean = False
    Private mstrPadWord As String = ""

    Private mエラー表示用項目名 As String = ""
    Private mstrFromToErrText As String = ""
    Private mctlFromCtl As Control
    Private menmFromToSearch As gEnmFromTo = gEnmFromTo.None

    Private mcolorHissuColor As New System.Drawing.Color
    Private mcolorImpactColor As New System.Drawing.Color

    Private mblnPaste As Boolean

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    ''プロパティー-------------------------------------------------------------------
    ''' <summary>
    ''' pID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pID() As String
        Get
            Return mstrID
        End Get
        Set(ByVal Value As String)
            mstrID = Value
        End Set
    End Property

    ''' <summary>
    ''' pClearValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pClearValue() As String
        Get
            Return mstrClearValue
        End Get
        Set(ByVal Value As String)
            mstrClearValue = Value
        End Set
    End Property
    Public Property pClearText() As String
        Get
            Return mstrClearValue
        End Get
        Set(ByVal value As String)
            mstrClearValue = value
        End Set
    End Property

    Public Property Isクリア() As Boolean Implements IUserControl.Isクリア
        Get
            Return mIsクリア
        End Get
        Set(ByVal Value As Boolean)
            mIsクリア = Value
        End Set
    End Property

    ''' <summary>
    ''' pAutoFocus
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pAutoFocus() As Boolean
        Get
            Return mblnAutoFocus
        End Get
        Set(ByVal Value As Boolean)
            mblnAutoFocus = Value
        End Set
    End Property

    ''' <summary>
    ''' pAutoSelect
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pAutoSelect() As Boolean
        Get
            Return mblnAutoSelect
        End Get
        Set(ByVal Value As Boolean)
            mblnAutoSelect = Value
        End Set
    End Property

    ''' <summary>
    ''' pMaxByte
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pMaxByte() As Integer
        Get
            Return mintMaxByte
        End Get
        Set(ByVal Value As Integer)
            mintMaxByte = Value
        End Set
    End Property

    ''' <summary>
    ''' pCharType
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pCharType() As gEnmCharType
        Get
            Return menmCharType
        End Get
        Set(ByVal Value As gEnmCharType)
            menmCharType = Value
        End Set
    End Property

    ''' <summary>
    ''' pCondition
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pCondition() As gEnm入力条件
        Get
            Return menmCondition
        End Get
        Set(ByVal Value As gEnm入力条件)
            menmCondition = Value
            Select Case Me.menmCondition
                Case gEnm入力条件.Nomal
                    Me.Enabled = True
                    Me.BackColor = System.Drawing.SystemColors.Window
                Case gEnm入力条件.Fuka
                    Me.Enabled = False
                    Me.BackColor = System.Drawing.SystemColors.Control
                Case gEnm入力条件.Hissu
                    Me.Enabled = True
                    Me.BackColor = mcolorHissuColor
                Case gEnm入力条件.Impact
                    Me.Enabled = True
                    Me.BackColor = mcolorImpactColor
            End Select
        End Set
    End Property

    ''' <summary>
    ''' pErrText
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property エラー表示用項目名() As String Implements IUserControl.エラー表示用項目名
        Get
            Return mエラー表示用項目名
        End Get
        Set(ByVal Value As String)
            mエラー表示用項目名 = Value
        End Set
    End Property

    ''' <summary>
    ''' pFromToSearch
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pFromToSearch() As gEnmFromTo
        Get
            Return menmFromToSearch
        End Get
        Set(ByVal Value As gEnmFromTo)
            menmFromToSearch = Value
        End Set
    End Property

    ''' <summary>
    ''' pFromCtl
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pFromCtl() As Control
        Get
            Return mctlFromCtl
        End Get
        Set(ByVal Value As Control)
            mctlFromCtl = Value
        End Set
    End Property

    ''' <summary>
    ''' pFromToErrText
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pFromToErrText() As String
        Get
            Return mstrFromToErrText
        End Get
        Set(ByVal Value As String)
            mstrFromToErrText = Value
        End Set
    End Property

    ''' <summary>
    ''' pAutoPad
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pAutoPad() As Boolean
        Get
            Return mblnAutoPad
        End Get
        Set(ByVal Value As Boolean)
            mblnAutoPad = Value
        End Set
    End Property
    ''' <summary>
    ''' pPadWord
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pPadWord() As String
        Get
            Return mstrPadWord
        End Get
        Set(ByVal Value As String)
            mstrPadWord = Value
        End Set
    End Property
    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
    ''イベント-------------------------------------------------------------------
    ''' <summary>
    ''' UsrTxt_KeyPress
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrTxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim intByte As Integer
        Dim intMoji As Integer

        ''Maxlength
        If Me.pMaxByte > 0 Then
            intByte = System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.Text)
            intMoji = Me.pMaxByte - intByte
            If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(e.KeyChar) = 2 Then
                If intMoji = 1 Then
                    Me.MaxLength = Me.TextLength
                Else
                    Me.MaxLength = Me.TextLength + intMoji
                End If
            Else
                Me.MaxLength = Me.TextLength + intMoji
            End If
        End If

        '数字
        If Char.IsDigit(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All, gEnmCharType.Numonly, gEnmCharType.NumLetter, gEnmCharType.WildNumonly, gEnmCharType.WildNumLetter

                Case Else
                    e.Handled = True
            End Select

            'backspace,enter
        ElseIf Char.IsControl(e.KeyChar) Then

            'アルファベット
        ElseIf Char.IsLetter(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All, gEnmCharType.Letter, gEnmCharType.NumLetter, gEnmCharType.WildLetter, gEnmCharType.WildNumLetter

                    'Case gEnmCharType.NumLetter非日本語
                    '    If Not (e.KeyChar Like "[0-9]" Or e.KeyChar Like "[a-z]" Or e.KeyChar Like "[A-Z]") Then
                    '        e.Handled = True
                    '    End If


                Case Else
                    e.Handled = True
            End Select

            '区切り文字
        ElseIf Char.IsPunctuation(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All

                Case gEnmCharType.WildLetter, gEnmCharType.WildNumLetter, gEnmCharType.WildNumonly
                    If e.KeyChar = "*" Then

                    Else
                        e.Handled = True
                    End If
                Case Else
                    e.Handled = True
            End Select

            'サロゲート文字
        ElseIf Char.IsSurrogate(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All

                Case Else
                    e.Handled = True
            End Select

            'シンボル
        ElseIf Char.IsSymbol(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All

                Case Else
                    e.Handled = True
            End Select

            'スペース
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All, gEnmCharType.NumLetter, gEnmCharType.Letter, gEnmCharType.WildLetter, gEnmCharType.WildNumLetter

                Case Else
                    e.Handled = True
            End Select

        Else

        End If
    End Sub

    ''' <summary>
    ''' UsrTxt_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrTxt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        If Me.mblnPaste Then
            ''貼付で許可のない文字を削除(全角)
            Dim strBuff As String = ""
            Select Case Me.pCharType
                Case gEnmCharType.Letter, gEnmCharType.Numonly, gEnmCharType.NumLetter, gEnmCharType.WildLetter, gEnmCharType.WildNumonly, gEnmCharType.WildNumLetter
                    For i As Integer = 0 To Me.TextLength - 1
                        If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.Text.Chars(i)) = 1 Then
                            strBuff = strBuff & Me.Text.Chars(i)
                        End If
                    Next
                Case Else
                    strBuff = Me.Text
            End Select

            ''貼付で許可のない文字を削除(数値文字)
            Dim intLength As Integer
            Dim strBuff2 As String = ""
            Dim strBuff3 As String = ""
            If Me.pCharType <> gEnmCharType.All Then
                For i As Integer = 0 To strBuff.Length - 1
                    Select Case True
                        ''数値
                        Case Char.IsDigit(strBuff.Chars(i))
                            Select Case Me.pCharType
                                Case gEnmCharType.Numonly, gEnmCharType.NumLetter, gEnmCharType.WildNumonly, gEnmCharType.WildNumLetter
                                    strBuff2 = strBuff2 & strBuff.Chars(i)
                                Case Else

                            End Select
                            ''文字
                        Case Char.IsLetter(strBuff.Chars(i))
                            Select Case Me.pCharType
                                Case gEnmCharType.Letter, gEnmCharType.NumLetter, gEnmCharType.WildLetter, gEnmCharType.WildNumLetter
                                    strBuff2 = strBuff2 & strBuff.Chars(i)
                                Case Else

                            End Select
                            ''*
                        Case strBuff.Chars(i) = "*"
                            Select Case Me.pCharType
                                Case gEnmCharType.WildNumonly, gEnmCharType.WildLetter, gEnmCharType.WildNumLetter
                                    strBuff2 = strBuff2 & strBuff.Chars(i)
                                Case Else

                            End Select
                        Case Else

                    End Select
                Next
            Else
                strBuff2 = strBuff
            End If

            'Select Case Me.pCharType
            '    Case gEnmCharType.Numonly, gEnmCharType.WildNumonly
            '        For i = 0 To strBuff.Length - 1
            '            If strBuff.Chars(i).IsDigit(strBuff.Chars(i)) Then
            '                strBuff2 = strBuff2 & strBuff.Chars(i)
            '            ElseIf strBuff.Chars(i) = "*" And Me.pCharType = gEnmCharType.WildNumonly Then
            '                strBuff2 = strBuff2 & strBuff.Chars(i)
            '            End If
            '        Next
            '    Case gEnmCharType.Letter, gEnmCharType.WildLetter
            '        For i = 0 To strBuff.Length - 1
            '            If strBuff.Chars(i).IsLetter(strBuff.Chars(i)) Then
            '                strBuff2 = strBuff2 & strBuff.Chars(i)
            '            End If
            '        Next
            '    Case Else
            '        strBuff2 = strBuff
            'End Select

            ''貼付で制限を越えている場合
            If Me.pMaxByte > 0 Then
                For i As Integer = 0 To strBuff2.Length - 1
                    intLength = intLength + System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(strBuff2.Chars(i))
                    If intLength <= Me.pMaxByte Then
                        strBuff3 = strBuff3 & strBuff2.Chars(i)
                    ElseIf intLength > Me.pMaxByte Then
                        Exit For
                    End If
                Next
            Else
                strBuff3 = strBuff2
            End If

            If Me.Text <> strBuff3 Then
                Me.Text = strBuff3
            End If
            Me.mblnPaste = False
        End If

        If Me.mblnAutoFocus = True Then
            If Me.pMaxByte > 0 And _
               Me.pMaxByte <= System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.Text) And _
               Me.SelectionStart = CType(sender, TextBox).TextLength Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    ''' <summary>
    ''' UsrTxt_Enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrTxt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        ''文字選択
        If Me.mblnAutoSelect Then
            Me.SelectAll()
        End If
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Public Sub New()
        MyBase.New()

        'フォント
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        ''色
        Me.mcolorImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.mcolorHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))

    End Sub

    ''' <summary>
    ''' WndProc
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks>貼り付けの制御</remarks>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_PASTE As Integer = &H302
        'Const WM_IME_CHAR As Integer = &H286

        Select Case m.Msg
            Case WM_PASTE   ''貼り付けメッセージ
                Me.mblnPaste = True
                MyBase.WndProc(m)
                'Case WM_IME_CHAR
                '    If mblnImeChar Then
                '        If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.SelectedText) >= 2 Then

                '        Else
                '            Exit Sub
                '        End If
                '    End If
                '    MyBase.WndProc(m)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果

        Try
            With Me
                ''必須入力チェック
                If .pCondition = gEnm入力条件.Hissu Then
                    If .Text = "" Then
                        If .エラー表示用項目名 = "" Then
                            Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_未指定)
                        Else
                            Call CMsg.gMsg_注意(.エラー表示用項目名 & M定数.MSG_未指定)
                        End If
                        入力チェック.ErrorContol = Me
                        Return 入力チェック
                    End If
                End If

                ''範囲チェック
                If .pFromToSearch <> gEnmFromTo.None Then
                    ''FromToに入力がある場合は範囲チェック
                    If .Text <> "" And .pFromCtl.Text <> "" Then
                        ''数値で範囲検索
                        If .pFromToSearch = gEnmFromTo.Num Then
                            If CInt(.pFromCtl.Text) > CInt(.Text) Then
                                If .pFromToErrText = "" Then
                                    Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_範囲不正)
                                Else
                                    Call CMsg.gMsg_注意(.pFromToErrText & M定数.MSG_範囲不正)
                                End If
                                入力チェック.ErrorContol = .pFromCtl
                                Return 入力チェック
                            End If

                            ''文字で範囲検索
                        ElseIf .pFromToSearch = gEnmFromTo.Letter Then
                            If .pFromCtl.Text > .Text Then
                                If .pFromToErrText = "" Then
                                    Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_範囲不正)
                                Else
                                    Call CMsg.gMsg_注意(.pFromToErrText & M定数.MSG_範囲不正)
                                End If
                                入力チェック.ErrorContol = .pFromCtl
                                Return 入力チェック
                            End If
                        Else

                        End If
                    End If
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
        With Me
            If .Isクリア Then
                .Text = .pClearValue
            End If
        End With
    End Sub

    Private Sub usrTxt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        If Me.pAutoPad = True Then
            Dim PadText As String = Me.Text
            Me.Text = PadText.PadLeft(Me.pMaxByte, pPadWord)
        End If
    End Sub
End Class

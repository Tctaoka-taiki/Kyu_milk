'*******************************************************************************
' @(h)  UsrTxt.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrTxt                             System.Windows.Forms.TextBox���p��
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************

Public Class usrTxt
    Inherits System.Windows.Forms.TextBox
    Implements IUserControl
    Implements IEnter�L�[����

    '#####################################################################################
    '�^
    '#####################################################################################

    '#####################################################################################
    '�����o�ϐ�
    '#####################################################################################
    Private mstrID As String = ""
    Private mstrClearValue As String = ""
    Private mIs�N���A As Boolean = True

    Private mblnAutoFocus As Boolean = True
    Private mblnAutoSelect As Boolean = True
    Private mintMaxByte As Integer
    Private menmCharType As gEnmCharType = gEnmCharType.All
    Private menmCondition As gEnm���͏��� = gEnm���͏���.Nomal

    Private mblnAutoPad As Boolean = False
    Private mstrPadWord As String = ""

    Private m�G���[�\���p���ږ� As String = ""
    Private mstrFromToErrText As String = ""
    Private mctlFromCtl As Control
    Private menmFromToSearch As gEnmFromTo = gEnmFromTo.None

    Private mcolorHissuColor As New System.Drawing.Color
    Private mcolorImpactColor As New System.Drawing.Color

    Private mblnPaste As Boolean

    '#####################################################################################
    '�v���p�e�B�[
    '#####################################################################################
    ''�v���p�e�B�[-------------------------------------------------------------------
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

    Public Property Is�N���A() As Boolean Implements IUserControl.Is�N���A
        Get
            Return mIs�N���A
        End Get
        Set(ByVal Value As Boolean)
            mIs�N���A = Value
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
    Public Property pCondition() As gEnm���͏���
        Get
            Return menmCondition
        End Get
        Set(ByVal Value As gEnm���͏���)
            menmCondition = Value
            Select Case Me.menmCondition
                Case gEnm���͏���.Nomal
                    Me.Enabled = True
                    Me.BackColor = System.Drawing.SystemColors.Window
                Case gEnm���͏���.Fuka
                    Me.Enabled = False
                    Me.BackColor = System.Drawing.SystemColors.Control
                Case gEnm���͏���.Hissu
                    Me.Enabled = True
                    Me.BackColor = mcolorHissuColor
                Case gEnm���͏���.Impact
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
    Public Property �G���[�\���p���ږ�() As String Implements IUserControl.�G���[�\���p���ږ�
        Get
            Return m�G���[�\���p���ږ�
        End Get
        Set(ByVal Value As String)
            m�G���[�\���p���ږ� = Value
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
    '�C�x���g
    '#####################################################################################

    '#####################################################################################
    '�C�x���g�n���h��
    '#####################################################################################
    ''�C�x���g-------------------------------------------------------------------
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

        '����
        If Char.IsDigit(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All, gEnmCharType.Numonly, gEnmCharType.NumLetter, gEnmCharType.WildNumonly, gEnmCharType.WildNumLetter

                Case Else
                    e.Handled = True
            End Select

            'backspace,enter
        ElseIf Char.IsControl(e.KeyChar) Then

            '�A���t�@�x�b�g
        ElseIf Char.IsLetter(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All, gEnmCharType.Letter, gEnmCharType.NumLetter, gEnmCharType.WildLetter, gEnmCharType.WildNumLetter

                    'Case gEnmCharType.NumLetter����{��
                    '    If Not (e.KeyChar Like "[0-9]" Or e.KeyChar Like "[a-z]" Or e.KeyChar Like "[A-Z]") Then
                    '        e.Handled = True
                    '    End If


                Case Else
                    e.Handled = True
            End Select

            '��؂蕶��
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

            '�T���Q�[�g����
        ElseIf Char.IsSurrogate(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All

                Case Else
                    e.Handled = True
            End Select

            '�V���{��
        ElseIf Char.IsSymbol(e.KeyChar) Then
            Select Case Me.pCharType
                Case gEnmCharType.All

                Case Else
                    e.Handled = True
            End Select

            '�X�y�[�X
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
            ''�\�t�ŋ��̂Ȃ��������폜(�S�p)
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

            ''�\�t�ŋ��̂Ȃ��������폜(���l����)
            Dim intLength As Integer
            Dim strBuff2 As String = ""
            Dim strBuff3 As String = ""
            If Me.pCharType <> gEnmCharType.All Then
                For i As Integer = 0 To strBuff.Length - 1
                    Select Case True
                        ''���l
                        Case Char.IsDigit(strBuff.Chars(i))
                            Select Case Me.pCharType
                                Case gEnmCharType.Numonly, gEnmCharType.NumLetter, gEnmCharType.WildNumonly, gEnmCharType.WildNumLetter
                                    strBuff2 = strBuff2 & strBuff.Chars(i)
                                Case Else

                            End Select
                            ''����
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

            ''�\�t�Ő������z���Ă���ꍇ
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
        ''�����I��
        If Me.mblnAutoSelect Then
            Me.SelectAll()
        End If
    End Sub

    '#####################################################################################
    '�v���V�[�W��
    '#####################################################################################
    Public Sub New()
        MyBase.New()

        '�t�H���g
        Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        ''�F
        Me.mcolorImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.mcolorHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))

    End Sub

    ''' <summary>
    ''' WndProc
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks>�\��t���̐���</remarks>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_PASTE As Integer = &H302
        'Const WM_IME_CHAR As Integer = &H286

        Select Case m.Msg
            Case WM_PASTE   ''�\��t�����b�Z�[�W
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

    Public Function ���̓`�F�b�N(ByVal Is�G���[�t�H�[�J�X As Boolean) As C�`�F�b�N���� Implements IUserControl.���̓`�F�b�N
        ���̓`�F�b�N = New C�`�F�b�N����

        Try
            With Me
                ''�K�{���̓`�F�b�N
                If .pCondition = gEnm���͏���.Hissu Then
                    If .Text = "" Then
                        If .�G���[�\���p���ږ� = "" Then
                            Call CMsg.gMsg_����(.Name.Substring(3) & M�萔.MSG_���w��)
                        Else
                            Call CMsg.gMsg_����(.�G���[�\���p���ږ� & M�萔.MSG_���w��)
                        End If
                        ���̓`�F�b�N.ErrorContol = Me
                        Return ���̓`�F�b�N
                    End If
                End If

                ''�͈̓`�F�b�N
                If .pFromToSearch <> gEnmFromTo.None Then
                    ''FromTo�ɓ��͂�����ꍇ�͔͈̓`�F�b�N
                    If .Text <> "" And .pFromCtl.Text <> "" Then
                        ''���l�Ŕ͈͌���
                        If .pFromToSearch = gEnmFromTo.Num Then
                            If CInt(.pFromCtl.Text) > CInt(.Text) Then
                                If .pFromToErrText = "" Then
                                    Call CMsg.gMsg_����(.Name.Substring(3) & M�萔.MSG_�͈͕s��)
                                Else
                                    Call CMsg.gMsg_����(.pFromToErrText & M�萔.MSG_�͈͕s��)
                                End If
                                ���̓`�F�b�N.ErrorContol = .pFromCtl
                                Return ���̓`�F�b�N
                            End If

                            ''�����Ŕ͈͌���
                        ElseIf .pFromToSearch = gEnmFromTo.Letter Then
                            If .pFromCtl.Text > .Text Then
                                If .pFromToErrText = "" Then
                                    Call CMsg.gMsg_����(.Name.Substring(3) & M�萔.MSG_�͈͕s��)
                                Else
                                    Call CMsg.gMsg_����(.pFromToErrText & M�萔.MSG_�͈͕s��)
                                End If
                                ���̓`�F�b�N.ErrorContol = .pFromCtl
                                Return ���̓`�F�b�N
                            End If
                        Else

                        End If
                    End If
                End If
            End With
        Finally
            If Not ���̓`�F�b�N.ErrorContol Is Nothing And Is�G���[�t�H�[�J�X Then
                ���̓`�F�b�N.ErrorContol.Focus()
            End If
        End Try

        ���̓`�F�b�N.Is���� = True
    End Function

    Public Sub �N���A() Implements IUserControl.�N���A
        With Me
            If .Is�N���A Then
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

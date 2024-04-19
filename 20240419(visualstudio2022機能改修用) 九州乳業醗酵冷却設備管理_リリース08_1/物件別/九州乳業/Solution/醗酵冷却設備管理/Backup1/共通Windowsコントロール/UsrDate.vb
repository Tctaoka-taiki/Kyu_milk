'*******************************************************************************
' @(h)  UsrDate.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrDate                             System.Windows.Forms.UserControl���p��
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************

Public Class usrDate
    Inherits System.Windows.Forms.UserControl
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
    Private menmCondition As gEnm���͏��� = gEnm���͏���.Nomal

    Private m�G���[�\���p���ږ� As String = ""
    Private mstrFromToErrText As String = ""
    Private mctlFromCtl As Control
    Private menmFromToSearch As gEnmFromTo = gEnmFromTo.None

    Private mblnClearToday As Boolean

    Private mcolorHissuColor As New System.Drawing.Color
    Private mcolorImpactColor As New System.Drawing.Color

    '#####################################################################################
    '�v���p�e�B�[
    '#####################################################################################
    Public Property pID() As String
        Get
            Return mstrID
        End Get
        Set(ByVal Value As String)
            mstrID = Value
        End Set
    End Property

    Public Property pClearValue() As String
        Get
            Return mstrClearValue
        End Get
        Set(ByVal Value As String)
            mstrClearValue = Value
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
    ''' Text
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>/�Ȃ�</remarks>
    Public Overloads Overrides Property Text() As String
        Get
            Return Me.Text(False)
        End Get
        Set(ByVal Value As String)
            Dim strBuff As String = ""

            strBuff = Replace(Value, "/", "")
            If strBuff = "" Then
                Me.txtYear.Text = ""
                Me.txtMonth.Text = ""
                Me.txtDay.Text = ""
            ElseIf strBuff.Length = 8 Then
                Me.txtYear.Text = strBuff.Substring(0, 4)
                Me.txtMonth.Text = strBuff.Substring(4, 2)
                Me.txtDay.Text = strBuff.Substring(6, 2)
            Else
                Me.txtYear.Text = ""
                Me.txtMonth.Text = ""
                Me.txtDay.Text = ""
            End If
        End Set
    End Property

    ''' <summary>
    ''' Text
    ''' </summary>
    ''' <param name="blnSura">/�̗L���̎w��</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property Text(ByVal blnSura As Boolean) As String
        Get
            If blnSura Then
                Return Me.txtYear.Text & "/" & Me.txtMonth.Text & "/" & Me.txtDay.Text
            Else
                Return Me.txtYear.Text & Me.txtMonth.Text & Me.txtDay.Text
            End If
        End Get
    End Property

    ''' <summary>
    ''' ���t�Ƃ��Đ�������
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pIsDate() As Boolean
        Get
            Return Is�L�����t���͍� Or Me.Text.Trim = ""
        End Get
    End Property

    Public ReadOnly Property Is�L�����t���͍�() As Boolean
        Get
            If Me.Text.Trim = "" Then
                Return False
            ElseIf Me.txtYear.Text = "" Then
                Return False

            ElseIf Val(Me.txtYear.Text) < 1754 Then
                '090228 morichika SQLServer�ł�datetime�͈͂�1753/1/1 12:00 - 9999/12/31 23:59
                Return False
            Else
                Return IsDate(Me.txtYear.Text & "/" & Me.txtMonth.Text & "/" & Me.txtDay.Text)
            End If
        End Get
    End Property

    ''' <summary>
    ''' �N���A����Ƃ��ɖ{�����t�ɃN���A
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pClearToday() As Boolean
        Get
            Return mblnClearToday
        End Get
        Set(ByVal Value As Boolean)
            mblnClearToday = Value
        End Set
    End Property

    ''' <summary>
    ''' pYear
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pYear() As String
        Get
            Return Me.txtYear.Text
        End Get
        Set(ByVal Value As String)
            Me.txtYear.Text = Value
        End Set
    End Property

    ''' <summary>
    ''' pMonth
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pMonth() As String
        Get
            Return Me.txtMonth.Text
        End Get
        Set(ByVal Value As String)
            Me.txtMonth.Text = Value
        End Set
    End Property

    ''' <summary>
    ''' pDay
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pDay() As String
        Get
            Return Me.txtDay.Text
        End Get
        Set(ByVal Value As String)
            Me.txtDay.Text = Value
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
    ''' UsrDate_KeyPress
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYear.KeyPress, txtMonth.KeyPress, txtDay.KeyPress
        '����
        If Char.IsDigit(e.KeyChar.ToString.Chars(0)) = True Then

            'backspace,enter
        ElseIf Char.IsControl(e.KeyChar.ToString.Chars(0)) = True Then

            '�A���t�@�x�b�g
        ElseIf Char.IsLetter(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            '��؂蕶��
        ElseIf Char.IsPunctuation(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            '�T���Q�[�g����
        ElseIf Char.IsSurrogate(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            '�V���{��
        ElseIf Char.IsSymbol(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

            '�X�y�[�X
        ElseIf Char.IsWhiteSpace(e.KeyChar.ToString.Chars(0)) = True Then
            e.Handled = True

        Else
        End If

    End Sub

    ''' <summary>
    ''' UsrDate_Enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.Enter, txtMonth.Enter, txtDay.Enter
        If Me.mblnAutoSelect Then
            CType(sender, TextBox).SelectAll()
        End If
    End Sub

    ''' <summary>
    ''' UsrDate_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.TextChanged, txtMonth.TextChanged, txtDay.TextChanged
        ''���[�U�[�R���g���[���̃e�L�X�g�`�F���W�C�x���g�𔭐�������
        Call Me.OnTextChanged(e)

        If Me.mblnAutoFocus Then
            If CType(sender, TextBox).MaxLength > 0 And _
               CType(sender, TextBox).MaxLength <= CType(sender, TextBox).Text.Length And _
               CType(sender, TextBox).SelectionStart = CType(sender, TextBox).Text.Length Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    ''' <summary>
    ''' UsrDate_BackColorChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrDate_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.BackColorChanged
        Me.txtYear.BackColor = Me.BackColor
        Me.txtMonth.BackColor = Me.BackColor
        Me.txtDay.BackColor = Me.BackColor
        Me.lblSura1.BackColor = Me.BackColor
        Me.lblSura2.BackColor = Me.BackColor
    End Sub

    ''' <summary>
    ''' UsrDate_SizeChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>�T�C�Y�ύX�Ȃ��ɂ��邽��</remarks>
    Private Sub UsrDate_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        '�T�C�Y�ύX�͂Ȃ�
        'Me.Size = New System.Drawing.Size(100, 20)
    End Sub

    ''' <summary>
    ''' txtYear_Leave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.Leave, MyBase.Leave
        Select Case Me.txtYear.TextLength
            Case 1 To 3
                Me.txtYear.Text = "2" & Me.txtYear.Text.PadLeft(3, Chr(Asc("0")))
        End Select
    End Sub

    ''' <summary>
    ''' txtMonth_Leave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonth.Leave, MyBase.Leave
        If Me.txtMonth.TextLength = 1 Then
            Me.txtMonth.Text = Me.txtMonth.Text.PadLeft(2, Chr(Asc("0")))
        End If
    End Sub

    ''' <summary>
    ''' txtDay_Leave
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtDay_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDay.Leave, MyBase.Leave
        If Me.txtDay.TextLength = 1 Then
            Me.txtDay.Text = Me.txtDay.Text.PadLeft(2, Chr(Asc("0")))
        End If
    End Sub

    '#####################################################################################
    '�v���V�[�W��
    '#####################################################################################
    '�R���X�g���N�^
    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B
        ''�F
        Me.mcolorImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.mcolorHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    End Sub

    Public Sub SetDate(ByVal ���t As Date)
        With ���t
            pYear = .Year.ToString
            pMonth = Strings.Right("00" & .Month.ToString, 2)
            pDay = Strings.Right("00" & .Day.ToString, 2)
        End With
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="�l"></param>
    ''' <remarks>�l��DBNull�Ȃ�A�\�����N���A�BDate�^�Ȃ�Βl���Z�b�g</remarks>
    Public Sub Db�̒l���Z�b�g(ByVal �l As Object)
        If IsDBNull(�l) Then
            Text = ""
        Else
            SetDate(CType(�l, Date))
        End If
    End Sub

    ''' <summary>
    ''' �t�H�[�J�X�̃Z�b�g
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubFocus()
        Me.txtYear.Focus()
    End Sub

    Public Function ���̓`�F�b�N(ByVal Is�G���[�t�H�[�J�X As Boolean) As C�`�F�b�N���� Implements IUserControl.���̓`�F�b�N
        ���̓`�F�b�N = New C�`�F�b�N����

        Try
            With Me
                ''���̓`�F�b�N
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

                ''���t�`�F�b�N
                If .pIsDate = False Then
                    If .�G���[�\���p���ږ� = "" Then
                        Call CMsg.gMsg_����(.Name.Substring(3) & M�萔.MSG_�s��)
                    Else
                        Call CMsg.gMsg_����(.�G���[�\���p���ږ� & M�萔.MSG_�s��)
                    End If
                    ���̓`�F�b�N.ErrorContol = Me
                    Return ���̓`�F�b�N
                End If

                ''�͈̓`�F�b�N
                If .pFromToSearch <> gEnmFromTo.None Then
                    ''FromTo�ɓ��͂�����ꍇ�͔͈̓`�F�b�N
                    If .Text <> "" And .pFromCtl.Text <> "" Then
                        If .pFromCtl.Text > .Text Then
                            If .pFromToErrText = "" Then
                                Call CMsg.gMsg_����(.Name.Substring(3) & M�萔.MSG_�͈͕s��)
                            Else
                                Call CMsg.gMsg_����(.pFromToErrText & M�萔.MSG_�͈͕s��)
                            End If
                            ���̓`�F�b�N.ErrorContol = .pFromCtl
                            Return ���̓`�F�b�N
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
        If Is�N���A Then
            If pClearToday Then
                Text = Format(Now, M�萔.FORMAT_���t)
            Else
                Text = pClearValue
            End If
        End If
    End Sub

    Public Function ���t�I�u�W�F�N�g() As Object
        If Is�L�����t���͍� Then
            Return CDbUtil.�󕶎���ToDBNull(Text(True))
        Else
            Return DBNull.Value
        End If
    End Function
End Class

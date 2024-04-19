'*******************************************************************************
' @(h)  UsrCmb.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrCmb                             System.Windows.Forms.ComboBox���p��
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************

Public Class usrCmb
    Inherits System.Windows.Forms.ComboBox
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
    Private mintclearIndex As Integer = -1
    Private mIs�N���A As Boolean = True

    Private mblnAutoFocus As Boolean = True
    Private mblnAutoSelect As Boolean = True
    Private mintMaxByte As Integer
    Private menmCharType As gEnmCharType = gEnmCharType.All
    Private menmCondition As gEnm���͏��� = gEnm���͏���.Nomal

    Private m�G���[�\���p���ږ� As String = ""
    Private mstrFromToErrText As String = ""
    Private mctlFromCtl As Control
    Private menmFromToSearch As gEnmFromTo = gEnmFromTo.None

    Private m�l���X�g As New Generic.List(Of String)
    Private m�l���X�g2 As New Generic.List(Of String)
    Private m�l���X�g3 As New Generic.List(Of String)

    Private mstrHitKey As String = ""
    Private m�K�{�F As New System.Drawing.Color
    Private m�����F As New System.Drawing.Color

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

    ''' <summary>
    ''' pClearIndex
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pClearIndex() As Integer
        Get
            Return mintclearIndex
        End Get
        Set(ByVal Value As Integer)
            mintclearIndex = Value
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
                    Me.BackColor = m�K�{�F
                Case gEnm���͏���.Impact
                    Me.Enabled = True
                    Me.BackColor = m�����F
            End Select
        End Set
    End Property

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

    Public Overloads ReadOnly Property pValueAsText(ByVal intIndex As Integer) As String
        Get
            If intIndex = -1 Then
                Return ""
            Else
                Return m�l���X�g.Item(intIndex)
            End If
        End Get
    End Property

    Public Overloads ReadOnly Property pValueAsText() As String
        Get
            Return pValueAsText(Me.SelectedIndex)
        End Get
    End Property

    Public ReadOnly Property �l���X�g() As Generic.List(Of String)
        Get
            Return m�l���X�g
        End Get
    End Property

    Public ReadOnly Property �l���X�g2() As Generic.List(Of String)
        Get
            Return m�l���X�g2
        End Get
    End Property

    Public ReadOnly Property �l���X�g3() As Generic.List(Of String)
        Get
            Return m�l���X�g3
        End Get
    End Property

    '#####################################################################################
    '�C�x���g
    '#####################################################################################

    '#####################################################################################
    '�C�x���g�n���h��
    '#####################################################################################
    ''�C�x���g����-------------------------------------------------------------------
    ''' <summary>
    ''' UsrCmb_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrCmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        'If Me.mBlnAutoFocus = True Then
        '    If CType(sender, ComboBox).MaxLength > 0 And _
        '       CType(sender, ComboBox).MaxLength <= CType(sender, ComboBox).Text.Length And _
        '       CType(sender, ComboBox).SelectionStart = CType(sender, ComboBox).Text.Length Then
        '        SendKeys.Send("{TAB}")
        '    End If
        'End If
    End Sub

    ''' <summary>
    ''' UsrCmb_Enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrCmb_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        If Me.mblnAutoFocus And Me.DropDownStyle = ComboBoxStyle.DropDownList Then
            Me.SelectAll()
        End If
        Me.mstrHitKey = ""
    End Sub

    ''' <summary>
    ''' UsrCmb_SizeChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrCmb_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.DropDownWidth = Me.Width
    End Sub

    ''' <summary>
    ''' UsrCmb_KeyPress
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrCmb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim intByte As Integer
        Dim intMoji As Integer

        ''�ҏW�\���̂�
        If Me.DropDownStyle = ComboBoxStyle.DropDown Then
            'Maxlength
            intByte = System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.Text)
            intMoji = Me.pMaxByte - intByte
            If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(e.KeyChar) = 2 Then
                If intMoji = 1 Then
                    Me.MaxLength = Me.Text.Length
                Else
                    Me.MaxLength = Me.Text.Length + intMoji
                End If
            Else
                Me.MaxLength = Me.Text.Length + intMoji
            End If
        ElseIf Me.DropDownStyle = ComboBoxStyle.DropDownList Then
            If Char.IsLetterOrDigit(e.KeyChar) Then
                Me.mstrHitKey &= e.KeyChar
                Call Me.mSubHitIndex()
                e.Handled = True
            End If
        End If
    End Sub

    '#####################################################################################
    '�v���V�[�W��
    '#####################################################################################
    Public Sub New()
        MyBase.New()

        ''���X�g�X�^�C��
        Me.DropDownStyle = ComboBoxStyle.DropDownList
        '�t�H���g
        Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        '�F
        Me.m�����F = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.m�K�{�F = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))

    End Sub

    ''' <summary>
    ''' �R���{���e��Index��������
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mSubHitIndex()
        For i As Integer = 0 To Me.Items.Count - 1
            If CStr(Me.Items.Item(i)).Length >= Me.mstrHitKey.Length Then
                If CStr(Me.Items.Item(i)).Substring(0, Me.mstrHitKey.Length) = Me.mstrHitKey Then
                    Me.SelectedIndex = i
                    Exit Sub
                End If
            End If
        Next
        Me.SelectedIndex = -1
        Me.mstrHitKey = ""
    End Sub

    ''���\�b�h------------------------------------------------------------------
    ''' <summary>
    ''' gSubComboClear
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub gSubComboClear()
        Call Me.gSubComboClear(True)
    End Sub
    Public Overloads Sub gSubComboClear(ByVal blnTextClear As Boolean)
        Me.Items.Clear()
        Me.�l���X�g.Clear()

        If blnTextClear Then
            If Me.DropDownStyle = ComboBoxStyle.DropDown Then
                Me.Text = Me.pClearValue
            End If
        End If
    End Sub

    ''' <summary>
    ''' Values�ƈ�v����Index�̎擾
    ''' </summary>
    ''' <param name="strSearch"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gIntFindValue(ByVal strSearch As String) As Integer
        If Me.�l���X�g.Contains(strSearch) Then
            Return Me.�l���X�g.IndexOf(strSearch)
        Else
            Return -1
        End If
    End Function

    ''' <summary>
    ''' Items�ƈ�v����Index��
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <remarks></remarks>
    Public Sub gSubSetItemIndex(ByVal strValue As String)
        Me.SelectedIndex = Me.FindStringExact(strValue) '�R���{ �{�b�N�X���ŁA�w�肵��������ƈ�v����ŏ��̍��ڂ��������܂��B
    End Sub

    ''' <summary>
    ''' Values�ƈ�v����Index��
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <remarks></remarks>
    Public Sub gSubSetValueIndex(ByVal strValue As String)
        Me.SelectedIndex = Me.gIntFindValue(strValue)
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
                                ���̓`�F�b�N.ErrorContol = CType(.pFromCtl, usrCmb)
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
                If .DropDownStyle = ComboBoxStyle.DropDownList Then
                    If .Items.Count > .pClearIndex Then '�N���A�\�ȏꍇ�Ɍ���
                        .SelectedIndex = .pClearIndex
                    End If
                ElseIf .DropDownStyle = ComboBoxStyle.DropDown Then
                    .Text = .pClearValue
                End If
            End If
        End With
    End Sub
End Class

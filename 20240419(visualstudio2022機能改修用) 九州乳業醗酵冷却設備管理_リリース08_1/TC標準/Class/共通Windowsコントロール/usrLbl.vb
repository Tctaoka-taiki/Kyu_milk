'*******************************************************************************
' @(h)  UsrLbl.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrLbl                             System.Windows.Forms.Label���p��
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ForeColor = System.Drawing.SystemColors.ControlText
'       TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************

Public Class usrLbl
    Inherits System.Windows.Forms.Label
    Implements IUserControl

    '#####################################################################################
    '�^
    '#####################################################################################

    '#####################################################################################
    '�����o�ϐ�
    '#####################################################################################
    Private m�G���[�\���p���ږ� As String = ""
    Private mstrID As String = ""
    Private mstrClearValue As String = ""
    Private mIs�N���A As Boolean

    'Private mblnNumDisply As Boolean
    'Private mstrNumFormat As String = "#,##0"

    '#####################################################################################
    '�v���p�e�B�[
    '#####################################################################################
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
    ''' pIsClear
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Is�N���A() As Boolean Implements IUserControl.Is�N���A
        Get
            Return mIs�N���A
        End Get
        Set(ByVal Value As Boolean)
            mIs�N���A = Value
        End Set
    End Property

    '#Region "pIsNumDisply�v���p�e�B�["
    '    '---------------------------------------------------------------------------
    '    ' @(f)
    '    ' �@�@�\�@�FpIsNumDisply�v���p�e�B�[
    '    ' ���@���@�F
    '    ' �߂�l�@�F
    '    ' �@�\�����FText�v���p�e�B�[���Z�b�g����Ƃ��Ƀt�H�[�}�b�g���Đݒ肷�邩�ǂ���
    '    ' ���@�l�@�F
    '    '---------------------------------------------------------------------------
    '#End Region
    '    Public Property pIsNumDisply() As Boolean
    '        Get
    '            Return mblnNumDisply
    '        End Get
    '        Set(ByVal Value As Boolean)
    '            mblnNumDisply = Value
    '            If Value Then
    '                Me.TextAlign = ContentAlignment.MiddleRight
    '            Else
    '                Me.TextAlign = ContentAlignment.MiddleLeft
    '            End If
    '            Me.text = Me.text
    '        End Set
    '    End Property

    '#Region "pFormatNum�v���p�e�B�["
    '    '---------------------------------------------------------------------------
    '    ' @(f)
    '    ' �@�@�\�@�FpFormatNum�v���p�e�B�[
    '    ' ���@���@�F
    '    ' �߂�l�@�F
    '    ' �@�\�����Ftext�v���p�e�B�ɐݒ肷��Ƃ��̃t�H�[�}�b�g
    '    ' ���@�l�@�F
    '    '---------------------------------------------------------------------------
    '#End Region
    '    Public Property pFormatNum() As String
    '        Get
    '            Return mstrNumFormat
    '        End Get
    '        Set(ByVal Value As String)
    '            mstrNumFormat = Value
    '            Me.text = Me.text
    '        End Set
    '    End Property

    '    Public Overrides Property text() As String
    '        Get
    '            Return MyBase.Text
    '        End Get
    '        Set(ByVal value As String)
    '            If Me.mblnNumDisply Then
    '                If IsNumeric(value) Then
    '                    MyBase.Text = Format(CDbl(value), Me.mstrNumFormat)
    '                Else
    '                    MyBase.Text = value
    '                End If
    '            Else
    '                MyBase.Text = value
    '            End If
    '        End Set
    '    End Property

    Public Property �G���[�\���p���ږ�() As String Implements IUserControl.�G���[�\���p���ږ�
        Get
            Return m�G���[�\���p���ږ�
        End Get
        Set(ByVal value As String)
            m�G���[�\���p���ږ� = value
        End Set
    End Property

    '#####################################################################################
    '�C�x���g
    '#####################################################################################

    '#####################################################################################
    '�C�x���g�n���h��
    '#####################################################################################

    '#####################################################################################
    '�v���V�[�W��
    '#####################################################################################
    Public Sub New()
        MyBase.New()

        '�t�H���g
        Me.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    End Sub

    Public Sub �N���A() Implements IUserControl.�N���A
        If Is�N���A Then
            Text = pClearValue
        End If
    End Sub

    Public Function ���̓`�F�b�N(ByVal Is�G���[�t�H�[�J�X As Boolean) As C�`�F�b�N���� Implements IUserControl.���̓`�F�b�N
        ���̓`�F�b�N = New C�`�F�b�N����
        ���̓`�F�b�N.Is���� = True
    End Function
End Class

'*******************************************************************************
' @(h)  UsrChk.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrChk                             System.Windows.Forms.CheckBox���p��
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************

Public Class UsrChk
    Inherits System.Windows.Forms.CheckBox
    Implements IUserControl
    Implements IEnter�L�[����

    '#####################################################################################
    '�^
    '#####################################################################################

    '#####################################################################################
    '�����o�ϐ�
    '#####################################################################################
    Private mstrID As String = ""
    Private mblnClear As Boolean
    Private mcheckClearChecked As CheckState = Windows.Forms.CheckState.Unchecked

    '#####################################################################################
    '�v���p�e�B�[
    '#####################################################################################
    '�v���p�e�B�[-------------------------------------------------------------------
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
    Public Property pClearValue() As CheckState
        Get
            Return mcheckClearChecked
        End Get
        Set(ByVal Value As CheckState)
            mcheckClearChecked = Value
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
            Return mblnClear
        End Get
        Set(ByVal Value As Boolean)
            mblnClear = Value
        End Set
    End Property

    Private m�G���[�\���p���ږ� As String = ""
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
    '�R���X�g���N�^
    Public Sub New()
        MyBase.New()

        '�t�H���g
        Me.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    End Sub

    Public Sub �N���A() Implements IUserControl.�N���A
        If Is�N���A Then
            CheckState = pClearValue
        End If
    End Sub

    Public Function ���̓`�F�b�N(ByVal Is�G���[�t�H�[�J�X As Boolean) As C�`�F�b�N���� Implements IUserControl.���̓`�F�b�N
        ���̓`�F�b�N = New C�`�F�b�N����
        ���̓`�F�b�N.Is���� = True
    End Function
End Class

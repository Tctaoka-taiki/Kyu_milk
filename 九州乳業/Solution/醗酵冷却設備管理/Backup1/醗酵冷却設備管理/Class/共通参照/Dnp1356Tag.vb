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
    ''' �C���X�^���X�������Ƀ^�OID���w�肵�܂�
    ''' </summary>
    ''' <param name="TagID"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal TagID As Byte())
        Me.New()
        Array.Copy(TagID, MyBase.ID.Binary, SYSTEM_AREA_SIZE + USER_AREA_SIZE)
    End Sub
    ''' <summary>
    ''' �C���X�^���X�������Ƀ^�OID���w�肵�܂�
    ''' </summary>
    ''' <param name="TagID"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal TagID As String)
        Me.New()
        MyBase.ID.HexString = TagID
    End Sub
End Class

''' <summary>
''' �c�m�o���g�q�v�|�c�r�t�O�P���[�_�A���C�^����
''' </summary>
''' <remarks></remarks>
Public Class CHRW_DSU01
    '�萔
    '���̒萔�l��RX5300DLL.h�����Q�Ƃ��������B
    Private Const MAX_IDENT As Integer = 4          '�ő�F���^�O��
    Private Const TAGID_LEN As Integer = 16         '�^�OUID�����O�X
    Private Const TAGDATA As Integer = 2048         '�^�O�����݃f�[�^��
    Private Const COMAND_SND_DATA As Integer = 35   '�R�}���h���M�f�[�^
    Private Const COMAND_RCV_DATA As Integer = 35   '�R�}���h��M�f�[�^
    Private Const DLL_NAME As String = "RX5300DLL.dll" 'DLL��
    '�u�U�[�p
    Private Const OF_BUZZER As Integer = 0          '�u�U�[��炳�Ȃ�
    Private Const ON_BUZZER As Integer = 1          '�u�U�[���
    'LOOP�p
    Private Const STOP_LOOP As Integer = 1          '���[�v����p(�����l�ݒ�p)
    Private Const OF_LOOP As Integer = 0            '���[�v�w��p(���[�v���Ȃ�
    Private Const ON_LOOP As Integer = 1            '���[�v�w��p(���[�v����


    '�G���[���b�Z�[�W��`
    '�G���[�l��RX5300DLL.h�����Q�Ɖ������B
    Private Shared ErrMsg() As String = { _
                                        "����I�����܂���", _
                                        "��M�o�C�g���ُ�", _
                                        "�u���b�N���ُ�", _
                                        "�A�h���X�u���b�N���ُ�", _
                                        "LOOP�ݒ�ُ�", _
                                        "�R�}���h�ُ�", _
                                        "�R�}���h�p�����[�^�ُ�", _
                                        "CRLF���F���ł��Ȃ�", _
                                        "�O���ʐM��M�ُ�", _
                                        "Inventory���s�G���[", _
                                        "�R�}���h���s�G���[", _
                                        "�F���^�O�Q�ȏ�", _
                                        "", _
                                        "", _
                                        "TAG�R�}���h���s�G���[", _
                                        "���X�|���X�E�t���O�G���[", _
                                        "�ڑ��G���[", _
                                        "�R�}���h���M���s", _
                                        "�R�}���h��M���s", _
                                        "�V���A���ԍ��擾���s", _
                                        "�^�O���[�h�擾���s", _
                                        "�^�O���C�g�擾���s", _
                                        "UID�擾���s", _
                                        "�^�O�R�}���h���s���s", _
                                        "�u�U�[�R�}���h���s", _
                                        "�Z���T�R�}���h���s", _
                                        "���[�h�R���t�B�O���s", _
                                        "���[�v�X�^�[�g���s", _
                                        "�^�C���A�E�g��M�G���[", _
                                        "�p�����[�^�G���[", _
                                        "���̑��G���[", _
                                        "�^�O�^�C�v�`�F�b�N�G���[" _
                                       }

    ''' <summary>
    ''' USB���\����
    '''  ���M�^�C���A�E�g�l
    '''  ��M�^�C���A�E�g�l
    '''  �V���A���ԍ�
    '''  USB�n���h��
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
    ''' �^�O���\����
    '''  �^�OID
    '''  �^�O���
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
    ''' [IN]TAG�R�}���h�p�\����
    '''  TAG�R�}���h���M�f�[�^
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_IN_TA
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=COMAND_SND_DATA + 1)> _
        Public saCmdData As String
    End Structure
    ''' <summary>
    ''' [OUT]TAG�R�}���h�p�\����
    '''  TAG�R�}���h��M�f�[�^
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_OUT_TA
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=COMAND_RCV_DATA + 1)> _
        Public saRcvData As String
    End Structure


    ''' <summary>
    ''' [OUT]OUT_GU�p�\����
    '''  �擾�^�O��
    '''  �^�O���\���̔z��[MAX_IDENT]
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_OUT_GU
        Public byTagIdNum As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_IDENT)> _
        Public s_TAGINFO() As tag_TAGINFO
    End Structure

    ''' <summary>
    ''' [IN]�^�O���ǎ��p�\����
    '''  �ǎ�J�n�A�h���X
    '''  �ǎ�u���b�N��
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_IN_MR
        Public byStartAddr As Byte
        Public byReadLeng As Byte
    End Structure
    ''' <summary>
    ''' [OUT]�^�O���ǎ��p�\����
    '''  �擾�^�O��
    '''  �Ǎ��ݐ����^�O��
    '''  �^�O���\���̔z��[MAX_IDENT]
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_OUT_MR
        Public byTagIdNum As Byte
        Public byTagReadNum As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_IDENT)> _
        Public s_TAGINFO() As tag_TAGINFO
    End Structure

    ''' <summary>
    ''' [IN]�^�O�����ݗp�\����
    '''  �ǎ�J�n�A�h���X
    '''  �ǎ�u���b�N��
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_IN_MW
        Public byStartAddr As Byte
        Public byReadLeng As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_IDENT)> _
        Public s_TAGINFO() As tag_TAGINFO
    End Structure
    ''' <summary>
    ''' [OUT]�^�O��񏑍��ݗp�\����
    '''  �擾�^�O��
    '''  �Ǎ��ݐ����^�O��
    '''  �^�O���\���̔z��[MAX_IDENT]
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_OUT_MW
        Public byTagIdNum As Byte
        Public byTagWriteNum As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=MAX_IDENT)> _
        Public s_TAGINFO() As tag_TAGINFO
    End Structure

    ''' <summary>
    ''' �u�U�[���p�R�}���h
    '''  �u�U�[�t���O�@ON_BUZZER/OF_BUZZER
    '''  �u�U�[��炷����(0x0�`0xF)
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure tag_BUZZER
        Public byBuzzerFlg As Byte
        Public byTime As Byte
    End Structure

    ''' <summary>
    ''' ���[�v�ݒ�\����
    '''  ���[�v�t���O�@ON_LOOP/OF_LOOP
    '''  ���[�v����t���O�@�����l�Ƃ���STOP_LOOP��ݒ肵�Ă�������(DLL�����p)
    '''  ���[�v�X�e�[�^�X�@���݃��[�v���Ă����ʂł�(�l��RX5300DLL.h�Q��)
    '''  ���[�v�n���h���@�@���b�Z�[�W���o�� ��ʃn���h��
    '''  ���[�v�n���h���@�@(DLL�����p)�@
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
    ''' �v���p�e�B�\����
    '''  ���̍\���̂��e�֐����Ăяo���ׂ̈����Ƃ��܂��B
    '''  RX_Init_PROPERTY�֐��ł��̍\���̂����������邱�Ƃ��o���܂��B
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
    ''' PROPERTY�\���̂̏��������s���܂�
    ''' </summary>
    ''' <param name="s_PROPERTY">[in]�֐������\����</param>
    Private Declare Function RX_Init_PROPERTY Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer


    ''' <summary>
    ''' USB�V���A���ԍ����擾���܂�
    ''' </summary>
    ''' <param name="lpBuf">[out]�擾�����V���A���ԍ�</param>
    Private Declare Function RX_GetSerialNo Lib "RX5300DLL.dll" (ByVal lpBuf As StringBuilder) As Integer

    ''' <summary>
    ''' USB���I�[�v�����܂�
    ''' </summary>
    ''' <param name="s_USB_INFO">USB���\����</param>
    Private Declare Function RX_OpenUSB Lib "RX5300DLL.dll" (ByRef s_USB_INFO As tag_USB_INFO) As Integer

    ''' <summary>
    ''' USB���N���[�Y���܂�
    ''' </summary>
    ''' <param name="s_USB_INFO">USB���\����</param>
    Private Declare Function RX_CloseUSB Lib "RX5300DLL.dll" (ByRef s_USB_INFO As tag_USB_INFO) As Integer

    ''' <summary>
    ''' �u�U�[��炵�܂�
    ''' </summary>
    ''' <param name="s_USB_INFO">USB���\����</param>
    ''' <param name="byTime">�炷����(0h�`1h)</param>
    Private Declare Function RX_BuzzerCommand Lib "RX5300DLL.dll" (ByRef s_USB_INFO As tag_USB_INFO, ByVal byTime As System.Byte) As Integer

    ''' <summary>
    ''' �ő�S����UID���擾���܂�
    ''' </summary>
    ''' <param name="s_PROPERTY"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Declare Function RX_GetUID Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' TAG�R�}���h�̎��s
    ''' </summary>
    Private Declare Function RX_TagCommand Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' �^�O���Ǎ��݊֐�
    ''' </summary>
    ''' <param name="s_PROPERTY">[in]�֐������\����</param>
    Private Declare Function RX_MultiRead Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' �^�O��񏑍��݊֐�
    ''' </summary>
    ''' <param name="s_PROPERTY">[in]�֐������\����</param>
    Private Declare Function RX_MultiWrite Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' ���s����Loop���~���܂��B
    ''' �Ăяo���ۂ�s_PROPERTY�̒l��V���ɕύX����K�v�͂���܂���B
    ''' ���̂܂�s_PROPERTY��n���Ă�������
    ''' </summary>
    ''' <param name="s_PROPERTY">[in]�֐������\����</param>
    Private Declare Function RX_LoopStop Lib "RX5300DLL.dll" (ByRef s_PROPERTY As tag_PROPERTY) As Integer

    ''' <summary>
    ''' �G���[���b�Z�[�W�\��
    ''' </summary>
    ''' <param name="ErrNo">�G���[�ԍ�</param>
    Public Shared Function showErrMsg(ByVal ErrNo As Integer) As String

        '30�ȏ�̃R�[�h���擾�����ꍇ��"���̑��G���["�Ƃ���B
        If ErrNo > 30 Then
            ErrNo = 29
        End If

        '�G���[���b�Z�[�W��\�����܂��B
        Return ErrMsg(ErrNo)
    End Function

    ''' <summary>
    ''' ����p�\����
    ''' </summary>
    ''' <remarks></remarks>
    Private _Prop As tag_PROPERTY
    Sub New()
        'USB�̃V���A���ԍ����擾����
        Dim buf As StringBuilder = New System.Text.StringBuilder(9)
        Dim ret As Integer
        ret = RX_GetSerialNo(buf)

        RX_Init_PROPERTY(Me._Prop)
        With Me._Prop
            Me.SendTimeput = 1000                   '���M�^�C���A�E�g�ݒ�
            Me.ReceiveTimeout = 1000                '��M�^�C���A�E�g�ݒ�
            .s_USB_INFO.buf = buf.ToString()        '�V���A���ԍ�
            .s_LOOP.hw = Nothing                    '�A��LOOP�C�x���g��M�p��ʃn���h���ݒ�
            .s_LOOP.hTh = Nothing                   'NULL�ŏ��������Ă����Ă�������
            .s_LOOP.byLoopCtrlFlg = STOP_LOOP       'STOP_LOOP�ŏ��������Ă����Ă�������
            Me.BuzzerTime = 2                       '�u�U�[�炷����
        End With
    End Sub

    ''' <summary>
    ''' ���M�^�C���A�E�g
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
    ''' ��M�^�C���A�E�g
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
    ''' �u�U�[�̒���
    ''' </summary>
    ''' <remarks></remarks>
    Public Property BuzzerTime() As Byte
        Get
            Return Me._Prop.s_BUZZER.byTime
        End Get
        Set(ByVal value As Byte)
            If value > 15 Then
                Throw New Exception("�u�U�[�̒�����1�`15�Őݒ肵�Ă�������")
            End If
            Me._Prop.s_BUZZER.byTime = value               '�u�U�[�炷����
            If value = 0 Then
                Me._Prop.s_BUZZER.byBuzzerFlg = OF_BUZZER      '�u�U�[�ݒ� 
            Else
                Me._Prop.s_BUZZER.byBuzzerFlg = ON_BUZZER      '�u�U�[�ݒ� 
            End If
        End Set
    End Property


    ''' <summary>
    ''' �^�OID��ǂݏo��
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTagIDs() As List(Of TagID)
        'UID�擾�֐����s
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

''' <summary>
''' ���b�Z�[�W�{�b�N�X���[�e�B���e�B�N���X
''' </summary>
''' <remarks></remarks>
Public Class CMsg
    '#####################################################################################
    '�^
    '#####################################################################################

    '#####################################################################################
    '�����o�ϐ�
    '#####################################################################################

    '#####################################################################################
    '�v���p�e�B�[
    '#####################################################################################

    '#####################################################################################
    '�C�x���g
    '#####################################################################################

    '#####################################################################################
    '�C�x���g�n���h��
    '#####################################################################################

    '#####################################################################################
    '�v���V�[�W��
    '#####################################################################################
    Private Sub New()
    End Sub

    ''���b�Z�[�W�{�b�N�X
    Public Shared Sub gMsg_����(ByVal strMsg As String)
        Call MessageBox.Show(strMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    ''' <summary>
    ''' �G���[
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <remarks></remarks>
    Public Shared Sub gMsg_�G���[(ByVal strMsg As String)
        Call MessageBox.Show(strMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' ���
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <remarks></remarks>
    Public Shared Sub gMsg_���(ByVal strMsg As String)
        Call MessageBox.Show(strMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' �m�F
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function gMsg_YesNo(ByVal strMsg As String, Optional ByVal ���o�� As String = "") As System.Windows.Forms.DialogResult
        Return MessageBox.Show(strMsg, ���o��, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    ''' <summary>
    ''' �m�F�L�����Z��
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function gMsg_YesNoCancel(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        Return MessageBox.Show(strMsg, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
    End Function

    ''' <summary>
    ''' ���g���C
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function gMsg_RetryCancel(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        Return MessageBox.Show(strMsg, "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    Public Shared Sub gMsg_�폜�������b�Z�[�W()
        gMsg_���(M�萔.MSG_�폜����)
    End Sub
    Public Shared Sub gMsg_�o�^�������b�Z�[�W()
        gMsg_���(M�萔.MSG_�o�^����)
    End Sub
End Class

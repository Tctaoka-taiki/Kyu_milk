
Public Class Frm�p�X���[�h�ύX
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
    Private Sub Frm0141�o�^�ҏ�񃁃��e�i���X_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CUsrctl.gSub�R���g���[���̏�����(Me)
    End Sub

    Private Sub btn����_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gRSubF�ĕ\��()
    End Sub

    Private Sub btn�N���A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�N���A.Click
        CUsrctl.gSub�R���g���[���̏�����(Me)
    End Sub

    Private Sub btn���j���[_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn���j���[.Click
        gMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ�����ގ��Ǘ�.�}�X�^�����e���j���[)
    End Sub

    Private Sub btn�ύX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�ύX.Click
        Try

            ''�������ݒ�
            Call Me.gMdiMain.gSub�������ݒ�(Me, True, M�萔.MSG_���s��)

        Dim �Í������ꂽ�ύX�O�p�X���[�h As String = CUtil.�ݒ�֘A.�ݒ蕶����Ǎ�("app.�p�X���[�h")
        Dim �ύX�O�p�X���[�h As String = Crypto.Key.Decrypt(C��ʐ���.�p�X�t���[�Y, �Í������ꂽ�ύX�O�p�X���[�h)
        If Txt�ύX�O�p�X���[�h.Text <> �ύX�O�p�X���[�h Then
            CMsg.gMsg_����("�ύX�O�̃p�X���[�h���Ԉ���Ă��܂��B")
            Txt�ύX�O�p�X���[�h.Focus()
            Exit Sub
        End If

        If CUtil.�ݒ�֘A.�ݒ蕶���񏑍�("app.�p�X���[�h", Crypto.Key.Encrypt(C��ʐ���.�p�X�t���[�Y, Txt�ύX��p�X���[�h.Text)) Then
            CMsg.gMsg_���("�p�X���[�h��ύX���܂����B�ύX��̃p�X���[�h�͍ċN����ɗL���ɂȂ�܂��B")
               '***************************
                '08/05/08 morichika
            gMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ�����ގ��Ǘ�.���C�����j���[)
                If CMsg.gMsg_YesNo("�A�v���P�[�V�������I�����Ă���낵���ł����H") = Windows.Forms.DialogResult.Yes Then
                    End
                Else

                End If

            End If

        Catch ex As Exception

        Finally
            ''����������
            Me.gMdiMain.gSub�������ݒ�(Me, False, "")

        End Try
    End Sub

    '#####################################################################################
    '�v���V�[�W��
    '#####################################################################################

End Class

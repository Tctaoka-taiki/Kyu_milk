Public Class Frm00002_��p�����C�����j���[

  

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

    Private Sub Frm9999���C�����j���[_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CMdiMain.mInt���y��p���[�h = 0 Then
            CMdiMain.���j���[�ؑ�ToolStripMenuItem.Enabled = True
        Else
            CMdiMain.���j���[�ؑ�ToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub Frm00002_��p�����C�����j���[_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        CMdiMain.���j���[�ؑ�ToolStripMenuItem.Enabled = False
    End Sub

    Private Sub Frm00001_���C�����j���[_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            '
            If txt����No.Focused = True Then
                '���͂���Ă���f�[�^�����ɉ�ʑJ��
                Select Case txt����No.Text
                    Case "1"
                        Mnu��p�����o�ɐݒ�()

                    Case "2"
                        Mnu�I�w��o�ɐݒ�()

                    Case "11"
                        Mnu�I�⍇�����e�i���X()

                    Case "12"
                        Mnu�݌ɖ⍇��()

                    Case "13"
                        Mnu��p��I�⍇��()

                    Case "21"
                        Mnu�ݔ���()

                    Case "99"
                        CMdiMain.Close()

                End Select
            End If
        End If

    End Sub

    Private Sub Mnu��p�����o�ɐݒ�()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��p�����o�ɐݒ�)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu�I�w��o�ɐݒ�()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��p�I�w��o�ɐݒ�)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu�I�⍇�����e�i���X()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��p�I�⍇�������e�i���X)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu�݌ɖ⍇��()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��p�݌ɖ⍇��)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu��p��I�⍇��()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��p��I�⍇��)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu�ݔ���()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��p�ݔ���)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu�d���n�e�e()

    End Sub
End Class

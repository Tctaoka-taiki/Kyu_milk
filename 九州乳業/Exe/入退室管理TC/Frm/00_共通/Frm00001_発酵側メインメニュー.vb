Public Class Frm00001_���y�����C�����j���[


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
        CMdiMain.���j���[�ؑ�ToolStripMenuItem.Enabled = True
    End Sub

    Private Sub Frm00001_���y�����C�����j���[_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        CMdiMain.���j���[�ؑ�ToolStripMenuItem.Enabled = False
    End Sub

    Private Sub Frm00001_���C�����j���[_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            '
            If txt����No.Focused = True Then
                '���͂���Ă���f�[�^�����ɉ�ʑJ��
                Select Case txt����No.Text
                    Case "1"
                        Mnu���ɐݒ�_�n�[�h1()
                    Case "2"
                        Mnu���ɐݒ�_�v���[��1()
                    Case "3"
                        Mnu���ɐݒ�_�n�[�h2()
                    Case "4"
                        Mnu���y�����o�ɐݒ�()
                    Case "5"
                        Mnu���y�I�w��o�ɐݒ�()
                    Case "11"
                        Mnu�}�X�^�[�ݒ�()
                    Case "12"
                        Mnu���y���ɒI���ݒ�()
                    Case "13"
                        Mnu���y�I�⍇�������e�i���X()
                    Case "14"
                        Mnu���y�݌ɖ⍇��()
                    Case "15"
                        Mnu���y��I�⍇��()
                    Case "21"
                        Mnu���y�ݔ���()
                    Case "22"
                        Mnu���Y����()
                    Case "23"
                        Mnu���x����()
                    Case "24"
                        Mnu��Ɨ���()
                    Case "41"
                        Mnu�W���[�i���Ɖ�()

                    Case "99"
                        CMdiMain.Close()
                End Select
            End If
        End If

    End Sub

    Private Sub Mnu���ɐݒ�_�n�[�h1()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���ɐݒ�, , 0)


        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���ɐݒ�_�v���[��1()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���ɐݒ�, , 1)


        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���ɐݒ�_�n�[�h2()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���ɐݒ�, , 2)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���y�����o�ɐݒ�()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y�����o�ɐݒ�)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���y���ɒI���ݒ�()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���ɒI���ݒ�ݒ�)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���y�I�w��o�ɐݒ�()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y�I�w��o�ɐݒ�)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu�}�X�^�[�ݒ�()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.�}�X�^�[�ݒ�)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���y�I�⍇�������e�i���X()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y�I�⍇�������e�i���X)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���y�݌ɖ⍇��()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y�݌ɖ⍇��)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���y��I�⍇��()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y��I�⍇��)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���y�ݔ���()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y�ݔ���)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���Y����()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���Y����)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu���x����()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���x����)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu��Ɨ���()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��Ɨ���)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Mnu�W���[�i���Ɖ�()
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.�W���[�i���Ɖ�)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub
End Class

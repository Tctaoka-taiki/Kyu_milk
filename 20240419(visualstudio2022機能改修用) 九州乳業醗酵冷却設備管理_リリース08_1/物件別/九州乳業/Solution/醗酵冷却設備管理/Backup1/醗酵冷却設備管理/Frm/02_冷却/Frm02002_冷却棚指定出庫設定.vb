
Imports System.Data.Common

Public Class Frm02002_��p�I�w��o�ɐݒ�
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
    Dim int�J�����g�s As Integer = 0
    Private Sub Frm02002_��p�I�w��o�ɐݒ�_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        �q�ɏ��\��()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        �q�ɏ��\��()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Timer1.Stop()

        Try
            Dim dlg As New Dlg01005_�I�w��o�ɓo�^
            With dlg
                .m��ʃ��[�h = 1
                .ShowDialog()

            End With
            �q�ɏ��\��()

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Timer1.Stop()
        Try
            Dim dlg As New Dlg01005_�I�w��o�ɍ폜
            With dlg
                .m��ʃ��[�h = 1
                .ShowDialog()

            End With
            �q�ɏ��\��()

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Timer1.Stop()
        Try
            Dim dlg As New Dlg01005_�I�w��o�ɊJ�n
            With dlg
                .m��ʃ��[�h = 1
                .ShowDialog()

            End With
            �q�ɏ��\��()

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Timer1.Stop()
        Try
            Dim dlg As New Dlg01005_�I�w��o�ɒ��f
            With dlg
                .m��ʃ��[�h = 1
                .ShowDialog()

            End With
            �q�ɏ��\��()

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��p���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub �q�ɏ��\��()
        Me.dgv���Y�f�[�^.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("MAX(A.��) as ��")
                .gSubSelect("MAX(A.�A) as �A")
                .gSubSelect("MAX(A.�i) as �i")
                .gSubSelect("MAX(A.���b�gNo COLLATE Japanese_CS_AS_KS_WS) as ���b�gNo")
                .gSubSelect("MAX(A.�T���v��No) as �T���v��No")
                .gSubSelect("MAX(B.�i�햼) as �i�햼")
                .gSubSelect("MAX(A.�ܖ�����) as �ܖ�����")
                .gSubSelect("SUM(A.�����) as �N���[�g��")
                .gSubSelect("MAX(A.��p�J�n����) as �J�n����")
                .gSubSelect("MAX(B.�����p����) as ���莞��")
                .gSubSelect("MAX(A.�X�e�[�^�X) as �X�e�[�^�X")
                .gSubFrom("DN�g���b�L���O A")
                .gSubFrom("DM�i�� B")
                '---------------------------------
                '���y�q�ɓ��̃g���b�L���O��ΏۂƂ���
                '27:�݌ɒ�(---)
                '28:�o�׎w���m���ԁi�J�n�j
                '29,30:�o�ג�(�o�ɒ�)
                '31:�o��ST(����)
                .gSubWhere("(A.�X�e�[�^�X >= 27 AND A.�X�e�[�^�X <= 31)")
                .gSubWhere("A.�I�w��o�� = 1")
                '---------------------------------
                .gSubWhere("A.�i��CD = B.�i��CD")
                .gSubGroupBy("A.���j�b�gSEQ")
                .gSubOrderBy("��,�A,�i")

                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    Dim i As Integer = 0
                    While reader.Read
                        Me.dgv���Y�f�[�^.Rows.Add()
                        Me.dgv���Y�f�[�^.Item(0, i).Value = reader.GetValue(0) & "-" & reader.GetValue(1).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(2)
                        Me.dgv���Y�f�[�^.Item(1, i).Value = reader.GetValue(3)
                        Me.dgv���Y�f�[�^.Item(2, i).Value = reader.GetValue(4)
                        Me.dgv���Y�f�[�^.Item(3, i).Value = reader.GetValue(5)
                        Me.dgv���Y�f�[�^.Item(4, i).Value = Mid(reader.GetValue(6).ToString, 1, 10)
                        Me.dgv���Y�f�[�^.Item(5, i).Value = reader.GetValue(7)
                        Me.dgv���Y�f�[�^.Item(6, i).Value = reader.GetValue(8)
                        If reader.GetValue(9).ToString <> "" Then
                            Me.dgv���Y�f�[�^.Item(7, i).Value = reader.GetValue(9) & "��"
                        End If
                        Select Case reader.GetValue(10)
                            Case 27
                                Me.dgv���Y�f�[�^.Item(8, i).Value = ""
                            Case 28
                                Me.dgv���Y�f�[�^.Item(8, i).Value = "�J�n"
                            Case 29, 30
                                Me.dgv���Y�f�[�^.Item(8, i).Value = "�o�ɒ�"
                            Case 31
                                Me.dgv���Y�f�[�^.Item(8, i).Value = "����"
                        End Select
                        i += 1
                    End While

                End If
            End With
        Catch ex As Exception
        Finally
            Dim int�J�����g�s As Integer = 0
            Me.dgv���Y�f�[�^.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Dim int���O�y�[�W����敪 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        If Me.dgv���Y�f�[�^.Rows.Count < 0 Then
            Exit Sub
        End If


        If int���O�y�[�W����敪 = 0 Then
            int�J�����g�s = int�J�����g�s - 24
        Else
            int�J�����g�s = int�J�����g�s - 47
        End If

        If int�J�����g�s < 0 Then
            int�J�����g�s = 0

        ElseIf int�J�����g�s > Me.dgv���Y�f�[�^.Rows.Count - 1 Then
            int�J�����g�s = Me.dgv���Y�f�[�^.Rows.Count - 1

        End If

        Me.dgv���Y�f�[�^.CurrentCell = dgv���Y�f�[�^(0, int�J�����g�s)
        Me.dgv���Y�f�[�^.CurrentCell = Nothing

        int���O�y�[�W����敪 = 0
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If Me.dgv���Y�f�[�^.Rows.Count < 0 Then
            Exit Sub
        End If

        If int���O�y�[�W����敪 = 1 Then
            int�J�����g�s = int�J�����g�s + 24
        Else
            int�J�����g�s = int�J�����g�s + 47
        End If

        If int�J�����g�s > Me.dgv���Y�f�[�^.Rows.Count - 1 Then
            int�J�����g�s = Me.dgv���Y�f�[�^.Rows.Count - 1
        End If

        Me.dgv���Y�f�[�^.CurrentCell = dgv���Y�f�[�^(0, int�J�����g�s)
        Me.dgv���Y�f�[�^.CurrentCell = Nothing

        int���O�y�[�W����敪 = 1
    End Sub

End Class

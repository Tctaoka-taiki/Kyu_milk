
Imports System.Data.Common

Public Class Frm02001_��p�����o�ɐݒ�
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

    Private Sub Frm02001_��p�����o�ɐݒ�_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ��p���Y�i���()

        Me.Timer1.Start()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Me.Timer1.Stop()

        Try
            '
            Dim dlg As New Dlg01999_��p�o�ɐݒ�
            With dlg
                .m��ʃ��[�h = 0
                .btnF1.Enabled = False
                .ShowDialog()

            End With

            '��ʂ̍ĕ\��
            ��p���Y�i���()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Me.Timer1.Stop()

        Try
            '
            Dim dlg As New Dlg01999_��p�o�ɐݒ�
            With dlg
                .m��ʃ��[�h = 1
                .btnF1.Enabled = False
                .ShowDialog()

            End With

            '��ʂ̍ĕ\��
            ��p���Y�i���()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��p���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '��ʂ̍ĕ\��
        ��p���Y�i���()
    End Sub

    Private Sub ��p���Y�i���()
        Me.dgv���Y�f�[�^.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("MAX(B.�i�햼)")
                .gSubSelect("MAX(B.�����p����)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,��p�J�n����,GETDATE()))")
                .gSubSelect("MAX(A.�X�e�[�^�X)")
                .gSubSelect("MAX(A.�o�ɒ��f_��)")
                .gSubSelect("MAX(A.�o�Ɏw��)")
                .gSubSelect("Count(DISTINCT A.���j�b�gSEQ)")
                .gSubSelect("SUM(A.�����)")
                .gSubFrom("DN�g���b�L���O A")
                .gSubFrom("DM�i�� B")
                .gSubWhere("A.�X�e�[�^�X >= 27 ")
                .gSubWhere("A.�X�e�[�^�X <= 30 ")
                .gSubWhere("A.�i��CD = B.�i��CD")
                .gSubGroupBy("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubOrderBy("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        Me.dgv���Y�f�[�^.Rows.Add()
                        Me.dgv���Y�f�[�^.Item(0, i).Value = i + 1
                        Me.dgv���Y�f�[�^.Item(1, i).Value = reader.GetValue(0)
                        Me.dgv���Y�f�[�^.Item(2, i).Value = reader.GetValue(1)
                        Dim �����p���� As Integer = reader.GetValue(2)
                        Dim ��p�o�ߎ��� As Integer = reader.GetValue(3)
                        Me.dgv���Y�f�[�^.Item(3, i).Value = �����p���� & "��"
                        Me.dgv���Y�f�[�^.Item(4, i).Value = ��p�o�ߎ��� & "��"

                        Me.dgv���Y�f�[�^.Item(6, i).Value = "0"
                        Select Case reader.GetValue(4)
                            Case 27
                                If �����p���� > ��p�o�ߎ��� Then
                                    Me.dgv���Y�f�[�^.Item(5, i).Value = ""
                                Else
                                    Me.dgv���Y�f�[�^.Item(5, i).Value = "��p����"
                                    Me.dgv���Y�f�[�^.Item(6, i).Value = "1"
                                End If

                                If reader.GetValue(6) = 1 Then
                                    Me.dgv���Y�f�[�^.Item(5, i).Value = "�o�ɑ҂�"

                                End If

                            Case 28
                                Me.dgv���Y�f�[�^.Item(5, i).Value = "�o�ɑ҂�"
                            Case 29, 30
                                Me.dgv���Y�f�[�^.Item(5, i).Value = "�o�ɒ�"
                        End Select
                        If reader.GetValue(5) = 1 Then
                            Me.dgv���Y�f�[�^.Item(5, i).Value = "���f��"

                        End If
                        Me.dgv���Y�f�[�^.Item(7, i).Value = reader.GetValue(7)
                        Me.dgv���Y�f�[�^.Item(8, i).Value = reader.GetValue(8)
                        i += 1
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            Me.dgv���Y�f�[�^.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub dgv���Y�f�[�^_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv���Y�f�[�^.DoubleClick
        Me.Timer1.Stop()

        Try
            If Me.dgv���Y�f�[�^.Item(5, Me.dgv���Y�f�[�^.CurrentRow.Index).Value = "�o�ɑ҂�" Then
                Dim dlg As New Dlg01999_��p�o�ɐݒ�
                With dlg
                    .m��ʃ��[�h = 1    '�o�ɒ��f�ݒ胂�[�h
                    .btnF1.Enabled = False
                    .txt���b�gNo.Text = Me.dgv���Y�f�[�^.Item(1, Me.dgv���Y�f�[�^.CurrentRow.Index).Value
                    .ShowDialog()
                End With
            Else
                Dim dlg As New Dlg01999_��p�o�ɐݒ�
                With dlg
                    .m��ʃ��[�h = 0
                    .txt���b�gNo.Text = Me.dgv���Y�f�[�^.Item(1, Me.dgv���Y�f�[�^.CurrentRow.Index).Value
                    .lbl�i�햼.Text = Me.dgv���Y�f�[�^.Item(2, Me.dgv���Y�f�[�^.CurrentRow.Index).Value
                    .lbl���蔮�y����.Text = Me.dgv���Y�f�[�^.Item(3, Me.dgv���Y�f�[�^.CurrentRow.Index).Value
                    .lbl���y�o�ߎ���.Text = Me.dgv���Y�f�[�^.Item(4, Me.dgv���Y�f�[�^.CurrentRow.Index).Value
                    .btnF1.Enabled = True
                    .ShowDialog()

                End With
            End If
        Catch ex As Exception
        Finally
            '��ʂ̍ĕ\��
            ��p���Y�i���()
            Me.Timer1.Start()
        End Try
    End Sub
End Class

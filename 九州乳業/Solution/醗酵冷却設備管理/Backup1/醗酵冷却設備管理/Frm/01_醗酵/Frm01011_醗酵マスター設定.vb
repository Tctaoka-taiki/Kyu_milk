
Imports System.Data.Common

Public Class Frm01011_���y�}�X�^�[�ݒ�
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

    Private Sub Frm01011_���y�}�X�^�[�ݒ�_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb���i�敪.Text = "�n�[�h"
        mSub�i����\��()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim dlg As New Dlg01999_�i��o�^
            With dlg
                .cmb���i�敪.SelectedIndex = Me.cmb���i�敪.SelectedIndex
                .ShowDialog()

            End With
            mSub�i����\��()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Try
            Dim dlg As New Dlg01999_�i��폜
            With dlg
                .ShowDialog()

            End With
            mSub�i����\��()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Try
            Dim dlg As New Dlg01999_�i��C��
            With dlg
                .ShowDialog()

            End With
            mSub�i����\��()

        Catch ex As Exception
        Finally

        End Try
    End Sub


    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub mSub�i����\��()
        Me.dgv���Y�f�[�^.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("�i��CD")
                .gSubSelect("�i�햼")
                .gSubSelect("���蔮�y����")
                .gSubSelect("�����p����")
                .gSubFrom("DM�i��")
                .gSubWhere("���i�敪", Me.cmb���i�敪.SelectedIndex, , , , , , , False)
                .gSubOrderBy("�i��CD")

                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    Dim i As Integer = 0
                    While reader.Read
                        Me.dgv���Y�f�[�^.Rows.Add()
                        Me.dgv���Y�f�[�^.Item(0, i).Value = reader.GetValue(0)
                        Me.dgv���Y�f�[�^.Item(1, i).Value = reader.GetValue(1)
                        Me.dgv���Y�f�[�^.Item(2, i).Value = reader.GetValue(2) & "��"
                        Me.dgv���Y�f�[�^.Item(3, i).Value = reader.GetValue(3) & "��"
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

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Dim intSelectIDX As Integer = Me.cmb���i�敪.SelectedIndex
        If intSelectIDX = 1 Then
            intSelectIDX = 0
        Else
            intSelectIDX = 1
        End If
        Me.cmb���i�敪.SelectedIndex = intSelectIDX

    End Sub

    Private Sub cmb���i�敪_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb���i�敪.SelectedIndexChanged
        mSub�i����\��()
    End Sub

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        Dim intSelectIDX As Integer = Me.cmb���i�敪.SelectedIndex
        If intSelectIDX = 1 Then
            If CMsg.gMsg_YesNo("�}�X�^�[���X�g�i�v���[���j���o�͂��Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            '�}�X�^�[�f�[�^
            With New CSqlEx
                .gSubSelect("�i��CD as �i��CD")
                .gSubSelect("�i�햼 as �i�햼")
                .gSubSelect("���蔮�y���� as ���蔮�y����")
                .gSubSelect("�����p���� as �����p����")
                .gSubFrom("DM�i��")
                .gSubWhere("���i�敪 = 1")
                .gSubOrderBy("�i��CD")

                CMdiMain.���[�o��(New �}�X�^�[�ݒ�, "***�}�X�^�[�ݒ�i�v���[���j***", .gSQL���̎擾)
            End With
        Else
            If CMsg.gMsg_YesNo("�}�X�^�[���X�g�i�n�[�h�j���o�͂��Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            '�}�X�^�[�f�[�^
            With New CSqlEx
                .gSubSelect("�i��CD as �i��CD")
                .gSubSelect("�i�햼 as �i�햼")
                .gSubSelect("���蔮�y���� as ���蔮�y����")
                .gSubSelect("�����p���� as �����p����")
                .gSubFrom("DM�i��")
                .gSubWhere("���i�敪 = 0")
                .gSubOrderBy("�i��CD")

                CMdiMain.���[�o��(New �}�X�^�[�ݒ�, "***�}�X�^�[�ݒ�i�n�[�h�j***", .gSQL���̎擾)
            End With
        End If
    End Sub
End Class

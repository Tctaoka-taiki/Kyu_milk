
Imports System.Data.Common
Public Class Frm02011_��p�I�⍇�������e�i���X
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
    Private Sub Frm02011_��p�I�⍇�������e�i���X_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        �q�ɏ��\��()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Dim �\���s���`�F�b�N As Integer
        Dim �\���Z�� As String
        Dim �s�� As Integer

        Try
            For �\���s���`�F�b�N = 0 To Me.dgv���Y�f�[�^.Rows.Count
                If Me.dgv���Y�f�[�^.Rows(�\���s���`�F�b�N).Displayed Then
                    �\���Z�� = Me.dgv���Y�f�[�^.Item(0, �\���s���`�F�b�N).Value
                    Exit For
                End If
            Next
            Dim dlg As New Dlg01999_�I�����e�i���X�o�^
            With dlg
                .m��ʃ��[�h = 1
                .ShowDialog()

            End With
            �q�ɏ��\��()

            Me.dgv���Y�f�[�^.FirstDisplayedScrollingRowIndex = �\���s���`�F�b�N

            For �s�� = 0 To Me.dgv���Y�f�[�^.Rows.Count
                If �\���Z�� = Me.dgv���Y�f�[�^.Item(0, �s��).Value Then
                    Exit For
                End If
            Next

            If �s�� - 1 = �\���s���`�F�b�N Then
                Me.dgv���Y�f�[�^.FirstDisplayedScrollingRowIndex = �\���s���`�F�b�N + 1
            Else
                Me.dgv���Y�f�[�^.FirstDisplayedScrollingRowIndex = �\���s���`�F�b�N
            End If

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click

        Dim �\���s���`�F�b�N As Integer
        Dim �\���Z�� As String
        Dim �s�� As Integer

        Try
            For �\���s���`�F�b�N = 0 To Me.dgv���Y�f�[�^.Rows.Count
                If Me.dgv���Y�f�[�^.Rows(�\���s���`�F�b�N).Displayed Then
                    �\���Z�� = Me.dgv���Y�f�[�^.Item(0, �\���s���`�F�b�N).Value
                    Exit For
                End If
            Next
            Dim dlg As New Dlg01999_�I�����e�i���X�폜
            With dlg
                .m��ʃ��[�h = 1
                .ShowDialog()

            End With
            �q�ɏ��\��()

            Me.dgv���Y�f�[�^.FirstDisplayedScrollingRowIndex = �\���s���`�F�b�N

            For �s�� = 0 To Me.dgv���Y�f�[�^.Rows.Count
                If �\���Z�� = Me.dgv���Y�f�[�^.Item(0, �s��).Value Then
                    Exit For
                End If
            Next

            If �s�� + 1 = �\���s���`�F�b�N Then
                Me.dgv���Y�f�[�^.FirstDisplayedScrollingRowIndex = �\���s���`�F�b�N - 1
            Else
                Me.dgv���Y�f�[�^.FirstDisplayedScrollingRowIndex = �\���s���`�F�b�N
            End If

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Dim �\���s���`�F�b�N As Integer
        Try
            For �\���s���`�F�b�N = 0 To Me.dgv���Y�f�[�^.Rows.Count
                If Me.dgv���Y�f�[�^.Rows(�\���s���`�F�b�N).Displayed Then
                    Exit For
                End If
            Next

            Dim dlg As New Dlg01999_�I�����e�i���X�C��
            With dlg
                .m��ʃ��[�h = 1
                .ShowDialog()

            End With
            �q�ɏ��\��()

            Me.dgv���Y�f�[�^.FirstDisplayedScrollingRowIndex = �\���s���`�F�b�N

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Try
            �֎~�I�ݒ�("      ")
        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub �֎~�I�ݒ�(ByVal �I�ԍ� As String)
        Dim �\���s���`�F�b�N As Integer
        For �\���s���`�F�b�N = 0 To Me.dgv���Y�f�[�^.Rows.Count
            If Me.dgv���Y�f�[�^.Rows(�\���s���`�F�b�N).Displayed Then
                Exit For
            End If
        Next
        Dim dlg As New Dlg01999_�I�����e�i���X�֎~�I
        With dlg
            .m��ʃ��[�h = 1
            .txt��.Text = �I�ԍ�.Substring(0, 1)
            .txt�A.Text = �I�ԍ�.Substring(2, 2)
            .txt�i.Text = �I�ԍ�.Substring(5, 1)
            .ShowDialog()
        End With
        �q�ɏ��\��()

        Me.dgv���Y�f�[�^.FirstDisplayedScrollingRowIndex = �\���s���`�F�b�N

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
                .gSubSelect("B.�i��CD")
                .gSubSelect("MAX(A.��) as ��")
                .gSubSelect("MAX(A.�A) as �A")
                .gSubSelect("MAX(A.�i) as �i")
                .gSubSelect("MAX(A.���b�gNo COLLATE Japanese_CS_AS_KS_WS) as ���b�gNo")
                .gSubSelect("MAX(A.�T���v��No) as �T���v��No")
                .gSubSelect("MAX(B.�i�햼) as �i�햼")
                .gSubSelect("SUM(A.�����) as �N���[�g��")
                .gSubSelect("MAX(A.�ܖ�����) as �ܖ�����")
                .gSubSelect("MAX(A.��p�J�n����) as �J�n����")
                .gSubSelect("MAX(B.�����p����) as ���莞��")
                .gSubSelect("MAX(DATEDIFF(MINUTE,A.��p�J�n����,GETDATE())) as �o�ߎ���")
                .gSubFrom("DN�g���b�L���O A")
                .gSubFrom("DM�i�� B")
                '---------------------------------
                '��p�q�ɓ��̃g���b�L���O��ΏۂƂ���
                .gSubWhere("A.�X�e�[�^�X >= 27 ")
                .gSubWhere("A.�X�e�[�^�X <= 29 ")
                '---------------------------------
                .gSubWhere("A.�i��CD = B.�i��CD")
                .gSubGroupBy("B.�i��CD,A.���j�b�gSEQ")

                Dim str�g���b�L���O��SQL As String = .gSQL���̎擾
                .gSubClearSQL()
                .gSubSelect("A.��")
                .gSubSelect("A.�A")
                .gSubSelect("A.�i")
                .gSubSelect("B.���b�gNo")
                .gSubSelect("B.�T���v��No")
                .gSubSelect("B.�i�햼")
                .gSubSelect("B.�ܖ�����")
                .gSubSelect("B.�N���[�g��")
                .gSubSelect("B.�J�n����")
                .gSubSelect("B.���莞��")
                .gSubSelect("B.�o�ߎ���")
                .gSubSelect("A.�I�敪")
                .gSubSelect("B.�i��CD")
                .gSubFrom("DM�I A LEFT JOIN (" & str�g���b�L���O��SQL & ")B ON A.��=B.�� AND A.�A=B.�A AND A.�i=B.�i")
                .gSubWhere("A.�q�ɋ敪", 1, , , , , , , False)
                .gSubWhere("A.�I�敪<>1")   '�X�e�[�V�����͑ΏۊO
                .gSubWhere("A.�I�敪<>3")   '�I�����͑ΏۊO
                .gSubOrderBy("IIF(B.�i��CD IS NOT NULL, 0, 1),B.�i��CD,�J�n����,��,�A,�i")

                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    '���v�\���s�̍쐬
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
                        If reader.GetValue(10).ToString <> "" Then
                            Me.dgv���Y�f�[�^.Item(8, i).Value = reader.GetValue(10) & "��"
                        End If
                        If reader.GetValue(11) = 2 Then  '�֎~�I�i�Ԏ����]�j
                            Me.dgv���Y�f�[�^.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        End If
                        i += 1
                    End While

                End If
            End With
        Catch ex As Exception
        Finally
            int�J�����g�s = 0
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

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        If Me.dgv���Y�f�[�^.Rows.Count <= 0 Then
            CMsg.gMsg_����("��񂪂���܂���B")
            Exit Sub
        End If
        If CMsg.gMsg_YesNo("�I�݌Ɏ��у��X�g���o�͂��Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '�O���b�h�f�[�^������e�[�u���ɓo�^
        Dim i As Integer = 0
        For i = 0 To Me.dgv���Y�f�[�^.Rows.Count - 1
            'INSERT ����
            Try
                With New CSql
                    .gSubClearSQL()
                    .pSQL�擾�^�C�v = CSql.SQL_TYPE.SQL_INSERT
                    .p�e�[�u���� = "DP���"
                    .gSubColumnValue("�I�Ԓn", Me.dgv���Y�f�[�^.Item(0, i).Value.ToString, True)
                    If Me.dgv���Y�f�[�^.Item(1, i).Value.ToString <> "" Then
                        .gSubColumnValue("���b�gNo", Me.dgv���Y�f�[�^.Item(1, i).Value.ToString, True)
                        .gSubColumnValue("�T���v��No", Me.dgv���Y�f�[�^.Item(2, i).Value.ToString, False)
                        .gSubColumnValue("�i�햼", Me.dgv���Y�f�[�^.Item(3, i).Value.ToString, True)
                        .gSubColumnValue("�ܖ�����", Me.dgv���Y�f�[�^.Item(4, i).Value.ToString, True)
                        .gSubColumnValue("�����", Me.dgv���Y�f�[�^.Item(5, i).Value.ToString, False)
                        .gSubColumnValue("��p�J�n����", Me.dgv���Y�f�[�^.Item(6, i).Value.ToString, True)
                        .gSubColumnValue("�����p����", Me.dgv���Y�f�[�^.Item(7, i).Value.ToString, True)
                        .gSubColumnValue("��p�o�ߎ���", Me.dgv���Y�f�[�^.Item(8, i).Value.ToString, True)
                    End If


                    If Not CUsrctl.gDp.gBlnExecute(.gSQL���̎擾, New System.Data.SqlClient.SqlCommand) Then
                        Exit Sub
                    End If
                End With

            Catch ex As Exception
            Finally
            End Try
        Next

        '����f�[�^
        With New CSqlEx
            .gSubSelect("A.�I�Ԓn")
            .gSubSelect("A.���b�gNo")
            .gSubSelect("A.�T���v��No")
            .gSubSelect("A.�i�햼")
            .gSubSelect("A.�ܖ�����")
            .gSubSelect("A.�����")
            .gSubSelect("A.��p�J�n����")
            .gSubSelect("A.�����p����")
            .gSubSelect("A.��p�o�ߎ���")
            .gSubFrom("DP��� A")
            .gSubOrderBy("�Ǘ�No")

            CMdiMain.���[�o��(New �I�݌Ɏ���_��p, "***�I�݌Ɏ��сi��p�j***", .gSQL���̎擾, "")
        End With

        ''����f�[�^�̍폜
        Try
            With New CSql
                .gSubClearSQL()
                .pSQL�擾�^�C�v = CSql.SQL_TYPE.SQL_DELETE
                .p�e�[�u���� = "DP���"
                If Not CUsrctl.gDp.gBlnExecute(.gSQL���̎擾, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try

    End Sub
    Private Sub dgv���Y�f�[�^_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv���Y�f�[�^.CellDoubleClick
        Dim �s�� As Integer = e.RowIndex
        Dim �I�ԍ� As String = dgv���Y�f�[�^(0, e.RowIndex).Value.ToString()

        Try
            �֎~�I�ݒ�(�I�ԍ�)
        Catch ex As Exception
        Finally

        End Try
    End Sub
End Class

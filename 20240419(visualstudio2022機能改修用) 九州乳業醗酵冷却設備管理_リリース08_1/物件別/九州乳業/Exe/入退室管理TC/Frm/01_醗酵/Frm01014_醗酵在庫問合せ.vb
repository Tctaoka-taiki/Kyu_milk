
Imports System.Data.Common
Public Class Frm01014_���y�݌ɖ⍇��
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
    Private Sub Frm01002_���y�����o�ɐݒ�_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl���b�gNo.Text = ""
        Me.lbl�i�햼.Text = ""

    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim �Ώەi��CD As String = ""
            Dim �Ώۃ��b�gNo As String = ""

            Dim dlg As New Dlg01003_���i�\���ݒ�
            With dlg
                .ShowDialog()
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    �Ώەi��CD = .txt�i��.Text
                    �Ώۃ��b�gNo = .txt���b�gNo.Text
                    Me.lbl���b�gNo.Text = �Ώۃ��b�gNo
                    Me.lbl�i�햼.Text = .lbl�i��.Text
                    '��ʂ̍ĕ\��
                    ���y���Y�i���(�Ώەi��CD, �Ώۃ��b�gNo)
                End If
            End With

        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub ���y���Y�i���(ByVal �i��CD As String, ByVal ���b�gNo As String)
        Me.dgv���Y�f�[�^.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("MAX(A.���b�gNo COLLATE Japanese_CS_AS_KS_WS)")
                .gSubSelect("MAX(A.�T���v��No)")
                .gSubSelect("MAX(B.�i�햼)")
                .gSubSelect("MAX(A.��)")
                .gSubSelect("MAX(A.�A)")
                .gSubSelect("MAX(A.�i)")
                .gSubSelect("SUM(A.�����)")
                .gSubSelect("MAX(B.���蔮�y����)")
                .gSubSelect("MAX(DATEDIFF(MINUTE,���y�J�n����,GETDATE()))")
                .gSubFrom("DN�g���b�L���O A")
                .gSubFrom("DM�i�� B")
                '---------------------------------
                '���y�q�ɓ��̃g���b�L���O��ΏۂƂ���
                .gSubWhere("A.�X�e�[�^�X >= 6 ")
                .gSubWhere("A.�X�e�[�^�X <= 10 ")
                '---------------------------------
                .gSubWhere("A.�i��CD = B.�i��CD")
                .gSubWhere("A.�i��CD", �i��CD)

                .gSubWhere�����܂�����("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS", ���b�gNo)
                .gSubGroupBy("A.���j�b�gSEQ")
                .gSubOrderBy("MAX(A.���b�gNo COLLATE Japanese_CS_AS_KS_WS)")
                .gSubOrderBy("MAX(A.�T���v��No)")

                Dim i As Integer = 1
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    '���v�\���s�̍쐬
                    Dim ���v����� As Integer = 0
                    Me.dgv���Y�f�[�^.Rows.Add()

                    While reader.Read
                        Me.dgv���Y�f�[�^.Rows.Add()
                        Me.dgv���Y�f�[�^.Item(0, i).Value = i
                        Me.dgv���Y�f�[�^.Item(1, i).Value = reader.GetValue(0)
                        Me.dgv���Y�f�[�^.Item(2, i).Value = reader.GetValue(1)
                        Me.dgv���Y�f�[�^.Item(3, i).Value = reader.GetValue(2)
                        Me.dgv���Y�f�[�^.Item(4, i).Value = reader.GetValue(3) & "-" & reader.GetValue(4).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(5)
                        Me.dgv���Y�f�[�^.Item(5, i).Value = reader.GetValue(6)
                        ���v����� += reader.GetValue(6)
                        Dim ���蔮�y���� As Integer = reader.GetValue(7)
                        Dim ���y�o�ߎ��� As Integer = reader.GetValue(8)
                        Me.dgv���Y�f�[�^.Item(6, i).Value = ���蔮�y���� & "��"
                        Me.dgv���Y�f�[�^.Item(7, i).Value = ���y�o�ߎ��� & "��"
                        i += 1
                    End While

                    If i > 1 Then
                        Me.dgv���Y�f�[�^.Rows(0).DefaultCellStyle.BackColor = Color.Yellow
                        Me.dgv���Y�f�[�^.Item(5, 0).Value = ���v�����
                    Else
                        '�f�[�^�������ꍇ�́A�N���A����
                        CMsg.gMsg_���("�Y���f�[�^������܂���B")
                        Me.dgv���Y�f�[�^.Rows.Clear()
                    End If

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

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        If Me.dgv���Y�f�[�^.Rows.Count <= 0 Then
            CMsg.gMsg_����("��񂪂���܂���B")
            Exit Sub
        End If
        If CMsg.gMsg_YesNo("�݌Ɏ��у��X�g���o�͂��Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '�O���b�h�f�[�^������e�[�u���ɓo�^
        Dim i As Integer = 0
        '���v�l���͊܂߂Ȃ�
        For i = 1 To Me.dgv���Y�f�[�^.Rows.Count - 1
            'INSERT ����
            Try
                With New CSql
                    .gSubClearSQL()
                    .pSQL�擾�^�C�v = CSql.SQL_TYPE.SQL_INSERT
                    .p�e�[�u���� = "DP���"
                    .gSubColumnValue("���b�gNo", Me.dgv���Y�f�[�^.Item(1, i).Value, True)
                    .gSubColumnValue("�T���v��No", Me.dgv���Y�f�[�^.Item(2, i).Value, False)
                    .gSubColumnValue("�i�햼", Me.dgv���Y�f�[�^.Item(3, i).Value, True)
                    .gSubColumnValue("�I�Ԓn", Me.dgv���Y�f�[�^.Item(4, i).Value, True)
                    .gSubColumnValue("�����", Me.dgv���Y�f�[�^.Item(5, i).Value, False)
                    .gSubColumnValue("���蔮�y����", Me.dgv���Y�f�[�^.Item(6, i).Value, True)
                    .gSubColumnValue("���y�o�ߎ���", Me.dgv���Y�f�[�^.Item(7, i).Value, True)

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
            .gSubSelect("A.���b�gNo")
            .gSubSelect("A.�T���v��No")
            .gSubSelect("A.�i�햼")
            .gSubSelect("A.�I�Ԓn")
            .gSubSelect("A.�����")
            .gSubSelect("A.���蔮�y����")
            .gSubSelect("A.���y�o�ߎ���")
            .gSubFrom("DP��� A")
            .gSubOrderBy("�Ǘ�No")

            Dim str���� As String = "�i��CD:" & Me.lbl�i�햼.Text.PadRight(20, " "c) & "���b�gNo:" & Me.lbl���b�gNo.Text.PadRight(10, " "c) & "�@�N���[�g���v:" & Me.dgv���Y�f�[�^.Item(5, 0).Value
            CMdiMain.���[�o��(New �݌Ɏ���_���y, "***�݌Ɏ��сi���y�j***", .gSQL���̎擾, str����)
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

End Class


Imports System.Data.Common
Public Class Frm01022_���Y���і⍇��
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
    Private Sub Frm01022_���Y���і⍇��_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl�ܖ�����.Text = ""
        Me.lbl�i�햼.Text = ""

    End Sub


    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim �Ώەi��CD As String = ""
            Dim �Ώۏܖ����� As String = ""

            Dim dlg As New Dlg01031_���Y�⍇�ݒ�
            With dlg
                .ShowDialog()
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    �Ώەi��CD = .txt�i��.Text
                    If .txt�ܖ������N.Text <> "" And .txt�ܖ�������.Text <> "" And .txt�ܖ�������.Text <> "" Then
                        �Ώۏܖ����� = .txt�ܖ������N.Text & "/" & .txt�ܖ�������.Text & "/" & .txt�ܖ�������.Text
                    End If
                    Me.lbl�ܖ�����.Text = �Ώۏܖ�����
                    Me.lbl�i�햼.Text = .txt�i��.Text
                    '��ʂ̍ĕ\��
                    ���y���Y�i���(�Ώەi��CD, �Ώۏܖ�����)
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        If CMsg.gMsg_YesNo("���Y���у��X�g���o�͂��Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '���Y����
        With New CSqlEx
            .gSubSelect("CONVERT(VARCHAR,MAX(A.���y�J�n����),111) as ���y�J�n����")
            .gSubSelect("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS as ���b�gNo")
            .gSubSelect("A.�T���v��No as �T���v��No")
            .gSubSelect("MAX(A.�i��CD) as �i��CD")
            .gSubSelect("MAX(A.�i�햼) as �i�햼")
            .gSubSelect("SUM(A.�����) as �����")
            .gSubFrom("DJ�g���b�L���O A")
            If Me.lbl�i�햼.Text <> "" Then
                .gSubWhere("A.�i��CD", Me.lbl�i�햼.Text)

            End If
            If Me.lbl�ܖ�����.Text <> "" Then
                .gSubWhere("A.�ܖ�����", Me.lbl�ܖ�����.Text)

            End If
            .gSubGroupBy("A.���b�gNo")
            .gSubGroupBy("A.�T���v��No")
            .gSubOrderBy("MAX(A.���y�J�n����)")
            .gSubOrderBy("���b�gNo")
            .gSubOrderBy("�T���v��No")

            Dim str���� As String = "�i��CD:" & Me.lbl�i�햼.Text.PadRight(20, " "c) & "�ܖ�����:" & Me.lbl�ܖ�����.Text
            CMdiMain.���[�o��(New ���Y����, "***���Y����***", .gSQL���̎擾, str����)
        End With
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub ���y���Y�i���(ByVal �i��CD As String, ByVal �ܖ����� As String)
        Me.dgv���Y�f�[�^.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("CONVERT(VARCHAR,MAX(A.���y�J�n����),111) as ���y�J�n����")
                .gSubSelect("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("A.�T���v��No")
                .gSubSelect("MAX(A.�i�햼)")
                .gSubSelect("SUM(A.�����)")
                .gSubFrom("DJ�g���b�L���O A")
                If �i��CD <> "" Then
                    .gSubWhere("A.�i��CD", �i��CD)

                End If
                If �ܖ����� <> "" Then
                    .gSubWhere("A.�ܖ�����", �ܖ�����)

                End If
                .gSubGroupBy("A.���b�gNo  COLLATE Japanese_CS_AS_KS_WS")
                .gSubGroupBy("A.�T���v��No")
                .gSubOrderBy("���y�J�n����")
                .gSubGroupBy("���y�J�n����")
                .gSubOrderBy("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubOrderBy("A.�T���v��No")

                Dim i As Integer = 1
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    '���v�\���s�̍쐬
                    Dim ���v����� As Integer = 0
                    Me.dgv���Y�f�[�^.Rows.Add()

                    While reader.Read
                        Me.dgv���Y�f�[�^.Rows.Add()
                        Me.dgv���Y�f�[�^.Item(0, i).Value = i
                        Me.dgv���Y�f�[�^.Item(1, i).Value = reader.GetValue(0)
                        'Me.dgv���Y�f�[�^.Item(1, i).Value = Mid(reader.GetValue(0).ToString, 1, 10)
                        Me.dgv���Y�f�[�^.Item(2, i).Value = reader.GetValue(1)
                        Me.dgv���Y�f�[�^.Item(3, i).Value = reader.GetValue(2)
                        Me.dgv���Y�f�[�^.Item(4, i).Value = reader.GetValue(3)
                        Me.dgv���Y�f�[�^.Item(5, i).Value = reader.GetValue(4)
                        ���v����� += reader.GetValue(4)
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
        If Me.dgv���Y�f�[�^.Rows.Count <= 0 Then
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
        If Me.dgv���Y�f�[�^.Rows.Count <= 0 Then
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


Imports System.Data.Common
Public Class Frm00003_���y���ݔ���
    '#####################################################################################
    '�^
    '#####################################################################################

    '#####################################################################################
    '�����o�ϐ�
    '#####################################################################################
    Dim dbl���y�����x�X�� As Double = CUtil.�ݒ�֘A.�ݒ蕶����Ǎ�("���y�����x�X��", 1)
    Dim dbl���y�����x�ؕ� As Double = CUtil.�ݒ�֘A.�ݒ蕶����Ǎ�("���y�����x�ؕ�", 0)
    Dim dbl�}�⎺���x�X�� As Double = CUtil.�ݒ�֘A.�ݒ蕶����Ǎ�("�}�⎺���x�X��", 1)
    Dim dbl�}�⎺���x�ؕ� As Double = CUtil.�ݒ�֘A.�ݒ蕶����Ǎ�("�}�⎺���x�ؕ�", 0)
    Dim dbl��p�����x�X�� As Double = CUtil.�ݒ�֘A.�ݒ蕶����Ǎ�("��p�����x�X��", 1)
    Dim dbl��p�����x�ؕ� As Double = CUtil.�ݒ�֘A.�ݒ蕶����Ǎ�("��p�����x�ؕ�", 0)

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

    Private Sub Frm00002_�ݔ���_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To 17
            dgv�ݔ���.Rows.Add()
        Next

        For i = 0 To 2
            dgv�ݔ��󋵋���.Rows.Add()
            dgv�ݔ��󋵋���(0, i).Value = i + 21
            dgv�ݔ��󋵋���(1, i).Value = str�ݔ�����(i + 10)
        Next


        dgv�ݔ���.CurrentCell = Nothing
        dgv�ݔ��󋵋���.CurrentCell = Nothing
        Me.cmb���C��.Text = "�v���[���P�E�n�[�h�Q"
        �ݔ��󋵍X�V()
        Timer1.Interval = 2000
        Timer1.Start()

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Timer1.Stop()

            Dim dlg As New Dlg01999_�g���b�L���O�폜
            With dlg
                .m��ʃ��[�h = 0
                .ShowDialog()
            End With

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Dim intSelectIDX As Integer = Me.cmb���C��.SelectedIndex
        If intSelectIDX = 1 Then
            intSelectIDX = 0
        Else
            intSelectIDX += 1
        End If
        Me.cmb���C��.SelectedIndex = intSelectIDX

    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y���C�����j���[)


        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        �ݔ��󋵍X�V()
    End Sub

    Private Sub cmb���C��_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb���C��.SelectedIndexChanged

        �ݔ��󋵍X�V()
    End Sub

    Private Sub �ݔ��󋵍X�V()
        Dim �f�o�C�XOFFSET As Integer
        Dim �������C�� As Integer = 0

        Try

            Select Case Me.cmb���C��.Text
                Case "�n�[�h�P"
                    Dim n As Integer
                    For n = 9 To 17
                        Me.dgv�ݔ���.Item(0, n).Value = ""
                        Me.dgv�ݔ���.Item(1, n).Value = ""
                        Me.dgv�ݔ���.Item(2, n).Value = ""
                        Me.dgv�ݔ���.Item(3, n).Value = ""
                        Me.dgv�ݔ���.Item(9, n).Value = ""
                    Next
                    �f�o�C�XOFFSET = 6000
                    �������C�� = 0
                    Dim i As Integer = 0
                    For i = 0 To 8
                        dgv�ݔ���(0, i).Value = i + 1
                        dgv�ݔ���(1, i).Value = str�ݔ�����(i + 1)
                    Next
                    For i = 0 To 17
                        Me.dgv�ݔ���.Item(4, i).Value = ""
                        Me.dgv�ݔ���.Item(5, i).Value = ""
                        Me.dgv�ݔ���.Item(6, i).Value = ""
                        Me.dgv�ݔ���.Item(7, i).Value = ""
                        Me.dgv�ݔ���.Item(8, i).Value = ""
                        Me.dgv�ݔ���.Item(9, i).Value = ""
                    Next
                    �\������(�f�o�C�XOFFSET, �������C��, 0)
                Case "�v���[���P�E�n�[�h�Q"
                    �f�o�C�XOFFSET = 6004
                    �������C�� = 1
                    Dim i As Integer = 0
                    For i = 0 To 8
                        dgv�ݔ���(0, i).Value = i + 11
                        dgv�ݔ���(1, i).Value = str�ݔ�����(i + 1)
                    Next
                    For i = 0 To 8
                        Me.dgv�ݔ���.Item(4, i).Value = ""
                        Me.dgv�ݔ���.Item(5, i).Value = ""
                        Me.dgv�ݔ���.Item(6, i).Value = ""
                        Me.dgv�ݔ���.Item(7, i).Value = ""
                        Me.dgv�ݔ���.Item(8, i).Value = ""
                        Me.dgv�ݔ���.Item(9, i).Value = ""
                    Next
                    �\������(�f�o�C�XOFFSET, �������C��, 0)
                    �f�o�C�XOFFSET = 6010
                    �������C�� = 2
                    i = 0
                    For i = 0 To 8
                        dgv�ݔ���(0, i + 9).Value = i + 31
                        dgv�ݔ���(1, i + 9).Value = str�ݔ�����(i + 1)
                    Next
                    For i = 9 To 17
                        Me.dgv�ݔ���.Item(4, i).Value = ""
                        Me.dgv�ݔ���.Item(5, i).Value = ""
                        Me.dgv�ݔ���.Item(6, i).Value = ""
                        Me.dgv�ݔ���.Item(7, i).Value = ""
                        Me.dgv�ݔ���.Item(8, i).Value = ""
                        Me.dgv�ݔ���.Item(9, i).Value = ""
                    Next
                    �\������(�f�o�C�XOFFSET, �������C��, 9)
                    'Case "�v���[���P"
                    '    �f�o�C�XOFFSET = 6004
                    '    �������C�� = 1
                    '    Dim i As Integer = 0
                    '    For i = 0 To 8
                    '        dgv�ݔ���(0, i).Value = i + 11
                    '        dgv�ݔ���(1, i).Value = str�ݔ�����(i + 1)
                    '    Next
                    'Case "�n�[�h�Q"
                    '    �f�o�C�XOFFSET = 6010
                    '    �������C�� = 2
                    '    Dim i As Integer = 0
                    '    For i = 0 To 8
                    '        dgv�ݔ���(0, i).Value = i + 31
                    '        dgv�ݔ���(1, i).Value = str�ݔ�����(i + 1)
                    '    Next
            End Select



            '�ݔ����x�\��
            lbl���y�q�ɉ��x.Text = Format(Int((Dbl���x�f�[�^�擾(0, 6009) - dbl���y�����x�ؕ�) / dbl���y�����x�X�� * 10) / 10, "0.0")
            lbl��p�q�ɉ��x.Text = Format(Int((Dbl���x�f�[�^�擾(1, 6009) - dbl��p�����x�ؕ�) / dbl��p�����x�X�� * 10) / 10, "0.0")
            lbl�}�⎺���x.Text = Format(Int((Dbl���x�f�[�^�擾(1, 6010) - dbl�}�⎺���x�ؕ�) / dbl�}�⎺���x�X�� * 10) / 10, "0.0")

        Catch ex As Exception

        End Try

    End Sub
    Private Sub �\������(ByVal �f�o�C�XOFFSET As Integer, ByVal �������C�� As Integer, ByVal �J�n�s�� As Integer)
        '�i�ϋ@
        �M�����X�V_���C����(0, �f�o�C�XOFFSET + 1, 0, �J�n�s��)
        �׏��X�V_���C����(0, �f�o�C�XOFFSET + 1, 2, 0, �J�n�s��)

        '�R���x��
        �M�����X�V_���C����(0, �f�o�C�XOFFSET + 2, 1, �J�n�s��)

        �׏��X�V_���C����(0, �f�o�C�XOFFSET + 2, 4, 3, �J�n�s��)
        �׏��X�V_���C����(0, �f�o�C�XOFFSET + 2, 3, 4, �J�n�s��)
        �׏��X�V_���C����(0, �f�o�C�XOFFSET + 2, 2, 5, �J�n�s��)

        '����ST
        �M�����X�V_���C����(0, �f�o�C�XOFFSET + 3, 6, �J�n�s��)
        �M�����X�V_���C����(0, �f�o�C�XOFFSET + 3, 7, �J�n�s��)
        �M�����X�V_���C����(0, �f�o�C�XOFFSET + 3, 8, �J�n�s��)

        �׏��X�V_���C����(0, �f�o�C�XOFFSET + 3, 4, 6, �J�n�s��)
        �׏��X�V_���C����(0, �f�o�C�XOFFSET + 3, 3, 7, �J�n�s��)
        �׏��X�V_���C����(0, �f�o�C�XOFFSET + 3, 2, 8, �J�n�s��)

        '�N���[��(�s��)
        �N���[���M�����X�V(0, 5002, 0)

        '�o��ST
        �M�����X�V_����(0, 6008, 1)
        �׏��X�V_����(0, 6008, 2, 1)

        '��p���O
        �M�����X�V_����(1, 6000, 2)
        �׏��X�V_����(1, 6000, 2, 2)

        '�g���b�L���O�f�[�^�\��
        �g���b�L���O���X�V(�������C��, �J�n�s��)
    End Sub
    Private Sub �g���b�L���O���X�V(ByVal �������C�� As Integer, ByVal �J�n�s�� As Integer)
        Dim i As Integer = 0

        For i = 0 To 2
            Me.dgv�ݔ��󋵋���.Item(4, i).Value = ""
            Me.dgv�ݔ��󋵋���.Item(5, i).Value = ""
            Me.dgv�ݔ��󋵋���.Item(6, i).Value = ""
            Me.dgv�ݔ��󋵋���.Item(7, i).Value = ""
            Me.dgv�ݔ��󋵋���.Item(8, i).Value = ""
        Next

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("A.�X�e�[�^�X")
                .gSubSelect("B.�i�햼")
                .gSubSelect("A.�����")
                .gSubSelect("A.�T���v��No")
                .gSubSelect("A.STNO")
                .gSubSelect("A.��")
                .gSubSelect("A.�A")
                .gSubSelect("A.�i")
                .gSubSelect("A.���b�gNo")
                .gSubFrom("DN�g���b�L���O A")
                .gSubFrom("DM�i�� B")
                .gSubWhere("A.�������C��", �������C��, , , , , , , False)
                .gSubWhere("A.�i��CD = B.�i��CD")
                .gSubWhere("A.�X�e�[�^�X < 5")
                .gSubOrderBy("A.�X�V����")

                Dim �R���x��CNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read

                        Select Case reader.GetValue(0)
                            Case 0  '�i�ϋ@�f�[�^
                                Me.dgv�ݔ���.Item(4, 0 + �J�n�s��).Value = reader.GetValue(1)
                                Me.dgv�ݔ���.Item(5, 0 + �J�n�s��).Value = reader.GetValue(2)
                                Me.dgv�ݔ���.Item(6, 0 + �J�n�s��).Value = reader.GetValue(3)
                                Me.dgv�ݔ���.Item(9, 0 + �J�n�s��).Value = reader.GetValue(8)

                            Case 1  '�R���x���f�[�^ �������f�[�^���X�g�b�N�����ꍇ������
                                Me.dgv�ݔ���.Item(4, 5 - �R���x��CNT + �J�n�s��).Value = reader.GetValue(1)
                                Me.dgv�ݔ���.Item(5, 5 - �R���x��CNT + �J�n�s��).Value = reader.GetValue(2)
                                Me.dgv�ݔ���.Item(6, 5 - �R���x��CNT + �J�n�s��).Value = reader.GetValue(3)
                                Me.dgv�ݔ���.Item(9, 5 - �R���x��CNT + �J�n�s��).Value = reader.GetValue(8)

                                �R���x��CNT += 1
                            Case 2
                                Select Case reader.GetValue(4)
                                    Case 3
                                        Me.dgv�ݔ���.Item(4, 8 + �J�n�s��).Value = reader.GetValue(1)
                                        Me.dgv�ݔ���.Item(5, 8 + �J�n�s��).Value = reader.GetValue(2)
                                        Me.dgv�ݔ���.Item(6, 8 + �J�n�s��).Value = reader.GetValue(3)
                                        Me.dgv�ݔ���.Item(9, 8 + �J�n�s��).Value = reader.GetValue(8)
                                    Case 2
                                        Me.dgv�ݔ���.Item(4, 7 + �J�n�s��).Value = reader.GetValue(1)
                                        Me.dgv�ݔ���.Item(5, 7 + �J�n�s��).Value = reader.GetValue(2)
                                        Me.dgv�ݔ���.Item(6, 7 + �J�n�s��).Value = reader.GetValue(3)
                                        Me.dgv�ݔ���.Item(9, 7 + �J�n�s��).Value = reader.GetValue(8)
                                    Case 1
                                        Me.dgv�ݔ���.Item(4, 6 + �J�n�s��).Value = reader.GetValue(1)
                                        Me.dgv�ݔ���.Item(5, 6 + �J�n�s��).Value = reader.GetValue(2)
                                        Me.dgv�ݔ���.Item(6, 6 + �J�n�s��).Value = reader.GetValue(3)
                                        Me.dgv�ݔ���.Item(9, 6 + �J�n�s��).Value = reader.GetValue(8)
                                End Select

                            Case 3 '�N���[���w���\��
                                Select Case reader.GetValue(4)
                                    Case 3
                                        Me.dgv�ݔ���.Item(4, 8 + �J�n�s��).Value = reader.GetValue(1)
                                        Me.dgv�ݔ���.Item(5, 8 + �J�n�s��).Value = reader.GetValue(2)
                                        Me.dgv�ݔ���.Item(6, 8 + �J�n�s��).Value = reader.GetValue(3)
                                        Me.dgv�ݔ���.Item(7, 8 + �J�n�s��).Value = reader.GetValue(5) & "-" & reader.GetValue(6).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(7)
                                        Me.dgv�ݔ���.Item(9, 8 + �J�n�s��).Value = reader.GetValue(8)
                                    Case 2
                                        Me.dgv�ݔ���.Item(4, 7 + �J�n�s��).Value = reader.GetValue(1)
                                        Me.dgv�ݔ���.Item(5, 7 + �J�n�s��).Value = reader.GetValue(2)
                                        Me.dgv�ݔ���.Item(6, 7 + �J�n�s��).Value = reader.GetValue(3)
                                        Me.dgv�ݔ���.Item(9, 7 + �J�n�s��).Value = reader.GetValue(8)
                                    Case 1
                                        Me.dgv�ݔ���.Item(4, 6 + �J�n�s��).Value = reader.GetValue(1)
                                        Me.dgv�ݔ���.Item(5, 6 + �J�n�s��).Value = reader.GetValue(2)
                                        Me.dgv�ݔ���.Item(6, 6 + �J�n�s��).Value = reader.GetValue(3)
                                        Me.dgv�ݔ���.Item(9, 6 + �J�n�s��).Value = reader.GetValue(8)
                                End Select

                            Case 4  '�N���[���w�����M��
                                Select Case reader.GetValue(4)
                                    Case 3
                                        Me.dgv�ݔ���.Item(4, 8 + �J�n�s��).Value = reader.GetValue(1)
                                        Me.dgv�ݔ���.Item(5, 8 + �J�n�s��).Value = reader.GetValue(2)
                                        Me.dgv�ݔ���.Item(6, 8 + �J�n�s��).Value = reader.GetValue(3)
                                        Me.dgv�ݔ���.Item(7, 8 + �J�n�s��).Value = reader.GetValue(5) & "-" & reader.GetValue(6).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(7)
                                        Me.dgv�ݔ���.Item(9, 8 + �J�n�s��).Value = reader.GetValue(8)
                                    Case 2
                                        Me.dgv�ݔ���.Item(4, 7 + �J�n�s��).Value = reader.GetValue(1)
                                        Me.dgv�ݔ���.Item(5, 7 + �J�n�s��).Value = reader.GetValue(2)
                                        Me.dgv�ݔ���.Item(6, 7 + �J�n�s��).Value = reader.GetValue(3)
                                        Me.dgv�ݔ���.Item(9, 7 + �J�n�s��).Value = reader.GetValue(8)
                                    Case 1
                                        Me.dgv�ݔ���.Item(4, 6 + �J�n�s��).Value = reader.GetValue(1)
                                        Me.dgv�ݔ���.Item(5, 6 + �J�n�s��).Value = reader.GetValue(2)
                                        Me.dgv�ݔ���.Item(6, 6 + �J�n�s��).Value = reader.GetValue(3)
                                        Me.dgv�ݔ���.Item(9, 6 + �J�n�s��).Value = reader.GetValue(8)
                                End Select
                        End Select
                    End While
                End If
            End With

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Try
            With New CSqlEx
                .gSubSelect("A.�X�e�[�^�X")
                .gSubSelect("MAX(B.�i�햼)")
                .gSubSelect("SUM(A.�����)")
                .gSubSelect("A.�T���v��No")
                .gSubSelect("A.��")
                .gSubSelect("A.�A")
                .gSubSelect("A.�i")
                .gSubFrom("DN�g���b�L���O A")
                .gSubFrom("DM�i�� B")
                .gSubWhere("A.�i��CD = B.�i��CD")
                .gSubWhere("A.�X�e�[�^�X >= 5")
                .gSubGroupBy("A.�X�e�[�^�X")
                .gSubGroupBy("A.�T���v��No")
                .gSubGroupBy("A.��")
                .gSubGroupBy("A.�A")
                .gSubGroupBy("A.�i")

                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        Select Case reader.GetValue(0)
                            Case 5  '�N���[���f�[�^
                                Me.dgv�ݔ��󋵋���.Item(4, 0).Value = reader.GetValue(1)
                                Me.dgv�ݔ��󋵋���.Item(5, 0).Value = reader.GetValue(2)
                                Me.dgv�ݔ��󋵋���.Item(6, 0).Value = reader.GetValue(3)
                                Me.dgv�ݔ��󋵋���.Item(7, 0).Value = reader.GetValue(4) & "-" & reader.GetValue(5).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(6)
                                Me.dgv�ݔ��󋵋���.Item(8, 0).Value = "����"

                            Case 9  '�N���[���f�[�^
                                Me.dgv�ݔ��󋵋���.Item(4, 0).Value = reader.GetValue(1)
                                Me.dgv�ݔ��󋵋���.Item(5, 0).Value = reader.GetValue(2)
                                Me.dgv�ݔ��󋵋���.Item(6, 0).Value = reader.GetValue(3)
                                Me.dgv�ݔ��󋵋���.Item(7, 0).Value = reader.GetValue(4) & "-" & reader.GetValue(5).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(6)
                                Me.dgv�ݔ��󋵋���.Item(8, 0).Value = "�o��"

                            Case 10  '�o��ST�f�[�^
                                Me.dgv�ݔ��󋵋���.Item(4, 1).Value = reader.GetValue(1)
                                Me.dgv�ݔ��󋵋���.Item(5, 1).Value = reader.GetValue(2)
                                Me.dgv�ݔ��󋵋���.Item(6, 1).Value = reader.GetValue(3)

                            Case 20  '�}�⎺�O�f�[�^
                                Me.dgv�ݔ��󋵋���.Item(4, 2).Value = reader.GetValue(1)
                                Me.dgv�ݔ��󋵋���.Item(5, 2).Value = reader.GetValue(2)
                                Me.dgv�ݔ��󋵋���.Item(6, 2).Value = reader.GetValue(3)
                        End Select
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub �N���[���M�����X�V(ByVal �q�ɋ敪 As Integer, ByVal �f�o�C�XNo As Integer, ByVal Row As Integer)
        If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 5) = 1 Then
            dgv�ݔ��󋵋���.Item(2, Row).Value = "�ُ�"
        Else
            If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 7) = 1 Then
                dgv�ݔ��󋵋���.Item(2, Row).Value = "����"
            Else
                dgv�ݔ��󋵋���.Item(2, Row).Value = "�蓮"
            End If
        End If
    End Sub

    Private Sub �M�����X�V_���C����(ByVal �q�ɋ敪 As Integer, ByVal �f�o�C�XNo As Integer, ByVal Row As Integer, ByVal �J�n�s�� As Integer)
        If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 0) = 1 Then
            dgv�ݔ���.Item(2, Row + �J�n�s��).Value = "�ُ�"
        Else
            If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 1) = 1 Then
                dgv�ݔ���.Item(2, Row + �J�n�s��).Value = "����"
            Else
                dgv�ݔ���.Item(2, Row + �J�n�s��).Value = "�蓮"
            End If
        End If
    End Sub

    Private Sub �׏��X�V_���C����(ByVal �q�ɋ敪 As Integer, ByVal �f�o�C�XNo As Integer, ByVal �r�b�gNo As Integer, ByVal Row As Integer, ByVal �J�n�s�� As Integer)
        If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, �r�b�gNo) = 1 Then
            dgv�ݔ���.Item(3, Row + �J�n�s��).Value = "�L"
        Else
            dgv�ݔ���.Item(3, Row + �J�n�s��).Value = ""
        End If
    End Sub

    Private Sub �M�����X�V_����(ByVal �q�ɋ敪 As Integer, ByVal �f�o�C�XNo As Integer, ByVal Row As Integer)
        If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 0) = 1 Then
            dgv�ݔ��󋵋���.Item(2, Row).Value = "�ُ�"
        Else
            If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 1) = 1 Then
                dgv�ݔ��󋵋���.Item(2, Row).Value = "����"
            Else
                dgv�ݔ��󋵋���.Item(2, Row).Value = "�蓮"
            End If
        End If
    End Sub

    Private Sub �׏��X�V_����(ByVal �q�ɋ敪 As Integer, ByVal �f�o�C�XNo As Integer, ByVal �r�b�gNo As Integer, ByVal Row As Integer)
        If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, �r�b�gNo) = 1 Then
            dgv�ݔ��󋵋���.Item(3, Row).Value = "�L"
        Else
            dgv�ݔ��󋵋���.Item(3, Row).Value = ""
        End If
    End Sub

    Private Function str�ݔ�����(ByVal no As Integer) As String
        Dim �ݔ����� As String
        Select Case no
            Case 1
                �ݔ����� = "�i�ϋ@"
            Case 2
                �ݔ����� = "�R���x��"
            Case 7
                �ݔ����� = "����ST�P"
            Case 8
                �ݔ����� = "����ST�Q"
            Case 9
                �ݔ����� = "����ST�R"
            Case 10
                �ݔ����� = "�N���[��"
            Case 11
                �ݔ����� = "�o��ST"
            Case 12
                �ݔ����� = "��p���O"
            Case Else
                �ݔ����� = ""
        End Select

        Return �ݔ�����
    End Function

    Private Function Dbl���x�f�[�^�擾(ByVal int�q�ɋ敪 As Integer, ByVal intOFFSET As Integer) As Double
        Dim i As Integer
        Dim BitData As String = ""
        Dim ���x�f�[�^ As Double = 0

        BitData = ""
        For i = 0 To 15
            BitData = Int(CMdiMain.blnON���(int�q�ɋ敪, intOFFSET, i)) & BitData
        Next

        ���x�f�[�^ = Convert.ToInt32(BitData, 2)

        Return ���x�f�[�^
    End Function
End Class

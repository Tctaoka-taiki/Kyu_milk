
Imports System.Data.Common
Public Class Frm01024_��Ɨ����Ɖ�
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
    Dim int�J�����g�s As Integer = 0
    Private Sub Frm01024_��Ɨ����Ɖ�_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl�w�����F.Text = ""
        Me.lbl�w�����T.Text = ""
        Me.lbl�ݔ�����.Text = ""

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
            Dim �Ώېݔ� As String = ""
            Dim �Ώێw���FR As String = ""
            Dim �Ώێw���TO As String = ""

            Dim dlg As New Dlg01024_��Ɨ���⍇��
            With dlg
                .ShowDialog()
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    �Ώېݔ� = .cmbPLC.Text
                    If .txt�w��NFR.Text <> "" And .txt�w�茎FR.Text <> "" And .txt�w���FR.Text <> "" Then
                        �Ώێw���FR = .txt�w��NFR.Text.PadLeft(4, "0"c) & "/" & .txt�w�茎FR.Text.PadLeft(2, "0"c) & "/" & .txt�w���FR.Text.PadLeft(2, "0"c) & " " & .txt�w�莞FR.Text.PadLeft(2, "0"c) & ":" & .txt�w�蕪FR.Text.PadLeft(2, "0"c) & ":00"
                    End If
                    If .txt�w��NTO.Text <> "" And .txt�w�茎TO.Text <> "" And .txt�w���TO.Text <> "" Then
                        �Ώێw���TO = .txt�w��NTO.Text.PadLeft(4, "0"c) & "/" & .txt�w�茎TO.Text.PadLeft(2, "0"c) & "/" & .txt�w���TO.Text.PadLeft(2, "0"c) & " " & .txt�w�莞TO.Text.PadLeft(2, "0"c) & ":" & .txt�w�蕪TO.Text.PadLeft(2, "0"c) & ":00"
                    End If
                    Me.lbl�w�����F.Text = �Ώێw���FR
                    Me.lbl�w�����T.Text = �Ώێw���TO
                    Me.lbl�ݔ�����.Text = �Ώېݔ�
                    Me.lbl�ݔ�����.Text = �Ώېݔ�

                    '��ʂ̍ĕ\��
                    ��Ɨ������\��(�Ώېݔ�, �Ώێw���FR, �Ώێw���TO)
                End If
            End With

        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub ��Ɨ������\��(ByVal �ݔ����� As String, ByVal �w���FR As String, ByVal �w���TO As String)
        Dim �X���l1 As Double
        Dim �ؕ�1 As Double
        Dim �X���l2 As Double
        Dim �ؕ�2 As Double
        Select Case �ݔ�����
            Case "���y"
                �X���l1 = dbl���y�����x�X��
                �ؕ�1 = dbl���y�����x�ؕ�

                �X���l2 = dbl�}�⎺���x�X��
                �ؕ�2 = dbl�}�⎺���x�ؕ�

            Case "��p"
                �X���l1 = dbl�}�⎺���x�X��
                �ؕ�1 = dbl�}�⎺���x�ؕ�

                �X���l2 = dbl��p�����x�X��
                �ؕ�2 = dbl��p�����x�ؕ�
        End Select

        Me.dgv��Ɨ���.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.��Ƌ敪")
                .gSubSelect("A.�o�^����")
                .gSubSelect("A.���b�gNo")
                .gSubSelect("A.�T���v��No")
                .gSubSelect("B.�i�햼")
                .gSubSelect("A.�����")
                .gSubSelect("A.���x�M��")
                .gSubFrom("DL��Ɨ��� A")
                .gSubFrom("DM�i�� B")
                Select Case �ݔ�����
                    Case "���y"
                        .gSubWhere("A.�q�ɋ敪=0")
                    Case "��p"
                        .gSubWhere("A.�q�ɋ敪=1")
                End Select
                .gSubWhere("A.�o�^����", �w���FR, ">=", , , , , , True)
                .gSubWhere("A.�o�^����", �w���TO, "<=", , , , , , True)
                .gSubWhere("A.�i��CD = B.�i��CD")
                .gSubOrderBy("A.�o�^����")

                Dim i As Integer = 0
                Dim ��Ɠ��e As String = ""
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        Me.dgv��Ɨ���.Rows.Add()
                        Me.dgv��Ɨ���.Item(0, i).Value = i + 1
                        Select Case reader.GetValue(0)
                            Case 0
                                ��Ɠ��e = "����"
                            Case 1
                                ��Ɠ��e = "���o"
                            Case 2
                                ��Ɠ��e = "�o�^"
                            Case 3
                                ��Ɠ��e = "�폜"
                        End Select
                        Me.dgv��Ɨ���.Item(1, i).Value = ��Ɠ��e
                        Me.dgv��Ɨ���.Item(2, i).Value = reader.GetValue(1)
                        Me.dgv��Ɨ���.Item(3, i).Value = reader.GetValue(2)
                        Me.dgv��Ɨ���.Item(4, i).Value = reader.GetValue(3)
                        Me.dgv��Ɨ���.Item(5, i).Value = reader.GetValue(4)
                        Me.dgv��Ɨ���.Item(6, i).Value = reader.GetValue(5)
                        Select Case ��Ɠ��e
                            Case "����"
                                Me.dgv��Ɨ���.Item(7, i).Value = Int(CInt("&H" & reader.GetValue(6).ToString) - �ؕ�1 / �X���l1 * 10) / 10 & "��"
                            Case "���o"
                                Me.dgv��Ɨ���.Item(7, i).Value = Int(CInt("&H" & reader.GetValue(6).ToString) - �ؕ�2 / �X���l2 * 10) / 10 & "��"
                            Case Else   '���̏ꍇ�A���x��\��

                        End Select

                        i += 1

                        If i + 1 = 5000 Then
                            CMsg.gMsg_���("�f�[�^�\���͍ő�5000���܂łƂ��܂��B")
                            Exit While
                        End If
                    End While

                    If i > 0 Then

                    Else
                        '�f�[�^�������ꍇ�́A�N���A����
                        CMsg.gMsg_���("�Y���f�[�^������܂���B")
                        Me.lbl�w�����F.Text = ""
                        Me.lbl�w�����T.Text = ""
                        Me.lbl�ݔ�����.Text = ""
                        Me.dgv��Ɨ���.Rows.Clear()
                    End If

                End If
            End With
        Catch ex As Exception
        Finally
            Dim int�J�����g�s As Integer = 0
            Me.dgv��Ɨ���.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Dim int���O�y�[�W����敪 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        If Me.dgv��Ɨ���.Rows.Count <= 0 Then
            Exit Sub
        End If


        If int���O�y�[�W����敪 = 0 Then
            int�J�����g�s = int�J�����g�s - 24
        Else
            int�J�����g�s = int�J�����g�s - 47
        End If

        If int�J�����g�s < 0 Then
            int�J�����g�s = 0

        ElseIf int�J�����g�s > Me.dgv��Ɨ���.Rows.Count - 1 Then
            int�J�����g�s = Me.dgv��Ɨ���.Rows.Count - 1

        End If

        Me.dgv��Ɨ���.CurrentCell = dgv��Ɨ���(0, int�J�����g�s)
        Me.dgv��Ɨ���.CurrentCell = Nothing

        int���O�y�[�W����敪 = 0
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If Me.dgv��Ɨ���.Rows.Count <= 0 Then
            Exit Sub
        End If

        If int���O�y�[�W����敪 = 1 Then
            int�J�����g�s = int�J�����g�s + 24
        Else
            int�J�����g�s = int�J�����g�s + 47
        End If

        If int�J�����g�s > Me.dgv��Ɨ���.Rows.Count - 1 Then
            int�J�����g�s = Me.dgv��Ɨ���.Rows.Count - 1
        End If

        Me.dgv��Ɨ���.CurrentCell = dgv��Ɨ���(0, int�J�����g�s)
        Me.dgv��Ɨ���.CurrentCell = Nothing

        int���O�y�[�W����敪 = 1
    End Sub
End Class

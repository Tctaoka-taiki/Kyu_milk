
Imports System.Data.Common
Public Class Frm01023_���x���і⍇��
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
    Private Sub Frm01023_���x���і⍇��_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl�w���.Text = ""
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
            Dim �Ώێw��� As String = ""

            Dim dlg As New Dlg01023_���x
            With dlg
                .ShowDialog()
                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    �Ώېݔ� = .cmb�ݔ�����.Text
                    If .txt�w��N.Text <> "" And .txt�w�茎.Text <> "" And .txt�w���.Text <> "" Then
                        �Ώێw��� = .txt�w��N.Text.PadLeft(4, "0"c) & "/" & .txt�w�茎.Text.PadLeft(2, "0"c) & "/" & .txt�w���.Text.PadLeft(2, "0"c)
                    End If
                    Me.lbl�w���.Text = �Ώێw���
                    Me.lbl�ݔ�����.Text = �Ώېݔ�
                    '��ʂ̍ĕ\��
                    �ݔ����x���(�Ώېݔ�, �Ώێw���)
                End If
            End With

        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub �ݔ����x���(ByVal �ݔ����� As String, ByVal �w��� As String)
        Me.dgv���x�f�[�^.Rows.Clear()
        Dim �X���l As Double
        Dim �ؕ� As Double

        Select Case �ݔ�����
            Case "���y�q��"
                �X���l = dbl���y�����x�X��
                �ؕ� = dbl���y�����x�ؕ�
            Case "��p�q��"
                �X���l = dbl��p�����x�X��
                �ؕ� = dbl��p�����x�ؕ�
            Case "�}�⎺"
                �X���l = dbl�}�⎺���x�X��
                �ؕ� = dbl�}�⎺���x�ؕ�
        End Select
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.��")
                .gSubSelect("MAX(A.���x�M��00��)")
                .gSubSelect("MAX(A.���x�M��10��)")
                .gSubSelect("MAX(A.���x�M��20��)")
                .gSubSelect("MAX(A.���x�M��30��)")
                .gSubSelect("MAX(A.���x�M��40��)")
                .gSubSelect("MAX(A.���x�M��50��)")
                .gSubFrom("DV���x���� A")
                Select Case �ݔ�����
                    Case "���y�q��"
                        .gSubWhere("A.�ݔ��敪=0")
                    Case "��p�q��"
                        .gSubWhere("A.�ݔ��敪=1")
                    Case "�}�⎺"
                        .gSubWhere("A.�ݔ��敪=2")
                End Select
                .gSubWhere("A.�N", Mid(�w���, 1, 4))
                .gSubWhere("A.��", Mid(�w���, 6, 2))
                .gSubWhere("A.��", Mid(�w���, 9, 2))
                .gSubGroupBy("A.��")
                .gSubOrderBy("A.��")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        Me.dgv���x�f�[�^.Rows.Add()
                        Me.dgv���x�f�[�^.Item(0, i).Value = i + 1
                        Me.dgv���x�f�[�^.Item(1, i).Value = reader.GetValue(0)
                        If Trim(reader.GetValue(1).ToString) <> "" Then
                            Me.dgv���x�f�[�^.Item(2, i).Value = Format(Int((CInt("&H" & reader.GetValue(1).ToString) - �ؕ�) / �X���l * 10) / 10, "0.0") & "��"
                        End If
                        If Trim(reader.GetValue(2).ToString) <> "" Then
                            Me.dgv���x�f�[�^.Item(3, i).Value = Format(Int((CInt("&H" & reader.GetValue(2).ToString) - �ؕ�) / �X���l * 10) / 10, "0.0") & "��"
                        End If
                        If Trim(reader.GetValue(3).ToString) <> "" Then
                            Me.dgv���x�f�[�^.Item(4, i).Value = Format(Int((CInt("&H" & reader.GetValue(3).ToString) - �ؕ�) / �X���l * 10) / 10, "0.0") & "��"
                        End If
                        If Trim(reader.GetValue(4).ToString) <> "" Then
                            Me.dgv���x�f�[�^.Item(5, i).Value = Format(Int((CInt("&H" & reader.GetValue(4).ToString) - �ؕ�) / �X���l * 10) / 10, "0.0") & "��"
                        End If
                        If Trim(reader.GetValue(5).ToString) <> "" Then
                            Me.dgv���x�f�[�^.Item(6, i).Value = Format(Int((CInt("&H" & reader.GetValue(5).ToString) - �ؕ�) / �X���l * 10) / 10, "0.0") & "��"
                        End If
                        If Trim(reader.GetValue(6).ToString) <> "" Then
                            Me.dgv���x�f�[�^.Item(7, i).Value = Format(Int((CInt("&H" & reader.GetValue(6).ToString) - �ؕ�) / �X���l * 10) / 10, "0.0") & "��"
                        End If

                        i += 1
                    End While

                    If i > 0 Then

                    Else
                        '�f�[�^�������ꍇ�́A�N���A����
                        CMsg.gMsg_���("�Y���f�[�^������܂���B")
                        Me.dgv���x�f�[�^.Rows.Clear()
                    End If

                End If
            End With
        Catch ex As Exception
        Finally
            Dim int�J�����g�s As Integer = 0
            Me.dgv���x�f�[�^.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Dim int���O�y�[�W����敪 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        If Me.dgv���x�f�[�^.Rows.Count < 0 Then
            Exit Sub
        End If


        If int���O�y�[�W����敪 = 0 Then
            int�J�����g�s = int�J�����g�s - 24
        Else
            int�J�����g�s = int�J�����g�s - 47
        End If

        If int�J�����g�s < 0 Then
            int�J�����g�s = 0

        ElseIf int�J�����g�s > Me.dgv���x�f�[�^.Rows.Count - 1 Then
            int�J�����g�s = Me.dgv���x�f�[�^.Rows.Count - 1

        End If

        Me.dgv���x�f�[�^.CurrentCell = dgv���x�f�[�^(0, int�J�����g�s)
        Me.dgv���x�f�[�^.CurrentCell = Nothing

        int���O�y�[�W����敪 = 0
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If Me.dgv���x�f�[�^.Rows.Count < 0 Then
            Exit Sub
        End If

        If int���O�y�[�W����敪 = 1 Then
            int�J�����g�s = int�J�����g�s + 24
        Else
            int�J�����g�s = int�J�����g�s + 47
        End If

        If int�J�����g�s > Me.dgv���x�f�[�^.Rows.Count - 1 Then
            int�J�����g�s = Me.dgv���x�f�[�^.Rows.Count - 1
        End If

        Me.dgv���x�f�[�^.CurrentCell = dgv���x�f�[�^(0, int�J�����g�s)
        Me.dgv���x�f�[�^.CurrentCell = Nothing

        int���O�y�[�W����敪 = 1
    End Sub
End Class

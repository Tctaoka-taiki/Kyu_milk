
Imports System.Data.Common
Public Class Frm01041_�W���[�i���Ɖ�
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
    Private Sub Frm01041_�W���[�i���Ɖ�_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbl�w�����F.Text = ""
        Me.lbl�w�����T.Text = ""
        Me.lbl�f�o�C�X.Text = ""
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
            Dim �f�o�C�XNo As String = ""


            Dim dlg As New Dlg01041_�W���[�i���⍇
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
                    �f�o�C�XNo = .txt�f�o�C�XNo.Text
                    Me.lbl�w�����F.Text = �Ώێw���FR
                    Me.lbl�w�����T.Text = �Ώێw���TO
                    Me.lbl�ݔ�����.Text = �Ώېݔ�
                    Me.lbl�ݔ�����.Text = �Ώېݔ�

                    '��ʂ̍ĕ\��
                    �W���[�i�����(�Ώېݔ�, �Ώێw���FR, �Ώێw���TO, �f�o�C�XNo)
                End If
            End With

        Catch ex As Exception
        Finally


        End Try

    End Sub

    Private Sub �W���[�i�����(ByVal �ݔ����� As String, ByVal �w���FR As String, ByVal �w���TO As String, ByVal �f�o�C�XNo As String)
        Me.dgv�W���[�i���f�[�^.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.�o�^����")
                .gSubSelect("A.�f�o�C�XNo")
                .gSubSelect("A.���O�M��")
                .gSubSelect("A.�M��")
                .gSubFrom("DL�W���[�i������ A")
                Select Case �ݔ�����
                    Case "���y"
                        .gSubWhere("A.�q�ɋ敪=0")
                    Case "��p"
                        .gSubWhere("A.�q�ɋ敪=1")
                End Select
                .gSubWhere�����܂�����("�f�o�C�XNo", �f�o�C�XNo)
                .gSubWhere("A.�o�^����", �w���FR, ">=", , , , , , True)
                .gSubWhere("A.�o�^����", �w���TO, "<=", , , , , , True)
                .gSubOrderBy("A.�o�^����")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        Me.dgv�W���[�i���f�[�^.Rows.Add()
                        Me.dgv�W���[�i���f�[�^.Item(0, i).Value = i + 1
                        Me.dgv�W���[�i���f�[�^.Item(1, i).Value = reader.GetValue(0)
                        Me.dgv�W���[�i���f�[�^.Item(2, i).Value = reader.GetValue(1)
                        If reader.GetValue(2).ToString <> "" Then
                            Me.dgv�W���[�i���f�[�^.Item(3, i).Value = Convert.ToString(Convert.ToInt32(reader.GetValue(2).ToString, 16), 2).PadLeft(16, "0"c)
                        End If
                        If reader.GetValue(3).ToString <> "" Then
                            Me.dgv�W���[�i���f�[�^.Item(4, i).Value = Convert.ToString(Convert.ToInt32(reader.GetValue(3).ToString, 16), 2).PadLeft(16, "0"c)
                        End If

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
                        Me.lbl�f�o�C�X.Text = ""
                        Me.lbl�ݔ�����.Text = ""
                        Me.dgv�W���[�i���f�[�^.Rows.Clear()
                    End If

                End If
            End With
        Catch ex As Exception
        Finally
            Dim int�J�����g�s As Integer = 0
            Me.dgv�W���[�i���f�[�^.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Dim int���O�y�[�W����敪 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        If Me.dgv�W���[�i���f�[�^.Rows.Count <= 0 Then
            Exit Sub
        End If


        If int���O�y�[�W����敪 = 0 Then
            int�J�����g�s = int�J�����g�s - 24
        Else
            int�J�����g�s = int�J�����g�s - 47
        End If

        If int�J�����g�s < 0 Then
            int�J�����g�s = 0

        ElseIf int�J�����g�s > Me.dgv�W���[�i���f�[�^.Rows.Count - 1 Then
            int�J�����g�s = Me.dgv�W���[�i���f�[�^.Rows.Count - 1

        End If

        Me.dgv�W���[�i���f�[�^.CurrentCell = dgv�W���[�i���f�[�^(0, int�J�����g�s)
        Me.dgv�W���[�i���f�[�^.CurrentCell = Nothing

        int���O�y�[�W����敪 = 0
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If Me.dgv�W���[�i���f�[�^.Rows.Count <= 0 Then
            Exit Sub
        End If

        If int���O�y�[�W����敪 = 1 Then
            int�J�����g�s = int�J�����g�s + 24
        Else
            int�J�����g�s = int�J�����g�s + 47
        End If

        If int�J�����g�s > Me.dgv�W���[�i���f�[�^.Rows.Count - 1 Then
            int�J�����g�s = Me.dgv�W���[�i���f�[�^.Rows.Count - 1
        End If

        Me.dgv�W���[�i���f�[�^.CurrentCell = dgv�W���[�i���f�[�^(0, int�J�����g�s)
        Me.dgv�W���[�i���f�[�^.CurrentCell = Nothing

        int���O�y�[�W����敪 = 1
    End Sub
End Class

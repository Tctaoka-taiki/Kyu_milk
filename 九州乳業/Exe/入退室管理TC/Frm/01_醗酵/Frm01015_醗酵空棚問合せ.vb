
Imports System.Data.Common
Public Class Frm01015_���y��I�⍇��
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

    Private Sub Frm00009_��I�⍇��_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '������
        ��ʏ�����()

        '�f�[�^�X�V
        �I�󋵕\��(1)
        �I�󋵕\��(2)

        Timer1.Start()
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub ��ʏ�����()
        Dim i As Integer
        Dim j As Integer
        For i = 0 To 3
            dgv��1.Rows.Add()
            dgv��1(0, i).Value = "�i" & (4 - i)
            For j = 1 To 28
                dgv��1.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv��1.Columns(j).Width = 30
                dgv��1(j, i).Value = "��"
            Next
        Next
        dgv��1.CurrentCell = Nothing

        For i = 0 To 3
            dgv��2.Rows.Add()
            dgv��2(0, i).Value = "�i" & (4 - i)
            For j = 1 To 28
                dgv��2.Columns(j).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv��2.Columns(j).Width = 30
                dgv��2(j, i).Value = "��"
            Next
        Next
        dgv��2.CurrentCell = Nothing

    End Sub

    Private Sub �I�󋵕\��(ByVal int�� As Integer)
        Dim reader As DbDataReader = Nothing
        Try
            '�֎~�I�AST���̕\��
            With New CSqlEx
                .gSubSelect("A.�A")
                .gSubSelect("A.�i")
                .gSubSelect("A.�I�敪")
                .gSubFrom("DM�I A")
                .gSubWhere("A.�q�ɋ敪 = 0")
                .gSubWhere("A.��", int��, , , , , , , , )
                .gSubOrderBy("A.�A")
                .gSubOrderBy("A.�i DESC")

                Dim �A As Integer
                Dim �i As Integer
                Dim �I�敪 As String
                Dim �\���f�[�^ As String = ""
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        �A = reader.GetValue(0)
                        �i = reader.GetValue(1)

                        �I�敪 = reader.GetValue(2)
                        Select Case �I�敪
                            Case 0
                                '��U�������ŁA����\��
                                �\���f�[�^ = "��"
                            Case 1
                                �\���f�[�^ = "�r"
                            Case 2
                                �\���f�[�^ = "��"
                            Case 3
                                �\���f�[�^ = "��"
                        End Select

                        Select Case int��
                            Case 1
                                dgv��1.Item(�A, 4 - �i).Value = �\���f�[�^

                            Case 2
                                dgv��2.Item(�A, 4 - �i).Value = �\���f�[�^

                        End Select

                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Try
            '�I���p�󋵂̕\��
            With New CSqlEx
                .gSubSelect("A.�A")
                .gSubSelect("A.�i")
                .gSubFrom("DN�g���b�L���O A")
                .gSubWhere("A.�X�e�[�^�X >= 6")
                .gSubWhere("A.�X�e�[�^�X < 20")
                .gSubWhere("A.��", int��, , , , , , , , )
                .gSubOrderBy("A.�A")
                .gSubOrderBy("A.�i DESC")

                Dim �A As Integer
                Dim �i As Integer
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        �A = reader.GetValue(0)
                        �i = reader.GetValue(1)

                        Select Case int��
                            Case 1
                                dgv��1.Item(�A, 4 - �i).Value = "��"

                            Case 2
                                dgv��2.Item(�A, 4 - �i).Value = "��"

                        End Select

                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '�f�[�^�X�V
        �I�󋵕\��(1)
        �I�󋵕\��(2)
    End Sub
End Class

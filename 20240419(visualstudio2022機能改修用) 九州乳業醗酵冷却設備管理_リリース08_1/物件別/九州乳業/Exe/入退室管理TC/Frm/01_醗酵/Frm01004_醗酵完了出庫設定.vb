
Imports System.Data.Common
Public Class Frm01004_���y�����o�ɐݒ�
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
    Dim �t�H�[�J�X As String = "�n�[�h"
    Private Sub Frm01002_���y�����o�ɐݒ�_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ���y���Y�i���()

        Me.Timer1.Start()
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y���C�����j���[)


        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub ���y���Y�i���()
        Try
            CMdiMain.gSub�������ݒ�(Me, True)


            Me.dgv���Y�f�[�^�n�[�h.Rows.Clear()
            Me.dgv���Y�f�[�^�v���[��.Rows.Clear()

            Dim reader As DbDataReader = Nothing
            Try

                With New CSqlEx
                    .gSubSelect("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubSelect("A.�T���v��No")
                    .gSubSelect("MAX(B.�i�햼)")
                    .gSubSelect("MAX(B.���蔮�y����)")
                    .gSubSelect("MAX(DATEDIFF(MINUTE,���y�J�n����,GETDATE()))")
                    .gSubSelect("MAX(A.�X�e�[�^�X)")
                    .gSubSelect("MAX(A.�o�ɒ��f)")
                    .gSubSelect("Count(DISTINCT A.���j�b�gSEQ)")
                    .gSubSelect("Count(A.�Ǘ�No)")
                    .gSubFrom("DN�g���b�L���O A")
                    .gSubFrom("DM�i�� B")
                    .gSubWhere("A.�X�e�[�^�X >= 6 ")
                    .gSubWhere("A.�X�e�[�^�X <= 9 ")
                    .gSubWhere("A.�i��CD = B.�i��CD")
                    .gSubWhere("B.���i�敪 = 0")
                    .gSubGroupBy("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubGroupBy("A.�T���v��No")
                    .gSubOrderBy("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubOrderBy("A.�T���v��No")

                    Dim i As Integer = 0
                    If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                        While reader.Read
                            Me.dgv���Y�f�[�^�n�[�h.Rows.Add()
                            Me.dgv���Y�f�[�^�n�[�h.Item(0, i).Value = i + 1
                            Me.dgv���Y�f�[�^�n�[�h.Item(1, i).Value = reader.GetValue(0)
                            Me.dgv���Y�f�[�^�n�[�h.Item(2, i).Value = reader.GetValue(1)
                            Me.dgv���Y�f�[�^�n�[�h.Item(3, i).Value = reader.GetValue(2)
                            Dim ���蔮�y���� As Integer = reader.GetValue(3)
                            Dim ���y�o�ߎ��� As Integer = reader.GetValue(4)
                            Me.dgv���Y�f�[�^�n�[�h.Item(4, i).Value = ���蔮�y���� & "��"
                            Me.dgv���Y�f�[�^�n�[�h.Item(5, i).Value = ���y�o�ߎ��� & "��"

                            Select Case reader.GetValue(5)
                                Case 6
                                    If ���蔮�y���� > ���y�o�ߎ��� Then
                                        Me.dgv���Y�f�[�^�n�[�h.Item(6, i).Value = ""
                                    Else
                                        Me.dgv���Y�f�[�^�n�[�h.Item(6, i).Value = "���y����"
                                    End If
                                Case 7
                                    Me.dgv���Y�f�[�^�n�[�h.Item(6, i).Value = "�o�ɑ҂�"
                                Case 8, 9
                                    Me.dgv���Y�f�[�^�n�[�h.Item(6, i).Value = "�o�ɒ�"
                            End Select

                            If reader.GetValue(6) = 1 Then
                                Me.dgv���Y�f�[�^�n�[�h.Item(6, i).Value = "���f��"
                            End If
                            Me.dgv���Y�f�[�^�n�[�h.Item(7, i).Value = reader.GetValue(7)
                            Me.dgv���Y�f�[�^�n�[�h.Item(8, i).Value = reader.GetValue(8)
                            i += 1
                        End While
                    End If
                End With
                int�J�����g�s = 0
                Me.dgv���Y�f�[�^�n�[�h.CurrentCell = Nothing
                CUsrctl.gDp.gSubReaderClose(reader)

                With New CSqlEx
                    .gSubSelect("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubSelect("A.�T���v��No")
                    .gSubSelect("MAX(B.�i�햼)")
                    .gSubSelect("MAX(B.���蔮�y����)")
                    .gSubSelect("MAX(DATEDIFF(MINUTE,���y�J�n����,GETDATE()))")
                    .gSubSelect("MAX(A.�X�e�[�^�X)")
                    .gSubSelect("MAX(A.�o�ɒ��f)")
                    .gSubSelect("Count(DISTINCT A.���j�b�gSEQ)")
                    .gSubSelect("Count(A.�Ǘ�No)")
                    .gSubFrom("DN�g���b�L���O A")
                    .gSubFrom("DM�i�� B")
                    .gSubWhere("A.�X�e�[�^�X >= 6 ")
                    .gSubWhere("A.�X�e�[�^�X <= 9 ")
                    .gSubWhere("A.�i��CD = B.�i��CD")
                    .gSubWhere("B.���i�敪 = 1")
                    .gSubGroupBy("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubGroupBy("A.�T���v��No")
                    .gSubOrderBy("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                    .gSubOrderBy("A.�T���v��No")

                    Dim i As Integer = 0
                    If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                        While reader.Read
                            Me.dgv���Y�f�[�^�v���[��.Rows.Add()
                            Me.dgv���Y�f�[�^�v���[��.Item(0, i).Value = i + 1
                            Me.dgv���Y�f�[�^�v���[��.Item(1, i).Value = reader.GetValue(0)
                            Me.dgv���Y�f�[�^�v���[��.Item(2, i).Value = reader.GetValue(1)
                            Me.dgv���Y�f�[�^�v���[��.Item(3, i).Value = reader.GetValue(2)
                            Dim ���蔮�y���� As Integer = reader.GetValue(3)
                            Dim ���y�o�ߎ��� As Integer = reader.GetValue(4)
                            Me.dgv���Y�f�[�^�v���[��.Item(4, i).Value = ���蔮�y���� & "��"
                            Me.dgv���Y�f�[�^�v���[��.Item(5, i).Value = ���y�o�ߎ��� & "��"

                            Select Case reader.GetValue(5)
                                Case 6
                                    If ���蔮�y���� > ���y�o�ߎ��� Then
                                        Me.dgv���Y�f�[�^�v���[��.Item(6, i).Value = ""
                                    Else
                                        Me.dgv���Y�f�[�^�v���[��.Item(6, i).Value = "���y����"
                                    End If
                                Case 7
                                    Me.dgv���Y�f�[�^�v���[��.Item(6, i).Value = "�o�ɑ҂�"
                                Case 8, 9
                                    Me.dgv���Y�f�[�^�v���[��.Item(6, i).Value = "�o�ɒ�"
                            End Select

                            If reader.GetValue(6) = 1 Then
                                Me.dgv���Y�f�[�^�v���[��.Item(6, i).Value = "���f��"
                            End If
                            Me.dgv���Y�f�[�^�v���[��.Item(7, i).Value = reader.GetValue(7)
                            Me.dgv���Y�f�[�^�v���[��.Item(8, i).Value = reader.GetValue(8)
                            i += 1
                        End While
                    End If
                End With
            Catch ex As Exception
            Finally

                Me.dgv���Y�f�[�^�v���[��.CurrentCell = Nothing
                CUsrctl.gDp.gSubReaderClose(reader)
            End Try
        Catch ex As Exception
        Finally
            CMdiMain.gSub�������ݒ�(Me, False)
        End Try

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01004_�o�ɐݒ�
            With dlg
                .m��ʃ��[�h = 0    '�o�ɐݒ胂�[�h
                .btnF1.Enabled = False
                .ShowDialog()
            End With

            '��ʂ̍ĕ\��
            ���y���Y�i���()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01004_�o�ɐݒ�
            With dlg
                .m��ʃ��[�h = 1    '�o�ɒ��f�ݒ胂�[�h
                .btnF1.Enabled = False
                .ShowDialog()
            End With

            '��ʂ̍ĕ\��
            ���y���Y�i���()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '��ʂ̍ĕ\��
        ���y���Y�i���()
    End Sub

    Dim int���O�y�[�W����敪 As Integer = 9
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click


        If �t�H�[�J�X Is "�n�[�h" Then
            If Me.dgv���Y�f�[�^�n�[�h.Rows.Count < 0 Then
                Exit Sub
            End If


            If int���O�y�[�W����敪 = 0 Then
                int�J�����g�s = int�J�����g�s - 10
            Else
                int�J�����g�s = int�J�����g�s - 19
            End If

            If int�J�����g�s < 0 Then
                int�J�����g�s = 0

            ElseIf int�J�����g�s > Me.dgv���Y�f�[�^�n�[�h.Rows.Count - 1 Then
                int�J�����g�s = Me.dgv���Y�f�[�^�n�[�h.Rows.Count - 1

            End If

            Me.dgv���Y�f�[�^�n�[�h.CurrentCell = dgv���Y�f�[�^�n�[�h(0, int�J�����g�s)
            Me.dgv���Y�f�[�^�n�[�h.CurrentCell = Nothing

            int���O�y�[�W����敪 = 0
        ElseIf �t�H�[�J�X Is "�v���[��" Then
            If Me.dgv���Y�f�[�^�v���[��.Rows.Count < 0 Then
                Exit Sub
            End If


            If int���O�y�[�W����敪 = 0 Then
                int�J�����g�s = int�J�����g�s - 10
            Else
                int�J�����g�s = int�J�����g�s - 19
            End If

            If int�J�����g�s < 0 Then
                int�J�����g�s = 0

            ElseIf int�J�����g�s > Me.dgv���Y�f�[�^�v���[��.Rows.Count - 1 Then
                int�J�����g�s = Me.dgv���Y�f�[�^�v���[��.Rows.Count - 1

            End If

            Me.dgv���Y�f�[�^�v���[��.CurrentCell = dgv���Y�f�[�^�v���[��(0, int�J�����g�s)
            Me.dgv���Y�f�[�^�v���[��.CurrentCell = Nothing

            int���O�y�[�W����敪 = 0
        End If

    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        If �t�H�[�J�X Is "�n�[�h" Then
            If Me.dgv���Y�f�[�^�n�[�h.Rows.Count < 0 Then
                Exit Sub
            End If

            If int���O�y�[�W����敪 = 1 Then
                int�J�����g�s = int�J�����g�s + 10
            Else
                int�J�����g�s = int�J�����g�s + 19
            End If

            If int�J�����g�s > Me.dgv���Y�f�[�^�n�[�h.Rows.Count - 1 Then
                int�J�����g�s = Me.dgv���Y�f�[�^�n�[�h.Rows.Count - 1
            End If

            Me.dgv���Y�f�[�^�n�[�h.CurrentCell = dgv���Y�f�[�^�n�[�h(0, int�J�����g�s)
            Me.dgv���Y�f�[�^�n�[�h.CurrentCell = Nothing

            int���O�y�[�W����敪 = 1
        ElseIf �t�H�[�J�X Is "�v���[��" Then
            If Me.dgv���Y�f�[�^�v���[��.Rows.Count < 0 Then
                Exit Sub
            End If

            If int���O�y�[�W����敪 = 1 Then
                int�J�����g�s = int�J�����g�s + 10
            Else
                int�J�����g�s = int�J�����g�s + 19
            End If

            If int�J�����g�s > Me.dgv���Y�f�[�^�v���[��.Rows.Count - 1 Then
                int�J�����g�s = Me.dgv���Y�f�[�^�v���[��.Rows.Count - 1
            End If

            Me.dgv���Y�f�[�^�v���[��.CurrentCell = dgv���Y�f�[�^�v���[��(0, int�J�����g�s)
            Me.dgv���Y�f�[�^�v���[��.CurrentCell = Nothing

            int���O�y�[�W����敪 = 1
        End If
    End Sub

    Private Sub dgv���Y�f�[�^�n�[�h_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv���Y�f�[�^�n�[�h.DoubleClick
        If Me.dgv���Y�f�[�^�n�[�h.RowCount <= 0 Then
            Exit Sub
        End If

        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01004_�o�ɐݒ�
            With dlg
                .m��ʃ��[�h = 0    '�o�ɐݒ胂�[�h
                .txt���b�gNo.Text = Me.dgv���Y�f�[�^�n�[�h.Item(1, Me.dgv���Y�f�[�^�n�[�h.CurrentRow.Index).Value
                .txt�T���v��No.Text = Me.dgv���Y�f�[�^�n�[�h.Item(2, Me.dgv���Y�f�[�^�n�[�h.CurrentRow.Index).Value
                .lbl�i�햼.Text = Me.dgv���Y�f�[�^�n�[�h.Item(3, Me.dgv���Y�f�[�^�n�[�h.CurrentRow.Index).Value
                .lbl���蔮�y����.Text = Me.dgv���Y�f�[�^�n�[�h.Item(4, Me.dgv���Y�f�[�^�n�[�h.CurrentRow.Index).Value
                .lbl���y�o�ߎ���.Text = Me.dgv���Y�f�[�^�n�[�h.Item(5, Me.dgv���Y�f�[�^�n�[�h.CurrentRow.Index).Value
                .btnF1.Focus()

                .ShowDialog()
            End With

            '��ʂ̍ĕ\��
            ���y���Y�i���()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try

    End Sub
    Private Sub dgv���Y�f�[�^�v���[��_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv���Y�f�[�^�v���[��.DoubleClick
        If Me.dgv���Y�f�[�^�v���[��.RowCount <= 0 Then
            Exit Sub
        End If

        Me.Timer1.Stop()

        Try
            Dim dlg As New Dlg01004_�o�ɐݒ�
            With dlg
                .m��ʃ��[�h = 0    '�o�ɐݒ胂�[�h
                .txt���b�gNo.Text = Me.dgv���Y�f�[�^�v���[��.Item(1, Me.dgv���Y�f�[�^�v���[��.CurrentRow.Index).Value
                .txt�T���v��No.Text = Me.dgv���Y�f�[�^�v���[��.Item(2, Me.dgv���Y�f�[�^�v���[��.CurrentRow.Index).Value
                .lbl�i�햼.Text = Me.dgv���Y�f�[�^�v���[��.Item(3, Me.dgv���Y�f�[�^�v���[��.CurrentRow.Index).Value
                .lbl���蔮�y����.Text = Me.dgv���Y�f�[�^�v���[��.Item(4, Me.dgv���Y�f�[�^�v���[��.CurrentRow.Index).Value
                .lbl���y�o�ߎ���.Text = Me.dgv���Y�f�[�^�v���[��.Item(5, Me.dgv���Y�f�[�^�v���[��.CurrentRow.Index).Value
                .btnF1.Focus()

                .ShowDialog()
            End With

            '��ʂ̍ĕ\��
            ���y���Y�i���()
        Catch ex As Exception
        Finally
            Me.Timer1.Start()
        End Try

    End Sub

    Private Sub dgv���Y�f�[�^�n�[�h_Enter(sender As Object, e As EventArgs) Handles dgv���Y�f�[�^�n�[�h.Enter
        �t�H�[�J�X = "�n�[�h"
    End Sub

    Private Sub dgv���Y�f�[�^�v���[��_Enter(sender As Object, e As EventArgs) Handles dgv���Y�f�[�^�v���[��.Enter
        �t�H�[�J�X = "�v���[��"
    End Sub
End Class


Imports System.Data.Common
Public Class Frm00003_��p���ݔ���
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

    Private Sub Frm00002_�ݔ���_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To 31
            dgv�ݔ���.Rows.Add()
            dgv�ݔ���(0, i).Value = i + 1
            dgv�ݔ���(1, i).Value = str�ݔ�����(i + 1)
        Next

        �ݔ��󋵍X�V()
        Timer1.Interval = 2000
        Timer1.Start()
        dgv�ݔ���.CurrentCell = Nothing

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Timer1.Stop()

            Dim dlg As New Dlg01999_�g���b�L���O�폜
            With dlg
                .m��ʃ��[�h = 1
                .ShowDialog()
            End With

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Me.dgv�ݔ���.CurrentCell = dgv�ݔ���(0, 0)
        Me.dgv�ݔ���.CurrentCell = Nothing
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        Me.dgv�ݔ���.CurrentCell = dgv�ݔ���(0, 31)
        Me.dgv�ݔ���.CurrentCell = Nothing
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.��p���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub �ݔ��󋵍X�V()
        Dim �f�o�C�XOFFSET As Integer = 6000
        Dim �������C�� As Integer = 0

        '��p�O��
        �M�����X�V(1, �f�o�C�XOFFSET, 0)
        �׏��X�V(1, �f�o�C�XOFFSET, 2, 0)

        '��p�R���x��
        �M�����X�V(1, �f�o�C�XOFFSET + 1, 1)

        �׏��X�V(1, �f�o�C�XOFFSET + 1, 11, 12)
        �׏��X�V(1, �f�o�C�XOFFSET + 1, 10, 13)
        �׏��X�V(1, �f�o�C�XOFFSET + 1, 9, 14)
        �׏��X�V(1, �f�o�C�XOFFSET + 1, 8, 15)
        �׏��X�V(1, �f�o�C�XOFFSET + 1, 7, 16)
        �׏��X�V(1, �f�o�C�XOFFSET + 1, 6, 17)
        �׏��X�V(1, �f�o�C�XOFFSET + 1, 5, 18)
        �׏��X�V(1, �f�o�C�XOFFSET + 1, 4, 19)
        �׏��X�V(1, �f�o�C�XOFFSET + 1, 3, 20)
        �׏��X�V(1, �f�o�C�XOFFSET + 1, 2, 21)

        '����ST
        �M�����X�V(1, �f�o�C�XOFFSET + 2, 22)
        �׏��X�V(1, �f�o�C�XOFFSET + 2, 4, 22)

        '�N���[��
        �N���[���M�����X�V(1, 5002, 23)

        '�o��ST
        �M�����X�V(1, 6003, 24)
        �׏��X�V(1, 6003, 2, 24)

        '�o�ɃR���x��
        �M�����X�V(1, 6004, 25)
        �׏��X�V(1, 6004, 2, 25)

        '�o�ɑO��
        �M�����X�V(1, 6005, 26)
        �׏��X�V(1, 6005, 2, 26)

        '�����R���x��
        �M�����X�V(1, 6006, 27)
        �׏��X�V(1, 6006, 2, 27)

        '�p���^�C�U�O
        �M�����X�V(1, 6007, 28)
        �׏��X�V(1, 6007, 2, 28)

        '�p���^�C�U�P
        �M�����X�V(1, 6007, 29)
        �׏��X�V(1, 6007, 2, 29)

        '�p���^�C�U�Q
        �M�����X�V(1, 6007, 30)
        �׏��X�V(1, 6007, 2, 30)

        '��n�R���x��
        �M�����X�V(1, 6008, 31)
        �׏��X�V(1, 6008, 2, 31)

        '�g���b�L���O�f�[�^�\��
        �g���b�L���O���X�V()
    End Sub

    Private Sub �M�����X�V(ByVal �q�ɋ敪 As Integer, ByVal �f�o�C�XNo As Integer, ByVal Row As Integer)
        If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 0) = 1 Then
            dgv�ݔ���.Item(2, Row).Value = "�ُ�"
        Else
            If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 1) = 1 Then
                dgv�ݔ���.Item(2, Row).Value = "����"
            Else
                dgv�ݔ���.Item(2, Row).Value = "�蓮"
            End If
        End If
    End Sub

    Private Sub �g���b�L���O���X�V()
        Dim i As Integer = 0
        For i = 0 To 31
            Me.dgv�ݔ���.Item(4, i).Value = ""
            Me.dgv�ݔ���.Item(5, i).Value = ""
            Me.dgv�ݔ���.Item(6, i).Value = ""
            Me.dgv�ݔ���.Item(7, i).Value = ""
            Me.dgv�ݔ���.Item(8, i).Value = ""
        Next

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("MAX(A.�X�e�[�^�X)")
                .gSubSelect("MAX(B.�i�햼)")
                .gSubSelect("SUM(A.�����)")
                .gSubSelect("MAX(A.�T���v��No)")
                .gSubSelect("MAX(A.��)")
                .gSubSelect("MAX(A.�A)")
                .gSubSelect("MAX(A.�i)")
                .gSubSelect("A.���b�gNo")
                .gSubSelect("A.�Ǘ�No")
                .gSubFrom("DN�g���b�L���O A")
                .gSubFrom("DM�i�� B")
                .gSubGroupBy("A.���j�b�gSEQ,A.���b�gNo,A.�Ǘ�No")
                .gSubWhere("A.�i��CD = B.�i��CD")
                .gSubWhere("A.�X�e�[�^�X >= 20")
                .gSubOrderBy("MAX(A.��p�J�n����)")

                Dim �}��R���x���\���J�E���g As Integer = 0
                Dim ��n�R���x������ As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        Select Case reader.GetValue(0)
                            Case 20  '�}�⎺�O�f�[�^
                                mSub�ݔ��󋵕\��(0, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 21  '�}��R���x���f�[�^
                                mSub�ݔ��󋵕\��(21 - �}��R���x���\���J�E���g, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))
                                �}��R���x���\���J�E���g += 1

                            Case 22, 23, 24, 25 '����ST&�N���[���w���\��
                                mSub�ݔ��󋵕\��(22, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))
                                Me.dgv�ݔ���.Item(7, 22).Value = reader.GetValue(4) & "-" & reader.GetValue(5) & "-" & reader.GetValue(6)

                            Case 26, 30 '�N���[�����쒆
                                mSub�ݔ��󋵕\��(23, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))
                                Me.dgv�ݔ���.Item(7, 23).Value = reader.GetValue(4) & "-" & reader.GetValue(5) & "-" & reader.GetValue(6)
                                Select Case reader.GetValue(0)
                                    Case 26
                                        Me.dgv�ݔ���.Item(8, 23).Value = "����"
                                    Case 30
                                        Me.dgv�ݔ���.Item(8, 23).Value = "�o��"

                                End Select

                            Case 27, 28, 29 '���Ɋ����`�o�Ɏw����

                            Case 31 '�o��ST
                                mSub�ݔ��󋵕\��(24, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 32 '�o�ɃR���x��
                                mSub�ݔ��󋵕\��(25, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 33 '�o�ɑO��
                                mSub�ݔ��󋵕\��(26, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 34 '�����R���x��
                                mSub�ݔ��󋵕\��(27, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 35 '�p���^�C�U�O
                                mSub�ݔ��󋵕\��(28, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 36 '�p���^�C�U�P
                                mSub�ݔ��󋵕\��(29, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 37 '�p���^�C�U�Q
                                mSub�ݔ��󋵕\��(30, reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                            Case 38 '��n���R���x��
                                ��n�R���x������ += Int(reader.GetValue(2).ToString)
                                mSub�ݔ��󋵕\��(31, reader.GetValue(1), ��n�R���x������, reader.GetValue(3), reader.GetValue(0), reader.GetValue(7), reader.GetValue(8))

                        End Select
                    End While
                End If
            End With

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub mSub�ݔ��󋵕\��(ByVal intRow As Integer, ByVal data1 As String, ByVal data2 As String, ByVal data3 As String, ByVal data4 As String, ByVal data5 As String, ByVal data6 As String)
        Me.dgv�ݔ���.Item(4, intRow).Value = data1
        Me.dgv�ݔ���.Item(5, intRow).Value = data2
        Me.dgv�ݔ���.Item(6, intRow).Value = data3
        'Me.dgv�ݔ���.Item(8, intRow).Value = data4
        Me.dgv�ݔ���.Item(9, intRow).Value = data5
        Me.dgv�ݔ���.Item(10, intRow).Value = data6

    End Sub
    Private Sub �N���[���M�����X�V(ByVal �q�ɋ敪 As Integer, ByVal �f�o�C�XNo As Integer, ByVal Row As Integer)
        If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 5) = 1 Then
            dgv�ݔ���.Item(2, Row).Value = "�ُ�"
        Else
            If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, 7) = 1 Then
                dgv�ݔ���.Item(2, Row).Value = "����"
            Else
                dgv�ݔ���.Item(2, Row).Value = "�蓮"
            End If
        End If
    End Sub

    Private Sub �׏��X�V(ByVal �q�ɋ敪 As Integer, ByVal �f�o�C�XNo As Integer, ByVal �r�b�gNo As Integer, ByVal Row As Integer)
        If CMdiMain.int�f�o�C�X�X�e�[�^�X(�q�ɋ敪, �f�o�C�XNo, �r�b�gNo) = 1 Then
            dgv�ݔ���.Item(3, Row).Value = "�L"
        Else
            dgv�ݔ���.Item(3, Row).Value = ""
        End If
    End Sub

    Private Function str�ݔ�����(ByVal no As Integer) As String
        Dim �ݔ����� As String
        Select Case no
            Case 1
                �ݔ����� = "��p�O��"
            Case 2
                �ݔ����� = "��p�R���x��"
            Case 23
                �ݔ����� = "����ST"
            Case 24
                �ݔ����� = "�N���[��"
            Case 25
                �ݔ����� = "�o��ST"
            Case 26
                �ݔ����� = "�o�ɃR���x��"
            Case 27
                �ݔ����� = "�o�ɑO��"
            Case 28
                �ݔ����� = "�����R���x��"
            Case 29
                �ݔ����� = "�p���^�C�U�O"
            Case 30
                �ݔ����� = "�p���^�C�U�P"
            Case 31
                �ݔ����� = "�p���^�C�U�Q"
            Case 32
                �ݔ����� = "��n�R���x��"
            Case Else
                �ݔ����� = ""
        End Select

        Return �ݔ�����
    End Function

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        �ݔ��󋵍X�V()

    End Sub
End Class


Imports System.Data.Common
Public Class Frm01001_���ɐݒ�
    '#####################################################################################
    '�^
    '#####################################################################################

    '#####################################################################################
    '�����o�ϐ�
    '#####################################################################################
    '���ԕ\��
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

    Dim OFFSET As Integer = 0
    Private Sub Frm01001_���ɐݒ�_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case m��ʃ��[�h
            Case 0
                Me.lbl���C������.Text = "�n�[�h�P"
                OFFSET = 6000
            Case 1
                Me.lbl���C������.Text = "�v���[���P"
                OFFSET = 6004
            Case 2
                Me.lbl���C������.Text = "�n�[�h�Q"
                OFFSET = 6010
            Case Else
        End Select

        '��ʕ\��
        ��ʏ�����()
        ���ɐݒ�\��()
        �T���v�����\��()
        ���b�g�����\��()
        mSub�{�^���X�V()

        Me.Timer1.Interval = 3000
        Me.Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            CMdiMain.gSub�������ݒ�(Me, True)

            ���ɐݒ�\��()
            �T���v�����\��()
            ���b�g�����\��()
            mSub�{�^���X�V()
        Catch ex As Exception
        Finally
            CMdiMain.gSub�������ݒ�(Me, False)
        End Try

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        '��ʕ\��
        ��ʏ�����()

        Dim Dlg As New Dlg01001_���ɐݒ�
        With Dlg
            .m��ʃ��[�h = m��ʃ��[�h
            .ShowDialog()
            Me.lbl���b�gNo.Text = .txt���b�gNo.Text
        End With

        If Me.lbl���b�gNo.Text <> "" Then
            ���ɐݒ�\��()
            �T���v�����\��()
            ���b�g�����\��()
            mSub�{�^���X�V()
        End If
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        If CMsg.gMsg_YesNo("���ɐݒ���폜���Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '���O�擾
        Dim int�i�ϋ@�ډ׏�� As Integer = CMdiMain.int�f�o�C�X�X�e�[�^�X(0, OFFSET + 1, 2)
        If Me.dgv�T���v��.Rows.Count = 0 And int�i�ϋ@�ډ׏�� = 0 Then
            '�f�[�^�폜�̎��s
            Update���ɐݒ�N���A(m��ʃ��[�h)
            '��ʕ\��
            ���ɐݒ�\��()
            �T���v�����\��()
            ���b�g�����\��()
            mSub�{�^���X�V()

        Else
            CMsg.gMsg_�G���[("���ɃN���[�g����������ł��܂��B���b�g���������{���ĉ������B")
            Exit Sub
        End If

    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        '�Y�����C���̊m��א�<>0�̏ꍇ�́A0�ƂȂ�܂Ń��b�g�����s���Ȃ�
        If int�m��א��擾() > 0 Then
            CMsg.gMsg_����("�O�񃍃b�g�̓��ɂ��������Ă��܂���B" & vbCrLf & "�O�񃍃b�g�����ɂ����܂ł��҂���������")
            Exit Sub
        End If

        If CMsg.gMsg_YesNo("���b�g���������s���Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Select Case m��ʃ��[�h
            Case 0
                CMdiMain.Update���b�g����(True, 0)
            Case 1
                CMdiMain.Update���b�g����(True, 1)
            Case 2
                CMdiMain.Update���b�g����(True, 2)
            Case Else
        End Select

        ���ɐݒ�\��()
        �T���v�����\��()
        ���b�g�����\��()
        mSub�{�^���X�V()

    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Dim Dlg As New Dlg01002_�w��T���v�����ݒ�
        With Dlg
            .m��ʃ��[�h = m��ʃ��[�h
            .ShowDialog()

            '��ʕ\��
            ��ʏ�����()
            If Me.lbl���b�gNo.Text <> "" Then
                ���ɐݒ�\��()
                �T���v�����\��()
                ���b�g�����\��()
                mSub�{�^���X�V()
            End If
        End With
    End Sub
    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub ��ʏ�����()
        '�e�L�X�g������
        Me.lbl�i��CD.Text = ""
        Me.lbl�i�햼.Text = ""
        Me.lbl���b�gNo.Text = ""
        Me.lbl�ܖ�����.Text = ""
        Me.lbl���y�J�n����.Text = ""
        Me.lbl���蔮�y����.Text = ""
        Me.lbl�����p����.Text = ""
        Me.lbl���y�I������.Text = ""
    End Sub

    Private Sub ���ɐݒ�\��()
        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("A.�i��CD")
                .gSubSelect("B.�i�햼")
                .gSubSelect("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS")
                .gSubSelect("A.�ܖ�����")
                .gSubSelect("A.���y�J�n����")
                .gSubSelect("B.���蔮�y����")
                .gSubSelect("B.�����p����")
                .gSubFrom("DN�������i A")
                .gSubFrom("DM�i�� B")
                .gSubWhere("A.�������C��", m��ʃ��[�h, , , , , , , False)
                .gSubWhere("A.�i��CD = B.�i��CD")
                Select Case m��ʃ��[�h
                    Case 1      '�v���[�����i
                        .gSubWhere("B.���i�敪 = 1")
                    Case Else   '�n�[�h���i
                        .gSubWhere("B.���i�敪 = 0")
                End Select

                Dim CNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        Me.lbl�i��CD.Text = reader.GetValue(0)
                        Me.lbl�i�햼.Text = reader.GetValue(1)
                        Me.lbl���b�gNo.Text = reader.GetValue(2)
                        Me.lbl�ܖ�����.Text = reader.GetValue(3)
                        Me.lbl���y�J�n����.Text = reader.GetValue(4).ToString
                        Me.lbl���蔮�y����.Text = reader.GetValue(5) & "(��)"
                        Me.lbl�����p����.Text = reader.GetValue(6) & "(��)"
                        Me.lbl���y�I������.Text = str���y�I�������擾(reader.GetValue(4), reader.GetValue(5).ToString)

                        CNT += 1
                    End While

                    If CNT = 0 Then
                        '�\���N���A
                        Me.lbl�i��CD.Text = ""
                        Me.lbl�i�햼.Text = ""
                        Me.lbl���b�gNo.Text = ""
                        Me.lbl�ܖ�����.Text = ""
                        Me.lbl���y�J�n����.Text = ""
                        Me.lbl���蔮�y����.Text = ""
                        Me.lbl�����p����.Text = ""
                        Me.lbl���y�I������.Text = ""
                    End If

                End If


            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub
    Private Function str���y�I�������擾(ByVal ���y�J�n���� As Date, ByVal ���蔭�y���� As String) As String
        Dim ���y�I������ As Date = ���y�J�n����.AddMinutes(Convert.ToInt32(���蔭�y����))
        Return ���y�I������.ToString
    End Function
    Private Function int�m��א��擾() As Integer
        Dim reader As DbDataReader = Nothing
        Dim int�m��א� As Integer = 0
        Try
            With New CSqlEx
                .gSubSelect("A.�m��א�")
                .gSubFrom("DN�������i A")
                .gSubWhere("A.�������C��", m��ʃ��[�h, , , , , , , False)

                Dim CNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        int�m��א� = reader.GetValue(0)
                    End While
                End If

                Return int�m��א�
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Private Sub �T���v�����\��()
        Me.dgv�T���v��.Rows.Clear()

        If Me.lbl���b�gNo.Text = "" Then
            Exit Sub
        End If

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("A.�T���v��No")
                .gSubSelect("MAX(B.�w�萔)")
                .gSubSelect("SUM(A.�����)")
                .gSubFrom("DN�g���b�L���O A")
                .gSubFrom("DN�w��T���v���� B")
                .gSubWhere("A.���b�gNo COLLATE Japanese_CS_AS_KS_WS", Me.lbl���b�gNo.Text, , , , , , , True)
                .gSubWhere("A.�������C��", m��ʃ��[�h, , , , , , , False)
                .gSubWhere("B.�������C�� = A.�������C��")
                .gSubWhere("B.�T���v��No = A.�T���v��No")
                .gSubGroupBy("A.�T���v��No")

                Dim i As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        Me.dgv�T���v��.Rows.Add()
                        Me.dgv�T���v��.Item(0, i).Value = "�T���v��" & reader.GetValue(0)
                        Me.dgv�T���v��.Item(1, i).Value = reader.GetValue(1)
                        Me.dgv�T���v��.Item(2, i).Value = reader.GetValue(2)
                        i += 1
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            Me.dgv�T���v��.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub mSub�{�^���X�V()
        '�폜�{�^��
        '�g���b�L���O�f�[�^�������A�i�ϋ@�����ύڂ̏ꍇ�̂ݗ��p���\�ł��B
        '���b�g�����{�^��
        '�g���b�L���O�f�[�^�����邩�A�i�ϋ@���ύڒ��̏ꍇ�ɂ̂ݗ��p���\�ł��B
        If Me.lbl���b�gNo.Text <> "" Then   '�ݒ蒆
            Me.btnF1.Enabled = False
            Me.btnF4.Enabled = True

            Dim int�i�ϋ@�ډ׏�� As Integer = CMdiMain.int�f�o�C�X�X�e�[�^�X(0, OFFSET + 1, 2)
            If Me.dgv�T���v��.Rows.Count = 0 And int�i�ϋ@�ډ׏�� = 0 Then
                Me.btnF2.Enabled = True
                Me.btnF3.Enabled = False
            Else
                Me.btnF2.Enabled = False
                Me.btnF3.Enabled = True
            End If
        Else
            Me.btnF1.Enabled = True
            Me.btnF2.Enabled = False
            Me.btnF3.Enabled = False
            Me.btnF4.Enabled = False

        End If
    End Sub

    Private Sub ���b�g�����\��()
        Select Case m��ʃ��[�h
            Case 0
                If CMdiMain.bln���b�g�������(0) = True Then
                    pnl���b�Z�[�W.Visible = True
                Else
                    pnl���b�Z�[�W.Visible = False
                End If
            Case 1
                If CMdiMain.bln���b�g�������(1) = True Then
                    pnl���b�Z�[�W.Visible = True
                Else
                    pnl���b�Z�[�W.Visible = False
                End If
            Case 2
                If CMdiMain.bln���b�g�������(2) = True Then
                    pnl���b�Z�[�W.Visible = True
                Else
                    pnl���b�Z�[�W.Visible = False
                End If
            Case Else
        End Select
    End Sub

    '�ᐻ�����i�f�[�^�X�V��
    Public Sub Update���ɐݒ�N���A(ByVal ���C��No As Integer)
        Try
            With New CSql
                .pSQL�擾�^�C�v = CSql.SQL_TYPE.SQL_UPDATE
                .p�e�[�u���� = "DN�������i"
                .gSubColumnValue("�i��CD", "NULL", False)
                .gSubColumnValue("���b�gNo", "NULL", False)
                .gSubColumnValue("�ܖ�����", "NULL", False)
                .gSubColumnValue("���y�J�n����", "NULL", False)
                .gSubColumnValue("�����T���v��No", 1, False)
                .gSubColumnValue("���b�g����", "0", False)
                .gSubColumnValue("�X�V�v���O����", Name, True)
                .gSubColumnValue("�X�V����", "GETDATE()", False)
                .gSubWhere("�������C��", ���C��No, , , , , , , False)

                If Not CUsrctl.gDp.gBlnExecute(.gSQL���̎擾, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

End Class

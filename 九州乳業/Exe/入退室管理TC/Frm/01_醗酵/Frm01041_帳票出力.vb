
Imports System.Data.Common
Public Class Frm01041_���[�o��
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
    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub Frm00001_���C�����j���[_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            '
            If txt����No.Focused = True Then
                '���͂���Ă���f�[�^�����ɉ�ʑJ��
                Select Case txt����No.Text
                    Case "1"
                        If CMsg.gMsg_YesNo("�}�X�^�[���X�g�i�n�[�h�j���o�͂��Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                        '�}�X�^�[�f�[�^
                        With New CSqlEx
                            .gSubSelect("�i��CD as �i��CD")
                            .gSubSelect("�i�햼 as �i�햼")
                            .gSubSelect("���蔮�y���� as ���蔮�y����")
                            .gSubSelect("�����p���� as �����p����")
                            .gSubFrom("DM�i��")
                            .gSubWhere("���i�敪 = 0")
                            .gSubOrderBy("�i��CD")

                            ���[�o��(New �}�X�^�[�ݒ�, "***�}�X�^�[�ݒ�i�n�[�h�j***", .gSQL���̎擾)
                        End With

                    Case "2"
                        If CMsg.gMsg_YesNo("�}�X�^�[���X�g�i�v���[���j���o�͂��Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                        '�}�X�^�[�f�[�^
                        With New CSqlEx
                            .gSubSelect("�i��CD as �i��CD")
                            .gSubSelect("�i�햼 as �i�햼")
                            .gSubSelect("���蔮�y���� as ���蔮�y����")
                            .gSubSelect("�����p���� as �����p����")
                            .gSubFrom("DM�i��")
                            .gSubWhere("���i�敪 = 1")
                            .gSubOrderBy("�i��CD")

                            ���[�o��(New �}�X�^�[�ݒ�, "***�}�X�^�[�ݒ�i�v���[���j***", .gSQL���̎擾)
                        End With

                    Case "3"
                        If CMsg.gMsg_YesNo("�݌Ƀ��X�g�i���y�j���o�͂��Ă���낵���ł����H") = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                        '�}�X�^�[�f�[�^
                        With New CSqlEx
                            .gSubSelect("�i��CD as �i��CD")
                            .gSubSelect("�i�햼 as �i�햼")
                            .gSubSelect("���蔮�y���� as ���蔮�y����")
                            .gSubSelect("�����p���� as �����p����")
                            .gSubFrom("DM�i��")
                            .gSubWhere("���i�敪 = 1")
                            .gSubOrderBy("�i��CD")

                            ���[�o��(New �}�X�^�[�ݒ�, "***�}�X�^�[�ݒ�i�v���[���j***", .gSQL���̎擾)
                        End With

                End Select
                '����
                txt����No.Text = ""
                txt����No.Focus()
            End If
        End If

    End Sub


    Private Sub ���[�o��(ByVal ���|�[�g As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal ���� As String, ByVal strSQL As String)
        Try
            ''�������ݒ�
            Call Me.gMdiMain.gSub�������ݒ�(Me, True, M�萔.MSG_������)

            Call Application.DoEvents()

            Dim reader As DbDataReader = Nothing

            Try
                ''�f�[�^���o
                If Not CUsrctl.gDp.gBlnReader(strSQL, reader) Then
                    Exit Sub
                End If

                If Not reader.Read Then
                    CMsg.gMsg_����("�o�͂����񂪂���܂���")
                    Exit Sub
                End If

                'DataReader�����Ƀf�[�^�e�[�u�����쐬����
                Dim �e�[�u�� As New DataTable

                For i As Integer = 0 To reader.FieldCount - 1
                    �e�[�u��.Columns.Add(reader.GetName(i))
                Next

                ''���׏�������
                Do
                    Dim �R�s�[��̍s As DataRow = �e�[�u��.NewRow
                    For i As Integer = 0 To reader.FieldCount - 1
                        If IsDBNull(reader(i)) Then
                            �R�s�[��̍s(i) = ""
                        Else
                            �R�s�[��̍s(i) = CStr(reader(i)).Trim
                        End If

                    Next
                    �e�[�u��.Rows.Add(�R�s�[��̍s)

                Loop While reader.Read

                With New CReport
                    ���|�[�g.SetDataSource(�e�[�u��)
                    ���|�[�g.DataDefinition.FormulaFields.Item("UnboundString1").Text = "'" & ���� & "'"

                    .Text = ����
                    .������s(���|�[�g, False)
                End With

            Catch ex As Exception
                Call CMsg.gMsg_�G���[(ex.ToString)
                ���|�[�g.Clone()

            Finally
                CUsrctl.gDp.gSubReaderClose(reader)
            End Try

        Catch ex As Exception
            Call CMsg.gMsg_�G���[(ex.ToString)

        Finally
            ''����������
            Me.gMdiMain.gSub�������ݒ�(Me, False, "")
        End Try

    End Sub
End Class

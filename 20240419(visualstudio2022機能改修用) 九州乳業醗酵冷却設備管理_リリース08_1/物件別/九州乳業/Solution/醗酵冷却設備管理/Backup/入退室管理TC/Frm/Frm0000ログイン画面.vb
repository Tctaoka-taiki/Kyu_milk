Imports System.Data.Common

Public Class Frm0000���O�C�����
    '#####################################################################################
    '�^
    '#####################################################################################

    '#####################################################################################
    '�����o�ϐ�
    '#####################################################################################
    Dim mStr�p�X���[�h As String = ""
    '#####################################################################################
    '�v���p�e�B�[
    '#####################################################################################

    '#####################################################################################
    '�C�x���g
    '#####################################################################################

    '#####################################################################################
    '�C�x���g�n���h��
    '#####################################################################################
    Private Sub Frm���O�C�����_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''Me.PictureBox1.Image = Image.FromFile(mstr�摜�t�@�C���Q�Ɛ� & "logo_brand.gif")
        'TxtCODE.Enabled = False
        ''Me.MinimizeBox = True
        ''Me.MaximizeBox = True
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        'Me.ShowInTaskbar = False
        Me.ControlBox = False
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub Usr�I��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Usr�I��.Click
        If CMsg.gMsg_YesNo("�A�v���P�[�V�������I�����Ă���낵���ł����H") = Windows.Forms.DialogResult.Yes Then
            End
        End If
        'Throw New Exception("test")
    End Sub

    Private Sub TxtCODE_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCODE.Leave
        '���̓R�[�h�̊m�F
        �Ǘ��҃R�[�h���͎��̏���(Me.TxtCODE.Text)
    End Sub

    '#####################################################################################
    '�v���V�[�W��
    '#####################################################################################
    Private Sub �Ǘ��҃R�[�h���͎��̏���(ByVal �Ǘ��҃R�[�h As String)
        '������
        CMdiMain.gStr���O�C���Ǘ���ID = ""
        Me.LblNAME.Text = ""
        CMdiMain.gStr���O�C���Ǘ��Җ� = ""
        mStr�p�X���[�h = ""

        If �Ǘ��҃R�[�h = "" Then
            Exit Sub
        End If

        Dim reader As DbDataReader = Nothing
        Try
            With New CSql
                .gSubSelect("�Ǘ���ID")
                .gSubSelect("����")
                .gSubSelect("�p�X���[�h")
                .gSubFrom("DM�Ǘ���")
                .gSubWhere("�Ǘ��҃R�[�h", �Ǘ��҃R�[�h)

                Dim strSQL As String = .gSQL���̎擾

                CUsrctl.gDp.gBlnReader(strSQL, reader)


                While reader.Read
                    CMdiMain.gStr���O�C���Ǘ���ID = reader.GetValue(0).ToString
                    Me.LblNAME.Text = reader.GetValue(1).ToString
                    CMdiMain.gStr���O�C���Ǘ��Җ� = reader.GetValue(1).ToString
                    mStr�p�X���[�h = reader.GetValue(2).ToString

                End While

            End With

        Catch ex As Exception

        Finally

            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub
End Class

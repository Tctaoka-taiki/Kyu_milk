Public Class Frm01413������񃁃��e�i���X
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
    Private Sub Frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mSub�O���b�h�ݒ�()
        'CSV�o�͖͂�����
        Me.BtnCSV�o��.Visible = False
    End Sub

    Private Sub Frm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gRSubF�ĕ\��()
        gRSub�{�^���ݒ�()
    End Sub

    Private Sub btn�ύX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�ύX.Click
        If p�O���b�h.Row < 0 Then
            CMsg.gMsg_����(MSG_�f�[�^���I��)
            Exit Sub
        End If
        �X�V����(enm�����敪.�ύX)
    End Sub

    Private Sub btn�ǉ�_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�ǉ�.Click
        �X�V����(enm�����敪.�ǉ�)
    End Sub

    Private Sub btn�폜_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�폜.Click
        If p�O���b�h.Row < 0 Then
            CMsg.gMsg_����(MSG_�f�[�^���I��)
            Exit Sub
        End If

        If Is�������g�p���Ă���() Then
            Exit Sub
        End If
        �W���폜����()
    End Sub

    Private Sub BtnCSV�o��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCSV�o��.Click
        �O���b�h������CSV�o��()
    End Sub

    Private Sub btn�}�X�^�����e���j���[_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�}�X�^�����e���j���[.Click
        '�}�X�^�����e���j���[
        gMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ�����ގ��Ǘ�.�}�X�^�����e���j���[)
    End Sub

    Private Sub UsrDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles UsrDataGridView1.CellDoubleClick
        With UsrDataGridView1
            '�w�b�_�s�łȂ��ꍇ
            If e.RowIndex >= 0 And btn�ύX.Enabled = True Then
                btn�ύX_Click(sender, e)
            End If
        End With
    End Sub

    '#####################################################################################
    '�v���V�[�W��
    '#####################################################################################
    Private Sub mSub�O���b�h�ݒ�()
        'pFlxGrid = FlxData�����R�[�h
        p�O���b�h = UsrDataGridView1
        With New C����
            .�O���b�h�ݒ�(p�O���b�h)
        End With
    End Sub

    Protected Overrides Function iRStr�\��SQL(Optional ByVal enmSqlType As CSql.SQL_TYPE = CSql.SQL_TYPE.SQL_SELECT) As String
        Return mSQL�擾()
    End Function

    Private Function mSQL�擾(Optional ByVal SQL��� As enmSQL��� = enmSQL���.�ꗗ�\��) As String
        With New CSqlEx
            .gSubClearSQL()
            'SELECT
            If SQL��� = enmSQL���.�ꗗ�\�� Then
                .gSubSelect("DM����.����ID")
            End If
            .gSubSelect("ISNULL(DM���.���̊���,'') ��Ɩ�")
            .gSubSelect("ISNULL(DM����.�����R�[�h,'') �����R�[�h")
            .gSubSelect("ISNULL(DM����.���̊���,'') ������")
            .gSubSelect("ISNULL(DM����.���̃J�i,'') �����J�i��")
            .gSubSelect("ISNULL(DM����.�d�b�ԍ�,'') �d�b�ԍ�")
            .gSubSelect����������("DM����.�X�V����", , True)
            ''FROM
            .gSubFrom("DM���")
            .gSubFrom("DM����")
            ''WHERE
            .gSubWhere("DM���.���ID = DM����.���ID")
            ''ORDER BY
            .gSubOrderBy("DM����.���ID")
            .gSubOrderBy("�����R�[�h")
            .gSubOrderBy("����ID")

            Return .gSQL���̎擾
        End With
    End Function

    Private Sub �X�V����(ByVal o�����敪 As enm�����敪)
        With New Dlg0011�}�X�^��񃁃��e�i���X
            .�e��� = Me
            .�����敪 = o�����敪
            .�����Ώ� = enm�����e�����Ώ�.����

            .Uc����1.�����敪 = o�����敪
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                gRSubF�ĕ\��()
            End If
        End With
    End Sub

    Public Overrides Function �폜����() As Boolean
        With New CSqlEx
            .gSubClearSQL()
            .pSQL�擾�^�C�v = CSql.SQL_TYPE.SQL_DELETE
            .p�e�[�u���� = "DM����"
            .gSubWhere("����ID", p�O���b�h.�Z��������(C����.EnmCol.����ID), , , , , , , False)
            .gSubWhere�X�V����(p�O���b�h.�Z��������(C����.EnmCol.�X�V����))

            Return CUsrctl.�W���폜����(.gSQL���̎擾)
        End With
    End Function

    Private Function Is�������g�p���Ă���() As Boolean
        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM����")
            .gSubWhere("����ID", p�O���b�h.�Z��������(C����.EnmCol.����ID), , , , , , , False)

            If CUsrctl.gDp.ExecuteScalar�ɂ�錏���擾(CUsrctl.gDp.gdb�ڑ�.CreateCommand(), .gSQL���̎擾) > 0 Then
                'CMsg.gMsg_�G���[("�o�^�ҏ��Ŏg�p����Ă��镔���̍폜�͂ł��܂���B")
                CMsg.gMsg_����("�������Ŏg�p����Ă���N���X���̍폜�͂ł��܂���B")
                Return True
            End If
        End With
    End Function
End Class

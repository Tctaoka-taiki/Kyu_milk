Public Class Frm0142��Ƌ敪�����e�i���X

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

        If Is��Ƌ敪���g�p���Ă���() Then
            'CMsg.gMsg_�G���[("��Ə��Ŏg�p����Ă����Ƌ敪�̍폜�͂ł��܂���B")
            CMsg.gMsg_�G���[("���敪���Ŏg�p����Ă����敪�̍폜�͂ł��܂���B")
            Exit Sub
        End If
        �W���폜����()
    End Sub

    Private Sub BtnCSV�o��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCSV�o��.Click
        �O���b�h������CSV�o��()
    End Sub

    Private Sub btn�}�X�^�����e���j���[_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�}�X�^�����e���j���[.Click
        gMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ�����ގ��Ǘ�.�}�X�^�����e���j���[)
    End Sub

    Private Sub UsrDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles UsrDataGridView��Ƌ敪.CellDoubleClick
        With UsrDataGridView��Ƌ敪
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
        p�O���b�h = UsrDataGridView��Ƌ敪
        With New C��Ƌ敪
            .�O���b�h�ݒ�(p�O���b�h)
        End With
    End Sub

    Protected Overrides Function iRStr�\��SQL(Optional ByVal enmSqlType As CSql.SQL_TYPE = CSql.SQL_TYPE.SQL_SELECT) As String
        Return mSQL�擾()
    End Function

    Private Sub �X�V����(ByVal o�����敪 As enm�����敪)
        With New Dlg0011�}�X�^��񃁃��e�i���X
            .�e��� = Me
            .�����敪 = o�����敪
            .�����Ώ� = enm�����e�����Ώ�.��Ƌ敪

            .Uc��Ƌ敪1.�����敪 = o�����敪
            .Uc��Ƌ敪1.�O��X�V���� = p�O���b�h.�Z��������(C��Ƌ敪.EnmCol.�X�V����)
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                gRSubF�ĕ\��()
            End If
        End With
    End Sub

    Public Overrides Function �폜����() As Boolean
        With New CSqlEx
            .gSubClearSQL()
            .pSQL�擾�^�C�v = CSql.SQL_TYPE.SQL_DELETE
            .p�e�[�u���� = "DP��Ƌ敪"
            .gSubWhere("��Ƌ敪ID", p�O���b�h.�Z��������(C��Ƌ敪.EnmCol.��Ƌ敪ID), , , , , , , False)
            .gSubWhere�X�V����(p�O���b�h.�Z��������(C��Ƌ敪.EnmCol.�X�V����))

            Return CUsrctl.�W���폜����(.gSQL���̎擾)
        End With
    End Function

    Private Function mSQL�擾(Optional ByVal SQL��� As enmSQL��� = enmSQL���.�ꗗ�\��) As String
        With New CSqlEx
            'SELECT
            If SQL��� = enmSQL���.�ꗗ�\�� Then
                .gSubSelect("��Ƌ敪ID")
            End If
            .gSubSelect("���� ��Ƌ敪��")
            .gSubSelect����������()
            'FROM
            .gSubFrom("DP��Ƌ敪")
            .gSubWhere("�L���t���O", "1")
            'ORDER BY
            .gSubOrderBy("�\���D�揇")

            Return .gSQL���̎擾
        End With
    End Function

    Private Function Is��Ƌ敪���g�p���Ă���() As Boolean
        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM���")
            .gSubWhere("��Ƌ敪ID", p�O���b�h.�Z��������(C��Ƌ敪.EnmCol.��Ƌ敪ID), , , , , , , False)

            Return CUsrctl.gDp.ExecuteScalar�ɂ�錏���擾(CUsrctl.gDp.gdb�ڑ�.CreateCommand(), .gSQL���̎擾) > 0
        End With
    End Function
End Class

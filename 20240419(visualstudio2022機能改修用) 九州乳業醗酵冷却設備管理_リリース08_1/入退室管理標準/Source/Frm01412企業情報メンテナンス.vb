Public Class Frm01412��Ə�񃁃��e�i���X
    '#####################################################################################
    '�^
    '#####################################################################################
    Public Enum EnmCol
        ���ID
        ��ƃR�[�h
        ��Ƌ敪
        ��Ɩ�
        ��ƃJ�i��
        �d�b�ԍ�
        �X�V����
        cols
    End Enum

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
        Me.btnCSV�o��.Visible = False
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

        If Is��Ƃ��g�p���Ă���() Then
            Exit Sub
        End If
        �W���폜����()
    End Sub

    Private Sub BtnCSV�o��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSV�o��.Click
        �O���b�h������CSV�o��()
    End Sub

    Private Sub btn�}�X�^�����e���j���[_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�}�X�^�����e���j���[.Click
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
        p�O���b�h = UsrDataGridView1
        With p�O���b�h
            .gSub�O���b�h�����ݒ�(EnmCol.cols)

            .gSub�񏉊��ݒ�(EnmCol.���ID, "���ID", 100, C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter)
            .gSub�񏉊��ݒ�(EnmCol.��ƃR�[�h, "���敪CD", 80, C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter)
            .gSub�񏉊��ݒ�(EnmCol.��Ƌ敪, "��敪", 150, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub�񏉊��ݒ�(EnmCol.��Ɩ�, "�w�N", 400, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub�񏉊��ݒ�(EnmCol.��ƃJ�i��, "�Ŗ�", 330, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub�񏉊��ݒ�(EnmCol.�d�b�ԍ�, "�d�b�ԍ�", 100, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub�񏉊��ݒ�(EnmCol.�X�V����, "�X�V����", 172, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)

            .Cols(EnmCol.���ID).Visible = False
            .Cols(EnmCol.��ƃR�[�h).Visible = False
            .Cols(EnmCol.��Ƌ敪).Visible = False
            .Cols(EnmCol.��ƃJ�i��).Visible = False
            .Cols(EnmCol.�d�b�ԍ�).Visible = False
            .Cols(EnmCol.�X�V����).Visible = False
        End With
    End Sub

    Protected Overrides Function iRStr�\��SQL(Optional ByVal enmSqlType As CSql.SQL_TYPE = CSql.SQL_TYPE.SQL_SELECT) As String
        Return mSQL�擾()
    End Function

    Private Function mSQL�擾(Optional ByVal SQL��� As enmSQL��� = enmSQL���.�ꗗ�\��) As String
        With New CSqlEx
            'SELECT
            If SQL��� = enmSQL���.�ꗗ�\�� Then
                .gSubSelect("���ID")
            End If
            .gSubSelect("��ƃR�[�h")
            .gSubSelect("ISNULL(DP��Ƌ敪.����,'') ��Ƌ敪")
            .gSubSelect("ISNULL(DM���.���̊���,'') ��Ɩ�")
            .gSubSelect("ISNULL(DM���.���̃J�i,'') ��ƃJ�i��")
            .gSubSelect("ISNULL(DM���.�d�b�ԍ�,'') �d�b�ԍ�")
            .gSubSelect����������("DM���.�X�V����", , True)
            'FROM
            .gSubFrom("DM���" & _
                      " LEFT JOIN DP��Ƌ敪 ON DM���.��Ƌ敪ID = DP��Ƌ敪.��Ƌ敪ID")
            'WHERE
            'ORDER BY
            .gSubOrderBy("DM���.��ƃR�[�h")
            .gSubOrderBy("DP��Ƌ敪.�\���D�揇")
            .gSubOrderBy("DM���.���ID")

            Return .gSQL���̎擾
        End With
    End Function

    Private Sub �X�V����(ByVal o�����敪 As enm�����敪)
        With New Dlg0011�}�X�^��񃁃��e�i���X
            .�e��� = Me
            .�����敪 = o�����敪
            .�����Ώ� = enm�����e�����Ώ�.���

            .Uc���1.�����敪 = .�����敪
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                gRSubF�ĕ\��()
            End If
        End With
    End Sub

    Public Overrides Function �폜����() As Boolean
        With New CSqlEx
            .pSQL�擾�^�C�v = CSql.SQL_TYPE.SQL_DELETE
            .p�e�[�u���� = "DM���"
            .gSubWhere("���ID", p�O���b�h.�Z��������(EnmCol.���ID), , , , , , , False)
            .gSubWhere�X�V����(p�O���b�h.�Z��������(EnmCol.�X�V����))

            Return CUsrctl.�W���폜����(.gSQL���̎擾)
        End With
    End Function

    Private Function Is��Ƃ��g�p���Ă���() As Boolean
        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM����")
            .gSubWhere("���ID", p�O���b�h.�Z��������(EnmCol.���ID), , , , , , , False)

            If CUsrctl.gDp.ExecuteScalar�ɂ�錏���擾(CUsrctl.gDp.gdb�ڑ�.CreateCommand(), .gSQL���̎擾) > 0 Then
                'CMsg.gMsg_�G���[("�o�^�ҏ��Ŏg�p����Ă����Ƃ̍폜�͂ł��܂���B")
                CMsg.gMsg_����("�������Ŏg�p����Ă���w�N���̍폜�͂ł��܂���B")
                Return True
            End If
        End With

        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM����")
            .gSubWhere("���ID", p�O���b�h.�Z��������(EnmCol.���ID), , , , , , , False)

            If CUsrctl.gDp.ExecuteScalar�ɂ�錏���擾(CUsrctl.gDp.gdb�ڑ�.CreateCommand(), .gSQL���̎擾) > 0 Then
                'CMsg.gMsg_�G���[("�������Ŏg�p����Ă����Ƃ̍폜�͂ł��܂���B")
                CMsg.gMsg_����("�N���X���Ŏg�p����Ă���w�N���̍폜�͂ł��܂���B")
                Return True
            End If
        End With

        'With New CSql
        '    .gSubSelect("COUNT(*)")
        '    .gSubFrom("DM���Ə�")
        '    .gSubWhere("���ID", p�O���b�h.�Z��������(EnmCol.���ID), , , , , , , False)

        '    If CUsrctl.gDp.ExecuteScalar�ɂ�錏���擾(CUsrctl.gDp.gdb�ڑ�.CreateCommand(), .gSQL���̎擾) > 0 Then
        '        'CMsg.gMsg_�G���[("���Ə����Ŏg�p����Ă����Ƃ̍폜�͂ł��܂���B")
        '        CMsg.gMsg_�G���[("���Ə����Ŏg�p����Ă��钆�敪�̍폜�͂ł��܂���B")
        '        Return True
        '    End If
        'End With
    End Function
End Class

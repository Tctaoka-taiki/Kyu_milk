
Imports System.Data.Common

Public Class Frm01012_���y���ɒI���ݒ�
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
    Dim int�J�����g�y�[�W As Integer = 1
    Private Sub Frm01012_���y���ɒI���ݒ�_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        For i = 0 To 23
            Me.dgv�I��1.Rows.Add()
            Me.dgv�I��2.Rows.Add()
            Me.dgv�I��3.Rows.Add()
            Me.dgv�I��4.Rows.Add()
            Me.dgv�I��5.Rows.Add()
        Next
        Me.dgv�I��1.CurrentCell = Nothing
        Me.dgv�I��2.CurrentCell = Nothing
        Me.dgv�I��3.CurrentCell = Nothing
        Me.dgv�I��4.CurrentCell = Nothing
        Me.dgv�I��5.CurrentCell = Nothing

        �q�ɏ��\��()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim dlg As New Dlg01999_�I�����e�i���X�o�^
            With dlg
                .m��ʃ��[�h = 0
                .ShowDialog()

            End With
            �q�ɏ��\��()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Try
            Dim dlg As New Dlg01999_�I�����e�i���X�폜
            With dlg
                .m��ʃ��[�h = 0
                .ShowDialog()

            End With
            �q�ɏ��\��()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Try
            Dim dlg As New Dlg01999_�I�����e�i���X�C��
            With dlg
                .m��ʃ��[�h = 0
                .ShowDialog()

            End With
            �q�ɏ��\��()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Try
            Dim dlg As New Dlg01999_�I�����e�i���X�֎~�I
            With dlg
                .m��ʃ��[�h = 0
                .ShowDialog()

            End With
            �q�ɏ��\��()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI�q�t�H�[�����J��(C��ʐ���I�[�_�[��.���y���C�����j���[)

        Catch ex As Exception
            Call CMdiMain.mSub�G���[�\��(ex)
        End Try
    End Sub

    Private Sub �q�ɏ��\��()
        Dim OFFSET As Integer = 0
        If int�J�����g�y�[�W = 2 Then
            OFFSET = 120
        End If
        Dim i As Integer = 0
        For i = 0 To 23
            Me.dgv�I��1(0, i).Value = i + 1 + OFFSET
            Me.dgv�I��2(0, i).Value = i + 25 + OFFSET
            Me.dgv�I��3(0, i).Value = i + 49 + OFFSET
            Me.dgv�I��4(0, i).Value = i + 73 + OFFSET
            Me.dgv�I��5(0, i).Value = i + 97 + OFFSET
            Me.dgv�I��1(1, i).Value = ""
            Me.dgv�I��2(1, i).Value = ""
            Me.dgv�I��3(1, i).Value = ""
            Me.dgv�I��4(1, i).Value = ""
            Me.dgv�I��5(1, i).Value = ""
        Next

        Application.DoEvents()

        Dim reader As DbDataReader = Nothing
        Dim �� As Integer = 99
        Dim �A As Integer = 99
        Dim �i As Integer = 99

        Try
            With New CSqlEx
                .gSubSelect("������")
                '.gSubSelect("CONVERT(varchar,��) + '-' + CONVERT(varchar,�A) + '-' + CONVERT(varchar,�i) as LOC")
                .gSubSelect("��")
                .gSubSelect("�A")
                .gSubSelect("�i")
                .gSubFrom("DM�I")
                .gSubWhere("�q�ɋ敪", 0, , , , , , , False, )
                .gSubWhere("(�I�敪 = 0 OR �I�敪 = 2)")
                .gSubOrderBy("������")

                If CUsrctl.gDp.gBlnReader(.gSQL���̎擾, reader) Then
                    While reader.Read
                        �f�[�^�\��(reader.GetValue(0).ToString, reader.GetValue(1).ToString & "-" & reader.GetValue(2).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(3).ToString)
                    End While
                End If

            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

    End Sub

    Private Sub �f�[�^�\��(ByVal ������ As Integer, ByVal str�I�Ԓn As String)
        If int�J�����g�y�[�W = 1 Then
            If ������ <= 120 Then
                Select Case Math.Ceiling(������ / 24)
                    Case 1
                        Me.dgv�I��1(1, ������ - 1).Value = str�I�Ԓn
                    Case 2
                        Me.dgv�I��2(1, ������ - 25).Value = str�I�Ԓn
                    Case 3
                        Me.dgv�I��3(1, ������ - 49).Value = str�I�Ԓn
                    Case 4
                        Me.dgv�I��4(1, ������ - 73).Value = str�I�Ԓn
                    Case 5
                        Me.dgv�I��5(1, ������ - 97).Value = str�I�Ԓn

                End Select
            Else
                Exit Sub
            End If
        Else
            If ������ > 120 Then
                ������ = ������ - 120
                Select Case Math.Ceiling(������ / 24)
                    Case 1
                        Me.dgv�I��1(1, ������ - 1).Value = str�I�Ԓn
                    Case 2
                        Me.dgv�I��2(1, ������ - 25).Value = str�I�Ԓn
                    Case 3
                        Me.dgv�I��3(1, ������ - 49).Value = str�I�Ԓn
                    Case 4
                        Me.dgv�I��4(1, ������ - 73).Value = str�I�Ԓn
                    Case 5
                        Me.dgv�I��5(1, ������ - 97).Value = str�I�Ԓn

                End Select

            Else
                Exit Sub
            End If

        End If

    End Sub
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        int�J�����g�y�[�W = 1
        �q�ɏ��\��()
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        int�J�����g�y�[�W = 2
        �q�ɏ��\��()
    End Sub
End Class

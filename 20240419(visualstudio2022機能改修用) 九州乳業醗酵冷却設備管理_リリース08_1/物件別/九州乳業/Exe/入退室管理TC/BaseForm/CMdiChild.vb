Imports System.Data.Common

Public Class CMdiChild
    Implements I�q���

    '#####################################################################################
    '�^
    '#####################################################################################

    '#####################################################################################
    '�����o�ϐ�
    '#####################################################################################
    Public gMdiMain As CMdiMain         '�e�t�H�[���̎Q��

    ''�v���p�e�B�[�̕ϐ�
    Private mctlInitialFocus As Control

    '#####################################################################################
    '�v���p�e�B�[
    '#####################################################################################

    Private m�����敪 As enm�����敪
    Public Property �����敪() As enm�����敪
        Get
            Return m�����敪
        End Get
        Set(ByVal value As enm�����敪)
            m�����敪 = value
        End Set
    End Property

    Private m�O���b�h As UsrDataGridView
    Public Property p�O���b�h() As UsrDataGridView
        Get
            Return m�O���b�h
        End Get
        Set(ByVal Value As UsrDataGridView)
            m�O���b�h = Value
        End Set
    End Property

    Public Property ��ʖ�() As String Implements ��ʕW��.I�q���.��ʖ�
        Get
            Return Me.Name
        End Get
        Set(ByVal value As String)
            Me.Name = value
        End Set
    End Property

    Public Property Mdi�e���() As System.Windows.Forms.Form Implements ��ʕW��.I�q���.Mdi�e���
        Get
            Return MdiParent
        End Get
        Set(ByVal value As System.Windows.Forms.Form)
            MdiParent = value
        End Set
    End Property

    Public m��ʃ��[�h As String
    Public Property ��ʃ��[�h() As String Implements ��ʕW��.I�q���.��ʃ��[�h
        Get
            Return m��ʃ��[�h
        End Get
        Set(ByVal value As String)
            m��ʃ��[�h = value
        End Set
    End Property

#Region "�����t�H�[�J�X���Z�b�g����R���g���[��"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FpInitialFocus
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�t�H�[�����[�h��Ƀt�H�[�J�X���Z�b�g����R���g���[��
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Public Property pInitialFocus() As Control
        Get
            Return Me.mctlInitialFocus
        End Get
        Set(ByVal Value As Control)
            Me.mctlInitialFocus = Value
        End Set
    End Property

    '#####################################################################################
    '�C�x���g
    '#####################################################################################

    '#####################################################################################
    '�C�x���g�n���h��
    '#####################################################################################
#Region "KeyDown�C�x���g"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FKeyDown
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F�G���^�[�L�[�Ŏ��̃R���g���[���ցA�t�@���N�V�����L�[����
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Protected Sub CMdiChild_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim ctlObj As Control
        Dim strKey As String

        Try
            If e.KeyCode = Keys.Enter Then
                ' ''�G���^�[�L�[���e��ʂŏ�������ꍇ�̓I�[�o�[���C�h����B
                If Me.iRBlnKeyEnter(sender, e) Then
                    e.Handled = True
                End If
            Else
                ''�t�@���N�V�����L�[����
                Select Case e.KeyCode
                    Case Keys.F1 To Keys.F12
                        strKey = e.KeyCode.ToString
                        If e.Shift Then
                            strKey = "S" & strKey
                        End If

                        For Each ctlObj In Me.Controls
                            If TypeOf ctlObj Is usrBtn Then
                                If CType(ctlObj, usrBtn).pFuncKey = strKey Then
                                    If ctlObj.Visible And ctlObj.Enabled Then
                                        Call CType(ctlObj, usrBtn).PerformClick()
                                    End If
                                    e.Handled = True
                                    Exit Sub
                                End If
                            End If
                        Next
                        e.Handled = True
                    Case Else
                End Select
            End If
        Catch ex As Exception
            Call C���ފǗ�Ex._Log.WriteLine(ex.StackTrace)
        End Try
    End Sub

#Region "CMdiChild_KeyPress"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�FKeyPress
    ' ���@���@�F
    ' �߂�l�@�F
    ' �@�\�����F��������啶���ɕϊ�
    ' ���@�l�@�F
    '---------------------------------------------------------------------------
#End Region
    Private Sub CMdiChild_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'If Char.IsLetter(e.KeyChar) Then
        '    If Char.IsLower(e.KeyChar) Then
        '        e.Handled = True
        '        SendKeys.Send(CStr(Char.ToUpper(e.KeyChar)))
        '    End If
        'End If
    End Sub

    '#####################################################################################
    '�v���V�[�W��
    '#####################################################################################
    Public Sub ���ʉ�ʏ����ݒ�() Implements ��ʕW��.I�q���.���ʉ�ʏ����ݒ�
        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .ControlBox = False
            .MaximizeBox = False
            .MinimizeBox = False
            .ShowInTaskbar = False

            '�T�C�Y��INI�t�@�C������ݒ�ł���悤�ɂ���
            'Dim intX As Integer = CInt(CUtil.�ݒ�֘A.�ݒ蕶����Ǎ�("��ʃT�C�YX", "1005"))
            'Dim intY As Integer = CInt(CUtil.�ݒ�֘A.�ݒ蕶����Ǎ�("��ʃT�C�YY", "626"))

            '.Size = New Size(intX, intY)

            '.StartPosition = FormStartPosition.Manual
            '.StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .gMdiMain = CType(.ParentForm, CMdiMain)
        End With
    End Sub

    Private Sub CMdiChild_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '�L��btn�ݒ�(Me.Name)
    End Sub

    Private Sub btn������(ByVal str�����敪 As String)
        Dim objControl1 As Control
        Dim objControl2 As Control

        '�q�t�H�[��������
        For Each objControl1 In Me.Controls

            If TypeOf objControl1 Is ����Windows�R���g���[��.usrBtn Then
                objControl1.Enabled = False

                Select Case str�����敪
                    Case "0" '���ׂĎg�p�s��

                    Case "1"    '�\���̂�
                        Select Case objControl1.Name
                            Case "btn����"
                                objControl1.Enabled = True
                            Case "btn�ڍ�"
                                objControl1.Enabled = True
                            Case "btnF2"
                                If Me.Name = "�o�^�ҏ��Ɖ�" Then
                                    objControl1.Enabled = True
                                End If
                            Case "btn�N���A"
                                objControl1.Enabled = True
                            Case "btn���j�^�[�@�\"
                                objControl1.Enabled = True

                            Case "btn�ĕ\��"
                                objControl1.Enabled = True

                        End Select

                    Case "2"    '�\���E����̂�
                        Select Case objControl1.Name
                            Case "btn����"
                                objControl1.Enabled = True
                            Case "btn�ڍ�"
                                objControl1.Enabled = True
                            Case "btnF2"
                                If Me.Name = "�o�^�ҏ��Ɖ�" Then
                                    objControl1.Enabled = True
                                End If
                            Case "btn�N���A"
                                objControl1.Enabled = True
                            Case "btn���"
                                objControl1.Enabled = True
                            Case "btnCSV�o��"
                                objControl1.Enabled = True
                            Case "btn���j�^�[�@�\"
                                objControl1.Enabled = True

                            Case "btn�ĕ\��"
                                objControl1.Enabled = True
                        End Select

                    Case "3"    '���ׂ�
                        objControl1.Enabled = True

                End Select
            End If

            If TypeOf objControl1 Is GroupBox Then
                For Each objControl2 In CType(objControl1, GroupBox).Controls
                    If TypeOf objControl2 Is ����Windows�R���g���[��.usrBtn Then
                        objControl2.Enabled = False

                        Select Case str�����敪
                            Case "0" '���ׂĎg�p�s��

                            Case "1"    '�\���̂�
                                Select Case objControl2.Name
                                    Case "btn����"
                                        objControl2.Enabled = True
                                    Case "btn�ڍ�"
                                        objControl2.Enabled = True
                                    Case "btnF2"
                                        If Me.Name = "�o�^�ҏ��Ɖ�" Then
                                            objControl2.Enabled = True
                                        End If
                                    Case "btn�N���A"
                                        objControl2.Enabled = True
                                    Case "btn���j�^�[�@�\"
                                        objControl1.Enabled = True

                                    Case "btn�ĕ\��"
                                        objControl1.Enabled = True
                                End Select

                            Case "2"    '�\���E����̂�
                                Select Case objControl2.Name
                                    Case "btn����"
                                        objControl2.Enabled = True
                                    Case "btn�ڍ�"
                                        objControl2.Enabled = True
                                    Case "btnF2"
                                        If Me.Name = "�o�^�ҏ��Ɖ�" Then
                                            objControl1.Enabled = True
                                        End If
                                    Case "btn�N���A"
                                        objControl2.Enabled = True
                                    Case "btn���"
                                        objControl2.Enabled = True
                                    Case "btnCSV�o��"
                                        objControl2.Enabled = True
                                    Case "btn���j�^�[�@�\"
                                        objControl1.Enabled = True

                                    Case "btn�ĕ\��"
                                        objControl1.Enabled = True
                                End Select

                            Case "3"    '���ׂ�
                                objControl2.Enabled = True

                        End Select
                    End If
                Next
            End If
            
        Next

    End Sub

    Public Overridable Sub gRSubF�ĕ\��(Optional ByVal bln�{�^���ݒ� As Boolean = True, Optional ByVal bln������ As Boolean = True)
        Dim reader As DbDataReader = Nothing

        Try
            If bln������ = True Then
                ''�\���O����(�ʏ��pFlxGrid�̃N���A�Ə����ʃO���b�h�̐ݒ�)
                Call Me.iRSub�\���O����(Me.p�O���b�h)
            End If

            If CUsrctl.gDp.gBlnReader(Me.iRStr�\��SQL, reader) Then
                ''�\��
                If Not p�O���b�h Is Nothing Then
                    p�O���b�h.�\��(reader)
                    If Not p�O���b�h.�����\�����x�� Is Nothing Then
                        p�O���b�h.�����\�����x��.Text = p�O���b�h.RowCount.ToString
                    End If
                End If
            End If
        Finally
            ''�{�^���ݒ�
            If bln�{�^���ݒ� Then
                Call Me.gRSub�{�^���ݒ�()
            End If

            CUsrctl.gDp.gSubReaderClose(reader)

        End Try
        If p�O���b�h.Rows.Count = 0 Then
            '09/01/19 morichika
            '�Y���f�[�^�Ȃ����͔�\��
            'CMsg.gMsg_���(MSG_�Y���f�[�^�Ȃ�)
        End If
    End Sub

    Public Overridable Function mbln�\������() As Boolean
        Dim reader As DbDataReader = Nothing
        Try
            If CUsrctl.gDp.gBlnReader(Me.iRStr�\��SQL, reader) Then

                If reader Is Nothing Then
                    Exit Function
                End If

                Dim intRowCount As Integer
                While reader.Read

                    intRowCount += 1

                End While

                If intRowCount >= 5000 And intRowCount < 10000 Then
                    If CMsg.gMsg_YesNo("�\��������5000���ȏ�ƂȂ�܂����\�����܂����H") = Windows.Forms.DialogResult.No Then
                        Call Me.gRSub�{�^���ݒ�()
                        Return False
                    End If
                ElseIf intRowCount >= 10000 Then
                    If CMsg.gMsg_YesNo("�\��������10000���ȏ�ƂȂ�܂����\�����܂����H") = Windows.Forms.DialogResult.No Then
                        Call Me.gRSub�{�^���ݒ�()
                        Return False
                    End If
                End If

                Return True
            End If
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Function

    Protected Overridable Sub iRSub�\���O����(ByVal flx As UsrDataGridView)
        CUsrctl.gSub�R���g���[���̏�����(flx)
    End Sub

    Protected Overridable Function iRStr�\��SQL(Optional ByVal enmSqlType As CSql.SQL_TYPE = CSql.SQL_TYPE.SQL_SELECT) As String
        Return ""
    End Function

    ''' <summary>
    ''' �{�^���̗L�������ݒ�
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub gRSub�{�^���ݒ�()
    End Sub

#Region "�t�H�[�J�X�Z�b�g"
    '---------------------------------------------------------------------------
    ' @(f)
    ' �@�@�\�@�F�t�H�[�J�X�Z�b�g
    ' ���@���@�FctlSet:�R���g���[��
    ' �߂�l�@�F
    ' �@�\�����FctlSet�̃C���f�N�b�X���ɃZ�b�g�ł���R���g���[��������ׂăt�H�[�J�X���Z�b�g����B
    ' ���@�l�@�F�^�u�R���g���[���̏ꍇ�̓^�u�y�[�W���A�N�e�B�u�ɂ���
    ' �@�@�@�@�FUsrFlx���͕\���s���Ȃ���΃Z�b�g����Ȃ�
    '---------------------------------------------------------------------------
#End Region
    Public Sub gSubSetFocus(ByVal ParamArray ctlSet() As Control)
        Dim i As Integer

        For i = 0 To UBound(ctlSet)
            If CUsrctl�x�[�X.Is�t�H�[�J�X�Z�b�g�\(ctlSet(i)) Then
                Call Me.mSub�t�H�[�J�X�̃Z�b�g(ctlSet(i))
                Exit Sub
            End If
        Next
    End Sub

    ''�����֐�(Sub)----------------------------------------------------------------------------
    ''' <summary>
    ''' �t�H�[�J�X�̃Z�b�g
    ''' </summary>
    ''' <param name="ctlSet">�R���g���[��</param>
    ''' <remarks>�����R���g���[���̏ꍇ��iSubFocus���Ăяo��</remarks>
    Private Sub mSub�t�H�[�J�X�̃Z�b�g(ByVal ctlSet As Control)
        ctlSet.Focus()
    End Sub

    Protected Overloads Sub iSubFCSV(ByVal reader As DbDataReader, ByVal blnHedda As Boolean)
        Try
            Call Me.gMdiMain.gSub�������ݒ�(Me, True, M�萔.MSG_���s��)

            With New CCsv�o��
                .�o��(reader, blnHedda)
            End With
        Finally
            Me.gMdiMain.gSub�������ݒ�(Me, False, "")
            Call Me.gSubSetFocus(Me.pInitialFocus)
        End Try
    End Sub

    Protected Overloads Sub iSubFCSV(ByVal strSQL As String, ByVal bln�w�b�_ As Boolean)
        Try
            Call Me.gMdiMain.gSub�������ݒ�(Me, True, M�萔.MSG_���s��)

            With New CCsv�o��
                .�o��(strSQL, bln�w�b�_)
            End With
        Finally
            Me.gMdiMain.gSub�������ݒ�(Me, False, "")
            Call Me.gSubSetFocus(Me.pInitialFocus)
        End Try
    End Sub

    Protected Overloads Sub iSubFCSV(ByVal �O���b�h As DataGridView, ByVal Is�w�b�_�o�͂��� As Boolean)
        Try
            Call Me.gMdiMain.gSub�������ݒ�(Me, True, M�萔.MSG_���s��)

            With New CCsv�o��
                .�o��(�O���b�h, Is�w�b�_�o�͂���)
            End With
        Finally
            Me.gMdiMain.gSub�������ݒ�(Me, False, "")
            Call Me.gSubSetFocus(Me.pInitialFocus)
        End Try
    End Sub

    Public Sub �O���b�h������CSV�o��()
        Try
            ''�������ݒ�
            Call Me.gMdiMain.gSub�������ݒ�(Me, True, M�萔.MSG_������)

            iSubFCSV(p�O���b�h, True)
        Catch ex As Exception

        Finally
            ''����������
            Me.gMdiMain.gSub�������ݒ�(Me, False, "")
        End Try
    End Sub

    Public Sub �O���b�h�����Ɉ�����s(ByVal ���|�[�g As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal ���� As String)
        Try
            ''�������ݒ�
            Call Me.gMdiMain.gSub�������ݒ�(Me, True, M�萔.MSG_������)

            With New CReport
                'Dim o���X�g As New �ݏ�҃��X�g
                ���|�[�g.SetDataSource(p�O���b�h.�O���b�h�����Ƀf�[�^�e�[�u�����쐬����)
                .Text = ����
                .������s(���|�[�g)
            End With

        Catch ex As Exception

        Finally
            ''����������
            Me.gMdiMain.gSub�������ݒ�(Me, False, "")

        End Try
    End Sub

    Public Overridable Function �폜����() As Boolean
        CMsg.gMsg_����("����������")
    End Function

    Public Overridable Function �폜�`�F�b�N����() As Boolean
        'CMsg.gMsg_����("����������")
        Return True
    End Function

    Public Sub �W���폜����()
        If p�O���b�h.Row < 0 Then
            CMsg.gMsg_����(MSG_�f�[�^���I��)
            Exit Sub
        End If
        If CUsrctl.gMsg_�X�V�����m�F(enm�����敪.�폜) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim Is�R�~�b�g As Boolean = False
        Try

            If Not �폜�`�F�b�N����() Then
                Exit Sub
            End If

            CUsrctl.gDp.gSub�g�����U�N�V�����J�n()  '�g�����U�N�V�����J�n

            If Not �폜����() Then
                Exit Sub
            End If

            Is�R�~�b�g = True

        Finally
            CUsrctl.gDp.gSub�g�����U�N�V�����I��(Is�R�~�b�g)
        End Try

        If Is�R�~�b�g Then
            CMsg.gMsg_�폜�������b�Z�[�W()
        End If

        Call Me.gRSub�{�^���ݒ�()
        Me.gRSubF�ĕ\��()
    End Sub

    '�I�[�o�[���C�h�\�錾---------------------------------------------------------------
    ''' <summary>
    ''' �G���^�[�L�[�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks>�G���^�[�L�[�̂Ƃ��Ƀ^�u�L�[�𑗂莟�̃R���g���[����(�O���b�h�͏������Ȃ�)
    '''  �G���^�[�L�[�̓�����e��ʂōs���ꍇ�̓I�[�o�[���C�h����</remarks>
    Protected Overridable Function iRBlnKeyEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean
        If TypeOf Me.ActiveControl Is TabControl _
            Or TypeOf Me.ActiveControl Is IEnter�L�[���� Then
            SendKeys.Send("{TAB}")
            Return True
        End If
    End Function

    Public Sub �\��() Implements ��ʕW��.I�q���.�\��
        Show()
    End Sub

    Public Overridable Sub ��ʃN���A(ByVal objform As Form)
        Dim objControl1 As Control
        Dim objControl2 As Control

        Try
            '�q�t�H�[��������
            For Each objControl1 In objform.Controls

                If TypeOf objControl1 Is usrCmb Then
                    CType(objControl1, usrCmb).�N���A()
                End If

                If TypeOf objControl1 Is UsrDataGridView Then
                    CType(objControl1, UsrDataGridView).�N���A()
                End If

                If TypeOf objControl1 Is usrTxt Then
                    CType(objControl1, usrTxt).�N���A()
                End If

                If TypeOf objControl1 Is usrDate Then
                    CType(objControl1, usrDate).�N���A()
                End If

                '�\�������̏�����
                If TypeOf objControl1 Is usrLbl Then
                    If objControl1.Name = "Lbl����" Then
                        objControl1.Text = "-----"
                    End If
                End If

                If TypeOf objControl1 Is GroupBox Then
                    For Each objControl2 In CType(objControl1, GroupBox).Controls
                        If TypeOf objControl2 Is usrCmb Then
                            CType(objControl2, usrCmb).�N���A()
                        End If

                        If TypeOf objControl2 Is UsrDataGridView Then
                            CType(objControl2, UsrDataGridView).�N���A()
                        End If

                        If TypeOf objControl2 Is usrTxt Then
                            CType(objControl2, usrTxt).�N���A()
                        End If

                        If TypeOf objControl2 Is usrDate Then
                            CType(objControl2, usrDate).�N���A()
                        End If

                        '�\�������̏�����
                        If TypeOf objControl2 Is usrLbl Then
                            If objControl2.Name = "Lbl����" Then
                                objControl2.Text = "-----"
                            End If
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            'Call Me.mSub�G���[�\��(ex)
        Finally
            Application.DoEvents()
        End Try
    End Sub

End Class

Public Class CCsv�o��
    Public �_�C�A���O As New SaveFileDialog
    Public Sub New()
        �_�C�A���O.Filter = "csv files (*.csv)|*.csv"
    End Sub

    Private Sub �w�b�_����(ByVal sw As System.IO.StreamWriter, ByVal reader As DbDataReader)
        Dim strCSV As String = ""
        For i As Integer = 0 To reader.FieldCount - 1
            strCSV = strCSV & "," & reader.GetName(i)
        Next
        sw.WriteLine(strCSV.Substring(1))
    End Sub
    Private Sub �w�b�_����(ByVal sw As System.IO.StreamWriter, ByVal �O���b�h As DataGridView)
        Dim strCSV As String = ""
        For Each �� As DataGridViewColumn In �O���b�h.Columns
            If ��.Visible Then
                strCSV = strCSV & "," & ��.Name
            End If
        Next
        sw.WriteLine(strCSV.Substring(1))
    End Sub
    Private Sub �w�b�_����(ByVal sw As System.IO.StreamWriter, ByVal List As ArrayList)
        Dim strCSV As String = ""
        Dim i As Integer
        For i = 0 To List.Count - 1
            strCSV = strCSV & "," & List(i).ToString
        Next
        sw.WriteLine(strCSV.Substring(1))
    End Sub
    Public Sub �o��(ByVal sql As String, ByVal Is�w�b�_�o�͂��� As Boolean)
        Dim reader As DbDataReader = Nothing
        Try
            ''�f�[�^���o
            If Not CUsrctl.gDp.gBlnReader(sql, reader) Then
                Exit Sub
            End If
            �o��(reader, Is�w�b�_�o�͂���)
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub
    Public Sub �o��(ByVal reader As DbDataReader, ByVal Is�w�b�_�o�͂��� As Boolean)
        If Not reader.Read Then
            Exit Sub
        End If

        If �_�C�A���O.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Call Application.DoEvents()

            Dim fs As New System.IO.FileStream(�_�C�A���O.FileName, System.IO.FileMode.OpenOrCreate)
            Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(932))
            'JIS�̏ꍇ�͉��L�̂悤�ɂ���    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(50220))
            'EUC�̏ꍇ�͉��L�̂悤�ɂ���    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(51932))
            Try
                If Is�w�b�_�o�͂��� Then
                    �w�b�_����(sw, reader)
                End If

                ''���׏�������
                Do
                    Dim strCSV As String = ""
                    For i As Integer = 0 To reader.FieldCount - 1
                        If IsDBNull(reader(i)) Then
                            strCSV = strCSV & ",Null"
                        Else
                            strCSV = strCSV & "," & CStr(reader(i)).Trim
                        End If
                    Next
                    sw.WriteLine(strCSV.Substring(1))

                Loop While reader.Read
            Finally
                sw.Close()
            End Try

            CMsg.gMsg_���("CSV�o�͂��܂����B")
        End If
    End Sub

    Public Sub �o��(ByVal �O���b�h As DataGridView, ByVal Is�w�b�_�o�͂��� As Boolean)
        If �_�C�A���O.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Call Application.DoEvents()
            Dim fs As New System.IO.FileStream(�_�C�A���O.FileName, IO.FileMode.Create)
            Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(932))
            'JIS�̏ꍇ�͉��L�̂悤�ɂ���    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(50220))
            'EUC�̏ꍇ�͉��L�̂悤�ɂ���    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(51932))
            Try
                If Is�w�b�_�o�͂��� Then
                    �w�b�_����(sw, �O���b�h)
                End If

                ''���׏�������
                For Each �s As DataGridViewRow In �O���b�h.Rows
                    Dim strCSV As String = ""
                    For Each �� As DataGridViewColumn In �O���b�h.Columns
                        If ��.Visible Then
                            If IsDBNull(�s.Cells(��.Name)) Then
                                strCSV = strCSV & ",Null"
                            Else
                                strCSV = strCSV & "," & CStr(�s.Cells(��.Name).Value).Trim
                            End If
                        End If
                    Next
                    sw.WriteLine(strCSV.Substring(1))
                Next
                CMsg.gMsg_���("CSV�o�͂��܂����B")
            Finally
                sw.Close()
            End Try
        End If
    End Sub

    Public Sub �o��_�w�b�_�̂�(ByVal List As ArrayList, ByVal filename As String)
            Call Application.DoEvents()
        Dim fs As New System.IO.FileStream(filename, IO.FileMode.Create)
        Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(932))
        'JIS�̏ꍇ�͉��L�̂悤�ɂ���    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(50220))
        'EUC�̏ꍇ�͉��L�̂悤�ɂ���    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(51932))
        Try
            �w�b�_����(sw, List)

        Finally
            sw.Close()
        End Try

    End Sub

    Public Sub �o��(ByVal reader As DbDataReader, ByVal filename As String)
        If Not reader.Read Then
            Exit Sub
        End If

        Call Application.DoEvents()

        Dim fs As New System.IO.FileStream(filename, System.IO.FileMode.OpenOrCreate)
        Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(932))
        'JIS�̏ꍇ�͉��L�̂悤�ɂ���    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(50220))
        'EUC�̏ꍇ�͉��L�̂悤�ɂ���    'Dim sw As New System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding(51932))
        Try
            �w�b�_����(sw, reader)

            ''���׏�������
            Do
                Dim strCSV As String = ""
                For i As Integer = 0 To reader.FieldCount - 1
                    If IsDBNull(reader(i)) Then
                        strCSV = strCSV & ",Null"
                    Else
                        strCSV = strCSV & "," & CStr(reader(i)).Trim
                    End If
                Next
                sw.WriteLine(strCSV.Substring(1))

            Loop While reader.Read
        Finally
            sw.Close()
        End Try

    End Sub
End Class

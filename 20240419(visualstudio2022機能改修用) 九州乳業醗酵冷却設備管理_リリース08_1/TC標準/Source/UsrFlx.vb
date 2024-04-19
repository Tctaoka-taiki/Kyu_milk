'*******************************************************************************
' @(h)  UsrFlx.vb
'                                           Ver.1.0 (            T.TADA )
'       **  Version 2.1.20032 ���g�p **
'       C1.Win.C1FlexGrid2  �̎Q�ƒǉ����K�v�ł�
'
'
' @(s)  UsrFlx                             C1.Win.C1FlexGrid.C1FlexGrid���p��
'       �����ݒ肳���쐬�v���p�e�B�[
'       pCondition = EnmCondition.Nomal
'       ��L�ȊO�͏����̌^�̒l�ɂȂ�܂��B
'
'       �����ݒ肳���p�����v���p�e�B�[
'       Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       Styles.Frozen.BackColor = Color.Beige
'       Styles.Alternate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
'       Styles.Fixed.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       ��L�ȊO�͌p�����̏����l�Ɠ����ɂȂ�܂��B
'*******************************************************************************
Imports C1.Win.C1FlexGrid

Public Class usrFlx
    Inherits C1FlexGrid
    Implements I�O���b�h

    Public Const gCstrTOTAL_NAME As String = "TOTAL"
    Public Const gCintTOTAL_ROW As Integer = 2
    Private Const mCintAUTOCOL_SPACE As Integer = 5   '�����񕝐ݒ�g�p���̗]����

    Private mstrID As String = ""
    Private mblnClear As Boolean = True
    Private mblnFixDisply As Boolean
    Private mblnSortReNumber As Boolean

    Private mblnAltermate As Boolean = True
    Private mblnAutoColSize As Boolean
    Private mintAutoColSizeF As Integer
    Private mintAutoColSizeT As Integer

    Private mbtnDClick As Button

    Private mlstTotal As New Generic.List(Of Integer)

    Private mcolorAltermateColor As New System.Drawing.Color


    '�R���X�g���N�^
    Public Sub New()
        MyBase.New()

        '�t�H���g
        Me.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Styles.Fixed.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KeyActionEnter = KeyActionEnum.MoveAcrossOut

        '�F
        Me.mcolorAltermateColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Styles.Frozen.BackColor = Color.Beige

        ''���܂���
        Me.pAltemate = True

    End Sub


    '�v���p�e�B�[-------------------------------------------------------------------
    ''' <summary>
    ''' pID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pID() As String
        Get
            Return mstrID
        End Get
        Set(ByVal Value As String)
            mstrID = Value
        End Set
    End Property

    ''' <summary>
    ''' pIsClear
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pIsClear() As Boolean
        Get
            Return mblnClear
        End Get
        Set(ByVal Value As Boolean)
            mblnClear = Value
        End Set
    End Property

    ''' <summary>
    ''' pIsSortReNumber
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>�\�[�g�����Ƃ��ɌŒ�s�̃i���o�[���ĔԂ���</remarks>
    Public Property pIsSortReNumber() As Boolean
        Get
            Return mblnSortReNumber
        End Get
        Set(ByVal value As Boolean)
            mblnSortReNumber = value
        End Set
    End Property

    ''' <summary>
    ''' �����񕝐ݒ�
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pIsAutoColSize() As Boolean
        Get
            Return mblnAutoColSize
        End Get
        Set(ByVal Value As Boolean)
            mblnAutoColSize = Value
        End Set
    End Property
    Public Property pAutoColSize() As Boolean
        Get
            Return mblnAutoColSize

        End Get
        Set(ByVal value As Boolean)
            mblnAutoColSize = value

        End Set
    End Property

    ''' <summary>
    ''' �����񕝐ݒ�J�n��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pAutoColSizeF() As Integer
        Get
            Return mintAutoColSizeF
        End Get
        Set(ByVal Value As Integer)
            mintAutoColSizeF = Value
        End Set
    End Property

    ''' <summary>
    ''' �����񕝐ݒ�I����
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pAutoColSizeT() As Integer
        Get
            Return mintAutoColSizeT
        End Get
        Set(ByVal Value As Integer)
            mintAutoColSizeT = Value
        End Set
    End Property


    ''' <summary>
    ''' ���܂��ܕ\��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pAltemate() As Boolean
        Get
            Return mblnAltermate
        End Get
        Set(ByVal value As Boolean)
            mblnAltermate = value
            If value Then
                Me.Styles.Alternate.BackColor = Me.mcolorAltermateColor
            Else
                Me.Styles.Alternate.BackColor = System.Drawing.SystemColors.Window
            End If
        End Set
    End Property

    ''' <summary>
    ''' �_�u���N���b�N�����Ƃ��̊��蓖�ă{�^��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pDclicBtn() As Button
        Get
            Return mbtnDClick
        End Get
        Set(ByVal Value As Button)
            mbtnDClick = Value
        End Set
    End Property


    ''' <summary>
    ''' �\���s�̊J�nIndex
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pStartRow() As Integer
        Get
            Return Me.Rows.Fixed + Me.Rows.Frozen
        End Get
    End Property

    ''' <summary>
    ''' �\���s�̏I��Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pEndRow() As Integer
        Get
            Return Me.Rows.Count - 1
        End Get
    End Property


    ''' <summary>
    ''' �\���s�̗L��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pIsDisply() As Boolean
        Get
            If Me.pDisplyCount = 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    ''' <summary>
    ''' �\���s��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pDisplyCount() As Integer
        Get
            Return Me.Rows.Count - Me.pStartRow
        End Get
    End Property


    '�C�x���g-------------------------------------------------------------------
    ''' <summary>
    ''' �\���s�̃_�u���N���b�N�Ń{�^���N���b�N�C�x���g���Ăяo��
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrFlx_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        ''�{�^���������Ă��邱��
        If Me.pDclicBtn Is Nothing Then

            ''Button�ł��邱��
        ElseIf Not TypeOf Me.pDclicBtn Is Button Then

            ''�\�������邱��
        ElseIf Not Me.pIsDisply Then

            ''�Œ�s�̃_�u���N���b�N�͔����Ȃ�
        ElseIf Me.MouseRow < Me.pStartRow Then

        Else
            ''�{�^���N���b�N�Ăяo��
            Call Me.pDclicBtn.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' ���̓��[�h�ł�Delete��Back�ł̓��̓N���A
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub usrFlx_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            If Me.SelectionMode = SelectionModeEnum.Cell Then
                Dim intCol As Integer
                Dim intRow As Integer

                For intRow = Me.Selection.r1 To Me.Selection.r2
                    For intCol = Me.Selection.c1 To Me.Selection.c2
                        Me.SetData(intRow, intCol, "")
                    Next
                Next
            End If
        End If
    End Sub

    ''' <summary>
    ''' �\�[�g�̌�Ƀw�b�_�s���ĔԂ���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub usrFlx_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles Me.AfterSort
        If Me.pIsSortReNumber Then
            Me.gSubRowHedderRenumber()
        End If
    End Sub

    '���\�b�h-------------------------------------------------------------------
    ''' <summary>
    ''' ������
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubAutoColSize()
        Me.AutoSizeCols(Me.pAutoColSizeF, Me.pAutoColSizeT, mCintAUTOCOL_SPACE)
    End Sub

    ''' <summary>
    ''' �O���b�h�����ݒ�
    ''' </summary>
    ''' <param name="intCols"></param>
    ''' <param name="intColFrozen"></param>
    ''' <param name="EnmSelectionMode"></param>
    ''' <param name="blnRowHedder"></param>
    ''' <param name="blnEdit"></param>
    ''' <param name="EnmSort"></param>
    ''' <param name="EnmDragg"></param>
    ''' <param name="EnmResize"></param>
    ''' <param name="EnmHighLight"></param>
    ''' <param name="EnmFocusRect"></param>
    ''' <param name="FixdDisply"></param>
    ''' <remarks></remarks>
    Public Sub gSub�O���b�h�����ݒ�( _
            ByVal intCols As Integer _
            , Optional ByVal intColFrozen As Integer = -1 _
            , Optional ByVal EnmSelectionMode As SelectionModeEnum = SelectionModeEnum.ListBox _
            , Optional ByVal blnRowHedder As Boolean = False _
            , Optional ByVal blnEdit As Boolean = False _
            , Optional ByVal EnmSort As AllowSortingEnum = AllowSortingEnum.SingleColumn _
            , Optional ByVal EnmDragg As AllowDraggingEnum = AllowDraggingEnum.None _
            , Optional ByVal EnmResize As AllowResizingEnum = AllowResizingEnum.Columns _
            , Optional ByVal EnmHighLight As HighLightEnum = HighLightEnum.Always _
            , Optional ByVal EnmFocusRect As FocusRectEnum = FocusRectEnum.None _
            , Optional ByVal FixdDisply As Integer = -1 _
            )
        Dim i As Integer

        ''�g�[�^����N���A
        Me.mlstTotal.Clear()
        With Me
            ''�I���`��
            .SelectionMode = EnmSelectionMode
            ''��̃h���b�O�ړ�
            .AllowDragging = EnmDragg
            ''�Z���̕ҏW
            .AllowEditing = blnEdit
            '�񕝕ύX
            .AllowResizing = EnmResize
            ''�\�[�g
            .AllowSorting = EnmSort
            ''�\�[�g��̕\��
            .ShowSort = False
            ''�I���Z���̐ݒ�
            .HighLight = EnmHighLight
            .FocusRect = EnmFocusRect
            ''�G���^�[�L�[�̑��삵�Ȃ�
            '.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
            ''�Œ�s�܂�Ԃ��ݒ�
            .Styles.Fixed.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly

            ''�s�w�b�_�ݒ�
            If blnRowHedder Then
                .Cols.Fixed = 1
                ''�\���Œ��
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen
                    ''�Œ�s�̃h���b�O�͋֎~
                    For i = 1 To intColFrozen - 1
                        .Cols(i).AllowDragging = False
                    Next
                End If
            Else
                .Cols.Fixed = 0
                ''�\���Œ��
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen + 1
                    ''�Œ�s�̃h���b�O�͋֎~
                    For i = 0 To intColFrozen - 1
                        .Cols(i).AllowDragging = False
                    Next
                End If
            End If
            .Cols.Count = intCols

            ''��w�b�_�ݒ�
            .Rows.Fixed = 2
            .Rows.Count = 2

            ''�Œ�s�}�[�W�ݒ�
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next

            ''�Œ�s�\��
            If FixdDisply > 0 Then
                Me.pIsFixDisply = True
                Me.Rows.Count = Me.Rows.Fixed + FixdDisply
            End If
        End With
    End Sub

    ''' <summary>
    ''' �O���b�h�����ݒ�
    ''' </summary>
    ''' <param name="intCols"></param>
    ''' <param name="intColFrozen"></param>
    ''' <param name="EnmSelectionMode"></param>
    ''' <param name="blnRowHedder"></param>
    ''' <param name="blnEdit"></param>
    ''' <param name="EnmSort"></param>
    ''' <param name="EnmDragg"></param>
    ''' <param name="EnmResize"></param>
    ''' <param name="EnmHighLight"></param>
    ''' <param name="EnmFocusRect"></param>
    ''' <param name="FixdDisply"></param>
    ''' <remarks>���v�s��</remarks>
    Public Sub gSubInitialData_Total( _
            ByVal intCols As Integer _
            , Optional ByVal intColFrozen As Integer = -1 _
            , Optional ByVal EnmSelectionMode As SelectionModeEnum = SelectionModeEnum.ListBox _
            , Optional ByVal blnRowHedder As Boolean = False _
            , Optional ByVal blnEdit As Boolean = False _
            , Optional ByVal EnmSort As AllowSortingEnum = AllowSortingEnum.SingleColumn _
            , Optional ByVal EnmDragg As AllowDraggingEnum = AllowDraggingEnum.None _
            , Optional ByVal EnmResize As AllowResizingEnum = AllowResizingEnum.Columns _
            , Optional ByVal EnmHighLight As HighLightEnum = HighLightEnum.Always _
            , Optional ByVal EnmFocusRect As FocusRectEnum = FocusRectEnum.None _
            , Optional ByVal FixdDisply As Integer = -1 _
            )
        Dim i As Integer

        ''�g�[�^����N���A
        Me.mlstTotal.Clear()

        With Me
            ''�I���`��
            .SelectionMode = EnmSelectionMode
            ''��̃h���b�O�ړ�
            .AllowDragging = EnmDragg
            ''�Z���̕ҏW
            .AllowEditing = blnEdit
            '�񕝕ύX
            .AllowResizing = EnmResize
            ''�\�[�g
            .AllowSorting = EnmSort
            ''�\�[�g���\��
            .ShowSort = False

            ''�I���Z���̐ݒ�
            .HighLight = EnmHighLight
            .FocusRect = EnmFocusRect
            ''�G���^�[�L�[�̑��삵�Ȃ�
            '.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
            ''�Œ�s�܂�Ԃ��ݒ�
            .Styles.Fixed.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly

            ''�s�w�b�_�ݒ�
            If blnRowHedder Then
                .Cols.Fixed = 1
                ''�\���Œ��
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen
                    ''�Œ�s�̃h���b�O�͋֎~
                    For i = 1 To intColFrozen
                        .Cols(i).AllowDragging = False
                    Next
                End If
            Else
                .Cols.Fixed = 0
                ''�\���Œ��
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen + 1
                    ''�Œ�s�̃h���b�O�͋֎~
                    For i = 0 To intColFrozen
                        .Cols(i).AllowDragging = False
                    Next
                End If
            End If
            .Cols.Count = intCols

            ''��w�b�_�ݒ�
            .Rows.Fixed = 3
            .Rows.Count = 3

            ''���v�s
            Dim style As CellStyle
            style = .Styles.Add(gCstrTOTAL_NAME)
            style.BackColor = Color.LightYellow
            style.TextAlign = TextAlignEnum.RightCenter

            For i = 0 To .Cols.Count - 1
                .SetCellStyle(gCintTOTAL_ROW, i, style)
            Next

            ''�Œ�s�}�[�W�ݒ�
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 2
                .Rows(i).AllowMerging = True
            Next

            ''�Œ�s�\��
            If FixdDisply > 0 Then
                Me.pIsFixDisply = True
                Me.Rows.Count = Me.Rows.Fixed + FixdDisply
            End If

        End With
    End Sub


    ''' <summary>
    ''' �񏉊��ݒ�
    ''' </summary>
    ''' <param name="intCol"></param>
    ''' <param name="strTitle">��̃w�b�_��(�J���}�ŋ�؂�ƃ}�[�W)</param>
    ''' <param name="intWith"></param>
    ''' <param name="enmAlign"></param>
    ''' <param name="blnDisplyNum"></param>
    ''' <param name="blnVisible"></param>
    ''' <param name="blnEdit"></param>
    ''' <param name="strFormat"></param>
    ''' <param name="objType"></param>
    ''' <param name="objMap"></param>
    ''' <param name="strComboList"></param>
    ''' <param name="strMask"></param>
    ''' <param name="blnTotal"></param>
    ''' <param name="enmFixedAlign"></param>
    ''' <remarks></remarks>
    Public Sub gSub�񏉊��ݒ�( _
         ByVal intCol As Integer _
        , ByVal strTitle As String _
        , ByVal intWith As Integer _
        , ByVal enmAlign As TextAlignEnum _
        , Optional ByVal blnDisplyNum As Boolean = False _
        , Optional ByVal blnVisible As Boolean = True _
        , Optional ByVal blnEdit As Boolean = False _
        , Optional ByVal strFormat As String = "" _
        , Optional ByVal objType As Type = Nothing _
        , Optional ByVal objMap As Hashtable = Nothing _
        , Optional ByVal strComboList As String = "" _
        , Optional ByVal strMask As String = "" _
        , Optional ByVal blnTotal As Boolean = False _
        , Optional ByVal enmFixedAlign As TextAlignEnum = TextAlignEnum.CenterCenter _
    )
        Dim intP As Integer

        With Me.Cols(intCol)
            ''��ݒ�
            .Name = intCol.ToString
            intP = InStr(strTitle, ",")
            If intP > 0 Then
                Me(0, intCol) = strTitle.Substring(0, intP - 1)
                Me(1, intCol) = strTitle.Substring(intP)
            Else
                Me(0, intCol) = strTitle
                Me(1, intCol) = strTitle
            End If
            '.Caption = strTitle

            ''���l�\��
            If blnDisplyNum Then
                .Format = "#,##0"
                .DataType = GetType(Long)
            Else
                .DataType = GetType(String)
            End If

            ''�^�C�v
            If Not objType Is Nothing Then
                .DataType = objType
            End If

            ''�t�H�[�}�b�g
            If strFormat <> "" Then
                .Format = strFormat
            End If

            ''Map�ݒ�
            If Not objMap Is Nothing Then
                .DataMap = objMap
            Else
                .DataMap = Nothing
            End If

            ''�R���{�ݒ�
            If strComboList <> "" Then
                .ComboList = strComboList
            End If

            ''�}�X�N
            If strMask <> "" Then
                .EditMask = strMask
            End If

            .TextAlignFixed = enmFixedAlign
            .TextAlign = enmAlign
            .Width = intWith
            .Visible = blnVisible
            .AllowEditing = blnEdit

            ''���v��
            If blnTotal Then
                Me.mlstTotal.Add(intCol)
            End If
        End With
    End Sub

    ''' <summary>
    ''' ���v�s�̌v�Z���ĕ\��
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubSetTotal()
        If Me.mlstTotal.Count = 0 Then
            Exit Sub
        End If

        Dim dlbTotal As Double
        For Each intCol As Integer In Me.mlstTotal
            dlbTotal = 0
            For i As Integer = Me.pStartRow To Me.pEndRow
                If Me.GetDataDisplay(i, intCol).TrimEnd <> "" Then
                    dlbTotal += CDbl(Me.GetData(i, intCol))
                End If
            Next
            Me(gCintTOTAL_ROW, intCol) = Format(dlbTotal, Me.Cols(intCol).Format)
        Next
        Me.Rows(gCintTOTAL_ROW).StyleNew.Font = New System.Drawing.Font("�l�r �S�V�b�N", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    End Sub

    ''' <summary>
    ''' ���v�s���N���A
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubClearTotal()
        If Me.Rows.Fixed = 3 Then
            For Each intCol As Integer In Me.mlstTotal
                Me(gCintTOTAL_ROW, intCol) = ""
            Next
        End If
    End Sub

    ''' <summary>
    ''' �I���s���폜����
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubSelectDelete()
        If Me.SelectionMode = SelectionModeEnum.Row Then
            Me.Rows.Remove(Me.Row)
        Else
            For Each objRow As Row In Me.Rows.Selected
                Me.Rows.Remove(objRow.Index)
            Next
        End If
    End Sub

    ''' <summary>
    ''' �w�b�_�s�̔ԍ��̍Ĕ�
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubRowHedderRenumber()
        Dim intNum As Integer

        For i As Integer = Me.pStartRow To Me.pEndRow
            intNum += 1
            Me.SetData(i, 0, intNum)
        Next
    End Sub


    ''�e�X�g�p
    Public Sub gSubCol�C�~�f�B�G�C�g()
        For i As Integer = 0 To Me.Cols.Count - 1
            Debug.WriteLine(CStr(i) & ":" & Me.Cols(i).Width)
        Next
    End Sub

    Private Sub InitializeComponent()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'usrFlx
        '
        Me.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Rows.DefaultSize = 16
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    ''' <summary>
    ''' �J�����g�s�̎w���̃Z���������Ԃ�
    ''' </summary>
    ''' <param name="col"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function �Z��������(ByVal col As Integer) As String Implements I�O���b�h.�Z��������
        Return �Z��������(Me.Row, col)
    End Function
    Public Function �Z��������(ByVal row As Integer, ByVal col As Integer) As String Implements I�O���b�h.�Z��������
        If row >= 0 Then
            Return GetDataDisplay(row, col)
        Else
            Return ""
        End If
    End Function
    Public Function �Z�����e(ByVal col As Integer) As Object Implements I�O���b�h.�Z�����e
        Return GetData(Me.Row, col)
    End Function
    ''' <summary>
    ''' pIsFixDisply
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>�Œ�s�\��</remarks>
    Public Property pIsFixDisply() As Boolean
        Get
            Return mblnFixDisply
        End Get
        Set(ByVal value As Boolean)
            mblnFixDisply = value
        End Set
    End Property

End Class

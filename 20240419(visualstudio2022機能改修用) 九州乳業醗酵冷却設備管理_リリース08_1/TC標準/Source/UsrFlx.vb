'*******************************************************************************
' @(h)  UsrFlx.vb
'                                           Ver.1.0 (            T.TADA )
'       **  Version 2.1.20032 を使用 **
'       C1.Win.C1FlexGrid2  の参照追加が必要です
'
'
' @(s)  UsrFlx                             C1.Win.C1FlexGrid.C1FlexGridを継承
'       初期設定される作成プロパティー
'       pCondition = EnmCondition.Nomal
'       上記以外は初期の型の値になります。
'
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       Styles.Frozen.BackColor = Color.Beige
'       Styles.Alternate.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
'       Styles.Fixed.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************
Imports C1.Win.C1FlexGrid

Public Class usrFlx
    Inherits C1FlexGrid
    Implements Iグリッド

    Public Const gCstrTOTAL_NAME As String = "TOTAL"
    Public Const gCintTOTAL_ROW As Integer = 2
    Private Const mCintAUTOCOL_SPACE As Integer = 5   '自動列幅設定使用時の余白幅

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


    'コンストラクタ
    Public Sub New()
        MyBase.New()

        'フォント
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Styles.Fixed.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.KeyActionEnter = KeyActionEnum.MoveAcrossOut

        '色
        Me.mcolorAltermateColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Styles.Frozen.BackColor = Color.Beige

        ''しましま
        Me.pAltemate = True

    End Sub


    'プロパティー-------------------------------------------------------------------
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
    ''' <remarks>ソートしたときに固定行のナンバーを再番する</remarks>
    Public Property pIsSortReNumber() As Boolean
        Get
            Return mblnSortReNumber
        End Get
        Set(ByVal value As Boolean)
            mblnSortReNumber = value
        End Set
    End Property

    ''' <summary>
    ''' 自動列幅設定
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
    ''' 自動列幅設定開始列
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
    ''' 自動列幅設定終了列
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
    ''' しましま表示
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
    ''' ダブルクリックしたときの割り当てボタン
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
    ''' 表示行の開始Index
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
    ''' 表示行の終了Index
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
    ''' 表示行の有無
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
    ''' 表示行数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pDisplyCount() As Integer
        Get
            Return Me.Rows.Count - Me.pStartRow
        End Get
    End Property


    'イベント-------------------------------------------------------------------
    ''' <summary>
    ''' 表示行のダブルクリックでボタンクリックイベントを呼び出す
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrFlx_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        ''ボタンがわりついていること
        If Me.pDclicBtn Is Nothing Then

            ''Buttonであること
        ElseIf Not TypeOf Me.pDclicBtn Is Button Then

            ''表示があること
        ElseIf Not Me.pIsDisply Then

            ''固定行のダブルクリックは発動なし
        ElseIf Me.MouseRow < Me.pStartRow Then

        Else
            ''ボタンクリック呼び出し
            Call Me.pDclicBtn.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' 入力モードでのDeleteとBackでの入力クリア
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
    ''' ソートの後にヘッダ行を再番する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub usrFlx_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles Me.AfterSort
        If Me.pIsSortReNumber Then
            Me.gSubRowHedderRenumber()
        End If
    End Sub

    'メソッド-------------------------------------------------------------------
    ''' <summary>
    ''' 自動列幅
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubAutoColSize()
        Me.AutoSizeCols(Me.pAutoColSizeF, Me.pAutoColSizeT, mCintAUTOCOL_SPACE)
    End Sub

    ''' <summary>
    ''' グリッド初期設定
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
    Public Sub gSubグリッド初期設定( _
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

        ''トータル列クリア
        Me.mlstTotal.Clear()
        With Me
            ''選択形式
            .SelectionMode = EnmSelectionMode
            ''列のドラッグ移動
            .AllowDragging = EnmDragg
            ''セルの編集
            .AllowEditing = blnEdit
            '列幅変更
            .AllowResizing = EnmResize
            ''ソート
            .AllowSorting = EnmSort
            ''ソート印の表示
            .ShowSort = False
            ''選択セルの設定
            .HighLight = EnmHighLight
            .FocusRect = EnmFocusRect
            ''エンターキーの操作しない
            '.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
            ''固定行折り返し設定
            .Styles.Fixed.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly

            ''行ヘッダ設定
            If blnRowHedder Then
                .Cols.Fixed = 1
                ''表示固定列
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen
                    ''固定行のドラッグは禁止
                    For i = 1 To intColFrozen - 1
                        .Cols(i).AllowDragging = False
                    Next
                End If
            Else
                .Cols.Fixed = 0
                ''表示固定列
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen + 1
                    ''固定行のドラッグは禁止
                    For i = 0 To intColFrozen - 1
                        .Cols(i).AllowDragging = False
                    Next
                End If
            End If
            .Cols.Count = intCols

            ''列ヘッダ設定
            .Rows.Fixed = 2
            .Rows.Count = 2

            ''固定行マージ設定
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next

            ''固定行表示
            If FixdDisply > 0 Then
                Me.pIsFixDisply = True
                Me.Rows.Count = Me.Rows.Fixed + FixdDisply
            End If
        End With
    End Sub

    ''' <summary>
    ''' グリッド初期設定
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
    ''' <remarks>合計行つき</remarks>
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

        ''トータル列クリア
        Me.mlstTotal.Clear()

        With Me
            ''選択形式
            .SelectionMode = EnmSelectionMode
            ''列のドラッグ移動
            .AllowDragging = EnmDragg
            ''セルの編集
            .AllowEditing = blnEdit
            '列幅変更
            .AllowResizing = EnmResize
            ''ソート
            .AllowSorting = EnmSort
            ''ソート矢印表示
            .ShowSort = False

            ''選択セルの設定
            .HighLight = EnmHighLight
            .FocusRect = EnmFocusRect
            ''エンターキーの操作しない
            '.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
            ''固定行折り返し設定
            .Styles.Fixed.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly

            ''行ヘッダ設定
            If blnRowHedder Then
                .Cols.Fixed = 1
                ''表示固定列
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen
                    ''固定行のドラッグは禁止
                    For i = 1 To intColFrozen
                        .Cols(i).AllowDragging = False
                    Next
                End If
            Else
                .Cols.Fixed = 0
                ''表示固定列
                If intColFrozen >= 0 Then
                    .Cols.Frozen = intColFrozen + 1
                    ''固定行のドラッグは禁止
                    For i = 0 To intColFrozen
                        .Cols(i).AllowDragging = False
                    Next
                End If
            End If
            .Cols.Count = intCols

            ''列ヘッダ設定
            .Rows.Fixed = 3
            .Rows.Count = 3

            ''合計行
            Dim style As CellStyle
            style = .Styles.Add(gCstrTOTAL_NAME)
            style.BackColor = Color.LightYellow
            style.TextAlign = TextAlignEnum.RightCenter

            For i = 0 To .Cols.Count - 1
                .SetCellStyle(gCintTOTAL_ROW, i, style)
            Next

            ''固定行マージ設定
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 2
                .Rows(i).AllowMerging = True
            Next

            ''固定行表示
            If FixdDisply > 0 Then
                Me.pIsFixDisply = True
                Me.Rows.Count = Me.Rows.Fixed + FixdDisply
            End If

        End With
    End Sub


    ''' <summary>
    ''' 列初期設定
    ''' </summary>
    ''' <param name="intCol"></param>
    ''' <param name="strTitle">列のヘッダ名(カンマで区切るとマージ)</param>
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
    Public Sub gSub列初期設定( _
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
            ''列設定
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

            ''数値表示
            If blnDisplyNum Then
                .Format = "#,##0"
                .DataType = GetType(Long)
            Else
                .DataType = GetType(String)
            End If

            ''タイプ
            If Not objType Is Nothing Then
                .DataType = objType
            End If

            ''フォーマット
            If strFormat <> "" Then
                .Format = strFormat
            End If

            ''Map設定
            If Not objMap Is Nothing Then
                .DataMap = objMap
            Else
                .DataMap = Nothing
            End If

            ''コンボ設定
            If strComboList <> "" Then
                .ComboList = strComboList
            End If

            ''マスク
            If strMask <> "" Then
                .EditMask = strMask
            End If

            .TextAlignFixed = enmFixedAlign
            .TextAlign = enmAlign
            .Width = intWith
            .Visible = blnVisible
            .AllowEditing = blnEdit

            ''合計列
            If blnTotal Then
                Me.mlstTotal.Add(intCol)
            End If
        End With
    End Sub

    ''' <summary>
    ''' 合計行の計算を再表示
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
        Me.Rows(gCintTOTAL_ROW).StyleNew.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    End Sub

    ''' <summary>
    ''' 合計行をクリア
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
    ''' 選択行を削除する
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
    ''' ヘッダ行の番号の再番
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubRowHedderRenumber()
        Dim intNum As Integer

        For i As Integer = Me.pStartRow To Me.pEndRow
            intNum += 1
            Me.SetData(i, 0, intNum)
        Next
    End Sub


    ''テスト用
    Public Sub gSubColイミディエイト()
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
    ''' カレント行の指定列のセル文字列を返す
    ''' </summary>
    ''' <param name="col"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function セル文字列(ByVal col As Integer) As String Implements Iグリッド.セル文字列
        Return セル文字列(Me.Row, col)
    End Function
    Public Function セル文字列(ByVal row As Integer, ByVal col As Integer) As String Implements Iグリッド.セル文字列
        If row >= 0 Then
            Return GetDataDisplay(row, col)
        Else
            Return ""
        End If
    End Function
    Public Function セル内容(ByVal col As Integer) As Object Implements Iグリッド.セル内容
        Return GetData(Me.Row, col)
    End Function
    ''' <summary>
    ''' pIsFixDisply
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>固定行表示</remarks>
    Public Property pIsFixDisply() As Boolean
        Get
            Return mblnFixDisply
        End Get
        Set(ByVal value As Boolean)
            mblnFixDisply = value
        End Set
    End Property

End Class

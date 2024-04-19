Imports System.Windows.Forms

Public Class UsrDataGridView
    Inherits System.Windows.Forms.DataGridView
    Implements IUserControl

    Public Redraw As Boolean

    Private mstrID As String = ""
    Private mblnClear As Boolean = True
    Private mblnFixDisply As Boolean
    Private mblnSortReNumber As Boolean

    Private mblnAltermate As Boolean = True
    Private mblnAutoColSize As Boolean
    Private mintAutoColSizeF As Integer
    Private mintAutoColSizeT As Integer
    Private mlstTotal As New Generic.List(Of Integer)

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

    Public ReadOnly Property Cols() As DataGridViewColumnCollection
        Get
            Return Columns
        End Get
    End Property

    Public Sub gSubグリッド初期設定( _
            ByVal intCols As Integer _
            , Optional ByVal intColFrozen As Integer = -1 _
            , Optional ByVal EnmSelectionMode As C1.Win.C1FlexGrid.SelectionModeEnum = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox _
            , Optional ByVal blnRowHedder As Boolean = False _
            , Optional ByVal blnEdit As Boolean = False _
            , Optional ByVal EnmSort As C1.Win.C1FlexGrid.AllowSortingEnum = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn _
            , Optional ByVal EnmDragg As C1.Win.C1FlexGrid.AllowDraggingEnum = C1.Win.C1FlexGrid.AllowDraggingEnum.None _
            , Optional ByVal EnmResize As C1.Win.C1FlexGrid.AllowResizingEnum = C1.Win.C1FlexGrid.AllowResizingEnum.Columns _
            , Optional ByVal EnmHighLight As C1.Win.C1FlexGrid.HighLightEnum = C1.Win.C1FlexGrid.HighLightEnum.Always _
            , Optional ByVal EnmFocusRect As C1.Win.C1FlexGrid.FocusRectEnum = C1.Win.C1FlexGrid.FocusRectEnum.None _
            , Optional ByVal FixdDisply As Integer = -1 _
            )
        With Me
            .Font = New Font("ＭＳゴシック", 10)
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = False

            'カラムを設定.[注意] 必ず先にColumnCountプロパティを設定しておくこと
            '            .ColumnCount = intCols

            'With .ColumnHeadersDefaultCellStyle
            '    .BackColor = Color.Navy
            '    .ForeColor = Color.White
            '    .Font = New Font(songsDataGridView.Font, FontStyle.Bold)
            'End With
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect    '行選択

            .RowHeadersVisible = False

            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

            '.ColumnHeadersHeight = ColumnHeadersHeight * 2
        End With

        'セルのデータの幅のみで調整するように指定
        'AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        'セルのデータの高さのみで調整するように指定
        AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells

        'セルにフォーカスが移った時点で編集モードになるようにする.
        '[デフォルトでは、フォーカスが移った時点では選択状態となっている.]
        'EditMode = DataGridViewEditMode.EditOnEnter

        'しましま
        RowsDefaultCellStyle.BackColor = Color.LightCyan '
        '奇数行を白にする
        AlternatingRowsDefaultCellStyle.BackColor = Color.White

        TabStop = False
    End Sub


    Public Sub gSub列初期設定( _
         ByVal intCol As Integer _
        , ByVal strTitle As String _
        , ByVal intWith As Integer _
        , ByVal enmAlign As C1.Win.C1FlexGrid.TextAlignEnum _
        , Optional ByVal blnDisplyNum As Boolean = False _
        , Optional ByVal blnVisible As Boolean = True _
        , Optional ByVal blnEdit As Boolean = False _
        , Optional ByVal strFormat As String = "" _
        , Optional ByVal objType As Type = Nothing _
        , Optional ByVal objMap As Hashtable = Nothing _
        , Optional ByVal strComboList As String = "" _
        , Optional ByVal strMask As String = "" _
        , Optional ByVal blnTotal As Boolean = False _
        , Optional ByVal enmFixedAlign As C1.Win.C1FlexGrid.TextAlignEnum = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter _
    )

        Dim カラム As DataGridViewColumn
        If objType Is Nothing Then
            カラム = New DataGridViewTextBoxColumn
            カラム.ReadOnly = blnEdit
        ElseIf objType Is GetType(Boolean) Then
            カラム = New DataGridViewCheckBoxColumn
        Else
            カラム = New DataGridViewTextBoxColumn
        End If
        Me.Columns.Add(カラム)

        With Me.Cols(intCol)
            Select Case enmAlign
                Case C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End Select
            .Name = strTitle
            .HeaderText = strTitle
            .Width = intWith
        End With
    End Sub

    ''' <summary>
    ''' 自動列幅
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubAutoColSize()
        'Me.AutoSizeCols(Me.pAutoColSizeF, Me.pAutoColSizeT, mCintAUTOCOL_SPACE)
    End Sub

    ''' <summary>
    ''' 表示行の開始Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pStartRow() As Integer
        Get
            Return 1 '            Return Me.Rows.Fixed + Me.Rows.Frozen
        End Get
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

    Public Property Row() As Integer
        Get
            Return Me.CurrentCellAddress.Y
        End Get
        Set(ByVal value As Integer)
            'CMsg.gMsg_注意("未実装")
        End Set
    End Property

    ''' <summary>
    ''' カレント行の指定列のセル文字列を返す
    ''' </summary>
    ''' <param name="col"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function セル文字列(ByVal col As Integer) As String 'Implements Iグリッド.セル文字列
        Return セル文字列(Me.Row, col)
    End Function
    Public Function セル文字列(ByVal row As Integer, ByVal col As Integer) As String 'Implements Iグリッド.セル文字列
        If row >= 0 Then
            Return Me(col, row).Value.ToString 'GetDataDisplay(row, col)
        Else
            Return ""
        End If
    End Function
    Public Function セル内容(ByVal col As Integer) As Object 'Implements Iグリッド.セル内容
        Return Me(col, Row).Value
    End Function

    'FlexGrid標準機能
    Public Overridable Sub AutoSizeCols(ByVal leftCol As Integer, ByVal rightCol As Integer, ByVal extraSpace As Integer)

    End Sub
    ''' <summary>
    ''' pIsClear
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Isクリア() As Boolean Implements IUserControl.Isクリア
        Get
            Return mblnClear
        End Get
        Set(ByVal Value As Boolean)
            mblnClear = Value
        End Set
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

    ''' <summary>
    ''' 合計行をクリア
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub gSubClearTotal()
        'If Me.Rows.Fixed = 3 Then
        '    For Each intCol As Integer In Me.mlstTotal
        '        Me(gCintTOTAL_ROW, intCol) = ""
        '    Next
        'End If
    End Sub

    Private m件数表示ラベル As usrLbl
    Public Property 件数表示ラベル() As usrLbl
        Get
            Return m件数表示ラベル
        End Get
        Set(ByVal value As usrLbl)
            m件数表示ラベル = value
        End Set
    End Property

    Private mエラー表示用項目名 As String = ""
    Public Property エラー表示用項目名() As String Implements IUserControl.エラー表示用項目名
        Get
            Return mエラー表示用項目名
        End Get
        Set(ByVal value As String)
            mエラー表示用項目名 = value
        End Set
    End Property

    Public Sub クリア() Implements IUserControl.クリア
        If Isクリア Then
            If pIsFixDisply Then
                'Dim inRow, intCol As Integer
                'For inRow = .Rows.Fixed To .Rows.Count - 1
                '    For intCol = .Cols.Fixed To .Cols.Count - 1
                '        .SetData(inRow, intCol, "")
                '    Next
                'Next
            Else
                Rows.Clear()
                '.Rows.Count = .pStartRow
                'If CType(objCtl(i), usrFlx).AllowDragging = AllowDraggingEnum.Columns Then
                '        Dim j As Integer
                '    ''列の位置を戻す
                '    j = 0
                '    Do
                '        If .Cols(j).Name <> j.ToString Then
                '            Call .Cols.Move(j, CInt(.Cols(j).Name))
                '        Else
                '            j = j + 1
                '        End If
                '        If j = .Cols.Count - 1 Then
                '            Exit Do
                '        ElseIf .Cols.Count = 1 Then
                '            Exit Do
                '        End If
                '    Loop
                'End If

                ''合計行クリア
                gSubClearTotal()

                ''列幅設定
                If pIsAutoColSize Then
                    gSubAutoColSize()
                End If
                TabStop = False
            End If
        End If
    End Sub

    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果
        入力チェック.Is正常 = True
    End Function
End Class

Imports System.Windows.Forms
Imports System.Data.Common

Public Class UsrDataGridView
    Inherits System.Windows.Forms.DataGridView
    Implements IUserControl
    Implements Iグリッド

    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Private mIsクリア As Boolean = True
    Private mIs固定行表示 As Boolean

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    Public ReadOnly Property p表示行数() As Integer
        Get
            Return Me.Rows.Count - Me.p表示行の開始Index
        End Get
    End Property

    Public ReadOnly Property Cols() As DataGridViewColumnCollection
        Get
            Return Columns
        End Get
    End Property

    Public ReadOnly Property p表示行の開始Index() As Integer
        Get
            Return 1 '            Return Me.Rows.Fixed + Me.Rows.Frozen
        End Get
    End Property

    Public Property Row() As Integer
        Get
            Return Me.CurrentCellAddress.Y
        End Get
        Set(ByVal value As Integer)
            'CMsg.gMsg_注意("未実装")
        End Set
    End Property

    Public Property Isクリア() As Boolean Implements IUserControl.Isクリア
        Get
            Return mIsクリア
        End Get
        Set(ByVal Value As Boolean)
            mIsクリア = Value
        End Set
    End Property

    Public ReadOnly Property pIs表示行あり() As Boolean
        Get
            Return p表示行数 <> 0
        End Get
    End Property

    Public Property pIs固定行表示() As Boolean
        Get
            Return mIs固定行表示
        End Get
        Set(ByVal value As Boolean)
            mIs固定行表示 = value
        End Set
    End Property

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

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
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
        'AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

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
         ByVal 列Index As Integer _
        , ByVal 列見出し As String _
        , ByVal 列幅 As Integer _
        , ByVal enmAlign As C1.Win.C1FlexGrid.TextAlignEnum _
        , Optional ByVal blnDisplyNum As Boolean = False _
        , Optional ByVal blnVisible As Boolean = True _
        , Optional ByVal blnEdit As Boolean = False _
        , Optional ByVal strFormat As String = "" _
        , Optional ByVal 列の型 As Type = Nothing _
        , Optional ByVal objMap As Hashtable = Nothing _
        , Optional ByVal strComboList As String = "" _
        , Optional ByVal strMask As String = "" _
        , Optional ByVal blnTotal As Boolean = False _
        , Optional ByVal enmFixedAlign As C1.Win.C1FlexGrid.TextAlignEnum = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter _
    )

        Dim カラム As DataGridViewColumn
        If 列の型 Is Nothing Then
            カラム = New DataGridViewTextBoxColumn
            カラム.ReadOnly = blnEdit
        ElseIf 列の型 Is GetType(Boolean) Then
            カラム = New DataGridViewCheckBoxColumn
        Else
            カラム = New DataGridViewTextBoxColumn
        End If
        Me.Columns.Add(カラム)

        With Me.Cols(列Index)
            Select Case enmAlign
                Case C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End Select
            .Name = 列見出し
            .HeaderText = 列見出し
            .Width = 列幅
        End With
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
            Return Me(col, row).Value.ToString 'GetDataDisplay(row, col)
        Else
            Return ""
        End If
    End Function
    Public Function セル内容(ByVal col As Integer) As Object Implements Iグリッド.セル内容
        Return Me(col, Row).Value
    End Function

    Public Sub クリア() Implements IUserControl.クリア
        If Isクリア Then
            If pIs固定行表示 Then
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

                TabStop = False
            End If
        End If
    End Sub

    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果
        入力チェック.Is正常 = True
    End Function

    Public Sub グリッドへ値をセットする(ByVal テーブル As DataTable)
        With Me
            ''列数は、小さい方を採用
            Dim 列数 As Integer
            If .Cols.Count < テーブル.Columns.Count Then
                列数 = .Cols.Count
            Else
                列数 = テーブル.Columns.Count
            End If

            For Each row As DataRow In テーブル.Rows
                '.Rows.Count += 1
                Dim 行データ As Object() = New Object(列数 - 1) {}

                ''グリッドまたはＳＱＬフィールドの最小数を設定する
                For i As Integer = 0 To 列数 - 1
                    Dim value As Object = row(i)
                    If .Columns(i).GetType Is GetType(DataGridViewCheckBoxColumn) Then
                        If value.ToString = "1" Then
                            行データ(i) = True
                        Else
                            行データ(i) = False
                        End If
                    Else
                        If TypeOf value Is Byte() Then
                            行データ(i) = CUtil.バイト配列ToHexString(CType(value, Byte())) 'ctlFlx(.Rows.Count - 1, i) = CUtil.バイト配列ToHexString(CType(value, Byte()))
                        Else
                            行データ(i) = value.ToString 'ctlFlx(.Rows.Count - 1, i) = value
                        End If

                    End If
                Next
                .Rows.Add(行データ)

                ''表示中に特別な処理を行う場合はオーバーライドしてください。（色変更など）
                'Call Me.iRSub表示中処理(ctlFlx, .Rows.Count - 1, odpRead)
            Next
        End With
    End Sub

    Public Sub グリッドへ値をセットする(ByVal reader As DbDataReader)
        With Me
            ''列数は、小さい方を採用
            Dim 列数 As Integer
            If .Cols.Count < reader.FieldCount Then
                列数 = .Cols.Count
            Else
                列数 = reader.FieldCount
            End If

            While reader.Read
                '.Rows.Count += 1
                Dim 行データ As Object() = New Object(列数 - 1) {}

                ''グリッドまたはＳＱＬフィールドの最小数を設定する
                For i As Integer = 0 To 列数 - 1
                    Dim value As Object = reader.GetValue(i)
                    If .Columns(i).GetType Is GetType(DataGridViewCheckBoxColumn) Then
                        If value.ToString = "1" Then
                            行データ(i) = True
                        Else
                            行データ(i) = False
                        End If
                    Else
                        Dim テスト As Boolean = False
                        If テスト Then

                        ElseIf TypeOf value Is Byte() Then
                            行データ(i) = CUtil.バイト配列ToHexString(CType(value, Byte())) 'ctlFlx(.Rows.Count - 1, i) = CUtil.バイト配列ToHexString(CType(value, Byte()))
                        Else
                            行データ(i) = value.ToString 'ctlFlx(.Rows.Count - 1, i) = value
                        End If

                    End If
                Next
                .Rows.Add(行データ)

                ''表示中に特別な処理を行う場合はオーバーライドしてください。（色変更など）
                'Call Me.iRSub表示中処理(ctlFlx, .Rows.Count - 1, odpRead)
            End While
        End With
    End Sub

    Public Function グリッドを元にデータテーブルを作成する() As DataTable
        Dim テーブル As New DataTable

        '列を作成する
        For Each 列 As DataGridViewColumn In Me.Columns
            テーブル.Columns.Add(列.Name)
        Next

        'データを転記する
        For Each コピー元の行 As DataGridViewRow In Me.Rows
            Dim コピー先の行 As DataRow = テーブル.NewRow
            For Each 列 As DataGridViewColumn In Me.Columns
                コピー先の行(列.Name) = コピー元の行.Cells(列.Name).Value
            Next
            テーブル.Rows.Add(コピー先の行)
        Next

        Return テーブル
    End Function

    Public Sub 表示(ByRef reader As DbDataReader)
        If reader Is Nothing Then
            Exit Sub
        End If

        グリッドへ値をセットする(reader)

        ''表示後に特別な処理を行う場合はオーバーライドしてください。こちらは、すべての表示が終わった後の処理
        'Call Me.iRSub表示後処理(ctlFlx)

        ''1行目選択
        ' '' ''If ctlFlx.pRowCount(usrFlx.EnmRowCount.Enm表示行数) > 0 Then
        ' '' ''    Select Case .SelectionMode
        ' '' ''        Case SelectionModeEnum.Cell, SelectionModeEnum.CellRange
        ' '' ''            .Row = .pRowCount
        ' '' ''            .Col = .Cols.Fixed
        ' '' ''        Case SelectionModeEnum.Row
        ' '' ''            .Row = .pRowCount
        ' '' ''        Case SelectionModeEnum.ListBox, SelectionModeEnum.RowRange
        ' '' ''            .Rows(.pRowCount).Selected = True
        ' '' ''        Case Else
        ' '' ''    End Select
        ' '' ''End If

        ''TabStop設定
        If pIs表示行あり Then
            TabStop = True
        End If
    End Sub
End Class

'*******************************************************************************
' @(h)  UsrCmb.vb
'                                           Ver.1.0 (            T.TADA )
'
' @(s)  UsrCmb                             System.Windows.Forms.ComboBoxを継承
'       初期設定される継承元プロパティー
'       Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
'       DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'       上記以外は継承元の初期値と同じになります。
'*******************************************************************************

Public Class usrCmb
    Inherits System.Windows.Forms.ComboBox
    Implements IUserControl
    Implements IEnterキー制御

    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Private mstrID As String = ""
    Private mstrClearValue As String = ""
    Private mintclearIndex As Integer = -1
    Private mIsクリア As Boolean = True

    Private mblnAutoFocus As Boolean = True
    Private mblnAutoSelect As Boolean = True
    Private mintMaxByte As Integer
    Private menmCharType As gEnmCharType = gEnmCharType.All
    Private menmCondition As gEnm入力条件 = gEnm入力条件.Nomal

    Private mエラー表示用項目名 As String = ""
    Private mstrFromToErrText As String = ""
    Private mctlFromCtl As Control
    Private menmFromToSearch As gEnmFromTo = gEnmFromTo.None

    Private m値リスト As New Generic.List(Of String)
    Private m値リスト2 As New Generic.List(Of String)
    Private m値リスト3 As New Generic.List(Of String)

    Private mstrHitKey As String = ""
    Private m必須色 As New System.Drawing.Color
    Private m強調色 As New System.Drawing.Color

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    ''プロパティー-------------------------------------------------------------------
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
    ''' pClearValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pClearValue() As String
        Get
            Return mstrClearValue
        End Get
        Set(ByVal Value As String)
            mstrClearValue = Value
        End Set
    End Property

    ''' <summary>
    ''' pClearIndex
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pClearIndex() As Integer
        Get
            Return mintclearIndex
        End Get
        Set(ByVal Value As Integer)
            mintclearIndex = Value
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


    ''' <summary>
    ''' pAutoFocus
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pAutoFocus() As Boolean
        Get
            Return mblnAutoFocus
        End Get
        Set(ByVal Value As Boolean)
            mblnAutoFocus = Value
        End Set
    End Property

    ''' <summary>
    ''' pAutoSelect
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pAutoSelect() As Boolean
        Get
            Return mblnAutoSelect
        End Get
        Set(ByVal Value As Boolean)
            mblnAutoSelect = Value
        End Set
    End Property

    ''' <summary>
    ''' pMaxByte
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pMaxByte() As Integer
        Get
            Return mintMaxByte
        End Get
        Set(ByVal Value As Integer)
            mintMaxByte = Value
        End Set
    End Property

    ''' <summary>
    ''' pCharType
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pCharType() As gEnmCharType
        Get
            Return menmCharType
        End Get
        Set(ByVal Value As gEnmCharType)
            menmCharType = Value
        End Set
    End Property

    ''' <summary>
    ''' pCondition
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pCondition() As gEnm入力条件
        Get
            Return menmCondition
        End Get
        Set(ByVal Value As gEnm入力条件)
            menmCondition = Value
            Select Case Me.menmCondition
                Case gEnm入力条件.Nomal
                    Me.Enabled = True
                    Me.BackColor = System.Drawing.SystemColors.Window
                Case gEnm入力条件.Fuka
                    Me.Enabled = False
                    Me.BackColor = System.Drawing.SystemColors.Control
                Case gEnm入力条件.Hissu
                    Me.Enabled = True
                    Me.BackColor = m必須色
                Case gEnm入力条件.Impact
                    Me.Enabled = True
                    Me.BackColor = m強調色
            End Select
        End Set
    End Property

    Public Property エラー表示用項目名() As String Implements IUserControl.エラー表示用項目名
        Get
            Return mエラー表示用項目名
        End Get
        Set(ByVal Value As String)
            mエラー表示用項目名 = Value
        End Set
    End Property

    ''' <summary>
    ''' pFromToSearch
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pFromToSearch() As gEnmFromTo
        Get
            Return menmFromToSearch
        End Get
        Set(ByVal Value As gEnmFromTo)
            menmFromToSearch = Value
        End Set
    End Property

    ''' <summary>
    ''' pFromCtl
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pFromCtl() As Control
        Get
            Return mctlFromCtl
        End Get
        Set(ByVal Value As Control)
            mctlFromCtl = Value
        End Set
    End Property

    ''' <summary>
    ''' pFromToErrText
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pFromToErrText() As String
        Get
            Return mstrFromToErrText
        End Get
        Set(ByVal Value As String)
            mstrFromToErrText = Value
        End Set
    End Property

    Public Overloads ReadOnly Property pValueAsText(ByVal intIndex As Integer) As String
        Get
            If intIndex = -1 Then
                Return ""
            Else
                Return m値リスト.Item(intIndex)
            End If
        End Get
    End Property

    Public Overloads ReadOnly Property pValueAsText() As String
        Get
            Return pValueAsText(Me.SelectedIndex)
        End Get
    End Property

    Public ReadOnly Property 値リスト() As Generic.List(Of String)
        Get
            Return m値リスト
        End Get
    End Property

    Public ReadOnly Property 値リスト2() As Generic.List(Of String)
        Get
            Return m値リスト2
        End Get
    End Property

    Public ReadOnly Property 値リスト3() As Generic.List(Of String)
        Get
            Return m値リスト3
        End Get
    End Property

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
    ''イベント処理-------------------------------------------------------------------
    ''' <summary>
    ''' UsrCmb_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrCmb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        'If Me.mBlnAutoFocus = True Then
        '    If CType(sender, ComboBox).MaxLength > 0 And _
        '       CType(sender, ComboBox).MaxLength <= CType(sender, ComboBox).Text.Length And _
        '       CType(sender, ComboBox).SelectionStart = CType(sender, ComboBox).Text.Length Then
        '        SendKeys.Send("{TAB}")
        '    End If
        'End If
    End Sub

    ''' <summary>
    ''' UsrCmb_Enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrCmb_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        If Me.mblnAutoFocus And Me.DropDownStyle = ComboBoxStyle.DropDownList Then
            Me.SelectAll()
        End If
        Me.mstrHitKey = ""
    End Sub

    ''' <summary>
    ''' UsrCmb_SizeChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrCmb_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Me.DropDownWidth = Me.Width
    End Sub

    ''' <summary>
    ''' UsrCmb_KeyPress
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UsrCmb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim intByte As Integer
        Dim intMoji As Integer

        ''編集可能時のみ
        If Me.DropDownStyle = ComboBoxStyle.DropDown Then
            'Maxlength
            intByte = System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(Me.Text)
            intMoji = Me.pMaxByte - intByte
            If System.Text.Encoding.GetEncoding("shift-jis").GetByteCount(e.KeyChar) = 2 Then
                If intMoji = 1 Then
                    Me.MaxLength = Me.Text.Length
                Else
                    Me.MaxLength = Me.Text.Length + intMoji
                End If
            Else
                Me.MaxLength = Me.Text.Length + intMoji
            End If
        ElseIf Me.DropDownStyle = ComboBoxStyle.DropDownList Then
            If Char.IsLetterOrDigit(e.KeyChar) Then
                Me.mstrHitKey &= e.KeyChar
                Call Me.mSubHitIndex()
                e.Handled = True
            End If
        End If
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Public Sub New()
        MyBase.New()

        ''リストスタイル
        Me.DropDownStyle = ComboBoxStyle.DropDownList
        'フォント
        Me.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        '色
        Me.m強調色 = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.m必須色 = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))

    End Sub

    ''' <summary>
    ''' コンボ内容のIndexをかえる
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mSubHitIndex()
        For i As Integer = 0 To Me.Items.Count - 1
            If CStr(Me.Items.Item(i)).Length >= Me.mstrHitKey.Length Then
                If CStr(Me.Items.Item(i)).Substring(0, Me.mstrHitKey.Length) = Me.mstrHitKey Then
                    Me.SelectedIndex = i
                    Exit Sub
                End If
            End If
        Next
        Me.SelectedIndex = -1
        Me.mstrHitKey = ""
    End Sub

    ''メソッド------------------------------------------------------------------
    ''' <summary>
    ''' gSubComboClear
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub gSubComboClear()
        Call Me.gSubComboClear(True)
    End Sub
    Public Overloads Sub gSubComboClear(ByVal blnTextClear As Boolean)
        Me.Items.Clear()
        Me.値リスト.Clear()

        If blnTextClear Then
            If Me.DropDownStyle = ComboBoxStyle.DropDown Then
                Me.Text = Me.pClearValue
            End If
        End If
    End Sub

    ''' <summary>
    ''' Valuesと一致するIndexの取得
    ''' </summary>
    ''' <param name="strSearch"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function gIntFindValue(ByVal strSearch As String) As Integer
        If Me.値リスト.Contains(strSearch) Then
            Return Me.値リスト.IndexOf(strSearch)
        Else
            Return -1
        End If
    End Function

    ''' <summary>
    ''' Itemsと一致するIndexへ
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <remarks></remarks>
    Public Sub gSubSetItemIndex(ByVal strValue As String)
        Me.SelectedIndex = Me.FindStringExact(strValue) 'コンボ ボックス内で、指定した文字列と一致する最初の項目を検索します。
    End Sub

    ''' <summary>
    ''' Valuesと一致するIndexへ
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <remarks></remarks>
    Public Sub gSubSetValueIndex(ByVal strValue As String)
        Me.SelectedIndex = Me.gIntFindValue(strValue)
    End Sub

    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果

        Try
            With Me
                ''必須入力チェック
                If .pCondition = gEnm入力条件.Hissu Then
                    If .Text = "" Then
                        If .エラー表示用項目名 = "" Then
                            Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_未指定)
                        Else
                            Call CMsg.gMsg_注意(.エラー表示用項目名 & M定数.MSG_未指定)
                        End If
                        入力チェック.ErrorContol = Me
                        Return 入力チェック
                    End If
                End If

                ''範囲チェック
                If .pFromToSearch <> gEnmFromTo.None Then
                    ''FromToに入力がある場合は範囲チェック
                    If .Text <> "" And .pFromCtl.Text <> "" Then
                        ''数値で範囲検索
                        If .pFromToSearch = gEnmFromTo.Num Then
                            If CInt(.pFromCtl.Text) > CInt(.Text) Then
                                If .pFromToErrText = "" Then
                                    Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_範囲不正)
                                Else
                                    Call CMsg.gMsg_注意(.pFromToErrText & M定数.MSG_範囲不正)
                                End If
                                入力チェック.ErrorContol = .pFromCtl
                                Return 入力チェック
                            End If

                            ''文字で範囲検索
                        ElseIf .pFromToSearch = gEnmFromTo.Letter Then
                            If .pFromCtl.Text > .Text Then
                                If .pFromToErrText = "" Then
                                    Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_範囲不正)
                                Else
                                    Call CMsg.gMsg_注意(.pFromToErrText & M定数.MSG_範囲不正)
                                End If
                                入力チェック.ErrorContol = CType(.pFromCtl, usrCmb)
                                Return 入力チェック
                            End If
                        Else

                        End If
                    End If
                End If
            End With
        Finally
            If Not 入力チェック.ErrorContol Is Nothing And Isエラーフォーカス Then
                入力チェック.ErrorContol.Focus()
            End If
        End Try

        入力チェック.Is正常 = True
    End Function

    Public Sub クリア() Implements IUserControl.クリア
        With Me
            If .Isクリア Then
                If .DropDownStyle = ComboBoxStyle.DropDownList Then
                    If .Items.Count > .pClearIndex Then 'クリア可能な場合に限定
                        .SelectedIndex = .pClearIndex
                    End If
                ElseIf .DropDownStyle = ComboBoxStyle.DropDown Then
                    .Text = .pClearValue
                End If
            End If
        End With
    End Sub
End Class

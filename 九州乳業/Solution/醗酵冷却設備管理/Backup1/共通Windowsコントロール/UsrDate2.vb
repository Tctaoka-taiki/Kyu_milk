''' <summary>
''' 
''' </summary>
''' <remarks>DateTimePickerをベースに、は背景色の変更などに対応。</remarks>
Public Class UsrDate2
    Inherits Windows.Forms.DateTimePicker
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
    Private mIsクリア As Boolean = True

    Private mblnAutoFocus As Boolean = True
    Private mblnAutoSelect As Boolean = True
    Private menmCondition As gEnm入力条件 = gEnm入力条件.Nomal

    Private mエラー表示用項目名 As String = ""
    Private mstrFromToErrText As String = ""
    Private mctlFromCtl As Control
    Private menmFromToSearch As gEnmFromTo = gEnmFromTo.None

    Private mblnClearToday As Boolean

    Private mcolorHissuColor As New System.Drawing.Color
    Private mcolorImpactColor As New System.Drawing.Color

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    Public Property 背景色() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            MyBase.BackColor = value
        End Set
    End Property
    Public Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As Color)
            MyBase.BackColor = value
        End Set
    End Property










    Public Property pID() As String
        Get
            Return mstrID
        End Get
        Set(ByVal Value As String)
            mstrID = Value
        End Set
    End Property

    Public Property pClearValue() As String
        Get
            Return mstrClearValue
        End Get
        Set(ByVal Value As String)
            mstrClearValue = Value
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
                    Me.BackColor = mcolorHissuColor
                Case gEnm入力条件.Impact
                    Me.Enabled = True
                    Me.BackColor = mcolorImpactColor
            End Select
        End Set
    End Property

    ''' <summary>
    ''' pErrText
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Text
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>/なし</remarks>
    Public Overloads Overrides Property Text() As String
        Get
            Return Me.Text(False)
        End Get
        Set(ByVal Value As String)
            Dim strBuff As String = ""

            strBuff = Replace(Value, "/", "")
            If strBuff = "" Then
                Value = Nothing
            ElseIf strBuff.Length = 8 Then
                Value = New Date(CInt(strBuff.Substring(0, 4)), CInt(strBuff.Substring(4, 2)), CInt(strBuff.Substring(6, 2)))
            Else
                Value = Nothing
            End If
        End Set
    End Property

    ''' <summary>
    ''' Text
    ''' </summary>
    ''' <param name="blnSura">/の有無の指定</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads ReadOnly Property Text(ByVal blnSura As Boolean) As String
        Get
            Dim スラッシュ As String = ""
            If blnSura Then
                スラッシュ = "/"
            End If

            If Not ShowCheckBox Or (ShowCheckBox And Checked) Then
                Return Value.Year & スラッシュ & Strings.Right("00" & Value.Month, 2) & スラッシュ & Strings.Right("00" & Value.Day, 2)
            Else
                Return ""
            End If
        End Get
    End Property

    ''' <summary>
    ''' 日付として正しいか
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property pIsDate() As Boolean
        Get
            Return Is有効日付入力済 Or Me.Text.Trim = ""
        End Get
    End Property

    Public ReadOnly Property Is有効日付入力済() As Boolean
        Get
            If Me.Text.Trim = "" Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    ''' <summary>
    ''' クリアするときに本日日付にクリア
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pClearToday() As Boolean
        Get
            Return mblnClearToday
        End Get
        Set(ByVal Value As Boolean)
            mblnClearToday = Value
        End Set
    End Property

    ''' <summary>
    ''' pYear
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pYear() As String
        Get
            Return Value.Year
        End Get
        Set(ByVal Value As String)
            Value = New Date(CInt(Value), Me.Value.Month, Me.Value.Day)
        End Set
    End Property

    ''' <summary>
    ''' pMonth
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pMonth() As String
        Get
            Return Value.Month
        End Get
        Set(ByVal Value As String)
            Value = New Date(Me.Value.Year, CInt(Value), Me.Value.Day)
        End Set
    End Property

    ''' <summary>
    ''' pDay
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pDay() As String
        Get
            Return Value.Day
        End Get
        Set(ByVal Value As String)
            Value = New Date(Me.Value.Year, Me.Value.Month, CInt(Value))
        End Set
    End Property



















    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
    ' ''イベント-------------------------------------------------------------------

    '''' <summary>
    '''' UsrDate_TextChanged
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub UsrDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.TextChanged, txtMonth.TextChanged, txtDay.TextChanged
    '    ''ユーザーコントロールのテキストチェンジイベントを発生させる
    '    Call Me.OnTextChanged(e)

    '    If Me.mblnAutoFocus Then
    '        If CType(sender, TextBox).MaxLength > 0 And _
    '           CType(sender, TextBox).MaxLength <= CType(sender, TextBox).Text.Length And _
    '           CType(sender, TextBox).SelectionStart = CType(sender, TextBox).Text.Length Then
    '            SendKeys.Send("{TAB}")
    '        End If
    '    End If
    'End Sub

    '''' <summary>
    '''' txtYear_Leave
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub txtYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYear.Leave, MyBase.Leave
    '    Select Case Me.txtYear.TextLength
    '        Case 1 To 3
    '            Me.txtYear.Text = "2" & Me.txtYear.Text.PadLeft(3, Chr(Asc("0")))
    '    End Select
    'End Sub

    '''' <summary>
    '''' txtMonth_Leave
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub txtMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonth.Leave, MyBase.Leave
    '    If Me.txtMonth.TextLength = 1 Then
    '        Me.txtMonth.Text = Me.txtMonth.Text.PadLeft(2, Chr(Asc("0")))
    '    End If
    'End Sub

    '''' <summary>
    '''' txtDay_Leave
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub txtDay_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDay.Leave, MyBase.Leave
    '    If Me.txtDay.TextLength = 1 Then
    '        Me.txtDay.Text = Me.txtDay.Text.PadLeft(2, Chr(Asc("0")))
    '    End If
    'End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    'コンストラクタ
    Public Sub New()
        Format = DateTimePickerFormat.Custom
        CustomFormat = "yyyy/MM/dd(ddd)"
        ''色
        Me.mcolorImpactColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.mcolorHissuColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        'BackColor = Color.Cyan
    End Sub

    Public Sub SetDate(ByVal 日付 As Date)
        With 日付
            pYear = .Year.ToString
            pMonth = Strings.Right("00" & .Month.ToString, 2)
            pDay = Strings.Right("00" & .Day.ToString, 2)
        End With
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="値"></param>
    ''' <remarks>値がDBNullなら、表示をクリア。Date型ならば値をセット</remarks>
    Public Sub Dbの値をセット(ByVal 値 As Object)
        If IsDBNull(値) Then
            Text = ""
        Else
            SetDate(CType(値, Date))
        End If
    End Sub

    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        入力チェック = New Cチェック結果

        Try
            With Me
                ''入力チェック
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

                ''日付チェック
                If .pIsDate = False Then
                    If .エラー表示用項目名 = "" Then
                        Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_不正)
                    Else
                        Call CMsg.gMsg_注意(.エラー表示用項目名 & M定数.MSG_不正)
                    End If
                    入力チェック.ErrorContol = Me
                    Return 入力チェック
                End If

                ''範囲チェック
                If .pFromToSearch <> gEnmFromTo.None Then
                    ''FromToに入力がある場合は範囲チェック
                    If .Text <> "" And .pFromCtl.Text <> "" Then
                        If .pFromCtl.Text > .Text Then
                            If .pFromToErrText = "" Then
                                Call CMsg.gMsg_注意(.Name.Substring(3) & M定数.MSG_範囲不正)
                            Else
                                Call CMsg.gMsg_注意(.pFromToErrText & M定数.MSG_範囲不正)
                            End If
                            入力チェック.ErrorContol = .pFromCtl
                            Return 入力チェック
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
        If Isクリア Then
            If pClearToday Then
                Value = Now
            Else
                Text = pClearValue
            End If
            If pClearValue = "" Then
                Checked = False
            End If
        End If
    End Sub

    Public Function 日付オブジェクト() As Object
        If Is有効日付入力済 Then
            Return CDbUtil.空文字列ToDBNull(Text(True))
        Else
            Return DBNull.Value
        End If
    End Function

    ''' <summary>
    ''' WndProc
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks>貼り付けの制御</remarks>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_ERASEBKGND As Integer = &H14

        Select Case m.Msg
            Case WM_ERASEBKGND   ''貼り付けメッセージ
                Dim g As Graphics = Graphics.FromHdc(m.WParam)
                Dim backBrush As SolidBrush = New SolidBrush(Me.BackColor)
                g.FillRectangle(backBrush, MyBase.ClientRectangle)
                backBrush.Dispose()
                g.Dispose()
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    Public Sub カレンダーウィンドウ表示()
    End Sub
End Class

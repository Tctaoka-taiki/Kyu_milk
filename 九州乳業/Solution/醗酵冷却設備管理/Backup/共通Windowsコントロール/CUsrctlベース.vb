Public Class Cチェック結果
    Public ErrorContol As Control = Nothing
    Public Is正常 As Boolean = False

    Public ReadOnly Property Isエラー() As Boolean
        Get
            Return Not Is正常
        End Get
    End Property

End Class

Public Class CUsrctlベース
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################

    '#####################################################################################
    'プロパティー
    '#####################################################################################

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    ''' <summary>
    ''' 初期化実行
    ''' </summary>
    ''' <param name="objCtl">所属コントロールも処理します</param>
    ''' <remarks>コントロールを初期化する。</remarks>
    Public Shared Sub gSubコントロールの初期化(ByVal ParamArray objCtl() As Object)
        For Each コントロール As Object In objCtl
            If TypeOf コントロール Is IUserControl Then
                With CType(コントロール, IUserControl)
                    .クリア()
                End With

                ''コレクション
            ElseIf TypeOf コントロール Is Collection Then
                For Each objCollectionCtl As Object In CType(コントロール, Collection)
                    Call gSubコントロールの初期化(objCollectionCtl)
                Next

            ElseIf TypeOf コントロール Is GroupBox Or _
                   TypeOf コントロール Is Panel Or _
                   TypeOf コントロール Is TabPage Or _
                   TypeOf コントロール Is TabControl Or _
                   TypeOf コントロール Is Form Then

                With CType(コントロール, Control)
                    For intLoop As Integer = 0 To .Controls.Count - 1
                        Call gSubコントロールの初期化(.Controls(intLoop))
                    Next
                End With
            Else

            End If
        Next
    End Sub

    Public Shared Function 入力チェック(ByVal Isエラーフォーカス As Boolean, ByVal ParamArray ctlSearch() As Object) As Cチェック結果
        入力チェック = New Cチェック結果

        ''いまは入力チェックじゃまなので------------------------------------------------------------
        'Return True

        Try
            For Each コントロール As Object In ctlSearch
                If TypeOf コントロール Is IUserControl Then
                    With CType(コントロール, IUserControl)
                        Dim o As Cチェック結果 = .入力チェック(Isエラーフォーカス)
                        If o.Isエラー Then
                            Return o
                        End If
                    End With

                    ''コレクション
                ElseIf TypeOf コントロール Is Collection Then
                    For Each objCtl As Object In CType(コントロール, Collection)
                        Dim o As Cチェック結果 = 入力チェック(Isエラーフォーカス, objCtl)
                        If o.Isエラー Then
                            Return o
                        End If
                    Next

                    ''グループボックス
                ElseIf TypeOf コントロール Is GroupBox Or _
                       TypeOf コントロール Is Panel Or _
                       TypeOf コントロール Is TabPage _
                       Then                    'or TypeOf コントロール Is Ucメンテベース Then
                    Dim コレクション As Collection = タブIndex順にならべたコレクションを返す(CType(コントロール, Control))
                    Dim o As Cチェック結果 = 入力チェック(Isエラーフォーカス, コレクション)
                    If o.Isエラー Then
                        Return o
                    End If

                    ''タブ
                ElseIf TypeOf コントロール Is TabControl Or _
                        TypeOf コントロール Is Form Then
                    For Each コントロール2 As Control In CType(コントロール, Control).Controls
                        Dim o As Cチェック結果 = 入力チェック(Isエラーフォーカス, コントロール2)
                        If o.Isエラー Then
                            Return o
                        End If
                    Next
                Else

                End If
            Next
        Finally
            If Not 入力チェック.ErrorContol Is Nothing And Isエラーフォーカス Then
                入力チェック.ErrorContol.Focus()
            End If
        End Try

        入力チェック.Is正常 = True
        Return 入力チェック
    End Function

    Public Shared Function タブIndex順にならべたコレクションを返す(ByVal コントロール As Control) As Collection
        Dim col As New Collection
        For intLoop As Integer = 0 To コントロール.Controls.Count - 1
            ''タブインデックス順にコレクションに追加
            Dim Is追加 As Boolean = False
            Dim インデックス As Integer = コントロール.Controls(intLoop).TabIndex
            For intBuff As Integer = 1 To col.Count
                If インデックス < CType(col.Item(intBuff), Control).TabIndex Then
                    Is追加 = True
                    col.Add(コントロール.Controls(intLoop), , intBuff)
                    Exit For
                End If
            Next
            If Is追加 = False Then
                col.Add(コントロール.Controls(intLoop))
            End If
        Next
        Return col
    End Function

    ''内部関数(Function)-----------------------------------------------------------------------
    ''' <summary>
    ''' フォーカスがセットできるか判定する
    ''' </summary>
    ''' <param name="コントロール">コントロール</param>
    ''' <returns>処理結果</returns>
    ''' <remarks>タブページの時はページをアクティブにする</remarks>
    Public Shared Function Isフォーカスセット可能(ByVal コントロール As Control) As Boolean
        Dim ctlParent As Control

        If コントロール Is Nothing Then
            Return False
        End If

        ''グリッドの場合に表示行がない場合はセット不可
        'If TypeOf ctlSet Is usrFlx Then
        '    If Not CType(ctlSet, usrFlx).pIsDisply Then
        '        Return False
        '    End If
        'End If
        If TypeOf コントロール Is UsrDataGridView Then
            If Not CType(コントロール, UsrDataGridView).pIs表示行あり Then
                Return False
            End If
        End If

        ''タブページ内にある場合はページをアクティブにする。
        ctlParent = コントロール
        Do
            ctlParent = ctlParent.Parent
            If TypeOf ctlParent Is Form Then
                If コントロール.CanFocus Then
                    Return True
                Else
                    Return False
                End If
            ElseIf TypeOf ctlParent Is TabPage Then
                If CType(ctlParent, TabPage).Enabled Then
                    CType(CType(ctlParent, TabPage).Parent, TabControl).SelectedTab = CType(ctlParent, TabPage)
                    If コントロール.CanFocus Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else

            End If
        Loop
    End Function
End Class

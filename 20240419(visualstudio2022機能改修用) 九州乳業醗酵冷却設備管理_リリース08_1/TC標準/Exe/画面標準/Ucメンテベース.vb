'Public MustInherit Class Ucメンテベース
Public Class Ucメンテベース
    Inherits UserControl
    Implements Iメンテ
    Implements IUserControl
    Implements IEnterキー制御

    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    Public Overridable ReadOnly Property テーブル名() As String Implements Iメンテ.テーブル名
        Get
            Return Nothing
        End Get
    End Property

    Public Overridable ReadOnly Property IDの列名() As String
        Get
            Return "ID"
        End Get
    End Property
    Public Overridable ReadOnly Property コードの列名() As String
        Get
            Return "コード"
        End Get
    End Property

    Private m処理区分 As enm処理区分
    Public Property 処理区分() As enm処理区分
        Get
            Return m処理区分
        End Get
        Set(ByVal value As enm処理区分)
            m処理区分 = value
        End Set
    End Property

    Private m前回更新日時 As String
    Public Property 前回更新日時() As String
        Get
            Return m前回更新日時
        End Get
        Set(ByVal value As String)
            m前回更新日時 = value
        End Set
    End Property

    Private mIsクリア As Boolean = True
    Public Property Isクリア() As Boolean Implements IUserControl.Isクリア
        Get
            Return mIsクリア
        End Get
        Set(ByVal value As Boolean)
            mIsクリア = value
        End Set
    End Property

    Public Property エラー表示用項目名() As String Implements IUserControl.エラー表示用項目名
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            '設定しない
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
    Private Function 追加SQL() As String Implements Iメンテ.追加
        Dim o As CSql = CreateSQLオブジェクト()
        With o
            .gSubClearSQL()
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_INSERT
            .pテーブル名 = テーブル名
            追加(o)
            Return .gSQL文の取得
        End With
    End Function

    Protected Overridable Function CreateSQLオブジェクト() As CSql
        Return New CSql
    End Function

    Public Overridable Function Is追加変更チェック() As Boolean
        Return True
    End Function

    'Public MustOverride Sub 追加(ByVal o As CSql)
    'Public MustOverride Sub 変更(ByVal o As CSql)
    Public Overridable Sub 追加(ByVal o As CSql)

    End Sub
    Public Overridable Sub 変更(ByVal o As CSql)

    End Sub
    'Public Overridable Sub 初期値設定(ByVal grid As usrFlx)
    Public Overridable Sub 初期値設定(ByVal grid As UsrDataGridView)

    End Sub

    Private Function 変更SQL() As String Implements Iメンテ.変更
        Dim o As CSql = CreateSQLオブジェクト()
        With o
            .gSubClearSQL()
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
            .pテーブル名 = テーブル名
            変更(o)
            Return .gSQL文の取得
        End With
    End Function

    Public Function 追加更新SQL() As String
        Select Case Me.処理区分
            Case enm処理区分.追加
                Return 追加SQL()

            Case enm処理区分.変更
                Return 変更SQL()

            Case Else
                Return ""
        End Select
    End Function

    Public Sub クリア() Implements IUserControl.クリア
        For Each o As Object In Controls
            Call CUsrctl.gSubコントロールの初期化(o)
        Next
    End Sub

    Public Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果 Implements IUserControl.入力チェック
        Dim コレクション As Collection = CUsrctl.タブIndex順にならべたコレクションを返す(CType(Me, Control))
        Return CUsrctl.入力チェック(Isエラーフォーカス, コレクション)
    End Function
End Class

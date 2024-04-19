Public Class Uc部署
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################

    '#####################################################################################
    'プロパティー
    '#####################################################################################
    Public Overrides ReadOnly Property テーブル名() As String
        Get
            Return "DM部署"
        End Get
    End Property
    Public Overrides ReadOnly Property IDの列名() As String
        Get
            Return "部署ID"
        End Get
    End Property
    Public Overrides ReadOnly Property コードの列名() As String
        Get
            Return "部署コード"
        End Get
    End Property

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
    Private Sub Cmb企業名_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb企業名.Enter
        CDbUtil入退.Cmb企業名コンボ初期化(Cmb企業名, , , False)
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Private Sub 追加変更共通(ByVal o As CSql)
        With o
            .gSubColumnValue("部署コード", Txt部署コード.Text, True)
            .gSubColumnValue("名称漢字", Txt部署名.Text, True)
            .gSubColumnValue("名称カナ", Txt部署ｶﾅ名.Text, True)
            .gSubColumnValue("電話番号", Txt電話番号.Text, True)
            .gSubColumnValue("許可パターンID", Cmb許可パターン.pValueAsText, False)
            .gSubColumnValue("更新プログラム", Me.Name, True)
        End With
    End Sub

    Public Overrides Function Is追加変更チェック() As Boolean
        '20081211 morichika
        'If CDbUtil入退.Isコードが存在する(テーブル名, コードの列名, IDの列名, Txt部署コード.Text, IIf(処理区分 = enm処理区分.追加, "", Lbl部署ID.Text).ToString) Then
        '    CMsg.gMsg_エラー("部署コードが重複しています。部署コードを確認してください。")
        '    Txt部署コード.Focus()
        '    Return False
        'End If
        '⇒部署CDと企業CDセットでチェックを行うように変更すること

        Return True
    End Function

    Public Overloads Overrides Sub 追加(ByVal o As CSql)
        追加変更共通(o)
        With o
            .gSubColumnValue("企業ID", Cmb企業名.pValueAsText, False)
        End With
    End Sub

    Public Overloads Overrides Sub 変更(ByVal o As CSql)
        追加変更共通(o)
        With CType(o, CSqlEx)
            .gSubColumnValue("更新日時", "GETDATE()", False)
            .gSubWhere("部署ID", Lbl部署ID.Text, , , , , , , False)
            .gSubWhere更新日時(前回更新日時)
        End With
    End Sub

    'Public Overrides Sub 初期値設定(ByVal grid As usrFlx)
    Public Overrides Sub 初期値設定(ByVal grid As UsrDataGridView)
        Txt部署コード.MaxLength = LEN_部署コード
        Txt部署コード.pMaxByte = LEN_部署コード

        Txt電話番号.MaxLength = LEN_電話番号
        Txt電話番号.pMaxByte = LEN_電話番号

        CDbUtil入退.Cmb企業名コンボ初期化(Cmb企業名, , , False)
        CDbUtil入退.Cmb許可パターンコンボ初期化(Cmb許可パターン)
        Txt部署名.pCondition = gEnm入力条件.Hissu
        Txt部署ｶﾅ名.pCondition = gEnm入力条件.Nomal
        Cmb企業名.pCondition = gEnm入力条件.Hissu
        With Me
            Select Case .処理区分
                Case enm処理区分.追加
                    .Cmb企業名.Visible = True
                    .Lbl企業名.Visible = False

                Case enm処理区分.変更
                    .Cmb企業名.Visible = False
                    .Lbl企業名.Visible = True

                    .Cmb企業名.Text = grid.セル文字列(C部署.EnmCol.企業名)
                    .Lbl企業名.Text = grid.セル文字列(C部署.EnmCol.企業名)
                    .Cmb企業名.Isクリア = False
                    .Txt部署名.Text = grid.セル文字列(C部署.EnmCol.部署名)
                    .Txt部署ｶﾅ名.Text = grid.セル文字列(C部署.EnmCol.部署カナ名)
                    .Lbl部署ID.Text = grid.セル文字列(C部署.EnmCol.部署ID)

                    With New CSqlEx
                        .gSubClearSQL()
                        'SELECT
                        .gSubSelect("DM部署.電話番号")
                        .gSubSelect日時文字列("DM部署.更新日時")
                        .gSubSelect("DM部署.許可パターンID")
                        .gSubSelect("DM部署.部署コード")
                        'FROM
                        .gSubFrom("DM部署" & _
                                  " LEFT JOIN DM許可パターン ON DM部署.許可パターンID = DM許可パターン.許可パターンID")
                        'WHERE
                        .gSubWhere("DM部署.部署ID", grid.セル文字列(C部署.EnmCol.部署ID), , , , , , , False)

                        Dim reader As System.Data.Common.DbDataReader = Nothing
                        Try
                            If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                                If reader.Read() Then
                                    前回更新日時 = reader("更新日時").ToString
                                    Cmb許可パターン.gSubSetValueIndex(reader("許可パターンID").ToString)
                                    Txt部署コード.Text = reader("部署コード").ToString
                                    Txt電話番号.Text = reader("電話番号").ToString
                                End If
                            End If
                        Finally
                            cusrctl.gDp.gSubReaderClose(reader)
                        End Try
                    End With
            End Select
        End With
    End Sub
End Class

Public Class C部署
    '#####################################################################################
    '型
    '#####################################################################################
    Public Enum EnmCol
        部署ID
        企業名
        部署コード
        部署名
        部署カナ名
        電話番号
        更新日時
        cols
    End Enum

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

    'Public Sub グリッド設定(ByVal grid As usrFlx)
    Public Sub グリッド設定(ByVal grid As UsrDataGridView)
        With grid
            .gSubグリッド初期設定(EnmCol.cols)

            .gSub列初期設定(EnmCol.部署ID, "部署ID", 100, C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter)
            .gSub列初期設定(EnmCol.企業名, "学年", 300, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub列初期設定(EnmCol.部署コード, "小区分CD", 80, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub列初期設定(EnmCol.部署名, "クラス", 400, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub列初期設定(EnmCol.部署カナ名, "ｶﾅ名", 300, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub列初期設定(EnmCol.電話番号, "電話番号", 100, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub列初期設定(EnmCol.更新日時, "更新日時", 172, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)

            .Cols(EnmCol.部署ID).Visible = False
            .Cols(EnmCol.部署コード).Visible = False
            .Cols(EnmCol.部署カナ名).Visible = False
            .Cols(EnmCol.電話番号).Visible = False
            .Cols(EnmCol.更新日時).Visible = False
        End With
    End Sub

    Public Function 表示SQL() As String
        With New CSqlEx
            .gSubClearSQL()
            'SELECT
            .gSubSelect("DM部署.部署ID")
            .gSubSelect("DM企業.名称漢字")
            .gSubSelect("DM部署.部署コード")
            .gSubSelect("DM部署.名称漢字")
            .gSubSelect("DM部署.名称カナ")
            .gSubSelect("DM部署.電話番号")
            .gSubSelect日時文字列("DM部署.更新日時")
            ''FROM
            .gSubFrom("DM企業")
            .gSubFrom("DM部署")
            ''WHERE
            .gSubWhere("DM企業.企業ID = DM部署.企業ID")
            ''ORDER BY
            .gSubOrderBy("DM部署.企業ID")
            .gSubOrderBy("部署コード")
            .gSubOrderBy("部署ID")

            Return .gSQL文の取得
        End With
    End Function
End Class
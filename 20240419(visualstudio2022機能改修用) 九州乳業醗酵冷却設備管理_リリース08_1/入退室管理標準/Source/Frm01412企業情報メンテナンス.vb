Public Class Frm01412企業情報メンテナンス
    '#####################################################################################
    '型
    '#####################################################################################
    Public Enum EnmCol
        企業ID
        企業コード
        企業区分
        企業名
        企業カナ名
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
    Private Sub Frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mSubグリッド設定()
        'CSV出力は無効化
        Me.btnCSV出力.Visible = False
    End Sub

    Private Sub Frm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gRSubF再表示()
        gRSubボタン設定()
    End Sub

    Private Sub btn変更_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn変更.Click
        If pグリッド.Row < 0 Then
            CMsg.gMsg_注意(MSG_データ未選択)
            Exit Sub
        End If
        更新処理(enm処理区分.変更)
    End Sub

    Private Sub btn追加_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn追加.Click
        更新処理(enm処理区分.追加)
    End Sub

    Private Sub btn削除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn削除.Click
        If pグリッド.Row < 0 Then
            CMsg.gMsg_注意(MSG_データ未選択)
            Exit Sub
        End If

        If Is企業を使用している() Then
            Exit Sub
        End If
        標準削除処理()
    End Sub

    Private Sub BtnCSV出力_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSV出力.Click
        グリッドを元にCSV出力()
    End Sub

    Private Sub btnマスタメンテメニュー_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnマスタメンテメニュー.Click
        gMdiMain.gSubMDI子フォームを開く(C画面制御入退室管理.マスタメンテメニュー)
    End Sub

    Private Sub UsrDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles UsrDataGridView1.CellDoubleClick
        With UsrDataGridView1
            'ヘッダ行でない場合
            If e.RowIndex >= 0 And btn変更.Enabled = True Then
                btn変更_Click(sender, e)
            End If
        End With
    End Sub
    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Private Sub mSubグリッド設定()
        pグリッド = UsrDataGridView1
        With pグリッド
            .gSubグリッド初期設定(EnmCol.cols)

            .gSub列初期設定(EnmCol.企業ID, "企業ID", 100, C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter)
            .gSub列初期設定(EnmCol.企業コード, "中区分CD", 80, C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter)
            .gSub列初期設定(EnmCol.企業区分, "大区分", 150, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub列初期設定(EnmCol.企業名, "学年", 400, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub列初期設定(EnmCol.企業カナ名, "ｶﾅ名", 330, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub列初期設定(EnmCol.電話番号, "電話番号", 100, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)
            .gSub列初期設定(EnmCol.更新日時, "更新日時", 172, C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter)

            .Cols(EnmCol.企業ID).Visible = False
            .Cols(EnmCol.企業コード).Visible = False
            .Cols(EnmCol.企業区分).Visible = False
            .Cols(EnmCol.企業カナ名).Visible = False
            .Cols(EnmCol.電話番号).Visible = False
            .Cols(EnmCol.更新日時).Visible = False
        End With
    End Sub

    Protected Overrides Function iRStr表示SQL(Optional ByVal enmSqlType As CSql.SQL_TYPE = CSql.SQL_TYPE.SQL_SELECT) As String
        Return mSQL取得()
    End Function

    Private Function mSQL取得(Optional ByVal SQL種別 As enmSQL種別 = enmSQL種別.一覧表示) As String
        With New CSqlEx
            'SELECT
            If SQL種別 = enmSQL種別.一覧表示 Then
                .gSubSelect("企業ID")
            End If
            .gSubSelect("企業コード")
            .gSubSelect("ISNULL(DP企業区分.名称,'') 企業区分")
            .gSubSelect("ISNULL(DM企業.名称漢字,'') 企業名")
            .gSubSelect("ISNULL(DM企業.名称カナ,'') 企業カナ名")
            .gSubSelect("ISNULL(DM企業.電話番号,'') 電話番号")
            .gSubSelect日時文字列("DM企業.更新日時", , True)
            'FROM
            .gSubFrom("DM企業" & _
                      " LEFT JOIN DP企業区分 ON DM企業.企業区分ID = DP企業区分.企業区分ID")
            'WHERE
            'ORDER BY
            .gSubOrderBy("DM企業.企業コード")
            .gSubOrderBy("DP企業区分.表示優先順")
            .gSubOrderBy("DM企業.企業ID")

            Return .gSQL文の取得
        End With
    End Function

    Private Sub 更新処理(ByVal o処理区分 As enm処理区分)
        With New Dlg0011マスタ情報メンテナンス
            .親画面 = Me
            .処理区分 = o処理区分
            .処理対象 = enmメンテ処理対象.企業

            .Uc企業1.処理区分 = .処理区分
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                gRSubF再表示()
            End If
        End With
    End Sub

    Public Overrides Function 削除処理() As Boolean
        With New CSqlEx
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DM企業"
            .gSubWhere("企業ID", pグリッド.セル文字列(EnmCol.企業ID), , , , , , , False)
            .gSubWhere更新日時(pグリッド.セル文字列(EnmCol.更新日時))

            Return CUsrctl.標準削除処理(.gSQL文の取得)
        End With
    End Function

    Private Function Is企業を使用している() As Boolean
        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM園児")
            .gSubWhere("企業ID", pグリッド.セル文字列(EnmCol.企業ID), , , , , , , False)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                'CMsg.gMsg_エラー("登録者情報で使用されている企業の削除はできません。")
                CMsg.gMsg_注意("園児情報で使用されている学年情報の削除はできません。")
                Return True
            End If
        End With

        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM部署")
            .gSubWhere("企業ID", pグリッド.セル文字列(EnmCol.企業ID), , , , , , , False)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                'CMsg.gMsg_エラー("部署情報で使用されている企業の削除はできません。")
                CMsg.gMsg_注意("クラス情報で使用されている学年情報の削除はできません。")
                Return True
            End If
        End With

        'With New CSql
        '    .gSubSelect("COUNT(*)")
        '    .gSubFrom("DM事業所")
        '    .gSubWhere("企業ID", pグリッド.セル文字列(EnmCol.企業ID), , , , , , , False)

        '    If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
        '        'CMsg.gMsg_エラー("事業所情報で使用されている企業の削除はできません。")
        '        CMsg.gMsg_エラー("事業所情報で使用されている中区分の削除はできません。")
        '        Return True
        '    End If
        'End With
    End Function
End Class

Public Class Frm0142企業区分メンテナンス

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
    Private Sub Frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mSubグリッド設定()
        'CSV出力は無効化
        Me.BtnCSV出力.Visible = False
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

        If Is企業区分を使用している() Then
            'CMsg.gMsg_エラー("企業情報で使用されている企業区分の削除はできません。")
            CMsg.gMsg_エラー("中区分情報で使用されている大区分の削除はできません。")
            Exit Sub
        End If
        標準削除処理()
    End Sub

    Private Sub BtnCSV出力_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCSV出力.Click
        グリッドを元にCSV出力()
    End Sub

    Private Sub btnマスタメンテメニュー_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnマスタメンテメニュー.Click
        gMdiMain.gSubMDI子フォームを開く(C画面制御入退室管理.マスタメンテメニュー)
    End Sub

    Private Sub UsrDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles UsrDataGridView企業区分.CellDoubleClick
        With UsrDataGridView企業区分
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
        pグリッド = UsrDataGridView企業区分
        With New C企業区分
            .グリッド設定(pグリッド)
        End With
    End Sub

    Protected Overrides Function iRStr表示SQL(Optional ByVal enmSqlType As CSql.SQL_TYPE = CSql.SQL_TYPE.SQL_SELECT) As String
        Return mSQL取得()
    End Function

    Private Sub 更新処理(ByVal o処理区分 As enm処理区分)
        With New Dlg0011マスタ情報メンテナンス
            .親画面 = Me
            .処理区分 = o処理区分
            .処理対象 = enmメンテ処理対象.企業区分

            .Uc企業区分1.処理区分 = o処理区分
            .Uc企業区分1.前回更新日時 = pグリッド.セル文字列(C企業区分.EnmCol.更新日時)
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                gRSubF再表示()
            End If
        End With
    End Sub

    Public Overrides Function 削除処理() As Boolean
        With New CSqlEx
            .gSubClearSQL()
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DP企業区分"
            .gSubWhere("企業区分ID", pグリッド.セル文字列(C企業区分.EnmCol.企業区分ID), , , , , , , False)
            .gSubWhere更新日時(pグリッド.セル文字列(C企業区分.EnmCol.更新日時))

            Return CUsrctl.標準削除処理(.gSQL文の取得)
        End With
    End Function

    Private Function mSQL取得(Optional ByVal SQL種別 As enmSQL種別 = enmSQL種別.一覧表示) As String
        With New CSqlEx
            'SELECT
            If SQL種別 = enmSQL種別.一覧表示 Then
                .gSubSelect("企業区分ID")
            End If
            .gSubSelect("名称 企業区分名")
            .gSubSelect日時文字列()
            'FROM
            .gSubFrom("DP企業区分")
            .gSubWhere("有効フラグ", "1")
            'ORDER BY
            .gSubOrderBy("表示優先順")

            Return .gSQL文の取得
        End With
    End Function

    Private Function Is企業区分を使用している() As Boolean
        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM企業")
            .gSubWhere("企業区分ID", pグリッド.セル文字列(C企業区分.EnmCol.企業区分ID), , , , , , , False)

            Return CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0
        End With
    End Function
End Class

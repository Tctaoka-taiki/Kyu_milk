Public Class Frm01413部署情報メンテナンス
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

        If Is部署を使用している() Then
            Exit Sub
        End If
        標準削除処理()
    End Sub

    Private Sub BtnCSV出力_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCSV出力.Click
        グリッドを元にCSV出力()
    End Sub

    Private Sub btnマスタメンテメニュー_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnマスタメンテメニュー.Click
        'マスタメンテメニュー
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
        'pFlxGrid = FlxData部署コード
        pグリッド = UsrDataGridView1
        With New C部署
            .グリッド設定(pグリッド)
        End With
    End Sub

    Protected Overrides Function iRStr表示SQL(Optional ByVal enmSqlType As CSql.SQL_TYPE = CSql.SQL_TYPE.SQL_SELECT) As String
        Return mSQL取得()
    End Function

    Private Function mSQL取得(Optional ByVal SQL種別 As enmSQL種別 = enmSQL種別.一覧表示) As String
        With New CSqlEx
            .gSubClearSQL()
            'SELECT
            If SQL種別 = enmSQL種別.一覧表示 Then
                .gSubSelect("DM部署.部署ID")
            End If
            .gSubSelect("ISNULL(DM企業.名称漢字,'') 企業名")
            .gSubSelect("ISNULL(DM部署.部署コード,'') 部署コード")
            .gSubSelect("ISNULL(DM部署.名称漢字,'') 部署名")
            .gSubSelect("ISNULL(DM部署.名称カナ,'') 部署カナ名")
            .gSubSelect("ISNULL(DM部署.電話番号,'') 電話番号")
            .gSubSelect日時文字列("DM部署.更新日時", , True)
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

    Private Sub 更新処理(ByVal o処理区分 As enm処理区分)
        With New Dlg0011マスタ情報メンテナンス
            .親画面 = Me
            .処理区分 = o処理区分
            .処理対象 = enmメンテ処理対象.部署

            .Uc部署1.処理区分 = o処理区分
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                gRSubF再表示()
            End If
        End With
    End Sub

    Public Overrides Function 削除処理() As Boolean
        With New CSqlEx
            .gSubClearSQL()
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DM部署"
            .gSubWhere("部署ID", pグリッド.セル文字列(C部署.EnmCol.部署ID), , , , , , , False)
            .gSubWhere更新日時(pグリッド.セル文字列(C部署.EnmCol.更新日時))

            Return CUsrctl.標準削除処理(.gSQL文の取得)
        End With
    End Function

    Private Function Is部署を使用している() As Boolean
        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM園児")
            .gSubWhere("部署ID", pグリッド.セル文字列(C部署.EnmCol.部署ID), , , , , , , False)

            If CUsrctl.gDp.ExecuteScalarによる件数取得(CUsrctl.gDp.gdb接続.CreateCommand(), .gSQL文の取得) > 0 Then
                'CMsg.gMsg_エラー("登録者情報で使用されている部署の削除はできません。")
                CMsg.gMsg_注意("園児情報で使用されているクラス情報の削除はできません。")
                Return True
            End If
        End With
    End Function
End Class

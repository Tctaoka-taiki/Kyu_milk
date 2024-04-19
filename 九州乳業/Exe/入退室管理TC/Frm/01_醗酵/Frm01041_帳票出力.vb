
Imports System.Data.Common
Public Class Frm01041_帳票出力
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
    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Frm00001_メインメニュー_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            '
            If txt処理No.Focused = True Then
                '入力されているデータを元に画面遷移
                Select Case txt処理No.Text
                    Case "1"
                        If CMsg.gMsg_YesNo("マスターリスト（ハード）を出力してもよろしいですか？") = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                        'マスターデータ
                        With New CSqlEx
                            .gSubSelect("品種CD as 品種CD")
                            .gSubSelect("品種名 as 品種名")
                            .gSubSelect("所定醗酵時間 as 所定醗酵時間")
                            .gSubSelect("所定冷却時間 as 所定冷却時間")
                            .gSubFrom("DM品種")
                            .gSubWhere("製品区分 = 0")
                            .gSubOrderBy("品種CD")

                            帳票出力(New マスター設定, "***マスター設定（ハード）***", .gSQL文の取得)
                        End With

                    Case "2"
                        If CMsg.gMsg_YesNo("マスターリスト（プレーン）を出力してもよろしいですか？") = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                        'マスターデータ
                        With New CSqlEx
                            .gSubSelect("品種CD as 品種CD")
                            .gSubSelect("品種名 as 品種名")
                            .gSubSelect("所定醗酵時間 as 所定醗酵時間")
                            .gSubSelect("所定冷却時間 as 所定冷却時間")
                            .gSubFrom("DM品種")
                            .gSubWhere("製品区分 = 1")
                            .gSubOrderBy("品種CD")

                            帳票出力(New マスター設定, "***マスター設定（プレーン）***", .gSQL文の取得)
                        End With

                    Case "3"
                        If CMsg.gMsg_YesNo("在庫リスト（醗酵）を出力してもよろしいですか？") = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                        'マスターデータ
                        With New CSqlEx
                            .gSubSelect("品種CD as 品種CD")
                            .gSubSelect("品種名 as 品種名")
                            .gSubSelect("所定醗酵時間 as 所定醗酵時間")
                            .gSubSelect("所定冷却時間 as 所定冷却時間")
                            .gSubFrom("DM品種")
                            .gSubWhere("製品区分 = 1")
                            .gSubOrderBy("品種CD")

                            帳票出力(New マスター設定, "***マスター設定（プレーン）***", .gSQL文の取得)
                        End With

                End Select
                '完了
                txt処理No.Text = ""
                txt処理No.Focus()
            End If
        End If

    End Sub


    Private Sub 帳票出力(ByVal レポート As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal 名称 As String, ByVal strSQL As String)
        Try
            ''処理中設定
            Call Me.gMdiMain.gSub処理中設定(Me, True, M定数.MSG_処理中)

            Call Application.DoEvents()

            Dim reader As DbDataReader = Nothing

            Try
                ''データ抽出
                If Not CUsrctl.gDp.gBlnReader(strSQL, reader) Then
                    Exit Sub
                End If

                If Not reader.Read Then
                    CMsg.gMsg_注意("出力する情報がありません")
                    Exit Sub
                End If

                'DataReaderを元にデータテーブルを作成する
                Dim テーブル As New DataTable

                For i As Integer = 0 To reader.FieldCount - 1
                    テーブル.Columns.Add(reader.GetName(i))
                Next

                ''明細書き込み
                Do
                    Dim コピー先の行 As DataRow = テーブル.NewRow
                    For i As Integer = 0 To reader.FieldCount - 1
                        If IsDBNull(reader(i)) Then
                            コピー先の行(i) = ""
                        Else
                            コピー先の行(i) = CStr(reader(i)).Trim
                        End If

                    Next
                    テーブル.Rows.Add(コピー先の行)

                Loop While reader.Read

                With New CReport
                    レポート.SetDataSource(テーブル)
                    レポート.DataDefinition.FormulaFields.Item("UnboundString1").Text = "'" & 名称 & "'"

                    .Text = 名称
                    .印刷実行(レポート, False)
                End With

            Catch ex As Exception
                Call CMsg.gMsg_エラー(ex.ToString)
                レポート.Clone()

            Finally
                CUsrctl.gDp.gSubReaderClose(reader)
            End Try

        Catch ex As Exception
            Call CMsg.gMsg_エラー(ex.ToString)

        Finally
            ''処理中解除
            Me.gMdiMain.gSub処理中設定(Me, False, "")
        End Try

    End Sub
End Class

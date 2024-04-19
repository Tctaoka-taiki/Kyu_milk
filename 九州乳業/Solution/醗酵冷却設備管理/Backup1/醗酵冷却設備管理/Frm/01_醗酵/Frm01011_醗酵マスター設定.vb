
Imports System.Data.Common

Public Class Frm01011_醗酵マスター設定
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

    Private Sub Frm01011_醗酵マスター設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmb製品区分.Text = "ハード"
        mSub品種情報表示()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim dlg As New Dlg01999_品種登録
            With dlg
                .cmb製品区分.SelectedIndex = Me.cmb製品区分.SelectedIndex
                .ShowDialog()

            End With
            mSub品種情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Try
            Dim dlg As New Dlg01999_品種削除
            With dlg
                .ShowDialog()

            End With
            mSub品種情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Try
            Dim dlg As New Dlg01999_品種修正
            With dlg
                .ShowDialog()

            End With
            mSub品種情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub


    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵メインメニュー)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub mSub品種情報表示()
        Me.dgv生産データ.Rows.Clear()

        Dim reader As DbDataReader = Nothing
        Try
            With New CSqlEx
                .gSubSelect("品種CD")
                .gSubSelect("品種名")
                .gSubSelect("所定醗酵時間")
                .gSubSelect("所定冷却時間")
                .gSubFrom("DM品種")
                .gSubWhere("製品区分", Me.cmb製品区分.SelectedIndex, , , , , , , False)
                .gSubOrderBy("品種CD")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    Dim i As Integer = 0
                    While reader.Read
                        Me.dgv生産データ.Rows.Add()
                        Me.dgv生産データ.Item(0, i).Value = reader.GetValue(0)
                        Me.dgv生産データ.Item(1, i).Value = reader.GetValue(1)
                        Me.dgv生産データ.Item(2, i).Value = reader.GetValue(2) & "分"
                        Me.dgv生産データ.Item(3, i).Value = reader.GetValue(3) & "分"
                        i += 1
                    End While

                End If
            End With
        Catch ex As Exception
        Finally
            Me.dgv生産データ.CurrentCell = Nothing
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Dim intSelectIDX As Integer = Me.cmb製品区分.SelectedIndex
        If intSelectIDX = 1 Then
            intSelectIDX = 0
        Else
            intSelectIDX = 1
        End If
        Me.cmb製品区分.SelectedIndex = intSelectIDX

    End Sub

    Private Sub cmb製品区分_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb製品区分.SelectedIndexChanged
        mSub品種情報表示()
    End Sub

    Private Sub btnF10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF10.Click
        Dim intSelectIDX As Integer = Me.cmb製品区分.SelectedIndex
        If intSelectIDX = 1 Then
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

                CMdiMain.帳票出力(New マスター設定, "***マスター設定（プレーン）***", .gSQL文の取得)
            End With
        Else
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

                CMdiMain.帳票出力(New マスター設定, "***マスター設定（ハード）***", .gSQL文の取得)
            End With
        End If
    End Sub
End Class

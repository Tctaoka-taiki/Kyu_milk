
Imports System.Data.Common

Public Class Frm01012_醗酵入庫棚順設定
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
    Dim intカレントページ As Integer = 1
    Private Sub Frm01012_醗酵入庫棚順設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        For i = 0 To 23
            Me.dgv棚順1.Rows.Add()
            Me.dgv棚順2.Rows.Add()
            Me.dgv棚順3.Rows.Add()
            Me.dgv棚順4.Rows.Add()
            Me.dgv棚順5.Rows.Add()
        Next
        Me.dgv棚順1.CurrentCell = Nothing
        Me.dgv棚順2.CurrentCell = Nothing
        Me.dgv棚順3.CurrentCell = Nothing
        Me.dgv棚順4.CurrentCell = Nothing
        Me.dgv棚順5.CurrentCell = Nothing

        倉庫情報表示()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim dlg As New Dlg01999_棚メンテナンス登録
            With dlg
                .m画面モード = 0
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Try
            Dim dlg As New Dlg01999_棚メンテナンス削除
            With dlg
                .m画面モード = 0
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Try
            Dim dlg As New Dlg01999_棚メンテナンス修正
            With dlg
                .m画面モード = 0
                .ShowDialog()

            End With
            倉庫情報表示()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Try
            Dim dlg As New Dlg01999_棚メンテナンス禁止棚
            With dlg
                .m画面モード = 0
                .ShowDialog()

            End With
            倉庫情報表示()

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

    Private Sub 倉庫情報表示()
        Dim OFFSET As Integer = 0
        If intカレントページ = 2 Then
            OFFSET = 120
        End If
        Dim i As Integer = 0
        For i = 0 To 23
            Me.dgv棚順1(0, i).Value = i + 1 + OFFSET
            Me.dgv棚順2(0, i).Value = i + 25 + OFFSET
            Me.dgv棚順3(0, i).Value = i + 49 + OFFSET
            Me.dgv棚順4(0, i).Value = i + 73 + OFFSET
            Me.dgv棚順5(0, i).Value = i + 97 + OFFSET
            Me.dgv棚順1(1, i).Value = ""
            Me.dgv棚順2(1, i).Value = ""
            Me.dgv棚順3(1, i).Value = ""
            Me.dgv棚順4(1, i).Value = ""
            Me.dgv棚順5(1, i).Value = ""
        Next

        Application.DoEvents()

        Dim reader As DbDataReader = Nothing
        Dim 列 As Integer = 99
        Dim 連 As Integer = 99
        Dim 段 As Integer = 99

        Try
            With New CSqlEx
                .gSubSelect("引当順")
                '.gSubSelect("CONVERT(varchar,列) + '-' + CONVERT(varchar,連) + '-' + CONVERT(varchar,段) as LOC")
                .gSubSelect("列")
                .gSubSelect("連")
                .gSubSelect("段")
                .gSubFrom("DM棚")
                .gSubWhere("倉庫区分", 0, , , , , , , False, )
                .gSubWhere("(棚区分 = 0 OR 棚区分 = 2)")
                .gSubOrderBy("引当順")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        データ表示(reader.GetValue(0).ToString, reader.GetValue(1).ToString & "-" & reader.GetValue(2).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(3).ToString)
                    End While
                End If

            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

    End Sub

    Private Sub データ表示(ByVal 引当順 As Integer, ByVal str棚番地 As String)
        If intカレントページ = 1 Then
            If 引当順 <= 120 Then
                Select Case Math.Ceiling(引当順 / 24)
                    Case 1
                        Me.dgv棚順1(1, 引当順 - 1).Value = str棚番地
                    Case 2
                        Me.dgv棚順2(1, 引当順 - 25).Value = str棚番地
                    Case 3
                        Me.dgv棚順3(1, 引当順 - 49).Value = str棚番地
                    Case 4
                        Me.dgv棚順4(1, 引当順 - 73).Value = str棚番地
                    Case 5
                        Me.dgv棚順5(1, 引当順 - 97).Value = str棚番地

                End Select
            Else
                Exit Sub
            End If
        Else
            If 引当順 > 120 Then
                引当順 = 引当順 - 120
                Select Case Math.Ceiling(引当順 / 24)
                    Case 1
                        Me.dgv棚順1(1, 引当順 - 1).Value = str棚番地
                    Case 2
                        Me.dgv棚順2(1, 引当順 - 25).Value = str棚番地
                    Case 3
                        Me.dgv棚順3(1, 引当順 - 49).Value = str棚番地
                    Case 4
                        Me.dgv棚順4(1, 引当順 - 73).Value = str棚番地
                    Case 5
                        Me.dgv棚順5(1, 引当順 - 97).Value = str棚番地

                End Select

            Else
                Exit Sub
            End If

        End If

    End Sub
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        intカレントページ = 1
        倉庫情報表示()
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        intカレントページ = 2
        倉庫情報表示()
    End Sub
End Class


Imports System.Data.Common
Public Class Dlg01999_トラッキング削除
    Dim int該当ステータス As Integer = 0
    Dim int該当製造ライン As Integer = 99

    Private Sub Dlg01999_トラッキング削除_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mSub初期化()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If CMsg.gMsg_YesNo("トラッキング削除を実行しても宜しいですか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        '該当するトラッキングを削除する
        Dim 削除対象 As Integer = Me.txt処理No.Text
        トラッキング削除(削除対象)
        DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub btnF12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub txt処理No_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt処理No.TextChanged
        If Me.txt処理No.Text = "" Then
            mSub初期化()
            Exit Sub
        End If
        トラッキング内容表示(Me.txt処理No.Text)
    End Sub

    Private Sub mSub初期化()
        Me.lblラインNo.Text = "---"
        Me.lbl設備名称.Text = ""
        Me.btnF1.Enabled = False
    End Sub

    Private Sub トラッキング内容表示(ByVal int処理No As Integer)
        Me.btnF1.Enabled = True
        Select Case m画面モード
            Case 0
                If int処理No >= 1 And int処理No <= 9 Then
                    Me.lblラインNo.Text = "ハード1"
                    Me.lbl設備名称.Text = str設備名称(int処理No)
                    int該当製造ライン = 0

                ElseIf int処理No >= 11 And int処理No <= 19 Then
                    Me.lblラインNo.Text = "プレーン1"
                    Me.lbl設備名称.Text = str設備名称(int処理No - 10)
                    int該当製造ライン = 1

                ElseIf int処理No >= 21 And int処理No <= 23 Then
                    Me.lblラインNo.Text = "---"
                    Me.lbl設備名称.Text = str設備名称(int処理No - 11)
                    int該当製造ライン = 99

                ElseIf int処理No >= 31 And int処理No <= 39 Then
                    Me.lblラインNo.Text = "ハード2"
                    Me.lbl設備名称.Text = str設備名称(int処理No - 30)
                    int該当製造ライン = 2
                Else
                    mSub初期化()
                End If

            Case 1
                Me.lblラインNo.Text = "---"

                If int処理No = 1 Then
                    Me.lbl設備名称.Text = "急冷室前"

                ElseIf (int処理No >= 2 And int処理No <= 22) Then
                    Me.lbl設備名称.Text = "急冷コンベヤ"

                ElseIf int処理No = 23 Then
                    Me.lbl設備名称.Text = "入庫ST"

                ElseIf int処理No = 24 Then
                    Me.lbl設備名称.Text = "クレーン"

                ElseIf int処理No = 25 Then
                    Me.lbl設備名称.Text = "出庫ST"

                ElseIf int処理No = 26 Then
                    Me.lbl設備名称.Text = "出庫コンベヤ"

                ElseIf int処理No = 27 Then
                    Me.lbl設備名称.Text = "出庫前室"

                ElseIf int処理No = 28 Then
                    Me.lbl設備名称.Text = "コンベヤ"

                ElseIf int処理No = 29 Then
                    Me.lbl設備名称.Text = "パレタイザ前"

                ElseIf int処理No = 30 Then
                    Me.lbl設備名称.Text = "パレタイザ１"

                ElseIf int処理No = 31 Then
                    Me.lbl設備名称.Text = "パレタイザ２"

                ElseIf int処理No = 32 Then
                    Me.lbl設備名称.Text = "受渡コンベヤ"

                Else
                    mSub初期化()
                End If
        End Select

    End Sub

    Private Function str設備名称(ByVal no As Integer) As String
        Dim 設備名称 As String
        Select Case no
            Case 1
                設備名称 = "段積機"
                int該当ステータス = 0
            Case 2, 3, 4, 5, 6
                設備名称 = "コンベヤ"
                int該当ステータス = 1
            Case 7
                設備名称 = "入庫ST１"
                int該当ステータス = 2   '※2～3 STNOで引っ掛けること
            Case 8
                設備名称 = "入庫ST２"
                int該当ステータス = 2
            Case 9
                設備名称 = "入庫ST３"
                int該当ステータス = 2
            Case 10
                設備名称 = "クレーン"
                int該当ステータス = 5
            Case 11
                設備名称 = "出庫ST"
                int該当ステータス = 10
            Case 12
                設備名称 = "冷却室前"
                int該当ステータス = 20
            Case Else
                設備名称 = ""
        End Select

        Return 設備名称
    End Function

    Private Sub トラッキング削除(ByVal int処理No As Integer)
        If m画面モード = 0 Then '発酵側
            Select Case int該当ステータス
                Case 0

                Case 1
                    Delete醗酵コンベヤトラッキング(int処理No)

                Case 2 To 4
                    Delete醗酵入庫STトラッキング(int処理No)

                Case 5  'クレーンのトラッキング削除
                    Delete醗酵クレーントラッキング()

                Case 10, 11, 20 '単体で絞り込めるトラッキング
                    Deleteトラッキング(int該当ステータス)
            End Select

        Else    '冷却側
            Select Case int処理No
                Case 1  '急冷室前
                    Deleteトラッキング(20)

                Case 2 To 22    '急冷コンベヤデータ
                    Delete冷却急冷コンベヤトラッキング(int処理No)

                Case 23 '入庫ST(ステータス：22-25)
                    Delete冷却入庫STトラッキング()

                Case 24 'クレーン（ステータス：26、30）
                    Delete冷却クレーントラッキング()

                Case 25 To 32
                    '出庫ST(ステータス:31)
                    '出庫CV(ステータス:32)
                    '出庫前室（ステータス：33）
                    'コンベヤ（ステータス：34）
                    'パレタイザ前（ステータス：35）
                    'パレタイザ１（ステータス：36）
                    'パレタイザ２（ステータス：37）
                    '受渡CV（ステータス：38）
                    Deleteトラッキング(int処理No + 6)
            End Select
        End If
    End Sub

    Private Sub Deleteトラッキング(ByVal intステータス As Integer)
        ''作業登録
        'Sub作業履歴登録_ステータス("ステータス = " & intステータス)

        With New CSql
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DNトラッキング"
            .gSubWhere("ステータス", intステータス, , , , , , , False)

            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得) Then
                Exit Sub
            End If

        End With
    End Sub

    Private Sub Delete醗酵コンベヤトラッキング(ByVal No As Integer)
        'コンベヤ上のアイテムでNoに合うトラッキングを削除
        Dim reader As DbDataReader = Nothing
        Dim 削除管理No As Integer
        Dim CNT As Integer = 0
        Try
            With New CSqlEx
                .gSubSelect("A.管理No")
                .gSubFrom("DNトラッキング A")
                .gSubWhere("A.製造ライン", int該当製造ライン, , , , , , , False)
                .gSubWhere("ステータス", 1, , , , , , , False)
                .gSubOrderBy("A.更新日時")

                Dim OFFSET As Integer
                Select Case int該当製造ライン
                    Case 0
                        OFFSET = 6
                    Case 1
                        OFFSET = 16
                    Case Else
                        OFFSET = 36

                End Select
                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If OFFSET - No = CNT Then
                            削除管理No = reader.GetValue(0)
                            CNT += 1
                            Exit While
                        End If
                        CNT += 1
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        If CNT = 0 Then
            Exit Sub
        End If

        ''作業登録
        'Sub作業履歴登録_管理No(削除管理No)

        '対象トラッキングの削除
        With New CSql
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DNトラッキング"
            .gSubWhere("管理No", 削除管理No, , , , , , , False)

            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得) Then
                Exit Sub
            End If
        End With

        '該当ラインに確定荷数が登録されていれば減算を行うこと
        If int確定荷数() > 0 Then
            '減算処理を実施
            Update製造製品の確定荷数を減算()

        End If
    End Sub

    Private Sub Delete醗酵入庫STトラッキング(ByVal No As Integer)
        'コンベヤ上のアイテムでNoに合うトラッキングを削除
        Dim reader As DbDataReader = Nothing
        Dim 削除管理No As Integer
        Dim 荷積可済 As Integer = 0
        Dim CNT As Integer = 0

        Dim OFFSET As Integer
        Select Case int該当製造ライン
            Case 0
                OFFSET = 6
            Case 1
                OFFSET = 16
            Case Else
                OFFSET = 36

        End Select

        Try
            With New CSqlEx
                .gSubSelect("A.管理No")
                .gSubSelect("A.荷積可済")
                .gSubFrom("DNトラッキング A")
                .gSubWhere("A.製造ライン", int該当製造ライン, , , , , , , False)
                .gSubWhere("ステータス", 2, , , , , , , False)
                .gSubWhere("STNO", No - OFFSET, , , , , , , False)
                .gSubOrderBy("A.更新日時")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        削除管理No = reader.GetValue(0)
                        If reader.GetValue(1).ToString = "1" Then
                            荷積可済 = 1
                        End If
                        CNT += 1
                        Exit While
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        If CNT = 0 Then
            Exit Sub
        End If

        ''作業登録
        'Sub作業履歴登録_管理No(削除管理No)

        '対象トラッキングの削除
        With New CSql
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DNトラッキング"
            .gSubWhere("管理No", 削除管理No, , , , , , , False)

            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得) Then
                Exit Sub
            End If
        End With

        '
        If 荷積可済 = 0 Then '荷積可済でない場合、ロット完処理により確定荷数に含まれている可能性がある
            '該当ラインに確定荷数が登録されていれば減算を行うこと
            If int確定荷数() > 0 Then
                '減算処理を実施
                Update製造製品の確定荷数を減算()

            End If

        End If
    End Sub

    Private Function int確定荷数() As Integer
        Dim reader As DbDataReader = Nothing
        Dim 確定荷数 As Integer = 0

        Try
            With New CSqlEx
                .gSubSelect("A.確定荷数")
                .gSubFrom("DN製造製品 A")
                .gSubWhere("A.製造ライン", int該当製造ライン, , , , , , , False)

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        確定荷数 = reader.GetValue(0)
                        Exit While
                    End While
                End If
            End With
            Return 確定荷数
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

    End Function

    Public Sub Update製造製品の確定荷数を減算()
        Try
            With New CSql
                .pSQL取得タイプ = CSql.SQL_TYPE.SQL_UPDATE
                .pテーブル名 = "DN製造製品"
                .gSubColumnValue("確定荷数", "確定荷数 - 1", False)
                .gSubWhere("製造ライン", int該当製造ライン, , , , , , , , )

                If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
                    Exit Sub
                End If
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub Delete醗酵クレーントラッキング()
        ''作業登録
        'Sub作業履歴登録_ステータス("(ステータス = 5) OR (ステータス = 9)")

        With New CSql
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DNトラッキング"
            .gSubWhere("(ステータス = 5) OR (ステータス = 9)")

            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得) Then
                Exit Sub
            End If
        End With
    End Sub

    Private Sub Delete冷却急冷コンベヤトラッキング(ByVal No As Integer)
        'コンベヤ上のアイテムでNoに合うトラッキングを削除
        Dim reader As DbDataReader = Nothing
        Dim 削除ユニットSEQ As Integer
        Dim CNT As Integer = 0
        Try
            With New CSqlEx
                .gSubSelect("A.ユニットSEQ")
                .gSubFrom("DNトラッキング A")
                .gSubWhere("ステータス", 21, , , , , , , False)
                .gSubGroupBy("A.ユニットSEQ")
                .gSubOrderBy("MAX(A.更新日時)")

                If CUsrctl.gDp.gBlnReader(.gSQL文の取得, reader) Then
                    While reader.Read
                        If 22 - No = CNT Then
                            削除ユニットSEQ = reader.GetValue(0)
                            CNT += 1
                            Exit While
                        End If
                        CNT += 1
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        If CNT = 0 Then
            Exit Sub
        End If

        ''作業登録
        'Sub作業履歴登録_ユニットSEQ(削除ユニットSEQ)

        '対象トラッキングの削除
        With New CSql
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DNトラッキング"
            .gSubWhere("ユニットSEQ", 削除ユニットSEQ, , , , , , , False)

            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得) Then
                Exit Sub
            End If
        End With
    End Sub

    Private Sub Delete冷却入庫STトラッキング()
        ''作業登録
        'Sub作業履歴登録_ステータス("(ステータス = 26) OR (ステータス = 30)")

        With New CSql
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DNトラッキング"
            .gSubWhere("(ステータス = 26) OR (ステータス = 30)")

            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得) Then
                Exit Sub
            End If
        End With
    End Sub

    Private Sub Delete冷却クレーントラッキング()
        ''作業登録
        'Sub作業履歴登録_ステータス("(ステータス = 26) OR (ステータス = 30)")

        With New CSql
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_DELETE
            .pテーブル名 = "DNトラッキング"
            .gSubWhere("(ステータス = 26) OR (ステータス = 30)")

            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得) Then
                Exit Sub
            End If
        End With
    End Sub

    'Private Sub Sub作業履歴登録_管理No(ByVal 対象管理No As Integer)
    '    '現在の発酵室温度の取得

    '    '履歴データの作成
    '    Try
    '        With New CSql
    '            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_SELECTINSERT
    '            .pテーブル名 = "DL作業履歴"
    '            .gSubColumn("倉庫区分")
    '            .gSubColumn("作業区分")
    '            .gSubColumn("ロットNo")
    '            .gSubColumn("サンプルNo")
    '            .gSubColumn("品種CD")
    '            .gSubColumn("受入数")
    '            .gSubColumn("温度信号")
    '            .gSubColumn("更新プログラム")
    '            .gSubSelect(0)
    '            .gSubSelect(2)
    '            .gSubSelect("DNトラッキング.ロットNo")
    '            .gSubSelect("DNトラッキング.サンプルNo")
    '            .gSubSelect("DNトラッキング.品種CD")
    '            .gSubSelect("トラッキング.受入数")
    '            .gSubSelect("'" & str直前TMPデータ_醗酵 & "'")
    '            .gSubSelect("'" & Name & "'")
    '            .gSubFrom("DNトラッキング")
    '            .gSubWhere("管理No", 対象管理No, , , , , , , False, )

    '            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
    '                Exit Sub
    '            End If
    '        End With
    '    Catch ex As Exception
    '    Finally
    '    End Try
    'End Sub

    'Private Sub Sub作業履歴登録_ステータス(ByVal strステータス条件 As String)
    '    '現在の発酵室温度の取得

    '    '履歴データの作成
    '    Try
    '        With New CSql
    '            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_SELECTINSERT
    '            .pテーブル名 = "DL作業履歴"
    '            .gSubColumn("倉庫区分")
    '            .gSubColumn("作業区分")
    '            .gSubColumn("ロットNo")
    '            .gSubColumn("サンプルNo")
    '            .gSubColumn("品種CD")
    '            .gSubColumn("受入数")
    '            .gSubColumn("温度信号")
    '            .gSubColumn("更新プログラム")
    '            .gSubSelect(0)
    '            .gSubSelect(2)
    '            .gSubSelect("DNトラッキング.ロットNo")
    '            .gSubSelect("DNトラッキング.サンプルNo")
    '            .gSubSelect("DNトラッキング.品種CD")
    '            .gSubSelect("トラッキング.受入数")
    '            .gSubSelect("'" & str直前TMPデータ_醗酵 & "'")
    '            .gSubSelect("'" & Name & "'")
    '            .gSubFrom("DNトラッキング")
    '            .gSubWhere("ステータス", strステータス条件, , , , , , , False, )

    '            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
    '                Exit Sub
    '            End If
    '        End With
    '    Catch ex As Exception
    '    Finally
    '    End Try
    'End Sub

    'Private Sub Sub作業履歴登録_ユニットSEQ(ByVal strユニットSEQ As Integer)
    '    '現在の発酵室温度の取得

    '    '履歴データの作成
    '    Try
    '        With New CSql
    '            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_SELECTINSERT
    '            .pテーブル名 = "DL作業履歴"
    '            .gSubColumn("倉庫区分")
    '            .gSubColumn("作業区分")
    '            .gSubColumn("ロットNo")
    '            .gSubColumn("サンプルNo")
    '            .gSubColumn("品種CD")
    '            .gSubColumn("受入数")
    '            .gSubColumn("温度信号")
    '            .gSubColumn("更新プログラム")
    '            .gSubSelect(0)
    '            .gSubSelect(2)
    '            .gSubSelect("MAX(DNトラッキング.ロットNo)")
    '            .gSubSelect("MAX(DNトラッキング.サンプルNo)")
    '            .gSubSelect("MAX(DNトラッキング.品種CD)")
    '            .gSubSelect("SUM(ラッキング.受入数)")
    '            .gSubSelect("'" & str直前TMPデータ_醗酵 & "'")
    '            .gSubSelect("'" & Name & "'")
    '            .gSubFrom("DNトラッキング")
    '            .gSubWhere("ユニットSEQ", strユニットSEQ, , , , , , , False, )
    '            .gSubGroupBy("DNトラッキング.ユニットSEQ")

    '            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得, New System.Data.SqlClient.SqlCommand) Then
    '                Exit Sub
    '            End If
    '        End With
    '    Catch ex As Exception
    '    Finally
    '    End Try
    'End Sub
End Class

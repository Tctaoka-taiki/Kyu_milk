'Imports UsrCtl
Imports System.Data.Common

''' <summary>
''' ユーザコントロール共通クラス
''' </summary>
''' <remarks>DB関連の処理を使用する前にgDpを初期化する必要あり</remarks>
Public Class CUsrctl
    Inherits CUsrctlベース

    ''' <summary>
    ''' データプロバイダ管理オブジェクト
    ''' </summary>
    ''' <remarks>コンボItem設定に使用します</remarks>
    Public Shared gDp As Cdp

    ''コンボボックス処理-------------------------------------------------------------------
    ''' <summary>
    ''' コンボ内容のセット(SQL文による)
    ''' </summary>
    ''' <param name="objCmb"></param>
    ''' <param name="strSQL"></param>
    ''' <param name="Is空白あり"></param>
    ''' <param name="blnItemOnly">表示項目のみセット</param>
    ''' <remarks>SQLの1つ目は表示内容、2つ目は隠し項目</remarks>
    ''' 
    Public Overloads Shared Sub gSubコンボItem設定_改(ByVal objCmb As usrCmb, ByVal strSQL As String, ByVal Is空白あり As Boolean, Optional ByVal blnItemOnly As Boolean = False, Optional ByVal str初期文字列1 As String = "", Optional ByVal str初期pValue1 As String = "", Optional ByVal str初期文字列2 As String = "", Optional ByVal str初期pValue2 As String = "", Optional ByVal 空白FLG As Boolean = False)
        Dim reader As DbDataReader = Nothing

        With objCmb
            Dim 直前のテキスト As String = ""
            Try
                ''直前情報記憶
                直前のテキスト = .Text
                .BeginUpdate()
                ''クリア
                .gSubComboClear()

                ''09/09 morichika
                If 空白FLG = True Then
                    .Items.Add("")
                    .値リスト.Add("")

                End If

                ''09/01/19 morichika 
                If Is空白あり Then
                    If str初期文字列1 = "" Then
                        .Items.Add("")
                        .値リスト.Add("")

                    Else
                        .Items.Add(str初期文字列1)
                        .値リスト.Add(str初期pValue1)
                        .値リスト2.Add(str初期文字列1)
                        .値リスト3.Add("")

                        If str初期文字列2 <> "" Then
                            .Items.Add(str初期文字列2)
                            .値リスト.Add(str初期pValue2)
                            .値リスト2.Add(str初期文字列2)
                            .値リスト3.Add("")

                        End If
                    End If
                End If
                If gDp.gBlnReader(strSQL, reader) Then
                    While reader.Read
                        ''表示
                        .Items.Add(reader(0))
                        ''隠し
                        If blnItemOnly Then
                            .値リスト.Add(CStr(reader(0)))
                        Else
                            .値リスト.Add(CStr(reader(1)))
                        End If

                        If Not CStr(reader(2)) Is Nothing Then
                            .値リスト2.Add(CStr(reader(2)))

                        End If

                        If Not CStr(reader(3)) Is Nothing Then
                            .値リスト3.Add(CStr(reader(3)))

                        End If

                    End While
                End If
                .EndUpdate()

            Finally
                gDp.gSubReaderClose(reader)
                objCmb.gSubSetItemIndex(直前のテキスト)
            End Try
        End With
    End Sub

    Public Overloads Shared Sub gSubコンボItem設定(ByVal objCmb As usrCmb, ByVal strSQL As String, ByVal Is空白あり As Boolean, Optional ByVal blnItemOnly As Boolean = False, Optional ByVal str初期文字列 As String = "")
        Dim reader As DbDataReader = Nothing

        With objCmb
            Dim 直前のテキスト As String = ""
            Try
                ''直前情報記憶
                直前のテキスト = .Text
                .BeginUpdate()
                ''クリア
                .gSubComboClear()

                ''09/01/19 morichika 
                If Is空白あり Then
                    If str初期文字列 = "" Then
                        .Items.Add("")
                        .値リスト.Add("")

                    Else
                        .Items.Add(str初期文字列)
                        .値リスト.Add("")

                    End If
                End If
                If gDp.gBlnReader(strSQL, reader) Then
                    While reader.Read
                        ''表示
                        .Items.Add(reader(0))
                        ''隠し
                        If blnItemOnly Then
                            .値リスト.Add(CStr(reader(0)))
                        Else
                            .値リスト.Add(CStr(reader(1)))
                        End If
                    End While
                End If
                .EndUpdate()

            Finally
                gDp.gSubReaderClose(reader)
                objCmb.gSubSetItemIndex(直前のテキスト)
            End Try
        End With
    End Sub

    ''コンボボックス処理-------------------------------------------------------------------
    ''' <summary>
    ''' コンボ内容のセット(SQL文による)
    ''' </summary>
    ''' <param name="objCmb"></param>
    ''' <param name="strSQL"></param>
    ''' <param name="Is空白あり"></param>
    ''' <param name="blnItemOnly">表示項目のみセット</param>
    ''' <remarks>SQLの1つ目は表示内容、2つ目は隠し項目</remarks>
    Public Overloads Shared Sub gSubコンボItem設定カスタム(ByVal objCmb As usrCmb, ByVal strSQL As String, ByVal Is空白あり As Boolean, Optional ByVal blnItemOnly As Boolean = False)
        Dim reader As DbDataReader = Nothing

        With objCmb
            Dim 直前のテキスト As String = ""
            Try
                ''直前情報記憶
                直前のテキスト = .Text
                .BeginUpdate()
                ''クリア
                .gSubComboClear()

                ''09/01/19 morichika 
                If Is空白あり Then
                    .Items.Add("")
                    .値リスト.Add("")

                End If
                If gDp.gBlnReader(strSQL, reader) Then
                    While reader.Read
                        ''表示
                        .Items.Add(reader(0))
                        ''隠し
                        If blnItemOnly Then
                            .値リスト.Add(CStr(reader(0)))
                        Else
                            .値リスト.Add(CUtil.バイト配列ToHexString(CType(reader(1), Byte())))
                        End If
                    End While
                End If
                .EndUpdate()

            Finally
                gDp.gSubReaderClose(reader)
                objCmb.gSubSetItemIndex(直前のテキスト)
            End Try
        End With
    End Sub

    ''' <summary>
    ''' コンボ内容のセット
    ''' </summary>
    ''' <param name="objCmb"></param>
    ''' <param name="str名称セット">順番にカンマ区切りで指定</param>
    ''' <param name="str値セット">順番にカンマ区切りで指定(値の指定をしないときは表示項目のみのセットになる</param>
    ''' <param name="blnSpace"></param>
    ''' <param name="blnItemOnly"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub gSubコンボItem設定(ByVal objCmb As usrCmb, ByVal str名称セット As String, ByVal str値セット As String, ByVal blnSpace As Boolean, ByVal blnItemOnly As Boolean)
        Dim strBuff名称() As String
        Dim strBuff値() As String

        With objCmb
            ''直前情報記憶
            .BeginUpdate()
            ''クリア
            .gSubComboClear()
            ''空白
            If blnSpace = True Then
                .Items.Add("")
                .値リスト.Add("")
            End If

            ''表示
            strBuff名称 = Split(str名称セット, ",")
            For i As Integer = LBound(strBuff名称) To UBound(strBuff名称)
                .Items.Add(strBuff名称(i))
            Next

            ''隠し
            If blnItemOnly = False And str値セット <> "" Then
                strBuff値 = Split(str値セット, ",")
                For i As Integer = LBound(strBuff値) To UBound(strBuff値)
                    ''表示
                    .値リスト.Add(strBuff値(i))
                Next
            Else
                For i As Integer = LBound(strBuff名称) To UBound(strBuff名称)
                    .値リスト.Add(strBuff名称(i))
                Next
            End If

            .EndUpdate()
        End With
    End Sub

    Public Shared Function 標準追加更新処理(ByVal sql As String, Optional ByVal コマンド As System.Data.Common.DbCommand = Nothing) As Boolean
        If コマンド Is Nothing Then
            コマンド = CUsrctl.gDp.gdb接続.CreateCommand
        End If
        If CUsrctl.gDp.gBlnExecute(sql, コマンド) Then
            Select Case CUsrctl.gDp.pInt実行レコード件数
                Case 0
                    CMsg.gMsg_注意("他のユーザにより更新されました。最新の情報を取得し直してください。")
                    Exit Function
                Case 1
                    '正常
                Case Else

                    If Left(sql, 17) = "INSERT INTO DM管理者" Then  '管理者追加時にはトリガで複数行作成されるので無視する
                        '正常
                    ElseIf Left(sql, 17) = "INSERT INTO DM園児" Then    '園児追加時にはトリガで複数行作成されるので無視する
                        '正常
                    Else
                        CMsg.gMsg_注意("更新件数異常 " & CUsrctl.gDp.pInt実行レコード件数)
                        Exit Function

                    End If

            End Select
        End If

        Return True
    End Function

    Public Shared Function 標準追加更新処理_複数更新可(ByVal sql As String, Optional ByVal コマンド As System.Data.Common.DbCommand = Nothing) As Boolean
        If コマンド Is Nothing Then
            コマンド = CUsrctl.gDp.gdb接続.CreateCommand
        End If
        If CUsrctl.gDp.gBlnExecute(sql, コマンド) Then
            Select Case CUsrctl.gDp.pInt実行レコード件数
                Case 0
                    CMsg.gMsg_注意("他のユーザにより更新されました。最新の情報を取得し直してください。")
                    Exit Function
                Case Else
                    '正常
            End Select
        End If

        Return True
    End Function

    Public Shared Function 標準削除処理(ByVal sql As String, Optional ByVal コマンド As System.Data.Common.DbCommand = Nothing, Optional ByVal bln処理チェック As Boolean = True) As Boolean
        If コマンド Is Nothing Then
            コマンド = CUsrctl.gDp.gdb接続.CreateCommand
        End If

        If CUsrctl.gDp.gBlnExecute(sql, コマンド) Then
            If bln処理チェック = True Then
                Select Case CUsrctl.gDp.pInt実行レコード件数
                    Case 0
                        CMsg.gMsg_注意("他のユーザにより更新されました。最新の情報を取得し直してください。")
                        Exit Function
                    Case 1
                        '正常
                    Case Else

                        If Left(sql, 17) = "DELETE FROM DM管理者" Then  '管理者削除時にはトリガで複数行作成されるので無視する
                            '正常
                        ElseIf Left(sql, 16) = "DELETE FROM DM園児" Then    '園児削除時にはトリガで複数行作成されるので無視する
                            '正常
                        Else
                            CMsg.gMsg_注意("削除件数異常 " & CUsrctl.gDp.pInt実行レコード件数)
                            Exit Function
                        End If
                End Select
            Else
            End If
        End If
        Return True
    End Function

    Public Shared Function 標準削除処理_複数削除可(ByVal sql As String, Optional ByVal コマンド As System.Data.Common.DbCommand = Nothing, Optional ByVal bln処理チェック As Boolean = True) As Boolean
        If コマンド Is Nothing Then
            コマンド = CUsrctl.gDp.gdb接続.CreateCommand
        End If

        If CUsrctl.gDp.gBlnExecute(sql, コマンド) Then
            If bln処理チェック = True Then
                'Select Case CUsrctl.gDp.pInt実行レコード件数
                '    Case 0
                '        CMsg.gMsg_注意("他のユーザにより更新されました。最新の情報を取得し直してください。")
                '        Exit Function
                '    Case Else

                'End Select

            Else

            End If
        End If
        Return True
    End Function

    Public Shared Function gMsg_更新処理確認(ByVal 処理区分 As enm処理区分) As System.Windows.Forms.DialogResult
        Dim メッセージ As String
        Select Case 処理区分
            Case enm処理区分.追加
                メッセージ = MSG_登録確認

            Case enm処理区分.変更
                メッセージ = MSG_登録確認

            Case enm処理区分.削除
                メッセージ = MSG_選択データ削除確認

            Case Else
                メッセージ = "処理区分不明"
        End Select

        Return MessageBox.Show(メッセージ, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function
End Class


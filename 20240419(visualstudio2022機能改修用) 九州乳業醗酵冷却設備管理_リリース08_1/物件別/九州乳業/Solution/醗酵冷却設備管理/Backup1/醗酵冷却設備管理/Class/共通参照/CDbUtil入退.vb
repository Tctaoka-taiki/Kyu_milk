Imports System.Data.Common

Public Class CDbUtil入退
    ''' <summary>
    ''' 入退ステータス
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum E入退ステータス
        正常 = 0
        ID異常 = 1
        不許可ID = 2
        タイムアウト = 3
        割り込み通過 = 4
        不正通過 = 5
        入場中に入場 = 6
        退場中に退場 = 7
    End Enum

    Public Shared Sub Cmbステータスコンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With cmb
            .Items.Clear()
            If blnSpace Then
                .Items.Add("")
            End If
            .Items.Add("正常")
            '.Items.Add("ID異常")
            .Items.Add("不許可ID")
            '.Items.Add("タイムアウト")
            '.Items.Add("割り込み通過")
            '.Items.Add("不正通過")
            '.Items.Add("入場中に入場")
            '.Items.Add("退場中に退場")
            .Items.Add("紛失中ｶｰﾄﾞ使用")
            .Items.Add("不可ｶｰﾄﾞ使用")
            .Items.Add("禁止ｶｰﾄﾞ使用")
            .Items.Add("ｶｰﾄﾞ有効期限切れ")
            .Items.Add("許可パターン有効期限切れ")
            .Items.Add("許可パターン割当なし")

            If blnSpace Then
                .値リスト.Add("")
            End If
            .値リスト.Add("0")
            '.値リスト.Add("1")
            .値リスト.Add("2")
            '.値リスト.Add("3")
            '.値リスト.Add("4")
            '.値リスト.Add("5")
            '.値リスト.Add("6")
            '.値リスト.Add("7")
            .値リスト.Add("9")
            .値リスト.Add("10")
            .値リスト.Add("11")
            .値リスト.Add("12")
            .値リスト.Add("13")
            .値リスト.Add("14")
        End With
    End Sub

    Public Shared Sub Cmb入退場コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With cmb
            .Items.Clear()
            If blnSpace Then
                .Items.Add("")
            End If
            .Items.Add("入場")
            .Items.Add("退場")

            If blnSpace Then
                .値リスト.Add("")     '未登録
            End If
            '.値リスト.Add("0")
            '.値リスト.Add("1")
            .値リスト.Add("1")
            .値リスト.Add("0")

        End With
    End Sub

    Public Shared Sub Cmb性別コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With cmb
            .Items.Clear()
            If blnSpace Then
                .Items.Add("")
            End If
            .Items.Add("男子")
            .Items.Add("女子")

            If blnSpace Then
                .値リスト.Add("")     '未登録
            End If
            .値リスト.Add("1")     '男子
            .値リスト.Add("0")     '女子

        End With
    End Sub

    Public Shared Sub Cmbクラブ情報コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True, Optional ByVal Is親ID指定必須 As Boolean = True, Optional ByVal なしFLG As Boolean = False)
        With New CSql
            .gSubSelect("名称")
            .gSubSelect("クラブID")
            .gSubFrom("DMクラブ")
            .gSubOrderBy("名称")
            If なしFLG = True Then
                Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace, , "未登録")
            Else
                Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)

            End If
        End With
    End Sub

    Public Shared Sub Cmb送迎バス情報コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True, Optional ByVal 園ID As String = "", Optional ByVal Is親ID指定必須 As Boolean = True, Optional ByVal お迎えFLG As Boolean = True, Optional ByVal 休園FLG As Boolean = False, Optional ByVal 空白FLG As Boolean = False)
        With New CSql
            .gSubSelect("DM車両.名称 + '【' + DM時間帯.名称 + '】'")
            .gSubSelect("DMバス.バスID")
            .gSubSelect("DM車両.名称")
            .gSubSelect("DM時間帯.名称")
            .gSubFrom("DMバス")
            .gSubFrom("DM時間帯")
            .gSubFrom("DM車両")
            .gSubWhere("DM車両.園ID", 園ID, , , , , , , False)
            .gSubWhere("DMバス.時間帯ID = DM時間帯.時間帯ID")
            .gSubWhere("DMバス.車両ID = DM車両.車両ID")
            .gSubOrderBy("DM車両.名称")
            .gSubOrderBy("DM時間帯.名称")
            If お迎えFLG = True Then
                If 休園FLG = False Then
                    Call CUsrctl.gSubコンボItem設定_改(cmb, .gSQL文の取得, blnSpace, , "お迎え", "")

                Else
                    If 空白FLG = False Then
                        Call CUsrctl.gSubコンボItem設定_改(cmb, .gSQL文の取得, blnSpace, , "休園日", "", "お迎え", "")
                    Else
                        '予定表変更用
                        Call CUsrctl.gSubコンボItem設定_改(cmb, .gSQL文の取得, blnSpace, , "お休み", "", "お迎え", "", True)

                    End If
                End If
            Else
                Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
            End If
        End With
    End Sub

    Public Shared Sub Cmb出欠コンボ初期化(ByVal cmb As usrCmb)
        With cmb
            .Items.Clear()
            .Items.Add("出席")
            .Items.Add("欠席")
            .Items.Add("早退")

            .値リスト.Add("0")     '出席
            .値リスト.Add("1")     '欠席
            .値リスト.Add("2")     '早退

        End With
    End Sub

    Public Shared Sub Cmbカード割当コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With cmb
            .Items.Clear()
            If blnSpace Then
                .Items.Add("")
            End If
            .Items.Add("なし")
            .Items.Add("あり")

            If blnSpace Then
                .値リスト.Add("")     '未登録
            End If
            .値リスト.Add("0")     'なし
            .値リスト.Add("1")     'あり
        End With
    End Sub

    Public Shared Sub Cmb割当状態コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With cmb
            .Items.Clear()
            If blnSpace Then
                .Items.Add("")
            End If
            .Items.Add("園児割当タグ")
            .Items.Add("保護者割当タグ")
            '.Items.Add("未割当タグ")

            If blnSpace Then
                .値リスト.Add("")
            End If
            .値リスト.Add("0")
            .値リスト.Add("1")
            '.値リスト.Add("2")

            If Not blnSpace Then
                .Text = "園児割当タグ"
            End If
        End With
    End Sub

    Public Shared Sub Cmbカード種別コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With New CSql
            .gSubSelect("名称")
            .gSubSelect("タグ用途ID")
            .gSubFrom("DPタグ用途")
            .gSubWhere("有効フラグ", "1", , , , , , , False)
            .gSubOrderBy("表示優先順")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Sub Cmbカード状態コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With New CSql
            .gSubSelect("名称")
            .gSubSelect("タグ状態ID")
            .gSubFrom("DPタグ状態")
            .gSubWhere("有効フラグ", "1", , , , , , , False)
            .gSubOrderBy("表示優先順")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    ''' <summary>
    ''' 親となる企業区分IDが指定されていない場合、候補を表示しない
    ''' </summary>
    ''' <param name="cmb"></param>
    ''' <param name="blnSpace"></param>
    ''' <param name="企業区分ID"></param>
    ''' <remarks></remarks>
    Public Shared Sub Cmb企業名コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True, Optional ByVal 企業区分ID As String = "", Optional ByVal Is親ID指定必須 As Boolean = True)
        With New CSql
            .gSubSelect("名称漢字")
            .gSubSelect("企業ID")
            .gSubFrom("DM企業")
            'If 企業区分ID <> "" Then
            '    .gSubWhere("企業区分ID", 企業区分ID, , , , , , , False)
            'Else
            '    If Is親ID指定必須 Then
            '        .gSubWhere("1=0")
            '    End If
            'End If

            .gSubOrderBy("企業ID")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Sub Cmb部署名コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True, Optional ByVal 企業ID As String = "")
        With New CSql
            .gSubSelect("名称漢字")
            .gSubSelect("部署ID")
            .gSubFrom("DM部署")
            If 企業ID <> "" Then
                .gSubWhere("企業ID", 企業ID, , , , , , , False)
            End If
            .gSubOrderBy("名称漢字")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Sub Cmb事業所名コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True, Optional ByVal 企業ID As String = "")
        With New CSql
            .gSubSelect("名称漢字")
            .gSubSelect("事業所ID")
            .gSubFrom("DM事業所")
            If 企業ID <> "" Then
                .gSubWhere("企業ID", 企業ID, , , , , , , False)
            Else
                .gSubWhere("1=0")
            End If
            .gSubOrderBy("事業所ID")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Sub Cmb許可パターンコンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With New CSql
            .gSubSelect("名称漢字")
            .gSubSelect("許可パターンID")
            .gSubFrom("DM許可パターン")
            .gSubOrderBy("許可パターンID")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Sub Cmb登降区分コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With cmb
            .Items.Clear()
            If blnSpace Then
                .Items.Add("")
            End If
            .Items.Add("登園")
            .Items.Add("降園")

            If blnSpace Then
                .値リスト.Add("")
            End If
            .値リスト.Add("0")
            .値リスト.Add("1")
        End With
    End Sub

    Public Shared Sub Cmb認証区分コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With cmb
            .Items.Clear()
            If blnSpace Then
                .Items.Add("")
            End If
            .Items.Add("HT認証")
            .Items.Add("端末認証")
            .Items.Add("PC登録")

            If blnSpace Then
                .値リスト.Add("")
            End If
            .値リスト.Add("0")
            .値リスト.Add("1")
            .値リスト.Add("2")
        End With
    End Sub

    Public Shared Function DMタグにある(ByVal o As Byte()) As Boolean
        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DMタグ")
            .gSubWhere("タグID = @WHEREタグID")

            Dim strSQL As String = .gSQL文の取得
            Dim コマンド As DbCommand = CUsrctl.gDp.gdb接続.CreateCommand()
            CUsrctl.gDp.AddWithValue(コマンド, "WHEREタグID", o)
            Return CUsrctl.gDp.ExecuteScalarによる件数取得(コマンド, strSQL) > 0
        End With
    End Function

    Public Shared Function DRユーザタグ割当にある(ByVal o As Byte()) As Boolean
        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DRユーザタグ割当")
            .gSubWhere("タグID = @WHEREタグID")

            Dim strSQL As String = .gSQL文の取得
            Dim コマンド As DbCommand = CUsrctl.gDp.gdb接続.CreateCommand()
            CUsrctl.gDp.AddWithValue(コマンド, "WHEREタグID", o)
            Return CUsrctl.gDp.ExecuteScalarによる件数取得(コマンド, strSQL) > 0
        End With
    End Function

    Public Shared Function Is園児IDが存在する(ByVal 園児ID As String, Optional ByVal 除外するユーザID As String = "") As Boolean
        If 除外するユーザID Is Nothing Then
            除外するユーザID = ""
        End If

        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM園児")
            .gSubWhere("園児ID", 園児ID)
            If 除外するユーザID <> "" Then
                .gSubWhere("ユーザID", 除外するユーザID, "<>")
            End If

            Dim strSQL As String = .gSQL文の取得
            Dim objCom As DbCommand = CUsrctl.gDp.gdb接続.CreateCommand()
            Return CUsrctl.gDp.ExecuteScalarによる件数取得(objCom, strSQL) > 0
        End With
    End Function

    Public Shared Function Isコードが存在する(ByVal テーブル名 As String, ByVal コードの列名 As String, ByVal IDの列名 As String, ByVal コード As String, Optional ByVal 除外するID As String = "") As Boolean
        If 除外するID Is Nothing Then
            除外するID = ""
        End If

        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom(テーブル名)
            .gSubWhere(コードの列名, コード)
            If 除外するID <> "" Then
                .gSubWhere(IDの列名, 除外するID, "<>")
            End If

            Dim strSQL As String = .gSQL文の取得
            Dim objCom As DbCommand = CUsrctl.gDp.gdb接続.CreateCommand()
            Return CUsrctl.gDp.ExecuteScalarによる件数取得(objCom, strSQL) > 0
        End With
    End Function

    Public Shared Function Is企業区分コードが存在する(ByVal 企業区分コード As String, Optional ByVal 除外する企業区分ID As String = "") As Boolean
        Return Isコードが存在する("DP企業区分", "企業区分コード", "企業区分ID", 企業区分コード, 除外する企業区分ID)
    End Function

    Public Shared Sub Cmb入場ゲートコンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With New CSql
            .gSubSelect("名称漢字")
            .gSubSelect("ゲートID")
            .gSubFrom("DMゲート")
            .gSubWhere("入出区分", CInt(enm入出区分.入口).ToString, , , , , , , False)
            .gSubOrderBy("ゲートID")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Sub Cmb入退場ゲートコンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With New CSql
            .gSubSelect("名称漢字")
            .gSubSelect("ゲートID")
            .gSubFrom("DMゲート")
            .gSubOrderBy("ゲートID")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Sub Cmb管理者コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With New CSql
            .gSubSelect("名称")
            .gSubSelect("管理者ID")
            .gSubFrom("DM管理者")
            .gSubOrderBy("管理者ID")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Sub Cmb機能コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With New CSql
            .gSubSelect("名称")
            .gSubSelect("機能ID")
            .gSubFrom("DM機能")
            .gSubOrderBy("表示優先順")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Sub Cmb権限区分コンボ初期化(ByVal cmb As usrCmb, Optional ByVal blnSpace As Boolean = True)
        With New CSql
            .gSubSelect("名称")
            .gSubSelect("権限ID")
            .gSubFrom("DM権限")
            .gSubOrderBy("表示優先順")
            Call CUsrctl.gSubコンボItem設定(cmb, .gSQL文の取得, blnSpace)
        End With
    End Sub

    Public Shared Function 企業デフォルト許可パターンID取得(ByVal 企業ID As String) As String
        If 企業ID <> "" Then
            With New CSql
                .gSubSelect("許可パターンID")
                .gSubFrom("DM企業")
                .gSubWhere("企業ID", 企業ID, , , , , , , False)
                Return CUsrctl.gDp.gObjReadScalar(.gSQL文の取得).ToString
            End With
        Else
            Return ""
        End If
    End Function

    Public Shared Function 部署デフォルト許可パターンID取得(ByVal 部署ID As String) As String
        If 部署ID <> "" Then
            With New CSql
                .gSubSelect("許可パターンID")
                .gSubFrom("DM部署")
                .gSubWhere("部署ID", 部署ID, , , , , , , False)
                Return CUsrctl.gDp.gObjReadScalar(.gSQL文の取得).ToString
            End With
        Else
            Return ""
        End If
    End Function

    Public Shared Function Is管理者コードが存在する(ByVal 管理者コード As String) As Boolean
        If 管理者コード Is Nothing Then
            管理者コード = ""
        End If

        With New CSql
            .gSubSelect("COUNT(*)")
            .gSubFrom("DM管理者")
            .gSubWhere("管理者コード", 管理者コード)

            Dim strSQL As String = .gSQL文の取得
            Dim objCom As DbCommand = CUsrctl.gDp.gdb接続.CreateCommand()

            Return CUsrctl.gDp.ExecuteScalarによる件数取得(objCom, strSQL) > 0
        End With
    End Function

    Public Shared Function ログイン履歴追加(ByVal ログイン管理者ID As String, ByVal ログイン管理者名 As String, ByVal bln区分 As Boolean, ByVal 更新プログラム As String) As Boolean
        With New CSql
            .pSQL取得タイプ = CSql.SQL_TYPE.SQL_INSERT
            .pテーブル名 = "DRログイン履歴"
            .gSubColumnValue("管理者ID", ログイン管理者ID, False)
            .gSubColumnValue("名称", ログイン管理者名, True)
            .gSubColumnValue("区分", bln区分.ToString, True)
            .gSubColumnValue("更新プログラム", 更新プログラム, True)

            If Not CUsrctl.gDp.gBlnExecute(.gSQL文の取得) Then
                Exit Function
            End If
            Select Case CUsrctl.gDp.pInt実行レコード件数
                Case 1
                    '正常
                Case Else
                    Exit Function
            End Select
        End With
        Return True
    End Function
End Class

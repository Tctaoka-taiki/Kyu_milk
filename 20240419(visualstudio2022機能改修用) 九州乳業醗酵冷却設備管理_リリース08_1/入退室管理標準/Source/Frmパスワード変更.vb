
Public Class Frmパスワード変更
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
    Private Sub Frm0141登録者情報メンテナンス_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CUsrctl.gSubコントロールの初期化(Me)
    End Sub

    Private Sub btn検索_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gRSubF再表示()
    End Sub

    Private Sub btnクリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnクリア.Click
        CUsrctl.gSubコントロールの初期化(Me)
    End Sub

    Private Sub btnメニュー_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnメニュー.Click
        gMdiMain.gSubMDI子フォームを開く(C画面制御入退室管理.マスタメンテメニュー)
    End Sub

    Private Sub btn変更_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn変更.Click
        Try

            ''処理中設定
            Call Me.gMdiMain.gSub処理中設定(Me, True, M定数.MSG_実行中)

        Dim 暗号化された変更前パスワード As String = CUtil.設定関連.設定文字列読込("app.パスワード")
        Dim 変更前パスワード As String = Crypto.Key.Decrypt(C画面制御.パスフレーズ, 暗号化された変更前パスワード)
        If Txt変更前パスワード.Text <> 変更前パスワード Then
            CMsg.gMsg_注意("変更前のパスワードが間違っています。")
            Txt変更前パスワード.Focus()
            Exit Sub
        End If

        If CUtil.設定関連.設定文字列書込("app.パスワード", Crypto.Key.Encrypt(C画面制御.パスフレーズ, Txt変更後パスワード.Text)) Then
            CMsg.gMsg_情報("パスワードを変更しました。変更後のパスワードは再起動後に有効になります。")
               '***************************
                '08/05/08 morichika
            gMdiMain.gSubMDI子フォームを開く(C画面制御入退室管理.メインメニュー)
                If CMsg.gMsg_YesNo("アプリケーションを終了してもよろしいですか？") = Windows.Forms.DialogResult.Yes Then
                    End
                Else

                End If

            End If

        Catch ex As Exception

        Finally
            ''処理中解除
            Me.gMdiMain.gSub処理中設定(Me, False, "")

        End Try
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################

End Class

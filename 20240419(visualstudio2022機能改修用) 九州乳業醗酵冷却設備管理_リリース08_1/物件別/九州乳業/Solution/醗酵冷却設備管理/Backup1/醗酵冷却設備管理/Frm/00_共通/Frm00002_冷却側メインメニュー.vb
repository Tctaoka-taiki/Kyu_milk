Public Class Frm00002_冷却側メインメニュー

  

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

    Private Sub Frm9999メインメニュー_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If CMdiMain.mInt醗酵冷却モード = 0 Then
            CMdiMain.メニュー切替ToolStripMenuItem.Enabled = True
        Else
            CMdiMain.メニュー切替ToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub Frm00002_冷却側メインメニュー_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        CMdiMain.メニュー切替ToolStripMenuItem.Enabled = False
    End Sub

    Private Sub Frm00001_メインメニュー_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            '
            If txt処理No.Focused = True Then
                '入力されているデータを元に画面遷移
                Select Case txt処理No.Text
                    Case "1"
                        Mnu冷却完了出庫設定()

                    Case "2"
                        Mnu棚指定出庫設定()

                    Case "11"
                        Mnu棚問合メンテナンス()

                    Case "12"
                        Mnu在庫問合せ()

                    Case "13"
                        Mnu冷却空棚問合せ()

                    Case "21"
                        Mnu設備状況()

                    Case "99"
                        CMdiMain.Close()

                End Select
            End If
        End If

    End Sub

    Private Sub Mnu冷却完了出庫設定()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.冷却完了出庫設定)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu棚指定出庫設定()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.冷却棚指定出庫設定)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu棚問合メンテナンス()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.冷却棚問合せメンテナンス)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu在庫問合せ()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.冷却在庫問合せ)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu冷却空棚問合せ()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.冷却空棚問合せ)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu設備状況()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.冷却設備状況)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu電源ＯＦＦ()

    End Sub
End Class

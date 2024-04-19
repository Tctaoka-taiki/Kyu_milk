Public Class Frm00001_醗酵側メインメニュー


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
        CMdiMain.メニュー切替ToolStripMenuItem.Enabled = True
    End Sub

    Private Sub Frm00001_醗酵側メインメニュー_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        CMdiMain.メニュー切替ToolStripMenuItem.Enabled = False
    End Sub

    Private Sub Frm00001_メインメニュー_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            '
            If txt処理No.Focused = True Then
                '入力されているデータを元に画面遷移
                Select Case txt処理No.Text
                    Case "1"
                        Mnu入庫設定_ハード1()
                    Case "2"
                        Mnu入庫設定_プレーン1()
                    Case "3"
                        Mnu入庫設定_ハード2()
                    Case "4"
                        Mnu醗酵完了出庫設定()
                    Case "5"
                        Mnu醗酵棚指定出庫設定()
                    Case "11"
                        Mnuマスター設定()
                    Case "12"
                        Mnu醗酵入庫棚順設定()
                    Case "13"
                        Mnu醗酵棚問合せメンテナンス()
                    Case "14"
                        Mnu醗酵在庫問合せ()
                    Case "15"
                        Mnu醗酵空棚問合せ()
                    Case "21"
                        Mnu発酵設備状況()
                    Case "22"
                        Mnu生産実績()
                    Case "23"
                        Mnu温度実績()
                    Case "24"
                        Mnu作業履歴()
                    Case "41"
                        Mnuジャーナル照会()

                    Case "99"
                        CMdiMain.Close()
                End Select
            End If
        End If

    End Sub

    Private Sub Mnu入庫設定_ハード1()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.入庫設定, , 0)


        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu入庫設定_プレーン1()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.入庫設定, , 1)


        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu入庫設定_ハード2()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.入庫設定, , 2)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu醗酵完了出庫設定()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵完了出庫設定)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu醗酵入庫棚順設定()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.入庫棚順設定設定)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu醗酵棚指定出庫設定()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵棚指定出庫設定)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnuマスター設定()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.マスター設定)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu醗酵棚問合せメンテナンス()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵棚問合せメンテナンス)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu醗酵在庫問合せ()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵在庫問合せ)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu醗酵空棚問合せ()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.醗酵空棚問合せ)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu発酵設備状況()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.発酵設備状況)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu生産実績()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.生産実績)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu温度実績()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.温度実績)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnu作業履歴()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.作業履歴)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub

    Private Sub Mnuジャーナル照会()
        Try
            CMdiMain.gSubMDI子フォームを開く(C画面制御オーダー別.ジャーナル照会)

        Catch ex As Exception
            Call CMdiMain.mSubエラー表示(ex)
        End Try
    End Sub
End Class

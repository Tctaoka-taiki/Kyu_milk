Imports System.Data.Common

Public Class Frm0000ログイン画面
    '#####################################################################################
    '型
    '#####################################################################################

    '#####################################################################################
    'メンバ変数
    '#####################################################################################
    Dim mStrパスワード As String = ""
    '#####################################################################################
    'プロパティー
    '#####################################################################################

    '#####################################################################################
    'イベント
    '#####################################################################################

    '#####################################################################################
    'イベントハンドラ
    '#####################################################################################
    Private Sub Frmログイン画面_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''Me.PictureBox1.Image = Image.FromFile(mstr画像ファイル参照先 & "logo_brand.gif")
        'TxtCODE.Enabled = False
        ''Me.MinimizeBox = True
        ''Me.MaximizeBox = True
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        'Me.ShowInTaskbar = False
        Me.ControlBox = False
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub Usr終了_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Usr終了.Click
        If CMsg.gMsg_YesNo("アプリケーションを終了してもよろしいですか？") = Windows.Forms.DialogResult.Yes Then
            End
        End If
        'Throw New Exception("test")
    End Sub

    Private Sub TxtCODE_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCODE.Leave
        '入力コードの確認
        管理者コード入力時の処理(Me.TxtCODE.Text)
    End Sub

    '#####################################################################################
    'プロシージャ
    '#####################################################################################
    Private Sub 管理者コード入力時の処理(ByVal 管理者コード As String)
        '初期化
        CMdiMain.gStrログイン管理者ID = ""
        Me.LblNAME.Text = ""
        CMdiMain.gStrログイン管理者名 = ""
        mStrパスワード = ""

        If 管理者コード = "" Then
            Exit Sub
        End If

        Dim reader As DbDataReader = Nothing
        Try
            With New CSql
                .gSubSelect("管理者ID")
                .gSubSelect("名称")
                .gSubSelect("パスワード")
                .gSubFrom("DM管理者")
                .gSubWhere("管理者コード", 管理者コード)

                Dim strSQL As String = .gSQL文の取得

                CUsrctl.gDp.gBlnReader(strSQL, reader)


                While reader.Read
                    CMdiMain.gStrログイン管理者ID = reader.GetValue(0).ToString
                    Me.LblNAME.Text = reader.GetValue(1).ToString
                    CMdiMain.gStrログイン管理者名 = reader.GetValue(1).ToString
                    mStrパスワード = reader.GetValue(2).ToString

                End While

            End With

        Catch ex As Exception

        Finally

            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub
End Class

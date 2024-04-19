''' <summary>
''' メッセージボックスユーティリティクラス
''' </summary>
''' <remarks></remarks>
Public Class CMsg
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
    Private Sub New()
    End Sub

    ''メッセージボックス
    Public Shared Sub gMsg_注意(ByVal strMsg As String)
        Call MessageBox.Show(strMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    ''' <summary>
    ''' エラー
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <remarks></remarks>
    Public Shared Sub gMsg_エラー(ByVal strMsg As String)
        Call MessageBox.Show(strMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' 情報
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <remarks></remarks>
    Public Shared Sub gMsg_情報(ByVal strMsg As String)
        Call MessageBox.Show(strMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' 確認
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function gMsg_YesNo(ByVal strMsg As String, Optional ByVal 見出部 As String = "") As System.Windows.Forms.DialogResult
        Return MessageBox.Show(strMsg, 見出部, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    ''' <summary>
    ''' 確認キャンセル
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function gMsg_YesNoCancel(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        Return MessageBox.Show(strMsg, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
    End Function

    ''' <summary>
    ''' リトライ
    ''' </summary>
    ''' <param name="strMsg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function gMsg_RetryCancel(ByVal strMsg As String) As System.Windows.Forms.DialogResult
        Return MessageBox.Show(strMsg, "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    Public Shared Sub gMsg_削除完了メッセージ()
        gMsg_情報(M定数.MSG_削除結果)
    End Sub
    Public Shared Sub gMsg_登録完了メッセージ()
        gMsg_情報(M定数.MSG_登録結果)
    End Sub
End Class

Module MFile

#Region "ファイル名取得"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：ファイル名取得
    ' 引　数　：strFilter       フィルタ設定文字列
    '           strFileName     ファイル名デフォルト値
    ' 戻り値　：blnRslt         処理結果
    '           strFileName     ファイル名
    ' 機能説明：ファイル名指定ダイアログを表示し、ファイル名を返す。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Function gBlnファイル名取得(ByRef strFileName As String, ByVal strDirectory As String, ByVal strFilter As String) As Boolean
        Dim objFileDialog As New OpenFileDialog

        With objFileDialog
            ''ファイルフィルタ設定
            .Filter = strFilter
            ''初期ファイル名設定
            .FileName = strFileName
            ''初期ディレクトリ設定
            If strDirectory.Length = 0 Then strDirectory = Application.StartupPath
            .InitialDirectory = strDirectory

            ''ファイル指定ダイアログ表示
            If .ShowDialog() = DialogResult.OK Then
                Call Application.DoEvents()

                ''指定ファイル名格納
                strFileName = .FileName

                Return True
            End If
        End With
        objFileDialog = Nothing

    End Function


#Region "ファイル名取得ダイアログ"
    '---------------------------------------------------------------------------
    ' @(f)
    ' 機　能　：ファイル名取得
    ' 引　数　：strFilter       フィルタ設定文字列
    '           strFileName     ファイル名デフォルト値
    ' 戻り値　：blnRslt         処理結果
    '           strFileName     ファイル名
    ' 機能説明：ファイル名指定ダイアログを表示し、ファイル名を返す。
    ' 備　考　：
    '---------------------------------------------------------------------------
#End Region
    Public Function gBlnOpenFileDialog(ByRef strFileName As String, ByVal strDirectory As String, ByVal strFilter As String) As Boolean
        Dim objFileDialog As New OpenFileDialog

        With objFileDialog
            ''ファイルフィルタ設定
            .Filter = strFilter
            ''初期ファイル名設定
            .FileName = strFileName
            ''初期ディレクトリ設定
            If strDirectory.Length = 0 Then strDirectory = Application.StartupPath
            .InitialDirectory = strDirectory

            ''ファイル指定ダイアログ表示
            If .ShowDialog() = DialogResult.OK Then

                ''指定ファイル名格納
                strFileName = .FileName

                Return True
            End If
        End With
        objFileDialog = Nothing

    End Function

    Public Function gBlnSaveFileDialog(ByRef strFileName As String, ByVal strDirectory As String, ByVal strFilter As String) As Boolean
        Dim objFileDialog As New SaveFileDialog

        With objFileDialog
            ''ファイルフィルタ設定
            .Filter = strFilter
            ''初期ファイル名設定
            .FileName = strFileName
            ''初期ディレクトリ設定
            If strDirectory.Length = 0 Then strDirectory = Application.StartupPath
            .InitialDirectory = strDirectory

            ''ファイル指定ダイアログ表示
            If .ShowDialog() = DialogResult.OK Then

                ''指定ファイル名格納
                strFileName = .FileName

                Return True
            End If
        End With
        objFileDialog = Nothing

    End Function

End Module


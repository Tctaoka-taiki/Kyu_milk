Public Interface IUserControl
    Function 入力チェック(ByVal Isエラーフォーカス As Boolean) As Cチェック結果
    Property エラー表示用項目名() As String
    'Property Name() As String
    Property Isクリア() As Boolean
    Sub クリア()

End Interface

''' <summary>
''' ENTERキー制御対象となるためのインターフェイス
''' </summary>
''' <remarks></remarks>
Public Interface IEnterキー制御

End Interface
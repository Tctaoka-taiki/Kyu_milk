''' <summary>
''' グリッド系共通インターフェイス
''' </summary>
''' <remarks>グリッド系に共通するインターフェイスを定義し、コントロールが変わってもコード修正を減らすのが目的。
''' 現時点では機能していない。</remarks>
Public Interface Iグリッド
    Function セル文字列(ByVal row As Integer, ByVal col As Integer) As String
    Function セル文字列(ByVal row As Integer) As String
    Function セル内容(ByVal col As Integer) As Object
End Interface

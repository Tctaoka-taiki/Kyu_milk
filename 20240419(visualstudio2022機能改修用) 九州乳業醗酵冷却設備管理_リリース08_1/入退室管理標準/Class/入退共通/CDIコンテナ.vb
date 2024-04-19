Public Class CDIコンテナ三菱UHF
    Implements IDIコンテナ

    Private Shared _MelUHFTag As New MelUHFTag

    Public Function GetRFIDリーダライタ() As 共通.IRFIDリーダライタ Implements 共通.IDIコンテナ.GetRFIDリーダライタ
        Return _MelUHFTag
    End Function

End Class

Public Class CDIコンテナDnp1356
    Implements IDIコンテナ

    Private Shared _リーダライタ As New CHRW_DSU01

    Public Function GetRFIDリーダライタ() As 共通.IRFIDリーダライタ Implements 共通.IDIコンテナ.GetRFIDリーダライタ
        Return _リーダライタ
    End Function

End Class
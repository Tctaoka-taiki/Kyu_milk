
Imports System.Data.Common

Public Class Frm01012_®yüÉIÝè
    '#####################################################################################
    '^
    '#####################################################################################

    '#####################################################################################
    'oÏ
    '#####################################################################################

    '#####################################################################################
    'vpeB[
    '#####################################################################################

    '#####################################################################################
    'Cxg
    '#####################################################################################

    '#####################################################################################
    'Cxgnh
    '#####################################################################################

    '#####################################################################################
    'vV[W
    '#####################################################################################
    Dim intJgy[W As Integer = 1
    Private Sub Frm01012_®yüÉIÝè_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        For i = 0 To 23
            Me.dgvI1.Rows.Add()
            Me.dgvI2.Rows.Add()
            Me.dgvI3.Rows.Add()
            Me.dgvI4.Rows.Add()
            Me.dgvI5.Rows.Add()
        Next
        Me.dgvI1.CurrentCell = Nothing
        Me.dgvI2.CurrentCell = Nothing
        Me.dgvI3.CurrentCell = Nothing
        Me.dgvI4.CurrentCell = Nothing
        Me.dgvI5.CurrentCell = Nothing

        qÉîñ\¦()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Dim dlg As New Dlg01999_IeiXo^
            With dlg
                .mæÊ[h = 0
                .ShowDialog()

            End With
            qÉîñ\¦()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Try
            Dim dlg As New Dlg01999_IeiXí
            With dlg
                .mæÊ[h = 0
                .ShowDialog()

            End With
            qÉîñ\¦()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Try
            Dim dlg As New Dlg01999_IeiXC³
            With dlg
                .mæÊ[h = 0
                .ShowDialog()

            End With
            qÉîñ\¦()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Try
            Dim dlg As New Dlg01999_IeiXÖ~I
            With dlg
                .mæÊ[h = 0
                .ShowDialog()

            End With
            qÉîñ\¦()

        Catch ex As Exception
        Finally

        End Try
    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDIqtH[ðJ­(CæÊ§äI[_[Ê.®yCj[)

        Catch ex As Exception
            Call CMdiMain.mSubG[\¦(ex)
        End Try
    End Sub

    Private Sub qÉîñ\¦()
        Dim OFFSET As Integer = 0
        If intJgy[W = 2 Then
            OFFSET = 120
        End If
        Dim i As Integer = 0
        For i = 0 To 23
            Me.dgvI1(0, i).Value = i + 1 + OFFSET
            Me.dgvI2(0, i).Value = i + 25 + OFFSET
            Me.dgvI3(0, i).Value = i + 49 + OFFSET
            Me.dgvI4(0, i).Value = i + 73 + OFFSET
            Me.dgvI5(0, i).Value = i + 97 + OFFSET
            Me.dgvI1(1, i).Value = ""
            Me.dgvI2(1, i).Value = ""
            Me.dgvI3(1, i).Value = ""
            Me.dgvI4(1, i).Value = ""
            Me.dgvI5(1, i).Value = ""
        Next

        Application.DoEvents()

        Dim reader As DbDataReader = Nothing
        Dim ñ As Integer = 99
        Dim A As Integer = 99
        Dim i As Integer = 99

        Try
            With New CSqlEx
                .gSubSelect("ø")
                '.gSubSelect("CONVERT(varchar,ñ) + '-' + CONVERT(varchar,A) + '-' + CONVERT(varchar,i) as LOC")
                .gSubSelect("ñ")
                .gSubSelect("A")
                .gSubSelect("i")
                .gSubFrom("DMI")
                .gSubWhere("qÉæª", 0, , , , , , , False, )
                .gSubWhere("(Iæª = 0 OR Iæª = 2)")
                .gSubOrderBy("ø")

                If CUsrctl.gDp.gBlnReader(.gSQL¶Ìæ¾, reader) Then
                    While reader.Read
                        f[^\¦(reader.GetValue(0).ToString, reader.GetValue(1).ToString & "-" & reader.GetValue(2).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(3).ToString)
                    End While
                End If

            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

    End Sub

    Private Sub f[^\¦(ByVal ø As Integer, ByVal strIÔn As String)
        If intJgy[W = 1 Then
            If ø <= 120 Then
                Select Case Math.Ceiling(ø / 24)
                    Case 1
                        Me.dgvI1(1, ø - 1).Value = strIÔn
                    Case 2
                        Me.dgvI2(1, ø - 25).Value = strIÔn
                    Case 3
                        Me.dgvI3(1, ø - 49).Value = strIÔn
                    Case 4
                        Me.dgvI4(1, ø - 73).Value = strIÔn
                    Case 5
                        Me.dgvI5(1, ø - 97).Value = strIÔn

                End Select
            Else
                Exit Sub
            End If
        Else
            If ø > 120 Then
                ø = ø - 120
                Select Case Math.Ceiling(ø / 24)
                    Case 1
                        Me.dgvI1(1, ø - 1).Value = strIÔn
                    Case 2
                        Me.dgvI2(1, ø - 25).Value = strIÔn
                    Case 3
                        Me.dgvI3(1, ø - 49).Value = strIÔn
                    Case 4
                        Me.dgvI4(1, ø - 73).Value = strIÔn
                    Case 5
                        Me.dgvI5(1, ø - 97).Value = strIÔn

                End Select

            Else
                Exit Sub
            End If

        End If

    End Sub
    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        intJgy[W = 1
        qÉîñ\¦()
    End Sub

    Private Sub btnF9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF9.Click
        intJgy[W = 2
        qÉîñ\¦()
    End Sub
End Class

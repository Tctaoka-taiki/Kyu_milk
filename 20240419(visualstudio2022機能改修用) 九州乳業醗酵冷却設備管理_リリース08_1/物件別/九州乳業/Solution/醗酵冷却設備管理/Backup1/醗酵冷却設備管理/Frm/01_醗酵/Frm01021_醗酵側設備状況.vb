
Imports System.Data.Common
Public Class Frm00003_®y¤Ýõóµ
    '#####################################################################################
    '^
    '#####################################################################################

    '#####################################################################################
    'oÏ
    '#####################################################################################
    Dim dbl­yº·xX« As Double = CUtil.ÝèÖA.Ýè¶ñÇ("­yº·xX«", 1)
    Dim dbl­yº·xØÐ As Double = CUtil.ÝèÖA.Ýè¶ñÇ("­yº·xØÐ", 0)
    Dim dbl}âº·xX« As Double = CUtil.ÝèÖA.Ýè¶ñÇ("}âº·xX«", 1)
    Dim dbl}âº·xØÐ As Double = CUtil.ÝèÖA.Ýè¶ñÇ("}âº·xØÐ", 0)
    Dim dblâpº·xX« As Double = CUtil.ÝèÖA.Ýè¶ñÇ("âpº·xX«", 1)
    Dim dblâpº·xØÐ As Double = CUtil.ÝèÖA.Ýè¶ñÇ("âpº·xØÐ", 0)

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

    Private Sub Frm00002_Ýõóµ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To 8
            dgvÝõóµ.Rows.Add()
        Next

        For i = 0 To 2
            dgvÝõóµ¤Ê.Rows.Add()
            dgvÝõóµ¤Ê(0, i).Value = i + 21
            dgvÝõóµ¤Ê(1, i).Value = strÝõ¼Ì(i + 10)
        Next


        dgvÝõóµ.CurrentCell = Nothing
        dgvÝõóµ¤Ê.CurrentCell = Nothing
        Me.cmbC.Text = "n[hP"
        ÝõóµXV()
        Timer1.Interval = 2000
        Timer1.Start()

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Try
            Timer1.Stop()

            Dim dlg As New Dlg01999_gbLOí
            With dlg
                .mæÊ[h = 0
                .ShowDialog()
            End With

        Catch ex As Exception
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub btnF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF8.Click
        Dim intSelectIDX As Integer = Me.cmbC.SelectedIndex
        If intSelectIDX = 2 Then
            intSelectIDX = 0
        Else
            intSelectIDX += 1
        End If
        Me.cmbC.SelectedIndex = intSelectIDX

    End Sub

    Private Sub btnF12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF12.Click
        Try
            CMdiMain.gSubMDIqtH[ðJ­(CæÊ§äI[_[Ê.®yCj[)


        Catch ex As Exception
            Call CMdiMain.mSubG[\¦(ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ÝõóµXV()
    End Sub

    Private Sub cmbC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbC.SelectedIndexChanged

        ÝõóµXV()
    End Sub

    Private Sub ÝõóµXV()
        Dim foCXOFFSET As Integer
        Dim »¢C As Integer = 0

        Try

            Select Case Me.cmbC.Text
                Case "n[hP"
                    foCXOFFSET = 6000
                    »¢C = 0
                    Dim i As Integer = 0
                    For i = 0 To 8
                        dgvÝõóµ(0, i).Value = i + 1
                        dgvÝõóµ(1, i).Value = strÝõ¼Ì(i + 1)
                    Next
                Case "v[P"
                    foCXOFFSET = 6004
                    »¢C = 1
                    Dim i As Integer = 0
                    For i = 0 To 8
                        dgvÝõóµ(0, i).Value = i + 11
                        dgvÝõóµ(1, i).Value = strÝõ¼Ì(i + 1)
                    Next
                Case "n[hQ"
                    foCXOFFSET = 6010
                    »¢C = 2
                    Dim i As Integer = 0
                    For i = 0 To 8
                        dgvÝõóµ(0, i).Value = i + 31
                        dgvÝõóµ(1, i).Value = strÝõ¼Ì(i + 1)
                    Next
            End Select

            'iÏ@
            MîñXV_CÊ(0, foCXOFFSET + 1, 0)
            ×îñXV_CÊ(0, foCXOFFSET + 1, 2, 0)

            'Rx
            MîñXV_CÊ(0, foCXOFFSET + 2, 1)

            ×îñXV_CÊ(0, foCXOFFSET + 2, 4, 3)
            ×îñXV_CÊ(0, foCXOFFSET + 2, 3, 4)
            ×îñXV_CÊ(0, foCXOFFSET + 2, 2, 5)

            'üÉST
            MîñXV_CÊ(0, foCXOFFSET + 3, 6)
            MîñXV_CÊ(0, foCXOFFSET + 3, 7)
            MîñXV_CÊ(0, foCXOFFSET + 3, 8)

            ×îñXV_CÊ(0, foCXOFFSET + 3, 4, 6)
            ×îñXV_CÊ(0, foCXOFFSET + 3, 3, 7)
            ×îñXV_CÊ(0, foCXOFFSET + 3, 2, 8)

            'N[(s¾)
            N[MîñXV(0, 5002, 0)

            'oÉST
            MîñXV_¤Ê(0, 6008, 1)
            ×îñXV_¤Ê(0, 6008, 2, 1)

            'âpºO
            MîñXV_¤Ê(1, 6000, 2)
            ×îñXV_¤Ê(1, 6000, 2, 2)

            'gbLOf[^\¦
            gbLOîñXV(»¢C)

            'Ýõ·x\¦
            lbl®yqÉ·x.Text = Format(Int((Dbl·xf[^æ¾(0, 6009) - dbl­yº·xØÐ) / dbl­yº·xX« * 10) / 10, "0.0")
            lblâpqÉ·x.Text = Format(Int((Dbl·xf[^æ¾(1, 6009) - dblâpº·xØÐ) / dblâpº·xX« * 10) / 10, "0.0")
            lbl}âº·x.Text = Format(Int((Dbl·xf[^æ¾(1, 6010) - dbl}âº·xØÐ) / dbl}âº·xX« * 10) / 10, "0.0")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub gbLOîñXV(ByVal »¢C As Integer)
        Dim i As Integer = 0
        For i = 0 To 8
            Me.dgvÝõóµ.Item(4, i).Value = ""
            Me.dgvÝõóµ.Item(5, i).Value = ""
            Me.dgvÝõóµ.Item(6, i).Value = ""
            Me.dgvÝõóµ.Item(7, i).Value = ""
            Me.dgvÝõóµ.Item(8, i).Value = ""
        Next
        For i = 0 To 2
            Me.dgvÝõóµ¤Ê.Item(4, i).Value = ""
            Me.dgvÝõóµ¤Ê.Item(5, i).Value = ""
            Me.dgvÝõóµ¤Ê.Item(6, i).Value = ""
            Me.dgvÝõóµ¤Ê.Item(7, i).Value = ""
            Me.dgvÝõóµ¤Ê.Item(8, i).Value = ""
        Next

        Dim reader As DbDataReader = Nothing
        Try

            With New CSqlEx
                .gSubSelect("A.Xe[^X")
                .gSubSelect("B.ií¼")
                .gSubSelect("A.óü")
                .gSubSelect("A.TvNo")
                .gSubSelect("A.STNO")
                .gSubSelect("A.ñ")
                .gSubSelect("A.A")
                .gSubSelect("A.i")
                .gSubFrom("DNgbLO A")
                .gSubFrom("DMií B")
                .gSubWhere("A.»¢C", »¢C, , , , , , , False)
                .gSubWhere("A.iíCD = B.iíCD")
                .gSubWhere("A.Xe[^X < 5")
                .gSubOrderBy("A.XVú")

                Dim RxCNT As Integer = 0
                If CUsrctl.gDp.gBlnReader(.gSQL¶Ìæ¾, reader) Then
                    While reader.Read
                        Select Case reader.GetValue(0)
                            Case 0  'iÏ@f[^
                                Me.dgvÝõóµ.Item(4, 0).Value = reader.GetValue(1)
                                Me.dgvÝõóµ.Item(5, 0).Value = reader.GetValue(2)
                                Me.dgvÝõóµ.Item(6, 0).Value = reader.GetValue(3)

                            Case 1  'Rxf[^ ¦¡f[^ªXgbN³êéêª é
                                Me.dgvÝõóµ.Item(4, 5 - RxCNT).Value = reader.GetValue(1)
                                Me.dgvÝõóµ.Item(5, 5 - RxCNT).Value = reader.GetValue(2)
                                Me.dgvÝõóµ.Item(6, 5 - RxCNT).Value = reader.GetValue(3)
                                RxCNT += 1
                            Case 2
                                Select Case reader.GetValue(4)
                                    Case 3
                                        Me.dgvÝõóµ.Item(4, 8).Value = reader.GetValue(1)
                                        Me.dgvÝõóµ.Item(5, 8).Value = reader.GetValue(2)
                                        Me.dgvÝõóµ.Item(6, 8).Value = reader.GetValue(3)
                                    Case 2
                                        Me.dgvÝõóµ.Item(4, 7).Value = reader.GetValue(1)
                                        Me.dgvÝõóµ.Item(5, 7).Value = reader.GetValue(2)
                                        Me.dgvÝõóµ.Item(6, 7).Value = reader.GetValue(3)
                                    Case 1
                                        Me.dgvÝõóµ.Item(4, 6).Value = reader.GetValue(1)
                                        Me.dgvÝõóµ.Item(5, 6).Value = reader.GetValue(2)
                                        Me.dgvÝõóµ.Item(6, 6).Value = reader.GetValue(3)
                                End Select

                            Case 3 'N[w¦\ñ
                                Select Case reader.GetValue(4)
                                    Case 3
                                        Me.dgvÝõóµ.Item(4, 8).Value = reader.GetValue(1)
                                        Me.dgvÝõóµ.Item(5, 8).Value = reader.GetValue(2)
                                        Me.dgvÝõóµ.Item(6, 8).Value = reader.GetValue(3)
                                        Me.dgvÝõóµ.Item(7, 8).Value = reader.GetValue(5) & "-" & reader.GetValue(6).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(7)
                                    Case 2
                                        Me.dgvÝõóµ.Item(4, 7).Value = reader.GetValue(1)
                                        Me.dgvÝõóµ.Item(5, 7).Value = reader.GetValue(2)
                                        Me.dgvÝõóµ.Item(6, 7).Value = reader.GetValue(3)
                                    Case 1
                                        Me.dgvÝõóµ.Item(4, 6).Value = reader.GetValue(1)
                                        Me.dgvÝõóµ.Item(5, 6).Value = reader.GetValue(2)
                                        Me.dgvÝõóµ.Item(6, 6).Value = reader.GetValue(3)
                                End Select

                            Case 4  'N[w¦M
                                Select Case reader.GetValue(4)
                                    Case 3
                                        Me.dgvÝõóµ.Item(4, 8).Value = reader.GetValue(1)
                                        Me.dgvÝõóµ.Item(5, 8).Value = reader.GetValue(2)
                                        Me.dgvÝõóµ.Item(6, 8).Value = reader.GetValue(3)
                                        Me.dgvÝõóµ.Item(7, 8).Value = reader.GetValue(5) & "-" & reader.GetValue(6).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(7)
                                    Case 2
                                        Me.dgvÝõóµ.Item(4, 7).Value = reader.GetValue(1)
                                        Me.dgvÝõóµ.Item(5, 7).Value = reader.GetValue(2)
                                        Me.dgvÝõóµ.Item(6, 7).Value = reader.GetValue(3)
                                    Case 1
                                        Me.dgvÝõóµ.Item(4, 6).Value = reader.GetValue(1)
                                        Me.dgvÝõóµ.Item(5, 6).Value = reader.GetValue(2)
                                        Me.dgvÝõóµ.Item(6, 6).Value = reader.GetValue(3)
                                End Select
                        End Select
                    End While
                End If
            End With

        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try

        Try
            With New CSqlEx
                .gSubSelect("A.Xe[^X")
                .gSubSelect("MAX(B.ií¼)")
                .gSubSelect("SUM(A.óü)")
                .gSubSelect("A.TvNo")
                .gSubSelect("A.ñ")
                .gSubSelect("A.A")
                .gSubSelect("A.i")
                .gSubFrom("DNgbLO A")
                .gSubFrom("DMií B")
                .gSubWhere("A.iíCD = B.iíCD")
                .gSubWhere("A.Xe[^X >= 5")
                .gSubGroupBy("A.Xe[^X")
                .gSubGroupBy("A.TvNo")
                .gSubGroupBy("A.ñ")
                .gSubGroupBy("A.A")
                .gSubGroupBy("A.i")

                If CUsrctl.gDp.gBlnReader(.gSQL¶Ìæ¾, reader) Then
                    While reader.Read
                        Select Case reader.GetValue(0)
                            Case 5  'N[f[^
                                Me.dgvÝõóµ¤Ê.Item(4, 0).Value = reader.GetValue(1)
                                Me.dgvÝõóµ¤Ê.Item(5, 0).Value = reader.GetValue(2)
                                Me.dgvÝõóµ¤Ê.Item(6, 0).Value = reader.GetValue(3)
                                Me.dgvÝõóµ¤Ê.Item(7, 0).Value = reader.GetValue(4) & "-" & reader.GetValue(5).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(6)
                                Me.dgvÝõóµ¤Ê.Item(8, 0).Value = "üÉ"

                            Case 9  'N[f[^
                                Me.dgvÝõóµ¤Ê.Item(4, 0).Value = reader.GetValue(1)
                                Me.dgvÝõóµ¤Ê.Item(5, 0).Value = reader.GetValue(2)
                                Me.dgvÝõóµ¤Ê.Item(6, 0).Value = reader.GetValue(3)
                                Me.dgvÝõóµ¤Ê.Item(7, 0).Value = reader.GetValue(4) & "-" & reader.GetValue(5).ToString.PadLeft(2, "0"c) & "-" & reader.GetValue(6)
                                Me.dgvÝõóµ¤Ê.Item(8, 0).Value = "oÉ"

                            Case 10  'oÉSTf[^
                                Me.dgvÝõóµ¤Ê.Item(4, 1).Value = reader.GetValue(1)
                                Me.dgvÝõóµ¤Ê.Item(5, 1).Value = reader.GetValue(2)
                                Me.dgvÝõóµ¤Ê.Item(6, 1).Value = reader.GetValue(3)

                            Case 20  '}âºOf[^
                                Me.dgvÝõóµ¤Ê.Item(4, 2).Value = reader.GetValue(1)
                                Me.dgvÝõóµ¤Ê.Item(5, 2).Value = reader.GetValue(2)
                                Me.dgvÝõóµ¤Ê.Item(6, 2).Value = reader.GetValue(3)
                        End Select
                    End While
                End If
            End With
        Catch ex As Exception
        Finally
            CUsrctl.gDp.gSubReaderClose(reader)
        End Try
    End Sub

    Private Sub N[MîñXV(ByVal qÉæª As Integer, ByVal foCXNo As Integer, ByVal Row As Integer)
        If CMdiMain.intfoCXXe[^X(qÉæª, foCXNo, 5) = 1 Then
            dgvÝõóµ¤Ê.Item(2, Row).Value = "Ùí"
        Else
            If CMdiMain.intfoCXXe[^X(qÉæª, foCXNo, 7) = 1 Then
                dgvÝõóµ¤Ê.Item(2, Row).Value = "©®"
            Else
                dgvÝõóµ¤Ê.Item(2, Row).Value = "è®"
            End If
        End If
    End Sub

    Private Sub MîñXV_CÊ(ByVal qÉæª As Integer, ByVal foCXNo As Integer, ByVal Row As Integer)
        If CMdiMain.intfoCXXe[^X(qÉæª, foCXNo, 0) = 1 Then
            dgvÝõóµ.Item(2, Row).Value = "Ùí"
        Else
            If CMdiMain.intfoCXXe[^X(qÉæª, foCXNo, 1) = 1 Then
                dgvÝõóµ.Item(2, Row).Value = "©®"
            Else
                dgvÝõóµ.Item(2, Row).Value = "è®"
            End If
        End If
    End Sub

    Private Sub ×îñXV_CÊ(ByVal qÉæª As Integer, ByVal foCXNo As Integer, ByVal rbgNo As Integer, ByVal Row As Integer)
        If CMdiMain.intfoCXXe[^X(qÉæª, foCXNo, rbgNo) = 1 Then
            dgvÝõóµ.Item(3, Row).Value = "L"
        Else
            dgvÝõóµ.Item(3, Row).Value = ""
        End If
    End Sub

    Private Sub MîñXV_¤Ê(ByVal qÉæª As Integer, ByVal foCXNo As Integer, ByVal Row As Integer)
        If CMdiMain.intfoCXXe[^X(qÉæª, foCXNo, 0) = 1 Then
            dgvÝõóµ¤Ê.Item(2, Row).Value = "Ùí"
        Else
            If CMdiMain.intfoCXXe[^X(qÉæª, foCXNo, 1) = 1 Then
                dgvÝõóµ¤Ê.Item(2, Row).Value = "©®"
            Else
                dgvÝõóµ¤Ê.Item(2, Row).Value = "è®"
            End If
        End If
    End Sub

    Private Sub ×îñXV_¤Ê(ByVal qÉæª As Integer, ByVal foCXNo As Integer, ByVal rbgNo As Integer, ByVal Row As Integer)
        If CMdiMain.intfoCXXe[^X(qÉæª, foCXNo, rbgNo) = 1 Then
            dgvÝõóµ¤Ê.Item(3, Row).Value = "L"
        Else
            dgvÝõóµ¤Ê.Item(3, Row).Value = ""
        End If
    End Sub

    Private Function strÝõ¼Ì(ByVal no As Integer) As String
        Dim Ýõ¼Ì As String
        Select Case no
            Case 1
                Ýõ¼Ì = "iÏ@"
            Case 2
                Ýõ¼Ì = "Rx"
            Case 7
                Ýõ¼Ì = "üÉSTP"
            Case 8
                Ýõ¼Ì = "üÉSTQ"
            Case 9
                Ýõ¼Ì = "üÉSTR"
            Case 10
                Ýõ¼Ì = "N["
            Case 11
                Ýõ¼Ì = "oÉST"
            Case 12
                Ýõ¼Ì = "âpºO"
            Case Else
                Ýõ¼Ì = ""
        End Select

        Return Ýõ¼Ì
    End Function

    Private Function Dbl·xf[^æ¾(ByVal intqÉæª As Integer, ByVal intOFFSET As Integer) As Double
        Dim i As Integer
        Dim BitData As String = ""
        Dim ·xf[^ As Double = 0

        BitData = ""
        For i = 0 To 15
            BitData = Int(CMdiMain.blnONóÔ(intqÉæª, intOFFSET, i)) & BitData
        Next

        ·xf[^ = Convert.ToInt32(BitData, 2)

        Return ·xf[^
    End Function
End Class

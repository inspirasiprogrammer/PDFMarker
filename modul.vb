Imports System.Drawing.Imaging

Module modul
    Public Sub CreateTempSignature(ByVal Data As DataTable, ByVal iWidth As Single, ByVal iHeight As Single, ByVal WatermarkLocation As String, Optional ByVal ImgPath As Boolean = False)
        If Data.Rows.Count > 0 Then
            Dim i As Integer = 0
            Dim flSignature As New FlowLayoutPanel
            Dim NameSign As String = ""

            With flSignature
                .AllowDrop = True
                .AutoScroll = True
                .Size = New System.Drawing.Size(iWidth, iHeight)
                .BorderStyle = BorderStyle.None
                .BackColor = Color.White
                .Controls.Clear()
            End With

            For Each r As DataRow In Data.Rows
                i += 1
                Dim sign As New Signature

                Dim Otoritas As String = ""
                Dim Verified As Boolean = False
                If r.Item("isValid") = "Y" Then
                    Otoritas = r.Item("otoritas")
                    Verified = True
                ElseIf r.Item("isValid") = "L" Then
                    Otoritas = "Ditunda"
                    Verified = True
                ElseIf r.Item("isValid") = "D" Then
                    Otoritas = "Dibatalkan"
                    Verified = True
                Else
                    Otoritas = "X"
                    Verified = False
                End If

                NameSign = IIf(r.Item("jabatan") = "", r.Item("user_name").ToString, r.Item("jabatan").ToString)

                With sign
                    .Jabatan = NameSign
                    .sVerified = IIf(Not ImgPath, Format(r.Item("valid_time"), "dd-MM-yy  HH:mm"), "")
                    .Verified = Verified
                    .Diketahui = Otoritas
                    .PathImage = IIf(Not ImgPath, Application.StartupPath & "\Verified\" & r.Item("dept_id") & ".png", "")
                    flSignature.Controls.Add(sign)
                End With
            Next
            Dim img As Image = New Bitmap(flSignature.Width, flSignature.Height)
            flSignature.DrawToBitmap(img, New Rectangle(0, 0, flSignature.Width, flSignature.Height))
            img.Save(WatermarkLocation, ImageFormat.Png)
        End If
    End Sub
End Module

Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text

Public Class Form1
    Dim sFile, sVerified, sSessionID As String
    Dim PageMax As Integer = 1
    Private DataVerified As DataTable

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .Title = "Select multiple files E.g Document, Excel and PDF"
            .Filter = "Filter Files (*.pdf;*.doc;*.docx;*.xls;*.xlsx)|*.pdf;*.doc;*.docx;*.xls;*.xlsx|All files (*.*)|*.*"
            .InitialDirectory = Application.StartupPath
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                sFile = .FileName
                TextBox1.Text = sFile
                lblMessage.Text = System.IO.Path.GetFileName(sFile)
            End If
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sVerified = Path.GetDirectoryName(sFile) & "\Ver" & lblMessage.Text
        Dim WatermarkLocation As String = Application.StartupPath & "\Verified\" & sSessionID & "Verified.png"
        Dim HeaderLocation As String = Application.StartupPath & "\Verified\" & sSessionID & "Header.png"
        AddTempPDFWaterMark(sFile, sVerified, WatermarkLocation, HeaderLocation, 0, DataVerified)
        If File.Exists(sVerified) Then
            Process.Start(sVerified)
        End If
    End Sub

    Sub TabelOtoritas()
        DataVerified = New DataTable()
        DataVerified.Columns.Add("urut", GetType(Long))
        DataVerified.Columns.Add("user_id", GetType(Long))
        DataVerified.Columns.Add("user_name", GetType(String))
        DataVerified.Columns.Add("jabatan", GetType(String))
        DataVerified.Columns.Add("otoritas", GetType(String))
        DataVerified.Columns.Add("isValid", GetType(String))
        DataVerified.Columns.Add("valid_time", GetType(DateTime))
        DataVerified.Columns.Add("dept_id", GetType(String))

        DataVerified.Rows.Clear()
        For i As Integer = 0 To 3
            Dim newrowSender() As Object = {i, i, "UserName " & i, "Jab " & i, "Otoritas " & i, "Y", Now, ""}
            DataVerified.Rows.Add(newrowSender)
        Next
    End Sub

    Public Sub AddTempPDFWaterMark(ByVal strFileLocation As String, ByVal strFileLocationOut As String, ByVal WatermarkLocation As String, ByVal HeaderLocation As String, ByVal ID As Long, Optional ByVal Valid As DataTable = Nothing)
        Dim document As Document = New Document()
        Dim pdfReader As PdfReader = New PdfReader(strFileLocation)
        Dim pagesize As iTextSharp.text.Rectangle = pdfReader.GetPageSize(pdfReader.NumberOfPages)

        If File.Exists(WatermarkLocation) Then
            My.Computer.FileSystem.DeleteFile(WatermarkLocation, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        End If

        CreateTempSignature(Valid, pagesize.Width, 70, WatermarkLocation, True)

        If File.Exists(strFileLocationOut) Then
            My.Computer.FileSystem.DeleteFile(strFileLocationOut, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        End If

        Dim pdfStamper As PdfStamper = New PdfStamper(pdfReader, New FileStream(strFileLocationOut, FileMode.Create, FileAccess.Write, FileShare.None))

        Dim waterMark As PdfContentByte

        For i As Integer = 1 To pdfReader.NumberOfPages
            If File.Exists(HeaderLocation) Then
                My.Computer.FileSystem.DeleteFile(HeaderLocation, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            End If
            pagesize = pdfReader.GetPageSize(i)
            PageMax = pdfReader.NumberOfPages
            'Add Signature to Last
            waterMark = pdfStamper.GetOverContent(pdfReader.NumberOfPages)
            If File.Exists(WatermarkLocation) Then
                Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(WatermarkLocation)
                With img
                    .SetAbsolutePosition(10, 10)
                End With
                waterMark.AddImage(img)
            End If

            'WATERMARK
            Dim watermarkText As String = "AUTHORIZED EVB   AUTHORIZED EVB   AUTHORIZED EVB   AUTHORIZED EVB   "
            Dim layer As PdfLayer = New PdfLayer("WatermarkLayer", pdfStamper.Writer)
            Dim rect As iTextSharp.text.Rectangle = pdfReader.GetPageSize(i)
            Dim cb As PdfContentByte = pdfStamper.GetOverContent(i)
            cb.BeginLayer(layer)
            cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 25)
            Dim gState As PdfGState = New PdfGState()
            gState.FillOpacity = 0.25F
            cb.SetGState(gState)
            cb.SetColorFill(BaseColor.RED)
            cb.BeginText()
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, watermarkText, rect.Width / 2, rect.Height / 2, 52.0F)
            cb.EndText()
            cb.EndLayer()
        Next
        pdfStamper.FormFlattening = True
        pdfStamper.Close()
        'Else
        '    File.Copy(strFileLocation, strFileLocationOut, True)
        'End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sSessionID = 1
        TabelOtoritas()
    End Sub
End Class

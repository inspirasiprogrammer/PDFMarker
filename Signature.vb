Imports System.IO

Public Class Signature
    Public Property Verified As Boolean
    Public Property Jabatan As String
    Public Property sVerified As String
    Public Property Diketahui As String
    Public Property PathImage As String

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Signature_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Verified Then
            btnSign.Text = "√"
            btnSign.Text = Diketahui
            txtTanggal.Text = sVerified
        Else
            btnSign.Text = "X"
            txtTanggal.Text = ""
        End If        

        If Not PathImage = "" Then
            If File.Exists(PathImage) Then
                btnSign.BackgroundImage = System.Drawing.Image.FromFile(PathImage)
            End If
        End If

        txtNama.Text = IIf(Jabatan = "", "(                   )", "( " & Jabatan & " )")
        'ChangeColor(Me)
    End Sub
End Class

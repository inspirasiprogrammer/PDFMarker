<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Signature
    Inherits UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Signature))
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.btnSign = New System.Windows.Forms.Button()
        Me.txtTanggal = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtNama
        '
        Me.txtNama.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNama.BackColor = System.Drawing.Color.White
        Me.txtNama.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNama.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNama.Location = New System.Drawing.Point(4, 39)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(81, 14)
        Me.txtNama.TabIndex = 0
        Me.txtNama.Text = "Irwan Syahputra"
        Me.txtNama.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSign
        '
        Me.btnSign.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSign.BackColor = System.Drawing.Color.White
        Me.btnSign.BackgroundImage = CType(resources.GetObject("btnSign.BackgroundImage"), System.Drawing.Image)
        Me.btnSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSign.FlatAppearance.BorderSize = 0
        Me.btnSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSign.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSign.Location = New System.Drawing.Point(1, 1)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.Size = New System.Drawing.Size(86, 21)
        Me.btnSign.TabIndex = 1
        Me.btnSign.Text = "  Signature"
        Me.btnSign.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSign.UseVisualStyleBackColor = False
        '
        'txtTanggal
        '
        Me.txtTanggal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTanggal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTanggal.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTanggal.Location = New System.Drawing.Point(3, 25)
        Me.txtTanggal.Name = "txtTanggal"
        Me.txtTanggal.Size = New System.Drawing.Size(81, 13)
        Me.txtTanggal.TabIndex = 2
        Me.txtTanggal.Text = "05-10-1992 hh:nn:ss"
        Me.txtTanggal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Signature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.txtTanggal)
        Me.Controls.Add(Me.btnSign)
        Me.Controls.Add(Me.txtNama)
        Me.Name = "Signature"
        Me.Size = New System.Drawing.Size(88, 61)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents btnSign As System.Windows.Forms.Button
    Friend WithEvents txtTanggal As System.Windows.Forms.TextBox

End Class

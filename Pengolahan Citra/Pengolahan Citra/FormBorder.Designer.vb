<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBorder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblWarna = New System.Windows.Forms.Label()
        Me.cmbWarna = New System.Windows.Forms.ComboBox()
        Me.lblTebal = New System.Windows.Forms.Label()
        Me.cmbTebal = New System.Windows.Forms.ComboBox()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblWarna
        '
        Me.lblWarna.AutoSize = True
        Me.lblWarna.Location = New System.Drawing.Point(30, 40)
        Me.lblWarna.Name = "lblWarna"
        Me.lblWarna.Size = New System.Drawing.Size(100, 17)
        Me.lblWarna.TabIndex = 0
        Me.lblWarna.Text = "Warna Border :"
        '
        'cmbWarna
        '
        Me.cmbWarna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWarna.FormattingEnabled = True
        Me.cmbWarna.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "White", "Yellow"})
        Me.cmbWarna.Location = New System.Drawing.Point(180, 37)
        Me.cmbWarna.Name = "cmbWarna"
        Me.cmbWarna.Size = New System.Drawing.Size(150, 24)
        Me.cmbWarna.TabIndex = 1
        '
        'lblTebal
        '
        Me.lblTebal.AutoSize = True
        Me.lblTebal.Location = New System.Drawing.Point(30, 90)
        Me.lblTebal.Name = "lblTebal"
        Me.lblTebal.Size = New System.Drawing.Size(124, 17)
        Me.lblTebal.TabIndex = 2
        Me.lblTebal.Text = "Ketebalan Border :"
        '
        'cmbTebal
        '
        Me.cmbTebal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTebal.FormattingEnabled = True
        Me.cmbTebal.Items.AddRange(New Object() {"5px", "10px", "25px", "50px"})
        Me.cmbTebal.Location = New System.Drawing.Point(180, 87)
        Me.cmbTebal.Name = "cmbTebal"
        Me.cmbTebal.Size = New System.Drawing.Size(150, 24)
        Me.cmbTebal.TabIndex = 3
        '
        'btnBatal
        '
        Me.btnBatal.Location = New System.Drawing.Point(80, 150)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 4
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(200, 150)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 5
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'FormBorder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 220)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.cmbTebal)
        Me.Controls.Add(Me.lblTebal)
        Me.Controls.Add(Me.cmbWarna)
        Me.Controls.Add(Me.lblWarna)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBorder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Opsi Border"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblWarna As Label
    Friend WithEvents cmbWarna As ComboBox
    Friend WithEvents lblTebal As Label
    Friend WithEvents cmbTebal As ComboBox
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnSimpan As Button
End Class
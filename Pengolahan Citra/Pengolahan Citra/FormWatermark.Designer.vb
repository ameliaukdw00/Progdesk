<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormWatermark
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblKataWatermark = New System.Windows.Forms.Label()
        Me.txtKataWatermark = New System.Windows.Forms.TextBox()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblKataWatermark
        '
        Me.lblKataWatermark.AutoSize = True
        Me.lblKataWatermark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblKataWatermark.Location = New System.Drawing.Point(50, 60)
        Me.lblKataWatermark.Name = "lblKataWatermark"
        Me.lblKataWatermark.Size = New System.Drawing.Size(126, 18)
        Me.lblKataWatermark.TabIndex = 0
        Me.lblKataWatermark.Text = "Kata Watermark :"
        '
        'txtKataWatermark
        '
        Me.txtKataWatermark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtKataWatermark.Location = New System.Drawing.Point(190, 58)
        Me.txtKataWatermark.Name = "txtKataWatermark"
        Me.txtKataWatermark.Size = New System.Drawing.Size(220, 24)
        Me.txtKataWatermark.TabIndex = 1
        '
        'btnBatal
        '
        Me.btnBatal.Location = New System.Drawing.Point(100, 130)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(90, 35)
        Me.btnBatal.TabIndex = 2
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(260, 130)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(90, 35)
        Me.btnSimpan.TabIndex = 3
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'FormWatermark
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 210)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.btnBatal)
        Me.Controls.Add(Me.txtKataWatermark)
        Me.Controls.Add(Me.lblKataWatermark)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormWatermark"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Watermark"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblKataWatermark As Label
    Friend WithEvents txtKataWatermark As TextBox
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnSimpan As Button
End Class
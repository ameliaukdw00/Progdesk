Public Class FormWatermark
    ' Variabel publik untuk menyimpan teks yang diinput
    Public WatermarkText As String = ""

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Cek apakah textbox kosong
        If String.IsNullOrWhiteSpace(txtKataWatermark.Text) Then
            MessageBox.Show("Kata watermark tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Simpan teks dan tutup form dengan hasil OK
        WatermarkText = txtKataWatermark.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ' Tutup form dengan hasil Cancel
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
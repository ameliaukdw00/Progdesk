Public Class FormBorder
    ' Properti untuk menyimpan pilihan yang bisa diambil FormUtama
    Public SelectedColor As Color = Color.Red
    Public SelectedThickness As Integer = 25
    Public IsConfirmed As Boolean = False

    Private Sub FormBorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set nilai default saat form dibuka [cite: 88, 90]
        cmbWarna.SelectedIndex = 0 ' Red
        cmbTebal.SelectedIndex = 2 ' 25px
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            ' 1. Ambil warna
            If cmbWarna.SelectedItem IsNot Nothing Then
                SelectedColor = Color.FromName(cmbWarna.SelectedItem.ToString())
            End If

            ' 2. Ambil ketebalan (Hilangkan "px" lalu ubah ke angka)
            If cmbTebal.SelectedItem IsNot Nothing Then
                Dim tebalStr As String = cmbTebal.SelectedItem.ToString().Replace("px", "").Trim()
                Integer.TryParse(tebalStr, SelectedThickness)
            End If

            ' 3. Kirim sinyal sukses
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        IsConfirmed = False
        Me.Close()
    End Sub
End Class
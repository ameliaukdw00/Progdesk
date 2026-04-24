Public Class FormHistogram

    ' Variabel untuk menyimpan gambar yang dikirim dari Form1
    Private imageBmp As Bitmap

    ' Array untuk menyimpan jumlah piksel pada setiap tingkat intensitas warna (0-255)
    Private histR(255) As Integer
    Private histG(255) As Integer
    Private histB(255) As Integer
    Private maxFreq As Integer = 0

    ' Constructor khusus: Menerima parameter Bitmap dari Form1 saat dipanggil
    Public Sub New(bmp As Bitmap)
        InitializeComponent()
        ' Membuat salinan gambar agar proses pembacaan piksel aman
        If bmp IsNot Nothing Then
            imageBmp = New Bitmap(bmp)
        End If
    End Sub

    Private Sub FormHistogramBalok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Menghitung data distribusi piksel begitu form terbuka
        HitungHistogram()
    End Sub

    Private Sub HitungHistogram()
        If imageBmp Is Nothing Then Return

        ' Reset array ke 0
        Array.Clear(histR, 0, histR.Length)
        Array.Clear(histG, 0, histG.Length)
        Array.Clear(histB, 0, histB.Length)
        maxFreq = 0

        ' Looping membaca piksel per piksel untuk menghitung frekuensi warna
        For y As Integer = 0 To imageBmp.Height - 1
            For x As Integer = 0 To imageBmp.Width - 1
                Dim c As Color = imageBmp.GetPixel(x, y)
                histR(c.R) += 1
                histG(c.G) += 1
                histB(c.B) += 1
            Next
        Next

        ' Mencari nilai frekuensi paling tinggi (untuk menyesuaikan skala tinggi grafik)
        For i As Integer = 0 To 255
            If histR(i) > maxFreq Then maxFreq = histR(i)
            If histG(i) > maxFreq Then maxFreq = histG(i)
            If histB(i) > maxFreq Then maxFreq = histB(i)
        Next
    End Sub

    ' Event Paint: Menggambar grafik secara visual di atas Form
    Private Sub FormHistogram_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If maxFreq = 0 Then Return

        Dim g As Graphics = e.Graphics
        Dim startX As Integer = 10
        Dim startY As Integer = Me.ClientSize.Height - 10
        Dim drawHeight As Integer = Me.ClientSize.Height - 30
        Dim barWidth As Integer = 2

        ' Menggambar balok histogram
        ' Menggunakan Step 8 (mengelompokkan nilai) agar grafik terlihat rapi dan tidak terlalu rapat seperti di PDF tugas
        For i As Integer = 0 To 255 Step 8
            Dim avgR As Integer = 0, avgG As Integer = 0, avgB As Integer = 0

            ' Menjumlahkan frekuensi untuk rentang 8 nilai
            For j As Integer = 0 To 7
                If i + j <= 255 Then
                    avgR += histR(i + j)
                    avgG += histG(i + j)
                    avgB += histB(i + j)
                End If
            Next

            ' Menghitung persentase tinggi balok terhadap layar (dikali drawHeight)
            Dim hR As Integer = CInt((avgR / maxFreq) * drawHeight)
            Dim hG As Integer = CInt((avgG / maxFreq) * drawHeight)
            Dim hB As Integer = CInt((avgB / maxFreq) * drawHeight)

            ' Menghitung letak posisi X di layar
            Dim xPos As Integer = startX + (i \ 8) * (barWidth * 3 + 2)

            ' Menggambar balok Merah, Hijau, dan Biru secara berjejer
            g.FillRectangle(Brushes.Red, xPos, startY - hR, barWidth, hR)
            g.FillRectangle(Brushes.Green, xPos + barWidth, startY - hG, barWidth, hG)
            g.FillRectangle(Brushes.Blue, xPos + (barWidth * 2), startY - hB, barWidth, hB)
        Next
    End Sub
End Class
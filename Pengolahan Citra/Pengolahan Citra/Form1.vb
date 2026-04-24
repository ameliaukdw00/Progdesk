Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1

#Region "=== VARIABEL GLOBAL ==="

    ' Layer Management
    Private layers As New List(Of LayerInfo)()
    Private activeLayerIndex As Integer = -1
    Private layerCounter As Integer = 0

    ' Gambar asli dan saat ini
    Private originalBitmap As Bitmap = Nothing
    Private currentBitmap As Bitmap = Nothing

    ' Undo/Redo stack
    Private undoStack As New Stack(Of Bitmap)()
    Private redoStack As New Stack(Of Bitmap)()

    ' Select Mode (ROI)
    Private isSelectMode As Boolean = False
    Private selectionRect As Rectangle = Rectangle.Empty
    Private isDrawing As Boolean = False
    Private startPoint As Point

    ' Color Balance
    Private redIntensity As Integer = 100
    Private greenIntensity As Integer = 100
    Private blueIntensity As Integer = 100

    ' Transform Mode (Stiker)
    Private isTransformMode As Boolean = False
    Private currentSticker As Bitmap = Nothing
    Private stickerRect As Rectangle
    Private isDraggingSticker As Boolean = False
    Private isResizingSticker As Boolean = False
    Private dragOffset As Point

#End Region

#Region "=== CLASS LAYER INFO ==="

    Private Class LayerInfo
        Public Name As String
        Public Image As Bitmap
        Public IsVisible As Boolean = True

        Public Sub New(name As String, img As Bitmap)
            Me.Name = name
            Me.Image = img
        End Sub
    End Class

#End Region

#Region "=== FORM LOAD ==="

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Pengolahan Citra - Multi-Layer Editor"
        RefreshLayerList()
        PictureBox1.BackColor = Color.LightGray

        ' Mendaftarkan semua event mouse ke PictureBox
        AddHandler PictureBox1.MouseDown, AddressOf PictureBox1_MouseDown
        AddHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove
        AddHandler PictureBox1.MouseUp, AddressOf PictureBox1_MouseUp
        AddHandler PictureBox1.Paint, AddressOf PictureBox1_Paint
        AddHandler PictureBox1.DoubleClick, AddressOf PictureBox1_DoubleClick
    End Sub

#End Region

#Region "=== FILE MENU ==="

    Private Sub BukaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BukaToolStripMenuItem.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            ofd.Title = "Buka Gambar"
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim bmp As New Bitmap(ofd.FileName)
                SaveUndoState()

                layerCounter += 1
                Dim newLayer As New LayerInfo("Layer " & layerCounter, bmp)
                layers.Add(newLayer)
                activeLayerIndex = layers.Count - 1

                currentBitmap = New Bitmap(bmp)
                originalBitmap = New Bitmap(bmp)
                PictureBox1.Image = currentBitmap
                RefreshLayerList()
                UpdateActiveLayerLabel()
            End If
        End Using
    End Sub

    Private Sub SimpanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimpanToolStripMenuItem.Click
        If currentBitmap Is Nothing Then
            MessageBox.Show("Tidak ada gambar untuk disimpan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using sfd As New SaveFileDialog()
            sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap|*.bmp"
            sfd.Title = "Simpan Gambar"
            If sfd.ShowDialog() = DialogResult.OK Then
                Select Case sfd.FilterIndex
                    Case 1 : currentBitmap.Save(sfd.FileName, ImageFormat.Png)
                    Case 2 : currentBitmap.Save(sfd.FileName, ImageFormat.Jpeg)
                    Case 3 : currentBitmap.Save(sfd.FileName, ImageFormat.Bmp)
                End Select
                MessageBox.Show("Gambar berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub PropertiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropertiToolStripMenuItem.Click
        If currentBitmap Is Nothing Then
            MessageBox.Show("Tidak ada gambar yang dibuka.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim info As String = $"Ukuran: {currentBitmap.Width} x {currentBitmap.Height} px" & vbCrLf &
                             $"Format: {currentBitmap.PixelFormat}" & vbCrLf &
                             $"Jumlah Layer: {layers.Count}"
        MessageBox.Show(info, "Properti Gambar", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        If MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

#End Region

#Region "=== HISTOGRAM MENU (SUPPORT ROI) ==="

    Private Sub GreyscaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GreyscaleToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        ApplyGreyscale(bmp)
        UpdateDisplay(bmp)
    End Sub

    Private Sub ApplyGreyscale(bmp As Bitmap)
        Dim roi As Rectangle = GetROIOnBitmap(bmp)
        For y As Integer = roi.Top To roi.Bottom - 1
            For x As Integer = roi.Left To roi.Right - 1
                If x < 0 OrElse x >= bmp.Width OrElse y < 0 OrElse y >= bmp.Height Then Continue For
                Dim c As Color = bmp.GetPixel(x, y)
                Dim grey As Integer = CInt(0.299 * c.R + 0.587 * c.G + 0.114 * c.B)
                grey = Math.Max(0, Math.Min(255, grey))
                bmp.SetPixel(x, y, Color.FromArgb(grey, grey, grey))
            Next
        Next
    End Sub

    Private Sub CerahkanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerahkanToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        AdjustBrightness(bmp, 30)
        UpdateDisplay(bmp)
    End Sub

    Private Sub GelapkanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GelapkanToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        AdjustBrightness(bmp, -30)
        UpdateDisplay(bmp)
    End Sub

    Private Sub AdjustBrightness(bmp As Bitmap, delta As Integer)
        Dim roi As Rectangle = GetROIOnBitmap(bmp)
        For y As Integer = roi.Top To roi.Bottom - 1
            For x As Integer = roi.Left To roi.Right - 1
                If x < 0 OrElse x >= bmp.Width OrElse y < 0 OrElse y >= bmp.Height Then Continue For
                Dim c As Color = bmp.GetPixel(x, y)
                Dim r As Integer = Math.Max(0, Math.Min(255, c.R + delta))
                Dim g As Integer = Math.Max(0, Math.Min(255, c.G + delta))
                Dim b As Integer = Math.Max(0, Math.Min(255, c.B + delta))
                bmp.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next
        Next
    End Sub

    Private Sub TambahKontrasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TambahKontrasToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        AdjustContrast(bmp, 30)
        UpdateDisplay(bmp)
    End Sub

    Private Sub KurangiKontrasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KurangiKontrasToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        AdjustContrast(bmp, -30)
        UpdateDisplay(bmp)
    End Sub

    Private Sub AdjustContrast(bmp As Bitmap, delta As Integer)
        Dim roi As Rectangle = GetROIOnBitmap(bmp)
        For y As Integer = roi.Top To roi.Bottom - 1
            For x As Integer = roi.Left To roi.Right - 1
                If x < 0 OrElse x >= bmp.Width OrElse y < 0 OrElse y >= bmp.Height Then Continue For
                Dim c As Color = bmp.GetPixel(x, y)
                Dim r As Integer = Math.Max(0, Math.Min(255, 128 + (c.R - 128) * (100 + delta) \ 100))
                Dim g As Integer = Math.Max(0, Math.Min(255, 128 + (c.G - 128) * (100 + delta) \ 100))
                Dim b As Integer = Math.Max(0, Math.Min(255, 128 + (c.B - 128) * (100 + delta) \ 100))
                bmp.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next
        Next
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        If originalBitmap Is Nothing Then Return
        SaveUndoState()
        currentBitmap = New Bitmap(originalBitmap)
        If activeLayerIndex >= 0 AndAlso activeLayerIndex < layers.Count Then
            layers(activeLayerIndex).Image = New Bitmap(originalBitmap)
        End If
        trackBarRed.Value = 100
        trackBarGreen.Value = 100
        trackBarBlue.Value = 100
        PictureBox1.Image = currentBitmap
        PictureBox1.Invalidate()
    End Sub

    Private Sub TampilkanHistogramToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TampilkanHistogramToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        Dim frmHistogram As New FormHistogram(GetActiveBitmap())
        frmHistogram.Show()
    End Sub

#End Region

#Region "=== EFFECTS MENU (SUPPORT ROI) ==="

    Private Sub TajamkanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TajamkanToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        Dim result As Bitmap = ApplyKernel(bmp, New Integer(,) {
            {0, -1, 0},
            {-1, 5, -1},
            {0, -1, 0}
        }, 1, 0)
        UpdateDisplay(result)
    End Sub

    Private Sub KaburkanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KaburkanToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        Dim result As Bitmap = ApplyKernel(bmp, New Integer(,) {
            {1, 1, 1},
            {1, 1, 1},
            {1, 1, 1}
        }, 9, 0)
        UpdateDisplay(result)
    End Sub

    Private Function ApplyKernel(bmp As Bitmap, kernel As Integer(,), divisor As Integer, offset As Integer) As Bitmap
        Dim result As New Bitmap(bmp) ' Salin gambar asli agar luar ROI tidak berubah
        Dim roi As Rectangle = GetROIOnBitmap(bmp)

        ' Batasi rentang loop agar kernel tidak menabrak batas gambar
        Dim startY As Integer = Math.Max(1, roi.Top)
        Dim endY As Integer = Math.Min(bmp.Height - 2, roi.Bottom - 1)
        Dim startX As Integer = Math.Max(1, roi.Left)
        Dim endX As Integer = Math.Min(bmp.Width - 2, roi.Right - 1)

        For y As Integer = startY To endY
            For x As Integer = startX To endX
                Dim rSum As Integer = 0, gSum As Integer = 0, bSum As Integer = 0
                For ky As Integer = -1 To 1
                    For kx As Integer = -1 To 1
                        Dim c As Color = bmp.GetPixel(x + kx, y + ky)
                        Dim k As Integer = kernel(ky + 1, kx + 1)
                        rSum += c.R * k
                        gSum += c.G * k
                        bSum += c.B * k
                    Next
                Next
                Dim r As Integer = Math.Max(0, Math.Min(255, rSum \ divisor + offset))
                Dim g As Integer = Math.Max(0, Math.Min(255, gSum \ divisor + offset))
                Dim b As Integer = Math.Max(0, Math.Min(255, bSum \ divisor + offset))
                result.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next
        Next
        Return result
    End Function

    Private Sub Putar90ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Putar90ToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        bmp.RotateFlip(RotateFlipType.Rotate90FlipNone)
        UpdateDisplay(bmp)
    End Sub

    Private Sub FlipHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlipHorizontalToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        bmp.RotateFlip(RotateFlipType.RotateNoneFlipX)
        UpdateDisplay(bmp)
    End Sub

    Private Sub FlipVertikalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlipVertikalToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        bmp.RotateFlip(RotateFlipType.RotateNoneFlipY)
        UpdateDisplay(bmp)
    End Sub

#End Region

#Region "=== TUGAS 3 - RONA WARNA (SUPPORT ROI) ==="

    Private Sub RonaMerahToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RonaMerahToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        ApplyRona(bmp, "Merah")
        UpdateDisplay(bmp)
    End Sub

    Private Sub RonaHijauToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RonaHijauToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        ApplyRona(bmp, "Hijau")
        UpdateDisplay(bmp)
    End Sub

    Private Sub RonaBiruToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RonaBiruToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        ApplyRona(bmp, "Biru")
        UpdateDisplay(bmp)
    End Sub

    Private Sub RonaSpesialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RonaSpesialToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        ApplyRonaSpesial(bmp)
        UpdateDisplay(bmp)
    End Sub

    Private Sub ApplyRona(bmp As Bitmap, kanal As String)
        Dim roi As Rectangle = GetROIOnBitmap(bmp)
        For y As Integer = roi.Top To roi.Bottom - 1
            For x As Integer = roi.Left To roi.Right - 1
                If x < 0 OrElse x >= bmp.Width OrElse y < 0 OrElse y >= bmp.Height Then Continue For
                Dim c As Color = bmp.GetPixel(x, y)
                Dim lum As Integer = CInt(0.299 * c.R + 0.587 * c.G + 0.114 * c.B)
                lum = Math.Max(0, Math.Min(255, lum))
                Select Case kanal
                    Case "Merah" : bmp.SetPixel(x, y, Color.FromArgb(lum, 0, 0))
                    Case "Hijau" : bmp.SetPixel(x, y, Color.FromArgb(0, lum, 0))
                    Case "Biru" : bmp.SetPixel(x, y, Color.FromArgb(0, 0, lum))
                End Select
            Next
        Next
    End Sub

    Private Sub ApplyRonaSpesial(bmp As Bitmap)
        Dim roi As Rectangle = GetROIOnBitmap(bmp)
        For y As Integer = roi.Top To roi.Bottom - 1
            For x As Integer = roi.Left To roi.Right - 1
                If x < 0 OrElse x >= bmp.Width OrElse y < 0 OrElse y >= bmp.Height Then Continue For
                Dim c As Color = bmp.GetPixel(x, y)
                bmp.SetPixel(x, y, Color.FromArgb(c.B, c.R, c.G))
            Next
        Next
    End Sub

#End Region

#Region "=== TUGAS 3 - BORDER ==="

    Private Sub BorderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorderToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        Dim frmBorder As New FormBorder()
        If frmBorder.ShowDialog() = DialogResult.OK Then
            SaveUndoState()
            Dim bmp As Bitmap = GetActiveBitmap()
            Using g As Graphics = Graphics.FromImage(bmp)
                Using pen As New Pen(frmBorder.SelectedColor, frmBorder.SelectedThickness)
                    pen.Alignment = Drawing2D.PenAlignment.Inset
                    g.DrawRectangle(pen, 0, 0, bmp.Width, bmp.Height)
                End Using
            End Using
            UpdateDisplay(bmp)
        End If
    End Sub

#End Region

#Region "=== TUGAS 3 - WATERMARK ==="

    Private Sub WatermarkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WatermarkToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        Dim frmWatermark As New FormWatermark()
        If frmWatermark.ShowDialog() = DialogResult.OK Then
            SaveUndoState()
            Dim bmp As Bitmap = GetActiveBitmap()
            Using g As Graphics = Graphics.FromImage(bmp)
                Dim font As New Font("Arial", 20, FontStyle.Bold)
                Dim brush As New SolidBrush(Color.FromArgb(120, 255, 255, 255))
                Dim yPos As Integer = 10
                Do While yPos < bmp.Height
                    Dim xPos As Integer = 10
                    Do While xPos < bmp.Width
                        g.DrawString(frmWatermark.WatermarkText, font, brush, xPos, yPos)
                        xPos += 200
                    Loop
                    yPos += 80
                Loop
            End Using
            UpdateDisplay(bmp)
        End If
    End Sub

#End Region

#Region "=== TUGAS 3 - INVERSI WARNA (SUPPORT ROI) ==="

    Private Sub InversiWarnaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InversiWarnaToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        SaveUndoState()
        Dim bmp As Bitmap = GetActiveBitmap()
        Dim roi As Rectangle = GetROIOnBitmap(bmp)

        For y As Integer = roi.Top To roi.Bottom - 1
            For x As Integer = roi.Left To roi.Right - 1
                If x < 0 OrElse x >= bmp.Width OrElse y < 0 OrElse y >= bmp.Height Then Continue For
                Dim c As Color = bmp.GetPixel(x, y)
                bmp.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B))
            Next
        Next
        UpdateDisplay(bmp)
    End Sub

#End Region

#Region "=== TUGAS 3 - HISTOGRAM BALOK ==="

    Private Sub HistogramBalokToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistogramBalokToolStripMenuItem.Click
        If Not ValidasiGambar() Then Return
        Dim frmHistogram As New FormHistogram(GetActiveBitmap())
        frmHistogram.Show()
    End Sub

#End Region

#Region "=== TUGAS 3b - UNDO / REDO ==="

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If undoStack.Count = 0 Then
            MessageBox.Show("Tidak ada aksi yang bisa di-undo.", "Undo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If currentBitmap IsNot Nothing Then
            redoStack.Push(New Bitmap(currentBitmap))
        End If
        currentBitmap = undoStack.Pop()
        If activeLayerIndex >= 0 AndAlso activeLayerIndex < layers.Count Then
            layers(activeLayerIndex).Image = New Bitmap(currentBitmap)
        End If
        PictureBox1.Image = currentBitmap
        PictureBox1.Invalidate()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        If redoStack.Count = 0 Then
            MessageBox.Show("Tidak ada aksi yang bisa di-redo.", "Redo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If currentBitmap IsNot Nothing Then
            undoStack.Push(New Bitmap(currentBitmap))
        End If
        currentBitmap = redoStack.Pop()
        If activeLayerIndex >= 0 AndAlso activeLayerIndex < layers.Count Then
            layers(activeLayerIndex).Image = New Bitmap(currentBitmap)
        End If
        PictureBox1.Image = currentBitmap
        PictureBox1.Invalidate()
    End Sub

    Private Sub SaveUndoState()
        If currentBitmap IsNot Nothing Then
            undoStack.Push(New Bitmap(currentBitmap))
            redoStack.Clear()
        End If
    End Sub

#End Region

#Region "=== COLOR BALANCE RGB TRACKBAR ==="

    Private Sub trackBarRed_Scroll(sender As Object, e As EventArgs) Handles trackBarRed.Scroll
        redIntensity = trackBarRed.Value
        ApplyColorBalance()
    End Sub

    Private Sub trackBarGreen_Scroll(sender As Object, e As EventArgs) Handles trackBarGreen.Scroll
        greenIntensity = trackBarGreen.Value
        ApplyColorBalance()
    End Sub

    Private Sub trackBarBlue_Scroll(sender As Object, e As EventArgs) Handles trackBarBlue.Scroll
        blueIntensity = trackBarBlue.Value
        ApplyColorBalance()
    End Sub

    Private Sub ApplyColorBalance()
        If activeLayerIndex < 0 OrElse activeLayerIndex >= layers.Count Then Return
        Dim source As Bitmap = layers(activeLayerIndex).Image
        If source Is Nothing Then Return

        Dim result As New Bitmap(source.Width, source.Height)
        For y As Integer = 0 To source.Height - 1
            For x As Integer = 0 To source.Width - 1
                Dim c As Color = source.GetPixel(x, y)
                Dim r As Integer = Math.Min(255, CInt(c.R * redIntensity / 100))
                Dim g As Integer = Math.Min(255, CInt(c.G * greenIntensity / 100))
                Dim b As Integer = Math.Min(255, CInt(c.B * blueIntensity / 100))
                result.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next
        Next
        currentBitmap = result
        PictureBox1.Image = currentBitmap
        PictureBox1.Invalidate()
    End Sub

#End Region

#Region "=== SELECT MODE & STIKER MOUSE EVENTS ==="

    Private Sub btnSelectMode_Click(sender As Object, e As EventArgs) Handles btnSelectMode.Click
        isSelectMode = Not isSelectMode
        If isSelectMode Then
            btnSelectMode.Text = "□ Select Mode ON"
            btnSelectMode.BackColor = Color.LightGreen
        Else
            btnSelectMode.Text = "□ Select Mode OFF"
            btnSelectMode.BackColor = SystemColors.Control
            selectionRect = Rectangle.Empty
            PictureBox1.Invalidate()
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs)
        ' Logika Transform Stiker
        If isTransformMode AndAlso currentSticker IsNot Nothing Then
            Dim bmpPt As Point = GetBitmapCoordinate(e.Location)
            Dim resizeRect As New Rectangle(stickerRect.Right - 20, stickerRect.Bottom - 20, 20, 20)

            If resizeRect.Contains(bmpPt) Then
                isResizingSticker = True
                dragOffset = bmpPt
                Return
            ElseIf stickerRect.Contains(bmpPt) Then
                isDraggingSticker = True
                dragOffset = New Point(bmpPt.X - stickerRect.X, bmpPt.Y - stickerRect.Y)
                Return
            End If
        End If

        ' Logika Select Mode ROI
        If isSelectMode Then
            isDrawing = True
            startPoint = e.Location
            selectionRect = Rectangle.Empty
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs)
        ' Logika Transform Stiker
        If isTransformMode Then
            Dim bmpPt As Point = GetBitmapCoordinate(e.Location)
            If isDraggingSticker Then
                stickerRect.X = bmpPt.X - dragOffset.X
                stickerRect.Y = bmpPt.Y - dragOffset.Y
                PictureBox1.Invalidate()
                Return
            ElseIf isResizingSticker Then
                Dim newWidth As Integer = bmpPt.X - stickerRect.X
                Dim newHeight As Integer = bmpPt.Y - stickerRect.Y
                If newWidth > 20 AndAlso newHeight > 20 Then
                    stickerRect.Width = newWidth
                    stickerRect.Height = newHeight
                    PictureBox1.Invalidate()
                End If
                Return
            End If
        End If

        ' Logika Select Mode ROI
        If isSelectMode AndAlso isDrawing Then
            Dim x As Integer = Math.Min(e.X, startPoint.X)
            Dim y As Integer = Math.Min(e.Y, startPoint.Y)
            Dim w As Integer = Math.Abs(e.X - startPoint.X)
            Dim h As Integer = Math.Abs(e.Y - startPoint.Y)
            selectionRect = New Rectangle(x, y, w, h)
            PictureBox1.Invalidate()
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs)
        isDraggingSticker = False
        isResizingSticker = False
        isDrawing = False
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs)
        ' Gambar Garis Biru Putus-putus untuk ROI
        If isSelectMode AndAlso selectionRect <> Rectangle.Empty Then
            Using pen As New Pen(Color.Blue, 2)
                pen.DashStyle = Drawing2D.DashStyle.Dash
                e.Graphics.DrawRectangle(pen, selectionRect)
            End Using
        End If

        ' Gambar Frame & Handle Stiker
        If isTransformMode AndAlso currentSticker IsNot Nothing AndAlso currentBitmap IsNot Nothing Then
            Dim scaleX As Double = CDbl(PictureBox1.Width) / currentBitmap.Width
            Dim scaleY As Double = CDbl(PictureBox1.Height) / currentBitmap.Height

            Dim pbRect As New Rectangle(CInt(stickerRect.X * scaleX), CInt(stickerRect.Y * scaleY), CInt(stickerRect.Width * scaleX), CInt(stickerRect.Height * scaleY))

            e.Graphics.DrawImage(currentSticker, pbRect)

            Using p As New Pen(Color.Cyan, 2)
                p.DashStyle = Drawing2D.DashStyle.Dash
                e.Graphics.DrawRectangle(p, pbRect)
            End Using

            Dim handleRect As New Rectangle(pbRect.Right - 10, pbRect.Bottom - 10, 10, 10)
            e.Graphics.FillRectangle(Brushes.White, handleRect)
            e.Graphics.DrawRectangle(Pens.Black, handleRect)
        End If
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs)
        ' Jadikan stiker permanen (Layer Baru) saat di-double-click
        If isTransformMode AndAlso currentSticker IsNot Nothing Then
            SaveUndoState()

            Dim newLayerBmp As New Bitmap(originalBitmap.Width, originalBitmap.Height)
            Using g As Graphics = Graphics.FromImage(newLayerBmp)
                g.DrawImage(currentSticker, stickerRect)
            End Using

            layerCounter += 1
            Dim newLayer As New LayerInfo("Stiker " & layerCounter, newLayerBmp)
            layers.Add(newLayer)
            activeLayerIndex = layers.Count - 1

            Dim msg As String = $"Stiker ditambahkan!" & vbCrLf & $"Ukuran: {stickerRect.Width}x{stickerRect.Height}" & vbCrLf & $"Posisi: ({stickerRect.X}, {stickerRect.Y})"
            MessageBox.Show(msg, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            isTransformMode = False
            currentSticker = Nothing

            RefreshLayerList()
            UpdateActiveLayerLabel()
            CompositeLayers()
        End If
    End Sub

#End Region

#Region "=== LAYER MANAGEMENT ==="

    Private Sub btnTambahLayer_Click(sender As Object, e As EventArgs) Handles btnTambahLayer.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            ofd.Title = "Pilih Gambar untuk Layer Baru"
            If ofd.ShowDialog() = DialogResult.OK Then
                layerCounter += 1
                Dim bmp As New Bitmap(ofd.FileName)
                Dim newLayer As New LayerInfo("Layer " & layerCounter, bmp)
                layers.Add(newLayer)
                activeLayerIndex = layers.Count - 1
                currentBitmap = New Bitmap(bmp)
                PictureBox1.Image = currentBitmap
                RefreshLayerList()
                UpdateActiveLayerLabel()
            End If
        End Using
    End Sub

    Private Sub btnHapusLayer_Click(sender As Object, e As EventArgs) Handles btnHapusLayer.Click
        If activeLayerIndex < 0 OrElse activeLayerIndex >= layers.Count Then
            MessageBox.Show("Pilih layer terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If MessageBox.Show("Hapus layer ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            layers.RemoveAt(activeLayerIndex)
            activeLayerIndex = If(layers.Count > 0, layers.Count - 1, -1)
            If activeLayerIndex >= 0 Then
                currentBitmap = New Bitmap(layers(activeLayerIndex).Image)
                PictureBox1.Image = currentBitmap
            Else
                PictureBox1.Image = Nothing
                currentBitmap = Nothing
            End If
            RefreshLayerList()
            UpdateActiveLayerLabel()
        End If
    End Sub

    Private Sub btnToggleVisibility_Click(sender As Object, e As EventArgs) Handles btnToggleVisibility.Click
        If activeLayerIndex < 0 OrElse activeLayerIndex >= layers.Count Then Return
        layers(activeLayerIndex).IsVisible = Not layers(activeLayerIndex).IsVisible
        RefreshLayerList()
        CompositeLayers()
    End Sub

    Private Sub btnMergeKeBawah_Click(sender As Object, e As EventArgs) Handles btnMergeKeBawah.Click
        If activeLayerIndex <= 0 OrElse layers.Count < 2 Then
            MessageBox.Show("Tidak bisa merge: butuh minimal 2 layer dan bukan layer terbawah.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        SaveUndoState()
        Dim topLayer As LayerInfo = layers(activeLayerIndex)
        Dim bottomLayer As LayerInfo = layers(activeLayerIndex - 1)
        Dim merged As New Bitmap(bottomLayer.Image.Width, bottomLayer.Image.Height)
        Using g As Graphics = Graphics.FromImage(merged)
            g.DrawImage(bottomLayer.Image, 0, 0)
            g.DrawImage(topLayer.Image, 0, 0)
        End Using
        bottomLayer.Image = merged
        layers.RemoveAt(activeLayerIndex)
        activeLayerIndex -= 1
        currentBitmap = New Bitmap(merged)
        PictureBox1.Image = currentBitmap
        RefreshLayerList()
        UpdateActiveLayerLabel()
    End Sub

    Private Sub btnTambahStiker_Click(sender As Object, e As EventArgs) Handles btnTambahStiker.Click
        If Not ValidasiGambar() Then Return
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            ofd.Title = "Pilih Stiker"
            If ofd.ShowDialog() = DialogResult.OK Then
                currentSticker = New Bitmap(ofd.FileName)
                Dim bmp As Bitmap = GetActiveBitmap()
                Dim sx As Integer = (bmp.Width - currentSticker.Width) \ 2
                Dim sy As Integer = (bmp.Height - currentSticker.Height) \ 2
                stickerRect = New Rectangle(sx, sy, currentSticker.Width, currentSticker.Height)

                isTransformMode = True
                MessageBox.Show("Mode Transform Stiker:" & vbCrLf & "- Drag stiker untuk memindah" & vbCrLf & "- Drag kotak putih di pojok kanan bawah untuk resize" & vbCrLf & "- Double-click stiker untuk konfirmasi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PictureBox1.Invalidate()
            End If
        End Using
    End Sub

    Private Sub btnNaik_Click(sender As Object, e As EventArgs) Handles btnNaik.Click
        If activeLayerIndex <= 0 OrElse layers.Count < 2 Then Return
        Dim temp As LayerInfo = layers(activeLayerIndex)
        layers(activeLayerIndex) = layers(activeLayerIndex - 1)
        layers(activeLayerIndex - 1) = temp
        activeLayerIndex -= 1
        RefreshLayerList()
        UpdateActiveLayerLabel()
        CompositeLayers()
    End Sub

    Private Sub btnTurun_Click(sender As Object, e As EventArgs) Handles btnTurun.Click
        If activeLayerIndex >= layers.Count - 1 OrElse layers.Count < 2 Then Return
        Dim temp As LayerInfo = layers(activeLayerIndex)
        layers(activeLayerIndex) = layers(activeLayerIndex + 1)
        layers(activeLayerIndex + 1) = temp
        activeLayerIndex += 1
        RefreshLayerList()
        UpdateActiveLayerLabel()
        CompositeLayers()
    End Sub

    Private Sub btnRefreshList_Click(sender As Object, e As EventArgs) Handles btnRefreshList.Click
        RefreshLayerList()
        UpdateActiveLayerLabel()
    End Sub

    Private Sub RefreshLayerList()
        listViewLayers.Items.Clear()
        For i As Integer = 0 To layers.Count - 1
            Dim lv As LayerInfo = layers(i)
            Dim item As New ListViewItem(lv.Name)
            item.SubItems.Add(If(lv.IsVisible, "✓", ""))
            If i = activeLayerIndex Then
                item.BackColor = Color.LightBlue
            End If
            listViewLayers.Items.Add(item)
        Next
    End Sub

    Private Sub UpdateActiveLayerLabel()
        If activeLayerIndex >= 0 AndAlso activeLayerIndex < layers.Count Then
            lblActiveLayer.Text = $"Active Layer: {layers(activeLayerIndex).Name} ({activeLayerIndex + 1}/{layers.Count})"
        Else
            lblActiveLayer.Text = "Active Layer: None"
        End If
    End Sub

    Private Sub listViewLayers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewLayers.SelectedIndexChanged
        If listViewLayers.SelectedIndices.Count > 0 Then
            activeLayerIndex = listViewLayers.SelectedIndices(0)
            currentBitmap = New Bitmap(layers(activeLayerIndex).Image)
            PictureBox1.Image = currentBitmap
            RefreshLayerList()
            UpdateActiveLayerLabel()
        End If
    End Sub

    Private Sub CompositeLayers()
        If layers.Count = 0 Then Return
        Dim first As Bitmap = Nothing
        For Each lv As LayerInfo In layers
            If lv.IsVisible AndAlso lv.Image IsNot Nothing Then
                first = lv.Image
                Exit For
            End If
        Next
        If first Is Nothing Then Return

        Dim composite As New Bitmap(first.Width, first.Height)
        Using g As Graphics = Graphics.FromImage(composite)
            For Each lv As LayerInfo In layers
                If lv.IsVisible AndAlso lv.Image IsNot Nothing Then
                    g.DrawImage(lv.Image, 0, 0)
                End If
            Next
        End Using
        currentBitmap = composite
        PictureBox1.Image = composite
        PictureBox1.Invalidate()
    End Sub

#End Region

#Region "=== HELPER FUNCTIONS ==="

    Private Function ValidasiGambar() As Boolean
        If currentBitmap Is Nothing OrElse layers.Count = 0 Then
            MessageBox.Show("Silakan buka gambar terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
        Return True
    End Function

    Private Function GetActiveBitmap() As Bitmap
        If activeLayerIndex >= 0 AndAlso activeLayerIndex < layers.Count Then
            Return New Bitmap(layers(activeLayerIndex).Image)
        End If
        Return New Bitmap(currentBitmap)
    End Function

    Private Sub UpdateDisplay(bmp As Bitmap)
        currentBitmap = bmp
        If activeLayerIndex >= 0 AndAlso activeLayerIndex < layers.Count Then
            layers(activeLayerIndex).Image = New Bitmap(bmp)
        End If
        PictureBox1.Image = currentBitmap
        PictureBox1.Invalidate()
    End Sub

    Private Function GetBitmapCoordinate(pbPt As Point) As Point
        If currentBitmap Is Nothing Then Return pbPt
        Dim scaleX As Double = CDbl(currentBitmap.Width) / PictureBox1.Width
        Dim scaleY As Double = CDbl(currentBitmap.Height) / PictureBox1.Height
        Return New Point(CInt(pbPt.X * scaleX), CInt(pbPt.Y * scaleY))
    End Function

    Private Function GetROIOnBitmap(bmp As Bitmap) As Rectangle
        If Not isSelectMode OrElse selectionRect.IsEmpty Then
            Return New Rectangle(0, 0, bmp.Width, bmp.Height)
        End If
        Dim scaleX As Double = CDbl(bmp.Width) / PictureBox1.Width
        Dim scaleY As Double = CDbl(bmp.Height) / PictureBox1.Height
        Dim rx As Integer = CInt(selectionRect.X * scaleX)
        Dim ry As Integer = CInt(selectionRect.Y * scaleY)
        Dim rw As Integer = CInt(selectionRect.Width * scaleX)
        Dim rh As Integer = CInt(selectionRect.Height * scaleY)

        rx = Math.Max(0, Math.Min(rx, bmp.Width - 1))
        ry = Math.Max(0, Math.Min(ry, bmp.Height - 1))
        rw = Math.Min(rw, bmp.Width - rx)
        rh = Math.Min(rh, bmp.Height - ry)
        Return New Rectangle(rx, ry, rw, rh)
    End Function

#End Region

End Class
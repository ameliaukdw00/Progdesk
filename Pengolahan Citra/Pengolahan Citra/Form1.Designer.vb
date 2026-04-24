<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        BukaToolStripMenuItem = New ToolStripMenuItem()
        SimpanToolStripMenuItem = New ToolStripMenuItem()
        PropertiToolStripMenuItem = New ToolStripMenuItem()
        KeluarToolStripMenuItem = New ToolStripMenuItem()
        HistogramToolStripMenuItem = New ToolStripMenuItem()
        GreyscaleToolStripMenuItem = New ToolStripMenuItem()
        CerahkanToolStripMenuItem = New ToolStripMenuItem()
        GelapkanToolStripMenuItem = New ToolStripMenuItem()
        TambahKontrasToolStripMenuItem = New ToolStripMenuItem()
        KurangiKontrasToolStripMenuItem = New ToolStripMenuItem()
        ResetToolStripMenuItem = New ToolStripMenuItem()
        TampilkanHistogramToolStripMenuItem = New ToolStripMenuItem()
        EffectsToolStripMenuItem = New ToolStripMenuItem()
        TajamkanToolStripMenuItem = New ToolStripMenuItem()
        KaburkanToolStripMenuItem = New ToolStripMenuItem()
        Putar90ToolStripMenuItem = New ToolStripMenuItem()
        FlipHorizontalToolStripMenuItem = New ToolStripMenuItem()
        FlipVertikalToolStripMenuItem = New ToolStripMenuItem()
        Tugas3ToolStripMenuItem = New ToolStripMenuItem()
        BorderToolStripMenuItem = New ToolStripMenuItem()
        WatermarkToolStripMenuItem = New ToolStripMenuItem()
        InversiWarnaToolStripMenuItem = New ToolStripMenuItem()
        RonaMerahToolStripMenuItem = New ToolStripMenuItem()
        RonaHijauToolStripMenuItem = New ToolStripMenuItem()
        RonaBiruToolStripMenuItem = New ToolStripMenuItem()
        RonaSpesialToolStripMenuItem = New ToolStripMenuItem()
        HistogramBalokToolStripMenuItem = New ToolStripMenuItem()
        Tugas3bToolStripMenuItem = New ToolStripMenuItem()
        UndoToolStripMenuItem = New ToolStripMenuItem()
        RedoToolStripMenuItem = New ToolStripMenuItem()
        PictureBox1 = New PictureBox()
        btnSelectMode = New Button()
        trackBarRed = New TrackBar()
        trackBarGreen = New TrackBar()
        trackBarBlue = New TrackBar()
        lblRed = New Label()
        lblGreen = New Label()
        lblBlue = New Label()
        panelLayers = New Panel()
        lblLayers = New Label()
        btnTambahLayer = New Button()
        btnHapusLayer = New Button()
        btnToggleVisibility = New Button()
        btnMergeKeBawah = New Button()
        btnTambahStiker = New Button()
        btnNaik = New Button()
        btnTurun = New Button()
        listViewLayers = New ListView()
        colNama = New ColumnHeader()
        colVisible = New ColumnHeader()
        lblActiveLayer = New Label()
        btnRefreshList = New Button()
        MenuStrip1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(trackBarRed, ComponentModel.ISupportInitialize).BeginInit()
        CType(trackBarGreen, ComponentModel.ISupportInitialize).BeginInit()
        CType(trackBarBlue, ComponentModel.ISupportInitialize).BeginInit()
        panelLayers.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, HistogramToolStripMenuItem, EffectsToolStripMenuItem, Tugas3ToolStripMenuItem, Tugas3bToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(8, 3, 0, 3)
        MenuStrip1.Size = New Size(1067, 30)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {BukaToolStripMenuItem, SimpanToolStripMenuItem, PropertiToolStripMenuItem, KeluarToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(46, 24)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' BukaToolStripMenuItem
        ' 
        BukaToolStripMenuItem.Name = "BukaToolStripMenuItem"
        BukaToolStripMenuItem.Size = New Size(145, 26)
        BukaToolStripMenuItem.Text = "Buka"
        ' 
        ' SimpanToolStripMenuItem
        ' 
        SimpanToolStripMenuItem.Name = "SimpanToolStripMenuItem"
        SimpanToolStripMenuItem.Size = New Size(145, 26)
        SimpanToolStripMenuItem.Text = "Simpan"
        ' 
        ' PropertiToolStripMenuItem
        ' 
        PropertiToolStripMenuItem.Name = "PropertiToolStripMenuItem"
        PropertiToolStripMenuItem.Size = New Size(145, 26)
        PropertiToolStripMenuItem.Text = "Properti"
        ' 
        ' KeluarToolStripMenuItem
        ' 
        KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        KeluarToolStripMenuItem.Size = New Size(145, 26)
        KeluarToolStripMenuItem.Text = "Keluar"
        ' 
        ' HistogramToolStripMenuItem
        ' 
        HistogramToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {GreyscaleToolStripMenuItem, CerahkanToolStripMenuItem, GelapkanToolStripMenuItem, TambahKontrasToolStripMenuItem, KurangiKontrasToolStripMenuItem, ResetToolStripMenuItem, TampilkanHistogramToolStripMenuItem})
        HistogramToolStripMenuItem.Name = "HistogramToolStripMenuItem"
        HistogramToolStripMenuItem.Size = New Size(93, 24)
        HistogramToolStripMenuItem.Text = "Histogram"
        ' 
        ' GreyscaleToolStripMenuItem
        ' 
        GreyscaleToolStripMenuItem.Name = "GreyscaleToolStripMenuItem"
        GreyscaleToolStripMenuItem.Size = New Size(233, 26)
        GreyscaleToolStripMenuItem.Text = "Greyscale"
        ' 
        ' CerahkanToolStripMenuItem
        ' 
        CerahkanToolStripMenuItem.Name = "CerahkanToolStripMenuItem"
        CerahkanToolStripMenuItem.Size = New Size(233, 26)
        CerahkanToolStripMenuItem.Text = "Cerahkan"
        ' 
        ' GelapkanToolStripMenuItem
        ' 
        GelapkanToolStripMenuItem.Name = "GelapkanToolStripMenuItem"
        GelapkanToolStripMenuItem.Size = New Size(233, 26)
        GelapkanToolStripMenuItem.Text = "Gelapkan"
        ' 
        ' TambahKontrasToolStripMenuItem
        ' 
        TambahKontrasToolStripMenuItem.Name = "TambahKontrasToolStripMenuItem"
        TambahKontrasToolStripMenuItem.Size = New Size(233, 26)
        TambahKontrasToolStripMenuItem.Text = "Tambah Kontras"
        ' 
        ' KurangiKontrasToolStripMenuItem
        ' 
        KurangiKontrasToolStripMenuItem.Name = "KurangiKontrasToolStripMenuItem"
        KurangiKontrasToolStripMenuItem.Size = New Size(233, 26)
        KurangiKontrasToolStripMenuItem.Text = "Kurangi Kontras"
        ' 
        ' ResetToolStripMenuItem
        ' 
        ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        ResetToolStripMenuItem.Size = New Size(233, 26)
        ResetToolStripMenuItem.Text = "Reset"
        ' 
        ' TampilkanHistogramToolStripMenuItem
        ' 
        TampilkanHistogramToolStripMenuItem.Name = "TampilkanHistogramToolStripMenuItem"
        TampilkanHistogramToolStripMenuItem.Size = New Size(233, 26)
        TampilkanHistogramToolStripMenuItem.Text = "Tampilkan Histogram"
        ' 
        ' EffectsToolStripMenuItem
        ' 
        EffectsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {TajamkanToolStripMenuItem, KaburkanToolStripMenuItem, Putar90ToolStripMenuItem, FlipHorizontalToolStripMenuItem, FlipVertikalToolStripMenuItem})
        EffectsToolStripMenuItem.Name = "EffectsToolStripMenuItem"
        EffectsToolStripMenuItem.Size = New Size(67, 24)
        EffectsToolStripMenuItem.Text = "Effects"
        ' 
        ' TajamkanToolStripMenuItem
        ' 
        TajamkanToolStripMenuItem.Name = "TajamkanToolStripMenuItem"
        TajamkanToolStripMenuItem.Size = New Size(190, 26)
        TajamkanToolStripMenuItem.Text = "Tajamkan"
        ' 
        ' KaburkanToolStripMenuItem
        ' 
        KaburkanToolStripMenuItem.Name = "KaburkanToolStripMenuItem"
        KaburkanToolStripMenuItem.Size = New Size(190, 26)
        KaburkanToolStripMenuItem.Text = "Kaburkan"
        ' 
        ' Putar90ToolStripMenuItem
        ' 
        Putar90ToolStripMenuItem.Name = "Putar90ToolStripMenuItem"
        Putar90ToolStripMenuItem.Size = New Size(190, 26)
        Putar90ToolStripMenuItem.Text = "Putar 90°"
        ' 
        ' FlipHorizontalToolStripMenuItem
        ' 
        FlipHorizontalToolStripMenuItem.Name = "FlipHorizontalToolStripMenuItem"
        FlipHorizontalToolStripMenuItem.Size = New Size(190, 26)
        FlipHorizontalToolStripMenuItem.Text = "Flip Horizontal"
        ' 
        ' FlipVertikalToolStripMenuItem
        ' 
        FlipVertikalToolStripMenuItem.Name = "FlipVertikalToolStripMenuItem"
        FlipVertikalToolStripMenuItem.Size = New Size(190, 26)
        FlipVertikalToolStripMenuItem.Text = "Flip Vertikal"
        ' 
        ' Tugas3ToolStripMenuItem
        ' 
        Tugas3ToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {BorderToolStripMenuItem, WatermarkToolStripMenuItem, InversiWarnaToolStripMenuItem, RonaMerahToolStripMenuItem, RonaHijauToolStripMenuItem, RonaBiruToolStripMenuItem, RonaSpesialToolStripMenuItem, HistogramBalokToolStripMenuItem})
        Tugas3ToolStripMenuItem.Name = "Tugas3ToolStripMenuItem"
        Tugas3ToolStripMenuItem.Size = New Size(74, 24)
        Tugas3ToolStripMenuItem.Text = "Tugas 3"
        ' 
        ' BorderToolStripMenuItem
        ' 
        BorderToolStripMenuItem.Name = "BorderToolStripMenuItem"
        BorderToolStripMenuItem.Size = New Size(203, 26)
        BorderToolStripMenuItem.Text = "Border"
        ' 
        ' WatermarkToolStripMenuItem
        ' 
        WatermarkToolStripMenuItem.Name = "WatermarkToolStripMenuItem"
        WatermarkToolStripMenuItem.Size = New Size(203, 26)
        WatermarkToolStripMenuItem.Text = "Watermark"
        ' 
        ' InversiWarnaToolStripMenuItem
        ' 
        InversiWarnaToolStripMenuItem.Name = "InversiWarnaToolStripMenuItem"
        InversiWarnaToolStripMenuItem.Size = New Size(203, 26)
        InversiWarnaToolStripMenuItem.Text = "Inversi Warna"
        ' 
        ' RonaMerahToolStripMenuItem
        ' 
        RonaMerahToolStripMenuItem.Name = "RonaMerahToolStripMenuItem"
        RonaMerahToolStripMenuItem.Size = New Size(203, 26)
        RonaMerahToolStripMenuItem.Text = "Rona Merah"
        ' 
        ' RonaHijauToolStripMenuItem
        ' 
        RonaHijauToolStripMenuItem.Name = "RonaHijauToolStripMenuItem"
        RonaHijauToolStripMenuItem.Size = New Size(203, 26)
        RonaHijauToolStripMenuItem.Text = "Rona Hijau"
        ' 
        ' RonaBiruToolStripMenuItem
        ' 
        RonaBiruToolStripMenuItem.Name = "RonaBiruToolStripMenuItem"
        RonaBiruToolStripMenuItem.Size = New Size(203, 26)
        RonaBiruToolStripMenuItem.Text = "Rona Biru"
        ' 
        ' RonaSpesialToolStripMenuItem
        ' 
        RonaSpesialToolStripMenuItem.Name = "RonaSpesialToolStripMenuItem"
        RonaSpesialToolStripMenuItem.Size = New Size(203, 26)
        RonaSpesialToolStripMenuItem.Text = "Rona Spesial"
        ' 
        ' HistogramBalokToolStripMenuItem
        ' 
        HistogramBalokToolStripMenuItem.Name = "HistogramBalokToolStripMenuItem"
        HistogramBalokToolStripMenuItem.Size = New Size(203, 26)
        HistogramBalokToolStripMenuItem.Text = "Histogram Balok"
        ' 
        ' Tugas3bToolStripMenuItem
        ' 
        Tugas3bToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {UndoToolStripMenuItem, RedoToolStripMenuItem})
        Tugas3bToolStripMenuItem.Name = "Tugas3bToolStripMenuItem"
        Tugas3bToolStripMenuItem.Size = New Size(83, 24)
        Tugas3bToolStripMenuItem.Text = "Tugas 3b"
        ' 
        ' UndoToolStripMenuItem
        ' 
        UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        UndoToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Z
        UndoToolStripMenuItem.Size = New Size(179, 26)
        UndoToolStripMenuItem.Text = "Undo"
        ' 
        ' RedoToolStripMenuItem
        ' 
        RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        RedoToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Y
        RedoToolStripMenuItem.Size = New Size(179, 26)
        RedoToolStripMenuItem.Text = "Redo"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Location = New Point(13, 92)
        PictureBox1.Margin = New Padding(4, 5, 4, 5)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(746, 768)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' btnSelectMode
        ' 
        btnSelectMode.Location = New Point(13, 46)
        btnSelectMode.Margin = New Padding(4, 5, 4, 5)
        btnSelectMode.Name = "btnSelectMode"
        btnSelectMode.Size = New Size(160, 38)
        btnSelectMode.TabIndex = 1
        btnSelectMode.Text = "□ Select Mode OFF"
        ' 
        ' trackBarRed
        ' 
        trackBarRed.Location = New Point(13, 885)
        trackBarRed.Margin = New Padding(4, 5, 4, 5)
        trackBarRed.Maximum = 100
        trackBarRed.Name = "trackBarRed"
        trackBarRed.Size = New Size(233, 56)
        trackBarRed.TabIndex = 3
        trackBarRed.TickFrequency = 10
        trackBarRed.Value = 100
        ' 
        ' trackBarGreen
        ' 
        trackBarGreen.Location = New Point(267, 885)
        trackBarGreen.Margin = New Padding(4, 5, 4, 5)
        trackBarGreen.Maximum = 100
        trackBarGreen.Name = "trackBarGreen"
        trackBarGreen.Size = New Size(233, 56)
        trackBarGreen.TabIndex = 4
        trackBarGreen.TickFrequency = 10
        trackBarGreen.Value = 100
        ' 
        ' trackBarBlue
        ' 
        trackBarBlue.Location = New Point(520, 885)
        trackBarBlue.Margin = New Padding(4, 5, 4, 5)
        trackBarBlue.Maximum = 100
        trackBarBlue.Name = "trackBarBlue"
        trackBarBlue.Size = New Size(233, 56)
        trackBarBlue.TabIndex = 5
        trackBarBlue.TickFrequency = 10
        trackBarBlue.Value = 100
        ' 
        ' lblRed
        ' 
        lblRed.AutoSize = True
        lblRed.Location = New Point(100, 954)
        lblRed.Margin = New Padding(4, 0, 4, 0)
        lblRed.Name = "lblRed"
        lblRed.Size = New Size(35, 20)
        lblRed.TabIndex = 6
        lblRed.Text = "Red"
        ' 
        ' lblGreen
        ' 
        lblGreen.AutoSize = True
        lblGreen.Location = New Point(353, 954)
        lblGreen.Margin = New Padding(4, 0, 4, 0)
        lblGreen.Name = "lblGreen"
        lblGreen.Size = New Size(48, 20)
        lblGreen.TabIndex = 7
        lblGreen.Text = "Green"
        ' 
        ' lblBlue
        ' 
        lblBlue.AutoSize = True
        lblBlue.Location = New Point(607, 954)
        lblBlue.Margin = New Padding(4, 0, 4, 0)
        lblBlue.Name = "lblBlue"
        lblBlue.Size = New Size(38, 20)
        lblBlue.TabIndex = 8
        lblBlue.Text = "Blue"
        ' 
        ' panelLayers
        ' 
        panelLayers.BorderStyle = BorderStyle.FixedSingle
        panelLayers.Controls.Add(lblLayers)
        panelLayers.Controls.Add(btnTambahLayer)
        panelLayers.Controls.Add(btnHapusLayer)
        panelLayers.Controls.Add(btnToggleVisibility)
        panelLayers.Controls.Add(btnMergeKeBawah)
        panelLayers.Controls.Add(btnTambahStiker)
        panelLayers.Controls.Add(btnNaik)
        panelLayers.Controls.Add(btnTurun)
        panelLayers.Controls.Add(listViewLayers)
        panelLayers.Controls.Add(lblActiveLayer)
        panelLayers.Controls.Add(btnRefreshList)
        panelLayers.Location = New Point(773, 46)
        panelLayers.Margin = New Padding(4, 5, 4, 5)
        panelLayers.Name = "panelLayers"
        panelLayers.Size = New Size(273, 907)
        panelLayers.TabIndex = 9
        ' 
        ' lblLayers
        ' 
        lblLayers.AutoSize = True
        lblLayers.Location = New Point(7, 8)
        lblLayers.Margin = New Padding(4, 0, 4, 0)
        lblLayers.Name = "lblLayers"
        lblLayers.Size = New Size(50, 20)
        lblLayers.TabIndex = 0
        lblLayers.Text = "Layers"
        ' 
        ' btnTambahLayer
        ' 
        btnTambahLayer.Location = New Point(7, 38)
        btnTambahLayer.Margin = New Padding(4, 5, 4, 5)
        btnTambahLayer.Name = "btnTambahLayer"
        btnTambahLayer.Size = New Size(253, 43)
        btnTambahLayer.TabIndex = 1
        btnTambahLayer.Text = "+ Tambah Layer"
        ' 
        ' btnHapusLayer
        ' 
        btnHapusLayer.Location = New Point(7, 89)
        btnHapusLayer.Margin = New Padding(4, 5, 4, 5)
        btnHapusLayer.Name = "btnHapusLayer"
        btnHapusLayer.Size = New Size(253, 43)
        btnHapusLayer.TabIndex = 2
        btnHapusLayer.Text = "✕ Hapus Layer"
        ' 
        ' btnToggleVisibility
        ' 
        btnToggleVisibility.Location = New Point(7, 140)
        btnToggleVisibility.Margin = New Padding(4, 5, 4, 5)
        btnToggleVisibility.Name = "btnToggleVisibility"
        btnToggleVisibility.Size = New Size(253, 43)
        btnToggleVisibility.TabIndex = 3
        btnToggleVisibility.Text = "⊙ Toggle Visibility"
        ' 
        ' btnMergeKeBawah
        ' 
        btnMergeKeBawah.Location = New Point(7, 191)
        btnMergeKeBawah.Margin = New Padding(4, 5, 4, 5)
        btnMergeKeBawah.Name = "btnMergeKeBawah"
        btnMergeKeBawah.Size = New Size(253, 43)
        btnMergeKeBawah.TabIndex = 4
        btnMergeKeBawah.Text = "↓ Merge ke Bawah"
        ' 
        ' btnTambahStiker
        ' 
        btnTambahStiker.Location = New Point(7, 242)
        btnTambahStiker.Margin = New Padding(4, 5, 4, 5)
        btnTambahStiker.Name = "btnTambahStiker"
        btnTambahStiker.Size = New Size(253, 43)
        btnTambahStiker.TabIndex = 5
        btnTambahStiker.Text = "☆ Tambah Stiker"
        ' 
        ' btnNaik
        ' 
        btnNaik.Location = New Point(7, 292)
        btnNaik.Margin = New Padding(4, 5, 4, 5)
        btnNaik.Name = "btnNaik"
        btnNaik.Size = New Size(120, 43)
        btnNaik.TabIndex = 6
        btnNaik.Text = "▲ Naik"
        ' 
        ' btnTurun
        ' 
        btnTurun.Location = New Point(133, 292)
        btnTurun.Margin = New Padding(4, 5, 4, 5)
        btnTurun.Name = "btnTurun"
        btnTurun.Size = New Size(120, 43)
        btnTurun.TabIndex = 7
        btnTurun.Text = "▼ Turun"
        ' 
        ' listViewLayers
        ' 
        listViewLayers.Columns.AddRange(New ColumnHeader() {colNama, colVisible})
        listViewLayers.FullRowSelect = True
        listViewLayers.GridLines = True
        listViewLayers.Location = New Point(7, 346)
        listViewLayers.Margin = New Padding(4, 5, 4, 5)
        listViewLayers.Name = "listViewLayers"
        listViewLayers.Size = New Size(252, 459)
        listViewLayers.TabIndex = 0
        listViewLayers.UseCompatibleStateImageBehavior = False
        listViewLayers.View = View.Details
        ' 
        ' colNama
        ' 
        colNama.Text = "Nama"
        colNama.Width = 120
        ' 
        ' colVisible
        ' 
        colVisible.Text = "Visible"
        colVisible.Width = 65
        ' 
        ' lblActiveLayer
        ' 
        lblActiveLayer.AutoSize = True
        lblActiveLayer.Location = New Point(7, 815)
        lblActiveLayer.Margin = New Padding(4, 0, 4, 0)
        lblActiveLayer.Name = "lblActiveLayer"
        lblActiveLayer.Size = New Size(132, 20)
        lblActiveLayer.TabIndex = 8
        lblActiveLayer.Text = "Active Layer: None"
        ' 
        ' btnRefreshList
        ' 
        btnRefreshList.Location = New Point(7, 846)
        btnRefreshList.Margin = New Padding(4, 5, 4, 5)
        btnRefreshList.Name = "btnRefreshList"
        btnRefreshList.Size = New Size(253, 43)
        btnRefreshList.TabIndex = 9
        btnRefreshList.Text = "⟳ Refresh List"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1067, 1000)
        Controls.Add(MenuStrip1)
        Controls.Add(btnSelectMode)
        Controls.Add(PictureBox1)
        Controls.Add(trackBarRed)
        Controls.Add(trackBarGreen)
        Controls.Add(trackBarBlue)
        Controls.Add(lblRed)
        Controls.Add(lblGreen)
        Controls.Add(lblBlue)
        Controls.Add(panelLayers)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(4, 5, 4, 5)
        Name = "Form1"
        Text = "Pengolahan Citra - Multi-Layer Editor"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(trackBarRed, ComponentModel.ISupportInitialize).EndInit()
        CType(trackBarGreen, ComponentModel.ISupportInitialize).EndInit()
        CType(trackBarBlue, ComponentModel.ISupportInitialize).EndInit()
        panelLayers.ResumeLayout(False)
        panelLayers.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    ' Controls Declaration
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BukaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SimpanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeluarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistogramToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GreyscaleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerahkanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GelapkanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TambahKontrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KurangiKontrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TampilkanHistogramToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EffectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TajamkanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KaburkanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Putar90ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlipHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlipVertikalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tugas3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WatermarkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InversiWarnaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RonaMerahToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RonaHijauToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RonaBiruToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RonaSpesialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistogramBalokToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tugas3bToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSelectMode As System.Windows.Forms.Button
    Friend WithEvents trackBarRed As System.Windows.Forms.TrackBar
    Friend WithEvents trackBarGreen As System.Windows.Forms.TrackBar
    Friend WithEvents trackBarBlue As System.Windows.Forms.TrackBar
    Friend WithEvents lblRed As System.Windows.Forms.Label
    Friend WithEvents lblGreen As System.Windows.Forms.Label
    Friend WithEvents lblBlue As System.Windows.Forms.Label
    Friend WithEvents panelLayers As System.Windows.Forms.Panel
    Friend WithEvents lblLayers As System.Windows.Forms.Label
    Friend WithEvents btnTambahLayer As System.Windows.Forms.Button
    Friend WithEvents btnHapusLayer As System.Windows.Forms.Button
    Friend WithEvents btnToggleVisibility As System.Windows.Forms.Button
    Friend WithEvents btnMergeKeBawah As System.Windows.Forms.Button
    Friend WithEvents btnTambahStiker As System.Windows.Forms.Button
    Friend WithEvents btnNaik As System.Windows.Forms.Button
    Friend WithEvents btnTurun As System.Windows.Forms.Button
    Friend WithEvents listViewLayers As System.Windows.Forms.ListView
    Friend WithEvents colNama As System.Windows.Forms.ColumnHeader
    Friend WithEvents colVisible As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblActiveLayer As System.Windows.Forms.Label
    Friend WithEvents btnRefreshList As System.Windows.Forms.Button
End Class
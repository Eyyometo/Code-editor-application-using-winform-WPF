namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            dosyaToolStripMenuItem = new ToolStripMenuItem();
            yeniToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            dosyaAçToolStripMenuItem = new ToolStripMenuItem();
            dosyaKaydetoolStripMenuItem = new ToolStripMenuItem();
            farklıKaydetToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            yazdırToolStripMenuItem = new ToolStripMenuItem();
            yazdırmaÖnizleToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            çıkışToolStripMenuItem = new ToolStripMenuItem();
            biçimToolStripMenuItem = new ToolStripMenuItem();
            geriAlToolStripMenuItem = new ToolStripMenuItem();
            ileriAlToolStripMenuItem = new ToolStripMenuItem();
            hepsiniSeçToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            kesToolStripMenuItem = new ToolStripMenuItem();
            kopyalaToolStripMenuItem = new ToolStripMenuItem();
            yapıştırToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            biçimToolStripMenuItem1 = new ToolStripMenuItem();
            bulToolStripMenuItem = new ToolStripMenuItem();
            gitToolStripMenuItem = new ToolStripMenuItem();
            düzeltToolStripMenuItem = new ToolStripMenuItem();
            kodDiliToolStripMenuItem = new ToolStripMenuItem();
            cToolStripMenuItem = new ToolStripMenuItem();
            cToolStripMenuItem1 = new ToolStripMenuItem();
            cToolStripMenuItem2 = new ToolStripMenuItem();
            pHPToolStripMenuItem = new ToolStripMenuItem();
            jSToolStripMenuItem = new ToolStripMenuItem();
            sQLToolStripMenuItem = new ToolStripMenuItem();
            lUAToolStripMenuItem = new ToolStripMenuItem();
            jSONToolStripMenuItem = new ToolStripMenuItem();
            xMLToolStripMenuItem = new ToolStripMenuItem();
            ayarlarToolStripMenuItem = new ToolStripMenuItem();
            yazıÇeşitiToolStripMenuItem = new ToolStripMenuItem();
            yazıRengiToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripMenuItem1 = new ToolStripMenuItem();
            hakkıdaToolStripMenuItem = new ToolStripMenuItem();
            uygulamaHakkındaToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripButton4 = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripButton5 = new ToolStripButton();
            toolStripButton6 = new ToolStripButton();
            toolStripSeparator8 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            toolStripSeparator9 = new ToolStripSeparator();
            printDialog1 = new PrintDialog();
            colorDialog1 = new ColorDialog();
            fontDialog1 = new FontDialog();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            toolStripContainer1 = new ToolStripContainer();
            fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            CapstoolStripStatusLabel2 = new ToolStripStatusLabel();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dosyaToolStripMenuItem, biçimToolStripMenuItem, kodDiliToolStripMenuItem, ayarlarToolStripMenuItem, hakkıdaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1000, 30);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            dosyaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { yeniToolStripMenuItem, toolStripSeparator1, dosyaAçToolStripMenuItem, dosyaKaydetoolStripMenuItem, farklıKaydetToolStripMenuItem, toolStripSeparator4, yazdırToolStripMenuItem, yazdırmaÖnizleToolStripMenuItem, toolStripSeparator5, çıkışToolStripMenuItem });
            dosyaToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.folder;
            dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            dosyaToolStripMenuItem.Size = new Size(71, 24);
            dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // yeniToolStripMenuItem
            // 
            yeniToolStripMenuItem.BackColor = SystemColors.Control;
            yeniToolStripMenuItem.Image = (Image)resources.GetObject("yeniToolStripMenuItem.Image");
            yeniToolStripMenuItem.Name = "yeniToolStripMenuItem";
            yeniToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            yeniToolStripMenuItem.Size = new Size(235, 26);
            yeniToolStripMenuItem.Text = "Yeni";
            yeniToolStripMenuItem.Click += yeniToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(232, 6);
            // 
            // dosyaAçToolStripMenuItem
            // 
            dosyaAçToolStripMenuItem.Image = (Image)resources.GetObject("dosyaAçToolStripMenuItem.Image");
            dosyaAçToolStripMenuItem.Name = "dosyaAçToolStripMenuItem";
            dosyaAçToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            dosyaAçToolStripMenuItem.Size = new Size(235, 26);
            dosyaAçToolStripMenuItem.Text = "Aç";
            dosyaAçToolStripMenuItem.Click += dosyaAçToolStripMenuItem_Click;
            // 
            // dosyaKaydetoolStripMenuItem
            // 
            dosyaKaydetoolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.save;
            dosyaKaydetoolStripMenuItem.Name = "dosyaKaydetoolStripMenuItem";
            dosyaKaydetoolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            dosyaKaydetoolStripMenuItem.Size = new Size(235, 26);
            dosyaKaydetoolStripMenuItem.Text = "Kaydet";
            dosyaKaydetoolStripMenuItem.Click += dosyaKaydetToolStripMenuItem_Click;
            // 
            // farklıKaydetToolStripMenuItem
            // 
            farklıKaydetToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.app;
            farklıKaydetToolStripMenuItem.Name = "farklıKaydetToolStripMenuItem";
            farklıKaydetToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            farklıKaydetToolStripMenuItem.Size = new Size(235, 26);
            farklıKaydetToolStripMenuItem.Text = "Farklı Kaydet";
            farklıKaydetToolStripMenuItem.Click += farklıKaydetToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(232, 6);
            // 
            // yazdırToolStripMenuItem
            // 
            yazdırToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.printer;
            yazdırToolStripMenuItem.Name = "yazdırToolStripMenuItem";
            yazdırToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            yazdırToolStripMenuItem.Size = new Size(235, 26);
            yazdırToolStripMenuItem.Text = "Yazdır";
            yazdırToolStripMenuItem.Click += yazdırToolStripMenuItem_Click;
            // 
            // yazdırmaÖnizleToolStripMenuItem
            // 
            yazdırmaÖnizleToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.print;
            yazdırmaÖnizleToolStripMenuItem.Name = "yazdırmaÖnizleToolStripMenuItem";
            yazdırmaÖnizleToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.P;
            yazdırmaÖnizleToolStripMenuItem.Size = new Size(235, 26);
            yazdırmaÖnizleToolStripMenuItem.Text = "Yazdırma Önizle";
            yazdırmaÖnizleToolStripMenuItem.Click += yazdırmaÖnizleToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(232, 6);
            // 
            // çıkışToolStripMenuItem
            // 
            çıkışToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.door;
            çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            çıkışToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            çıkışToolStripMenuItem.Size = new Size(235, 26);
            çıkışToolStripMenuItem.Text = "Çıkış";
            çıkışToolStripMenuItem.Click += çıkışToolStripMenuItem_Click;
            // 
            // biçimToolStripMenuItem
            // 
            biçimToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { geriAlToolStripMenuItem, ileriAlToolStripMenuItem, hepsiniSeçToolStripMenuItem, toolStripSeparator2, kesToolStripMenuItem, kopyalaToolStripMenuItem, yapıştırToolStripMenuItem, toolStripSeparator3, biçimToolStripMenuItem1, bulToolStripMenuItem, gitToolStripMenuItem, düzeltToolStripMenuItem });
            biçimToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.contract;
            biçimToolStripMenuItem.Name = "biçimToolStripMenuItem";
            biçimToolStripMenuItem.Size = new Size(72, 24);
            biçimToolStripMenuItem.Text = "Düzen";
            // 
            // geriAlToolStripMenuItem
            // 
            geriAlToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.undo_circular_arrow;
            geriAlToolStripMenuItem.Name = "geriAlToolStripMenuItem";
            geriAlToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            geriAlToolStripMenuItem.Size = new Size(181, 26);
            geriAlToolStripMenuItem.Text = "Geri Al";
            geriAlToolStripMenuItem.Click += geriAlToolStripMenuItem_Click;
            // 
            // ileriAlToolStripMenuItem
            // 
            ileriAlToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.redo_arrow_symbol;
            ileriAlToolStripMenuItem.Name = "ileriAlToolStripMenuItem";
            ileriAlToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            ileriAlToolStripMenuItem.Size = new Size(181, 26);
            ileriAlToolStripMenuItem.Text = "İleri Al";
            ileriAlToolStripMenuItem.Click += ileriAlToolStripMenuItem_Click;
            // 
            // hepsiniSeçToolStripMenuItem
            // 
            hepsiniSeçToolStripMenuItem.Image = (Image)resources.GetObject("hepsiniSeçToolStripMenuItem.Image");
            hepsiniSeçToolStripMenuItem.Name = "hepsiniSeçToolStripMenuItem";
            hepsiniSeçToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            hepsiniSeçToolStripMenuItem.Size = new Size(181, 26);
            hepsiniSeçToolStripMenuItem.Text = "Hepsini Seç";
            hepsiniSeçToolStripMenuItem.Click += hepsiniSeçToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(178, 6);
            // 
            // kesToolStripMenuItem
            // 
            kesToolStripMenuItem.Image = (Image)resources.GetObject("kesToolStripMenuItem.Image");
            kesToolStripMenuItem.Name = "kesToolStripMenuItem";
            kesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            kesToolStripMenuItem.Size = new Size(181, 26);
            kesToolStripMenuItem.Text = "Kes";
            kesToolStripMenuItem.Click += kesToolStripMenuItem_Click;
            // 
            // kopyalaToolStripMenuItem
            // 
            kopyalaToolStripMenuItem.Image = (Image)resources.GetObject("kopyalaToolStripMenuItem.Image");
            kopyalaToolStripMenuItem.Name = "kopyalaToolStripMenuItem";
            kopyalaToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            kopyalaToolStripMenuItem.Size = new Size(181, 26);
            kopyalaToolStripMenuItem.Text = "Kopyala";
            kopyalaToolStripMenuItem.Click += kopyalaToolStripMenuItem_Click;
            // 
            // yapıştırToolStripMenuItem
            // 
            yapıştırToolStripMenuItem.Image = (Image)resources.GetObject("yapıştırToolStripMenuItem.Image");
            yapıştırToolStripMenuItem.Name = "yapıştırToolStripMenuItem";
            yapıştırToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            yapıştırToolStripMenuItem.Size = new Size(181, 26);
            yapıştırToolStripMenuItem.Text = "Yapıştır";
            yapıştırToolStripMenuItem.Click += yapıştırToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(178, 6);
            // 
            // biçimToolStripMenuItem1
            // 
            biçimToolStripMenuItem1.Image = (Image)resources.GetObject("biçimToolStripMenuItem1.Image");
            biçimToolStripMenuItem1.Name = "biçimToolStripMenuItem1";
            biçimToolStripMenuItem1.ShortcutKeys = Keys.F5;
            biçimToolStripMenuItem1.Size = new Size(181, 26);
            biçimToolStripMenuItem1.Text = "Tarih/Zaman";
            biçimToolStripMenuItem1.Click += biçimToolStripMenuItem1_Click;
            // 
            // bulToolStripMenuItem
            // 
            bulToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.search;
            bulToolStripMenuItem.Name = "bulToolStripMenuItem";
            bulToolStripMenuItem.Size = new Size(181, 26);
            bulToolStripMenuItem.Text = "Bul";
            bulToolStripMenuItem.Click += bulToolStripMenuItem_Click;
            // 
            // gitToolStripMenuItem
            // 
            gitToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.right;
            gitToolStripMenuItem.Name = "gitToolStripMenuItem";
            gitToolStripMenuItem.Size = new Size(181, 26);
            gitToolStripMenuItem.Text = "Git";
            gitToolStripMenuItem.Click += gitToolStripMenuItem_Click;
            // 
            // düzeltToolStripMenuItem
            // 
            düzeltToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.technics;
            düzeltToolStripMenuItem.Name = "düzeltToolStripMenuItem";
            düzeltToolStripMenuItem.Size = new Size(181, 26);
            düzeltToolStripMenuItem.Text = "Düzelt";
            düzeltToolStripMenuItem.Click += düzeltToolStripMenuItem_Click;
            // 
            // kodDiliToolStripMenuItem
            // 
            kodDiliToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cToolStripMenuItem, cToolStripMenuItem1, cToolStripMenuItem2, pHPToolStripMenuItem, jSToolStripMenuItem, sQLToolStripMenuItem, lUAToolStripMenuItem, jSONToolStripMenuItem, xMLToolStripMenuItem });
            kodDiliToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.coding__1_;
            kodDiliToolStripMenuItem.Name = "kodDiliToolStripMenuItem";
            kodDiliToolStripMenuItem.Size = new Size(80, 24);
            kodDiliToolStripMenuItem.Text = "Kod Dili";
            // 
            // cToolStripMenuItem
            // 
            cToolStripMenuItem.Name = "cToolStripMenuItem";
            cToolStripMenuItem.Size = new Size(180, 22);
            cToolStripMenuItem.Text = "C#";
            cToolStripMenuItem.Click += cToolStripMenuItem_Click_1;
            // 
            // cToolStripMenuItem1
            // 
            cToolStripMenuItem1.Name = "cToolStripMenuItem1";
            cToolStripMenuItem1.Size = new Size(180, 22);
            cToolStripMenuItem1.Text = "VB";
            cToolStripMenuItem1.Click += cToolStripMenuItem1_Click_1;
            // 
            // cToolStripMenuItem2
            // 
            cToolStripMenuItem2.Name = "cToolStripMenuItem2";
            cToolStripMenuItem2.Size = new Size(180, 22);
            cToolStripMenuItem2.Text = "HTML";
            cToolStripMenuItem2.Click += cToolStripMenuItem2_Click_1;
            // 
            // pHPToolStripMenuItem
            // 
            pHPToolStripMenuItem.Name = "pHPToolStripMenuItem";
            pHPToolStripMenuItem.Size = new Size(180, 22);
            pHPToolStripMenuItem.Text = "PHP";
            pHPToolStripMenuItem.Click += pHPToolStripMenuItem_Click;
            // 
            // jSToolStripMenuItem
            // 
            jSToolStripMenuItem.Name = "jSToolStripMenuItem";
            jSToolStripMenuItem.Size = new Size(180, 22);
            jSToolStripMenuItem.Text = "JS";
            jSToolStripMenuItem.Click += jSToolStripMenuItem_Click;
            // 
            // sQLToolStripMenuItem
            // 
            sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            sQLToolStripMenuItem.Size = new Size(180, 22);
            sQLToolStripMenuItem.Text = "SQL";
            sQLToolStripMenuItem.Click += sQLToolStripMenuItem_Click;
            // 
            // lUAToolStripMenuItem
            // 
            lUAToolStripMenuItem.Name = "lUAToolStripMenuItem";
            lUAToolStripMenuItem.Size = new Size(180, 22);
            lUAToolStripMenuItem.Text = "LUA";
            lUAToolStripMenuItem.Click += lUAToolStripMenuItem_Click;
            // 
            // jSONToolStripMenuItem
            // 
            jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            jSONToolStripMenuItem.Size = new Size(180, 22);
            jSONToolStripMenuItem.Text = "JSON";
            jSONToolStripMenuItem.Click += jSONToolStripMenuItem_Click;
            // 
            // xMLToolStripMenuItem
            // 
            xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            xMLToolStripMenuItem.Size = new Size(180, 22);
            xMLToolStripMenuItem.Text = "XML";
            xMLToolStripMenuItem.Click += xMLToolStripMenuItem_Click;
            // 
            // ayarlarToolStripMenuItem
            // 
            ayarlarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { yazıÇeşitiToolStripMenuItem, yazıRengiToolStripMenuItem, toolStripSeparator6, toolStripMenuItem1 });
            ayarlarToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.setting;
            ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            ayarlarToolStripMenuItem.Size = new Size(69, 24);
            ayarlarToolStripMenuItem.Text = "Biçim";
            // 
            // yazıÇeşitiToolStripMenuItem
            // 
            yazıÇeşitiToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.setting__1_;
            yazıÇeşitiToolStripMenuItem.Name = "yazıÇeşitiToolStripMenuItem";
            yazıÇeşitiToolStripMenuItem.Size = new Size(141, 26);
            yazıÇeşitiToolStripMenuItem.Text = "Yazı Ayarları";
            yazıÇeşitiToolStripMenuItem.Click += yazıÇeşitiToolStripMenuItem_Click;
            // 
            // yazıRengiToolStripMenuItem
            // 
            yazıRengiToolStripMenuItem.Name = "yazıRengiToolStripMenuItem";
            yazıRengiToolStripMenuItem.Size = new Size(141, 26);
            yazıRengiToolStripMenuItem.Text = "Yazı Rengi";
            yazıRengiToolStripMenuItem.Click += yazıRengiToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(138, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Image = MetinMertBiyikoglu.Properties.Resources.paper;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(141, 26);
            toolStripMenuItem1.Text = "Sayfa Rengi";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // hakkıdaToolStripMenuItem
            // 
            hakkıdaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uygulamaHakkındaToolStripMenuItem });
            hakkıdaToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.info;
            hakkıdaToolStripMenuItem.Name = "hakkıdaToolStripMenuItem";
            hakkıdaToolStripMenuItem.Size = new Size(82, 24);
            hakkıdaToolStripMenuItem.Text = "Hakkıda";
            // 
            // uygulamaHakkındaToolStripMenuItem
            // 
            uygulamaHakkındaToolStripMenuItem.Image = MetinMertBiyikoglu.Properties.Resources.info;
            uygulamaHakkındaToolStripMenuItem.Name = "uygulamaHakkındaToolStripMenuItem";
            uygulamaHakkındaToolStripMenuItem.Size = new Size(185, 26);
            uygulamaHakkındaToolStripMenuItem.Text = "Uygulama Hakkında";
            uygulamaHakkındaToolStripMenuItem.Click += uygulamaHakkındaToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton4, toolStripSeparator7, toolStripButton5, toolStripButton6, toolStripSeparator8, toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton7, toolStripSeparator9 });
            toolStrip1.Location = new Point(3, 30);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(198, 27);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = MetinMertBiyikoglu.Properties.Resources.save;
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(24, 24);
            toolStripButton4.Text = "Kaydet";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 27);
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Image = MetinMertBiyikoglu.Properties.Resources.undo_circular_arrow;
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(24, 24);
            toolStripButton5.Text = "Geri Al";
            toolStripButton5.Click += toolStripButton5_Click;
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton6.Image = MetinMertBiyikoglu.Properties.Resources.redo_arrow_symbol;
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(24, 24);
            toolStripButton6.Text = "İleri Al";
            toolStripButton6.Click += toolStripButton6_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 27);
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(24, 24);
            toolStripButton1.Text = "Kes";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(24, 24);
            toolStripButton2.Text = "Kopyala";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(24, 24);
            toolStripButton3.Text = "Yapıştır";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton7
            // 
            toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton7.Image = MetinMertBiyikoglu.Properties.Resources.select;
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(24, 24);
            toolStripButton7.Text = "Hepsini Seç";
            toolStripButton7.Click += toolStripButton7_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(6, 27);
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "TextDocument.txt";
            saveFileDialog1.Title = "Kaydet";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.AutoScroll = true;
            toolStripContainer1.ContentPanel.Controls.Add(fastColoredTextBox1);
            toolStripContainer1.ContentPanel.Controls.Add(statusStrip1);
            toolStripContainer1.ContentPanel.Margin = new Padding(4);
            toolStripContainer1.ContentPanel.Size = new Size(1000, 484);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.LeftToolStripPanelVisible = false;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Margin = new Padding(4);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.RightToolStripPanelVisible = false;
            toolStripContainer1.Size = new Size(1000, 541);
            toolStripContainer1.TabIndex = 3;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip1);
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            // 
            // fastColoredTextBox1
            // 
            fastColoredTextBox1.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            fastColoredTextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            fastColoredTextBox1.AutoScrollMinSize = new Size(0, 14);
            fastColoredTextBox1.BackBrush = null;
            fastColoredTextBox1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            fastColoredTextBox1.CharHeight = 14;
            fastColoredTextBox1.CharWidth = 8;
            fastColoredTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBox1.Dock = DockStyle.Fill;
            fastColoredTextBox1.Font = new Font("Courier New", 9.75F);
            fastColoredTextBox1.Hotkeys = resources.GetString("fastColoredTextBox1.Hotkeys");
            fastColoredTextBox1.IsReplaceMode = false;
            fastColoredTextBox1.LeftBracket = '(';
            fastColoredTextBox1.LeftBracket2 = '{';
            fastColoredTextBox1.LineNumberColor = SystemColors.ControlDarkDark;
            fastColoredTextBox1.LineNumberStartValue = 0U;
            fastColoredTextBox1.Location = new Point(0, 0);
            fastColoredTextBox1.Name = "fastColoredTextBox1";
            fastColoredTextBox1.Paddings = new Padding(0);
            fastColoredTextBox1.RightBracket = ')';
            fastColoredTextBox1.RightBracket2 = '}';
            fastColoredTextBox1.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            fastColoredTextBox1.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("fastColoredTextBox1.ServiceColors");
            fastColoredTextBox1.ShowLineNumbers = false;
            fastColoredTextBox1.Size = new Size(1000, 462);
            fastColoredTextBox1.TabIndex = 2;
            fastColoredTextBox1.WordWrap = true;
            fastColoredTextBox1.Zoom = 100;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, CapstoolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 462);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1000, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "CAPS ON";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // CapstoolStripStatusLabel2
            // 
            CapstoolStripStatusLabel2.Name = "CapstoolStripStatusLabel2";
            CapstoolStripStatusLabel2.Size = new Size(0, 17);
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 541);
            Controls.Add(toolStripContainer1);
            Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Kod Editörü";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.ContentPanel.PerformLayout();
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dosyaToolStripMenuItem;
        private ToolStripMenuItem yeniToolStripMenuItem;
        private ToolStripMenuItem dosyaAçToolStripMenuItem;
        private ToolStripMenuItem dosyaKaydetoolStripMenuItem;
        private ToolStripMenuItem çıkışToolStripMenuItem;
        private ToolStripMenuItem biçimToolStripMenuItem;
        private ToolStripMenuItem kesToolStripMenuItem;
        private ToolStripMenuItem kopyalaToolStripMenuItem;
        private ToolStripMenuItem yapıştırToolStripMenuItem;
        private ToolStripMenuItem ayarlarToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem yazıÇeşitiToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private PrintDialog printDialog1;
        private ColorDialog colorDialog1;
        private FontDialog fontDialog1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripButton toolStripButton3;
        private ToolStripMenuItem ileriAlToolStripMenuItem;
        private ToolStripMenuItem geriAlToolStripMenuItem;
        private ToolStripMenuItem hepsiniSeçToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem biçimToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripContainer toolStripContainer1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem farklıKaydetToolStripMenuItem;
        private ToolStripMenuItem yazdırToolStripMenuItem;
        private ToolStripMenuItem yazdırmaÖnizleToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem hakkıdaToolStripMenuItem;
        private ToolStripMenuItem uygulamaHakkındaToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel CapstoolStripStatusLabel2;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripButton toolStripButton4;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton toolStripButton7;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem yazıRengiToolStripMenuItem;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private ToolStripMenuItem bulToolStripMenuItem;
        private ToolStripMenuItem gitToolStripMenuItem;
        private ToolStripMenuItem düzeltToolStripMenuItem;
        private ToolStripMenuItem kodDiliToolStripMenuItem;
        private ToolStripMenuItem cToolStripMenuItem;
        private ToolStripMenuItem cToolStripMenuItem1;
        private ToolStripMenuItem cToolStripMenuItem2;
        private ToolStripMenuItem pHPToolStripMenuItem;
        private ToolStripMenuItem jSToolStripMenuItem;
        private ToolStripMenuItem sQLToolStripMenuItem;
        private ToolStripMenuItem lUAToolStripMenuItem;
        private ToolStripMenuItem jSONToolStripMenuItem;
        private ToolStripMenuItem xMLToolStripMenuItem;
    }
}

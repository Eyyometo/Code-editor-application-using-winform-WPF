using System.Security.Cryptography.X509Certificates; // X.509 sertifikalar�n� y�netmek i�in kullan�l�r.
using System.Windows.Forms; // Windows uygulamalar� geli�tirmek i�in kullan�lan temel k�t�phane.
using static System.Windows.Forms.VisualStyles.VisualStyleElement; // G�r�n�mler �zerinde de�i�iklik yapmak i�in kullan�l�r.
using System.IO; // Dosya ve dizin i�lemleri i�in kullan�l�r.
using System.Text; // Metin kodlama ve d�n��t�rme i�lemleri i�in kullan�l�r.
using System.Drawing.Printing; // Yaz�c� i�lemleri i�in kullan�l�r.
using System.IO.Packaging; // Open Packaging Conventions (OPC) dosyalar�n� i�lemek i�in kullan�l�r.
using System.Drawing; // Grafiklerle ilgili i�lemler i�in kullan�l�r.
using System.Drawing.Imaging; // G�r�nt� dosyalar�n� i�lemek i�in kullan�l�r.
using System.Drawing.Text; // Sistem fontlar�na eri�mek ve �zelle�tirmek i�in kullan�l�r.
using System.ComponentModel; // Bile�en tabanl� programlama ve veri ba�lama i�lemleri i�in kullan�l�r.
using System.Linq; // LINQ (Language Integrated Query) ifadeleri olu�turmak i�in kullan�l�r.
using System.Threading.Tasks; // E� zamanl� i�lemler ve g�revler olu�turmak i�in kullan�l�r.
using Microsoft.CSharp; // C# kodu derlemek i�in kullan�l�r.
using System.CodeDom.Compiler; // Kod derleme i�lemleri i�in kullan�l�r.
using System.CodeDom; // Kod olu�turma ve i�leme i�lemleri i�in kullan�l�r.
using System.IO; // Dosya ve dizin i�lemleri i�in kullan�l�r.
using ScintillaNET; // Metin d�zenleme kontrol� i�in kullan�l�r.
using System.Text.RegularExpressions; // D�zenli ifadelerle metin arama ve de�i�tirme i�lemleri i�in kullan�l�r.
using Microsoft.VisualBasic; // Visual Basic kodu derlemek ve �al��t�rmak i�in kullan�l�r.
using FastColoredTextBoxNS; // H�zl� renkli metin d�zenleme i�in kullan�l�r.
using Microsoft.CodeAnalysis; // Microsoft'un program analizi platformu i�in kullan�l�r.





//Metin Mert B�y�ko�lu -E235013169




namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Yaz� tipi se�im ile ilgili ileti�im kutusu
        FontDialog fontDialog = new FontDialog();

        // dosya i�lemleri i�in kullan�lacak nesneler.
        private bool dosyaKayitli;
        private bool dosyaGuncelle;
        private string seciliDosyaIsmi;
        public int k = 0;

        // Yazd�rma i�lemlerini y�netmek i�in kullan�lan nesneler.
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public Form1()
        {

            InitializeComponent();

            // Ba�lang��ta "Dosyay� Kaydediniz." metnini g�ster
            toolStripStatusLabel1.Text = "Dosyay� Kaydediniz.";

            // Yazd�rma belgesi olu�tur
            printDocument = new PrintDocument();

            // Yazd�rma belgesi olaylar�
            printDocument.PrintPage += printDocument1_PrintPage;

            // Yazd�rma �nizleme ileti�im kutusunu olu�tur ve belgeyi ata
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;


        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Metni kesme i�lemi
            fastColoredTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Metni kopyalama i�lemi
            fastColoredTextBox1.Copy();
        }

        private void yap��t�rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Metni yap��t�rma i�lemi
            fastColoredTextBox1.Paste();
        }
        private void yaz��e�itiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Yaz� tipi se�im ile ilgili ileti�im kutusunu a�

            fontDialog.ShowApply = true; // Uygula butonunu g�ster
            fontDialog.Apply += new System.EventHandler(font_Uygula_Dialog); // Uygula butonu t�kland���nda olay� tan�mla

            // Yaz� tipi ile ilgili ileti�im kutusunu g�ster ve kullan�c�n�n se�imini al
            DialogResult result = fontDialog.ShowDialog();

            // Kullan�c� se�imini de�erlendir
            if (result == DialogResult.OK)
            {
                // Metinde bir se�im yap�lm�� m� kontrol et
                if (fastColoredTextBox1.SelectionLength > 0)
                {
                    // Se�ili metnin yaz� tipini ve rengini de�i�tir
                    fastColoredTextBox1.Font = fontDialog.Font;


                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Metni kesme i�lemi
            fastColoredTextBox1.Cut();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Metni yap��t�rma i�lemi
            fastColoredTextBox1.Copy();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Geri alma ve ileri alma i�levlerini devre d��� b�rak
            ileriAlToolStripMenuItem.Enabled = false;
            geriAlToolStripMenuItem.Enabled = false;

            // E�er dosya g�ncellendi ise
            if (dosyaGuncelle)
            {
                // Kullan�c�ya de�i�iklikleri kaydetmek isteyip istemedi�ini sor
                DialogResult result = MessageBox.Show("De�i�ikleri kaydet?", "Dosyay� Kaydet", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        // Dosyay� kaydetme ve g�ncelleme i�lemi
                        DosyaKayitGuncelle();
                        break;

                    case DialogResult.No:
                        // Ekran� temizleme i�lemi
                        Ekran�Temizle();
                        break;
                }
            }
            else
            {
                // E�er dosya g�ncellenmemi�se, ekran� temizle
                Ekran�Temizle();
            }

            // Geri alma ve ileri alma i�levlerini tekrar devre d��� b�rak
            geriAlToolStripMenuItem.Enabled = false;
            ileriAlToolStripMenuItem.Enabled = false;

            // Durum �ubu�una "Yeni Dosya Olu�turuldu." mesaj�n� g�ster
            toolStripStatusLabel1.Text = "Yeni Dosya Olu�turuldu.";
        }

        private void dosyaKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Dosyay� kaydetme i�lemi
            DosyaKayitGuncelle();

            // Durum �ubu�una "Dosya Kaydedildi." mesaj�n� g�ster
            toolStripStatusLabel1.Text = "Dosya Kaydedildi.";

        }

        private void DosyaKayitGuncelle()
        {
            // E�er dosya daha �nce kaydedilmi�se
            if (dosyaKayitli)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                // Dosya uzant�s�na g�re farkl� kaydetme i�lemleri yap
                if (Path.GetExtension(seciliDosyaIsmi) == ".txt")
                {
                    // Metni d�z metin olarak kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                    

                }
                if (Path.GetExtension(seciliDosyaIsmi) == ".rtf")
                {
                    // Metni zengin metin format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                    
                }

                // Dosya g�ncelleme i�lemini tamamla
                dosyaGuncelle = false;

            }
            else
            {
                // Dosya daha �nce kaydedilmediyse
                if (dosyaGuncelle)
                {
                    // Dosyay� kaydetme i�lemi
                    DosyaKaydet();
                }
                else
                {
                    // Ekran� temizleme i�lemi
                    Ekran�Temizle();
                }

            }
        }

        private void Ekran�Temizle()
        {
            // Metin kutusunu temizle
            fastColoredTextBox1.Clear();

            // Dosya g�ncelleme i�aret�isini false olarak ayarla
            dosyaGuncelle = false;

            // Form ba�l���n� varsay�lan olarak ayarla
            this.Text = "Not Defteri";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            // Geri alma i�levini etkinle�tir
            geriAlToolStripMenuItem.Enabled = true;

            // Geri alma i�levini etkinle�tir
            dosyaGuncelle = true;

        }

        private void ��k��ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // E�er dosya g�ncellendi ise
            if (dosyaGuncelle)
            {
                // Kullan�c�ya de�i�iklikleri kaydetmek isteyip istemedi�ini sor
                DialogResult result = MessageBox.Show("De�i�ikleri kaydet?", "Dosyay� Kaydet", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:

                        // Dosyay� kaydetme ve ��k�� i�lemi
                        DosyaKayitGuncelle();
                        break;

                    case DialogResult.No:

                        // Uygulamadan ��k
                        Application.Exit();
                        break;
                }
            }
            else
            {
                // E�er dosya g�ncellenmediyse, uygulamadan ��k
                Application.Exit();

            }

        }

        private void yaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Yaz� rengi se�me ileti�im kutusunu g�ster
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            DialogResult result = fontDialog.ShowDialog();

            // Kullan�c�n�n se�imini de�erlendir
            if (result == DialogResult.OK)
            {
                // E�er bir metin se�ilmi�se
                if (fastColoredTextBox1.SelectionLength > 0)
                {
                    // Se�ili metnin rengini de�i�tir
                    fastColoredTextBox1.SelectionColor = fontDialog.Color;
                }
            }
        }

        private void zeminRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Zemin rengi ileti�im kutusunu g�ster ve kullan�c�n�n se�ti�i rengi metin kutusunun arka plan rengi olarak ayarla
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                fastColoredTextBox1.BackColor = colorDialog1.Color;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form y�klendi�inde ba�lang�� de�erlerini ayarla

            // Dosyan�n kaydedilip kaydedilmedi�i bilgisini s�f�rla
            dosyaKayitli = false;

            // Dosyan�n g�ncellenip g�ncellenmedi�i bilgisini s�f�rla
            dosyaGuncelle = false;

            // Se�ili dosya ismini bo� bir dize olarak ayarla
            seciliDosyaIsmi = "";

            // Caps Lock tu�unun durumunu kontrol et
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                // E�er Caps Lock a��ksa durum �ubu�una "CAPS ON" mesaj�n� g�ster
                CapstoolStripStatusLabel2.Text = "CAPS ON";
            }
            else
            {
                // E�er Caps Lock kapal�ysa durum �ubu�una "caps off" mesaj�n� g�ster
                CapstoolStripStatusLabel2.Text = "caps off";

            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Metni yap��t�r
            fastColoredTextBox1.Paste();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form kapat�lmaya �al���ld���nda dosya g�ncellenmi�se kullan�c�ya kaydetme se�ene�i sun



            if (dosyaGuncelle)
            {
                // Dosya g�ncellenmi�se
                DialogResult result = MessageBox.Show("De�i�ikleri kaydet?", "Dosyay� Kaydet", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        // Dosyay� kaydet ve formu kapat
                        DosyaKayitGuncelle();
                        break;
                    case DialogResult.No:
                        // Kaydetme se�ene�i olmadan formu kapat
                        e.Cancel = false;
                        break;
                }
            }
            else
            {
                // Dosya g�ncellenmediyse formu kapat
                e.Cancel = false;
            }



        }

        private void dosyaA�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Geri alma ve ileri alma i�levlerini devre d��� b�rak
            ileriAlToolStripMenuItem.Enabled = false;
            geriAlToolStripMenuItem.Enabled = false;

            // E�er dosya g�ncellenmi�se
            if (dosyaGuncelle)
            {
                // Kullan�c�ya de�i�iklikleri kaydetmek isteyip istemedi�ini sor
                DialogResult result = MessageBox.Show("De�i�ikleri kaydet?", "Dosyay� Kaydet", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        // Dosyay� kaydet ve dosya a�ma i�lemine devam et
                        DosyaKayitGuncelle();
                        break;

                    // Dosyay� kaydetmeden dosya a�ma i�lemine devam et
                    case DialogResult.No:
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Metin Dosyalar�(*.txt)|*.txt|Zengin Metin Dosyalar� (*.rtf)|*.rtf|C# (*.cs)|*.cs|VB (*.vb)|*.vb|HTML (*.html)|*.html|PHP (*.php)|*.php|JS (*.js)|*.js|SQL (*.sql)|*.sql|LUA (*.lua)|*.lua|JSON (*.json)|*.json|XML (*.xml)|*.xml";
                        DialogResult result1 = openFileDialog.ShowDialog();

                        if (result1 == DialogResult.OK)
                        {
                            // Dosya uzant�s�na g�re farkl� kaydetme i�lemleri yap
                            if (Path.GetExtension(openFileDialog.FileName) == ".txt")
                            {
                                // Metni d�z metin olarak kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".rtf")
                            {
                                // Metni zengin metin format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                           
                            if (Path.GetExtension(openFileDialog.FileName) == ".cs")
                            {
                                // Metni cs format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".vb")
                            {
                                // Metni vb format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();

                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".html")
                            {
                                // Metni html format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".php")
                            {
                                // Metni pho format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".js")
                            {
                                // Metni js format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".sql")
                            {
                                // Metni sql format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".lua")
                            {
                                // Metni lua format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".json")
                            {
                                // Metni json format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".xml")
                            {
                                // Metni xml format�nda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }


                        }
                        // Form ba�l���n� g�ncelle
                        this.Text = Path.GetFileName(openFileDialog.FileName) + " -Not Defteri";

                        // Dosyan�n kaydedildi�i bilgisini g�ncelle
                        dosyaKayitli = true;

                        // Dosyan�n g�ncellendi�i bilgisini s�f�rla
                        dosyaGuncelle = false;

                        // Se�ili dosya ad�n� g�ncelle
                        seciliDosyaIsmi = openFileDialog.FileName;

                        // Durum �ubu�una mesaj g�ster
                        toolStripStatusLabel1.Text = "Dosya A��ld�.";
                        break;
                }
            }
            else
            {

                // E�er dosya g�ncellenmediyse dosya a�ma i�lemine devam et
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Metin Dosyalar�(*.txt)|*.txt|Zengin Metin Dosyalar� (*.rtf)|*.rtf|C# (*.cs)|*.cs|VB (*.vb)|*.vb|HTML (*.html)|*.html|PHP (*.php)|*.php|JS (*.js)|*.js|SQL (*.sql)|*.sql|LUA (*.lua)|*.lua|JSON (*.json)|*.json|XML (*.xml)|*.xml";
                DialogResult result1 = openFileDialog.ShowDialog();

                if (result1 == DialogResult.OK)
                {
                    // Dosya uzant�s�na g�re farkl� kaydetme i�lemleri yap
                    if (Path.GetExtension(openFileDialog.FileName) == ".txt")
                    {
                        // Metni d�z metin olarak kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".rtf")
                    {
                        // Metni zengin metin format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }

                    if (Path.GetExtension(openFileDialog.FileName) == ".cs")
                    {
                        // Metni cs format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".vb")
                    {
                        // Metni vb format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();

                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".html")
                    {
                        // Metni html format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".php")
                    {
                        // Metni pho format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".js")
                    {
                        // Metni js format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".sql")
                    {
                        // Metni sql format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".lua")
                    {
                        // Metni lua format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".json")
                    {
                        // Metni json format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".xml")
                    {
                        // Metni xml format�nda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }


                }

                // Form ba�l���n� g�ncelle
                this.Text = Path.GetFileName(openFileDialog.FileName) + " -Not Defteri";

                // Dosyan�n kaydedildi�i bilgisini g�ncelle
                dosyaKayitli = true;

                // Dosyan�n g�ncellendi�i bilgisini s�f�rla
                dosyaGuncelle = false;

                // Se�ili dosya ad�n� g�ncelle
                seciliDosyaIsmi = openFileDialog.FileName;

                // Durum �ubu�una mesaj g�ster
                toolStripStatusLabel1.Text = "Dosya A��ld�.";
            }

        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // "Geri Al" men� ��esine t�kland���nda

            // Metin kutusunda geri alma i�lemini ger�ekle�tir
            fastColoredTextBox1.Undo();

            // "Geri Al" ��esini devre d��� b�rak
            geriAlToolStripMenuItem.Enabled = false;

            // "�leri Al" ��esini etkinle�tir
            ileriAlToolStripMenuItem.Enabled = true;
        }

        private void ileriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "�leri Al" men� ��esine t�kland���nda

            // Metin kutusunda ileri alma i�lemini ger�ekle�tir
            fastColoredTextBox1.Redo();

            // "�leri Al" ��esini devre d��� b�rak
            ileriAlToolStripMenuItem.Enabled = false;

            // "Geri Al" ��esini etkinle�tir
            geriAlToolStripMenuItem.Enabled = true;
        }

        private void bi�imToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            // "Bi�im" men�s�ndeki "Tarih ve Saat Ekle" ��esine t�kland���nda

            // Metin kutusunun se�ili metin k�sm�n� mevcut tarih ve saatle de�i�tir
            fastColoredTextBox1.SelectedText = DateTime.Now.ToString();
        }

        private void hepsiniSe�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Hepsini Se�" men� ��esine t�kland���nda

            // Metin kutusunda t�m metni se�
            fastColoredTextBox1.SelectAll();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // "Arka Plan Rengi De�i�tir" men� ��esine t�kland���nda

            // E�er renk se�im ileti�im kutusu ba�ar�l� bir �ekilde tamamland�ysa
            if (colorDialog1.ShowDialog() == DialogResult.OK)

                // Metin kutusunun arka plan rengini se�ilen renge ayarla
                fastColoredTextBox1.BackColor = colorDialog1.Color;

        }

        private void uygulamaHakk�ndaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Uygulama Hakk�nda" men� ��esine t�kland���nda

            // Kullan�c�ya uygulama hakk�nda bilgi veren bir ileti�im kutusu g�ster
            MessageBox.Show("Bu Uygulama Metin Mert B�y�ko�lu Taraf�ndan Geli�tirilmi�tir.", "Kod Edit�r�", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void farkl�KaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Farkl� Kaydet" men� ��esine t�kland���nda

            // Dosyay� kaydetme i�lemini ger�ekle�tir
            DosyaKaydet();


        }

        private void DosyaKaydet()
        {

            // Dosyay� kaydetme i�lemini ger�ekle�tiren metod

            // Dosya kaydetme ileti�im kutusunu olu�tur
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Dosya filtrelerini belirle
            saveFileDialog.Filter = "Metin Dosyalar�(*.txt)|*.txt|Zengin Metin Dosyalar� (*.rtf)|*.rtf|Exe (*.exe)|*.exe|C# (*.cs)|*.cs|VB (*.vb)|*.vb|HTML (*.html)|*.html|PHP (*.php)|*.php|JS (*.js)|*.js|SQL (*.sql)|*.sql|LUA (*.lua)|*.lua|JSON (*.json)|*.json|XML (*.xml)|*.xml";

            // Dosya kaydetme ileti�im kutusunu g�ster ve sonucunu al
            DialogResult savefileresult = saveFileDialog.ShowDialog();


            // E�er kullan�c� dosyay� kaydetmek isterse
            if (savefileresult == DialogResult.OK)
            {
                k = 1;

                // Dosya uzant�s�na g�re farkl� kaydetme i�lemleri yap
                if (Path.GetExtension(saveFileDialog.FileName) == ".txt")
                {
                    // Metni d�z metin olarak kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".rtf")
                {
                    // Metni zengin metin format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                    //fastColoredTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".exe")
                {
                    // Metni exe format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".cs")
                {
                    // Metni cs format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }

                if (Path.GetExtension(saveFileDialog.FileName) == ".vb")
                {
                    // Metni VB format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".html")
                {
                    // Metni html format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".php")
                {
                    // Metni php format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".sql")
                {
                    // Metni sql format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".lua")
                {
                    // Metni lua format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".json")
                {
                    // Metni json format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".js")
                {
                    // Metni js format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".xml")
                {
                    // Metni xml format�nda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }


            }

            // Form ba�l���n� g�ncelle
            this.Text = Path.GetFileName(saveFileDialog.FileName) + " -Not Defteri";

            // Dosyan�n kaydedildi�i bilgisini g�ncelle
            dosyaKayitli = true;

            // Dosyan�n g�ncellendi�i bilgisini s�f�rla
            dosyaGuncelle = false;

            // Se�ili dosya ad�n� g�ncelle
            seciliDosyaIsmi = saveFileDialog.FileName;
        }
        private void font_Uygula_Dialog(object sender, EventArgs e)
        {

            // Yaz� tipi uygulama ileti�im kutusunun Uygula olay� tetiklendi�inde

            // E�er metin kutusunda bir metin se�iliyse
            if (fastColoredTextBox1.SelectionLength > 0)
            {

                // Se�ili metnin yaz� tipini ve rengini yaz� tipi ileti�im kutusundan gelen de�erlerle ayarla
                fastColoredTextBox1.Font = fontDialog.Font;
                //fastColoredTextBox1.ForeColor = fontDialog.Color;



            }
        }
        
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            // Metin kutusunda bir tu�a bas�ld���nda

            // Caps Lock tu�u etkinle�tirilmi�se
            if (Control.IsKeyLocked(Keys.CapsLock))
            {

                // Durum �ubu�unda "CAPS ON" mesaj�n� g�ster
                CapstoolStripStatusLabel2.Text = "CAPS ON";
            }
            else
            {

                // Caps Lock tu�u etkin de�ilse
                // Durum �ubu�unda "caps off" mesaj�n� g�ster
                CapstoolStripStatusLabel2.Text = "caps off";

            }
        }

        private void yazd�rToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // "Yazd�r" men� ��esine t�kland���nda

            // Yazd�rma ileti�im kutusunu olu�tur ve belgeyi belirle
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            // Yazd�rma ileti�im kutusunu g�ster ve kullan�c�n�n se�imine g�re belgeyi yazd�r
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Belge yazd�r�lmak �zere ayarland���nda

            // Formun g�r�nt�s�n� bir bit e�lemi olarak olu�tur
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));

            // Olu�turulan bit e�lemi �zerine belgeyi �iz
            e.Graphics.DrawImage(bitmap, 0, 0);

            // Kullan�lan kaynaklar� serbest b�rak
            bitmap.Dispose();
        }

        private void yaz�ArkaplanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // "Yaz� Arkaplan Rengi" men� ��esine t�kland���nda

            //Renk ileti�im kutusunu olu�tur
            ColorDialog colorDialog = new ColorDialog();

            //E�er renk ileti�im kutusu ba�ar�l� bir �ekilde tamamland�ysa
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

            //Metin kutusunda se�ili metnin arka plan rengini se�ilen renge ayarla
            fastColoredTextBox1.BackColor= colorDialog.Color;



            }
        }

        private void yazd�rma�nizleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // "Yazd�rma �nizleme" men� ��esine t�kland���nda

            // Yazd�rma �nizleme ileti�im kutusunu g�ster
            printPreviewDialog.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            // "Kaydet" ara� �ubu�u d��mesine t�kland���nda

            // Dosya kaydetme i�lemini ger�ekle�tir ve durum �ubu�unda bilgilendirme g�ster
            DosyaKayitGuncelle();
            toolStripStatusLabel1.Text = "Dosya Kaydedildi.";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            // "Geri Al" ara� �ubu�u d��mesine t�kland���nda

            // Metin kutusunda geri alma i�lemini ger�ekle�tir
            fastColoredTextBox1.Undo();

            // "Geri Al" d��mesini devre d��� b�rak ve "�leri Al" d��mesini etkinle�tir
            geriAlToolStripMenuItem.Enabled = false;
            ileriAlToolStripMenuItem.Enabled = true;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            // "�leri Al" ara� �ubu�u d��mesine t�kland���nda

            // Metin kutusunda ileri alma i�lemini ger�ekle�tir
            fastColoredTextBox1.Redo();

            // "�leri Al" d��mesini devre d��� b�rak ve "Geri Al" d��mesini etkinle�tir
            ileriAlToolStripMenuItem.Enabled = false;
            geriAlToolStripMenuItem.Enabled = true;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            // "Hepsini Se�" ara� �ubu�u d��mesine t�kland���nda

            // Metin kutusunda t�m metni se�
            fastColoredTextBox1.SelectAll();
        }
        private void yaz�RengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Yaz� Rengi" men� ��esine t�kland���nda

            // Renk ileti�im kutusunu olu�tur
            ColorDialog colorDialog = new ColorDialog();

            // E�er renk ileti�im kutusu ba�ar�l� bir �ekilde tamamland�ysa
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

                // Metin kutusunda se�ili metnin rengini se�ilen renge ayarla
                fastColoredTextBox1.ForeColor = colorDialog.Color;
            }
        }

        private void bulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // H�zl� arama diyalo�unu g�sterir
            fastColoredTextBox1.ShowFindDialog();
        }

        private void gitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gitme diyalo�unu g�sterir
            fastColoredTextBox1.ShowGoToDialog();
        }

        private void d�zeltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // De�i�tirme diyalo�unu g�sterir
            fastColoredTextBox1.ShowReplaceDialog();
        }

        private void cToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // C# dilini belirler
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void cToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            // Visual Basic dilini belirler
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
        }

        private void cToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            // HTML dilini belirler
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // PHP dilini belirler
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
        }

        private void jSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // JavaScript dilini belirler
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // SQL dilini belirler
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
        }

        private void lUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Lua dilini belirler
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // JSON dilini belirler
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JSON;
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // XML dilini belirler
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.XML;
        }
    }
}

        
    
   





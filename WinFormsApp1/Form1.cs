using System.Security.Cryptography.X509Certificates; // X.509 sertifikalarýný yönetmek için kullanýlýr.
using System.Windows.Forms; // Windows uygulamalarý geliþtirmek için kullanýlan temel kütüphane.
using static System.Windows.Forms.VisualStyles.VisualStyleElement; // Görünümler üzerinde deðiþiklik yapmak için kullanýlýr.
using System.IO; // Dosya ve dizin iþlemleri için kullanýlýr.
using System.Text; // Metin kodlama ve dönüþtürme iþlemleri için kullanýlýr.
using System.Drawing.Printing; // Yazýcý iþlemleri için kullanýlýr.
using System.IO.Packaging; // Open Packaging Conventions (OPC) dosyalarýný iþlemek için kullanýlýr.
using System.Drawing; // Grafiklerle ilgili iþlemler için kullanýlýr.
using System.Drawing.Imaging; // Görüntü dosyalarýný iþlemek için kullanýlýr.
using System.Drawing.Text; // Sistem fontlarýna eriþmek ve özelleþtirmek için kullanýlýr.
using System.ComponentModel; // Bileþen tabanlý programlama ve veri baðlama iþlemleri için kullanýlýr.
using System.Linq; // LINQ (Language Integrated Query) ifadeleri oluþturmak için kullanýlýr.
using System.Threading.Tasks; // Eþ zamanlý iþlemler ve görevler oluþturmak için kullanýlýr.
using Microsoft.CSharp; // C# kodu derlemek için kullanýlýr.
using System.CodeDom.Compiler; // Kod derleme iþlemleri için kullanýlýr.
using System.CodeDom; // Kod oluþturma ve iþleme iþlemleri için kullanýlýr.
using System.IO; // Dosya ve dizin iþlemleri için kullanýlýr.
using ScintillaNET; // Metin düzenleme kontrolü için kullanýlýr.
using System.Text.RegularExpressions; // Düzenli ifadelerle metin arama ve deðiþtirme iþlemleri için kullanýlýr.
using Microsoft.VisualBasic; // Visual Basic kodu derlemek ve çalýþtýrmak için kullanýlýr.
using FastColoredTextBoxNS; // Hýzlý renkli metin düzenleme için kullanýlýr.
using Microsoft.CodeAnalysis; // Microsoft'un program analizi platformu için kullanýlýr.





//Metin Mert Býyýkoðlu -E235013169




namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Yazý tipi seçim ile ilgili iletiþim kutusu
        FontDialog fontDialog = new FontDialog();

        // dosya iþlemleri için kullanýlacak nesneler.
        private bool dosyaKayitli;
        private bool dosyaGuncelle;
        private string seciliDosyaIsmi;
        public int k = 0;

        // Yazdýrma iþlemlerini yönetmek için kullanýlan nesneler.
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;

        public Form1()
        {

            InitializeComponent();

            // Baþlangýçta "Dosyayý Kaydediniz." metnini göster
            toolStripStatusLabel1.Text = "Dosyayý Kaydediniz.";

            // Yazdýrma belgesi oluþtur
            printDocument = new PrintDocument();

            // Yazdýrma belgesi olaylarý
            printDocument.PrintPage += printDocument1_PrintPage;

            // Yazdýrma önizleme iletiþim kutusunu oluþtur ve belgeyi ata
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;


        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Metni kesme iþlemi
            fastColoredTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Metni kopyalama iþlemi
            fastColoredTextBox1.Copy();
        }

        private void yapýþtýrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Metni yapýþtýrma iþlemi
            fastColoredTextBox1.Paste();
        }
        private void yazýÇeþitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Yazý tipi seçim ile ilgili iletiþim kutusunu aç

            fontDialog.ShowApply = true; // Uygula butonunu göster
            fontDialog.Apply += new System.EventHandler(font_Uygula_Dialog); // Uygula butonu týklandýðýnda olayý tanýmla

            // Yazý tipi ile ilgili iletiþim kutusunu göster ve kullanýcýnýn seçimini al
            DialogResult result = fontDialog.ShowDialog();

            // Kullanýcý seçimini deðerlendir
            if (result == DialogResult.OK)
            {
                // Metinde bir seçim yapýlmýþ mý kontrol et
                if (fastColoredTextBox1.SelectionLength > 0)
                {
                    // Seçili metnin yazý tipini ve rengini deðiþtir
                    fastColoredTextBox1.Font = fontDialog.Font;


                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Metni kesme iþlemi
            fastColoredTextBox1.Cut();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Metni yapýþtýrma iþlemi
            fastColoredTextBox1.Copy();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Geri alma ve ileri alma iþlevlerini devre dýþý býrak
            ileriAlToolStripMenuItem.Enabled = false;
            geriAlToolStripMenuItem.Enabled = false;

            // Eðer dosya güncellendi ise
            if (dosyaGuncelle)
            {
                // Kullanýcýya deðiþiklikleri kaydetmek isteyip istemediðini sor
                DialogResult result = MessageBox.Show("Deðiþikleri kaydet?", "Dosyayý Kaydet", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        // Dosyayý kaydetme ve güncelleme iþlemi
                        DosyaKayitGuncelle();
                        break;

                    case DialogResult.No:
                        // Ekraný temizleme iþlemi
                        EkranýTemizle();
                        break;
                }
            }
            else
            {
                // Eðer dosya güncellenmemiþse, ekraný temizle
                EkranýTemizle();
            }

            // Geri alma ve ileri alma iþlevlerini tekrar devre dýþý býrak
            geriAlToolStripMenuItem.Enabled = false;
            ileriAlToolStripMenuItem.Enabled = false;

            // Durum çubuðuna "Yeni Dosya Oluþturuldu." mesajýný göster
            toolStripStatusLabel1.Text = "Yeni Dosya Oluþturuldu.";
        }

        private void dosyaKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Dosyayý kaydetme iþlemi
            DosyaKayitGuncelle();

            // Durum çubuðuna "Dosya Kaydedildi." mesajýný göster
            toolStripStatusLabel1.Text = "Dosya Kaydedildi.";

        }

        private void DosyaKayitGuncelle()
        {
            // Eðer dosya daha önce kaydedilmiþse
            if (dosyaKayitli)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                // Dosya uzantýsýna göre farklý kaydetme iþlemleri yap
                if (Path.GetExtension(seciliDosyaIsmi) == ".txt")
                {
                    // Metni düz metin olarak kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                    

                }
                if (Path.GetExtension(seciliDosyaIsmi) == ".rtf")
                {
                    // Metni zengin metin formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                    
                }

                // Dosya güncelleme iþlemini tamamla
                dosyaGuncelle = false;

            }
            else
            {
                // Dosya daha önce kaydedilmediyse
                if (dosyaGuncelle)
                {
                    // Dosyayý kaydetme iþlemi
                    DosyaKaydet();
                }
                else
                {
                    // Ekraný temizleme iþlemi
                    EkranýTemizle();
                }

            }
        }

        private void EkranýTemizle()
        {
            // Metin kutusunu temizle
            fastColoredTextBox1.Clear();

            // Dosya güncelleme iþaretçisini false olarak ayarla
            dosyaGuncelle = false;

            // Form baþlýðýný varsayýlan olarak ayarla
            this.Text = "Not Defteri";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            // Geri alma iþlevini etkinleþtir
            geriAlToolStripMenuItem.Enabled = true;

            // Geri alma iþlevini etkinleþtir
            dosyaGuncelle = true;

        }

        private void çýkýþToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Eðer dosya güncellendi ise
            if (dosyaGuncelle)
            {
                // Kullanýcýya deðiþiklikleri kaydetmek isteyip istemediðini sor
                DialogResult result = MessageBox.Show("Deðiþikleri kaydet?", "Dosyayý Kaydet", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:

                        // Dosyayý kaydetme ve çýkýþ iþlemi
                        DosyaKayitGuncelle();
                        break;

                    case DialogResult.No:

                        // Uygulamadan çýk
                        Application.Exit();
                        break;
                }
            }
            else
            {
                // Eðer dosya güncellenmediyse, uygulamadan çýk
                Application.Exit();

            }

        }

        private void yaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Yazý rengi seçme iletiþim kutusunu göster
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            DialogResult result = fontDialog.ShowDialog();

            // Kullanýcýnýn seçimini deðerlendir
            if (result == DialogResult.OK)
            {
                // Eðer bir metin seçilmiþse
                if (fastColoredTextBox1.SelectionLength > 0)
                {
                    // Seçili metnin rengini deðiþtir
                    fastColoredTextBox1.SelectionColor = fontDialog.Color;
                }
            }
        }

        private void zeminRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Zemin rengi iletiþim kutusunu göster ve kullanýcýnýn seçtiði rengi metin kutusunun arka plan rengi olarak ayarla
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                fastColoredTextBox1.BackColor = colorDialog1.Color;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklendiðinde baþlangýç deðerlerini ayarla

            // Dosyanýn kaydedilip kaydedilmediði bilgisini sýfýrla
            dosyaKayitli = false;

            // Dosyanýn güncellenip güncellenmediði bilgisini sýfýrla
            dosyaGuncelle = false;

            // Seçili dosya ismini boþ bir dize olarak ayarla
            seciliDosyaIsmi = "";

            // Caps Lock tuþunun durumunu kontrol et
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                // Eðer Caps Lock açýksa durum çubuðuna "CAPS ON" mesajýný göster
                CapstoolStripStatusLabel2.Text = "CAPS ON";
            }
            else
            {
                // Eðer Caps Lock kapalýysa durum çubuðuna "caps off" mesajýný göster
                CapstoolStripStatusLabel2.Text = "caps off";

            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Metni yapýþtýr
            fastColoredTextBox1.Paste();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form kapatýlmaya çalýþýldýðýnda dosya güncellenmiþse kullanýcýya kaydetme seçeneði sun



            if (dosyaGuncelle)
            {
                // Dosya güncellenmiþse
                DialogResult result = MessageBox.Show("Deðiþikleri kaydet?", "Dosyayý Kaydet", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        // Dosyayý kaydet ve formu kapat
                        DosyaKayitGuncelle();
                        break;
                    case DialogResult.No:
                        // Kaydetme seçeneði olmadan formu kapat
                        e.Cancel = false;
                        break;
                }
            }
            else
            {
                // Dosya güncellenmediyse formu kapat
                e.Cancel = false;
            }



        }

        private void dosyaAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Geri alma ve ileri alma iþlevlerini devre dýþý býrak
            ileriAlToolStripMenuItem.Enabled = false;
            geriAlToolStripMenuItem.Enabled = false;

            // Eðer dosya güncellenmiþse
            if (dosyaGuncelle)
            {
                // Kullanýcýya deðiþiklikleri kaydetmek isteyip istemediðini sor
                DialogResult result = MessageBox.Show("Deðiþikleri kaydet?", "Dosyayý Kaydet", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        // Dosyayý kaydet ve dosya açma iþlemine devam et
                        DosyaKayitGuncelle();
                        break;

                    // Dosyayý kaydetmeden dosya açma iþlemine devam et
                    case DialogResult.No:
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Metin Dosyalarý(*.txt)|*.txt|Zengin Metin Dosyalarý (*.rtf)|*.rtf|C# (*.cs)|*.cs|VB (*.vb)|*.vb|HTML (*.html)|*.html|PHP (*.php)|*.php|JS (*.js)|*.js|SQL (*.sql)|*.sql|LUA (*.lua)|*.lua|JSON (*.json)|*.json|XML (*.xml)|*.xml";
                        DialogResult result1 = openFileDialog.ShowDialog();

                        if (result1 == DialogResult.OK)
                        {
                            // Dosya uzantýsýna göre farklý kaydetme iþlemleri yap
                            if (Path.GetExtension(openFileDialog.FileName) == ".txt")
                            {
                                // Metni düz metin olarak kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".rtf")
                            {
                                // Metni zengin metin formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                           
                            if (Path.GetExtension(openFileDialog.FileName) == ".cs")
                            {
                                // Metni cs formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".vb")
                            {
                                // Metni vb formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();

                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".html")
                            {
                                // Metni html formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".php")
                            {
                                // Metni pho formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".js")
                            {
                                // Metni js formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".sql")
                            {
                                // Metni sql formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".lua")
                            {
                                // Metni lua formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".json")
                            {
                                // Metni json formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }
                            if (Path.GetExtension(openFileDialog.FileName) == ".xml")
                            {
                                // Metni xml formatýnda kaydet
                                StreamReader sr = new StreamReader(openFileDialog.FileName);
                                fastColoredTextBox1.Text = sr.ReadToEnd();
                            }


                        }
                        // Form baþlýðýný güncelle
                        this.Text = Path.GetFileName(openFileDialog.FileName) + " -Not Defteri";

                        // Dosyanýn kaydedildiði bilgisini güncelle
                        dosyaKayitli = true;

                        // Dosyanýn güncellendiði bilgisini sýfýrla
                        dosyaGuncelle = false;

                        // Seçili dosya adýný güncelle
                        seciliDosyaIsmi = openFileDialog.FileName;

                        // Durum çubuðuna mesaj göster
                        toolStripStatusLabel1.Text = "Dosya Açýldý.";
                        break;
                }
            }
            else
            {

                // Eðer dosya güncellenmediyse dosya açma iþlemine devam et
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Metin Dosyalarý(*.txt)|*.txt|Zengin Metin Dosyalarý (*.rtf)|*.rtf|C# (*.cs)|*.cs|VB (*.vb)|*.vb|HTML (*.html)|*.html|PHP (*.php)|*.php|JS (*.js)|*.js|SQL (*.sql)|*.sql|LUA (*.lua)|*.lua|JSON (*.json)|*.json|XML (*.xml)|*.xml";
                DialogResult result1 = openFileDialog.ShowDialog();

                if (result1 == DialogResult.OK)
                {
                    // Dosya uzantýsýna göre farklý kaydetme iþlemleri yap
                    if (Path.GetExtension(openFileDialog.FileName) == ".txt")
                    {
                        // Metni düz metin olarak kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".rtf")
                    {
                        // Metni zengin metin formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }

                    if (Path.GetExtension(openFileDialog.FileName) == ".cs")
                    {
                        // Metni cs formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".vb")
                    {
                        // Metni vb formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();

                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".html")
                    {
                        // Metni html formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".php")
                    {
                        // Metni pho formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".js")
                    {
                        // Metni js formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".sql")
                    {
                        // Metni sql formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".lua")
                    {
                        // Metni lua formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".json")
                    {
                        // Metni json formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }
                    if (Path.GetExtension(openFileDialog.FileName) == ".xml")
                    {
                        // Metni xml formatýnda kaydet
                        StreamReader sr = new StreamReader(openFileDialog.FileName);
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                    }


                }

                // Form baþlýðýný güncelle
                this.Text = Path.GetFileName(openFileDialog.FileName) + " -Not Defteri";

                // Dosyanýn kaydedildiði bilgisini güncelle
                dosyaKayitli = true;

                // Dosyanýn güncellendiði bilgisini sýfýrla
                dosyaGuncelle = false;

                // Seçili dosya adýný güncelle
                seciliDosyaIsmi = openFileDialog.FileName;

                // Durum çubuðuna mesaj göster
                toolStripStatusLabel1.Text = "Dosya Açýldý.";
            }

        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // "Geri Al" menü öðesine týklandýðýnda

            // Metin kutusunda geri alma iþlemini gerçekleþtir
            fastColoredTextBox1.Undo();

            // "Geri Al" öðesini devre dýþý býrak
            geriAlToolStripMenuItem.Enabled = false;

            // "Ýleri Al" öðesini etkinleþtir
            ileriAlToolStripMenuItem.Enabled = true;
        }

        private void ileriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Ýleri Al" menü öðesine týklandýðýnda

            // Metin kutusunda ileri alma iþlemini gerçekleþtir
            fastColoredTextBox1.Redo();

            // "Ýleri Al" öðesini devre dýþý býrak
            ileriAlToolStripMenuItem.Enabled = false;

            // "Geri Al" öðesini etkinleþtir
            geriAlToolStripMenuItem.Enabled = true;
        }

        private void biçimToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            // "Biçim" menüsündeki "Tarih ve Saat Ekle" öðesine týklandýðýnda

            // Metin kutusunun seçili metin kýsmýný mevcut tarih ve saatle deðiþtir
            fastColoredTextBox1.SelectedText = DateTime.Now.ToString();
        }

        private void hepsiniSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Hepsini Seç" menü öðesine týklandýðýnda

            // Metin kutusunda tüm metni seç
            fastColoredTextBox1.SelectAll();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // "Arka Plan Rengi Deðiþtir" menü öðesine týklandýðýnda

            // Eðer renk seçim iletiþim kutusu baþarýlý bir þekilde tamamlandýysa
            if (colorDialog1.ShowDialog() == DialogResult.OK)

                // Metin kutusunun arka plan rengini seçilen renge ayarla
                fastColoredTextBox1.BackColor = colorDialog1.Color;

        }

        private void uygulamaHakkýndaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Uygulama Hakkýnda" menü öðesine týklandýðýnda

            // Kullanýcýya uygulama hakkýnda bilgi veren bir iletiþim kutusu göster
            MessageBox.Show("Bu Uygulama Metin Mert Býyýkoðlu Tarafýndan Geliþtirilmiþtir.", "Kod Editörü", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void farklýKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Farklý Kaydet" menü öðesine týklandýðýnda

            // Dosyayý kaydetme iþlemini gerçekleþtir
            DosyaKaydet();


        }

        private void DosyaKaydet()
        {

            // Dosyayý kaydetme iþlemini gerçekleþtiren metod

            // Dosya kaydetme iletiþim kutusunu oluþtur
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Dosya filtrelerini belirle
            saveFileDialog.Filter = "Metin Dosyalarý(*.txt)|*.txt|Zengin Metin Dosyalarý (*.rtf)|*.rtf|Exe (*.exe)|*.exe|C# (*.cs)|*.cs|VB (*.vb)|*.vb|HTML (*.html)|*.html|PHP (*.php)|*.php|JS (*.js)|*.js|SQL (*.sql)|*.sql|LUA (*.lua)|*.lua|JSON (*.json)|*.json|XML (*.xml)|*.xml";

            // Dosya kaydetme iletiþim kutusunu göster ve sonucunu al
            DialogResult savefileresult = saveFileDialog.ShowDialog();


            // Eðer kullanýcý dosyayý kaydetmek isterse
            if (savefileresult == DialogResult.OK)
            {
                k = 1;

                // Dosya uzantýsýna göre farklý kaydetme iþlemleri yap
                if (Path.GetExtension(saveFileDialog.FileName) == ".txt")
                {
                    // Metni düz metin olarak kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".rtf")
                {
                    // Metni zengin metin formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                    //fastColoredTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".exe")
                {
                    // Metni exe formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".cs")
                {
                    // Metni cs formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }

                if (Path.GetExtension(saveFileDialog.FileName) == ".vb")
                {
                    // Metni VB formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".html")
                {
                    // Metni html formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".php")
                {
                    // Metni php formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".sql")
                {
                    // Metni sql formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".lua")
                {
                    // Metni lua formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".json")
                {
                    // Metni json formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".js")
                {
                    // Metni js formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".xml")
                {
                    // Metni xml formatýnda kaydet
                    StreamWriter sr = new StreamWriter(saveFileDialog.FileName);
                    sr.Write(fastColoredTextBox1.Text);
                    sr.Close();
                }


            }

            // Form baþlýðýný güncelle
            this.Text = Path.GetFileName(saveFileDialog.FileName) + " -Not Defteri";

            // Dosyanýn kaydedildiði bilgisini güncelle
            dosyaKayitli = true;

            // Dosyanýn güncellendiði bilgisini sýfýrla
            dosyaGuncelle = false;

            // Seçili dosya adýný güncelle
            seciliDosyaIsmi = saveFileDialog.FileName;
        }
        private void font_Uygula_Dialog(object sender, EventArgs e)
        {

            // Yazý tipi uygulama iletiþim kutusunun Uygula olayý tetiklendiðinde

            // Eðer metin kutusunda bir metin seçiliyse
            if (fastColoredTextBox1.SelectionLength > 0)
            {

                // Seçili metnin yazý tipini ve rengini yazý tipi iletiþim kutusundan gelen deðerlerle ayarla
                fastColoredTextBox1.Font = fontDialog.Font;
                //fastColoredTextBox1.ForeColor = fontDialog.Color;



            }
        }
        
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            // Metin kutusunda bir tuþa basýldýðýnda

            // Caps Lock tuþu etkinleþtirilmiþse
            if (Control.IsKeyLocked(Keys.CapsLock))
            {

                // Durum çubuðunda "CAPS ON" mesajýný göster
                CapstoolStripStatusLabel2.Text = "CAPS ON";
            }
            else
            {

                // Caps Lock tuþu etkin deðilse
                // Durum çubuðunda "caps off" mesajýný göster
                CapstoolStripStatusLabel2.Text = "caps off";

            }
        }

        private void yazdýrToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // "Yazdýr" menü öðesine týklandýðýnda

            // Yazdýrma iletiþim kutusunu oluþtur ve belgeyi belirle
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            // Yazdýrma iletiþim kutusunu göster ve kullanýcýnýn seçimine göre belgeyi yazdýr
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Belge yazdýrýlmak üzere ayarlandýðýnda

            // Formun görüntüsünü bir bit eþlemi olarak oluþtur
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));

            // Oluþturulan bit eþlemi üzerine belgeyi çiz
            e.Graphics.DrawImage(bitmap, 0, 0);

            // Kullanýlan kaynaklarý serbest býrak
            bitmap.Dispose();
        }

        private void yazýArkaplanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // "Yazý Arkaplan Rengi" menü öðesine týklandýðýnda

            //Renk iletiþim kutusunu oluþtur
            ColorDialog colorDialog = new ColorDialog();

            //Eðer renk iletiþim kutusu baþarýlý bir þekilde tamamlandýysa
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

            //Metin kutusunda seçili metnin arka plan rengini seçilen renge ayarla
            fastColoredTextBox1.BackColor= colorDialog.Color;



            }
        }

        private void yazdýrmaÖnizleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // "Yazdýrma Önizleme" menü öðesine týklandýðýnda

            // Yazdýrma önizleme iletiþim kutusunu göster
            printPreviewDialog.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            // "Kaydet" araç çubuðu düðmesine týklandýðýnda

            // Dosya kaydetme iþlemini gerçekleþtir ve durum çubuðunda bilgilendirme göster
            DosyaKayitGuncelle();
            toolStripStatusLabel1.Text = "Dosya Kaydedildi.";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            // "Geri Al" araç çubuðu düðmesine týklandýðýnda

            // Metin kutusunda geri alma iþlemini gerçekleþtir
            fastColoredTextBox1.Undo();

            // "Geri Al" düðmesini devre dýþý býrak ve "Ýleri Al" düðmesini etkinleþtir
            geriAlToolStripMenuItem.Enabled = false;
            ileriAlToolStripMenuItem.Enabled = true;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            // "Ýleri Al" araç çubuðu düðmesine týklandýðýnda

            // Metin kutusunda ileri alma iþlemini gerçekleþtir
            fastColoredTextBox1.Redo();

            // "Ýleri Al" düðmesini devre dýþý býrak ve "Geri Al" düðmesini etkinleþtir
            ileriAlToolStripMenuItem.Enabled = false;
            geriAlToolStripMenuItem.Enabled = true;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            // "Hepsini Seç" araç çubuðu düðmesine týklandýðýnda

            // Metin kutusunda tüm metni seç
            fastColoredTextBox1.SelectAll();
        }
        private void yazýRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // "Yazý Rengi" menü öðesine týklandýðýnda

            // Renk iletiþim kutusunu oluþtur
            ColorDialog colorDialog = new ColorDialog();

            // Eðer renk iletiþim kutusu baþarýlý bir þekilde tamamlandýysa
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

                // Metin kutusunda seçili metnin rengini seçilen renge ayarla
                fastColoredTextBox1.ForeColor = colorDialog.Color;
            }
        }

        private void bulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hýzlý arama diyaloðunu gösterir
            fastColoredTextBox1.ShowFindDialog();
        }

        private void gitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gitme diyaloðunu gösterir
            fastColoredTextBox1.ShowGoToDialog();
        }

        private void düzeltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Deðiþtirme diyaloðunu gösterir
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

        
    
   





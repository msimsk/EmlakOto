using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmlakOto
{
    public partial class Konut : Form
    {
        #region değişkenler
        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        #endregion

        public Konut()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        //Başlangıçta çalışır
        private void Form1_Load(object sender, EventArgs e)
        {
            #region buton ekleme
            //datagridview a güncelle butonu ekliyoruz.
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgvKonutlar.Columns.Add(btn);
            btn.Text = "Güncelle";
            btn.Name = "btn";
            btn.HeaderText = "";
            btn.UseColumnTextForButtonValue = true;
            //dgv sil butonu ekleme
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgvKonutlar.Columns.Add(btn1);
            btn1.Text = "Sil";
            btn1.Name = "sil";
            btn1.HeaderText = "";
            btn1.UseColumnTextForButtonValue = true;
            //dgv alıcı butonu ekleme
            dgvKonutlar.Columns.Add(btn2);
            btn2.Text = "Sat";
            btn2.Name = "sat";
            btn2.HeaderText = "";
            btn2.UseColumnTextForButtonValue = true;
            #endregion

            //İlçeler Çekme
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpIlceCek";
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                cmbIlce.Items.Add(reader[0].ToString());
            }
            sqlBaglantisi.Baglanti().Close();

            //odaları comboboxa atama
            SqlCommand komut2 = new SqlCommand();
            komut2.Connection = sqlBaglantisi.Baglanti();
            komut2.CommandType = CommandType.StoredProcedure;
            komut2.CommandText = "SpOdaCek";
            SqlDataReader reader1 = komut2.ExecuteReader();
            while (reader1.Read())
            {
                cmbOda.Items.Add(reader1[0].ToString());
            }
            sqlBaglantisi.Baglanti().Close();

            KonutEkle konutEkle = new KonutEkle();
            konutEkle.Hide();

            baslangic();
        }

        //başlangoç fonksiyounu
        private void baslangic()
        {
            dgvKonutlar.Width = 1510;

            cmbSatilik.SelectedIndex = -1;
            cmbIlce.SelectedIndex = -1;
            //default olarak satılmayanları çekme
            btnSatildimi.Text = "Satılmayanlar";
            dgvSatilanlar(cmbSatilik.Text);
        }

        #region ComboBoxlar ile arama kısmı
        private string[] bolunmusAdres1;
        private char ayrac = '/';
        private string yapilanislemvarmi;

        //ilçe tıklanma olayı
        private void CmbIlce_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (yapilanislemvarmi != "yok")
            {
                //İlçeye göre Mahalle Ekleme
                cmbMahalle.Items.Clear();
                SqlCommand komut = new SqlCommand();
                komut.Connection = sqlBaglantisi.Baglanti();
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpMahalleCek";
                komut.Parameters.Add("@ilceAd", SqlDbType.NVarChar, 30).Value = cmbIlce.Text;
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    cmbMahalle.Items.Add(reader[0].ToString());
                }
                sqlBaglantisi.Baglanti().Close();

                //ilçede bulunan konutları çekme
                for (int i = 0; i < (dgvKonutlar.Rows.Count); i++)
                {
                    dgvKonutlar.Rows[i].Visible = true;
                }

                for (int i = 0; i < (dgvKonutlar.Rows.Count); i++)
                {
                    bolunmusAdres1 = dgvKonutlar.Rows[i].Cells[5].Value.ToString().Split(ayrac);
                    if (bolunmusAdres1[3] != cmbIlce.Text)
                    {
                        adresGizle(i);
                    }
                }

                //cmb leri temizleme
                yapilanislemvarmi = "yok";
                cmbMahalle.SelectedIndex = -1;
                cmbSokak.SelectedIndex = -1;
                cmbOda.SelectedIndex = -1;
                yapilanislemvarmi = "var";
            }
        }

        //Mahalleye tıklanma olayı
        private void CmbMahalle_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (yapilanislemvarmi != "yok")
            {
                //mahalleye göre sokak çekme
                cmbSokak.Items.Clear();
                SqlCommand komut = new SqlCommand() {
                    Connection = sqlBaglantisi.Baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "SpSokakCek"
                };
                komut.Parameters.Add("@mahalleAd", SqlDbType.NVarChar, 50).Value = cmbMahalle.Text;
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    cmbSokak.Items.Add(reader[0].ToString());
                }
                sqlBaglantisi.Baglanti().Close();

                //Mahallede bulunan konutları çekme
                for (int i = 0; i < (dgvKonutlar.Rows.Count); i++)
                {
                    dgvKonutlar.Rows[i].Visible = true;
                }

                for (int i = 0; i < (dgvKonutlar.Rows.Count); i++)
                {
                    bolunmusAdres1 = dgvKonutlar.Rows[i].Cells[5].Value.ToString().Split(ayrac);
                    if (bolunmusAdres1[2] != cmbMahalle.Text || bolunmusAdres1[3] != cmbIlce.Text)
                    {
                        adresGizle(i);
                    }
                }

                //cmbleri temizleme
                yapilanislemvarmi = "yok";
                cmbSokak.SelectedIndex = -1;
                cmbOda.SelectedIndex = -1;
                yapilanislemvarmi = "var";
            }
        }

        //sokağa tıklanma olayı
        private void CmbSokak_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (yapilanislemvarmi != "yok")
            {
                //Sokağa göre konutları çekme
                for (int i = 0; i < (dgvKonutlar.Rows.Count); i++)
                {
                    dgvKonutlar.Rows[i].Visible = true;
                }

                for (int i = 0; i < (dgvKonutlar.Rows.Count); i++)
                {
                    bolunmusAdres1 = dgvKonutlar.Rows[i].Cells[5].Value.ToString().Split(ayrac);
                    if (bolunmusAdres1[1] != cmbSokak.Text || bolunmusAdres1[2] != cmbMahalle.Text || bolunmusAdres1[3] != cmbIlce.Text)
                    {
                        adresGizle(i);
                    }
                }

                //cmbodayi temizleme
                yapilanislemvarmi = "yok";
                cmbOda.SelectedIndex = -1;
                yapilanislemvarmi = "var";
            }
        }

        //oda comboboxa tıklanma olayı
        private void CmbOda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yapilanislemvarmi != "yok")
            {
                //odaya göre konutları çekme
                for (int i = 0; i < (dgvKonutlar.Rows.Count); i++)
                {
                    dgvKonutlar.Rows[i].Visible = true;
                }

                for (int i = 0; i < (dgvKonutlar.Rows.Count); i++)
                {
                    bolunmusAdres1 = dgvKonutlar.Rows[i].Cells[5].Value.ToString().Split(ayrac);
                    if (cmbIlce.Text != "")
                    {
                        if (cmbMahalle.Text != "")
                        {
                            if (cmbSokak.Text != "")
                            {
                                if (dgvKonutlar.Rows[i].Cells[7].Value.ToString() != cmbOda.Text || bolunmusAdres1[1] != cmbSokak.Text || bolunmusAdres1[2] != cmbMahalle.Text || bolunmusAdres1[3] != cmbIlce.Text)
                                {
                                    adresGizle(i);
                                }
                            }
                            else if (dgvKonutlar.Rows[i].Cells[7].Value.ToString() != cmbOda.Text || bolunmusAdres1[3] != cmbIlce.Text || bolunmusAdres1[2] != cmbMahalle.Text)
                            {
                                adresGizle(i);
                            }
                        }
                        else if (dgvKonutlar.Rows[i].Cells[7].Value.ToString() != cmbOda.Text || bolunmusAdres1[3] != cmbIlce.Text)
                        {
                            adresGizle(i);
                        }

                    }
                    else if (dgvKonutlar.Rows[i].Cells[7].Value.ToString() != cmbOda.Text)
                    {
                        adresGizle(i);
                    }
                }
            }
        }

        //satılık comboxsına kısmına tıklandığında
        private void CmbSatilik_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dgvSatilanlar(cmbSatilik.Text);

            // comboları temizleme
            yapilanislemvarmi = "yok";
            cmbIlce.SelectedIndex = -1;
            cmbMahalle.SelectedIndex = -1;
            cmbSokak.SelectedIndex = -1;
            cmbOda.SelectedIndex = -1;
            yapilanislemvarmi = "var";
        }
        #endregion

        //veriler
        private string id, aciklama, ilce, mahalle, sokak, odaTip, satilik, kat, tip, metrekare, kisi, konutAdi, konutKatSayisi, konutYasi, fiyat, bahce, bodrum, ebeveynBanyo, alici, degisken;

        //dgvKonutar tablosuna tıklanma olayı
        private void DgvKonutlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgvKonutlar.SelectedCells[0].RowIndex;
            veriAta(secilen);

            //güncellemeye tıklama olayı
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                KonutEkle konutEkle = new KonutEkle();

                //Güncelleme
                konutEkle.id = id;
                konutEkle.aciklama = aciklama; ;
                konutEkle.ilce = ilce;
                konutEkle.mahalle = mahalle;
                konutEkle.sokak = sokak;
                konutEkle.odaTip = odaTip;
                konutEkle.satilik = satilik;
                konutEkle.kat = kat;
                konutEkle.tip = tip;
                konutEkle.metrekare = metrekare;
                konutEkle.kisi = kisi;
                konutEkle.konutAdi = konutAdi;
                konutEkle.konutKatSayisi = konutKatSayisi;
                konutEkle.konutYasi = konutYasi;
                konutEkle.fiyat = fiyat;
                konutEkle.bahce = bahce;
                konutEkle.bodrum = bodrum;
                konutEkle.ebeveynBanyo = ebeveynBanyo;



                konutEkle.Show();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Konut Silinecek!!! Emin misin? bak son çare...", "Tehlike", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    SqlCommand komut1 = new SqlCommand();
                    komut1.Connection = sqlBaglantisi.Baglanti();
                    komut1.CommandType = CommandType.StoredProcedure;
                    komut1.CommandText = "SpKonutSil";
                    komut1.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(id);
                    komut1.ExecuteNonQuery();
                    sqlBaglantisi.Baglanti().Close();
                }
            }
            else if (e.ColumnIndex == 2 && e.RowIndex != -1)
            {
                AliciEkle aliciEkle = new AliciEkle();
                if (btnSatildimi.Text == "Satılmayanlar")
                {
                    aliciSaticiEkle(aliciEkle, secilen);
                    aliciEkle.yapilacakIslem = "sat";
                    aliciEkle.alici = alici;
                    aliciEkle.Show();
                }
                else
                {
                    aliciEkle.konutSat(Convert.ToInt64(id), " ", "");
                    MessageBox.Show("Alıcı Kaldırıldı..)", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //güncelleme dışında bir yere dokununca
            else if (e.RowIndex != -1)
            {
                AliciEkle aliciEkle = new AliciEkle();
                aliciSaticiEkle(aliciEkle, secilen);
                if (btnSatildimi.Text == "Satılmayanlar")
                {
                    aliciEkle.yapilacakIslem = "aliciekle";
                }
                else
                {
                    aliciEkle.alici = alici;
                    aliciEkle.yapilacakIslem = "satildi";
                }
                aliciEkle.Show();
            }
        }

        //alıcı ve satıcı ekleme kısmı
        private void aliciSaticiEkle(AliciEkle aliciEkle, int secilen)
        {
            aliciEkle.id = id;
            aliciEkle.sahip = "Sahibi: " + kisi;
            aliciEkle.fiyat = "Fiyat: " + fiyat + "TL";
            if (satilik == "Satılık")
            {
                aliciEkle.satkira = "Satılık";
            }
            else { aliciEkle.satkira = "Kiralık"; }
            aliciEkle.aciklama = "Açıklama: " + aciklama;
            aliciEkle.oda = "Oda: " + odaTip;
            aliciEkle.m2 = metrekare;
            aliciEkle.tip = "Tipi: " + tip;
            aliciEkle.binaYasi = "Konut Yaşı: " + konutYasi;
            aliciEkle.kat = "Kat: " + kat;
            aliciEkle.tKat = "Toplak Kat: " + dgvKonutlar.Rows[secilen].Cells[12].Value.ToString();
            aliciEkle.bodrum = dgvKonutlar.Rows[secilen].Cells[16].Value.ToString();
            aliciEkle.bahce = dgvKonutlar.Rows[secilen].Cells[15].Value.ToString();
            aliciEkle.ebeveynBanyosu = dgvKonutlar.Rows[secilen].Cells[17].Value.ToString();
        }

        #region Oluşturlan Metodlar
        //dgvdeki verileri stringlere atama metodu
        private void veriAta(int secilen)
        {
            degisken = dgvKonutlar.Rows[secilen].Cells[5].Value.ToString();
            string[] degiskenler = degisken.Split('/');

            //güncelleme
            id = dgvKonutlar.Rows[secilen].Cells[3].Value.ToString();
            aciklama = dgvKonutlar.Rows[secilen].Cells[6].Value.ToString();
            ilce = degiskenler[3];
            mahalle = degiskenler[2];
            sokak = degiskenler[1];
            odaTip = dgvKonutlar.Rows[secilen].Cells[7].Value.ToString();
            satilik = dgvKonutlar.Rows[secilen].Cells[8].Value.ToString();
            kat = dgvKonutlar.Rows[secilen].Cells[11].Value.ToString();
            tip = dgvKonutlar.Rows[secilen].Cells[10].Value.ToString();
            metrekare = dgvKonutlar.Rows[secilen].Cells[9].Value.ToString();
            kisi = dgvKonutlar.Rows[secilen].Cells[4].Value.ToString();
            konutAdi = degiskenler[0];
            konutKatSayisi = dgvKonutlar.Rows[secilen].Cells[12].Value.ToString();
            konutYasi = dgvKonutlar.Rows[secilen].Cells[13].Value.ToString();
            fiyat = dgvKonutlar.Rows[secilen].Cells[14].Value.ToString();
            if (dgvKonutlar.Rows[secilen].Cells[15].Value.ToString() == "True")
            {
                bahce = "1";
            }
            if (dgvKonutlar.Rows[secilen].Cells[16].Value.ToString() == "True")
            {
                bodrum = "1";
            }
            if (dgvKonutlar.Rows[secilen].Cells[17].Value.ToString() == "True")
            {
                ebeveynBanyo = "1";
            }
            

            //aliciları çekme
            alici = dgvKonutlar.Rows[secilen].Cells[19].Value.ToString();
            if (alici != "")
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = sqlBaglantisi.Baglanti();
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpKisiAdSoyadIdyeGoreCek";
                komut.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(alici);
                SqlDataReader reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    alici = reader[0].ToString();
                }
                sqlBaglantisi.Baglanti().Close();
            }
        }

        //dgview kolon düzeni
        private void dgvTasarim()
        {
            int i;
            dgvKonutlar.Columns[3].Visible = false;
            dgvKonutlar.Columns[5].Visible = false;
            dgvKonutlar.Columns[14].Visible = false;
            dgvKonutlar.Columns[7].Visible = false;
            dgvKonutlar.Columns[9].Visible = false;
            dgvKonutlar.Columns[15].Visible = false;
            dgvKonutlar.Columns[17].Visible = false;
            dgvKonutlar.Columns[16].Visible = false;
            dgvKonutlar.Columns[19].Visible = false;
            dgvKonutlar.Columns[20].Visible = false;
            dgvKonutlar.Columns["btn"].DisplayIndex = 19;
            dgvKonutlar.Columns[1].DisplayIndex = 19;
            dgvKonutlar.Columns[2].DisplayIndex = 19;

            //satılmış ise satılma butonu olmasın
            if (btnSatildimi.Text == "Satılmayanlar")
            {
                for (i = 0; i < dgvKonutlar.Rows.Count; i++)
                {
                    btn2.Text = "Sat";
                    btn2.UseColumnTextForButtonValue = true;
                }
            }
            else
            {
                for (i = 0; i < dgvKonutlar.Rows.Count; i++)
                {
                    btn2.Text = "Satış İptal";
                    btn2.UseColumnTextForButtonValue = true;
                }
            }
            
            //boyutlandırma
            for (i = 0; i < (dgvKonutlar.Columns.Count - 1); i++)
            {
                if(i != 6)
                {
                    dgvKonutlar.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
        }

        //adresi gizleme
        private void adresGizle(int i)
        {
            //bu kısımda bindingi durdurup tekrar devam ettirmek gerekiyormuş !!!
            CurrencyManager cm = (CurrencyManager)BindingContext[dgvKonutlar.DataSource];
            cm.SuspendBinding();
            dgvKonutlar.Rows[i].Visible = false;
            cm.ResumeBinding();
        }

        //satilik veya kiralıkları dgvsatilanlar ile çekme
        private void kiraluk(string a)
        {
            dgvKonutlar.DataSource = null;
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpKonutKiralikCek";
            komut.Parameters.Add("@kiralik", SqlDbType.NChar, 7).Value = a;
            if (btnSatildimi.Text == "Satılmayanlar")
            {
                komut.Parameters.Add("@deger", SqlDbType.Bit).Value = 0;
            }
            else
            {
                komut.Parameters.Add("@deger", SqlDbType.Bit).Value = 1;
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komut;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgvKonutlar.DataSource = table;
            dgvTasarim();
            sqlBaglantisi.Baglanti().Close();
        }

        //satilanlara göre tablodaki verileri gizleme
        private void dgvSatilanlar(string a)
        {
            if (a == "Kiralık")
            {
                kiraluk(a);
            }
            else if (a == "Satılık")
            {
                kiraluk(a);
            }
            else
            {
                dgvKonutlar.DataSource = null;
                SqlCommand komut = new SqlCommand();
                komut.Connection = sqlBaglantisi.Baglanti();
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpKonutSatCek";
                if (btnSatildimi.Text == "Satılmayanlar")
                {
                    komut.Parameters.Add("@deger", SqlDbType.Bit).Value = 0;
                }
                else
                {
                    komut.Parameters.Add("@deger", SqlDbType.Bit).Value = 1;
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = komut;
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dgvKonutlar.DataSource = table;
                dgvTasarim();
                sqlBaglantisi.Baglanti().Close();
            }
        }

        #endregion

        //uygulama kapatma
        private void Konut_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Konut Ekle buton ve lable tıklama
        private void LblKonutEkle_Click(object sender, EventArgs e)
        {
            KonutEkle konutEkle = new KonutEkle();
            konutEkle.islem = "kayıt";
            konutEkle.Show();
        }
        private void BtnKonutEkle_Click(object sender, EventArgs e)
        {
            KonutEkle konutEkle = new KonutEkle();
            konutEkle.islem = "kayıt";
            konutEkle.Show();
        }

        //yenile butonuna tıklama olayı
        private void BtnYenile_Click(object sender, EventArgs e)
        {
            baslangic();
        }

        //Arsa buton ve labeline tıklama olayı
        private void LblArsaGec_Click(object sender, EventArgs e)
        {
            Arsa arsa = new Arsa();
            arsa.Show();
            this.Hide();
        }
        private void BtnArsaGec_Click(object sender, EventArgs e)
        {
            Arsa arsa = new Arsa();
            arsa.Show();
            this.Hide();
        }

        //Kişiler butonuna ve labeline tıklama olayı
        private void LblKisiler_Click(object sender, EventArgs e)
        {
            KisiEkle kisiEkle = new KisiEkle();
            kisiEkle.neYapti = "kayıt";
            kisiEkle.Show();
        }
        private void BtnKisiler_Click(object sender, EventArgs e)
        {
            KisiEkle kisiEkle = new KisiEkle();
            kisiEkle.neYapti = "kayıt";
            kisiEkle.Show();
        }

        //buton il satılan veya satılmayana geçiş yapma lo
        private void BtnSatildimi_Click(object sender, EventArgs e)
        {
            if (btnSatildimi.Text == "Satılanlar")
            {
                btnSatildimi.Text = "Satılmayanlar";
            }
            else
            {
                btnSatildimi.Text = "Satılanlar";
            }

            //satildi mı olayına göre dgv ayarlama
            dgvSatilanlar(cmbSatilik.Text);

            //cmbleri boşaltma
            cmbIlce.SelectedIndex = -1;
            cmbSatilik.SelectedIndex = -1;
            cmbMahalle.SelectedIndex = -1;
            cmbSokak.SelectedIndex = -1;
            cmbOda.SelectedIndex = -1;
        }
    }
}

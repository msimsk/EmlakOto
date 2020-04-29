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
    public partial class KisiEkle : Form
    {
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        //değişkenler
        public string adSoyad, Tel, email, saticimiacaba, istekler, neYapti, id, kisiId;
        private string[] istekDuzen, ad;
        int secim;

        public KisiEkle()
        {
            InitializeComponent();
        }
        //Başlangıç durumu
        private void KisiEkle_Load(object sender, EventArgs e)
        {
            //başlangıçta kişi ekleme gelecek
            grbKisiIstekEkle.Visible = false;
            lnklblGeriKonut.Visible = false;
            grbUygunKonutlar.Visible = false;
            btnIstekKaldır.Visible = false;

            //combolara veri aktarma
            cmbVeriCekme();

            //buton ekleme kısmı
            butonlariEkle();

            //başlangıçta gelmesi gerekenler
            baslangic();

        }

        //güncelleme için hazırlanan fonksiyon
        private void baslangic()
        {
            rctIstekler.ReadOnly = true;
            lnklblSatici.Text = "Satıcılar";
            grbSatici.Text = "Satıcılar";

            //Kişileri çekme
            SqlCommand komut3 = new SqlCommand();
            komut3.Connection = sqlBaglantisi.Baglanti();
            komut3.CommandType = CommandType.StoredProcedure;
            komut3.CommandText = "SpKisiCek";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable dataTable1 = new DataTable();
            dataAdapter.SelectCommand = komut3;
            dataAdapter.Fill(dataTable1);
            dgvKisiler.DataSource = dataTable1;
            sqlBaglantisi.Baglanti().Close();

            //kişileri kaydet ve güncelleye göre düzenleme
            kisileriDuzenle();

            //satıcıları çekme
            for (int i = 0; i < dgvKisiler.Rows.Count; i++)
            {
                if (dgvKisiler.Rows[i].Cells[5].Value.ToString() != "True" || dgvKisiler.Rows[i].Cells[2].Value.ToString() == "")
                {
                    dgvKisiler.Rows[i].Visible = false;
                }
            }

            //isteklerden satılık kısmına defaul kiralık atama
            cmbSatKira.Text = "Kiralık";
        }

        #region harflere basmayı engelleme
        //txtboxa string girişini ekleme
        private void TxtBinaYas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void TxtM2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //fiyat kısmı
        private void TxtDusukFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void TxtYuksekFiyak_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        #endregion

        //dgvkişilere tıklama olayı
        private void DgvKisiler_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            secim = dgvKisiler.SelectedCells[0].RowIndex;
            kisiId = dgvKisiler.Rows[secim].Cells[7].Value.ToString();
            //istek butonuna tıklama
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                lblAdSoyad.Text = "Ad Soyad: " + dgvKisiler.Rows[secim].Cells[2].Value.ToString();
                istekDuzen = dgvKisiler.Rows[secim].Cells[6].Value.ToString().Split('+');
                if (istekDuzen.Length == 8)
                {
                    string[] adresBol = istekDuzen[0].Split('/');
                    string[] fiyatBol = istekDuzen[5].Split('-');
                    cmbIlce.Text = adresBol[0];
                    cmbMahalle.Text = adresBol[1];
                    cmbOda.Text = istekDuzen[1] + "+" + istekDuzen[2];
                    cmbSatKira.Text = istekDuzen[7];
                    txtBinaYas.Text = istekDuzen[4];
                    txtM2.Text = istekDuzen[3];
                    txtDusukFiyat.Text = fiyatBol[0];
                    txtYuksekFiyak.Text = fiyatBol[1];
                    rctIstekler1.Text = istekDuzen[6];
                    btnIstekEkle.Text = "İstek Güncelle";
                    btnIstekKaldır.Visible = true;
                }
                grbKisiIstekEkle.Visible = true;
                kisiDuzenleIstek();
            }
            else if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("Veri silinecek Bak kaçarı yok!!! Bununla ilişkli arsa konut da silinmiş olacak ona göre...", "Tehlike!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlBaglantisi.Baglanti();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SpKisiSil";
                    command.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(dgvKisiler.Rows[secim].Cells[7].Value.ToString());
                    command.ExecuteNonQuery();
                    sqlBaglantisi.Baglanti().Close();
                }
            }
            else if (e.RowIndex != -1)
            {
                adSoyad = dgvKisiler.Rows[secim].Cells[2].Value.ToString();
                Tel = dgvKisiler.Rows[secim].Cells[3].Value.ToString();
                email = dgvKisiler.Rows[secim].Cells[4].Value.ToString();
                saticimiacaba = dgvKisiler.Rows[secim].Cells[5].Value.ToString();
                istekler = dgvKisiler.Rows[secim].Cells[6].Value.ToString();
                id = dgvKisiler.Rows[secim].Cells[7].Value.ToString();

                //yapılan işlem ne güncelleme mi yoksa 
                string[] str = email.Split(' ');
                if (str[0] != "" && str[0] != null)
                {
                    string[] ayir = str[0].Split('@');
                    txtEMail.Text = ayir[0];
                    cmbAtmail.Text = "@" + ayir[1];
                }
                if (saticimiacaba == "True")
                {
                    chbSatici.Checked = true;
                }
                else
                {
                    chbSatici.Checked = false;
                }
                btnKayit.Text = "Güncelle";
                txtAdSoyad.Text = adSoyad;
                mtbTel.Text = Tel;
            }
        }

        //yenile butonu
        private void LnklblSifirla_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            baslangic();
            cmbAtmail.Text = "";
            cmbIlce.SelectedIndex = -1;
            cmbMahalle.SelectedIndex = -1;
            cmbOda.SelectedIndex = -1;
            txtAdSoyad.Text = "";
            txtBinaYas.Text = "";
            txtDusukFiyat.Text = "";
            txtEMail.Text = "";
            txtM2.Text = "";
            txtYuksekFiyak.Text = "";
            mtbTel.Text = "";
            chbSatici.Checked = false;
            rctIstekler.Text = "";
            rctIstekler1.Text = "";
        }

        #region İstek kısmı
        //isteklerdeki temizleme butonu
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            baslangic();
            istekDuzen = dgvKisiler.Rows[secim].Cells[6].Value.ToString().Split('+');
            kisiDuzenleIstek();

        }

        //İsteklere göre dgv kişileri düzenleme
        private void kisiDuzenleIstek()
        {
            lnklblSatici.Visible = false;
            grbSatici.Visible = false;

            //istek verilerini çekip ayrıştırma işlemi
            if (istekDuzen.Length <= 1)
            {
                lblKonum.Text = "İstek Bulunmamaktadır.";
                lblM2.Visible = false;
                lblOda.Visible = false;
                lblBinaYas.Visible = false;
                lblIstek.Visible = false;
                lblFiyatAralik.Visible = false;
                lnklblIstenilenKonutlar.Visible = false;
                lnklblUygunKonutlar.Visible = false;
            }
            else
            {
                lblM2.Visible = true;
                lblOda.Visible = true;
                lblBinaYas.Visible = true;
                lblIstek.Visible = true;
                lblFiyatAralik.Visible = true;
                lnklblIstenilenKonutlar.Visible = true;
                lnklblUygunKonutlar.Visible = true;
                if (istekDuzen.Length == 7)
                {
                    lblKonum.Text = "Adres: " + istekDuzen[0];
                    lblFiyatAralik.Text = "Fiyat Aralığı:" + istekDuzen[5];
                    lblM2.Text = "Metre Kare: " + istekDuzen[3];
                    lblOda.Text = "Oda Türü: " + istekDuzen[1] + "+" + istekDuzen[2];
                    lblBinaYas.Text = "Bina Yaşı: " + istekDuzen[4];
                    lblIstek.Text = "İstekler: " + istekDuzen[6];
                }
                else
                {
                    lblKonum.Text = "Adres: " + istekDuzen[0];
                    lblFiyatAralik.Text = "Fiyat Aralığı:" + istekDuzen[5];
                    lblM2.Text = "Metre Kare: " + istekDuzen[3];
                    lblOda.Text = "Oda Türü: " + istekDuzen[1] + "+" + istekDuzen[2];
                    lblBinaYas.Text = "Bina Yaşı: " + istekDuzen[4];
                    lblIstek.Text = "İstekler: " + istekDuzen[6];
                }
            }
        }

        //ilçe kombosuna tıklama olayı
        private void CmbIlce_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        //geri labeline tıklama işlemi
        private void LnklblGeri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grbKisiEkleDuzenle.Visible = true;
            lnklblGeriKonut.Visible = false;
            grbKisiIstekEkle.Visible = false;
            grbUygunKonutlar.Visible = false;
            grbSatici.Visible = true;
            lnklblSatici.Visible = true;
            cmbIlce.Text = "";
            cmbMahalle.Text = "";
            cmbOda.Text = "";
            cmbSatKira.Text = "Kiralık";
            txtBinaYas.Text = "";
            txtM2.Text = "";
            txtDusukFiyat.Text = "";
            txtYuksekFiyak.Text = "";
            rctIstekler1.Text = "";
        }

        //istek kaldır butonu
        private void BtnIstekKaldır_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpKisiIstek";
            komut.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(dgvKisiler.Rows[secim].Cells[7].Value.ToString());
            komut.Parameters.Add("@deger", SqlDbType.NVarChar).Value = "";
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("İstekler Kaldırıldı..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnIstekKaldır.Visible = false;
            //kişi isteklerini labellara aktarma işlemi
            baslangic();
            istekDuzen = dgvKisiler.Rows[secim].Cells[6].Value.ToString().Split('+');
            kisiDuzenleIstek();
            rctIstekler1.Text = "";
            cmbIlce.SelectedIndex = -1;
            cmbMahalle.SelectedIndex = -1;
            cmbOda.SelectedIndex = -1;
            txtBinaYas.Text = "";
            txtDusukFiyat.Text = "";
            txtEMail.Text = "";
            txtM2.Text = "";
            txtYuksekFiyak.Text = "";
        }

        //istek ekle ve güncelle butonu
        private void BtnIstekEkle_Click(object sender, EventArgs e)
        {
            //istek ekleme 
            string istekler = cmbIlce.Text + "/" + cmbMahalle.Text + "+" + cmbOda.Text + "+" + txtM2.Text + "+" + txtBinaYas.Text + "+" + txtDusukFiyat.Text + "-" + txtYuksekFiyak.Text + "+" + rctIstekler1.Text + "+" + cmbSatKira.Text;
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpKisiIstek";
            komut.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(dgvKisiler.Rows[secim].Cells[7].Value.ToString());

            if (btnIstekEkle.Text == "İstek Güncelle")
            {
                komut.Parameters.Add("@deger", SqlDbType.NVarChar).Value = istekler;
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("İstekler Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                komut.Parameters.Add("@deger", SqlDbType.NVarChar).Value = istekler;
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("İstekler Eklendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIstekKaldır.Visible = true;
                btnIstekEkle.Text = "İstek Güncelle";
            }

            //kişi isteklerini labellara aktarma işlemi
            baslangic();
            istekDuzen = dgvKisiler.Rows[secim].Cells[6].Value.ToString().Split('+');
            kisiDuzenleIstek();
        }

        //Çıkış labela tıklama 
        private void LnklblCikis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        //combolara veri aktarma
        private void cmbVeriCekme()
        {
            //Cmbilce veri atama
            SqlCommand komut1 = new SqlCommand();
            komut1.Connection = sqlBaglantisi.Baglanti();
            komut1.CommandType = CommandType.StoredProcedure;
            komut1.CommandText = "SpIlceCek";
            SqlDataReader reader1 = komut1.ExecuteReader();
            while (reader1.Read())
            {
                cmbIlce.Items.Add(reader1[0].ToString());
            }
            sqlBaglantisi.Baglanti().Close();
            //CmbOda veri atama
            SqlCommand komut2 = new SqlCommand();
            komut2.Connection = sqlBaglantisi.Baglanti();
            komut2.CommandType = CommandType.StoredProcedure;
            komut2.CommandText = "SpOdaCek";
            SqlDataReader reader2 = komut2.ExecuteReader();
            while (reader2.Read())
            {
                cmbOda.Items.Add(reader2[0].ToString());
            }
            sqlBaglantisi.Baglanti().Close();
        }


        //Uygun konutlar labeline tıklama olayı
        private void LnklblUygunKonutlar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvUygunKonutlar.DataSource = null;
            grbUygunKonutlar.Visible = true;
            lnklblGeriKonut.Visible = true;
            grbUygunKonutlar.Text = "Uygun Konutlar";

            //Konutları Çekme
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpKonutSatCek";
            komut.Parameters.Add("@deger", SqlDbType.Bit).Value = 0;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komut;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgvUygunKonutlar.DataSource = table;

            //kolon tasarımları
            dgvTasarim();

            //uygun olmayan konutları gizleme
            konutGizle();
            sqlBaglantisi.Baglanti().Close();
        }

        //uygun olmayan konutları gizleme
        private void konutGizle()
        {
            //Verileri veri tabanından çektikten sonra bağlantı kapanır ise currency manager komutu ile bağlantıya müdahale edilir tablo düzenlenip tekrar bağlantının devam etemsi sağlanır
            

            int i, j = 0;
            string[] bolunmusAdres, bolunmusFiyat;
            //uygun olmayanları gizleme
            for (i = 0; i < dgvUygunKonutlar.Rows.Count; i++)
            {
                j = 0;
                bolunmusAdres = dgvUygunKonutlar.Rows[i].Cells[2].Value.ToString().Split('/');
                bolunmusFiyat = istekDuzen[5].Split('-');

                if (dgvUygunKonutlar.Rows[i].Cells[4].Value.ToString() == istekDuzen[1] + "+" + istekDuzen[2])
                {
                    j++;
                }
                if (dgvUygunKonutlar.Rows[i].Cells[6].Value.ToString() == istekDuzen[3])
                {
                    j++;
                }
                if (dgvUygunKonutlar.Rows[i].Cells[10].Value.ToString() == istekDuzen[4])
                {
                    j++;
                }
                if (Convert.ToInt64(bolunmusFiyat[0]) < Convert.ToInt64(dgvUygunKonutlar.Rows[i].Cells[11].Value.ToString()) &&
                    Convert.ToInt64(dgvUygunKonutlar.Rows[i].Cells[11].Value.ToString()) < Convert.ToInt64(bolunmusFiyat[1]))
                {
                    j++;
                }
                if (dgvUygunKonutlar.Rows[i].Cells[5].Value.ToString() != istekDuzen[7])
                {
                    j = 0;
                }

                if (j == 0)
                {
                    dgvUygunKonutlar.Rows[i].Visible = false;
                }
                if (j == 4)
                {
                    dgvUygunKonutlar.Rows[i].Cells[17].Value = "%100";
                }
                else if (j == 3)
                {
                    dgvUygunKonutlar.Rows[i].Cells[17].Value = "%75";
                }
                else if (j == 2)
                {
                    dgvUygunKonutlar.Rows[i].Cells[17].Value = "%50";
                }
                else if (j == 1)
                {
                    dgvUygunKonutlar.Rows[i].Cells[17].Value = "%25";
                }

            }
        }

        //dgv uygun konut ve istenen konutlara tasarım
        private void dgvTasarim()
        {
            int i;

            //Verileri gizleme olayı
            //boyutlandırma
            for (i = 0; i < dgvUygunKonutlar.Columns.Count; i++)
            {
                dgvUygunKonutlar.Columns[i].Visible = false;

                if (i != 2)
                {
                    dgvUygunKonutlar.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }

            for (i = 0; i < dgvUygunKonutlar.Rows.Count; i++)
            {
                ad = lblAdSoyad.Text.Split(' ');
                if ((ad[2] + " " + ad[3]) == dgvUygunKonutlar.Rows[i].Cells[1].Value.ToString())
                {
                    dgvUygunKonutlar.Rows[i].Visible = false;
                }
                string[] ayir = dgvUygunKonutlar.Rows[i].Cells[2].Value.ToString().Split('/');
                if (ayir.Length == 4)
                {
                    dgvUygunKonutlar.Rows[i].Cells[2].Value = ayir[2] + "/" + ayir[3];
                }
                else
                {
                    dgvUygunKonutlar.Rows[i].Cells[2].Value = ayir[1] + "/" + ayir[2];
                }
            }

            dgvUygunKonutlar.Columns[11].Visible = true;
            dgvUygunKonutlar.Columns[17].Visible = true;
            dgvUygunKonutlar.Columns[2].Visible = true;
        }

        //İstenilen konutlar labelina tıklama olayı
        private void LnklblIstenilenKonutlar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int i;
            dgvUygunKonutlar.DataSource = null;
            grbUygunKonutlar.Visible = true;
            lnklblGeriKonut.Visible = true;
            grbUygunKonutlar.Text = "İstenilen Konutlar";

            //Konutları Çekme
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpKisiKonutİstekCek";
            komut.Parameters.Add("@id", SqlDbType.BigInt).Value = kisiId;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = komut;
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            dgvUygunKonutlar.DataSource = table;
            dgvUygunKonutlar.Columns[0].Visible = false;

            for (i = 0; i < dgvUygunKonutlar.Rows.Count; i++)
            {
                  string[] ayir = dgvUygunKonutlar.Rows[i].Cells[1].Value.ToString().Split('/');
                if (ayir.Length == 4)
                {
                    dgvUygunKonutlar.Rows[i].Cells[2].Value = ayir[1] + "/" + ayir[2];
                }
                else
                {
                    dgvUygunKonutlar.Rows[i].Cells[2].Value = ayir[0] + "/" + ayir[1];
                }
            }

            sqlBaglantisi.Baglanti().Close();

        }

        #region uygun konut kısmı

        //KOnut kısmındaki geri tuşu
        private void LnklblGeriKonut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grbUygunKonutlar.Visible = false;
            lnklblGeriKonut.Visible = false;
        }

        //dgvuygunkonut tıklama olayı(hem uygun hemde istenilen konutlar için)
        private void DgvUygunKonutlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgvUygunKonutlar.SelectedCells[0].RowIndex;
            if (e.RowIndex != -1)
            {
                AliciEkle aliciEkle = new AliciEkle();
                aliciEkle.id = dgvUygunKonutlar.Rows[secilen].Cells[0].Value.ToString();
                aliciEkle.sahip = "Sahip: " + dgvUygunKonutlar.Rows[secilen].Cells[1].Value.ToString();
                aliciEkle.aciklama = "Açıklama: " + dgvUygunKonutlar.Rows[secilen].Cells[3].Value.ToString();
                aliciEkle.oda = "Oda Tipi: " + dgvUygunKonutlar.Rows[secilen].Cells[4].Value.ToString();
                aliciEkle.satkira = dgvUygunKonutlar.Rows[secilen].Cells[5].Value.ToString();
                aliciEkle.m2 = dgvUygunKonutlar.Rows[secilen].Cells[6].Value.ToString() + " m2";
                aliciEkle.tip = "Tip: " + dgvUygunKonutlar.Rows[secilen].Cells[7].Value.ToString();
                aliciEkle.kat = "Kat: " + dgvUygunKonutlar.Rows[secilen].Cells[8].Value.ToString();
                aliciEkle.tKat = "Toplam Kat: " + dgvUygunKonutlar.Rows[secilen].Cells[9].Value.ToString();
                aliciEkle.binaYasi = "Bina Yaşı: " + dgvUygunKonutlar.Rows[secilen].Cells[10].Value.ToString();
                aliciEkle.fiyat = "Fiyat: " + dgvUygunKonutlar.Rows[secilen].Cells[11].Value.ToString() + "TL";
                aliciEkle.bahce = dgvUygunKonutlar.Rows[secilen].Cells[12].Value.ToString();
                aliciEkle.bodrum = dgvUygunKonutlar.Rows[secilen].Cells[13].Value.ToString();
                aliciEkle.ebeveynBanyosu = dgvUygunKonutlar.Rows[secilen].Cells[14].Value.ToString();

                aliciEkle.alici = ad[2] + " " + ad[3];
                aliciEkle.Show();
            }

        }
        #endregion
        #endregion

        #region Kayıt ve güncelleme
        //Kişileri düzenle ve kaydete göre çek
        private void kisileriDuzenle()
        {
            for (int i = 0; i < dgvKisiler.Columns.Count; i++)
            {
                dgvKisiler.Columns[i].Visible = true;
            }

            //bu kısımda bindingi durdurup tekrar devam ettirmek gerekiyormuş !!!
            CurrencyManager cm = (CurrencyManager)BindingContext[dgvKisiler.DataSource];
            cm.SuspendBinding();
            dgvKisiler.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKisiler.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKisiler.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKisiler.Columns[7].Visible = false;
            dgvKisiler.Columns[4].Visible = false;
            dgvKisiler.Columns[5].Visible = false;
            dgvKisiler.Columns[6].Visible = false;
            dgvKisiler.Columns[0].DisplayIndex = 3;
            dgvKisiler.Columns[1].DisplayIndex = 4;
            dgvKisiler.Columns[0].Visible = false;
            dgvKisiler.Columns[1].Visible = false;
            cm.ResumeBinding();
        }

        //buton ekleme kısmı
        private void butonlariEkle()
        {
            //istek butonu ekleme
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgvKisiler.Columns.Add(btn);
            btn.Text = "İstek";
            btn.Name = "istek";
            btn.HeaderText = "";
            btn.UseColumnTextForButtonValue = true;
            //sil butonu ekleme
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            dgvKisiler.Columns.Add(btn1);
            btn1.Text = "Sil";
            btn1.Name = "sil";
            btn1.HeaderText = "";
            btn1.UseColumnTextForButtonValue = true;
        }

        //kaydet butonuna tıklama
        SqlCommand komut = new SqlCommand();

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            if (btnKayit.Text == "Kayıt")
            {
                kisiIslem("SpKisiEkle");
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Kişi Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                kisiIslem("SpKisiGuncelle");
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Kişi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            KisiEkle kisi = new KisiEkle();
            kisi.Show();
            this.Close();
            //baslangic();
        }

        //kişi güncelle veya kayıt işlemi
        string[] b;
        private void kisiIslem(string komutTexti)
        {
            b = mtbTel.Text.Split('(');
            b = b[1].Split(')');
            b[0] += b[1];
            b = b[0].Split(' ');
            b[0] += b[1];
            b = b[0].Split('-');
            b[0] += b[1];


            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = komutTexti;
            komut.Parameters.Add("@adSoyad", SqlDbType.NVarChar, 70).Value = txtAdSoyad.Text;
            if (id != null && id != "")
            {
                komut.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(id);
            }
            komut.Parameters.Add("@tel", SqlDbType.BigInt).Value = b[0];
            if (txtEMail.Text != null && txtEMail.Text != "")
            {
                komut.Parameters.Add("@email", SqlDbType.NChar, 40).Value = txtEMail.Text + cmbAtmail.Text;
            }
            if (chbSatici.Checked == true)
            {
                komut.Parameters.Add("@saticiMi", SqlDbType.Bit).Value = 1;
            }
            else
            {
                komut.Parameters.Add("@saticiMi", SqlDbType.Bit).Value = 0;
            }
            komut.Parameters.Add("@istek", SqlDbType.NVarChar).Value = rctIstekler.Text;
        }

        //çıkış labeline tıklama
        private void LnklblCikis1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        //Satıcı mı alıcı mı ayarlama(gizleme işte) metodu
        private void saticiMi()
        {
            int i;
            for (i = 0; i < dgvKisiler.Rows.Count; i++)
            {
                dgvKisiler.Rows[i].Visible = true;
            }
            //gizleme olyı önemli
            CurrencyManager cm = (CurrencyManager)BindingContext[dgvKisiler.DataSource];
            cm.SuspendBinding();

            if (lnklblSatici.Text == "Satıcılar")
            {
                lnklblSatici.Text = "Alıcılar";
                grbSatici.Text = "Alıcılar";
                for (i = 0; i < dgvKisiler.Rows.Count; i++)
                {
                    if (dgvKisiler.Rows[i].Cells[5].Value.ToString() == "True" || dgvKisiler.Rows[i].Cells[2].Value.ToString() == "")
                    {
                        dgvKisiler.Rows[i].Visible = false;
                    }
                }
                dgvKisiler.Columns[0].Visible = true;
                dgvKisiler.Columns[1].Visible = true;
            }
            else
            {
                lnklblSatici.Text = "Satıcılar";
                grbSatici.Text = "Satıcılar";
                for (i = 0; i < dgvKisiler.Rows.Count; i++)
                {
                    if (dgvKisiler.Rows[i].Cells[5].Value.ToString() != "True" || dgvKisiler.Rows[i].Cells[2].Value.ToString() == "")
                    {
                        dgvKisiler.Rows[i].Visible = false;
                    }
                }
                dgvKisiler.Columns[0].Visible = false;
                dgvKisiler.Columns[1].Visible = false;
            }
            cm.ResumeBinding();
        }

        //Satıcılar labeline tıklama
        private void LnklblSatici_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            saticiMi();
        }

        //satıcı olunca rctIstekleri iptal etme"yazı yazılmasını engelleme"
        private void ChbSatici_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSatici.Checked == false)
            {
                rctIstekler.Text = "";
                rctIstekler.ReadOnly = true;
            }
            else
            {
                rctIstekler.ReadOnly = false;
            }
        }

        #endregion
    }
}
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
    public partial class ArsaAliciVeBilgi : Form
    {
        //Değişkenler
        public string arsaId, sahip, aciklama, adres, satKira, m2, fiyat, yapilanIslem, alici, c;

        //Bağlantı oluşturma
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        public ArsaAliciVeBilgi()
        {
            InitializeComponent();
        }

        //form Yüklenince başlangıç
        private void ArsaAliciVeBilgi_Load(object sender, EventArgs e)
        {
            //alıcı ekleme combosunu temizleme için iptal tuşuna tıklama olayı
            lnklblCIptal.Visible = false;


            //değişkenleri atamave yapılan işlem
            degerAtaIslem();

            //aliciları çekme 
            alicilairiCek();

            //Combobox düzenle
            comboBoxDuzenle();
        }

        //alıcı kısmına tıklama olayı
        private void CmbAlici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c == "a")
            {

            }
            else
            {
                cmbAlmakIsteyenler.SelectedIndex = -1;
                degerAtaIslem();
            }
            c = "";
        }

        //Alıcılar almak isteyenleri Çekme
        private void alicilairiCek()
        {
            SqlCommand komut1 = new SqlCommand();
            komut1.Connection = sqlBaglantisi.Baglanti();
            komut1.CommandType = CommandType.StoredProcedure;
            komut1.CommandText = "SpKisiCek";
            SqlDataReader reader2 = komut1.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2[0].ToString() != sahip)
                {
                    cmbAlici.Items.Add(reader2[0].ToString());
                }
            }
            sqlBaglantisi.Baglanti().Close();

            aliciCek();
        }

        private void aliciCek()
        {
            //Alıcıları çekme
            SqlCommand command1 = new SqlCommand();
            command1.Connection = sqlBaglantisi.Baglanti();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "SpArsaAliciIstekCek";
            command1.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(arsaId);
            SqlDataAdapter sqlData = new SqlDataAdapter();
            DataTable table = new DataTable();
            sqlData.SelectCommand = command1;
            sqlData.Fill(table);
            dgvAlmakIsteyenKullanicilar.DataSource = table;
            SqlDataReader dataReader1 = command1.ExecuteReader();
            while (dataReader1.Read())
            {
                cmbAlmakIsteyenler.Items.Add(dataReader1[0].ToString());
            }
            sqlBaglantisi.Baglanti().Close();
        }

        //comboboxları düzenleme
        private void comboBoxDuzenle()
        {
            int i;
            string alinan = "";
            for (i = 0; i < cmbAlici.Items.Count; i++)
            {
                if (i == (cmbAlici.Items.Count - 1))
                {
                    alinan += cmbAlici.Items[i].ToString();
                }
                else
                {
                    alinan += cmbAlici.Items[i].ToString() + "+";
                }
            }
            string[] cmbUzunlugu = alinan.Split('+');
            for (i = 0; i < cmbUzunlugu.Length; i++)
            {
                for (int j = 0; j < cmbAlmakIsteyenler.Items.Count; j++)
                {
                    if (cmbUzunlugu[i] == cmbAlmakIsteyenler.Items[j].ToString())
                    {
                        cmbAlici.Items.Remove(cmbUzunlugu[i]); break;
                    }
                }
            }
        }

        //Değerleri Atama ve yapılan işlem ne
        private void degerAtaIslem()
        {
            lblSahip.Text = "Sahip: " + sahip;
            lblAciklama.Text = "Açıklama: " + aciklama;
            if (adres.Length > 40)
            {
                string[] bolAdres = adres.Split('/');
                lblAdres.Text = "Adres: " + bolAdres[0] + "/\n" + bolAdres[1] + "/Bursa";
            }
            else
            {
                lblAdres.Text = "Adres: " + adres + "/Bursa";
            }
            lblKiraSat.Text = satKira;
            lblM2.Text = "Metre Kare: " + m2 + "m2";
            lblFiyat.Text = "Fiyat: " + fiyat + "TL";

            if (yapilanIslem == "alıcıekle")
            {
                grbArsaAliciEkleSat.Text = "Arsa Alıcı Ekle";
                btnKaydet.Text = "Alıcı Ekle";
            }
            else if (yapilanIslem == "sat")
            {
                grbArsaAliciEkleSat.Text = "Arsa Sat";
                btnKaydet.Text = "Arsa Sat";
            }
            else
            {
                grbArsaAliciEkleSat.Text = "Satılan arsa";
                btnKaydet.Text = "Satış İptal";
                cmbAlmakIsteyenler.Visible = false;
                cmbAlici.Visible = false;
                dgvAlmakIsteyenKullanicilar.Visible = false;
                lnklblEkle.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                lblKiraSat.Visible = false;
                //konum ve boyut ayarlama
                lblAdres.Location = new Point(5, 88);
                lblAciklama.Location = new Point(5, 110);
                lblFiyat.Location = new Point(5, 135);
                lblM2.Location = new Point(5, 162);
                btnKaydet.Location = new Point(170, 200);
                grbArsaAliciEkleSat.Width = 330;
                grbArsaAliciEkleSat.Height = 250;
                lnklblCikis.Location = new Point(280, 18);
                this.Width = 348;
                this.Height = 268;
                lblAlici.Text = "Yeni Sahip: " + alici;
            }
        }

        //Kayıt işlemi
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Arsa Sat")
            {
                //satma işlemi
                konutSat(Convert.ToInt64(arsaId), cmbAlici.Text, "true");
                MessageBox.Show("Arsa Satıldı!!!\nAlıcı: " + cmbAlici.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ( btnKaydet.Text == "Alıcı Ekle")
            {
                //Alıcı ekleme
                SqlCommand komut1 = new SqlCommand();
                komut1.Connection = sqlBaglantisi.Baglanti();
                komut1.CommandType = CommandType.StoredProcedure;
                komut1.CommandText = "SpArsaAliciIstek";
                komut1.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(arsaId);
                komut1.Parameters.Add("@kisiad", SqlDbType.NVarChar, 70).Value = cmbAlici.Text;
                komut1.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Alıcı Eklendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                aliciCek();

            }
            else if (btnKaydet.Text == "Alıcı Kaldır")
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Alıcı Kaldırılacak!!!", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(dialog == DialogResult.Yes)
                {
                    //Alıcı Kaldırma
                    SqlCommand komut2 = new SqlCommand();
                    komut2.Connection = sqlBaglantisi.Baglanti();
                    komut2.CommandType = CommandType.StoredProcedure;
                    komut2.CommandText = "SpArsaIstekSil";
                    komut2.Parameters.Add("@arsaId", SqlDbType.BigInt).Value = Convert.ToInt64(arsaId);
                    komut2.Parameters.Add("@kisiAdi", SqlDbType.NVarChar, 70).Value = cmbAlmakIsteyenler.Text;
                    komut2.ExecuteNonQuery();
                    sqlBaglantisi.Baglanti().Close();
                    MessageBox.Show("Alıcı Kaldırıldı..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                //Satış İptal Kısmı
                konutSat(Convert.ToInt64(arsaId), " ", "");
                MessageBox.Show("Alıcı Kaldırıldı..)", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //this.Close();

        }

        //Satış işlemi ve satış iptal etme
        public void konutSat(Int64 a, string alan, string d)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpArsaAlici";
            komut.Parameters.Add("@id", SqlDbType.BigInt).Value = a;
            komut.Parameters.Add("@alici", SqlDbType.NVarChar, 70).Value = alan;
            if (d == "true")
            {
                komut.Parameters.Add("@durum", SqlDbType.Bit).Value = 1;
            }
            else
            {
                komut.Parameters.Add("@durum", SqlDbType.Bit).Value = 0;
            }
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti();
        }

        //formu kapatma çıkışa dokunma kısmı
        private void LnklblCikis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        //Cmb almak isteyen birine satış işleminde almak isteyene tıklanınca satışa eklensin
        private void CmbAlmakIsteyenler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c == "c")
            {

            }
            else
            {
                if (btnKaydet.Text == "Arsa Sat")
                {
                    comboBoxDuzenle();
                    c = "a";
                    cmbAlici.Items.Add(cmbAlmakIsteyenler.Text);
                    cmbAlici.Text = cmbAlmakIsteyenler.Text;
                    c = "";
                }
                else if (btnKaydet.Text == "Alıcı Ekle")
                {
                    btnKaydet.Text = "Alıcı Kaldır";
                    lnklblCIptal.Visible = true;
                }
            }
        }

        //dgv tıklanma olayı ile veri satma işlemi
        private void DgvAlmakIsteyenKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxDuzenle();
            int i = dgvAlmakIsteyenKullanicilar.SelectedCells[0].RowIndex;
            if (btnKaydet.Text == "Arsa Sat")
            {
                c = "a";
                cmbAlmakIsteyenler.Text = dgvAlmakIsteyenKullanicilar.Rows[i].Cells[0].Value.ToString();
                cmbAlici.Items.Add(cmbAlmakIsteyenler.Text);
                cmbAlici.Text = cmbAlmakIsteyenler.Text;
                c = "";
            }
            else if (btnKaydet.Text == "Alıcı Ekle" || btnKaydet.Text == "Alıcı Kaldır")
            {
                c = "c";
                btnKaydet.Text = "Alıcı Kaldır";
                cmbAlmakIsteyenler.Text = dgvAlmakIsteyenKullanicilar.Rows[i].Cells[0].Value.ToString();
                lnklblCIptal.Visible = true;
                c = "";
            }
        }


        //İptal butonu yenileme yapıyor
        private void LnklblCIptal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cmbAlmakIsteyenler.SelectedIndex = -1;
            degerAtaIslem();
        }
    }
}

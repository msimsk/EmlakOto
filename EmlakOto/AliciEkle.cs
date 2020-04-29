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
    public partial class AliciEkle : Form
    {
        //Bağlantı
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        //Değişkenler
        public string id, sahip, adres, aciklama, oda, satkira, m2, tip, kat, tKat, binaYasi, fiyat, bahce, bodrum, ebeveynBanyosu, alici, yapilacakIslem;

        public AliciEkle()
        {
            InitializeComponent();
        }

        //Başlangıçta yüklenenler
        private void AliciEkle_Load(object sender, EventArgs e)
        {
            //silmek için olan iptal linkini görünmez yapma
            lnklblCIptal.Visible = false;

            //yapılacak işlemi belirleme
            if (yapilacakIslem == "sat")
            {
                btnKaydet.Text = "Sat";
                grbAliciEkle.Text = "Konutu Sat";
            }
            else if(yapilacakIslem == "satildi")
            {
                btnKaydet.Text = "Satış İptal";
                grbAliciEkle.Text = "Satılan Konut";
                dgvAlmakIsteyenKullanicilar.Visible = false;
                lblkira.Visible = false;
                grbAliciEkle.Width = 700;
                grbAliciEkle.Height = 240;
                lnklblIptal.Location = new Point(640, 18);
                lblAlici.Location = new Point(371, 30);
                //sahibin altındaki kısım
                lblAdres.Location = new Point(7, lblSahip.Location.Y + 30);
                lblAciklama.Location = new Point(7, lblAdres.Location.Y + 25);
                lblFiyat.Location = new Point(7, lblAciklama.Location.Y + 25);
                lblBahceli.Location = new Point(7, lblFiyat.Location.Y + 25);
                lblEbeveynBanyosu.Location = new Point(7, lblBahceli.Location.Y + 25);
                lblM2.Location = new Point(7, lblEbeveynBanyosu.Location.Y + 25);
                lblBinaYasi.Location = new Point(7, lblM2.Location.Y + 25);
                //yeni sahbin altındaki kısım
                lblOda.Location = new Point(411, lblAlici.Location.Y + 30);
                lblKonutTipi.Location = new Point(411, lblOda.Location.Y + 25);
                lblKat.Location = new Point(411, lblKonutTipi.Location.Y + 25);
                lblToplamKat.Location = new Point(411, lblKat.Location.Y + 25);
                lblBodrum.Location = new Point(411, lblKat.Location.Y + 25);
                btnKaydet.Location = new Point(400, lblBodrum.Location.Y + 50);
                this.Width = 723;
                this.Height = 263;
            }
            else
            {
                btnKaydet.Text = "Alıcı Ekle";
                grbAliciEkle.Text = "Konuta Alıcı Ekle";
            }

            //aliciları çekme 
            SqlCommand komut1 = new SqlCommand();
            komut1.Connection = sqlBaglantisi.Baglanti();
            komut1.CommandType = CommandType.StoredProcedure;
            komut1.CommandText = "SpKisiCek";
            SqlDataReader reader2 = komut1.ExecuteReader();
            string[] bolAd = sahip.Split(' ');
            while (reader2.Read())
            {
                if (reader2[0].ToString() != (bolAd[1] + " " + bolAd[2]))
                {
                    cmbAlici.Items.Add(reader2[0].ToString());
                }
            }
            sqlBaglantisi.Baglanti().Close();
            
            //Alıcıları çekme
            SqlCommand command = new SqlCommand();
            command.Connection = sqlBaglantisi.Baglanti();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SpKisiAlici";
            command.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(table);
            dgvAlmakIsteyenKullanicilar.DataSource = table;
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
              cmbAlmakIsteyenler.Items.Add(dataReader[0].ToString());
            }
            sqlBaglantisi.Baglanti().Close();

            //değerleri atama
            veriAta();
            //comboboxları düzenle
            comboBoxDuzenle();
            
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

        //comboboxtan almak isteyenlere tıklayınca
        private void CmbAlmakIsteyenler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yapilacakIslem == "sat")
            {
                comboBoxDuzenle();
                cmbAlici.Items.Add(cmbAlmakIsteyenler.Text);
                cmbAlici.Text = cmbAlmakIsteyenler.Text;
            }
            else
            {
                btnKaydet.Text = "Alıcıyı Sil";
                lnklblCIptal.Visible = true;
            }
            
        }

        //silme işlemini iptal etme
        private void LnklblCIptal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cmbAlmakIsteyenler.SelectedIndex = -1;
            if (yapilacakIslem == "sat")
            {
                btnKaydet.Text = "Sat";
            }
            else
            {
                btnKaydet.Text = "Alıcı Ekle";
            }
            lnklblCIptal.Visible = false;
        }


        //değerleri lbllara atama vb. yerler
        private void veriAta()
        {
            SqlCommand komut1 = new SqlCommand();
            komut1.Connection = sqlBaglantisi.Baglanti();
            komut1.CommandType = CommandType.StoredProcedure;
            komut1.CommandText = "SpKonutAdresCek";
            komut1.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(id);
            SqlDataReader reader1 = komut1.ExecuteReader();
            if (reader1.Read())
            {
                adres = reader1[0].ToString();
            }
            sqlBaglantisi.Baglanti().Close();
            //verileri atama
            lblAdres.Text = "Adres: " + adres;
            lblFiyat.Text = fiyat;
            lblkira.Text = satkira;
            //konut satılmış ise
            if (yapilacakIslem == "satildi")
            {
                cmbAlici.Visible = false;
                cmbAlmakIsteyenler.Visible = false;
                label1.Visible = false;
                lnklblEkle.Visible = false;
                label2.Visible = false;
                lblAlici.Text = "Yeni Sahip: " + alici;
                lblAlici.Font = new Font("Times New Roman", 16, FontStyle.Underline);
            }
            else
            {
                cmbAlici.Text = alici;
            }
            lblSahip.Text = sahip;
            lblAciklama.Text = aciklama;
            lblOda.Text = oda;
            lblM2.Text = "Metre Kare: " + m2;
            lblKonutTipi.Text = "Konut " + tip;
            lblBinaYasi.Text = binaYasi;
            lblKat.Text = kat;
            lblToplamKat.Text = tKat;

            if (bodrum == "True")
            {
                lblBodrum.Visible = true;
            }
            else
            {
                lblBodrum.Visible = false;
            }
            if (bahce == "True")
            {
                lblBahceli.Visible = true;
            }
            else
            {
                lblBahceli.Visible = false;
            }
            if (ebeveynBanyosu == "True")
            {
                lblEbeveynBanyosu.Visible = true;
            }
            else
            {
                lblEbeveynBanyosu.Visible = false;
            }
        }

        //kaydet butonu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Alıcıyı Sil")
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Alıcıyı silmek istediğinizden emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = sqlBaglantisi.Baglanti();
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "SpKonutIstekSil";
                    komut.Parameters.Add("@kisiAdi", SqlDbType.NVarChar, 70).Value = cmbAlmakIsteyenler.Text;
                    komut.Parameters.Add("@konutId", SqlDbType.BigInt).Value = Convert.ToInt64(id);
                    komut.ExecuteNonQuery();
                    sqlBaglantisi.Baglanti().Close();
                    MessageBox.Show("Veri Silindi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (yapilacakIslem == "sat")
                {
                    string[] degisken = cmbAlici.Text.Split(' ');
                    //Alıcı ekleme
                    if (degisken[0] == "" || cmbAlici.Text == null || degisken[1] == "")
                    {
                        konutSat(Convert.ToInt64(id), " ", "");
                        MessageBox.Show("Alıcı Kaldırıldı..)", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                    else
                    {
                        konutSat(Convert.ToInt64(id), cmbAlici.Text, "true");
                        MessageBox.Show("Alıcı: " + cmbAlici.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else if (yapilacakIslem == "satildi")
                {
                    konutSat(Convert.ToInt64(id), " ", "");
                    MessageBox.Show("Alıcı Kaldırıldı..)", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = sqlBaglantisi.Baglanti();
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.CommandText = "SpKisiAliciEkle";
                    komut.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(id);
                    komut.Parameters.Add("@kisiad", SqlDbType.NVarChar, 70).Value = cmbAlici.Text;
                    komut.ExecuteNonQuery();
                    sqlBaglantisi.Baglanti().Close();
                    MessageBox.Show("Veri Kaydedildi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        //konuta alıcı ekleme
        public void konutSat(Int64 a, string alan, string d)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpKonutAliciEkle";
            komut.Parameters.Add("@konutId", SqlDbType.BigInt).Value = a;
            komut.Parameters.Add("@alici", SqlDbType.NVarChar, 70).Value = alan;
            if (d == "true")
            {
                komut.Parameters.Add("@satilikmi", SqlDbType.Bit).Value = 1;
            }
            else
            {
                komut.Parameters.Add("@satilikmi", SqlDbType.Bit).Value = 0;
            }
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti();
        }

        //iptal labeline tıklama olayı
        private void LnklblIptal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        //Kişi eklemeye geçiş butonu
        private void LnklblEkle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KisiEkle kisi = new KisiEkle();
            kisi.Show();
        }

    }
}

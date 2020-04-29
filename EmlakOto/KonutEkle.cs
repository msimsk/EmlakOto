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
    public partial class KonutEkle : Form
    {
        //veri tabanı bağlantısı
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        //veriler
        public string id, aciklama, ilce, mahalle, sokak, odaTip, satilik, kat, tip, metrekare, kisi, konutAdi, konutKatSayisi, konutYasi, fiyat, bahce, bodrum, ebeveynBanyo, islem;


        public KonutEkle()
        {
            InitializeComponent();
        }

        //başlangıç işlemleri
        private void KonutEkle_Load(object sender, EventArgs e)
        {
            //yapılacak işlem
            if (islem == "kayıt")
            {
                btnKaydet.Text = "Kaydet";
            }
            else { btnKaydet.Text = "Güncelle"; }

            //oda türlerini ekleme
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpOdaCek";
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                cmbOda.Items.Add(reader[0].ToString());
            }
            sqlBaglantisi.Baglanti().Close();

            //ilçeleri çekme
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

            //konut tipi çekme
            SqlCommand komut2 = new SqlCommand();
            komut2.Connection = sqlBaglantisi.Baglanti();
            komut2.CommandType = CommandType.StoredProcedure;
            komut2.CommandText = "SpTipCek";
            SqlDataReader reader2 = komut2.ExecuteReader();
            while (reader2.Read())
            {
                cmbKonutTur.Items.Add(reader2[0].ToString());
            }
            sqlBaglantisi.Baglanti().Close();

            //kişileri çekme
            SqlCommand komut3 = new SqlCommand();
            komut3.Connection = sqlBaglantisi.Baglanti();
            komut3.CommandType = CommandType.StoredProcedure;
            komut3.CommandText = "SpKisiCek";
            SqlDataReader reader3 = komut3.ExecuteReader();
            while (reader3.Read())
            {
                if (reader3[3].ToString() == "True")
                {
                    cmbKisiler.Items.Add(reader3[0].ToString());
                }
            }
            sqlBaglantisi.Baglanti().Close();

            //güncelleme verilerinin eklenmesi
            cmbKisiler.Text = kisi;
            cmbIlce.Text = ilce;
            cmbMahalle.Text = mahalle;
            cmbSokak.Text = sokak;
            txtKonutAdi.Text = konutAdi;
            cmbKonutTur.Text = tip;
            cmbOda.Text = odaTip;
            txtMetreKare.Text = metrekare;
            txtToplamKat.Text = konutKatSayisi;
            txtKat.Text = kat;
            txtFiyat.Text = fiyat;
            txtBinaYasi.Text = konutYasi;
            rctAciklama.Text = aciklama;
            if (bodrum == "1")
            {
                chbBodrum.Checked = true;
            }
            if (ebeveynBanyo == "1")
            {
                chbEbeveynBanyosu.Checked = true;
            }
            if (bahce == "1")
            {
                chbBahce.Checked = true;
            }
            cmbSatilikKira.Text = satilik;
        }

        //ilçeye göre mahalle çekme
        private void CmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            sqlBaglantisi.Baglanti();
        }

        //mahalleye göre sokak çekme
        private void CmbMahalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSokak.Items.Clear();
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpSokakCek";
            komut.Parameters.Add("@mahalleAd", SqlDbType.NVarChar, 50).Value = cmbMahalle.Text;
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                cmbSokak.Items.Add(reader[0].ToString());
            }
        }

        //konut ekleme butonu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // try
            // {
            if (islem == "kayıt"){
                SqlCommand komut = new SqlCommand();
                komut.Connection = sqlBaglantisi.Baglanti();
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpKonutEkleme";
                komut.Parameters.Add("@aciklama", SqlDbType.NVarChar, 100).Value = rctAciklama.Text;
                komut.Parameters.Add("@ilce", SqlDbType.NVarChar, 30).Value = cmbIlce.Text;
                komut.Parameters.Add("@mahalle", SqlDbType.NVarChar, 50).Value = cmbMahalle.Text;
                komut.Parameters.Add("@sokak", SqlDbType.NVarChar, 50).Value = cmbSokak.Text;
                if (cmbOda.Text != "")
                {
                    komut.Parameters.Add("@oda", SqlDbType.NChar, 7).Value = cmbOda.Text;
                }
                komut.Parameters.Add("@satilik", SqlDbType.NChar, 7).Value = cmbSatilikKira.Text;
                if (txtKat.Text != "")
                {
                    komut.Parameters.Add("@kat", SqlDbType.TinyInt).Value = Convert.ToByte(txtKat.Text);
                }
                komut.Parameters.Add("@tip", SqlDbType.NVarChar, 20).Value = cmbKonutTur.Text;
                komut.Parameters.Add("@metrekare", SqlDbType.Int).Value = Convert.ToInt32(txtMetreKare.Text);
                komut.Parameters.Add("@kisi", SqlDbType.NVarChar, 70).Value = cmbKisiler.Text;
                komut.Parameters.Add("@konutAdi", SqlDbType.NVarChar, 50).Value = txtKonutAdi.Text;
                if (txtToplamKat.Text != "")
                {
                    komut.Parameters.Add("@konutKatSayisi", SqlDbType.TinyInt).Value = Convert.ToByte(txtToplamKat.Text);
                }
                komut.Parameters.Add("@konutYasi", SqlDbType.TinyInt).Value = Convert.ToByte(txtBinaYasi.Text);
                komut.Parameters.Add("@fiyat", SqlDbType.BigInt).Value = Convert.ToInt64(txtFiyat.Text);
                if (chbBahce.Checked)
                {
                    komut.Parameters.Add("@bahce", SqlDbType.Bit).Value = 1;
                }
                if (chbBodrum.Checked)
                {
                    komut.Parameters.Add("@bodrum", SqlDbType.Bit).Value = 1;
                }
                if (chbEbeveynBanyosu.Checked)
                {
                    komut.Parameters.Add("@ebeveynBanyo", SqlDbType.Bit).Value = 1;
                }

                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti();
                MessageBox.Show("Kayıt Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                //güncelleme
                SqlCommand komut = new SqlCommand();
                komut.Connection = sqlBaglantisi.Baglanti();
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpKonutGuncelle";
                komut.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(id);
                komut.Parameters.Add("@aciklama", SqlDbType.NVarChar, 100).Value = rctAciklama.Text;
                komut.Parameters.Add("@ilce", SqlDbType.NVarChar, 30).Value = cmbIlce.Text;
                komut.Parameters.Add("@mahalle", SqlDbType.NVarChar, 50).Value = cmbMahalle.Text;
                komut.Parameters.Add("@sokak", SqlDbType.NVarChar, 50).Value = cmbSokak.Text;
                //if (cmbOda.Text != "")
                //{
                komut.Parameters.Add("@oda", SqlDbType.NChar, 7).Value = cmbOda.Text;
                //}
                komut.Parameters.Add("@satilik", SqlDbType.NChar, 7).Value = cmbSatilikKira.Text;
                if (txtKat.Text != "")
                {
                    komut.Parameters.Add("@kat", SqlDbType.TinyInt).Value = Convert.ToByte(txtKat.Text);
                }
                komut.Parameters.Add("@tip", SqlDbType.NVarChar, 20).Value = cmbKonutTur.Text;
                komut.Parameters.Add("@metrekare", SqlDbType.Int).Value = Convert.ToInt32(txtMetreKare.Text);
                komut.Parameters.Add("@kisi", SqlDbType.NVarChar, 70).Value = cmbKisiler.Text;
                komut.Parameters.Add("@konutAdi", SqlDbType.NVarChar, 50).Value = txtKonutAdi.Text;
                if (txtToplamKat.Text != "")
                {
                    komut.Parameters.Add("@konutKatSayisi", SqlDbType.TinyInt).Value = Convert.ToByte(txtToplamKat.Text);
                }
                komut.Parameters.Add("@konutYasi", SqlDbType.TinyInt).Value = Convert.ToByte(txtBinaYasi.Text);
                komut.Parameters.Add("@fiyat", SqlDbType.BigInt).Value = Convert.ToInt64(txtFiyat.Text);
                if (chbBahce.Checked)
                {
                    komut.Parameters.Add("@bahce", SqlDbType.Bit).Value = 1;
                }
                if (chbBodrum.Checked)
                {
                    komut.Parameters.Add("@bodrum", SqlDbType.Bit).Value = 1;
                }
                if (chbEbeveynBanyosu.Checked)
                {
                    komut.Parameters.Add("@ebeveynBanyo", SqlDbType.Bit).Value = 1;
                }
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti();
                MessageBox.Show("Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            
           // }
           // catch (Exception)
            //{
               // lblHata.Text = "Bir şeyler ters gitti. Değerlerinizi kontrol ediniz!!!";
           // }
            
        }

        
        //İptal labela tıklama durumu
        private void LnklblIptal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        #region tuşa basılınca harfleri engelleme
        private void TxtMetreKare_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtToplamKat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtBinaYasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtKat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

    }
}

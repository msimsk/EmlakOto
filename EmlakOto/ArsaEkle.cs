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
    public partial class ArsaEkle : Form
    {
        //bağlantı oluşturma
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        public ArsaEkle()
        {
            InitializeComponent();
        }

        //değişkenler
        public string id, aciklama, ilce, mahalle, sahip, satkira, adres, m2, fiyat, satildimi, islem;

        //Form açılınca (başlangıç)
        private void ArsaEkle_Load(object sender, EventArgs e)
        {
            //yapılacak işlem
            if (islem == "kayıt")
            {
                btnKaydet.Text = "Kaydet";
            }
            else {
                btnKaydet.Text = "Güncelle";
                grbArsaEkle.Text = "Arsa Güncelle";
            }

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

            //Kişi çekme
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

            //gelen verileri yerleştirme
            cmbIlce.Text = ilce;
            cmbMahalle.Text = mahalle;
            cmbKisiler.Text = sahip;
            cmbSatilikKira.Text = satkira;
            rctAciklama.Text = aciklama;
            rctAdres.Text = adres;
            txtFiyat.Text = fiyat;
            txtMetreKare.Text = m2;
        }

        //formu kapatma
        private void LnklblIptal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        //Kaydet Butonu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (islem == "kayıt")
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = sqlBaglantisi.Baglanti();
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpArsaEkle";
                komut.Parameters.Add("@aciklama", SqlDbType.NVarChar).Value = rctAciklama.Text;
                komut.Parameters.Add("@ilce", SqlDbType.NVarChar, 30).Value = cmbIlce.Text;
                komut.Parameters.Add("@mahalle", SqlDbType.NVarChar, 50).Value = cmbMahalle.Text;
                komut.Parameters.Add("@adres", SqlDbType.NVarChar).Value = rctAdres.Text;
                komut.Parameters.Add("@metreKare", SqlDbType.Int).Value = txtMetreKare.Text;
                komut.Parameters.Add("@fiyat", SqlDbType.BigInt).Value = txtFiyat.Text;
                komut.Parameters.Add("@arsasatdurum", SqlDbType.Bit).Value = 0;
                komut.Parameters.Add("@kisi", SqlDbType.NVarChar, 70).Value = cmbKisiler.Text;
                komut.Parameters.Add("@satDurum", SqlDbType.NChar, 7).Value = cmbSatilikKira.Text;
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Kayıt Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = sqlBaglantisi.Baglanti();
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpArsaGuncelle";
                komut.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(id);
                komut.Parameters.Add("@aciklama", SqlDbType.NVarChar).Value = rctAciklama.Text;
                komut.Parameters.Add("@ilce", SqlDbType.NVarChar, 30).Value = cmbIlce.Text;
                komut.Parameters.Add("@mahalle", SqlDbType.NVarChar, 50).Value = cmbMahalle.Text;
                komut.Parameters.Add("@adres", SqlDbType.NVarChar).Value = rctAdres.Text;
                komut.Parameters.Add("@metreKare", SqlDbType.Int).Value = txtMetreKare.Text;
                komut.Parameters.Add("@fiyat", SqlDbType.BigInt).Value = txtFiyat.Text;
                komut.Parameters.Add("@arsasatdurum", SqlDbType.Bit).Value = 0;
                komut.Parameters.Add("@kisi", SqlDbType.NVarChar, 70).Value = cmbKisiler.Text;
                komut.Parameters.Add("@satDurum", SqlDbType.NChar, 7).Value = cmbSatilikKira.Text;
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        //ilçe Seçimi
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
    }
}

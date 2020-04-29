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
    public partial class Arsa : Form
    {
        //değişkenler
        private string id,sahip, aciklama, adres, satKira, m2, fiyat, alici, satildimi;
        private DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        //cmblerde seçim yapınca diğer cmblerde işlem yapıldı mı yapılmadı mı
        private string islemvarmi;
        
        public Arsa()
        {
            InitializeComponent();
        }

        //Bağlantı oluşturma
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        //Başlangıçta gerçekleşecek işlemler
        private void Arsa_Load(object sender, EventArgs e)
        {
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

            //butonları ekleme işlemi
            btnEkle();

            //dgv verilerini çekme
            baslangic();
        }

        //Başlangıç
        private void baslangic()
        {
            cmbSatilik.SelectedIndex = -1;
            cmbMahalle.SelectedIndex = -1;
            cmbIlce.SelectedIndex = -1;

            //dgv verilerini çekme
            btnSatildimi.Text = "Satılmayanlar";
            dgvSatilanlar(cmbSatilik.Text);
        }

        #region eventlar

        #region geçiş ikonlarına tıklanma olayı
        //Konut Kısmına Geçiş buton ve labeli
        private void BtnKonutGec_Click(object sender, EventArgs e)
        {
            Konut konut = new Konut();
            konut.Show();
            this.Hide();
        }
        private void LblKonutGec_Click(object sender, EventArgs e)
        {
            Konut konut = new Konut();
            konut.Show();
            this.Hide();
        }

        //Arsa Ekleme butonu ve labeli
        private void BtnArsaEkle_Click(object sender, EventArgs e)
        {
            ArsaEkle arsa = new ArsaEkle();
            arsa.islem = "kayıt";
            arsa.Show();
        }

        private void LblArsaEkle_Click(object sender, EventArgs e)
        {
            ArsaEkle arsa = new ArsaEkle();
            arsa.Show();
        }

        //Kişilere geçiş butonu ve labeli
        private void BtnKisiler_Click(object sender, EventArgs e)
        {
            KisiEkle kisi = new KisiEkle();
            kisi.neYapti = "kayıt";
            kisi.Show();
        }
        private void LblKisiler_Click(object sender, EventArgs e)
        {
            KisiEkle kisi = new KisiEkle();
            kisi.Show();
        }

        //Yenileme Butonu
        private void BtnYenile_Click(object sender, EventArgs e)
        {
            baslangic();
        }
        #endregion

        //Form Kapatma
        private void Arsa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        //İlçeye cmboxuna tıklama
        private void CmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (islemvarmi != "yok")
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

                //ilçede bulunan Arsaları çekme
                for (int i = 0; i < (dgvArsalar.Rows.Count); i++)
                {
                    dgvArsalar.Rows[i].Visible = true;
                }

                for (int i = 0; i < (dgvArsalar.Rows.Count); i++)
                {
                    string[] bolunmusAdres1 = dgvArsalar.Rows[i].Cells[5].Value.ToString().Split('/');
                    if (bolunmusAdres1[1] != cmbIlce.Text)
                    {
                        adresGizle(i);
                    }
                }
            }
        }
        //mahalleye tıklama olayı
        private void CmbMahalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (islemvarmi != "yok")
            {
                //ilçede bulunan Arsaları çekme
                for (int i = 0; i < (dgvArsalar.Rows.Count); i++)
                {
                    dgvArsalar.Rows[i].Visible = true;
                }

                for (int i = 0; i < (dgvArsalar.Rows.Count); i++)
                {
                    string[] bolunmusAdres1 = dgvArsalar.Rows[i].Cells[5].Value.ToString().Split('/');
                    if (bolunmusAdres1[0] != cmbMahalle.Text)
                    {
                        adresGizle(i);
                    }
                }
            }
        }
        //satılık combobxuna tıklama olayı
        private void CmbSatilik_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSatilanlar(cmbSatilik.Text);

            // comboları temizleme
            islemvarmi = "yok";
            cmbIlce.SelectedIndex = -1;
            cmbMahalle.SelectedIndex = -1;
            islemvarmi = "var";
        }

      
        //dgvArsalara tıklanma olayı
        private void DgvArsalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgvArsalar.SelectedCells[0].RowIndex;
            veriAta(secilen);

            //Güncellemek için verileri atama
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                ArsaEkle ekle = new ArsaEkle();
                ekle.id = id;
                ekle.aciklama = aciklama;
                ekle.sahip = sahip;
                ekle.satkira = satKira;
                ekle.m2 = m2;
                ekle.fiyat = fiyat;
                ekle.satildimi = satildimi;

                string[] ayir = dgvArsalar.Rows[secilen].Cells[5].Value.ToString().Split('/');
                if(ayir.Length == 3)
                {
                    ekle.adres = ayir[0];
                    ekle.ilce = ayir[2];
                    ekle.mahalle = ayir[1];
                    
                }
                else
                {
                    ekle.adres = "";
                    ekle.ilce = ayir[1];
                    ekle.mahalle = ayir[0];
                }
                ekle.Show();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                //silme işlemi
                DialogResult silme = new DialogResult();
                silme = MessageBox.Show("Silmek istediğinden emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (silme == DialogResult.Yes)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlBaglantisi.Baglanti();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SpArsaSil";
                    command.Parameters.Add("@id", SqlDbType.BigInt).Value = Convert.ToInt64(id);
                    command.ExecuteNonQuery();
                    sqlBaglantisi.Baglanti().Close();
                    MessageBox.Show("Arsa Silindi!!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }else if(e.RowIndex != -1 && e.ColumnIndex == 2)
            {
                if (btnSatildimi.Text == "Satılmayanlar")
                {
                    arsaAliciSaticiVeriGonder("sat");
                }
                else
                {
                    arsaAliciSaticiVeriGonder("");
                }
            }
            else if (e.RowIndex != -1)
            {
                if (btnSatildimi.Text == "Satılmayanlar")
                {
                    arsaAliciSaticiVeriGonder("alıcıekle");
                }
                else
                {
                    arsaAliciSaticiVeriGonder("");
                }
            }
        }

        //Verileri arsaalicivebilgi formuna gönderme
        private void arsaAliciSaticiVeriGonder(string islem)
        {
            //verileri detaylı çekme
            ArsaAliciVeBilgi arsaAliciVeBilgi = new ArsaAliciVeBilgi();
            arsaAliciVeBilgi.sahip = sahip;
            arsaAliciVeBilgi.satKira = satKira;
            arsaAliciVeBilgi.fiyat = fiyat;
            arsaAliciVeBilgi.adres = adres;
            arsaAliciVeBilgi.alici = alici;
            arsaAliciVeBilgi.arsaId = id;
            arsaAliciVeBilgi.yapilanIslem = islem;
            arsaAliciVeBilgi.m2 = m2;
            arsaAliciVeBilgi.Show();

        }

        //cmbsatildimi combosuna tıklanma olayı
        private void BtnSatildimi_Click(object sender, EventArgs e)
        {
            if(btnSatildimi.Text == "Satılmayanlar")
            {
                btnSatildimi.Text = "Satılanlar";
            }
            else
            {
                btnSatildimi.Text = "Satılmayanlar";
            }
            cmbIlce.SelectedIndex = -1;
            cmbMahalle.SelectedIndex = -1;
            cmbSatilik.SelectedIndex = -1;
            dgvSatilanlar(cmbSatilik.Text);
            btnSat();
        }
        #region Oluşturulan metodlar


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
                dgvArsalar.DataSource = null;
                SqlCommand komut = new SqlCommand();
                komut.Connection = sqlBaglantisi.Baglanti();
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SpArsaSatildiCek";
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
                dgvArsalar.DataSource = table;
                dgvTasarim();
                sqlBaglantisi.Baglanti().Close();
            }
        }

        //satilik veya kiralıkları dgvsatilanlar ile çekme
        private void kiraluk(string a)
        {
            dgvArsalar.DataSource = null;
            SqlCommand komut = new SqlCommand();
            komut.Connection = sqlBaglantisi.Baglanti();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SpArsaKiralikCek";
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
            dgvArsalar.DataSource = table;
            dgvTasarim();
            sqlBaglantisi.Baglanti().Close();
        }

        //Adres Gizle
        private void adresGizle(int i)
        {
            //bu kısımda bindingi durdurup tekrar devam ettirmek gerekiyormuş !!!
            CurrencyManager cm = (CurrencyManager)BindingContext[dgvArsalar.DataSource];
            cm.SuspendBinding();
            dgvArsalar.Rows[i].Visible = false;
            cm.ResumeBinding();
        }

        //verileri atama
        private void veriAta(int secilen)
        {
            sahip = dgvArsalar.Rows[secilen].Cells[4].Value.ToString();
            satKira = dgvArsalar.Rows[secilen].Cells[7].Value.ToString();
            fiyat = dgvArsalar.Rows[secilen].Cells[9].Value.ToString();
            adres = dgvArsalar.Rows[secilen].Cells[5].Value.ToString();
            id = dgvArsalar.Rows[secilen].Cells[3].Value.ToString();
            aciklama = dgvArsalar.Rows[secilen].Cells[6].Value.ToString();
            m2 = dgvArsalar.Rows[secilen].Cells[8].Value.ToString();
            satildimi = dgvArsalar.Rows[secilen].Cells[10].Value.ToString();

            alici = dgvArsalar.Rows[secilen].Cells[11].Value.ToString();
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

        //tasarim diyelim
        private void dgvTasarim()
        {
            dgvArsalar.Columns[0].DisplayIndex = 10;
            dgvArsalar.Columns[1].DisplayIndex = 10;
            dgvArsalar.Columns[2].DisplayIndex = 10;

            dgvArsalar.Columns[3].Visible = false;
            dgvArsalar.Columns[11].Visible = false;
            for (int i = 0; i < (dgvArsalar.Columns.Count - 1); i++)
            {
                if (dgvArsalar.Columns[i].HeaderText != "Adres" && dgvArsalar.Columns[i].HeaderText != "Açıklama")
                {
                    dgvArsalar.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
            string[] ayir;
            for (int i = 0; i < dgvArsalar.Rows.Count; i++)
            {
                ayir = dgvArsalar.Rows[i].Cells[5].Value.ToString().Split('/');
                if (ayir[0] == "")
                {
                    dgvArsalar.Rows[i].Cells[5].Value = ayir[1] + "/" + ayir[2];
                }
            }
        }

        //butonları data gride ekleme kısmı
        private void btnEkle()
        {
            //Güncelle butonu ekleme
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Güncelle";
            btn.HeaderText = "";
            dgvArsalar.Columns.Add(btn);
            btn.UseColumnTextForButtonValue = true;

            //Sil butonu ekleme
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.Text = "Sil";
            btn1.HeaderText = "";
            dgvArsalar.Columns.Add(btn1);
            btn1.UseColumnTextForButtonValue = true;
            
            //Sat butonu ekleme
            btn2.Text = "Sat";
            btn2.HeaderText = "";
            dgvArsalar.Columns.Add(btn2);
            btn2.UseColumnTextForButtonValue = true;
        }

        //satma butonunu değiştirme
        private void btnSat()
        {
            if (btnSatildimi.Text == "Satılmayanlar")
            {
                btn2.Text = "Sat";
                btn2.UseColumnTextForButtonValue = true;
            }
            else
            {
                btn2.Text = "Satış İptal";
                btn2.UseColumnTextForButtonValue = true;
            }
        }
        #endregion
    }
}

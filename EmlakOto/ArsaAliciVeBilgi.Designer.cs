namespace EmlakOto
{
    partial class ArsaAliciVeBilgi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbArsaAliciEkleSat = new System.Windows.Forms.GroupBox();
            this.lnklblCIptal = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAlmakIsteyenler = new System.Windows.Forms.ComboBox();
            this.lnklblCikis = new System.Windows.Forms.LinkLabel();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.lblM2 = new System.Windows.Forms.Label();
            this.lblKiraSat = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.lnklblEkle = new System.Windows.Forms.LinkLabel();
            this.cmbAlici = new System.Windows.Forms.ComboBox();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.lblAdres = new System.Windows.Forms.Label();
            this.lblAlici = new System.Windows.Forms.Label();
            this.lblSahip = new System.Windows.Forms.Label();
            this.dgvAlmakIsteyenKullanicilar = new System.Windows.Forms.DataGridView();
            this.grbArsaAliciEkleSat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlmakIsteyenKullanicilar)).BeginInit();
            this.SuspendLayout();
            // 
            // grbArsaAliciEkleSat
            // 
            this.grbArsaAliciEkleSat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grbArsaAliciEkleSat.Controls.Add(this.lnklblCIptal);
            this.grbArsaAliciEkleSat.Controls.Add(this.label2);
            this.grbArsaAliciEkleSat.Controls.Add(this.label1);
            this.grbArsaAliciEkleSat.Controls.Add(this.cmbAlmakIsteyenler);
            this.grbArsaAliciEkleSat.Controls.Add(this.lnklblCikis);
            this.grbArsaAliciEkleSat.Controls.Add(this.dgvAlmakIsteyenKullanicilar);
            this.grbArsaAliciEkleSat.Controls.Add(this.lblAciklama);
            this.grbArsaAliciEkleSat.Controls.Add(this.lblM2);
            this.grbArsaAliciEkleSat.Controls.Add(this.lblKiraSat);
            this.grbArsaAliciEkleSat.Controls.Add(this.btnKaydet);
            this.grbArsaAliciEkleSat.Controls.Add(this.lnklblEkle);
            this.grbArsaAliciEkleSat.Controls.Add(this.cmbAlici);
            this.grbArsaAliciEkleSat.Controls.Add(this.lblFiyat);
            this.grbArsaAliciEkleSat.Controls.Add(this.lblAdres);
            this.grbArsaAliciEkleSat.Controls.Add(this.lblAlici);
            this.grbArsaAliciEkleSat.Controls.Add(this.lblSahip);
            this.grbArsaAliciEkleSat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grbArsaAliciEkleSat.Location = new System.Drawing.Point(12, 12);
            this.grbArsaAliciEkleSat.Name = "grbArsaAliciEkleSat";
            this.grbArsaAliciEkleSat.Size = new System.Drawing.Size(756, 443);
            this.grbArsaAliciEkleSat.TabIndex = 19;
            this.grbArsaAliciEkleSat.TabStop = false;
            this.grbArsaAliciEkleSat.Text = "Seçilen Arsa";
            // 
            // lnklblCIptal
            // 
            this.lnklblCIptal.AutoSize = true;
            this.lnklblCIptal.Location = new System.Drawing.Point(332, 143);
            this.lnklblCIptal.Name = "lnklblCIptal";
            this.lnklblCIptal.Size = new System.Drawing.Size(56, 27);
            this.lnklblCIptal.TabIndex = 36;
            this.lnklblCIptal.TabStop = true;
            this.lnklblCIptal.Text = "İptal";
            this.lnklblCIptal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnklblCIptal_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 27);
            this.label2.TabIndex = 35;
            this.label2.Text = "İsteyenler:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 27);
            this.label1.TabIndex = 34;
            this.label1.Text = "Almak";
            // 
            // cmbAlmakIsteyenler
            // 
            this.cmbAlmakIsteyenler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlmakIsteyenler.FormattingEnabled = true;
            this.cmbAlmakIsteyenler.Location = new System.Drawing.Point(125, 140);
            this.cmbAlmakIsteyenler.Name = "cmbAlmakIsteyenler";
            this.cmbAlmakIsteyenler.Size = new System.Drawing.Size(201, 34);
            this.cmbAlmakIsteyenler.TabIndex = 33;
            this.cmbAlmakIsteyenler.SelectedIndexChanged += new System.EventHandler(this.CmbAlmakIsteyenler_SelectedIndexChanged);
            // 
            // lnklblCikis
            // 
            this.lnklblCikis.AutoSize = true;
            this.lnklblCikis.Location = new System.Drawing.Point(689, 16);
            this.lnklblCikis.Name = "lnklblCikis";
            this.lnklblCikis.Size = new System.Drawing.Size(61, 27);
            this.lnklblCikis.TabIndex = 15;
            this.lnklblCikis.TabStop = true;
            this.lnklblCikis.Text = "Çıkış";
            this.lnklblCikis.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnklblCikis_LinkClicked);
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(5, 282);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(110, 27);
            this.lblAciklama.TabIndex = 13;
            this.lblAciklama.Text = "Açıklama:";
            // 
            // lblM2
            // 
            this.lblM2.AutoSize = true;
            this.lblM2.Location = new System.Drawing.Point(5, 366);
            this.lblM2.Name = "lblM2";
            this.lblM2.Size = new System.Drawing.Size(129, 27);
            this.lblM2.TabIndex = 12;
            this.lblM2.Text = "Metre Kare:";
            // 
            // lblKiraSat
            // 
            this.lblKiraSat.AutoSize = true;
            this.lblKiraSat.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKiraSat.Location = new System.Drawing.Point(421, 16);
            this.lblKiraSat.Name = "lblKiraSat";
            this.lblKiraSat.Size = new System.Drawing.Size(0, 33);
            this.lblKiraSat.TabIndex = 11;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.Khaki;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKaydet.Location = new System.Drawing.Point(221, 398);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(200, 39);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // lnklblEkle
            // 
            this.lnklblEkle.AutoSize = true;
            this.lnklblEkle.Location = new System.Drawing.Point(332, 76);
            this.lnklblEkle.Name = "lnklblEkle";
            this.lnklblEkle.Size = new System.Drawing.Size(56, 27);
            this.lnklblEkle.TabIndex = 8;
            this.lnklblEkle.TabStop = true;
            this.lnklblEkle.Text = "Ekle";
            // 
            // cmbAlici
            // 
            this.cmbAlici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlici.FormattingEnabled = true;
            this.cmbAlici.Location = new System.Drawing.Point(125, 73);
            this.cmbAlici.Name = "cmbAlici";
            this.cmbAlici.Size = new System.Drawing.Size(201, 34);
            this.cmbAlici.TabIndex = 7;
            this.cmbAlici.SelectedIndexChanged += new System.EventHandler(this.CmbAlici_SelectedIndexChanged);
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Location = new System.Drawing.Point(5, 324);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(67, 27);
            this.lblFiyat.TabIndex = 3;
            this.lblFiyat.Text = "Fiyat:";
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Location = new System.Drawing.Point(5, 210);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(75, 27);
            this.lblAdres.TabIndex = 2;
            this.lblAdres.Text = "Adres:";
            // 
            // lblAlici
            // 
            this.lblAlici.AutoSize = true;
            this.lblAlici.Location = new System.Drawing.Point(5, 73);
            this.lblAlici.Name = "lblAlici";
            this.lblAlici.Size = new System.Drawing.Size(64, 27);
            this.lblAlici.TabIndex = 1;
            this.lblAlici.Text = "Alıcı:";
            // 
            // lblSahip
            // 
            this.lblSahip.AutoSize = true;
            this.lblSahip.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSahip.Location = new System.Drawing.Point(5, 30);
            this.lblSahip.Name = "lblSahip";
            this.lblSahip.Size = new System.Drawing.Size(95, 33);
            this.lblSahip.TabIndex = 0;
            this.lblSahip.Text = "Sahibi:";
            // 
            // dgvAlmakIsteyenKullanicilar
            // 
            this.dgvAlmakIsteyenKullanicilar.AllowUserToAddRows = false;
            this.dgvAlmakIsteyenKullanicilar.AllowUserToDeleteRows = false;
            this.dgvAlmakIsteyenKullanicilar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlmakIsteyenKullanicilar.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlmakIsteyenKullanicilar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlmakIsteyenKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlmakIsteyenKullanicilar.Location = new System.Drawing.Point(427, 46);
            this.dgvAlmakIsteyenKullanicilar.Name = "dgvAlmakIsteyenKullanicilar";
            this.dgvAlmakIsteyenKullanicilar.ReadOnly = true;
            this.dgvAlmakIsteyenKullanicilar.RowHeadersWidth = 51;
            this.dgvAlmakIsteyenKullanicilar.RowTemplate.Height = 24;
            this.dgvAlmakIsteyenKullanicilar.Size = new System.Drawing.Size(323, 391);
            this.dgvAlmakIsteyenKullanicilar.TabIndex = 14;
            this.dgvAlmakIsteyenKullanicilar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAlmakIsteyenKullanicilar_CellClick);
            // 
            // ArsaAliciVeBilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(780, 467);
            this.Controls.Add(this.grbArsaAliciEkleSat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ArsaAliciVeBilgi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArsaAliciVeBilgi";
            this.Load += new System.EventHandler(this.ArsaAliciVeBilgi_Load);
            this.grbArsaAliciEkleSat.ResumeLayout(false);
            this.grbArsaAliciEkleSat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlmakIsteyenKullanicilar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbArsaAliciEkleSat;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.LinkLabel lnklblEkle;
        private System.Windows.Forms.ComboBox cmbAlici;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.Label lblAlici;
        private System.Windows.Forms.Label lblSahip;
        private System.Windows.Forms.Label lblKiraSat;
        private System.Windows.Forms.Label lblM2;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.LinkLabel lnklblCikis;
        private System.Windows.Forms.LinkLabel lnklblCIptal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAlmakIsteyenler;
        private System.Windows.Forms.DataGridView dgvAlmakIsteyenKullanicilar;
    }
}
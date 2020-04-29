namespace EmlakOto
{
    partial class Konut
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Konut));
            this.cmbOda = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvKonutlar = new System.Windows.Forms.DataGridView();
            this.cmbSatilik = new System.Windows.Forms.ComboBox();
            this.cmbSokak = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIlce = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMahalle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnYenile = new System.Windows.Forms.Button();
            this.lblKisiler = new System.Windows.Forms.Label();
            this.btnKisiler = new System.Windows.Forms.Button();
            this.lblArsaGec = new System.Windows.Forms.Label();
            this.btnArsaGec = new System.Windows.Forms.Button();
            this.LblKonutEkle = new System.Windows.Forms.Label();
            this.btnKonutEkle = new System.Windows.Forms.Button();
            this.btnSatildimi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKonutlar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbOda
            // 
            this.cmbOda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOda.FormattingEnabled = true;
            this.cmbOda.Location = new System.Drawing.Point(132, 187);
            this.cmbOda.Name = "cmbOda";
            this.cmbOda.Size = new System.Drawing.Size(188, 34);
            this.cmbOda.TabIndex = 5;
            this.cmbOda.SelectedIndexChanged += new System.EventHandler(this.CmbOda_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Oda Sayısı:";
            // 
            // dgvKonutlar
            // 
            this.dgvKonutlar.AllowUserToAddRows = false;
            this.dgvKonutlar.AllowUserToDeleteRows = false;
            this.dgvKonutlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKonutlar.BackgroundColor = System.Drawing.Color.White;
            this.dgvKonutlar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKonutlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKonutlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKonutlar.Location = new System.Drawing.Point(0, 0);
            this.dgvKonutlar.Name = "dgvKonutlar";
            this.dgvKonutlar.ReadOnly = true;
            this.dgvKonutlar.RowHeadersWidth = 51;
            this.dgvKonutlar.RowTemplate.Height = 24;
            this.dgvKonutlar.Size = new System.Drawing.Size(1168, 752);
            this.dgvKonutlar.TabIndex = 2;
            this.dgvKonutlar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvKonutlar_CellClick);
            // 
            // cmbSatilik
            // 
            this.cmbSatilik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSatilik.FormattingEnabled = true;
            this.cmbSatilik.Items.AddRange(new object[] {
            "Kiralık",
            "Satılık"});
            this.cmbSatilik.Location = new System.Drawing.Point(132, 27);
            this.cmbSatilik.Name = "cmbSatilik";
            this.cmbSatilik.Size = new System.Drawing.Size(188, 34);
            this.cmbSatilik.TabIndex = 1;
            this.cmbSatilik.SelectedIndexChanged += new System.EventHandler(this.CmbSatilik_SelectedIndexChanged_1);
            // 
            // cmbSokak
            // 
            this.cmbSokak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSokak.FormattingEnabled = true;
            this.cmbSokak.Location = new System.Drawing.Point(132, 147);
            this.cmbSokak.Name = "cmbSokak";
            this.cmbSokak.Size = new System.Drawing.Size(188, 34);
            this.cmbSokak.TabIndex = 4;
            this.cmbSokak.SelectedIndexChanged += new System.EventHandler(this.CmbSokak_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 27);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sokak:";
            // 
            // cmbIlce
            // 
            this.cmbIlce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIlce.FormattingEnabled = true;
            this.cmbIlce.Location = new System.Drawing.Point(132, 67);
            this.cmbIlce.Name = "cmbIlce";
            this.cmbIlce.Size = new System.Drawing.Size(188, 34);
            this.cmbIlce.TabIndex = 2;
            this.cmbIlce.SelectedIndexChanged += new System.EventHandler(this.CmbIlce_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "İlçe:";
            // 
            // cmbMahalle
            // 
            this.cmbMahalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMahalle.FormattingEnabled = true;
            this.cmbMahalle.Location = new System.Drawing.Point(132, 107);
            this.cmbMahalle.Name = "cmbMahalle";
            this.cmbMahalle.Size = new System.Drawing.Size(188, 34);
            this.cmbMahalle.TabIndex = 3;
            this.cmbMahalle.SelectedIndexChanged += new System.EventHandler(this.CmbMahalle_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mahalle:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.cmbSatilik);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbSokak);
            this.groupBox1.Controls.Add(this.cmbOda);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbIlce);
            this.groupBox1.Controls.Add(this.cmbMahalle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 261);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arama";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvKonutlar);
            this.panel1.Location = new System.Drawing.Point(360, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1168, 752);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.btnYenile);
            this.panel2.Controls.Add(this.lblKisiler);
            this.panel2.Controls.Add(this.btnKisiler);
            this.panel2.Controls.Add(this.lblArsaGec);
            this.panel2.Controls.Add(this.btnArsaGec);
            this.panel2.Controls.Add(this.LblKonutEkle);
            this.panel2.Controls.Add(this.btnKonutEkle);
            this.panel2.Controls.Add(this.btnSatildimi);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 274);
            this.panel2.TabIndex = 18;
            // 
            // btnYenile
            // 
            this.btnYenile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYenile.BackgroundImage")));
            this.btnYenile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYenile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Location = new System.Drawing.Point(132, 135);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(83, 60);
            this.btnYenile.TabIndex = 27;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.BtnYenile_Click);
            // 
            // lblKisiler
            // 
            this.lblKisiler.AutoSize = true;
            this.lblKisiler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKisiler.Location = new System.Drawing.Point(245, 105);
            this.lblKisiler.Name = "lblKisiler";
            this.lblKisiler.Size = new System.Drawing.Size(75, 27);
            this.lblKisiler.TabIndex = 26;
            this.lblKisiler.Text = "Kişiler";
            this.lblKisiler.Click += new System.EventHandler(this.LblKisiler_Click);
            // 
            // btnKisiler
            // 
            this.btnKisiler.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKisiler.BackgroundImage")));
            this.btnKisiler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKisiler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKisiler.FlatAppearance.BorderSize = 0;
            this.btnKisiler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKisiler.Location = new System.Drawing.Point(228, 26);
            this.btnKisiler.Name = "btnKisiler";
            this.btnKisiler.Size = new System.Drawing.Size(105, 76);
            this.btnKisiler.TabIndex = 25;
            this.btnKisiler.UseVisualStyleBackColor = true;
            this.btnKisiler.Click += new System.EventHandler(this.BtnKisiler_Click);
            // 
            // lblArsaGec
            // 
            this.lblArsaGec.AutoSize = true;
            this.lblArsaGec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblArsaGec.Location = new System.Drawing.Point(142, 105);
            this.lblArsaGec.Name = "lblArsaGec";
            this.lblArsaGec.Size = new System.Drawing.Size(57, 27);
            this.lblArsaGec.TabIndex = 24;
            this.lblArsaGec.Text = "Arsa";
            this.lblArsaGec.Click += new System.EventHandler(this.LblArsaGec_Click);
            // 
            // btnArsaGec
            // 
            this.btnArsaGec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnArsaGec.BackgroundImage")));
            this.btnArsaGec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnArsaGec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArsaGec.FlatAppearance.BorderSize = 0;
            this.btnArsaGec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArsaGec.Location = new System.Drawing.Point(117, 26);
            this.btnArsaGec.Name = "btnArsaGec";
            this.btnArsaGec.Size = new System.Drawing.Size(105, 76);
            this.btnArsaGec.TabIndex = 23;
            this.btnArsaGec.UseVisualStyleBackColor = true;
            this.btnArsaGec.Click += new System.EventHandler(this.BtnArsaGec_Click);
            // 
            // LblKonutEkle
            // 
            this.LblKonutEkle.AutoSize = true;
            this.LblKonutEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblKonutEkle.Location = new System.Drawing.Point(6, 105);
            this.LblKonutEkle.Name = "LblKonutEkle";
            this.LblKonutEkle.Size = new System.Drawing.Size(122, 27);
            this.LblKonutEkle.TabIndex = 22;
            this.LblKonutEkle.Text = "Konut Ekle";
            this.LblKonutEkle.Click += new System.EventHandler(this.LblKonutEkle_Click);
            // 
            // btnKonutEkle
            // 
            this.btnKonutEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKonutEkle.BackgroundImage")));
            this.btnKonutEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKonutEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKonutEkle.FlatAppearance.BorderSize = 0;
            this.btnKonutEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKonutEkle.Location = new System.Drawing.Point(6, 26);
            this.btnKonutEkle.Name = "btnKonutEkle";
            this.btnKonutEkle.Size = new System.Drawing.Size(105, 76);
            this.btnKonutEkle.TabIndex = 21;
            this.btnKonutEkle.UseVisualStyleBackColor = true;
            this.btnKonutEkle.Click += new System.EventHandler(this.BtnKonutEkle_Click);
            // 
            // btnSatildimi
            // 
            this.btnSatildimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSatildimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatildimi.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSatildimi.Location = new System.Drawing.Point(45, 201);
            this.btnSatildimi.Name = "btnSatildimi";
            this.btnSatildimi.Size = new System.Drawing.Size(255, 56);
            this.btnSatildimi.TabIndex = 14;
            this.btnSatildimi.Text = "Satılmayanlar";
            this.btnSatildimi.UseVisualStyleBackColor = false;
            this.btnSatildimi.Click += new System.EventHandler(this.BtnSatildimi_Click);
            // 
            // Konut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1541, 796);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Konut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emlak";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Konut_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKonutlar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbOda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvKonutlar;
        private System.Windows.Forms.ComboBox cmbSatilik;
        private System.Windows.Forms.ComboBox cmbSokak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIlce;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMahalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSatildimi;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Label lblKisiler;
        private System.Windows.Forms.Button btnKisiler;
        private System.Windows.Forms.Label lblArsaGec;
        private System.Windows.Forms.Button btnArsaGec;
        private System.Windows.Forms.Label LblKonutEkle;
        private System.Windows.Forms.Button btnKonutEkle;
    }
}


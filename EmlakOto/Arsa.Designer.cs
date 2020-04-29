namespace EmlakOto
{
    partial class Arsa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arsa));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSatilik = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIlce = new System.Windows.Forms.ComboBox();
            this.cmbMahalle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvArsalar = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.lblKisiler = new System.Windows.Forms.Label();
            this.btnKisiler = new System.Windows.Forms.Button();
            this.lblArsaEkle = new System.Windows.Forms.Label();
            this.btnArsaEkle = new System.Windows.Forms.Button();
            this.LblKonutGec = new System.Windows.Forms.Label();
            this.btnKonutGec = new System.Windows.Forms.Button();
            this.btnSatildimi = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArsalar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.cmbSatilik);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbIlce);
            this.groupBox1.Controls.Add(this.cmbMahalle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 294);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 237);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arama";
            // 
            // cmbSatilik
            // 
            this.cmbSatilik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSatilik.FormattingEnabled = true;
            this.cmbSatilik.Items.AddRange(new object[] {
            "Kiralık",
            "Satılık"});
            this.cmbSatilik.Location = new System.Drawing.Point(156, 27);
            this.cmbSatilik.Name = "cmbSatilik";
            this.cmbSatilik.Size = new System.Drawing.Size(188, 34);
            this.cmbSatilik.TabIndex = 1;
            this.cmbSatilik.SelectedIndexChanged += new System.EventHandler(this.CmbSatilik_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mahalle/Köy:";
            // 
            // cmbIlce
            // 
            this.cmbIlce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIlce.FormattingEnabled = true;
            this.cmbIlce.Location = new System.Drawing.Point(156, 67);
            this.cmbIlce.Name = "cmbIlce";
            this.cmbIlce.Size = new System.Drawing.Size(188, 34);
            this.cmbIlce.TabIndex = 2;
            this.cmbIlce.SelectedIndexChanged += new System.EventHandler(this.CmbIlce_SelectedIndexChanged);
            // 
            // cmbMahalle
            // 
            this.cmbMahalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMahalle.FormattingEnabled = true;
            this.cmbMahalle.Location = new System.Drawing.Point(156, 107);
            this.cmbMahalle.Name = "cmbMahalle";
            this.cmbMahalle.Size = new System.Drawing.Size(188, 34);
            this.cmbMahalle.TabIndex = 3;
            this.cmbMahalle.SelectedIndexChanged += new System.EventHandler(this.CmbMahalle_SelectedIndexChanged);
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
            // dgvArsalar
            // 
            this.dgvArsalar.AllowUserToAddRows = false;
            this.dgvArsalar.AllowUserToDeleteRows = false;
            this.dgvArsalar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArsalar.BackgroundColor = System.Drawing.Color.White;
            this.dgvArsalar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArsalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArsalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArsalar.Location = new System.Drawing.Point(0, 0);
            this.dgvArsalar.Name = "dgvArsalar";
            this.dgvArsalar.ReadOnly = true;
            this.dgvArsalar.RowHeadersWidth = 51;
            this.dgvArsalar.RowTemplate.Height = 24;
            this.dgvArsalar.Size = new System.Drawing.Size(1147, 752);
            this.dgvArsalar.TabIndex = 17;
            this.dgvArsalar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArsalar_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.btnYenile);
            this.groupBox2.Controls.Add(this.lblKisiler);
            this.groupBox2.Controls.Add(this.btnKisiler);
            this.groupBox2.Controls.Add(this.lblArsaEkle);
            this.groupBox2.Controls.Add(this.btnArsaEkle);
            this.groupBox2.Controls.Add(this.LblKonutGec);
            this.groupBox2.Controls.Add(this.btnKonutGec);
            this.groupBox2.Controls.Add(this.btnSatildimi);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 276);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // btnYenile
            // 
            this.btnYenile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYenile.BackgroundImage")));
            this.btnYenile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYenile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYenile.FlatAppearance.BorderSize = 0;
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Location = new System.Drawing.Point(137, 132);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(83, 60);
            this.btnYenile.TabIndex = 20;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.BtnYenile_Click);
            // 
            // lblKisiler
            // 
            this.lblKisiler.AutoSize = true;
            this.lblKisiler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKisiler.Location = new System.Drawing.Point(269, 102);
            this.lblKisiler.Name = "lblKisiler";
            this.lblKisiler.Size = new System.Drawing.Size(75, 27);
            this.lblKisiler.TabIndex = 19;
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
            this.btnKisiler.Location = new System.Drawing.Point(243, 23);
            this.btnKisiler.Name = "btnKisiler";
            this.btnKisiler.Size = new System.Drawing.Size(114, 76);
            this.btnKisiler.TabIndex = 18;
            this.btnKisiler.UseVisualStyleBackColor = true;
            this.btnKisiler.Click += new System.EventHandler(this.BtnKisiler_Click);
            // 
            // lblArsaEkle
            // 
            this.lblArsaEkle.AutoSize = true;
            this.lblArsaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblArsaEkle.Location = new System.Drawing.Point(13, 102);
            this.lblArsaEkle.Name = "lblArsaEkle";
            this.lblArsaEkle.Size = new System.Drawing.Size(107, 27);
            this.lblArsaEkle.TabIndex = 17;
            this.lblArsaEkle.Text = "Arsa Ekle";
            this.lblArsaEkle.Click += new System.EventHandler(this.LblArsaEkle_Click);
            // 
            // btnArsaEkle
            // 
            this.btnArsaEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnArsaEkle.BackgroundImage")));
            this.btnArsaEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnArsaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArsaEkle.FlatAppearance.BorderSize = 0;
            this.btnArsaEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArsaEkle.Location = new System.Drawing.Point(6, 23);
            this.btnArsaEkle.Name = "btnArsaEkle";
            this.btnArsaEkle.Size = new System.Drawing.Size(114, 76);
            this.btnArsaEkle.TabIndex = 16;
            this.btnArsaEkle.UseVisualStyleBackColor = true;
            this.btnArsaEkle.Click += new System.EventHandler(this.BtnArsaEkle_Click);
            // 
            // LblKonutGec
            // 
            this.LblKonutGec.AutoSize = true;
            this.LblKonutGec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblKonutGec.Location = new System.Drawing.Point(147, 102);
            this.LblKonutGec.Name = "LblKonutGec";
            this.LblKonutGec.Size = new System.Drawing.Size(72, 27);
            this.LblKonutGec.TabIndex = 15;
            this.LblKonutGec.Text = "Konut";
            this.LblKonutGec.Click += new System.EventHandler(this.LblKonutGec_Click);
            // 
            // btnKonutGec
            // 
            this.btnKonutGec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKonutGec.BackgroundImage")));
            this.btnKonutGec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKonutGec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKonutGec.FlatAppearance.BorderSize = 0;
            this.btnKonutGec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKonutGec.Location = new System.Drawing.Point(124, 23);
            this.btnKonutGec.Name = "btnKonutGec";
            this.btnKonutGec.Size = new System.Drawing.Size(113, 76);
            this.btnKonutGec.TabIndex = 14;
            this.btnKonutGec.UseVisualStyleBackColor = true;
            this.btnKonutGec.Click += new System.EventHandler(this.BtnKonutGec_Click);
            // 
            // btnSatildimi
            // 
            this.btnSatildimi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSatildimi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSatildimi.FlatAppearance.BorderSize = 0;
            this.btnSatildimi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatildimi.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSatildimi.Location = new System.Drawing.Point(11, 198);
            this.btnSatildimi.Name = "btnSatildimi";
            this.btnSatildimi.Size = new System.Drawing.Size(333, 72);
            this.btnSatildimi.TabIndex = 13;
            this.btnSatildimi.Text = "Satılmayanlar";
            this.btnSatildimi.UseVisualStyleBackColor = false;
            this.btnSatildimi.Click += new System.EventHandler(this.BtnSatildimi_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvArsalar);
            this.panel1.Location = new System.Drawing.Point(381, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 752);
            this.panel1.TabIndex = 18;
            // 
            // Arsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1541, 796);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Arsa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arsa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Arsa_FormClosed);
            this.Load += new System.EventHandler(this.Arsa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArsalar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSatilik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbIlce;
        private System.Windows.Forms.ComboBox cmbMahalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvArsalar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSatildimi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblKonutGec;
        private System.Windows.Forms.Button btnKonutGec;
        private System.Windows.Forms.Label lblArsaEkle;
        private System.Windows.Forms.Button btnArsaEkle;
        private System.Windows.Forms.Label lblKisiler;
        private System.Windows.Forms.Button btnKisiler;
        private System.Windows.Forms.Button btnYenile;
    }
}
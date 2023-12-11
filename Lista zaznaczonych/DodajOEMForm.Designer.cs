using Hydra;
using System.Drawing;
using System.Windows.Forms;

namespace WyszukiwanieGrup
{
    partial class DodajOEMForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DodajOEMForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dodajIcon = new System.Windows.Forms.ImageList(this.components);
            this.zapiszIcon = new System.Windows.Forms.ImageList(this.components);
            this.usunIcon = new System.Windows.Forms.ImageList(this.components);
            this.wklejIcon = new System.Windows.Forms.ImageList(this.components);
            this.wklejButton = new System.Windows.Forms.Button();
            this.usunButton = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.dodajButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.kodOEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dostawca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pokazB2B = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.szukajB2B = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dostawcaGidNumer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oemGidNumer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodOEM,
            this.dostawca,
            this.pokazB2B,
            this.szukajB2B,
            this.dostawcaGidNumer,
            this.oemGidNumer});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(346, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // dodajIcon
            // 
            this.dodajIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("dodajIcon.ImageStream")));
            this.dodajIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.dodajIcon.Images.SetKeyName(0, "more.png");
            // 
            // zapiszIcon
            // 
            this.zapiszIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("zapiszIcon.ImageStream")));
            this.zapiszIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.zapiszIcon.Images.SetKeyName(0, "floppy-disc.png");
            // 
            // usunIcon
            // 
            this.usunIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("usunIcon.ImageStream")));
            this.usunIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.usunIcon.Images.SetKeyName(0, "bin.png");
            // 
            // wklejIcon
            // 
            this.wklejIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("wklejIcon.ImageStream")));
            this.wklejIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.wklejIcon.Images.SetKeyName(0, "paste.png");
            // 
            // wklejButton
            // 
            this.wklejButton.FlatAppearance.BorderSize = 0;
            this.wklejButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wklejButton.ImageIndex = 0;
            this.wklejButton.ImageList = this.wklejIcon;
            this.wklejButton.Location = new System.Drawing.Point(72, 334);
            this.wklejButton.Name = "wklejButton";
            this.wklejButton.Size = new System.Drawing.Size(33, 33);
            this.wklejButton.TabIndex = 4;
            this.wklejButton.UseVisualStyleBackColor = true;
            this.wklejButton.Click += new System.EventHandler(this.wklejButton_Click);
            // 
            // usunButton
            // 
            this.usunButton.FlatAppearance.BorderSize = 0;
            this.usunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usunButton.ImageIndex = 0;
            this.usunButton.ImageList = this.usunIcon;
            this.usunButton.Location = new System.Drawing.Point(132, 334);
            this.usunButton.Name = "usunButton";
            this.usunButton.Size = new System.Drawing.Size(33, 33);
            this.usunButton.TabIndex = 2;
            this.usunButton.Click += new System.EventHandler(this.usunButton_Click);
            // 
            // zapiszButton
            // 
            this.zapiszButton.FlatAppearance.BorderSize = 0;
            this.zapiszButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zapiszButton.ImageIndex = 0;
            this.zapiszButton.ImageList = this.zapiszIcon;
            this.zapiszButton.Location = new System.Drawing.Point(192, 336);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(31, 31);
            this.zapiszButton.TabIndex = 1;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // dodajButton
            // 
            this.dodajButton.FlatAppearance.BorderSize = 0;
            this.dodajButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dodajButton.ImageIndex = 0;
            this.dodajButton.ImageList = this.dodajIcon;
            this.dodajButton.Location = new System.Drawing.Point(12, 334);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(33, 33);
            this.dodajButton.TabIndex = 1;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Lime;
            this.pictureBox1.Location = new System.Drawing.Point(251, 323);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(251, 366);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 15);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(251, 344);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(15, 15);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox1.Location = new System.Drawing.Point(272, 323);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "- Zmiana zapisana";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox2.Location = new System.Drawing.Point(272, 344);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 13);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "- Zmiana niezapisana";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox3.Location = new System.Drawing.Point(272, 366);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 13);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "- Zdublowany kod";
            // 
            // kodOEM
            // 
            this.kodOEM.HeaderText = "Kod OEM";
            this.kodOEM.Name = "kodOEM";
            this.kodOEM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.kodOEM.Width = 122;
            // 
            // dostawca
            // 
            this.dostawca.HeaderText = "Dostawca";
            this.dostawca.Name = "dostawca";
            this.dostawca.ReadOnly = true;
            this.dostawca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dostawca.Width = 120;
            // 
            // pokazB2B
            // 
            this.pokazB2B.HeaderText = "Pokaz B2B";
            this.pokazB2B.Name = "pokazB2B";
            this.pokazB2B.Width = 50;
            // 
            // szukajB2B
            // 
            this.szukajB2B.HeaderText = "Szukaj B2B";
            this.szukajB2B.Name = "szukajB2B";
            this.szukajB2B.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.szukajB2B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.szukajB2B.Width = 51;
            // 
            // dostawcaGidNumer
            // 
            this.dostawcaGidNumer.HeaderText = "dostawcaGidNumer";
            this.dostawcaGidNumer.Name = "dostawcaGidNumer";
            this.dostawcaGidNumer.Visible = false;
            // 
            // oemGidNumer
            // 
            this.oemGidNumer.HeaderText = "oemGidNumer";
            this.oemGidNumer.Name = "oemGidNumer";
            this.oemGidNumer.ReadOnly = true;
            this.oemGidNumer.Visible = false;
            // 
            // DodajOEMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 387);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.wklejButton);
            this.Controls.Add(this.usunButton);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.dodajButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DodajOEMForm";
            this.Text = "Dodaj OEMY";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList dodajIcon;
        private System.Windows.Forms.ImageList zapiszIcon;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button zapiszButton;
        private System.Windows.Forms.ImageList usunIcon;
        private System.Windows.Forms.Button usunButton;
        private System.Windows.Forms.Button wklejButton;
        private System.Windows.Forms.ImageList wklejIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private DataGridViewTextBoxColumn kodOEM;
        private DataGridViewTextBoxColumn dostawca;
        private DataGridViewCheckBoxColumn pokazB2B;
        private DataGridViewCheckBoxColumn szukajB2B;
        private DataGridViewTextBoxColumn dostawcaGidNumer;
        private DataGridViewTextBoxColumn oemGidNumer;
    }
}


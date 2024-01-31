using Hydra;
using System.Drawing;
using System.Windows.Forms;

namespace DodajOem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DodajOEMForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kodOEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dostawca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pokazB2B = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.szukajB2B = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dostawcaGidNumer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oemGidNumer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usunButton = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.dodajButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
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
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(697, 403);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // kodOEM
            // 
            this.kodOEM.HeaderText = "Kod OEM";
            this.kodOEM.Name = "kodOEM";
            this.kodOEM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.kodOEM.Width = 220;
            // 
            // dostawca
            // 
            this.dostawca.HeaderText = "Dostawca";
            this.dostawca.Name = "dostawca";
            this.dostawca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dostawca.Width = 300;
            // 
            // pokazB2B
            // 
            this.pokazB2B.HeaderText = "Pokaz B2B";
            this.pokazB2B.Name = "pokazB2B";
            this.pokazB2B.Width = 85;
            // 
            // szukajB2B
            // 
            this.szukajB2B.HeaderText = "Szukaj B2B";
            this.szukajB2B.Name = "szukajB2B";
            this.szukajB2B.Width = 87;
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
            this.oemGidNumer.Visible = false;
            // 
            // usunButton
            // 
            this.usunButton.FlatAppearance.BorderSize = 0;
            this.usunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usunButton.Image = global::DodajOem.Properties.Resources.delete;
            this.usunButton.Location = new System.Drawing.Point(157, 439);
            this.usunButton.Name = "usunButton";
            this.usunButton.Size = new System.Drawing.Size(33, 33);
            this.usunButton.TabIndex = 10;
            this.usunButton.Click += new System.EventHandler(this.usunButton_Click);
            // 
            // zapiszButton
            // 
            this.zapiszButton.FlatAppearance.BorderSize = 0;
            this.zapiszButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zapiszButton.Image = global::DodajOem.Properties.Resources.save;
            this.zapiszButton.Location = new System.Drawing.Point(224, 440);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(31, 31);
            this.zapiszButton.TabIndex = 10;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            // 
            // dodajButton
            // 
            this.dodajButton.FlatAppearance.BorderSize = 0;
            this.dodajButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dodajButton.Image = ((System.Drawing.Image)(resources.GetObject("dodajButton.Image")));
            this.dodajButton.Location = new System.Drawing.Point(12, 437);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(33, 33);
            this.dodajButton.TabIndex = 10;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Lime;
            this.pictureBox1.Location = new System.Drawing.Point(586, 426);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(586, 469);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 15);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(586, 447);
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
            this.textBox1.Location = new System.Drawing.Point(607, 426);
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
            this.textBox2.Location = new System.Drawing.Point(607, 447);
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
            this.textBox3.Location = new System.Drawing.Point(607, 469);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 13);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "- Zdublowany kod";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox4.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox4.Location = new System.Drawing.Point(12, 475);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(33, 13);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "Dodaj";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox6.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox6.Location = new System.Drawing.Point(157, 477);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(33, 13);
            this.textBox6.TabIndex = 6;
            this.textBox6.Text = "Usuń";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox7.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox7.Location = new System.Drawing.Point(224, 477);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(33, 13);
            this.textBox7.TabIndex = 6;
            this.textBox7.Text = "Zapisz";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // copyButton
            // 
            this.copyButton.FlatAppearance.BorderSize = 0;
            this.copyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyButton.Image = global::DodajOem.Properties.Resources.copy;
            this.copyButton.Location = new System.Drawing.Point(83, 439);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(31, 31);
            this.copyButton.TabIndex = 10;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox8.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox8.Location = new System.Drawing.Point(65, 476);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(72, 13);
            this.textBox8.TabIndex = 6;
            this.textBox8.Text = "Skopiuj z karty";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DodajOEMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 494);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.usunButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.dodajButton);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DodajOEMForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj OEMY";
            this.Load += new System.EventHandler(this.DodajOEMForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button zapiszButton;
        private System.Windows.Forms.Button usunButton;
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
        private TextBox textBox4;
        private TextBox textBox6;
        private TextBox textBox7;
        private Button copyButton;
        private TextBox textBox8;
    }
}


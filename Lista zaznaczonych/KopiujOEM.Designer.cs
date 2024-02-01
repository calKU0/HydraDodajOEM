namespace DodajOem
{
    partial class KopiujOEM
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.oem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dostawca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pokazB2B = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.szukajB2B = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kntGidNumer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(153, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(410, 29);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(12, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(135, 19);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Wpisz kod towaru";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.oem,
            this.dostawca,
            this.pokazB2B,
            this.szukajB2B,
            this.kntGidNumer});
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(551, 315);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.Name = "check";
            this.check.Width = 40;
            // 
            // oem
            // 
            this.oem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.oem.HeaderText = "Kod OEM";
            this.oem.Name = "oem";
            this.oem.ReadOnly = true;
            // 
            // dostawca
            // 
            this.dostawca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dostawca.HeaderText = "Dostawca";
            this.dostawca.Name = "dostawca";
            this.dostawca.ReadOnly = true;
            // 
            // pokazB2B
            // 
            this.pokazB2B.HeaderText = "Pokaz w B2B";
            this.pokazB2B.Name = "pokazB2B";
            this.pokazB2B.ReadOnly = true;
            this.pokazB2B.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pokazB2B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.pokazB2B.Width = 70;
            // 
            // szukajB2B
            // 
            this.szukajB2B.HeaderText = "Szukaj w B2B";
            this.szukajB2B.Name = "szukajB2B";
            this.szukajB2B.ReadOnly = true;
            this.szukajB2B.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.szukajB2B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.szukajB2B.Width = 70;
            // 
            // kntGidNumer
            // 
            this.kntGidNumer.HeaderText = "kntGidNumer";
            this.kntGidNumer.Name = "kntGidNumer";
            this.kntGidNumer.ReadOnly = true;
            this.kntGidNumer.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Kopiuj wszystkie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(429, 405);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "Kopiuj zaznaczone";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // KopiujOEM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "KopiujOEM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kopiuj Oemy";
            this.Load += new System.EventHandler(this.KopiujOEM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn oem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dostawca;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pokazB2B;
        private System.Windows.Forms.DataGridViewCheckBoxColumn szukajB2B;
        private System.Windows.Forms.DataGridViewTextBoxColumn kntGidNumer;
    }
}
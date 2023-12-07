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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dodajNowyOEM = new System.Windows.Forms.Button();
            this.zapisz = new System.Windows.Forms.Button();
            this.KodOEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dostawca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KodOEM,
            this.Dostawca});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(251, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // dodajNowyOEM
            // 
            this.dodajNowyOEM.Location = new System.Drawing.Point(12, 336);
            this.dodajNowyOEM.Name = "dodajNowyOEM";
            this.dodajNowyOEM.Size = new System.Drawing.Size(113, 30);
            this.dodajNowyOEM.TabIndex = 1;
            this.dodajNowyOEM.Text = "Dodaj OEM";
            this.dodajNowyOEM.UseVisualStyleBackColor = true;
            // 
            // zapisz
            // 
            this.zapisz.Location = new System.Drawing.Point(153, 336);
            this.zapisz.Name = "zapisz";
            this.zapisz.Size = new System.Drawing.Size(110, 30);
            this.zapisz.TabIndex = 2;
            this.zapisz.Text = "Zapisz";
            this.zapisz.UseVisualStyleBackColor = true;
            // 
            // KodOEM
            // 
            this.KodOEM.HeaderText = "KodOEM";
            this.KodOEM.Name = "KodOEM";
            // 
            // Dostawca
            // 
            this.Dostawca.HeaderText = "Dostawca";
            this.Dostawca.Name = "Dostawca";
            this.Dostawca.Width = 120;
            // 
            // DodajOEM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 378);
            this.Controls.Add(this.zapisz);
            this.Controls.Add(this.dodajNowyOEM);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DodajOEM";
            this.Text = "Dodaj OEMY";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KodOEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dostawca;
        private System.Windows.Forms.Button dodajNowyOEM;
        private System.Windows.Forms.Button zapisz;
    }
}


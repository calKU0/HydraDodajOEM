using Hydra;

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
            this.dodajButton = new System.Windows.Forms.Button();
            this.zapiszButton = new System.Windows.Forms.Button();
            this.usunIcon = new System.Windows.Forms.ImageList(this.components);
            this.usunButton = new System.Windows.Forms.Button();
            this.kodOEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dostawca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dostawcaGidNumer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oemGidNumer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodOEM,
            this.dostawca,
            this.dostawcaGidNumer,
            this.oemGidNumer});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(245, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // dodajIcon
            // 
            this.dodajIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("dodajIcon.ImageStream")));
            this.dodajIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.dodajIcon.Images.SetKeyName(0, "add.png");
            this.dodajIcon.Images.SetKeyName(1, "add_hover.png");
            // 
            // zapiszIcon
            // 
            this.zapiszIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("zapiszIcon.ImageStream")));
            this.zapiszIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.zapiszIcon.Images.SetKeyName(0, "save.png");
            this.zapiszIcon.Images.SetKeyName(1, "save_hover.png");
            // 
            // dodajButton
            // 
            this.dodajButton.FlatAppearance.BorderSize = 0;
            this.dodajButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dodajButton.ImageIndex = 0;
            this.dodajButton.ImageList = this.dodajIcon;
            this.dodajButton.Location = new System.Drawing.Point(39, 333);
            this.dodajButton.Name = "dodajButton";
            this.dodajButton.Size = new System.Drawing.Size(33, 33);
            this.dodajButton.TabIndex = 1;
            this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
            this.dodajButton.MouseLeave += new System.EventHandler(this.dodajButton_MouseLeave);
            this.dodajButton.MouseHover += new System.EventHandler(this.dodajButton_MouseHover);
            // 
            // zapiszButton
            // 
            this.zapiszButton.FlatAppearance.BorderSize = 0;
            this.zapiszButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zapiszButton.ImageIndex = 0;
            this.zapiszButton.ImageList = this.zapiszIcon;
            this.zapiszButton.Location = new System.Drawing.Point(188, 334);
            this.zapiszButton.Name = "zapiszButton";
            this.zapiszButton.Size = new System.Drawing.Size(31, 31);
            this.zapiszButton.TabIndex = 1;
            this.zapiszButton.Click += new System.EventHandler(this.zapiszButton_Click);
            this.zapiszButton.MouseLeave += new System.EventHandler(this.zapiszButton_MouseLeave);
            this.zapiszButton.MouseHover += new System.EventHandler(this.zapiszButton_MouseHover);
            // 
            // usunIcon
            // 
            this.usunIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("usunIcon.ImageStream")));
            this.usunIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.usunIcon.Images.SetKeyName(0, "delete.png");
            this.usunIcon.Images.SetKeyName(1, "delete_hover.png");
            // 
            // usunButton
            // 
            this.usunButton.FlatAppearance.BorderSize = 0;
            this.usunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usunButton.ImageIndex = 0;
            this.usunButton.ImageList = this.usunIcon;
            this.usunButton.Location = new System.Drawing.Point(112, 333);
            this.usunButton.Name = "usunButton";
            this.usunButton.Size = new System.Drawing.Size(33, 33);
            this.usunButton.TabIndex = 2;
            this.usunButton.Click += new System.EventHandler(this.usunButton_Click);
            this.usunButton.MouseLeave += new System.EventHandler(this.usunButton_MouseLeave);
            this.usunButton.MouseHover += new System.EventHandler(this.usunButton_MouseHover);
            // 
            // kodOEM
            // 
            this.kodOEM.HeaderText = "Kod OEM";
            this.kodOEM.Name = "kodOEM";
            this.kodOEM.Width = 122;
            // 
            // dostawca
            // 
            this.dostawca.HeaderText = "Dostawca";
            this.dostawca.Name = "dostawca";
            this.dostawca.ReadOnly = true;
            this.dostawca.Width = 120;
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
            this.ClientSize = new System.Drawing.Size(269, 378);
            this.Controls.Add(this.usunButton);
            this.Controls.Add(this.zapiszButton);
            this.Controls.Add(this.dodajButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DodajOEMForm";
            this.Text = "Dodaj OEMY";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList dodajIcon;
        private System.Windows.Forms.ImageList zapiszIcon;
        private System.Windows.Forms.Button dodajButton;
        private System.Windows.Forms.Button zapiszButton;
        private System.Windows.Forms.ImageList usunIcon;
        private System.Windows.Forms.Button usunButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodOEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dostawca;
        private System.Windows.Forms.DataGridViewTextBoxColumn dostawcaGidNumer;
        private System.Windows.Forms.DataGridViewTextBoxColumn oemGidNumer;
    }
}


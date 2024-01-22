using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DodajOem
{
    public partial class DostawcyForm : Form
    {
        public string Dostawca { get; set; }
        public int DostawcaGidNumer { get; set; }
        public string Search { get; set; }
        private DataTable Dt { get; set; } = new DataTable("Dostawcy");
        public DostawcyForm(string connectionString, string search = "")
        {
            try
            {
                this.Search = search;
                InitializeComponent();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Knt_GIDNumer, Knt_Nazwa1 as Dostawca FROM cdn.KntKarty join cdn.Atrybuty ON Atr_Obinumer = Knt_GIDnumer and Atr_OBITyp=32 AND Atr_OBISubLp=0 and atr_atkid = 249 where atr_wartosc = 'TAK' order by Knt_Akronim";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(Dt);
                    dataGridView1.DataSource = Dt;
                    dataGridView1.Columns["Knt_GIDNumer"].Visible = false;
                    dataGridView1.Columns["Dostawca"].Width = 210;
                    dataGridView1.Columns["Dostawca"].ReadOnly = true;
                    txtSearch.Text = Search;
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd podczas pobierania dostawców: " + ex.ToString()); }
            
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Dostawca = dataGridView1.Rows[e.RowIndex].Cells["Dostawca"].Value.ToString();
            DostawcaGidNumer = (int)dataGridView1.Rows[e.RowIndex].Cells["Knt_GIDNumer"].Value;
            Search = txtSearch.Text ?? "";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Length > 2)
                {
                    DataView dv = Dt.DefaultView;
                    dv.RowFilter = string.Format("Dostawca like '%{0}%'", txtSearch.Text);
                    dataGridView1.DataSource = dv.ToTable();
                    dataGridView1.Columns["Knt_GIDNumer"].Visible = false;
                }
                if (txtSearch.Text.Length <= 2)
                {
                    DataView dv = Dt.DefaultView;
                    dv.RowFilter = string.Format("Dostawca like '%%'");
                    dataGridView1.DataSource = dv.ToTable();
                    dataGridView1.Columns["Knt_GIDNumer"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd przy wyszukiwaniu dostawców " + ex); }
        }
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Dostawca = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Dostawca"].Value.ToString();
                DostawcaGidNumer = (int)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Knt_GIDNumer"].Value;
                Search = txtSearch.Text ?? "";
                e.SuppressKeyPress = true;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && txtSearch.Focused == true && dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.Rows.Count == 1)
                {
                    this.txtSearch.TabIndex = 3;
                    this.dataGridView1.TabIndex = 0;
                    this.dataGridView1.Focus();
                }
                else
                {
                    this.txtSearch.TabIndex = 3;
                    this.dataGridView1.TabIndex = 0;
                    this.dataGridView1.Focus();
                    this.dataGridView1.CurrentCell = dataGridView1.Rows[1].Cells["Dostawca"];
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Dostawca = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Dostawca"].Value.ToString();
                DostawcaGidNumer = (int)dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Knt_GIDNumer"].Value;
                Search = txtSearch.Text ?? "";
                e.SuppressKeyPress = true;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    protected override bool ProcessDialogKey(Keys keyData)
    {
        if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
        {
            this.Close();
            return true;
        }
        return base.ProcessDialogKey(keyData);
    }
    }
}

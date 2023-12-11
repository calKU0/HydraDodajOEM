using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public partial class DostawcyForm : Form
    {
        public string Dostawca { get; set; }
        public int DostawcaGidNumer { get; set; }
        private DataTable dt { get; set; } = new DataTable("Dostawcy");
        public DostawcyForm(string Baza)
        {
            try
            {
                InitializeComponent();
                using (SqlConnection connection = new SqlConnection("user id=xxxx;password=xxxx;Data Source=xxxx;Trusted_Connection=no;database=" + Baza + ";connection timeout=5;"))
                {
                    connection.Open();
                    string query = "SELECT Knt_GIDNumer, Knt_Akronim as Dostawca FROM cdn.KntKarty join cdn.Atrybuty ON Atr_Obinumer = Knt_GIDnumer and Atr_OBITyp=32 AND Atr_OBISubLp=0 and atr_atkid = 249 where atr_wartosc = 'TAK' order by Knt_Akronim";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["Knt_GIDNumer"].Visible = false;
                    dataGridView1.Columns["Dostawca"].Width = 210;
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd podczas pobierania dostawców: " + ex.ToString()); }
            
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Dostawca = dataGridView1.Rows[e.RowIndex].Cells["Dostawca"].Value.ToString();
            DostawcaGidNumer = (int)dataGridView1.Rows[e.RowIndex].Cells["Knt_GIDNumer"].Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = string.Format("Dostawca like '%{0}%'", txtSearch.Text);
                    dataGridView1.DataSource = dv.ToTable();
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd przy wyszukiwaniu dostawców " + ex); }
        }
    }
}

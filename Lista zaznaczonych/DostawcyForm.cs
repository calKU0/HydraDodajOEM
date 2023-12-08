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
        public DostawcyForm(string Baza)
        {
            try
            {
                InitializeComponent();
                using (SqlConnection connection = new SqlConnection("user id=xxxx;password=xxxx;Data Source=xxxx;Trusted_Connection=no;database=" + Baza + ";connection timeout=5;"))
                {
                    connection.Open();
                    string query = "SELECT Knt_Akronim, Knt_GIDNumer FROM cdn.KntKarty join cdn.Atrybuty ON Atr_Obinumer = Knt_GIDnumer and Atr_OBITyp=32 AND Atr_OBISubLp=0 and atr_atkid = 249 where atr_wartosc = 'TAK' ";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["Knt_GIDNumer"], reader["Knt_Akronim"]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd podczas pobierania dostawców: " + ex.ToString()); }
            
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Dostawca = dataGridView1.Rows[e.RowIndex].Cells["DostawcaColumn"].Value.ToString();
            DostawcaGidNumer = (int)dataGridView1.Rows[e.RowIndex].Cells["KntGidNumer"].Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

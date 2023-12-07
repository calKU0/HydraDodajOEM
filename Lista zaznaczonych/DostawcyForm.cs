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
        public DostawcyForm()
        {
            try
            {
                InitializeComponent();
                SqlConnection connection = new SqlConnection("user id=xxxx;password=xxxx;Data Source=192.168.0.105;Trusted_Connection=no;database=xxxx;connection timeout=5;");
                string query = "SELECT Knt_Akronim FROM cdn.KntKarty join cdn.Atrybuty ON Atr_Obinumer = Knt_GIDnumer and Atr_OBITyp=32 AND Atr_OBISubLp=0 and atr_atkid = 249 where atr_wartosc = 'TAK' ";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Knt_Akronim"]);
                }
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd: " + ex.ToString()); }
            
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Dostawca = dataGridView1.Rows[e.RowIndex].Cells["DostawcaColumn"].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

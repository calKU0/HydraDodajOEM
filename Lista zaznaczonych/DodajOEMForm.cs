using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClassLibrary1;

namespace WyszukiwanieGrup
{
    public partial class DodajOEMForm : Form
    {
        private long GidNumer { get; set; }
        private string Baza { get; set; }
        private string[] kodyOEM { get; set; }
        public DodajOEMForm(long GidNumer, string Baza)
        {
            try
            {
                InitializeComponent();
                this.GidNumer = GidNumer;
                this.Baza = Baza;

                SqlConnection connection = new SqlConnection("user id=xxxx;password=xxxx;Data Source=xxxx;Trusted_Connection=no;database=" + Baza + ";connection timeout=5;");
                string query = "SELECT TKO_OEM, Knt_Akronim FROM dbo.TwrKodyOEM JOIN cdn.KntKarty on knt_gidnumer = TKO_KntNumer WHERE TKO_TwrNumer = @GidNumer";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GidNumer", GidNumer);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader["TKO_OEM"], reader["Knt_Akronim"]);
                    }
                }
                else
                {
                    reader.Close();
                    query = "SELECT TPO_OpisKrotki FROM cdn.twrAplikacjeOpisy with (nolock) WHERE TPO_JezykId = 0 AND TPO_ObiNumer = @GidNumer";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GidNumer", GidNumer);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        kodyOEM = reader["TPO_OpisKrotki"].ToString().Split(',');
                    }
                    foreach (string kod in kodyOEM)
                    {
                        dataGridView1.Rows.Add(kod.Replace(" ", ""), "");
                    }
                }
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd: " + ex.ToString()); }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Dostawca"].Index && e.RowIndex >= 0)
            {
                using (var forma = new DostawcyForm())
                {
                    var result = forma.ShowDialog();

                    if (result == DialogResult.OK) // jesli forma zwraca wynik
                    {
                        string wybranyDostawca = forma.Dostawca;
                        dataGridView1.Rows[e.RowIndex].Cells["Dostawca"].Value = wybranyDostawca;
                    }
                }
            }
        }


    }
}

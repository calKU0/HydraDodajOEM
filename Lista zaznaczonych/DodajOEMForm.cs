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
using System.Collections;

namespace WyszukiwanieGrup
{
    public partial class DodajOEMForm : Form
    {
        private long twrGidNumer { get; set; }
        private string Baza { get; set; }
        private string[] kodyOEM { get; set; }
        private SqlConnection connection { get; set; }
        private string OldCellValue { get; set; }
        public DodajOEMForm(long GidNumer, string Baza)
        {
            try
            {
                InitializeComponent();
                this.twrGidNumer = GidNumer;
                this.Baza = Baza;

                using (SqlConnection connection = new SqlConnection("user id=xxxx;password=xxxx;Data Source=xxxx;Trusted_Connection=no;database=" + Baza + ";connection timeout=5;"))
                {
                    string query = "SELECT TKO_GidNumer, TKO_OEM,Knt_Akronim, TKO_KntNumer FROM dbo.TwrKodyOEM JOIN cdn.KntKarty on knt_gidnumer = TKO_KntNumer WHERE TKO_TwrNumer = @GidNumer";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GidNumer", GidNumer);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["TKO_OEM"], reader["Knt_Akronim"], reader["TKO_KntNumer"], reader["TKO_GidNumer"]);
                        }
                    }
                    else
                    {
                        reader.Close();
                        query = "SELECT TPO_OpisKrotki FROM cdn.twrAplikacjeOpisy with (nolock) WHERE TPO_JezykId = 0 AND TPO_ObiNumer = @GidNumer";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@GidNumer", GidNumer);
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                kodyOEM = reader["TPO_OpisKrotki"].ToString().Split(',');
                            }
                            foreach (string kod in kodyOEM)
                            {
                                dataGridView1.Rows.Add(kod.Replace(" ", ""), "");
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd: " + ex.ToString()); }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Dostawca"].Index && e.RowIndex >= 0)
            {
                using (var forma = new DostawcyForm(Baza))
                {
                    var result = forma.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string wybranyDostawca = forma.Dostawca;
                        int wybranyDostawcaGid = forma.DostawcaGidNumer;
                        dataGridView1.Rows[e.RowIndex].Cells["dostawca"].Value = wybranyDostawca;
                        dataGridView1.Rows[e.RowIndex].Cells["dostawcaGidNumer"].Value = wybranyDostawcaGid;
                    }
                }
            }
        }
        private void dodajButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }
        private void zapiszButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("user id=xxxx;password=xxxx;Data Source=xxxx;Trusted_Connection=no;database=" + Baza + ";connection timeout=5;"))
                {
                    connection.Open();
                    int rowsAffected = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["kodOEM"].Value == null || (string)row.Cells["kodOEM"].Value == "")
                        {
                            MessageBox.Show("Jeden z wierszy w kolumnie kod OEM jest pusty\nWprowadź wartość lub go usuń i spróbuj ponownie");
                            return;
                        }
                        //MessageBox.Show($"OEM: {row.Cells["kodOEM"].Value} oemGidNumer: {row.Cells["oemGidNumer"].Value}");
                        /* Zapytanie, które jeśli:
                         * 1. Nie ma zapisu w tabeli TwrKodyOEM, to INSERTuje nowe warości (jeśli jest to nowy rekord, to @oemGidNumer ma wartość NULL)
                         * 2. Jest zapis w tabeli, to UPDATEuje je pod warunkiem, że zmieniły się wartości (porównanie danych z formularza do danych z bazy)
                         */
                        string query = @"IF NOT EXISTS (SELECT * FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer)
                                 BEGIN
                                    INSERT INTO dbo.TwrKodyOEM(TKO_TwrNumer, TKO_KntNumer, TKO_OEM) VALUES (@twrGidNumer, @kntGidNumer, @kodOEM)
                                 END
                                 ELSE
                                 BEGIN
                                     IF (SELECT TKO_OEM FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer) != @kodOEM OR (SELECT TKO_KntNumer FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer) != @kntGidNumer
                                     BEGIN
                                        UPDATE dbo.TwrKodyOEM SET TKO_KntNumer = @kntGidNumer, TKO_OEM = @kodOEM WHERE TKO_GidNumer = @oemGidNumer
                                     END
                                 END";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@kodOEM", row.Cells["kodOEM"].Value);
                        command.Parameters.AddWithValue("@twrGidNumer", twrGidNumer);
                        command.Parameters.AddWithValue("@kntGidNumer", row.Cells["dostawcaGidNumer"].Value ?? DBNull.Value);
                        command.Parameters.AddWithValue("@oemGidNumer", row.Cells["oemGidNumer"].Value ?? DBNull.Value);
                        int czyWykonano = command.ExecuteNonQuery();
                        rowsAffected += rowsAffected == -1 ? 0 : rowsAffected;
                    }
                    MessageBox.Show($"Zaktualizowano {rowsAffected} wierszy");
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd podczas zapisu kodów OEM " + ex); }
        }
        private void usunButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows[index].Cells["oemGidNumer"].Value == null)
                {
                    dataGridView1.Rows.RemoveAt(index);
                    return;
                }
                using (SqlConnection connection = new SqlConnection("user id=xxxx;password=xxxx;Data Source=xxxx;Trusted_Connection=no;database=" + Baza + ";connection timeout=5;"))
                {
                    connection.Open();
                    string query = @"DELETE FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@oemGidNumer", dataGridView1.Rows[index].Cells["oemGidNumer"].Value);
                    int czyWykonano = command.ExecuteNonQuery();
                }
                dataGridView1.Rows.RemoveAt(index);
                MessageBox.Show($"Pomyślnie usunięto");
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd przy usuwaniu wiersza: " + ex); }
        }
        private void dodajButton_MouseHover(object sender, EventArgs e) => dodajButton.ImageIndex = 1;
        private void dodajButton_MouseLeave(object sender, EventArgs e) => dodajButton.ImageIndex = 0;
        private void zapiszButton_MouseHover(object sender, EventArgs e) => zapiszButton.ImageIndex = 1;
        private void zapiszButton_MouseLeave(object sender, EventArgs e) => zapiszButton.ImageIndex = 0;
        private void usunButton_MouseHover(object sender, EventArgs e) => usunButton.ImageIndex = 1;
        private void usunButton_MouseLeave(object sender, EventArgs e) => usunButton.ImageIndex = 0;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}

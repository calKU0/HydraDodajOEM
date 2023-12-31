﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DodajOem;
using System.Collections;
using System.Reflection;
using Hydra;

namespace DodajOem
{
    public partial class DodajOEMForm : Form
    {
        private long twrGidNumer { get; set; }
        private string Baza { get; set; }
        private string[] kodyOEM { get; set; }
        private SqlConnection connection { get; set; }
        private string Search { get; set; } = "";
        public DodajOEMForm(long GidNumer, string Baza)
        {
            try
            {
                this.twrGidNumer = GidNumer;
                this.Baza = Baza;
                InitializeComponent();
                InitializeRows(twrGidNumer);
                dataGridView1.Rows.RemoveAt(0);
            }
            catch (Exception ex) { MessageBox.Show("Wystąpił błąd przy otwieraniu formularza " + ex); }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Dostawca"].Index && e.RowIndex >= 0)
            {
                using (var forma = new DostawcyForm(Baza, Search))
                {
                    var result = forma.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string wybranyDostawca = forma.Dostawca;
                        int wybranyDostawcaGid = forma.DostawcaGidNumer;
                        Search = forma.Search;
                        dataGridView1.Rows[e.RowIndex].Cells["dostawca"].Value = wybranyDostawca;
                        dataGridView1.Rows[e.RowIndex].Cells["dostawcaGidNumer"].Value = wybranyDostawcaGid;
                    }
                }
            }
        }
        private void dodajButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["kodOEM"];
            dataGridView1.BeginEdit(true);
        }
        private void zapiszButton_Click(object sender, EventArgs e)
        {
            ZapiszZmiany();
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
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (e.ColumnIndex == dataGridView1.Columns["kodOEM"].Index)
                {
                    for (int a = 0; a <= dataGridView1.Rows.Count - 1; a++)
                    {
                        if (e.RowIndex != a)
                        {
                            if ((string)dataGridView1.Rows[a].Cells["kodOEM"].Value == (string)dataGridView1.Rows[e.RowIndex].Cells["kodOEM"].Value)
                            {
                                ColorRow(e.RowIndex, Color.Red);
                                return;
                            }
                        }
                    }
                }
                if (dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red){}
                else { ColorRow(e.RowIndex, true); }
            }
        }
        private void ZapiszZmiany()
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
                        if (row.DefaultCellStyle.BackColor == Color.Red)
                        {
                            MessageBox.Show($"Usuń nieprawidłowe wartości\nKod {row.Cells["kodOEM"].Value} jest zdublowany");
                            return;
                        }
                        /* Zapytanie, które jeśli:
                         * 1. Nie ma zapisu w tabeli TwrKodyOEM, to INSERTuje nowe warości (jeśli jest to nowy rekord, to @oemGidNumer ma wartość NULL)
                         * 2. Jest zapis w tabeli, to UPDATEuje je pod warunkiem, że zmieniły się wartości (porównanie danych z formularza do danych z bazy)
                         * 3. Usuwa Opis Krótki jeśli są w nim kody OEM
                         */
                        string query = @"IF NOT EXISTS (SELECT * FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer)
                                 BEGIN
                                    INSERT INTO dbo.TwrKodyOEM(TKO_TwrNumer, TKO_KntNumer, TKO_OEM, TKO_PokazB2B, TKO_SzukajB2B) VALUES (@twrGidNumer, @kntGidNumer, @kodOEM, @pokazB2B, @szukajB2B)
                                 END
                                 ELSE
                                 BEGIN
                                     IF (SELECT TKO_OEM FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer) != @kodOEM 
                                        OR (SELECT isnull(TKO_KntNumer,0) FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer) != @kntGidNumer
                                        OR (SELECT TKO_SzukajB2B FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer) != @szukajB2B
                                        OR (SELECT TKO_PokazB2B FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer) != @pokazB2B
                                     BEGIN
                                        UPDATE dbo.TwrKodyOEM SET TKO_KntNumer = @kntGidNumer, TKO_OEM = @kodOEM, TKO_PokazB2B = @pokazB2B, TKO_SzukajB2B = @szukajB2B WHERE TKO_GidNumer = @oemGidNumer
                                     END
                                 END
                                 IF (SELECT isnull(TPO_OpisKrotki,'') FROM CDN.TwrAplikacjeOpisy WHERE TPO_JezykId = 0 AND TPO_ObiNumer = @twrGidNumer) <> ''
                                 BEGIN
                                     UPDATE CDN.TwrAplikacjeOpisy SET TPO_OpisKrotki = '' WHERE TPO_JezykId = 0 AND TPO_ObiNumer = @twrGidNumer
                                 END";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@kodOEM", row.Cells["kodOEM"].Value);
                        command.Parameters.AddWithValue("@twrGidNumer", twrGidNumer);
                        command.Parameters.AddWithValue("@kntGidNumer", row.Cells["dostawcaGidNumer"].Value ?? DBNull.Value);
                        command.Parameters.AddWithValue("@szukajB2B", Convert.ToInt32(row.Cells["szukajB2B"].Value));
                        command.Parameters.AddWithValue("@pokazB2B", Convert.ToInt32(row.Cells["pokazB2B"].Value));
                        command.Parameters.AddWithValue("@oemGidNumer", row.Cells["oemGidNumer"].Value ?? DBNull.Value);
                        int czyWykonano = command.ExecuteNonQuery();
                        if (row.Cells["oemGidNumer"].Value == null)
                        {
                            string gidNumerQuery = "SELECT @@IDENTITY";
                            SqlCommand commandOemNumer = new SqlCommand(gidNumerQuery, connection);
                            string oemGidNumer = commandOemNumer.ExecuteScalar().ToString();
                            row.Cells["oemGidNumer"].Value = Int32.Parse(oemGidNumer);
                        }

                        rowsAffected += czyWykonano == -1 ? 0 : czyWykonano;
                        ColorRow(row.Index);
                    }
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Zaktualizowano kody OEM");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd podczas zapisu kodów OEM " + ex); }
        }

        public void InitializeRows(long GidNumer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("user id=xxxx;password=xxxx;Data Source=xxxx;Trusted_Connection=no;database=" + Baza + ";connection timeout=5;"))
                {
                    string query = "SELECT TKO_GidNumer, TKO_OEM, Knt_Akronim, TKO_KntNumer, TKO_SzukajB2B, TKO_PokazB2B FROM dbo.TwrKodyOEM LEFT JOIN cdn.KntKarty on knt_gidnumer = TKO_KntNumer WHERE TKO_TwrNumer = @GidNumer";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GidNumer", GidNumer);

                    SqlDataReader reader = command.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["TKO_OEM"], reader["Knt_Akronim"], Convert.ToBoolean(reader["TKO_PokazB2B"]), Convert.ToBoolean(reader["TKO_SzukajB2B"]), reader["TKO_KntNumer"], reader["TKO_GidNumer"]);
                            ColorRow(i);
                            i += 1;
                        }
                    }
                    else
                    {
                        reader.Close();
                        i = 0;
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
                                ColorRow(i);
                                i += 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd: " + ex.ToString()); }
        }

        private void wklejButton_Click(object sender, EventArgs e)
        {
            string s = Clipboard.GetText();
            string[] fields = s.Replace("\n", "").Split('\r');
            int i = dataGridView1.Rows.Count - 1;
            foreach (string f in fields)
            {
                dataGridView1.Rows.Add(f);
                ColorRow(i);
                i += 1;
            }
        }
        public void ColorRow(int index, bool forceChange = false)
        {
            try
            {
                if (dataGridView1.Rows[index].Cells["oemGidNumer"].Value != null)
                {
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Lime;
                }
                if (dataGridView1.Rows[index].Cells["oemGidNumer"].Value == null || forceChange)
                {
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd przy próbie przekolorowania komórek " + ex); }
        }
        public void ColorRow(int index, Color color)
        {
            dataGridView1.Rows[index].DefaultCellStyle.BackColor = color;
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
                if (columnIndex == dataGridView1.Columns["Dostawca"].Index && rowIndex >= 0)
                {
                    using (var forma = new DostawcyForm(Baza, Search))
                    {
                        var result = forma.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            string wybranyDostawca = forma.Dostawca;
                            int wybranyDostawcaGid = forma.DostawcaGidNumer;
                            Search = forma.Search;
                            dataGridView1.Rows[rowIndex].Cells["dostawca"].Value = wybranyDostawca;
                            dataGridView1.Rows[rowIndex].Cells["dostawcaGidNumer"].Value = wybranyDostawcaGid;
                        }
                    }
                }
                e.SuppressKeyPress = true;
            }
            else if (e.Control == true && e.KeyCode == Keys.V) //Kopiowanie
            {
                string s = Clipboard.GetText();
                string[] fields = s.Replace("\n", "").Split('\r');
                int i = dataGridView1.Rows.Count - 1;
                foreach (string f in fields)
                {
                    dataGridView1.Rows.Add(f);
                    ColorRow(i);
                    i += 1;
                }
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.Yellow)
                {
                    DialogResult dr = MessageBox.Show("Pozostawiłeś niezapisane zmiany\nCzy chcesz je zapisać?", "Potwierdź", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        ZapiszZmiany();
                        break;
                    }
                    else if (dr == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        if (connection != null && connection.State != ConnectionState.Closed)
                        {
                            connection.Close();
                        }
                        break;
                    }
                }
            }
        }
    }
}

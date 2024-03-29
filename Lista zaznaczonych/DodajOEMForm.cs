﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using ADODB;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DodajOem
{
    public partial class DodajOEMForm : Form
    {
        CheckBox headerSzukajB2BChk = new CheckBox();
        CheckBox headerPokazB2BChk = new CheckBox();
        private long twrGidNumer { get; set; }
        private string[] kodyOEM { get; set; }
        private SqlConnection connection { get; }
        private string Search { get; set; } = "";
        private readonly string connectionString;
        public DodajOEMForm(long GidNumer, string connectionString)
        {
            try
            {
                this.twrGidNumer = GidNumer;
                this.connectionString = connectionString;
                InitializeComponent();
                InitializeRows(twrGidNumer);
            }
            catch (Exception ex) { MessageBox.Show("Wystąpił błąd przy otwieraniu formularza " + ex); }
        }

        private void DodajOEMForm_Load(object sender, EventArgs e)
        {
            Rectangle szukajB2BHeader = this.dataGridView1.GetCellDisplayRectangle(this.dataGridView1.Columns.IndexOf(this.szukajB2B), -1, true);
            headerSzukajB2BChk.Location = new Point(szukajB2BHeader.Location.X + 4, szukajB2BHeader.Location.Y + (szukajB2BHeader.Height - szukajB2BHeader.Height) / 2);
            headerSzukajB2BChk.Click += new EventHandler(headerSzukajB2BChk_Click);
            headerSzukajB2BChk.FlatStyle = FlatStyle.Flat;
            headerSzukajB2BChk.BackColor = Color.Transparent;
            headerSzukajB2BChk.ForeColor = Color.Transparent;
            headerSzukajB2BChk.FlatAppearance.MouseOverBackColor = Color.Transparent;
            headerSzukajB2BChk.FlatAppearance.MouseDownBackColor = Color.Transparent;
            headerSzukajB2BChk.FlatAppearance.BorderSize = 0;

            Rectangle pokazB2BHeader = this.dataGridView1.GetCellDisplayRectangle(this.dataGridView1.Columns.IndexOf(this.pokazB2B), -1, true);
            headerPokazB2BChk.Location = new Point(pokazB2BHeader.Location.X + 4, pokazB2BHeader.Location.Y + (pokazB2BHeader.Height - pokazB2BHeader.Height) / 2);
            headerPokazB2BChk.Click += new EventHandler(headerPokazB2BChk_Click);
            headerPokazB2BChk.FlatStyle = FlatStyle.Flat;
            headerPokazB2BChk.BackColor = Color.Transparent;
            headerPokazB2BChk.ForeColor = Color.Transparent;
            headerPokazB2BChk.FlatAppearance.MouseOverBackColor = Color.Transparent;
            headerPokazB2BChk.FlatAppearance.MouseDownBackColor = Color.Transparent;
            headerPokazB2BChk.FlatAppearance.BorderSize = 0;

            dataGridView1.Controls.Add(headerSzukajB2BChk);
            dataGridView1.Controls.Add(headerPokazB2BChk);

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name == "szukajB2B" || col.Name == "pokazB2B")
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Dostawca"].Index && e.RowIndex >= 0)
            {
                using (var forma = new DostawcyForm(connectionString, Search))
                {
                    var result = forma.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string wybranyDostawca = forma.Dostawca;
                        string wybranyDostawcaGid = forma.DostawcaGidNumer;
                        Search = forma.Search;
                        dataGridView1.Rows[e.RowIndex].Cells["dostawca"].Value = wybranyDostawca;
                        dataGridView1.Rows[e.RowIndex].Cells["dostawcaGidNumer"].Value = wybranyDostawcaGid;
                    }
                }
            }
        }
        private void dodajButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(String.Empty, String.Empty, false, false);
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"DELETE FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@oemGidNumer", dataGridView1.Rows[index].Cells["oemGidNumer"].Value);
                    int czyWykonano = command.ExecuteNonQuery();
                }
                dataGridView1.Rows.RemoveAt(index);
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd przy usuwaniu wiersza: " + ex); }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (e.ColumnIndex == dataGridView1.Columns["kodOEM"].Index)
                {
                    ColorRow(e.RowIndex);
                }
                else { ColorRow(e.RowIndex, true); }
            }
        }
        private void ZapiszZmiany()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                        string query = @"
                                 BEGIN TRY
                                     BEGIN TRANSACTION TEST
                                     IF NOT EXISTS (SELECT * FROM dbo.TwrKodyOEM WHERE TKO_GidNumer = @oemGidNumer)
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
                                     END
                                     COMMIT
                                 END TRY
                                 BEGIN CATCH
                                    ROLLBACK TRANSACTION
                                 END CATCH";
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
                        if (czyWykonano == 0)
                        {
                            ColorRow(row.Index,Color.Red);
                            MessageBox.Show("Zdublowany Oem w wierszu: " + Convert.ToInt32(row.Index + 1));
                        }
                    }
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Zaktualizowano kody OEM");
                    }
                    this.Close();
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Napotkano błąd podczas zapisu kodów OEM " + ex);
            }
        }

        public void InitializeRows(long GidNumer)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT TKO_GidNumer, TKO_OEM, Knt_Nazwa1, TKO_KntNumer, TKO_SzukajB2B, TKO_PokazB2B FROM dbo.TwrKodyOEM LEFT JOIN cdn.KntKarty on knt_gidnumer = TKO_KntNumer WHERE TKO_TwrNumer = @GidNumer";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GidNumer", GidNumer);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int index = dataGridView1.Rows.Add(reader["TKO_OEM"], reader["Knt_Nazwa1"], Convert.ToBoolean(reader["TKO_PokazB2B"]), Convert.ToBoolean(reader["TKO_SzukajB2B"]), reader["TKO_KntNumer"], reader["TKO_GidNumer"]);
                            ColorRow(index);
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
                                int index = dataGridView1.Rows.Add(kod.Trim());
                                ColorRow(index);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Napotkano błąd: " + ex.ToString()); }
        }
        public void ColorRow(int index, bool forceChange = false)
        {
            try
            {
                var dostawcaValue = dataGridView1.Rows[index].Cells["dostawca"].Value;
                string oemValue = dataGridView1.Rows[index].Cells["kodOEM"].Value.ToString();
                if (dataGridView1.Rows[index].Cells["oemGidNumer"].Value != null)
                {
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Lime;
                }
                else
                {
                    dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var dostawcaValueRow = dataGridView1.Rows[index].Cells["dostawca"].Value;
                    if (row.Cells["kodOEM"].Value.ToString().Equals(oemValue) && (dostawcaValueRow ?? "").Equals(dostawcaValue ?? ""))
                    {
                        if (row.Index != index)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
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
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (columnIndex == dataGridView1.Columns["Dostawca"].Index && rowIndex >= 0)
                {
                    using (var forma = new DostawcyForm(connectionString, Search))
                    {
                        var result = forma.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            string wybranyDostawca = forma.Dostawca;
                            string wybranyDostawcaGid = forma.DostawcaGidNumer;
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
                if (Clipboard.ContainsText())
                {
                    string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                    string[] rows = clipboardText.Split('\n', '\r');
                    int startRowIndex = dataGridView1.Rows.Count;

                    foreach (string rowText in rows)
                    {
                        if (string.IsNullOrWhiteSpace(rowText))
                            continue;

                        string[] values = rowText.Split('\t');

                        int newRowIndex = dataGridView1.Rows.Add();

                        for (int i = 0; i < values.Length; i++)
                        {
                            dataGridView1.Rows[newRowIndex].Cells[i].Value = values[i].Trim();

                            if (dataGridView1.Columns[i] is DataGridViewCheckBoxColumn)
                            {
                                if (values[i].Trim() == "1" || values[i].Trim().ToUpper() == "TAK")
                                {
                                    dataGridView1.Rows[newRowIndex].Cells[i].Value = true;
                                }
                                else
                                {
                                    dataGridView1.Rows[newRowIndex].Cells[i].Value = false;
                                }
                            }
                        }

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "SELECT Knt_GIDNumer FROM cdn.KntKarty join cdn.Atrybuty ON Atr_Obinumer = Knt_GIDnumer and Atr_OBITyp=32 AND Atr_OBISubLp=0 and atr_atkid = 249 where atr_wartosc = 'TAK' and knt_Nazwa1 = '" + dataGridView1.Rows[rowIndex].Cells["dostawca"].Value + "'order by Knt_Akronim";
                            SqlCommand command = new SqlCommand(query, connection);
                            object result = command.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                dataGridView1.Rows[rowIndex].Cells["dostawcaGidNumer"].Value = result.ToString();
                            }
                            else
                            {
                                dataGridView1.Rows[rowIndex].Cells["dostawca"].Value = String.Empty;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Brak danych do skopiowania.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var forma = new KopiujOEM(connectionString))
                {
                    var result = forma.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        foreach (var row in forma.ReturnList)
                        {
                            int index = dataGridView1.Rows.Add(row.Oem,row.Dostawca,row.PokazB2B,row.SzukajB2B,row.KntGidNumer);
                            ColorRow(index);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Błąd przy kopiowaniu z karty: " + ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { ReturnToFront(); }
        }
        private void headerSzukajB2BChk_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["szukajB2B"].Value = headerSzukajB2BChk.Checked;
            }
        }
        private async void ReturnToFront() //Musimy o zrobić poprzez delay ponieważ Comarch po wybraniu z formatki czeka chwilę i chowa wszyskie podokna
        {
            await Task.Delay(200);
            await Task.Run(() => { this.BringToFront(); });
        }
        private void headerPokazB2BChk_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["pokazB2B"].Value = headerPokazB2BChk.Checked;
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

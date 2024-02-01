using Hydra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DodajOem
{
    public partial class KopiujOEM : Form
    {
        CheckBox headerCheck = new CheckBox();

        private string connectionString;
        private string[] kodyOEM;
        private string towarKod;
        private int towarGid;
        public List<Row> ReturnList = new List<Row>();

        public KopiujOEM(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeComponent();
        }
        private void KopiujOEM_Load(object sender, EventArgs e)
        {
            Rectangle szukajB2BHeader = this.dataGridView1.GetCellDisplayRectangle(this.dataGridView1.Columns.IndexOf(this.check), -1, true);

            headerCheck.Location = new Point(szukajB2BHeader.Location.X, szukajB2BHeader.Location.Y + (szukajB2BHeader.Height - szukajB2BHeader.Height) / 2);
            headerCheck.Click += new EventHandler(headerCheck_Click);
            headerCheck.FlatStyle = FlatStyle.Flat;
            headerCheck.BackColor = Color.Transparent;
            headerCheck.ForeColor = Color.Transparent;
            headerCheck.FlatAppearance.MouseOverBackColor = Color.Transparent;
            headerCheck.FlatAppearance.MouseDownBackColor = Color.Transparent;
            headerCheck.FlatAppearance.BorderSize = 0;
            dataGridView1.Controls.Add(headerCheck);
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Rows.Clear();
                towarKod = textBox1.Text;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryGid = "SELECT Twr_GidNumer from cdn.TwrKarty where twr_kod = '" + towarKod + "'";
                    string query = "SELECT TKO_OEM, Knt_Nazwa1, TKO_KntNumer, TKO_SzukajB2B, TKO_PokazB2B FROM dbo.TwrKodyOEM LEFT JOIN cdn.KntKarty on knt_gidnumer = TKO_KntNumer WHERE TKO_TwrNumer = @GidNumer";
                    connection.Open();
                    SqlCommand commandGid = new SqlCommand(queryGid, connection);
                    towarGid = Convert.ToInt32(commandGid.ExecuteScalar());

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GidNumer", towarGid);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int index = dataGridView1.Rows.Add(false,reader["TKO_OEM"], reader["Knt_Nazwa1"] == DBNull.Value ? null : reader["Knt_Nazwa1"], Convert.ToBoolean(reader["TKO_PokazB2B"]), Convert.ToBoolean(reader["TKO_SzukajB2B"]), reader["TKO_KntNumer"] == DBNull.Value ? null : reader["TKO_KntNumer"]);
                        }
                    }
                    else
                    {
                        reader.Close();
                        query = "SELECT TPO_OpisKrotki FROM cdn.twrAplikacjeOpisy with (nolock) WHERE TPO_JezykId = 0 AND TPO_ObiNumer = @GidNumer";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@GidNumer", towarGid);
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                kodyOEM = reader["TPO_OpisKrotki"].ToString().Split(',');
                            }
                            foreach (string kod in kodyOEM)
                            {
                                dataGridView1.Rows.Add(false,kod.Trim(), null, false, false, null);
                            }
                        }
                    }
                }
                if (dataGridView1.Rows.Count < 1)
                {
                    MessageBox.Show("Brak towaru z podanym kodem", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        Row row1 = new Row();
                        row1.Oem = row.Cells["oem"].Value.ToString();
                        row1.Dostawca = row.Cells["dostawca"].Value.ToString();
                        row1.PokazB2B = Convert.ToBoolean(row.Cells["pokazB2B"].Value);
                        row1.SzukajB2B = Convert.ToBoolean(row.Cells["szukajB2B"].Value);
                        row1.KntGidNumer = row.Cells["kntGidNumer"].Value.ToString();
                        ReturnList.Add(row1);
                    }
                    catch (NullReferenceException)
                    {
                        Row row1 = new Row();
                        row1.Oem = row.Cells["oem"].Value.ToString();
                        row1.PokazB2B = Convert.ToBoolean(row.Cells["pokazB2B"].Value);
                        row1.SzukajB2B = Convert.ToBoolean(row.Cells["szukajB2B"].Value);
                        ReturnList.Add(row1);
                    }
                    finally
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Błąd w kopiowaniu " + ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void headerCheck_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["check"].Value = headerCheck.Checked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((bool)row.Cells["check"].Value == true)
                    {
                        try
                        {
                            Row row1 = new Row();
                            row1.Oem = row.Cells["oem"].Value.ToString();
                            row1.Dostawca = row.Cells["dostawca"].Value.ToString();
                            row1.PokazB2B = Convert.ToBoolean(row.Cells["pokazB2B"].Value);
                            row1.SzukajB2B = Convert.ToBoolean(row.Cells["szukajB2B"].Value);
                            row1.KntGidNumer = row.Cells["kntGidNumer"].Value.ToString();
                            ReturnList.Add(row1);
                        }
                        catch (NullReferenceException)
                        {
                            Row row1 = new Row();
                            row1.Oem = row.Cells["oem"].Value.ToString();
                            row1.PokazB2B = Convert.ToBoolean(row.Cells["pokazB2B"].Value);
                            row1.SzukajB2B = Convert.ToBoolean(row.Cells["szukajB2B"].Value);
                            ReturnList.Add(row1);
                        }
                        finally
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Błąd w kopiowaniu " + ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }
    }
    public class Row
    {
        public string Oem;
        public string Dostawca = null;
        public bool PokazB2B;
        public bool SzukajB2B;
        public string KntGidNumer = null;
    }
}

using System;
using Hydra;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;


[assembly: CallbackAssemblyDescription("Dodaj OEM",
"Dodaj Kod OEM",
"Krzysztof Kurowski",
"1.0",
"2023.1",
"07-12-2023")]

namespace DodajOem
{
    [SubscribeProcedure((Procedures)Procedures.TwrEdycja, "callback na karcie towaru")]
    public class callbacktestowy : Callback
    {
        ClaWindow button;
        ClaWindow ButtonParent;
        private string connectionString { get; } = "user id=xxxx;password=xxxx;Data Source=xxxx;Trusted_Connection=no;database=" + Runtime.ActiveRuntime.Repository.Connection.Database.ToString() + ";connection timeout=5;";

        public override void Init()
        {
            AddSubscription(true, 0, Events.OpenWindow, new TakeEventDelegate(OnOpenWindow)); // Otwarcie okna
            AddSubscription(false, 0, Events.ResizeWindow, new TakeEventDelegate(ChangeWindow)); // zmiana szerokosci/wysokosci okna
        }

        public bool OnOpenWindow(Procedures ProcId, int ControlId, Events Event)
        {
            int liczbaOem = LiczbaNumerowOem(TwrKarty.Twr_GIDNumer);
            ClaWindow Parent = GetWindow();
            ButtonParent = Parent.AllChildren["?Pinezka"]; // od ktorego przycisku
            button = Parent.Children["?TabAplikacje"].Children.Add(ControlTypes.button); // w ktorej belce
            button.Visible = true;
            button.Bounds = new Rectangle(Convert.ToInt32(ButtonParent.XposRaw) - 123, Convert.ToInt32(ButtonParent.YposRaw), 112, 20);
            button.TextRaw = $"Kody OEM ({liczbaOem})";
            if (liczbaOem > 0)
            {
                button.BackgroundRaw = "32768";
            }

            if (liczbaOem <= 0)
            {
                button.FontColorRaw = "16777215";
                button.BackgroundRaw = "255";
            }


            AddSubscription(false, button.Id, Events.Accepted, new TakeEventDelegate(NewButton_OnAfterMouseDown));
            return true; 
        }

        public bool ChangeWindow(Procedures ProcId, int ControlId, Events Event)
        {
            button.Bounds = new Rectangle(Convert.ToInt32(ButtonParent.XposRaw) - 123, Convert.ToInt32(ButtonParent.YposRaw), 112, 20);
            return true;
        }

        public bool NewButton_OnAfterMouseDown(Procedures ProcedureId, int ControlId, Events Event)
        {
            try
            {
                DodajOEMForm form1 = new DodajOEMForm(TwrKarty.Twr_GIDNumer, connectionString);
                form1.Show();
            }
            catch (Exception ex)
            {
                Runtime.WindowController.UnlockThread();
                MessageBox.Show("Błąd:" + ex.Message);
                Runtime.WindowController.LockThread();
            }
            Runtime.WindowController.PostEvent(0, Events.FullRefresh);

            return true;
        }

        public override void Cleanup()
        {
        }

        public int LiczbaNumerowOem(long twrGidNumer)
        {
            int liczbaOem = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM dbo.TwrKodyOem WHERE TKO_TwrNumer = @twrGidNumer";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@twrGidNumer", twrGidNumer);
                    liczbaOem = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            return liczbaOem;
        }
    }
}

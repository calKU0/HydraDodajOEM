using System;
using Hydra;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using WyszukiwanieGrup;

[assembly: CallbackAssemblyDescription("Dodaj OEM",
"Dodaj Kod OEM",
"Krzysztof Kurowski",
"1.0",
"2023.2",
"07-12-2023")]

namespace Cena_Detaliczna_Na_ZS
{
    [SubscribeProcedure((Procedures)Procedures.TwrEdycja, "callback na karcie towaru")]
    public class callbacktestowy : Callback
    {
        ClaWindow button; // tutaj zeby dalo sie uzywac we wszystkich metodach
        ClaWindow ButtonParent; // tutaj zeby dalo sie uzywac we wszystkich metodach

        public override void Init()
        {
            AddSubscription(true, 0, Events.OpenWindow, new TakeEventDelegate(OnOpenWindow)); // Otwarcie okna
            AddSubscription(false, 0, Events.ResizeWindow, new TakeEventDelegate(ChangeWindow)); // zmiana szerokosci/wysokosci okna
        }

        public bool OnOpenWindow(Procedures ProcId, int ControlId, Events Event)
        {
                ClaWindow Parent = GetWindow();

                ButtonParent = Parent.AllChildren["?Pinezka"]; // od ktorego przycisku
                button = Parent.Children["?TabAplikacje"].Children.Add(ControlTypes.button); // w ktorej belce
                button.Visible = true;

                button.TextRaw = "Dodaj OEM";

                button.Bounds = new Rectangle(Convert.ToInt32(ButtonParent.XposRaw) - 100, Convert.ToInt32(ButtonParent.YposRaw) - 0, 60, 15);


                AddSubscription(false, button.Id, Events.Accepted, new TakeEventDelegate(NewButton_OnAfterMouseDown));

                return true; 
        }

        public bool ChangeWindow(Procedures ProcId, int ControlId, Events Event)
        {
            button.Bounds = new Rectangle(Convert.ToInt32(ButtonParent.XposRaw) - 107, Convert.ToInt32(ButtonParent.YposRaw) + 0, 80, 20);
            return true;
        }

        public bool NewButton_OnAfterMouseDown(Procedures ProcedureId, int ControlId, Events Event)
        {
            try
            {
                DodajOEMForm form1 = new DodajOEMForm(TwrKarty.Twr_GIDNumer, Runtime.ActiveRuntime.Repository.Connection.Database.ToString());

                form1.Show();

                /*ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"K:\Dodatki Hydra\WyszukiwanieGrup.exe";

                // jesli jakis argument bedzie zawieral spacje to nalezy go podac w ten sposob: "\"" + costam + "\""
                startInfo.Arguments = TwrKarty.Twr_GIDNumer.ToString() + " " + "\"" + TwrKarty.Twr_Kod.ToString() + "\"" + " " + "\"" + TwrKarty.Twr_Nazwa.ToString() + "\"" + " " + "\"" +  Runtime.ActiveRuntime.Repository.Connection.Database.ToString() + "\""; // przekazanie do aplikacji exe do konstruktora parametrów (parametry powinny byc oddzielone spacjami!)


                Process process = new Process();
                process.StartInfo = startInfo;
                Thread th = new Thread(() =>
                {
                    process.Start();

                });
                th.Start();*/
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
    }
}

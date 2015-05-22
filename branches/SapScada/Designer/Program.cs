using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Designer.View;
using Designer.Core;
using Designer.Model;
using Common;
using System.ComponentModel;

namespace Designer
{
    public static class Program
    {
        #region version
        //public static string version = "2.0.2"; // updated 14/8/2014
        //public static string version = "2.0.3"; // updated 29/8/2014
        //public static string version = "2.0.4"; // updated 3/9/2014
        //public static string version = "2.0.5"; // updated 22/9/2014 - update IsStoreToLog
        //public static string version = "2.0.6"; // updated 22/10/2014 - update error status on marker
        //public static string version = "2.0.7"; // updated 23/12/2014 - update UI for VDK Controller and dabase connection
        //public static string version = "2.0.8"; // updated 6/1/2015 - update UI for VDK Controller - VDK Details and Scenario
        //public static string version = "2.0.9"; // updated 7/1/2015 - update Junction status : marker in google map and vdk app driver
        //public static string version = "2.0.10"; // updated 14/1/2015 - update alarm serverb
        //public static string version = "2.0.11"; // updated 14/1/2015 - update alarm for PLC and alarm news
        //public static string version = "2.0.12"; // updated 21/1/2015 - update alarm for PLC and alarm news
        // public static string version = "2.0.13"; // updated 21/1/2015 - update trend and update time every 4 hours
        //      public static string version = "2.1.0"; // updated 3/2/2015 - Update reset error layout for PLC Junction
        //     public static string version = "2.1.1"; // updated 8/4/2015 - 1 device can control 1 or more junctions.
        //  public static string version = "2.1.2"; // updated 5/5/2015 - when moving marker is allowed, can not open junction form (VDKJuntion or OPCJunction), fix update TOD
        //  public static string version = "2.1.3"; // updated 8/5/2015 - when losting connection and lost light, system send notifcatetion to supervisor via email : add email.cs and INotify interface and EmailNotify class
        //public static string version = "2.1.4"; // updated 8/5/2015 - update FrmVDKScenario : when currentTODId changed, unhighlight this row and highlight another row
     //   public static string version = "2.1.5"; // updated 19/5/2015 - update enhance perfomance of FrmVDKJunction and VDKPLCJunction, not come into 'not responding' state
        public static string version = "2.1.6"; // updated 21/5/2015 - update: send an email when the connection between server and controller is established
      
        #endregion

        public static bool IsRunning = false;
        public static Root Core = new Root();
        public static Dictionary<Form, List<Display>> DisplayForms = new Dictionary<Form, List<Display>>();
        public static FrmMain MainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new FrmMain();
            Application.Run(MainForm);
            StopRuntime();
        }

        public static void StartRuntime()
        {
            //    Core = new Root();
            Core.Initialize();
            Core.RunTask();
            Core.RunAlarmTask();
            IsRunning = true;
        }

        public static void StopRuntime()
        {
            if (Core != null)
            {
                Core.RemoveDisplay();
                Core.StopTask();
                Core.StopAlarmTask();
            }

            List<Form> keys = DisplayForms.Keys.ToList();
            for (int j = keys.Count - 1; j >= 0; j--)
            {
                keys[j].Close();
            }

            MainForm.CloseGraphicDesignerForm();
        }

        public static string GetDisplayTagAddress(string ioTagName)
        {
            string res = "";
            if (Core != null)
            {
                res = Core.GetDisplayTagAddress(ioTagName);
            }
            return res;
        }

        public static void AddDisplayForm(Form f, List<Display> disps)
        {
            DisplayForms.Add(f, disps);
            foreach (Display disp in disps)
            {
                int id = Core.AddDisplay(disp);
                disp.ID = id;
            }
            f.Enter += f_Enter;
            f.Leave += f_Leave;
        }

        private static void f_Leave(object sender, EventArgs e)
        {
            Form f = (Form)sender;
            if (DisplayForms.ContainsKey(f))
            {
                foreach (Display disp in DisplayForms[f])
                {
                    disp.Stop();
                }
            }
        }

        private static void f_Enter(object sender, EventArgs e)
        {
            Form f = (Form)sender;
            if (DisplayForms.ContainsKey(f))
            {
                foreach (Display disp in DisplayForms[f])
                {
                    disp.Run();
                }
            }
        }

        public static void RemoveDisplayForm(Form f)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(f);

        }

        private static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // release resource
            Form f = (Form)e.Result;
            f.Close();
            f.Dispose();
            GC.Collect();
        }

        private static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Form f = (Form)e.Argument;
            e.Result = f;
            if (DisplayForms.ContainsKey(f))
            {
                List<Display> disp = DisplayForms[f];
                for (int j = disp.Count - 1; j >= 0; j--)
                {
                    disp[j].Stop();
                    Core.RemoveDisplay(disp[j].ID);
                    disp.RemoveAt(j);
                }
                DisplayForms.Remove(f);
            }
        }

        public static void RefreshTask(string taskName)
        {

        }

        public static void SetIOTag(string tagName, string tagAddress, object[] data)
        {
            if (Core != null)
            {
                string taskName = tagAddress.Substring(0, tagAddress.Length - tagName.Length - 1);
                Task t = Core.FindTask(taskName);
                if (t != null)
                {
                    t.SetTagValue(tagName, data);
                }
            }
        }

        public static bool GetIOTag(string tagName, string tagAddress, List<int> param, out object data)
        {
            bool res = false;
            data = null;
            string taskName = tagAddress.Substring(0, tagAddress.Length - tagName.Length - 1);
            Task t = Core.FindTask(taskName);
            if (t != null)
            {
                res = t.GetTagValue(tagName, param);
                data = t.FindTag(tagName).Value2;
            }
            return res;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Designer.View;
using Designer.Core;
using Designer.Model;
using HDSComponent;

namespace Designer.View
{
    public partial class FrmGraphicDesign : Telerik.WinControls.UI.RadForm
    {
        FrmMonitor _FMonitor;
        FrmAlarm1 _FAlarm;
        FrmTrend1 _FTrend;
        FrmReport _FReport;
        bool _IsClosed = false;

        public FrmGraphicDesign()
        {
            InitializeComponent();

            _FMonitor = new FrmMonitor();
            _FMonitor.FormClosing += _FMonitor_FormClosing;

            _FAlarm = new FrmAlarm1();
            _FAlarm.FormClosing += _FMonitor_FormClosing;

            _FTrend = new FrmTrend1();
            _FTrend.FormClosing += _FMonitor_FormClosing;

            _FReport = new FrmReport();
            _FReport.FormClosing += _FMonitor_FormClosing;
        }

        void _FMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_IsClosed;
            if (e.Cancel == true)
            {
                ((Form)sender).Hide();
                ((Form)sender).MdiParent = null;
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender.Equals(menuDisplay))
            {
                _FMonitor.MdiParent = this;
                _FMonitor.Tag = this; // use for mdi container
                _FMonitor.Show();
            }
            else if (sender.Equals(menuAlarm))
            {
                _FAlarm.MdiParent = this;
                _FAlarm.Show();
            }
            else if (sender.Equals(menuTrend))
            {
                _FTrend.MdiParent = this;
                _FTrend.Show();
            }
            else if (sender.Equals(menuReport))
            {
                _FReport.MdiParent = this;
                _FReport.Show();
            }
            else if (sender.Equals(menuUpdateTime))
            {
                UpdateTimeForAllJunctions();
            }
        }

        private void UpdateTimeForAllJunctions()
        {
            List<Junction> juncs = DesignerAccess.GetJunctions();
            for (int j = 0; j < juncs.Count; j++)
            {
                string tagName = string.Format("{0}.Time", juncs[j].JunctionName);
                string address = Program.GetDisplayTagAddress(tagName);
                try
                {
                    Program.SetIOTag(tagName, address, new object[] { DateTime.Now});
                }
                catch (Exception)
                {
                    MessageHandler.Inform("Please start the runtime first !");
                }
            }
        }

        private void FrmGraphicDesign_FormClosed(object sender, FormClosedEventArgs e)
        {
            _IsClosed = true;
            _FMonitor.Close();
            _FAlarm.Close();
            _FReport.Close();
            _FTrend.Close();
        }

        private void FrmGraphicDesign_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}

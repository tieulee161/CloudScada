using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Designer.View
{
    public partial class FrmPLCJunction : Telerik.WinControls.UI.RadForm
    {
        FrmPLCControl _FrmControl;
        FrmPLCNormalDaySetting _FrmNormalDaySetting;
        FrmPLCSpecialDaySetting _FrmSpecialDaySetting;
        FrmPLCParametterSetting _FrmParametterSetting;
        FrmPLCAlarmSetting _FrmAlarmSetting;
        FrmPLCTime _FrmPLCTime;
        public string JunctionName;

        int _Index = 0;

        public FrmPLCJunction()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.FormClosed += FrmPLCJunction_FormClosed;
        }

        private void FrmPLCJunction_Load(object sender, EventArgs e)
        {
            this.Text = JunctionName;
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            BackgroundWorker loadWorker = new BackgroundWorker();
            // loadWorker.DoWork += loadWorker_DoWork;
            loadWorker.RunWorkerCompleted += loadWorker_RunWorkerCompleted;
            loadWorker.RunWorkerAsync();
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _FrmPLCTime = new FrmPLCTime();
            _FrmPLCTime.JunctionName = this.JunctionName;

            _FrmAlarmSetting = new FrmPLCAlarmSetting();
            _FrmAlarmSetting.JunctionName = this.JunctionName;

            _FrmParametterSetting = new FrmPLCParametterSetting();
            _FrmParametterSetting.JunctionName = this.JunctionName;

            _FrmSpecialDaySetting = new FrmPLCSpecialDaySetting();
            _FrmSpecialDaySetting.JunctionName = this.JunctionName;

            _FrmNormalDaySetting = new FrmPLCNormalDaySetting();
            _FrmNormalDaySetting.JunctionName = this.JunctionName;

            _FrmControl = new FrmPLCControl();
            _FrmControl.JunctionName = this.JunctionName;

            _FrmPLCTime.MdiParent = this;
            _FrmAlarmSetting.MdiParent = this;
            _FrmParametterSetting.MdiParent = this;
            _FrmSpecialDaySetting.MdiParent = this;
            _FrmNormalDaySetting.MdiParent = this;
            _FrmControl.MdiParent = this;

            Timer timer1 = new Timer();
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;

            _FrmPLCTime.Show();
            _FrmAlarmSetting.Show();
            _FrmParametterSetting.Show();
            _FrmSpecialDaySetting.Show();
            _FrmNormalDaySetting.Show();
            _FrmControl.Show();
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // do nothing
        }

        private void FrmPLCJunction_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmPLCTime.StopUpdating();
            _FrmAlarmSetting.StopUpdating();
            _FrmParametterSetting.StopUpdating();
            _FrmSpecialDaySetting.StopUpdating();
            _FrmNormalDaySetting.StopUpdating();
            _FrmControl.StopUpdating();
        }
    }
}

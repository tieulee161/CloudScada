using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Designer.Model;
using Designer.Core;

namespace Designer.View
{
    public partial class FrmPLCTime : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }

        public FrmPLCTime()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            JunctionName = DesignerAccess.GetJunction(JunctionName).DeviceName;
            this.Enter += FrmPLCControl_Enter;
        }

        private void FrmPLCControl_Enter(object sender, EventArgs e)
        {
            this.Enter -= FrmPLCControl_Enter;
            BackgroundWorker initWorker = new BackgroundWorker();
            initWorker.DoWork += initWorker_DoWork;
            initWorker.RunWorkerAsync();
        }

   
        private void initWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitDisplayTag();
        }

        private void InitDisplayTag()
        {
            Display page = new Display(100);

            indicatorDA.DisplayTag.Name = string.Format("{0}.DA_Q", JunctionName);
            indicatorDA.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDA.DisplayTag.Name);
            indicatorDA.DataMapping.Add(true, Properties.Resources.Red);
            indicatorDA.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorVA.DisplayTag.Name = string.Format("{0}.VA_Q", JunctionName);
            indicatorVA.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorVA.DisplayTag.Name);
            indicatorVA.DataMapping.Add(true, Properties.Resources.Yellow);
            indicatorVA.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorXA.DisplayTag.Name = string.Format("{0}.XA_Q", JunctionName);
            indicatorXA.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorXA.DisplayTag.Name);
            indicatorXA.DataMapping.Add(true, Properties.Resources.Green);
            indicatorXA.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorDB.DisplayTag.Name = string.Format("{0}.DB_Q", JunctionName);
            indicatorDB.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDB.DisplayTag.Name);
            indicatorDB.DataMapping.Add(true, Properties.Resources.Red);
            indicatorDB.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorVB.DisplayTag.Name = string.Format("{0}.VB_Q", JunctionName);
            indicatorVB.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorVB.DisplayTag.Name);
            indicatorVB.DataMapping.Add(true, Properties.Resources.Yellow);
            indicatorVB.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorXB.DisplayTag.Name = string.Format("{0}.XB_Q", JunctionName);
            indicatorXB.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorXB.DisplayTag.Name);
            indicatorXB.DataMapping.Add(true, Properties.Resources.Green);
            indicatorXB.DataMapping.Add(false, Properties.Resources.Gray);

            numberTDay.DisplayTag.Name = string.Format("{0}.DAY_PV", JunctionName);
            numberTDay.DisplayTag.Address = Program.GetDisplayTagAddress(numberTDay.DisplayTag.Name);

            numberTMonth.DisplayTag.Name = string.Format("{0}.MONTH_PV", JunctionName);
            numberTMonth.DisplayTag.Address = Program.GetDisplayTagAddress(numberTMonth.DisplayTag.Name);

            numberTYear.DisplayTag.Name = string.Format("{0}.YEAR_PV", JunctionName);
            numberTYear.DisplayTag.Address = Program.GetDisplayTagAddress(numberTYear.DisplayTag.Name);

            numberTHour.DisplayTag.Name = string.Format("{0}.HOUR_PV", JunctionName);
            numberTHour.DisplayTag.Address = Program.GetDisplayTagAddress(numberTHour.DisplayTag.Name);

            numberTMin.DisplayTag.Name = string.Format("{0}.MIN_PV", JunctionName);
            numberTMin.DisplayTag.Address = Program.GetDisplayTagAddress(numberTMin.DisplayTag.Name);

            numberTSec.DisplayTag.Name = string.Format("{0}.SEC_PV", JunctionName);
            numberTSec.DisplayTag.Address = Program.GetDisplayTagAddress(numberTSec.DisplayTag.Name);

            btnApplyTime.DisplayTag.Name = string.Format("{0}.SETTIME", JunctionName);
            btnApplyTime.DisplayTag.Address = Program.GetDisplayTagAddress(btnApplyTime.DisplayTag.Name);
            btnApplyTime.DataOnClickMapping.Add(this.BackColor, true);

            btnCV.DisplayTag.Name = string.Format("{0}.MAN_YEL", JunctionName);
            btnCV.DisplayTag.Address = Program.GetDisplayTagAddress(btnCV.DisplayTag.Name);
            btnCV.DataMapping.Add(false, Color.White);
            btnCV.DataMapping.Add(true, Color.Lime);
            btnCV.DataOnClickMapping.Add(Color.White, true);

            btnCVOff.DisplayTag.Name = string.Format("{0}.MAN_YEL", JunctionName);
            btnCVOff.DisplayTag.Address = Program.GetDisplayTagAddress(btnCVOff.DisplayTag.Name);
            btnCVOff.DataMapping.Add(true, Color.White);
            btnCVOff.DataMapping.Add(false, Color.Lime);
            btnCVOff.DataOnClickMapping.Add(Color.White, false);

            btnA.DisplayTag.Name = string.Format("{0}.MAN_TA", JunctionName);
            btnA.DisplayTag.Address = Program.GetDisplayTagAddress(btnA.DisplayTag.Name);
            btnA.DataMapping.Add(false, Color.White);
            btnA.DataMapping.Add(true, Color.Lime);
            btnA.DataOnClickMapping.Add(Color.White, true);

            btnB.DisplayTag.Name = string.Format("{0}.MAN_TB", JunctionName);
            btnB.DisplayTag.Address = Program.GetDisplayTagAddress(btnB.DisplayTag.Name);
            btnB.DataMapping.Add(false, Color.White);
            btnB.DataMapping.Add(true, Color.Lime);
            btnB.DataOnClickMapping.Add(Color.White, true);

            page.AddTag(indicatorDA.DisplayTag);
            page.AddTag(indicatorVA.DisplayTag);
            page.AddTag(indicatorXA.DisplayTag);
            page.AddTag(indicatorDB.DisplayTag);
            page.AddTag(indicatorVB.DisplayTag);
            page.AddTag(indicatorXB.DisplayTag);
            page.AddTag(numberTDay.DisplayTag);
            page.AddTag(numberTMonth.DisplayTag);
            page.AddTag(numberTYear.DisplayTag);
            page.AddTag(numberTHour.DisplayTag);
            page.AddTag(numberTMin.DisplayTag);
            page.AddTag(numberTSec.DisplayTag);
            page.AddTag(btnCV.DisplayTag);
            page.AddTag(btnCVOff.DisplayTag);
            page.AddTag(btnA.DisplayTag);
            page.AddTag(btnB.DisplayTag);
            page.AddTag(btnApplyTime.DisplayTag);

            Program.AddDisplayForm(this, new List<Display>() { page });

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.AutoReset = true;
            timer.Elapsed += timer_Elapsed;
            timer.Start();

            btnA.DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
            btnB.DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;

        }

        void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            try
            {
                bool A = (bool)btnA.DisplayTag.Value;
                bool B = (bool)btnB.DisplayTag.Value;
                if (A || B)
                {
                    btnABOff.ButtonElement.BackColor = Color.White;
                    btnABOff.ButtonElement.ButtonFillElement.BackColor = Color.White;
                    btnABOff.ButtonElement.ButtonFillElement.BackColor2 = Color.White;
                    btnABOff.ButtonElement.ButtonFillElement.BackColor3 = Color.White;
                    btnABOff.ButtonElement.ButtonFillElement.BackColor4 = Color.White;
                }
                else
                {
                    btnABOff.ButtonElement.BackColor = Color.Lime;
                    btnABOff.ButtonElement.ButtonFillElement.BackColor = Color.Lime;
                    btnABOff.ButtonElement.ButtonFillElement.BackColor2 = Color.Lime;
                    btnABOff.ButtonElement.ButtonFillElement.BackColor3 = Color.Lime;
                    btnABOff.ButtonElement.ButtonFillElement.BackColor4 = Color.Lime;
                }
            }
            catch (Exception)
            { }
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime time = DateTime.Now;
            numberSDay.Value = time.Day;
            numberSMonth.Value = time.Month;
            numberSYear.Value = time.Year;
            numberSHour.Value = time.Hour;
            numberSMin.Value = time.Minute;
            numberSSec.Value = time.Second;
            lbTime.Text = time.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnABOff_Click(object sender, EventArgs e)
        {
            btnA.DisplayTag.SetTagValue(false);
            btnB.DisplayTag.SetTagValue(false);
        }

       
        private void FrmPLCTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.RemoveDisplayForm(this);
        }


    }
}

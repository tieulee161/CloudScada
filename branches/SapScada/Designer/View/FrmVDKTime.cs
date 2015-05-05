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
    public partial class FrmVDKTime : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }

        private bool _FirstScan { get; set; }

        public FrmVDKTime()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            JunctionName = DesignerAccess.GetJunction(JunctionName).DeviceName;
            _FirstScan = true;
            this.Enter += FrmVDKTime_Enter;
        }

        private void FrmVDKTime_Enter(object sender, EventArgs e)
        {
            if(_FirstScan)
            {
                _FirstScan = false;
                BackgroundWorker initWorker = new BackgroundWorker();
                initWorker.DoWork += initWorker_DoWork;
                initWorker.RunWorkerAsync();
                initWorker.RunWorkerCompleted += initWorker_RunWorkerCompleted;
            }
            else
            {
                ((Form)(this.Tag)).Size = new Size(634, 482);
            }
          
        }

        private void initWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Enabled = true;
        }

        private void initWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitDisplayTag();
        }

        private void InitDisplayTag()
        {
            Display page = new Display(500);

            HDSComponent.UI.HDDataSource textSource1 = new HDSComponent.UI.HDDataSource();
            textSource1.DisplayTag.Name = string.Format("{0}.ControlMode", JunctionName);
            textSource1.DisplayTag.Address = Program.GetDisplayTagAddress(textSource1.DisplayTag.Name);
            Dictionary<object, object> dataMapping1 = new Dictionary<object, object>();
            dataMapping1.Add(0, "Tự động");
            dataMapping1.Add(1, "Điều khiển bằng tay tại tủ");
            dataMapping1.Add(2, "Điều khiển từ xa qua mạng");
            dataMapping1.Add(3, "An toàn");
            dataMapping1.Add(4, "Hiệu chỉnh");
            textSource1.BindTo(txtControlMode, "Text", dataMapping1);

            HDSComponent.UI.HDDataSource textSource2 = new HDSComponent.UI.HDDataSource();
            textSource2.DisplayTag.Name = string.Format("{0}.ControlType", JunctionName);
            textSource2.DisplayTag.Address = Program.GetDisplayTagAddress(textSource2.DisplayTag.Name);
            Dictionary<object, object> dataMapping2 = new Dictionary<object, object>();
            dataMapping2.Add(0, "Giản đồ");
            dataMapping2.Add(1, "Làn sóng xanh");
            dataMapping2.Add(2, "Chớp vàng");
            dataMapping2.Add(3, "Tắt tủ");
            dataMapping2.Add(4, "Tất cả đỏ");
            textSource2.BindTo(txtControlType, "Text", dataMapping2);

            numberTDay.DisplayTag.Name = string.Format("{0}.Day", JunctionName);
            numberTDay.DisplayTag.Address = Program.GetDisplayTagAddress(numberTDay.DisplayTag.Name);

            numberTMonth.DisplayTag.Name = string.Format("{0}.Month", JunctionName);
            numberTMonth.DisplayTag.Address = Program.GetDisplayTagAddress(numberTMonth.DisplayTag.Name);

            numberTYear.DisplayTag.Name = string.Format("{0}.Year", JunctionName);
            numberTYear.DisplayTag.Address = Program.GetDisplayTagAddress(numberTYear.DisplayTag.Name);

            numberTHour.DisplayTag.Name = string.Format("{0}.Hour", JunctionName);
            numberTHour.DisplayTag.Address = Program.GetDisplayTagAddress(numberTHour.DisplayTag.Name);

            numberTMin.DisplayTag.Name = string.Format("{0}.Minute", JunctionName);
            numberTMin.DisplayTag.Address = Program.GetDisplayTagAddress(numberTMin.DisplayTag.Name);

            numberTSec.DisplayTag.Name = string.Format("{0}.Second", JunctionName);
            numberTSec.DisplayTag.Address = Program.GetDisplayTagAddress(numberTSec.DisplayTag.Name);

            btnSetTime.DisplayTag.Name = string.Format("{0}.SetTime", JunctionName);
            btnSetTime.DisplayTag.Address = Program.GetDisplayTagAddress(btnSetTime.DisplayTag.Name);
            btnSetTime.DataOnClickMapping.Add(this.BackColor, true);

            btnFlash.DisplayTag.Name = string.Format("{0}.Flash", JunctionName);
            btnFlash.DisplayTag.Address = Program.GetDisplayTagAddress(btnFlash.DisplayTag.Name);
            btnFlash.DataMapping.Add(0, Color.White);
            btnFlash.DataMapping.Add(1, Color.Lime);
            btnFlash.DataOnClickMapping.Add(this.BackColor, 1);

            btnOff.DisplayTag.Name = string.Format("{0}.OffController", JunctionName);
            btnOff.DisplayTag.Address = Program.GetDisplayTagAddress(btnOff.DisplayTag.Name);
            btnOff.DataMapping.Add(0, Color.White);
            btnOff.DataMapping.Add(1, Color.Lime);
            btnOff.DataOnClickMapping.Add(this.BackColor, 1);

            btnChangePhase.DisplayTag.Name = string.Format("{0}.ChangePhase", JunctionName);
            btnChangePhase.DisplayTag.Address = Program.GetDisplayTagAddress(btnChangePhase.DisplayTag.Name);
            btnChangePhase.DataMapping.Add(0, Color.White);
            btnChangePhase.DataMapping.Add(1, Color.Lime);
            btnChangePhase.DataOnClickMapping.Add(this.BackColor, 1);

            btnAuto.DisplayTag.Name = string.Format("{0}.Auto", JunctionName);
            btnAuto.DisplayTag.Address = Program.GetDisplayTagAddress(btnAuto.DisplayTag.Name);
            btnAuto.DataMapping.Add(0, Color.White);
            btnAuto.DataMapping.Add(1, Color.Lime);
            btnAuto.DataOnClickMapping.Add(this.BackColor, 1);

            btnCalib.DisplayTag.Name = string.Format("{0}.Calib", JunctionName);
            btnCalib.DisplayTag.Address = Program.GetDisplayTagAddress(btnCalib.DisplayTag.Name);
            btnCalib.DataMapping.Add(0, Color.White);
            btnCalib.DataMapping.Add(1, Color.Lime);
            btnCalib.DataOnClickMapping.Add(this.BackColor, 1);

            page.AddTag(textSource1.DisplayTag);
            page.AddTag(textSource2.DisplayTag);
            page.AddTag(numberTDay.DisplayTag);
            page.AddTag(numberTMonth.DisplayTag);
            page.AddTag(numberTYear.DisplayTag);
            page.AddTag(numberTHour.DisplayTag);
            page.AddTag(numberTMin.DisplayTag);
            page.AddTag(numberTSec.DisplayTag);
            page.AddTag(btnSetTime.DisplayTag);
            page.AddTag(btnFlash.DisplayTag);
            page.AddTag(btnOff.DisplayTag);
            page.AddTag(btnChangePhase.DisplayTag);
            page.AddTag(btnAuto.DisplayTag);
            page.AddTag(btnCalib.DisplayTag);

            Program.AddDisplayForm(this, new List<Display>() { page });



           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            { }
        }

        private void FrmVDKTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            Program.RemoveDisplayForm(this);
        }
    }
}

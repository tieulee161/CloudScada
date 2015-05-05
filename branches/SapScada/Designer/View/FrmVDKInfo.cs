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
using Common;

namespace Designer.View
{
    public partial class FrmVDKInfo : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }

        private bool _FirstScan { get; set; }

        public FrmVDKInfo()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            JunctionName = DesignerAccess.GetJunction(JunctionName).DeviceName;
            _FirstScan = true;
            this.Enter += FrmVDKInfo_Enter;
        }

        private void FrmVDKInfo_Enter(object sender, EventArgs e)
        {
           if(_FirstScan)
           {
               _FirstScan = false;
               BackgroundWorker initWorker = new BackgroundWorker();
               initWorker.DoWork += initWorker_DoWork;
               initWorker.RunWorkerAsync();
           }
           else
           {
               ((Form)(this.Tag)).Size = new Size(634, 482);
           }
           
        }

        void initWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitDisplayTag();
        }

        private void InitDisplayTag()
        {
            Display page = new Display(1000);

            txtControllerId.DisplayTag.Name = string.Format("{0}.ControllerId", JunctionName);
            txtControllerId.DisplayTag.Address = Program.GetDisplayTagAddress(txtControllerId.DisplayTag.Name);

            txtHardwareVersion.DisplayTag.Name = string.Format("{0}.HardwareVersion", JunctionName);
            txtHardwareVersion.DisplayTag.Address = Program.GetDisplayTagAddress(txtHardwareVersion.DisplayTag.Name);

            txtFirmwareVersion.DisplayTag.Name = string.Format("{0}.FirmwareVersion", JunctionName);
            txtFirmwareVersion.DisplayTag.Address = Program.GetDisplayTagAddress(txtFirmwareVersion.DisplayTag.Name);

            txtDownloadTime.DisplayTag.Name = string.Format("{0}.DownloadTime", JunctionName);
            txtDownloadTime.DisplayTag.Address = Program.GetDisplayTagAddress(txtDownloadTime.DisplayTag.Name);

            txtSource.DisplayTag.Name = string.Format("{0}.SourceVoltage", JunctionName);
            txtSource.DisplayTag.Address = Program.GetDisplayTagAddress(txtSource.DisplayTag.Name);

            txtBat.DisplayTag.Name = string.Format("{0}.BatteryVoltage", JunctionName);
            txtBat.DisplayTag.Address = Program.GetDisplayTagAddress(txtBat.DisplayTag.Name);

            txtTemperature.DisplayTag.Name = string.Format("{0}.Temperature", JunctionName);
            txtTemperature.DisplayTag.Address = Program.GetDisplayTagAddress(txtTemperature.DisplayTag.Name);

            txtPowerOff.DisplayTag.Name = string.Format("{0}.OffTime", JunctionName);
            txtPowerOff.DisplayTag.Address = Program.GetDisplayTagAddress(txtPowerOff.DisplayTag.Name);

            txtPowerOn.DisplayTag.Name = string.Format("{0}.OnTime", JunctionName);
            txtPowerOn.DisplayTag.Address = Program.GetDisplayTagAddress(txtPowerOn.DisplayTag.Name);

            IDisplayTag infoTag = new IDisplayTag();
            infoTag.Name = string.Format("{0}.CotrollerInfo", JunctionName);
            infoTag.Address = Program.GetDisplayTagAddress(infoTag.Name);

            IDisplayTag ptsTag = new IDisplayTag();
            ptsTag.Name = string.Format("{0}.PowerTimeStamp", JunctionName);
            ptsTag.Address = Program.GetDisplayTagAddress(ptsTag.Name);

            page.AddTag(txtControllerId.DisplayTag);
            page.AddTag(txtHardwareVersion.DisplayTag);
            page.AddTag(txtFirmwareVersion.DisplayTag);
            page.AddTag(txtDownloadTime.DisplayTag);
            page.AddTag(txtSource.DisplayTag);
            page.AddTag(txtBat.DisplayTag);
            page.AddTag(txtTemperature.DisplayTag);
            page.AddTag(txtPowerOff.DisplayTag);
            page.AddTag(txtPowerOn.DisplayTag);
            page.AddTag(infoTag);
            page.AddTag(ptsTag);

            Program.AddDisplayForm(this, new List<Display>() { page });
        }

        private void FrmVDKInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.RemoveDisplayForm(this);
        }

    }
}

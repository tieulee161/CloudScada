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
    public partial class FrmVDKPeripheral : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }

        private bool _FirstScan { get; set; }

        public FrmVDKPeripheral()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            JunctionName = DesignerAccess.GetJunction(JunctionName).DeviceName;
            _FirstScan = true;

            this.Enter += FrmVDKPeripheral_Enter;
        }

        private void FrmVDKPeripheral_Enter(object sender, EventArgs e)
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

        private void initWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitDisplayTag();
        }

        private void InitDisplayTag()
        {
            Display page = new Display(500);

            chkI0.DisplayTag.Name = string.Format("{0}.Input.0", JunctionName);
            chkI0.DisplayTag.Address = Program.GetDisplayTagAddress(chkI0.DisplayTag.Name);
            chkI0.DataMapping.Add(true, true);
            chkI0.DataMapping.Add(false, false);

            chkI1.DisplayTag.Name = string.Format("{0}.Input.1", JunctionName);
            chkI1.DisplayTag.Address = Program.GetDisplayTagAddress(chkI1.DisplayTag.Name);
            chkI1.DataMapping.Add(true, true);
            chkI1.DataMapping.Add(false, false);

            chkI2.DisplayTag.Name = string.Format("{0}.Input.2", JunctionName);
            chkI2.DisplayTag.Address = Program.GetDisplayTagAddress(chkI2.DisplayTag.Name);
            chkI2.DataMapping.Add(true, true);
            chkI2.DataMapping.Add(false, false);

            chkI3.DisplayTag.Name = string.Format("{0}.Input.3", JunctionName);
            chkI3.DisplayTag.Address = Program.GetDisplayTagAddress(chkI3.DisplayTag.Name);
            chkI3.DataMapping.Add(true, true);
            chkI3.DataMapping.Add(false, false);

            chkI4.DisplayTag.Name = string.Format("{0}.Input.4", JunctionName);
            chkI4.DisplayTag.Address = Program.GetDisplayTagAddress(chkI4.DisplayTag.Name);
            chkI4.DataMapping.Add(true, true);
            chkI4.DataMapping.Add(false, false);

            chkI5.DisplayTag.Name = string.Format("{0}.Input.5", JunctionName);
            chkI5.DisplayTag.Address = Program.GetDisplayTagAddress(chkI5.DisplayTag.Name);
            chkI5.DataMapping.Add(true, true);
            chkI5.DataMapping.Add(false, false);

            chkI6.DisplayTag.Name = string.Format("{0}.Input.6", JunctionName);
            chkI6.DisplayTag.Address = Program.GetDisplayTagAddress(chkI6.DisplayTag.Name);
            chkI6.DataMapping.Add(true, true);
            chkI6.DataMapping.Add(false, false);

            chkI7.DisplayTag.Name = string.Format("{0}.Input.7", JunctionName);
            chkI7.DisplayTag.Address = Program.GetDisplayTagAddress(chkI7.DisplayTag.Name);
            chkI7.DataMapping.Add(true, true);
            chkI7.DataMapping.Add(false, false);

            chkI8.DisplayTag.Name = string.Format("{0}.Input.8", JunctionName);
            chkI8.DisplayTag.Address = Program.GetDisplayTagAddress(chkI8.DisplayTag.Name);
            chkI8.DataMapping.Add(true, true);
            chkI8.DataMapping.Add(false, false);

            chkI9.DisplayTag.Name = string.Format("{0}.Input.9", JunctionName);
            chkI9.DisplayTag.Address = Program.GetDisplayTagAddress(chkI9.DisplayTag.Name);
            chkI9.DataMapping.Add(true, true);
            chkI9.DataMapping.Add(false, false);

            chkI10.DisplayTag.Name = string.Format("{0}.Input.10", JunctionName);
            chkI10.DisplayTag.Address = Program.GetDisplayTagAddress(chkI10.DisplayTag.Name);
            chkI10.DataMapping.Add(true, true);
            chkI10.DataMapping.Add(false, false);

            chkI11.DisplayTag.Name = string.Format("{0}.Input.11", JunctionName);
            chkI11.DisplayTag.Address = Program.GetDisplayTagAddress(chkI11.DisplayTag.Name);
            chkI11.DataMapping.Add(true, true);
            chkI11.DataMapping.Add(false, false);

            chkI12.DisplayTag.Name = string.Format("{0}.Input.12", JunctionName);
            chkI12.DisplayTag.Address = Program.GetDisplayTagAddress(chkI12.DisplayTag.Name);
            chkI12.DataMapping.Add(true, true);
            chkI12.DataMapping.Add(false, false);

            chkI13.DisplayTag.Name = string.Format("{0}.Input.13", JunctionName);
            chkI13.DisplayTag.Address = Program.GetDisplayTagAddress(chkI13.DisplayTag.Name);
            chkI13.DataMapping.Add(true, true);
            chkI13.DataMapping.Add(false, false);

            chkI14.DisplayTag.Name = string.Format("{0}.Input.14", JunctionName);
            chkI14.DisplayTag.Address = Program.GetDisplayTagAddress(chkI14.DisplayTag.Name);
            chkI14.DataMapping.Add(true, true);
            chkI14.DataMapping.Add(false, false);

            chkI15.DisplayTag.Name = string.Format("{0}.Input.15", JunctionName);
            chkI15.DisplayTag.Address = Program.GetDisplayTagAddress(chkI15.DisplayTag.Name);
            chkI15.DataMapping.Add(true, true);
            chkI15.DataMapping.Add(false, false);

            chkQ0.DisplayTag.Name = string.Format("{0}.Output.0", JunctionName);
            chkQ0.DisplayTag.Address = Program.GetDisplayTagAddress(chkQ0.DisplayTag.Name);
            chkQ0.DataMapping.Add(true, true);
            chkQ0.DataMapping.Add(false, false);


            chkQ1.DisplayTag.Name = string.Format("{0}.Output.1", JunctionName);
            chkQ1.DisplayTag.Address = Program.GetDisplayTagAddress(chkQ1.DisplayTag.Name);
            chkQ1.DataMapping.Add(true, true);
            chkQ1.DataMapping.Add(false, false);

            chkQ2.DisplayTag.Name = string.Format("{0}.Output.2", JunctionName);
            chkQ2.DisplayTag.Address = Program.GetDisplayTagAddress(chkQ2.DisplayTag.Name);
            chkQ2.DataMapping.Add(true, true);
            chkQ2.DataMapping.Add(false, false);

            chkManualError0.DisplayTag.Name = string.Format("{0}.ManualError.0", JunctionName);
            chkManualError0.DisplayTag.Address = Program.GetDisplayTagAddress(chkManualError0.DisplayTag.Name);
            chkManualError0.DataMapping.Add(true, true);
            chkManualError0.DataMapping.Add(false, false);

            chkManualError1.DisplayTag.Name = string.Format("{0}.ManualError.1", JunctionName);
            chkManualError1.DisplayTag.Address = Program.GetDisplayTagAddress(chkManualError1.DisplayTag.Name);
            chkManualError1.DataMapping.Add(true, true);
            chkManualError1.DataMapping.Add(false, false);

            chkManualError2.DisplayTag.Name = string.Format("{0}.ManualError.2", JunctionName);
            chkManualError2.DisplayTag.Address = Program.GetDisplayTagAddress(chkManualError2.DisplayTag.Name);
            chkManualError2.DataMapping.Add(true, true);
            chkManualError2.DataMapping.Add(false, false);

            HDSComponent.UI.HDDataSource textSource1 = new HDSComponent.UI.HDDataSource();
            textSource1.DisplayTag.Name = string.Format("{0}.ManualButton", JunctionName);
            textSource1.DisplayTag.Address = Program.GetDisplayTagAddress(textSource1.DisplayTag.Name);
            Dictionary<object, object> dataMapping1 = new Dictionary<object, object>();
            dataMapping1.Add(0, "Tự động");
            dataMapping1.Add(1, "Xanh vàng đỏ");
            dataMapping1.Add(2, "Chớp vàng");
            dataMapping1.Add(3, "Tất cả đỏ");
            textSource1.BindTo(txtManualButtonStatus, "Text", dataMapping1);

            HDSComponent.UI.HDDataSource textSource2 = new HDSComponent.UI.HDDataSource();
            textSource2.DisplayTag.Name = string.Format("{0}.HMIConnection", JunctionName);
            textSource2.DisplayTag.Address = Program.GetDisplayTagAddress(textSource2.DisplayTag.Name);
            Dictionary<object, object> dataMapping2 = new Dictionary<object, object>();
            dataMapping2.Add(0, "Bắt đầu kết nối");
            dataMapping2.Add(1, "Đã được kết nối");
            dataMapping2.Add(2, "Mất kết nối");
            textSource2.BindTo(txtHMIStatus, "Text", dataMapping2);

            HDSComponent.UI.HDDataSource textSource3 = new HDSComponent.UI.HDDataSource();
            textSource3.DisplayTag.Name = string.Format("{0}.SDConnection", JunctionName);
            textSource3.DisplayTag.Address = Program.GetDisplayTagAddress(textSource3.DisplayTag.Name);
            Dictionary<object, object> dataMapping3 = new Dictionary<object, object>();
            dataMapping3.Add(0, "Chưa được gắn");
            dataMapping3.Add(1, "Đã được tháo ra");
            dataMapping3.Add(2, "Quá trình khởi động bị lỗi");
            dataMapping3.Add(3, "Thẻ nhớ đã bị lỗi");
            dataMapping3.Add(4, "Đã được gắn");
            dataMapping3.Add(5, "Đang khởi động");
            dataMapping3.Add(6, "Đã được kết nối");
            dataMapping3.Add(7, "Thực hiện lại việc kết nối");
            textSource3.BindTo(txtSDCardStatus, "Text", dataMapping3);

            IDisplayTag ioTag = new IDisplayTag();
            ioTag.Name = string.Format("{0}.IOStatus", JunctionName);
            ioTag.Address = Program.GetDisplayTagAddress(ioTag.Name);

            IDisplayTag hmiTag = new IDisplayTag();
            hmiTag.Name = string.Format("{0}.HMIStatus", JunctionName);
            hmiTag.Address = Program.GetDisplayTagAddress(hmiTag.Name);

            IDisplayTag sdTag = new IDisplayTag();
            sdTag.Name = string.Format("{0}.SDCardStatus", JunctionName);
            sdTag.Address = Program.GetDisplayTagAddress(sdTag.Name);

            page.AddTag(chkI0.DisplayTag);
            page.AddTag(chkI1.DisplayTag);
            page.AddTag(chkI2.DisplayTag);
            page.AddTag(chkI3.DisplayTag);
            page.AddTag(chkI4.DisplayTag);
            page.AddTag(chkI5.DisplayTag);
            page.AddTag(chkI6.DisplayTag);
            page.AddTag(chkI7.DisplayTag);
            page.AddTag(chkI8.DisplayTag);
            page.AddTag(chkI9.DisplayTag);
            page.AddTag(chkI10.DisplayTag);
            page.AddTag(chkI11.DisplayTag);
            page.AddTag(chkI12.DisplayTag);
            page.AddTag(chkI13.DisplayTag);
            page.AddTag(chkI14.DisplayTag);
            page.AddTag(chkI15.DisplayTag);

            page.AddTag(chkQ0.DisplayTag);
            page.AddTag(chkQ1.DisplayTag);
            page.AddTag(chkQ2.DisplayTag);

            page.AddTag(chkManualError0.DisplayTag);
            page.AddTag(chkManualError1.DisplayTag);
            page.AddTag(chkManualError2.DisplayTag);

            page.AddTag(textSource1.DisplayTag);
            page.AddTag(textSource2.DisplayTag);
            page.AddTag(textSource3.DisplayTag);

            page.AddTag(ioTag);
            page.AddTag(hmiTag);
            page.AddTag(sdTag);

            Program.AddDisplayForm(this, new List<Display>() { page });
        }

        private void FrmVDKPeripheral_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        public void StopUpdating()
        {
            Program.RemoveDisplayForm(this);
        }


    }
}

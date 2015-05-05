using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using System.Threading;
using Designer.Model;
using Designer.Core;

namespace Designer.View
{
    public partial class FrmVDKPowerCard : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }

        private bool _FirstScan { get; set; }

        private Display _Page { get; set; }

        public FrmVDKPowerCard()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            JunctionName = DesignerAccess.GetJunction(JunctionName).DeviceName;
            _FirstScan = true;

            this.Enter += FrmVDKPowerCard_Enter;
            this.spinPLCIndex.ValueChanged += spinPLCIndex_ValueChanged;
        }
      
        private void spinPLCIndex_ValueChanged(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void FrmVDKPowerCard_Enter(object sender, EventArgs e)
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

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ChangeTagAddress((int)spinPLCIndex.Value);
        }

        private void initWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitDisplayTag();
        }

        private void InitDisplayTag(int cardId = 0)
        {
            _Page = new Display(500);

            HDSComponent.UI.HDDataSource textSource1 = new HDSComponent.UI.HDDataSource();
            textSource1.DisplayTag.Name = string.Format("{0}.CardStatus.{1}", JunctionName, cardId);
            textSource1.DisplayTag.Address = Program.GetDisplayTagAddress(textSource1.DisplayTag.Name);
            Dictionary<object, object> dataMapping1 = new Dictionary<object, object>();
            dataMapping1.Add(0, "Đang khởi động");
            dataMapping1.Add(1, "Kiểm tra card có được gắn");
            dataMapping1.Add(2, "Kiểm tra có kết nối được không");
            dataMapping1.Add(3, "Card không được gắn");
            dataMapping1.Add(4, "Không kết nối được với card công suất");
            dataMapping1.Add(5, "Card đã kết nối");
            dataMapping1.Add(6, "Card được kết nối nhưng không được sử dụng");
            textSource1.BindTo(txtStatus, "Text", dataMapping1);
            txtStatus.DisplayTag = textSource1.DisplayTag;

            numberAlive.DisplayTag.Name = string.Format("{0}.CardAlive.{1}", JunctionName, cardId);
            numberAlive.DisplayTag.Address = Program.GetDisplayTagAddress(numberAlive.DisplayTag.Name);

            chkError0.DisplayTag.Name = string.Format("{0}.CardError.{1}.0", JunctionName, cardId);
            chkError0.DisplayTag.Address = Program.GetDisplayTagAddress(chkError0.DisplayTag.Name);
            chkError0.DataMapping.Add(true, true);
            chkError0.DataMapping.Add(false, false);

            chkError1.DisplayTag.Name = string.Format("{0}.CardError.{1}.1", JunctionName, cardId);
            chkError1.DisplayTag.Address = Program.GetDisplayTagAddress(chkError1.DisplayTag.Name);
            chkError1.DataMapping.Add(true, true);
            chkError1.DataMapping.Add(false, false);

            chkError2.DisplayTag.Name = string.Format("{0}.CardError.{1}.2", JunctionName, cardId);
            chkError2.DisplayTag.Address = Program.GetDisplayTagAddress(chkError2.DisplayTag.Name);
            chkError2.DataMapping.Add(true, true);
            chkError2.DataMapping.Add(false, false);

            chkError3.DisplayTag.Name = string.Format("{0}.CardError.{1}.4", JunctionName, cardId);
            chkError3.DisplayTag.Address = Program.GetDisplayTagAddress(chkError3.DisplayTag.Name);
            chkError3.DataMapping.Add(true, true);
            chkError3.DataMapping.Add(false, false);

            chkError4.DisplayTag.Name = string.Format("{0}.CardError.{1}.5", JunctionName, cardId);
            chkError4.DisplayTag.Address = Program.GetDisplayTagAddress(chkError4.DisplayTag.Name);
            chkError4.DataMapping.Add(true, true);
            chkError4.DataMapping.Add(false, false);

            chkError5.DisplayTag.Name = string.Format("{0}.CardError.{1}.6", JunctionName, cardId);
            chkError5.DisplayTag.Address = Program.GetDisplayTagAddress(chkError5.DisplayTag.Name);
            chkError5.DataMapping.Add(true, true);
            chkError5.DataMapping.Add(false, false);

            chkError6.DisplayTag.Name = string.Format("{0}.CardError.{1}.7", JunctionName, cardId);
            chkError6.DisplayTag.Address = Program.GetDisplayTagAddress(chkError6.DisplayTag.Name);
            chkError6.DataMapping.Add(true, true);
            chkError6.DataMapping.Add(false, false);

            _Page.AddTag(textSource1.DisplayTag);
            _Page.AddTag(numberAlive.DisplayTag);
            _Page.AddTag(chkError0.DisplayTag);
            _Page.AddTag(chkError1.DisplayTag);
            _Page.AddTag(chkError2.DisplayTag);
            _Page.AddTag(chkError3.DisplayTag);
            _Page.AddTag(chkError4.DisplayTag);
            _Page.AddTag(chkError5.DisplayTag);
            _Page.AddTag(chkError6.DisplayTag);

            Program.AddDisplayForm(this, new List<Display>() { _Page });
        }

        private void ChangeTagAddress(int cardId = 0)
        {
            txtStatus.DisplayTag.Name = string.Format("{0}.CardStatus.{1}", JunctionName, cardId);
            txtStatus.DisplayTag.Address = Program.GetDisplayTagAddress(txtStatus.DisplayTag.Name);

            numberAlive.DisplayTag.Name = string.Format("{0}.CardAlive.{1}", JunctionName, cardId);
            numberAlive.DisplayTag.Address = Program.GetDisplayTagAddress(numberAlive.DisplayTag.Name);

            chkError0.DisplayTag.Name = string.Format("{0}.CardError.{1}.0", JunctionName, cardId);
            chkError0.DisplayTag.Address = Program.GetDisplayTagAddress(chkError0.DisplayTag.Name);

            chkError1.DisplayTag.Name = string.Format("{0}.CardError.{1}.1", JunctionName, cardId);
            chkError1.DisplayTag.Address = Program.GetDisplayTagAddress(chkError1.DisplayTag.Name);

            chkError2.DisplayTag.Name = string.Format("{0}.CardError.{1}.2", JunctionName, cardId);
            chkError2.DisplayTag.Address = Program.GetDisplayTagAddress(chkError2.DisplayTag.Name);

            chkError3.DisplayTag.Name = string.Format("{0}.CardError.{1}.4", JunctionName, cardId);
            chkError3.DisplayTag.Address = Program.GetDisplayTagAddress(chkError3.DisplayTag.Name);

            chkError4.DisplayTag.Name = string.Format("{0}.CardError.{1}.5", JunctionName, cardId);
            chkError4.DisplayTag.Address = Program.GetDisplayTagAddress(chkError4.DisplayTag.Name);

            chkError5.DisplayTag.Name = string.Format("{0}.CardError.{1}.6", JunctionName, cardId);
            chkError5.DisplayTag.Address = Program.GetDisplayTagAddress(chkError5.DisplayTag.Name);

            chkError6.DisplayTag.Name = string.Format("{0}.CardError.{1}.7", JunctionName, cardId);
            chkError6.DisplayTag.Address = Program.GetDisplayTagAddress(chkError6.DisplayTag.Name);
        }

        private void FrmVDKPowerCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.RemoveDisplayForm(this);
        }
    }
}

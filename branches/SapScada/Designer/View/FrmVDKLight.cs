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
    public partial class FrmVDKLight : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }
        private bool _FirstScan { get; set; }
        private Display _Page { get; set; }

        public FrmVDKLight()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            JunctionName = DesignerAccess.GetJunction(JunctionName).DeviceName;
            _FirstScan = true;

            this.Enter += FrmVDKLight_Enter;
            this.spinCardId.ValueChanged += spinCardId_ValueChanged;
        }

        private void spinCardId_ValueChanged(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ChangeDisplayTagAddress((int)spinCardId.Value);
        }

        private void FrmVDKLight_Enter(object sender, EventArgs e)
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

        private void InitDisplayTag(int cardId = 0)
        {
            _Page = new Display(500);

            indicatorDK0.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 0);
            indicatorDK0.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK0.DisplayTag.Name);
            indicatorDK0.DataMapping.Add(true, Properties.Resources.Green);
            indicatorDK0.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorDK1.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 1);
            indicatorDK1.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK1.DisplayTag.Name);
            indicatorDK1.DataMapping.Add(true, Properties.Resources.Green);
            indicatorDK1.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorDK2.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 2);
            indicatorDK2.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK2.DisplayTag.Name);
            indicatorDK2.DataMapping.Add(true, Properties.Resources.Green);
            indicatorDK2.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorDK3.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 3);
            indicatorDK3.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK3.DisplayTag.Name);
            indicatorDK3.DataMapping.Add(true, Properties.Resources.Green);
            indicatorDK3.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorDK4.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 4);
            indicatorDK4.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK4.DisplayTag.Name);
            indicatorDK4.DataMapping.Add(true, Properties.Resources.Green);
            indicatorDK4.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorDK5.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 5);
            indicatorDK5.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK5.DisplayTag.Name);
            indicatorDK5.DataMapping.Add(true, Properties.Resources.Green);
            indicatorDK5.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorDK6.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 6);
            indicatorDK6.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK6.DisplayTag.Name);
            indicatorDK6.DataMapping.Add(true, Properties.Resources.Green);
            indicatorDK6.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorDK7.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 7);
            indicatorDK7.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK7.DisplayTag.Name);
            indicatorDK7.DataMapping.Add(true, Properties.Resources.Green);
            indicatorDK7.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorFB0.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 0);
            indicatorFB0.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB0.DisplayTag.Name);
            indicatorFB0.DataMapping.Add(true, Properties.Resources.Green);
            indicatorFB0.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorFB1.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 1);
            indicatorFB1.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB1.DisplayTag.Name);
            indicatorFB1.DataMapping.Add(true, Properties.Resources.Green);
            indicatorFB1.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorFB2.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 2);
            indicatorFB2.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB2.DisplayTag.Name);
            indicatorFB2.DataMapping.Add(true, Properties.Resources.Green);
            indicatorFB2.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorFB3.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 3);
            indicatorFB3.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB3.DisplayTag.Name);
            indicatorFB3.DataMapping.Add(true, Properties.Resources.Green);
            indicatorFB3.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorFB4.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 4);
            indicatorFB4.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB4.DisplayTag.Name);
            indicatorFB4.DataMapping.Add(true, Properties.Resources.Green);
            indicatorFB4.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorFB5.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 5);
            indicatorFB5.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB5.DisplayTag.Name);
            indicatorFB5.DataMapping.Add(true, Properties.Resources.Green);
            indicatorFB5.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorFB6.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 6);
            indicatorFB6.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB6.DisplayTag.Name);
            indicatorFB6.DataMapping.Add(true, Properties.Resources.Green);
            indicatorFB6.DataMapping.Add(false, Properties.Resources.Gray);

            indicatorFB7.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 7);
            indicatorFB7.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB7.DisplayTag.Name);
            indicatorFB7.DataMapping.Add(true, Properties.Resources.Green);
            indicatorFB7.DataMapping.Add(false, Properties.Resources.Gray);

            #region light error 0
            chkErrorD01.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.0", JunctionName, cardId);
            chkErrorD01.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD01.DisplayTag.Name);
            chkErrorD01.DataMapping.Add(true, true);
            chkErrorD01.DataMapping.Add(false, false);

            chkErrorD02.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.1", JunctionName, cardId);
            chkErrorD02.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD02.DisplayTag.Name);
            chkErrorD02.DataMapping.Add(true, true);
            chkErrorD02.DataMapping.Add(false, false);

            chkErrorD03.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.2", JunctionName, cardId);
            chkErrorD03.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD03.DisplayTag.Name);
            chkErrorD03.DataMapping.Add(true, true);
            chkErrorD03.DataMapping.Add(false, false);

            chkErrorD04.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.4", JunctionName, cardId);
            chkErrorD04.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD04.DisplayTag.Name);
            chkErrorD04.DataMapping.Add(true, true);
            chkErrorD04.DataMapping.Add(false, false);

            chkErrorD05.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.5", JunctionName, cardId);
            chkErrorD05.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD05.DisplayTag.Name);
            chkErrorD05.DataMapping.Add(true, true);
            chkErrorD05.DataMapping.Add(false, false);

            chkErrorD06.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.6", JunctionName, cardId);
            chkErrorD06.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD06.DisplayTag.Name);
            chkErrorD06.DataMapping.Add(true, true);
            chkErrorD06.DataMapping.Add(false, false);
            #endregion

            #region light error 1
            chkErrorD11.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.0", JunctionName, cardId);
            chkErrorD11.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD11.DisplayTag.Name);
            chkErrorD11.DataMapping.Add(true, true);
            chkErrorD11.DataMapping.Add(false, false);

            chkErrorD12.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.1", JunctionName, cardId);
            chkErrorD12.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD12.DisplayTag.Name);
            chkErrorD12.DataMapping.Add(true, true);
            chkErrorD12.DataMapping.Add(false, false);

            chkErrorD13.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.2", JunctionName, cardId);
            chkErrorD13.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD13.DisplayTag.Name);
            chkErrorD13.DataMapping.Add(true, true);
            chkErrorD13.DataMapping.Add(false, false);

            chkErrorD14.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.4", JunctionName, cardId);
            chkErrorD14.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD14.DisplayTag.Name);
            chkErrorD14.DataMapping.Add(true, true);
            chkErrorD14.DataMapping.Add(false, false);

            chkErrorD15.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.5", JunctionName, cardId);
            chkErrorD15.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD15.DisplayTag.Name);
            chkErrorD15.DataMapping.Add(true, true);
            chkErrorD15.DataMapping.Add(false, false);

            chkErrorD16.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.6", JunctionName, cardId);
            chkErrorD16.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD16.DisplayTag.Name);
            chkErrorD16.DataMapping.Add(true, true);
            chkErrorD16.DataMapping.Add(false, false);
            #endregion

            #region light error 2
            chkErrorD21.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.0", JunctionName, cardId);
            chkErrorD21.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD21.DisplayTag.Name);
            chkErrorD21.DataMapping.Add(true, true);
            chkErrorD21.DataMapping.Add(false, false);

            chkErrorD22.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.1", JunctionName, cardId);
            chkErrorD22.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD22.DisplayTag.Name);
            chkErrorD22.DataMapping.Add(true, true);
            chkErrorD22.DataMapping.Add(false, false);

            chkErrorD23.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.2", JunctionName, cardId);
            chkErrorD23.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD23.DisplayTag.Name);
            chkErrorD23.DataMapping.Add(true, true);
            chkErrorD23.DataMapping.Add(false, false);

            chkErrorD24.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.4", JunctionName, cardId);
            chkErrorD24.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD24.DisplayTag.Name);
            chkErrorD24.DataMapping.Add(true, true);
            chkErrorD24.DataMapping.Add(false, false);

            chkErrorD25.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.5", JunctionName, cardId);
            chkErrorD25.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD25.DisplayTag.Name);
            chkErrorD25.DataMapping.Add(true, true);
            chkErrorD25.DataMapping.Add(false, false);

            chkErrorD26.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.6", JunctionName, cardId);
            chkErrorD26.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD26.DisplayTag.Name);
            chkErrorD26.DataMapping.Add(true, true);
            chkErrorD26.DataMapping.Add(false, false);
            #endregion

            #region light error 3
            chkErrorD31.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.0", JunctionName, cardId);
            chkErrorD31.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD31.DisplayTag.Name);
            chkErrorD31.DataMapping.Add(true, true);
            chkErrorD31.DataMapping.Add(false, false);

            chkErrorD32.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.1", JunctionName, cardId);
            chkErrorD32.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD32.DisplayTag.Name);
            chkErrorD32.DataMapping.Add(true, true);
            chkErrorD32.DataMapping.Add(false, false);

            chkErrorD33.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.2", JunctionName, cardId);
            chkErrorD33.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD33.DisplayTag.Name);
            chkErrorD33.DataMapping.Add(true, true);
            chkErrorD33.DataMapping.Add(false, false);

            chkErrorD34.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.4", JunctionName, cardId);
            chkErrorD34.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD34.DisplayTag.Name);
            chkErrorD34.DataMapping.Add(true, true);
            chkErrorD34.DataMapping.Add(false, false);

            chkErrorD35.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.5", JunctionName, cardId);
            chkErrorD35.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD35.DisplayTag.Name);
            chkErrorD35.DataMapping.Add(true, true);
            chkErrorD35.DataMapping.Add(false, false);

            chkErrorD36.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.6", JunctionName, cardId);
            chkErrorD36.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD36.DisplayTag.Name);
            chkErrorD36.DataMapping.Add(true, true);
            chkErrorD36.DataMapping.Add(false, false);
            #endregion

            #region light error 4
            chkErrorD41.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.0", JunctionName, cardId);
            chkErrorD41.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD41.DisplayTag.Name);
            chkErrorD41.DataMapping.Add(true, true);
            chkErrorD41.DataMapping.Add(false, false);

            chkErrorD42.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.1", JunctionName, cardId);
            chkErrorD42.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD42.DisplayTag.Name);
            chkErrorD42.DataMapping.Add(true, true);
            chkErrorD42.DataMapping.Add(false, false);

            chkErrorD43.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.2", JunctionName, cardId);
            chkErrorD43.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD43.DisplayTag.Name);
            chkErrorD43.DataMapping.Add(true, true);
            chkErrorD43.DataMapping.Add(false, false);

            chkErrorD44.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.4", JunctionName, cardId);
            chkErrorD44.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD44.DisplayTag.Name);
            chkErrorD44.DataMapping.Add(true, true);
            chkErrorD44.DataMapping.Add(false, false);

            chkErrorD45.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.5", JunctionName, cardId);
            chkErrorD45.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD45.DisplayTag.Name);
            chkErrorD45.DataMapping.Add(true, true);
            chkErrorD45.DataMapping.Add(false, false);

            chkErrorD46.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.6", JunctionName, cardId);
            chkErrorD46.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD46.DisplayTag.Name);
            chkErrorD46.DataMapping.Add(true, true);
            chkErrorD46.DataMapping.Add(false, false);
            #endregion

            #region light error 5
            chkErrorD51.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.0", JunctionName, cardId);
            chkErrorD51.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD51.DisplayTag.Name);
            chkErrorD51.DataMapping.Add(true, true);
            chkErrorD51.DataMapping.Add(false, false);

            chkErrorD52.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.1", JunctionName, cardId);
            chkErrorD52.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD52.DisplayTag.Name);
            chkErrorD52.DataMapping.Add(true, true);
            chkErrorD52.DataMapping.Add(false, false);

            chkErrorD53.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.2", JunctionName, cardId);
            chkErrorD53.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD53.DisplayTag.Name);
            chkErrorD53.DataMapping.Add(true, true);
            chkErrorD53.DataMapping.Add(false, false);

            chkErrorD54.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.4", JunctionName, cardId);
            chkErrorD54.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD54.DisplayTag.Name);
            chkErrorD54.DataMapping.Add(true, true);
            chkErrorD54.DataMapping.Add(false, false);

            chkErrorD55.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.5", JunctionName, cardId);
            chkErrorD55.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD55.DisplayTag.Name);
            chkErrorD55.DataMapping.Add(true, true);
            chkErrorD55.DataMapping.Add(false, false);

            chkErrorD56.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.6", JunctionName, cardId);
            chkErrorD56.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD56.DisplayTag.Name);
            chkErrorD56.DataMapping.Add(true, true);
            chkErrorD56.DataMapping.Add(false, false);
            #endregion

            #region light error 6
            chkErrorD61.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.0", JunctionName, cardId);
            chkErrorD61.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD61.DisplayTag.Name);
            chkErrorD61.DataMapping.Add(true, true);
            chkErrorD61.DataMapping.Add(false, false);

            chkErrorD62.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.1", JunctionName, cardId);
            chkErrorD62.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD62.DisplayTag.Name);
            chkErrorD62.DataMapping.Add(true, true);
            chkErrorD62.DataMapping.Add(false, false);

            chkErrorD63.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.2", JunctionName, cardId);
            chkErrorD63.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD63.DisplayTag.Name);
            chkErrorD63.DataMapping.Add(true, true);
            chkErrorD63.DataMapping.Add(false, false);

            chkErrorD64.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.4", JunctionName, cardId);
            chkErrorD64.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD64.DisplayTag.Name);
            chkErrorD64.DataMapping.Add(true, true);
            chkErrorD64.DataMapping.Add(false, false);

            chkErrorD65.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.5", JunctionName, cardId);
            chkErrorD65.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD65.DisplayTag.Name);
            chkErrorD65.DataMapping.Add(true, true);
            chkErrorD65.DataMapping.Add(false, false);

            chkErrorD66.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.6", JunctionName, cardId);
            chkErrorD66.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD66.DisplayTag.Name);
            chkErrorD66.DataMapping.Add(true, true);
            chkErrorD66.DataMapping.Add(false, false);
            #endregion

            #region light error 7
            chkErrorD71.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.0", JunctionName, cardId);
            chkErrorD71.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD71.DisplayTag.Name);
            chkErrorD71.DataMapping.Add(true, true);
            chkErrorD71.DataMapping.Add(false, false);

            chkErrorD72.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.1", JunctionName, cardId);
            chkErrorD72.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD72.DisplayTag.Name);
            chkErrorD72.DataMapping.Add(true, true);
            chkErrorD72.DataMapping.Add(false, false);

            chkErrorD73.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.2", JunctionName, cardId);
            chkErrorD73.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD73.DisplayTag.Name);
            chkErrorD73.DataMapping.Add(true, true);
            chkErrorD73.DataMapping.Add(false, false);

            chkErrorD74.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.4", JunctionName, cardId);
            chkErrorD74.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD74.DisplayTag.Name);
            chkErrorD74.DataMapping.Add(true, true);
            chkErrorD74.DataMapping.Add(false, false);

            chkErrorD75.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.5", JunctionName, cardId);
            chkErrorD75.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD75.DisplayTag.Name);
            chkErrorD75.DataMapping.Add(true, true);
            chkErrorD75.DataMapping.Add(false, false);

            chkErrorD76.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.6", JunctionName, cardId);
            chkErrorD76.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD76.DisplayTag.Name);
            chkErrorD76.DataMapping.Add(true, true);
            chkErrorD76.DataMapping.Add(false, false);
            #endregion

            #region current

            numberCurrent0.DisplayTag.Name = string.Format("{0}.Current.{1}.0", JunctionName, cardId);
            numberCurrent0.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent0.DisplayTag.Name);

            numberCurrent1.DisplayTag.Name = string.Format("{0}.Current.{1}.1", JunctionName, cardId);
            numberCurrent1.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent1.DisplayTag.Name);

            numberCurrent2.DisplayTag.Name = string.Format("{0}.Current.{1}.2", JunctionName, cardId);
            numberCurrent2.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent2.DisplayTag.Name);

            numberCurrent3.DisplayTag.Name = string.Format("{0}.Current.{1}.3", JunctionName, cardId);
            numberCurrent3.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent3.DisplayTag.Name);

            numberCurrent4.DisplayTag.Name = string.Format("{0}.Current.{1}.4", JunctionName, cardId);
            numberCurrent4.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent4.DisplayTag.Name);

            numberCurrent5.DisplayTag.Name = string.Format("{0}.Current.{1}.5", JunctionName, cardId);
            numberCurrent5.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent5.DisplayTag.Name);

            numberCurrent6.DisplayTag.Name = string.Format("{0}.Current.{1}.6", JunctionName, cardId);
            numberCurrent6.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent6.DisplayTag.Name);

            numberCurrent7.DisplayTag.Name = string.Format("{0}.Current.{1}.7", JunctionName, cardId);
            numberCurrent7.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent7.DisplayTag.Name);

            numberThreshold0.DisplayTag.Name = string.Format("{0}.Threshold.{1}.0", JunctionName, cardId);
            numberThreshold0.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold0.DisplayTag.Name);

            numberThreshold1.DisplayTag.Name = string.Format("{0}.Threshold.{1}.1", JunctionName, cardId);
            numberThreshold1.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold1.DisplayTag.Name);

            numberThreshold2.DisplayTag.Name = string.Format("{0}.Threshold.{1}.2", JunctionName, cardId);
            numberThreshold2.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold2.DisplayTag.Name);

            numberThreshold3.DisplayTag.Name = string.Format("{0}.Threshold.{1}.3", JunctionName, cardId);
            numberThreshold3.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold3.DisplayTag.Name);

            numberThreshold4.DisplayTag.Name = string.Format("{0}.Threshold.{1}.4", JunctionName, cardId);
            numberThreshold4.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold4.DisplayTag.Name);

            numberThreshold5.DisplayTag.Name = string.Format("{0}.Threshold.{1}.5", JunctionName, cardId);
            numberThreshold5.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold5.DisplayTag.Name);

            numberThreshold6.DisplayTag.Name = string.Format("{0}.Threshold.{1}.6", JunctionName, cardId);
            numberThreshold6.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold6.DisplayTag.Name);

            numberThreshold7.DisplayTag.Name = string.Format("{0}.Threshold.{1}.7", JunctionName, cardId);
            numberThreshold7.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold7.DisplayTag.Name);
            #endregion

            _Page.AddTag(indicatorDK0.DisplayTag);
            _Page.AddTag(indicatorDK1.DisplayTag);
            _Page.AddTag(indicatorDK2.DisplayTag);
            _Page.AddTag(indicatorDK3.DisplayTag);
            _Page.AddTag(indicatorDK4.DisplayTag);
            _Page.AddTag(indicatorDK5.DisplayTag);
            _Page.AddTag(indicatorDK6.DisplayTag);
            _Page.AddTag(indicatorDK7.DisplayTag);
            _Page.AddTag(indicatorFB0.DisplayTag);
            _Page.AddTag(indicatorFB1.DisplayTag);
            _Page.AddTag(indicatorFB2.DisplayTag);
            _Page.AddTag(indicatorFB3.DisplayTag);
            _Page.AddTag(indicatorFB4.DisplayTag);
            _Page.AddTag(indicatorFB5.DisplayTag);
            _Page.AddTag(indicatorFB6.DisplayTag);
            _Page.AddTag(indicatorFB7.DisplayTag);

            _Page.AddTag(chkErrorD01.DisplayTag);
            _Page.AddTag(chkErrorD02.DisplayTag);
            _Page.AddTag(chkErrorD03.DisplayTag);
            _Page.AddTag(chkErrorD04.DisplayTag);
            _Page.AddTag(chkErrorD05.DisplayTag);
            _Page.AddTag(chkErrorD06.DisplayTag);

            _Page.AddTag(chkErrorD11.DisplayTag);
            _Page.AddTag(chkErrorD12.DisplayTag);
            _Page.AddTag(chkErrorD13.DisplayTag);
            _Page.AddTag(chkErrorD14.DisplayTag);
            _Page.AddTag(chkErrorD15.DisplayTag);
            _Page.AddTag(chkErrorD16.DisplayTag);

            _Page.AddTag(chkErrorD21.DisplayTag);
            _Page.AddTag(chkErrorD22.DisplayTag);
            _Page.AddTag(chkErrorD23.DisplayTag);
            _Page.AddTag(chkErrorD24.DisplayTag);
            _Page.AddTag(chkErrorD25.DisplayTag);
            _Page.AddTag(chkErrorD26.DisplayTag);

            _Page.AddTag(chkErrorD31.DisplayTag);
            _Page.AddTag(chkErrorD32.DisplayTag);
            _Page.AddTag(chkErrorD33.DisplayTag);
            _Page.AddTag(chkErrorD34.DisplayTag);
            _Page.AddTag(chkErrorD35.DisplayTag);
            _Page.AddTag(chkErrorD36.DisplayTag);

            _Page.AddTag(chkErrorD41.DisplayTag);
            _Page.AddTag(chkErrorD42.DisplayTag);
            _Page.AddTag(chkErrorD43.DisplayTag);
            _Page.AddTag(chkErrorD44.DisplayTag);
            _Page.AddTag(chkErrorD45.DisplayTag);
            _Page.AddTag(chkErrorD46.DisplayTag);

            _Page.AddTag(chkErrorD51.DisplayTag);
            _Page.AddTag(chkErrorD52.DisplayTag);
            _Page.AddTag(chkErrorD53.DisplayTag);
            _Page.AddTag(chkErrorD54.DisplayTag);
            _Page.AddTag(chkErrorD55.DisplayTag);
            _Page.AddTag(chkErrorD56.DisplayTag);

            _Page.AddTag(chkErrorD61.DisplayTag);
            _Page.AddTag(chkErrorD62.DisplayTag);
            _Page.AddTag(chkErrorD63.DisplayTag);
            _Page.AddTag(chkErrorD64.DisplayTag);
            _Page.AddTag(chkErrorD65.DisplayTag);
            _Page.AddTag(chkErrorD66.DisplayTag);

            _Page.AddTag(chkErrorD71.DisplayTag);
            _Page.AddTag(chkErrorD72.DisplayTag);
            _Page.AddTag(chkErrorD73.DisplayTag);
            _Page.AddTag(chkErrorD74.DisplayTag);
            _Page.AddTag(chkErrorD75.DisplayTag);
            _Page.AddTag(chkErrorD76.DisplayTag);

            _Page.AddTag(numberCurrent0.DisplayTag);
            _Page.AddTag(numberCurrent1.DisplayTag);
            _Page.AddTag(numberCurrent2.DisplayTag);
            _Page.AddTag(numberCurrent3.DisplayTag);
            _Page.AddTag(numberCurrent4.DisplayTag);
            _Page.AddTag(numberCurrent5.DisplayTag);
            _Page.AddTag(numberCurrent6.DisplayTag);
            _Page.AddTag(numberCurrent7.DisplayTag);

            _Page.AddTag(numberThreshold0.DisplayTag);
            _Page.AddTag(numberThreshold1.DisplayTag);
            _Page.AddTag(numberThreshold2.DisplayTag);
            _Page.AddTag(numberThreshold3.DisplayTag);
            _Page.AddTag(numberThreshold4.DisplayTag);
            _Page.AddTag(numberThreshold5.DisplayTag);
            _Page.AddTag(numberThreshold6.DisplayTag);
            _Page.AddTag(numberThreshold7.DisplayTag);

            Program.AddDisplayForm(this, new List<Display>() { _Page });
        }

        private void ChangeDisplayTagAddress(int cardId = 0)
        {
            indicatorDK0.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 0);
            indicatorDK0.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK0.DisplayTag.Name);

            indicatorDK1.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 1);
            indicatorDK1.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK1.DisplayTag.Name);

            indicatorDK2.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 2);
            indicatorDK2.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK2.DisplayTag.Name);

            indicatorDK3.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 3);
            indicatorDK3.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK3.DisplayTag.Name);

            indicatorDK4.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 4);
            indicatorDK4.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK4.DisplayTag.Name);

            indicatorDK5.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 5);
            indicatorDK5.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK5.DisplayTag.Name);

            indicatorDK6.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 6);
            indicatorDK6.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK6.DisplayTag.Name);

            indicatorDK7.DisplayTag.Name = string.Format("{0}.OutputControl.{1}.{2}", JunctionName, cardId, 7);
            indicatorDK7.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorDK7.DisplayTag.Name);

            indicatorFB0.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 0);
            indicatorFB0.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB0.DisplayTag.Name);

            indicatorFB1.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 1);
            indicatorFB1.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB1.DisplayTag.Name);

            indicatorFB2.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 2);
            indicatorFB2.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB2.DisplayTag.Name);

            indicatorFB3.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 3);
            indicatorFB3.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB3.DisplayTag.Name);

            indicatorFB4.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 4);
            indicatorFB4.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB4.DisplayTag.Name);

            indicatorFB5.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 5);
            indicatorFB5.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB5.DisplayTag.Name);

            indicatorFB6.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 6);
            indicatorFB6.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB6.DisplayTag.Name);

            indicatorFB7.DisplayTag.Name = string.Format("{0}.OutputFeedback.{1}.{2}", JunctionName, cardId, 7);
            indicatorFB7.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorFB7.DisplayTag.Name);

            #region light error 0
            chkErrorD01.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.0", JunctionName, cardId);
            chkErrorD01.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD01.DisplayTag.Name);

            chkErrorD02.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.1", JunctionName, cardId);
            chkErrorD02.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD02.DisplayTag.Name);

            chkErrorD03.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.2", JunctionName, cardId);
            chkErrorD03.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD03.DisplayTag.Name);

            chkErrorD04.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.4", JunctionName, cardId);
            chkErrorD04.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD04.DisplayTag.Name);

            chkErrorD05.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.5", JunctionName, cardId);
            chkErrorD05.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD05.DisplayTag.Name);

            chkErrorD06.DisplayTag.Name = string.Format("{0}.LightError.{1}.0.6", JunctionName, cardId);
            chkErrorD06.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD06.DisplayTag.Name);
            #endregion

            #region light error 1
            chkErrorD11.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.0", JunctionName, cardId);
            chkErrorD11.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD11.DisplayTag.Name);

            chkErrorD12.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.1", JunctionName, cardId);
            chkErrorD12.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD12.DisplayTag.Name);

            chkErrorD13.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.2", JunctionName, cardId);
            chkErrorD13.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD13.DisplayTag.Name);

            chkErrorD14.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.4", JunctionName, cardId);
            chkErrorD14.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD14.DisplayTag.Name);

            chkErrorD15.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.5", JunctionName, cardId);
            chkErrorD15.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD15.DisplayTag.Name);

            chkErrorD16.DisplayTag.Name = string.Format("{0}.LightError.{1}.1.6", JunctionName, cardId);
            chkErrorD16.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD16.DisplayTag.Name);
            #endregion

            #region light error 2
            chkErrorD21.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.0", JunctionName, cardId);
            chkErrorD21.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD21.DisplayTag.Name);

            chkErrorD22.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.1", JunctionName, cardId);
            chkErrorD22.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD22.DisplayTag.Name);

            chkErrorD23.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.2", JunctionName, cardId);
            chkErrorD23.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD23.DisplayTag.Name);

            chkErrorD24.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.4", JunctionName, cardId);
            chkErrorD24.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD24.DisplayTag.Name);

            chkErrorD25.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.5", JunctionName, cardId);
            chkErrorD25.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD25.DisplayTag.Name);

            chkErrorD26.DisplayTag.Name = string.Format("{0}.LightError.{1}.2.6", JunctionName, cardId);
            chkErrorD26.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD26.DisplayTag.Name);
            #endregion

            #region light error 3
            chkErrorD31.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.0", JunctionName, cardId);
            chkErrorD31.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD31.DisplayTag.Name);

            chkErrorD32.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.1", JunctionName, cardId);
            chkErrorD32.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD32.DisplayTag.Name);

            chkErrorD33.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.2", JunctionName, cardId);
            chkErrorD33.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD33.DisplayTag.Name);

            chkErrorD34.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.4", JunctionName, cardId);
            chkErrorD34.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD34.DisplayTag.Name);

            chkErrorD35.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.5", JunctionName, cardId);
            chkErrorD35.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD35.DisplayTag.Name);

            chkErrorD36.DisplayTag.Name = string.Format("{0}.LightError.{1}.3.6", JunctionName, cardId);
            chkErrorD36.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD36.DisplayTag.Name);
            #endregion

            #region light error 4
            chkErrorD41.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.0", JunctionName, cardId);
            chkErrorD41.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD41.DisplayTag.Name);

            chkErrorD42.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.1", JunctionName, cardId);
            chkErrorD42.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD42.DisplayTag.Name);

            chkErrorD43.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.2", JunctionName, cardId);
            chkErrorD43.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD43.DisplayTag.Name);

            chkErrorD44.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.4", JunctionName, cardId);
            chkErrorD44.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD44.DisplayTag.Name);

            chkErrorD45.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.5", JunctionName, cardId);
            chkErrorD45.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD45.DisplayTag.Name);

            chkErrorD46.DisplayTag.Name = string.Format("{0}.LightError.{1}.4.6", JunctionName, cardId);
            chkErrorD46.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD46.DisplayTag.Name);
            #endregion

            #region light error 5
            chkErrorD51.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.0", JunctionName, cardId);
            chkErrorD51.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD51.DisplayTag.Name);

            chkErrorD52.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.1", JunctionName, cardId);
            chkErrorD52.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD52.DisplayTag.Name);

            chkErrorD53.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.2", JunctionName, cardId);
            chkErrorD53.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD53.DisplayTag.Name);

            chkErrorD54.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.4", JunctionName, cardId);
            chkErrorD54.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD54.DisplayTag.Name);

            chkErrorD55.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.5", JunctionName, cardId);
            chkErrorD55.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD55.DisplayTag.Name);

            chkErrorD56.DisplayTag.Name = string.Format("{0}.LightError.{1}.5.6", JunctionName, cardId);
            chkErrorD56.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD56.DisplayTag.Name);
            #endregion

            #region light error 6
            chkErrorD61.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.0", JunctionName, cardId);
            chkErrorD61.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD61.DisplayTag.Name);

            chkErrorD62.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.1", JunctionName, cardId);
            chkErrorD62.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD62.DisplayTag.Name);

            chkErrorD63.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.2", JunctionName, cardId);
            chkErrorD63.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD63.DisplayTag.Name);

            chkErrorD64.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.4", JunctionName, cardId);
            chkErrorD64.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD64.DisplayTag.Name);

            chkErrorD65.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.5", JunctionName, cardId);
            chkErrorD65.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD65.DisplayTag.Name);

            chkErrorD66.DisplayTag.Name = string.Format("{0}.LightError.{1}.6.6", JunctionName, cardId);
            chkErrorD66.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD66.DisplayTag.Name);

            #endregion

            #region light error 7
            chkErrorD71.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.0", JunctionName, cardId);
            chkErrorD71.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD71.DisplayTag.Name);

            chkErrorD72.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.1", JunctionName, cardId);
            chkErrorD72.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD72.DisplayTag.Name);

            chkErrorD73.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.2", JunctionName, cardId);
            chkErrorD73.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD73.DisplayTag.Name);

            chkErrorD74.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.4", JunctionName, cardId);
            chkErrorD74.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD74.DisplayTag.Name);

            chkErrorD75.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.5", JunctionName, cardId);
            chkErrorD75.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD75.DisplayTag.Name);

            chkErrorD76.DisplayTag.Name = string.Format("{0}.LightError.{1}.7.6", JunctionName, cardId);
            chkErrorD76.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorD76.DisplayTag.Name);
            #endregion

            #region current

            numberCurrent0.DisplayTag.Name = string.Format("{0}.Current.{1}.0", JunctionName, cardId);
            numberCurrent0.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent0.DisplayTag.Name);

            numberCurrent1.DisplayTag.Name = string.Format("{0}.Current.{1}.1", JunctionName, cardId);
            numberCurrent1.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent1.DisplayTag.Name);

            numberCurrent2.DisplayTag.Name = string.Format("{0}.Current.{1}.2", JunctionName, cardId);
            numberCurrent2.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent2.DisplayTag.Name);

            numberCurrent3.DisplayTag.Name = string.Format("{0}.Current.{1}.3", JunctionName, cardId);
            numberCurrent3.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent3.DisplayTag.Name);

            numberCurrent4.DisplayTag.Name = string.Format("{0}.Current.{1}.4", JunctionName, cardId);
            numberCurrent4.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent4.DisplayTag.Name);

            numberCurrent5.DisplayTag.Name = string.Format("{0}.Current.{1}.5", JunctionName, cardId);
            numberCurrent5.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent5.DisplayTag.Name);

            numberCurrent6.DisplayTag.Name = string.Format("{0}.Current.{1}.6", JunctionName, cardId);
            numberCurrent6.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent6.DisplayTag.Name);

            numberCurrent7.DisplayTag.Name = string.Format("{0}.Current.{1}.7", JunctionName, cardId);
            numberCurrent7.DisplayTag.Address = Program.GetDisplayTagAddress(numberCurrent7.DisplayTag.Name);

            numberThreshold0.DisplayTag.Name = string.Format("{0}.Threshold.{1}.0", JunctionName, cardId);
            numberThreshold0.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold0.DisplayTag.Name);

            numberThreshold1.DisplayTag.Name = string.Format("{0}.Threshold.{1}.1", JunctionName, cardId);
            numberThreshold1.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold1.DisplayTag.Name);

            numberThreshold2.DisplayTag.Name = string.Format("{0}.Threshold.{1}.2", JunctionName, cardId);
            numberThreshold2.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold2.DisplayTag.Name);

            numberThreshold3.DisplayTag.Name = string.Format("{0}.Threshold.{1}.3", JunctionName, cardId);
            numberThreshold3.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold3.DisplayTag.Name);

            numberThreshold4.DisplayTag.Name = string.Format("{0}.Threshold.{1}.4", JunctionName, cardId);
            numberThreshold4.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold4.DisplayTag.Name);

            numberThreshold5.DisplayTag.Name = string.Format("{0}.Threshold.{1}.5", JunctionName, cardId);
            numberThreshold5.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold5.DisplayTag.Name);

            numberThreshold6.DisplayTag.Name = string.Format("{0}.Threshold.{1}.6", JunctionName, cardId);
            numberThreshold6.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold6.DisplayTag.Name);

            numberThreshold7.DisplayTag.Name = string.Format("{0}.Threshold.{1}.7", JunctionName, cardId);
            numberThreshold7.DisplayTag.Address = Program.GetDisplayTagAddress(numberThreshold7.DisplayTag.Name);
            #endregion
        }

        private void FrmVDKLight_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  Program.RemoveDisplayForm(this);
        }

        public void StopUpdating()
        {
            Program.RemoveDisplayForm(this);
        }


    }
}

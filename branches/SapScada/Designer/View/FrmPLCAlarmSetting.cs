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
    public partial class FrmPLCAlarmSetting : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }

        public FrmPLCAlarmSetting()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            JunctionName = DesignerAccess.GetJunction(JunctionName).DeviceName;
            this.Enter += FrmPLCAlarmSetting_Enter;
        }

        private void FrmPLCAlarmSetting_Enter(object sender, EventArgs e)
        {
            this.Enter -= FrmPLCAlarmSetting_Enter;
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
            Display page = new Display(500);

            chkErrorXA.DisplayTag.Name = string.Format("{0}.OP_E_XA", JunctionName);
            chkErrorXA.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorXA.DisplayTag.Name);
            chkErrorXA.DataMapping.Add(true, true);
            chkErrorXA.DataMapping.Add(false, false);

            chkErrorXB.DisplayTag.Name = string.Format("{0}.OP_E_XB", JunctionName);
            chkErrorXB.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorXB.DisplayTag.Name);
            chkErrorXB.DataMapping.Add(true, true);
            chkErrorXB.DataMapping.Add(false, false);

            chkErrorVA.DisplayTag.Name = string.Format("{0}.OP_E_VA", JunctionName);
            chkErrorVA.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorVA.DisplayTag.Name);
            chkErrorVA.DataMapping.Add(true, true);
            chkErrorVA.DataMapping.Add(false, false);

            chkErrorVB.DisplayTag.Name = string.Format("{0}.OP_E_VB", JunctionName);
            chkErrorVB.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorVB.DisplayTag.Name);
            chkErrorVB.DataMapping.Add(true, true);
            chkErrorVB.DataMapping.Add(false, false);

            chkErrorDA.DisplayTag.Name = string.Format("{0}.OP_E_DA", JunctionName);
            chkErrorDA.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorDA.DisplayTag.Name);
            chkErrorDA.DataMapping.Add(true, true);
            chkErrorDA.DataMapping.Add(false, false);

            chkErrorDB.DisplayTag.Name = string.Format("{0}.OP_E_DB", JunctionName);
            chkErrorDB.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorDB.DisplayTag.Name);
            chkErrorDB.DataMapping.Add(true, true);
            chkErrorDB.DataMapping.Add(false, false);

            chkErrorA.DisplayTag.Name = string.Format("{0}.OP_E_CDA", JunctionName);
            chkErrorA.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorA.DisplayTag.Name);
            chkErrorA.DataMapping.Add(true, true);
            chkErrorA.DataMapping.Add(false, false);

            chkErrorB.DisplayTag.Name = string.Format("{0}.OP_E_CDB", JunctionName);
            chkErrorB.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorB.DisplayTag.Name);
            chkErrorB.DataMapping.Add(true, true);
            chkErrorB.DataMapping.Add(false, false);

            chkErrorSensorA.DisplayTag.Name = string.Format("{0}.OP_E_CTA", JunctionName);
            chkErrorSensorA.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorSensorA.DisplayTag.Name);
            chkErrorSensorA.DataMapping.Add(true, true);
            chkErrorSensorA.DataMapping.Add(false, false);

            chkErrorSensorB.DisplayTag.Name = string.Format("{0}.OP_E_CTB", JunctionName);
            chkErrorSensorB.DisplayTag.Address = Program.GetDisplayTagAddress(chkErrorSensorB.DisplayTag.Name);
            chkErrorSensorB.DataMapping.Add(true, true);
            chkErrorSensorB.DataMapping.Add(false, false);

            HDSComponent.UI.HDDataSource textSource = new HDSComponent.UI.HDDataSource();
            textSource.DisplayTag.Name = string.Format("{0}.XA_Q", JunctionName);
            textSource.DisplayTag.Address = Program.GetDisplayTagAddress(textSource.DisplayTag.Name);
            Dictionary<object, object> dataMapping = new Dictionary<object, object>();
            dataMapping.Add(false, "0");
            dataMapping.Add(true, "1");
            textSource.BindTo(txtControlXA, "Text", dataMapping);

            HDSComponent.UI.HDDataSource textSource1 = new HDSComponent.UI.HDDataSource();
            textSource1.DisplayTag.Name = string.Format("{0}.VA_Q", JunctionName);
            textSource1.DisplayTag.Address = Program.GetDisplayTagAddress(textSource1.DisplayTag.Name);
            Dictionary<object, object> dataMapping1 = new Dictionary<object, object>();
            dataMapping1.Add(false, "0");
            dataMapping1.Add(true, "1");
            textSource1.BindTo(txtControlVA, "Text", dataMapping1);

            HDSComponent.UI.HDDataSource textSource2 = new HDSComponent.UI.HDDataSource();
            textSource2.DisplayTag.Name = string.Format("{0}.DA_Q", JunctionName);
            textSource2.DisplayTag.Address = Program.GetDisplayTagAddress(textSource2.DisplayTag.Name);
            Dictionary<object, object> dataMapping2 = new Dictionary<object, object>();
            dataMapping2.Add(false, "0");
            dataMapping2.Add(true, "1");
            textSource2.BindTo(txtControlDA, "Text", dataMapping2);

            HDSComponent.UI.HDDataSource textSource3 = new HDSComponent.UI.HDDataSource();
            textSource3.DisplayTag.Name = string.Format("{0}.XB_Q", JunctionName);
            textSource3.DisplayTag.Address = Program.GetDisplayTagAddress(textSource3.DisplayTag.Name);
            Dictionary<object, object> dataMapping3 = new Dictionary<object, object>();
            dataMapping3.Add(false, "0");
            dataMapping3.Add(true, "1");
            textSource3.BindTo(txtControlXB, "Text", dataMapping3);

            HDSComponent.UI.HDDataSource textSource4 = new HDSComponent.UI.HDDataSource();
            textSource4.DisplayTag.Name = string.Format("{0}.VB_Q", JunctionName);
            textSource4.DisplayTag.Address = Program.GetDisplayTagAddress(textSource4.DisplayTag.Name);
            Dictionary<object, object> dataMapping4 = new Dictionary<object, object>();
            dataMapping4.Add(false, "0");
            dataMapping4.Add(true, "1");
            textSource4.BindTo(txtControlVB, "Text", dataMapping4);

            HDSComponent.UI.HDDataSource textSource5 = new HDSComponent.UI.HDDataSource();
            textSource5.DisplayTag.Name = string.Format("{0}.DB_Q", JunctionName);
            textSource5.DisplayTag.Address = Program.GetDisplayTagAddress(textSource5.DisplayTag.Name);
            Dictionary<object, object> dataMapping5 = new Dictionary<object, object>();
            dataMapping5.Add(false, "0");
            dataMapping5.Add(true, "1");
            textSource5.BindTo(txtControlDB, "Text", dataMapping5);

            HDSComponent.UI.HDDataSource textSource6 = new HDSComponent.UI.HDDataSource();
            textSource6.DisplayTag.Name = string.Format("{0}.XA_FB", JunctionName);
            textSource6.DisplayTag.Address = Program.GetDisplayTagAddress(textSource6.DisplayTag.Name);
            Dictionary<object, object> dataMapping6 = new Dictionary<object, object>();
            dataMapping6.Add(false, "0");
            dataMapping6.Add(true, "1");
            textSource6.BindTo(txtFeedbackXA, "Text", dataMapping6);

            HDSComponent.UI.HDDataSource textSource7 = new HDSComponent.UI.HDDataSource();
            textSource7.DisplayTag.Name = string.Format("{0}.VA_FB", JunctionName);
            textSource7.DisplayTag.Address = Program.GetDisplayTagAddress(textSource7.DisplayTag.Name);
            Dictionary<object, object> dataMapping7 = new Dictionary<object, object>();
            dataMapping7.Add(false, "0");
            dataMapping7.Add(true, "1");
            textSource7.BindTo(txtFeedbackVA, "Text", dataMapping7);

            HDSComponent.UI.HDDataSource textSource8 = new HDSComponent.UI.HDDataSource();
            textSource8.DisplayTag.Name = string.Format("{0}.DA_FB", JunctionName);
            textSource8.DisplayTag.Address = Program.GetDisplayTagAddress(textSource8.DisplayTag.Name);
            Dictionary<object, object> dataMapping8 = new Dictionary<object, object>();
            dataMapping8.Add(false, "0");
            dataMapping8.Add(true, "1");
            textSource8.BindTo(txtFeedbackDA, "Text", dataMapping8);

            HDSComponent.UI.HDDataSource textSource9 = new HDSComponent.UI.HDDataSource();
            textSource9.DisplayTag.Name = string.Format("{0}.XB_FB", JunctionName);
            textSource9.DisplayTag.Address = Program.GetDisplayTagAddress(textSource9.DisplayTag.Name);
            Dictionary<object, object> dataMapping9 = new Dictionary<object, object>();
            dataMapping9.Add(false, "0");
            dataMapping9.Add(true, "1");
            textSource9.BindTo(txtFeedbackXB, "Text", dataMapping9);

            HDSComponent.UI.HDDataSource textSource10 = new HDSComponent.UI.HDDataSource();
            textSource10.DisplayTag.Name = string.Format("{0}.VB_FB", JunctionName);
            textSource10.DisplayTag.Address = Program.GetDisplayTagAddress(textSource10.DisplayTag.Name);
            Dictionary<object, object> dataMapping10 = new Dictionary<object, object>();
            dataMapping10.Add(false, "0");
            dataMapping10.Add(true, "1");
            textSource10.BindTo(txtFeedbackVB, "Text", dataMapping10);

            HDSComponent.UI.HDDataSource textSource11 = new HDSComponent.UI.HDDataSource();
            textSource11.DisplayTag.Name = string.Format("{0}.DB_FB", JunctionName);
            textSource11.DisplayTag.Address = Program.GetDisplayTagAddress(textSource11.DisplayTag.Name);
            Dictionary<object, object> dataMapping11 = new Dictionary<object, object>();
            dataMapping11.Add(false, "0");
            dataMapping11.Add(true, "1");
            textSource11.BindTo(txtFeedbackDB, "Text", dataMapping11);

            cbbxErrorX.DisplayTag.Name = string.Format("{0}.AC_MAT_X", JunctionName);
            cbbxErrorX.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxErrorX.DisplayTag.Name);
            cbbxErrorX.DataMapping.Add(1, 0);
            cbbxErrorX.DataMapping.Add(2, 1);
            cbbxErrorX.DataMapping.Add(3, 2);

            cbbxErrorV.DisplayTag.Name = string.Format("{0}.AC_MAT_V", JunctionName);
            cbbxErrorV.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxErrorV.DisplayTag.Name);
            cbbxErrorV.DataMapping.Add(1, 0);
            cbbxErrorV.DataMapping.Add(2, 1);
            cbbxErrorV.DataMapping.Add(3, 2);

            cbbxErrorD.DisplayTag.Name = string.Format("{0}.AC_MAT_D", JunctionName);
            cbbxErrorD.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxErrorD.DisplayTag.Name);
            cbbxErrorD.DataMapping.Add(1, 0);
            cbbxErrorD.DataMapping.Add(2, 1);
            cbbxErrorD.DataMapping.Add(3, 2);

            cbbxErrorDuplicate.DisplayTag.Name = string.Format("{0}.AC_CD", JunctionName);
            cbbxErrorDuplicate.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxErrorDuplicate.DisplayTag.Name);
            cbbxErrorDuplicate.DataMapping.Add(1, 0);
            cbbxErrorDuplicate.DataMapping.Add(2, 1);
            cbbxErrorDuplicate.DataMapping.Add(3, 2);

            cbbxErrorSensor.DisplayTag.Name = string.Format("{0}.AC_CT", JunctionName);
            cbbxErrorSensor.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxErrorSensor.DisplayTag.Name);
            cbbxErrorSensor.DataMapping.Add(1, 0);
            cbbxErrorSensor.DataMapping.Add(2, 1);
            cbbxErrorSensor.DataMapping.Add(3, 2);

            numberGreenFlashA.DisplayTag.Name = string.Format("{0}.F_XBA", JunctionName);
            numberGreenFlashA.DisplayTag.Address = Program.GetDisplayTagAddress(numberGreenFlashA.DisplayTag.Name);

            numberGreenFlashB.DisplayTag.Name = string.Format("{0}.F_XBB", JunctionName);
            numberGreenFlashB.DisplayTag.Address = Program.GetDisplayTagAddress(numberGreenFlashB.DisplayTag.Name);

            numberRedA.DisplayTag.Name = string.Format("{0}.O_XBA", JunctionName);
            numberRedA.DisplayTag.Address = Program.GetDisplayTagAddress(numberRedA.DisplayTag.Name);

            numberRedB.DisplayTag.Name = string.Format("{0}.O_XBB", JunctionName);
            numberRedB.DisplayTag.Address = Program.GetDisplayTagAddress(numberRedB.DisplayTag.Name);

            page.AddTag(chkErrorXA.DisplayTag);
            page.AddTag(chkErrorVA.DisplayTag);
            page.AddTag(chkErrorDA.DisplayTag);
            page.AddTag(chkErrorXB.DisplayTag);
            page.AddTag(chkErrorVB.DisplayTag);
            page.AddTag(chkErrorDB.DisplayTag);
            page.AddTag(chkErrorA.DisplayTag);
            page.AddTag(chkErrorB.DisplayTag);
            page.AddTag(chkErrorSensorA.DisplayTag);
            page.AddTag(chkErrorSensorB.DisplayTag);
            //page.AddTag(txtControlXA.DisplayTag);
            //page.AddTag(txtControlVA.DisplayTag);
            //page.AddTag(txtControlDA.DisplayTag);
            //page.AddTag(txtControlXB.DisplayTag);
            //page.AddTag(txtControlVB.DisplayTag);
            //page.AddTag(txtControlDB.DisplayTag);
            //page.AddTag(txtFeedbackXA.DisplayTag);
            //page.AddTag(txtFeedbackVA.DisplayTag);
            //page.AddTag(txtFeedbackDA.DisplayTag);
            //page.AddTag(txtFeedbackXB.DisplayTag);
            //page.AddTag(txtFeedbackVB.DisplayTag);
            //page.AddTag(txtFeedbackDB.DisplayTag);

            page.AddTag(textSource.DisplayTag);
            page.AddTag(textSource1.DisplayTag);
            page.AddTag(textSource2.DisplayTag);
            page.AddTag(textSource3.DisplayTag);
            page.AddTag(textSource4.DisplayTag);
            page.AddTag(textSource5.DisplayTag);
            page.AddTag(textSource6.DisplayTag);
            page.AddTag(textSource7.DisplayTag);
            page.AddTag(textSource8.DisplayTag);
            page.AddTag(textSource9.DisplayTag);
            page.AddTag(textSource10.DisplayTag);
            page.AddTag(textSource11.DisplayTag);

            page.AddTag(cbbxErrorX.DisplayTag);
            page.AddTag(cbbxErrorV.DisplayTag);
            page.AddTag(cbbxErrorD.DisplayTag);
            page.AddTag(cbbxErrorDuplicate.DisplayTag);
            page.AddTag(cbbxErrorSensor.DisplayTag);
            page.AddTag(numberGreenFlashA.DisplayTag);
            page.AddTag(numberGreenFlashB.DisplayTag);
            page.AddTag(numberRedA.DisplayTag);
            page.AddTag(numberRedB.DisplayTag);

            Program.AddDisplayForm(this, new List<Display>() { page });
        }

        private void FrmPLCAlarmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.RemoveDisplayForm(this);
        }

    }
}

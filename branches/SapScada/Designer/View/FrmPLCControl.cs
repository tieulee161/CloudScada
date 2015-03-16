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
    public partial class FrmPLCControl : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName;

        public FrmPLCControl()
        {
            InitializeComponent();
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
            Display page = new Display(500);

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

            HDSComponent.UI.HDDataSource textSource = new HDSComponent.UI.HDDataSource();
            textSource.DisplayTag.Name = string.Format("{0}.MAN", JunctionName);
            textSource.DisplayTag.Address = Program.GetDisplayTagAddress(textSource.DisplayTag.Name);
            Dictionary<object, object> dataMapping = new Dictionary<object, object>();
            dataMapping.Add(false, "Tự động");
            dataMapping.Add(true, "Cài đặt tay");
            textSource.BindTo(txtSetting, "Text", dataMapping);

            HDSComponent.UI.HDDataSource textSource1 = new HDSComponent.UI.HDDataSource();
            textSource1.DisplayTag.Name = string.Format("{0}.MODE", JunctionName);
            textSource1.DisplayTag.Address = Program.GetDisplayTagAddress(textSource1.DisplayTag.Name);
            Dictionary<object, object> dataMapping1 = new Dictionary<object, object>();
            dataMapping1.Add(1, "Thông số");
            dataMapping1.Add(2, "Chớp vàng");
            dataMapping1.Add(3, "Làn sóng xanh");
            dataMapping1.Add(4, "Tắt tủ");
            textSource1.BindTo(txtControlMode, "Text", dataMapping1);

            HDSComponent.UI.HDDataSource textSource2 = new HDSComponent.UI.HDDataSource();
            textSource2.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            textSource2.DisplayTag.Address = Program.GetDisplayTagAddress(textSource2.DisplayTag.Name);
            Dictionary<object, object> dataMapping2 = new Dictionary<object, object>();
            dataMapping2.Add(177, "Ngày bình thường");
            dataMapping2.Add(182, "Ngày bình thường");
            dataMapping2.Add(187, "Ngày bình thường");
            dataMapping2.Add(192, "Ngày bình thường");
            dataMapping2.Add(297, "Ngày bình thường");
            dataMapping2.Add(202, "Ngày bình thường");
            dataMapping2.Add(207, "Ngày bình thường");
            dataMapping2.Add(212, "Ngày đặc biệt");
            dataMapping2.Add(217, "Ngày đặc biệt");
            dataMapping2.Add(222, "Ngày đặc biệt");
            dataMapping2.Add(227, "Ngày đặc biệt");
            dataMapping2.Add(232, "Ngày đặc biệt");
            dataMapping2.Add(237, "Ngày đặc biệt");
            dataMapping2.Add(242, "Ngày đặc biệt");
            textSource2.BindTo(txtControlDateType, "Text", dataMapping2);

            HDSComponent.UI.HDDataSource textSource3 = new HDSComponent.UI.HDDataSource();
            textSource3.DisplayTag.Name = string.Format("{0}.DB_A", JunctionName);
            textSource3.DisplayTag.Address = Program.GetDisplayTagAddress(textSource3.DisplayTag.Name);
            Dictionary<object, object> dataMapping3 = new Dictionary<object, object>();
            dataMapping3.Add(false, "Theo tuyến B");
            dataMapping3.Add(true, "Theo tuyến A");
            textSource3.BindTo(txtGreenWaveDirection, "Text", dataMapping3);

            HDSComponent.UI.HDDataSource textSource4 = new HDSComponent.UI.HDDataSource();
            textSource4.DisplayTag.Name = string.Format("{0}.ERR", JunctionName);
            textSource4.DisplayTag.Address = Program.GetDisplayTagAddress(textSource4.DisplayTag.Name);
            Dictionary<object, object> dataMapping4 = new Dictionary<object, object>();
            dataMapping4.Add(false, "Bình thường");
            dataMapping4.Add(true, "Lỗi");
            textSource4.BindTo(txtControlError, "Text", dataMapping4);
            Dictionary<object, object> dataMapping4_1 = new Dictionary<object, object>();
            textSource4.BindTo(txtErrorInfo, "Visible", dataMapping4_1);
            textSource4.BindTo(btnResetError, "Visible", dataMapping4_1);

            btnResetError.DisplayTag.Name = string.Format("{0}.ERR_CODE", JunctionName);
            btnResetError.DisplayTag.Address = Program.GetDisplayTagAddress(btnResetError.DisplayTag.Name);
            btnResetError.Click += btnResetError_Click;

            HDSComponent.UI.HDDataSource textSource5 = new HDSComponent.UI.HDDataSource();
            textSource5.DisplayTag.Name = string.Format("{0}.ERR_CODE", JunctionName);
            textSource5.DisplayTag.Address = Program.GetDisplayTagAddress(textSource5.DisplayTag.Name);
            Dictionary<object, object> dataMapping6 = new Dictionary<object, object>();
            dataMapping6.Add(0, "Không lỗi");
            dataMapping6.Add(1, "Mất xanh A");
            dataMapping6.Add(2, "Mất vàng A");
            dataMapping6.Add(3, "Mất đỏ A");
            dataMapping6.Add(4, "Chồng đèn tuyến A");
            dataMapping6.Add(5, "Lỗi cảm biến tuyến A");
            dataMapping6.Add(6, "Mất xanh B");
            dataMapping6.Add(7, "Mất vàng B");
            dataMapping6.Add(8, "Mất đỏ B");
            dataMapping6.Add(9, "Chồng đèn tuyến B");
            dataMapping6.Add(10, "Lỗi cảm biến tuyến B");
            textSource5.BindTo(txtErrorInfo, "Text", dataMapping6);

            indicatorPar1.DisplayTag.Name = string.Format("{0}.MOV_P1", JunctionName);
            indicatorPar1.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPar1.DisplayTag.Name);
            indicatorPar1.DataMapping.Add(true, Properties.Resources.Connect);

            indicatorPar2.DisplayTag.Name = string.Format("{0}.MOV_P2", JunctionName);
            indicatorPar2.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPar2.DisplayTag.Name);
            indicatorPar2.DataMapping.Add(true, Properties.Resources.Connect);

            indicatorPar3.DisplayTag.Name = string.Format("{0}.MOV_P3", JunctionName);
            indicatorPar3.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPar3.DisplayTag.Name);
            indicatorPar3.DataMapping.Add(true, Properties.Resources.Connect);

            indicatorPar4.DisplayTag.Name = string.Format("{0}.MOV_P4", JunctionName);
            indicatorPar4.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPar4.DisplayTag.Name);
            indicatorPar4.DataMapping.Add(true, Properties.Resources.Connect);

            indicatorPeriod1.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            indicatorPeriod1.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPeriod1.DisplayTag.Name);
            indicatorPeriod1.DataMapping.Add(177, Properties.Resources.Connect);
            indicatorPeriod1.DataMapping.Add(212, Properties.Resources.Connect);

            indicatorPeriod2.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            indicatorPeriod2.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPeriod2.DisplayTag.Name);
            indicatorPeriod2.DataMapping.Add(182, Properties.Resources.Connect);
            indicatorPeriod2.DataMapping.Add(217, Properties.Resources.Connect);

            indicatorPeriod3.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            indicatorPeriod3.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPeriod3.DisplayTag.Name);
            indicatorPeriod3.DataMapping.Add(187, Properties.Resources.Connect);
            indicatorPeriod3.DataMapping.Add(222, Properties.Resources.Connect);

            indicatorPeriod4.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            indicatorPeriod4.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPeriod4.DisplayTag.Name);
            indicatorPeriod4.DataMapping.Add(192, Properties.Resources.Connect);
            indicatorPeriod4.DataMapping.Add(227, Properties.Resources.Connect);

            indicatorPeriod5.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            indicatorPeriod5.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPeriod5.DisplayTag.Name);
            indicatorPeriod5.DataMapping.Add(197, Properties.Resources.Connect);
            indicatorPeriod5.DataMapping.Add(232, Properties.Resources.Connect);

            indicatorPeriod6.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            indicatorPeriod6.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPeriod6.DisplayTag.Name);
            indicatorPeriod6.DataMapping.Add(202, Properties.Resources.Connect);
            indicatorPeriod6.DataMapping.Add(237, Properties.Resources.Connect);

            indicatorPeriod7.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            indicatorPeriod7.DisplayTag.Address = Program.GetDisplayTagAddress(indicatorPeriod7.DisplayTag.Name);
            indicatorPeriod7.DataMapping.Add(207, Properties.Resources.Connect);
            indicatorPeriod7.DataMapping.Add(242, Properties.Resources.Connect);

            chkSetting.DisplayTag.Name = string.Format("{0}.MAN", JunctionName);
            chkSetting.DisplayTag.Address = Program.GetDisplayTagAddress(chkSetting.DisplayTag.Name);
            chkSetting.DataMapping.Add(true, true);
            chkSetting.DataMapping.Add(false, false);

            numberMXA.DisplayTag.Name = string.Format("{0}.X_A_MAN", JunctionName);
            numberMXA.DisplayTag.Address = Program.GetDisplayTagAddress(numberMXA.DisplayTag.Name);

            numberMVA.DisplayTag.Name = string.Format("{0}.V_A_MAN", JunctionName);
            numberMVA.DisplayTag.Address = Program.GetDisplayTagAddress(numberMVA.DisplayTag.Name);

            numberMGTA.DisplayTag.Name = string.Format("{0}.GT_A_MAN", JunctionName);
            numberMGTA.DisplayTag.Address = Program.GetDisplayTagAddress(numberMGTA.DisplayTag.Name);

            numberMXB.DisplayTag.Name = string.Format("{0}.X_B_MAN", JunctionName);
            numberMXB.DisplayTag.Address = Program.GetDisplayTagAddress(numberMXB.DisplayTag.Name);

            numberMVB.DisplayTag.Name = string.Format("{0}.V_B_MAN", JunctionName);
            numberMVB.DisplayTag.Address = Program.GetDisplayTagAddress(numberMVB.DisplayTag.Name);

            numberMGTB.DisplayTag.Name = string.Format("{0}.GT_B_MAN", JunctionName);
            numberMGTB.DisplayTag.Address = Program.GetDisplayTagAddress(numberMGTB.DisplayTag.Name);

            numberRXA.DisplayTag.Name = string.Format("{0}.X_A_R", JunctionName);
            numberRXA.DisplayTag.Address = Program.GetDisplayTagAddress(numberRXA.DisplayTag.Name);

            numberRVA.DisplayTag.Name = string.Format("{0}.V_A_R", JunctionName);
            numberRVA.DisplayTag.Address = Program.GetDisplayTagAddress(numberRVA.DisplayTag.Name);

            numberRGTA.DisplayTag.Name = string.Format("{0}.GT_A_R", JunctionName);
            numberRGTA.DisplayTag.Address = Program.GetDisplayTagAddress(numberRGTA.DisplayTag.Name);

            numberRXB.DisplayTag.Name = string.Format("{0}.X_B_R", JunctionName);
            numberRXB.DisplayTag.Address = Program.GetDisplayTagAddress(numberRXB.DisplayTag.Name);

            numberRVB.DisplayTag.Name = string.Format("{0}.V_B_R", JunctionName);
            numberRVB.DisplayTag.Address = Program.GetDisplayTagAddress(numberRVB.DisplayTag.Name);

            numberRGTB.DisplayTag.Name = string.Format("{0}.GT_B_R", JunctionName);
            numberRGTB.DisplayTag.Address = Program.GetDisplayTagAddress(numberRGTB.DisplayTag.Name);

            btnApplyManualSetting.DisplayTag.Name = string.Format("{0}.SET_T_M", JunctionName);
            btnApplyManualSetting.DisplayTag.Address = Program.GetDisplayTagAddress(btnApplyManualSetting.DisplayTag.Name);
            btnApplyManualSetting.DataOnClickMapping.Add(this.BackColor, true);

            btnSetting.DisplayTag.Name = string.Format("{0}.SETUP", JunctionName);
            btnSetting.DisplayTag.Address = Program.GetDisplayTagAddress(btnSetting.DisplayTag.Name);
            btnSetting.DataMapping.Add(false, Color.White);
            btnSetting.DataMapping.Add(true, Color.Lime);
            btnSetting.DataOnClickMapping.Add(Color.White, true);
            btnSetting.DataOnClickMapping.Add(Color.Lime, false);

            panelSetting.DisplayTag.Name = string.Format("{0}.MAN", JunctionName);
            panelSetting.DisplayTag.Address = Program.GetDisplayTagAddress(panelSetting.DisplayTag.Name);
            panelSetting.DataMapping.Add(true, new List<object> { true, 2, Color.Lime });
            panelSetting.DataMapping.Add(false, new List<object> { false, 1, Color.Black });

            page.AddTag(indicatorDA.DisplayTag);
            page.AddTag(indicatorVA.DisplayTag);
            page.AddTag(indicatorXA.DisplayTag);
            page.AddTag(indicatorDB.DisplayTag);
            page.AddTag(indicatorVB.DisplayTag);
            page.AddTag(indicatorXB.DisplayTag);
            //page.AddTag(txtSetting.DisplayTag);
            //page.AddTag(txtControlMode.DisplayTag);
            //page.AddTag(txtControlDateType.DisplayTag);
            //page.AddTag(txtGreenWaveDirection.DisplayTag);

            page.AddTag(textSource.DisplayTag);
            page.AddTag(textSource1.DisplayTag);
            page.AddTag(textSource2.DisplayTag);
            page.AddTag(textSource3.DisplayTag);
            page.AddTag(textSource4.DisplayTag);
            page.AddTag(textSource5.DisplayTag);

            page.AddTag(indicatorPar1.DisplayTag);
            page.AddTag(indicatorPar2.DisplayTag);
            page.AddTag(indicatorPar3.DisplayTag);
            page.AddTag(indicatorPar4.DisplayTag);
            page.AddTag(indicatorPeriod1.DisplayTag);
            page.AddTag(indicatorPeriod2.DisplayTag);
            page.AddTag(indicatorPeriod3.DisplayTag);
            page.AddTag(indicatorPeriod4.DisplayTag);
            page.AddTag(indicatorPeriod5.DisplayTag);
            page.AddTag(indicatorPeriod6.DisplayTag);
            page.AddTag(indicatorPeriod7.DisplayTag);
            page.AddTag(chkSetting.DisplayTag);
            page.AddTag(numberMXA.DisplayTag);
            page.AddTag(numberMVA.DisplayTag);
            page.AddTag(numberMGTA.DisplayTag);
            page.AddTag(numberMXB.DisplayTag);
            page.AddTag(numberMVB.DisplayTag);
            page.AddTag(numberMGTB.DisplayTag);
            page.AddTag(numberRXA.DisplayTag);
            page.AddTag(numberRVA.DisplayTag);
            page.AddTag(numberRGTA.DisplayTag);
            page.AddTag(numberRXB.DisplayTag);
            page.AddTag(numberRVB.DisplayTag);
            page.AddTag(numberRGTB.DisplayTag);
            page.AddTag(btnApplyManualSetting.DisplayTag);
            page.AddTag(btnSetting.DisplayTag);
            page.AddTag(panelSetting.DisplayTag);
            page.AddTag(btnResetError.DisplayTag);


            Program.AddDisplayForm(this, new List<Display>() { page });
        }

        private void btnResetError_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnResetError))
            {
                string tagName = "";
                string tagAddress = "";
                switch ((int)btnResetError.DisplayTag.Value)
                {
                    case 1:
                        tagName = string.Format("{0}.E_MAT_XA", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                    case 2:
                        tagName = string.Format("{0}.E_MAT_VA", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                    case 3:
                        tagName = string.Format("{0}.E_MAT_DA", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                    case 4:
                        tagName = string.Format("{0}.E_CD_A", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                    case 5:
                        tagName = string.Format("{0}.E_CT_A", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                    case 6:
                        tagName = string.Format("{0}.E_MAT_XB", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                    case 7:
                        tagName = string.Format("{0}.E_MAT_VB", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                    case 8:
                        tagName = string.Format("{0}.E_MAT_DB", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                    case 9:
                        tagName = string.Format("{0}.E_CD_B", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                    case 10:
                        tagName = string.Format("{0}.E_CT_B", JunctionName);
                        tagAddress = Program.GetDisplayTagAddress(tagName);
                        break;
                }
                Program.SetIOTag(tagName, tagAddress, new object[] { false });
            }
        }

        private void FrmPLCControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.RemoveDisplayForm(this);
        }
    }
}

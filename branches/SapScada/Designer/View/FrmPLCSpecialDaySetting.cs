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
    public partial class FrmPLCSpecialDaySetting : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }

        public FrmPLCSpecialDaySetting()
        {
            InitializeComponent();
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            JunctionName = DesignerAccess.GetJunction(JunctionName).DeviceName;
            this.Enter += FrmPLCSpecialDaySetting_Enter;
        }

        private void FrmPLCSpecialDaySetting_Enter(object sender, EventArgs e)
        {
            this.Enter -= FrmPLCSpecialDaySetting_Enter;
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

            chkSelect1.DisplayTag.Name = string.Format("{0}.OPT_S1", JunctionName);
            chkSelect1.DisplayTag.Address = Program.GetDisplayTagAddress(chkSelect1.DisplayTag.Name);
            chkSelect1.DataMapping.Add(true, true);
            chkSelect1.DataMapping.Add(false, false);

            chkSelect2.DisplayTag.Name = string.Format("{0}.OPT_S2", JunctionName);
            chkSelect2.DisplayTag.Address = Program.GetDisplayTagAddress(chkSelect2.DisplayTag.Name);
            chkSelect2.DataMapping.Add(true, true);
            chkSelect2.DataMapping.Add(false, false);

            chkSelect3.DisplayTag.Name = string.Format("{0}.OPT_S3", JunctionName);
            chkSelect3.DisplayTag.Address = Program.GetDisplayTagAddress(chkSelect3.DisplayTag.Name);
            chkSelect3.DataMapping.Add(true, true);
            chkSelect3.DataMapping.Add(false, false);

            chkSelect4.DisplayTag.Name = string.Format("{0}.OPT_S4", JunctionName);
            chkSelect4.DisplayTag.Address = Program.GetDisplayTagAddress(chkSelect4.DisplayTag.Name);
            chkSelect4.DataMapping.Add(true, true);
            chkSelect4.DataMapping.Add(false, false);

            chkSelect5.DisplayTag.Name = string.Format("{0}.OPT_S5", JunctionName);
            chkSelect5.DisplayTag.Address = Program.GetDisplayTagAddress(chkSelect5.DisplayTag.Name);
            chkSelect5.DataMapping.Add(true, true);
            chkSelect5.DataMapping.Add(false, false);

            chkSelect6.DisplayTag.Name = string.Format("{0}.OPT_S6", JunctionName);
            chkSelect6.DisplayTag.Address = Program.GetDisplayTagAddress(chkSelect6.DisplayTag.Name);
            chkSelect6.DataMapping.Add(true, true);
            chkSelect6.DataMapping.Add(false, false);

            chkSelect7.DisplayTag.Name = string.Format("{0}.OPT_S7", JunctionName);
            chkSelect7.DisplayTag.Address = Program.GetDisplayTagAddress(chkSelect7.DisplayTag.Name);
            chkSelect7.DataMapping.Add(true, true);
            chkSelect7.DataMapping.Add(false, false);

            panelSelect1.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            panelSelect1.DisplayTag.Address = Program.GetDisplayTagAddress(panelSelect1.DisplayTag.Name);
            panelSelect1.DataMapping.Add(212, new List<object>() { false, 2, Color.Lime });

            panelSelect2.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            panelSelect2.DisplayTag.Address = Program.GetDisplayTagAddress(panelSelect2.DisplayTag.Name);
            panelSelect2.DataMapping.Add(217, new List<object>() { false, 2, Color.Lime });

            panelSelect3.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            panelSelect3.DisplayTag.Address = Program.GetDisplayTagAddress(panelSelect3.DisplayTag.Name);
            panelSelect3.DataMapping.Add(222, new List<object>() { false, 2, Color.Lime });

            panelSelect4.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            panelSelect4.DisplayTag.Address = Program.GetDisplayTagAddress(panelSelect4.DisplayTag.Name);
            panelSelect4.DataMapping.Add(227, new List<object>() { false, 2, Color.Lime });

            panelSelect5.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            panelSelect5.DisplayTag.Address = Program.GetDisplayTagAddress(panelSelect5.DisplayTag.Name);
            panelSelect5.DataMapping.Add(232, new List<object>() { false, 2, Color.Lime });

            panelSelect6.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            panelSelect6.DisplayTag.Address = Program.GetDisplayTagAddress(panelSelect6.DisplayTag.Name);
            panelSelect6.DataMapping.Add(237, new List<object>() { false, 2, Color.Lime });

            panelSelect7.DisplayTag.Name = string.Format("{0}.PAR_R", JunctionName);
            panelSelect7.DisplayTag.Address = Program.GetDisplayTagAddress(panelSelect7.DisplayTag.Name);
            panelSelect7.DataMapping.Add(242, new List<object>() { false, 2, Color.Lime });

            numberHour1.DisplayTag.Name = string.Format("{0}.S1_HOUR", JunctionName);
            numberHour1.DisplayTag.Address = Program.GetDisplayTagAddress(numberHour1.DisplayTag.Name);

            numberHour2.DisplayTag.Name = string.Format("{0}.S2_HOUR", JunctionName);
            numberHour2.DisplayTag.Address = Program.GetDisplayTagAddress(numberHour2.DisplayTag.Name);

            numberHour3.DisplayTag.Name = string.Format("{0}.S3_HOUR", JunctionName);
            numberHour3.DisplayTag.Address = Program.GetDisplayTagAddress(numberHour3.DisplayTag.Name);

            numberHour4.DisplayTag.Name = string.Format("{0}.S4_HOUR", JunctionName);
            numberHour4.DisplayTag.Address = Program.GetDisplayTagAddress(numberHour4.DisplayTag.Name);

            numberHour5.DisplayTag.Name = string.Format("{0}.S5_HOUR", JunctionName);
            numberHour5.DisplayTag.Address = Program.GetDisplayTagAddress(numberHour5.DisplayTag.Name);

            numberHour6.DisplayTag.Name = string.Format("{0}.S6_HOUR", JunctionName);
            numberHour6.DisplayTag.Address = Program.GetDisplayTagAddress(numberHour6.DisplayTag.Name);

            numberHour7.DisplayTag.Name = string.Format("{0}.S7_HOUR", JunctionName);
            numberHour7.DisplayTag.Address = Program.GetDisplayTagAddress(numberHour7.DisplayTag.Name);

            numberMin1.DisplayTag.Name = string.Format("{0}.S1_MIN", JunctionName);
            numberMin1.DisplayTag.Address = Program.GetDisplayTagAddress(numberMin1.DisplayTag.Name);

            numberMin2.DisplayTag.Name = string.Format("{0}.S2_MIN", JunctionName);
            numberMin2.DisplayTag.Address = Program.GetDisplayTagAddress(numberMin2.DisplayTag.Name);

            numberMin3.DisplayTag.Name = string.Format("{0}.S3_MIN", JunctionName);
            numberMin3.DisplayTag.Address = Program.GetDisplayTagAddress(numberMin3.DisplayTag.Name);

            numberMin4.DisplayTag.Name = string.Format("{0}.S4_MIN", JunctionName);
            numberMin4.DisplayTag.Address = Program.GetDisplayTagAddress(numberMin4.DisplayTag.Name);

            numberMin5.DisplayTag.Name = string.Format("{0}.S5_MIN", JunctionName);
            numberMin5.DisplayTag.Address = Program.GetDisplayTagAddress(numberMin5.DisplayTag.Name);

            numberMin6.DisplayTag.Name = string.Format("{0}.S6_MIN", JunctionName);
            numberMin6.DisplayTag.Address = Program.GetDisplayTagAddress(numberMin6.DisplayTag.Name);

            numberMin7.DisplayTag.Name = string.Format("{0}.S7_MIN", JunctionName);
            numberMin7.DisplayTag.Address = Program.GetDisplayTagAddress(numberMin7.DisplayTag.Name);

            numberPar1.DisplayTag.Name = string.Format("{0}.S1_PAR", JunctionName);
            numberPar1.DisplayTag.Address = Program.GetDisplayTagAddress(numberPar1.DisplayTag.Name);

            numberPar2.DisplayTag.Name = string.Format("{0}.S2_PAR", JunctionName);
            numberPar2.DisplayTag.Address = Program.GetDisplayTagAddress(numberPar2.DisplayTag.Name);

            numberPar3.DisplayTag.Name = string.Format("{0}.S3_PAR", JunctionName);
            numberPar3.DisplayTag.Address = Program.GetDisplayTagAddress(numberPar3.DisplayTag.Name);

            numberPar4.DisplayTag.Name = string.Format("{0}.S4_PAR", JunctionName);
            numberPar4.DisplayTag.Address = Program.GetDisplayTagAddress(numberPar4.DisplayTag.Name);

            numberPar5.DisplayTag.Name = string.Format("{0}.S5_PAR", JunctionName);
            numberPar5.DisplayTag.Address = Program.GetDisplayTagAddress(numberPar5.DisplayTag.Name);

            numberPar6.DisplayTag.Name = string.Format("{0}.S6_PAR", JunctionName);
            numberPar6.DisplayTag.Address = Program.GetDisplayTagAddress(numberPar6.DisplayTag.Name);

            numberPar7.DisplayTag.Name = string.Format("{0}.S7_PAR", JunctionName);
            numberPar7.DisplayTag.Address = Program.GetDisplayTagAddress(numberPar7.DisplayTag.Name);

            numberOffset1.DisplayTag.Name = string.Format("{0}.S1_OFFSET", JunctionName);
            numberOffset1.DisplayTag.Address = Program.GetDisplayTagAddress(numberOffset1.DisplayTag.Name);

            numberOffset2.DisplayTag.Name = string.Format("{0}.S2_OFFSET", JunctionName);
            numberOffset2.DisplayTag.Address = Program.GetDisplayTagAddress(numberOffset2.DisplayTag.Name);

            numberOffset3.DisplayTag.Name = string.Format("{0}.S3_OFFSET", JunctionName);
            numberOffset3.DisplayTag.Address = Program.GetDisplayTagAddress(numberOffset3.DisplayTag.Name);

            numberOffset4.DisplayTag.Name = string.Format("{0}.S4_OFFSET", JunctionName);
            numberOffset4.DisplayTag.Address = Program.GetDisplayTagAddress(numberOffset4.DisplayTag.Name);

            numberOffset5.DisplayTag.Name = string.Format("{0}.S5_OFFSET", JunctionName);
            numberOffset5.DisplayTag.Address = Program.GetDisplayTagAddress(numberOffset5.DisplayTag.Name);

            numberOffset6.DisplayTag.Name = string.Format("{0}.S6_OFFSET", JunctionName);
            numberOffset6.DisplayTag.Address = Program.GetDisplayTagAddress(numberOffset6.DisplayTag.Name);

            numberOffset7.DisplayTag.Name = string.Format("{0}.S7_OFFSET", JunctionName);
            numberOffset7.DisplayTag.Address = Program.GetDisplayTagAddress(numberOffset7.DisplayTag.Name);

            cbbxMode1.DisplayTag.Name = string.Format("{0}.S1_MODE", JunctionName);
            cbbxMode1.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxMode1.DisplayTag.Name);
            cbbxMode1.DataMapping.Add(1, 0);
            cbbxMode1.DataMapping.Add(2, 1);
            cbbxMode1.DataMapping.Add(3, 2);
            cbbxMode1.DataMapping.Add(4, 3);

            cbbxMode2.DisplayTag.Name = string.Format("{0}.S2_MODE", JunctionName);
            cbbxMode2.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxMode2.DisplayTag.Name);
            cbbxMode2.DataMapping.Add(1, 0);
            cbbxMode2.DataMapping.Add(2, 1);
            cbbxMode2.DataMapping.Add(3, 2);
            cbbxMode2.DataMapping.Add(4, 3);

            cbbxMode3.DisplayTag.Name = string.Format("{0}.S3_MODE", JunctionName);
            cbbxMode3.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxMode3.DisplayTag.Name);
            cbbxMode3.DataMapping.Add(1, 0);
            cbbxMode3.DataMapping.Add(2, 1);
            cbbxMode3.DataMapping.Add(3, 2);
            cbbxMode3.DataMapping.Add(4, 3);

            cbbxMode4.DisplayTag.Name = string.Format("{0}.S4_MODE", JunctionName);
            cbbxMode4.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxMode4.DisplayTag.Name);
            cbbxMode4.DataMapping.Add(1, 0);
            cbbxMode4.DataMapping.Add(2, 1);
            cbbxMode4.DataMapping.Add(3, 2);
            cbbxMode4.DataMapping.Add(4, 3);

            cbbxMode5.DisplayTag.Name = string.Format("{0}.S5_MODE", JunctionName);
            cbbxMode5.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxMode5.DisplayTag.Name);
            cbbxMode5.DataMapping.Add(1, 0);
            cbbxMode5.DataMapping.Add(2, 1);
            cbbxMode5.DataMapping.Add(3, 2);
            cbbxMode5.DataMapping.Add(4, 3);

            cbbxMode6.DisplayTag.Name = string.Format("{0}.S6_MODE", JunctionName);
            cbbxMode6.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxMode6.DisplayTag.Name);
            cbbxMode6.DataMapping.Add(1, 0);
            cbbxMode6.DataMapping.Add(2, 1);
            cbbxMode6.DataMapping.Add(3, 2);
            cbbxMode6.DataMapping.Add(4, 3);

            cbbxMode7.DisplayTag.Name = string.Format("{0}.S7_MODE", JunctionName);
            cbbxMode7.DisplayTag.Address = Program.GetDisplayTagAddress(cbbxMode7.DisplayTag.Name);
            cbbxMode7.DataMapping.Add(1, 0);
            cbbxMode7.DataMapping.Add(2, 1);
            cbbxMode7.DataMapping.Add(3, 2);
            cbbxMode7.DataMapping.Add(4, 3);

            page.AddTag(chkSelect1.DisplayTag);
            page.AddTag(chkSelect2.DisplayTag);
            page.AddTag(chkSelect3.DisplayTag);
            page.AddTag(chkSelect4.DisplayTag);
            page.AddTag(chkSelect5.DisplayTag);
            page.AddTag(chkSelect6.DisplayTag);
            page.AddTag(chkSelect7.DisplayTag);
            page.AddTag(panelSelect1.DisplayTag);
            page.AddTag(panelSelect2.DisplayTag);
            page.AddTag(panelSelect3.DisplayTag);
            page.AddTag(panelSelect4.DisplayTag);
            page.AddTag(panelSelect5.DisplayTag);
            page.AddTag(panelSelect6.DisplayTag);
            page.AddTag(panelSelect7.DisplayTag);
            page.AddTag(numberHour1.DisplayTag);
            page.AddTag(numberHour2.DisplayTag);
            page.AddTag(numberHour3.DisplayTag);
            page.AddTag(numberHour4.DisplayTag);
            page.AddTag(numberHour5.DisplayTag);
            page.AddTag(numberHour6.DisplayTag);
            page.AddTag(numberHour7.DisplayTag);
            page.AddTag(numberMin1.DisplayTag);
            page.AddTag(numberMin2.DisplayTag);
            page.AddTag(numberMin3.DisplayTag);
            page.AddTag(numberMin4.DisplayTag);
            page.AddTag(numberMin5.DisplayTag);
            page.AddTag(numberMin6.DisplayTag);
            page.AddTag(numberMin7.DisplayTag);
            page.AddTag(numberPar1.DisplayTag);
            page.AddTag(numberPar2.DisplayTag);
            page.AddTag(numberPar3.DisplayTag);
            page.AddTag(numberPar4.DisplayTag);
            page.AddTag(numberPar5.DisplayTag);
            page.AddTag(numberPar6.DisplayTag);
            page.AddTag(numberPar7.DisplayTag);
            page.AddTag(numberOffset1.DisplayTag);
            page.AddTag(numberOffset2.DisplayTag);
            page.AddTag(numberOffset3.DisplayTag);
            page.AddTag(numberOffset4.DisplayTag);
            page.AddTag(numberOffset5.DisplayTag);
            page.AddTag(numberOffset6.DisplayTag);
            page.AddTag(numberOffset7.DisplayTag);
            page.AddTag(cbbxMode1.DisplayTag);
            page.AddTag(cbbxMode2.DisplayTag);
            page.AddTag(cbbxMode3.DisplayTag);
            page.AddTag(cbbxMode4.DisplayTag);
            page.AddTag(cbbxMode5.DisplayTag);
            page.AddTag(cbbxMode6.DisplayTag);
            page.AddTag(cbbxMode7.DisplayTag);

            Program.AddDisplayForm(this, new List<Display>() { page });
        }

     

        private void FrmPLCSpecialDaySetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.RemoveDisplayForm(this);
        }


    }
}

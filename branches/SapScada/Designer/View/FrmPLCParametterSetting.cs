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
    public partial class FrmPLCParametterSetting : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }

        public FrmPLCParametterSetting()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            JunctionName = DesignerAccess.GetJunction(JunctionName).DeviceName;
            this.Enter += FrmPLCParametterSetting_Enter;
        }

        private void FrmPLCParametterSetting_Enter(object sender, EventArgs e)
        {
            this.Enter -= FrmPLCParametterSetting_Enter;
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

            chkT2.DisplayTag.Name = string.Format("{0}.S_T2", JunctionName);
            chkT2.DisplayTag.Address = Program.GetDisplayTagAddress(chkT2.DisplayTag.Name);
            chkT2.DataMapping.Add(true, true);
            chkT2.DataMapping.Add(false, false);

            chkT3.DisplayTag.Name = string.Format("{0}.S_T3", JunctionName);
            chkT3.DisplayTag.Address = Program.GetDisplayTagAddress(chkT3.DisplayTag.Name);
            chkT3.DataMapping.Add(true, true);
            chkT3.DataMapping.Add(false, false);

            chkT4.DisplayTag.Name = string.Format("{0}.S_T4", JunctionName);
            chkT4.DisplayTag.Address = Program.GetDisplayTagAddress(chkT4.DisplayTag.Name);
            chkT4.DataMapping.Add(true, true);
            chkT4.DataMapping.Add(false, false);

            chkT5.DisplayTag.Name = string.Format("{0}.S_T5", JunctionName);
            chkT5.DisplayTag.Address = Program.GetDisplayTagAddress(chkT5.DisplayTag.Name);
            chkT5.DataMapping.Add(true, true);
            chkT5.DataMapping.Add(false, false);

            chkT6.DisplayTag.Name = string.Format("{0}.S_T6", JunctionName);
            chkT6.DisplayTag.Address = Program.GetDisplayTagAddress(chkT6.DisplayTag.Name);
            chkT6.DataMapping.Add(true, true);
            chkT6.DataMapping.Add(false, false);

            chkT7.DisplayTag.Name = string.Format("{0}.S_T7", JunctionName);
            chkT7.DisplayTag.Address = Program.GetDisplayTagAddress(chkT7.DisplayTag.Name);
            chkT7.DataMapping.Add(true, true);
            chkT7.DataMapping.Add(false, false);

            chkCN.DisplayTag.Name = string.Format("{0}.S_CN", JunctionName);
            chkCN.DisplayTag.Address = Program.GetDisplayTagAddress(chkCN.DisplayTag.Name);
            chkCN.DataMapping.Add(true, true);
            chkCN.DataMapping.Add(false, false);

            chkLe.DisplayTag.Name = string.Format("{0}.S_LE", JunctionName);
            chkLe.DisplayTag.Address = Program.GetDisplayTagAddress(chkLe.DisplayTag.Name);
            chkLe.DataMapping.Add(true, true);
            chkLe.DataMapping.Add(false, false);

            panelPar1.DisplayTag.Name = string.Format("{0}.MOV_P1", JunctionName);
            panelPar1.DisplayTag.Address = Program.GetDisplayTagAddress(panelPar1.DisplayTag.Name);
            panelPar1.DataMapping.Add(true, new List<object>() { false, 2, Color.Lime });

            panelPar2.DisplayTag.Name = string.Format("{0}.MOV_P2", JunctionName);
            panelPar2.DisplayTag.Address = Program.GetDisplayTagAddress(panelPar2.DisplayTag.Name);
            panelPar2.DataMapping.Add(true, new List<object>() { false, 2, Color.Lime });

            panelPar3.DisplayTag.Name = string.Format("{0}.MOV_P3", JunctionName);
            panelPar3.DisplayTag.Address = Program.GetDisplayTagAddress(panelPar3.DisplayTag.Name);
            panelPar3.DataMapping.Add(true, new List<object>() { false, 2, Color.Lime });

            panelPar4.DisplayTag.Name = string.Format("{0}.MOV_P4", JunctionName);
            panelPar4.DisplayTag.Address = Program.GetDisplayTagAddress(panelPar4.DisplayTag.Name);
            panelPar4.DataMapping.Add(true, new List<object>() { false, 2, Color.Lime });

            numberXA1.DisplayTag.Name = string.Format("{0}.TG_X_A1", JunctionName);
            numberXA1.DisplayTag.Address = Program.GetDisplayTagAddress(numberXA1.DisplayTag.Name);

            numberXA2.DisplayTag.Name = string.Format("{0}.TG_X_A2", JunctionName);
            numberXA2.DisplayTag.Address = Program.GetDisplayTagAddress(numberXA2.DisplayTag.Name);

            numberXA3.DisplayTag.Name = string.Format("{0}.TG_X_A3", JunctionName);
            numberXA3.DisplayTag.Address = Program.GetDisplayTagAddress(numberXA3.DisplayTag.Name);

            numberXA4.DisplayTag.Name = string.Format("{0}.TG_X_A4", JunctionName);
            numberXA4.DisplayTag.Address = Program.GetDisplayTagAddress(numberXA4.DisplayTag.Name);

            numberVA1.DisplayTag.Name = string.Format("{0}.TG_V_A1", JunctionName);
            numberVA1.DisplayTag.Address = Program.GetDisplayTagAddress(numberVA1.DisplayTag.Name);

            numberVA2.DisplayTag.Name = string.Format("{0}.TG_V_A2", JunctionName);
            numberVA2.DisplayTag.Address = Program.GetDisplayTagAddress(numberVA2.DisplayTag.Name);

            numberVA3.DisplayTag.Name = string.Format("{0}.TG_V_A3", JunctionName);
            numberVA3.DisplayTag.Address = Program.GetDisplayTagAddress(numberVA3.DisplayTag.Name);

            numberVA4.DisplayTag.Name = string.Format("{0}.TG_V_A4", JunctionName);
            numberVA4.DisplayTag.Address = Program.GetDisplayTagAddress(numberVA4.DisplayTag.Name);

            numberGTA1.DisplayTag.Name = string.Format("{0}.TG_GT_A1", JunctionName);
            numberGTA1.DisplayTag.Address = Program.GetDisplayTagAddress(numberGTA1.DisplayTag.Name);

            numberGTA2.DisplayTag.Name = string.Format("{0}.TG_GT_A2", JunctionName);
            numberGTA2.DisplayTag.Address = Program.GetDisplayTagAddress(numberGTA2.DisplayTag.Name);

            numberGTA3.DisplayTag.Name = string.Format("{0}.TG_GT_A3", JunctionName);
            numberGTA3.DisplayTag.Address = Program.GetDisplayTagAddress(numberGTA3.DisplayTag.Name);

            numberGTA4.DisplayTag.Name = string.Format("{0}.TG_GT_A4", JunctionName);
            numberGTA4.DisplayTag.Address = Program.GetDisplayTagAddress(numberGTA4.DisplayTag.Name);

            numberXB1.DisplayTag.Name = string.Format("{0}.TG_X_B1", JunctionName);
            numberXB1.DisplayTag.Address = Program.GetDisplayTagAddress(numberXB1.DisplayTag.Name);

            numberXB2.DisplayTag.Name = string.Format("{0}.TG_X_B2", JunctionName);
            numberXB2.DisplayTag.Address = Program.GetDisplayTagAddress(numberXB2.DisplayTag.Name);

            numberXB3.DisplayTag.Name = string.Format("{0}.TG_X_B3", JunctionName);
            numberXB3.DisplayTag.Address = Program.GetDisplayTagAddress(numberXB3.DisplayTag.Name);

            numberXB4.DisplayTag.Name = string.Format("{0}.TG_X_B4", JunctionName);
            numberXB4.DisplayTag.Address = Program.GetDisplayTagAddress(numberXB4.DisplayTag.Name);

            numberVB1.DisplayTag.Name = string.Format("{0}.TG_V_B1", JunctionName);
            numberVB1.DisplayTag.Address = Program.GetDisplayTagAddress(numberVB1.DisplayTag.Name);

            numberVB1.DisplayTag.Name = string.Format("{0}.TG_V_B1", JunctionName);
            numberVB1.DisplayTag.Address = Program.GetDisplayTagAddress(numberVB1.DisplayTag.Name);

            numberVB2.DisplayTag.Name = string.Format("{0}.TG_V_B2", JunctionName);
            numberVB2.DisplayTag.Address = Program.GetDisplayTagAddress(numberVB2.DisplayTag.Name);

            numberVB3.DisplayTag.Name = string.Format("{0}.TG_V_B3", JunctionName);
            numberVB3.DisplayTag.Address = Program.GetDisplayTagAddress(numberVB3.DisplayTag.Name);

            numberVB4.DisplayTag.Name = string.Format("{0}.TG_V_B4", JunctionName);
            numberVB4.DisplayTag.Address = Program.GetDisplayTagAddress(numberVB4.DisplayTag.Name);

            numberGTB1.DisplayTag.Name = string.Format("{0}.TG_GT_B1", JunctionName);
            numberGTB1.DisplayTag.Address = Program.GetDisplayTagAddress(numberGTB1.DisplayTag.Name);

            numberGTB2.DisplayTag.Name = string.Format("{0}.TG_GT_B2", JunctionName);
            numberGTB2.DisplayTag.Address = Program.GetDisplayTagAddress(numberGTB2.DisplayTag.Name);

            numberGTB3.DisplayTag.Name = string.Format("{0}.TG_GT_B3", JunctionName);
            numberGTB3.DisplayTag.Address = Program.GetDisplayTagAddress(numberGTB3.DisplayTag.Name);

            numberGTB4.DisplayTag.Name = string.Format("{0}.TG_GT_B4", JunctionName);
            numberGTB4.DisplayTag.Address = Program.GetDisplayTagAddress(numberGTB4.DisplayTag.Name);

            numberC1.DisplayTag.Name = string.Format("{0}.CK1", JunctionName);
            numberC1.DisplayTag.Address = Program.GetDisplayTagAddress(numberC1.DisplayTag.Name);

            numberC2.DisplayTag.Name = string.Format("{0}.CK2", JunctionName);
            numberC2.DisplayTag.Address = Program.GetDisplayTagAddress(numberC2.DisplayTag.Name);

            numberC3.DisplayTag.Name = string.Format("{0}.CK3", JunctionName);
            numberC3.DisplayTag.Address = Program.GetDisplayTagAddress(numberC3.DisplayTag.Name);

            numberC4.DisplayTag.Name = string.Format("{0}.CK4", JunctionName);
            numberC4.DisplayTag.Address = Program.GetDisplayTagAddress(numberC4.DisplayTag.Name);

            btnDirectionA.DisplayTag.Name = string.Format("{0}.DB_A", JunctionName);
            btnDirectionA.DisplayTag.Address = Program.GetDisplayTagAddress(btnDirectionA.DisplayTag.Name);
            btnDirectionA.DataMapping.Add(false, Color.White);
            btnDirectionA.DataMapping.Add(true, Color.Lime);
            btnDirectionA.DataOnClickMapping.Add(Color.White, true);
            btnDirectionA.DataOnClickMapping.Add(Color.Lime, false);

            btnDirectionB.DisplayTag.Name = string.Format("{0}.DB_B", JunctionName);
            btnDirectionB.DisplayTag.Address = Program.GetDisplayTagAddress(btnDirectionB.DisplayTag.Name);
            btnDirectionB.DataMapping.Add(false, Color.White);
            btnDirectionB.DataMapping.Add(true, Color.Lime);
            btnDirectionB.DataOnClickMapping.Add(Color.White, true);
            btnDirectionB.DataOnClickMapping.Add(Color.Lime, false);

            page.AddTag(chkT2.DisplayTag);
            page.AddTag(chkT3.DisplayTag);
            page.AddTag(chkT4.DisplayTag);
            page.AddTag(chkT5.DisplayTag);
            page.AddTag(chkT6.DisplayTag);
            page.AddTag(chkT7.DisplayTag);
            page.AddTag(chkCN.DisplayTag);
            page.AddTag(chkLe.DisplayTag);
            page.AddTag(panelPar1.DisplayTag);
            page.AddTag(panelPar2.DisplayTag);
            page.AddTag(panelPar3.DisplayTag);
            page.AddTag(panelPar4.DisplayTag);
            page.AddTag(numberXA1.DisplayTag);
            page.AddTag(numberXA2.DisplayTag);
            page.AddTag(numberXA3.DisplayTag);
            page.AddTag(numberXA4.DisplayTag);
            page.AddTag(numberVA1.DisplayTag);
            page.AddTag(numberVA2.DisplayTag);
            page.AddTag(numberVA3.DisplayTag);
            page.AddTag(numberVA4.DisplayTag);
            page.AddTag(numberGTA1.DisplayTag);
            page.AddTag(numberGTA2.DisplayTag);
            page.AddTag(numberGTA3.DisplayTag);
            page.AddTag(numberGTA4.DisplayTag);
            page.AddTag(numberXB1.DisplayTag);
            page.AddTag(numberXB2.DisplayTag);
            page.AddTag(numberXB3.DisplayTag);
            page.AddTag(numberXB4.DisplayTag);
            page.AddTag(numberVB1.DisplayTag);
            page.AddTag(numberVB2.DisplayTag);
            page.AddTag(numberVB3.DisplayTag);
            page.AddTag(numberVB4.DisplayTag);
            page.AddTag(numberGTB1.DisplayTag);
            page.AddTag(numberGTB2.DisplayTag);
            page.AddTag(numberGTB3.DisplayTag);
            page.AddTag(numberGTB4.DisplayTag);
            page.AddTag(numberC1.DisplayTag);
            page.AddTag(numberC2.DisplayTag);
            page.AddTag(numberC3.DisplayTag);
            page.AddTag(numberC4.DisplayTag);
            page.AddTag(btnDirectionA.DisplayTag);
            page.AddTag(btnDirectionB.DisplayTag);

            Program.AddDisplayForm(this, new List<Display>() { page });
        }

      
        private void FrmPLCParametterSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        public void StopUpdating()
        {
            Program.RemoveDisplayForm(this);
        }

    }
}

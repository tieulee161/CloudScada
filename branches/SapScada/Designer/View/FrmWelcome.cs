using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik;

namespace Designer.View
{
    public partial class FrmWelcome : Telerik.WinControls.UI.RadForm
    {
        public bool IsDone = false;
        public FrmWelcome()
        {
            InitializeComponent();
            this.Size = new Size(655, 253);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radProgressBar1.Value1 < 100)
            {
                radProgressBar1.Value1++;
            }
            else
            {
                timer1.Enabled = false;
                IsDone = true;
            }
        }

        private void FrmWelcome_Load(object sender, EventArgs e)
        {
            radProgressBar1.Value1 = 0;
            timer1.Enabled = true;
            timer1.Start();
        }
    }
}

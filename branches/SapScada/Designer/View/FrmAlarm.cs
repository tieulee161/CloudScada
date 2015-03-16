using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Designer.View
{
    public partial class FrmAlarm : Telerik.WinControls.UI.RadForm
    {
        public FrmAlarm()
        {
            InitializeComponent();
        }

        private void FrmAlarm_Load(object sender, EventArgs e)
        {
            UCAlarmControl.LoadIncomingSource();
            UCAlarmControl.LoadConfirmedSource();
            UCAlarmControl.LoadJunction();
        }


    }
}

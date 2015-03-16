using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Designer.Model;
using Designer.Core;
using Common;
using HDSComponent;
using Telerik.WinControls.UI;

namespace Designer.View
{
    public partial class UCAlarmNews : UserControl
    {
        List<Alarm> Alarms { get; set; }
        public UCAlarmNews()
        {
            InitializeComponent();
            Alarms = new List<Alarm>();
            lbAlarm.Text = "";
        }

        public void SetAlarm(Alarm alarm)
        {
            Alarms.Add(alarm);
            alarm.RaiseAlarmEvent += alarm_RaiseAlarmEvent;
        }

        private void alarm_RaiseAlarmEvent(object sender, AlarmEventArgs a)
        {
            GetCurrentAlarm();
        }

        public void GetCurrentAlarm()
        {
            AlarmTagValue value = DBAccess.GetCurrentAlarm();
            if (value != null)
            {
                lbAlarm.Text = string.Format("{0} : {1} - {2}", value.AlarmTag.IOTag.Device.Name, value.AlarmTag.Name, (AlarmStatus)value.Status);

            }
        }
    }
}

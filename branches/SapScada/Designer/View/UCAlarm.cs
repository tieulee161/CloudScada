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
    public partial class UCAlarm : UserControl
    {
        public List<Alarm> Alarms { get; set; }
        public UCAlarm()
        {
            InitializeComponent();
            Alarms = new List<Alarm>();

        }

        private void UCAlarm_Load(object sender, EventArgs e)
        {
            dtgIncoming.CellClick += dtgIncoming_CellClick;
            btnSearch.Click += btnSearch_Click;
            dtgIncoming.CreateCell += GridView_CreateCell;
            dtgConfirmed.CreateCell += GridView_CreateCell;
            dtgAll.CreateCell += GridView_CreateCell;
            InitializeGridview(dtgIncoming);
            InitializeGridview(dtgConfirmed);
            InitializeGridview(dtgAll);

            Dictionary<int, string> source = new Dictionary<int, string>() { { 0, "Cảnh báo mới" }, { 1, "Cảnh báo đã mất" }, { 2, "Cảnh báo đã xác nhận" }, { 3, "Cảnh báo xác nhận đã mất" } };
            ((GridViewComboBoxColumn)dtgAll.Columns["colStatus"]).DataSource = source;
            ((GridViewComboBoxColumn)dtgAll.Columns["colStatus"]).DisplayMember = "Value";
            ((GridViewComboBoxColumn)dtgAll.Columns["colStatus"]).ValueMember = "Key";

        }

        private void GridView_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            if (e.CellType == typeof(GridRowHeaderCellElement) && e.Row is GridDataRowElement)
            {
                e.CellType = typeof(SpreadsheetGridRowHeaderCellElement);
            }
        }

        private void InitializeGridview(RadGridView grid)
        {
            grid.TableElement.RowHeaderColumnWidth = 42;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = this.dateFrom.Value.Date;
            DateTime dateTo = this.dateTo.Value.Date.AddDays(1);
            string deviceName = cbbxDevice.Text;
            List<AlarmTagValue> alarms = DBAccess.GetAlarms(dateFrom, dateTo, deviceName);
            for (int j = 0; j < alarms.Count; j++)
            {
                dtgAll.Rows.Add(new object[] { alarms[j].Id, 
                                                alarms[j].AlarmTag.IOTag.Device.Name, 
                                                alarms[j].AlarmTag.Name, 
                                                alarms[j].TimeStampOn, 
                                                alarms[j].TimeStampOff, 
                                                alarms[j].Status });
            }
        }

        private void dtgIncoming_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "colConfirm")
            {
                if (MessageHandler.AskForConfirmAlarm() == DialogResult.Yes)
                {
                    int id = (int)(decimal)e.Row.Cells[0].Value;
                    if (DBAccess.ConfirmAlarm(id))
                    {
                        LoadIncomingSource();
                        LoadConfirmedSource();
                    }
                }
            }
        }

        public void SetAlarm(Alarm alarm)
        {
            Alarms.Add(alarm);
            alarm.RaiseAlarmEvent += Alarm_RaiseAlarmEvent;
        }

        private void Alarm_RaiseAlarmEvent(object sender, AlarmEventArgs a)
        {
            if (a.AlarmTagValue.Status == (int)AlarmStatus.Incomming)
            {
                dtgIncoming.Rows.Add(new object[] { a.AlarmTagValue.AlarmTag.Id, 
                                                    a.AlarmTagValue.AlarmTag.IOTag.Device.Name,
                                                    a.AlarmTagValue.AlarmTag.Name,
                                                    a.AlarmTagValue.TimeStampOn,
                                                    ((AlarmValue)a.AlarmTagValue.Value).ToString(), 
                                                    false });

            }
            else
            {
                for (int j = 0; j < dtgIncoming.Rows.Count; j++)
                {
                    if (a.AlarmTagValue.AlarmTag.Id == (int)(decimal)dtgIncoming.Rows[j].Cells[0].Value)
                    {
                        dtgIncoming.Rows[j].Delete();
                        break;
                    }
                }

                for (int j = 0; j < dtgConfirmed.Rows.Count; j++)
                {
                    if (a.AlarmTagValue.AlarmTag.Id == (int)(decimal)dtgConfirmed.Rows[j].Cells[0].Value)
                    {
                        dtgConfirmed.Rows[j].Delete();
                        break;
                    }
                }

            }
        }

        public void LoadIncomingSource()
        {
            dtgIncoming.Rows.Clear();
            List<AlarmTagValue> incomingAlarms = DBAccess.GetIncomingAlarms();
            for (int j = 0; j < incomingAlarms.Count; j++)
            {
                dtgIncoming.Rows.Add(new object[] { incomingAlarms[j].AlarmTag.Id,
                                                            incomingAlarms[j].AlarmTag.IOTag.Device.Name, 
                                                            incomingAlarms[j].AlarmTag.Name, 
                                                            incomingAlarms[j].TimeStampOn,
                                                            ((AlarmValue)incomingAlarms[j].Value).ToString(), 
                                                            false });
            }
        }

        public void LoadConfirmedSource()
        {
            dtgConfirmed.Rows.Clear();
            List<AlarmTagValue> confirmedAlarms = DBAccess.GetConfirmedAlarms();
            for (int j = 0; j < confirmedAlarms.Count; j++)
            {
                dtgConfirmed.Rows.Add(new object[] { confirmedAlarms[j].AlarmTag.Id,
                                                            confirmedAlarms[j].AlarmTag.IOTag.Device.Name, 
                                                            confirmedAlarms[j].AlarmTag.Name, 
                                                            confirmedAlarms[j].TimeStampOn,
                                                            ((AlarmValue)confirmedAlarms[j].Value).ToString(), 
                                                   });
            }
        }

        public void LoadJunction()
        {
            cbbxDevice.Items.Clear();
            List<Device> devices = DBAccess.GetDevices();
            for (int j = 0; j < devices.Count; j++)
            {
                cbbxDevice.Items.Add(devices[j].Name);
            }
        }


    }
}

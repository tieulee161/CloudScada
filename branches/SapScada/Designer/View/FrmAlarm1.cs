using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Designer.Core;
using Designer.Model;
using HDSComponent;

namespace Designer.View
{
    public partial class FrmAlarm1 : Telerik.WinControls.UI.RadForm
    {
        BindingSource _AlarmSource;
        private string _DeviceName;

        public FrmAlarm1()
        {
            InitializeComponent();
        }

        private void FrmAlarm_Load(object sender, EventArgs e)
        {
            List<Device> devices = DBAccess.GetDevices(true);
            for (int j = 0; j < devices.Count; j++)
            {
                cbbxJunction.Items.Add(devices[j].Name);
            }
            if (devices.Count > 0)
            {
                cbbxJunction.Text = devices[0].Name;
            }

            dateFrom.Value = DateTime.Now;
            dateTo.Value = DateTime.Now;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnSearchEvent))
            {
                if (cbbxJunction.SelectedItem != null)
                {
                    _DeviceName = cbbxJunction.SelectedItem.ToString();
                    _AlarmSource = new BindingSource();
                    _AlarmSource = DBAccess.GetDeviceEvent(cbbxJunction.SelectedItem.ToString(),
                                                    new bool[] { rdConfirmed.Checked, rdUnconfirmed.Checked, rdWarning.Checked, rdLessCritical.Checked, rdCritical.Checked, rdFindByTime.Checked },
                                                    dateFrom.Value.Add(-dateFrom.Value.TimeOfDay),
                                                    dateTo.Value.AddDays(1).Add(-dateTo.Value.TimeOfDay));
                    dtgEvent.AutoGenerateColumns = false;
                    dtgEvent.DataSource = _AlarmSource;
                    dtgEvent.Columns[1].FieldName = "EventID";
                    dtgEvent.Columns[2].FieldName = "Time";
                    dtgEvent.Columns[3].FieldName = "Priority";
                    dtgEvent.Columns[4].FieldName = "IsConfirm";
                    dtgEvent.Columns[5].FieldName = "Description";
                    dtgEvent.Columns[6].FieldName = "Detail";
                    for (int j = 0; j < _AlarmSource.Count; j++)
                    {
                        dtgEvent.Rows[j].Cells[0].Value = j + 1;
                    }
                }
                else
                {
                    MessageHandler.Inform("Vui lòng chọn giao lộ");
                }
            }
            else if (sender.Equals(btnSaveConfirmed))
            {
                if (_AlarmSource != null)
                {
                    DBAccess.ConfirmEvent(_AlarmSource);
                }
            }
            else if (sender.Equals(btnExprortToExcel))
            {
                if ((_DeviceName != "") && (dtgEvent.Rows.Count > 0))
                {
                    Dictionary<string, DataTable> data = new Dictionary<string, DataTable>();
                    DataTable tb = new DataTable();
                    tb.Columns.Add("Mã lỗi", typeof(string));
                    tb.Columns.Add("Thời gian", typeof(string));
                    tb.Columns.Add("Mức độ lỗi", typeof(string));
                    tb.Columns.Add("Xác nhận", typeof(bool));
                    tb.Columns.Add("Mô tả", typeof(string));
                    tb.Columns.Add("Chi tiết", typeof(string));
                    for (int j = 0; j < dtgEvent.Rows.Count; j++)
                    {
                        tb.Rows.Add(new object[] {  dtgEvent.Rows[j].Cells[1].Value,
                                                dtgEvent.Rows[j].Cells[2].Value,
                                                dtgEvent.Rows[j].Cells[3].Value,
                                                dtgEvent.Rows[j].Cells[4].Value,
                                                dtgEvent.Rows[j].Cells[5].Value,
                                                dtgEvent.Rows[j].Cells[6].Value
                                                });
                    }
                    data.Add(_DeviceName, tb);
                    ReportDB.exportDataToExcel(data);
                }
                else
                {
                    MessageHandler.AskToFullFillInfo();
                }
            }
        }

        private void dtgEvent_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9.75);
        }


    }
}

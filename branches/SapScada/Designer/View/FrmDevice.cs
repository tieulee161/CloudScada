using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Designer.Model;
using Common;
using HDSComponent;

namespace Designer.View
{
    public partial class FrmDevice : Telerik.WinControls.UI.RadForm
    {
        public FrmDevice()
        {
            InitializeComponent();
        }

        // update
        private void dtgServer_DoubleClick(object sender, EventArgs e)
        {
            if (dtgDevice.SelectedRows.Count > 0)
            {
                FrmDeviceSetting f = new FrmDeviceSetting();
                f.FormType = FormType.Update;
                f.OldDevice = new Device();
                f.OldDevice.Name = dtgDevice.SelectedRows[0].Cells[0].Value.ToString();
                f.OldDevice.Driver = dtgDevice.SelectedRows[0].Cells[1].Value.ToString();
                f.OldDevice.Port = (int)((decimal)dtgDevice.SelectedRows[0].Cells[2].Value);
                f.OldDevice.Address = (string)dtgDevice.SelectedRows[0].Cells[3].Value;
                f.OldDevice.Note = dtgDevice.SelectedRows[0].Cells[4].Value.ToString();
                f.ShowDialog();
                if (f.Logic == Logic.Succcess)
                {
                    dtgDevice.SelectedRows[0].Cells[0].Value = f.OldDevice.Name;
                    dtgDevice.SelectedRows[0].Cells[1].Value = f.OldDevice.Driver;
                    dtgDevice.SelectedRows[0].Cells[2].Value = f.OldDevice.Port;
                    dtgDevice.SelectedRows[0].Cells[3].Value = f.OldDevice.Address;
                    dtgDevice.SelectedRows[0].Cells[4].Value = f.OldDevice.Note;
                }

            }
        }

        private void FrmServer_Load(object sender, EventArgs e)
        {
            PrepareContextMenu();
            List<Device> devices = DBAccess.GetDevices();
            foreach (Device dev in devices)
            {
                dtgDevice.Rows.Add(new object[] 
                { 
                    dev.Name,
                    dev.Driver,
                    dev.Port,
                    dev.Address,
                    dev.Note 
                });
            }
        }


        private void PrepareContextMenu()
        {
            contextAdd.Click += contextAdd_Click;
            contextDelete.Click += contextDelete_Click;
        }

        // delete
        private void contextDelete_Click(object sender, EventArgs e)
        {
            if (dtgDevice.SelectedRows.Count > 0)
            {
                string deviceName = dtgDevice.SelectedRows[0].Cells[0].Value.ToString();
                if (MessageHandler.AskForDeleteRecord())
                {
                    if (DBAccess.DeleteDevice(deviceName))
                    {
                        dtgDevice.Rows.Remove(dtgDevice.SelectedRows[0]);
                    }
                    else
                    {
                        MessageHandler.DeleteRecordError();
                    }
                }
            }
        }

        // add
        private void contextAdd_Click(object sender, EventArgs e)
        {
            FrmDeviceSetting f = new FrmDeviceSetting();
            f.FormType = FormType.Add;
            f.ShowDialog();
            if (f.Logic == Logic.Succcess)
            {
                dtgDevice.Rows.Add(new object[] 
                { 
                    f.OldDevice.Name,
                    f.OldDevice.Driver,
                    f.OldDevice.Port, 
                    f.OldDevice.Address,
                    f.OldDevice.Note 
                });
            }
        }

        private void dtgServer_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9.75);
        }
    }
}

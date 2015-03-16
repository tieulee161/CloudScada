using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Common;
using Designer.Model;
using HDSComponent;

namespace Designer.View
{
    public partial class FrmIOTagSetting : Telerik.WinControls.UI.RadForm
    {
        public FormType FormType = FormType.None;
        public Logic Logic = Logic.Fail;
        public IOTag OldIOTag;

        public FrmIOTagSetting()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnAdd))
            {
                if (ValidateInformation())
                {
                    int updateRating = 0;
                    int.TryParse(txtUpdateRate.Text, out updateRating);
                    if (DBAccess.AddIOTag(txtName.Text, cbbxType.SelectedIndex, cbbxDataType.SelectedIndex, cbbxAddress.Text, updateRating, cbbxDevice.Text, txtNote.Text, chkSaveToLog.Checked))
                    {
                        OldIOTag = DBAccess.GetIOTag(txtName.Text);
                        Logic = Logic.Succcess;
                        Close();
                    }
                    else
                    {
                        MessageHandler.AddRecordError();
                    }
                }
                else
                {
                    MessageHandler.AskToFullFillInfo();
                }
            }
            else if (sender.Equals(btnUpdate))
            {
                if (ValidateInformation())
                {
                    int updateRating = 0;
                    int.TryParse(txtUpdateRate.Text, out updateRating);
                    if (DBAccess.UpdateIOTag(OldIOTag.Name, txtName.Text, cbbxType.SelectedIndex, cbbxDataType.SelectedIndex, cbbxAddress.Text, updateRating, cbbxDevice.Text, txtNote.Text, chkSaveToLog.Checked))
                    {
                        OldIOTag = DBAccess.GetIOTag(txtName.Text);
                        Logic = Common.Logic.Succcess;
                        Close();
                    }
                    else
                    {
                        MessageHandler.UpdateRecordError();
                    }
                }
                else
                {
                    MessageHandler.AskToFullFillInfo();
                }
            }
            else if (sender.Equals(btnCancel))
            {
                this.Close();
            }
        }

        private void FrmUpdateServer_Load(object sender, EventArgs e)
        {
            List<Device> devices = DBAccess.GetDevices();
            for (int j = 0; j < devices.Count; j++)
            {
                cbbxDevice.Items.Add(devices[j].Name);
                cbbxDevice.Items[j].Font = new Font(cbbxDevice.Font.FontFamily, (float)9.75);
            }

            if (FormType == FormType.Add)
            {
                btnAdd.Location = btnUpdate.Location;
                btnUpdate.Visible = false;
            }
            else if (FormType == FormType.Update)
            {
                btnAdd.Visible = false;
                txtName.Text = OldIOTag.Name;
                cbbxType.SelectedIndex = (int)OldIOTag.Type;
                cbbxDataType.SelectedIndex = (int)OldIOTag.DataType;
                cbbxAddress.Text = OldIOTag.Address;
                cbbxDevice.Text = OldIOTag.Device.Name;
                txtNote.Text = OldIOTag.Note;
                txtUpdateRate.Text = OldIOTag.UpdateRating.ToString();
                chkSaveToLog.Checked = OldIOTag.IsStoreToLog != null ? (bool)OldIOTag.IsStoreToLog : false;
            }
        }

        private bool ValidateInformation()
        {
            bool res = false;
            if ((txtName.Text.Trim() != "") && (cbbxDataType.SelectedItem != null) && (cbbxType.SelectedItem != null))
            {
                res = true;
            }
            return res;
        }


        private void cbbxDevice_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cbbxDevice.SelectedItem != null)
            {
                Device dev = DBAccess.GetDevice(cbbxDevice.SelectedItem.Text);
                if (dev != null)
                {
                    cbbxAddress.Items.Clear();
                    switch (dev.Driver)
                    {
                        case "VDK":
                            List<string> addressList = IODriver.AppDriver.GetTagAdressList();
                            cbbxAddress.Items.AddRange(addressList);
                            for (int j = 0; j < cbbxAddress.Items.Count; j++)
                            {
                                cbbxAddress.Items[j].Font = new Font(cbbxAddress.Font.FontFamily, (float)9.75);
                            }
                            break;
                        case "Kepware V4.0":

                            break;
                    }
                }
            }
        }

        private void cbbxType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            switch (cbbxType.SelectedIndex)
            {
                case 0: // external
                    cbbxDevice.Enabled = true;
                    cbbxAddress.Enabled = true;
                    break;
                case 1: // internal
                    cbbxDevice.Enabled = false;
                    cbbxAddress.Enabled = false;
                    break;
            }
        }
    }
}

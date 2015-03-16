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
    public partial class FrmDeviceSetting : Telerik.WinControls.UI.RadForm
    {
        public FormType FormType = FormType.None;
        public Logic Logic = Logic.Fail;
        public Device OldDevice;

        public FrmDeviceSetting()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnAdd))
            {
                if (ValidateInformation())
                {
                    if (DBAccess.AddDevice(txtName.Text, (int)intPort.Value, cbbxDriver.Text, txtNote.Text, txtAdress.Text.Trim()))
                    {
                        OldDevice = DBAccess.GetDevice(txtName.Text);
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
                    if (DBAccess.UpdateDevice(OldDevice.Name, txtName.Text, (int)intPort.Value, cbbxDriver.Text, txtNote.Text, txtAdress.Text.Trim()))
                    {
                        OldDevice = DBAccess.GetDevice(txtName.Text);
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
            if (FormType == FormType.Add)
            {
                btnAdd.Location = btnUpdate.Location;
                btnUpdate.Visible = false;
            }
            else if (FormType == FormType.Update)
            {
                btnAdd.Visible = false;
                txtName.Text = OldDevice.Name;
                intPort.Value = (int)OldDevice.Port;
                txtNote.Text = OldDevice.Note;
                cbbxDriver.Text = OldDevice.Driver;
                txtAdress.Text = OldDevice.Address;
            }
        }

        private bool ValidateInformation()
        {
            bool res = false;
            if ((txtName.Text.Trim() != "") && (intPort.Value != 0) && (cbbxDriver.Text != ""))
            {
                res = true;
            }
            return res;
        }
    }
}

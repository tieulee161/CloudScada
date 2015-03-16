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
    public partial class FrmServerSetting : Telerik.WinControls.UI.RadForm
    {
        public FormType FormType = FormType.None;
        public Logic Logic = Logic.Fail;
        public Server OldServer;

        public FrmServerSetting()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnAdd))
            {
                if (ValidateInformation())
                {
                    if (DBAccess.AddServer(txtName.Text, txtIP.Text, cbbxType.SelectedIndex, cbbxPriority.SelectedIndex, txtNote.Text))
                    {
                        OldServer = DBAccess.GetServer(txtName.Text);
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
                    if (DBAccess.UpdateServer(OldServer.Name, txtName.Text, txtIP.Text, cbbxType.SelectedIndex, cbbxPriority.SelectedIndex, txtNote.Text))
                    {
                        OldServer = DBAccess.GetServer(txtName.Text);
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
                txtName.Text = OldServer.Name;
                txtIP.Text = OldServer.IP;
                cbbxType.SelectedIndex = (int)OldServer.Type;
                cbbxPriority.SelectedIndex = (int)OldServer.Priority;
                txtNote.Text = OldServer.Note;
            }
        }

        private bool ValidateInformation()
        {
            bool res = false;
            if ((txtName.Text.Trim() != "") && (txtIP.Text.Trim() != "") && (cbbxType.SelectedItem != null) && (cbbxPriority.SelectedItem != null))
            {
                res = true;
            }
            return res;
        }
    }
}

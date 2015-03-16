using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HDSComponent;
using Designer.Model;

namespace Designer.View
{
    public partial class FrmChangePassword : Telerik.WinControls.UI.RadForm
    {
        public string UserName = "";
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePass();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            txtUserName.Text = UserName;
        }
        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ChangePass();
            }
        }
        private void ChangePass()
        {
            if (txtConfirmPassword.Text == txtNewPassword.Text)
            {
                if (DBAccess.ChangePassword(txtUserName.Text, txtOldPassword.Text, txtNewPassword.Text))
                {
                    Close();
                }
                else
                {
                    MessageHandler.Error("Mật khẩu cũ hoặc tên đăng nhập không đúng !");
                }
            }
            else
            {
                MessageHandler.Error("Xác nhận mật khẩu mới không đúng !");
            }
        }

        private void txtOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (sender.Equals(txtOldPassword))
                {
                    txtNewPassword.Focus();
                }
                else if (sender.Equals(txtNewPassword))
                {
                    txtConfirmPassword.Focus();
                }
            }
        }

        
    }
}

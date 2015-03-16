using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Designer.Model;
using HDSComponent;

namespace Designer.View
{
    public partial class FrmLogin : Telerik.WinControls.UI.RadForm
    {
        public User LoginUser = null;
        public FrmLogin()
        {
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void Login()
        {
            LoginUser = DBAccess.Login(txtUserName.Text, txtPassword.Text);
            if (LoginUser != null)
            {
                Close();
            }
            else
            {
                MessageHandler.Error("Tên đăng nhập hoặc mật khẩu không đúng!");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Login();
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
            //this.ActiveControl = txtUserName;
            //txtUserName.Focus();
            //MessageBox.Show(txtUserName.Focused.ToString());
        }
    }
}

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
    public partial class FrmUserManagement : Telerik.WinControls.UI.RadForm
    {
        public FrmUserManagement()
        {
            InitializeComponent();
        }

        private void FrmUserManagement_Load(object sender, EventArgs e)
        {
            List<User> users = DBAccess.GetUserList();
            foreach (User usr in users)
            {
                if (usr.Name != "admin")
                {
                    dtgUser.Rows.Add(new object[] { usr.Name, usr.Password });
                }
            }
            dtgUser.ClearSelection();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnAddUser))
            {
                if (DBAccess.AddNewUser(txtUserName.Text, txtPassword.Text, GetUserRight()))
                {
                    dtgUser.Rows.Add(new object[] { txtUserName.Text, txtPassword.Text });
                }
            }
            else if (sender.Equals(btnDeleteUser))
            {
                if (dtgUser.SelectedRows.Count > 0)
                {
                    var m = MessageHandler.Question("Bạn có thật sự muốn xóa ?");
                    if (m == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (DBAccess.DeleteUser((string)dtgUser.SelectedRows[0].Cells[0].Value))
                        {
                            dtgUser.Rows.Remove(dtgUser.SelectedRows[0]);
                            if (dtgUser.Rows.Count == 0)
                            {
                                txtUserName.Text = "";
                                txtPassword.Text = "";
                                for (int j = 0; j < treeRights.Nodes.Count; j++)
                                {
                                    treeRights.Nodes[j].CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                                }
                                //chkAdd.Checked = false;
                                //chkEdit.Checked = false;
                                //chkDelete.Checked = false;
                                //chkChangeScenario.Checked = false;
                                //chkUserManagement.Checked = false;
                            }
                        }
                    }
                }
            }
            else if (sender.Equals(btnUpdateUserRight))
            {
                if (dtgUser.SelectedRows.Count > 0)
                {
                    var m = MessageHandler.Question("Bạn có thực sự muốn đổi quyển truy cập phần mềm ?");
                    if (m == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (DBAccess.UpdateUserRights((string)dtgUser.SelectedRows[0].Cells[0].Value, GetUserRight()))
                        {
                            // MessageHandler.Inform("Cập nhật thành công !");
                        }
                        else
                        {
                            MessageHandler.Error("Có lỗi xảy ra ! Thử khởi động lại phần mềm !");
                        }
                    }
                }
            }
            else if (sender.Equals(btnUserAction))
            {
                //FrmUserAction f = new FrmUserAction();
                //f.ShowDialog();
            }
        }

        private void chkShowPassword_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = char.MinValue;
                dtgUser.Columns[1].FormatString = "";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                dtgUser.Columns[1].FormatString = "***********";
            }
        }

        private void dtgUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgUser.SelectedRows.Count > 0)
            {
                txtUserName.Text = (string)dtgUser.SelectedRows[0].Cells[0].Value;
                txtPassword.Text = (string)dtgUser.SelectedRows[0].Cells[1].Value;
                for (int j = 0; j < treeRights.Nodes.Count; j++)
                {
                    treeRights.Nodes[j].CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                }
                //chkAdd.Checked = false;
                //chkEdit.Checked = false;
                //chkDelete.Checked = false;
                //chkChangeScenario.Checked = false;
                //chkUserManagement.Checked = false;
                List<int> rights = DBAccess.GetUserRight((string)dtgUser.SelectedRows[0].Cells[0].Value, (string)dtgUser.SelectedRows[0].Cells[1].Value);
                for (int j = 0; j < rights.Count; j++)
                {
                    switch (rights[j])
                    {
                        case 0:
                            treeRights.Nodes[1].Nodes["chkAdd"].Checked = true;
                            // chkAdd.Checked = true;
                            break;
                        case 1:
                            treeRights.Nodes[1].Nodes["chkEdit"].Checked = true;
                            // chkEdit.Checked = true;
                            break;
                        case 2:
                            treeRights.Nodes[1].Nodes["chkDelete"].Checked = true;
                            //  chkDelete.Checked = true;
                            break;
                        case 3:
                            treeRights.Nodes["chkChangeScenario"].Checked = true;
                            //  chkChangeScenario.Checked = true;
                            break;
                        case 4:
                            treeRights.Nodes["chkUserManagement"].Checked = true;
                            //  chkUserManagement.Checked = true;
                            break;
                    }
                }
            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                for (int j = 0; j < treeRights.Nodes.Count; j++)
                {
                    treeRights.Nodes[j].CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                }
            }

        }

        private List<int> GetUserRight()
        {
            List<int> res = new List<int>();
            //if (chkAdd.Checked) res.Add(0);
            //if (chkEdit.Checked) res.Add(1);
            //if (chkDelete.Checked) res.Add(2);
            //if (chkChangeScenario.Checked) res.Add(3);
            //if (chkUserManagement.Checked) res.Add(4);

            if (treeRights.Nodes[1].Nodes["chkAdd"].Checked) res.Add(0);
            if (treeRights.Nodes[1].Nodes["chkEdit"].Checked) res.Add(1);
            if (treeRights.Nodes[1].Nodes["chkDelete"].Checked) res.Add(2);
            if (treeRights.Nodes["chkChangeScenario"].Checked) res.Add(3);
            if (treeRights.Nodes["chkUserManagement"].Checked) res.Add(4);

            return res;
        }

        private void dtgUser_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9.75);
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (sender.Equals(txtUserName))
                {
                    txtPassword.Focus();
                }
                else if (sender.Equals(txtPassword))
                {
                    btnAddUser.Focus();
                }
            }
        }


    }
}

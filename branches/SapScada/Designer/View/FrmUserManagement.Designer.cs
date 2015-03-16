namespace Designer.View
{
    partial class FrmUserManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.RadTreeNode radTreeNode7 = new Telerik.WinControls.UI.RadTreeNode();
            Telerik.WinControls.UI.RadTreeNode radTreeNode8 = new Telerik.WinControls.UI.RadTreeNode();
            Telerik.WinControls.UI.RadTreeNode radTreeNode9 = new Telerik.WinControls.UI.RadTreeNode();
            Telerik.WinControls.UI.RadTreeNode radTreeNode10 = new Telerik.WinControls.UI.RadTreeNode();
            Telerik.WinControls.UI.RadTreeNode radTreeNode11 = new Telerik.WinControls.UI.RadTreeNode();
            Telerik.WinControls.UI.RadTreeNode radTreeNode12 = new Telerik.WinControls.UI.RadTreeNode();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManagement));
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnUserAction = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.treeRights = new Telerik.WinControls.UI.RadTreeView();
            this.btnUpdateUserRight = new Telerik.WinControls.UI.RadButton();
            this.chkShowPassword = new Telerik.WinControls.UI.RadCheckBox();
            this.dtgUser = new Telerik.WinControls.UI.RadGridView();
            this.btnDeleteUser = new Telerik.WinControls.UI.RadButton();
            this.btnAddUser = new Telerik.WinControls.UI.RadButton();
            this.txtPassword = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtUserName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeRights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateUserRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnUserAction);
            this.radPanel1.Controls.Add(this.radGroupBox2);
            this.radPanel1.Controls.Add(this.chkShowPassword);
            this.radPanel1.Controls.Add(this.dtgUser);
            this.radPanel1.Controls.Add(this.btnDeleteUser);
            this.radPanel1.Controls.Add(this.btnAddUser);
            this.radPanel1.Controls.Add(this.txtPassword);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.txtUserName);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPanel1.Location = new System.Drawing.Point(3, 3);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.radPanel1.Size = new System.Drawing.Size(477, 374);
            this.radPanel1.TabIndex = 3;
            // 
            // btnUserAction
            // 
            this.btnUserAction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserAction.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUserAction.Location = new System.Drawing.Point(10, 342);
            this.btnUserAction.Name = "btnUserAction";
            this.btnUserAction.Size = new System.Drawing.Size(168, 24);
            this.btnUserAction.TabIndex = 18;
            this.btnUserAction.Text = "Xem lịch sử vận hành ";
            this.btnUserAction.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserAction.Visible = false;
            this.btnUserAction.Click += new System.EventHandler(this.Button_Click);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.treeRights);
            this.radGroupBox2.Controls.Add(this.btnUpdateUserRight);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.HeaderText = "Quyền truy cập";
            this.radGroupBox2.Location = new System.Drawing.Point(256, 10);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(3, 25, 3, 40);
            this.radGroupBox2.Size = new System.Drawing.Size(210, 326);
            this.radGroupBox2.TabIndex = 17;
            this.radGroupBox2.Text = "Quyền truy cập";
            // 
            // treeRights
            // 
            this.treeRights.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.treeRights.CheckBoxes = true;
            this.treeRights.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRights.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeRights.ForeColor = System.Drawing.Color.Black;
            this.treeRights.Location = new System.Drawing.Point(3, 25);
            this.treeRights.Name = "treeRights";
            radTreeNode7.CheckType = Telerik.WinControls.UI.CheckType.CheckBox;
            radTreeNode7.Expanded = true;
            radTreeNode7.Name = "chkUserManagement";
            radTreeNode7.Text = "Quản lý người dùng";
            radTreeNode8.CheckType = Telerik.WinControls.UI.CheckType.CheckBox;
            radTreeNode8.Expanded = true;
            radTreeNode8.Name = "Node2";
            radTreeNode9.CheckType = Telerik.WinControls.UI.CheckType.CheckBox;
            radTreeNode9.Name = "chkAdd";
            radTreeNode9.Text = "Thêm dữ liệu";
            radTreeNode10.CheckType = Telerik.WinControls.UI.CheckType.CheckBox;
            radTreeNode10.Name = "chkEdit";
            radTreeNode10.Text = "Sửa dữ liệu";
            radTreeNode11.CheckType = Telerik.WinControls.UI.CheckType.CheckBox;
            radTreeNode11.Name = "chkDelete";
            radTreeNode11.Text = "Xóa dữ liệu";
            radTreeNode8.Nodes.AddRange(new Telerik.WinControls.UI.RadTreeNode[] {
            radTreeNode9,
            radTreeNode10,
            radTreeNode11});
            radTreeNode8.Text = "Cài đặt";
            radTreeNode12.CheckType = Telerik.WinControls.UI.CheckType.CheckBox;
            radTreeNode12.Name = "chkChangeScenario";
            radTreeNode12.Text = "Vận hành";
            this.treeRights.Nodes.AddRange(new Telerik.WinControls.UI.RadTreeNode[] {
            radTreeNode7,
            radTreeNode8,
            radTreeNode12});
            this.treeRights.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.treeRights.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeRights.Size = new System.Drawing.Size(204, 261);
            this.treeRights.SpacingBetweenNodes = 20;
            this.treeRights.TabIndex = 0;
            this.treeRights.Text = "radTreeView1";
            this.treeRights.TriStateMode = true;
            // 
            // btnUpdateUserRight
            // 
            this.btnUpdateUserRight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUserRight.Image = global::Designer.Properties.Resources.Save;
            this.btnUpdateUserRight.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdateUserRight.Location = new System.Drawing.Point(45, 294);
            this.btnUpdateUserRight.Name = "btnUpdateUserRight";
            this.btnUpdateUserRight.Size = new System.Drawing.Size(121, 24);
            this.btnUpdateUserRight.TabIndex = 6;
            this.btnUpdateUserRight.Text = "Cập nhật";
            this.btnUpdateUserRight.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateUserRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateUserRight.Click += new System.EventHandler(this.Button_Click);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowPassword.Location = new System.Drawing.Point(10, 107);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(107, 21);
            this.chkShowPassword.TabIndex = 3;
            this.chkShowPassword.Text = "Hiện mật khẩu";
            this.chkShowPassword.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkShowPassword_ToggleStateChanged);
            // 
            // dtgUser
            // 
            this.dtgUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgUser.Location = new System.Drawing.Point(10, 162);
            // 
            // dtgUser
            // 
            this.dtgUser.MasterTemplate.AllowColumnReorder = false;
            this.dtgUser.MasterTemplate.AllowColumnResize = false;
            this.dtgUser.MasterTemplate.AllowDragToGroup = false;
            this.dtgUser.MasterTemplate.AllowRowResize = false;
            this.dtgUser.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn3.HeaderText = "Tên";
            gridViewTextBoxColumn3.Name = "column1";
            gridViewTextBoxColumn3.Width = 111;
            gridViewTextBoxColumn4.FormatString = "***********";
            gridViewTextBoxColumn4.HeaderText = "Mật khẩu";
            gridViewTextBoxColumn4.Name = "column2";
            gridViewTextBoxColumn4.Width = 109;
            this.dtgUser.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dtgUser.MasterTemplate.EnableGrouping = false;
            this.dtgUser.Name = "dtgUser";
            this.dtgUser.ReadOnly = true;
            this.dtgUser.Size = new System.Drawing.Size(240, 174);
            this.dtgUser.TabIndex = 16;
            this.dtgUser.Text = "radGridView3";
            this.dtgUser.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dtgUser_RowFormatting);
            this.dtgUser.SelectionChanged += new System.EventHandler(this.dtgUser_SelectionChanged);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.Image = global::Designer.Properties.Resources.Delete;
            this.btnDeleteUser.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteUser.Location = new System.Drawing.Point(135, 132);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(115, 24);
            this.btnDeleteUser.TabIndex = 5;
            this.btnDeleteUser.Text = "Xóa";
            this.btnDeleteUser.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteUser.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddUser.Location = new System.Drawing.Point(10, 132);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(115, 24);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Thêm";
            this.btnAddUser.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddUser.Click += new System.EventHandler(this.Button_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(10, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(240, 23);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(10, 59);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(69, 21);
            this.radLabel2.TabIndex = 11;
            this.radLabel2.Text = "Mật khẩu :";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(10, 31);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(240, 23);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(10, 10);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(102, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Tên đăng nhập :";
            // 
            // FrmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 380);
            this.Controls.Add(this.radPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUserManagement";
            this.Padding = new System.Windows.Forms.Padding(3);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Quản lý người dùng";
            this.Load += new System.EventHandler(this.FrmUserManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUserAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeRights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateUserRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadTextBox txtPassword;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtUserName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnDeleteUser;
        private Telerik.WinControls.UI.RadButton btnAddUser;
        private Telerik.WinControls.UI.RadGridView dtgUser;
        private Telerik.WinControls.UI.RadButton btnUpdateUserRight;
        private Telerik.WinControls.UI.RadCheckBox chkShowPassword;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTreeView treeRights;
        private Telerik.WinControls.UI.RadButton btnUserAction;
    }
}
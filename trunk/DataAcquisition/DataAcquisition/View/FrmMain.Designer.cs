namespace DataAcquisition.View
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.lbSpentTime = new Telerik.WinControls.UI.RadLabelElement();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.lbStatus = new Telerik.WinControls.UI.RadLabelElement();
            this.dtgInfo = new Telerik.WinControls.UI.RadGridView();
            this.menuSetting = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuReset = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuHide = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuAbout = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuMain = new Telerik.WinControls.UI.RadMenu();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.lbSpentTime,
            this.commandBarSeparator1,
            this.lbStatus});
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 332);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(719, 27);
            this.radStatusStrip1.TabIndex = 1;
            this.radStatusStrip1.Text = "radStatusStrip1";
            this.radStatusStrip1.ThemeName = "TelerikMetro";
            // 
            // lbSpentTime
            // 
            this.lbSpentTime.AccessibleDescription = "Spent time :";
            this.lbSpentTime.AccessibleName = "Spent time :";
            this.lbSpentTime.Name = "lbSpentTime";
            this.radStatusStrip1.SetSpring(this.lbSpentTime, false);
            this.lbSpentTime.Text = "Spent time :";
            this.lbSpentTime.TextWrap = true;
            this.lbSpentTime.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
            this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.radStatusStrip1.SetSpring(this.commandBarSeparator1, false);
            this.commandBarSeparator1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // lbStatus
            // 
            this.lbStatus.AccessibleDescription = "Status";
            this.lbStatus.AccessibleName = "Status";
            this.lbStatus.Name = "lbStatus";
            this.radStatusStrip1.SetSpring(this.lbStatus, false);
            this.lbStatus.Text = "Status";
            this.lbStatus.TextWrap = true;
            this.lbStatus.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // dtgInfo
            // 
            this.dtgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dtgInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtgInfo.ForeColor = System.Drawing.Color.Black;
            this.dtgInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgInfo.Location = new System.Drawing.Point(0, 84);
            // 
            // dtgInfo
            // 
            this.dtgInfo.MasterTemplate.AllowAddNewRow = false;
            this.dtgInfo.MasterTemplate.AllowDeleteRow = false;
            this.dtgInfo.MasterTemplate.AllowEditRow = false;
            this.dtgInfo.MasterTemplate.AllowRowResize = false;
            this.dtgInfo.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Driver";
            gridViewTextBoxColumn1.Name = "colDriverName";
            gridViewTextBoxColumn1.Width = 158;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.HeaderText = "Port";
            gridViewDecimalColumn1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn1.Name = "colPort";
            gridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn1.Width = 133;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Status";
            gridViewTextBoxColumn2.Name = "colStatus";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 150;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.HeaderText = "Send (KB)";
            gridViewDecimalColumn2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn2.Name = "colSend";
            gridViewDecimalColumn2.ThousandsSeparator = true;
            gridViewDecimalColumn2.Width = 134;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.HeaderText = "Receive (KB)";
            gridViewDecimalColumn3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn3.Name = "colReceive";
            gridViewDecimalColumn3.ThousandsSeparator = true;
            gridViewDecimalColumn3.Width = 128;
            gridViewDecimalColumn4.EnableExpressionEditor = false;
            gridViewDecimalColumn4.HeaderText = "Driver Type";
            gridViewDecimalColumn4.IsVisible = false;
            gridViewDecimalColumn4.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn4.Name = "colDriverType";
            gridViewDecimalColumn4.VisibleInColumnChooser = false;
            gridViewDecimalColumn4.Width = 46;
            this.dtgInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3,
            gridViewDecimalColumn4});
            this.dtgInfo.MasterTemplate.EnableGrouping = false;
            this.dtgInfo.Name = "dtgInfo";
            this.dtgInfo.ReadOnly = true;
            this.dtgInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgInfo.Size = new System.Drawing.Size(719, 248);
            this.dtgInfo.TabIndex = 2;
            this.dtgInfo.Text = "dtgInfo";
            this.dtgInfo.ThemeName = "TelerikMetro";
            this.dtgInfo.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dtgInfo_RowFormatting);
            // 
            // menuSetting
            // 
            this.menuSetting.AccessibleDescription = "Setting";
            this.menuSetting.AccessibleName = "Setting";
            // 
            // 
            // 
            this.menuSetting.ButtonElement.AccessibleDescription = "Setting";
            this.menuSetting.ButtonElement.AccessibleName = "Setting";
            this.menuSetting.Image = global::DataAcquisition.Properties.Resources.Setting;
            this.menuSetting.Name = "menuSetting";
            this.menuSetting.Text = "Setting";
            this.menuSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuSetting.Click += new System.EventHandler(this.Button_Click);
            // 
            // menuReset
            // 
            this.menuReset.AccessibleDescription = "Reset";
            this.menuReset.AccessibleName = "Reset";
            // 
            // 
            // 
            this.menuReset.ButtonElement.AccessibleDescription = "Reset";
            this.menuReset.ButtonElement.AccessibleName = "Reset";
            this.menuReset.Image = global::DataAcquisition.Properties.Resources.Refresh;
            this.menuReset.Name = "menuReset";
            this.menuReset.Text = "Reset";
            this.menuReset.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuReset.Click += new System.EventHandler(this.Button_Click);
            // 
            // menuHide
            // 
            this.menuHide.AccessibleDescription = "Show/Hide (F3)";
            this.menuHide.AccessibleName = "Show/Hide (F3)";
            // 
            // 
            // 
            this.menuHide.ButtonElement.AccessibleDescription = "Show/Hide (F3)";
            this.menuHide.ButtonElement.AccessibleName = "Show/Hide (F3)";
            this.menuHide.Image = global::DataAcquisition.Properties.Resources.Show;
            this.menuHide.Name = "menuHide";
            this.menuHide.Text = "Hide (F3)";
            this.menuHide.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuHide.Click += new System.EventHandler(this.Button_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.AccessibleDescription = "About";
            this.menuAbout.AccessibleName = "About";
            // 
            // 
            // 
            this.menuAbout.ButtonElement.AccessibleDescription = "About";
            this.menuAbout.ButtonElement.AccessibleName = "About";
            this.menuAbout.Image = global::DataAcquisition.Properties.Resources.Info;
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Text = "About";
            this.menuAbout.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuAbout.Click += new System.EventHandler(this.Button_Click);
            // 
            // menuMain
            // 
            this.menuMain.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuMain.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuSetting,
            this.menuReset,
            this.menuHide,
            this.menuAbout});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.menuMain.Size = new System.Drawing.Size(719, 44);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "radMenu1";
            this.menuMain.ThemeName = "TelerikMetro";
            ((Telerik.WinControls.UI.RadMenuElement)(this.menuMain.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.menuMain.GetChildAt(0).GetChildAt(3))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.menuMain.GetChildAt(0).GetChildAt(3))).BottomWidth = 1F;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.SpringGreen;
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPanel1.Location = new System.Drawing.Point(0, 44);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(719, 40);
            this.radPanel1.TabIndex = 3;
            this.radPanel1.Text = "DATA ACQUISITION";
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPanel1.ThemeName = "TelerikMetro";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 359);
            this.Controls.Add(this.dtgInfo);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.menuMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Acquisition";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadLabelElement lbStatus;
        private Telerik.WinControls.UI.RadGridView dtgInfo;
        private Telerik.WinControls.UI.RadMenuButtonItem menuSetting;
        private Telerik.WinControls.UI.RadMenuButtonItem menuReset;
        private Telerik.WinControls.UI.RadMenuButtonItem menuHide;
        private Telerik.WinControls.UI.RadMenuButtonItem menuAbout;
        private Telerik.WinControls.UI.RadMenu menuMain;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Timer timer1;
        private Telerik.WinControls.UI.RadLabelElement lbSpentTime;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    }
}

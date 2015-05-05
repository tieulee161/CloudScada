namespace Designer.View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.customShape1 = new Telerik.WinControls.OldShapeEditor.CustomShape();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.lbUser = new Telerik.WinControls.UI.RadLabelElement();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.menuFile = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.menuNew = new Telerik.WinControls.UI.RadMenuItem();
            this.menuOpen = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.menuExit = new Telerik.WinControls.UI.RadMenuItem();
            this.menuDevice = new Telerik.WinControls.UI.RadMenuItem();
            this.menuDeviceSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.menuTag = new Telerik.WinControls.UI.RadMenuItem();
            this.menuTagSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.menuServer = new Telerik.WinControls.UI.RadMenuItem();
            this.menuServerSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.menuAlarm = new Telerik.WinControls.UI.RadMenuItem();
            this.menuAlarmSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.menuTrend = new Telerik.WinControls.UI.RadMenuItem();
            this.menuTrendSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.menuReport = new Telerik.WinControls.UI.RadMenuItem();
            this.menuReportSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.menuGraphic = new Telerik.WinControls.UI.RadMenuItem();
            this.menuUser = new Telerik.WinControls.UI.RadMenuItem();
            this.menuLogin = new Telerik.WinControls.UI.RadMenuItem();
            this.menuLogout = new Telerik.WinControls.UI.RadMenuItem();
            this.menuChangePassword = new Telerik.WinControls.UI.RadMenuItem();
            this.menuUserManagement = new Telerik.WinControls.UI.RadMenuItem();
            this.menuHelp = new Telerik.WinControls.UI.RadMenuItem();
            this.menuManual = new Telerik.WinControls.UI.RadMenuItem();
            this.menuAbout = new Telerik.WinControls.UI.RadMenuItem();
            this.menuStart = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuStop = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // customShape1
            // 
            this.customShape1.Dimension = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // radDock1
            // 
            this.radDock1.AutoDetectMdiChildren = true;
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 65);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radDock1.Size = new System.Drawing.Size(1144, 370);
            this.radDock1.TabIndex = 0;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            // 
            // documentContainer1
            // 
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.lbUser});
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 435);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(1144, 27);
            this.radStatusStrip1.TabIndex = 3;
            this.radStatusStrip1.Text = "radStatusStrip1";
            // 
            // lbUser
            // 
            this.lbUser.AccessibleDescription = "Đăng nhập : Chỉ xem";
            this.lbUser.AccessibleName = "Đăng nhập : Chỉ xem";
            this.lbUser.Name = "lbUser";
            this.radStatusStrip1.SetSpring(this.lbUser, false);
            this.lbUser.Text = "Đăng nhập : Chỉ xem";
            this.lbUser.TextWrap = true;
            this.lbUser.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenu1
            // 
            this.radMenu1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuFile,
            this.menuDevice,
            this.menuTag,
            this.menuServer,
            this.menuAlarm,
            this.menuTrend,
            this.menuReport,
            this.menuGraphic,
            this.menuUser,
            this.menuHelp,
            this.menuStart,
            this.menuStop});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(1144, 65);
            this.radMenu1.TabIndex = 2;
            this.radMenu1.Text = "User";
            // 
            // menuFile
            // 
            this.menuFile.AccessibleDescription = "File";
            this.menuFile.AccessibleName = "File";
            this.menuFile.Image = global::Designer.Properties.Resources.File;
            this.menuFile.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuSeparatorItem2,
            this.menuNew,
            this.menuOpen,
            this.radMenuSeparatorItem1,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Text = "FILE";
            this.menuFile.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.AccessibleDescription = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.AccessibleName = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuNew
            // 
            this.menuNew.AccessibleDescription = "New";
            this.menuNew.AccessibleName = "New";
            this.menuNew.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuNew.KeyTip = "N";
            this.menuNew.Name = "menuNew";
            this.menuNew.Text = "New";
            this.menuNew.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuOpen
            // 
            this.menuOpen.AccessibleDescription = "Open";
            this.menuOpen.AccessibleName = "Open";
            this.menuOpen.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Text = "Open";
            this.menuOpen.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.AccessibleDescription = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.AccessibleName = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuExit
            // 
            this.menuExit.AccessibleDescription = "Exit";
            this.menuExit.AccessibleName = "Exit";
            this.menuExit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuExit.Name = "menuExit";
            this.menuExit.Text = "Exit";
            this.menuExit.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuDevice
            // 
            this.menuDevice.AccessibleDescription = "DEVICE";
            this.menuDevice.AccessibleName = "DEVICE";
            this.menuDevice.Image = ((System.Drawing.Image)(resources.GetObject("menuDevice.Image")));
            this.menuDevice.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuDeviceSetting});
            this.menuDevice.Name = "menuDevice";
            this.menuDevice.Text = "DEVICE";
            this.menuDevice.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuDeviceSetting
            // 
            this.menuDeviceSetting.AccessibleDescription = "Setting";
            this.menuDeviceSetting.AccessibleName = "Setting";
            this.menuDeviceSetting.DescriptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.menuDeviceSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuDeviceSetting.Name = "menuDeviceSetting";
            this.menuDeviceSetting.Text = "Setting";
            this.menuDeviceSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuDeviceSetting.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuTag
            // 
            this.menuTag.AccessibleDescription = "TAG";
            this.menuTag.AccessibleName = "TAG";
            this.menuTag.Image = global::Designer.Properties.Resources.Tag;
            this.menuTag.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuTagSetting});
            this.menuTag.Name = "menuTag";
            this.menuTag.Text = "TAG";
            this.menuTag.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuTagSetting
            // 
            this.menuTagSetting.AccessibleDescription = "External";
            this.menuTagSetting.AccessibleName = "External";
            this.menuTagSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuTagSetting.Name = "menuTagSetting";
            this.menuTagSetting.Text = "Setting";
            this.menuTagSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuTagSetting.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuServer
            // 
            this.menuServer.AccessibleDescription = "SERVER";
            this.menuServer.AccessibleName = "SERVER";
            this.menuServer.Image = global::Designer.Properties.Resources.Server;
            this.menuServer.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuServerSetting});
            this.menuServer.Name = "menuServer";
            this.menuServer.Text = "SERVER";
            this.menuServer.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuServerSetting
            // 
            this.menuServerSetting.AccessibleDescription = "Setting";
            this.menuServerSetting.AccessibleName = "Setting";
            this.menuServerSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuServerSetting.Name = "menuServerSetting";
            this.menuServerSetting.Text = "Setting";
            this.menuServerSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuServerSetting.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuAlarm
            // 
            this.menuAlarm.AccessibleDescription = "ALARM";
            this.menuAlarm.AccessibleName = "ALARM";
            this.menuAlarm.Image = global::Designer.Properties.Resources.Alarm;
            this.menuAlarm.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuAlarmSetting});
            this.menuAlarm.Name = "menuAlarm";
            this.menuAlarm.Text = "ALARM";
            this.menuAlarm.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuAlarm.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuAlarmSetting
            // 
            this.menuAlarmSetting.AccessibleDescription = "Setting";
            this.menuAlarmSetting.AccessibleName = "Setting";
            this.menuAlarmSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuAlarmSetting.Name = "menuAlarmSetting";
            this.menuAlarmSetting.Text = "Setting";
            this.menuAlarmSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuTrend
            // 
            this.menuTrend.AccessibleDescription = "TREND";
            this.menuTrend.AccessibleName = "TREND";
            this.menuTrend.Image = global::Designer.Properties.Resources.Trend;
            this.menuTrend.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuTrendSetting});
            this.menuTrend.Name = "menuTrend";
            this.menuTrend.Text = "TREND";
            this.menuTrend.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuTrend.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuTrendSetting
            // 
            this.menuTrendSetting.AccessibleDescription = "Setting";
            this.menuTrendSetting.AccessibleName = "Setting";
            this.menuTrendSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuTrendSetting.Name = "menuTrendSetting";
            this.menuTrendSetting.Text = "Setting";
            this.menuTrendSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuReport
            // 
            this.menuReport.AccessibleDescription = "REPORT";
            this.menuReport.AccessibleName = "REPORT";
            this.menuReport.Image = global::Designer.Properties.Resources.Report;
            this.menuReport.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuReportSetting});
            this.menuReport.Name = "menuReport";
            this.menuReport.Text = "REPORT";
            this.menuReport.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuReportSetting
            // 
            this.menuReportSetting.AccessibleDescription = "Setting";
            this.menuReportSetting.AccessibleName = "Setting";
            this.menuReportSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuReportSetting.Name = "menuReportSetting";
            this.menuReportSetting.Text = "Setting";
            this.menuReportSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuGraphic
            // 
            this.menuGraphic.AccessibleDescription = "GRAPHIC";
            this.menuGraphic.AccessibleName = "GRAPHIC";
            this.menuGraphic.Image = global::Designer.Properties.Resources.Graphic;
            this.menuGraphic.Name = "menuGraphic";
            this.menuGraphic.Text = "GRAPHIC";
            this.menuGraphic.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuGraphic.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuUser
            // 
            this.menuUser.AccessibleDescription = "User";
            this.menuUser.AccessibleName = "User";
            this.menuUser.Image = global::Designer.Properties.Resources.User;
            this.menuUser.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuLogin,
            this.menuLogout,
            this.menuChangePassword,
            this.menuUserManagement});
            this.menuUser.Name = "menuUser";
            this.menuUser.Text = "USER";
            this.menuUser.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuLogin
            // 
            this.menuLogin.AccessibleDescription = "Login";
            this.menuLogin.AccessibleName = "Login";
            this.menuLogin.DescriptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.menuLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuLogin.Name = "menuLogin";
            this.menuLogin.Text = "Login";
            this.menuLogin.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuLogin.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.AccessibleDescription = "Logout";
            this.menuLogout.AccessibleName = "Logout";
            this.menuLogout.DescriptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.menuLogout.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Text = "Logout";
            this.menuLogout.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.menuLogout.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuChangePassword
            // 
            this.menuChangePassword.AccessibleDescription = "Change Password";
            this.menuChangePassword.AccessibleName = "Change Password";
            this.menuChangePassword.Enabled = false;
            this.menuChangePassword.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuChangePassword.Name = "menuChangePassword";
            this.menuChangePassword.Text = "Change Password";
            this.menuChangePassword.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuChangePassword.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuUserManagement
            // 
            this.menuUserManagement.AccessibleDescription = "User Management";
            this.menuUserManagement.AccessibleName = "User Management";
            this.menuUserManagement.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuUserManagement.Name = "menuUserManagement";
            this.menuUserManagement.Text = "User Management";
            this.menuUserManagement.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuUserManagement.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.AccessibleDescription = "HELP";
            this.menuHelp.AccessibleName = "HELP";
            this.menuHelp.Image = global::Designer.Properties.Resources.Help;
            this.menuHelp.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuManual,
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Text = "HELP";
            this.menuHelp.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuManual
            // 
            this.menuManual.AccessibleDescription = "Manual";
            this.menuManual.AccessibleName = "Manual";
            this.menuManual.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuManual.Name = "menuManual";
            this.menuManual.Text = "Manual";
            this.menuManual.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuAbout
            // 
            this.menuAbout.AccessibleDescription = "About";
            this.menuAbout.AccessibleName = "About";
            this.menuAbout.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Text = "About";
            this.menuAbout.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuStart
            // 
            this.menuStart.AccessibleDescription = "Start";
            this.menuStart.AccessibleName = "Start";
            // 
            // 
            // 
            this.menuStart.ButtonElement.AccessibleDescription = "Start";
            this.menuStart.ButtonElement.AccessibleName = "Start";
            this.menuStart.Image = global::Designer.Properties.Resources.Start_Black;
            this.menuStart.Name = "menuStart";
            this.menuStart.Text = "START";
            this.menuStart.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuStart.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuStart.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuStop
            // 
            this.menuStop.AccessibleDescription = "Stop";
            this.menuStop.AccessibleName = "Stop";
            // 
            // 
            // 
            this.menuStop.ButtonElement.AccessibleDescription = "Stop";
            this.menuStop.ButtonElement.AccessibleName = "Stop";
            this.menuStop.Image = global::Designer.Properties.Resources.Stop_Black;
            this.menuStop.Name = "menuStop";
            this.menuStop.Text = "STOP";
            this.menuStop.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.menuStop.Click += new System.EventHandler(this.Menu_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 462);
            this.Controls.Add(this.radDock1);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SAP SCADA";
            this.ThemeName = "Office2013Light";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.OldShapeEditor.CustomShape customShape1;
        private Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.RadMenuItem menuFile;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadMenuItem menuNew;
        private Telerik.WinControls.UI.RadMenuItem menuOpen;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem menuExit;
        private Telerik.WinControls.UI.RadMenuItem menuDevice;
        private Telerik.WinControls.UI.RadMenuItem menuTag;
        private Telerik.WinControls.UI.RadMenuItem menuServer;
        private Telerik.WinControls.UI.RadMenuItem menuAlarm;
        private Telerik.WinControls.UI.RadMenuItem menuTrend;
        private Telerik.WinControls.UI.RadMenuItem menuReport;
        private Telerik.WinControls.UI.RadMenuItem menuHelp;
        private Telerik.WinControls.UI.RadMenuItem menuManual;
        private Telerik.WinControls.UI.RadMenuItem menuAbout;
        private Telerik.WinControls.UI.RadMenuItem menuDeviceSetting;
        private Telerik.WinControls.UI.RadMenuItem menuTagSetting;
        private Telerik.WinControls.UI.RadMenuItem menuServerSetting;
        private Telerik.WinControls.UI.RadMenuItem menuAlarmSetting;
        private Telerik.WinControls.UI.RadMenuItem menuTrendSetting;
        private Telerik.WinControls.UI.RadMenuItem menuReportSetting;
        private Telerik.WinControls.UI.RadMenuItem menuGraphic;
        private Telerik.WinControls.UI.RadMenuButtonItem menuStart;
        private Telerik.WinControls.UI.RadMenuButtonItem menuStop;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
        private Telerik.WinControls.UI.RadMenuItem menuUser;
        private Telerik.WinControls.UI.RadMenuItem menuLogin;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem menuLogout;
        private Telerik.WinControls.UI.RadMenuItem menuChangePassword;
        private Telerik.WinControls.UI.RadMenuItem menuUserManagement;
        private Telerik.WinControls.UI.RadLabelElement lbUser;
        private System.Windows.Forms.Timer timer1;

    }
}

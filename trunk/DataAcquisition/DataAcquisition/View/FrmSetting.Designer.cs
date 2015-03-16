namespace DataAcquisition.View
{
    partial class FrmSetting
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn17 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn18 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor5 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn19 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn20 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetting));
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.pageService = new Telerik.WinControls.UI.RadPageViewPage();
            this.txtServerIP = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.btnUpdateService = new Telerik.WinControls.UI.RadButton();
            this.spinOPCServicePort = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.spinVDKServicePort = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.pageVDKPort = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnDeleteVDKPort = new Telerik.WinControls.UI.RadButton();
            this.btnAddVDKPort = new Telerik.WinControls.UI.RadButton();
            this.dtgVDKPort = new Telerik.WinControls.UI.RadGridView();
            this.spinVDKPort = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.pageOPCPort = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnDeleteOPCPort = new Telerik.WinControls.UI.RadButton();
            this.btnAddOPCPort = new Telerik.WinControls.UI.RadButton();
            this.dtgOPCPort = new Telerik.WinControls.UI.RadGridView();
            this.spinOPCPort = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.lbStatus = new Telerik.WinControls.UI.RadLabelElement();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.pageService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinOPCServicePort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVDKServicePort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.pageVDKPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteVDKPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddVDKPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVDKPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVDKPort.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVDKPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.pageOPCPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteOPCPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddOPCPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOPCPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOPCPort.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinOPCPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.pageService);
            this.radPageView1.Controls.Add(this.pageVDKPort);
            this.radPageView1.Controls.Add(this.pageOPCPort);
            this.radPageView1.DefaultPage = this.pageService;
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.pageService;
            this.radPageView1.Size = new System.Drawing.Size(258, 244);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "OPC Port";
            this.radPageView1.ThemeName = "TelerikMetro";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // pageService
            // 
            this.pageService.Controls.Add(this.txtServerIP);
            this.pageService.Controls.Add(this.btnUpdateService);
            this.pageService.Controls.Add(this.spinOPCServicePort);
            this.pageService.Controls.Add(this.radLabel3);
            this.pageService.Controls.Add(this.spinVDKServicePort);
            this.pageService.Controls.Add(this.radLabel2);
            this.pageService.Controls.Add(this.radLabel1);
            this.pageService.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.pageService.ItemSize = new System.Drawing.SizeF(54F, 27F);
            this.pageService.Location = new System.Drawing.Point(5, 33);
            this.pageService.Name = "pageService";
            this.pageService.Size = new System.Drawing.Size(248, 206);
            this.pageService.Text = "Service";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtServerIP.Location = new System.Drawing.Point(128, 12);
            this.txtServerIP.MaskType = Telerik.WinControls.UI.MaskType.IP;
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(110, 24);
            this.txtServerIP.TabIndex = 1;
            this.txtServerIP.TabStop = false;
            this.txtServerIP.Text = "   .   .   .   ";
            this.txtServerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtServerIP.ThemeName = "TelerikMetro";
            // 
            // btnUpdateService
            // 
            this.btnUpdateService.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnUpdateService.Image = global::DataAcquisition.Properties.Resources.Save;
            this.btnUpdateService.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdateService.Location = new System.Drawing.Point(69, 158);
            this.btnUpdateService.Name = "btnUpdateService";
            this.btnUpdateService.Size = new System.Drawing.Size(110, 24);
            this.btnUpdateService.TabIndex = 6;
            this.btnUpdateService.Text = "Update";
            this.btnUpdateService.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateService.ThemeName = "TelerikMetro";
            this.btnUpdateService.Click += new System.EventHandler(this.Button_Click);
            // 
            // spinOPCServicePort
            // 
            this.spinOPCServicePort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinOPCServicePort.Location = new System.Drawing.Point(130, 106);
            this.spinOPCServicePort.Maximum = new decimal(new int[] {
            65355,
            0,
            0,
            0});
            this.spinOPCServicePort.Name = "spinOPCServicePort";
            this.spinOPCServicePort.Size = new System.Drawing.Size(108, 24);
            this.spinOPCServicePort.TabIndex = 5;
            this.spinOPCServicePort.TabStop = false;
            this.spinOPCServicePort.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinOPCServicePort.ThemeName = "TelerikMetro";
            this.spinOPCServicePort.Value = new decimal(new int[] {
            8089,
            0,
            0,
            0});
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel3.Location = new System.Drawing.Point(7, 109);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(113, 21);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "OPC Service Port :";
            // 
            // spinVDKServicePort
            // 
            this.spinVDKServicePort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinVDKServicePort.Location = new System.Drawing.Point(130, 59);
            this.spinVDKServicePort.Maximum = new decimal(new int[] {
            65355,
            0,
            0,
            0});
            this.spinVDKServicePort.Name = "spinVDKServicePort";
            this.spinVDKServicePort.Size = new System.Drawing.Size(108, 24);
            this.spinVDKServicePort.TabIndex = 3;
            this.spinVDKServicePort.TabStop = false;
            this.spinVDKServicePort.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinVDKServicePort.ThemeName = "TelerikMetro";
            this.spinVDKServicePort.Value = new decimal(new int[] {
            8087,
            0,
            0,
            0});
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel2.Location = new System.Drawing.Point(7, 59);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(112, 21);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "VDK Service Port :";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel1.Location = new System.Drawing.Point(8, 15);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(65, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Server IP :";
            // 
            // pageVDKPort
            // 
            this.pageVDKPort.Controls.Add(this.btnDeleteVDKPort);
            this.pageVDKPort.Controls.Add(this.btnAddVDKPort);
            this.pageVDKPort.Controls.Add(this.dtgVDKPort);
            this.pageVDKPort.Controls.Add(this.spinVDKPort);
            this.pageVDKPort.Controls.Add(this.radLabel4);
            this.pageVDKPort.ItemSize = new System.Drawing.SizeF(67F, 27F);
            this.pageVDKPort.Location = new System.Drawing.Point(5, 33);
            this.pageVDKPort.Name = "pageVDKPort";
            this.pageVDKPort.Size = new System.Drawing.Size(248, 206);
            this.pageVDKPort.Text = "VDK Port";
            // 
            // btnDeleteVDKPort
            // 
            this.btnDeleteVDKPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnDeleteVDKPort.Image = global::DataAcquisition.Properties.Resources.Delete;
            this.btnDeleteVDKPort.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteVDKPort.Location = new System.Drawing.Point(152, 36);
            this.btnDeleteVDKPort.Name = "btnDeleteVDKPort";
            this.btnDeleteVDKPort.Size = new System.Drawing.Size(89, 24);
            this.btnDeleteVDKPort.TabIndex = 8;
            this.btnDeleteVDKPort.Text = "Delete";
            this.btnDeleteVDKPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteVDKPort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteVDKPort.ThemeName = "TelerikMetro";
            this.btnDeleteVDKPort.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnAddVDKPort
            // 
            this.btnAddVDKPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnAddVDKPort.Image = global::DataAcquisition.Properties.Resources.Add;
            this.btnAddVDKPort.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddVDKPort.Location = new System.Drawing.Point(152, 6);
            this.btnAddVDKPort.Name = "btnAddVDKPort";
            this.btnAddVDKPort.Size = new System.Drawing.Size(89, 24);
            this.btnAddVDKPort.TabIndex = 7;
            this.btnAddVDKPort.Text = "Add";
            this.btnAddVDKPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddVDKPort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddVDKPort.ThemeName = "TelerikMetro";
            this.btnAddVDKPort.Click += new System.EventHandler(this.Button_Click);
            // 
            // dtgVDKPort
            // 
            this.dtgVDKPort.BackColor = System.Drawing.Color.White;
            this.dtgVDKPort.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgVDKPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtgVDKPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgVDKPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgVDKPort.Location = new System.Drawing.Point(7, 36);
            // 
            // 
            // 
            this.dtgVDKPort.MasterTemplate.AllowAddNewRow = false;
            this.dtgVDKPort.MasterTemplate.AllowDeleteRow = false;
            this.dtgVDKPort.MasterTemplate.AllowEditRow = false;
            gridViewDecimalColumn17.EnableExpressionEditor = false;
            gridViewDecimalColumn17.HeaderText = "column1";
            gridViewDecimalColumn17.IsVisible = false;
            gridViewDecimalColumn17.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn17.Name = "colId";
            gridViewDecimalColumn18.EnableExpressionEditor = false;
            gridViewDecimalColumn18.HeaderText = "Port List";
            gridViewDecimalColumn18.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn18.Name = "colPort";
            gridViewDecimalColumn18.ShowUpDownButtons = false;
            gridViewDecimalColumn18.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending;
            gridViewDecimalColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewDecimalColumn18.Width = 101;
            this.dtgVDKPort.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn17,
            gridViewDecimalColumn18});
            this.dtgVDKPort.MasterTemplate.EnableGrouping = false;
            this.dtgVDKPort.MasterTemplate.EnableSorting = false;
            sortDescriptor5.Direction = System.ComponentModel.ListSortDirection.Descending;
            sortDescriptor5.PropertyName = "colPort";
            this.dtgVDKPort.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor5});
            this.dtgVDKPort.Name = "dtgVDKPort";
            this.dtgVDKPort.ReadOnly = true;
            this.dtgVDKPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgVDKPort.Size = new System.Drawing.Size(139, 164);
            this.dtgVDKPort.TabIndex = 5;
            this.dtgVDKPort.Text = "radGridView1";
            this.dtgVDKPort.ThemeName = "TelerikMetro";
            // 
            // spinVDKPort
            // 
            this.spinVDKPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinVDKPort.Location = new System.Drawing.Point(76, 6);
            this.spinVDKPort.Maximum = new decimal(new int[] {
            65355,
            0,
            0,
            0});
            this.spinVDKPort.Name = "spinVDKPort";
            this.spinVDKPort.Size = new System.Drawing.Size(70, 24);
            this.spinVDKPort.TabIndex = 4;
            this.spinVDKPort.TabStop = false;
            this.spinVDKPort.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinVDKPort.ThemeName = "TelerikMetro";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel4.Location = new System.Drawing.Point(3, 9);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(67, 21);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "VDK Port :";
            // 
            // pageOPCPort
            // 
            this.pageOPCPort.Controls.Add(this.btnDeleteOPCPort);
            this.pageOPCPort.Controls.Add(this.btnAddOPCPort);
            this.pageOPCPort.Controls.Add(this.dtgOPCPort);
            this.pageOPCPort.Controls.Add(this.spinOPCPort);
            this.pageOPCPort.Controls.Add(this.radLabel5);
            this.pageOPCPort.ItemSize = new System.Drawing.SizeF(67F, 27F);
            this.pageOPCPort.Location = new System.Drawing.Point(5, 33);
            this.pageOPCPort.Name = "pageOPCPort";
            this.pageOPCPort.Size = new System.Drawing.Size(248, 206);
            this.pageOPCPort.Text = "OPC Port";
            // 
            // btnDeleteOPCPort
            // 
            this.btnDeleteOPCPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnDeleteOPCPort.Image = global::DataAcquisition.Properties.Resources.Delete;
            this.btnDeleteOPCPort.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteOPCPort.Location = new System.Drawing.Point(152, 36);
            this.btnDeleteOPCPort.Name = "btnDeleteOPCPort";
            this.btnDeleteOPCPort.Size = new System.Drawing.Size(89, 24);
            this.btnDeleteOPCPort.TabIndex = 13;
            this.btnDeleteOPCPort.Text = "Delete";
            this.btnDeleteOPCPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteOPCPort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteOPCPort.ThemeName = "TelerikMetro";
            this.btnDeleteOPCPort.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnAddOPCPort
            // 
            this.btnAddOPCPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnAddOPCPort.Image = global::DataAcquisition.Properties.Resources.Add;
            this.btnAddOPCPort.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddOPCPort.Location = new System.Drawing.Point(152, 6);
            this.btnAddOPCPort.Name = "btnAddOPCPort";
            this.btnAddOPCPort.Size = new System.Drawing.Size(89, 24);
            this.btnAddOPCPort.TabIndex = 12;
            this.btnAddOPCPort.Text = "Add";
            this.btnAddOPCPort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddOPCPort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddOPCPort.ThemeName = "TelerikMetro";
            this.btnAddOPCPort.Click += new System.EventHandler(this.Button_Click);
            // 
            // dtgOPCPort
            // 
            this.dtgOPCPort.Location = new System.Drawing.Point(7, 36);
            // 
            // 
            // 
            this.dtgOPCPort.MasterTemplate.AllowAddNewRow = false;
            this.dtgOPCPort.MasterTemplate.AllowDeleteRow = false;
            this.dtgOPCPort.MasterTemplate.AllowEditRow = false;
            gridViewDecimalColumn19.HeaderText = "column1";
            gridViewDecimalColumn19.IsVisible = false;
            gridViewDecimalColumn19.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn19.Name = "colId";
            gridViewDecimalColumn20.HeaderText = "Port List";
            gridViewDecimalColumn20.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn20.Name = "colPort";
            gridViewDecimalColumn20.ShowUpDownButtons = false;
            gridViewDecimalColumn20.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            gridViewDecimalColumn20.Width = 101;
            this.dtgOPCPort.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn19,
            gridViewDecimalColumn20});
            this.dtgOPCPort.MasterTemplate.EnableGrouping = false;
            this.dtgOPCPort.Name = "dtgOPCPort";
            this.dtgOPCPort.ReadOnly = true;
            this.dtgOPCPort.Size = new System.Drawing.Size(139, 164);
            this.dtgOPCPort.TabIndex = 11;
            this.dtgOPCPort.Text = "radGridView2";
            this.dtgOPCPort.ThemeName = "TelerikMetro";
            // 
            // spinOPCPort
            // 
            this.spinOPCPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinOPCPort.Location = new System.Drawing.Point(76, 6);
            this.spinOPCPort.Maximum = new decimal(new int[] {
            65355,
            0,
            0,
            0});
            this.spinOPCPort.Name = "spinOPCPort";
            this.spinOPCPort.Size = new System.Drawing.Size(70, 24);
            this.spinOPCPort.TabIndex = 10;
            this.spinOPCPort.TabStop = false;
            this.spinOPCPort.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinOPCPort.ThemeName = "TelerikMetro";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel5.Location = new System.Drawing.Point(3, 9);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(67, 21);
            this.radLabel5.TabIndex = 9;
            this.radLabel5.Text = "OPC Port :";
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.lbStatus});
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 244);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(258, 25);
            this.radStatusStrip1.TabIndex = 1;
            this.radStatusStrip1.Text = "radStatusStrip1";
            this.radStatusStrip1.ThemeName = "TelerikMetro";
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
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 269);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.radStatusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSetting";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.pageService.ResumeLayout(false);
            this.pageService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinOPCServicePort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVDKServicePort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.pageVDKPort.ResumeLayout(false);
            this.pageVDKPort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteVDKPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddVDKPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVDKPort.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVDKPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVDKPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.pageOPCPort.ResumeLayout(false);
            this.pageOPCPort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteOPCPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddOPCPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOPCPort.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOPCPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinOPCPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage pageService;
        private Telerik.WinControls.UI.RadPageViewPage pageVDKPort;
        private Telerik.WinControls.UI.RadMaskedEditBox txtServerIP;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadSpinEditor spinOPCServicePort;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadSpinEditor spinVDKServicePort;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnUpdateService;
        private Telerik.WinControls.UI.RadSpinEditor spinVDKPort;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton btnDeleteVDKPort;
        private Telerik.WinControls.UI.RadButton btnAddVDKPort;
        private Telerik.WinControls.UI.RadGridView dtgVDKPort;
        private Telerik.WinControls.UI.RadPageViewPage pageOPCPort;
        private Telerik.WinControls.UI.RadButton btnDeleteOPCPort;
        private Telerik.WinControls.UI.RadButton btnAddOPCPort;
        private Telerik.WinControls.UI.RadGridView dtgOPCPort;
        private Telerik.WinControls.UI.RadSpinEditor spinOPCPort;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadLabelElement lbStatus;
    }
}

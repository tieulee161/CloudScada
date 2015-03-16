namespace Designer.View
{
    partial class UCAlarm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn4 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.pageIncoming = new Telerik.WinControls.UI.RadPageViewPage();
            this.dtgIncoming = new Telerik.WinControls.UI.RadGridView();
            this.pageConfirmed = new Telerik.WinControls.UI.RadPageViewPage();
            this.dtgConfirmed = new Telerik.WinControls.UI.RadGridView();
            this.pageOutgoing = new Telerik.WinControls.UI.RadPageViewPage();
            this.dtgAll = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.cbbxDevice = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dateTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dateFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.pageIncoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIncoming)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIncoming.MasterTemplate)).BeginInit();
            this.pageConfirmed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfirmed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfirmed.MasterTemplate)).BeginInit();
            this.pageOutgoing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAll.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.pageIncoming);
            this.radPageView1.Controls.Add(this.pageConfirmed);
            this.radPageView1.Controls.Add(this.pageOutgoing);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.pageOutgoing;
            this.radPageView1.Size = new System.Drawing.Size(1275, 603);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            // 
            // pageIncoming
            // 
            this.pageIncoming.Controls.Add(this.dtgIncoming);
            this.pageIncoming.ItemSize = new System.Drawing.SizeF(93F, 29F);
            this.pageIncoming.Location = new System.Drawing.Point(10, 38);
            this.pageIncoming.Name = "pageIncoming";
            this.pageIncoming.Size = new System.Drawing.Size(1254, 554);
            this.pageIncoming.Text = "Cảnh báo mới";
            // 
            // dtgIncoming
            // 
            this.dtgIncoming.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.dtgIncoming.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgIncoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgIncoming.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtgIncoming.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgIncoming.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgIncoming.Location = new System.Drawing.Point(0, 0);
            // 
            // dtgIncoming
            // 
            this.dtgIncoming.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dtgIncoming.MasterTemplate.AllowAddNewRow = false;
            this.dtgIncoming.MasterTemplate.AllowCellContextMenu = false;
            this.dtgIncoming.MasterTemplate.AllowColumnReorder = false;
            this.dtgIncoming.MasterTemplate.AllowDeleteRow = false;
            this.dtgIncoming.MasterTemplate.AllowRowResize = false;
            this.dtgIncoming.MasterTemplate.AllowSearchRow = true;
            this.dtgIncoming.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DecimalPlaces = 0;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.HeaderText = "Id";
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn1.Name = "colId";
            gridViewDecimalColumn1.Width = 239;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Giao lộ";
            gridViewTextBoxColumn1.Name = "colJunction";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 341;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Tên cảnh báo";
            gridViewTextBoxColumn2.Name = "colName";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 411;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn1.HeaderText = "Thời điểm cảnh báo";
            gridViewDateTimeColumn1.Name = "colTimeStamp";
            gridViewDateTimeColumn1.ReadOnly = true;
            gridViewDateTimeColumn1.Width = 237;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.HeaderText = "Giá trị";
            gridViewComboBoxColumn1.Name = "colValue";
            gridViewComboBoxColumn1.Width = 127;
            gridViewCheckBoxColumn1.Checked = Telerik.WinControls.Enumerations.ToggleState.Off;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.EnableHeaderCheckBox = false;
            gridViewCheckBoxColumn1.HeaderText = "Xác nhận";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colConfirm";
            gridViewCheckBoxColumn1.Width = 122;
            this.dtgIncoming.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDateTimeColumn1,
            gridViewComboBoxColumn1,
            gridViewCheckBoxColumn1});
            this.dtgIncoming.Name = "dtgIncoming";
            this.dtgIncoming.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgIncoming.Size = new System.Drawing.Size(1254, 554);
            this.dtgIncoming.TabIndex = 0;
            this.dtgIncoming.Text = "radGridView1";
            // 
            // pageConfirmed
            // 
            this.pageConfirmed.Controls.Add(this.dtgConfirmed);
            this.pageConfirmed.ItemSize = new System.Drawing.SizeF(137F, 29F);
            this.pageConfirmed.Location = new System.Drawing.Point(10, 38);
            this.pageConfirmed.Name = "pageConfirmed";
            this.pageConfirmed.Size = new System.Drawing.Size(1254, 554);
            this.pageConfirmed.Text = "Cảnh báo đã xác nhận";
            // 
            // dtgConfirmed
            // 
            this.dtgConfirmed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.dtgConfirmed.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgConfirmed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgConfirmed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtgConfirmed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgConfirmed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgConfirmed.Location = new System.Drawing.Point(0, 0);
            // 
            // dtgConfirmed
            // 
            this.dtgConfirmed.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dtgConfirmed.MasterTemplate.AllowAddNewRow = false;
            this.dtgConfirmed.MasterTemplate.AllowCellContextMenu = false;
            this.dtgConfirmed.MasterTemplate.AllowColumnReorder = false;
            this.dtgConfirmed.MasterTemplate.AllowDeleteRow = false;
            this.dtgConfirmed.MasterTemplate.AllowRowResize = false;
            this.dtgConfirmed.MasterTemplate.AllowSearchRow = true;
            this.dtgConfirmed.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn2.DecimalPlaces = 0;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.HeaderText = "Id";
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn2.Name = "colId";
            gridViewDecimalColumn2.Width = 239;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "Giao lộ";
            gridViewTextBoxColumn3.Name = "colJunction";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 337;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Tên cảnh báo";
            gridViewTextBoxColumn4.Name = "colName";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 442;
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn2.HeaderText = "Thời điểm cảnh báo";
            gridViewDateTimeColumn2.Name = "colTimeStamp";
            gridViewDateTimeColumn2.ReadOnly = true;
            gridViewDateTimeColumn2.Width = 293;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "Giá trị";
            gridViewTextBoxColumn5.Name = "colValue";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 165;
            this.dtgConfirmed.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn5});
            this.dtgConfirmed.Name = "dtgConfirmed";
            this.dtgConfirmed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgConfirmed.Size = new System.Drawing.Size(1254, 554);
            this.dtgConfirmed.TabIndex = 1;
            this.dtgConfirmed.Text = "radGridView2";
            // 
            // pageOutgoing
            // 
            this.pageOutgoing.Controls.Add(this.dtgAll);
            this.pageOutgoing.Controls.Add(this.radGroupBox1);
            this.pageOutgoing.ItemSize = new System.Drawing.SizeF(123F, 29F);
            this.pageOutgoing.Location = new System.Drawing.Point(10, 38);
            this.pageOutgoing.Name = "pageOutgoing";
            this.pageOutgoing.Size = new System.Drawing.Size(1254, 554);
            this.pageOutgoing.Text = "Tất cả các cảnh báo";
            // 
            // dtgAll
            // 
            this.dtgAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.dtgAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtgAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgAll.Location = new System.Drawing.Point(0, 70);
            // 
            // dtgAll
            // 
            this.dtgAll.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dtgAll.MasterTemplate.AllowAddNewRow = false;
            this.dtgAll.MasterTemplate.AllowCellContextMenu = false;
            this.dtgAll.MasterTemplate.AllowColumnReorder = false;
            this.dtgAll.MasterTemplate.AllowDeleteRow = false;
            this.dtgAll.MasterTemplate.AllowRowResize = false;
            this.dtgAll.MasterTemplate.AllowSearchRow = true;
            this.dtgAll.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn3.DecimalPlaces = 0;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.HeaderText = "Id";
            gridViewDecimalColumn3.IsVisible = false;
            gridViewDecimalColumn3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn3.Name = "colId";
            gridViewDecimalColumn3.Width = 239;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "Giao lộ";
            gridViewTextBoxColumn6.Name = "colJunction";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 306;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Tên cảnh báo";
            gridViewTextBoxColumn7.Name = "colName";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 317;
            gridViewDateTimeColumn3.EnableExpressionEditor = false;
            gridViewDateTimeColumn3.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn3.HeaderText = "Thời điểm cảnh báo";
            gridViewDateTimeColumn3.Name = "colTimeStampOn";
            gridViewDateTimeColumn3.ReadOnly = true;
            gridViewDateTimeColumn3.Width = 255;
            gridViewDateTimeColumn4.EnableExpressionEditor = false;
            gridViewDateTimeColumn4.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn4.HeaderText = "Thời điểm kết thúc";
            gridViewDateTimeColumn4.Name = "colTimeStampOff";
            gridViewDateTimeColumn4.ReadOnly = true;
            gridViewDateTimeColumn4.Width = 208;
            gridViewComboBoxColumn2.EnableExpressionEditor = false;
            gridViewComboBoxColumn2.HeaderText = "Trạng thái";
            gridViewComboBoxColumn2.Name = "colStatus";
            gridViewComboBoxColumn2.Width = 152;
            this.dtgAll.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn3,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewDateTimeColumn3,
            gridViewDateTimeColumn4,
            gridViewComboBoxColumn2});
            this.dtgAll.Name = "dtgAll";
            this.dtgAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgAll.Size = new System.Drawing.Size(1254, 484);
            this.dtgAll.TabIndex = 2;
            this.dtgAll.Text = "radGridView3";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnSearch);
            this.radGroupBox1.Controls.Add(this.cbbxDevice);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.dateTo);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.dateFrom);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radGroupBox1.HeaderText = "Tìm kiếm";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1254, 70);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "Tìm kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(744, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 24);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm kiếm";
            // 
            // cbbxDevice
            // 
            this.cbbxDevice.AllowShowFocusCues = false;
            this.cbbxDevice.AutoCompleteDisplayMember = null;
            this.cbbxDevice.AutoCompleteValueMember = null;
            this.cbbxDevice.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxDevice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbbxDevice.Location = new System.Drawing.Point(466, 30);
            this.cbbxDevice.Name = "cbbxDevice";
            this.cbbxDevice.Size = new System.Drawing.Size(259, 21);
            this.cbbxDevice.TabIndex = 5;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radLabel3.Location = new System.Drawing.Point(409, 31);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(51, 19);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Giao lộ :";
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "dd/MM/yyyy";
            this.dateTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(289, 30);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(101, 21);
            this.dateTo.TabIndex = 3;
            this.dateTo.TabStop = false;
            this.dateTo.Text = "13/01/2015";
            this.dateTo.Value = new System.DateTime(2015, 1, 13, 10, 27, 39, 369);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radLabel1.Location = new System.Drawing.Point(40, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(56, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Từ ngày :";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd/MM/yyyy";
            this.dateFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(102, 30);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(101, 21);
            this.dateFrom.TabIndex = 1;
            this.dateFrom.TabStop = false;
            this.dateFrom.Text = "13/01/2015";
            this.dateFrom.Value = new System.DateTime(2015, 1, 13, 10, 27, 39, 369);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radLabel2.Location = new System.Drawing.Point(218, 31);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(65, 19);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Đến ngày :";
            // 
            // UCAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPageView1);
            this.Name = "UCAlarm";
            this.Size = new System.Drawing.Size(1275, 603);
            this.Load += new System.EventHandler(this.UCAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.pageIncoming.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIncoming.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIncoming)).EndInit();
            this.pageConfirmed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfirmed.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfirmed)).EndInit();
            this.pageOutgoing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage pageIncoming;
        private Telerik.WinControls.UI.RadPageViewPage pageConfirmed;
        private Telerik.WinControls.UI.RadPageViewPage pageOutgoing;
        private Telerik.WinControls.UI.RadGridView dtgIncoming;
        private Telerik.WinControls.UI.RadGridView dtgConfirmed;
        private Telerik.WinControls.UI.RadGridView dtgAll;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadDateTimePicker dateTo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker dateFrom;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadDropDownList cbbxDevice;
        private Telerik.WinControls.UI.RadLabel radLabel3;
    }
}

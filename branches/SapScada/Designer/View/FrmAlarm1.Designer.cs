namespace Designer.View
{
    partial class FrmAlarm1
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnExprortToExcel = new Telerik.WinControls.UI.RadButton();
            this.btnSaveConfirmed = new Telerik.WinControls.UI.RadButton();
            this.btnSearchEvent = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.dateTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.dateFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.rdFindByTime = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.rdCritical = new Telerik.WinControls.UI.RadCheckBox();
            this.rdLessCritical = new Telerik.WinControls.UI.RadCheckBox();
            this.rdWarning = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.rdUnconfirmed = new Telerik.WinControls.UI.RadCheckBox();
            this.rdConfirmed = new Telerik.WinControls.UI.RadCheckBox();
            this.cbbxJunction = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dtgEvent = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExprortToExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveConfirmed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdFindByTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdCritical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLessCritical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdUnconfirmed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdConfirmed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxJunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvent.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnExprortToExcel);
            this.radPanel1.Controls.Add(this.btnSaveConfirmed);
            this.radPanel1.Controls.Add(this.btnSearchEvent);
            this.radPanel1.Controls.Add(this.radGroupBox3);
            this.radPanel1.Controls.Add(this.radGroupBox2);
            this.radPanel1.Controls.Add(this.radGroupBox1);
            this.radPanel1.Controls.Add(this.cbbxJunction);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radPanel1.Location = new System.Drawing.Point(0, 3);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(244, 441);
            this.radPanel1.TabIndex = 0;
            // 
            // btnExprortToExcel
            // 
            this.btnExprortToExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnExprortToExcel.Image = global::Designer.Properties.Resources.Excel;
            this.btnExprortToExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExprortToExcel.Location = new System.Drawing.Point(100, 396);
            this.btnExprortToExcel.Name = "btnExprortToExcel";
            this.btnExprortToExcel.Size = new System.Drawing.Size(138, 24);
            this.btnExprortToExcel.TabIndex = 46;
            this.btnExprortToExcel.Text = "Xuất ra Excel";
            this.btnExprortToExcel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExprortToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExprortToExcel.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnSaveConfirmed
            // 
            this.btnSaveConfirmed.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnSaveConfirmed.Image = global::Designer.Properties.Resources.Save;
            this.btnSaveConfirmed.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSaveConfirmed.Location = new System.Drawing.Point(100, 366);
            this.btnSaveConfirmed.Name = "btnSaveConfirmed";
            this.btnSaveConfirmed.Size = new System.Drawing.Size(138, 24);
            this.btnSaveConfirmed.TabIndex = 45;
            this.btnSaveConfirmed.Text = "Lưu xác nhận";
            this.btnSaveConfirmed.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveConfirmed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveConfirmed.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnSearchEvent
            // 
            this.btnSearchEvent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnSearchEvent.Image = global::Designer.Properties.Resources.Search;
            this.btnSearchEvent.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearchEvent.Location = new System.Drawing.Point(12, 366);
            this.btnSearchEvent.Name = "btnSearchEvent";
            this.btnSearchEvent.Size = new System.Drawing.Size(82, 24);
            this.btnSearchEvent.TabIndex = 44;
            this.btnSearchEvent.Text = "Xem";
            this.btnSearchEvent.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchEvent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchEvent.Click += new System.EventHandler(this.Button_Click);
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.radLabel3);
            this.radGroupBox3.Controls.Add(this.dateTo);
            this.radGroupBox3.Controls.Add(this.radLabel2);
            this.radGroupBox3.Controls.Add(this.dateFrom);
            this.radGroupBox3.Controls.Add(this.rdFindByTime);
            this.radGroupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGroupBox3.HeaderText = "Thời gian";
            this.radGroupBox3.Location = new System.Drawing.Point(12, 241);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(226, 119);
            this.radGroupBox3.TabIndex = 4;
            this.radGroupBox3.Text = "Thời gian";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel3.Location = new System.Drawing.Point(24, 82);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(37, 21);
            this.radLabel3.TabIndex = 4;
            this.radLabel3.Text = "Đến :";
            // 
            // dateTo
            // 
            this.dateTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(65, 80);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(138, 23);
            this.dateTo.TabIndex = 3;
            this.dateTo.TabStop = false;
            this.dateTo.Text = "5/9/2014 2:48 PM";
            this.dateTo.Value = new System.DateTime(2014, 5, 9, 14, 48, 39, 391);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel2.Location = new System.Drawing.Point(24, 53);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(28, 21);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Từ :";
            // 
            // dateFrom
            // 
            this.dateFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(65, 51);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(138, 23);
            this.dateFrom.TabIndex = 1;
            this.dateFrom.TabStop = false;
            this.dateFrom.Text = "5/9/2014 2:48 PM";
            this.dateFrom.Value = new System.DateTime(2014, 5, 9, 14, 48, 39, 391);
            // 
            // rdFindByTime
            // 
            this.rdFindByTime.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rdFindByTime.Location = new System.Drawing.Point(24, 24);
            this.rdFindByTime.Name = "rdFindByTime";
            this.rdFindByTime.Size = new System.Drawing.Size(162, 21);
            this.rdFindByTime.TabIndex = 0;
            this.rdFindByTime.Text = "Tìm kiếm theo thời gian";
            this.rdFindByTime.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.rdCritical);
            this.radGroupBox2.Controls.Add(this.rdLessCritical);
            this.radGroupBox2.Controls.Add(this.rdWarning);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGroupBox2.HeaderText = "Mức độ lỗi";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 128);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(226, 107);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Mức độ lỗi";
            // 
            // rdCritical
            // 
            this.rdCritical.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rdCritical.Location = new System.Drawing.Point(24, 78);
            this.rdCritical.Name = "rdCritical";
            this.rdCritical.Size = new System.Drawing.Size(104, 21);
            this.rdCritical.TabIndex = 2;
            this.rdCritical.Text = "Nghiêm trọng";
            // 
            // rdLessCritical
            // 
            this.rdLessCritical.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rdLessCritical.Location = new System.Drawing.Point(24, 51);
            this.rdLessCritical.Name = "rdLessCritical";
            this.rdLessCritical.Size = new System.Drawing.Size(114, 21);
            this.rdLessCritical.TabIndex = 1;
            this.rdLessCritical.Text = "Ít nghiêm trọng";
            // 
            // rdWarning
            // 
            this.rdWarning.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rdWarning.Location = new System.Drawing.Point(24, 24);
            this.rdWarning.Name = "rdWarning";
            this.rdWarning.Size = new System.Drawing.Size(144, 21);
            this.rdWarning.TabIndex = 0;
            this.rdWarning.Text = "Không nghiêm trọng";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.rdUnconfirmed);
            this.radGroupBox1.Controls.Add(this.rdConfirmed);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGroupBox1.HeaderText = "Xác nhận";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 40);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(226, 82);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Xác nhận";
            // 
            // rdUnconfirmed
            // 
            this.rdUnconfirmed.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rdUnconfirmed.Location = new System.Drawing.Point(24, 51);
            this.rdUnconfirmed.Name = "rdUnconfirmed";
            this.rdUnconfirmed.Size = new System.Drawing.Size(107, 21);
            this.rdUnconfirmed.TabIndex = 1;
            this.rdUnconfirmed.Text = "Chưa xác nhận";
            // 
            // rdConfirmed
            // 
            this.rdConfirmed.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rdConfirmed.Location = new System.Drawing.Point(24, 24);
            this.rdConfirmed.Name = "rdConfirmed";
            this.rdConfirmed.Size = new System.Drawing.Size(75, 21);
            this.rdConfirmed.TabIndex = 0;
            this.rdConfirmed.Text = "Xác nhận";
            // 
            // cbbxJunction
            // 
            this.cbbxJunction.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbbxJunction.Location = new System.Drawing.Point(46, 11);
            this.cbbxJunction.Name = "cbbxJunction";
            this.cbbxJunction.Size = new System.Drawing.Size(192, 23);
            this.cbbxJunction.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel1.Location = new System.Drawing.Point(12, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(28, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Tủ :";
            // 
            // dtgEvent
            // 
            this.dtgEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dtgEvent.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEvent.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtgEvent.ForeColor = System.Drawing.Color.Black;
            this.dtgEvent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgEvent.Location = new System.Drawing.Point(244, 3);
            // 
            // dtgEvent
            // 
            this.dtgEvent.MasterTemplate.AllowAddNewRow = false;
            this.dtgEvent.MasterTemplate.AllowDeleteRow = false;
            this.dtgEvent.MasterTemplate.AllowRowResize = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "STT";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 62;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Mã lỗi";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 87;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "Thời gian";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 172;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Mức độ lỗi";
            gridViewTextBoxColumn4.Name = "column4";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 158;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.HeaderText = "Xác nhận";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column8";
            gridViewCheckBoxColumn1.Width = 69;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "Mô tả";
            gridViewTextBoxColumn5.Name = "column6";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 308;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "Chi tiết";
            gridViewTextBoxColumn6.Name = "column7";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 639;
            gridViewTextBoxColumn6.WrapText = true;
            this.dtgEvent.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.dtgEvent.Name = "dtgEvent";
            this.dtgEvent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgEvent.Size = new System.Drawing.Size(536, 441);
            this.dtgEvent.TabIndex = 1;
            this.dtgEvent.Text = "radGridView1";
            this.dtgEvent.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dtgEvent_RowFormatting);
            // 
            // FrmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 444);
            this.Controls.Add(this.dtgEvent);
            this.Controls.Add(this.radPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmAlarm";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Alarm";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExprortToExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveConfirmed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdFindByTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdCritical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdLessCritical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdUnconfirmed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdConfirmed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxJunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvent.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadCheckBox rdUnconfirmed;
        private Telerik.WinControls.UI.RadCheckBox rdConfirmed;
        private Telerik.WinControls.UI.RadDropDownList cbbxJunction;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGridView dtgEvent;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadCheckBox rdFindByTime;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadCheckBox rdCritical;
        private Telerik.WinControls.UI.RadCheckBox rdLessCritical;
        private Telerik.WinControls.UI.RadCheckBox rdWarning;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDateTimePicker dateTo;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDateTimePicker dateFrom;
        private Telerik.WinControls.UI.RadButton btnSaveConfirmed;
        private Telerik.WinControls.UI.RadButton btnSearchEvent;
        private Telerik.WinControls.UI.RadButton btnExprortToExcel;

    }
}

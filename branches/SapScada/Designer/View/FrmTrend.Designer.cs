namespace Designer.View
{
    partial class FrmTrend
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
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnRemove = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.cbbxLine = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.cbbxDevice = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.graphTrend = new HDSComponent.UI.HDGraph();
            this.rdRealtime = new Telerik.WinControls.UI.RadRadioButton();
            this.rdHistory = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.dateTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.dateFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdRealtime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnRemove);
            this.radGroupBox1.Controls.Add(this.btnAdd);
            this.radGroupBox1.Controls.Add(this.cbbxLine);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.cbbxDevice);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radGroupBox1.HeaderText = "Giao lộ";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 390);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1100, 47);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Giao lộ";
            this.radGroupBox1.ThemeName = "TelerikMetroBlue";
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnRemove.Image = global::Designer.Properties.Resources.Delete;
            this.btnRemove.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRemove.Location = new System.Drawing.Point(821, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(95, 24);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemove.ThemeName = "TelerikMetroBlue";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnAdd.Image = global::Designer.Properties.Resources.Add;
            this.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(720, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 24);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.ThemeName = "TelerikMetroBlue";
            // 
            // cbbxLine
            // 
            this.cbbxLine.AllowShowFocusCues = false;
            this.cbbxLine.AutoCompleteDisplayMember = null;
            this.cbbxLine.AutoCompleteValueMember = null;
            this.cbbxLine.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxLine.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbxLine.Location = new System.Drawing.Point(606, 12);
            this.cbbxLine.Name = "cbbxLine";
            this.cbbxLine.Size = new System.Drawing.Size(93, 24);
            this.cbbxLine.TabIndex = 8;
            this.cbbxLine.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radLabel4.Location = new System.Drawing.Point(562, 15);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(38, 21);
            this.radLabel4.TabIndex = 7;
            this.radLabel4.Text = "Line :";
            // 
            // cbbxDevice
            // 
            this.cbbxDevice.AllowShowFocusCues = false;
            this.cbbxDevice.AutoCompleteDisplayMember = null;
            this.cbbxDevice.AutoCompleteValueMember = null;
            this.cbbxDevice.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxDevice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbxDevice.Location = new System.Drawing.Point(175, 12);
            this.cbbxDevice.Name = "cbbxDevice";
            this.cbbxDevice.Size = new System.Drawing.Size(369, 24);
            this.cbbxDevice.TabIndex = 6;
            this.cbbxDevice.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radLabel3.Location = new System.Drawing.Point(112, 14);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(57, 21);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Giao lộ :";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.graphTrend);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox2.HeaderText = "Giản đồ";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(2, 30, 2, 2);
            this.radGroupBox2.Size = new System.Drawing.Size(1100, 349);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Giản đồ";
            this.radGroupBox2.ThemeName = "TelerikMetroBlue";
            // 
            // graphTrend
            // 
            this.graphTrend.DateFrom = new System.DateTime(((long)(0)));
            this.graphTrend.DateTo = new System.DateTime(((long)(0)));
            this.graphTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTrend.Location = new System.Drawing.Point(2, 30);
            this.graphTrend.Name = "graphTrend";
            this.graphTrend.Size = new System.Drawing.Size(1096, 317);
            this.graphTrend.TabIndex = 0;
            // 
            // rdRealtime
            // 
            this.rdRealtime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rdRealtime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdRealtime.Location = new System.Drawing.Point(112, 12);
            this.rdRealtime.Name = "rdRealtime";
            this.rdRealtime.Size = new System.Drawing.Size(110, 21);
            this.rdRealtime.TabIndex = 1;
            this.rdRealtime.TabStop = true;
            this.rdRealtime.Text = "Thời gian thực";
            this.rdRealtime.ThemeName = "TelerikMetroBlue";
            this.rdRealtime.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // rdHistory
            // 
            this.rdHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdHistory.Location = new System.Drawing.Point(243, 12);
            this.rdHistory.Name = "rdHistory";
            this.rdHistory.Size = new System.Drawing.Size(65, 21);
            this.rdHistory.TabIndex = 2;
            this.rdHistory.Text = "Lịch sử";
            this.rdHistory.ThemeName = "TelerikMetroBlue";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.dateTo);
            this.radGroupBox3.Controls.Add(this.radLabel2);
            this.radGroupBox3.Controls.Add(this.dateFrom);
            this.radGroupBox3.Controls.Add(this.radLabel1);
            this.radGroupBox3.Controls.Add(this.rdHistory);
            this.radGroupBox3.Controls.Add(this.rdRealtime);
            this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radGroupBox3.HeaderText = "Chế độ xem";
            this.radGroupBox3.Location = new System.Drawing.Point(0, 349);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(1100, 41);
            this.radGroupBox3.TabIndex = 3;
            this.radGroupBox3.Text = "Chế độ xem";
            this.radGroupBox3.ThemeName = "TelerikMetroBlue";
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(667, 9);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(133, 24);
            this.dateTo.TabIndex = 7;
            this.dateTo.TabStop = false;
            this.dateTo.Text = "23/01/2015 16:27";
            this.dateTo.ThemeName = "TelerikMetroBlue";
            this.dateTo.Value = new System.DateTime(2015, 1, 23, 16, 27, 59, 126);
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radLabel2.Location = new System.Drawing.Point(562, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(100, 21);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Đến thời điểm :";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(411, 9);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(133, 24);
            this.dateFrom.TabIndex = 5;
            this.dateFrom.TabStop = false;
            this.dateFrom.Text = "23/01/2015 16:27";
            this.dateFrom.ThemeName = "TelerikMetroBlue";
            this.dateFrom.Value = new System.DateTime(2015, 1, 23, 16, 27, 59, 126);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radLabel1.Location = new System.Drawing.Point(314, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(91, 21);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Từ thời điểm :";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 437);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmTrend";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trend";
            this.ThemeName = "TelerikMetroBlue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdRealtime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton rdHistory;
        private Telerik.WinControls.UI.RadRadioButton rdRealtime;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadDateTimePicker dateTo;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDateTimePicker dateFrom;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cbbxDevice;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList cbbxLine;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private System.Windows.Forms.Timer timer1;
        private HDSComponent.UI.HDGraph graphTrend;
        private Telerik.WinControls.UI.RadButton btnRemove;

    }
}
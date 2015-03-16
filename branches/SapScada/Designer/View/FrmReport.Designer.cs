namespace Designer.View
{
    partial class FrmReport
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
            this.dateTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dateFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel32 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel31 = new Telerik.WinControls.UI.RadLabel();
            this.btnSearchHistoricalTrend = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchHistoricalTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTo
            // 
            this.dateTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(255, 12);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(149, 23);
            this.dateTo.TabIndex = 47;
            this.dateTo.TabStop = false;
            this.dateTo.Text = "5/6/2014 8:06 AM";
            this.dateTo.Value = new System.DateTime(2014, 5, 6, 8, 6, 25, 808);
            // 
            // dateFrom
            // 
            this.dateFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(64, 12);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(149, 23);
            this.dateFrom.TabIndex = 46;
            this.dateFrom.TabStop = false;
            this.dateFrom.Text = "5/6/2014 8:06 AM";
            this.dateFrom.Value = new System.DateTime(2014, 5, 6, 8, 6, 25, 808);
            // 
            // radLabel32
            // 
            this.radLabel32.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel32.Location = new System.Drawing.Point(221, 14);
            this.radLabel32.Name = "radLabel32";
            this.radLabel32.Size = new System.Drawing.Size(28, 21);
            this.radLabel32.TabIndex = 45;
            this.radLabel32.Text = "To :";
            // 
            // radLabel31
            // 
            this.radLabel31.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel31.Location = new System.Drawing.Point(14, 14);
            this.radLabel31.Name = "radLabel31";
            this.radLabel31.Size = new System.Drawing.Size(44, 21);
            this.radLabel31.TabIndex = 44;
            this.radLabel31.Text = "From :";
            // 
            // btnSearchHistoricalTrend
            // 
            this.btnSearchHistoricalTrend.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnSearchHistoricalTrend.Image = global::Designer.Properties.Resources.Search;
            this.btnSearchHistoricalTrend.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearchHistoricalTrend.Location = new System.Drawing.Point(410, 11);
            this.btnSearchHistoricalTrend.Name = "btnSearchHistoricalTrend";
            this.btnSearchHistoricalTrend.Size = new System.Drawing.Size(101, 24);
            this.btnSearchHistoricalTrend.TabIndex = 48;
            this.btnSearchHistoricalTrend.Text = "Xem";
            this.btnSearchHistoricalTrend.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchHistoricalTrend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.dateTo);
            this.radPanel1.Controls.Add(this.dateFrom);
            this.radPanel1.Controls.Add(this.radLabel32);
            this.radPanel1.Controls.Add(this.radLabel31);
            this.radPanel1.Controls.Add(this.btnSearchHistoricalTrend);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(708, 47);
            this.radPanel1.TabIndex = 49;
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGridView1.Location = new System.Drawing.Point(0, 47);
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(708, 199);
            this.radGridView1.TabIndex = 50;
            this.radGridView1.Text = "radGridView1";
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 246);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Report";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchHistoricalTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadDateTimePicker dateTo;
        private Telerik.WinControls.UI.RadDateTimePicker dateFrom;
        private Telerik.WinControls.UI.RadLabel radLabel32;
        private Telerik.WinControls.UI.RadLabel radLabel31;
        private Telerik.WinControls.UI.RadButton btnSearchHistoricalTrend;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
    }
}

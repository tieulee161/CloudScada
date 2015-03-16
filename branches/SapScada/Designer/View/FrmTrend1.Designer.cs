namespace Designer.View
{
    partial class FrmTrend1
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.lstLines = new Telerik.WinControls.UI.RadListControl();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnStop = new Telerik.WinControls.UI.RadButton();
            this.btnStart = new Telerik.WinControls.UI.RadButton();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cbbxLines = new Telerik.WinControls.UI.RadDropDownList();
            this.graphTrend = new HDSComponent.UI.HDGraph();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.lstLines);
            this.radPanel1.Controls.Add(this.radPanel2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radPanel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(295, 479);
            this.radPanel1.TabIndex = 52;
            this.radPanel1.ThemeName = "TelerikMetroBlue";
            // 
            // lstLines
            // 
            this.lstLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLines.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstLines.Location = new System.Drawing.Point(0, 123);
            this.lstLines.Name = "lstLines";
            this.lstLines.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLines.Size = new System.Drawing.Size(295, 356);
            this.lstLines.TabIndex = 4;
            this.lstLines.Text = "43123";
            this.lstLines.ThemeName = "TelerikMetroBlue";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.btnStop);
            this.radPanel2.Controls.Add(this.btnStart);
            this.radPanel2.Controls.Add(this.btnDelete);
            this.radPanel2.Controls.Add(this.btnAdd);
            this.radPanel2.Controls.Add(this.radLabel1);
            this.radPanel2.Controls.Add(this.cbbxLines);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(295, 123);
            this.radPanel2.TabIndex = 5;
            this.radPanel2.ThemeName = "TelerikMetroBlue";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnStop.Image = global::Designer.Properties.Resources.Stop_small;
            this.btnStop.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStop.Location = new System.Drawing.Point(154, 87);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(135, 24);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStop.ThemeName = "TelerikMetroBlue";
            this.btnStop.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnStart.Image = global::Designer.Properties.Resources.Start_small;
            this.btnStart.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStart.Location = new System.Drawing.Point(12, 87);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(135, 24);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStart.ThemeName = "TelerikMetroBlue";
            this.btnStart.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnDelete.Image = global::Designer.Properties.Resources.Delete;
            this.btnDelete.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Location = new System.Drawing.Point(154, 57);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 24);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.ThemeName = "TelerikMetroBlue";
            this.btnDelete.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnAdd.Image = global::Designer.Properties.Resources.Add;
            this.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(12, 57);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 24);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.ThemeName = "TelerikMetroBlue";
            this.btnAdd.Click += new System.EventHandler(this.Button_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel1.Location = new System.Drawing.Point(10, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(38, 21);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Line :";
            // 
            // cbbxLines
            // 
            this.cbbxLines.AllowShowFocusCues = false;
            this.cbbxLines.AutoCompleteDisplayMember = null;
            this.cbbxLines.AutoCompleteValueMember = null;
            this.cbbxLines.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbbxLines.Location = new System.Drawing.Point(12, 28);
            this.cbbxLines.Name = "cbbxLines";
            this.cbbxLines.Size = new System.Drawing.Size(277, 24);
            this.cbbxLines.TabIndex = 0;
            this.cbbxLines.ThemeName = "TelerikMetroBlue";
            // 
            // graphTrend
            // 
            this.graphTrend.DateFrom = new System.DateTime(((long)(0)));
            this.graphTrend.DateTo = new System.DateTime(((long)(0)));
            this.graphTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTrend.Location = new System.Drawing.Point(295, 0);
            this.graphTrend.Name = "graphTrend";
            this.graphTrend.Size = new System.Drawing.Size(554, 479);
            this.graphTrend.TabIndex = 50;
            // 
            // FrmTrend1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 479);
            this.Controls.Add(this.graphTrend);
            this.Controls.Add(this.radPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmTrend1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Trend";
            this.ThemeName = "TelerikMetroBlue";
            this.Load += new System.EventHandler(this.FrmTrend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HDSComponent.UI.HDGraph graphTrend;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cbbxLines;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadListControl lstLines;
        private Telerik.WinControls.UI.RadButton btnStart;
        private Telerik.WinControls.UI.RadButton btnStop;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
    }
}

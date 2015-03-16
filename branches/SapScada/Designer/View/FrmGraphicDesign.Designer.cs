namespace Designer.View
{
    partial class FrmGraphicDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGraphicDesign));
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.menuDisplay = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuTrend = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuAlarm = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuReport = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuStart = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuStop = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menuUpdateTime = new Telerik.WinControls.UI.RadMenuButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 285);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(659, 24);
            this.radStatusStrip1.TabIndex = 1;
            this.radStatusStrip1.Text = "radStatusStrip1";
            // 
            // radDock1
            // 
            this.radDock1.AutoDetectMdiChildren = true;
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 65);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radDock1.Size = new System.Drawing.Size(659, 220);
            this.radDock1.TabIndex = 2;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            // 
            // documentContainer1
            // 
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            // 
            // radMenu1
            // 
            this.radMenu1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuDisplay,
            this.menuTrend,
            this.menuAlarm,
            this.menuReport,
            this.menuStart,
            this.menuStop,
            this.menuUpdateTime});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(659, 65);
            this.radMenu1.TabIndex = 0;
            this.radMenu1.Text = "radMenu1";
            // 
            // menuDisplay
            // 
            this.menuDisplay.AccessibleDescription = "Display";
            this.menuDisplay.AccessibleName = "Display";
            // 
            // 
            // 
            this.menuDisplay.ButtonElement.AccessibleDescription = "Display";
            this.menuDisplay.ButtonElement.AccessibleName = "Display";
            this.menuDisplay.Image = global::Designer.Properties.Resources.Monitor;
            this.menuDisplay.Name = "menuDisplay";
            this.menuDisplay.Text = " Display ";
            this.menuDisplay.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuDisplay.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuTrend
            // 
            this.menuTrend.AccessibleDescription = "Trend";
            this.menuTrend.AccessibleName = "Trend";
            // 
            // 
            // 
            this.menuTrend.ButtonElement.AccessibleDescription = "Trend";
            this.menuTrend.ButtonElement.AccessibleName = "Trend";
            this.menuTrend.Image = global::Designer.Properties.Resources.Graph;
            this.menuTrend.Name = "menuTrend";
            this.menuTrend.Text = "  Trend  ";
            this.menuTrend.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuTrend.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuAlarm
            // 
            this.menuAlarm.AccessibleDescription = "Alarm";
            this.menuAlarm.AccessibleName = "Alarm";
            // 
            // 
            // 
            this.menuAlarm.ButtonElement.AccessibleDescription = "Alarm";
            this.menuAlarm.ButtonElement.AccessibleName = "Alarm";
            this.menuAlarm.Image = global::Designer.Properties.Resources.Warning;
            this.menuAlarm.Name = "menuAlarm";
            this.menuAlarm.Text = "  Alarm  ";
            this.menuAlarm.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuAlarm.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuReport
            // 
            this.menuReport.AccessibleDescription = "Report";
            this.menuReport.AccessibleName = "Report";
            // 
            // 
            // 
            this.menuReport.ButtonElement.AccessibleDescription = "Report";
            this.menuReport.ButtonElement.AccessibleName = "Report";
            this.menuReport.Image = global::Designer.Properties.Resources.Statistic;
            this.menuReport.Name = "menuReport";
            this.menuReport.Text = "  Report ";
            this.menuReport.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.menuReport.Click += new System.EventHandler(this.Menu_Click);
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
            this.menuStart.Image = ((System.Drawing.Image)(resources.GetObject("menuStart.Image")));
            this.menuStart.Name = "menuStart";
            this.menuStart.Text = "  Start  ";
            this.menuStart.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.menuStart.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuStop
            // 
            this.menuStop.AccessibleDescription = "   Stop  ";
            this.menuStop.AccessibleName = "   Stop  ";
            // 
            // 
            // 
            this.menuStop.ButtonElement.AccessibleDescription = "   Stop  ";
            this.menuStop.ButtonElement.AccessibleName = "   Stop  ";
            this.menuStop.Image = global::Designer.Properties.Resources.Stop;
            this.menuStop.Name = "menuStop";
            this.menuStop.Text = "   Stop  ";
            this.menuStop.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.menuStop.Click += new System.EventHandler(this.Menu_Click);
            // 
            // menuUpdateTime
            // 
            this.menuUpdateTime.AccessibleDescription = "Update Time";
            this.menuUpdateTime.AccessibleName = "Update Time";
            // 
            // 
            // 
            this.menuUpdateTime.ButtonElement.AccessibleDescription = "Update Time";
            this.menuUpdateTime.ButtonElement.AccessibleName = "Update Time";
            this.menuUpdateTime.Image = global::Designer.Properties.Resources.Clock;
            this.menuUpdateTime.Name = "menuUpdateTime";
            this.menuUpdateTime.Text = "Update Time";
            this.menuUpdateTime.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.menuUpdateTime.Click += new System.EventHandler(this.Menu_Click);
            // 
            // FrmGraphicDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 309);
            this.Controls.Add(this.radDock1);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmGraphicDesign";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphic Design";
            this.ThemeName = "ControlDefault";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGraphicDesign_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmGraphicDesign_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.RadMenuButtonItem menuDisplay;
        private Telerik.WinControls.UI.RadMenuButtonItem menuTrend;
        private Telerik.WinControls.UI.RadMenuButtonItem menuAlarm;
        private Telerik.WinControls.UI.RadMenuButtonItem menuReport;
        private Telerik.WinControls.UI.RadMenuButtonItem menuStart;
        private Telerik.WinControls.UI.RadMenuButtonItem menuStop;
        private Telerik.WinControls.UI.RadMenuButtonItem menuUpdateTime;



    }
}

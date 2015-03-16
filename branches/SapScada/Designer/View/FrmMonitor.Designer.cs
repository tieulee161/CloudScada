namespace Designer.View
{
    partial class FrmMonitor
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
            this.GMap = new HDSComponent.UI.Map();
            this.btnUpdateTime = new Telerik.WinControls.UI.RadButton();
            this.UCAlarmNewsControl = new Designer.View.UCAlarmNews();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GMap
            // 
            this.GMap.AllowDrop = true;
            this.GMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GMap.Location = new System.Drawing.Point(0, 0);
            this.GMap.Name = "GMap";
            this.GMap.Size = new System.Drawing.Size(633, 278);
            this.GMap.TabIndex = 0;
            // 
            // btnUpdateTime
            // 
            this.btnUpdateTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTime.Image = global::Designer.Properties.Resources.Download_Big;
            this.btnUpdateTime.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdateTime.Location = new System.Drawing.Point(6, 30);
            this.btnUpdateTime.Name = "btnUpdateTime";
            this.btnUpdateTime.Size = new System.Drawing.Size(104, 49);
            this.btnUpdateTime.TabIndex = 4;
            this.btnUpdateTime.Text = "Cập nhật thời gian";
            this.btnUpdateTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateTime.TextWrap = true;
            // 
            // UCAlarmNewsControl
            // 
            this.UCAlarmNewsControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.UCAlarmNewsControl.Location = new System.Drawing.Point(0, 0);
            this.UCAlarmNewsControl.Name = "UCAlarmNewsControl";
            this.UCAlarmNewsControl.Size = new System.Drawing.Size(633, 26);
            this.UCAlarmNewsControl.TabIndex = 2;
            // 
            // FrmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 278);
            this.Controls.Add(this.btnUpdateTime);
            this.Controls.Add(this.UCAlarmNewsControl);
            this.Controls.Add(this.GMap);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "FrmMonitor";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Monitor";
            this.ThemeName = "ControlDefault";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMonitor_FormClosed);
            this.Load += new System.EventHandler(this.FrmMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HDSComponent.UI.Map GMap;
        public UCAlarmNews UCAlarmNewsControl;
        private Telerik.WinControls.UI.RadButton btnUpdateTime;

    }
}

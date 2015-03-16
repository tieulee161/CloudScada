namespace Designer.View
{
    partial class FrmAlarm
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
            this.UCAlarmControl = new Designer.View.UCAlarm();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // UCAlarmControl
            // 
            this.UCAlarmControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UCAlarmControl.Location = new System.Drawing.Point(0, 0);
            this.UCAlarmControl.Name = "UCAlarmControl";
            this.UCAlarmControl.Size = new System.Drawing.Size(1144, 514);
            this.UCAlarmControl.TabIndex = 0;
            // 
            // FrmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 514);
            this.Controls.Add(this.UCAlarmControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmAlarm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarm";
            this.ThemeName = "ControlDefault";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public UCAlarm UCAlarmControl;

    }
}

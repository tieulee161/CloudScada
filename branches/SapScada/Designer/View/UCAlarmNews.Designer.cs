namespace Designer.View
{
    partial class UCAlarmNews
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
            this.lbAlarm = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lbAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAlarm
            // 
            this.lbAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAlarm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlarm.ForeColor = System.Drawing.Color.Red;
            this.lbAlarm.Location = new System.Drawing.Point(0, 0);
            this.lbAlarm.Name = "lbAlarm";
            this.lbAlarm.Size = new System.Drawing.Size(79, 25);
            this.lbAlarm.TabIndex = 0;
            this.lbAlarm.Text = "radLabel1";
            // 
            // UCAlarmNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbAlarm);
            this.Name = "UCAlarmNews";
            this.Size = new System.Drawing.Size(1205, 27);
            ((System.ComponentModel.ISupportInitialize)(this.lbAlarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lbAlarm;
    }
}

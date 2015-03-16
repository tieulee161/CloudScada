namespace HDSComponent.UI
{
    partial class HDTrafficLight
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
            this.indicatorXA = new HDSComponent.UI.HDIndicator();
            this.indicatorVA = new HDSComponent.UI.HDIndicator();
            this.indicatorDA = new HDSComponent.UI.HDIndicator();
            this.SuspendLayout();
            // 
            // indicatorXA
            // 
            this.indicatorXA.BackColor = System.Drawing.Color.White;
            this.indicatorXA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indicatorXA.DisplayText = "";
            this.indicatorXA.Location = new System.Drawing.Point(0, 64);
            this.indicatorXA.Name = "indicatorXA";
            this.indicatorXA.Size = new System.Drawing.Size(32, 32);
            this.indicatorXA.TabIndex = 22;
            // 
            // indicatorVA
            // 
            this.indicatorVA.BackColor = System.Drawing.Color.White;
            this.indicatorVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indicatorVA.DisplayText = "";
            this.indicatorVA.Location = new System.Drawing.Point(0, 32);
            this.indicatorVA.Name = "indicatorVA";
            this.indicatorVA.Size = new System.Drawing.Size(32, 32);
            this.indicatorVA.TabIndex = 21;
            // 
            // indicatorDA
            // 
            this.indicatorDA.BackColor = System.Drawing.Color.White;
            this.indicatorDA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indicatorDA.DisplayText = "";
            this.indicatorDA.Location = new System.Drawing.Point(0, 0);
            this.indicatorDA.Name = "indicatorDA";
            this.indicatorDA.Size = new System.Drawing.Size(32, 32);
            this.indicatorDA.TabIndex = 20;
            // 
            // HDTrafficLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.indicatorXA);
            this.Controls.Add(this.indicatorVA);
            this.Controls.Add(this.indicatorDA);
            this.Name = "HDTrafficLight";
            this.Size = new System.Drawing.Size(32, 96);
            this.ResumeLayout(false);

        }

        #endregion

        private HDIndicator indicatorXA;
        private HDIndicator indicatorVA;
        private HDIndicator indicatorDA;
    }
}

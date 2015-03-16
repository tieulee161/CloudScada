namespace HDSComponent.TrafficGraph
{
    partial class UCTrafficGraph
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
            this.HDChart = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // HDChart
            // 
            this.HDChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HDChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HDChart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HDChart.Location = new System.Drawing.Point(0, 0);
            this.HDChart.Name = "HDChart";
            this.HDChart.ScrollGrace = 0D;
            this.HDChart.ScrollMaxX = 0D;
            this.HDChart.ScrollMaxY = 0D;
            this.HDChart.ScrollMaxY2 = 0D;
            this.HDChart.ScrollMinX = 0D;
            this.HDChart.ScrollMinY = 0D;
            this.HDChart.ScrollMinY2 = 0D;
            this.HDChart.Size = new System.Drawing.Size(541, 306);
            this.HDChart.TabIndex = 0;
            // 
            // UCTrafficGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HDChart);
            this.Name = "UCTrafficGraph";
            this.Size = new System.Drawing.Size(541, 306);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl HDChart;

    }
}

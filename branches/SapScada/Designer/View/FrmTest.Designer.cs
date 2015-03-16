namespace Designer.View
{
    partial class FrmTest
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
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.object_4f79a94f_6d0c_4c0e_aa35_6705e9c10d92 = new Telerik.WinControls.RootRadElement();
            this.radButton3 = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.map1 = new HDSComponent.UI.Map();
            this.radDropDownList1 = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.BackColor = System.Drawing.Color.Red;
            this.radButton1.Location = new System.Drawing.Point(12, 12);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(115, 36);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "radButton1";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "radButton1";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.Blue;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radButton1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.Blue;
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(148, 12);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 1;
            this.radButton2.Text = "radButton2";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // object_4f79a94f_6d0c_4c0e_aa35_6705e9c10d92
            // 
            this.object_4f79a94f_6d0c_4c0e_aa35_6705e9c10d92.Name = "object_4f79a94f_6d0c_4c0e_aa35_6705e9c10d92";
            this.object_4f79a94f_6d0c_4c0e_aa35_6705e9c10d92.StretchHorizontally = true;
            this.object_4f79a94f_6d0c_4c0e_aa35_6705e9c10d92.StretchVertically = true;
            this.object_4f79a94f_6d0c_4c0e_aa35_6705e9c10d92.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radButton3
            // 
            this.radButton3.Location = new System.Drawing.Point(318, 11);
            this.radButton3.Name = "radButton3";
            this.radButton3.Size = new System.Drawing.Size(110, 24);
            this.radButton3.TabIndex = 3;
            this.radButton3.Text = "radButton3";
            // 
            // radPanel1
            // 
            this.radPanel1.Location = new System.Drawing.Point(548, 119);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(200, 100);
            this.radPanel1.TabIndex = 4;
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel1.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Width = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).BottomWidth = 1F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.Color.Coral;
            // 
            // map1
            // 
            this.map1.AllowDrop = true;
            this.map1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.map1.Location = new System.Drawing.Point(12, 54);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(482, 296);
            this.map1.TabIndex = 2;
            this.map1.DoubleClick += new System.EventHandler(this.map1_DoubleClick);
            // 
            // radDropDownList1
            // 
            this.radDropDownList1.Location = new System.Drawing.Point(577, 285);
            this.radDropDownList1.Name = "radDropDownList1";
            this.radDropDownList1.Size = new System.Drawing.Size(125, 20);
            this.radDropDownList1.TabIndex = 5;
            this.radDropDownList1.Text = "radDropDownList1";
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 362);
            this.Controls.Add(this.radDropDownList1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.radButton3);
            this.Controls.Add(this.map1);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Name = "FrmTest";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTest";
            this.ThemeName = "TelerikMetroBlue";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private HDSComponent.UI.Map map1;
        private Telerik.WinControls.RootRadElement object_4f79a94f_6d0c_4c0e_aa35_6705e9c10d92;
        private Telerik.WinControls.UI.RadButton radButton3;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadDropDownList radDropDownList1;
    }
}

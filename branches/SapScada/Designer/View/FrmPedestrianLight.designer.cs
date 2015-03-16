namespace Designer.View
{
    partial class FrmPedestrianLight
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
            this.components = new System.ComponentModel.Container();
            this.box = new System.Windows.Forms.PictureBox();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            this.contextSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.contextDelete = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.box)).BeginInit();
            this.SuspendLayout();
            // 
            // box
            // 
            this.box.Location = new System.Drawing.Point(4, 34);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(26, 20);
            this.box.TabIndex = 1;
            this.box.TabStop = false;
            // 
            // radContextMenu1
            // 
            this.radContextMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextSetting,
            this.contextDelete});
            // 
            // contextSetting
            // 
            this.contextSetting.AccessibleDescription = "Setting";
            this.contextSetting.AccessibleName = "Setting";
            this.contextSetting.Image = global::Designer.Properties.Resources.setting;
            this.contextSetting.Name = "contextSetting";
            this.contextSetting.Text = "Setting";
            this.contextSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // contextDelete
            // 
            this.contextDelete.AccessibleDescription = "Delete";
            this.contextDelete.AccessibleName = "Delete";
            this.contextDelete.Image = global::Designer.Properties.Resources.Delete;
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Text = "Delete";
            this.contextDelete.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // FrmPedestrianLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Designer.Properties.Resources.Lamp_Pes_Off;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.box);
            this.DoubleBuffered = true;
            this.Name = "FrmPedestrianLight";
            this.radContextMenuManager1.SetRadContextMenu(this, this.radContextMenu1);
            this.Size = new System.Drawing.Size(33, 67);
            this.Load += new System.EventHandler(this.FrmPedestrianLight_Load);
            this.LocationChanged += new System.EventHandler(this.FrmPedestrianLight_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PedestrianLight_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox box;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadMenuItem contextSetting;
        private Telerik.WinControls.UI.RadMenuItem contextDelete;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
    }
}

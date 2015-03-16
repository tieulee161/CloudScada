namespace Designer.View
{
    partial class FrmArrowLamp
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
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.contextDelete = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            this.box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.box)).BeginInit();
            this.SuspendLayout();
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
            this.contextDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.contextDelete.Image = global::Designer.Properties.Resources.Delete;
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Text = "Delete";
            this.contextDelete.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // box
            // 
            this.box.BackColor = System.Drawing.Color.Transparent;
            this.box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.box.Location = new System.Drawing.Point(0, 0);
            this.box.Name = "box";
            this.radContextMenuManager1.SetRadContextMenu(this.box, this.radContextMenu1);
            this.box.Size = new System.Drawing.Size(37, 19);
            this.box.TabIndex = 1;
            this.box.TabStop = false;
            this.box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmArrowLamp_MouseDown);
            // 
            // FrmArrowLamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Designer.Properties.Resources.Lamp_Arrow_Off;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.box);
            this.Name = "FrmArrowLamp";
            this.radContextMenuManager1.SetRadContextMenu(this, this.radContextMenu1);
            this.Size = new System.Drawing.Size(37, 37);
            this.Load += new System.EventHandler(this.FrmArrowLamp_Load);
            this.LocationChanged += new System.EventHandler(this.FrmArrowLamp_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmArrowLamp_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadMenuItem contextDelete;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private Telerik.WinControls.UI.RadMenuItem contextSetting;
        private System.Windows.Forms.PictureBox box;
    }
}

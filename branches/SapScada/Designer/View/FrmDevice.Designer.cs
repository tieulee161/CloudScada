namespace Designer.View
{
    partial class FrmDevice
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.dtgDevice = new Telerik.WinControls.UI.RadGridView();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextAdd = new Telerik.WinControls.UI.RadMenuItem();
            this.contextDelete = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDevice.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDevice
            // 
            this.dtgDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dtgDevice.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDevice.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtgDevice.ForeColor = System.Drawing.Color.Black;
            this.dtgDevice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgDevice.Location = new System.Drawing.Point(0, 0);
            // 
            // dtgDevice
            // 
            this.dtgDevice.MasterTemplate.AllowCellContextMenu = false;
            this.dtgDevice.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Device Name";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn1.Width = 324;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Driver";
            gridViewTextBoxColumn2.Name = "column3";
            gridViewTextBoxColumn2.Width = 206;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.HeaderText = "Port";
            gridViewDecimalColumn1.Name = "column2";
            gridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn1.Width = 89;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "Address";
            gridViewTextBoxColumn3.Name = "colAddress";
            gridViewTextBoxColumn3.Width = 179;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Note";
            gridViewTextBoxColumn4.Name = "column5";
            gridViewTextBoxColumn4.Width = 178;
            this.dtgDevice.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dtgDevice.MasterTemplate.EnableGrouping = false;
            this.dtgDevice.MasterTemplate.EnableSorting = false;
            sortDescriptor1.PropertyName = "column1";
            this.dtgDevice.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dtgDevice.Name = "dtgDevice";
            this.radContextMenuManager1.SetRadContextMenu(this.dtgDevice, this.radContextMenu1);
            this.dtgDevice.ReadOnly = true;
            this.dtgDevice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgDevice.Size = new System.Drawing.Size(992, 238);
            this.dtgDevice.TabIndex = 0;
            this.dtgDevice.Text = "radGridView1";
            this.dtgDevice.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dtgServer_RowFormatting);
            this.dtgDevice.DoubleClick += new System.EventHandler(this.dtgServer_DoubleClick);
            // 
            // radContextMenu1
            // 
            this.radContextMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextAdd,
            this.contextDelete});
            // 
            // contextAdd
            // 
            this.contextAdd.AccessibleDescription = "Add";
            this.contextAdd.AccessibleName = "Add";
            this.contextAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.contextAdd.Image = global::Designer.Properties.Resources.Add;
            this.contextAdd.Name = "contextAdd";
            this.contextAdd.Text = "Add";
            this.contextAdd.Visibility = Telerik.WinControls.ElementVisibility.Visible;
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
            // FrmDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 238);
            this.Controls.Add(this.dtgDevice);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmDevice";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Device Setting";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDevice.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dtgDevice;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadMenuItem contextAdd;
        private Telerik.WinControls.UI.RadMenuItem contextDelete;

    }
}

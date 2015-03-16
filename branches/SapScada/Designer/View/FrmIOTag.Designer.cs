namespace Designer.View
{
    partial class FrmIOTag
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.dtgIOTag = new Telerik.WinControls.UI.RadGridView();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextAdd = new Telerik.WinControls.UI.RadMenuItem();
            this.contextDelete = new Telerik.WinControls.UI.RadMenuItem();
            this.contextCopy = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIOTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIOTag.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgIOTag
            // 
            this.dtgIOTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dtgIOTag.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgIOTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgIOTag.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtgIOTag.ForeColor = System.Drawing.Color.Black;
            this.dtgIOTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgIOTag.Location = new System.Drawing.Point(0, 0);
            // 
            // dtgIOTag
            // 
            this.dtgIOTag.MasterTemplate.AllowCellContextMenu = false;
            this.dtgIOTag.MasterTemplate.AllowSearchRow = true;
            this.dtgIOTag.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Tag Name";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending;
            gridViewTextBoxColumn1.Width = 280;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Type";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 79;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "Data Type";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 71;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Address";
            gridViewTextBoxColumn4.Name = "column4";
            gridViewTextBoxColumn4.Width = 145;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "Update Rating";
            gridViewTextBoxColumn5.Name = "column7";
            gridViewTextBoxColumn5.Width = 92;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "Device";
            gridViewTextBoxColumn6.Name = "column6";
            gridViewTextBoxColumn6.Width = 137;
            gridViewCheckBoxColumn1.Checked = Telerik.WinControls.Enumerations.ToggleState.Off;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.EnableHeaderCheckBox = false;
            gridViewCheckBoxColumn1.HeaderText = "Save to log";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colIsSaveToLog";
            gridViewCheckBoxColumn1.Width = 77;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Note";
            gridViewTextBoxColumn7.Name = "column5";
            gridViewTextBoxColumn7.Width = 98;
            this.dtgIOTag.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn7});
            this.dtgIOTag.MasterTemplate.EnableGrouping = false;
            this.dtgIOTag.MasterTemplate.EnableSorting = false;
            sortDescriptor1.Direction = System.ComponentModel.ListSortDirection.Descending;
            sortDescriptor1.PropertyName = "column1";
            this.dtgIOTag.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dtgIOTag.Name = "dtgIOTag";
            this.radContextMenuManager1.SetRadContextMenu(this.dtgIOTag, this.radContextMenu1);
            this.dtgIOTag.ReadOnly = true;
            this.dtgIOTag.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgIOTag.Size = new System.Drawing.Size(992, 238);
            this.dtgIOTag.TabIndex = 0;
            this.dtgIOTag.Text = "radGridView1";
            this.dtgIOTag.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dtgServer_RowFormatting);
            this.dtgIOTag.DoubleClick += new System.EventHandler(this.dtgServer_DoubleClick);
            // 
            // radContextMenu1
            // 
            this.radContextMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextAdd,
            this.contextDelete,
            this.contextCopy});
            // 
            // contextAdd
            // 
            this.contextAdd.AccessibleDescription = "Add";
            this.contextAdd.AccessibleName = "Add";
            this.contextAdd.Image = global::Designer.Properties.Resources.Add;
            this.contextAdd.Name = "contextAdd";
            this.contextAdd.Text = "Add";
            this.contextAdd.Visibility = Telerik.WinControls.ElementVisibility.Visible;
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
            // contextCopy
            // 
            this.contextCopy.AccessibleDescription = "Copy";
            this.contextCopy.AccessibleName = "Copy";
            this.contextCopy.Name = "contextCopy";
            this.contextCopy.Text = "Copy";
            this.contextCopy.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // FrmIOTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 238);
            this.Controls.Add(this.dtgIOTag);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmIOTag";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "IO Tag Setting";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgIOTag.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgIOTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dtgIOTag;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadMenuItem contextAdd;
        private Telerik.WinControls.UI.RadMenuItem contextDelete;
        private Telerik.WinControls.UI.RadMenuItem contextCopy;

    }
}

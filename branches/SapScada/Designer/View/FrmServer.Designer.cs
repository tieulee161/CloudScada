namespace Designer.View
{
    partial class FrmServer
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
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.dtgServer = new Telerik.WinControls.UI.RadGridView();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextAdd = new Telerik.WinControls.UI.RadMenuItem();
            this.contextDelete = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServer.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgServer
            // 
            this.dtgServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dtgServer.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgServer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtgServer.ForeColor = System.Drawing.Color.Black;
            this.dtgServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgServer.Location = new System.Drawing.Point(0, 0);
            // 
            // dtgServer
            // 
            this.dtgServer.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Server Name";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending;
            gridViewTextBoxColumn1.Width = 218;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "IP";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 131;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "Server Type";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 131;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Priority";
            gridViewTextBoxColumn4.Name = "column4";
            gridViewTextBoxColumn4.Width = 131;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "Note";
            gridViewTextBoxColumn5.Name = "column5";
            gridViewTextBoxColumn5.Width = 364;
            this.dtgServer.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.dtgServer.MasterTemplate.EnableGrouping = false;
            this.dtgServer.MasterTemplate.EnableSorting = false;
            sortDescriptor1.Direction = System.ComponentModel.ListSortDirection.Descending;
            sortDescriptor1.PropertyName = "column1";
            this.dtgServer.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dtgServer.Name = "dtgServer";
            this.radContextMenuManager1.SetRadContextMenu(this.dtgServer, this.radContextMenu1);
            this.dtgServer.ReadOnly = true;
            this.dtgServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgServer.Size = new System.Drawing.Size(992, 238);
            this.dtgServer.TabIndex = 0;
            this.dtgServer.Text = "radGridView1";
            this.dtgServer.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dtgServer_RowFormatting);
            this.dtgServer.DoubleClick += new System.EventHandler(this.dtgServer_DoubleClick);
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
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 238);
            this.Controls.Add(this.dtgServer);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmServer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Server Setting";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgServer.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dtgServer;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadMenuItem contextAdd;
        private Telerik.WinControls.UI.RadMenuItem contextDelete;

    }
}

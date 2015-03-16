namespace HDSComponent.UI
{
    partial class Map
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
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.trackZoom = new Telerik.WinControls.UI.RadTrackBar();
            this.txtSearch = new Telerik.WinControls.UI.RadTextBox();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.contextAdd = new Telerik.WinControls.UI.RadMenuItem();
            this.contextDelete = new Telerik.WinControls.UI.RadMenuItem();
            this.contextIsMovable = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMap
            // 
            this.MainMap.AllowDrop = true;
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 24);
            this.MainMap.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.radContextMenuManager1.SetRadContextMenu(this.MainMap, this.radContextMenu1);
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(408, 272);
            this.MainMap.TabIndex = 1;
            this.MainMap.Zoom = 0D;
            this.MainMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.MainMap_OnMarkerClick);
            this.MainMap.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.MainMap_OnMarkerEnter);
            this.MainMap.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.MainMap_OnMarkerLeave);
            this.MainMap.OnMapZoomChanged += new GMap.NET.MapZoomChanged(this.MainMap_OnMapZoomChanged);
            this.MainMap.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainMap_DragDrop);
            this.MainMap.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainMap_DragEnter);
            this.MainMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseClick);
            this.MainMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseDoubleClick);
            this.MainMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseDown);
            this.MainMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseMove);
            this.MainMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseUp);
            // 
            // trackZoom
            // 
            this.trackZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackZoom.Location = new System.Drawing.Point(408, 24);
            this.trackZoom.Minimum = 1F;
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // 
            // 
            this.trackZoom.RootElement.StretchHorizontally = false;
            this.trackZoom.RootElement.StretchVertically = true;
            this.trackZoom.Size = new System.Drawing.Size(37, 272);
            this.trackZoom.TabIndex = 2;
            this.trackZoom.ThumbSize = new System.Drawing.Size(5, 14);
            this.trackZoom.Value = 5F;
            this.trackZoom.ValueChanged += new System.EventHandler(this.trackZoom_ValueChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NullText = "Enter location ...";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.txtSearch.Size = new System.Drawing.Size(445, 24);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // radContextMenu1
            // 
            this.radContextMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextIsMovable,
            this.radMenuSeparatorItem2,
            this.contextSetting,
            this.radMenuSeparatorItem1,
            this.contextAdd,
            this.contextDelete});
            this.radContextMenu1.DropDownOpening += new System.ComponentModel.CancelEventHandler(this.radContextMenu1_DropDownOpening);
            // 
            // contextSetting
            // 
            this.contextSetting.AccessibleDescription = "Setting";
            this.contextSetting.AccessibleName = "Setting";
            this.contextSetting.Image = global::HDSComponent.Properties.Resources.setting;
            this.contextSetting.Name = "contextSetting";
            this.contextSetting.Text = "Setting";
            this.contextSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.AccessibleDescription = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.AccessibleName = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // contextAdd
            // 
            this.contextAdd.AccessibleDescription = "Add";
            this.contextAdd.AccessibleName = "Add";
            this.contextAdd.Image = global::HDSComponent.Properties.Resources.Add;
            this.contextAdd.Name = "contextAdd";
            this.contextAdd.Text = "Add";
            this.contextAdd.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // contextDelete
            // 
            this.contextDelete.AccessibleDescription = "Delete";
            this.contextDelete.AccessibleName = "Delete";
            this.contextDelete.Image = global::HDSComponent.Properties.Resources.Delete;
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Text = "Delete";
            this.contextDelete.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // contextIsMovable
            // 
            this.contextIsMovable.AccessibleDescription = "Di chuyển";
            this.contextIsMovable.AccessibleName = "Di chuyển";
            this.contextIsMovable.CheckOnClick = true;
            this.contextIsMovable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.contextIsMovable.Name = "contextIsMovable";
            this.contextIsMovable.Text = "Di chuyển";
            this.contextIsMovable.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.AccessibleDescription = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.AccessibleName = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // Map
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.MainMap);
            this.Controls.Add(this.trackZoom);
            this.Controls.Add(this.txtSearch);
            this.Name = "Map";
            this.Size = new System.Drawing.Size(445, 296);
            this.Load += new System.EventHandler(this.Map_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTrackBar trackZoom;
        public GMap.NET.WindowsForms.GMapControl MainMap;
        private Telerik.WinControls.UI.RadTextBox txtSearch;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadMenuItem contextAdd;
        private Telerik.WinControls.UI.RadMenuItem contextDelete;
        private Telerik.WinControls.UI.RadMenuItem contextSetting;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem contextIsMovable;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;

    }
}

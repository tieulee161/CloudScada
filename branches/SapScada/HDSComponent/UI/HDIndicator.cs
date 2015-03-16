using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Common;
using System.Windows.Forms;
using System.Drawing;

namespace HDSComponent.UI
{
    public class HDIndicator : UserControl
    {
        public int Id { get; set; }
        public IDisplayTag DisplayTag;
        private RadLabel lbStatus;

        public Dictionary<object, Image> DataMapping = new Dictionary<object, Image>();
        private RadContextMenuManager radContextMenuManager1;
        private RadContextMenu ContextMenu;
        private System.ComponentModel.IContainer components;
        public RadMenuItem menuSetting;
        public RadMenuItem menuDelete;
        private bool _IsActive = true;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbStatus = new Telerik.WinControls.UI.RadLabel();
            this.ContextMenu = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.menuSetting = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            this.menuDelete = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.lbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lbStatus.Location = new System.Drawing.Point(2, -3);
            this.lbStatus.Name = "lbStatus";
            this.radContextMenuManager1.SetRadContextMenu(this.lbStatus, this.ContextMenu);
            this.lbStatus.Size = new System.Drawing.Size(14, 21);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "0";
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuSetting,
            this.menuDelete});
            // 
            // menuSetting
            // 
            this.menuSetting.AccessibleDescription = "Setting";
            this.menuSetting.AccessibleName = "Setting";
            this.menuSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuSetting.Image = global::HDSComponent.Properties.Resources.setting;
            this.menuSetting.Name = "menuSetting";
            this.menuSetting.Text = "Setting";
            this.menuSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuDelete
            // 
            this.menuDelete.AccessibleDescription = "Delete";
            this.menuDelete.AccessibleName = "Delete";
            this.menuDelete.Image = global::HDSComponent.Properties.Resources.Delete;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Text = "Delete";
            this.menuDelete.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // HDIndicator
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lbStatus);
            this.Name = "HDIndicator";
            this.radContextMenuManager1.SetRadContextMenu(this, this.ContextMenu);
            this.Size = new System.Drawing.Size(16, 16);
            ((System.ComponentModel.ISupportInitialize)(this.lbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public HDIndicator()
        {
            DisplayTag = new IDisplayTag();
            DisplayTag.Name = "";
            DisplayTag.Address = "";
            DisplayTag.Value = new object();
            DisplayTag.Quality = Quality.Good;
            DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
            _IsActive = true;

            InitializeComponent();

            menuSetting.Tag = this;
            menuDelete.Tag = this;
            this.MouseDown += HDIndicator_MouseDown;
            this.Enter += HDIndicator_Enter;
            this.Leave += HDIndicator_Leave;
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            try
            {
                if (DataMapping.ContainsKey(DisplayTag.Value))
                {
                    this.BackgroundImage = DataMapping[DisplayTag.Value];
                }
                else
                {
                    this.BackgroundImage = null;
                }
            }
            catch (Exception)
            { }
        }

        public string DisplayText
        {
            get
            {
                return lbStatus.Text;
            }
            set
            {
                lbStatus.Text = value;
            }
        }

        #region drag
        private void HDIndicator_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DoDragDrop(e.X, e.Y);
            }
        }

        public void DoDragDrop(int XAxis, int YAxis)
        {
            this.DoDragDrop(new object[] { this, XAxis, YAxis }, DragDropEffects.Copy | DragDropEffects.Move);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_IsActive)
            {
                if (keyData == Keys.Left)
                {
                    this.Location = new Point(this.Location.X - 1, this.Location.Y);
                }
                else if (keyData == Keys.Right)
                {
                    this.Location = new Point(this.Location.X + 1, this.Location.Y);
                }
                else if (keyData == Keys.Up)
                {
                    this.Location = new Point(this.Location.X, this.Location.Y - 1);
                }
                else if (keyData == Keys.Down)
                {
                    this.Location = new Point(this.Location.X, this.Location.Y + 1);
                }
                this.Select();
            }
            return true;
        }

        private void HDIndicator_Leave(object sender, EventArgs e)
        {
            _IsActive = false;
        }

        private void HDIndicator_Enter(object sender, EventArgs e)
        {
            _IsActive = true;
        }
        #endregion

    }
}

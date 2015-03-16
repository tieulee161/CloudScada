namespace Designer.View
{
    partial class FrmVDKDetail
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
            this.picJunction = new Telerik.WinControls.UI.RadPanel();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.radMenuHeaderItem1 = new Telerik.WinControls.UI.RadMenuHeaderItem();
            this.menuChangeMap = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuHeaderItem2 = new Telerik.WinControls.UI.RadMenuHeaderItem();
            this.menuVehicleGreen = new Telerik.WinControls.UI.RadMenuItem();
            this.menuVehicleYellow = new Telerik.WinControls.UI.RadMenuItem();
            this.menuVehicleRed = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuHeaderItem3 = new Telerik.WinControls.UI.RadMenuHeaderItem();
            this.menuPedestrianGreen = new Telerik.WinControls.UI.RadMenuItem();
            this.menuPedestrianRed = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuHeaderItem4 = new Telerik.WinControls.UI.RadMenuHeaderItem();
            this.menuArrowGreen = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowGreenAhead = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowGreenBack = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowGreenLeft = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowGreenRight = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowYellow = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowYellowAhead = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowYellowBack = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowYellowLeft = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowYellowRight = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowRed = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowRedAhead = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowRedBack = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowRedLeft = new Telerik.WinControls.UI.RadMenuItem();
            this.menuArrowRedRight = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            ((System.ComponentModel.ISupportInitialize)(this.picJunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // picJunction
            // 
            this.picJunction.AllowDrop = true;
            this.picJunction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picJunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picJunction.Location = new System.Drawing.Point(0, 0);
            this.picJunction.Name = "picJunction";
            this.radContextMenuManager1.SetRadContextMenu(this.picJunction, this.radContextMenu1);
            this.picJunction.Size = new System.Drawing.Size(616, 422);
            this.picJunction.TabIndex = 3;
            // 
            // radContextMenu1
            // 
            this.radContextMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuHeaderItem1,
            this.menuChangeMap,
            this.radMenuHeaderItem2,
            this.menuVehicleGreen,
            this.menuVehicleYellow,
            this.menuVehicleRed,
            this.radMenuHeaderItem3,
            this.menuPedestrianGreen,
            this.menuPedestrianRed,
            this.radMenuHeaderItem4,
            this.menuArrowGreen,
            this.menuArrowYellow,
            this.menuArrowRed});
            // 
            // radMenuHeaderItem1
            // 
            this.radMenuHeaderItem1.AccessibleDescription = "Sơ đồ giao lộ";
            this.radMenuHeaderItem1.AccessibleName = "Sơ đồ giao lộ";
            this.radMenuHeaderItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMenuHeaderItem1.Image = global::Designer.Properties.Resources.Map;
            this.radMenuHeaderItem1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radMenuHeaderItem1.Name = "radMenuHeaderItem1";
            this.radMenuHeaderItem1.Text = "Sơ đồ giao lộ";
            this.radMenuHeaderItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuChangeMap
            // 
            this.menuChangeMap.AccessibleDescription = "Thay đổi sơ đồ";
            this.menuChangeMap.AccessibleName = "Thay đổi sơ đồ";
            this.menuChangeMap.Name = "menuChangeMap";
            this.menuChangeMap.Text = "Thay đổi sơ đồ";
            this.menuChangeMap.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuHeaderItem2
            // 
            this.radMenuHeaderItem2.AccessibleDescription = "Đèn xe cộ";
            this.radMenuHeaderItem2.AccessibleName = "Đèn xe cộ";
            this.radMenuHeaderItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMenuHeaderItem2.Image = global::Designer.Properties.Resources.Car;
            this.radMenuHeaderItem2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radMenuHeaderItem2.Name = "radMenuHeaderItem2";
            this.radMenuHeaderItem2.Text = "Đèn xe cộ";
            this.radMenuHeaderItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuVehicleGreen
            // 
            this.menuVehicleGreen.AccessibleDescription = "Đèn xanh";
            this.menuVehicleGreen.AccessibleName = "Đèn xanh";
            this.menuVehicleGreen.Name = "menuVehicleGreen";
            this.menuVehicleGreen.Text = "Đèn xanh";
            this.menuVehicleGreen.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuVehicleYellow
            // 
            this.menuVehicleYellow.AccessibleDescription = "Đèn vàng";
            this.menuVehicleYellow.AccessibleName = "Đèn vàng";
            this.menuVehicleYellow.Name = "menuVehicleYellow";
            this.menuVehicleYellow.Text = "Đèn vàng";
            this.menuVehicleYellow.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuVehicleRed
            // 
            this.menuVehicleRed.AccessibleDescription = "Đèn đỏ";
            this.menuVehicleRed.AccessibleName = "Đèn đỏ";
            this.menuVehicleRed.Name = "menuVehicleRed";
            this.menuVehicleRed.Text = "Đèn đỏ";
            this.menuVehicleRed.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuHeaderItem3
            // 
            this.radMenuHeaderItem3.AccessibleDescription = "Đèn đi bộ";
            this.radMenuHeaderItem3.AccessibleName = "Đèn đi bộ";
            this.radMenuHeaderItem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMenuHeaderItem3.Image = global::Designer.Properties.Resources.Pedestrian;
            this.radMenuHeaderItem3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radMenuHeaderItem3.Name = "radMenuHeaderItem3";
            this.radMenuHeaderItem3.Text = "Đèn đi bộ";
            this.radMenuHeaderItem3.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuPedestrianGreen
            // 
            this.menuPedestrianGreen.AccessibleDescription = "Đèn xanh";
            this.menuPedestrianGreen.AccessibleName = "Đèn xanh";
            this.menuPedestrianGreen.Name = "menuPedestrianGreen";
            this.menuPedestrianGreen.Text = "Đèn xanh";
            this.menuPedestrianGreen.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuPedestrianRed
            // 
            this.menuPedestrianRed.AccessibleDescription = "Đèn đỏ";
            this.menuPedestrianRed.AccessibleName = "Đèn đỏ";
            this.menuPedestrianRed.Name = "menuPedestrianRed";
            this.menuPedestrianRed.Text = "Đèn đỏ";
            this.menuPedestrianRed.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuHeaderItem4
            // 
            this.radMenuHeaderItem4.AccessibleDescription = "Đèn mũi tên";
            this.radMenuHeaderItem4.AccessibleName = "Đèn mũi tên";
            this.radMenuHeaderItem4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMenuHeaderItem4.Image = global::Designer.Properties.Resources.ArrowAll;
            this.radMenuHeaderItem4.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radMenuHeaderItem4.Name = "radMenuHeaderItem4";
            this.radMenuHeaderItem4.Text = "Đèn mũi tên";
            this.radMenuHeaderItem4.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowGreen
            // 
            this.menuArrowGreen.AccessibleDescription = "Đèn xanh";
            this.menuArrowGreen.AccessibleName = "Đèn xanh";
            this.menuArrowGreen.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuArrowGreenAhead,
            this.menuArrowGreenBack,
            this.menuArrowGreenLeft,
            this.menuArrowGreenRight});
            this.menuArrowGreen.Name = "menuArrowGreen";
            this.menuArrowGreen.Text = "Đèn xanh";
            this.menuArrowGreen.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowGreenAhead
            // 
            this.menuArrowGreenAhead.AccessibleDescription = "Đi thẳng";
            this.menuArrowGreenAhead.AccessibleName = "Đi thẳng";
            this.menuArrowGreenAhead.Name = "menuArrowGreenAhead";
            this.menuArrowGreenAhead.Text = "Đi thẳng";
            this.menuArrowGreenAhead.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowGreenBack
            // 
            this.menuArrowGreenBack.AccessibleDescription = "Đi thẳng quay 180º";
            this.menuArrowGreenBack.AccessibleName = "Đi thẳng quay 180º";
            this.menuArrowGreenBack.Name = "menuArrowGreenBack";
            this.menuArrowGreenBack.Text = "Đi thẳng quay 180º";
            this.menuArrowGreenBack.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowGreenLeft
            // 
            this.menuArrowGreenLeft.AccessibleDescription = "Rẽ trái";
            this.menuArrowGreenLeft.AccessibleName = "Rẽ trái";
            this.menuArrowGreenLeft.Name = "menuArrowGreenLeft";
            this.menuArrowGreenLeft.Text = "Rẽ trái";
            this.menuArrowGreenLeft.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowGreenRight
            // 
            this.menuArrowGreenRight.AccessibleDescription = "Rẽ phải";
            this.menuArrowGreenRight.AccessibleName = "Rẽ phải";
            this.menuArrowGreenRight.Name = "menuArrowGreenRight";
            this.menuArrowGreenRight.Text = "Rẽ phải";
            this.menuArrowGreenRight.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowYellow
            // 
            this.menuArrowYellow.AccessibleDescription = "Đèn vàng";
            this.menuArrowYellow.AccessibleName = "Đèn vàng";
            this.menuArrowYellow.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuArrowYellowAhead,
            this.menuArrowYellowBack,
            this.menuArrowYellowLeft,
            this.menuArrowYellowRight});
            this.menuArrowYellow.Name = "menuArrowYellow";
            this.menuArrowYellow.Text = "Đèn vàng";
            this.menuArrowYellow.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowYellowAhead
            // 
            this.menuArrowYellowAhead.AccessibleDescription = "Đi thẳng";
            this.menuArrowYellowAhead.AccessibleName = "Đi thẳng";
            this.menuArrowYellowAhead.Name = "menuArrowYellowAhead";
            this.menuArrowYellowAhead.Text = "Đi thẳng";
            this.menuArrowYellowAhead.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowYellowBack
            // 
            this.menuArrowYellowBack.AccessibleDescription = "Đi thẳng quay 180°C";
            this.menuArrowYellowBack.AccessibleName = "Đi thẳng quay 180°C";
            this.menuArrowYellowBack.Name = "menuArrowYellowBack";
            this.menuArrowYellowBack.Text = "Đi thẳng quay 180°C";
            this.menuArrowYellowBack.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowYellowLeft
            // 
            this.menuArrowYellowLeft.AccessibleDescription = "Rẽ trái";
            this.menuArrowYellowLeft.AccessibleName = "Rẽ trái";
            this.menuArrowYellowLeft.Name = "menuArrowYellowLeft";
            this.menuArrowYellowLeft.Text = "Rẽ trái";
            this.menuArrowYellowLeft.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowYellowRight
            // 
            this.menuArrowYellowRight.AccessibleDescription = "Rẽ phải";
            this.menuArrowYellowRight.AccessibleName = "Rẽ phải";
            this.menuArrowYellowRight.Name = "menuArrowYellowRight";
            this.menuArrowYellowRight.Text = "Rẽ phải";
            this.menuArrowYellowRight.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowRed
            // 
            this.menuArrowRed.AccessibleDescription = "Đèn đỏ";
            this.menuArrowRed.AccessibleName = "Đèn đỏ";
            this.menuArrowRed.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuArrowRedAhead,
            this.menuArrowRedBack,
            this.menuArrowRedLeft,
            this.menuArrowRedRight});
            this.menuArrowRed.Name = "menuArrowRed";
            this.menuArrowRed.Text = "Đèn đỏ";
            this.menuArrowRed.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowRedAhead
            // 
            this.menuArrowRedAhead.AccessibleDescription = "Đi thẳng";
            this.menuArrowRedAhead.AccessibleName = "Đi thẳng";
            this.menuArrowRedAhead.Name = "menuArrowRedAhead";
            this.menuArrowRedAhead.Text = "Đi thẳng";
            this.menuArrowRedAhead.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowRedBack
            // 
            this.menuArrowRedBack.AccessibleDescription = "Đi thẳng quay 180°C";
            this.menuArrowRedBack.AccessibleName = "Đi thẳng quay 180°C";
            this.menuArrowRedBack.Name = "menuArrowRedBack";
            this.menuArrowRedBack.Text = "Đi thẳng quay 180°C";
            this.menuArrowRedBack.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowRedLeft
            // 
            this.menuArrowRedLeft.AccessibleDescription = "Rẽ trái";
            this.menuArrowRedLeft.AccessibleName = "Rẽ trái";
            this.menuArrowRedLeft.Name = "menuArrowRedLeft";
            this.menuArrowRedLeft.Text = "Rẽ trái";
            this.menuArrowRedLeft.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuArrowRedRight
            // 
            this.menuArrowRedRight.AccessibleDescription = "Rẽ phải";
            this.menuArrowRedRight.AccessibleName = "Rẽ phải";
            this.menuArrowRedRight.Name = "menuArrowRedRight";
            this.menuArrowRedRight.Text = "Rẽ phải";
            this.menuArrowRedRight.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // FrmVDKDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 422);
            this.Controls.Add(this.picJunction);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmVDKDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Giao lộ";
            this.ThemeName = "ControlDefault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVDKDetail_FormClosing);
            this.Enter += new System.EventHandler(this.FrmVDKDetail_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.picJunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel picJunction;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadMenuHeaderItem radMenuHeaderItem1;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private Telerik.WinControls.UI.RadMenuItem menuChangeMap;
        private Telerik.WinControls.UI.RadMenuHeaderItem radMenuHeaderItem2;
        private Telerik.WinControls.UI.RadMenuItem menuVehicleGreen;
        private Telerik.WinControls.UI.RadMenuItem menuVehicleYellow;
        private Telerik.WinControls.UI.RadMenuItem menuVehicleRed;
        private Telerik.WinControls.UI.RadMenuHeaderItem radMenuHeaderItem3;
        private Telerik.WinControls.UI.RadMenuItem menuPedestrianGreen;
        private Telerik.WinControls.UI.RadMenuItem menuPedestrianRed;
        private Telerik.WinControls.UI.RadMenuHeaderItem radMenuHeaderItem4;
        private Telerik.WinControls.UI.RadMenuItem menuArrowGreen;
        private Telerik.WinControls.UI.RadMenuItem menuArrowYellow;
        private Telerik.WinControls.UI.RadMenuItem menuArrowRed;
        private Telerik.WinControls.UI.RadMenuItem menuArrowGreenAhead;
        private Telerik.WinControls.UI.RadMenuItem menuArrowGreenBack;
        private Telerik.WinControls.UI.RadMenuItem menuArrowGreenLeft;
        private Telerik.WinControls.UI.RadMenuItem menuArrowGreenRight;
        private Telerik.WinControls.UI.RadMenuItem menuArrowYellowAhead;
        private Telerik.WinControls.UI.RadMenuItem menuArrowYellowBack;
        private Telerik.WinControls.UI.RadMenuItem menuArrowYellowLeft;
        private Telerik.WinControls.UI.RadMenuItem menuArrowYellowRight;
        private Telerik.WinControls.UI.RadMenuItem menuArrowRedAhead;
        private Telerik.WinControls.UI.RadMenuItem menuArrowRedBack;
        private Telerik.WinControls.UI.RadMenuItem menuArrowRedLeft;
        private Telerik.WinControls.UI.RadMenuItem menuArrowRedRight;


    }
}

namespace Designer.View
{
    partial class FrmUpdateTOD
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            this.cbbxControlType = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.spinDiagramID = new Telerik.WinControls.UI.RadSpinEditor();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtPulses = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.spinOffset = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.spinID = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.spinHour = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.spinMinute = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.chkActive = new Telerik.WinControls.UI.RadCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxControlType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiagramID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPulses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbxControlType
            // 
            this.cbbxControlType.AllowShowFocusCues = false;
            this.cbbxControlType.AutoCompleteDisplayMember = null;
            this.cbbxControlType.AutoCompleteValueMember = null;
            this.cbbxControlType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxControlType.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            radListDataItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            radListDataItem1.Text = "Thông số";
            radListDataItem1.TextWrap = true;
            radListDataItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            radListDataItem2.Text = "Làn sóng xanh";
            radListDataItem2.TextWrap = true;
            radListDataItem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            radListDataItem3.Text = "Chớp vàng";
            radListDataItem3.TextWrap = true;
            radListDataItem4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            radListDataItem4.Text = "Tắt tủ";
            radListDataItem4.TextWrap = true;
            this.cbbxControlType.Items.Add(radListDataItem1);
            this.cbbxControlType.Items.Add(radListDataItem2);
            this.cbbxControlType.Items.Add(radListDataItem3);
            this.cbbxControlType.Items.Add(radListDataItem4);
            this.cbbxControlType.Location = new System.Drawing.Point(125, 64);
            this.cbbxControlType.Name = "cbbxControlType";
            this.cbbxControlType.Size = new System.Drawing.Size(196, 23);
            this.cbbxControlType.TabIndex = 13;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel3.Location = new System.Drawing.Point(18, 66);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(104, 21);
            this.radLabel3.TabIndex = 22;
            this.radLabel3.Text = "Kiểu điều khiển :";
            // 
            // spinDiagramID
            // 
            this.spinDiagramID.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinDiagramID.Location = new System.Drawing.Point(125, 93);
            this.spinDiagramID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinDiagramID.Name = "spinDiagramID";
            this.spinDiagramID.Size = new System.Drawing.Size(75, 23);
            this.spinDiagramID.TabIndex = 15;
            this.spinDiagramID.TabStop = false;
            this.spinDiagramID.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancel.Image = global::Designer.Properties.Resources.Delete;
            this.btnCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(227, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 24);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnUpdate.Image = global::Designer.Properties.Resources.Save;
            this.btnUpdate.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdate.Location = new System.Drawing.Point(126, 207);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 24);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.Click += new System.EventHandler(this.Button_Click);
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel5.Location = new System.Drawing.Point(18, 122);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(81, 21);
            this.radLabel5.TabIndex = 21;
            this.radLabel5.Text = "Chuỗi xung :";
            // 
            // txtPulses
            // 
            this.txtPulses.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPulses.Location = new System.Drawing.Point(125, 122);
            this.txtPulses.Name = "txtPulses";
            this.txtPulses.Size = new System.Drawing.Size(196, 23);
            this.txtPulses.TabIndex = 16;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel2.Location = new System.Drawing.Point(18, 95);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(98, 21);
            this.radLabel2.TabIndex = 17;
            this.radLabel2.Text = "Mã số giản đồ :";
            // 
            // spinOffset
            // 
            this.spinOffset.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinOffset.Location = new System.Drawing.Point(125, 151);
            this.spinOffset.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinOffset.Name = "spinOffset";
            this.spinOffset.Size = new System.Drawing.Size(75, 23);
            this.spinOffset.TabIndex = 23;
            this.spinOffset.TabStop = false;
            this.spinOffset.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel4.Location = new System.Drawing.Point(18, 153);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(49, 21);
            this.radLabel4.TabIndex = 24;
            this.radLabel4.Text = "Offset :";
            // 
            // spinID
            // 
            this.spinID.Enabled = false;
            this.spinID.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinID.Location = new System.Drawing.Point(125, 6);
            this.spinID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinID.Name = "spinID";
            this.spinID.ReadOnly = true;
            this.spinID.Size = new System.Drawing.Size(75, 23);
            this.spinID.TabIndex = 25;
            this.spinID.TabStop = false;
            this.spinID.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel1.Location = new System.Drawing.Point(18, 8);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(26, 21);
            this.radLabel1.TabIndex = 26;
            this.radLabel1.Text = "ID :";
            // 
            // spinHour
            // 
            this.spinHour.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinHour.Location = new System.Drawing.Point(125, 35);
            this.spinHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.spinHour.Name = "spinHour";
            this.spinHour.Size = new System.Drawing.Size(75, 23);
            this.spinHour.TabIndex = 27;
            this.spinHour.TabStop = false;
            this.spinHour.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel6.Location = new System.Drawing.Point(18, 35);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(34, 21);
            this.radLabel6.TabIndex = 28;
            this.radLabel6.Text = "Giờ :";
            // 
            // spinMinute
            // 
            this.spinMinute.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinMinute.Location = new System.Drawing.Point(246, 35);
            this.spinMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.spinMinute.Name = "spinMinute";
            this.spinMinute.Size = new System.Drawing.Size(75, 23);
            this.spinMinute.TabIndex = 29;
            this.spinMinute.TabStop = false;
            this.spinMinute.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel7.Location = new System.Drawing.Point(206, 37);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(41, 21);
            this.radLabel7.TabIndex = 30;
            this.radLabel7.Text = "Phút :";
            // 
            // chkActive
            // 
            this.chkActive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(125, 180);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(84, 21);
            this.chkActive.TabIndex = 31;
            this.chkActive.Text = "Hoạt động";
            // 
            // FrmUpdateTOD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 233);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.spinMinute);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.spinHour);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.spinID);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.spinOffset);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.cbbxControlType);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.spinDiagramID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.txtPulses);
            this.Controls.Add(this.radLabel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUpdateTOD";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật thời đoạn";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmUpdateTOD_Load);
            this.Click += new System.EventHandler(this.Button_Click);
            ((System.ComponentModel.ISupportInitialize)(this.cbbxControlType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDiagramID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPulses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cbbxControlType;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadSpinEditor spinDiagramID;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnUpdate;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtPulses;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadSpinEditor spinOffset;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadSpinEditor spinID;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadSpinEditor spinHour;
        private Telerik.WinControls.UI.RadSpinEditor spinMinute;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadCheckBox chkActive;
    }
}

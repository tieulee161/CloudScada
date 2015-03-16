namespace Designer.View
{
    partial class FrmDeviceSetting
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
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtNote = new Telerik.WinControls.UI.RadTextBox();
            this.intPort = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.cbbxDriver = new Telerik.WinControls.UI.RadDropDownList();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtAdress = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxDriver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtName.Location = new System.Drawing.Point(67, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(268, 23);
            this.txtName.TabIndex = 0;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel1.Location = new System.Drawing.Point(12, 10);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(49, 21);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Name :";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel2.Location = new System.Drawing.Point(12, 39);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(38, 21);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Port :";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel5.Location = new System.Drawing.Point(18, 68);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(43, 21);
            this.radLabel5.TabIndex = 9;
            this.radLabel5.Text = "Note :";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNote.Location = new System.Drawing.Point(67, 66);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(468, 23);
            this.txtNote.TabIndex = 4;
            // 
            // intPort
            // 
            this.intPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.intPort.Location = new System.Drawing.Point(67, 37);
            this.intPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.intPort.Name = "intPort";
            this.intPort.Size = new System.Drawing.Size(75, 23);
            this.intPort.TabIndex = 2;
            this.intPort.TabStop = false;
            this.intPort.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.intPort.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel3.Location = new System.Drawing.Point(341, 10);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(49, 21);
            this.radLabel3.TabIndex = 11;
            this.radLabel3.Text = "Driver :";
            // 
            // cbbxDriver
            // 
            this.cbbxDriver.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxDriver.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            radListDataItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            radListDataItem1.Text = "VDK";
            radListDataItem1.TextWrap = true;
            radListDataItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            radListDataItem2.Text = "OPC";
            radListDataItem2.TextWrap = true;
            this.cbbxDriver.Items.Add(radListDataItem1);
            this.cbbxDriver.Items.Add(radListDataItem2);
            this.cbbxDriver.Location = new System.Drawing.Point(396, 8);
            this.cbbxDriver.Name = "cbbxDriver";
            this.cbbxDriver.Size = new System.Drawing.Size(139, 23);
            this.cbbxDriver.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnAdd.Image = global::Designer.Properties.Resources.Add;
            this.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(240, 96);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 24);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancel.Image = global::Designer.Properties.Resources.Delete;
            this.btnCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(442, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 24);
            this.btnCancel.TabIndex = 7;
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
            this.btnUpdate.Location = new System.Drawing.Point(341, 96);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 24);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.Click += new System.EventHandler(this.Button_Click);
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel4.Location = new System.Drawing.Point(148, 39);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(61, 21);
            this.radLabel4.TabIndex = 13;
            this.radLabel4.Text = "Address :";
            // 
            // txtAdress
            // 
            this.txtAdress.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAdress.Location = new System.Drawing.Point(215, 37);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(320, 23);
            this.txtAdress.TabIndex = 3;
            // 
            // FrmDeviceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 125);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.cbbxDriver);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.intPort);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txtName);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDeviceSetting";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Information";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmUpdateServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxDriver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtNote;
        private Telerik.WinControls.UI.RadButton btnUpdate;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadSpinEditor intPort;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList cbbxDriver;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtAdress;
    }
}

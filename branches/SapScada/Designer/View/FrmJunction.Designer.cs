namespace Designer.View
{
    partial class FrmJunction
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
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cbbxTag = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtExpression = new Telerik.WinControls.UI.RadTextBox();
            this.cbbxDeviceName = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtJunctionName = new Telerik.WinControls.UI.RadTextBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxDeviceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJunctionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancel.Image = global::Designer.Properties.Resources.Delete;
            this.btnCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(376, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 24);
            this.btnCancel.TabIndex = 12;
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
            this.btnUpdate.Location = new System.Drawing.Point(275, 148);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 24);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.Click += new System.EventHandler(this.Button_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel1.Location = new System.Drawing.Point(5, 41);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(92, 21);
            this.radLabel1.TabIndex = 9;
            this.radLabel1.Text = "Device Name :";
            // 
            // cbbxTag
            // 
            this.cbbxTag.AllowShowFocusCues = false;
            this.cbbxTag.AutoCompleteDisplayMember = null;
            this.cbbxTag.AutoCompleteValueMember = null;
            this.cbbxTag.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxTag.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbbxTag.Location = new System.Drawing.Point(109, 68);
            this.cbbxTag.Name = "cbbxTag";
            this.cbbxTag.Size = new System.Drawing.Size(361, 23);
            this.cbbxTag.TabIndex = 13;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel3.Location = new System.Drawing.Point(5, 70);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(35, 21);
            this.radLabel3.TabIndex = 14;
            this.radLabel3.Text = "Tag :";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel2.Location = new System.Drawing.Point(5, 97);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 21);
            this.radLabel2.TabIndex = 16;
            this.radLabel2.Text = "Expression :";
            // 
            // txtExpression
            // 
            this.txtExpression.AutoSize = false;
            this.txtExpression.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtExpression.Location = new System.Drawing.Point(109, 97);
            this.txtExpression.Multiline = true;
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(361, 43);
            this.txtExpression.TabIndex = 15;
            // 
            // cbbxDeviceName
            // 
            this.cbbxDeviceName.AllowShowFocusCues = false;
            this.cbbxDeviceName.AutoCompleteDisplayMember = null;
            this.cbbxDeviceName.AutoCompleteValueMember = null;
            this.cbbxDeviceName.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxDeviceName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbbxDeviceName.Location = new System.Drawing.Point(109, 39);
            this.cbbxDeviceName.Name = "cbbxDeviceName";
            this.cbbxDeviceName.Size = new System.Drawing.Size(361, 23);
            this.cbbxDeviceName.TabIndex = 17;
            this.cbbxDeviceName.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbbxName_SelectedIndexChanged);
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel4.Location = new System.Drawing.Point(5, 12);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(102, 21);
            this.radLabel4.TabIndex = 18;
            this.radLabel4.Text = "Junction Name :";
            // 
            // txtJunctionName
            // 
            this.txtJunctionName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJunctionName.Location = new System.Drawing.Point(109, 13);
            this.txtJunctionName.Name = "txtJunctionName";
            this.txtJunctionName.Size = new System.Drawing.Size(361, 20);
            this.txtJunctionName.TabIndex = 19;
            // 
            // FrmJunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 177);
            this.Controls.Add(this.txtJunctionName);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.cbbxDeviceName);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtExpression);
            this.Controls.Add(this.cbbxTag);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.radLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmJunction";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Junction";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FrmJunction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxDeviceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJunctionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnUpdate;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList cbbxTag;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtExpression;
        private Telerik.WinControls.UI.RadDropDownList cbbxDeviceName;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBoxControl txtJunctionName;
    }
}

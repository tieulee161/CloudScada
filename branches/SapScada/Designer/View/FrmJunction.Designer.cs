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
            this.cbbxName = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancel.Image = global::Designer.Properties.Resources.Delete;
            this.btnCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(376, 120);
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
            this.btnUpdate.Location = new System.Drawing.Point(275, 120);
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
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(49, 21);
            this.radLabel1.TabIndex = 9;
            this.radLabel1.Text = "Name :";
            // 
            // cbbxTag
            // 
            this.cbbxTag.AllowShowFocusCues = false;
            this.cbbxTag.AutoCompleteDisplayMember = null;
            this.cbbxTag.AutoCompleteValueMember = null;
            this.cbbxTag.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxTag.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbbxTag.Location = new System.Drawing.Point(94, 39);
            this.cbbxTag.Name = "cbbxTag";
            this.cbbxTag.Size = new System.Drawing.Size(377, 23);
            this.cbbxTag.TabIndex = 13;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel3.Location = new System.Drawing.Point(12, 41);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(35, 21);
            this.radLabel3.TabIndex = 14;
            this.radLabel3.Text = "Tag :";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel2.Location = new System.Drawing.Point(12, 68);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 21);
            this.radLabel2.TabIndex = 16;
            this.radLabel2.Text = "Expression :";
            // 
            // txtExpression
            // 
            this.txtExpression.AutoSize = false;
            this.txtExpression.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtExpression.Location = new System.Drawing.Point(94, 68);
            this.txtExpression.Multiline = true;
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(377, 43);
            this.txtExpression.TabIndex = 15;
            // 
            // cbbxName
            // 
            this.cbbxName.AllowShowFocusCues = false;
            this.cbbxName.AutoCompleteDisplayMember = null;
            this.cbbxName.AutoCompleteValueMember = null;
            this.cbbxName.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbbxName.Location = new System.Drawing.Point(94, 10);
            this.cbbxName.Name = "cbbxName";
            this.cbbxName.Size = new System.Drawing.Size(377, 23);
            this.cbbxName.TabIndex = 17;
            this.cbbxName.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cbbxName_SelectedIndexChanged);
            // 
            // FrmJunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 149);
            this.Controls.Add(this.cbbxName);
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
            ((System.ComponentModel.ISupportInitialize)(this.cbbxName)).EndInit();
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
        private Telerik.WinControls.UI.RadDropDownList cbbxName;
    }
}

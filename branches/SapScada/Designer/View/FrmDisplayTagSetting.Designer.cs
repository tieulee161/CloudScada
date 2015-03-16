namespace Designer.View
{
    partial class FrmDisplayTagSetting
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
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.cbbxTag = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnSave.Image = global::Designer.Properties.Resources.Save;
            this.btnSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(363, 41);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 24);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel3.Location = new System.Drawing.Point(12, 14);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(35, 21);
            this.radLabel3.TabIndex = 44;
            this.radLabel3.Text = "Tag :";
            // 
            // cbbxTag
            // 
            this.cbbxTag.AllowShowFocusCues = false;
            this.cbbxTag.AutoCompleteDisplayMember = null;
            this.cbbxTag.AutoCompleteValueMember = null;
            this.cbbxTag.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxTag.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbbxTag.Location = new System.Drawing.Point(53, 12);
            this.cbbxTag.Name = "cbbxTag";
            this.cbbxTag.Size = new System.Drawing.Size(386, 23);
            this.cbbxTag.TabIndex = 45;
            // 
            // FrmDisplayTagSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 69);
            this.Controls.Add(this.cbbxTag);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmDisplayTagSetting";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.ThreeColorLampSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList cbbxTag;
    }
}

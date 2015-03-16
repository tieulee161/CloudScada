namespace Designer.View
{
    partial class FrmVDKPowerCard
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
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.chkError6 = new HDSComponent.UI.HDCheckBox();
            this.chkError5 = new HDSComponent.UI.HDCheckBox();
            this.chkError4 = new HDSComponent.UI.HDCheckBox();
            this.chkError3 = new HDSComponent.UI.HDCheckBox();
            this.chkError2 = new HDSComponent.UI.HDCheckBox();
            this.chkError1 = new HDSComponent.UI.HDCheckBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.chkError0 = new HDSComponent.UI.HDCheckBox();
            this.txtStatus = new HDSComponent.UI.HDTextbox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel20 = new Telerik.WinControls.UI.RadLabel();
            this.spinPLCIndex = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel16 = new Telerik.WinControls.UI.RadLabel();
            this.numberAlive = new HDSComponent.UI.HDNumberic();
            ((System.ComponentModel.ISupportInitialize)(this.chkError6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPLCIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberAlive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // chkError6
            // 
            this.chkError6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkError6.Location = new System.Drawing.Point(96, 382);
            this.chkError6.Name = "chkError6";
            this.chkError6.ReadOnly = true;
            this.chkError6.Size = new System.Drawing.Size(156, 21);
            this.chkError6.TabIndex = 133;
            this.chkError6.Text = "Bộ nhớ trên card bị lỗi";
            this.chkError6.ThemeName = "TelerikMetroBlue";
            // 
            // chkError5
            // 
            this.chkError5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkError5.Location = new System.Drawing.Point(96, 335);
            this.chkError5.Name = "chkError5";
            this.chkError5.ReadOnly = true;
            this.chkError5.Size = new System.Drawing.Size(167, 21);
            this.chkError5.TabIndex = 132;
            this.chkError5.Text = "Chip đọc cảm biến bị lỗi";
            this.chkError5.ThemeName = "TelerikMetroBlue";
            // 
            // chkError4
            // 
            this.chkError4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkError4.Location = new System.Drawing.Point(96, 288);
            this.chkError4.Name = "chkError4";
            this.chkError4.ReadOnly = true;
            this.chkError4.Size = new System.Drawing.Size(359, 21);
            this.chkError4.TabIndex = 131;
            this.chkError4.Text = "Ngưỡng dòng điện cho các đèn trên card chưa chính xác";
            this.chkError4.ThemeName = "TelerikMetroBlue";
            // 
            // chkError3
            // 
            this.chkError3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkError3.Location = new System.Drawing.Point(96, 241);
            this.chkError3.Name = "chkError3";
            this.chkError3.ReadOnly = true;
            this.chkError3.Size = new System.Drawing.Size(263, 21);
            this.chkError3.TabIndex = 130;
            this.chkError3.Text = "Lỗi giao tiếp giữa card công suất và CPU";
            this.chkError3.ThemeName = "TelerikMetroBlue";
            // 
            // chkError2
            // 
            this.chkError2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkError2.Location = new System.Drawing.Point(96, 194);
            this.chkError2.Name = "chkError2";
            this.chkError2.ReadOnly = true;
            this.chkError2.Size = new System.Drawing.Size(419, 21);
            this.chkError2.TabIndex = 129;
            this.chkError2.Text = "Dữ liệu điều khiển đèn phản hồi từ card công suất không chính xác";
            this.chkError2.ThemeName = "TelerikMetroBlue";
            // 
            // chkError1
            // 
            this.chkError1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkError1.Location = new System.Drawing.Point(96, 147);
            this.chkError1.Name = "chkError1";
            this.chkError1.ReadOnly = true;
            this.chkError1.Size = new System.Drawing.Size(323, 21);
            this.chkError1.TabIndex = 128;
            this.chkError1.Text = "Card công suất được gắn nhưng không thể kết nối";
            this.chkError1.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel2.Location = new System.Drawing.Point(59, 100);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(31, 21);
            this.radLabel2.TabIndex = 127;
            this.radLabel2.Text = "Lỗi :";
            // 
            // chkError0
            // 
            this.chkError0.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkError0.Location = new System.Drawing.Point(96, 100);
            this.chkError0.Name = "chkError0";
            this.chkError0.ReadOnly = true;
            this.chkError0.Size = new System.Drawing.Size(214, 21);
            this.chkError0.TabIndex = 126;
            this.chkError0.Text = "Card công suất không được gắn";
            this.chkError0.ThemeName = "TelerikMetroBlue";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtStatus.Location = new System.Drawing.Point(96, 55);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(419, 24);
            this.txtStatus.TabIndex = 3;
            this.txtStatus.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel1.Location = new System.Drawing.Point(17, 56);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(73, 21);
            this.radLabel1.TabIndex = 124;
            this.radLabel1.Text = "Trạng thái :";
            // 
            // radLabel20
            // 
            this.radLabel20.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel20.Location = new System.Drawing.Point(397, 13);
            this.radLabel20.Name = "radLabel20";
            this.radLabel20.Size = new System.Drawing.Size(42, 21);
            this.radLabel20.TabIndex = 122;
            this.radLabel20.Text = "Alive :";
            // 
            // spinPLCIndex
            // 
            this.spinPLCIndex.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.spinPLCIndex.Location = new System.Drawing.Point(96, 12);
            this.spinPLCIndex.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.spinPLCIndex.Name = "spinPLCIndex";
            this.spinPLCIndex.Size = new System.Drawing.Size(54, 24);
            this.spinPLCIndex.TabIndex = 1;
            this.spinPLCIndex.TabStop = false;
            this.spinPLCIndex.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinPLCIndex.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel16
            // 
            this.radLabel16.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radLabel16.Location = new System.Drawing.Point(49, 15);
            this.radLabel16.Name = "radLabel16";
            this.radLabel16.Size = new System.Drawing.Size(41, 21);
            this.radLabel16.TabIndex = 120;
            this.radLabel16.Text = "Card :";
            // 
            // numberAlive
            // 
            this.numberAlive.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numberAlive.Location = new System.Drawing.Point(446, 12);
            this.numberAlive.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numberAlive.Name = "numberAlive";
            this.numberAlive.ShowUpDownButtons = false;
            this.numberAlive.Size = new System.Drawing.Size(69, 24);
            this.numberAlive.TabIndex = 301;
            this.numberAlive.TabStop = false;
            this.numberAlive.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberAlive.ThemeName = "TelerikMetroBlue";
            // 
            // FrmVDKPowerCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 417);
            this.Controls.Add(this.numberAlive);
            this.Controls.Add(this.chkError6);
            this.Controls.Add(this.chkError5);
            this.Controls.Add(this.chkError4);
            this.Controls.Add(this.chkError3);
            this.Controls.Add(this.chkError2);
            this.Controls.Add(this.chkError1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.chkError0);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel20);
            this.Controls.Add(this.spinPLCIndex);
            this.Controls.Add(this.radLabel16);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmVDKPowerCard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Giám sát card công suất";
            this.ThemeName = "TelerikMetroBlue";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVDKPowerCard_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chkError6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkError0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPLCIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberAlive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private HDSComponent.UI.HDCheckBox chkError6;
        private HDSComponent.UI.HDCheckBox chkError5;
        private HDSComponent.UI.HDCheckBox chkError4;
        private HDSComponent.UI.HDCheckBox chkError3;
        private HDSComponent.UI.HDCheckBox chkError2;
        private HDSComponent.UI.HDCheckBox chkError1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private HDSComponent.UI.HDCheckBox chkError0;
        private HDSComponent.UI.HDTextbox txtStatus;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel20;
        private Telerik.WinControls.UI.RadSpinEditor spinPLCIndex;
        private Telerik.WinControls.UI.RadLabel radLabel16;
        private HDSComponent.UI.HDNumberic numberAlive;

    }
}

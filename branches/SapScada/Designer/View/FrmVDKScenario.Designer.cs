namespace Designer.View
{
    partial class FrmVDKScenario
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            this.dtgTOD = new Telerik.WinControls.UI.RadGridView();
            this.hdTrafficDiagram1 = new HDSComponent.UI.HDTrafficDiagram();
            this.treeScenario = new Telerik.WinControls.UI.RadTreeView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.treeDateType = new Telerik.WinControls.UI.RadTreeView();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTOD.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeScenario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeDateType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            this.radGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTOD
            // 
            this.dtgTOD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(240)))), ((int)(((byte)(249)))));
            this.dtgTOD.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgTOD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgTOD.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtgTOD.ForeColor = System.Drawing.Color.Black;
            this.dtgTOD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgTOD.Location = new System.Drawing.Point(2, 21);
            // 
            // dtgTOD
            // 
            this.dtgTOD.MasterTemplate.AllowAddNewRow = false;
            this.dtgTOD.MasterTemplate.AllowDeleteRow = false;
            this.dtgTOD.MasterTemplate.AllowRowResize = false;
            gridViewCheckBoxColumn1.Checked = Telerik.WinControls.Enumerations.ToggleState.Off;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.EnableHeaderCheckBox = false;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colActive";
            gridViewCheckBoxColumn1.Width = 37;
            gridViewDecimalColumn1.DecimalPlaces = 0;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.HeaderText = "ID";
            gridViewDecimalColumn1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            gridViewDecimalColumn1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn1.Name = "colID";
            gridViewDecimalColumn1.ReadOnly = true;
            gridViewDecimalColumn1.Width = 47;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Thời đoạn";
            gridViewTextBoxColumn1.Name = "colTOD";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn1.Width = 86;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.HeaderText = "Kiểu điều khiển";
            gridViewComboBoxColumn1.Name = "colControlType";
            gridViewComboBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewComboBoxColumn1.Width = 112;
            gridViewDecimalColumn2.DecimalPlaces = 0;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.HeaderText = "Mã số giản đồ";
            gridViewDecimalColumn2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            gridViewDecimalColumn2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn2.Name = "colDiagramID";
            gridViewDecimalColumn2.Width = 102;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Chuỗi xung";
            gridViewTextBoxColumn2.Name = "colPulses";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 185;
            gridViewDecimalColumn3.EnableExpressionEditor = false;
            gridViewDecimalColumn3.HeaderText = "Offset";
            gridViewDecimalColumn3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            gridViewDecimalColumn3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn3.Name = "colOffset";
            gridViewDecimalColumn3.Width = 100;
            gridViewCommandColumn1.DefaultText = "Cập nhật";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.IsVisible = false;
            gridViewCommandColumn1.Name = "column6";
            gridViewCommandColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 112;
            this.dtgTOD.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewComboBoxColumn1,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn3,
            gridViewCommandColumn1});
            this.dtgTOD.MasterTemplate.EnableGrouping = false;
            this.dtgTOD.Name = "dtgTOD";
            this.dtgTOD.ReadOnly = true;
            this.dtgTOD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgTOD.Size = new System.Drawing.Size(718, 206);
            this.dtgTOD.TabIndex = 1;
            // 
            // hdTrafficDiagram1
            // 
            this.hdTrafficDiagram1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hdTrafficDiagram1.Location = new System.Drawing.Point(2, 18);
            this.hdTrafficDiagram1.Name = "hdTrafficDiagram1";
            this.hdTrafficDiagram1.Size = new System.Drawing.Size(718, 334);
            this.hdTrafficDiagram1.TabIndex = 2;
            // 
            // treeScenario
            // 
            this.treeScenario.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeScenario.Location = new System.Drawing.Point(2, 50);
            this.treeScenario.Name = "treeScenario";
            this.treeScenario.Size = new System.Drawing.Size(165, 179);
            this.treeScenario.SpacingBetweenNodes = -1;
            this.treeScenario.TabIndex = 3;
            this.treeScenario.Text = "radTreeView1";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.btnRefresh);
            this.radGroupBox1.Controls.Add(this.treeScenario);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGroupBox1.HeaderText = "Kịch bản";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(2, 50, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(169, 583);
            this.radGroupBox1.TabIndex = 4;
            this.radGroupBox1.Text = "Kịch bản";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.treeDateType);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGroupBox2.HeaderText = "Ngày hoạt động";
            this.radGroupBox2.Location = new System.Drawing.Point(2, 229);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(2, 22, 2, 2);
            this.radGroupBox2.Size = new System.Drawing.Size(165, 352);
            this.radGroupBox2.TabIndex = 5;
            this.radGroupBox2.Text = "Ngày hoạt động";
            // 
            // treeDateType
            // 
            this.treeDateType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDateType.Location = new System.Drawing.Point(2, 22);
            this.treeDateType.Name = "treeDateType";
            this.treeDateType.Size = new System.Drawing.Size(161, 328);
            this.treeDateType.SpacingBetweenNodes = -1;
            this.treeDateType.TabIndex = 4;
            this.treeDateType.Text = "radTreeView2";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnRefresh.Image = global::Designer.Properties.Resources.Refresh_small;
            this.btnRefresh.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRefresh.Location = new System.Drawing.Point(2, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(162, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Đọc thông số cài đặt";
            this.btnRefresh.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.radGroupBox4);
            this.radGroupBox3.Controls.Add(this.dtgTOD);
            this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGroupBox3.HeaderText = "Thời đoạn";
            this.radGroupBox3.Location = new System.Drawing.Point(169, 0);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Padding = new System.Windows.Forms.Padding(2, 21, 2, 2);
            this.radGroupBox3.Size = new System.Drawing.Size(722, 229);
            this.radGroupBox3.TabIndex = 5;
            this.radGroupBox3.Text = "Thời đoạn";
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.HeaderText = "radGroupBox4";
            this.radGroupBox4.Location = new System.Drawing.Point(9, 228);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(435, 189);
            this.radGroupBox4.TabIndex = 2;
            this.radGroupBox4.Text = "radGroupBox4";
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.Controls.Add(this.hdTrafficDiagram1);
            this.radGroupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radGroupBox5.HeaderText = "Giản đồ";
            this.radGroupBox5.Location = new System.Drawing.Point(169, 229);
            this.radGroupBox5.Name = "radGroupBox5";
            this.radGroupBox5.Size = new System.Drawing.Size(722, 354);
            this.radGroupBox5.TabIndex = 6;
            this.radGroupBox5.Text = "Giản đồ";
            // 
            // FrmVDKScenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 583);
            this.Controls.Add(this.radGroupBox5);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmVDKScenario";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Kịch bản";
            this.ThemeName = "ControlDefault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVDKScenario_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTOD.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeScenario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeDateType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            this.radGroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dtgTOD;
        private HDSComponent.UI.HDTrafficDiagram hdTrafficDiagram1;
        private Telerik.WinControls.UI.RadTreeView treeScenario;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTreeView treeDateType;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;


    }
}

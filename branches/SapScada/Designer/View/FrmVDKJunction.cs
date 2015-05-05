using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Designer.View
{
    public partial class FrmVDKJunction : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }

        FrmVDKInfo _FrmVDKInfo;
        FrmVDKTime _FrmVDKTime;
        FrmVDKPeripheral _FrmVDKPeripheral;
        FrmVDKScenario _FrmVDKScenario;
        FrmVDKLight _FrmVDKLight;
        FrmVDKPowerCard _FrmVDKPowerCard;
        FrmVDKDetail _FrmVDKDetail;
        List<Form> _DisplayForm;

        public FrmVDKJunction()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.Size = new Size(640, 482);
            _DisplayForm = new List<Form>();
        }

        private void FrmVDKJunction_Load(object sender, EventArgs e)
        {
            this.Text = JunctionName;
            System.Windows.Forms.Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.RunWorkerCompleted += loadWorker_RunWorkerCompleted;
            loadWorker.RunWorkerAsync();
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _FrmVDKInfo = new FrmVDKInfo();
            _FrmVDKTime = new FrmVDKTime();
            _FrmVDKPeripheral = new FrmVDKPeripheral();
            _FrmVDKScenario = new FrmVDKScenario();
            _FrmVDKLight = new FrmVDKLight();
            _FrmVDKPowerCard = new FrmVDKPowerCard();
            _FrmVDKDetail = new FrmVDKDetail();

            _FrmVDKLight.JunctionName = this.JunctionName;
            _FrmVDKTime.JunctionName = this.JunctionName;
            _FrmVDKPowerCard.JunctionName = this.JunctionName;
            _FrmVDKPeripheral.JunctionName = this.JunctionName;
            _FrmVDKInfo.JunctionName = this.JunctionName;
            _FrmVDKScenario.JunctionName = this.JunctionName;
            _FrmVDKDetail.JunctionName = this.JunctionName;

            _DisplayForm.Add(_FrmVDKInfo);
            _DisplayForm.Add(_FrmVDKTime);
            _DisplayForm.Add(_FrmVDKPeripheral);
            _DisplayForm.Add(_FrmVDKScenario);
            _DisplayForm.Add(_FrmVDKLight);
            _DisplayForm.Add(_FrmVDKPowerCard);
            _DisplayForm.Add(_FrmVDKDetail);

            InitMdiChildren(_FrmVDKInfo);
            InitMdiChildren(_FrmVDKTime);
            InitMdiChildren(_FrmVDKPeripheral);
            InitMdiChildren(_FrmVDKScenario);
            InitMdiChildren(_FrmVDKLight);
            InitMdiChildren(_FrmVDKPowerCard);
            InitMdiChildren(_FrmVDKDetail);

            Timer timer1 = new Timer();
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            _FrmVDKInfo.Show();
            _FrmVDKTime.Show();
            _FrmVDKPeripheral.Show();
            _FrmVDKScenario.Show();
            _FrmVDKLight.Show();
            _FrmVDKPowerCard.Show();
            _FrmVDKDetail.Show();
        }

        private void InitMdiChildren(Form f)
        {
            f.Tag = this;
            f.MdiParent = this;
           
        }

        private void FrmVDKJunction_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            for (int j = _DisplayForm.Count - 1; j >= 0; j--)
            {
                _DisplayForm[j].Close();
            }
        }

    }
}

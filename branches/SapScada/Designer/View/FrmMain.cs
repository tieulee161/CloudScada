using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

using Designer.Model;
using Designer.Core;
using System.Threading;

namespace Designer.View
{
    public partial class FrmMain : Telerik.WinControls.UI.RadForm
    {
        private string _UserName = "";
        FrmWelcome _FrmWelcome;
        FrmGraphicDesign _FrmGraphicDesign;

        public FrmMain()
        {

            CheckForIllegalCrossThreadCalls = false;

            Thread t = new Thread(new ThreadStart(Run_SplashScreen));
            t.Start();

            InitializeComponent();
            this.Opacity = 0;
            this.Hide();
            ThemeResolutionService.ApplicationThemeName = telerikMetroBlueTheme1.ThemeName;
            this.Text = this.Text + " " + Program.version;
            //   menuGraphic.Enabled = false;
            //    DBAccess.WarmUpDatabase();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            while (!_FrmWelcome.IsDone) ;

            _FrmWelcome.Close();

            this.Show();
            this.Opacity = 100;
        }

        private void Run_SplashScreen()
        {
            _FrmWelcome = new FrmWelcome();
            Application.Run(_FrmWelcome);
        }

        private void AddLiveTilePanaroma()
        {
            //radLiveTileElement1.Children.Add(new LightVisualElement()
            //{
            //    Text = "Photo Album",
            //    TextAlignment = ContentAlignment.BottomLeft,
            //    ZIndex = 1000,
            //    Padding = new Padding(10),
            //    Font = new Font("Segoue UI Light", 9, GraphicsUnit.Point),
            //    ShouldHandleMouseInput = false,
            //    NotifyParentOnMouseInput = true,
            //    DrawFill = true,
            //    Margin = new Padding(0, 150, 0, 0),
            //    BackColor = Color.FromArgb(106, 161, 227),
            //    GradientStyle = GradientStyles.Solid,
            //    Opacity = 1
            //});
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender.Equals(menuServerSetting))
            {
                FrmServer f = new FrmServer();
                f.MdiParent = this;
                f.Show();
            }
            else if (sender.Equals(menuDeviceSetting))
            {
                FrmDevice f = new FrmDevice();
                f.MdiParent = this;
                f.Show();
            }
            else if (sender.Equals(menuTagSetting))
            {
                FrmIOTag f = new FrmIOTag();
                f.MdiParent = this;
                f.Show();
            }
            else if (sender.Equals(menuTrend))
            {
                FrmTrend f = new FrmTrend();
                f.Show();
            }
            else if (sender.Equals(menuGraphic))
            {
                //  _FrmGraphicDesign = new FrmGraphicDesign();
                //   _FrmGraphicDesign.Show();
                FrmMonitor f = new FrmMonitor();
                foreach (Alarm alarm in Program.Core.Alarms.Values)
                {
                    f.UCAlarmNewsControl.SetAlarm(alarm);
                }
                f.UCAlarmNewsControl.GetCurrentAlarm();
                f.Show();
            }
            else if (sender.Equals(menuStart))
            {
                menuStart.Visibility = ElementVisibility.Collapsed;
                menuStop.Visibility = ElementVisibility.Visible;
                Program.StartRuntime();
                timer1.Enabled = true;
                //    menuGraphic.Enabled = true;
            }
            else if (sender.Equals(menuStop))
            {
                menuStart.Visibility = ElementVisibility.Visible;
                menuStop.Visibility = ElementVisibility.Collapsed;
                Program.StopRuntime();
                timer1.Enabled = false;
                //          menuGraphic.Enabled = false;
            }
            else if (sender.Equals(menuAlarm))
            {
                FrmAlarm f = new FrmAlarm();
                foreach (Alarm alarm in Program.Core.Alarms.Values)
                {
                    f.UCAlarmControl.SetAlarm(alarm);
                }
                f.Show();
            }
            else if (sender.Equals(menuLogin))
            {
                FrmLogin f = new FrmLogin();
                f.ShowDialog();
                if (f.LoginUser != null)
                {
                    _UserName = f.LoginUser.Name;
                    menuLogin.Visibility = ElementVisibility.Collapsed;
                    menuLogout.Visibility = ElementVisibility.Visible;
                    menuChangePassword.Enabled = true;
                    lbUser.Text = "Đăng nhập : " + _UserName;
                    //try
                    //{
                    //    _UserRight = Program.Server.GetUserRight(f.LoginUser.Name, f.LoginUser.Password);
                    //}
                    //catch (Exception ex)
                    //{
                    //    ShowRemotingError(ex.Message + "\r\n Inner \r\n" + ex.InnerException);
                    //}

                    //enable features
                    //  EnableFeatures();
                }
            }
            else if (sender.Equals(menuLogout))
            {
                menuLogin.Visibility = ElementVisibility.Visible;
                menuLogout.Visibility = ElementVisibility.Collapsed;
                menuChangePassword.Enabled = false;
                lbUser.Text = "Đăng nhập : Chỉ xem";
                //   _UserRight = new List<int> { (int)eUserRight.ReadOnly };
                //enable features
                //    EnableFeatures();
            }
            else if (sender.Equals(menuChangePassword))
            {
                FrmChangePassword f = new FrmChangePassword();
                f.UserName = _UserName;
                f.ShowDialog();
            }
            else if (sender.Equals(menuUserManagement))
            {
                FrmUserManagement f = new FrmUserManagement();
                f.ShowDialog();
            }

        }

        public void CloseGraphicDesignerForm()
        {
            if ((_FrmGraphicDesign != null) && (!_FrmGraphicDesign.IsDisposed))
            {
                _FrmGraphicDesign.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            DateTime lastUpdate = Designer.Properties.Settings.Default.LastUpdateTime;
            if ((DateTime.Now - lastUpdate).TotalHours >= 4)
            {
                List<Device> devices = DBAccess.GetDevices();
                foreach (Device dev in devices)
                {
                    string tagName = "";
                    if (dev.Driver == "VDK")
                    {
                        tagName = string.Format("{0}.SetTime", dev.Name);
                    }
                    else
                    {
                        tagName = string.Format("{0}.SETTIME", dev.Name);
                    }
                    string tagAddress = Program.GetDisplayTagAddress(tagName);
                    Program.SetIOTag(tagName, tagAddress, new object[] { true });
                }

                Designer.Properties.Settings.Default.LastUpdateTime = DateTime.Now;
                Designer.Properties.Settings.Default.Save();
            }
        }
    }
}

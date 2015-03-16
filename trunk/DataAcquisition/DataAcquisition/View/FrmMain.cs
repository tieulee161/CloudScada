using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using OPCLib;
using IODriver;
using DriverCommon;
using Hotkeys;
using System.Threading;
using DataAcquisition.Service;
using DataAcquisition.Model.Entities;
using System.Diagnostics;

namespace DataAcquisition.View
{
    public partial class FrmMain : Telerik.WinControls.UI.RadForm
    {
        private DateTime _StartTime;

        private BackgroundWorker _Worker;

        public FrmMain()
        {
            InitializeComponent();
            lbStatus.Text = "";
            lbSpentTime.Text = "";

            _Worker = new BackgroundWorker();
            _Worker.DoWork += _Worker_DoWork;
            _Worker.RunWorkerCompleted += _Worker_RunWorkerCompleted;
            this.Disposed += FrmMain_Disposed;
        }

        private void FrmMain_Disposed(object sender, EventArgs e)
        {
            foreach (Process proc in Process.GetProcessesByName("DataAcquisition"))
            {
                Common.Logger.Log(string.Format("Kill program: {0}", proc.ProcessName));
                proc.Kill();
            }
        }

        private void _Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrepareLayout();
            PrepareGlobalKeyHook();
            _StartTime = DateTime.Now;
            timer1.Enabled = true;
        }

        private void _Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DriverHost.StartDriverHost();
            DriverHost.RaiseDataChangedEvent += DriverHost_RaiseDataChangedEvent;
            while (!DriverHost.IsDriverReady) ;
        }

        private void DriverHost_RaiseDataChangedEvent(DriverDataChangedArgs e)
        {
            try
            {
                List<DriverInfo> data = e.Data;
                if (IsShow)
                {
                    if (dtgInfo.Rows.Count == data.Count)
                    {
                        for (int j = 0; j < data.Count; j++)
                        {
                            dtgInfo.Rows[j].Cells["colStatus"].Value = data[j].Status;
                            dtgInfo.Rows[j].Cells["colSend"].Value = data[j].NumberOfSendingKB;
                            dtgInfo.Rows[j].Cells["colReceive"].Value = data[j].NumberOfReceivingKB;
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _Worker.RunWorkerAsync();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DriverHost.StopDriverHost();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(menuSetting))
            {
                FrmSetting f = new FrmSetting();
                f.ShowDialog();
            }
            else if (sender.Equals(menuReset))
            {
                DriverHost.ResetDataCounter();
            }
            else if (sender.Equals(menuHide))
            {
                IsShow = false;
            }
            else if (sender.Equals(menuAbout))
            {
                FrmAbout f = new FrmAbout();
                f.ShowDialog();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Now - _StartTime;
            lbSpentTime.Text = string.Format("Spent time: {0}:{1}:{2}", t.Hours.ToString("00"), t.Minutes.ToString("00"), t.Seconds.ToString("00"));
        }

        private void dtgInfo_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9.75);
        }
        private void PrepareLayout()
        {
            List<DriverInfo> data = DriverHost.DriverinfoList;
            for (int j = 0; j < data.Count; j++)
            {
                dtgInfo.Rows.Add(new object[] { data[j].DriverVersion,
                                                data[j].Port,
                                                data[j].Status,
                                                data[j].NumberOfSendingKB,
                                                data[j].NumberOfReceivingKB,
                                                data[j].DriverType
                                                });
            }
        }

        #region hide/unhide key F3
        private Hotkeys.GlobalHotkey _GlobalKey;
        private bool _IsShow = true;
        public bool IsShow
        {
            get
            {
                return _IsShow;
            }
            set
            {
                _IsShow = value;
                if (_IsShow)
                {
                    this.Show();
                    _GlobalKey.ActiveApplication();
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.Hide();
                }
            }
        }

        private void PrepareGlobalKeyHook()
        {
            _GlobalKey = new Hotkeys.GlobalHotkey(Hotkeys.Constants.NOMOD, Keys.F3, this);
            _GlobalKey.Register();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void HandleHotkey()
        {
            IsShow = !IsShow;
        }
        #endregion






    }

    public static class DriverHost
    {
        private static BackgroundWorker _BackGroundWorker = new BackgroundWorker();
        private static BackgroundWorker _ScanDataWorker = new BackgroundWorker();
        public static List<ITLCDriver> IDriver;
        public static ITLCDriver VDKDriver;
        public static ITLCDriver OPCDriver;
        private static List<int> VDKports = new List<int>(); // { 3000, 3001, 3002, 3003 };
        private static List<int> OPCports = new List<int>(); //{ 4000, 4001, 4002, 4003, 4004, 4005, 4006, 4007, 4008, 4009, 4010, 4011, 4012 };
        private static int _VDKServicePort, _OPCServicePort;
        private static string _ServerIOIP;
        public static bool IsDriverReady = false;
        public static List<DriverInfo> DriverinfoList;
        private static bool _IsRunning = false;

        private static void _ScanDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnDataChanged(new DriverDataChangedArgs(DriverinfoList));
            Thread.Sleep(10000);
            if (_IsRunning == true)
            {
                _ScanDataWorker.RunWorkerAsync();
            }
        }

        private static void _ScanDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (DriverInfo info in DriverinfoList)
            {
                bool isConnect = false;
                float numberOfSendingKB = 0;
                float numberOfReceivingKB = 0;
                int port = info.Port;
                switch (info.DriverType)
                {
                    case 0: // VDK
                        isConnect = VDKDriver.IsConnect(port);
                        numberOfReceivingKB = VDKDriver.GetNumberOfReceivingKB(port);
                        numberOfSendingKB = VDKDriver.GetNumberOfSendingKB(port);
                        break;
                    case 1: // OPC
                        isConnect = OPCDriver.IsConnect(port);
                        numberOfReceivingKB = OPCDriver.GetNumberOfReceivingKB(port);
                        numberOfSendingKB = OPCDriver.GetNumberOfSendingKB(port); ;
                        break;
                }

                if (isConnect)
                {
                    info.Status = "Connect";
                }
                else
                {
                    info.Status = "No connection";
                }

                info.NumberOfReceivingKB = (float)Math.Round(numberOfReceivingKB, 2);
                info.NumberOfSendingKB = (float)Math.Round(numberOfSendingKB, 2);
            }
        }

        private static void _BackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IDriver = new List<ITLCDriver>();
            DriverinfoList = new List<DriverInfo>();
            GetServiceInfoFromDatabase();
            PrepareVDKDriver();
            PrepareOPCClient();
            IsDriverReady = true;
            _IsRunning = true;
        }

        private static void _BackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _ScanDataWorker.RunWorkerAsync();
        }

        private static void PrepareVDKDriver()
        {
            int serverPort = _VDKServicePort;

            // host VDK driver for connecting from clients
            IODriver.VDKDriver.StartServer(_ServerIOIP, serverPort);

            // start VDK Driver
            VDKDriver = null;
            VDKDriver = IODriver.VDKDriver.Server;


            if ((_ServerIOIP != "") && (VDKports.Count > 0))
            {
                VDKDriver.Start(_ServerIOIP, VDKports);
            }

            // add all driver to list to manage all driver type more easily
            IDriver.Add(VDKDriver);

            // add this driver info
            for (int j = 0; j < VDKports.Count; j++)
            {
                DriverInfo info = new DriverInfo();
                info.DriverType = 0; // VDK
                info.DriverVersion = VDKDriver.GetDriverVersion();
                info.Port = VDKports[j];
                info.Status = "No connection";
                info.NumberOfReceivingKB = 0;
                info.NumberOfSendingKB = 0;
                DriverinfoList.Add(info);
            }
        }

        private static void PrepareOPCClient()
        {
            int serverPort = _OPCServicePort;

            // host OPC Driver
            OPCHost.StartServer(_ServerIOIP, serverPort);

            // Start OPC Driver
            OPCDriver = null;
            OPCDriver = OPCHost.Server;

            // dont implements these statement below at version 3.0.0 or higher
            //if ((_ServerIOIP != "") && (OPCports.Count > 0))
            //{
            //    OPCDriver.Start(_ServerIOIP, OPCports);
            //}

            // add all driver to list to manage all driver type more easily
            IDriver.Add(OPCDriver);

            // add this driver info
            for (int j = 0; j < OPCports.Count; j++)
            {
                DriverInfo info = new DriverInfo();
                info.DriverType = 1; // OPC
                info.DriverVersion = OPCDriver.GetDriverVersion();
                info.Port = OPCports[j];
                info.Status = "No connection";
                info.NumberOfReceivingKB = 0;
                info.NumberOfSendingKB = 0;
                DriverinfoList.Add(info);
            }
        }

        private static void GetServiceInfoFromDatabase()
        {
            ServiceInfo info = DBAccess.GetServiceInfo();
            if (info != null)
            {
                _ServerIOIP = info.ServerIP.Replace(" ", "").Replace(",", ".");
                _VDKServicePort = info.VDKServicePort;
                _OPCServicePort = info.OPCServicePort;
            }

            List<Port> VDKPorts = DBAccess.GetPorts(DriverType.VDK);
            foreach (Port p in VDKPorts)
            {
                VDKports.Add(p.DriverPort);
            }

            List<Port> OPCPorts = DBAccess.GetPorts(DriverType.OPC);
            foreach (Port p in OPCPorts)
            {
                OPCports.Add(p.DriverPort);
            }
        }

        public static void StartDriverHost()
        {
            _BackGroundWorker.DoWork += _BackGroundWorker_DoWork;
            _BackGroundWorker.RunWorkerCompleted += _BackGroundWorker_RunWorkerCompleted;
            _ScanDataWorker.DoWork += _ScanDataWorker_DoWork;
            _ScanDataWorker.RunWorkerCompleted += _ScanDataWorker_RunWorkerCompleted;

            _BackGroundWorker.RunWorkerAsync();
        }

        public static void StopDriverHost()
        {
            _IsRunning = false;
            VDKDriver.Stop();
            OPCDriver.Stop();
        }

        public static void ResetDataCounter()
        {
            for (int j = 0; j < VDKports.Count; j++)
            {
                VDKDriver.ResetDataTrafficCounter(VDKports[j]);
            }
            for (int j = 0; j < OPCports.Count; j++)
            {
                OPCDriver.ResetDataTrafficCounter(OPCports[j]);
            }
        }

        public delegate void DataChanged(DriverDataChangedArgs e);
        public static event DataChanged RaiseDataChangedEvent;
        private static void OnDataChanged(DriverDataChangedArgs e)
        {
            if (RaiseDataChangedEvent != null)
            {
                RaiseDataChangedEvent(e);
            }
        }

    }

    public class DriverInfo
    {
        public int DriverType;
        public string DriverVersion;
        public int Port;
        public string Status;
        public float NumberOfSendingKB;
        public float NumberOfReceivingKB;
    }

    public class DriverDataChangedArgs : EventArgs
    {
        public List<DriverInfo> Data;
        public DriverDataChangedArgs(List<DriverInfo> data)
        {
            this.Data = data;
        }
    }
}

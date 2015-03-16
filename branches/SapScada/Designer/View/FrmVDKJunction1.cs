using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Designer.Model;
using System.IO;
using HDSComponent;
using HDSComponent.UI;
using System.Threading;
using Common;
using Designer.Core;

namespace Designer.View
{
    public partial class FrmVDKJunction1 : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName;
        private Junction _Junction;
        private bool _IsAddingNewVehicleLamp = false;
        private bool _IsAddingNewPedestrianLamp = false;
        private List<IDisplayTag> _LampDisplayTag = new List<IDisplayTag>();

        public FrmVDKJunction1()
        {
            InitializeComponent();
        }

        private void FrmVDKJunction_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            rdAuto.IsChecked = true;
            this.Text = string.Format("VDK - {0}", JunctionName);
            this.txtPCTime.Enabled = true;
            this.graphTrend.LoadGraph();

            contextAddMap.Click += contextAddMap_Click;
            contextAddVehicleLamp.Click += contextAddMap_Click;
            contextAddPedestrianLamp.Click += contextAddMap_Click;
            contextAddArrowLamp.Click += contextAddMap_Click;

            ((System.Windows.Forms.Timer)sender).Enabled = false;

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.RunWorkerCompleted += loadWorker_RunWorkerCompleted;
            loadWorker.RunWorkerAsync();
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitializeDisplayTag();
        }

        private void FrmVDKJunction_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.RemoveDisplayForm(this);
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            if (rdRealtime.IsChecked)
            {
                IDisplayTag tag = sender as IDisplayTag;
                if ((tag != null) && (!this.IsDisposed))
                {
                    graphTrend.UpdateTrend(tag.Name, tag.Value, DateTime.Now);
                }
                else if (this.IsDisposed)
                {
                    tag.RaiseTagValueChangedEvent -= DisplayTag_RaiseTagValueChangedEvent;
                }
            }
        }

        private void btnSearchHistoricalTrend_Click(object sender, EventArgs e)
        {
            if (rdHistorical.IsChecked)
            {
                DateTime from = dateFrom.Value;
                DateTime to = dateTo.Value;
                for (int j = 0; j < _LampDisplayTag.Count; j++)
                {
                    List<IOTagValue> values = DBAccess.GetIOTagValue(_LampDisplayTag[j].Address, from, to);
                    object[] data = new object[values.Count];
                    DateTime[] time = new DateTime[values.Count];
                    for (int i = 0; i < values.Count; i++)
                    {
                        data[i] = double.Parse(values[i].Value);
                        time[i] = (DateTime)values[i].TimeStamp;
                        // graphTrend.UpdateTrend(_LampDisplayTag[j].Address, double.Parse(values[j].Value), (DateTime)values[j].TimeStamp);
                    }
                    graphTrend.UpdateTrend(_LampDisplayTag[j].Address, data, time);

                }
            }
        }

        private void tLamp_RaiseLampDeletingEvent(object sender, LampEventArgs e)
        {
            //if (!DesignerAccess.DeleteLamp(e.LampID))
            //{
            //    MessageHandler.DeleteRecordError();
            //}
        }

        private void contextAddMap_Click(object sender, EventArgs e)
        {
            if (sender.Equals(contextAddMap))
            {
                OpenFileDialog f = new OpenFileDialog();
                f.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string map = f.FileName;
                    if (File.Exists(map))
                    {
                        DesignerAccess.SetMap(JunctionName, map);
                        picJunction.BackgroundImage = Image.FromFile(map);
                    }
                    else
                    {
                        MessageHandler.AskForValidFilePath();
                    }
                }
            }
            else if (sender.Equals(contextAddVehicleLamp))
            {
                FrmThreeColorLamp tLamp = new FrmThreeColorLamp();
                Lamp lamp = null;
                if (DesignerAccess.AddLamp(_Junction.JunctionName, 0, tLamp.Location.X, tLamp.Location.Y, 0, "", "", 0, "", out lamp))
                {
                    tLamp.Lamp = lamp;
                    tLamp.InitDisplayTag();
                    picJunction.Controls.Add(tLamp);
                    tLamp.Location = picJunction.PointToClient(Cursor.Position);
                }
                else
                {
                    MessageHandler.AddRecordError();
                }

            }

            else if (sender.Equals(contextAddPedestrianLamp))
            {
                FrmPedestrianLight pLamp = new FrmPedestrianLight();
                Lamp lamp = null;
                if (DesignerAccess.AddLamp(_Junction.JunctionName, 0, pLamp.Location.X, pLamp.Location.Y, 0, "", "", 1, "", out lamp))
                {
                    pLamp.Lamp = lamp;
                    pLamp.InitDisplayTag();
                    picJunction.Controls.Add(pLamp);
                    pLamp.Location = picJunction.PointToClient(Cursor.Position);
                }
                else
                {
                    MessageHandler.AddRecordError();
                }
            }
            else if (sender.Equals(contextAddArrowLamp))
            {
                FrmArrowLamp pLamp = new FrmArrowLamp();
                Lamp lamp = null;
                if (DesignerAccess.AddLamp(_Junction.JunctionName, 0, pLamp.Location.X, pLamp.Location.Y, 0, "", "", 2, "", out lamp))
                {
                    pLamp.Lamp = lamp;
                    pLamp.InitDisplayTag();
                    picJunction.Controls.Add(pLamp);
                    pLamp.Location = picJunction.PointToClient(Cursor.Position);
                }
                else
                {
                    MessageHandler.AddRecordError();
                }
            }
        }

        private void rdAuto_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (sender.Equals(rdAuto))
            {
                cbbxControlType.Enabled = false;
                btnSwitchPhase.Enabled = false;
                //txtOffset.Enabled = false;
                //txtPulses.Enabled = false;
                //txtPeriod.Enabled = false;
            }
            else if (sender.Equals(rdRemote))
            {
                cbbxControlType.Enabled = true;
                btnSwitchPhase.Enabled = false;
                //txtOffset.Enabled = false;
                //txtPulses.Enabled = false;
                //txtPeriod.Enabled = false;
                btnSwitchPhase.Enabled = IsSelectColorControlType();


            }
            //else if (sender.Equals(rdCoordination))
            //{
            //    cbbxControlType.Enabled = false;
            //    btnSwitchPhase.Enabled = false;
            //    txtOffset.Enabled = true;
            //    txtPulses.Enabled = true;
            //    txtPeriod.Enabled = true;
            //}
        }

        private void cbbxControlType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            btnSwitchPhase.Enabled = IsSelectColorControlType();
        }

        private void intPLCIndex_ValueChanged(object sender, EventArgs e)
        {
            string tagName = "", address = "", taskName = "";
            if (sender.Equals(intPLCIndex))
            {
                try
                {
                    tagName = string.Format("{0}.PLCStatus.{1}", _Junction.JunctionName, intPLCIndex.Value);
                    address = Program.GetDisplayTagAddress(tagName);
                    if(address != "")
                    {
                    taskName = address.Substring(0, address.Length - tagName.Length - 1);
                    txtPLCStatus.DisplayTag.Address = address;
                    txtPLCStatus.DisplayTag.Name = tagName;
                        }
                }
                catch (Exception)
                {
                    MessageHandler.Error("Không có card này trong tủ !");
                }
 
            }
            else if (sender.Equals(intCard) || sender.Equals(intLight))
            {
                try
                {
                    tagName = string.Format("{0}.Current.{1}.{2}", _Junction.JunctionName, intCard.Value, intLight.Value);
                    address = Program.GetDisplayTagAddress(tagName);
                    if (address != "")
                    {
                        taskName = address.Substring(0, address.Length - tagName.Length - 1);
                        txtCurrent.DisplayTag.Address = address;
                        txtCurrent.DisplayTag.Name = tagName;
                    }

                    tagName = string.Format("{0}.Threshold.{1}.{2}", _Junction.JunctionName, intCard.Value, intLight.Value);
                    address = Program.GetDisplayTagAddress(tagName);
                    if (address != "")
                    {
                        taskName = address.Substring(0, address.Length - tagName.Length - 1);
                        txtThreshold.DisplayTag.Address = address;
                        txtThreshold.DisplayTag.Name = tagName;
                    }
                }
                catch (Exception)
                {
                    MessageHandler.Error("Không có card (line) này trong tủ !");
                }
            }
            
        }
        
        private bool IsSelectColorControlType()
        {
            bool res = false;
            if (cbbxControlType.SelectedItem != null)
            {
                if (cbbxControlType.SelectedIndex == 0)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            return res;
        }

        private void InitializeDisplayTag()
        {
            #region load graphics
            _Junction = DesignerAccess.GetJunction(JunctionName);
            if (_Junction != null)
            {
                if (File.Exists(_Junction.Map))
                {
                    picJunction.BackgroundImage = Image.FromFile(_Junction.Map);
                }

                foreach (Lamp lamp in _Junction.Lamps.ToList())
                {
                    switch ((int)lamp.Type)
                    {
                        case 0: // three color lamp
                            FrmThreeColorLamp tLamp = new FrmThreeColorLamp();
                            tLamp.Lamp = lamp;
                            picJunction.Controls.Add(tLamp);

                            tLamp.InitDisplayTag();
                            tLamp.DisplayTag.Address = Program.GetDisplayTagAddress(lamp.Tag);
                            _LampDisplayTag.Add(tLamp.DisplayTag);
                            #region Trend
                            graphTrend.AddNewLine(tLamp.DisplayTag.Name);
                            tLamp.DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
                            #endregion
                            break;
                        case 1: // pedestrian lamp
                            FrmPedestrianLight pLamp = new FrmPedestrianLight();
                            pLamp.Lamp = lamp;
                            picJunction.Controls.Add(pLamp);

                            pLamp.InitDisplayTag();
                            pLamp.DisplayTag.Address = Program.GetDisplayTagAddress(lamp.Tag);
                            _LampDisplayTag.Add(pLamp.DisplayTag);
                            #region Trend
                            graphTrend.AddNewLine(pLamp.DisplayTag.Name);
                            pLamp.DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
                            #endregion
                            break;
                        case 2: // arrow lamp
                            FrmArrowLamp aLamp = new FrmArrowLamp();
                            aLamp.Lamp = lamp;
                            picJunction.Controls.Add(aLamp);

                            aLamp.InitDisplayTag();
                            aLamp.DisplayTag.Address = Program.GetDisplayTagAddress(lamp.Tag);
                            _LampDisplayTag.Add(aLamp.DisplayTag);
                            #region Trend
                            graphTrend.AddNewLine(aLamp.DisplayTag.Name);
                            aLamp.DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
                            #endregion
                            break;
                    }
                }

                string tagName = string.Format("{0}.ControlMode", _Junction.JunctionName);
                string address = Program.GetDisplayTagAddress(tagName);
                txtControlMode.DisplayTag.Address = address;
                txtControlMode.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.ControlType", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtControlType.DisplayTag.Address = address;
                txtControlType.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.ID", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtBoxID.DisplayTag.Address = address;
                txtBoxID.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.Temperature", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtTemperature.DisplayTag.Address = address;
                txtTemperature.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.Bat", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtBat.DisplayTag.Address = address;
                txtBat.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.Source", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtSource.DisplayTag.Address = address;
                txtSource.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.Time", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtTime.DisplayTag.Address = address;
                txtTime.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.PowerOn", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtPowerOn.DisplayTag.Address = address;
                txtPowerOn.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.PowerOff", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtPowerOff.DisplayTag.Address = address;
                txtPowerOff.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.IOStatus", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtIOStatus.DisplayTag.Address = address;
                txtIOStatus.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.HMIStatus", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtHMIStatus.DisplayTag.Address = address;
                txtHMIStatus.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.SDStatus", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtSDStatus.DisplayTag.Address = address;
                txtSDStatus.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.PLCStatus.0", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtPLCStatus.DisplayTag.Address = address;
                txtPLCStatus.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.Current.0.0", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtCurrent.DisplayTag.Address = address;
                txtCurrent.DisplayTag.Name = tagName;

                tagName = string.Format("{0}.Threshold.0.0", _Junction.JunctionName);
                address = Program.GetDisplayTagAddress(tagName);
                txtThreshold.DisplayTag.Address = address;
                txtThreshold.DisplayTag.Name = tagName;

                Display page1 = new Display(1000);
                for (int j = 0; j < _LampDisplayTag.Count; j++)
                {
                    page1.AddTag(_LampDisplayTag[j]);
                }
                page1.AddTag(txtControlMode.DisplayTag);
                page1.AddTag(txtControlType.DisplayTag);
                page1.AddTag(txtBoxID.DisplayTag);
                page1.AddTag(txtTemperature.DisplayTag);
                page1.AddTag(txtBat.DisplayTag);
                page1.AddTag(txtSource.DisplayTag);
                page1.AddTag(txtTime.DisplayTag);

                Display page2 = new Display(1000);
                page2.AddTag(txtPowerOn.DisplayTag);
                page2.AddTag(txtPowerOff.DisplayTag);
                page2.AddTag(txtIOStatus.DisplayTag);
                page2.AddTag(txtHMIStatus.DisplayTag);
                page2.AddTag(txtSDStatus.DisplayTag);
                page2.AddTag(txtPLCStatus.DisplayTag);
                page2.AddTag(txtCurrent.DisplayTag);
                page2.AddTag(txtThreshold.DisplayTag);

                Program.AddDisplayForm(this, new List<Display>() { page1, page2 });

            }
            #endregion
        }

        #region dont use any more
        private void picJunction_Click(object sender, EventArgs e)
        {
            if (_IsAddingNewVehicleLamp)
            {
                _IsAddingNewVehicleLamp = false;

                //HDSComponent.UI.ThreeColorLamp lamp = new HDSComponent.UI.ThreeColorLamp();
                //picJunction.Controls.Add(lamp);

                //  lamp.Location = Cursor.Position;

            }
            else if (_IsAddingNewPedestrianLamp)
            {

            }
        }
        #endregion

        #region drag-drop
        private void picJunction_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] type = e.Data.GetFormats();
                object[] data = (object[])e.Data.GetData(type[0]);
                UserControl uc = (UserControl)data[0];
                int x = (int)data[1];
                int y = (int)data[2];

                uc.Parent = picJunction;
                uc.Location = picJunction.PointToClient(new Point(e.X - x, e.Y - y));
                uc.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picJunction_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnRefresh))
            {
                string taskName = "";
                string tagName = string.Format("{0}.Current.{1}.{2}", _Junction.JunctionName, intCard.Value, intLight.Value);
                string address = Program.GetDisplayTagAddress(tagName);
                taskName = address.Substring(0, address.Length - tagName.Length - 1);
                txtCurrent.DisplayTag.Address = address;
                txtCurrent.DisplayTag.Name = tagName;
                Program.RefreshTask(taskName);

                tagName = string.Format("{0}.PLCStatus.{1}", _Junction.JunctionName, intPLCIndex.Value);
                address = Program.GetDisplayTagAddress(tagName);
                taskName = address.Substring(0, address.Length - tagName.Length - 1);
                txtPLCStatus.DisplayTag.Address = address;
                txtPLCStatus.DisplayTag.Name = tagName;
                Program.RefreshTask(taskName);

                tagName = string.Format("{0}.Threshold.{1}.{2}", _Junction.JunctionName, intCard.Value, intLight.Value);
                address = Program.GetDisplayTagAddress(tagName);
                taskName = address.Substring(0, address.Length - tagName.Length - 1);
                txtThreshold.DisplayTag.Address = address;
                txtThreshold.DisplayTag.Name = tagName;
                Program.RefreshTask(taskName);
            }
            else if (sender.Equals(btnSetTime))
            {
                Program.SetIOTag(txtTime.DisplayTag.Name, txtTime.DisplayTag.Address, new object[] { DateTime.Now });
            }
            else if (sender.Equals(btnSetControlMode))
            {
                byte mode = (int)IODriver.NetModeCommand.Auto;
                bool isControlModeSelected = true;
                if (rdAuto.IsChecked) mode = (int)IODriver.NetModeCommand.Auto;
                else if (rdRemote.IsChecked)
                {
                    switch (cbbxControlType.SelectedIndex)
                    {
                        case 0:
                            mode = (int)IODriver.NetModeCommand.Remote_Color;
                            break;
                        case 1:
                            mode = (int)IODriver.NetModeCommand.Remote_Flash;
                            break;
                        case 2:
                            mode = (int)IODriver.NetModeCommand.Remote_Off;
                            break;
                    }
                }
                //  else if (rdCoordination.IsChecked) mode = (int)IODriver.AppDriver.NetModeCommand.Coordinate_On;
                else if (rdCalib.IsChecked)
                {
                    string tagName = string.Format("{0}.Calib", _Junction.JunctionName);
                    string tagAddress = Program.GetDisplayTagAddress(tagName);
                    Program.SetIOTag(tagName, tagAddress, null);
                    isControlModeSelected = false;
                }
                else
                {
                    MessageHandler.Inform("Vui lòng chọn chế độ điều khiển");
                    isControlModeSelected = false;
                }

                if (isControlModeSelected)
                {
                    if (mode == (int)IODriver.NetModeCommand.Coordinate)
                    {
                        byte[] pulses = GetPulses();
                        if (pulses != null)
                        {
                            Program.SetIOTag(txtControlMode.DisplayTag.Name, txtControlMode.DisplayTag.Address, new object[] { mode, pulses });
                        }
                    }
                    else
                    {
                        Program.SetIOTag(txtControlMode.DisplayTag.Name, txtControlMode.DisplayTag.Address, new object[] { mode });
                    }
                }

            }
            else if (sender.Equals(btnSwitchPhase))
            {
                if ((rdRemote.IsChecked) && (cbbxControlType.SelectedIndex == 0))
                {
                    byte mode = (int)IODriver.NetModeCommand.Remote_Change_Phase;
                    Program.SetIOTag(txtControlMode.DisplayTag.Name, txtControlMode.DisplayTag.Address, new object[] { mode });
                }
            }
            else if (sender.Equals(btnWriteIO))
            {
                byte[] data = new byte[2];
                data[0] = (byte)intBitOffset.Value;
                data[1] = (byte)(chkON.Checked ? 1 : 0);
                Program.SetIOTag(txtIOStatus.DisplayTag.Name, txtIOStatus.DisplayTag.Address, new object[] { data });
            }
            else if (sender.Equals(btnReadLineDataFromSD))
            {
                Thread t = new Thread(new ThreadStart(() =>
                {
                    btnReadLineDataFromSD.Enabled = false;
                    btnReadEvent.Enabled = false;

                    object data = null;
                    string tagName = string.Format("{0}.LineDataFromSD", _Junction.JunctionName);
                    string tagAddress = Program.GetDisplayTagAddress(tagName);
                    if (Program.GetIOTag(tagName, tagAddress, new List<int>() { (int)intDay.Value, (int)intMonth.Value }, out data))
                    {
                        btnReadLineDataFromSD.Enabled = true;
                        btnReadEvent.Enabled = true;
                        FolderBrowserDialog op = new FolderBrowserDialog();
                        if (op.ShowDialog(new Form() { TopMost = true }) == System.Windows.Forms.DialogResult.OK)
                        {
                            string file = op.SelectedPath + string.Format("\\{0}_{1}.DAT", intDay.Value, intMonth.Value);
                            BinaryWriter sw = new BinaryWriter(File.OpenWrite(file));
                            List<byte> temp = (List<byte>)data;
                            sw.Write(temp.ToArray());
                            sw.Close();
                            MessageHandler.Inform("Lịch sử hoạt động của tủ điều khiển đã được đọc thành công !");
                        }
                    }

                }));
                t.ApartmentState = ApartmentState.STA;
                t.Start();
            }
            else if (sender.Equals(btnReadEvent))
            {
                Thread t = new Thread(new ThreadStart(() =>
                {
                    btnReadLineDataFromSD.Enabled = false;
                    btnReadEvent.Enabled = false;

                    object data = null;
                    string tagName = string.Format("{0}.EventFromSD", _Junction.JunctionName);
                    string tagAddress = Program.GetDisplayTagAddress(tagName);
                    if (Program.GetIOTag(tagName, tagAddress, null, out data))
                    {
                        btnReadLineDataFromSD.Enabled = true;
                        btnReadEvent.Enabled = true;
                        FolderBrowserDialog op = new FolderBrowserDialog();
                        if (op.ShowDialog(new Form() { TopMost = true }) == System.Windows.Forms.DialogResult.OK)
                        {
                            string file = op.SelectedPath + string.Format("\\EVENT.DAT");
                            BinaryWriter sw = new BinaryWriter(File.OpenWrite(file));
                            List<byte> temp = (List<byte>)data;
                            sw.Write(temp.ToArray());
                            sw.Close();
                            MessageHandler.Inform("Sự kiện hoạt động của tủ điều khiển đã được đọc thành công !");
                        }

                    }
                }));
                t.ApartmentState = ApartmentState.STA;
                t.Start();
            }
        }

        private byte[] GetPulses()
        {
            int offset = 0, period = 0;
            //int.TryParse(txtOffset.Text, out offset);
            //int.TryParse(txtPeriod.Text, out period);

            char[] separator = new char[] { ',', '-', ';', ' ' };
            string[] strPulses = new string[8];//txtPulses.Text.Split(separator);

            if (strPulses.Length > 8)
            {
                MessageHandler.Inform("Số xung không được lớn hơn 8");
                return null;
            }

            ushort[] pulses = new ushort[strPulses.Length];
            for (int i = 0; i < strPulses.Length; i++)
            {
                if (!ushort.TryParse(strPulses[i], out pulses[i]))
                {
                    MessageHandler.Inform("Chuỗi xung phải mang giá trị số! Nhập lại chuỗi xung!");
                    return null;
                }
            }

            byte[] bytePulses = new byte[pulses.Length * 4 + 9];

            bytePulses[0] = (byte)(pulses.Length);
            bytePulses[1] = (byte)(offset);
            bytePulses[2] = (byte)(offset >> 8);
            bytePulses[3] = (byte)(offset >> 16);
            bytePulses[4] = (byte)(offset >> 24);
            bytePulses[5] = (byte)(period);
            bytePulses[6] = (byte)(period >> 8);
            bytePulses[7] = (byte)(period >> 16);
            bytePulses[8] = (byte)(period >> 24);

            for (int i = 0, j = 9; i < pulses.Length; i++)
            {
                bytePulses[j++] = (byte)pulses[i];
                bytePulses[j++] = (byte)(pulses[i] >> 8);
                bytePulses[j++] = (byte)(pulses[i] >> 16);
                bytePulses[j++] = (byte)(pulses[i] >> 24);
            }
            return bytePulses;
        }

        #region scenario tab
        // phần gridview đọc TOD theo trình tự sau:
        // 1. Đọc current scenario để lấy scenarioID
        // 2. Đọc file TODxx trong đó xx là current scenarioID
        // 3. Đọc current TOD, lây được diagramID
        // 4. Hiển thị tất cả các TOD của kịch bản đó đồng thời hightlight currentTOD

        // Phần vẽ diagram, làm tiếp các bước sau
        // 1. Đọc file DiagramXX, trong đó xx là diagramID được lấy khi đọc current TOD (mục 3 phần trên)
        // 2. Đọc file line, để biết kiểu đèn, thời gian vàng của đèn để vẽ
        // 3. Vẽ giản đồ, dùng user control là HDTrafficDiagram

        private enum ReadingState
        {
            Start = 0,
            ReadCurrentScenario = 1,
            ReadTODxxFile = 2,
            ReadCurrentTOD = 3,
            ReadDiagramxxFile = 4,
            ReadLineFile = 5,
            End = 6,
        }

        private BackgroundWorker _Worker;
        private ReadingState _State = ReadingState.Start;
        private int _CurrentScenarioID = -1;
        private Dictionary<int, IODriver.TODInfo> _TODs = new Dictionary<int, IODriver.TODInfo>();
        private int _CurrentTODID = -1;
        private IODriver.DiagramInfo _Diagram = null;
        private Dictionary<int, IODriver.LineHardware> _Line = new Dictionary<int, IODriver.LineHardware>();

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (radPageView1.SelectedPage.Equals(pageScenario))
            {
                if (_State == ReadingState.Start)
                {
                    _Worker = new BackgroundWorker();
                    _Worker.DoWork += _Worker_DoWork;
                    _Worker.RunWorkerCompleted += _Worker_RunWorkerCompleted;
                    _Worker.RunWorkerAsync();
                }

            }
        }

        private void UpdateTabScenario()
        {
            while (_State != ReadingState.End)
            {
                switch (_State)
                {
                    case ReadingState.Start:
                        _State = ReadingState.ReadCurrentScenario;
                        break;
                    case ReadingState.ReadCurrentScenario:
                        if (_CurrentScenarioID == -1)
                        {
                            ReadCurrentScenarioID();
                        }
                        else
                        {
                            _State = ReadingState.ReadTODxxFile;
                        }
                        break;
                    case ReadingState.ReadTODxxFile:
                        ReadTODxxFile();
                        break;
                    case ReadingState.ReadCurrentTOD:
                        ReadCurrentTOD();
                        if (_CurrentTODID != -1)
                        {
                            _State = ReadingState.ReadDiagramxxFile;
                        }
                        break;
                    case ReadingState.ReadDiagramxxFile:
                        ReadDiagramxxFile();
                        break;
                    case ReadingState.ReadLineFile:
                        ReadLineFile();
                        break;
                    case ReadingState.End:
                        break;
                }
            }

        }

        private void _Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DisplayTOD();
            DisplayDiagram();
        }

        private void _Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateTabScenario();
        }

        private void ReadCurrentScenarioID()
        {
            int res = -1;
            string tagName = string.Format("{0}.CurrentScenarioID", _Junction.JunctionName);
            string tagAddress = Program.GetDisplayTagAddress(tagName);
            object data = null;
            if (Program.GetIOTag(tagName, tagAddress, null, out data))
            {
                res = (int)data;
                if (res != -1)
                {
                    _CurrentScenarioID = res;
                }
            }
        }

        private void ReadTODxxFile()
        {
            object data = null;
            string tagName = string.Format("{0}.EepromFile", _Junction.JunctionName);
            string tagAddress = Program.GetDisplayTagAddress(tagName);

            if (Program.GetIOTag(tagName, tagAddress, new List<int>() { (int)IODriver.EerpromFile.TODxx, _CurrentScenarioID }, out data))
            {
                List<byte> rawData = (List<byte>)data;
                int numberOfTOD = rawData[0];
                int offset = 1;
                for (int j = 0; j < numberOfTOD; j++)
                {
                    IODriver.TODInfo tod = new IODriver.TODInfo();
                    tod.TODID = rawData[offset];
                    tod.Hour = Common.Utility.ConvertBCD2Hex(rawData[offset + 1]);
                    tod.Min = Common.Utility.ConvertBCD2Hex(rawData[offset + 2]);
                    tod.Type = (IODriver.TypeControl)rawData[offset + 3];

                    tod.DiagramID = rawData[offset + 6];
                    tod.NumberOfZone = rawData[offset + 7];
                    tod.Offset = rawData[offset + 8] + rawData[offset + 9] * 256;
                    for (int i = 0; i < 8; i++)
                    {
                        tod.Pulses.Add(rawData[offset + 10 + i * 2] + rawData[offset + 11 + i * 2] * 256);
                    }
                    offset += 28;
                    _TODs.Add(tod.TODID, tod);
                }

                _State = ReadingState.ReadCurrentTOD;
            }
        }

        private void ReadCurrentTOD()
        {
            int res = -1;
            string tagName = string.Format("{0}.CurrentTOD", _Junction.JunctionName);
            string tagAddress = Program.GetDisplayTagAddress(tagName);
            object data = null;
            if (Program.GetIOTag(tagName, tagAddress, null, out data))
            {
                res = (int)data;
                if (res != -1)
                {
                    _CurrentTODID = res;
                }
            }
        }

        private void ReadDiagramxxFile()
        {
            object data = null;
            string tagName = string.Format("{0}.EepromFile", _Junction.JunctionName);
            string tagAddress = Program.GetDisplayTagAddress(tagName);
            //if (Program.GetIOTag(tagName, tagAddress, new List<int>() { (int)IODriver.EerpromFile.diagramxx, _TODs[_CurrentTODID].DiagramID }, out data))
            //{
            //    List<byte> rawData = (List<byte>)data;
            //    _Diagram = new IODriver.DiagramInfo();

            //    _Diagram.NumberOfLine = rawData[0];
            //    _Diagram.NumberOfZone = rawData[1];
            //    _Diagram.Cycle = BitConverter.ToInt32(rawData.ToArray(), 2);

            //    int offset = 8;
            //    for (int j = 0; j < _Diagram.NumberOfLine; j++)
            //    {
            //        IODriver.LineInfo line = new IODriver.LineInfo();
            //        line.LineID = rawData[offset];
            //        line.GreenOn.Add(BitConverter.ToInt32(rawData.ToArray(), offset + 2));
            //        line.GreenOff.Add(BitConverter.ToInt32(rawData.ToArray(), offset + 6));
            //        offset += 10;
            //        _Diagram.Lines.Add(line);
            //    }

            //    offset += 2;// checksum

            //    for (int j = 0; j < _Diagram.NumberOfZone; j++)
            //    {
            //        _Diagram.StartZone.Add(BitConverter.ToInt32(rawData.ToArray(), offset));
            //        _Diagram.EndZone.Add(BitConverter.ToInt32(rawData.ToArray(), offset + 4));
            //        offset += 8;
            //    }


            //    _State = ReadingState.ReadLineFile;
            //}
        }

        private void ReadLineFile()
        {
            if (_Line.Count <= 0)
            {
                object data = null;
                string tagName = string.Format("{0}.EepromFile", _Junction.JunctionName);
                string tagAddress = Program.GetDisplayTagAddress(tagName);
                //if (Program.GetIOTag(tagName, tagAddress, new List<int>() { (int)IODriver.EerpromFile.line }, out data))
                //{
                //    byte[] rawData = ((List<byte>)data).ToArray();
                //    int numberOfline = rawData[0];
                //    int offset = 1;
                //    for (int j = 0; j < numberOfline; j++)
                //    {
                //        IODriver.LineHardware line = new IODriver.LineHardware();
                //        line.LineID = rawData[offset];
                //        line.Type = (IODriver.LightType)rawData[offset + 1];
                //        line.CardID = rawData[offset + 2];
                //        line.GreenLightPositionInPowerCard = rawData[offset + 3];
                //        line.MonitorState = rawData[offset + 4];
                //        line.LenthOfYellowTime = (int)BitConverter.ToInt16(rawData, offset + 6);
                //        _Line.Add(line.LineID, line);
                //        offset += 8;
                //    }

                //    _State = ReadingState.End;
                //}
            }
        }

        private void DisplayTOD()
        {
            dtgTOD.Rows.Clear();

            int currentTODRow = -1;
            for (int j = 0; j < _TODs.Count; j++)
            {
                bool isUsed = true;
                if (_TODs[j].Type == IODriver.TypeControl.Inactive) isUsed = false;
                string pulses = "";
                for (int i = 0; i < _TODs[j].NumberOfZone; i++)
                {
                    pulses += _TODs[j].Pulses[i] + ",";
                }
                if (pulses.Length > 1)
                {
                    pulses = pulses.Substring(0, pulses.Length - 1);
                }

                string controlType = "";
                switch (_TODs[j].Type)
                {
                    case IODriver.TypeControl.All_Red:
                        controlType = "Tất cả đỏ";
                        break;
                    case IODriver.TypeControl.Color:
                        controlType = "Thông số";
                        break;
                    case IODriver.TypeControl.Coordinate:
                        controlType = "Làn sóng xanh";
                        break;
                    case IODriver.TypeControl.Flash:
                        controlType = "Chớp vàng";
                        break;
                    case IODriver.TypeControl.Off:
                        controlType = "Tắt tủ";
                        break;
                }

                dtgTOD.Rows.Add(new object[] {
                                                isUsed,    
                                                _TODs[j].TODID, 
                                                string.Format("{0}:{1}", _TODs[j].Hour.ToString("00"),_TODs[j].Min.ToString("00")),
                                               controlType,
                                                _TODs[j].DiagramID,
                                                pulses,
                                                _TODs[j].Offset
                                            });
                if (_TODs[j].TODID == _CurrentTODID)
                {
                    currentTODRow = dtgTOD.Rows.Count - 1;
                    for (int i = 0; i < dtgTOD.Columns.Count; i++)
                    {
                        dtgTOD.Rows[currentTODRow].Cells[i].Style.CustomizeFill = true;
                        dtgTOD.Rows[currentTODRow].Cells[i].Style.DrawFill = true;
                        dtgTOD.Rows[currentTODRow].Cells[i].Style.BackColor = Color.Yellow;

                    }
                }
            }
            if (currentTODRow != -1)
            {
                dtgTOD.CurrentRow = dtgTOD.Rows[currentTODRow];
            }
        }

        private void DisplayDiagram()
        {
            if (_Diagram != null)
            {
                // clear diagram
                hdTrafficDiagram1.ClearGraph();

                //add diagram
                hdTrafficDiagram1.AddDiagram(_Diagram.DiagramID, "", _Diagram.Cycle);

                // add signal
                foreach (int id in _Line.Keys)
                {
                    hdTrafficDiagram1.AddSignal(id, (int)_Line[id].Type, _Line[id].LenthOfYellowTime);
                }

                // add line
                for (int j = 0; j < _Diagram.Lines.Count; j++)
                {
                    hdTrafficDiagram1.AddSignalInfo(_Diagram.Lines[j].LineID, _Diagram.Lines[j].GreenOn, _Diagram.Lines[j].GreenOff);
                }

                // add zone

                hdTrafficDiagram1.AddZone(_Diagram.StartZone, _Diagram.EndZone);

                // draw diagram
                hdTrafficDiagram1.DrawDiagram();
            }


        }

        private void dtgTOD_DoubleClick(object sender, EventArgs e)
        {
            if (dtgTOD.SelectedRows.Count > 0)
            {
                int id = (int)(decimal)dtgTOD.SelectedRows[0].Cells["colID"].Value;
                string time = (string)dtgTOD.SelectedRows[0].Cells["colTOD"].Value;
                int hour = 0, minute = 0;
                int.TryParse(time.Substring(0, 2), out hour);
                int.TryParse(time.Substring(3, 2), out minute);
                string controlType = (string)dtgTOD.SelectedRows[0].Cells["colControlType"].Value;
                int diagramID = (int)(decimal)dtgTOD.SelectedRows[0].Cells["colDiagramID"].Value;
                string pulses = (string)dtgTOD.SelectedRows[0].Cells["colPulses"].Value;
                int offset = (int)(decimal)dtgTOD.SelectedRows[0].Cells["colOffset"].Value;

                FrmUpdateTOD f = new FrmUpdateTOD();
                f.ID = id;
                f.Hour = hour;
                f.Minute = minute;
                f.ControlType = controlType;
                f.DiagramID = diagramID;
                f.Pulses = pulses;
                f.Offset = offset;
                f.Junc = _Junction;
                f.ScenarioID = _CurrentScenarioID;
                f.ShowDialog();
                if (f.IsSusscess)
                {
                    dtgTOD.SelectedRows[0].Cells["colTOD"].Value = string.Format("{0}:{1}", f.Hour.ToString("00"), f.Minute.ToString("00"));
                    dtgTOD.SelectedRows[0].Cells["colControlType"].Value = f.ControlType;
                    dtgTOD.SelectedRows[0].Cells["colDiagramID"].Value = f.DiagramID;
                    dtgTOD.SelectedRows[0].Cells["colPulses"].Value = f.Pulses;
                    dtgTOD.SelectedRows[0].Cells["colOffset"].Value = f.Offset;

                    _TODs[id].Pulses.Clear();
                    string[] temp = f.Pulses.Split(new char[] { ',' });
                    for (int j = 0; j < temp.Length; j++)
                    {
                        int data = 0;
                        int.TryParse(temp[j], out data);
                        _TODs[id].Pulses.Add(data);
                    }
                }
            }
        }
        #endregion

       

    }
}

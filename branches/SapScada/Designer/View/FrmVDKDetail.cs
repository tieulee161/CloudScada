using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using System.IO;
using Designer.Model;
using Designer.Core;
using Common;
using HDSComponent;
using HDSComponent.UI;
using System.Threading;
using Telerik.WinControls.UI;

namespace Designer.View
{
    public partial class FrmVDKDetail : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }
        private Display _Page { get; set; }
        private bool _FirstScan { get; set; }
        public FrmVDKDetail()
        {
            InitializeComponent();
        }

        #region event
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _FirstScan = true;

            this.Enter += new System.EventHandler(this.FrmVDKDetail_Enter);
        }

        private void FrmVDKDetail_Enter(object sender, EventArgs e)
        {
            if (_FirstScan)
            {
                _FirstScan = false;
                menuChangeMap.Click += Menu_Click;
                menuVehicleGreen.Click += Menu_Click;
                menuVehicleYellow.Click += Menu_Click;
                menuVehicleRed.Click += Menu_Click;
                menuPedestrianGreen.Click += Menu_Click;
                menuPedestrianRed.Click += Menu_Click;
                menuArrowGreenAhead.Click += Menu_Click;
                menuArrowGreenBack.Click += Menu_Click;
                menuArrowGreenLeft.Click += Menu_Click;
                menuArrowGreenRight.Click += Menu_Click;
                menuArrowRedAhead.Click += Menu_Click;
                menuArrowRedBack.Click += Menu_Click;
                menuArrowRedLeft.Click += Menu_Click;
                menuArrowRedRight.Click += Menu_Click;
                menuArrowYellowAhead.Click += Menu_Click;
                menuArrowYellowBack.Click += Menu_Click;
                menuArrowYellowLeft.Click += Menu_Click;
                menuArrowYellowRight.Click += Menu_Click;

                picJunction.DragEnter += picJunction_DragEnter;
                picJunction.DragDrop += picJunction_DragDrop;
                Junction junc = DesignerAccess.GetJunction(JunctionName);
                if (junc != null)
                {
                    if (File.Exists(junc.Map))
                    {
                        picJunction.BackgroundImage = Image.FromFile(junc.Map);
                        ((Form)(this.Tag)).Size = picJunction.BackgroundImage.Size;
                    }
                }

                BackgroundWorker initWorker = new BackgroundWorker();
                initWorker.DoWork += initWorker_DoWork;
                initWorker.RunWorkerAsync();
            }
            else
            {
                if (picJunction.BackgroundImage != null)
                {
                    ((Form)(this.Tag)).Size = picJunction.BackgroundImage.Size;
                }
                else
                {
                    ((Form)(this.Tag)).Size = new Size(624, 452);
                }
            }
        }

        private void initWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            InitDisplayTag();
        }

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

        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender.Equals(menuChangeMap))
            {
                OpenFileDialog f = new OpenFileDialog();
                f.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string map = f.FileName;
                    if (File.Exists(map))
                    {
                        DesignerAccess.SetMap(JunctionName, map);
                        Image img = Image.FromFile(map);
                        picJunction.BackgroundImage = img;
                        ((Form)(this.Tag)).Size = img.Size;
                    }
                    else
                    {
                        MessageHandler.AskForValidFilePath();
                    }
                }
            }
            else
            {
                HDIndicator indicator = new HDIndicator();
                LightType lightType = LightType.VehicleGreen;

                #region vehicle
                if (sender.Equals(menuVehicleGreen))
                {
                    lightType = LightType.VehicleGreen;
                }
                else if (sender.Equals(menuVehicleRed))
                {
                    lightType = LightType.VehicleRed;
                }
                else if (sender.Equals(menuVehicleYellow))
                {
                    lightType = LightType.VehicleYellow;
                }
                #endregion

                #region pedestrian
                else if (sender.Equals(menuPedestrianGreen))
                {
                    lightType = LightType.PedestrianGreen;
                }
                else if (sender.Equals(menuPedestrianRed))
                {
                    lightType = LightType.PedestrianRed;
                }
                #endregion

                #region arrow green
                else if (sender.Equals(menuArrowGreenAhead))
                {
                    lightType = LightType.ArrowGreenAhead;
                }
                else if (sender.Equals(menuArrowGreenBack))
                {
                    lightType = LightType.ArrowGreenBack;
                }
                else if (sender.Equals(menuArrowGreenLeft))
                {
                    lightType = LightType.ArrowGreenLeft;
                }
                else if (sender.Equals(menuArrowGreenRight))
                {
                    lightType = LightType.ArrowGreenRight;
                }
                #endregion

                #region arrow yellow
                else if (sender.Equals(menuArrowYellowAhead))
                {
                    lightType = LightType.ArrowYellowAhead;
                }
                else if (sender.Equals(menuArrowYellowBack))
                {
                    lightType = LightType.ArrowYellowBack;
                }
                else if (sender.Equals(menuArrowYellowLeft))
                {
                    lightType = LightType.ArrowYellowLeft;
                }
                else if (sender.Equals(menuArrowYellowRight))
                {
                    lightType = LightType.ArrowYellowRight;
                }
                #endregion

                #region arrow red
                else if (sender.Equals(menuArrowRedAhead))
                {
                    lightType = LightType.ArrowRedAhead;
                }
                else if (sender.Equals(menuArrowRedBack))
                {
                    lightType = LightType.ArrowRedBack;
                }
                else if (sender.Equals(menuArrowRedLeft))
                {
                    lightType = LightType.ArrowRedLeft;
                }
                else if (sender.Equals(menuArrowRedRight))
                {
                    lightType = LightType.ArrowRedRight;
                }
                #endregion

                Lamp lamp = null;
                Point location = picJunction.PointToClient(Cursor.Position);
                if (DesignerAccess.AddLamp(JunctionName, 0, location.X, location.Y, 0, "", "", (int)lightType, "", out lamp))
                {
                    ConfigIndicator(indicator, lamp.ID, lightType, location.X, location.Y);
                    picJunction.Controls.Add(indicator);

                    if (_Page != null)
                    {
                        _Page.Stop();
                        _Page.AddTag(indicator.DisplayTag);
                        _Page.Run();
                    }
                }
                else
                {
                    MessageHandler.AddRecordError();
                }
            }

        }

        private void indicator_LocationChanged(object sender, EventArgs e)
        {
            HDIndicator indicator = (HDIndicator)sender;
            if (sender != null)
            {
                if (!DesignerAccess.UpdateLamp(indicator.Id, indicator.Location.X, indicator.Location.Y))
                {
                    MessageHandler.UpdateRecordError();
                }
            }
        }

        private void menuSetting_Click(object sender, EventArgs e)
        {
            RadMenuItem menu = (RadMenuItem)sender;
            if (menu != null)
            {
                HDIndicator indicator = (HDIndicator)menu.Tag;
                if (indicator != null)
                {
                    FrmDisplayTagSetting f = new FrmDisplayTagSetting();
                    f.JunctionName = JunctionName;
                    f.LampId = indicator.Id;
                    f.ShowDialog();
                    if (f.IsSuccessful)
                    {
                        Lamp lamp = DesignerAccess.GetLamp(indicator.Id);
                        if (lamp != null)
                        {
                            _Page.Stop();
                            indicator.DisplayTag.Name = lamp.Tag;
                            indicator.DisplayTag.Address = Program.GetDisplayTagAddress(indicator.DisplayTag.Name);
                            _Page.Run();
                        }
                    }
                }
            }
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            RadMenuItem menu = (RadMenuItem)sender;
            if (menu != null)
            {
                HDIndicator indicator = (HDIndicator)menu.Tag;
                if (indicator != null)
                {
                    if (MessageHandler.AskForDeleteRecord())
                    {
                        if (DesignerAccess.DeleteLamp(indicator.Id))
                        {
                            picJunction.Controls.Remove(indicator);
                        }
                        else
                        {
                            MessageHandler.DeleteRecordError();
                        }
                    }
                }
            }
        }
        private void FrmVDKDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        public void StopUpdating()
        {
            Program.RemoveDisplayForm(this);
        }
        #endregion

        #region method
        private void InitDisplayTag()
        {
            List<Lamp> lamps = DesignerAccess.GetLamps(JunctionName);
            _Page = new Display(1000);
            if (lamps.Count > 0)
            {
                foreach (Lamp lamp in lamps)
                {
                    HDIndicator indicator = new HDIndicator();
                    ConfigIndicator(indicator, lamp.ID, (LightType)lamp.Type, (int)lamp.X, (int)lamp.Y);
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate()
                        {
                            picJunction.Controls.Add(indicator);
                        });
                    }
                    else
                    {
                        picJunction.Controls.Add(indicator);
                    }

                    indicator.DisplayTag.Name = lamp.Tag;
                    indicator.DisplayTag.Address = Program.GetDisplayTagAddress(indicator.DisplayTag.Name);
                    _Page.AddTag(indicator.DisplayTag);
                }
            }

            Program.AddDisplayForm(this, new List<Display>() { _Page });
        }

        private void ConfigIndicator(HDIndicator indicator, int Id, LightType type, int X, int Y)
        {
            indicator.Id = Id;
            indicator.Size = new Size(32, 32);

            indicator.DisplayText = "";
            indicator.Location = new Point(X, Y);
            indicator.LocationChanged += indicator_LocationChanged;
            indicator.menuSetting.Click += menuSetting_Click;
            indicator.menuDelete.Click += menuDelete_Click;
            switch (type)
            {
                case LightType.VehicleGreen:
                    indicator.BackgroundImage = Properties.Resources.Gray;
                    indicator.DataMapping.Add(true, Properties.Resources.Green);
                    indicator.DataMapping.Add(false, Properties.Resources.Gray);
                    break;
                case LightType.VehicleRed:
                    indicator.BackgroundImage = Properties.Resources.Gray;
                    indicator.DataMapping.Add(true, Properties.Resources.Red);
                    indicator.DataMapping.Add(false, Properties.Resources.Gray);
                    break;
                case LightType.VehicleYellow:
                    indicator.BackgroundImage = Properties.Resources.Gray;
                    indicator.DataMapping.Add(true, Properties.Resources.Yellow);
                    indicator.DataMapping.Add(false, Properties.Resources.Gray);
                    break;
                case LightType.PedestrianGreen:
                    indicator.BackgroundImage = Properties.Resources.Gray;
                    indicator.DataMapping.Add(true, Properties.Resources.Pedestrian_Green);
                    indicator.DataMapping.Add(false, Properties.Resources.Gray);
                    break;
                case LightType.PedestrianRed:
                    indicator.BackgroundImage = Properties.Resources.Gray;
                    indicator.DataMapping.Add(true, Properties.Resources.Pedestrian_Red);
                    indicator.DataMapping.Add(false, Properties.Resources.Gray);
                    break;
                case LightType.ArrowGreenAhead:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Green_Straight);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowGreenBack:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Green_Back);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowGreenLeft:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Green_Left);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowGreenRight:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Green_Right);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowRedAhead:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Red_Straight);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowRedBack:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Red_Back);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowRedLeft:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Red_Left);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowRedRight:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Red_Right);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowYellowAhead:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Yellow_Straight);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowYellowBack:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Yellow_Back);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowYellowLeft:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Yellow_Left);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;
                case LightType.ArrowYellowRight:
                    indicator.BackgroundImage = Properties.Resources.Lamp_Arrow_Off;
                    indicator.DataMapping.Add(true, Properties.Resources.Lamp_Arrow_Yellow_Right);
                    indicator.DataMapping.Add(false, Properties.Resources.Lamp_Arrow_Off);
                    break;

            }
        }

        #endregion

    }
}

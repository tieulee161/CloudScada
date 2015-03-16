using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;

using Common;
using IODriver;

namespace HDSComponent.UI
{
    public class MyMarker : GMap.NET.WindowsForms.Markers.GMapMarkerCross//, IDisplayTag
    {
        private Map _Map;
        private Image _Img;
        private object _CurrentValue;

        public string MakerName;

        private object _Status
        {
            set
            {
                try
                {
                    Type t = value.GetType();
                    if (t == typeof(int))
                    {
                        int _Value = (int)value;
                        switch(_Value)
                        {
                            case 0:
                                _Img = Properties.Resources.Off;
                                break;
                            case 1:
                                _Img = Properties.Resources.Connect;
                                break;
                            case 0xFF:
                                _Img = Properties.Resources.Error;
                                break;
                        }

                        //switch ((IODriver.JunctionStatus)_Value)
                        //{
                        //    case IODriver.JunctionStatus.Disconnect:
                        //        _Img = Properties.Resources.Off;
                        //        break;
                        //    case IODriver.JunctionStatus.Auto_Off:
                        //        _Img = Properties.Resources.Auto_Off;
                        //        break;
                        //    case IODriver.JunctionStatus.Auto_Color:
                        //        _Img = Properties.Resources.Auto_Plan;
                        //        break;
                        //    case IODriver.JunctionStatus.Auto_Yellow_Flashing:
                        //        _Img = Properties.Resources.Auto_Yellow_Flashing;
                        //        break;
                        //    case IODriver.JunctionStatus.Manual_All_Red:
                        //        _Img = Properties.Resources.Manual_All_Red;
                        //        break;
                        //    case IODriver.JunctionStatus.Manual_Color:
                        //        _Img = Properties.Resources.Manual_Plan;
                        //        break;
                        //    case IODriver.JunctionStatus.Manual_Yellow_Flashing:
                        //        _Img = Properties.Resources.Manual_Yellow_Flashing;
                        //        break;
                        //    case IODriver.JunctionStatus.Coordination:
                        //        _Img = Properties.Resources.Connect;
                        //        break;
                        //    case IODriver.JunctionStatus.Remote_Off:
                        //        _Img = Properties.Resources.Remote_Off;
                        //        break;
                        //    case IODriver.JunctionStatus.Remote_Color:
                        //        _Img = Properties.Resources.Remote_Plan;
                        //        break;
                        //    case IODriver.JunctionStatus.Remote_Yellow_Flashing:
                        //        _Img = Properties.Resources.Remote_Yellow_Flashing;
                        //        break;
                        //    case IODriver.JunctionStatus.Safety_Off:
                        //        _Img = Properties.Resources.Safety_Off;
                        //        break;
                        //    case IODriver.JunctionStatus.Safety_Yellow_Flashing:
                        //        _Img = Properties.Resources.Safety_Yellow_Flashing;
                        //        break;
                        //    case IODriver.JunctionStatus.Calib:
                        //        _Img = Properties.Resources.Calib;
                        //        break;
                          
                        //    case IODriver.JunctionStatus.Connect:
                        //        _Img = Properties.Resources.Connect;
                        //        break;
                        //}

                    }
                    else if (t == typeof(bool))
                    {
                        bool _value = (bool)value;
                        if (_value)
                        {
                            _Img = Properties.Resources.Off;
                        }
                        else
                        {
                            _Img = Properties.Resources.Connect;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _Img = Properties.Resources.Unknown;
                }

                if (!_Map.IsDisposed)
                {
                    Graphics g = _Map.CreateGraphics();
                    OnRender(g);
                    _Map.Refresh();
                }
            }
        }

        public MyMarker(PointLatLng p, Map map)
            : base(p)
        {
            _Map = map;
            _Img = Properties.Resources.Off;
            Size = _Img.Size;
            Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2);

            // instance IdisplayTag
            DisplayTag = new IDisplayTag();
            DisplayTag.Name = "";
            DisplayTag.Address = "";
            DisplayTag.Value = (int)IODriver.JunctionStatus.Disconnect;
            DisplayTag.Quality = Quality.Good;
            DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
           
            _Status = DisplayTag.Value;
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
           
            if (_CurrentValue != DisplayTag.Value)
            {
                _CurrentValue = DisplayTag.Value;
                _Status = DisplayTag.Value;
            }
        }

        public override void OnRender(Graphics g)
        {
            try
            {
                g.DrawImage(_Img, LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height);
            }
            catch (Exception)
            { }
        }

        private void ChangeStatus()
        {
            _Map.Refresh();
        }

        #region display tag interface

        public IDisplayTag DisplayTag;

        #endregion
    }
}

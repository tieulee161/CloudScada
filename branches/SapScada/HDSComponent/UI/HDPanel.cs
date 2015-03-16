using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Common;
using System.Drawing;

namespace HDSComponent.UI
{
    public class HDPanel : RadPanel
    {
        public IDisplayTag DisplayTag;

        public Dictionary<object, List<object>> DataMapping = new Dictionary<object, List<object>>();
        // animation - border width - border color
        System.Timers.Timer _Timer;
        int _animationCount = 0;

        public HDPanel()
        {
            DisplayTag = new IDisplayTag();
            DisplayTag.Name = "";
            DisplayTag.Address = "";
            DisplayTag.Value = new object();
            DisplayTag.Quality = Quality.Good;
            DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
            base.Text = "";
            this.PanelElement.PanelBorder.Width = 1;

            _Timer = new System.Timers.Timer();
            _Timer.Interval = 1000;
            _Timer.AutoReset = true;
            _Timer.Elapsed += _Timer_Elapsed;
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            try
            {
                if (DisplayTag.Value != null)
                {
                    if (DataMapping.ContainsKey(DisplayTag.Value))
                    {
                        List<object> properties = DataMapping[DisplayTag.Value];
                        bool isAnimation = (bool)properties[0];
                        if (isAnimation)
                        {
                            StartAnimation();
                        }
                        else
                        {
                            StopAnimation();
                            this.PanelElement.PanelBorder.ForeColor = (Color)properties[2];
                        }
                        this.PanelElement.PanelBorder.Width = (int)properties[1];
                       
                    }
                    else
                    {
                        StopAnimation();
                        this.PanelElement.PanelBorder.Width = 0;
                        this.PanelElement.PanelBorder.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

        }

        private void StartAnimation()
        {
            if ((_Timer != null) && (_Timer.Enabled == false))
            {
                _Timer.Start();
            }
           
        }

        private void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _animationCount++;
            switch (_animationCount % 2)
            {
                case 0:
                    this.PanelElement.PanelBorder.ForeColor = Color.Red;
                    break;
                case 1:
                    this.PanelElement.PanelBorder.ForeColor = Color.LimeGreen;
                    break;
                case 2:
                    this.PanelElement.PanelBorder.ForeColor = Color.Yellow;
                    break;

            }
        }

        private void StopAnimation()
        {
            if (_Timer != null)
            {
                _Timer.Stop();
            }
        }
    }
}

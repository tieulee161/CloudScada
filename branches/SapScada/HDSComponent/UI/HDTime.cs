using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;

namespace HDSComponent.UI
{
    public class HDTime : RadTextBox
    {
        System.Timers.Timer _timer = new System.Timers.Timer();

        protected override void OnLoad(System.Drawing.Size desiredSize)
        {
            base.OnLoad(desiredSize);
            this.ReadOnly = true;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            _timer.Interval = 1000;
            _timer.AutoReset = true;
            _timer.Elapsed += _timer_Elapsed;
           // _timer.Start();
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!this.IsDisposed)
            {
                try
                {
                    this.Text = DateTime.Now.ToString();
                }
                catch (Exception)
                { }
            }
        }

        public bool Enabled
        {
            get
            {
                return _timer.Enabled;
            }
            set
            {
                _timer.Enabled = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Common;

namespace HDSComponent.UI
{
    public class HDNumberic : RadSpinEditor
    {
        public IDisplayTag DisplayTag;

        public Dictionary<object, decimal> DataMapping = new Dictionary<object, decimal>();

        private bool _IsEditting = false;

        public HDNumberic()
        {
            DisplayTag = new IDisplayTag();
            DisplayTag.Name = "";
            DisplayTag.Address = "";
            DisplayTag.Value = new object();
            DisplayTag.Quality = Quality.Good;
            DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;

            base.ShowUpDownButtons = false;
            base.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Maximum = 100000000;
            //   base.DecimalPlaces = 2;
         //   base.ThousandsSeparator = true;
            base.Enter += HDNumberic_Enter;
            base.Leave += HDNumberic_Leave;
            base.KeyPress += HDNumberic_KeyPress;
        }

        private void HDNumberic_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (this.Parent != null)
                {
                    this.Parent.Select();
                }
            }
        }

        private void HDNumberic_Leave(object sender, EventArgs e)
        {
            _IsEditting = false;
            DisplayTag.SetTagValue(this.Value);
        }

        private void HDNumberic_Enter(object sender, EventArgs e)
        {
            _IsEditting = true;
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            this.Maximum = 100000000;
            if (_IsEditting == false)
            {
                try
                {
                    if (DisplayTag.Value != null)
                    {

                        Type type = DisplayTag.Value.GetType();
                        if (type == typeof(int))
                        {
                            this.Value = (int)DisplayTag.Value;
                        }
                        else if (type == typeof(float))
                        {
                            this.Value = (decimal)(float)DisplayTag.Value;
                        }
                        else if (type == typeof(double))
                        {
                            this.Value =  Convert.ToDecimal((double)DisplayTag.Value);
                        }
                            
                    }
                }
                catch (Exception ex)
                {
                    string temp = ex.Message;
                }
            }
        }
    }
}

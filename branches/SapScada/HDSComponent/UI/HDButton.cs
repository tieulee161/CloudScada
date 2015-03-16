using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Common;
using System.Drawing;

namespace HDSComponent.UI
{
    public class HDButton : RadButton
    {
        public IDisplayTag DisplayTag;

        public Dictionary<object, Color> DataMapping = new Dictionary<object, Color>();

        public Dictionary<Color, object> DataOnClickMapping = new Dictionary<Color, object>();

        private bool _IsEditting = false;

        public HDButton()
        {
            DisplayTag = new IDisplayTag();
            DisplayTag.Name = "";
            DisplayTag.Address = "";
            DisplayTag.Value = new object();
            DisplayTag.Quality = Quality.Good;
            DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;

            this.Click += HDButton_Click;
            this.MouseEnter += HDButton_Enter;
            this.MouseLeave += HDButton_Leave;
        }

        private void HDButton_Leave(object sender, EventArgs e)
        {
            _IsEditting = false;
        }

        private void HDButton_Enter(object sender, EventArgs e)
        {
            _IsEditting = true;
        }

        private void HDButton_Click(object sender, EventArgs e)
        {

            if (DataOnClickMapping.ContainsKey(this.BackColor))
            {
                object data = DataOnClickMapping[this.BackColor];
                if (data != null)
                {
                    DisplayTag.SetTagValue(data);
                }
            }

        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            if (_IsEditting == false)
            {
                try
                {
                    if (DisplayTag.Value != null)
                    {
                        if (DataMapping.ContainsKey(DisplayTag.Value))
                        {
                            this.BackColor = DataMapping[DisplayTag.Value];
                            this.ButtonElement.ButtonFillElement.BackColor = DataMapping[DisplayTag.Value];
                            this.ButtonElement.ButtonFillElement.BackColor2 = DataMapping[DisplayTag.Value];
                            this.ButtonElement.ButtonFillElement.BackColor3 = DataMapping[DisplayTag.Value];
                            this.ButtonElement.ButtonFillElement.BackColor4 = DataMapping[DisplayTag.Value];
                        }
                    }
                }
                catch (Exception)
                { }
            }
        }
    }
}

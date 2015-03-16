using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Common;

namespace HDSComponent.UI
{
    public class HDTextbox : RadTextBox
    {
        public IDisplayTag DisplayTag;
        public HDTextbox()
        {
            DisplayTag = new IDisplayTag();
            DisplayTag.Name = "";
            DisplayTag.Address = "";
            DisplayTag.Value = new object();
            DisplayTag.Quality = Quality.Good;
            DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
            
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            try
            {
                this.Text = DisplayTag.Value.ToString();
            }
            catch (Exception)
            { }
        }
    }
}

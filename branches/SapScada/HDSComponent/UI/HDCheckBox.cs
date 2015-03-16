using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Common;

namespace HDSComponent.UI
{
    public class HDCheckBox : RadCheckBox
    {
        public IDisplayTag DisplayTag;

        public Dictionary<object, bool> DataMapping = new Dictionary<object, bool>();

        public HDCheckBox()
        {
            DisplayTag = new IDisplayTag();
            DisplayTag.Name = "";
            DisplayTag.Address = "";
            DisplayTag.Value = new object();
            DisplayTag.Quality = Quality.Good;
            DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
            this.Click += HDCheckBox_Click;
        }

        private void HDCheckBox_Click(object sender, EventArgs e)
        {
            bool temp = !this.Checked;
            var query = (from q in DataMapping
                         where q.Value == temp
                         select q).FirstOrDefault();

            object data = query.Key;
            this.DisplayTag.SetTagValue(data);
        }


        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            try
            {
                if (DataMapping.ContainsKey(DisplayTag.Value))
                {
                    this.Checked = DataMapping[DisplayTag.Value];
                }
                else
                {
                    this.Checked = false;
                }
            }
            catch (Exception)
            { }
        }
    }
}

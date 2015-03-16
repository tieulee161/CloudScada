using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Common;

namespace HDSComponent.UI
{
    public class HDMappingTextbox : RadTextBox
    {
      //  public IDisplayTag DisplayTag;

      //  public Dictionary<object, string> DataMapping = new Dictionary<object, string>();

  //      public List<HDDataSource> DataSources = new List<HDDataSource>();

        public HDMappingTextbox()
        {
            //DisplayTag = new IDisplayTag();
            //DisplayTag.Name = "";
            //DisplayTag.Address = "";
            //DisplayTag.Value = new object();
            //DisplayTag.Quality = Quality.Good;
            //DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
          
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            //try
            //{
            //    if (DataMapping.ContainsKey(DisplayTag.Value))
            //    {
            //        this.Text = DataMapping[DisplayTag.Value];
            //    }
            //    else
            //    {
            //        this.Text = "No data";
            //    }
            //}
            //catch (Exception)
            //{ }
        }
    }
}

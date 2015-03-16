using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Common;

namespace HDSComponent.UI
{
    public class HDCombobox : RadDropDownList
    {
        public IDisplayTag DisplayTag;

        public Dictionary<object, int> DataMapping = new Dictionary<object, int>();

        private bool _IsUserEditting = false;

        public HDCombobox()
        {
            DisplayTag = new IDisplayTag();
            DisplayTag.Name = "";
            DisplayTag.Address = "";
            DisplayTag.Value = new object();
            DisplayTag.Quality = Quality.Good;
            DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;

            this.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;

            this.PopupOpening += HDCombobox_PopupOpened;
            this.PopupClosed += HDCombobox_PopupClosed;
          
            this.SelectedIndexChanged += HDCombobox_SelectedIndexChanged;
            
        }

        private void HDCombobox_PopupClosed(object sender, RadPopupClosedEventArgs args)
        {
           
        }

        private void HDCombobox_PopupOpened(object sender, EventArgs e)
        {
            _IsUserEditting = true;
        }

        private void HDCombobox_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            int index = this.SelectedIndex;
            if (_IsUserEditting)
            {  
                if (this.SelectedIndex > -1)
                {
                    var query = (from q in DataMapping
                                 where q.Value == index
                                 select q).FirstOrDefault();
                    DisplayTag.SetTagValue(query.Key);
                }
                this.Parent.Select();
                _IsUserEditting = false;
               
            }
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            try
            {
                if (_IsUserEditting == false)
                {
                    if (DisplayTag.Value != null)
                    {
                        if (DataMapping.ContainsKey(DisplayTag.Value))
                        {
                            this.SelectedIndex = DataMapping[DisplayTag.Value];
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }
    }
}

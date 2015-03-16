using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Common;

namespace HDSComponent.UI
{
    public class HDDataSource
    {

        public IDisplayTag DisplayTag { get; set; }

        public Dictionary<string, HDMapping> DataMapping = new Dictionary<string, HDMapping>();

        public HDDataSource()
        {
            DisplayTag = new IDisplayTag();
            DisplayTag.Name = "";
            DisplayTag.Address = "";
            DisplayTag.Value = new object();
            DisplayTag.Quality = Quality.Good;
            DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
        }

        public bool BindTo(object parent, string propertyName, Dictionary<object, object> dataMapping)
        {
            bool res = false;
            HDMapping mapping = new HDMapping();
            mapping.BindTo(parent, propertyName, dataMapping);
            string key = string.Format("{0}.{1}", parent.GetType().Name, propertyName);
            if (!DataMapping.ContainsKey(key))
            {
                DataMapping.Add(key, mapping);
                res = true;
            }
            return res;
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            try
            {
                foreach (HDMapping mapping in DataMapping.Values.ToList())
                {
                    mapping.SetValue(DisplayTag.Value);
                }

            }
            catch (Exception)
            { }
        }
    }

    public class HDMapping
    {
        private object _Parent { get; set; }
        private System.Reflection.PropertyInfo _Property { get; set; }

        private Dictionary<object, object> _DataMapping = new Dictionary<object, object>();

        public void BindTo(object parent, string propertyName, Dictionary<object, object> dataMapping)
        {
            _Parent = parent;
            _Property = _Parent.GetType().GetProperty(propertyName);
            _DataMapping = dataMapping;
        }

        public void SetValue(object value)
        {
            if (_Property != null)
            {
                if (_DataMapping.Count > 0)
                {
                    if (_DataMapping.ContainsKey(value))
                    {
                        _Property.SetValue(_Parent, _DataMapping[value],null);
                    }
                }
                else
                {
                    _Property.SetValue(_Parent, value, null);
                }
             //   ((System.Windows.Forms.Control)_Parent).Refresh();
            }
           
        }

    }
}

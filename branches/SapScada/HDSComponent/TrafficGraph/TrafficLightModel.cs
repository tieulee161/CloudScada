using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace HDSComponent.TrafficGraph
{
    public class TrafficLightModel
    {
        public float PredefineConstantValue { get; set; }

        private BindingList<TrafficLightData> _Data = new BindingList<TrafficLightData>();
        public BindingList<TrafficLightData> Data
        {
            get
            {
                return _Data;
            }
            set
            {
                if (_Data != value)
                {
                    _Data = value;
                }
            }
        }

        public void AddPoint(DateTime x, int green, int yellow, int red)
        {
            TrafficLightData point = new TrafficLightData(x, PredefineConstantValue, green, yellow, red);
            _Data.Add(point);
        }

        public TrafficLightModel GetModel()
        {
            return this;
        }
    }
}

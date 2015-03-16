using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDSComponent.TrafficGraph
{
    public class TrafficLightData
    {
        public DateTime X { get; set; }

        public float Y { get; set; } // always equal to predefide value

        public float Z { get; set; } // will be one of these value : {0,Black} , {1: Green}, {2: Yellow}, {4: Red}

        public TrafficLightData(DateTime x, float y, int green, int yellow, int red)
        {
            this.X = x;
            this.Y = y;
            this.Z = red * 4 + yellow * 2 + green;
        }
    }
}

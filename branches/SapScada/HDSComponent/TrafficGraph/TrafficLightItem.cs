using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Telerik.Charting;

namespace HDSComponent.TrafficGraph
{
    public class TrafficLightItem
    {
        public string Name { get; set; }
        public int LineId { get; set; }
        public SteplineSeries Line { get; set; }
        public TrafficLightModel DataSource { get; set; }

        public string GreenTagName { get; set; }
        public string YellowTagName { get; set; }
        public string RedTagName { get; set; }

        
    }
}

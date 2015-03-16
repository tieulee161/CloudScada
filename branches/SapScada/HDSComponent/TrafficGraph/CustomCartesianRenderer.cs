using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;

namespace HDSComponent.TrafficGraph
{
    public class CustomCartesianRenderer : CartesianRenderer
    {
      
        public CustomCartesianRenderer(CartesianArea area)
            : base(area)
        {
           
        }

        protected override void Initialize()
        {
            base.Initialize();
            for (int i = 0; i < this.DrawParts.Count; i++)
            {
                SteplineDrawPart linePart = this.DrawParts[i] as SteplineDrawPart;
                if (linePart != null)
                {
                    this.DrawParts[i] = new CustomLineSeriesDrawPart((SteplineSeries)linePart.Element, this);
                }
            }
        }

    }
}

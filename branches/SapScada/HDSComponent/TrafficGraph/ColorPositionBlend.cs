using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace HDSComponent.TrafficGraph
{
    public class ColorPositionBlend
    {
        private List<float> positions;
        private List<Color> colors;

        public ColorPositionBlend()
        {
            positions = new List<float>();
            colors = new List<Color>();
        }

        public void Add(Color color, float position)
        {
            this.colors.Add(color);
            this.positions.Add(position);
        }

        public void Add(ColorPositionBlend colorPositionBlend)
        {
            this.positions.AddRange(colorPositionBlend.positions);
            this.colors.AddRange(colorPositionBlend.colors);
        }

        public float[] Positions
        {
            get { return this.positions.ToArray(); }
        }

        public Color[] Colors
        {
            get { return this.colors.ToArray(); }
        }
    }
}

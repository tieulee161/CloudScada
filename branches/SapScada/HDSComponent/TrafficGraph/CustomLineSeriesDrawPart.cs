using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using Telerik.WinControls.UI;
using Telerik.Charting;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace HDSComponent.TrafficGraph
{
    class CustomLineSeriesDrawPart : SteplineDrawPart
    {
        Dictionary<float, Color> _ColorMaps = new Dictionary<float, Color>() 
                                            {
                                                {0, Color.Black},
                                                {1, Color.Green},
                                                {2, Color.Yellow},
                                                {4, Color.Red},
                                            };

        List<float> _DataPoints { get; set; }

        public CustomLineSeriesDrawPart(SteplineSeries series, IChartRenderer renderer)
            : base(series, renderer)
        {
            _DataPoints = new List<float>();
            if (series.DataSource != null)
            {
                BindingList<TrafficLightData> data = series.DataSource as BindingList<TrafficLightData>;
                if (data != null)
                {
                    foreach(TrafficLightData point in data)
                    {
                        _DataPoints.Add(point.Z);
                    }

                }
            }
        }

        protected override void DrawLine()
        {
            SteplineSeries series = this.Element as SteplineSeries;
            if (series.DataPoints.Count < 2)
            {
                return;
            }

            RectangleF rect = this.Element.Bounds;
            rect.Offset(this.OffsetX, this.OffsetY);
            if (rect.IsEmpty)
            {
                return;
            }

            GraphicsPath path = GetLinePath();
            LinearGradientBrush linearBrush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, 0f);

            ColorPositionBlend colorPositionBlend = GetColorPositionBlend(_DataPoints);
            System.Drawing.Drawing2D.ColorBlend blend = new System.Drawing.Drawing2D.ColorBlend();
            blend.Positions = colorPositionBlend.Positions;
            blend.Colors = colorPositionBlend.Colors;
            linearBrush.InterpolationColors = blend;

            Graphics graphics = this.Renderer.Surface as Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(new Pen(linearBrush, 3), path);
        }

        private ColorPositionBlend GetColorPositionBlend(List<float> dataPoints)
        {
            ColorPositionBlend blend = new ColorPositionBlend();
            decimal majorStep = 1m / (dataPoints.Count - 1);

            for (int i = 0; i < dataPoints.Count; i++)
            {
                float position = (float)(i * majorStep);
                Color color = GetValueColor(dataPoints[i]);
                blend.Add(color, position);

                if (i < dataPoints.Count - 1)
                {
                    double currentValue = (double)dataPoints[i];
                    double nextValue = (double)dataPoints[i + 1];

                    ColorPositionBlend additionalBlends = GetAdditionalColorPositionBlend(currentValue, nextValue, majorStep, i);
                    blend.Add(additionalBlends);
                }
            }
            return blend;
        }

        private ColorPositionBlend GetAdditionalColorPositionBlend(double currentValue, double nextValue, decimal majorStep, int iteration)
        {
            ColorPositionBlend blend = new ColorPositionBlend();
            float additionalPosition = (float)((double)((iteration + 1) * majorStep));
            Color additionalColor = GetValueColor((float)currentValue);
            blend.Add(additionalColor, additionalPosition);
            return blend;
        }

        private Color GetValueColor(float value)
        {
            Color res = Color.Transparent;
            if (_ColorMaps.ContainsKey(value))
            {
                res = _ColorMaps[value];
            }
            return res;
        }
    }
}

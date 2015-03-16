using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Telerik.Charting;

namespace HDSComponent.TrafficGraph
{
    public partial class UCTrafficGraph : UserControl
    {
        public Dictionary<string, TrafficLightItem> LineItems = new Dictionary<string, TrafficLightItem>();
        
        private float _PredefineConstantValue = 1;
        public UCTrafficGraph()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
          //  this.HDChart.ChartElement.TitlePosition = TitlePosition.Top;
          //  this.HDChart.ChartElement.TitleElement.TextAlignment = ContentAlignment.MiddleLeft;
          //  this.HDChart.ChartElement.TitleElement.Margin = new Padding(10, 10, 0, 0);
          ////  this.HDChart.ChartElement.TitleElement.Font = font;
          //  this.HDChart.View.Margin = new Padding(10, 0, 35, 0);

        

          //  HDChart.ShowGrid = true;
          //  HDChart.CreateRenderer += HDChart_CreateRenderer;
          //  base.OnLoad(e);
        }

        private void HDChart_CreateRenderer(object sender, Telerik.WinControls.UI.ChartViewCreateRendererEventArgs e)
        {
            CustomCartesianRenderer render = new CustomCartesianRenderer(e.Area as CartesianArea);
            e.Renderer = render;
        }

        public void AddLine(string lineName, int lineId, string greenTagName, string yellowTagName, string redTagName)
        {
            if(!LineItems.ContainsKey(lineName))
            {
                TrafficLightItem item = new TrafficLightItem();
                item.Name = lineName;
                item.LineId = lineId;
                item.GreenTagName = greenTagName;
                item.YellowTagName = yellowTagName;
                item.RedTagName = redTagName;

                item.Line = new SteplineSeries();
                item.Line.Name = item.Name;

                item.DataSource = new TrafficLightModel();
                item.DataSource.PredefineConstantValue = _PredefineConstantValue++;

                item.Line.DataSource = item.DataSource.Data;
                item.Line.CategoryMember = "X";
                item.Line.ValueMember = "Z";
                LineItems.Add(lineName, item);

             //   HDChart.Series.Add(item.Line);
                item.Line.VerticalAxis.LabelFormat = item.Line.Name;
                item.Line.HorizontalAxis.LabelFormat = "{0:dd/MM/yy HH:mm:ss}";
                item.Line.HorizontalAxis.LabelFitMode = AxisLabelFitMode.MultiLine;

                //LinearAxis axeY = HDChart.Axes.Get<LinearAxis>(0);
                //axeY.Minimum = 500;
                //axeY.Maximum = 2000;
                //axeY.MajorStep = 500;

                //CategoricalAxis axeX = HDChart.Axes.Get<CategoricalAxis>(0);
                //axeX.LabelInterval = 5;
                //axeX.LabelFormat = "{0:HH:mm:ss.f}";
                //axeX.LastLabelVisibility = AxisLastLabelVisibility.Visible;
            }
        }

        public void AddPoint(string lineName, DateTime x, int green, int yellow, int red)
        {
            if(LineItems.ContainsKey(lineName))
            {
                LineItems[lineName].DataSource.AddPoint(x, green, yellow, red);
            }
        }

        public void Clear()
        {
          //  HDChart.Series.Clear();
            _PredefineConstantValue = 1;
            LineItems.Clear();
        }


    }
}

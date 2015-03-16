using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.Charting;
using Designer.Model;
using HDSComponent.TrafficGraph;

namespace Designer.View
{
    public partial class FrmTrend : RadForm
    {
        public FrmTrend()
        {
            InitializeComponent();
        }

        #region method
        private void UpdateRealTimeTrend()
        {
            DateTime x = DateTime.Now;
            foreach (HDSComponent.UI.HDGraph.LineCurve item in graphTrend.Lines.Values)
            {
                int green = 0, yellow = 0, red = 0;
                bool temp;
                IOTag greenTag = DBAccess.GetIOTag(item.GreenTagName);
                IOTag yellowTag = DBAccess.GetIOTag(item.YellowTagName);
                IOTag redTag = DBAccess.GetIOTag(item.RedTagName);

                if (greenTag != null)
                {
                    temp = false;
                    bool.TryParse(greenTag.Value, out temp);
                    green = temp ? 1 : 0;
                }
                if (yellowTag != null)
                {
                    temp = false;
                    bool.TryParse(yellowTag.Value, out temp);
                    yellow = temp ? 1 : 0;
                }
                if (redTag != null)
                {
                    temp = false;
                    bool.TryParse(redTag.Value, out temp);
                    red = temp ? 1 : 0;
                }
                int value = red * 4 + yellow * 2 + green;
                graphTrend.UpdateTrend(item.Name, value, x);
            }
        }

        private void UpdateHistoryTrend()
        {
            DateTime from = dateFrom.Value;
            DateTime to = dateTo.Value;
            if (to >= from)
            {
                graphTrend.ClearPoints();
                foreach (HDSComponent.UI.HDGraph.LineCurve item in graphTrend.Lines.Values)
                {
                    Dictionary<DateTime, int> data = new Dictionary<DateTime, int>();

                    List<IOTagValue> greenTag = DBAccess.GetIOTagValue(item.GreenTagName, from, to);
                    List<IOTagValue> yellowTag = DBAccess.GetIOTagValue(item.YellowTagName, from, to);
                    List<IOTagValue> redTag = DBAccess.GetIOTagValue(item.RedTagName, from, to);
                    bool temp;
                    for (int j = 0; j < greenTag.Count; j++)
                    {
                        bool.TryParse(greenTag[j].Value, out temp);
                        if (temp == true)
                        {
                            data.Add((DateTime)greenTag[j].TimeStamp, 1);
                        }
                    }
                    for (int j = 0; j < yellowTag.Count; j++)
                    {
                        bool.TryParse(yellowTag[j].Value, out temp);
                        if (temp == true)
                        {
                            data.Add((DateTime)yellowTag[j].TimeStamp, 2);
                        }
                    }
                    for (int j = 0; j < redTag.Count; j++)
                    {
                        bool.TryParse(redTag[j].Value, out temp);
                        if (temp == true)
                        {
                            data.Add((DateTime)redTag[j].TimeStamp, 4);
                        }
                    }

                    List<object> values = new List<object>();
                    List<DateTime> x = new List<DateTime>();

                    List<KeyValuePair<DateTime, int>> mix = data.OrderBy(q => q.Key).ToList();
                    for (int j = 0; j < mix.Count; j++)
                    {
                        values.Add(mix[j].Value);
                        x.Add(mix[j].Key);
                    }

                    graphTrend.UpdateTrend(item.Name, values.ToArray(), x.ToArray());
                }
            }
        }

        #endregion

        #region event
        protected override void OnLoad(EventArgs e)
        {

            List<Device> devices = DBAccess.GetDevices();
            devices.Add(null);
            BindingSource bs = new BindingSource();
            bs.DataSource = devices;
            bs.MoveLast();

            cbbxDevice.DataSource = bs;
            cbbxDevice.DisplayMember = "Name";

            bs.PositionChanged += bs_PositionChanged;
            if (rdRealtime.IsChecked)
            {
                timer1.Enabled = true;
            }

            dateFrom.Value = DateTime.Now;
            dateTo.Value = DateTime.Now;

            graphTrend.LoadGraph();

            btnAdd.Click += Button_Click;
            btnRemove.Click += Button_Click;
            rdRealtime.CheckStateChanged += rdRealtime_CheckStateChanged;
            rdHistory.CheckStateChanged += rdRealtime_CheckStateChanged;
            dateFrom.ValueChanged += dateFrom_ValueChanged;
            dateTo.ValueChanged += dateFrom_ValueChanged;

            base.OnLoad(e);
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            if(rdHistory.IsChecked)
            {
                UpdateHistoryTrend();
            }
        }

        private void rdRealtime_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdRealtime.IsChecked)
            {
                timer1.Enabled = false;
                graphTrend.ClearPoints();
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                graphTrend.ClearPoints();
                UpdateHistoryTrend();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            timer1.Enabled = false;
            base.OnClosing(e);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnAdd))
            {
                timer1.Enabled = false;
                if (((BindingSource)cbbxLine.DataSource).Current != null)
                {
                    KeyValuePair<int, List<IOTag>> obj = (KeyValuePair<int, List<IOTag>>)(((BindingSource)cbbxLine.DataSource).Current);
                    string lineName = string.Format("{0}.Line.{1}", cbbxDevice.Text, obj.Key);
                    if (obj.Value.Count == 2)
                    {
                        graphTrend.AddNewLine(lineName, obj.Value[0].Name, "", obj.Value[1].Name);
                    }
                    else if (obj.Value.Count == 3)
                    {
                        graphTrend.AddNewLine(lineName, obj.Value[0].Name, obj.Value[1].Name, obj.Value[2].Name);
                    }

                }
                timer1.Enabled = true;
            }
            else if (sender.Equals(btnRemove))
            {

                timer1.Enabled = false;
                if (((BindingSource)cbbxLine.DataSource).Current != null)
                {
                    KeyValuePair<int, List<IOTag>> obj = (KeyValuePair<int, List<IOTag>>)(((BindingSource)cbbxLine.DataSource).Current);
                    string lineName = string.Format("{0}.Line.{1}", cbbxDevice.Text, obj.Key);
                    graphTrend.RemoveLine(lineName);
                }
                timer1.Enabled = true;
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            BindingSource bs = (BindingSource)sender;
            Device device = bs.Current as Device;
            if (device != null)
            {
                Dictionary<int, List<IOTag>> lines = DBAccess.GetLines(device.Name);
                BindingSource bs1 = new BindingSource();
                bs1.DataSource = lines;

                cbbxLine.DataSource = bs1;
                cbbxLine.DisplayMember = "Key";
                cbbxLine.ValueMember = "Value";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateRealTimeTrend();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ZedGraph;
using System.Drawing;
using System.Globalization;

namespace HDSComponent.UI
{

    public class HDGraph : System.Windows.Forms.UserControl
    {
        public class LineData
        {
            public DateTime X;
            public double Y;
            public double Z;
        }

        public class LineCurve
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public List<LineData> DataSource { get; set; }
            public bool IsActive { get; set; }
            public RollingPointPairList Data { get; set; }
            public LineItem Curve { get; set; }
            public string GreenTagName { get; set; }
            public string YellowTagName { get; set; }
            public string RedTagName { get; set; }

            public LineCurve(string lineName, int index, string greenTagName, string yellowTagName, string redTagName)
            {
                Index = index;
                Name = lineName;
                IsActive = true;
                GreenTagName = greenTagName;
                YellowTagName = yellowTagName;
                RedTagName = redTagName;

                Fill fill = new Fill(new Color[] { Color.Black, Color.Green, Color.Yellow, Color.Red });
                fill.RangeMin = 0;
                fill.RangeMax = 3;
                fill.Type = FillType.GradientByZ;
                Data = new RollingPointPairList(10000);
                Curve = new LineItem(lineName, Data, Color.Black, SymbolType.None);
                Curve.Line.GradientFill = fill;
                Curve.Line.Width = 3f;
            }
        }

        private GraphPane _MyPane;
        private DateTime _TickStart;
        private System.Windows.Forms.Timer timer1;
        private int _ViewMode = 0;
        private bool _FirstScan;
        private LineObj _Xref;
        private bool _IsEnableXRef;
        private CultureInfo enFr = new CultureInfo("fr-ch");
        private DateTime _DateFrom;
        private DateTime _DateTo;

        public Dictionary<string, LineCurve> Lines;
        public DateTime DateFrom
        {
            get
            {
                return _DateFrom;
            }
            set
            {
                _DateFrom = value;
                _Zgc.GraphPane.XAxis.Scale.Min = (double)(new XDate(_DateFrom));

            }
        }
        public DateTime DateTo
        {
            get
            {
                return _DateTo;
            }
            set
            {
                _DateTo = value;
                _Zgc.GraphPane.XAxis.Scale.Max = (double)(new XDate(_DateTo));
            }
        }
        private ZedGraph.ZedGraphControl _Zgc;

        public HDGraph()
        {
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(469, 257);

            _Zgc = new ZedGraphControl();
            _Zgc.Dock = System.Windows.Forms.DockStyle.Fill;
            _IsEnableXRef = false;
            _Zgc.DoubleClick += _Zgc_DoubleClick;
            _Zgc.MouseMoveEvent += _Zgc_MouseMoveEvent;
            this.Controls.Add(_Zgc);

            Lines = new Dictionary<string, LineCurve>();

            this.ResumeLayout();
        }

        public void AddNewLine(string lineName)
        {
            if (!Lines.ContainsKey(lineName))
            {
                //LineCurve line = new LineCurve(lineName, Lines.Count);
                //Lines.Add(lineName, line);
                //AddCurve(_Zgc, line);
                //RefreshChart(_Zgc);
            }
        }

        public void AddNewLine(string lineName, string greenTagName, string yellowTagName, string redTagName)
        {
            if (!Lines.ContainsKey(lineName))
            {
                LineCurve line = new LineCurve(lineName, Lines.Count, greenTagName, yellowTagName, redTagName);
                Lines.Add(lineName, line);
                AddCurve(_Zgc, line);
                RefreshChart(_Zgc);
            }
        }

        public void RemoveLine(string lineName)
        {
            if (Lines.ContainsKey(lineName))
            {
                Lines.Remove(lineName);
                RemoveCurve(_Zgc, lineName);
                RefreshChart(_Zgc);
            }
        }

        public void ActiveLine(string lineName)
        {
            if (Lines.ContainsKey(lineName))
            {
                Lines[lineName].IsActive = true;
            }
        }

        public void DeactiveLine(string lineName)
        {
            if (Lines.ContainsKey(lineName))
            {
                Lines[lineName].IsActive = false;
            }
        }

        public void Clear()
        {
            List<string> lineNames = Lines.Keys.ToList();
            for (int j = lineNames.Count - 1; j >= 0; j--)
            {
                RemoveLine(lineNames[j]);
            }
        }

        public void LoadGraph()
        {
            InitTrend(_Zgc);

        }

        public void ClearPoint(string lineName)
        {
            if (Lines.ContainsKey(lineName))
            {
                Lines[lineName].Data.Clear();
            }
        }

        public void ClearPoints()
        {
            foreach(LineCurve item in Lines.Values)
            {
                ClearPoint(item.Name);
            }
        }

        #region chart
        private void InitializeLineSeries(ZedGraphControl zed, string title)
        {
            RollingPointPairList Data_List = new RollingPointPairList(6000);
            RollingPointPairList Data_List1 = new RollingPointPairList(6000);
            RollingPointPairList Data_List2 = new RollingPointPairList(6000);
            RollingPointPairList Data_List3 = new RollingPointPairList(6000);
            Font f = new System.Drawing.Font("Segoe UI", 10);

            GraphPane myPane = zed.GraphPane;
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = "Ngày";
            myPane.YAxis.Title.Text = "Giờ";
            myPane.Legend.IsVisible = false;
            myPane.GraphObjList.Clear();
            myPane.CurveList.Clear();

            myPane.XAxis.Type = ZedGraph.AxisType.Date;
            myPane.YAxis.Type = ZedGraph.AxisType.Date;

            DateTime today = DateTime.Now.Add(-DateTime.Now.TimeOfDay);
            myPane.XAxis.Scale.Min = (double)(new XDate(today.AddDays(-15)));
            myPane.XAxis.Scale.Max = (double)(new XDate(today.AddDays(15)));
            myPane.XAxis.Scale.Format = "dd-MM-yyyy";

            myPane.XAxis.Scale.MajorUnit = DateUnit.Month;
            myPane.XAxis.Scale.MinorUnit = DateUnit.Day;
            myPane.XAxis.Scale.MajorStep = 4;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.MajorGrid.IsVisible = true;

            myPane.YAxis.Scale.Min = (double)(new XDate(new DateTime(2013, 1, 1, 17, 30, 0)));
            myPane.YAxis.Scale.Max = (double)(new XDate(new DateTime(2013, 1, 1, 19, 0, 0)));

            myPane.YAxis.Scale.MinorStep = 5;
            myPane.YAxis.Scale.MajorStep = 10;
            myPane.YAxis.Scale.Format = "HH:mm";
            myPane.YAxis.Scale.MajorUnit = DateUnit.Hour;
            myPane.YAxis.Scale.MinorUnit = DateUnit.Minute;
            myPane.YAxis.MajorGrid.IsVisible = true;

            myPane.YAxis.IsVisible = true;
            myPane.Legend.IsVisible = true;

            zed.IsEnableVZoom = true;
            zed.IsEnableHZoom = true;

            // Scale the axes
            RefreshChart(zed);
        }

        private void RefreshChart(ZedGraphControl zed)
        {
            try
            {
                zed.Invalidate();
                zed.AxisChange();
                zed.Refresh();
            }
            catch (Exception) { }
        }

        private void InitTrend(ZedGraphControl zed)
        {
            _FirstScan = true;
            _IsEnableXRef = false;

            if (timer1 != null)
            {
                timer1.Interval = 1000;
                timer1.Enabled = false;
                timer1 = null;
            }

            Font f = new System.Drawing.Font("Segoe UI", 10);
            GraphPane myPane = zed.GraphPane;
            //  myPane.Title.FontSpec.Family = f.FontFamily.ToString();
            myPane.Title.Text = "Giản đồ trạng thái tín hiệu";
            myPane.XAxis.Title.IsVisible = false;
            myPane.YAxis.Title.IsVisible = false;
            myPane.Legend.IsVisible = false;
            myPane.GraphObjList.Clear();
            myPane.CurveList.Clear();
            myPane.IsFontsScaled = false;

            //  zed.IsAntiAlias = true;
            myPane.XAxis.Type = AxisType.Date;

            DateTime today = DateTime.Now;
            myPane.XAxis.Scale.Min = (double)(new XDate(today.AddMinutes(-5)));
            myPane.XAxis.Scale.Max = (double)(new XDate(today.AddMinutes(5)));
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.Scale.MinorStep = 2;
            myPane.XAxis.Scale.MajorStep = 10;
            myPane.XAxis.Scale.Format = "HH:mm:ss";
            myPane.XAxis.Scale.MajorUnit = DateUnit.Minute;
            myPane.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MinorGrid.IsVisible = true;

            myPane.YAxis.MinorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.IsVisible = false;
          

            Scale xScale = myPane.XAxis.Scale;
            xScale.MaxAuto = true;
            xScale.MinAuto = true;
            xScale.MajorStepAuto = true;
            xScale.MinorStepAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;

            zed.IsEnableVZoom = false;
            zed.IsEnableHZoom = true;

            // Scale the axes
            RefreshChart(zed);
        }

        private void AddCurve(ZedGraphControl zed, LineCurve curve)
        {
            zed.GraphPane.CurveList.Add(curve.Curve);
            TextObj Lb = new TextObj(curve.Name, 0, curve.Index * 2 + 1, CoordType.XChartFractionYScale);
            Lb.FontSpec = new FontSpec(this.Font.FontFamily.ToString(), (float)12, Color.Black, false, false, false);
            Lb.FontSpec.Border.IsVisible = false;
            Lb.FontSpec.FontColor = Color.DeepSkyBlue;
            zed.GraphPane.GraphObjList.Add(Lb);
            Lb.IsClippedToChartRect = true;
            Lb.Location.AlignH = AlignH.Left;
        }

        private void RemoveCurve(ZedGraphControl zed, string curveName)
        {
            for (int j = 0; j < zed.GraphPane.CurveList.Count; j++)
            {
                if (zed.GraphPane.CurveList[j].Label.Text == curveName)
                {
                    zed.GraphPane.CurveList.RemoveAt(j);
                    break;
                }
            }

            for (int j = 0; j < zed.GraphPane.GraphObjList.Count; j++)
            {
                if (zed.GraphPane.GraphObjList[j].GetType() == typeof(TextObj))
                {
                    if (((TextObj)zed.GraphPane.GraphObjList[j]).Text == curveName)
                    {
                        zed.GraphPane.GraphObjList.RemoveAt(j);
                        break;
                    }
                }
            }

            RefreshChart(_Zgc);
        }

        private bool _Zgc_MouseMoveEvent(ZedGraphControl sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_IsEnableXRef == true)
            {
                double x = 0, y = 0;
                PointF a = new PointF(e.X, e.Y);
                _Zgc.GraphPane.ReverseTransform(a, out x, out y);
                if ((_Zgc.GraphPane.XAxis.Scale.Min < x) && (_Zgc.GraphPane.XAxis.Scale.Max > x))
                {
                    if (_Zgc.GraphPane.GraphObjList.Contains(_Xref)) _Zgc.GraphPane.GraphObjList.Remove(_Xref);
                    _Xref = new LineObj(x, _Zgc.GraphPane.YAxis.Scale.Min, x, _Zgc.GraphPane.YAxis.Scale.Max);
                    _Xref.IsClippedToChartRect = true;
                    _Xref.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
                    _Zgc.GraphPane.GraphObjList.Add(_Xref);
                    _Zgc.GraphPane.Title.Text = "Giản đồ thời gian\n" + XDate.XLDateToDateTime(_Xref.Location.X).ToString(enFr);

                }
                else
                {
                    // zed.GraphPane.Title.Text = "Giản đồ thời gian";
                }

                RefreshChart(_Zgc);
            }
            return true;
        }

        private void _Zgc_DoubleClick(object sender, EventArgs e)
        {
            _IsEnableXRef = !_IsEnableXRef;
        }


        public void UpdateTrend(string[] title, object[] data, DateTime XTime)
        {
            for (int j = 0; j < data.Length; j++)
            {
                if (data[j] == null) data[j] = 0;
                data[j] = Convert.ToInt32(data[j]) & 0x0f;
                switch ((int)data[j])
                {
                    case 0:
                        data[j] = 0;
                        break;
                    case 1:
                        data[j] = 1;
                        break;
                    case 2:
                        data[j] = 2;
                        break;
                    case 4:
                    case 0x0C:
                        data[j] = 3;
                        break;
                }
            }

            for (int j = 0; j < title.Length; j++)
            {
                if (Lines.ContainsKey(title[j]))
                {
                    Lines[title[j]].Data.Add((double)(new XDate(XTime)), j * 2 + 1, (int)data[j]);
                }
            }

            if ((XTime != null) && (_FirstScan == true))
            {
                _TickStart = XTime;
                _FirstScan = false;
            }

            Scale xScale = _Zgc.GraphPane.XAxis.Scale;
            double time = (XTime.Ticks - _TickStart.Ticks) / 1000;
            if (time > xScale.Max - xScale.MajorStep)
            {
                if (_ViewMode == 1)
                {
                    xScale.Max = (double)new XDate(XTime.AddSeconds(3));
                    xScale.Min = (double)new XDate(XTime.AddSeconds(-27));
                }
                else
                {
                    xScale.Max = (double)new XDate(XTime.AddSeconds(5));
                    xScale.Min = (double)new XDate(_TickStart);
                }
                _Zgc.GraphPane.XAxis.Scale.Format = "HH:mm:ss";
            }
            RefreshChart(_Zgc);
        }

        // one line, one datum
        public void UpdateTrend(string title, object data, DateTime XTime)
        {
            if ((XTime != null) && (_FirstScan == true))
            {
                _TickStart = XTime;
                _FirstScan = false;
            }

            if (data == null) data = 0;
            data = Convert.ToInt32(data) & 0x0f;
            switch ((int)data)
            {
                case 0:
                    data = 0;
                    break;
                case 1:
                    data = 1;
                    break;
                case 2:
                    data = 2;
                    break;
                case 4:
                case 0x0C:
                    data = 3;
                    break;
            }

            if (Lines.ContainsKey(title))
            {
                Lines[title].Data.Add((double)(new XDate(XTime)), Lines[title].Index * 2 + 1, (int)data);
            }

            if (!this.IsDisposed)
            {
                Scale xScale = _Zgc.GraphPane.XAxis.Scale;
                double time = (XTime.Ticks - _TickStart.Ticks) / 1000;
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = (double)new XDate(XTime.AddSeconds(3));
                    xScale.Min = (double)new XDate(XTime.AddSeconds(-197));
                }

                _Zgc.GraphPane.XAxis.Scale.Format = "HH:mm:ss";

                RefreshChart(_Zgc);
            }
        }

        // for history trend
        public void UpdateTrend(string title, object[] data, DateTime[] XTime)
        {
            for (int j = 0; j < data.Length; j++)
            {
                if (data[j] == null) data[j] = 0;
                data[j] = Convert.ToInt32(data[j]) & 0x0f;
                switch ((int)data[j])
                {
                    case 0:
                        data[j] = 0;
                        break;
                    case 1:
                        data[j] = 1;
                        break;
                    case 2:
                        data[j] = 2;
                        break;
                    case 4:
                    case 0x0C:
                        data[j] = 3;
                        break;
                }
            }

            if (Lines.ContainsKey(title))
            {
                for (int j = 0; j < data.Length; j++)
                {
                    Lines[title].Data.Add((double)(new XDate(XTime[j])), Lines[title].Index * 2 + 1, (int)data[j]);
                }
            }

            _Zgc.GraphPane.XAxis.Scale.Format = "HH:mm:ss";

            RefreshChart(_Zgc);
        }


        #endregion

        // scenario
        // 1: Load Graph
        // 2: Add new line
        // 3: update trend

    }
}

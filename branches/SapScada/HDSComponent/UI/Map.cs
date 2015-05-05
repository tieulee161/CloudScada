using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET;


namespace HDSComponent.UI
{
    public partial class Map : UserControl
    { 
        private float _Latitude = 10.777970f; //10.784328F;, 
        private float _Longitude = 106.700977f; //106.691608F;
        private GMapOverlay _BoxOverlay;
        private MyMarker _CurrentMarker;
        private const int ZoomLevel0 = 10;
        private const int ZoomLevel1 = 15;
        private bool _IsDraggingMaker = false;
        private bool _IsAddingNewMarker = false;
        public bool IsAllowMovingMarker { get; set; }

        private float TrackValue
        {
            get
            {
                return trackZoom.Maximum - trackZoom.Value + trackZoom.Minimum;
            }
            set
            {
                trackZoom.Value = trackZoom.Maximum - value + trackZoom.Minimum;
            }
        }

        public Map()
        {
            InitializeComponent();
            this.Disposed += new EventHandler(Map_Disposed);
            IsAllowMovingMarker = false;
        }

        private void Map_Disposed(object sender, EventArgs e)
        {
            ClearCache();
        }

        private void ClearCache()
        {
            MainMap.Manager.CancelTileCaching();
        }

        private void Map_Load(object sender, EventArgs e)
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                MainMap.MapProvider = GMapProviders.GoogleMap;
                MainMap.Manager.Mode = AccessMode.ServerAndCache;

                _BoxOverlay = new GMapOverlay(MainMap, "1");
                MainMap.Overlays.Add(_BoxOverlay);

                MainMap.Position = new PointLatLng(_Latitude, _Longitude);
                MainMap.MinZoom = (int)trackZoom.Minimum;
                MainMap.MaxZoom = (int)trackZoom.Maximum;
                MainMap.Zoom = (double)TrackValue;
                MainMap.DragButton = System.Windows.Forms.MouseButtons.Left;

                _IsDraggingMaker = false;

                contextAdd.Click += contextAdd_Click;
                contextDelete.Click += contextDelete_Click;
                contextSetting.Click += contextSetting_Click;
                contextIsMovable.Click += contextIsMovable_Click;

            }
            catch
            {
                MainMap.Manager.Mode = AccessMode.CacheOnly;
                MessageHandler.NetworkError();
            }
        }

        #region add/edit/delete marker
        private void contextIsMovable_Click(object sender, EventArgs e)
        {
            IsAllowMovingMarker = contextIsMovable.IsChecked;
        }

        private void contextDelete_Click(object sender, EventArgs e)
        {
            if (_CurrentMarker != null)
            {
                if (MessageHandler.AskForDeleteRecord())
                {
                    OnDeleteMarker(new MarkerEventArgs(_CurrentMarker.MakerName, _CurrentMarker.Position.Lat, _CurrentMarker.Position.Lng, _CurrentMarker));
                    RemoveMarker(_CurrentMarker);
                    _CurrentMarker = null;

                }
            }
        }

        private void contextAdd_Click(object sender, EventArgs e)
        {
            _IsAddingNewMarker = true;
        }

        private void MainMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (_IsAddingNewMarker)
                {
                    _IsAddingNewMarker = false;
                    MyMarker marker = AddMarker("", e.X, e.Y);
                    PointLatLng pos = MainMap.FromLocalToLatLng(e.X, e.Y);
                    OnAddNewMarker(new MarkerEventArgs("", pos.Lat, pos.Lng, marker));
                }
                else
                {
                    if (_CurrentMarker != null)
                    {
                        OnDoubleClickMarker(new MarkerEventArgs(_CurrentMarker.MakerName, _CurrentMarker.Position.Lat, _CurrentMarker.Position.Lng, _CurrentMarker));
                    }
                }
            }
        }

        private void contextSetting_Click(object sender, EventArgs e)
        {
            if (_CurrentMarker != null)
            {
                OnUpdateMarker(new MarkerEventArgs(_CurrentMarker.MakerName, _CurrentMarker.Position.Lat, _CurrentMarker.Position.Lng, _CurrentMarker));
            }
        }

        private MyMarker AddMarker(string name, int X, int Y)
        {
            PointLatLng position = MainMap.FromLocalToLatLng(X, Y);
            MyMarker marker = new MyMarker(position, this);
            marker.MakerName = name; // deviceName

            if (MainMap.Zoom >= ZoomLevel1)
            {
                marker.ToolTipMode = MarkerTooltipMode.Always;
            }
            else
            {
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            }

            _BoxOverlay.Markers.Add(marker);
            return marker;
        }

        public MyMarker AddMarker(string name, double lat, double lng)
        {
            GPoint position = MainMap.FromLatLngToLocal(new PointLatLng(lat, lng));
            return AddMarker(name, (int)position.X, (int)position.Y);
        }

        private void RemoveMarker(MyMarker item)
        {
            MainMap.Overlays[0].Markers.Remove(item);
        }

        private void RemoveMarker(string itemName)
        {
            for (int j = 0; j < _BoxOverlay.Markers.Count; j++)
            {
                if (((MyMarker)_BoxOverlay.Markers[j]).MakerName == itemName)
                {
                    this.RemoveMarker((MyMarker)_BoxOverlay.Markers[j]);
                    break;
                }
            }
        }

        public void ChangeMarkerName(string itemName, string newName)
        {
            for (int j = 0; j < _BoxOverlay.Markers.Count; j++)
            {
                if (((MyMarker)_BoxOverlay.Markers[j]).MakerName == itemName)
                {
                    ((MyMarker)_BoxOverlay.Markers[j]).MakerName = newName;
                    break;
                }
            }
        }
        #endregion

        private void FocusView(double[] location)
        {
            MainMap.SetZoomToFitRect(new RectLatLng(location[0], location[1], location[3], location[2]));
        }

        #region drag-drop marker
        private void MainMap_OnMapZoomChanged()
        {
            if (MainMap.Zoom <= ZoomLevel0)
            {
                MainMap.MarkersEnabled = false;
                MainMap.PolygonsEnabled = false;
            }
            else
            {
                MainMap.MarkersEnabled = true;
                MainMap.PolygonsEnabled = true;
            }

            if (MainMap.Zoom >= ZoomLevel1)
            {
                for (int j = 0; j < _BoxOverlay.Markers.Count; j++)
                {
                    _BoxOverlay.Markers[j].ToolTipMode = MarkerTooltipMode.Always;
                    _BoxOverlay.Markers[j].Size = new Size(32, 32);
                }
            }
            else
            {
                for (int j = 0; j < _BoxOverlay.Markers.Count; j++)
                {
                    _BoxOverlay.Markers[j].ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    _BoxOverlay.Markers[j].Size = new Size((int)(MainMap.Zoom), (int)(MainMap.Zoom));
                }
            }

            TrackValue = (int)MainMap.Zoom;
        }

        private void MainMap_OnMarkerEnter(GMapMarker item)
        {
            MyMarker mark = item as MyMarker;
            _CurrentMarker = mark;
        }

        private void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (_IsDraggingMaker == false)
            {
                _CurrentMarker = null;
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsAllowMovingMarker)
            {
                if ((e.Button == System.Windows.Forms.MouseButtons.Left) && (_CurrentMarker != null) && (_CurrentMarker.IsMouseOver))
                {
                    _IsDraggingMaker = true;
                }
            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsAllowMovingMarker)
            {
                if (_IsDraggingMaker == true)
                {
                    _IsDraggingMaker = false;
                    PointLatLng location = MainMap.FromLocalToLatLng(e.X, e.Y);
                    MarkerEventArgs ex = new MarkerEventArgs(_CurrentMarker.MakerName, location.Lat, location.Lng, _CurrentMarker);
                    OnMarkerLocationChangedEvent(ex);
                }
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsAllowMovingMarker)
            {
                if ((_IsDraggingMaker) && (e.Button == MouseButtons.Left) && (_CurrentMarker != null))
                {
                    PointLatLng p = MainMap.FromLocalToLatLng(e.X, e.Y);
                    _CurrentMarker.Position = p;
                }
            }
        }

        private void MainMap_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void MainMap_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] type = e.Data.GetFormats();
                object[] data = (object[])e.Data.GetData(type[0]);
                UserControl uc = (UserControl)data[0];
                int x = (int)data[1];
                int y = (int)data[2];

                uc.Parent = MainMap;
                uc.Location = MainMap.PointToClient(new Point(e.X - x, e.Y - y));
                uc.BringToFront();
            }
            catch (Exception ex)
            {
                //MessageHandler.Error(ex.Message);
            }
        }

        #endregion
        private void trackZoom_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = TrackValue;
        }

        private void MainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            // do nothing

        }

        private void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (_CurrentMarker != null)
            //{
            //    OnDoubleClickMarker(new MarkerEventArgs(_CurrentMarker.DisplayTag.Name, _CurrentMarker.Position.Lat, _CurrentMarker.Position.Lng, _CurrentMarker));
            //}
        }

        #region event
        public delegate void MarkerInfoChangedHandler(object sender, MarkerEventArgs e);
        public event MarkerInfoChangedHandler RaiseMarkerLocationChangedEvent;
        private void OnMarkerLocationChangedEvent(MarkerEventArgs e)
        {
            if (RaiseMarkerLocationChangedEvent != null)
            {
                RaiseMarkerLocationChangedEvent(this, e);
            }
        }

        public event MarkerInfoChangedHandler RaiseAddNewMarkerEvent;
        private void OnAddNewMarker(MarkerEventArgs e)
        {
            if (RaiseAddNewMarkerEvent != null)
            {
                RaiseAddNewMarkerEvent(this, e);
            }
        }

        public event MarkerInfoChangedHandler RaiseDeleteMarkerEvent;
        private void OnDeleteMarker(MarkerEventArgs e)
        {
            if (RaiseDeleteMarkerEvent != null)
            {
                RaiseDeleteMarkerEvent(this, e);
            }
        }

        public event MarkerInfoChangedHandler RaiseUpdateMarkerEvent;
        private void OnUpdateMarker(MarkerEventArgs e)
        {
            if (RaiseUpdateMarkerEvent != null)
            {
                RaiseUpdateMarkerEvent(this, e);
            }
        }

        public event MarkerInfoChangedHandler RaiseMarkerDoubleClickEvent;
        private void OnDoubleClickMarker(MarkerEventArgs e)
        {
            if (RaiseMarkerDoubleClickEvent != null)
            {
                RaiseMarkerDoubleClickEvent(this, e);
            }
        }

        #endregion

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                string localtion = txtSearch.Text;
                GeoCoderStatusCode a = MainMap.SetCurrentPositionByKeywords(localtion);

                GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;
                GeocodingProvider gp = GMapProviders.GoogleMap as GeocodingProvider;
                if (gp != null)
                {
                    var pt = gp.GetPoint(localtion, out status);
                    List<PointLatLng> position = new List<PointLatLng>();
                    status = gp.GetPoints(localtion, out position);
                    if (status == GeoCoderStatusCode.G_GEO_SUCCESS && pt.HasValue)
                    {
                        MainMap.Position = pt.Value;
                    }
                }

            }
        }

        private void radContextMenu1_DropDownOpening(object sender, CancelEventArgs e)
        {
            if (_CurrentMarker != null)
            {
                // prepare context menu
                contextAdd.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                contextDelete.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                contextSetting.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                radMenuSeparatorItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            }
            else
            {
                contextAdd.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                contextDelete.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                contextSetting.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                radMenuSeparatorItem1.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            }
        }
    }

    public class MarkerEventArgs : EventArgs
    {
        public string MarkerName;
        public double Lat;
        public double Lng;
        public MyMarker Marker;
        public MarkerEventArgs(string markerName, double lat, double lng, MyMarker marker)
        {
            MarkerName = markerName;
            Lat = lat;
            Lng = lng;
            Marker = marker;
        }

        public MarkerEventArgs()
        {
            MarkerName = "";
            Lat = 0;
            Lng = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Designer.Model;
using HDSComponent;
using Common;
using System.Threading;
using Designer.Core;
using System.Diagnostics;

namespace Designer.View
{


    public partial class FrmMonitor : Telerik.WinControls.UI.RadForm
    {
        public FrmMonitor()
        {
            InitializeComponent();
        }


        private List<Form> _Frms = new List<Form>();

        private void FrmMonitor_Load(object sender, EventArgs e)
        {
            LoadGraphics();
            GMap.RaiseAddNewMarkerEvent += GMap_RaiseAddNewMarkerEvent;
            GMap.RaiseUpdateMarkerEvent += GMap_RaiseUpdateMarkerEvent;
            GMap.RaiseMarkerLocationChangedEvent += GMap_RaiseMarkerLocationChangedEvent;
            GMap.RaiseDeleteMarkerEvent += GMap_RaiseDeleteMarkerEvent;
            GMap.RaiseMarkerDoubleClickEvent += GMap_RaiseMarkerDoubleClickEvent;
            btnUpdateTime.Click += btnUpdateTime_Click;
        }

        private void btnUpdateTime_Click(object sender, EventArgs e)
        {
            List<Device> devices = DBAccess.GetDevices();
            foreach (Device dev in devices)
            {
                string tagName = "";
                if (dev.Driver == "VDK")
                {
                    tagName = string.Format("{0}.SetTime", dev.Name);
                }
                else
                {
                    tagName = string.Format("{0}.SETTIME", dev.Name);
                }
                string tagAddress = Program.GetDisplayTagAddress(tagName);
                Program.SetIOTag(tagName, tagAddress, new object[] { true });
            }
            Designer.Properties.Settings.Default.LastUpdateTime = DateTime.Now;
            Designer.Properties.Settings.Default.Save();
        }

        private void GMap_RaiseMarkerDoubleClickEvent(object sender, HDSComponent.UI.MarkerEventArgs e)
        {
           if(GMap.IsAllowMovingMarker == false)
           {
               string deviceName = DesignerAccess.GetJunction(e.MarkerName).DeviceName;
               Device dev = DBAccess.GetDevice(deviceName);
               if (dev != null)
               {
                   if (dev.Driver == Common.DriverType.VDK.ToString())
                   {
                       FrmVDKJunction f = new FrmVDKJunction();
                       f.JunctionName = e.MarkerName;
                       f.Show(this);
                   }
                   else if (dev.Driver == Common.DriverType.OPC.ToString())
                   {
                       FrmPLCJunction f = new FrmPLCJunction();
                       f.JunctionName = e.MarkerName;
                       f.Show(this);
                   }
               }
           }
            

            //Thread t = new Thread(new ThreadStart(() =>
            //    {

            //    }));
            //t.ApartmentState = ApartmentState.STA;
            //t.Start();
        }

        private void GMap_RaiseDeleteMarkerEvent(object sender, HDSComponent.UI.MarkerEventArgs e)
        {
            if (!DesignerAccess.DeleteJunction(e.MarkerName))
            {
                MessageHandler.DeleteRecordError();
            }
        }

        private void GMap_RaiseMarkerLocationChangedEvent(object sender, HDSComponent.UI.MarkerEventArgs e)
        {
            Junction junc = DesignerAccess.GetJunction(e.MarkerName);
            if (junc != null)
            {
                junc.Lat = e.Lat;
                junc.Lng = e.Lng;
                if (!DesignerAccess.UpdateJunction(junc.JunctionName, junc))
                {
                    MessageHandler.UpdateRecordError();
                }
            }
        }

        private void GMap_RaiseUpdateMarkerEvent(object sender, HDSComponent.UI.MarkerEventArgs e)
        {
            FrmJunction f = new FrmJunction();
            f.MarkerInfo = e;
            f.ShowDialog();
            GMap.ChangeMarkerName(e.MarkerName, f.Junc.JunctionName);
        }

        private void GMap_RaiseAddNewMarkerEvent(object sender, HDSComponent.UI.MarkerEventArgs e)
        {
            if (DesignerAccess.AddJunction(e.MarkerName, e.MarkerName, e.Lat, e.Lng, "", "", "", ""))
            {
                FrmJunction f = new FrmJunction();
                f.MarkerInfo = e;
                f.ShowDialog();
                e.Marker.MakerName = f.Junc.JunctionName;
            }
        }

        private void LoadGraphics()
        {
            Display disp = new Display(1000);
            List<Junction> juncs = DesignerAccess.GetJunctions();
            for (int j = 0; j < juncs.Count; j++)
            {
                HDSComponent.UI.MyMarker marker = GMap.AddMarker(juncs[j].JunctionName, (double)juncs[j].Lat, (double)juncs[j].Lng);
                marker.DisplayTag.Name = juncs[j].Tag;
                marker.DisplayTag.Address = Program.GetDisplayTagAddress(marker.DisplayTag.Name);
                marker.DisplayTag.RaiseTagValueChangedEvent += DisplayTag_RaiseTagValueChangedEvent;
                disp.AddTag(marker.DisplayTag);
            }
            Program.AddDisplayForm(this, new List<Display>() { disp });
        }

        private void DisplayTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            
        }

        private void FrmMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.RemoveDisplayForm(this);
        }
    }
}

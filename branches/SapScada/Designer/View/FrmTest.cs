using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Designer.Model;

namespace Designer.View
{
    public partial class FrmTest : Telerik.WinControls.UI.RadForm
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog f = new FolderBrowserDialog();
            //var m = f.ShowDialog();
            //if (m == System.Windows.Forms.DialogResult.OK)
            //{
            //    string path = f.SelectedPath;
            //    if (!path.EndsWith("\\"))
            //    {
            //        path += "\\";
            //    }
            //    DBAccess.CreateDatabaseForProject(path);
                
            //}
            DesignerAccess.CreateJunctionDoc();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            //Junction junc = new Junction();
            //junc.Name = "123";
            //junc.Lat = 1;
            //junc.Lng = 2;
            //junc.Tag = "abc";
            //junc.Expression = "adf";
            //DesignerAccess.UpdateJunction("test", junc);
            DesignerAccess.DeleteJunction("test");
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            map1.RaiseAddNewMarkerEvent += map1_RaiseAddNewMarkerEvent;
            map1.RaiseMarkerDoubleClickEvent += map1_RaiseMarkerDoubleClickEvent;

            FrmMonitor f = new FrmMonitor();
            f.Show();
        }

        void map1_RaiseMarkerDoubleClickEvent(object sender, HDSComponent.UI.MarkerEventArgs e)
        {
            
        }

        void map1_RaiseAddNewMarkerEvent(object sender, HDSComponent.UI.MarkerEventArgs e)
        {
           
        }

        private void map1_DoubleClick(object sender, EventArgs e)
        {
           
        }
    }
}

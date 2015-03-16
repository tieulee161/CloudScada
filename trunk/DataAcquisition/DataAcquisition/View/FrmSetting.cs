using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using DataAcquisition.Service;
using DataAcquisition.Model.Entities;

namespace DataAcquisition.View
{
    public partial class FrmSetting : Telerik.WinControls.UI.RadForm
    {
        public FrmSetting()
        {
            InitializeComponent();
            lbStatus.Text = "";
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            ServiceInfo info = DBAccess.GetServiceInfo();
            if(info != null)
            {
                txtServerIP.Text = info.ServerIP;
                spinVDKServicePort.Value = info.VDKServicePort;
                spinOPCServicePort.Value = info.OPCServicePort;
            }
            else
            {
                txtServerIP.Text = "";
                spinVDKServicePort.Value = 0;
                spinOPCServicePort.Value = 0;
            }

            List<Port> VDKPorts = DBAccess.GetPorts(DriverType.VDK);
            foreach(Port p in VDKPorts)
            {
                dtgVDKPort.Rows.Add(new object[] { p.Id, p.DriverPort });
            }

            List<Port> OPCPorts = DBAccess.GetPorts(DriverType.OPC);
            foreach (Port p in OPCPorts)
            {
                dtgOPCPort.Rows.Add(new object[] { p.Id, p.DriverPort });
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if(sender.Equals(btnUpdateService))
            {
                if (DBAccess.UpdateServiceInfo(txtServerIP.Text, (int)spinVDKServicePort.Value, (int)spinOPCServicePort.Value) > 0)
                {
                    lbStatus.Text = "Update service info successfully !";
                }
                else
                {
                    lbStatus.Text = "Update service info unsuccessfully !";
                }
            }
            else if (sender.Equals(btnAddVDKPort))
            {
                Port newPort = DBAccess.AddPort(DriverType.VDK, (int)spinVDKPort.Value);
                if (newPort != null)
                {
                    dtgVDKPort.Rows.Add(new object[] { newPort.Id, newPort.DriverPort });
                    lbStatus.Text = "Add VDK port successfully !";
                }
                else
                {
                    lbStatus.Text = "Add VDK port unsuccessfully !";
                }
            }
            else if (sender.Equals(btnDeleteVDKPort))
            {
                if(dtgVDKPort.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgVDKPort.SelectedRows[0].Cells[0].Value;
                    if(DBAccess.DeletePort(id) > 0)
                    {
                        dtgVDKPort.SelectedRows[0].Delete();
                        lbStatus.Text = "Delete VDK port successfully !";
                    }
                    else
                    {
                        lbStatus.Text = "Delete VDK port unsuccessfully !";
                    }
                }
            }
            else if (sender.Equals(btnAddOPCPort))
            {
                Port newPort = DBAccess.AddPort(DriverType.OPC, (int)spinOPCPort.Value);
                if (newPort != null)
                {
                    dtgOPCPort.Rows.Add(new object[] { newPort.Id, newPort.DriverPort });
                    lbStatus.Text = "Add OPC port successfully !";
                }
                else
                {
                    lbStatus.Text = "Add OPC port unsuccessfully !";
                }
            }
            else if (sender.Equals(btnDeleteOPCPort))
            {
                if (dtgOPCPort.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgOPCPort.SelectedRows[0].Cells[0].Value;
                    if (DBAccess.DeletePort(id) > 0)
                    {
                        dtgOPCPort.SelectedRows[0].Delete();
                        lbStatus.Text = "Delete OPC port successfully !";
                    }
                    else
                    {
                        lbStatus.Text = "Delete OPC port unsuccessfully !";
                    }
                }
            }

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using HDSComponent;
using HDSComponent.UI;
using Designer.Model;

namespace Designer.View
{
    public partial class FrmJunction : Telerik.WinControls.UI.RadForm
    {
        public MarkerEventArgs MarkerInfo;
        public Junction Junc;

        public FrmJunction()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnUpdate))
            {
                if (Junc != null)
                {
                    string oldName = Junc.JunctionName;
                    Junc.JunctionName = txtJunctionName.Text;
                    Junc.DeviceName = cbbxDeviceName.Text;
                    Junc.Tag = cbbxTag.Text;
                    Junc.Expression = txtExpression.Text;
                    Junc.Lat = MarkerInfo.Lat;
                    Junc.Lng = MarkerInfo.Lng;
                    if (DesignerAccess.UpdateJunction(oldName, Junc))
                    {
                        Close();
                    }
                    else
                    {
                        MessageHandler.UpdateRecordError();
                    }
                }
            }
            else if (sender.Equals(btnCancel))
            {
                Close();
            }
        }

        private void FrmJunction_Load(object sender, EventArgs e)
        {
            List<Device> devices = DBAccess.GetDevices();
            for (int j = 0; j < devices.Count; j++)
            {
                cbbxDeviceName.Items.Add(devices[j].Name);
                cbbxDeviceName.Items[cbbxDeviceName.Items.Count - 1].Font = new Font(cbbxDeviceName.Font.FontFamily, (float)9.75);
            }

            Junc = DesignerAccess.GetJunction(MarkerInfo.MarkerName);
            if (Junc != null)
            {
                txtJunctionName.Text = Junc.JunctionName;
                cbbxDeviceName.Text = Junc.DeviceName;
                cbbxTag.Text = Junc.Tag;
                txtExpression.Text = Junc.Expression;

                List<IOTag> ioTags = DBAccess.GetIOTags(cbbxDeviceName.Text);
                for (int j = 0; j < ioTags.Count; j++)
                {
                    cbbxTag.Items.Add(ioTags[j].Name);
                    cbbxTag.Items[j].Font = new Font(cbbxTag.Font.FontFamily, (float)9.75);
                }
            }
        }

        private void cbbxName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            string deviceName = cbbxDeviceName.Text.Trim();
            cbbxTag.Items.Clear();

            List<IOTag> ioTags = DBAccess.GetIOTags(deviceName);
            for (int j = 0; j < ioTags.Count; j++)
            {
                cbbxTag.Items.Add(ioTags[j].Name);
                cbbxTag.Items[j].Font = new Font(cbbxTag.Font.FontFamily, (float)9.75);
            }
        }
    }
}

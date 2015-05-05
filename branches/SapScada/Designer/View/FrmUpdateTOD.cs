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

namespace Designer.View
{
    public partial class FrmUpdateTOD : Telerik.WinControls.UI.RadForm
    {
        public int Hour = 0, Minute = 0, DiagramID = 0, Offset = 0, ID = 0;
        public string ControlType = "", Pulses = "";
        public bool IsSusscess = false, IsActive = false;
        public int ScenarioID = 0;
        public Junction Junc;

        public FrmUpdateTOD()
        {
            InitializeComponent();
        }

        private void FrmUpdateTOD_Load(object sender, EventArgs e)
        {
            spinHour.Value = Hour;
            spinMinute.Value = Minute;
            spinDiagramID.Value = DiagramID;
            spinOffset.Value = Offset;
            txtPulses.Text = Pulses;
            chkActive.Checked = IsActive;

            int index = cbbxControlType.Items.IndexOf(ControlType);
            if (index > -1)
            {
                cbbxControlType.SelectedIndex = index;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnUpdate))
            {
                Hour = Common.Utility.ConvertHex2BCD((int)spinHour.Value);
                Minute =  Common.Utility.ConvertHex2BCD((int)spinMinute.Value);
                IsActive = chkActive.Checked;
                int controlType = cbbxControlType.SelectedIndex > -1 ? cbbxControlType.SelectedIndex : 0;
                ControlType = cbbxControlType.Text;
                Pulses = txtPulses.Text.Trim();
                Offset = (int)spinOffset.Value;
                DiagramID = (int)spinDiagramID.Value;

                if (IsActive == false) controlType = 0xFF;

                List<byte> data = new List<byte>();
                data.Add((byte)ScenarioID);
                data.Add((byte)ID);
                data.Add((byte)Hour);
                data.Add((byte)Minute);
                data.Add((byte)(controlType));

                if ((controlType == 0) || (controlType == 1)) // che do xnh-vang-do hoac lan song xanh
                {
                    data.Add((byte)DiagramID);
                    byte[] pulses = GetPulses(Pulses, Offset);
                    if (pulses != null)
                    {
                        data.AddRange(pulses);
                        IsSusscess = true;
                    }
                    else
                    {
                        IsSusscess = false;
                    }
                }
                else
                {
                    IsSusscess = true;
                }

                if ((IsSusscess == true))
                {
                    string tagName = string.Format("{0}.ChangeTODConfig", Junc.DeviceName);
                    string tagAddress = Program.GetDisplayTagAddress(tagName);
                    Program.SetIOTag(tagName, tagAddress, new object[] { data.ToArray() });
                    Close();
                }
                else
                {
                    MessageHandler.NetworkError();
                }

            }
            else if (sender.Equals(btnCancel))
            {
                Close();
            }
        }

        private byte[] GetPulses(string pulse, int offset)
        {
            char[] separator = new char[] { ',', '-', ';', ' ' };
            string[] strPulses = pulse.Split(separator);

            if (strPulses.Length > 8)
            {
                //   MessageHandler.Inform("Số xung không được lớn hơn 8");
                return null;
            }

            ushort[] pulses = new ushort[strPulses.Length];
            for (int i = 0; i < strPulses.Length; i++)
            {
                if (!ushort.TryParse(strPulses[i], out pulses[i]))
                {
                    //  MessageHandler.Inform("Chuỗi xung phải mang giá trị số! Nhập lại chuỗi xung!");
                    return null;
                }
            }

            byte[] bytePulses = new byte[pulses.Length * 2 + 3];

            bytePulses[0] = (byte)(pulses.Length);
            bytePulses[1] = (byte)(offset);
            bytePulses[2] = (byte)(offset >> 8);

            for (int i = 0, j = 3; i < pulses.Length; i++)
            {
                bytePulses[j++] = (byte)pulses[i];
                bytePulses[j++] = (byte)(pulses[i] >> 8);
            }
            return bytePulses;
        }


    }
}

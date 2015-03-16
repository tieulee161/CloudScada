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
    public partial class FrmDisplayTagSetting : Telerik.WinControls.UI.RadForm
    {
        public bool IsSuccessful { get; set; }
        public int LampId { get; set; }
        public string JunctionName { get; set; }

        public FrmDisplayTagSetting()
        {
            InitializeComponent();
        }

        private void ThreeColorLampSetting_Load(object sender, EventArgs e)
        {
            IsSuccessful = false;
            foreach (IOTag tag in DBAccess.GetIOTags(JunctionName))
            {
                cbbxTag.Items.Add(tag.Name);
                cbbxTag.Items[cbbxTag.Items.Count - 1].Font = new Font(cbbxTag.Font.FontFamily, (float)9.75);
            }
            Lamp lamp = DesignerAccess.GetLamp(LampId);
            if (lamp != null)
            {
                cbbxTag.Text = lamp.Tag;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tagName = cbbxTag.Text;
            IsSuccessful = false;
            Lamp lamp = DesignerAccess.GetLamp(LampId);
            if (lamp != null)
            {
                lamp.Tag = tagName;
                if (!DesignerAccess.UpdateLamp(lamp.ID, lamp))
                {
                    MessageHandler.UpdateRecordError();
                }
                else
                {
                    IsSuccessful = true;
                    Close();
                }
            }
            else
            {
                MessageHandler.UpdateRecordError();
            }

        }


    }
}

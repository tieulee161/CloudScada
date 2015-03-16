using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Designer.Model;
using Designer.Core;
using Common;

namespace Designer.View
{
    public partial class FrmTrend1 : Telerik.WinControls.UI.RadForm
    {
        private List<string> _Lines;

        public FrmTrend1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnAdd))
            {
                if (cbbxLines.SelectedItem != null)
                {
                    string lineName = cbbxLines.SelectedItem.Text;
                    if (!_Lines.Contains(lineName))
                    {
                        lstLines.Items.Add(lineName);
                        _Lines.Add(lineName);
                    }
                }
            }
            else if (sender.Equals(btnDelete))
            {
                if (lstLines.SelectedItems.Count > 0)
                {
                    for (int j = 0; j < lstLines.SelectedItems.Count; j++)
                    {
                        string lineName = lstLines.SelectedItems[j].Text;
                        lstLines.Items.Remove(lstLines.SelectedItems[j]);
                        _Lines.Remove(lineName);
                    }
                }
            }
            else if (sender.Equals(btnStart))
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnStop.Enabled = true;
                btnStart.Enabled = false;

                for (int j = 0; j < _Lines.Count; j++)
                {
                    graphTrend.AddNewLine(_Lines[j]);
                    IDisplayTag tag = new IDisplayTag();
                    tag.Name = _Lines[j];
                    tag.Address = _Lines[j];
                    tag.RaiseTagValueChangedEvent += tag_RaiseTagValueChangedEvent;
               //     Program.AddDisplayTag(tag);
                }
            }
            else if (sender.Equals(btnStop))
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnStop.Enabled = false;
                btnStart.Enabled = true;

                for (int j = 0; j < _Lines.Count; j++)
                {
                    graphTrend.RemoveLine(_Lines[j]);
                }
            }
          
        }

        private void tag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            IDisplayTag tag = sender as IDisplayTag;
            if ((tag != null) && (!this.IsDisposed))
            {
                graphTrend.UpdateTrend(tag.Address, tag.Value, DateTime.Now);
            }
            else if (this.IsDisposed)
            {
                tag.RaiseTagValueChangedEvent -= tag_RaiseTagValueChangedEvent;
            }
        }

        private void FrmTrend_Load(object sender, EventArgs e)
        {
            graphTrend.LoadGraph();

            List<string> lines = DBAccess.GetLineTags();
            for (int j = 0; j < lines.Count; j++)
            {
                cbbxLines.Items.Add(lines[j]);
                cbbxLines.Items[j].Font = new Font(cbbxLines.Font.FontFamily, (float)9.75);
            }

            _Lines = new List<string>();
        }
    }
}

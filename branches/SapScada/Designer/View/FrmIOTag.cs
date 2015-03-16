using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Designer.Model;
using Common;
using HDSComponent;

namespace Designer.View
{
    public partial class FrmIOTag : Telerik.WinControls.UI.RadForm
    {
        public FrmIOTag()
        {
            InitializeComponent();
        }

        // update
        private void dtgServer_DoubleClick(object sender, EventArgs e)
        {
            if (dtgIOTag.SelectedRows.Count > 0)
            {
                FrmIOTagSetting f = new FrmIOTagSetting();
                f.FormType = FormType.Update;
                f.OldIOTag = new IOTag();
                f.OldIOTag.Name = dtgIOTag.SelectedRows[0].Cells[0].Value.ToString();
                f.OldIOTag.Type = Utility.GetEnumInt(typeof(TagType), dtgIOTag.SelectedRows[0].Cells[1].Value.ToString());
                f.OldIOTag.DataType = Utility.GetEnumInt(typeof(DataType), dtgIOTag.SelectedRows[0].Cells[2].Value.ToString());
                f.OldIOTag.Address = dtgIOTag.SelectedRows[0].Cells[3].Value.ToString();
                f.OldIOTag.UpdateRating = int.Parse(dtgIOTag.SelectedRows[0].Cells[4].Value.ToString());
                f.OldIOTag.Device = new Device();
                f.OldIOTag.Device.Name = dtgIOTag.SelectedRows[0].Cells[5].Value.ToString();
                f.OldIOTag.IsStoreToLog = dtgIOTag.SelectedRows[0].Cells[6].Value != null ? (bool)dtgIOTag.SelectedRows[0].Cells[6].Value : false;
                f.OldIOTag.Note = (string)dtgIOTag.SelectedRows[0].Cells[7].Value;
                f.ShowDialog();
                if (f.Logic == Logic.Succcess)
                {
                    dtgIOTag.SelectedRows[0].Cells[0].Value = f.OldIOTag.Name;
                    dtgIOTag.SelectedRows[0].Cells[1].Value = Utility.GetEnumString((TagType)f.OldIOTag.Type);
                    dtgIOTag.SelectedRows[0].Cells[2].Value = Utility.GetEnumString((DataType)f.OldIOTag.DataType);
                    dtgIOTag.SelectedRows[0].Cells[3].Value = f.OldIOTag.Address;
                    dtgIOTag.SelectedRows[0].Cells[4].Value = f.OldIOTag.UpdateRating;
                    dtgIOTag.SelectedRows[0].Cells[5].Value = f.OldIOTag.Device.Name;
                    dtgIOTag.SelectedRows[0].Cells[6].Value = f.OldIOTag.IsStoreToLog;
                    dtgIOTag.SelectedRows[0].Cells[7].Value = f.OldIOTag.Note;
                }

            }
        }

        private void FrmServer_Load(object sender, EventArgs e)
        {
            PrepareContextMenu();
            List<IOTag> ioTags = DBAccess.GetIOTags();
            foreach (IOTag tag in ioTags)
            {
                dtgIOTag.Rows.Add(new object[] 
                { 
                    tag.Name, 
                    Utility.GetEnumString((TagType) tag.Type), 
                    Utility.GetEnumString((DataType)tag.DataType),
                    tag.Address,
                    tag.UpdateRating,
                    tag.Device.Name,
                    tag.IsStoreToLog,
                    tag.Note 
                });
            }
        }

        private void PrepareContextMenu()
        {
            contextAdd.Click += contextAdd_Click;
            contextDelete.Click += contextDelete_Click;
            contextCopy.Click += contextCopy_Click;
        }

        private void contextCopy_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < dtgIOTag.SelectedRows.Count; j++)
            {

            }
        }

        // delete
        private void contextDelete_Click(object sender, EventArgs e)
        {
            if (dtgIOTag.SelectedRows.Count > 0)
            {
                if (MessageHandler.AskForDeleteRecord())
                {
                    for (int j = dtgIOTag.SelectedRows.Count - 1; j >= 0; j--)
                    {
                        string ioTagName = dtgIOTag.SelectedRows[0].Cells[0].Value.ToString();
                        if (DBAccess.DeleteIOTag(ioTagName))
                        {
                            dtgIOTag.Rows.Remove(dtgIOTag.SelectedRows[0]);
                        }
                    }
                }
            }
        }

        // add
        private void contextAdd_Click(object sender, EventArgs e)
        {
            FrmIOTagSetting f = new FrmIOTagSetting();
            f.FormType = FormType.Add;
            f.ShowDialog();
            if (f.Logic == Logic.Succcess)
            {
                dtgIOTag.Rows.Add(new object[] 
                { 
                    f.OldIOTag.Name,
                    Utility.GetEnumString((TagType)f.OldIOTag.Type), 
                    Utility.GetEnumString((DataType)f.OldIOTag.DataType),
                    f.OldIOTag.Address,
                    f.OldIOTag.UpdateRating,
                    f.OldIOTag.Device.Name,
                    f.OldIOTag.Note 
                });
            }
        }

        private void dtgServer_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9.75);
        }
    }
}

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
    public partial class FrmServer : Telerik.WinControls.UI.RadForm
    {
        public FrmServer()
        {
            InitializeComponent();
        }

        // update
        private void dtgServer_DoubleClick(object sender, EventArgs e)
        {
            if (dtgServer.SelectedRows.Count > 0)
            {
                FrmServerSetting f = new FrmServerSetting();
                f.FormType = FormType.Update;
                f.OldServer = new Server();
                f.OldServer.Name = dtgServer.SelectedRows[0].Cells[0].Value.ToString();
                f.OldServer.IP = dtgServer.SelectedRows[0].Cells[1].Value.ToString();
                f.OldServer.Type = Utility.GetEnumInt(typeof(ServerType), dtgServer.SelectedRows[0].Cells[2].Value.ToString());
                f.OldServer.Priority = Utility.GetEnumInt(typeof(Priority), dtgServer.SelectedRows[0].Cells[3].Value.ToString());
                f.OldServer.Note = dtgServer.SelectedRows[0].Cells[4].Value.ToString();
                f.ShowDialog();
                if (f.Logic == Logic.Succcess)
                {
                    dtgServer.SelectedRows[0].Cells[0].Value = f.OldServer.Name;
                    dtgServer.SelectedRows[0].Cells[1].Value = f.OldServer.IP;
                    dtgServer.SelectedRows[0].Cells[2].Value = Utility.GetEnumString((ServerType)f.OldServer.Type);
                    dtgServer.SelectedRows[0].Cells[3].Value = Utility.GetEnumString((Priority)f.OldServer.Priority);
                    dtgServer.SelectedRows[0].Cells[4].Value = f.OldServer.Note;
                }

            }
        }

        private void FrmServer_Load(object sender, EventArgs e)
        {
            PrepareContextMenu();
            List<Server> servers = DBAccess.GetServers();
            foreach (Server serv in servers)
            {
                dtgServer.Rows.Add(new object[] 
                { 
                    serv.Name, 
                    serv.IP, 
                    Utility.GetEnumString((ServerType) serv.Type), 
                    Utility.GetEnumString((Priority)serv.Priority),
                    serv.Note 
                });
            }
        }

        private void PrepareContextMenu()
        {
            contextAdd.Click += contextAdd_Click;
            contextDelete.Click += contextDelete_Click;
        }

        // delete
        private void contextDelete_Click(object sender, EventArgs e)
        {
            if (dtgServer.SelectedRows.Count > 0)
            {
                string serverName = dtgServer.SelectedRows[0].Cells[0].Value.ToString();
                if (MessageHandler.AskForDeleteRecord())
                {
                    if (DBAccess.DeleteServer(serverName))
                    {
                        dtgServer.Rows.Remove(dtgServer.SelectedRows[0]);
                    }
                    else
                    {
                        MessageHandler.DeleteRecordError();
                    }
                }
            }
        }

        // add
        private void contextAdd_Click(object sender, EventArgs e)
        {
            FrmServerSetting f = new FrmServerSetting();
            f.FormType = FormType.Add;
            f.ShowDialog();
            if (f.Logic == Logic.Succcess)
            {
                dtgServer.Rows.Add(new object[] 
                { 
                    f.OldServer.Name,
                    f.OldServer.IP, 
                    Utility.GetEnumString((ServerType)f.OldServer.Type), 
                    Utility.GetEnumString((Priority)f.OldServer.Priority),
                    f.OldServer.Note 
                });
            }
        }

        private void dtgServer_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9.75);
        }
    }
}

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
using System.IO;
using System.Collections;
using Telerik.WinControls.UI;
using Common;

namespace Designer.View
{
    public partial class FrmVDKScenario : Telerik.WinControls.UI.RadForm
    {
        public string JunctionName { get; set; }
        private Display _Page { get; set; }
        private bool _FirstScan { get; set; }

        private Junction _Junc { get; set; }

        private int _CurrentDiagramId { get; set; }

        public FrmVDKScenario()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _Junc = DesignerAccess.GetJunction(JunctionName);
            JunctionName = _Junc.DeviceName;
            _FirstScan = true;

            this.Enter += FrmVDKScenario_Enter;
            dtgTOD.Click += dtgTOD_Click;
            dtgTOD.DoubleClick += dtgTOD_DoubleClick;
        }

        private void FrmVDKScenario_Enter(object sender, EventArgs e)
        {
            if(_FirstScan)
            {
                _FirstScan = false;
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += worker_DoWork;
                worker.RunWorkerAsync();
            }
            else
            {
                ((Form)(this.Tag)).Size = new Size(899, 613);
            }
          
           
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReadDataFromServerFile();
            InitDisplayTag();
        }

        private void InitDisplayTag()
        {
            _Page = new Display(1000);

            IDisplayTag scenarioIdTag = new IDisplayTag();
            scenarioIdTag.Name = string.Format("{0}.CurrentScenarioId", JunctionName);
            scenarioIdTag.Address = Program.GetDisplayTagAddress(scenarioIdTag.Name);
            scenarioIdTag.RaiseTagValueChangedEvent += ScenarioId_RaiseTagValueChangedEvent;

            IDisplayTag currentTODIdTag = new IDisplayTag();
            currentTODIdTag.Name = string.Format("{0}.CurrentTODId", JunctionName);
            currentTODIdTag.Address = Program.GetDisplayTagAddress(currentTODIdTag.Name);
            currentTODIdTag.RaiseTagValueChangedEvent += CurrentTODIdTag_RaiseTagValueChangedEvent;

            _Page.AddTag(scenarioIdTag);
            _Page.AddTag(currentTODIdTag);

            Program.AddDisplayForm(this, new List<Display>() { _Page });
        }

        private void ScenarioId_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            IDisplayTag tag = (IDisplayTag)sender;
            try
            {
                foreach (RadTreeNode node in treeScenario.Nodes)
                {
                    if (node.Value.ToString() == tag.Value.ToString())
                    {
                        node.Style.BackColor = Color.Lime;
                    }
                }
            }
            catch (Exception)
            { }
        }

        private void CurrentTODIdTag_RaiseTagValueChangedEvent(object sender, EventArgs e)
        {
            IDisplayTag tag = (IDisplayTag)sender;
            try
            {
                for (int j = 0; j < dtgTOD.Rows.Count; j++)
                {
                    int todId = (int)(decimal)dtgTOD.Rows[j].Cells["colID"].Value;
                    if (todId == (int)tag.Value)
                    {
                        for (int i = 0; i < dtgTOD.Columns.Count; i++)
                        {
                            dtgTOD.Rows[j].Cells[i].Style.CustomizeFill = true;
                            dtgTOD.Rows[j].Cells[i].Style.DrawFill = true;
                            dtgTOD.Rows[j].Cells[i].Style.BackColor = Color.Lime;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtgTOD.Columns.Count; i++)
                        {
                            dtgTOD.Rows[j].Cells[i].Style.CustomizeFill = true;
                            dtgTOD.Rows[j].Cells[i].Style.DrawFill = true;
                            dtgTOD.Rows[j].Cells[i].Style.BackColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_State == ReadingState.Start)
            {
                btnRefresh.Enabled = false;
                _Worker = new BackgroundWorker();
                _Worker.DoWork += _Worker_DoWork;
                _Worker.RunWorkerCompleted += _Worker_RunWorkerCompleted;
                _Worker.RunWorkerAsync();
            }
        }

        #region scenario tab
        // phần gridview đọc TOD theo trình tự sau:
        // 1. Đọc current scenario để lấy scenarioID
        // 2. Đọc file TODxx trong đó xx là current scenarioID
        // 3. Đọc current TOD, lây được diagramID
        // 4. Hiển thị tất cả các TOD của kịch bản đó đồng thời hightlight currentTOD

        // Phần vẽ diagram, làm tiếp các bước sau
        // 1. Đọc file DiagramXX, trong đó xx là diagramID được lấy khi đọc current TOD (mục 3 phần trên)
        // 2. Đọc file line, để biết kiểu đèn, thời gian vàng của đèn để vẽ
        // 3. Vẽ giản đồ, dùng user control là HDTrafficDiagram

        private BackgroundWorker _Worker;
        private ReadingState _State = ReadingState.Start;

        #region update file system from controller
        private enum ReadingState
        {
            Start = 0,
            ReadCurrentScenario = 1,
            ReadTODxxFile = 2,
            ReadCurrentTOD = 3,
            ReadDiagramxxFile = 4,
            ReadLineFile = 5,
            End = 6,
            ReadDateFile,
            ReadTODFile,
            ReadDiagramFile,
        }
        private Dictionary<int, List<IODriver.OperationDate>> _OperationDate = new Dictionary<int, List<IODriver.OperationDate>>(); // scenarioId is the key
        private Dictionary<int, List<IODriver.TODInfo>> _TODsOfScenario = new Dictionary<int, List<IODriver.TODInfo>>(); // scenarioId is the key
        private Dictionary<int, IODriver.DiagramInfo> _Diagrams = new Dictionary<int, IODriver.DiagramInfo>(); // diagramId is the key
        private Dictionary<int, IODriver.LineHardware> _Lines = new Dictionary<int, IODriver.LineHardware>();

        private void UpdateTabScenario()
        {
            // cap nhat cac file config theo trinh tu sau:
            // 1. Doc file date.cfg --> loc ra danh sach cac ScenarioId (mot scenarioId se chua nhieu loai ngay)
            // 2. Doc tat ca cac file TODxx.cfg, trong do xx la scenarioId --> loc ra danh sach cac diagramId
            // 3. Doc tat ca cac file diagramxx.cfg
            while (_State != ReadingState.End)
            {
                try
                {
                    switch (_State)
                    {
                        case ReadingState.Start:
                            string folderPath = Application.StartupPath + string.Format("\\{0}", JunctionName);
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }
                            _State = ReadingState.ReadDateFile;

                            break;
                        case ReadingState.ReadDateFile:
                            ReadDateFile();
                            _State = ReadingState.ReadTODFile;
                            break;
                        case ReadingState.ReadTODFile:
                            ReadTODFile();
                            _State = ReadingState.ReadDiagramFile;
                            break;
                        case ReadingState.ReadDiagramFile:
                            ReadDiagramFile();
                            _State = ReadingState.ReadLineFile;
                            break;
                        case ReadingState.ReadLineFile:
                            ReadLineFile();
                            _State = ReadingState.End;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    _State = ReadingState.End;
                }
            }
            _State = ReadingState.Start;
        }

        private void ReadDateFile()
        {
            object data = null;
            string tagName = string.Format("{0}.Eeprom.5", JunctionName);
            string tagAddress = Program.GetDisplayTagAddress(tagName);
            if (Program.GetIOTag(tagName, tagAddress, null, out data))
            {
                List<byte> rawData = (List<byte>)data;
                if (rawData != null)
                {
                    string path = string.Format(@"{0}\{1}\date.cfg", Application.StartupPath, JunctionName);
                    WriteDataToFile(path, rawData);
                    ParseDateFile();
                }
            }
        }

        private void ReadTODFile()
        {
            foreach (int scenarioId in _OperationDate.Keys)
            {
                object data = null;
                string tagName = string.Format("{0}.Eeprom.6", JunctionName);
                string tagAddress = Program.GetDisplayTagAddress(tagName);
                if (Program.GetIOTag(tagName, tagAddress, new List<int> { scenarioId }, out data))
                {
                    List<byte> rawData = (List<byte>)data;
                    if (rawData != null)
                    {
                        string path = string.Format(@"{0}\{1}\tod_{2}.cfg", Application.StartupPath, JunctionName, scenarioId.ToString("00"));
                        WriteDataToFile(path, rawData);
                    }
                }
            }
            ParseTODFile();
        }

        private void ReadDiagramFile()
        {
            foreach (int diagramId in _Diagrams.Keys)
            {
                object data = null;
                string tagName = string.Format("{0}.Eeprom.7", JunctionName);
                string tagAddress = Program.GetDisplayTagAddress(tagName);
                if (Program.GetIOTag(tagName, tagAddress, new List<int> { diagramId }, out data))
                {
                    List<byte> rawData = (List<byte>)data;
                    if (rawData != null)
                    {
                        string path = string.Format(@"{0}\{1}\diagram_{2}.cfg", Application.StartupPath, JunctionName, diagramId.ToString("00"));
                        WriteDataToFile(path, rawData);
                    }
                }
            }
            ParseDiagramFile();
        }

        private void ReadLineFile()
        {
            object data = null;
            string tagName = string.Format("{0}.Eeprom.4", JunctionName);
            string tagAddress = Program.GetDisplayTagAddress(tagName);
            if (Program.GetIOTag(tagName, tagAddress, null, out data))
            {
                List<byte> rawData = ((List<byte>)data);
                if (rawData != null)
                {
                    string path = string.Format(@"{0}\{1}\line.cfg", Application.StartupPath, JunctionName);
                    WriteDataToFile(path, rawData);
                }
                ParseLineFile();
            }

        }

        private void ParseDateFile()
        {
            string path = string.Format(@"{0}\{1}\date.cfg", Application.StartupPath, JunctionName);
            if (File.Exists(path))
            {
                List<byte> rawData = ReadDataFromFile(path);
                int count = rawData.Count / 6;
                int offset = 0;
                _OperationDate = new Dictionary<int, List<IODriver.OperationDate>>();
                for (int j = 0; j < count; j++)
                {
                    IODriver.OperationDateType type = (IODriver.OperationDateType)rawData[offset];
                    byte specialDay = rawData[offset + 1];
                    byte specialMonth = rawData[offset + 2];
                    byte scenarioId = rawData[offset + 3];
                    offset += 6;

                    if (!_OperationDate.ContainsKey((int)scenarioId))
                    {
                        _OperationDate.Add((int)scenarioId, new List<IODriver.OperationDate>());
                    }

                    IODriver.OperationDate temp = new IODriver.OperationDate();
                    temp.DateType = type;
                    temp.SpecialDay = Common.Utility.ConvertBCD2Hex(specialDay);
                    temp.SpecialMonth = Common.Utility.ConvertBCD2Hex(specialMonth);
                    temp.ScenarioId = scenarioId;
                    _OperationDate[scenarioId].Add(temp);
                }
            }
        }

        private void ParseTODFile()
        {
            _TODsOfScenario = new Dictionary<int, List<IODriver.TODInfo>>();
            foreach (int scenarioId in _OperationDate.Keys)
            {
                string path = string.Format(@"{0}\{1}\tod_{2}.cfg", Application.StartupPath, JunctionName, scenarioId.ToString("00"));
                if (File.Exists(path))
                {
                    List<byte> rawData = ReadDataFromFile(path);

                    if ((rawData != null) && (rawData.Count > 0))
                    {
                        int count = rawData[0];
                        int offset = 1;

                        for (int j = 0; j < count; j++)
                        {
                            IODriver.TODInfo tod = new IODriver.TODInfo();
                            tod.TODID = rawData[offset];
                            tod.Hour = Common.Utility.ConvertBCD2Hex(rawData[offset + 1]);
                            tod.Min = Common.Utility.ConvertBCD2Hex(rawData[offset + 2]);
                            tod.Type = (IODriver.TypeControl)rawData[offset + 3];

                            tod.DiagramID = rawData[offset + 6];
                            tod.NumberOfZone = rawData[offset + 7];
                            tod.Offset = rawData[offset + 8] + rawData[offset + 9] * 256;
                            for (int i = 0; i < 8; i++)
                            {
                                tod.Pulses.Add(rawData[offset + 10 + i * 2] + rawData[offset + 11 + i * 2] * 256);
                            }
                            offset += 28;

                            if (!_TODsOfScenario.ContainsKey(scenarioId))
                            {
                                _TODsOfScenario.Add((int)scenarioId, new List<IODriver.TODInfo>());
                            }

                            _TODsOfScenario[(int)scenarioId].Add(tod);

                            if (!_Diagrams.ContainsKey(tod.DiagramID))
                            {
                                _Diagrams.Add((int)tod.DiagramID, new IODriver.DiagramInfo());
                            }
                        }
                    }
                }
            }


        }

        private void ParseDiagramFile()
        {
            int[] keys = new int[_Diagrams.Keys.Count];
            _Diagrams.Keys.CopyTo(keys, 0);
            for (int k = 0; k < keys.Length; k++)
            {
                int diagramId = keys[k];
                string path = string.Format(@"{0}\{1}\diagram_{2}.cfg", Application.StartupPath, JunctionName, diagramId.ToString("00"));
                if (File.Exists(path))
                {
                    List<byte> rawData = ReadDataFromFile(path);
                    if ((rawData != null) && (rawData.Count > 0))
                    {
                        IODriver.DiagramInfo diagram = new IODriver.DiagramInfo();

                        diagram.NumberOfLine = rawData[0];
                        diagram.NumberOfZone = rawData[1];
                        diagram.Cycle = BitConverter.ToInt32(rawData.ToArray(), 2);

                        int offset = 8;
                        for (int j = 0; j < diagram.NumberOfLine; j++)
                        {
                            IODriver.LineInfo line = new IODriver.LineInfo();
                            line.LineID = rawData[offset];
                            line.GreenOn.Add(BitConverter.ToInt32(rawData.ToArray(), offset + 2));
                            line.GreenOff.Add(BitConverter.ToInt32(rawData.ToArray(), offset + 6));
                            offset += 10;
                            diagram.Lines.Add(line);
                        }

                        offset += 2;// checksum

                        for (int j = 0; j < diagram.NumberOfZone; j++)
                        {
                            diagram.StartZone.Add(BitConverter.ToInt32(rawData.ToArray(), offset));
                            diagram.EndZone.Add(BitConverter.ToInt32(rawData.ToArray(), offset + 4));
                            offset += 8;
                        }

                        _Diagrams[diagramId] = diagram;
                    }
                }
            }
        }

        private void ParseLineFile()
        {
            string path = string.Format(@"{0}\{1}\line.cfg", Application.StartupPath, JunctionName);
            if (File.Exists(path))
            {
                List<byte> rawData = ReadDataFromFile(path);
                if ((rawData != null) && (rawData.Count > 0))
                {
                    int numberOfline = rawData[0];
                    int offset = 1;
                    for (int j = 0; j < numberOfline; j++)
                    {
                        IODriver.LineHardware line = new IODriver.LineHardware();
                        line.LineID = rawData[offset];
                        line.Type = (IODriver.LightType)rawData[offset + 1];
                        line.CardID = rawData[offset + 2];
                        line.GreenLightPositionInPowerCard = rawData[offset + 3];
                        line.MonitorState = rawData[offset + 4];
                        line.LenthOfYellowTime = (int)BitConverter.ToInt16(rawData.ToArray(), offset + 6);
                        if (!_Lines.ContainsKey(line.LineID))
                        {
                            _Lines.Add(line.LineID, null);
                        }
                        _Lines[line.LineID] = line;
                        offset += 8;
                    }
                }
            }
        }

        private void WriteDataToFile(string path, List<byte> data)
        {
            StreamWriter sw = new StreamWriter(path, false);
            for (int j = 0; j < data.Count; j++)
            {
                sw.Write((char)data[j]);
            }
            sw.Close();
        }

        private List<byte> ReadDataFromFile(string path)
        {
            List<byte> res = new List<byte>();
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    res.Add((byte)sr.Read());
                }

            }
            return res;
        }

        private void _Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRefresh.Enabled = true;
            ReadDataFromServerFile();
        }

        private void _Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateTabScenario();
        }
        #endregion

        #region read data from server's files and display to UI
        private void ReadDataFromServerFile()
        {
            string folder = string.Format(@"{0}\{1}\", Application.StartupPath, JunctionName);
            string dateFile = string.Format(@"{0}\{1}\date.cfg", Application.StartupPath, JunctionName);
            if (File.Exists(dateFile))
            {
                ParseDateFile();
                ParseTODFile();
                ParseDiagramFile();
                ParseLineFile();

                // display to UI
                treeScenario.Nodes.Clear();
                foreach (int scenarioId in _OperationDate.Keys)
                {
                    RadTreeNode node = new RadTreeNode();
                    node.Text = string.Format("{0}", scenarioId);
                    node.Value = scenarioId;
                    node.Image = Properties.Resources.List;
                    treeScenario.Nodes.Add(node);
                }
             //   treeScenario.TreeViewElement.TreeNodeProvider.Reset();

                treeScenario.SelectedNodeChanged += treeScenario_SelectedNodeChanged;
             
            }
        }
        private void treeScenario_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if (treeScenario.SelectedNode != null)
            {

                treeDateType.Nodes.Clear();
                treeDateType.Nodes.Add("Ngày bình thường");
                treeDateType.Nodes.Add("Thứ đặc biệt");
                treeDateType.Nodes.Add("Ngày đặc biệt");
                int scenarioId = 0;
                if (int.TryParse(treeScenario.SelectedNode.Text, out scenarioId))
                {
                    #region date type
                    if (_OperationDate.ContainsKey(scenarioId))
                    {
                        List<IODriver.OperationDate> operationDates = _OperationDate[scenarioId];
                        for (int j = 0; j < operationDates.Count; j++)
                        {
                            RadTreeNode node = new RadTreeNode();
                            switch (operationDates[j].DateType)
                            {
                                case IODriver.OperationDateType.NormalDate:
                                    node.Text = "Ngày thường";
                                    treeDateType.Nodes[0].Nodes.Add(node);

                                    break;
                                case IODriver.OperationDateType.SpecialDOW:
                                    if (operationDates[j].SpecialDay == 1)
                                    {
                                        node.Text = "Chủ nhật";
                                    }
                                    else
                                    {
                                        node.Text = string.Format("Thứ {0}", operationDates[j].SpecialDay);
                                    }
                                    treeDateType.Nodes[1].Nodes.Add(node);
                                    break;
                                case IODriver.OperationDateType.SpecialDOM:
                                    node.Text = string.Format("{0}-{1}", operationDates[j].SpecialDay, operationDates[j].SpecialMonth);
                                    treeDateType.Nodes[2].Nodes.Add(node);
                                    break;
                            }

                        }
                    }
                    #endregion

                    #region tods
                    dtgTOD.Rows.Clear();
                    if (_TODsOfScenario.ContainsKey(scenarioId))
                    {
                        int currentTODRow = -1;
                        List<IODriver.TODInfo> tods = _TODsOfScenario[scenarioId];
                        for (int j = 0; j < tods.Count; j++)
                        {
                            bool isUsed = true;
                            if (tods[j].Type == IODriver.TypeControl.Inactive) isUsed = false;
                            string pulses = "";
                            for (int i = 0; i < tods[j].NumberOfZone; i++)
                            {
                                pulses += tods[j].Pulses[i] + ",";
                            }
                            if (pulses.Length > 1)
                            {
                                pulses = pulses.Substring(0, pulses.Length - 1);
                            }

                            string controlType = "";
                            switch (tods[j].Type)
                            {
                                case IODriver.TypeControl.All_Red:
                                    controlType = "Tất cả đỏ";
                                    break;
                                case IODriver.TypeControl.Color:
                                    controlType = "Thông số";
                                    break;
                                case IODriver.TypeControl.Coordinate:
                                    controlType = "Làn sóng xanh";
                                    break;
                                case IODriver.TypeControl.Flash:
                                    controlType = "Chớp vàng";
                                    break;
                                case IODriver.TypeControl.Off:
                                    controlType = "Tắt tủ";
                                    break;
                            }

                            dtgTOD.Rows.Add(new object[] {
                                                isUsed,    
                                                tods[j].TODID, 
                                                string.Format("{0}:{1}", tods[j].Hour.ToString("00"),tods[j].Min.ToString("00")),
                                               controlType,
                                                tods[j].DiagramID,
                                                pulses,
                                                tods[j].Offset
                                            });
                            //if (_TODs[j].TODID == _CurrentTODID)
                            //{
                            //    currentTODRow = dtgTOD.Rows.Count - 1;
                            //    for (int i = 0; i < dtgTOD.Columns.Count; i++)
                            //    {
                            //        dtgTOD.Rows[currentTODRow].Cells[i].Style.CustomizeFill = true;
                            //        dtgTOD.Rows[currentTODRow].Cells[i].Style.DrawFill = true;
                            //        dtgTOD.Rows[currentTODRow].Cells[i].Style.BackColor = Color.Yellow;

                            //    }
                            //}
                        }
                        if (currentTODRow != -1)
                        {
                            dtgTOD.CurrentRow = dtgTOD.Rows[currentTODRow];
                        }
                    }
                    #endregion
                }
            }
        }

        private void dtgTOD_Click(object sender, EventArgs e)
        {
            if (dtgTOD.SelectedRows.Count > 0)
            {
                int diagramId = (int)(decimal)dtgTOD.SelectedRows[0].Cells["colDiagramID"].Value;
                if(diagramId != _CurrentDiagramId)
                {
                    if (_Diagrams.ContainsKey(diagramId))
                    {
                        _CurrentDiagramId = diagramId;
                        IODriver.DiagramInfo diagram = _Diagrams[diagramId];
                        DisplayDiagram(diagram);
                    }
                }
               
            }
        }

        private void DisplayDiagram(IODriver.DiagramInfo diagram)
        {
            if (diagram != null)
            {
                // clear diagram
                hdTrafficDiagram1.ClearGraph();

                //add diagram
                hdTrafficDiagram1.AddDiagram(diagram.DiagramID, "", diagram.Cycle);

                // add signal
                foreach (int id in _Lines.Keys)
                {
                    hdTrafficDiagram1.AddSignal(id, (int)_Lines[id].Type, _Lines[id].LenthOfYellowTime);
                }

                // add line
                for (int j = 0; j < diagram.Lines.Count; j++)
                {
                    hdTrafficDiagram1.AddSignalInfo(diagram.Lines[j].LineID, diagram.Lines[j].GreenOn, diagram.Lines[j].GreenOff);
                }

                // add zone

                hdTrafficDiagram1.AddZone(diagram.StartZone, diagram.EndZone);

                // draw diagram
                hdTrafficDiagram1.DrawDiagram();
            }


        }
        #endregion

        private void dtgTOD_DoubleClick(object sender, EventArgs e)
        {
          //  dtgTOD.DoubleClick -= dtgTOD_DoubleClick;
            if (dtgTOD.SelectedRows.Count > 0)
            {
                bool isActive = (bool)dtgTOD.SelectedRows[0].Cells["colActive"].Value;
                int id = (int)(decimal)dtgTOD.SelectedRows[0].Cells["colID"].Value;
                string time = (string)dtgTOD.SelectedRows[0].Cells["colTOD"].Value;
                int hour = 0, minute = 0;
                int.TryParse(time.Substring(0, 2), out hour);
                int.TryParse(time.Substring(3, 2), out minute);
                string controlType = (string)dtgTOD.SelectedRows[0].Cells["colControlType"].Value;
                int diagramID = (int)(decimal)dtgTOD.SelectedRows[0].Cells["colDiagramID"].Value;
                string pulses = (string)dtgTOD.SelectedRows[0].Cells["colPulses"].Value;
                int offset = (int)(decimal)dtgTOD.SelectedRows[0].Cells["colOffset"].Value;

                FrmUpdateTOD f = new FrmUpdateTOD();
                f.ID = id;
                f.Hour = hour;
                f.Minute = minute;
                f.ControlType = controlType;
                f.DiagramID = diagramID;
                f.Pulses = pulses;
                f.Offset = offset;
                f.IsActive = isActive;
                f.Junc = _Junc;
                f.ScenarioID = -1;
                foreach (RadTreeNode node in treeScenario.Nodes)
                {
                    if (node.Style.BackColor == Color.Lime)
                    {
                        f.ScenarioID = (int)node.Value;
                    }
                }

                f.ShowDialog();
                if (f.IsSusscess)
                {
                    dtgTOD.SelectedRows[0].Cells["colActive"].Value = f.IsActive;
                    dtgTOD.SelectedRows[0].Cells["colTOD"].Value = string.Format("{0}:{1}", Common.Utility.ConvertBCD2Hex(f.Hour).ToString("00"), Common.Utility.ConvertBCD2Hex(f.Minute).ToString("00"));
                    dtgTOD.SelectedRows[0].Cells["colControlType"].Value = f.ControlType;
                    dtgTOD.SelectedRows[0].Cells["colDiagramID"].Value = f.DiagramID;
                    dtgTOD.SelectedRows[0].Cells["colPulses"].Value = f.Pulses;
                    dtgTOD.SelectedRows[0].Cells["colOffset"].Value = f.Offset;
                }
            }
         //   dtgTOD.DoubleClick += dtgTOD_DoubleClick;
        }
        #endregion


        private void FrmVDKScenario_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        public void StopUpdating()
        {
            Program.RemoveDisplayForm(this);
        }

    }
}

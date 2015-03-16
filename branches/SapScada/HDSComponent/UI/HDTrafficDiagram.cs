using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace HDSComponent.UI
{
    public partial class HDTrafficDiagram : UserControl
    {
        public enum LineType { FullLine = 1, ThreeColor, Pedestrian, Single, DigitalLight };

        public class DiagramStoreData
        {
            public DiagramListStoreData Info;
            public List<VariableZone> ListZones;
            public List<LineData> ListLines;
        }

        public class DiagramListStoreData
        {
            internal int ID;
            internal int Cycle;
            internal string Name;
        }

        public class CompiledInfo
        {
            public struct Diagram
            {
                public int ID;
                public string Name;
            }

            public struct TimeOfDay
            {
                public int ID;
                public string Name;
            }

            public List<Diagram> CompiledDiagram;
            public List<TimeOfDay> CompiledTOD;

            public CompiledInfo()
            {
                CompiledDiagram = new List<Diagram>();
                CompiledTOD = new List<TimeOfDay>();
            }
        }

        public class SignalStoreData
        {
            public int ID;
            public int SignalGroupID;
            public byte LightPosition;

            public string LineName;
            public LineType Type;

            public int MinGreen;
            public int MinRed;
            public int YellowTime;
            public int FlashGreenTime;

            public bool MainLine;

            public bool GreenMonitor;
            public bool YellowMonitor;
            public bool RedMonitor;
            public bool CredMonitor;
        }

        public class SafeMatrixElement
        {
            internal struct ConflictData
            {
                internal int ID;
                internal int Time;
            }

            internal int ID;
            internal List<ConflictData> ListConflicts = new List<ConflictData>();
        }

        public class VariableZone
        {
            public enum MousePosition { None = 0, Green, LeftEdge, RightEdge };

            public int ID;
            public Rectangle Rect;

            public int LeftX;

            public int RightX;

            private bool isDrawing;

            private bool isSelected;

            private bool movingDirection;   //True: Left; false: right

            public bool MovingDirection
            {
                get { return movingDirection; }
                set { movingDirection = value; }
            }

            public bool IsDrawing
            {
                get { return isDrawing; }
                set { isDrawing = value; }
            }

            public bool IsSelected
            {
                get { return isSelected; }
                set { isSelected = value; }
            }

            public MousePosition CheckPoint(Point pt)
            {
                if (Rect.Contains(pt))
                {
                    if (isSelected)     //Already chosen
                    {
                        Rectangle rectLeft = new Rectangle();
                        Rectangle rectRight = new Rectangle();

                        rectLeft.Y = rectRight.Y = Rect.Y;
                        rectLeft.Width = rectRight.Width = 10;
                        rectLeft.Height = rectRight.Height = Rect.Height;
                        rectLeft.X = Rect.X;
                        rectRight.X = Rect.Right - 10;

                        if (rectLeft.Contains(pt))
                            return MousePosition.LeftEdge;

                        if (rectRight.Contains(pt))
                            return MousePosition.RightEdge;
                    }

                    return MousePosition.Green;       //in green range
                }
                else
                    return MousePosition.None;       //out of range
            }
        }

        public class LineData
        {
            public enum MousePosition { None = 0, Green, LeftSide, RightSide, Red };

            public int ID;
            public List<GreenRectangle> RectList = new List<GreenRectangle>();
            public int Index;
            public int Y;

            public GreenRectangle SelectedRect;

            public SignalStoreData SignalGroup;

            public SafeMatrixElement ConflictData;

            public MousePosition CheckPoint(Point pt, int width)
            {
                foreach (GreenRectangle greenRect in RectList)
                {
                    MousePosition result = greenRect.CheckPoint(pt);
                    if (result != MousePosition.None)
                        return result;
                }

                Rectangle redRect = new Rectangle();

                redRect.Y = Y - 5;
                redRect.X = 0;
                redRect.Height = 10;
                redRect.Width = width;

                if (redRect.Contains(pt))
                    return LineData.MousePosition.Red;

                return MousePosition.None;
            }
        }

        public class GreenRectangle
        {
            public Rectangle LeftRect;
            public Rectangle RightRect;

            public int Start;
            public int End;

            public bool IsTwoSides;

            public bool IsSelected;

            public bool IsDrawing;

            public bool IsLeftSide;

            public LineData.MousePosition CheckPoint(Point pt)
            {
                if (LeftRect.Contains(pt) || RightRect.Contains(pt))
                {
                    if (IsSelected)     //Already chosen
                    {
                        Rectangle rect = new Rectangle();
                        rect.Y = LeftRect.Y;
                        rect.Width = 10;
                        rect.Height = LeftRect.Height;

                        if (IsTwoSides)
                        {
                            if (LeftRect.Contains(pt))
                            {
                                rect.X = LeftRect.Right - 10;
                                if (rect.Contains(pt))
                                    return LineData.MousePosition.LeftSide;
                            }

                            if (RightRect.Contains(pt))
                            {
                                rect.X = RightRect.X;
                                if (rect.Contains(pt))
                                    return LineData.MousePosition.RightSide;
                            }
                        }
                        else
                        {
                            rect.X = LeftRect.X;
                            if (rect.Contains(pt))
                                return LineData.MousePosition.LeftSide;

                            rect.X = LeftRect.Right - 10;
                            if (rect.Contains(pt))
                                return LineData.MousePosition.RightSide;
                        }
                    }

                    return LineData.MousePosition.Green;       //in green range
                }

                return LineData.MousePosition.None;
            }
        }

        public class Diagram
        {
            public enum LightInGroup { CRED = 0, RED, YELLOW, GREEN };

            public struct HardLineData
            {
                public byte ID;
                public byte Type;
                public byte Card;
                public byte Green;
                public byte MonitorBits;     //bit7: Is main line; 4LSB: Monitor bit - bit0: green monitor, bit1: yellow, bit2: red, bit3: cred;

                public byte rsvd;
                public UInt16 YFTime;
            }

            public struct SoftLineData
            {
                public byte ID;
                public byte rsvd;
                public UInt32 Start;
                public UInt32 End;
            }

            public struct ZoneData
            {
                public UInt32 Start;
                public UInt32 End;
            }

            public void WriteHardLineToFile(List<SignalStoreData> lines)
            {
                List<HardLineData> listHardLines = new List<HardLineData>();
                HardLineData hardLineData = new HardLineData();

                int monitorGreen = 0;
                int monitorYellow = 0;
                int monitorRed = 0;
                int monitorCred = 0;
                int mainLine = 0;

                for (int i = 0; i < lines.Count; i++)
                {
                    hardLineData.ID = (byte)lines[i].ID;
                    hardLineData.Type = (byte)lines[i].Type;
                    hardLineData.Card = (byte)(lines[i].SignalGroupID / 2);

                    monitorGreen = lines[i].GreenMonitor ? 0x01 : 0;
                    monitorYellow = lines[i].YellowMonitor ? 0x02 : 0;
                    monitorRed = lines[i].RedMonitor ? 0x04 : 0;
                    monitorCred = lines[i].CredMonitor ? 0x08 : 0;
                    mainLine = lines[i].MainLine ? 0x80 : 0;

                    hardLineData.MonitorBits = (byte)(mainLine | monitorGreen | monitorYellow | monitorRed | monitorCred);

                    switch (lines[i].Type)
                    {
                        case LineType.ThreeColor:
                            hardLineData.Green = (byte)((lines[i].SignalGroupID % 2) * 4);
                            hardLineData.YFTime = (ushort)(lines[i].YellowTime);
                            break;

                        case LineType.Pedestrian:
                            hardLineData.Green = (byte)((lines[i].SignalGroupID % 2) * 4 + lines[i].LightPosition);
                            hardLineData.YFTime = (ushort)(lines[i].FlashGreenTime);
                            break;

                        case LineType.Single:
                            hardLineData.Green = (byte)((lines[i].SignalGroupID % 2) * 4 + lines[i].LightPosition);
                            hardLineData.YFTime = 0;
                            break;

                        case LineType.DigitalLight:
                            hardLineData.Green = (byte)((lines[i].SignalGroupID % 2) * 4 + lines[i].LightPosition);
                            hardLineData.YFTime = 0;
                            break;
                    }

                    listHardLines.Add(hardLineData);
                }

                string filename = "";//Path.Combine(CommonInfo.DownloadFolder, "line.cfg");
                FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);

                fileStream.WriteByte((byte)(listHardLines.Count));

                ushort crc = 0;

                for (int i = 0; i < listHardLines.Count; i++)
                {
                    //   byte[] arrayData = StructConverter.StructureToByteArray<HardLineData>(listHardLines[i]);
                    //       fileStream.Write(arrayData, 0, Marshal.SizeOf(typeof(HardLineData)));

                    //         crc = CrcShiftRegister.CrcByteArray(arrayData, Marshal.SizeOf(typeof(HardLineData)), crc, false);
                }

                //     crc = CrcShiftRegister.CrcByte(0, crc);

                fileStream.WriteByte((byte)(crc & 0xFF));
                fileStream.WriteByte((byte)(crc >> 8));

                fileStream.Close();

                //xoa tat ca cac file diagramx.cfg, cac file TODxx.cfg, date.cfg
                string[] files = new string[10];//Directory.GetFiles(CommonInfo.DownloadFolder, "diagram*.cfg");
                if (files.Length > 0)
                {
                    foreach (string file in files)
                        File.Delete(file);
                }

                // files = Directory.GetFiles(CommonInfo.DownloadFolder, "TOD*.cfg");
                if (files.Length > 0)
                {
                    foreach (string file in files)
                        File.Delete(file);
                }

                string fileName = "";// Path.Combine(CommonInfo.DownloadFolder, "date.cfg");
                if (File.Exists(fileName))
                    File.Delete(fileName);

                //     fileName = Path.Combine(CommonInfo.DataFolder, CommonInfo.fnCompile);
                if (File.Exists(fileName))
                {
                    //CompiledInfo CompiledData = SerializeFormatter.BinDeserialize<CompiledInfo>(fileName);
                    //CompiledData.CompiledDiagram.Clear();
                    //CompiledData.CompiledTOD.Clear();

                    //SerializeFormatter.BinSerialize(fileName, CompiledData);
                }
            }

            private int CompareZone(ZoneData x, ZoneData y)
            {
                if (x.Start > y.Start)
                {
                    return 1;
                }
                else if (x.Start < y.Start)
                {
                    return -1;
                }
                return 0;
            }

            public void WriteDiagramToFile(int diagramID, int cycle, List<LineData> lines, List<VariableZone> zones)
            {
                List<SoftLineData> listSoftLines = new List<SoftLineData>();
                List<ZoneData> listZones = new List<ZoneData>();

                SoftLineData softLineData = new SoftLineData();
                ZoneData zoneData = new ZoneData();

                foreach (LineData line in lines)
                {
                    if (line.SignalGroup.Type == LineType.DigitalLight)
                    {
                        softLineData.ID = (byte)line.ID;
                        softLineData.rsvd = 0;

                        softLineData.Start = 0;
                        softLineData.End = 0;

                        listSoftLines.Add(softLineData);
                    }
                    else
                    {
                        foreach (GreenRectangle rect in line.RectList)
                        {
                            softLineData.ID = (byte)line.ID;
                            softLineData.rsvd = 0;

                            softLineData.Start = (UInt32)(rect.Start);
                            softLineData.End = (UInt32)(rect.End);

                            listSoftLines.Add(softLineData);
                        }
                    }
                }

                foreach (VariableZone zone in zones)
                {
                    zoneData.Start = (UInt32)(zone.LeftX);
                    zoneData.End = (UInt32)(zone.RightX);

                    listZones.Add(zoneData);
                }
                listZones.Sort(CompareZone);

                string filename = "";
                //if (diagramID > 9)
                //    filename = Path.Combine(CommonInfo.DownloadFolder, "diagram" + diagramID.ToString() + ".cfg");
                //else
                //    filename = Path.Combine(CommonInfo.DownloadFolder, "diagram0" + diagramID.ToString() + ".cfg");

                FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);

                fileStream.WriteByte((byte)listSoftLines.Count);
                fileStream.WriteByte((byte)listZones.Count);

                fileStream.WriteByte((byte)(cycle & 0xFF));
                fileStream.WriteByte((byte)((cycle >> 8) & 0xFF));
                fileStream.WriteByte((byte)((cycle >> 16) & 0xFF));
                fileStream.WriteByte((byte)((cycle >> 24) & 0xFF));

                ushort crc = 0;
                //crc = CrcShiftRegister.CrcByte((byte)listSoftLines.Count, 0);
                //crc = CrcShiftRegister.CrcByte((byte)listZones.Count, crc);

                //crc = CrcShiftRegister.CrcByte((byte)(cycle & 0xFF), crc);
                //crc = CrcShiftRegister.CrcByte((byte)((cycle >> 8) & 0xFF), crc);
                //crc = CrcShiftRegister.CrcByte((byte)((cycle >> 16) & 0xFF), crc);
                //crc = CrcShiftRegister.CrcByte((byte)((cycle >> 24) & 0xFF), crc);
                //crc = CrcShiftRegister.CrcByte(0, crc);

                fileStream.WriteByte((byte)(crc & 0xFF));
                fileStream.WriteByte((byte)(crc >> 8));

                crc = 0;
                //for (int i = 0; i < listSoftLines.Count; i++)
                //{
                //    byte[] arrayPhase = StructConverter.StructureToByteArray<SoftLineData>(listSoftLines[i]);
                //    fileStream.Write(arrayPhase, 0, Marshal.SizeOf(typeof(SoftLineData)));

                //    crc = CrcShiftRegister.CrcByteArray(arrayPhase, Marshal.SizeOf(typeof(SoftLineData)), crc, false);
                //}
                //crc = CrcShiftRegister.CrcByte(0, crc);

                fileStream.WriteByte((byte)(crc & 0xFF));
                fileStream.WriteByte((byte)(crc >> 8));

                crc = 0;
                //for (int i = 0; i < listZones.Count; i++)
                //{
                //    byte[] arrayLine = StructConverter.StructureToByteArray<ZoneData>(listZones[i]);
                //    fileStream.Write(arrayLine, 0, Marshal.SizeOf(typeof(ZoneData)));

                //    crc = CrcShiftRegister.CrcByteArray(arrayLine, Marshal.SizeOf(typeof(ZoneData)), crc, false);
                //}
                //crc = CrcShiftRegister.CrcByte(0, crc);

                fileStream.WriteByte((byte)(crc & 0xFF));
                fileStream.WriteByte((byte)(crc >> 8));

                fileStream.Close();
            }
        }

        public class DrawingDiagram
        {
            public LineData SelectedLine;
            public VariableZone SelectedZone;

            public DiagramListStoreData SelectedDiagram;
            public CompiledInfo CompiledData;

            public Form frmOwner;
            public PictureBox pbxDiagram;
            public Panel panelDiagram;

            int cycleDuration;

            int Width, Height;
            int KeepPoint;

            List<LineData> listLines;
            List<VariableZone> listZones;

            Bitmap bmpLine;
            Graphics grapLine;

            Bitmap bmpZone;
            Graphics grapZone;

            Bitmap bmpDiagram;
            Graphics grapDiagram;

            SolidBrush lineBrush;
            Pen linePen;

            HatchBrush zoneBrush;
            HatchBrush clearZoneBrush;
            Pen zonePen;

            Rectangle RestoredLeftRect;
            Rectangle RestoredRightRect;

            Rectangle RestoredZone;

            public int xResolution = 10;

            public DrawingDiagram()
            {
                listLines = new List<LineData>();
                listZones = new List<VariableZone>();

                linePen = new Pen(Color.Black, 1);
                lineBrush = new SolidBrush(Color.LawnGreen);

                zoneBrush = new HatchBrush(HatchStyle.DiagonalCross, Color.LightGray, Color.Transparent);
                clearZoneBrush = new HatchBrush(HatchStyle.DiagonalCross, Color.White, Color.Transparent);
                zonePen = new Pen(Color.Black, 1);

                RestoredLeftRect = new Rectangle();
            }

            public void InitDiagramGraphic(DiagramStoreData diagramData)
            {
                cycleDuration = SelectedDiagram.Cycle;

                int width = cycleDuration * xResolution;

                Width = cycleDuration * xResolution;
                Height = (listLines.Count + 2) * 20;

                bmpDiagram = new Bitmap(width, Height);
                grapDiagram = Graphics.FromImage(bmpDiagram);

                bmpLine = new Bitmap(width, Height);
                grapLine = Graphics.FromImage(bmpLine);

                bmpZone = new Bitmap(width, Height);
                grapZone = Graphics.FromImage(bmpZone);

                panelDiagram.AutoScroll = true;

                pbxDiagram.BackColor = Color.White;
                pbxDiagram.SizeMode = PictureBoxSizeMode.AutoSize;
                pbxDiagram.BorderStyle = BorderStyle.Fixed3D;
                pbxDiagram.Image = bmpDiagram;

                ////////////// Redraw from file \\\\\\\\\\\\\\
                //     string fileDiagram = "";// CommonInfo.DataFolder + "\\diagram" + SelectedDiagram.ID.ToString() + ".dat";
                //   if (File.Exists(fileDiagram))
                {
                    int i, j;
                    //  DiagramStoreData diagramData = new DiagramStoreData();//SerializeFormatter.BinDeserialize<DiagramStoreData>(fileDiagram);

                    for (i = 0; i < listLines.Count; i++)
                    {
                        for (j = 0; j < diagramData.ListLines.Count; j++)
                        {
                            if (listLines[i].ID == diagramData.ListLines[j].ID)
                            {
                                listLines[i].RectList = diagramData.ListLines[j].RectList;
                                foreach (GreenRectangle greenRect in listLines[i].RectList)
                                {
                                    greenRect.LeftRect.Y = greenRect.RightRect.Y = (listLines[i].Index + 1) * 20 - 5;
                                }
                                break;
                            }
                        }

                        listLines[i].Y = (listLines[i].Index + 1) * 20;
                    }

                    for (i = 0; i < diagramData.ListZones.Count; i++)
                    {
                        diagramData.ListZones[i].Rect.Height = Height;
                        listZones.Add(diagramData.ListZones[i]);
                    }

                    for (i = 0; i < listZones.Count; i++)
                    {
                        ConvertZoneCoordinate(listZones[i]);
                    }
                }
                //else
                //{
                //    for (int i = 0; i < listLines.Count; i++)
                //    {
                //        listLines[i].Y = (listLines[i].Index + 1) * 20;
                //    }
                //}

                RedrawAllLines();
                RedrawAllZones();
                DiagramRefresh();

                ///////////////// Add Label \\\\\\\\\\\\\\\\
                foreach (LineData line in listLines)
                {
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Name = "YLabel" + line.ID.ToString();
                    label.Text = "L" + line.SignalGroup.ID;
                    label.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
                    label.Location = new Point(pbxDiagram.Location.X - 40, pbxDiagram.Location.Y + line.Y - 5);

                    AddLabel(label);
                }

                for (int i = 0; i < cycleDuration + 10; i += 10)
                {
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Name = "XLabel" + i.ToString();
                    label.Text = i.ToString();
                    label.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
                    label.Location = new Point(i * xResolution + pbxDiagram.Location.X, pbxDiagram.Location.Y + pbxDiagram.Height);

                    AddLabel(label);
                }
            }

            private delegate void DlgAddLabel(Label lb);
            private void AddLabel(Label lb)
            {
                if (panelDiagram.InvokeRequired)
                {
                    DlgAddLabel dlg = new DlgAddLabel(AddLabel);
                    panelDiagram.Invoke(dlg, new object[] { lb });
                }
                else
                {
                    panelDiagram.Controls.Add(lb);
                }
            }

            public void AddLine(LineData line)
            {
                listLines.Add(line);
            }

            public void SaveData()
            {
                DiagramStoreData diagramData = new DiagramStoreData();

                diagramData.ListLines = listLines;
                diagramData.ListZones = listZones;

                string filename = "";// Path.Combine(CommonInfo.DataFolder, "diagram" + SelectedDiagram.ID.ToString() + ".dat");
                ///  SerializeFormatter.BinSerialize(filename, diagramData);
            }

            bool ValidateDiagram()
            {
                //Xác định các line đã được vẽ hết
                for (int i = 0; i < listLines.Count; i++)
                {
                    if (listLines[i].SignalGroup.Type != LineType.DigitalLight)
                    {
                        if (listLines[i].RectList.Count == 0)
                        {
                            MessageBox.Show("Chưa xác định thời gian xanh cho L" + listLines[i].ID.ToString());
                            return false;
                        }
                    }
                }

                return true;
            }

            private int CompareVZone(VariableZone x, VariableZone y)
            {
                if (x.LeftX > y.LeftX)
                    return 1;
                else if (x.LeftX < y.LeftX)
                    return -1;

                return 0;
            }

            public void Compile()
            {
                if (!ValidateDiagram())
                    return;

                int diagramID = SelectedDiagram.ID;
                string diagramName = SelectedDiagram.Name;

                listZones.Sort(CompareVZone);

                Diagram diagram = new Diagram();
                diagram.WriteDiagramToFile(diagramID, cycleDuration, listLines, listZones);

                CompiledInfo.Diagram compiledDiagram = new CompiledInfo.Diagram();
                compiledDiagram.ID = diagramID;
                compiledDiagram.Name = diagramName;

                if (!CompiledData.CompiledDiagram.Contains(compiledDiagram))
                {
                    CompiledData.CompiledDiagram.Add(compiledDiagram);
                }

                //Xoa nhung diagram chua duoc bien dich (hoac bi xoa file) nhung van co trong CompiledDiagram
                for (int i = 0; i < CompiledData.CompiledDiagram.Count; i++)
                {
                    string filename = "";

                    compiledDiagram = CompiledData.CompiledDiagram[i];

                    // if (compiledDiagram.ID > 9)
                    //   filename = CommonInfo.DownloadFolder + "\\diagram" + compiledDiagram.ID.ToString() + ".cfg";
                    //  else
                    //  filename = CommonInfo.DownloadFolder + "\\diagram0" + compiledDiagram.ID.ToString() + ".cfg";

                    if (!File.Exists(filename))
                    {
                        CompiledData.CompiledDiagram.Remove(compiledDiagram);
                    }
                }


            }

            public void ModifySelectedLine(int start, int end)
            {
                if (SelectedLine.SelectedRect != null)
                {
                    RestoredLeftRect = SelectedLine.SelectedRect.LeftRect;
                    RestoredRightRect = SelectedLine.SelectedRect.RightRect;

                    SelectedLine.SelectedRect.Start = start;
                    SelectedLine.SelectedRect.End = end;

                    if (start > end)
                    {
                        SelectedLine.SelectedRect.LeftRect.X = 0;
                        SelectedLine.SelectedRect.LeftRect.Width = end * xResolution;

                        SelectedLine.SelectedRect.RightRect.X = start * xResolution;
                        SelectedLine.SelectedRect.RightRect.Width = Width - start * xResolution;

                        SelectedLine.SelectedRect.IsTwoSides = true;
                    }
                    else
                    {
                        SelectedLine.SelectedRect.LeftRect.X = start * xResolution;
                        SelectedLine.SelectedRect.LeftRect.Width = (end - start) * xResolution;

                        SelectedLine.SelectedRect.RightRect.Width = 0;
                        SelectedLine.SelectedRect.IsTwoSides = false;
                    }

                    VerifySelectedLine();
                    ConvertLineCoordinate(SelectedLine);

                    RedrawAllLines();
                    DiagramRefresh();
                }
            }

            public void DeleteSelectedLine()
            {
                SelectedLine.RectList.Remove(SelectedLine.SelectedRect);
                SelectedLine.SelectedRect = null;

                RedrawAllLines();
                DiagramRefresh();
            }

            //////////////////// Line Mouse Events \\\\\\\\\\\\\\\\\\\\\
            #region Mouse Events for Line
            public void MouseDown(MouseEventArgs e)
            {
                Point ePoint = e.Location;

                if (SelectedLine != null)
                {
                    foreach (GreenRectangle rect in SelectedLine.RectList)
                    {
                        switch (rect.CheckPoint(ePoint))
                        {
                            case LineData.MousePosition.Green:
                                if (!rect.IsSelected)
                                {
                                    if (SelectedLine.SelectedRect != null)
                                    {
                                        SelectedLine.SelectedRect.IsSelected = false;
                                        RemoveBoldRectangle(SelectedLine);
                                    }

                                    SelectedLine.SelectedRect = rect;

                                    SelectedLine.SelectedRect.IsSelected = true;
                                    SelectedLine.SelectedRect.IsDrawing = false;

                                    linePen.Color = Color.Black;
                                    linePen.Width = 2;          //Bold the rectangle
                                    grapLine.DrawRectangle(linePen, SelectedLine.SelectedRect.LeftRect);
                                    grapLine.DrawRectangle(linePen, SelectedLine.SelectedRect.RightRect);

                                    DiagramRefresh();
                                }
                                return;

                            case LineData.MousePosition.LeftSide:
                                SelectedLine.SelectedRect.IsDrawing = true;
                                SelectedLine.SelectedRect.IsLeftSide = true;

                                if (SelectedLine.SelectedRect.IsTwoSides)
                                    KeepPoint = 0;
                                else
                                    KeepPoint = SelectedLine.SelectedRect.LeftRect.Right;

                                RestoredLeftRect = SelectedLine.SelectedRect.LeftRect;
                                RestoredRightRect = SelectedLine.SelectedRect.RightRect;
                                return;

                            case LineData.MousePosition.RightSide:
                                SelectedLine.SelectedRect.IsDrawing = true;
                                SelectedLine.SelectedRect.IsLeftSide = false;

                                if (SelectedLine.SelectedRect.IsTwoSides)
                                    KeepPoint = Width;
                                else
                                    KeepPoint = SelectedLine.SelectedRect.LeftRect.X;

                                RestoredLeftRect = SelectedLine.SelectedRect.LeftRect;
                                RestoredRightRect = SelectedLine.SelectedRect.RightRect;
                                return;
                        }
                    }
                }

                for (int i = 0; i < listLines.Count; i++)
                {
                    foreach (GreenRectangle rect in listLines[i].RectList)
                    {
                        if (rect.CheckPoint(ePoint) == LineData.MousePosition.Green)
                        {
                            if ((SelectedLine != null) && (SelectedLine.SelectedRect != null))
                            {
                                SelectedLine.SelectedRect.IsSelected = false;
                                RemoveBoldRectangle(SelectedLine);
                            }

                            SelectedLine = listLines[i];
                            SelectedLine.SelectedRect = rect;

                            SelectedLine.SelectedRect.IsSelected = true;
                            SelectedLine.SelectedRect.IsDrawing = false;

                            linePen.Color = Color.Black;
                            linePen.Width = 2;          //Bold the rectangle
                            grapLine.DrawRectangle(linePen, SelectedLine.SelectedRect.LeftRect);
                            grapLine.DrawRectangle(linePen, SelectedLine.SelectedRect.RightRect);

                            DiagramRefresh();
                            return;
                        }
                    }

                    Rectangle redRect = new Rectangle();
                    redRect.X = 0;
                    redRect.Y = listLines[i].Y - 5;
                    redRect.Width = Width;
                    redRect.Height = 10;

                    if (redRect.Contains(ePoint))
                    {
                        if ((SelectedLine != null) && (SelectedLine.SelectedRect != null))
                        {
                            SelectedLine.SelectedRect.IsSelected = false;
                            RemoveBoldRectangle(SelectedLine);
                        }

                        SelectedLine = listLines[i];

                        if (listLines[i].SignalGroup.Type != LineType.DigitalLight)
                        {
                            GreenRectangle greenRect = new GreenRectangle();

                            greenRect.IsTwoSides = false;
                            greenRect.IsSelected = true;
                            greenRect.IsDrawing = true;

                            greenRect.LeftRect.X = ePoint.X;
                            greenRect.LeftRect.Y = SelectedLine.Y - 5;
                            greenRect.LeftRect.Height = 10;
                            greenRect.LeftRect.Width = 0;

                            greenRect.RightRect = greenRect.LeftRect;

                            KeepPoint = ePoint.X;
                            RestoredLeftRect = greenRect.LeftRect;
                            RestoredRightRect = greenRect.RightRect;

                            SelectedLine.SelectedRect = greenRect;
                        }

                        DiagramRefresh();
                        return;
                    }
                }
            }

            public void MouseMove(MouseEventArgs e)
            {
                Point ePoint = e.Location;
                bool isInRect = false;

                if (e.Button == MouseButtons.None)
                {
                    for (int i = 0; i < listLines.Count; i++)
                    {
                        switch (listLines[i].CheckPoint(ePoint, Width))
                        {
                            case LineData.MousePosition.Green:
                                pbxDiagram.Cursor = Cursors.Hand;
                                isInRect = true;
                                break;

                            case LineData.MousePosition.LeftSide:
                            case LineData.MousePosition.RightSide:
                                pbxDiagram.Cursor = Cursors.SizeWE;
                                isInRect = true;
                                break;

                            case LineData.MousePosition.Red:
                                pbxDiagram.Cursor = Cursors.Arrow;
                                isInRect = true;
                                break;
                        }

                        if (isInRect)
                            break;
                    }
                }

                if (e.Button == MouseButtons.Left)
                {
                    if ((SelectedLine != null) && (SelectedLine.SelectedRect != null)
                                               && SelectedLine.SelectedRect.IsDrawing)
                    {
                        pbxDiagram.Cursor = Cursors.SizeWE;
                        ClearLineGraphic(SelectedLine);

                        if (ePoint.X < 0)
                        {
                            if (SelectedLine.SelectedRect.IsTwoSides)
                            {
                                SelectedLine.SelectedRect.LeftRect = SelectedLine.SelectedRect.RightRect;
                                SelectedLine.SelectedRect.RightRect.Width = 0;

                                SelectedLine.SelectedRect.IsTwoSides = false;
                                SelectedLine.SelectedRect.IsLeftSide = false;

                                KeepPoint = SelectedLine.SelectedRect.LeftRect.X;
                            }
                            else
                            {
                                SelectedLine.SelectedRect.LeftRect.X = 0;
                                SelectedLine.SelectedRect.LeftRect.Width = KeepPoint;

                                SelectedLine.SelectedRect.RightRect.X = Width;
                                SelectedLine.SelectedRect.RightRect.Width = 0;

                                SelectedLine.SelectedRect.IsTwoSides = true;
                                SelectedLine.SelectedRect.IsLeftSide = false;

                                KeepPoint = Width;
                            }

                            ePoint.X = Width;
                            Cursor.Position = new Point(frmOwner.Location.X + panelDiagram.Location.X + pbxDiagram.Location.X + Width - 10,
                                frmOwner.Location.Y + panelDiagram.Location.Y + pbxDiagram.Location.Y + 30 + SelectedLine.Y);
                        }
                        else if (ePoint.X > Width)
                        {
                            if (SelectedLine.SelectedRect.IsTwoSides)
                            {
                                SelectedLine.SelectedRect.RightRect.Width = 0;

                                SelectedLine.SelectedRect.IsTwoSides = false;
                                SelectedLine.SelectedRect.IsLeftSide = true;

                                KeepPoint = SelectedLine.SelectedRect.LeftRect.Right;
                            }
                            else
                            {
                                SelectedLine.SelectedRect.LeftRect.X = KeepPoint;
                                SelectedLine.SelectedRect.LeftRect.Width = Width - KeepPoint;
                                SelectedLine.SelectedRect.RightRect = SelectedLine.SelectedRect.LeftRect;

                                SelectedLine.SelectedRect.LeftRect.X = 0;
                                SelectedLine.SelectedRect.LeftRect.Width = 0;

                                SelectedLine.SelectedRect.IsTwoSides = true;
                                SelectedLine.SelectedRect.IsLeftSide = true;

                                KeepPoint = 0;
                            }

                            ePoint.X = 0;
                            Cursor.Position = new Point(frmOwner.Location.X + panelDiagram.Location.X + pbxDiagram.Location.X + 10,
                                frmOwner.Location.Y + panelDiagram.Location.Y + pbxDiagram.Location.Y + 30 + SelectedLine.Y);
                        }

                        if (SelectedLine.SelectedRect.IsTwoSides)
                        {
                            if (SelectedLine.SelectedRect.IsLeftSide)
                            {
                                SelectedLine.SelectedRect.LeftRect.Width = ePoint.X;
                            }
                            else
                            {
                                SelectedLine.SelectedRect.RightRect.X = ePoint.X;
                                SelectedLine.SelectedRect.RightRect.Width = KeepPoint - ePoint.X;
                            }
                        }
                        else
                        {
                            int delta = KeepPoint - ePoint.X;

                            if (delta > 0)
                            {
                                SelectedLine.SelectedRect.LeftRect.X = ePoint.X;
                                SelectedLine.SelectedRect.LeftRect.Width = delta;
                            }
                            else
                            {
                                SelectedLine.SelectedRect.LeftRect.X = KeepPoint;
                                SelectedLine.SelectedRect.LeftRect.Width = -delta;
                            }
                        }

                        if (SelectedLine.SelectedRect.LeftRect.Width < xResolution)
                            SelectedLine.SelectedRect.LeftRect.Width = xResolution;

                        ConvertLineCoordinate(SelectedLine);

                        linePen.Color = Color.Black;
                        linePen.Width = 1;
                        grapLine.DrawRectangle(linePen, SelectedLine.SelectedRect.LeftRect);
                        grapLine.DrawRectangle(linePen, SelectedLine.SelectedRect.RightRect);

                        DiagramRefresh();
                    }
                }
            }

            public void MouseUp(MouseEventArgs e)
            {
                if ((SelectedLine != null) && (SelectedLine.SelectedRect != null)
                                           && SelectedLine.SelectedRect.IsDrawing)
                {
                    if (SelectedLine.SelectedRect.LeftRect.Width == 0)
                    {
                        if (!SelectedLine.RectList.Contains(SelectedLine.SelectedRect))
                        {
                            SelectedLine.SelectedRect = null;
                            return;
                        }
                    }

                    SelectedLine.SelectedRect.IsDrawing = false;

                    VerifySelectedLine();
                    ConvertLineCoordinate(SelectedLine);

                    if (SelectedLine.SelectedRect.RightRect.Width > 0)
                        SelectedLine.SelectedRect.IsTwoSides = true;
                    else
                        SelectedLine.SelectedRect.IsTwoSides = false;

                    RedrawAllLines();
                    DiagramRefresh();
                }
            }

            #endregion
            public void ClearGraph()
            {
                if (grapDiagram != null)
                {
                    grapDiagram.Clear(Color.White);
                }
                if (listLines != null)
                {
                    listLines.Clear();
                }
                if (listZones != null)
                {
                    listZones.Clear();
                }

                if (panelDiagram != null)
                {
                    int count = panelDiagram.Controls.Count;
                    for (int j = count - 1; j >= 0; j--)
                    {
                        if (panelDiagram.Controls[j].GetType() == typeof(Label))
                        {
                            panelDiagram.Controls.RemoveAt(j);
                        }
                    }
                }
            }

            public void DiagramRefresh()
            {
                grapDiagram.Clear(Color.White);
                grapDiagram.DrawImage(bmpZone, 0, 0);
                grapDiagram.DrawImage(bmpLine, 0, 0);
                pbxDiagram.Invalidate();
            }

            bool CheckLineConflict(LineData line)
            {
                int iConflict, iLine;
                bool isConflict = false;

                for (iConflict = 0; iConflict < line.ConflictData.ListConflicts.Count; iConflict++)
                {
                    for (iLine = 0; iLine < listLines.Count; iLine++)
                    {
                        if (listLines[iLine].ID == line.ConflictData.ListConflicts[iConflict].ID)
                        {
                            foreach (GreenRectangle sourceRect in line.RectList)
                            {
                                foreach (GreenRectangle destRect in listLines[iLine].RectList)
                                {
                                    Rectangle leftSourceRect, rightSourceRect,
                                              leftDestRect, rightDestRect;

                                    leftSourceRect = sourceRect.LeftRect;
                                    rightSourceRect = sourceRect.RightRect;

                                    leftDestRect = destRect.LeftRect;
                                    rightDestRect = destRect.RightRect;

                                    leftDestRect.Y = leftSourceRect.Y;
                                    rightDestRect.Y = leftSourceRect.Y;

                                    switch (line.SignalGroup.Type)
                                    {
                                        case LineType.ThreeColor:
                                            leftSourceRect.Width += (line.SignalGroup.YellowTime +
                                                            line.ConflictData.ListConflicts[iConflict].Time) * xResolution;
                                            break;

                                        case LineType.Pedestrian:
                                            leftSourceRect.Width += (line.SignalGroup.FlashGreenTime +
                                                            line.ConflictData.ListConflicts[iConflict].Time) * xResolution;
                                            break;

                                        case LineType.Single:
                                            leftSourceRect.Width += line.ConflictData.ListConflicts[iConflict].Time * xResolution;
                                            break;
                                    }

                                    if (leftSourceRect.X + leftSourceRect.Width > Width)
                                    {
                                        Rectangle redundant = new Rectangle();
                                        redundant.X = 0;
                                        redundant.Height = 10;
                                        redundant.Y = leftSourceRect.Y;
                                        redundant.Width = (leftSourceRect.X + leftSourceRect.Width) - Width;

                                        if ((leftDestRect.Width > 0) && leftDestRect.IntersectsWith(redundant))
                                            isConflict = true;

                                        if ((rightDestRect.Width > 0) && rightDestRect.IntersectsWith(redundant))
                                            isConflict = true;

                                        leftSourceRect.Width = Width - leftSourceRect.X;
                                    }

                                    if (leftSourceRect.Width > 0)
                                    {
                                        if ((leftDestRect.Width > 0) && leftSourceRect.IntersectsWith(leftDestRect))
                                            isConflict = true;

                                        if ((rightDestRect.Width > 0) && leftSourceRect.IntersectsWith(rightDestRect))
                                            isConflict = true;
                                    }

                                    if (rightSourceRect.Width > 0)
                                    {
                                        if ((leftDestRect.Width > 0) && rightSourceRect.IntersectsWith(leftDestRect))
                                            isConflict = true;

                                        if ((rightDestRect.Width > 0) && rightSourceRect.IntersectsWith(rightDestRect))
                                            isConflict = true;
                                    }

                                    if (isConflict)
                                    {
                                        MessageBox.Show("L" + listLines[iLine].ID.ToString() + " và L" + line.ID.ToString() + " xung đột với nhau!");

                                        SelectedLine.SelectedRect.LeftRect = RestoredLeftRect;
                                        SelectedLine.SelectedRect.RightRect = RestoredRightRect;
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }

                return false;
            }

            bool CheckMinRed()
            {
                Rectangle srcLeftRect, srcRightRect, destLeftRect, destRightRect;
                bool isOverlapped = false;

                if (SelectedLine.RectList.Contains(SelectedLine.SelectedRect))
                {
                    for (int i = 0; i < SelectedLine.RectList.Count; i++)
                    {
                        for (int j = i + 1; j < SelectedLine.RectList.Count; j++)
                        {
                            srcLeftRect = SelectedLine.RectList[i].LeftRect;
                            srcRightRect = SelectedLine.RectList[i].RightRect;

                            destLeftRect = SelectedLine.RectList[j].LeftRect;
                            destRightRect = SelectedLine.RectList[j].RightRect;

                            switch (SelectedLine.SignalGroup.Type)
                            {
                                case LineType.ThreeColor:
                                    srcLeftRect.Width += (SelectedLine.SignalGroup.YellowTime + SelectedLine.SignalGroup.MinRed) * xResolution;
                                    destLeftRect.Width += (SelectedLine.SignalGroup.YellowTime + SelectedLine.SignalGroup.MinRed) * xResolution;
                                    break;

                                case LineType.Pedestrian:
                                    srcLeftRect.Width += (SelectedLine.SignalGroup.FlashGreenTime + SelectedLine.SignalGroup.MinRed) * xResolution;
                                    destLeftRect.Width += (SelectedLine.SignalGroup.FlashGreenTime + SelectedLine.SignalGroup.MinRed) * xResolution;
                                    break;

                                case LineType.Single:
                                    srcLeftRect.Width += SelectedLine.SignalGroup.MinRed * xResolution;
                                    destLeftRect.Width += SelectedLine.SignalGroup.MinRed * xResolution;
                                    break;
                            }

                            if (srcLeftRect.X + srcLeftRect.Width > Width)
                            {
                                Rectangle redundantRect = srcLeftRect;
                                redundantRect.X = 0;
                                redundantRect.Width = (srcLeftRect.X + srcLeftRect.Width) - Width;

                                if ((destLeftRect.Width > 0) && destLeftRect.IntersectsWith(redundantRect))
                                    isOverlapped = true;

                                if ((destRightRect.Width > 0) && destRightRect.IntersectsWith(redundantRect))
                                    isOverlapped = true;

                                srcLeftRect.Width = Width - srcLeftRect.X;
                            }

                            if (destLeftRect.X + destLeftRect.Width > Width)
                            {
                                Rectangle redundantRect = destLeftRect;
                                redundantRect.X = 0;
                                redundantRect.Width = (destLeftRect.X + destLeftRect.Width) - Width;

                                if ((srcLeftRect.Width > 0) && srcLeftRect.IntersectsWith(redundantRect))
                                    isOverlapped = true;

                                if ((srcRightRect.Width > 0) && srcRightRect.IntersectsWith(redundantRect))
                                    isOverlapped = true;

                                destLeftRect.Width = Width - destLeftRect.X;
                            }

                            if (srcLeftRect.Width > 0)
                            {
                                if ((destLeftRect.Width > 0) && srcLeftRect.IntersectsWith(destLeftRect))
                                    isOverlapped = true;

                                if ((destRightRect.Width > 0) && srcLeftRect.IntersectsWith(destRightRect))
                                    isOverlapped = true;
                            }

                            if (srcRightRect.Width > 0)
                            {
                                if ((destLeftRect.Width > 0) && srcRightRect.IntersectsWith(destLeftRect))
                                    isOverlapped = true;

                                if ((destRightRect.Width > 0) && srcRightRect.IntersectsWith(destRightRect))
                                    isOverlapped = true;
                            }

                            if (isOverlapped)
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    srcLeftRect = SelectedLine.SelectedRect.LeftRect;
                    srcRightRect = SelectedLine.SelectedRect.RightRect;

                    for (int j = 0; j < SelectedLine.RectList.Count; j++)
                    {
                        destLeftRect = SelectedLine.RectList[j].LeftRect;
                        destRightRect = SelectedLine.RectList[j].RightRect;

                        switch (SelectedLine.SignalGroup.Type)
                        {
                            case LineType.ThreeColor:
                                srcLeftRect.Width += (SelectedLine.SignalGroup.YellowTime + SelectedLine.SignalGroup.MinRed) * xResolution;
                                destLeftRect.Width += (SelectedLine.SignalGroup.YellowTime + SelectedLine.SignalGroup.MinRed) * xResolution;
                                break;

                            case LineType.Pedestrian:
                                srcLeftRect.Width += (SelectedLine.SignalGroup.FlashGreenTime + SelectedLine.SignalGroup.MinRed) * xResolution;
                                destLeftRect.Width += (SelectedLine.SignalGroup.FlashGreenTime + SelectedLine.SignalGroup.MinRed) * xResolution;
                                break;

                            case LineType.Single:
                                srcLeftRect.Width += SelectedLine.SignalGroup.MinRed * xResolution;
                                destLeftRect.Width += SelectedLine.SignalGroup.MinRed * xResolution;
                                break;
                        }

                        if (srcLeftRect.X + srcLeftRect.Width > Width)
                        {
                            Rectangle redundantRect = srcLeftRect;
                            redundantRect.X = 0;
                            redundantRect.Width = (srcLeftRect.X + srcLeftRect.Width) - Width;

                            if ((destLeftRect.Width > 0) && destLeftRect.IntersectsWith(redundantRect))
                                isOverlapped = true;

                            if ((destRightRect.Width > 0) && destRightRect.IntersectsWith(redundantRect))
                                isOverlapped = true;

                            srcLeftRect.Width = Width - srcLeftRect.X;
                        }

                        if (destLeftRect.X + destLeftRect.Width > Width)
                        {
                            Rectangle redundantRect = destLeftRect;
                            redundantRect.X = 0;
                            redundantRect.Width = (destLeftRect.X + destLeftRect.Width) - Width;

                            if ((srcLeftRect.Width > 0) && srcLeftRect.IntersectsWith(redundantRect))
                                isOverlapped = true;

                            if ((srcRightRect.Width > 0) && srcRightRect.IntersectsWith(redundantRect))
                                isOverlapped = true;

                            destLeftRect.Width = Width - destLeftRect.X;
                        }

                        if (srcLeftRect.Width > 0)
                        {
                            if ((destLeftRect.Width > 0) && srcLeftRect.IntersectsWith(destLeftRect))
                                isOverlapped = true;

                            if ((destRightRect.Width > 0) && srcLeftRect.IntersectsWith(destRightRect))
                                isOverlapped = true;
                        }

                        if (srcRightRect.Width > 0)
                        {
                            if ((destLeftRect.Width > 0) && srcRightRect.IntersectsWith(destLeftRect))
                                isOverlapped = true;

                            if ((destRightRect.Width > 0) && srcRightRect.IntersectsWith(destRightRect))
                                isOverlapped = true;
                        }

                        if (isOverlapped)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            bool VerifySelectedLine()
            {
                //Kiểm tra thời gian xanh tối thiểu
                bool retval = true;
                if (SelectedLine.SelectedRect.Start > SelectedLine.SelectedRect.End)
                {
                    if (SelectedLine.SelectedRect.Start + SelectedLine.SelectedRect.End < SelectedLine.SignalGroup.MinGreen)
                        retval = false;
                }
                else
                {
                    if (SelectedLine.SelectedRect.End - SelectedLine.SelectedRect.Start < SelectedLine.SignalGroup.MinGreen)
                        retval = false;
                }

                if (!retval)
                {
                    MessageBox.Show("Thời gian xanh không được nhỏ hơn thời gian xanh tối thiểu!");
                    SelectedLine.SelectedRect.LeftRect = RestoredLeftRect;
                    SelectedLine.SelectedRect.RightRect = RestoredRightRect;
                    return false;
                }

                if (!CheckMinRed())
                {
                    MessageBox.Show("Thời gian đỏ tối thiểu chưa thỏa mãn!");
                    SelectedLine.SelectedRect.LeftRect = RestoredLeftRect;
                    SelectedLine.SelectedRect.RightRect = RestoredRightRect;
                    return false;
                }

                //Kiểm tra sự thay đổi trạng thái trong vùng biến đổi
                foreach (VariableZone zone in listZones)
                {
                    if (((zone.LeftX < SelectedLine.SelectedRect.Start) && (SelectedLine.SelectedRect.Start < zone.RightX)) ||
                       ((zone.LeftX < SelectedLine.SelectedRect.End) && (SelectedLine.SelectedRect.End < zone.RightX)))
                    {
                        MessageBox.Show("Các nhóm tín hiệu không được thay đổi màu trong vùng biến đổi!");
                        SelectedLine.SelectedRect.LeftRect = RestoredLeftRect;
                        SelectedLine.SelectedRect.RightRect = RestoredRightRect;
                        return false;
                    }
                }

                //Kiểm tra thời gian tối thiểu sau khi trừ đi vùng biến đổi
                List<int> zoneLen = new List<int>();
                foreach (VariableZone zone in listZones)
                {
                    if (SelectedLine.SelectedRect.IsTwoSides)
                    {
                        if (zone.RightX <= SelectedLine.SelectedRect.End)
                        {
                            zoneLen.Add(zone.RightX - zone.LeftX);
                        }

                        if (SelectedLine.SelectedRect.Start <= zone.LeftX)
                        {
                            zoneLen.Add(zone.RightX - zone.LeftX);
                        }
                    }
                    else
                    {
                        if ((SelectedLine.SelectedRect.Start <= zone.LeftX) &&
                            (zone.RightX <= SelectedLine.SelectedRect.End))
                        {
                            zoneLen.Add(zone.RightX - zone.LeftX);
                        }
                    }
                }

                if (SelectedLine.SelectedRect.Start > SelectedLine.SelectedRect.End)
                {
                    if (cycleDuration - SelectedLine.SelectedRect.Start + SelectedLine.SelectedRect.End - zoneLen.Sum() <
                        SelectedLine.SignalGroup.MinGreen)
                    {
                        retval = false;
                    }
                }
                else
                {
                    if (SelectedLine.SelectedRect.End - SelectedLine.SelectedRect.Start - zoneLen.Sum() <
                        SelectedLine.SignalGroup.MinGreen)
                    {
                        retval = false;
                    }
                }

                if (!retval)
                {
                    MessageBox.Show("Thời gian xanh tối thiểu của L" + SelectedLine.ID.ToString() + " chưa được đáp ứng!");
                    SelectedLine.SelectedRect.LeftRect = RestoredLeftRect;
                    SelectedLine.SelectedRect.RightRect = RestoredRightRect;
                    return false;
                }

                //Kiểm tra xung đột
                bool isNew = false;
                if (!SelectedLine.RectList.Contains(SelectedLine.SelectedRect))
                {
                    SelectedLine.RectList.Add(SelectedLine.SelectedRect);
                    isNew = true;
                }

                for (int iLine = 0; iLine < listLines.Count; iLine++)
                {
                    if (listLines[iLine].ConflictData != null)
                    {
                        if (CheckLineConflict(listLines[iLine]))
                        {
                            if (isNew)
                                SelectedLine.RectList.Remove(SelectedLine.SelectedRect);

                            return false;
                        }
                    }
                }

                return true;
            }

            void ConvertLineCoordinate(LineData line)
            {
                if (line.SelectedRect != null)
                {
                    if (line.SelectedRect.RightRect.Width > 0)
                    {
                        line.SelectedRect.Start = line.SelectedRect.RightRect.X / xResolution;
                        line.SelectedRect.End = line.SelectedRect.LeftRect.Right / xResolution;

                        line.SelectedRect.RightRect.X = line.SelectedRect.Start * xResolution;
                        line.SelectedRect.RightRect.Width = Width - line.SelectedRect.RightRect.X;

                        line.SelectedRect.LeftRect.X = 0;
                        line.SelectedRect.LeftRect.Width = line.SelectedRect.End * xResolution;
                    }
                    else
                    {
                        line.SelectedRect.Start = line.SelectedRect.LeftRect.X / xResolution;
                        line.SelectedRect.End = line.SelectedRect.LeftRect.Right / xResolution;

                        line.SelectedRect.LeftRect.X = line.SelectedRect.Start * xResolution;
                        line.SelectedRect.LeftRect.Width = (line.SelectedRect.End - line.SelectedRect.Start) * xResolution;
                    }
                }
            }

            void DrawYellowRectangle(int x, int y, int width)
            {
                Rectangle rect = new Rectangle();
                rect.Y = y;
                rect.Height = 10;

                lineBrush.Color = Color.Yellow;
                linePen.Color = Color.Black;
                linePen.Width = 1;

                if (x + width > Width)
                {
                    if (x == Width)
                    {
                        x = 0;
                    }
                    else if (x < Width)
                    {
                        rect.X = x;
                        rect.Width = Width - x;

                        width = x + width - Width;
                        x = 0;

                        grapLine.FillRectangle(lineBrush, rect);
                        grapLine.DrawRectangle(linePen, rect);
                    }
                }

                rect.X = x;
                rect.Width = width;

                grapLine.FillRectangle(lineBrush, rect);
                grapLine.DrawRectangle(linePen, rect);
            }

            void DrawGreenFlashRectangle(int x, int y, int width)
            {
                float resolution = width / 8;
                float xRect;
                int i, j = 0;

                lineBrush.Color = Color.LawnGreen;
                linePen.Color = Color.Black;
                linePen.Width = 1;

                for (i = 1; i < 8; i += 2)
                {
                    xRect = x + i * resolution;
                    if (xRect < Width)
                    {
                        grapLine.FillRectangle(lineBrush, xRect, y, resolution, 10);
                        grapLine.DrawRectangle(linePen, xRect, y, resolution, 10);
                    }
                    else
                    {
                        break;
                    }
                    j++;
                }

                if (j < 4)
                {
                    for (i = 0; i < 4 - j; i++)
                    {
                        xRect = 2 * i * resolution;
                        grapLine.FillRectangle(lineBrush, xRect, y, resolution, 10);
                        grapLine.DrawRectangle(linePen, xRect, y, resolution, 10);
                    }
                }
            }

            public void RemoveBoldRectangle(LineData line)
            {
                linePen.Color = Color.White;
                linePen.Width = 2;      //Remove the bold rectangle
                grapLine.DrawRectangle(linePen, line.SelectedRect.LeftRect);
                grapLine.DrawRectangle(linePen, line.SelectedRect.RightRect);

                lineBrush.Color = Color.LawnGreen;

                grapLine.FillRectangle(lineBrush, line.SelectedRect.LeftRect);
                grapLine.FillRectangle(lineBrush, line.SelectedRect.RightRect);

                linePen.Color = Color.Black;
                linePen.Width = 1;  //Redraw the normal rectangle
                grapLine.DrawRectangle(linePen, line.SelectedRect.LeftRect);
                grapLine.DrawRectangle(linePen, line.SelectedRect.RightRect);
            }

            public void RemoveBoldRectangle(VariableZone zone)
            {
                zonePen.Color = Color.White;
                zonePen.Width = 2;
                grapZone.DrawRectangle(zonePen, zone.Rect);

                zonePen.Color = Color.Black;
                zonePen.Width = 1;
                grapZone.DrawRectangle(zonePen, zone.Rect);
            }

            //void ClearLineGraphic(LineData line)
            //{
            //    lineBrush.Color = Color.White;

            //    if ((line.SignalGroup.Type == LineType.ThreeColor) || (line.SignalGroup.Type == LineType.Pedestrian))
            //    {
            //        Rectangle rect = new Rectangle();
            //        rect.X = line.SelectedRect.LeftRect.Right;
            //        rect.Y = line.SelectedRect.LeftRect.Y;
            //        rect.Height = line.SelectedRect.LeftRect.Height;

            //        if (line.SignalGroup.Type == LineType.ThreeColor)
            //            rect.Width = line.SignalGroup.YellowTime * xResolution;
            //        else if (line.SignalGroup.Type == LineType.Pedestrian)
            //            rect.Width = line.SignalGroup.FlashGreenTime * xResolution;

            //        linePen.Color = Color.White;
            //        linePen.Width = 1;
            //        grapLine.DrawRectangle(linePen, rect);
            //        grapLine.FillRectangle(lineBrush, rect);
            //    }

            //    //linePen.Color = Color.Red;
            //    //linePen.Width = 1;
            //    //grapLine.DrawLine(linePen, 0, line.Y, Width, line.Y);

            //    linePen.Color = Color.White;
            //    linePen.Width = 2;
            //    grapLine.DrawRectangle(linePen, line.SelectedRect.LeftRect);
            //    grapLine.DrawRectangle(linePen, line.SelectedRect.RightRect);

            //    grapLine.FillRectangle(lineBrush, line.SelectedRect.LeftRect);
            //    grapLine.FillRectangle(lineBrush, line.SelectedRect.RightRect);
            //}

            void ClearLineGraphic(LineData line)
            {
                lineBrush.Color = Color.White;

                if ((line.SignalGroup.Type == LineType.FullLine)
                    || (line.SignalGroup.Type == LineType.Pedestrian)
                    || (line.SignalGroup.Type == LineType.ThreeColor))
                {
                    Rectangle rect = new Rectangle();
                    rect.X = line.SelectedRect.LeftRect.Right;
                    rect.Y = line.SelectedRect.LeftRect.Y;
                    rect.Height = line.SelectedRect.LeftRect.Height;

                    if ((line.SignalGroup.Type == LineType.FullLine) || (line.SignalGroup.Type == LineType.ThreeColor))
                        rect.Width = line.SignalGroup.YellowTime * xResolution;
                    else if (line.SignalGroup.Type == LineType.Pedestrian)
                        rect.Width = line.SignalGroup.FlashGreenTime * xResolution;

                    linePen.Color = Color.White;
                    linePen.Width = 1;
                    grapLine.DrawRectangle(linePen, rect);
                    grapLine.FillRectangle(lineBrush, rect);
                }

                //linePen.Color = Color.Red;
                //linePen.Width = 1;
                //grapLine.DrawLine(linePen, 0, line.Y, Width, line.Y);

                linePen.Color = Color.White;
                linePen.Width = 2;
                grapLine.DrawRectangle(linePen, line.SelectedRect.LeftRect);
                grapLine.DrawRectangle(linePen, line.SelectedRect.RightRect);

                grapLine.FillRectangle(lineBrush, line.SelectedRect.LeftRect);
                grapLine.FillRectangle(lineBrush, line.SelectedRect.RightRect);
            }

            //void RedrawAllLines()
            //{
            //    grapLine.Clear(Color.Transparent);
            //    foreach (LineData line in listLines)
            //    {
            //        if (line.SignalGroup.Type == LineType.DigitalLight)
            //        {
            //            linePen.Color = Color.Black;
            //            linePen.Width = 1;
            //            linePen.DashStyle = DashStyle.DashDotDot;
            //            grapLine.DrawLine(linePen, 0, line.Y, Width, line.Y);
            //            linePen.DashStyle = DashStyle.Solid;
            //        }
            //        else
            //        {
            //            linePen.Color = Color.Red;
            //            linePen.Width = 1;
            //            grapLine.DrawLine(linePen, 0, line.Y, Width, line.Y);

            //            foreach (GreenRectangle rect in line.RectList)
            //            {
            //                lineBrush.Color = Color.LawnGreen;
            //                linePen.Color = Color.Black;
            //                if (rect.IsSelected)
            //                    linePen.Width = 2;
            //                else
            //                    linePen.Width = 1;

            //                grapLine.FillRectangle(lineBrush, rect.LeftRect);
            //                grapLine.FillRectangle(lineBrush, rect.RightRect);

            //                grapLine.DrawRectangle(linePen, rect.LeftRect);
            //                grapLine.DrawRectangle(linePen, rect.RightRect);

            //                switch (line.SignalGroup.Type)
            //                {
            //                    case LineType.ThreeColor:
            //                        if (rect.IsTwoSides)
            //                            DrawYellowRectangle(rect.LeftRect.Right, rect.LeftRect.Y, line.SignalGroup.YellowTime * xResolution);
            //                        else if (rect.LeftRect.Width > 0)
            //                            DrawYellowRectangle(rect.LeftRect.Right, rect.LeftRect.Y, line.SignalGroup.YellowTime * xResolution);
            //                        break;

            //                    case LineType.Pedestrian:
            //                        if (rect.LeftRect.Width > 0)
            //                            DrawGreenFlashRectangle(rect.LeftRect.Right, rect.LeftRect.Y, line.SignalGroup.FlashGreenTime * xResolution);
            //                        break;
            //                }
            //            }
            //        }
            //    }
            //}

            void RedrawAllLines()
            {
                grapLine.Clear(Color.Transparent);
                foreach (LineData line in listLines)
                {
                    if (line.SignalGroup.Type == LineType.DigitalLight)
                    {
                        linePen.Color = Color.Black;
                        linePen.Width = 1;
                        linePen.DashStyle = DashStyle.DashDotDot;
                        grapLine.DrawLine(linePen, 0, line.Y, Width, line.Y);
                        linePen.DashStyle = DashStyle.Solid;
                    }
                    else
                    {
                        linePen.Color = Color.Red;
                        linePen.Width = 1;
                        grapLine.DrawLine(linePen, 0, line.Y, Width, line.Y);

                        foreach (GreenRectangle rect in line.RectList)
                        {
                            lineBrush.Color = Color.LawnGreen;
                            linePen.Color = Color.Black;
                            if (rect.IsSelected)
                                linePen.Width = 2;
                            else
                                linePen.Width = 1;

                            grapLine.FillRectangle(lineBrush, rect.LeftRect);
                            grapLine.FillRectangle(lineBrush, rect.RightRect);

                            grapLine.DrawRectangle(linePen, rect.LeftRect);
                            grapLine.DrawRectangle(linePen, rect.RightRect);

                            switch (line.SignalGroup.Type)
                            {
                                case LineType.FullLine:
                                case LineType.ThreeColor:
                                    if (rect.IsTwoSides)
                                        DrawYellowRectangle(rect.LeftRect.Right, rect.LeftRect.Y, line.SignalGroup.YellowTime * xResolution);
                                    else if (rect.LeftRect.Width > 0)
                                        DrawYellowRectangle(rect.LeftRect.Right, rect.LeftRect.Y, line.SignalGroup.YellowTime * xResolution);
                                    break;

                                case LineType.Pedestrian:
                                    if (rect.LeftRect.Width > 0)
                                        DrawGreenFlashRectangle(rect.LeftRect.Right, rect.LeftRect.Y, line.SignalGroup.FlashGreenTime * xResolution);
                                    break;
                            }
                        }
                    }
                }
            }

            public void DeleteSelectedZone()
            {
                if ((SelectedZone != null) && listZones.Contains(SelectedZone))
                {
                    listZones.Remove(SelectedZone);

                    RedrawAllZones();
                    DiagramRefresh();
                }

                SelectedZone = null;
            }

            public void ModifySelectedZone(int start, int end)
            {
                if (listZones.Contains(SelectedZone))
                {
                    RestoredZone = SelectedZone.Rect;

                    SelectedZone.LeftX = start;
                    SelectedZone.RightX = end;

                    SelectedZone.Rect.X = start * xResolution;
                    SelectedZone.Rect.Width = (end - start) * xResolution;

                    VerifySelectedZone();
                    ConvertZoneCoordinate(SelectedZone);

                    RedrawAllZones();
                    DiagramRefresh();
                }
                else
                    SelectedZone = null;
            }

            /////////////////////// Zone Mouse Events \\\\\\\\\\\\\\\\\\\\\
            #region Mouse Events for Zone
            public void MouseDownVZ(MouseEventArgs e)
            {
                Point ePoint = e.Location;

                if (SelectedZone != null)
                {
                    switch (SelectedZone.CheckPoint(ePoint))
                    {
                        case VariableZone.MousePosition.Green:
                            return;

                        case VariableZone.MousePosition.LeftEdge:     //Left
                            SelectedZone.IsDrawing = true;
                            SelectedZone.MovingDirection = true;    //Left direction

                            //Clear graphic
                            grapZone.FillRectangle(clearZoneBrush, SelectedZone.Rect);

                            zonePen.Color = Color.White;
                            zonePen.Width = 2;
                            grapZone.DrawRectangle(zonePen, SelectedZone.Rect);

                            RestoredZone = SelectedZone.Rect;
                            return;

                        case VariableZone.MousePosition.RightEdge:     //Right
                            SelectedZone.IsDrawing = true;
                            SelectedZone.MovingDirection = false;    //Right direction

                            //Clear graphic
                            grapZone.FillRectangle(clearZoneBrush, SelectedZone.Rect);

                            zonePen.Color = Color.White;
                            zonePen.Width = 2;
                            grapZone.DrawRectangle(zonePen, SelectedZone.Rect);

                            RestoredZone = SelectedZone.Rect;
                            return;
                    }

                    SelectedZone.IsSelected = false;

                    //Remove bold
                    zonePen.Color = Color.White;
                    zonePen.Width = 2;
                    grapZone.DrawRectangle(zonePen, SelectedZone.Rect);

                    zonePen.Color = Color.Black;
                    zonePen.Width = 1;
                    grapZone.DrawRectangle(zonePen, SelectedZone.Rect);
                }

                for (int i = 0; i < listZones.Count; i++)
                {
                    if (listZones[i].CheckPoint(ePoint) == VariableZone.MousePosition.Green)
                    {
                        SelectedZone = listZones[i];
                        SelectedZone.IsSelected = true;

                        //Bold the rectangle
                        zonePen.Color = Color.Black;
                        zonePen.Width = 2;
                        grapZone.DrawRectangle(zonePen, SelectedZone.Rect);

                        DiagramRefresh();
                        return;
                    }
                }

                //Nếu không có phần tử nào trong listZones
                VariableZone zone = new VariableZone();

                zone.ID = -1;

                zone.Rect.X = ePoint.X;
                zone.Rect.Y = 0;
                zone.Rect.Width = 0;
                zone.Rect.Height = bmpZone.Height;

                RestoredZone = zone.Rect;

                SelectedZone = zone;
                SelectedZone.IsSelected = true;
                SelectedZone.IsDrawing = true;

                ConvertZoneCoordinate(SelectedZone);
            }

            public void MouseMoveVZ(MouseEventArgs e)
            {
                Point ePoint = e.Location;
                bool isInRect = false;

                if (e.Button == MouseButtons.None)
                {
                    pbxDiagram.Cursor = Cursors.Arrow;
                    for (int i = 0; i < listZones.Count; i++)
                    {
                        switch (listZones[i].CheckPoint(ePoint))
                        {
                            case VariableZone.MousePosition.Green:
                                pbxDiagram.Cursor = Cursors.Hand;
                                isInRect = true;
                                break;

                            case VariableZone.MousePosition.LeftEdge:
                            case VariableZone.MousePosition.RightEdge:
                                pbxDiagram.Cursor = Cursors.SizeWE;
                                isInRect = true;
                                break;
                        }

                        if (isInRect)
                            break;
                    }
                }

                if ((e.Button == MouseButtons.Left) && (e.X > 0) && (e.X <= Width))
                {
                    if ((SelectedZone != null) && SelectedZone.IsDrawing)
                    {
                        pbxDiagram.Cursor = Cursors.SizeWE;

                        zonePen.Color = Color.White;
                        zonePen.Width = 1;
                        grapZone.DrawRectangle(zonePen, SelectedZone.Rect);

                        if (SelectedZone.MovingDirection)    //Left moving
                        {
                            SelectedZone.Rect.Width += SelectedZone.Rect.X - e.X;

                            if (SelectedZone.Rect.Width < 0)
                                SelectedZone.MovingDirection = false;
                            else
                                SelectedZone.Rect.X = e.X;
                        }
                        else   //Right moving
                        {
                            SelectedZone.Rect.Width = e.X - SelectedZone.Rect.X;
                            if (SelectedZone.Rect.Width < 0)
                                SelectedZone.MovingDirection = true;
                        }

                        ConvertZoneCoordinate(SelectedZone);

                        zonePen.Color = Color.Black;
                        zonePen.Width = 1;
                        grapZone.DrawRectangle(zonePen, SelectedZone.Rect);

                        DiagramRefresh();
                    }
                }
            }

            public void MouseUpVZ(MouseEventArgs e)
            {
                int i, j;
                bool isNewZone = false;

                if ((SelectedZone != null) && SelectedZone.IsDrawing)
                {
                    if (SelectedZone.Rect.Width < xResolution)
                    {
                        if (listZones.Contains(SelectedZone))
                        {
                            listZones.Remove(SelectedZone);
                            SelectedZone = null;
                        }

                        RedrawAllZones();
                        DiagramRefresh();
                        return;
                    }

                    SelectedZone.IsDrawing = false;

                    if (!listZones.Contains(SelectedZone))
                    {
                        //Find new ID
                        bool found;
                        for (i = 0; i < listZones.Count; i++)
                        {
                            found = false;
                            for (j = 0; j < listZones.Count; j++)
                            {
                                if (i == listZones[j].ID)
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                                break;
                        }

                        SelectedZone.ID = i;
                        listZones.Add(SelectedZone);
                        isNewZone = true;
                    }

                    //Verify SelectedZone before adding
                    if (!VerifySelectedZone())
                    {
                        if (isNewZone)
                        {
                            listZones.Remove(SelectedZone);
                            SelectedZone = null;
                        }
                    }

                    ConvertZoneCoordinate(SelectedZone);

                    RedrawAllZones();
                    DiagramRefresh();
                }
            }

            #endregion

            #region Zone Functions
            bool VerifySelectedZone()
            {
                int i;

                //Kiểm tra xem có đè lên nhau
                for (i = 0; i < listZones.Count; i++)
                {
                    if (SelectedZone.ID != listZones[i].ID)
                    {
                        if (SelectedZone.Rect.IntersectsWith(listZones[i].Rect))
                        {
                            SelectedZone.Rect = RestoredZone;
                            return false;
                        }
                    }
                }

                //Kiểm tra xem các line có thay đổi trạng thái trong zone
                for (i = 0; i < listLines.Count; i++)
                {
                    foreach (GreenRectangle rect in listLines[i].RectList)
                    {
                        if (((SelectedZone.LeftX < rect.Start) && (rect.Start < SelectedZone.RightX)) ||
                           ((SelectedZone.LeftX < rect.End) && (rect.End < SelectedZone.RightX)))
                        {
                            SelectedZone.Rect = RestoredZone;
                            MessageBox.Show("Các nhóm tín hiệu không được thay đổi màu trong vùng biến đổi!");
                            return false;
                        }
                    }
                }

                //Kiểm tra xem thời gian xanh tối thiểu của từng line có đạt không
                List<int> lenZoneList = new List<int>();
                bool minGreenFailed;

                foreach (LineData line in listLines)
                {
                    foreach (GreenRectangle greenRect in line.RectList)
                    {
                        lenZoneList.Clear();
                        minGreenFailed = false;
                        foreach (VariableZone zone in listZones)
                        {
                            if (greenRect.IsTwoSides)
                            {
                                if (zone.RightX <= greenRect.End)
                                    lenZoneList.Add(zone.RightX - zone.LeftX);

                                if (greenRect.Start <= zone.LeftX)
                                    lenZoneList.Add(zone.RightX - zone.LeftX);
                            }
                            else
                            {
                                if ((greenRect.Start <= zone.LeftX) && (zone.RightX <= greenRect.End))
                                    lenZoneList.Add(zone.RightX - zone.LeftX);
                            }
                        }

                        if (greenRect.IsTwoSides)
                        {
                            if (cycleDuration - greenRect.Start + greenRect.End - lenZoneList.Sum() < line.SignalGroup.MinGreen)
                                minGreenFailed = true;
                        }
                        else
                        {
                            if (greenRect.End - greenRect.Start - lenZoneList.Sum() < line.SignalGroup.MinGreen)
                                minGreenFailed = true;
                        }

                        if (minGreenFailed)
                        {
                            SelectedZone.Rect = RestoredZone;
                            MessageBox.Show("Thời gian xanh tối thiểu của L" + line.ID.ToString() + " chưa được đáp ứng!");
                            return false;
                        }
                    }
                }

                return true;
            }

            void ConvertZoneCoordinate(VariableZone zone)
            {
                if (zone != null)
                {
                    zone.LeftX = zone.Rect.X / xResolution;
                    zone.RightX = (zone.Rect.X + zone.Rect.Width) / xResolution;

                    zone.Rect.X = zone.LeftX * xResolution;
                    zone.Rect.Width = (zone.RightX - zone.LeftX) * xResolution;
                }
            }

            void RedrawAllZones()
            {
                for (int i = 0; i < listZones.Count; i++)
                {
                    if (listZones[i].Rect.Width < xResolution)
                    {
                        listZones.RemoveAt(i);
                    }
                }
                grapZone.Clear(Color.Transparent);

                foreach (VariableZone zone in listZones)
                {
                    grapZone.FillRectangle(zoneBrush, zone.Rect);

                    zonePen.Color = Color.Black;
                    if (zone.IsSelected)
                        zonePen.Width = 2;
                    else
                        zonePen.Width = 1;

                    grapZone.DrawRectangle(zonePen, zone.Rect);
                }
            }

            #endregion
        }


        DrawingDiagram _DrawDiagram;
        List<SignalStoreData> _Signals;
        DiagramListStoreData _SelectedDiagram;
        DiagramStoreData _DiagramInfo;
        int _Resolution = 10;

        public HDTrafficDiagram()
        {
            InitializeComponent();
            _Signals = new List<SignalStoreData>();
            _DrawDiagram = new DrawingDiagram();
            _Resolution = _DrawDiagram.xResolution;
            CheckForIllegalCrossThreadCalls = false;
        }

        public void DrawDiagram()
        {
            _DrawDiagram.pbxDiagram = pictureBox1;
            _DrawDiagram.panelDiagram = panel2;
            for (int j = 0; j < _Signals.Count; j++)
            {
                LineData lineData = new LineData();
                lineData.Index = j;
                lineData.ID = _Signals[j].ID;
                lineData.SignalGroup = _Signals[j];
                _DrawDiagram.AddLine(lineData);
            }
            _DrawDiagram.SelectedDiagram = _SelectedDiagram;
            _DrawDiagram.InitDiagramGraphic(_DiagramInfo);

        }

        public void AddSignal(int ID, int lineType, int yellowTime)
        {
            SignalStoreData signal = new SignalStoreData();
            signal.ID = ID;
            signal.Type = (LineType)lineType;
            signal.YellowTime = yellowTime;
            if (signal.Type == LineType.Pedestrian)
            {
                signal.FlashGreenTime = yellowTime;
            }
            _Signals.Add(signal);
        }

        public void AddDiagram(int id, string name, int cycle)
        {
            _SelectedDiagram = new DiagramListStoreData();
            _SelectedDiagram.ID = id;
            _SelectedDiagram.Name = name;
            _SelectedDiagram.Cycle = cycle;

            _DiagramInfo = new DiagramStoreData();
            _DiagramInfo.Info = _SelectedDiagram;
            _DiagramInfo.ListLines = new List<LineData>();
            _DiagramInfo.ListZones = new List<VariableZone>();

        }

        public void AddSignalInfo(int lineID, List<int> start, List<int> end)
        {
            LineData line = new LineData();
            line.ID = lineID;
            for (int j = 0; j < start.Count; j++)
            {
                GreenRectangle rec = new GreenRectangle();
                rec.Start = start[j] * _Resolution;
                rec.End = end[j] * _Resolution;
                if (rec.Start <= rec.End)
                {
                    rec.LeftRect = new System.Drawing.Rectangle();
                    rec.LeftRect.Width = rec.End - rec.Start;
                    rec.LeftRect.Height = 10;
                    rec.LeftRect.X = rec.Start;
                }
                else
                {
                    rec.LeftRect = new System.Drawing.Rectangle();
                    rec.LeftRect.Width = rec.End;
                    rec.LeftRect.Height = 10;
                    rec.LeftRect.X = 0;

                    rec.RightRect = new System.Drawing.Rectangle();
                    if (_SelectedDiagram.Cycle * _Resolution > rec.Start)
                    {
                        rec.RightRect.Width = _SelectedDiagram.Cycle * _Resolution - rec.Start;
                    }
                    else
                    {
                        rec.RightRect.Width = 0;
                    }
                    rec.RightRect.Height = 10;
                    rec.RightRect.X = rec.Start;
                }
                line.RectList.Add(rec);
            }
            _DiagramInfo.ListLines.Add(line);
        }

        public void AddZone(List<int> start, List<int> end)
        {
            for (int j = 0; j < start.Count; j++)
            {
                VariableZone zone = new VariableZone();
                zone.Rect.X = start[j] * _Resolution;
                zone.Rect.Width = (end[j] - start[j]) * _Resolution;
                _DiagramInfo.ListZones.Add(zone);
            }
        }

        public void ClearGraph()
        {
            _DrawDiagram.ClearGraph();
            _Signals = new List<SignalStoreData>();
        }

        // do these steps to draw a graph
        // 1. clear diagram
        // 2. add diagram
        // 3. add signal
        // 4. add line
        // 5. add zone
        // 6. draw diagram
    }
}

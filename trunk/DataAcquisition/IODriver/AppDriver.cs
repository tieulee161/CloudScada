using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;

using DriverCommon;
using System.ComponentModel;

namespace IODriver
{
    #region enum
    public enum eCommandID
    {
        Event = 0,
        ReadLineStatus = 1,
        ReadTime = 2,
        WriteTime = 3,
        ReadPowerTimeStamp = 4,

        ReadModeControl = 5,
        ChangeModeControl = 6,

        ReadErrorContent = 7,

        ReadControllerInfo = 10,
        ReadTemp = 11,
        ReadSourceVoltage = 12,
        ReadBatteryVoltage = 13,

        ReadIO = 20,
        WriteIO = 21,

        ReadSDCardStatus = 30,
        ReadFileSize = 31,
        ReadAllData = 32,
        ReadBlockData = 33,
        DeleteFile = 34,

        ReadPLCStatus = 40,
        ReadLightCurrent = 41,
        ReadThresholdCurrent = 42,
        WriteThresholdCurrent = 43,

        ReadHMIStatus = 60,

        Reset = 80,

        ChangeDateConfig = 90,
        ChangeTODConfig = 91,
        ReadEepromFileSize = 92,
        ReadEepromFile = 93,
        ReadEepromBlockData = 94,
        ReadCurrentScenarioID = 95,
        ReadCurrentTOD = 96,
        ReadCurrentDiagram = 97,

        None
    };

    public enum HMIStatus
    {
        HMIConnectedEntry = 0,
        HMIConnected = 1,
        HMIDisconnected = 2
    };

    public enum SDStatus
    {
        Dismount,	// ko được gắn
        Removed,		// được tháo ra
        InitFailed,	// quá trình khởi động bị lỗi
        Error,		// lỗi
        Mounted,		// đã được gắn
        Init,		// đang khởi động
        Connected,	// được kết nối
        Retry		// đang khởi động lại
    };

    public enum SDError
    {
        Good = 0,                    // No error
        EraseFailed,                  // An erase failed
        NotPresent,                 // No device was present
        NotFormatted,               // The disk is of an unsupported format
        BadPartition,               // The boot record is bad
        Unsupported,              // The file system type is unsupported
        InitError,                  // An initialization error has occured
        NotInit,                    // An operation was performed on an uninitialized device
        BadSector,             // A bad read of a sector occured
        WriteError,                 // Could not write to a sector
        InvalidCluster,             // Invalid cluster value > maxcls
        FileNotFound,              // Could not find the file on the device
        PathNotfount,               // Could not find the directory
        BadFile,                    // File is corrupted
        Done,                        // No more files in this directory
        CouldNotGetCluster,       // Could not load/allocate next cluster in file
        FileNameLong,             // A specified file name is too long to use
        FiledNameExisted,             // A specified filename already exists on the device
        InvalidFileName,            // Invalid file name
        DeleteDir,                  // The user tried to delete a directory with FSremove
        DirFull,                    // All root dir entry are taken
        DiskFull,                   // All clusters in partition are taken
        DirNotEmpty,               // This directory is not empty yet, remove files before deleting
        NonSupportedSize,           // The disk is too big to format as FAT16
        WriteProtected,             // Card is write protected
        FileNotOpened,               // File not opened for the write
        SeekError,                  // File location could not be changed successfully
        BadCatch,                // Bad cache read
        CardFat32,                   // FAT 32 - card not supported
        ReadOnlyFile,                    // The file is read-only
        WriteOnlyFile,                   // The file is write-only
        InvalidArgument,            // Invalid argument
        TooManyFilesOpened,         // Too many files are already open
        UnsupportSectorSize      // Unsupported sector size
    } ;

    public enum ModeControl
    {
        Auto = 0,
        Manual = 1,
        Remote = 2,
        //   Coordinate = 3,
        Safe = 3,
        Calib = 4,

    };

    public enum TypeControl
    {
        Color = 0,
        Coordinate = 1,
        Flash = 2,
        Off = 3,
        All_Red = 4,
        Inactive = 0xff,
    };

    public enum NetModeCommand
    {
        Remote_Color = 0, // 
        Remote_Change_Phase = 1, // dieu khien tay qua mang
        Remote_Flash = 2,
        Remote_Off = 3,
        Auto = 4, // chuyen sang che do local
        Calib = 5,
        Coordinate = 6, //  chuc nang coordinate theo xung
        Coordinate_Mod = 7, //  chuc nang coordinate theo thoi gian xanh

    };

    public enum JunctionStatus
    {
        Disconnect = 0xF0,
        Connect = 0xF1,
        Auto_Color = (int)(TypeControl.Color) * 16 + (int)(ModeControl.Auto),
        Auto_Yellow_Flashing = (int)(TypeControl.Flash) * 16 + (int)(ModeControl.Auto),
        Auto_Off = (int)(TypeControl.Off) * 16 + (int)(ModeControl.Auto),
        Manual_Color = (int)(TypeControl.Color) * 16 + (int)(ModeControl.Manual),
        Manual_Yellow_Flashing = (int)(TypeControl.Flash) * 16 + (int)(ModeControl.Manual),
        Manual_All_Red = (int)(TypeControl.All_Red) * 16 + (int)(ModeControl.Manual),
        Remote_Color = (int)(TypeControl.Color) * 16 + (int)(ModeControl.Remote),
        Remote_Yellow_Flashing = (int)(TypeControl.Flash) * 16 + (int)(ModeControl.Remote),
        Remote_Off = (int)(TypeControl.Off) * 16 + (int)(ModeControl.Remote),
        Coordination = (int)(TypeControl.Coordinate) * 16 + (int)(ModeControl.Auto),
        Safety_Off = (int)(TypeControl.Off) * 16 + (int)(ModeControl.Safe),
        Safety_Yellow_Flashing = (int)(TypeControl.Flash) * 16 + (int)(ModeControl.Safe),
        Calib = (int)(ModeControl.Calib),
        Error = 0xff
    }

    public enum EerpromFile
    {
        Info = 0,
        InOut = 1,
        Error = 2,
        IpConfig = 3,
        Line = 4,
        Date = 5,
        TODxx = 6,
        Diagramxx = 7,
    }

    public enum LightType
    {
        FullLine = 1,
        ThreeColorLight = 2,
        PedestrianLight = 3,
        SingleLight = 4,
        CountdownLight = 5,
    }

    public enum TagAddress
    {

    }

    public enum OperationDateType
    {
        NormalDate = 0,
        SpecialDOW = 1,
        SpecialDOM = 2,
    }

    public enum ParserState
    {
        ParsingHeader,
        ParsingBody,
        ParsingCRC,
        ParsingData,
    }

    #endregion

    #region data structure
    public class MsgHeader
    {
        public byte[] Marker;
        public byte ID;
        public byte Lenght;

        public MsgHeader()
        {
            Marker = Encoding.ASCII.GetBytes("MSG");
            ID = 0;
            Lenght = 0;
        }
        public List<byte> GetHeader()
        {
            List<byte> res = new List<byte>();
            res.AddRange(Marker);
            res.Add(ID);
            res.Add(Lenght);
            return res;
        }
        public bool ParseHeader(byte[] data)
        {
            bool res = false;
            if (data.Length == 5)
            {
                ID = data[3];
                Lenght = data[4];
                res = true;
            }
            return res;
        }
    }

    public class MsgBody
    {
        public List<byte> Data = new List<byte>();
    }

    public class MsgCRC
    {
        public List<byte> Data = new List<byte>();
    }

    public class Frame
    {
        public ParserState ParserState = ParserState.ParsingHeader;
        public MsgHeader Header;
        public MsgBody Body;
        public MsgCRC CRC;
        public bool CheckCRC()
        {
            bool res = false;
            List<byte> temp = this.Header.GetHeader();
            temp.AddRange(this.Body.Data.ToArray());
            ushort crc = Utilities.CRC_Final((ushort)Utilities.CRC_ByteArray(temp.ToArray(), temp.Count, 0));
            if (BitConverter.ToUInt16(this.CRC.Data.ToArray(), 0) == crc)
            {
                res = true;
            }
            return res;
        }
    }

    public class LineStatus
    {
        public byte ID;
        public byte Type;
        public byte State;
        public byte FbState;
        public bool IsError
        {
            get
            {
                bool res = false;
                if ((FbState & 0xf0) != 0)
                {
                    res = true;
                }
                return res;
            }
        }
    }

    public class LineArray
    {
        public int NumberOfLines
        {
            get
            {
                return AllLines.Count;
            }
        }
        public List<LineStatus> AllLines = new List<LineStatus>();
    }

    public class EventMessage : MarshalByRefObject
    {
        public byte ID { get; set; }
        public byte SubID { get; set; }
        public DateTime Time { get; set; }
        public int Parameter { get; set; }
        public string Description
        {
            get
            {
                string res = "";
                switch (ID)
                {
                    case 0:
                        res = "Lỗi thiếu đèn THGT";
                        break;
                    case 1:
                        res = "Lỗi triac điều khiển đèn bị hở mạch";
                        break;
                    case 2:
                        res = "Lỗi cảm biến áp";
                        break;
                    case 3:
                        res = "Lỗi triac ngắn mạch";
                        break;
                    case 4:
                        res = "Lỗi áp không mong muốn trên đèn";
                        break;
                    case 5:
                        res = "Lỗi cảm biến dòng điện hoặc ngưỡng dòng điện";
                        break;
                    case 6:
                        res = "Lỗi chip ADC trên card công suất";
                        break;
                    case 7:
                        res = "Lỗi ngưỡng dòng điện qua đèn";
                        break;
                    case 8:
                        res = "Lỗi bộ nhớ chương trình của card công suất";
                        break;
                    case 9:
                        res = "Lỗi giao tiếp với card công suất";
                        break;
                    case 10:
                        res = "Lỗi dữ liệu không đồng nhất giữa CPU và card công suất";
                        break;
                    case 11:
                        res = "Lỗi kết nối với card công suất";
                        break;
                    case 12:
                        res = "Lỗi chưa gắn card công suất";
                        //_Priority = "Lỗi nghiêm trọng";
                        break;

                    case 30:
                        res = "Lỗi bộ nhớ EEPROM của CPU";
                        break;
                    case 40:
                        res = "Lỗi đèn đã được khắc phục";
                        break;
                    case 41:
                        res = "Lỗi ngưỡng dòng điện đã được khắc phục";
                        break;
                    case 42:
                        res = "Lỗi chip ADC được khắc phục";
                        break;

                    case 50:
                        res = "Dữ liệu giữa CPU và card công suất đã đồng nhất";
                        break;
                    case 51:
                        res = "Lỗi chip ADC được khắc phục";
                        break;
                    case 52:
                        res = "Không còn lỗi bộ nhớ trên card";
                        break;
                    case 53:
                        res = "Lỗi thực hiện việc hiệu chỉnh";
                        break;
                    case 54:
                        res = "Bắt đầu quá trình hiệu chỉnh";
                        break;
                    case 55:
                        res = "Quá trình hiệu chỉnh đã xong";
                        break;

                    case 70:
                        res = "Thẻ nhớ bị lỗi";
                        break;
                    case 71:
                        res = "Thẻ nhớ đã được tháo ra";
                        break;
                    case 72:
                        res = "Thẻ nhớ đã được kết nối";
                        break;

                    case 80:
                        res = "Card HMI đã được kết nối";
                        break;
                    case 81:
                        res = "Card HMI mất kết nối";
                        break;

                    case 90:
                        res = "Đã kết nối với server";
                        break;
                    case 91:
                        res = "Mất kết nối với server";
                        break;

                    case 100:
                        res = "Thời gian trong hệ thống bị thay đổi";
                        break;
                    case 101:
                        res = "Kịch bản mới được áp dụng";
                        break;
                    case 102:
                        res = "Thời đoạn mới được áp dụng";
                        break;
                    case 103:
                        res = "Giản đồ mới được áp dụng";
                        break;

                    case 110:
                        res = "Lỗi bus giao tiếp với chip thời gian thực";
                        break;
                    case 111:
                        res = "Ghi thời gian thực vào chip RTC bị lỗi";
                        break;
                    case 112:
                        res = "Bộ dao động của chip RTC bị lỗi";
                        break;

                    case 120:
                        res = "Chương trình được nạp thành công";
                        break;
                    case 121:
                        res = "Nạp chương trình bị lỗi";
                        break;

                    case 130:
                        res = "Bộ nguồn DC được bật";
                        break;
                    case 131:
                        res = "Bộ nguồn DC bị tắt";
                        break;

                    case 150:
                        res = "Trạng thái điều khiển hiện tại của tủ";
                        break;

                }
                return res;
            }
        }
        public string Detail
        {
            get
            {
                string res = "";
                byte[] temp = new byte[4];
                //   temp[0] = (byte)(Parameter & 0x00ff);
                //   temp[1] = (byte)((Parameter & 0xff00) >> 8);
                temp = BitConverter.GetBytes(Parameter);

                switch (ID)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 40:
                        int CardID = temp[0] & 0x0f;
                        int LightID = (temp[0] & 0xf0) >> 4;
                        string lampType = "";
                        switch (temp[1] & 0x0f)
                        {
                            case 1:
                                lampType = "Xanh-Vàng-Đỏ ";
                                break;
                            case 2:
                                lampType = "Đèn đi bộ ";
                                break;
                            case 3:
                                lampType = "Đèn điều khiển đơn";
                                break;
                            case 4:
                                lampType = "Đèn số đếm lùi";
                                break;
                        }
                        string Color = "";
                        switch ((temp[1] & 0xF0) >> 4)
                        {
                            case 3:
                                Color = "Đỏ thập";
                                break;
                            case 0:
                                Color = "Xanh";
                                break;
                            case 1:
                                Color = "Vàng";
                                break;
                            case 2:
                                Color = "Đỏ";
                                break;
                        }
                        //switch ((temp[1] & 0xC0) >> 6)
                        //{
                        //    case 0:
                        //        _Priority = "Không lỗi";
                        //        break;
                        //    case 1:
                        //        _Priority = "Lỗi ít nghiêm trọng";
                        //        break;
                        //    case 2:
                        //        _Priority = "Lỗi nghiêm trọng";
                        //        break;
                        //}

                        string content = "";
                        content += MaskBit(temp[2], 0) ? "Lỗi thiếu đèn. " : "";
                        content += MaskBit(temp[2], 1) ? "Lỗi triac hở mạch. " : "";
                        content += MaskBit(temp[2], 2) ? "Lỗi cảm biến áp. " : "";
                        content += MaskBit(temp[2], 4) ? "Triac ngắn mạch. " : "";
                        content += MaskBit(temp[2], 5) ? "Áp không mong muốn. " : "";
                        content += MaskBit(temp[2], 6) ? "Lỗi cảm biến dòng điện. " : "";

                        res = string.Format("Line: {6},Card: {0}, Đèn: {1}, Màu: {2}, Kiểu: {3}, Mức độ: {4}, Lỗi: {5} ",
                                            CardID,
                                            LightID,
                                            Color,
                                            lampType,
                                            "",
                                            content,
                                            SubID);

                        break;
                    case 6:
                        string sensor_err = "";
                        sensor_err += MaskBit(temp[0], 0) ? "Chip ADC thứ 0 không hoạt động. " : "";
                        sensor_err += MaskBit(temp[0], 1) ? "Chip ADC thứ 1 không hoạt động. " : "";
                        sensor_err += MaskBit(temp[0], 2) ? "Chip ADC thứ 2 không hoạt động. " : "";
                        sensor_err += MaskBit(temp[0], 3) ? "Chip ADC thứ 3 không hoạt động. " : "";
                        sensor_err += MaskBit(temp[0], 4) ? "Chip ADC thứ 0 không cấu hình được. " : "";
                        sensor_err += MaskBit(temp[0], 5) ? "Chip ADC thứ 1 không cấu hình được. " : "";
                        sensor_err += MaskBit(temp[0], 6) ? "Chip ADC thứ 2 không cấu hình được. " : "";
                        sensor_err += MaskBit(temp[0], 7) ? "Chip ADC thứ 3 không cấu hình được. " : "";
                        res = string.Format("Card {1} : {0}",
                                               sensor_err,
                                               SubID);
                        //  _Priority = "Lỗi nghiêm trọng";
                        break;
                    case 7:
                        string current_threshod_err = "";
                        for (int j = 0; j < 8; j++)
                        {
                            current_threshod_err += MaskBit(temp[0], (byte)j) ? "Đèn " + j.ToString() + " . " : "";
                        }
                        res = string.Format("{0}, Card {1}",
                                               current_threshod_err,
                                               SubID);
                        //   _Priority = "Lỗi nghiêm trọng";
                        break;
                    case 8:
                    case 9:
                    case 10:
                    case 12:
                    case 41:
                    case 42:
                    case 50:
                    case 51:
                    case 52:
                    case 70:
                        res = string.Format("Card {0} : {1}", SubID, temp[0].ToString("X2"));
                        //   _Priority = "Lỗi nghiêm trọng";
                        break;
                    case 11:
                    case 53:
                    case 81:
                        string card_connection_err = "";
                        switch (temp[0] & 0x0f)
                        {
                            case 0:
                                card_connection_err = "Giao tiếp thành công. ";
                                break;
                            case 1:
                                card_connection_err = "Địa chỉ không hợp lệ. ";
                                break;
                            case 2:
                                card_connection_err = "Lệnh không hợp lệ. ";
                                break;
                            case 3:
                                card_connection_err = "Trả về NACK. ";
                                break;
                            case 4:
                                card_connection_err = "Lỗi checksum. ";
                                break;
                            case 5:
                                card_connection_err = "Lỗi timeout nhận dữ liệu. ";
                                break;
                            case 6:
                                card_connection_err = "Xung đột bus với IC khác. ";
                                break;
                            case 7:
                                card_connection_err = "Hết thời gian chờ bit điều khiển. ";
                                break;
                            case 8:
                                card_connection_err = "Số byte đọc/ghi không hợp lệ. ";
                                break;
                            case 9:
                                card_connection_err = "Bus đang bị treo do 1 task khác đang sử dụng bus. ";
                                break;
                        }
                        res = string.Format("Card {1} : {0}",
                                               card_connection_err,
                                               SubID);
                        //   _Priority = "Lỗi nghiêm trọng";
                        break;
                    case 30:
                        //    _Priority = "Lỗi rất nghiêm trọng";
                        string memoryCardError = "";
                        switch (temp[0])
                        {
                            case 0:
                                memoryCardError += "Không có lỗi. ";
                                break;
                            case 1:
                                memoryCardError += "Không mở được file. ";
                                break;
                            case 2:
                                memoryCardError += "CRC không chính xác. ";
                                break;
                            case 3:
                                memoryCardError += "Số line lớn hơn 48. ";
                                break;
                            case 4:
                                memoryCardError += "Số zone lớn hơn 8. ";
                                break;
                            case 5:
                                memoryCardError += "Không tìm thấy dữ liệu. ";
                                break;
                            case 6:
                                memoryCardError += "Không thể truy xuất bộ nhớ EEPROM, do 1 task khác đang truy xuất dữ liệu trong EEPROM. ";
                                break;
                        }
                        break;
                    case 54:
                    case 55:
                    case 71:
                    case 72:
                    case 80:
                    case 90:
                    case 91:
                    case 100:
                    case 120:
                    case 130:
                    case 131:
                        break;
                    case 101:
                        res = string.Format("Kịch bản mới được áp dụng: {0}", SubID);
                        break;
                    case 102:
                        res = string.Format("Thời đoạn mới được áp dụng: {0}, thời điểm : {1}:{2}", SubID, Utilities.ConvertBCD2Hex(temp[1]), Utilities.ConvertBCD2Hex(temp[0]));
                        break;
                    case 103:
                        res = string.Format("Giản đồ mới được áp dụng: {0}", SubID);
                        break;
                    case 110:
                    case 111:
                    case 112:
                        switch (temp[0])
                        {
                            case 0xff:
                                res = "Bus bị treo";
                                break;
                            case 0xfe:
                                res = "Sai địa chỉ chip";
                                break;
                            case 0xfd:
                                res = "Sai địa chỉ thanh ghi";
                                break;
                        }
                        break;
                    case 121:
                        res += MaskBit(temp[0], 0) ? "SOH không hợp lệ. " : "";
                        res += MaskBit(temp[0], 1) ? "Block number không hợp lệ. " : "";
                        res += MaskBit(temp[0], 2) ? "Bù block number không hợp lệ. " : "";
                        res += MaskBit(temp[0], 4) ? "Ghi vào EEPROM bị lỗi. " : "";
                        res += MaskBit(temp[0], 5) ? "Timeout. " : "";
                        res += MaskBit(temp[0], 6) ? "Lỗi checksum. " : "";
                        res += MaskBit(temp[0], 7) ? "Không truy xuất được EEPROM. " : "";
                        break;
                    case 150:
                        res = string.Format("Kiểu điều khiển: {0}, chế độ điều khiển: {1}", ((TypeControl)SubID).ToString(), ((ModeControl)temp[0]).ToString());
                        break;
                }
                return res;
            }

        }
        public string Priority
        {
            get
            {
                string res = "";
                byte[] temp = new byte[4];
                temp = BitConverter.GetBytes(Parameter);
                switch (temp[3])
                {
                    case 0:
                        res = "Lỗi không nghiêm trọng";
                        break;
                    case 1:
                        res = "Lỗi ít nghiêm trọng";
                        break;
                    case 2:
                        res = "Lỗi nghiêm trọng";
                        break;
                    default:
                        res = "";
                        break;
                }
                return res;
            }
        }
        private bool MaskBit(byte data, byte bit)
        {
            bool res = false;
            if (((data >> bit) & 0x01) == 1) res = true;
            return res;
        }
    }

    public class StrLinkProfile
    {
        public int ControllerId;
        public int CurrentScenarioID;
        public string IP;
        public int Port;
        public DateTime CurrentTime;
        public string CurrentControlMode;
        public ControlModeInfo ModeInfo;
        public string CurrentControlType;
        public LineArray CurrentLineStatus;
        public PowerTimeStamp CurrentPowerTimeStamp;
        public WriteDataInfo ChangeDateInfo;
        public WriteDataInfo ChangeTODInfo;
        public TODInfo CurrentTOD;
        public bool IsConnect;
        public float NumberOfSendingKB;
        public float NumberOfRecevingKB;
        public byte[] ErrorContent;

        public DataSocket DataSocket;
        public List<byte> Buffer;
        public Frame PDU;
        public Dictionary<string, object> Data { get; set; }

        public Queue<LineArray> LineStatus;
        public Queue<DateTime> MCUTime;
        public Queue<string> ControlMode;
        public Queue<string> ControlType;
        public Queue<EventMessage> Event;
        public Queue<float> Temperature;
        public Queue<float> Source;
        public Queue<float> Battery;
        public Queue<int> ConnectionStatus;
        public Queue<PowerTimeStamp> PowerTimeStamp;
        public Queue<MCUIOStatus> IOStatus;
        public Queue<PowerLineCard>[] PLCStatus;
        public Queue<float>[] LightCurrent;
        public Queue<float>[] LightCurrentThreshold;
        public Queue<HMI> HMI;
        public Queue<SD> SD;
        public SDData SDData;
        public SDData EepromData;

        public BackgroundWorker ParserWorker;

        public StrLinkProfile()
        {
            this.ControllerId = 0;
            this.CurrentScenarioID = -1;
            this.IP = "";
            this.Port = 0;
            this.CurrentControlMode = "";
            this.CurrentControlType = "";
            this.CurrentTime = DateTime.Now;
            this.CurrentLineStatus = new LineArray();
            this.ModeInfo = new ControlModeInfo();
            this.CurrentPowerTimeStamp = new PowerTimeStamp();
            this.ChangeDateInfo = new WriteDataInfo();
            this.ChangeTODInfo = new WriteDataInfo();
            this.IsConnect = false;
            this.NumberOfSendingKB = 0;
            this.NumberOfRecevingKB = 0;
            this.ErrorContent = new byte[100];

            this.DataSocket = new DataSocket();
            this.Buffer = new List<byte>();
            this.PDU = new Frame();

            this.LineStatus = new Queue<LineArray>();
            this.MCUTime = new Queue<DateTime>();
            this.ControlMode = new Queue<string>();
            this.ControlType = new Queue<string>();
            this.Event = new Queue<EventMessage>();
            this.Temperature = new Queue<float>();
            this.Source = new Queue<float>();
            this.Battery = new Queue<float>();
            this.ConnectionStatus = new Queue<int>();
            this.PowerTimeStamp = new Queue<PowerTimeStamp>();
            this.IOStatus = new Queue<MCUIOStatus>();
            this.PLCStatus = new Queue<PowerLineCard>[8];
            for (int j = 0; j < this.PLCStatus.Length; j++)
            {
                this.PLCStatus[j] = new Queue<PowerLineCard>();
            }
            this.LightCurrent = new Queue<float>[64];
            this.LightCurrentThreshold = new Queue<float>[64];
            for (int j = 0; j < 64; j++)
            {
                this.LightCurrent[j] = new Queue<float>();
                this.LightCurrentThreshold[j] = new Queue<float>();
            }

            this.HMI = new Queue<HMI>();
            this.SD = new Queue<SD>();
            this.SDData = new SDData();
            this.EepromData = new SDData();
            this.CurrentTOD = new TODInfo();

            this.ParserWorker = new BackgroundWorker();

            Data = new Dictionary<string, object>();

            Data.Add("Connection", 0);
            Data.Add("ManualButton", null);
            Data.Add("HMIConnection", null);
            Data.Add("SDConnection", null);
            Data.Add("ControlMode", null);
            Data.Add("ControlType", null);
            Data.Add("Day", null);
            Data.Add("Month", null);
            Data.Add("Year", null);
            Data.Add("Hour", null);
            Data.Add("Minute", null);
            Data.Add("Second", null);
            Data.Add("ControllerId", null);
            Data.Add("HardwareVersion", null);
            Data.Add("FirmwareVersion", null);
            Data.Add("DownloadTime", null);
            Data.Add("OffTime", null);
            Data.Add("OnTime", null);
            Data.Add("CurrentScenarioId", null);
            Data.Add("CurrentTODId", null);

            Data.Add("SetTime", null);
            Data.Add("Flash", null);
            Data.Add("OffController", null);
            Data.Add("ChangePhase", null);
            Data.Add("Auto", null);
            Data.Add("Calib", null);

            Data.Add("CotrollerTime", null);
            Data.Add("PowerTimeStamp", null);
            Data.Add("ModeControl", null);
            Data.Add("CotrollerInfo", null);
            Data.Add("SourceVoltage", null);
            Data.Add("BatteryVoltage", null);
            Data.Add("Temperature", null);
            Data.Add("IOStatus", null);
            Data.Add("SDCardStatus", null);
            Data.Add("HMIStatus", null);
            Data.Add("CurrentTOD", null);
            Data.Add("Error", false);
            Data.Add("JunctionStatus", 0);

            for (int j = 0; j < 3; j++)
            {
                Data.Add(string.Format("ManualError.{0}", j), null);
            }

            for (int j = 0; j < 8; j++)
            {
                Data.Add(string.Format("CardAlive.{0}", j), null);
                Data.Add(string.Format("CardStatus.{0}", j), null);
                Data.Add(string.Format("PLCStatus.{0}", j), null);
                Data.Add(string.Format("Epprom.{0}", j), null);
            }

            for (int j = 0; j < 16; j++)
            {
                Data.Add(string.Format("Input.{0}", j), null);
                Data.Add(string.Format("Output.{0}", j), null);
            }

            for (int j = 0; j < 8; j++)
            {
                Data.Add(string.Format("CardError.{0}", j), null);
                for (int i = 0; i < 8; i++)
                {
                    Data.Add(string.Format("Current.{0}.{1}", j, i), null);
                    Data.Add(string.Format("Threshold.{0}.{1}", j, i), null);
                    Data.Add(string.Format("OutputControl.{0}.{1}", j, i), null);
                    Data.Add(string.Format("OutputFeedback.{0}.{1}", j, i), null);
                    Data.Add(string.Format("CardError.{0}.{1}", j, i), null);
                    Data.Add(string.Format("LighError.{0}.{1}", j, i), null); // card.light.error_index
                    for (int k = 0; k < 8; k++)
                    {
                        Data.Add(string.Format("LighError.{0}.{1}.{2}", j, i, k), null); // card.light.error_index
                    }

                }
            }
        }
    }

    public class PowerTimeStamp : MarshalByRefObject
    {
        public DateTime Time_On;
        public DateTime Time_Off;
    }

    public class MCUIOStatus : MarshalByRefObject
    {
        public byte Manual;
        public byte AliveCounter;
        public byte[] ManualConfig = new byte[4];
        public byte[] ManualConfigFb = new byte[4];
        public byte[] Input = new byte[2];
        public byte[] Output = new byte[2];
        public int Error;
    }

    public class PowerLineCard : MarshalByRefObject
    {
        public byte CardID;
        public byte State;  //
        public byte TryCnt; // ko su dung

        public byte CorruptCnt;	//trạng thái lỗi của dữ liệu
        public byte Alive;

        public byte CalibState;	//card có đang được calib?
        public byte PmbusStatus;	//trạng thái của I2C bus

        public byte LightsUsed;	//những đèn được sử dụng trên card
        public byte ChangedErrors; //if error state of a light is changed, a corresponding bit will be toggled // ko su dung

        public byte FbOutput; //the output of lights are got from cards // real ouput

        public byte CtlData;	//trạng thái điều khiển của CPU
        public byte FbCtlData; //the feedback of the control data

        public byte ErrorChanged;	//trạng thái điều khiển của CPU
        public byte CardError; //the feedback of the control data

        public byte Rsvd; //the feedback of the control data

        public byte[] LightError = new byte[8];	//lỗi hiện tại của từng đèn trên card
    }

    public class HMI : MarshalByRefObject
    {
        public HMIStatus Status;
        public int PMBus;
    }

    public class SD : MarshalByRefObject
    {
        public SDStatus Status;
        public SDError ErrorStatus;
    }

    public class SDData
    {
        private Dictionary<int, Queue<byte>> _Data;
        private int _Count;
        private System.Timers.Timer _Watchdog;
        private object _Locker { get; set; }

        public bool IsError;

        private int _FileSize;
        public int FileSize
        {
            get
            {
                return _FileSize;
            }
            set
            {
                _FileSize = value;
                if (_FileSize > 0)
                    _IsCompleteReading = false;
            }
        }

        private bool _IsCompleteReading = false;
        public bool IsCompleteReading
        {
            get
            {
                while (_IsCompleteReading == false) ;
                return _IsCompleteReading;
            }
            set
            {
                _IsCompleteReading = value;
                if (_IsCompleteReading == false)
                {
                    _Data.Clear();
                    FileSize = 0;
                    _Count = 0;
                }
            }
        }
        public SDData()
        {
            _Data = new Dictionary<int, Queue<byte>>();
            IsCompleteReading = false;
            _Count = 0;
            FileSize = 0;
            IsError = false;
            _Locker = new object();
            _Watchdog = new System.Timers.Timer();
            _Watchdog.Interval = 15000;
            _Watchdog.Elapsed += _Watchdog_Elapsed;
        }

        private void _Watchdog_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (FileSize != _Count)
            {
                IsError = true;
                IsCompleteReading = true;
            }
            _Watchdog.Enabled = false;
        }

        public List<byte> GetEntireData()
        {
            List<byte> res = new List<byte>();
            lock(_Locker)
            {
                foreach (int key in _Data.Keys)
                {
                    while (_Data[key].Count > 0)
                    {
                        try
                        {
                            res.Add(_Data[key].Dequeue());
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                IsCompleteReading = false;
                _Data.Clear();
            }
            return res;
        }

        public void FlushData(int blockNumber, byte[] data)
        {
            if (_Watchdog.Enabled == false)
            {
                _Watchdog.Enabled = true;
            }

            if (!_Data.ContainsKey(blockNumber))
            {
                _Data.Add(blockNumber, new Queue<byte>());

            }

            for (int j = 0; j < data.Length; j++)
            {
                _Data[blockNumber].Enqueue(data[j]);
            }

            _Count += data.Length;
            if (_Count >= FileSize)
            {
                IsCompleteReading = true;
            }
        }
    }

    public class ControlModeInfo : MarshalByRefObject
    {
        public NetModeCommand Mode;
        public bool IsWriteComplete;
        public int Error;
        // 0 : OK
        // -1 : Sai số xung
        // -2 : Sai chu kỳ mong muốn
        // -3 : Xung không nằm trong vùng biến đổi
    }

    public class WriteDataInfo
    {
        public bool IsWriteComplete = true;
        public int IsError = 0;
        //0: Thành công
        //0xFF: Bộ đệm đang bị khóa (do 1 lệnh đọc file khác đang sử dụng bộ đệm), hoặc dữ liệu ghi xuống không hợp lệ
        //0xFE: Không mở được file date.cfg
        //0xFD: Không tìm thấy ngày, tháng cần thay đổi
        //0xFC: Giá trị CRC không đúng
    }

    public class TODInfo : MarshalByRefObject
    {
        public int TODID;
        public byte Hour;
        public byte Min;
        public TypeControl Type;

        public int DiagramID;
        public int Offset;
        public int NumberOfZone;
        public List<int> Pulses;

        public TODInfo()
        {
            TODID = -1;
            Hour = 0;
            Min = 0;
            Type = TypeControl.Off;

            DiagramID = 0;
            NumberOfZone = 0;
            Offset = 0;
            Pulses = new List<int>();
        }
    }

    public class DiagramInfo
    {
        public int DiagramID;
        public int NumberOfLine;
        public int NumberOfZone;
        public int Cycle;
        public List<LineInfo> Lines = new List<LineInfo>();
        public List<int> StartZone = new List<int>();
        public List<int> EndZone = new List<int>();
    }

    public class LineInfo
    {
        public int LineID;
        public List<int> GreenOn = new List<int>();
        public List<int> GreenOff = new List<int>();
    }

    public class LineHardware
    {
        public byte LineID;
        public LightType Type;
        public byte CardID;
        public byte GreenLightPositionInPowerCard;
        public byte MonitorState;
        public int LenthOfYellowTime;
    }

    public class OperationDate
    {
        public OperationDateType DateType { get; set; }
        public byte SpecialDay { get; set; }
        public byte SpecialMonth { get; set; }
        public byte ScenarioId { get; set; }
    }
    #endregion

    public class AppDriver : MarshalByRefObject, DriverCommon.ITLCDriver
    {
        public Dictionary<int, StrLinkProfile> BoxList;

        //   private string _Version = "VDK Server V3.0.2"; // updated 3-10-2014
        //    private string _Version = "VDK Server V3.0.3"; // updated 29-10-2014
        //  private string _Version = "VDK Server V3.0.4"; // updated 26-11-2014
        // private string _Version = "VDK Server V3.0.5"; // updated 7-1-2015
      //  private string _Version = "VDK Server V3.0.6"; // updated 14-1-2015
    //    private string _Version = "VDK Server V3.0.7"; // updated 21-1-2015 : optimize CPU usage, no use background worker anymore
        private string _Version = "VDK Server V3.0.8"; // updated 3-2-2015 : fix socket error
        private TCPIPServer _Server { get; set; }
        private CompState _State { get; set; }

        public AppDriver()
        {
            _State = CompState.Idle;
            BoxList = new Dictionary<int, StrLinkProfile>();

            _Server = new TCPIPServer();
            _Server.RaiseDataComeEvent += new TCPIPServer.DataEventHandler(Server_RaiseDataComeEvent);
            _Server.RaiseSocketClosedEvent += new TCPIPServer.SocketClosedEventHandler(Server_RaiseSocketClosedEvent);
            _Server.RaiseRegistrySocketEvent += new TCPIPServer.RegistrySocketEventHandler(Server_RaiseRegistrySocketEvent);
        }
        
        private void ParseData(StrLinkProfile box)
        {
            bool isValid = true; 
            if (box != null)
            {
                while (isValid)
                {
                    switch (box.PDU.ParserState)
                    {
                        case ParserState.ParsingHeader:
                            if (box.Buffer.Count >= 5)
                            {
                                string temp;
                                lock (box)
                                {
                                    temp = Encoding.ASCII.GetString(box.Buffer.Take(3).ToArray());
                                    if (temp == "MSG")
                                    {
                                        box.PDU.Header = new MsgHeader();
                                        box.PDU.Header.ParseHeader(box.Buffer.Take(5).ToArray());
                                        box.Buffer.RemoveRange(0, 5);
                                        box.PDU.ParserState = ParserState.ParsingBody;
                                    }
                                    else
                                    {
                                        box.Buffer.RemoveAt(0);
                                    }
                                }
                            }
                            else
                            {
                                isValid = false;
                            }
                            break;
                        case ParserState.ParsingBody:
                            lock (box)
                            {
                                if (box.Buffer.Count >= box.PDU.Header.Lenght)
                                {
                                    box.PDU.Body = new MsgBody();
                                    box.PDU.Body.Data.AddRange(box.Buffer.Take(box.PDU.Header.Lenght).ToArray());
                                    box.Buffer.RemoveRange(0, box.PDU.Header.Lenght);
                                    box.PDU.ParserState = ParserState.ParsingCRC;
                                }
                                else
                                {
                                    isValid = false;
                                }
                            }
                            break;
                        case ParserState.ParsingCRC:
                            lock (box)
                            {
                                if (box.Buffer.Count >= 2)
                                {
                                    box.PDU.CRC = new MsgCRC();
                                    box.PDU.CRC.Data.AddRange(box.Buffer.Take(2).ToArray());
                                    bool isCRCCorrect = box.PDU.CheckCRC();
                                    // check CRC
                                    if (isCRCCorrect)
                                    {
                                        box.PDU.ParserState = ParserState.ParsingData;
                                    }
                                    else
                                    {
                                        box.PDU.ParserState = ParserState.ParsingHeader;
                                    }
                                    box.Buffer.RemoveRange(0, 2);
                                }
                                else
                                {
                                    isValid = false;
                                }
                            }
                            break;
                        case ParserState.ParsingData:
                            ParseData_Master(box);
                            box.PDU.ParserState = ParserState.ParsingHeader;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        #region event
        private void Server_RaiseRegistrySocketEvent(object sender, SocketEventArgs a)
        {
            int port = a.Socket.Port;
            if (BoxList.ContainsKey(port))
            {
                if (BoxList[port] == null)
                {
                    StrLinkProfile newBox = new StrLinkProfile();
                    newBox.DataSocket = a.Socket;
                    //     newBox.ConnectionStatus.Enqueue((int)JunctionStatus.Connect);
                    newBox.Data["Connection"] = 1; // connect
                    newBox.Data["JunctionStatus"] = 1; // connect
                    newBox.Port = port;
                    newBox.IsConnect = true;
                    BoxList[newBox.Port] = newBox;
                    Thread.Sleep(1000);
                    ReadControllerInfo(newBox.Port);
                    Common.Logger.Log(string.Format("AppDriver new connection: {0}", port));
                }
                else
                {
                    BoxList[port].DataSocket = a.Socket;
                    BoxList[port].IsConnect = true;
                    //      BoxList[port].ConnectionStatus.Enqueue((int)JunctionStatus.Connect);
                    BoxList[port].Data["Connection"] = 1; // connect
                    BoxList[port].Data["JunctionStatus"] = 1; // connect
                    Common.Logger.Log(string.Format("AppDriver reconnection: {0}", port));
                }
            }
        }
        private void Server_RaiseSocketClosedEvent(object sender, SocketEventArgs a)
        {
            // remove box
            StrLinkProfile box = FindBoxByPort(a.Socket.Port);
            //     box.ConnectionStatus.Enqueue((int)JunctionStatus.Disconnect);
            box.Data["Connection"] = 0; // disconnect
            box.Data["JunctionStatus"] = 0; // disconnect
            box.IsConnect = false;
            Common.Logger.Log(string.Format("AppDriver disconnection: {0}", a.Socket.Port));
        }
        private void Server_RaiseDataComeEvent(object sender, DataComeEventArgs a)
        {
            // enqueue data
            StrLinkProfile linkProfile = FindBoxByPort(a.Socket.Port);
            lock (linkProfile)
            {
                linkProfile.IsConnect = true;
                linkProfile.Buffer.AddRange(a.Data);
                linkProfile.NumberOfRecevingKB += (float)a.Data.Length / 1024;
                ParseData(linkProfile);
                if(a.Socket.Port == 2048)
                {
                    string temp = string.Join(",", a.Data);
                  //  Common.Logger.LogRequest(temp);
                }
               
            }

           
        }
        #endregion

        #region read data
        private void ReadTagValue(int port, string address)
        {
            switch (address.ToLower().Trim())
            {
                case "id":
                    ReadControllerInfo(port);
                    break;
                case "line":
                    ReadLineStatus(port);
                    break;
                case "time":
                    ReadTime(port);
                    break;
                case "temparature":
                    ReadTemperature(port);
                    break;
                case "source":
                    ReadSourceVoltage(port);
                    break;
                case "battery":
                    ReadBatteryVoltage(port);
                    break;
                case "controlmode":
                case "controltype":
                    ReadControlMode(port);
                    break;
            }

        }
        private void ReadControllerInfo(int port)
        {
            ReadData(port, (byte)eCommandID.ReadControllerInfo);
        }
        private void ReadLineStatus(int port)
        {
            ReadData(port, (byte)eCommandID.ReadLineStatus);
        }
        private void ReadTime(int port)
        {
            ReadData(port, (byte)eCommandID.ReadTime);
        }
        private void ReadTemperature(int port)
        {
            ReadData(port, (byte)eCommandID.ReadTemp);
        }
        private void ReadSourceVoltage(int port)
        {
            ReadData(port, (byte)eCommandID.ReadSourceVoltage);
        }
        private void ReadBatteryVoltage(int port)
        {
            ReadData(port, (byte)eCommandID.ReadBatteryVoltage);
        }
        private void ReadControlMode(int port)
        {
            ReadData(port, (byte)eCommandID.ReadModeControl);
        }
        private void ReadPowerTimeStamp(int port)
        {
            ReadData(port, (byte)eCommandID.ReadPowerTimeStamp);
        }
        private void ReadIOStatus(int port)
        {
            ReadData(port, (byte)eCommandID.ReadIO);
        }
        private void ReadPLCStatus(int port, byte cardIndex)
        {
            ReadData(port, (byte)eCommandID.ReadPLCStatus, new byte[] { cardIndex });
        }
        private void ReadLightCurrent(int port, byte cardIndex, byte lightIndex)
        {
            ReadData(port, (byte)eCommandID.ReadLightCurrent, new byte[] { cardIndex, lightIndex });
        }
        private void ReadLightCurrentThreshold(int port, byte cardIndex, byte lightIndex)
        {
            ReadData(port, (byte)eCommandID.ReadThresholdCurrent, new byte[] { cardIndex, lightIndex });
        }
        private void ReadHMIStatus(int port)
        {
            ReadData(port, (byte)eCommandID.ReadHMIStatus);
        }
        private void ReadSDStatus(int port)
        {
            ReadData(port, (byte)eCommandID.ReadSDCardStatus);
        }
        private void ReadSDLine(int port, byte day, byte month)
        {
            string fileName = string.Format("{0}_{1}.dat\0", day.ToString("00"), month.ToString("00"));
            byte[] param = Encoding.ASCII.GetBytes(fileName);
            ReadData(port, (byte)eCommandID.ReadFileSize, param);
            ReadData(port, (byte)eCommandID.ReadAllData, param);
        }
        private void ReadEeprom(int port, string fileName)
        {
            byte[] param = Encoding.ASCII.GetBytes(fileName);
            ReadData(port, (byte)eCommandID.ReadEepromFileSize, param);
            Thread.Sleep(500);
            ReadData(port, (byte)eCommandID.ReadEepromFile, param);
        }
        private void ReadSDEvent(int port)
        {
            string fileName = string.Format("Event.dat\0");
            byte[] param = Encoding.ASCII.GetBytes(fileName);
            ReadData(port, (byte)eCommandID.ReadFileSize, param);
            ReadData(port, (byte)eCommandID.ReadAllData, param);
        }
        private void ReadCurrentScenarioID(int port)
        {
            ReadData(port, (byte)eCommandID.ReadCurrentScenarioID);
        }
        private void ReadCurrentTOD(int port)
        {
            ReadData(port, (byte)eCommandID.ReadCurrentTOD);
        }

        private void ReadErrorContent(int port, byte address)
        {
            ReadData(port, (byte)eCommandID.ReadErrorContent, new byte[] { address });
        }
        private void ReadData(int port, byte command)
        {
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    byte[] Cmd = new byte[5];
                    Cmd[0] = (byte)'M';
                    Cmd[1] = (byte)'S';
                    Cmd[2] = (byte)'G';
                    Cmd[3] = command;
                    Cmd[4] = 0;
                    byte[] temp = AddCRC(Cmd);
                    _Server.SendCmd(port, temp);
                    profile.NumberOfSendingKB += (float)temp.Length / 1024;
                }
            }
        }
        private void ReadData(int port, byte command, byte[] param)
        {
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    byte[] Cmd = new byte[5 + param.Length];
                    Cmd[0] = (byte)'M';
                    Cmd[1] = (byte)'S';
                    Cmd[2] = (byte)'G';
                    Cmd[3] = command;
                    Cmd[4] = (byte)param.Length;
                    for (int j = 0; j < param.Length; j++)
                    {
                        Cmd[5 + j] = param[j];
                    }
                    byte[] temp = AddCRC(Cmd);
                    _Server.SendCmd(port, temp);
                    profile.NumberOfSendingKB += (float)temp.Length / 1024;
                }
            }
        }
        #endregion

        #region write data
        private void WriteModeControl(int port, byte mode)
        {
            ReadData(port, (byte)eCommandID.ChangeModeControl, new byte[] { mode });
        }
        private void WriteTime(int port, DateTime time)
        {
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    CultureInfo enUS = new CultureInfo("en-US");
                    string strTime = string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                                                time.Month.ToString("00"),
                                                time.Day.ToString("00"),
                                                time.Year.ToString(),
                                                time.Hour.ToString("00"),
                                                time.Minute.ToString("00"),
                                                time.Second.ToString("00"));
                    DateTime t = new DateTime();
                    DateTime.TryParseExact(strTime, "MM/dd/yyyy HH:mm:ss", enUS, System.Globalization.DateTimeStyles.None, out t);

                    int len = 8;
                    byte[] Cmd = new byte[5 + len];
                    Cmd[0] = (byte)'M';
                    Cmd[1] = (byte)'S';
                    Cmd[2] = (byte)'G';
                    Cmd[3] = (byte)eCommandID.WriteTime;
                    Cmd[4] = (byte)len;

                    Cmd[5] = Utilities.ConvertHex2BCD(t.Year);
                    Cmd[6] = 0;
                    Cmd[7] = Utilities.ConvertHex2BCD(t.Day);
                    Cmd[8] = Utilities.ConvertHex2BCD(t.Month);
                    Cmd[9] = Utilities.ConvertHex2BCD(t.Hour);
                    Cmd[10] = Utilities.ConvertHex2BCD((int)t.DayOfWeek);
                    Cmd[11] = Utilities.ConvertHex2BCD(t.Second);
                    Cmd[12] = Utilities.ConvertHex2BCD(t.Minute);

                    _Server.SendCmd(port, AddCRC(Cmd));
                }
            }
        }
        private void WriteIO(int port, byte[] data)
        {
            // 1st byte: the sequence of ouput, 2nd: on=1, off=0
            ReadData(port, (byte)eCommandID.WriteIO, data);
        }
        private void WriteDateConfig(int port, byte[] data)
        {
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    profile.ChangeDateInfo.IsWriteComplete = false;
                    ReadData(port, (byte)eCommandID.ChangeDateConfig, data);
                }
            }

        }
        private void WriteTODConfig(int port, byte[] data)
        {
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    profile.ChangeTODInfo.IsWriteComplete = false;
                    ReadData(port, (byte)eCommandID.ChangeTODConfig, data);
                }
            }

        }
        private void WriteReset(int port)
        {
            ReadData(port, (byte)eCommandID.Reset);
        }
        private void WriteCurrentThreshod(int port, byte[] data)
        {
            ReadData(port, (byte)eCommandID.WriteThresholdCurrent, data);
        }
        #endregion

        #region get data from server
        private bool GetDataFromMemoryMap(int port, string address, out object data)
        {
            bool res = false;
            data = new object();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data.ContainsKey(address))
                    {
                        if (profile.Data[address] != null)
                        {
                            data = profile.Data[address];
                            res = true;
                        }
                    }
                }
            }
            return res;
        }

        #region no use anymore
        private bool GetControllerID(int port, out int controllerId)
        {
            bool res = false;
            controllerId = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data["ControllerId"] != null)
                    {
                        controllerId = profile.ControllerId;
                        res = true;
                    }

                }
            }
            return res;
        }
        private bool GetControlMode(int port, out int controlMode)
        {
            bool res = false;
            controlMode = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data["ControlMode"] != null)
                    {
                        controlMode = (int)profile.Data["ControlMode"];
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetControlType(int port, out int controlType)
        {
            bool res = false;
            controlType = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data["ControlType"] != null)
                    {
                        controlType = (int)profile.Data["ControlType"];
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetTemparature(int port, out float temparature)
        {
            bool res = false;
            temparature = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data["Temperature"] != null)
                    {
                        temparature = (float)profile.Data["Temperature"];
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetSourceVoltage(int port, out float source)
        {
            bool res = false;
            source = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data["SourceVoltage"] != null)
                    {
                        source = (float)profile.Data["SourceVoltage"];
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetBatteryVoltage(int port, out float battery)
        {
            bool res = false;
            battery = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data["BatteryVoltage"] != null)
                    {
                        battery = (float)profile.Data["BatteryVoltage"];
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetConnectionStatus(int port, out int connection)
        {
            bool res = false;
            connection = (int)JunctionStatus.Disconnect;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data["Connection"] != null)
                    {
                        connection = (int)profile.Data["Connection"];
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetPowerTimeOn(int port, out DateTime time)
        {
            bool res = false;
            time = new DateTime();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data["OnTime"] != null)
                    {
                        time = (DateTime)profile.Data["OnTime"];
                    }
                    res = true;
                }
            }
            return res;
        }
        private bool GetPowerTimeOff(int port, out DateTime time)
        {
            bool res = false;
            time = new DateTime();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Data["OffTime"] != null)
                    {
                        time = (DateTime)profile.Data["OffTime"];
                    }
                    res = true;
                }
            }
            return res;
        }
        private bool GetCurrentScenarioID(int port, out int CurrentScenarioID)
        {
            bool res = false;
            CurrentScenarioID = -1;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    CurrentScenarioID = profile.CurrentScenarioID;
                    res = true;
                }
            }
            return res;
        }
        private bool GetMCUTime(int port, out DateTime date)
        {
            bool res = false;
            date = DateTime.Now;
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.MCUTime.Count > 0)
                    {
                        date = profile.MCUTime.Dequeue();
                        profile.CurrentTime = date;
                        res = true;
                    }
                    else
                    {

                        date = profile.CurrentTime;
                    }
                }
            }
            return res;
        }
        private bool GetLineStatus(int port, out LineArray allLine)
        {
            bool res = false;
            allLine = new LineArray();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.LineStatus.Count > 0)
                    {
                        profile.CurrentLineStatus = profile.LineStatus.Dequeue();
                    }

                    allLine = profile.CurrentLineStatus;
                    res = true;
                }
            }
            return res;
        }
        private bool GetDeviceStatus(int port, out byte status)
        {
            bool res = true;
            status = 0;
            byte controlMode = 0;
            byte controlType = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    switch (profile.CurrentControlType)
                    {
                        case "Giản đồ":
                            controlType = 1;
                            break;
                        case "Chớp vàng":
                            controlType = 2;
                            break;
                        case "Tất cả đỏ":
                            controlType = 3;
                            break;
                        case "Tắt tủ":
                            controlType = 4;
                            break;
                    }
                    switch (profile.CurrentControlMode)
                    {
                        case "Tự động":
                            controlMode = 1;
                            break;
                        case "Bằng tay":
                            controlMode = 2;
                            break;
                        case "Qua mạng":
                            controlMode = 3;
                            break;
                        case "Phối hợp":
                            controlMode = 3;
                            controlType = 5;
                            break;
                        case "An toàn":
                            controlMode = 4;
                            break;
                        case "Hiệu chỉnh":
                            controlMode = 5;
                            break;
                    }
                    bool isError = false;

                    if (profile.CurrentLineStatus.AllLines != null)
                    {
                        for (int j = 0; j < profile.CurrentLineStatus.AllLines.Count; j++)
                        {
                            isError = isError || profile.CurrentLineStatus.AllLines[j].IsError;
                        }
                    }

                    if (isError == false)
                    {
                        status = (byte)(controlMode * 16 + controlType);
                    }
                    else
                    {
                        status = 0xff;
                    }
                }
            }

            return res;
        }
        private bool GetPowerTimeStamp(int port, out PowerTimeStamp pts)
        {
            bool res = false;
            pts = new PowerTimeStamp();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.PowerTimeStamp.Count > 0)
                    {
                        profile.CurrentPowerTimeStamp = profile.PowerTimeStamp.Dequeue();
                    }
                    pts = profile.CurrentPowerTimeStamp;
                    res = true;
                }
            }
            return res;
        }
        private bool GetIOStatus(int port, out MCUIOStatus ioStatus)
        {
            bool res = false;
            ioStatus = new MCUIOStatus();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.IOStatus.Count > 0)
                    {
                        ioStatus = profile.IOStatus.Dequeue();
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetPLCStatus(int port, out PowerLineCard plcStatus, int cardIndex)
        {
            bool res = false;
            plcStatus = new PowerLineCard();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.PLCStatus[cardIndex].Count > 0)
                    {
                        plcStatus = profile.PLCStatus[cardIndex].Dequeue();
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetLightCurrent(int port, out float lightCurrent, int cardIndex, int lightIndex)
        {
            bool res = false;
            lightCurrent = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    int index = cardIndex * 8 + lightIndex;
                    if (profile.LightCurrent[index].Count > 0)
                    {
                        lightCurrent = profile.LightCurrent[index].Dequeue();
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetLightCurrentThreshold(int port, out float lightCurrent, int cardIndex, int lightIndex)
        {
            bool res = false;
            lightCurrent = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    int index = cardIndex * 8 + lightIndex;
                    if (profile.LightCurrentThreshold[index].Count > 0)
                    {
                        lightCurrent = profile.LightCurrentThreshold[index].Dequeue();
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetHMIStatus(int port, out HMI hmi)
        {
            bool res = false;
            hmi = new HMI();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.HMI.Count > 0)
                    {
                        hmi = profile.HMI.Dequeue();
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetSDStatus(int port, out SD sd)
        {
            bool res = false;
            sd = new SD();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.SD.Count > 0)
                    {
                        sd = profile.SD.Dequeue();
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetSDLineDataFromSD(int port, out List<byte> data)
        {
            bool res = false;
            data = new List<byte>();
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.SDData.IsCompleteReading)
                    {
                        data = profile.SDData.GetEntireData();
                        res = !profile.SDData.IsError;
                        profile.SDData.IsCompleteReading = false;

                    }
                }
            }

            return res;
        }
        private bool GetSDEventFromSD(int port, out List<byte> data)
        {
            bool res = false;
            data = new List<byte>();
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.SDData.IsCompleteReading)
                    {
                        data = profile.SDData.GetEntireData();
                        res = !profile.SDData.IsError;
                        profile.SDData.IsCompleteReading = false;

                    }
                }
            }
            return res;
        }
        private bool GetFileFromEeprom(int port, out List<byte> data)
        {
            bool res = false;
            data = new List<byte>();
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.EepromData.IsCompleteReading)
                    {
                        data = profile.EepromData.GetEntireData();
                        res = !profile.EepromData.IsError;
                        profile.EepromData.IsCompleteReading = false;
                    }
                }
            }
            return res;
        }
        private bool GetEvent(int port, out  EventMessage data)
        {
            bool res = false;
            data = new EventMessage();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.Event.Count > 0)
                    {
                        data = profile.Event.Dequeue();
                        res = true;
                    }
                }
            }
            return res;
        }
        private bool GetCurrentTOD(int port, out TODInfo TOD)
        {
            bool res = false;
            TOD = new TODInfo();

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    TOD = profile.CurrentTOD;
                    res = true;
                }
            }
            return res;
        }
        private bool GetErrorContent(int port, int index, out byte error)
        {
            bool res = false;
            error = 0;

            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    if (profile.ErrorContent.Length > index)
                    {
                        error = profile.ErrorContent[index];
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }

                }
            }
            return res;
        }
        private int GetError(int port)
        {
            int res = 0;
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    for (int j = 0; j < profile.ErrorContent.Length; j++)
                    {
                        res = res | profile.ErrorContent[j];
                    }
                }
            }
            return res;
        }
        #endregion

        #endregion

        #region ultilities
        private StrLinkProfile FindBoxByPort(int port)
        {
            StrLinkProfile result = null;
            if (BoxList.ContainsKey(port))
            {
                result = BoxList[port];
            }
            return result;
        }
        private byte[] AddCRC(byte[] data)
        {
            lock (BoxList)
            {
                byte[] res = new byte[data.Length + 2];
                data.CopyTo(res, 0);
                ushort CRC = Utilities.CRC_Final(Utilities.CRC_ByteArray(data, data.Length, 0));

                res[res.Length - 2] = (byte)((CRC & 0x00FF));
                res[res.Length - 1] = (byte)((CRC & 0xFF00) >> 8);
                return res;
            }
        }


        #endregion

        #region parse data
        private void ParseData_Master(StrLinkProfile profile)
        {
            switch (profile.PDU.Header.ID)
            {
                case (byte)eCommandID.ReadControllerInfo:
                    ParseData_ControllerInfo(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.Event:
                    ParseData_EVT(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadTime:
                    ParseData_Time(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadLineStatus:
                    ParseData_LineStatus(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadModeControl:
                    ParseData_ControlMode(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ChangeModeControl:
                    ParseData_ChangeControlMode(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadTemp:
                    ParseData_Temperature(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadSourceVoltage:
                    ParseData_Source(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadBatteryVoltage:
                    ParseData_Battery(profile, profile.PDU.Body.Data.ToArray());
                    break;

                case (byte)eCommandID.ReadPowerTimeStamp:
                    ParseData_PowerTimeStamp(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadIO:
                    ParseData_IOStatus(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadPLCStatus:
                    ParseData_PLCStatus(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadLightCurrent:
                    ParseData_LightCurrent(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadHMIStatus:
                    ParseData_HMI(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadSDCardStatus:
                    ParseData_SD(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadThresholdCurrent:
                    ParseData_LightCurrentThreshold(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadFileSize:
                    ParseData_FileSizeFromSD(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadAllData:
                    ParseData_DataFromSD(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ChangeDateConfig:
                    ParseData_ChangeDateConfig(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ChangeTODConfig:
                    ParseData_ChangeTODConfig(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadCurrentScenarioID:
                    ParseData_CurrentScenarioID(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadCurrentTOD:
                    ParseData_TODInfo(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadEepromFile:
                    ParseData_DataFromEeprom(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadEepromFileSize:
                    ParseData_FileSizeFromEeprom(profile, profile.PDU.Body.Data.ToArray());
                    break;
                case (byte)eCommandID.ReadErrorContent:
                    ParseData_ErrorContent(profile, profile.PDU.Body.Data.ToArray());
                    break;
            }
        }

        #region no use any more
        private void ParseData_EVT(StrLinkProfile profile, byte[] data)
        {
            // check data lenth
            if (data.Length < 8) return;

            // parse data
            EventMessage mes = new EventMessage();

            CultureInfo enUS = new CultureInfo("en-US");
            string time = string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                                        Utilities.ConvertBCD2Hex(data[2]).ToString("00"),
                                        Utilities.ConvertBCD2Hex(data[1]).ToString("00"),
                                        "20" + Utilities.ConvertBCD2Hex(data[0]).ToString("00"),
                                        Utilities.ConvertBCD2Hex(data[3]).ToString("00"),
                                        Utilities.ConvertBCD2Hex(data[4]).ToString("00"),
                                        Utilities.ConvertBCD2Hex(data[5]).ToString("00"));
            DateTime temp = new DateTime();
            DateTime.TryParseExact(time, "dd/MM/yyyy HH:mm:ss", enUS, System.Globalization.DateTimeStyles.None, out temp);
            mes.Time = temp;

            mes.ID = data[6];
            mes.SubID = data[7];

            mes.Parameter = BitConverter.ToInt32(data, 8);
            profile.Event.Enqueue(mes);
        }
        private void ParseData_LineStatus(StrLinkProfile profile, byte[] data)
        {
            if (data.Length > 0)
            {
                byte numberOfLine = data[0];
                LineArray allLine = new LineArray();

                for (int j = 0, i = 1; j < numberOfLine; j++)
                {
                    LineStatus line = new LineStatus();
                    line.ID = data[i++];
                    line.Type = data[i++];
                    line.State = data[i++];
                    line.FbState = (byte)(data[i++] & 0x7F);
                    allLine.AllLines.Add(line);
                }
                profile.LineStatus.Enqueue(allLine);
            }
        }
        #endregion

        private void ParseData_ControllerInfo(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 20)
            {
                profile.ControllerId = data[1] * 256 + data[0];

                #region new memory map
                profile.Data["ControllerId"] = data[1] * 256 + data[0];
                profile.Data["FirmwareVersion"] = string.Format("{0}.{1}", data[10], data[11]);
                profile.Data["HardwareVersion"] = string.Format("{0}.{1}", data[12], data[13]);

                CultureInfo enUS = new CultureInfo("en-US");
                string time = string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                                           data[15].ToString("00"),
                                           data[14].ToString("00"),
                                           (data[16] + 2000).ToString(),
                                           data[17].ToString("00"),
                                           data[18].ToString("00"),
                                           data[19].ToString("00"));
                DateTime downloadTime = new DateTime();
                DateTime.TryParseExact(time, "MM/dd/yyyy HH:mm:ss", enUS, System.Globalization.DateTimeStyles.None, out downloadTime);
                profile.Data["DownloadTime"] = downloadTime;
                #endregion
            }
        }
        private void ParseData_Time(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 8)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                int year = Utilities.ConvertBCD2Hex(data[0]) + 2000;
                byte month = Utilities.ConvertBCD2Hex(data[3]);
                byte day = Utilities.ConvertBCD2Hex(data[2]);
                byte hour = Utilities.ConvertBCD2Hex(data[4]);
                byte min = Utilities.ConvertBCD2Hex(data[7]);
                byte sec = Utilities.ConvertBCD2Hex(data[6]);
                byte dayOfweek = Utilities.ConvertBCD2Hex(data[5]);

                string time = string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                                            month.ToString("00"),
                                            day.ToString("00"),
                                            year.ToString(),
                                            hour.ToString("00"),
                                            min.ToString("00"),
                                            sec.ToString("00"));
                DateTime t = new DateTime();
                DateTime.TryParseExact(time, "MM/dd/yyyy HH:mm:ss", enUS, System.Globalization.DateTimeStyles.None, out t);
                //  profile.MCUTime.Enqueue(t);

                #region new memory map
                profile.Data["Day"] = (int)day;
                profile.Data["Month"] = (int)month;
                profile.Data["Year"] = (int)year;
                profile.Data["Hour"] = (int)hour;
                profile.Data["Minute"] = (int)min;
                profile.Data["Second"] = (int)sec;
                profile.Data["CotrollerTime"] = t;
                #endregion
            }
        }
        private void ParseData_PowerTimeStamp(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 16)
            {
                PowerTimeStamp pts = new PowerTimeStamp();
                pts.Time_Off = new DateTime();
                pts.Time_On = new DateTime();

                // time on
                CultureInfo enUS = new CultureInfo("en-US");
                int year = Utilities.ConvertBCD2Hex(data[0]) + 2000;
                byte month = Utilities.ConvertBCD2Hex(data[3]);
                byte day = Utilities.ConvertBCD2Hex(data[2]);
                byte hour = Utilities.ConvertBCD2Hex(data[4]);
                byte min = Utilities.ConvertBCD2Hex(data[7]);
                byte sec = Utilities.ConvertBCD2Hex(data[6]);
                byte dayOfweek = Utilities.ConvertBCD2Hex(data[5]);

                string time = string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                                            month.ToString("00"),
                                            day.ToString("00"),
                                            year.ToString(),
                                            hour.ToString("00"),
                                            min.ToString("00"),
                                            sec.ToString("00"));


                DateTime.TryParseExact(time, "MM/dd/yyyy HH:mm:ss", enUS, System.Globalization.DateTimeStyles.None, out pts.Time_On);

                // time off
                year = Utilities.ConvertBCD2Hex(data[8]) + 2000;
                month = Utilities.ConvertBCD2Hex(data[11]);
                day = Utilities.ConvertBCD2Hex(data[10]);
                hour = Utilities.ConvertBCD2Hex(data[12]);
                min = Utilities.ConvertBCD2Hex(data[15]);
                sec = Utilities.ConvertBCD2Hex(data[14]);
                dayOfweek = Utilities.ConvertBCD2Hex(data[13]);

                time = string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                                           month.ToString("00"),
                                           day.ToString("00"),
                                           year.ToString(),
                                           hour.ToString("00"),
                                           min.ToString("00"),
                                           sec.ToString("00"));

                DateTime.TryParseExact(time, "MM/dd/yyyy HH:mm:ss", enUS, System.Globalization.DateTimeStyles.None, out pts.Time_Off);

                //   profile.PowerTimeStamp.Enqueue(pts);

                #region new memory map
                profile.Data["PowerTimeStamp"] = pts;
                profile.Data["OffTime"] = pts.Time_Off;
                profile.Data["OnTime"] = pts.Time_On;
                #endregion
            }

        }
        private void ParseData_ControlMode(StrLinkProfile profile, byte[] data)
        {
            #region new memory map
            if (data.Length >= 2)
            {
                switch (data[1])
                {
                    case (byte)ModeControl.Auto:
                        profile.Data["Flash"] = 0;
                        profile.Data["OffController"] = 0;
                        profile.Data["ChangePhase"] = 0;
                        profile.Data["Auto"] = 1;
                        profile.Data["Calib"] = 0;
                        break;
                    case (byte)ModeControl.Calib:
                        profile.Data["Flash"] = 0;
                        profile.Data["OffController"] = 0;
                        profile.Data["ChangePhase"] = 0;
                        profile.Data["Auto"] = 0;
                        profile.Data["Calib"] = 1;
                        break;
                    case (byte)ModeControl.Manual:
                        break;
                    case (byte)ModeControl.Remote:
                        switch (data[0])
                        {
                            case (byte)TypeControl.Color:
                                profile.Data["Flash"] = 0;
                                profile.Data["OffController"] = 0;
                                profile.Data["ChangePhase"] = 1;
                                profile.Data["Auto"] = 0;
                                profile.Data["Calib"] = 0;
                                break;
                            case (byte)TypeControl.Flash:
                                profile.Data["Flash"] = 1;
                                profile.Data["OffController"] = 0;
                                profile.Data["ChangePhase"] = 0;
                                profile.Data["Auto"] = 0;
                                profile.Data["Calib"] = 0;
                                break;
                            case (byte)TypeControl.Off:
                                profile.Data["Flash"] = 0;
                                profile.Data["OffController"] = 1;
                                profile.Data["ChangePhase"] = 0;
                                profile.Data["Auto"] = 0;
                                profile.Data["Calib"] = 0;
                                break;
                            default:
                                break;
                        }
                        break;
                    case (byte)ModeControl.Safe:
                        break;
                    default:
                        break;
                }

                profile.Data["ControlType"] = data[0];
                profile.Data["ControlMode"] = data[1];
                profile.Data["ModeControl"] = data;
            #endregion
            }
        }
        private void ParseData_Source(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 2)
            {
                float temp = (float)(data[1] * 100 + data[0]) / 100;
                //  profile.Source.Enqueue(temp);

                #region new memory map
                profile.Data["SourceVoltage"] = temp;
                #endregion
            }
        }
        private void ParseData_Battery(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 2)
            {
                float temp = (float)(data[1] * 100 + data[0]) / 100;
                //   profile.Battery.Enqueue(temp);

                #region new memory map
                profile.Data["BatteryVoltage"] = temp;
                #endregion
            }
        }
        private void ParseData_Temperature(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 2)
            {
                float temp = (float)(data[1] * 100 + data[0]) / 100;
                //  profile.Temperature.Enqueue(temp);

                #region new memory map
                profile.Data["Temperature"] = temp;
                #endregion
            }
        }
        private void ParseData_IOStatus(StrLinkProfile profile, byte[] data)
        {
            if (data.Length == 16)
            {
                MCUIOStatus ioStatus = new MCUIOStatus();
                ioStatus.Manual = data[0];
                ioStatus.AliveCounter = data[1];
                ioStatus.ManualConfig = data.Skip(2).Take(4).ToArray();
                ioStatus.ManualConfigFb = data.Skip(6).Take(4).ToArray();
                ioStatus.Output = data.Skip(10).Take(2).ToArray();
                ioStatus.Input = data.Skip(12).Take(2).ToArray();
                ioStatus.Error = BitConverter.ToInt16(data, 14);
                //     profile.IOStatus.Enqueue(ioStatus);

                #region new memory map
                profile.Data["IOStatus"] = ioStatus;
                profile.Data["ManualButton"] = (int)ioStatus.Manual;

                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        int index = j * 8 + i;
                        profile.Data[string.Format("Input.{0}", index)] = ((((int)ioStatus.Input[j] >> i) & 0x01) == 0x01) ? true : false;
                        profile.Data[string.Format("Output.{0}", index)] = ((((int)ioStatus.Output[j] >> i) & 0x01) == 0x01) ? true : false;
                    }
                }

                for (int j = 0; j < 3; j++)
                {
                    profile.Data[string.Format("ManualError.{0}", j)] = ((((int)ioStatus.Error >> j) & 0x01) == 0x01) ? true : false;
                }
                #endregion
            }
        }
        private void ParseData_SD(StrLinkProfile profile, byte[] data)
        {
            if (data.Length == 3)
            {
                SD sd = new SD();
                sd.Status = (SDStatus)data[0];
                sd.ErrorStatus = (SDError)(data[1] + data[2] * 256);
                //   profile.SD.Enqueue(sd);

                #region new memory map
                profile.Data["SDCardStatus"] = sd;
                profile.Data["SDConnection"] = (int)sd.Status;
                #endregion
            }
        }
        private void ParseData_HMI(StrLinkProfile profile, byte[] data)
        {
            if (data.Length == 2)
            {
                HMI hmi = new HMI();
                hmi.Status = (HMIStatus)data[0];
                hmi.PMBus = data[1];
                //   profile.HMI.Enqueue(hmi);

                #region new memory map
                profile.Data["HMIStatus"] = hmi;
                profile.Data["HMIConnection"] = (int)hmi.Status;
                #endregion
            }
        }
        private void ParseData_PLCStatus(StrLinkProfile profile, byte[] data)
        {
            if (data.Length == 23)
            {
                PowerLineCard plcStatus = new PowerLineCard();
                plcStatus.CardID = data[0];
                plcStatus.State = data[1];
                plcStatus.TryCnt = data[2];
                plcStatus.CorruptCnt = data[3];
                plcStatus.Alive = data[4];
                plcStatus.CalibState = data[5];
                plcStatus.PmbusStatus = data[6];
                plcStatus.LightsUsed = data[7];
                plcStatus.ChangedErrors = data[8];
                plcStatus.FbOutput = data[9];
                plcStatus.CtlData = data[10];
                plcStatus.FbCtlData = data[11];
                plcStatus.ErrorChanged = data[12];
                plcStatus.CardError = data[13];
                plcStatus.LightError = data.Skip(15).ToArray();

                //    profile.PLCStatus[data[0]].Enqueue(plcStatus);

                #region new memory map
                bool error = (plcStatus.CardError != 0) ? true : false;
                profile.Data[string.Format("PLCStatus.{0}", plcStatus.CardID)] = plcStatus;
                profile.Data[string.Format("CardAlive.{0}", plcStatus.CardID)] = (int)plcStatus.Alive;
                profile.Data[string.Format("CardStatus.{0}", plcStatus.CardID)] = (int)plcStatus.State;
                profile.Data[string.Format("CardError.{0}", plcStatus.CardID)] = (int)plcStatus.CardError;

                for (int j = 0; j < 8; j++)
                {
                    profile.Data[string.Format("OutputControl.{0}.{1}", plcStatus.CardID, j)] = ((((int)plcStatus.CtlData >> j) & 0x01) == 0x01) ? true : false;
                    profile.Data[string.Format("OutputFeedback.{0}.{1}", plcStatus.CardID, j)] = ((((int)plcStatus.FbOutput >> j) & 0x01) == 0x01) ? true : false;
                    profile.Data[string.Format("CardError.{0}.{1}", plcStatus.CardID, j)] = ((((int)plcStatus.CardError >> j) & 0x01) == 0x01) ? true : false;
                    profile.Data[string.Format("LightError.{0}.{1}", plcStatus.CardID, j)] = plcStatus.LightError[j];

                    for (int i = 0; i < 8; i++)
                    {
                        profile.Data[string.Format("LightError.{0}.{1}.{2}", plcStatus.CardID, j, i)] = ((((int)plcStatus.LightError[j] >> i) & 0x01) == 0x01) ? true : false;
                    }
                    error = error || ((plcStatus.LightError[j] != 0) ? true : false);
                }
                profile.Data["Error"] = error;
                if ((int)profile.Data["JunctionStatus"] == 1) // connnect
                {
                    if (error == true)
                    {
                        // disable this statement for showing to politic
                      //  profile.Data["JunctionStatus"] = 0xFF; // error
                    }
                }

                #endregion
            }
        }
        private void ParseData_LightCurrent(StrLinkProfile profile, byte[] data)
        {
            if (data.Length == 6)
            {
                int index = data[0] * 8 + data[1];
                float value = (float)BitConverter.ToUInt32(data, 2);
                //    profile.LightCurrent[index].Enqueue(value);

                #region new memory map
                profile.Data[string.Format("Current.{0}.{1}", data[0], data[1])] = value;
                #endregion
            }
        }
        private void ParseData_LightCurrentThreshold(StrLinkProfile profile, byte[] data)
        {
            if (data.Length == 6)
            {
                int index = data[0] * 8 + data[1];
                float value = (float)BitConverter.ToUInt32(data, 2);
                //    profile.LightCurrentThreshold[index].Enqueue(value);

                #region new memory map
                profile.Data[string.Format("Threshold.{0}.{1}", data[0], data[1])] = value;
                #endregion
            }
        }
        private void ParseData_CurrentScenarioID(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 1)
            {
                profile.CurrentScenarioID = data[0];

                #region new memory map
                profile.Data["CurrentScenarioId"] = data[0];
                #endregion
            }
        }
        private void ParseData_TODInfo(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 6)
            {
                profile.CurrentTOD.TODID = data[0];
                profile.CurrentTOD.Hour = Utilities.ConvertBCD2Hex(data[1]);
                profile.CurrentTOD.Min = Utilities.ConvertBCD2Hex(data[2]);
                profile.CurrentTOD.Type = (TypeControl)data[3];
                if (profile.CurrentTOD.Type == TypeControl.Color)
                {
                    profile.CurrentTOD.DiagramID = data[4];
                    profile.CurrentTOD.NumberOfZone = data[5];
                    profile.CurrentTOD.Pulses.Clear();

                    for (int j = 0; j < profile.CurrentTOD.NumberOfZone; j++)
                    {
                        profile.CurrentTOD.Pulses.Add(data[j * 2 + 6] + data[j * 2 + 7] * 256);
                    }
                }

                #region new memory map
                profile.Data["CurrentTOD"] = profile.CurrentTOD;
                profile.Data["CurrentTODId"] = profile.CurrentTOD.TODID;
                #endregion
            }
        }

        private void ParseData_ChangeControlMode(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 2)
            {
                profile.ModeInfo.Mode = (NetModeCommand)data[0];
                profile.ModeInfo.Error = data[1];
                profile.ModeInfo.IsWriteComplete = true;
            }
        }
        private void ParseData_ChangeDateConfig(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 1)
            {
                profile.ChangeDateInfo.IsError = data[0];
                profile.ChangeDateInfo.IsWriteComplete = true;
            }
        }
        private void ParseData_ChangeTODConfig(StrLinkProfile profile, byte[] data)
        {
            if (data.Length >= 1)
            {
                profile.ChangeTODInfo.IsError = data[0];
                profile.ChangeTODInfo.IsWriteComplete = true;
            }
        }
        private void ParseData_DataFromSD(StrLinkProfile profile, byte[] data)
        {
            if (data.Length > 2)
            {
                profile.SDData.FlushData(data[0] + data[1] * 256, data.Skip(2).ToArray());
            }
        }
        private void ParseData_FileSizeFromSD(StrLinkProfile profile, byte[] data)
        {
            if (data.Length == 4)
            {
                profile.SDData.FileSize = BitConverter.ToInt32(data, 0);
                profile.SDData.IsError = false;
            }
            else
            {
                profile.SDData.IsError = true;
                profile.SDData.IsCompleteReading = true;
            }
        }
        private void ParseData_FileSizeFromEeprom(StrLinkProfile profile, byte[] data)
        {
            if (data.Length == 4)
            {
                profile.EepromData.FileSize = BitConverter.ToInt32(data, 0);
                profile.EepromData.IsError = false;
            }
            else
            {
                profile.EepromData.IsError = true;
                profile.EepromData.IsCompleteReading = true;
            }
        }
        private void ParseData_DataFromEeprom(StrLinkProfile profile, byte[] data)
        {
            if (data.Length > 2)
            {
                profile.EepromData.FlushData(data[0] + data[1] * 256, data.Skip(2).ToArray());
            }
        }

        private void ParseData_ErrorContent(StrLinkProfile profile, byte[] data)
        {
            if (data.Length == 2)
            {
                byte index = data[0];
                byte error = data[1];
                if (profile.ErrorContent.Length > index)
                {
                    profile.ErrorContent[index] = data[1];
                }
            }
        }
        #endregion

        #region interface
        public void InitializeTags(int port, List<string> tagName, List<string> tagAddress, List<object> tagValue)
        {

        }
        public bool GetTagValue(int port, string tagAddress, List<int> parametter, out object result, out DateTime time)
        {
            bool res = false;
            result = new object();
            time = DateTime.Now;

            res = GetDataFromMemoryMap(port, tagAddress, out result);
        //    Common.Logger.LogRequest(string.Format("Port {0}({1}) : {2}", port, DateTime.Now, tagAddress));

            switch (tagAddress)
            {
                case "CotrollerTime":
                    ReadTime(port);
                    break;
                case "PowerTimeStamp":
                    ReadPowerTimeStamp(port);
                    break;
                case "ModeControl":
                    ReadControlMode(port);
                    break;
                case "CotrollerInfo":
                    ReadControllerInfo(port);
                    break;
                case "SourceVoltage":
                    ReadSourceVoltage(port);
                    break;
                case "BatteryVoltage":
                    ReadBatteryVoltage(port);
                    break;
                case "Temperature":
                    ReadTemperature(port);
                    break;
                case "IOStatus":
                    ReadIOStatus(port);
                    break;
                case "SDCardStatus":
                    ReadSDStatus(port);
                    break;
                case "HMIStatus":
                    ReadHMIStatus(port);
                    break;
                case "CurrentScenarioId":
                    ReadCurrentScenarioID(port);
                    break;
                case "CurrentTODId":
                    ReadCurrentTOD(port);
                    break;


            }
            if (tagAddress.Contains("."))
            {
                string[] splitAddress = tagAddress.Split(new char[1] { '.' });
                string address = splitAddress[0];
                int[] param = new int[splitAddress.Length - 1];
                for (int j = 0; j < param.Length; j++)
                {
                    int.TryParse(splitAddress[j + 1], out param[j]);
                }

                switch (address)
                {
                    case "PLCStatus":
                        ReadPLCStatus(port, (byte)param[0]);
                        break;
                    case "Current":
                        ReadLightCurrent(port, (byte)param[0], (byte)param[1]);
                        break;
                    case "Threshold":
                        ReadLightCurrentThreshold(port, (byte)param[0], (byte)param[1]);
                        break;
                    case "Eeprom":
                        string fileName = "";
                        bool isValidFileName = true;
                        switch (param[0])
                        {
                            case (byte)EerpromFile.Date:
                                fileName = "date.cfg\0";
                                break;
                            case (byte)EerpromFile.Diagramxx:
                                if (param.Length >= 2)
                                {
                                    fileName = string.Format("diagram{0}.cfg\0", param[1].ToString("00"));
                                }
                                else
                                {
                                    isValidFileName = false;
                                }
                                break;
                            case (byte)EerpromFile.Error:
                                fileName = "error.cfg\0";
                                break;
                            case (byte)EerpromFile.Info:
                                fileName = "info.cfg\0";
                                break;
                            case (byte)EerpromFile.InOut:
                                fileName = "inout.cfg\0";
                                break;
                            case (byte)EerpromFile.IpConfig:
                                fileName = "ipconfig.cfg\0";
                                break;
                            case (byte)EerpromFile.Line:
                                fileName = "line.cfg\0";
                                break;
                            case (byte)EerpromFile.TODxx:
                                if (param.Length >= 2)
                                {
                                    fileName = string.Format("TOD{0}.cfg\0", param[1].ToString("00"));
                                }
                                else
                                {
                                    isValidFileName = false;
                                }
                                break;
                        }

                        if (isValidFileName)
                        {
                            ReadEeprom(port, fileName);
                            List<byte> data = new List<byte>();
                            res = GetFileFromEeprom(port, out data);
                            result = data;

                        }
                        break;
                }

            }

            return res;
        }
        public bool SetTagValue(int port, string tagAddress, object[] data)
        {
            bool res = false;
            switch (tagAddress)
            {
                case "SetTime":
                    WriteTime(port, DateTime.Now);
                    res = true;
                    break;
                case "Flash":
                    WriteModeControl(port, (byte)NetModeCommand.Remote_Flash);
                    res = true;
                    break;
                case "OffController":
                    WriteModeControl(port, (byte)NetModeCommand.Remote_Off);
                    res = true;
                    break;
                case "ChangePhase":
                    WriteModeControl(port, (byte)NetModeCommand.Remote_Color);
                    WriteModeControl(port, (byte)NetModeCommand.Remote_Change_Phase);
                    res = true;
                    break;
                case "Auto":
                    WriteModeControl(port, (byte)NetModeCommand.Auto);
                    res = true;
                    break;
                case "Calib":
                    WriteModeControl(port, (byte)NetModeCommand.Calib);
                    res = true;
                    break;

                case "reset":
                    WriteReset(port);
                    break;
                case "changedateconfig":
                    WriteDateConfig(port, data[0] as byte[]);
                    break;
                case "ChangeTODConfig":
                    WriteTODConfig(port, data[0] as byte[]);
                    break;
            }

            if (tagAddress.Contains("."))
            {
                string[] splitAddress = tagAddress.Split(new char[1] { '.' });
                string address = splitAddress[0];
                int[] param = new int[splitAddress.Length - 1];
                for (int j = 0; j < param.Length; j++)
                {
                    int.TryParse(splitAddress[j + 1], out param[j]);
                }
                switch (address)
                {
                    case "Threshold":
                        byte[] temp = BitConverter.GetBytes((int)(decimal)data[0]);

                        WriteCurrentThreshod(port, new byte[] { (byte)param[0], (byte)param[1], temp[0], temp[1], temp[2], temp[3] });
                        break;
                    case "Output":
                        byte temp1 = (byte)(((bool)data[0] == true) ? 1 : 0);
                        WriteIO(port, new byte[] { (byte)param[0], temp1 });
                        break;
                }
            }
            return res;
        }
        public EventMessage GetSysState(int port)
        {
            EventMessage res = null;
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile.Event.Count > 0)
                {
                    res = profile.Event.Dequeue();
                }
                else
                {
                    res = null;
                }
            }
            return res;
        }
        public void RemoveDevice(int port)
        {
            BoxList.Remove(port);
        }
        public List<string> GetServerAddress()
        {
            return _Server.GetMyIPAddress();
        }
        public static List<string> GetTagAdressList()
        {
            List<string> res = new List<string>() 
            { 
                "connection",
                "line", 
                "time", 
                "boxid", 
                "controlmode", 
                "controltype", 
                "temperature", 
                "source", 
                "battery",
                "powertimestamp",
                "iostatus",
                "plcstatus",
                "lightcurrent",
                "lightcurrentthreshold",
                "hmi",
                "sd",
                "linedatafromsd",
                "event",
                "eventfromsd",
                "reset",
                "changedateconfig",
                "changetodconfig",
                "eepromfile",
                "currentscenarioid",
                "currenttod"
            };
            return res;
        }
        public void Start(string ioServerIP, List<int> ports)
        {
            _State = CompState.Starting;
            for (int j = 0; j < ports.Count; j++)
            {
                if (!BoxList.ContainsKey(ports[j]))
                {
                    BoxList.Add(ports[j], null);
                }
            }
            _Server.Start(ioServerIP, ports);
            _State = CompState.Running;
        }
        public void Stop()
        {
            _State = CompState.Stoping;
            if (BoxList != null)
            {
                BoxList.Clear();
            }
            _Server.Stop();
            _State = CompState.Stopped;
        }
        public int IsWriteSuccess(int port)
        {
            int res = -20;
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    res = profile.ModeInfo.Error;
                }
            }
            return res;
        }
        public bool IsWriteComplete(int port)
        {
            bool res = false;
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    res = profile.ModeInfo.IsWriteComplete;
                }
            }
            return res;
        }
        public bool IsConnect(int port)
        {
            bool res = false;
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    res = profile.IsConnect;
                }
            }
            return res;
        }
        public string GetDriverVersion()
        {
            return _Version;
        }
        public float GetNumberOfSendingKB(int port)
        {
            float res = 0;
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    res = profile.NumberOfSendingKB;
                }
            }
            return res;
        }
        public float GetNumberOfReceivingKB(int port)
        {
            float res = 0;
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    res = profile.NumberOfRecevingKB;
                }
            }
            return res;
        }
        public void ResetDataTrafficCounter(int port)
        {
            if (BoxList.ContainsKey(port))
            {
                StrLinkProfile profile = BoxList[port];
                if (profile != null)
                {
                    profile.NumberOfRecevingKB = 0;
                    profile.NumberOfSendingKB = 0;
                }
            }
        }
        #endregion
    }
}

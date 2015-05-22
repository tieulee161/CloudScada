using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public enum DriverType
    {
        VDK = 0,
        OPC = 1
    }

    public enum ServerType
    {
        IO = 0,
        Alarm = 1,
        Trend = 2,
        Report = 3
    }

    public enum Priority
    {
        Primary = 0,
        Secondary = 1
    }

    public enum FormType
    {
        Add = 0,
        Update = 1,
        None = 2
    }

    public enum Logic
    {
        Succcess = 0,
        Fail = 1
    }

    public enum TagType
    {
        External = 0,
        Internal = 1
    }

    public enum DataType
    {
        Bool = 0,
        Int8 = 1,
        Int16 = 2,
        Int32 = 3,
        Double = 4,
        String = 5,
        Object = 6,
        Datetime = 7,
    }

    public enum Quality
    {
        Bad = 0,
        Good = 1
    }

    public enum TypeControl
    {
        Color = 0,
        Flash = 1,
        Off = 2,
        All_Red = 3
    };

    public enum AlarmType
    {
        Digital = 0,
        Analog,
    }

    public enum AlarmValue
    {
        Null = 0,
        False,
        True,
        Lowlow,
        Low,
        Normal,
        High,
        Highhigh,
        Error,
    }

    public enum AlarmOnWhen
    {
        False = 0,
        True,
        Lowlow,
        Low,
        Normal,
        High,
        Highhigh,
    }

    public enum AlarmStatus
    {
        Incomming,
        Outgoing,
        Confirmed,
        ConfirmedOutgoing
    }

    public class IDisplayTag
    {
        private object _Value;
        public string Name { get; set; }
        public string Address { get; set; }
        public object Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                OnTagValueChangedEvent(new EventArgs());
            }
        }
        public Quality Quality { get; set; }
        public object Parent { get; set; }

        public delegate void TagValueChangedHandler(object sender, EventArgs e);
        public event TagValueChangedHandler RaiseTagValueChangedEvent;
        private void OnTagValueChangedEvent(EventArgs e)
        {
            if (RaiseTagValueChangedEvent != null)
            {
                RaiseTagValueChangedEvent(this, e);
            }
        }

        public delegate void UserChangeTagValueHandler(object sender, EventArgs e);
        public event UserChangeTagValueHandler RaiseUserChangeTagValueEvent;
        private void OnUserChangeTagValueEvent(EventArgs e)
        {
            if (RaiseUserChangeTagValueEvent != null)
            {
                RaiseUserChangeTagValueEvent(this, e);
            }
        }

        public object UserValue
        {
            get;
            set;
        }
        public void SetTagValue(object data)
        {
            UserValue = data;
            OnUserChangeTagValueEvent(new EventArgs());
        }
    }

    public static class Utility
    {
        public static string GetEnumString(ServerType type)
        {
            string res = type.ToString();
            return res;
        }

        public static string GetEnumString(Priority priority)
        {
            string res = priority.ToString();
            return res;
        }

        public static string GetEnumString(TagType tagType)
        {
            return tagType.ToString();
        }

        public static string GetEnumString(DataType dataType)
        {
            return dataType.ToString();
        }

        public static int GetEnumInt(Type type, string value)
        {
            int res = -1;
            if (type == typeof(ServerType))
            {
                if (value == "IO") res = (int)ServerType.IO;
                else if (value == "Alarm") res = (int)ServerType.Alarm;
                else if (value == "Trend") res = (int)ServerType.Trend;
                else if (value == "Report") res = (int)ServerType.Report;
            }
            else if (type == typeof(Priority))
            {
                if (value == "Primary") res = (int)Priority.Primary;
                else if (value == "Secondary") res = (int)Priority.Secondary;
            }
            else if (type == typeof(TagType))
            {
                if (value == "External") res = (int)TagType.External;
                else if (value == "Internal") res = (int)TagType.Internal;
            }
            else if (type == typeof(DataType))
            {
                if (value == "Bool") res = (int)DataType.Bool;
                else if (value == "Int8") res = (int)DataType.Int8;
                else if (value == "Int16") res = (int)DataType.Int16;
                else if (value == "Int32") res = (int)DataType.Int32;
                else if (value == "Double") res = (int)DataType.Double;
                else if (value == "String") res = (int)DataType.String;
            }
            return res;
        }

        public static byte ConvertHex2BCD(int data)
        {
            return (byte)((((data % 100) / 10) << 4) + (data % 10));
        }

        public static byte ConvertBCD2Hex(int data)
        {
            return (byte)((data >> 4) * 10 + (data & 0x0F));
        }
    }
}

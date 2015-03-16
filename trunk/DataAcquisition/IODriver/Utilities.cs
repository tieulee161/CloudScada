using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IODriver
{
    public class Utilities
    {
        public static int[] IndexOf(byte[] data, byte[] indentity)
        {
            List<int> res = new List<int>();
            for (int j = 0; j < data.Length - indentity.Length; j++)
            {
                bool bMatch = true;
                for (int i = 0; i < indentity.Length; i++)
                {
                    if (data[j + i] != indentity[i])
                    {
                        bMatch = false;
                        break;
                    }
                }
                if (bMatch == true)
                {
                    res.Add(j);
                }
            }

            return res.ToArray();
        }
        public static List<byte[]> ParseMessage(byte[] data,string indentity)
        {
            List<byte[]> res = new List<byte[]>();
            byte[] temp = Encoding.UTF8.GetBytes(indentity);

            string strData = BitConverter.ToString(data);
            string strIndentity = BitConverter.ToString(temp);

            string[] strSplitData = strData.Split(new string[] { strIndentity }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < strSplitData.Length; j++)
            {
                string[] strTemp = strSplitData[j].Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                byte[] arrayTemp = new byte[strTemp.Length];
                for (int i = 0; i < arrayTemp.Length; i++)
                {
                    arrayTemp[i] = byte.Parse(strTemp[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                }
                res.Add(arrayTemp);
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

        const int CRC_TYPE = 0x1021 << 16;    //CRC-CCITT: X16 + X12 + X5 + 1
        public static ushort CRC_ByteArray(byte[] data, int len, ushort prev_crc)
        {
            ushort crc = prev_crc;
            int i = 0;

            if (len != 0)
            {
                do
                {
                    crc = CRC_Byte(data[i++], crc);
                } while ((--len) != 0);

            }
            return crc;
        }
        public static ushort CRC_Byte(byte data, ushort prev_crc)
        {
            uint eor;
            uint crc;
            int i = 16;

            crc = (uint)((prev_crc << 16) | data);
            do
            {
                if ((crc & 0x80000000) == 0x80000000)
                    eor = CRC_TYPE;
                else
                    eor = 0;
                crc <<= 1;
                crc ^= eor;
            } while ((--i) != 0);

            return (ushort)(crc >> 16);
        }
        public static ushort CRC_Final(ushort prev_crc)
        {
            return CRC_Byte(0, prev_crc);
        }
    }
}

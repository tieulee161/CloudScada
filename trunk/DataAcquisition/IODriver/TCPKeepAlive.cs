using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace IODriver
{
    public class TCPKeepAlive1
    {
        public int SetKeepAliveValues(System.Net.Sockets.Socket Socket, bool On_Off, uint KeepaLiveTime, uint KeepaLiveInterval)
        {
            int Result = -1;

            byte[] enabled = BitConverter.GetBytes(Convert.ToUInt32(On_Off));
            byte[] timeOut = BitConverter.GetBytes(KeepaLiveTime);
            byte[] interval = BitConverter.GetBytes(KeepaLiveInterval);

            byte[] inValue = new byte[enabled.Length + timeOut.Length + interval.Length];

            for (int j = 0; j < enabled.Length; j++)
                inValue[j] = enabled[j];
            for (int j = 0; j < timeOut.Length; j++)
                inValue[j] = timeOut[j];
            for (int j = 0; j < interval.Length; j++)
                inValue[j] = interval[j];

            Result = Socket.IOControl(IOControlCode.KeepAliveValues, inValue, null);
            return Result;
        }
    }
}

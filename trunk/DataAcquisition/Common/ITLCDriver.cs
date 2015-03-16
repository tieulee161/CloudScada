using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriverCommon
{
    public interface ITLCDriver
    {
        string GetDriverVersion();
        void InitializeTags(int port, List<string> tagName, List<string> tagAddress, List<object> tagValue);
        bool GetTagValue(int port, string tagAddress, List<int> parametter, out object result, out DateTime time);
        bool SetTagValue(int port, string tagAddress, object[] data);
        int IsWriteSuccess(int port);
        bool IsWriteComplete(int port);
        bool IsConnect(int port);

        void RemoveDevice(int port);
        void Start(string ioServerIP, List<int> ports);
        void Stop();

        float GetNumberOfSendingKB(int port);
        float GetNumberOfReceivingKB(int port);
        void ResetDataTrafficCounter(int port);
    }
}

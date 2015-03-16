using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Common;
using Designer.Model;
using IODriver;
using OPCLib;
using DriverCommon;

namespace Designer.Core
{
    public class Driver
    {
        public Root Parent;
        public ITLCDriver IODriver;
        public DriverType Type;

        public Driver(DriverType driverType, ITLCDriver driver, string serverIP, int port)
        {
            IODriver = driver;
            Type = driverType;
            if (driverType == DriverType.VDK)
            {
                VDKDriver.ConnectToServer(serverIP, port);
                IODriver = VDKDriver.Server;
            }
            else
            {
                OPCHost.ConnectToServer(serverIP, port);
                IODriver = OPCHost.Server;
            }
        }

        public void InitializeTags(int port, List<string> tagName, List<string> tagAddress, List<object> tagValue)
        {
            if (Type == DriverType.OPC)
            {
                try
                {
                    if (IODriver != null)
                    {
                        IODriver.InitializeTags(port, tagName, tagAddress, tagValue);
                    }
                }
                catch (Exception)
                { }
            }
        }

        public void Stop()
        {
            IODriver.Stop();
        }

        public bool SetTagValue(IOTag tag, object[] data)
        {
            bool res = false;
            if (tag != null)
            {
                try
                {
                    res = IODriver.SetTagValue((int)tag.Device.Port, tag.Address, data);
                }
                catch (Exception ex)
                {

                }
            }
            return res;
        }

        public bool GetTagValue(IOTag tag, List<int> param, out object data)
        {
            bool res = false;
            data = null;
            DateTime time = new DateTime();
            string address = tag.Address;
            if (param != null)
            {
                for (int j = 0; j < param.Count; j++)
                {
                    address += "." + param[j];
                }
            }
            if (tag != null)
            {
                try
                {
                    res = IODriver.GetTagValue((int)tag.Device.Port, address, param, out data, out time);

                    // 
                    if (tag.Device.Driver == "OPC")
                    {
                        if (tag.Name.Contains("CONNECTION"))
                        {
                            if (data != null)
                            {
                                if ((bool)data == false)
                                {
                                    data = 1; // connect
                                }
                                else
                                {
                                    data = 0; // disconnect
                                }
                            }


                            var query = (from q in tag.Device.IOTags
                                         where q.Address.Contains("M70")
                                         select q).FirstOrDefault();
                            if (query != null)
                            {
                                object data1 = null;
                                if (IODriver.GetTagValue((int)tag.Device.Port, query.Address, param, out data1, out time))
                                {
                                    if (data1 != null)
                                    {
                                        if ((bool)data1 == true)
                                        {
                                            data = 0xff; // error
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }

                if (res)
                {
                    tag.Value2 = data;
                    DBAccess.UpdateValueForIOTag(tag.Device.Name, tag.Name, data, time, (int)Common.Quality.Good);
                }

            }
            return res;
        }
    }
}

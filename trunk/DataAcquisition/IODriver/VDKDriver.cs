using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

using DriverCommon;

namespace IODriver
{
    public class VDKDriver : MarshalByRefObject
    {
      //  public static string Version = "V2.0.0";

        public static string DriverUrl = string.Format("tcp://{0}:{1}/VDKDriver", Properties.Settings.Default.ServerIP, Properties.Settings.Default.Port);

        public static ITLCDriver Server;

        private static TcpChannel _Channel = null;

        public static void StartServer(string serverIP, int serverPort)
        {
            if (_Channel == null)
            {
                DriverUrl = string.Format("tcp://{0}:{1}/VDKDriver", serverIP, serverPort);

                System.Collections.IDictionary props = new System.Collections.Hashtable();
                props["name"] = "VDKChannel";
                props["port"] = serverPort;
                _Channel = new TcpChannel(
                   props,
                   null,
                   new BinaryServerFormatterSinkProvider()
                );
                _Channel.IsSecured = false;
                ChannelServices.RegisterChannel(_Channel, false);
                try
                {
                    RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                }
                catch (Exception)
                { }

                RemotingConfiguration.RegisterWellKnownServiceType(typeof(AppDriver), "VDKDriver", WellKnownObjectMode.Singleton);
            }

            Server = (AppDriver)Activator.GetObject(typeof(AppDriver), DriverUrl);
        }

        public static void ConnectToServer(string serverIP, int serverPort)
        {
            try
            {
                DriverUrl = string.Format("tcp://{0}:{1}/VDKDriver", serverIP, serverPort);
              //  ChannelServices.RegisterChannel(new TcpClientChannel(), false);
                Server = (AppDriver)Activator.GetObject(typeof(AppDriver), DriverUrl);
            }
            catch (Exception)
            {
                //MessageHandler.Error("Không thể kết nối đến server !\r\n\r\nXem lại kết nối internet hoặc server hiện đang không hoạt động.");
                //StopApplication();
            }
        }
    }
}

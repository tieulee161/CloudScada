using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.ComponentModel;

namespace IODriver
{
    public enum CompState
    {
        Idle,
        Starting,
        Running,
        Stoping,
        Stopped
    }

    public class DataSocket
    {
        public Socket Soc;
        public byte[] Buffer;
        public string IPAddr;
        public int Port;
        public DataSocket(Socket soc)
        {
            Soc = soc;
            Buffer = new byte[256];
            IPAddr = ((IPEndPoint)soc.RemoteEndPoint).Address.ToString();
            Port = ((IPEndPoint)soc.LocalEndPoint).Port;
        }
        public DataSocket()
        {
        }
    }

    public class TCPIPServer
    {
        private Dictionary<int, DataSocket> _Client { get; set; }
        private string _IOServerIP { get; set; }
        private Dictionary<int, Socket> _SocketManagers { get; set; }

        public int NumberOfClient = 10;
        public string ServerStatus { get; set; }
        public CompState State { get; set; }

        #region constructor
        public TCPIPServer()
        {
            _Client = new Dictionary<int, DataSocket>();
            _SocketManagers = new Dictionary<int, Socket>();
            State = CompState.Idle;
        }
        #endregion

        #region public method
        public void Start(string ioServerIP, List<int> ports)
        {
            State = CompState.Starting;
            NumberOfClient = ports.Count;
            _IOServerIP = ioServerIP;

            for (int j = 0; j < ports.Count; j++)
            {
                Socket temp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(_IOServerIP), ports[j]);
                temp.Bind(iep);
                temp.Listen(5);
                _SocketManagers.Add(ports[j], temp);

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += worker_DoWork;
                worker.RunWorkerAsync(temp);
            }
            State = CompState.Running;
        }

        public void Stop()
        {
            State = CompState.Stoping;
            foreach (DataSocket dataSoc in _Client.Values)
            {
                try
                {
                    if ((dataSoc != null) && (dataSoc.Soc != null))
                    {
                        dataSoc.Soc.Shutdown(SocketShutdown.Both);
                        dataSoc.Soc.Close();
                    }
                }
                catch (Exception ex)
                { }

            }
            foreach (Socket soc in _SocketManagers.Values)
            {
                if (soc != null)
                {
                    try
                    {
                        soc.Shutdown(SocketShutdown.Both);
                        soc.Close();
                    }
                    catch (Exception ex)
                    { }

                }
            }
            State = CompState.Stopped;
        }

        private void SendCmd(DataSocket dataSocket, byte[] Cmd)
        {
            if (dataSocket != null)
            {
                Socket soc = dataSocket.Soc;
                if ((soc != null) && (soc.Connected))
                {
                    try
                    {
                        soc.Send(Cmd);
                        if (dataSocket.Port == 2048)
                        {
                            string temp = string.Format("{0} : {1}", DateTime.Now, string.Join(",", Cmd));
                            Common.Logger.LogRequest(temp);
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Logger.Log(string.Format("TCPServer(SendCmd) {0}:{1}", dataSocket.Port, ex.Message));
                    }
                }
            }
        }

        public void SendCmd(int port, byte[] Cmd)
        {
            if (_Client.ContainsKey(port))
            {
                SendCmd(_Client[port], Cmd);
            }
        }

        public List<string> GetMyIPAddress()
        {
            List<string> res = new List<string>();
            string hostName = Dns.GetHostName();
            IPAddress[] Addr = Dns.GetHostAddresses(hostName);
            for (int j = 0; j < Addr.Length; j++)
            {
                res.Add(Addr[j].ToString());
            }
            return res;
        }
        #endregion

        #region private method
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            AcceptThread(e.Argument);
        }

        private void AcceptThread(object originalSocket)
        {
            Socket temp = (Socket)originalSocket;
            while (State == CompState.Running)
            {
                try
                {
                    Socket newClient = temp.Accept();

                    string connectionString = string.Format("from {0}:{1} to {2}:{3}",
                                                        ((IPEndPoint)newClient.RemoteEndPoint).Address.ToString(),
                                                        ((IPEndPoint)newClient.RemoteEndPoint).Port,
                                                        ((IPEndPoint)newClient.LocalEndPoint).Address.ToString(),
                                                        ((IPEndPoint)newClient.LocalEndPoint).Port);
                    Common.Logger.Log(string.Format("Connection: {0}", connectionString));
                    SetKeepAliveValues(newClient, true, 60000, 5000);


                    DataSocket newConnection = new DataSocket(newClient);
                    if (!_Client.ContainsKey(newConnection.Port))
                    {
                        _Client.Add(newConnection.Port, newConnection);
                    }
                    else
                    {
                        _Client[newConnection.Port] = newConnection;
                    }

                    // generate event
                    SocketEventArgs newConnectionEvent = new SocketEventArgs(newConnection);
                    OnRegistrySocket(newConnectionEvent);
                    Common.Logger.Log(string.Format("Generated socket connecting event: {0}", connectionString));


                    // start receiving data
                    try
                    {
                        int recv = 0;
                        byte[] data = _Client[newConnection.Port].Buffer;
                        while (_Client[newConnection.Port].Soc.Connected)
                        {
                            recv = _Client[newConnection.Port].Soc.Receive(data);
                            DataComeEventArgs newData = new DataComeEventArgs(data.Take(recv).ToArray(), _Client[newConnection.Port]);
                            OnDataCome(newData);
                        }
                    }
                    catch (Exception ex)
                    {
                        ServerStatus = ex.Message + "\r\n" + ex.InnerException;
                        Common.Logger.Log(string.Format("Receiving data exception port {0} : {1}", newConnection.Port, ServerStatus));
                    }


                    SocketEventArgs closeConnectionEvent = new SocketEventArgs(_Client[newConnection.Port]);
                    OnSocketClosed(closeConnectionEvent);
                    Common.Logger.Log(string.Format("Generated socket closing event : {0}", connectionString));

                    newClient.Close();
                }
                catch (Exception ex1)
                {
                    ServerStatus = ex1.Message + "\r\n" + ex1.InnerException;
                    Common.Logger.Log(string.Format("TCPServer(Accept) :{0}", ServerStatus));
                }

            }
        }

        private void AcceptConn(IAsyncResult iar)
        {
            Socket newClient = ((Socket)iar.AsyncState).EndAccept(iar);
            string connectionString = string.Format("from {0}:{1} to {2}:{3}",
                                                     ((IPEndPoint)newClient.RemoteEndPoint).Address.ToString(),
                                                     ((IPEndPoint)newClient.RemoteEndPoint).Port,
                                                     ((IPEndPoint)newClient.LocalEndPoint).Address.ToString(),
                                                     ((IPEndPoint)newClient.LocalEndPoint).Port);
            Common.Logger.Log(string.Format("Connection: {0}", connectionString));
            SetKeepAliveValues(newClient, true, 60000, 1000);

            DataSocket newConnection = new DataSocket(newClient);
            if (!_Client.ContainsKey(newConnection.Port))
            {
                _Client.Add(newConnection.Port, newConnection);
            }
            else
            {
                _Client[newConnection.Port] = newConnection;
            }

            // generate event
            SocketEventArgs newConnectionEvent = new SocketEventArgs(newConnection);
            OnRegistrySocket(newConnectionEvent);
            Common.Logger.Log(string.Format("Generated socket connecting event: {0}", connectionString));

            // start receiving data
            try
            {
                int recv = 0;
                byte[] data = _Client[newConnection.Port].Buffer;
                while (_Client[newConnection.Port].Soc.Connected)
                {
                    recv = _Client[newConnection.Port].Soc.Receive(data);
                    DataComeEventArgs newData = new DataComeEventArgs(data.Take(recv).ToArray(), _Client[newConnection.Port]);
                    OnDataCome(newData);
                }
            }
            catch (Exception ex)
            {
                ServerStatus = ex.Message + "\r\n" + ex.InnerException;
                Common.Logger.Log(string.Format("Receiving data exception port {0} : {1}", newConnection.Port, ServerStatus));
            }


            SocketEventArgs closeConnectionEvent = new SocketEventArgs(_Client[newConnection.Port]);
            OnSocketClosed(closeConnectionEvent);
            Common.Logger.Log(string.Format("Generated socket closing event : {0}", connectionString));

            newClient.Shutdown(SocketShutdown.Both);
            newClient.Close();

        }

        private int SetKeepAliveValues(System.Net.Sockets.Socket Socket, bool On_Off, uint KeepaLiveTime, uint KeepaLiveInterval)
        {
            int Result = -1;
            try
            {
                byte[] enabled = BitConverter.GetBytes(Convert.ToUInt32(On_Off));
                byte[] timeOut = BitConverter.GetBytes(KeepaLiveTime);
                byte[] interval = BitConverter.GetBytes(KeepaLiveInterval);

                byte[] inValue = new byte[enabled.Length + timeOut.Length + interval.Length];
                int offset = 0;

                for (int j = 0; j < enabled.Length; j++)
                    inValue[offset + j] = enabled[j];
                offset += enabled.Length;

                for (int j = 0; j < timeOut.Length; j++)
                    inValue[offset + j] = timeOut[j];
                offset += timeOut.Length;

                for (int j = 0; j < interval.Length; j++)
                    inValue[offset + j] = interval[j];

                Result = Socket.IOControl(IOControlCode.KeepAliveValues, inValue, null);
            }
            catch (Exception ex)
            {
                Common.Logger.Log(string.Format("TCPServer (SetKeepAlive) {0}:{1}", ((IPEndPoint)Socket.LocalEndPoint).Port, ex.Message));
            }

            return Result;
        }
        #endregion

        #region Event
        public delegate void DataEventHandler(object sender, DataComeEventArgs a);
        public event DataEventHandler RaiseDataComeEvent;
        private void OnDataCome(DataComeEventArgs e)
        {
            if (RaiseDataComeEvent != null)
            {
                RaiseDataComeEvent(this, e);
            }
        }

        public delegate void SocketClosedEventHandler(object sender, SocketEventArgs a);
        public event SocketClosedEventHandler RaiseSocketClosedEvent;
        private void OnSocketClosed(SocketEventArgs e)
        {
            if (RaiseSocketClosedEvent != null)
            {
                RaiseSocketClosedEvent(this, e);
            }
        }

        public delegate void RegistrySocketEventHandler(object sender, SocketEventArgs a);
        public event RegistrySocketEventHandler RaiseRegistrySocketEvent;
        private void OnRegistrySocket(SocketEventArgs e)
        {
            if (RaiseRegistrySocketEvent != null)
            {
                RaiseRegistrySocketEvent(this, e);
            }
        }

        #endregion
    }

    public class DataComeEventArgs : EventArgs
    {
        public byte[] Data;
        public DataSocket Socket;
        public DataComeEventArgs(byte[] data, DataSocket socket)
        {
            Data = data;
            Socket = socket;
        }
    }

    public class SocketEventArgs : EventArgs
    {
        public DataSocket Socket;
        public SocketEventArgs(DataSocket e)
        {
            this.Socket = e;
        }
    }
}

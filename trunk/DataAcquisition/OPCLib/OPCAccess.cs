using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPC.Common;
using OPC.Data.Interface;
using OPC.Data;
using System.Runtime.InteropServices;

using System.Threading;
using DriverCommon;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.ComponentModel;
using System.Windows.Forms;
using Common;


namespace OPCLib
{
    #region old version
    public class OPCAccess : MarshalByRefObject
    {
        private const string serverProgID = "KEPware.KEPServerEx.V4";
        private const int numberOfReWrite = 2;
        private const int timeOut = 1000;
        private OpcServer theSrv;
        private OpcGroup theGrp;
        private OPCItemDef[] _ItemDefs;
        private int[] _HandleServer;
        private List<int> _CancelID;
        private int _TransactionID = 0;
        private int _MaxOfRetry = 5;
        private int _Retry;

        public List<string> Items;
        public List<object> ItemsValue;
        public List<bool> ItemsStatus;
        public bool IsWriteComplete;
        public bool IsConnect;
        public bool IsAddItemsSuccess;
        public bool IsWriteSuccess;
        public float NumberOfSendingKB;
        public float NumberOfReceivingKB;

        System.Timers.Timer _Watchdog;

        public OPCAccess()
        {
            theSrv = new OpcServer();
            IsWriteComplete = true;
            IsWriteSuccess = true;
            IsConnect = false;
            IsAddItemsSuccess = false;
            NumberOfReceivingKB = 0;
            NumberOfSendingKB = 0;
            _Retry = 0;
            _CancelID = new List<int>();
            _Watchdog = new System.Timers.Timer();
            _Watchdog.AutoReset = true;
            _Watchdog.Interval = 60000;
            _Watchdog.Elapsed += _Watchdog_Elapsed;
        }

        private void _Watchdog_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _Watchdog.Stop();
            for (int j = 0; j < _CancelID.Count; j++)
            {
                theGrp.Cancel2(_CancelID[j]);
            }

            _CancelID.Clear();
            _Watchdog.Start();
        }

        public void InitItems(List<string> items, List<object> itemsValue)
        {
            // init tags
            Items = items;
            _ItemDefs = new OPCItemDef[Items.Count];
            _HandleServer = new int[Items.Count];
            for (int j = 0; j < _ItemDefs.Length; j++)
            {
                _ItemDefs[j] = new OPCItemDef(Items[j], true, j, VarEnum.VT_EMPTY);
            }

            // init tag value and tag status
            ItemsStatus = new List<bool>();
            ItemsValue = new List<object>();
            for (int j = 0; j < Items.Count; j++)
            {
                ItemsStatus.Add(false);
            }
            for (int j = 0; j < itemsValue.Count; j++)
            {
                ItemsValue.Add(itemsValue[j]);
            }
        }

        public bool Connect(string groupName)
        {
            bool res = false;

            IsWriteComplete = false;
            IsWriteSuccess = false;

            if (_Retry < _MaxOfRetry)
            {
                _Retry++;
                if (IsConnect == false)
                {
                    theSrv.Connect(serverProgID);
                    Thread.Sleep(500);
                    IsConnect = true;
                }
                else
                {
                    if (IsWriteComplete == false)
                    {
                        theSrv.Disconnect();
                        Thread.Sleep(500);
                        theSrv.Connect(serverProgID);
                        Thread.Sleep(500);
                    }
                }

                if (theGrp == null)
                {
                    theGrp = theSrv.AddGroup(groupName, false, 500);
                }
                else
                {
                    if (IsWriteComplete == false)
                    {
                        theGrp.Remove(true);
                        theGrp = theSrv.AddGroup(groupName, false, 500);
                        IsAddItemsSuccess = false;
                    }
                }

                if (IsAddItemsSuccess == false)
                {
                    OPCItemResult[] rItm;
                    theGrp.AddItems(_ItemDefs, out rItm);
                    if (rItm != null)
                    {
                        bool temp = false;
                        for (int j = 0; j < rItm.Length; j++)
                        {
                            temp = temp || HRESULTS.Failed(rItm[j].Error);
                            _HandleServer[j] = rItm[j].HandleServer;
                        }
                        if (temp == false) // success to add items to group
                        {
                            IsAddItemsSuccess = true;
                            theGrp.SetEnable(false);
                            theGrp.Active = true;
                            theGrp.WriteCompleted += new WriteCompleteEventHandler(theGrp_WriteCompleted);
                            theGrp.CancelCompleted += theGrp_CancelCompleted;

                            Thread.Sleep(500);
                            res = true;
                        }
                        else
                        {
                            IsAddItemsSuccess = false;
                        }
                    }
                }
                else
                {
                    res = true;
                    theGrp.Active = true;
                }
            }
            else
            {

            }
            return res;
        }

        public void Read()
        {
            int CancelID;
            int[] aE;
            theGrp.Read(_HandleServer, _TransactionID++, out CancelID, out aE);
            theGrp.ReadCompleted += theGrp_ReadCompleted;
        }

        void theGrp_ReadCompleted(object sender, ReadCompleteEventArgs e)
        {


        }

        public void Write()
        {
            Thread t = new Thread(new ThreadStart(DoWrite));
            _Watchdog.Start();
            t.Start();
        }

        private void DoWrite()
        {
            int CancelID;
            int[] aE;
            bool temp = false;

            try
            {
                temp = theGrp.Write(_HandleServer, ItemsValue.ToArray(), _TransactionID++, out CancelID, out aE);
                NumberOfSendingKB += (float)ItemsValue.Count / 1024;
                if (CancelID != 0)
                {
                    _CancelID.Add(CancelID);
                }
            }
            catch (Exception)
            { }
        }

        private void theGrp_WriteCompleted(object sender, WriteCompleteEventArgs e)
        {
            IsWriteSuccess = true;
            if (_CancelID.Count > 0)
            {
                _CancelID.RemoveAt(_CancelID.Count - 1);
            }
            for (int j = 0; j < e.res.Length; j++)
            {
                OPCWriteResult r = e.res[j];
                ItemsStatus[j] = HRESULTS.Succeeded(r.Error);
                IsWriteSuccess = IsWriteSuccess & ItemsStatus[j];
            }
            IsWriteComplete = true;
            theGrp.Active = false;
            _Retry = 0;
            _Watchdog.Stop();
        }

        private void theGrp_CancelCompleted(object sender, CancelCompleteEventArgs e)
        {

        }

        public void Disconnect()
        {
            int[] aE;
            IsConnect = false;
            IsAddItemsSuccess = false;

            IsWriteComplete = true;
            IsWriteSuccess = true;

            theGrp.WriteCompleted -= new WriteCompleteEventHandler(this.theGrp_WriteCompleted);
            if (_HandleServer != null)
            {
                theGrp.RemoveItems(_HandleServer, out aE);
            }

            theGrp.Remove(true);
            theGrp = null;
            theSrv.Disconnect();
        }

        public void ResetRetryCounter()
        {
            _Retry = 0;
        }
    }

    public class OPCsAccess : MarshalByRefObject
    {
        private Dictionary<string, OPCAccess> _OPCs;

        public OPCsAccess()
        {
            _OPCs = new Dictionary<string, OPCAccess>();
        }

        public void Registry(string zoneName)
        {
            if (!_OPCs.ContainsKey(zoneName))
            {
                _OPCs.Add(zoneName, new OPCAccess());
            }
        }

        public void UnRegistry(string zoneName)
        {
            if (_OPCs.ContainsKey(zoneName))
            {
                _OPCs.Remove(zoneName);
            }
        }

        public bool InitItems(string zoneName, List<string> items, List<object> itemsValue)
        {
            bool res = false;
            if (_OPCs.ContainsKey(zoneName))
            {
                _OPCs[zoneName].InitItems(items, itemsValue);
                res = true;
            }
            return res;
        }

        public bool Connect(string zoneName)
        {
            bool res = false;
            if (_OPCs.ContainsKey(zoneName))
            {
                res = _OPCs[zoneName].Connect(zoneName);
            }

            return res;
        }

        public bool Write(string zoneName)
        {
            bool res = false;
            if (_OPCs.ContainsKey(zoneName))
            {
                _OPCs[zoneName].Write();
                res = true;
            }
            return res;
        }

        public bool Disconnect(string zoneName)
        {
            bool res = false;
            if (_OPCs.ContainsKey(zoneName))
            {
                _OPCs[zoneName].Disconnect();
            }
            return res;
        }

        public bool IsConnect(string zoneName)
        {
            bool res = false;
            if (_OPCs.ContainsKey(zoneName))
            {
                res = _OPCs[zoneName].IsConnect;
            }
            return res;
        }

        public bool IsWriteComplete(string zoneName)
        {
            bool res = false;
            if (_OPCs.ContainsKey(zoneName))
            {
                res = _OPCs[zoneName].IsWriteComplete;
            }
            return res;
        }

        public bool IsWriteSuccess(string zoneName)
        {
            bool res = false;
            if (_OPCs.ContainsKey(zoneName))
            {
                res = _OPCs[zoneName].IsWriteSuccess;
            }
            return res;
        }

        public List<bool> GetItemsStatus(string zoneName)
        {
            List<bool> res = new List<bool>();
            if (_OPCs.ContainsKey(zoneName))
            {
                res = _OPCs[zoneName].ItemsStatus;
            }
            return res;
        }

        public void ResetReTryCounter(string zoneName)
        {
            if (_OPCs.ContainsKey(zoneName))
            {
                _OPCs[zoneName].ResetRetryCounter();
            }
        }

        public void CloseAllConnection()
        {
            List<string> keys = _OPCs.Keys.ToList();
            for (int j = 0; j < keys.Count; j++)
            {
                if (_OPCs[keys[j]].IsConnect)
                {
                    _OPCs[keys[j]].Disconnect();

                }
            }
        }


        // scenario
        // 1st : Registry
        // 2nd : InitItems
        // 3rd : Connect
        // 4th : Write
        // 5th : check if IsWriteComplete : GetItemsStatus
        // 6th : Disconnect
    }
    #endregion

    #region version 2
    public class OPCClient : MarshalByRefObject
    {
        private const string serverProgID = "KEPware.KEPServerEx.V4";
        private const int numberOfReWrite = 2;
        private const int timeOut = 1000;
        private OpcServer theSrv;
        private OpcGroup theGrp;



        public Dictionary<string, HDOPCItem> Items;
        private int[] _HandleServer;
        private List<int> _CancelID;
        private int _TransactionID = 0;
        private int _MaxOfRetry = 5;
        private int _Retry;

        public bool IsWriteComplete;
        public bool IsConnect;
        public bool IsAddItemsSuccess;
        public bool IsWriteSuccess;
        public float NumberOfSendingKB;
        public float NumberOfReceivingKB;

        System.Timers.Timer _Watchdog;

        public OPCClient()
        {
            theSrv = new OpcServer();
            IsWriteComplete = true;
            IsWriteSuccess = true;
            IsConnect = false;
            IsAddItemsSuccess = false;
            NumberOfReceivingKB = 0;
            NumberOfSendingKB = 0;
            _Retry = 0;
            _CancelID = new List<int>();

            Items = new Dictionary<string, HDOPCItem>();

            _Watchdog = new System.Timers.Timer();
            _Watchdog.AutoReset = true;
            _Watchdog.Interval = 60000;
            _Watchdog.Elapsed += _Watchdog_Elapsed;
        }

        private void _Watchdog_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _Watchdog.Stop();
            for (int j = 0; j < _CancelID.Count; j++)
            {
                theGrp.Cancel2(_CancelID[j]);
            }

            _CancelID.Clear();
            _Watchdog.Start();
        }

        public void InitItems(List<string> itemsName, List<string> itemsAddress, List<object> itemsValue)
        {
            // init tags
            Items.Clear();
            for (int j = 0; j < itemsName.Count; j++)
            {
                HDOPCItem item = new HDOPCItem();
                item.Name = itemsName[j];
                item.Address = itemsAddress[j];
                item.Value = itemsValue[j];
                item.Def = new OPCItemDef(itemsAddress[j], true, j, VarEnum.VT_EMPTY);
                Items.Add(item.Name, item);
            }
        }

        public bool Connect(string groupName)
        {
            bool res = false;

            IsWriteComplete = false;
            IsWriteSuccess = false;

            if (_Retry < _MaxOfRetry)
            {
                _Retry++;
                if (IsConnect == false)
                {
                    theSrv.Connect(serverProgID);
                    Thread.Sleep(500);
                    IsConnect = true;
                }
                else
                {
                    if (IsWriteComplete == false)
                    {
                        theSrv.Disconnect();
                        Thread.Sleep(500);
                        theSrv.Connect(serverProgID);
                        Thread.Sleep(500);
                    }
                }

                if (theGrp == null)
                {
                    theGrp = theSrv.AddGroup(groupName, false, 500);
                }
                else
                {
                    if (IsWriteComplete == false)
                    {
                        theGrp.Remove(true);
                        theGrp = theSrv.AddGroup(groupName, false, 500);
                        IsAddItemsSuccess = false;
                    }
                }

                if (IsAddItemsSuccess == false)
                {
                    List<string> keys = Items.Keys.ToList();
                    bool temp = false;
                    for (int offset = 0; offset < keys.Count; offset++)
                    {
                        OPCItemResult[] rItm;
                        OPCItemDef[] _ItemDefs = new OPCItemDef[1];
                        _ItemDefs[0] = Items[keys[offset]].Def;

                        theGrp.AddItems(_ItemDefs.ToArray(), out rItm);
                        if (rItm != null)
                        {
                            temp = temp || HRESULTS.Failed(rItm[0].Error);
                            Items[keys[offset]].HandleServer = rItm[0].HandleServer;
                        }
                    }

                    //      if (temp == false) // success to add items to group
                    {
                        IsAddItemsSuccess = true;
                        theGrp.SetEnable(false);
                        theGrp.Active = true;
                        theGrp.DataChanged += theGrp_DataChanged;

                        Thread.Sleep(500);
                        res = true;
                    }
                    //else
                    //{
                    //    IsAddItemsSuccess = false;
                    //}

                }
                else
                {
                    res = true;
                    theGrp.Active = true;
                }
            }
            else
            {

            }
            return res;
        }

        private void theGrp_DataChanged(object sender, DataChangeEventArgs e)
        {
            foreach (OPCItemState state in e.sts)
            {
                var query = (from q in Items.Values
                             where q.Def.HandleClient == state.HandleClient
                             select q).FirstOrDefault();
                if (query != null)
                {
                    query.Value = state.DataValue;
                }

            }
        }

        public object Read(string tagAddress)
        {
            object res = null;
            var query = (from q in Items.Values
                         where q.Address == tagAddress
                         select q).FirstOrDefault();
            if (query != null)
            {
                string tagName = query.Name;
                if (IsConnect)
                {
                    res = Items[tagName].Value;
                    NumberOfReceivingKB += (float)1 / 1024;
                    BackgroundWorker readWorker = new BackgroundWorker();
                    readWorker.DoWork += readWorker_DoWork;
                    readWorker.RunWorkerAsync(tagName);
                }
            }

            return res;
        }

        private void readWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            OPCItemState[] states = null;
            string tagName = (string)e.Argument;
            theGrp.Read(OPCDATASOURCE.OPC_DS_CACHE, new int[] { Items[tagName].HandleServer }, out states);
            if ((states != null) && (states.Length > 0))
            {
                Items[tagName].Value = states[0].DataValue;
            }
        }

        public void Write(string tagAddress, object value)
        {
            var query = (from q in Items.Values
                         where q.Address == tagAddress
                         select q).FirstOrDefault();
            if (query != null)
            {
                string tagName = query.Name;
                BackgroundWorker woker = new BackgroundWorker();
                woker.DoWork += woker_DoWork;
                woker.RunWorkerAsync(new object[] { tagName, value });
            }
        }

        private void woker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] param = (object[])e.Argument;
            string tagName = (string)param[0];
            object value = param[1];
            if (Items.ContainsKey(tagName))
            {
                if (IsConnect)
                {
                    int[] eA = null;
                    NumberOfSendingKB += (float)4 / 1024;
                    theGrp.Write(new int[] { Items[tagName].HandleServer }, new object[] { value }, out eA);
                    Thread.Sleep(500);
                    if ((eA != null) && (eA.Length > 0))
                    {
                        Items[tagName].Error = eA[0];
                    }
                }
            }
        }

        public void Disconnect()
        {
            int[] aE;
            try
            {
                IsConnect = false;
                IsAddItemsSuccess = false;

                IsWriteComplete = true;
                IsWriteSuccess = true;

                theGrp.DataChanged -= theGrp_DataChanged;
                if ((_HandleServer != null) && (theGrp != null))
                {
                    theGrp.RemoveItems(_HandleServer, out aE);
                    theGrp.Remove(true);
                    theGrp = null;
                }
                theSrv.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if ((_HandleServer != null) && (theGrp != null))
                {
                    theGrp.RemoveItems(_HandleServer, out aE);
                    theGrp.Remove(true);
                    theGrp = null;
                }
                theSrv.Disconnect();
            }
        }

        public void ResetRetryCounter()
        {
            _Retry = 0;
        }
    }

    public class OPCsClientDriver : MarshalByRefObject, ITLCDriver
    {
        private string _Version = "OPC Client V2.0.1"; // updated 25-8-2014

        private Dictionary<int, OPCClient> _OPCs;

        public OPCsClientDriver()
        {
            _OPCs = new Dictionary<int, OPCClient>();
        }

        public void Registry(int port)
        {
            if (!_OPCs.ContainsKey(port))
            {
                _OPCs.Add(port, new OPCClient());
            }
        }

        public void UnRegistry(int port)
        {
            if (_OPCs.ContainsKey(port))
            {
                _OPCs.Remove(port);
            }
        }

        public bool Connect(int port)
        {
            bool res = false;
            if (_OPCs.ContainsKey(port))
            {
                res = _OPCs[port].Connect(port.ToString());
            }

            return res;
        }

        public bool Write(int port, string tagAddress, object value)
        {
            bool res = false;
            if (_OPCs.ContainsKey(port))
            {
                _OPCs[port].Write(tagAddress, value);
                res = true;
            }
            return res;
        }

        public bool Disconnect(int port)
        {
            bool res = false;
            if (_OPCs.ContainsKey(port))
            {
                _OPCs[port].Disconnect();
            }
            return res;
        }

        public bool IsConnect(int port)
        {
            bool res = false;
            if (_OPCs.ContainsKey(port))
            {
                res = _OPCs[port].IsConnect;
            }
            return res;
        }

        public int GetItemsStatus(int port, string tagName)
        {
            int res = -1;
            if (_OPCs.ContainsKey(port))
            {
                res = _OPCs[port].Items[tagName].Error;
            }
            return res;
        }

        public void ResetReTryCounter(int port)
        {
            if (_OPCs.ContainsKey(port))
            {
                _OPCs[port].ResetRetryCounter();
            }
        }

        public void CloseAllConnection()
        {
            List<int> keys = _OPCs.Keys.ToList();
            for (int j = 0; j < keys.Count; j++)
            {
                if (_OPCs[keys[j]].IsConnect)
                {
                    _OPCs[keys[j]].Disconnect();

                }
            }
        }

        // scenario
        // 1st : Registry
        // 2nd : InitItems
        // 3rd : Connect
        // 4th : Write/Read
        // 5th : check if IsWriteComplete : GetItemsStatus
        //    // 6th : Disconnect

        #region itlc driver interface
        public string GetDriverVersion()
        {
            return _Version;
        }

        public bool GetTagValue(int port, string tagAddress, List<int> parametter, out object result, out DateTime time)
        {
            bool res = false;
            result = null;
            time = DateTime.Now;
            if (_OPCs.ContainsKey(port))
            {
                result = _OPCs[port].Read(tagAddress);
                if (result != null)
                {
                    res = true;
                }
            }

            return res;
        }

        public bool SetTagValue(int port, string tagAddress, object[] data)
        {
            return Write(port, tagAddress, data[0]);
        }

        public bool IsWriteComplete(int port)
        {
            bool res = false;
            if (_OPCs.ContainsKey(port))
            {
                res = _OPCs[port].IsWriteComplete;
            }
            return res;
        }

        public int IsWriteSuccess(int port)
        {
            int res = -1;
            if (_OPCs.ContainsKey(port))
            {
                res = (_OPCs[port].IsWriteSuccess == true) ? 0 : 1;
            }
            return res;
        }

        public void RemoveDevice(int port)
        {
            UnRegistry(port);
        }

        public void Start(string ioServerIP, List<int> ports)
        {
            for (int j = 0; j < ports.Count; j++)
            {
                Registry(ports[j]);
            }
        }

        public void Stop()
        {
            CloseAllConnection();
        }

        public float GetNumberOfSendingKB(int port)
        {
            float res = 0;
            if (_OPCs.ContainsKey(port))
            {
                res = _OPCs[port].NumberOfSendingKB;
            }
            return res;
        }

        public float GetNumberOfReceivingKB(int port)
        {
            float res = 0;
            if (_OPCs.ContainsKey(port))
            {
                res = _OPCs[port].NumberOfReceivingKB;
            }
            return res;
        }

        public void ResetDataTrafficCounter(int port)
        {
            if (_OPCs.ContainsKey(port))
            {
                _OPCs[port].NumberOfSendingKB = 0;
                _OPCs[port].NumberOfReceivingKB = 0;
            }
        }

        public void InitializeTags(int port, List<string> tagName, List<string> tagAddress, List<object> tagValue)
        {
            Registry(port);
            _OPCs[port].InitItems(tagName, tagAddress, tagValue);
            _OPCs[port].Connect(port.ToString());
        }
        #endregion


    }
    #endregion

    #region version 3
    public class HDOPCItem : MarshalByRefObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int HandleClient
        {
            get
            {
                int res = 0;
                if (Def != null)
                {
                    res = Def.HandleClient;
                }
                return res;
            }
            set
            {
                if (Def != null)
                {
                    Def.HandleClient = value;
                }
            }
        }
        public int HandleServer { get; set; }
        public object Value { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Quality { get; set; }
        public int Error { get; set; } // 0: OK
        public OPCItemDef Def { get; set; }

        public HDOPCGroup Group { get; set; }


        public HDOPCItem()
        {

        }
    }

    public class HDOPCGroup : MarshalByRefObject
    {
        public float NumberOfSendingKB { get; set; }
        public float NumberOfReceivingKB { get; set; }

        public bool IsConnect { get; set; }
        public string Name
        {
            get
            {
                string res = "";
                if (Group != null)
                {
                    res = Group.Name;
                }
                return res;
            }
        }

        public OpcGroup Group { get; set; }

        public List<HDOPCItem> Items { get; set; }

        public HDOPCGroup(OpcGroup group)
        {
            Group = group;
            Items = new List<HDOPCItem>();
            IsConnect = true;
        }

        public void AddItem(HDOPCItem item)
        {
            Items.Add(item);
            item.Group = this;
        }
    }

    public class HDOPCClient : MarshalByRefObject, ITLCDriver
    {
    //    private string _Version = "OPC Client V3.0.0"; // updated 30-1-2015
        private string _Version = "OPC Client V3.0.1"; // updated 3-2-2015
        private const string serverProgID = "KEPware.KEPServerEx.V4";
        private const int timeOut = 1000;

        private bool _IsConnect { get; set; }

        public OpcServer Client { get; set; }

        public Dictionary<string, HDOPCGroup> Groups { get; set; }

        public Dictionary<string, List<HDOPCItem>> DataSource { get; set; }

        public HDOPCClient()
        {
            Groups = new Dictionary<string, HDOPCGroup>();
            DataSource = new Dictionary<string, List<HDOPCItem>>();
        }

        public void Connect()
        {
            _IsConnect = false;
            try
            {
                Disconnect();
                Client = new OpcServer();
                Client.Connect(serverProgID);
                Groups = new Dictionary<string, HDOPCGroup>();
                _IsConnect = true;
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        public void Disconnect()
        {
            try
            {
                if (Client != null)
                {
                    Client.Disconnect();
                    _IsConnect = false;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        public bool AddGroup(string groupName)
        {
            bool res = false;
            try
            {
                if (_IsConnect == true)
                {
                    if (!Groups.ContainsKey(groupName))
                    {
                        Groups.Add(groupName, null);
                    }
                    OpcGroup group = Client.AddGroup(groupName, true, 500);
                    Groups[groupName] = new HDOPCGroup(group);
                    Groups[groupName].IsConnect = true;
                    Groups[groupName].Group.DataChanged += Group_DataChanged;
                    res = true;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
            return res;
        }

        private void Group_DataChanged(object sender, DataChangeEventArgs e)
        {
            HDOPCGroup grp = (from q in Groups.Values
                              where q.Group.Equals(sender)
                              select q).FirstOrDefault();
            if (grp != null)
            {
                foreach (OPCItemState state in e.sts)
                {
                    var query = (from q in grp.Items
                                 where q.Def.HandleClient == state.HandleClient
                                 select q).FirstOrDefault();
                    if (query != null)
                    {
                        query.Value = state.DataValue;
                        query.TimeStamp = DateTime.Now;// new DateTime(state.TimeStamp);
                        query.Error = state.Error;
                    }

                }
            }
        }

        public bool AddItem(string groupName, HDOPCItem item)
        {
            bool res = false;
            try
            {
                if (_IsConnect)
                {
                    if (Groups.ContainsKey(groupName))
                    {
                        OPCItemResult[] rItm;
                        OPCItemDef[] itemDefs = new OPCItemDef[1] { item.Def };

                        Groups[groupName].Group.AddItems(itemDefs.ToArray(), out rItm);
                        if (rItm != null)
                        {
                            //   bool isError = HRESULTS.Failed(rItm[0].Error);
                            item.HandleServer = rItm[0].HandleServer;
                            item.Error = rItm[0].Error;
                        }
                        Groups[groupName].AddItem(item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
            return res;
        }

        public void InitItems(string groupName, List<string> itemsName, List<string> itemsAddress, List<object> itemsValue)
        {
            if (!DataSource.ContainsKey(groupName))
            {
                DataSource.Add(groupName, new List<HDOPCItem>());
            }
            else
            {
                DataSource[groupName].Clear();
            }

            for (int j = 0; j < itemsName.Count; j++)
            {
                HDOPCItem item = new HDOPCItem();
                item.Name = itemsName[j];
                item.Address = itemsAddress[j];
                item.Value = itemsValue[j];
                item.Def = new OPCItemDef(itemsAddress[j], true, j, VarEnum.VT_EMPTY);
                DataSource[groupName].Add(item);
            }

        }

        public void Read(string groupName, string itemAddress)
        {
            if (_IsConnect)
            {
                if (Groups.ContainsKey(groupName))
                {
                    var query = (from q in Groups[groupName].Items
                                 where q.Address == itemAddress
                                 select q).FirstOrDefault();
                    if (query != null)
                    {
                        OPCItemState[] states = null;
                        Groups[groupName].Group.Read(OPCDATASOURCE.OPC_DS_CACHE, new int[] { query.HandleServer }, out states);
                        if ((states != null) && (states.Length > 0))
                        {
                            query.Value = states[0].DataValue;
                            query.TimeStamp = new DateTime(states[0].TimeStamp);
                            query.Quality = (int)states[0].Quality;
                        }
                    }
                }
            }
        }

        public void Write(string groupName, string itemAddress, object value)
        {
            if (Groups.ContainsKey(groupName))
            {
                var query = (from q in Groups[groupName].Items
                             where q.Address == itemAddress
                             select q).FirstOrDefault();
                if (query != null)
                {
                    BackgroundWorker woker = new BackgroundWorker();
                    woker.DoWork += woker_DoWork;
                    woker.RunWorkerAsync(new object[] { Groups[groupName], query, value });
                }
            }
        }

        private void woker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] param = (object[])e.Argument;
            HDOPCGroup group = (HDOPCGroup)param[0];
            HDOPCItem item = (HDOPCItem)param[1];
            object value = param[2];

            if (_IsConnect)
            {
                int[] eA = null;
                group.NumberOfSendingKB += (float)8 / 1024;
                group.Group.Write(new int[] { item.HandleServer }, new object[] { value }, out eA);
                Thread.Sleep(500);
                if ((eA != null) && (eA.Length > 0))
                {
                    item.Error = eA[0];
                }
            }
        }

        private HDOPCItem GetItem(string groupName, string itemAddress)
        {
            HDOPCItem res = null;
            if (Groups.ContainsKey(groupName))
            {
                var query = (from q in Groups[groupName].Items
                             where q.Address == itemAddress
                             select q).FirstOrDefault();
                res = query;
            }
            return res;
        }
        private void LogException(Exception ex)
        {
            string message = string.Format("Sender :{0}\r\nMesseage :{1}\r\nInner :{2}", ex.Source, ex.Message, ex.InnerException);
            Logger.Log(message);
            MessageBox.Show(message);
        }

        #region itlc driver interface
        public string GetDriverVersion()
        {
            return _Version;
        }
        public bool IsConnect(int port)
        {
            bool res = false;
            if (_IsConnect)
            {
                if (Groups.ContainsKey(port.ToString()))
                {
                    if (Groups[port.ToString()] != null)
                    {
                        res = Groups[port.ToString()].IsConnect;
                    }
                }
            }
            return res;
        }

        public bool GetTagValue(int port, string tagAddress, List<int> parametter, out object result, out DateTime time)
        {
            bool res = false;
            result = null;
            time = DateTime.Now;
            Read(port.ToString(), tagAddress);
            HDOPCItem item = GetItem(port.ToString(), tagAddress);
            if (item != null)
            {
                result = item.Value;
                time = item.TimeStamp;
                if (result != null)
                {
                    res = true;
                }
            }
            return res;
        }

        public bool SetTagValue(int port, string tagAddress, object[] data)
        {
            Write(port.ToString(), tagAddress, data[0]);
            return true;
        }

        public bool IsWriteComplete(int port)
        {
            return true;
        }

        public int IsWriteSuccess(int port)
        {
            return 0;
        }

        public void RemoveDevice(int port)
        {

        }

        public void Start(string ioServerIP, List<int> ports)
        {
            // connect
            // add group
            // add item
            Connect();
            foreach (string groupName in DataSource.Keys)
            {
                if (AddGroup(groupName))
                {
                    foreach (HDOPCItem item in DataSource[groupName])
                    {
                        AddItem(groupName, item);
                    }
                }

            }
        }

        public void Stop()
        {
            // disconnect
            Disconnect();
        }

        public float GetNumberOfSendingKB(int port)
        {
            float res = 0;
            if (Groups.ContainsKey(port.ToString()))
            {
                res = Groups[port.ToString()].NumberOfSendingKB;
            }

            return res;
        }

        public float GetNumberOfReceivingKB(int port)
        {
            float res = 0;
            if (Groups.ContainsKey(port.ToString()))
            {
                res = Groups[port.ToString()].NumberOfReceivingKB;
            }
            return res;
        }

        public void ResetDataTrafficCounter(int port)
        {
            if (Groups.ContainsKey(port.ToString()))
            {
                Groups[port.ToString()].NumberOfSendingKB = 0;
                Groups[port.ToString()].NumberOfReceivingKB = 0;
            }

        }

        public void InitializeTags(int port, List<string> tagName, List<string> tagAddress, List<object> tagValue)
        {
            InitItems(port.ToString(), tagName, tagAddress, tagValue);
        }
        #endregion
    }

    public class OPCHost : MarshalByRefObject
    {
        #region host server
        public static string OPCAUrl = "";
        private static TcpChannel _Channel = null;
        public static ITLCDriver Server;

        public static void StartServer(string serverIP, int port)
        {
            if (_Channel == null)
            {
                OPCAUrl = string.Format("tcp://{0}:{1}/OPCA", serverIP, port);
                System.Collections.IDictionary props = new System.Collections.Hashtable();
                props["name"] = "OPCChannel";
                props["port"] = port;
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

                RemotingConfiguration.RegisterWellKnownServiceType(typeof(HDOPCClient), "OPCA", WellKnownObjectMode.Singleton);
            }

            Server = (HDOPCClient)Activator.GetObject(typeof(HDOPCClient), OPCAUrl);
        }

        public static void ConnectToServer(string serverIP, int serverPort)
        {
            try
            {
                OPCAUrl = string.Format("tcp://{0}:{1}/OPCA", serverIP, serverPort);
                //   ChannelServices.RegisterChannel(new TcpClientChannel(), false);
                Server = (HDOPCClient)Activator.GetObject(typeof(HDOPCClient), OPCAUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException);
                //StopApplication();
            }
        }
        #endregion
    }
    #endregion
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using IODriver;

using Designer.Model;
using Common;
using IODriver;
using DriverCommon;

namespace Designer.Core
{
    public class Root
    {
        Dictionary<string, Task> Tasks { get; set; }
        Dictionary<int, Display> Displays { get; set; }
        public Dictionary<string, Alarm> Alarms { get; set; }
        Dictionary<IOTag, List<IDisplayTag>> Mapping;
        Dictionary<DriverType, Driver> IDriver;
        int DipslayIDCounter = 0;

        public Root()
        {
            Tasks = new Dictionary<string, Task>();
            Displays = new Dictionary<int, Display>();
            Alarms = new Dictionary<string, Alarm>();
            IDriver = new Dictionary<DriverType, Driver>();
        }

        #region Initilization
        public void Initialize()
        {
            Initialize_Task_Tag();
            Initialize_Display();
            Initialize_Alarm();
            Initialize_Mapping();
            Initialize_Driver();
        }

        private void Initialize_Driver()
        {
            IDriver = new Dictionary<DriverType, Driver>();
            INotification iNotify = new EmailNotification();

            // VDK Driver
            ITLCDriver vdkDriver = null;
            string serverIP = Properties.Settings.Default.DriverServerIP;
            int vdkPort = Properties.Settings.Default.VDKPort;
            Driver driver = new Driver(DriverType.VDK, vdkDriver, iNotify, serverIP, vdkPort);
            this.AddDriver(driver);

            // OPC Driver
            ITLCDriver opcDriver = null;
            int opcPort = Properties.Settings.Default.OPCPort;
            Driver driver1 = new Driver(DriverType.OPC, opcDriver, iNotify, serverIP, opcPort);
            this.AddDriver(driver1);

            List<Device> devs = DBAccess.GetDevices();
            foreach (Device dev in devs)
            {
                if (dev.Driver == Common.DriverType.OPC.ToString())
                {
                    List<string> tagName = new List<string>();
                    List<string> tagAddress = new List<string>();
                    List<object> tagValue = new List<object>();
                    foreach (IOTag ioTag in dev.IOTags.ToList())
                    {
                        tagName.Add(ioTag.Name);
                        tagAddress.Add(ioTag.Address);
                        tagValue.Add(new object());
                    }

                    driver1.InitializeTags((int)dev.Port, tagName, tagAddress, tagValue);
                }
            }
            driver1.IODriver.Start("", null);
        }

        private void Initialize_Task_Tag()
        {
            Tasks = null;
            Tasks = new Dictionary<string, Task>();
            Dictionary<string, List<IOTag>> tagGroups = DBAccess.GetTagGroups();
            List<string> keys = tagGroups.Keys.ToList();

            for (int j = 0; j < keys.Count; j++)
            {
                int updateRating = (int)tagGroups[keys[j]][0].UpdateRating;
                Task t = new Task(keys[j], updateRating);
                foreach (IOTag tag in tagGroups[keys[j]])
                {
                    t.AddTag(tag);
                }
                AddTask(t);
            }
        }

        private void Initialize_Display()
        {
            Displays = null;
            Displays = new Dictionary<int, Display>();
        }

        private void Initialize_Alarm()
        {
            Alarms = new Dictionary<string, Alarm>();
            Dictionary<string, List<AlarmTag>> tagGroups = DBAccess.GetAlarmTagGroups();
            List<string> keys = tagGroups.Keys.ToList();

            for (int j = 0; j < keys.Count; j++)
            {
                int updateRating = (int)tagGroups[keys[j]][0].UpdateRating;
                Alarm t = new Alarm(keys[j], updateRating);
                foreach (AlarmTag tag in tagGroups[keys[j]])
                {
                    t.AddTag(tag);
                }
                AddAlarmTask(t);
            }
        }

        private void Initialize_Mapping()
        {
            //Mapping = new Dictionary<IOTag, List<IDisplayTag>>();
            //foreach (Task task in Tasks.Values)
            //{
            //    foreach (IOTag tag in task.Tags.Values)
            //    {
            //        Mapping.Add(tag, new List<IDisplayTag>());
            //    }
            //}
        }

        public void Reinit()
        {
            Tasks.Clear();
            Displays.Clear();
            Initialize_Task_Tag();
            Initialize_Display();
            Initialize_Alarm();
        }

        #region dont use any more
        public void RegistryDisplayTagMapping(IDisplayTag disp)
        {
            //IOTag query = (from q in Mapping.Keys
            //               where q.Name == disp.Address
            //               select q).FirstOrDefault();
            //if (query != null)
            //{
            //    Mapping[query].Add(disp);
            //}

            //if (!((Display)Displays["Display1"]).DisplayTags.ContainsKey(disp.Address))
            //{
            //    ((Display)Displays["Display1"]).DisplayTags.Add(disp.Address, new List<IDisplayTag>());
            //}

            //((Display)Displays["Display1"]).DisplayTags[disp.Address].Add(disp);

        }

        public void RemoveDisplayTagMapping(IDisplayTag disp)
        {
            //IOTag query = (from q in Mapping.Keys
            //               where q.Name == disp.Address
            //               select q).FirstOrDefault();
            //if (query != null)
            //{
            //    if (Mapping[query].Contains(disp))
            //    {
            //        Mapping[query].Remove(disp);
            //    }
            //}
        }
        #endregion

        #endregion

        #region Task
        public Task FindTask(string taskName)
        {
            Task task = null;
            if (Tasks.ContainsKey(taskName))
            {
                task = (Task)Tasks[taskName];
            }
            return task;
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task.Name, task);
            task.Parent = this;
        }

        public void RunTask(string taskname)
        {
            if (Tasks.ContainsKey(taskname))
            {
                ((Task)Tasks[taskname]).Run();
            }
        }

        public void RunTask()
        {
            List<string> keys = Tasks.Keys.ToList();
            for (int j = 0; j < keys.Count; j++)
            {
                ((Task)Tasks[keys[j]]).Run();
            }
        }

        public void StopTask()
        {
            foreach (Task task in Tasks.Values)
            {
                task.Stop();
            }
        }
        #endregion

        #region Alarm
        public Alarm FindAlarmTask(string taskName)
        {
            Alarm task = null;
            if (Alarms.ContainsKey(taskName))
            {
                task = (Alarm)Alarms[taskName];
            }
            return task;
        }

        public void AddAlarmTask(Alarm alarm)
        {
            Alarms.Add(alarm.Name, alarm);
            alarm.Parent = this;
        }

        public void RunAlarmTask(string taskname)
        {
            if (Alarms.ContainsKey(taskname))
            {
                ((Alarm)Alarms[taskname]).Run();
            }
        }

        public void RunAlarmTask()
        {
            List<string> keys = Alarms.Keys.ToList();
            for (int j = 0; j < keys.Count; j++)
            {
                ((Alarm)Alarms[keys[j]]).Run();
            }
        }

        public void RefeshAlarmTask(string taskName)
        {

        }

        public void StopAlarmTask()
        {
            foreach (Alarm task in Alarms.Values)
            {
                task.Stop();
            }
        }
        #endregion

        #region Display
        public int AddDisplay(Display disp)
        {
            DipslayIDCounter++;
            this.Displays.Add(DipslayIDCounter, disp);
            disp.Parent = this;
            disp.Run();
            return DipslayIDCounter;
        }

        public void RemoveDisplay(int displayID)
        {
            if (Displays.ContainsKey(displayID))
            {
                Displays[displayID].Stop();
                Displays.Remove(displayID);
            }
        }

        public void RemoveDisplay()
        {
            List<int> keys = Displays.Keys.ToList();
            for (int j = keys.Count - 1; j >= 0; j--)
            {
                RemoveDisplay(j);
            }
        }

        public void RunDisplayTask(int displayID)
        {
            if (Displays.ContainsKey(displayID))
            {
                Displays[displayID].Run();
            }
        }

        public void StopDisplay(int displayID)
        {
            if (Displays.Count > displayID)
            {
                Displays[displayID].Stop();
            }
        }

        public Display FindDisplay(int displayID)
        {
            Display res = null;
            if (Displays.ContainsKey(displayID))
            {
                res = Displays[displayID];
            }
            return res;
        }

        public string GetDisplayTagAddress(string ioTagName)
        {
            string res = "";
            IOTag ioTag = DBAccess.GetIOTag(ioTagName);
            if (ioTag != null)
            {
                res = string.Format("{0}.{1}.{2}", ioTag.Device.Name, ioTag.UpdateRating, ioTag.Name);
            }
            return res;
        }

        #endregion

        #region Driver
        public Driver FindDriver(DriverType driverType)
        {
            Driver res = null;
            if (IDriver.ContainsKey(driverType))
            {
                res = IDriver[driverType];
            }
            return res;
        }

        public void AddDriver(Driver driver)
        {
            IDriver.Add(driver.Type, driver);
            driver.Parent = this;
        }

        public void StopDriver()
        {
            foreach (Driver driver in IDriver.Values)
            {
                driver.Stop();
            }
        }
        #endregion

        #region mapping
        public void UpdateValueForDisplayTag(IOTag tag)
        {
            // Display display = (Display)this.Displays["Display1"];
            //var query = (from q in display.DisplayTags
            //             where q.Key == tag.Name
            //             select q.Value).FirstOrDefault();

            //if (query != null)
            //{
            //    for (int j = 0; j < query.Count; j++)
            //    {
            //        IDisplayTag disp = query[j];
            //        if (disp != null)
            //        {
            //            switch ((int)tag.DataType)
            //            {
            //                case (int)DataType.Bool:
            //                    bool b = false;
            //                    if (bool.TryParse(tag.Value, out b))
            //                    {
            //                        disp.Value = b;
            //                    }
            //                    break;
            //                case (int)DataType.Double:
            //                    double db = 0;
            //                    if (double.TryParse(tag.Value, out db))
            //                    {
            //                        disp.Value = db;
            //                    }
            //                    break;
            //                case (int)DataType.Int16:
            //                    Int16 i16 = 0;
            //                    if (Int16.TryParse(tag.Value, out i16))
            //                    {
            //                        disp.Value = i16;
            //                    }
            //                    break;
            //                case (int)DataType.Int32:
            //                    int i32 = 0;
            //                    if (int.TryParse(tag.Value, out i32))
            //                    {
            //                        disp.Value = i32;
            //                    }
            //                    break;
            //                case (int)DataType.Int8:
            //                    byte i8 = 0;
            //                    if (byte.TryParse(tag.Value, out i8))
            //                    {
            //                        disp.Value = i8;
            //                    }
            //                    break;
            //                case (int)DataType.String:
            //                    disp.Value = tag.Value;
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //          //  ((Display)Displays["Display1"]).DisplayTags[disp.Address].Remove(disp);
            //        }
            //    }
            //}


        }
        #endregion
    }
}

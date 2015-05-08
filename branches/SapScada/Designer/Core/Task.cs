using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

using Designer.Model;
using Common;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Designer.Core
{
    public class Task
    {
        private System.Windows.Forms.Timer _Timer = null;
        private BackgroundWorker _BackgroundWorker = null;
        private bool _IsUpdateComplete = false;
        public string Name;
        public int Period;
        public Dictionary<string, IOTag> Tags = null;
        public Root Parent;
        public bool IsRunning { get; set; }

        public Task(string name, int period)
        {
            Name = name;
            Period = period;
            Tags = new Dictionary<string, IOTag>();
            _BackgroundWorker = new BackgroundWorker();
            _BackgroundWorker.DoWork += _BackgroundWorker_DoWork;
            _BackgroundWorker.RunWorkerCompleted += _BackgroundWorker_RunWorkerCompleted;
        }

        private void _BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (IsRunning == true)
            {
                _BackgroundWorker.RunWorkerAsync();
            }
        }

        private void _BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateTags();
            Thread.Sleep(Period);
        }

        public void AddTag(IOTag tag)
        {
            tag.Parent = this;
            Tags.Add(tag.Name, tag);
        }

        public IOTag FindTag(string name)
        {
            IOTag tag = null;
            if (Tags.ContainsKey(name))
            {
                tag = (IOTag)Tags[name];
            }
            return tag;
        }

        public void Run()
        {
            if (Period > 0)
            {
                IsRunning = true;
                _BackgroundWorker.RunWorkerAsync();
            }
        }

        public void Stop()
        {
            IsRunning = false;
        }

        private void UpdateTags()
        {
            foreach (IOTag tag in Tags.Values.ToList())
            {
                GetTagValue(tag.Name, null);
                Thread.Sleep(50);
            }
        }

        public void SetTagValue(string tagName, object[] data)
        {
            IOTag tag = FindTag(tagName);
            if (tag != null)
            {
                Driver driver = null;
                if (tag.Device.Driver == DriverType.VDK.ToString())
                {
                    driver = this.Parent.FindDriver(DriverType.VDK);
                }
                else if (tag.Device.Driver == DriverType.OPC.ToString())
                {
                    driver = this.Parent.FindDriver(DriverType.OPC);
                }

                if (driver != null)
                {
                    driver.SetTagValue(tag, data);
                }
            }
        }

        public bool GetTagValue(string tagName, List<int> param)
        {
            bool res = false;
            IOTag tag = FindTag(tagName);
            if (tag != null)
            {
                Driver driver = null;
                if (tag.Device.Driver == DriverType.VDK.ToString())
                {
                    driver = this.Parent.FindDriver(DriverType.VDK);
                }
                else if (tag.Device.Driver == DriverType.OPC.ToString())
                {
                    driver = this.Parent.FindDriver(DriverType.OPC);
                }

                if (driver != null)
                {
                    object data = null;
                    res = driver.GetTagValue(tag, param, out data);
                }
            }
            return res;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Common;
using Designer.Model;
using System.ComponentModel;
using System.Threading;

namespace Designer.Core
{
    public class Display
    {
        public int ID;
        public int Period;
        public Dictionary<string, List<IDisplayTag>> DisplayTags = null;
        public Root Parent;
        public bool IsRunning { get; set; }

        private BackgroundWorker _BackgroundWorker = null;
        private System.Timers.Timer _Timer { get; set; }

        public Display(int period)
        {
            ID = 0;
            Period = period;
            IsRunning = false;
            DisplayTags = new Dictionary<string, List<IDisplayTag>>();
            _BackgroundWorker = new BackgroundWorker();
            _BackgroundWorker.WorkerSupportsCancellation = true;
            _BackgroundWorker.DoWork += _BackgroundWorker_DoWork;

            _Timer = new System.Timers.Timer();
            _Timer.Interval = period;
            _Timer.Elapsed += _Timer_Elapsed;
        }

     

       

        public void AddTag(IDisplayTag tag)
        {

            tag.Parent = this;
            if (DisplayTags.ContainsKey(tag.Name))
            {
                DisplayTags[tag.Name].Add(tag);
            }
            else
            {
                DisplayTags.Add(tag.Name, new List<IDisplayTag> { tag });
            }

            tag.RaiseUserChangeTagValueEvent += tag_RaiseUserChangeTagValueEvent;

        }

        private void tag_RaiseUserChangeTagValueEvent(object sender, EventArgs e)
        {
            IDisplayTag displayTag = (IDisplayTag)sender;
            if (displayTag != null)
            {
                Task task = null;
                string ioTagName = "";

                int index = displayTag.Address.IndexOf(".");
                if (index > -1)
                {
                    index += displayTag.Address.Substring(index + 1).IndexOf(".") + 1;
                    if (index > -1)
                    {
                        string taskName = displayTag.Address.Substring(0, index);
                        task = this.Parent.FindTask(taskName);
                        ioTagName = displayTag.Address.Substring(index + 1);
                    }
                }

                if (task != null)
                {
                    task.SetTagValue(ioTagName, new object[] { displayTag.UserValue });
                }
            }
        }

        public List<IDisplayTag> FindDisplayTag(string tagName)
        {
            List<IDisplayTag> res = new List<IDisplayTag>();
            if (DisplayTags.ContainsKey(tagName))
            {
                res = DisplayTags[tagName];
            }
            return res;
        }

        public void Run()
        {
            if (IsRunning == false)
            {
                if (Period > 0)
                {
                    IsRunning = true;
                    _Timer.Start();
                }
            }
        }

        public void Stop()
        {
            IsRunning = false;
            _Timer.Stop();
        }
      
        private void _BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateDisplayTag();
        }

        private void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!_BackgroundWorker.IsBusy)
            {
                _BackgroundWorker.RunWorkerAsync();
            }
        }

        private void UpdateDisplayTag()
        {

            #region
            // display tag Address = TaskName.TagName
            // TaskName = DeviceName.UpdateRating
            // TagName = DeviceName.TagAddress
            foreach (List<IDisplayTag> tags in DisplayTags.Values)
            {
                Task task = null;
                string ioTagName = "";
                object data = null;

                int index = tags[0].Address.IndexOf(".");
                if (index > -1)
                {
                    int temp = tags[0].Address.Substring(index + 1).IndexOf(".") + 1;
                    if (temp > -1)
                    {
                        index += temp;
                        string taskName = tags[0].Address.Substring(0, index);
                        task = this.Parent.FindTask(taskName);
                        ioTagName = tags[0].Address.Substring(index + 1);
                    }
                }

                if (task != null)
                {
                    IOTag iotag = task.FindTag(ioTagName);
                    if (iotag != null)
                    {
                        if ((iotag.Value2 != null))
                        {
                            switch ((DataType)iotag.DataType)
                            {
                                case DataType.Bool:
                                    bool b;
                                    if (bool.TryParse(iotag.Value2.ToString(), out b))
                                    {
                                        data = b;
                                    }
                                    break;
                                case DataType.Double:
                                    double d;
                                    if (double.TryParse(iotag.Value2.ToString(), out d))
                                    {
                                        data = d;
                                    }
                                    break;
                                case DataType.Int16:
                                    Int16 i16;
                                    if (Int16.TryParse(iotag.Value2.ToString(), out i16))
                                    {
                                        data = i16;
                                    }
                                    break;
                                case DataType.Int32:
                                    int i32;
                                    if (int.TryParse(iotag.Value2.ToString(), out i32))
                                    {
                                        data = i32;
                                    }
                                    break;
                                case DataType.Int8:
                                    byte by;
                                    if (byte.TryParse(iotag.Value2.ToString(), out by))
                                    {
                                        data = by;
                                    }
                                    break;
                                case DataType.Object:
                                    data = iotag.Value2;
                                    break;
                                case DataType.String:
                                    data = iotag.Value2.ToString();
                                    break;
                                case DataType.Datetime:
                                    data = ((DateTime)iotag.Value2).ToString("dd/MM/yyyy HH:mm:ss");
                                    break;
                            }

                            if (data != null)
                            {
                                foreach (IDisplayTag tag in tags)
                                {
                                    tag.Value = data;
                                }
                            }
                        }

                        if (iotag.UpdateRating <= 0)
                        {
                            task.GetTagValue(ioTagName, null);
                        }
                    }
                }
            }
            #endregion

        }

    }
}

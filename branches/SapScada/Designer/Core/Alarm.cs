using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Designer.Model;
using Common;
using System.ComponentModel;
using System.Threading;

namespace Designer.Model
{
    using Designer.Core;

    public partial class AlarmTag
    {
        public Alarm Parent { get; set; }
    }
}

namespace Designer.Core
{
    public class Alarm
    {
       
        private BackgroundWorker _BackgroundWorker = null;
     
        public string Name;
        public int Period;
        public Dictionary<string, AlarmTag> Tags = null;
        public Root Parent;
        public bool IsRunning { get; set; }

        public Alarm(string name, int period)
        {
            Name = name;
            Period = period;
            Tags = new Dictionary<string, AlarmTag>();
            _BackgroundWorker = new BackgroundWorker();
            _BackgroundWorker.DoWork += _BackgroundWorker_DoWork;
            _BackgroundWorker.RunWorkerCompleted += _BackgroundWorker_RunWorkerCompleted;
        }

        private void _BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(IsRunning == true)
            {
                _BackgroundWorker.RunWorkerAsync();
            }
        }

        private void _BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateTags();
            Thread.Sleep(Period);
        }

        public void AddTag(AlarmTag tag)
        {
            tag.Parent = this;
            Tags.Add(tag.Name, tag);
        }

        public AlarmTag FindTag(string name)
        {
            AlarmTag tag = null;
            if (Tags.ContainsKey(name))
            {
                tag = (AlarmTag)Tags[name];
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
            // display tag Address = TaskName.TagName
            // TaskName = DeviceName.UpdateRating
            // TagName = DeviceName.TagAddress
            foreach (AlarmTag tag in Tags.Values.ToList())
            {
                string taskName = string.Format("{0}.{1}", tag.IOTag.Device.Name, tag.IOTag.UpdateRating);
                string ioTagName = tag.IOTag.Name;

                Task task = this.Parent.FindTask(taskName);
                if (task != null)
                {
                    IOTag iotag = task.FindTag(ioTagName);
                    if ((iotag != null) && (iotag.Value2 != null))
                    {
                        switch ((AlarmType)tag.Type)
                        {
                            case AlarmType.Digital:
                                Type type = iotag.Value2.GetType();
                                AlarmValue temp = AlarmValue.True;

                                if (type == typeof(bool))
                                {
                                    if ((bool)iotag.Value2) temp = AlarmValue.True;
                                    else temp = AlarmValue.False;
                                }
                                else if (type == typeof(int))
                                {
                                    if ((int)iotag.Value2 != 0) temp = AlarmValue.True;
                                    else temp = AlarmValue.False;
                                }


                                if (tag.Value != (int)temp)
                                {
                                    tag.Value = (int)temp;
                                    tag.TimeStamp = DateTime.Now;

                                    if (((temp == AlarmValue.True) && ((AlarmOnWhen)tag.AlarmOnWhen == AlarmOnWhen.True))
                                      || ((temp == AlarmValue.False) && ((AlarmOnWhen)tag.AlarmOnWhen == AlarmOnWhen.False)))// new alarm : incoming
                                    {
                                        AlarmTagValue newAlarm = new AlarmTagValue();
                                        newAlarm.Value = (int)temp;
                                        newAlarm.TimeStampOn = (DateTime)tag.TimeStamp;
                                        newAlarm.Status = (int)AlarmStatus.Incomming;
                                        tag.AlarmTagValues.Add(newAlarm);

                                        // update to database
                                        if (DBAccess.UpdateAlarmTagValue(tag.Id, (AlarmValue)newAlarm.Value, newAlarm.TimeStampOn, AlarmStatus.Incomming))
                                        {
                                            // generate event
                                            OnAlarm(new AlarmEventArgs(newAlarm));
                                        }

                                    }
                                    else // outgoing
                                    {
                                        AlarmTagValue current = tag.AlarmTagValues.LastOrDefault();
                                        if (current != null)
                                        {
                                            current.Value = (int)temp;
                                            current.TimeStampOff = (DateTime)tag.TimeStamp;
                                            switch ((AlarmStatus)current.Status)
                                            {
                                                case AlarmStatus.Incomming:
                                                    current.Status = (int)AlarmStatus.Outgoing;
                                                    break;
                                                case AlarmStatus.Confirmed:
                                                    current.Status = (int)AlarmStatus.ConfirmedOutgoing;
                                                    break;
                                            }

                                            // update to database
                                            if (DBAccess.UpdateAlarmTagValue(tag.Id, (AlarmValue)current.Value, (DateTime)current.TimeStampOff, (AlarmStatus)current.Status))
                                            {
                                                // generate event
                                                OnAlarm(new AlarmEventArgs(current));
                                            }
                                        }
                                    }
                                }
                                break;
                            case AlarmType.Analog:
                                break;
                        }
                    }
                }

            }
        }

        public delegate void AlarmEventHandler(object sender, AlarmEventArgs a);
        public event AlarmEventHandler RaiseAlarmEvent;
        private void OnAlarm(AlarmEventArgs e)
        {
            if (RaiseAlarmEvent != null)
            {
                RaiseAlarmEvent(this, e);
            }
        }
    }

    public class AlarmEventArgs : EventArgs
    {
        public AlarmTagValue AlarmTagValue { get; set; }
        public AlarmEventArgs(AlarmTagValue alarmTagValue)
        {
            this.AlarmTagValue = alarmTagValue;
        }
    }
}

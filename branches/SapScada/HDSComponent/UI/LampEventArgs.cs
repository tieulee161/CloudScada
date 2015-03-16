using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDSComponent.UI
{
    public class LampEventArgs : EventArgs
    {
        public int OldLampID;
        public int LampID;
        public int Direction;
        public LampEventArgs(int oldLampID,int lampID, int direction)
        {
            OldLampID = oldLampID;
            LampID = lampID;
            Direction = direction;
        }
    }
}

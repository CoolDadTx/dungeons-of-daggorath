/****************************************
Daggorath PC-Port Version 0.2.1
Richard Hunerlach
November 13, 2002

The copyright for Dungeons of Daggorath
is held by Douglas J. Morgan.
(c) 1982, DynaMicro
*****************************************/
using System;
using System.Linq;

namespace DoD.Scheduling
{
    //TODO: Rename to avoid conflicts
    /// <summary>The new Task class for use in the rewritten Scheduler algorithm.</summary>
    /// <remarks>
    /// Not all fields are being used currently.  They may go away, if the current algorithm tests well, 
    /// otherwise, they may be used for increasing the accuracy of the scheduler.
    /// </remarks>
    public class Task
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Task"/> class.</summary>
        public Task ()
        {
            Clear();
        }
        #endregion

        public int type { get; set; } // One of the seven task types
        public int data { get; set; } // Stores creatures ID
        public uint frequency { get; set; } // in milliseconds
        public uint prev_time { get; set; } // previous execution timestamp
        public uint next_time { get; set; } // next scheduled execution timestamp
        public int count { get; set; } // number of times executed

        public void SetValues ( int t, int d, int f, int p, int n, int c, bool e )
        {
            type = t;
            data = d;

            //TODO: Should these be unsigned?
            frequency = (uint)f;
            prev_time = (uint)p;
            next_time = (uint)n;
            count = c;
        }

        public void Clear ()
        {
            type = -1;
            data = -1;
            frequency = 0;
            prev_time = 0;
            next_time = 0;
            count = 0;
        }
    }
}
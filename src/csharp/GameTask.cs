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

namespace DoD
{
    // MLT: Renamed to avoid confusion with System.Threading.Tasks.Task

    // The new Task class for use in the rewritten
    // Scheduler algorithm.  Not all fields are being
    // used currently.  They may go away, if the current
    // algorithm tests well, otherwise, they may be used
    // for increasing the accuracy of the scheduler.
    public class GameTask
    {
        public int type; // One of the seven task types
        public int data; // Stores creatures ID

        //TODO: Do these need to be uints?
        public uint frequency; // in milliseconds
        public uint prev_time; // previous execution timestamp
        public uint next_time; // next scheduled execution timestamp
        public int count; // number of times executed

        public GameTask ()
        {
            Clear();
        }

        // Convenience Setter
        public void SetValues ( int t, int d, int f, int p, int n, int c, bool e )
        {
            type = t;
            data = d;
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
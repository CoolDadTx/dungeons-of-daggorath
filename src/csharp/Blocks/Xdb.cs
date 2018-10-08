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

namespace DoD.Blocks
{
    //TODO: Should this be a struct?
    // Extra definition block
    // Holds extra data for torches, rings, and shields:
    // torch timers, ring shot counters and incantation indices,
    // and shield magical and physical defense values.
    public class Xdb
    {
        // Constructors
        public Xdb ( int idx, ushort x0, ushort x1, ushort x2 )
        {
            this.P_OXIDX = idx;
            this.P_OXXX0 = x0;
            this.P_OXXX1 = x1;
            this.P_OXXX2 = x2;
        }

        public Xdb ()
        {
            this.P_OXIDX = -1;
            this.P_OXXX0 = 0;
            this.P_OXXX1 = 0;
            this.P_OXXX2 = 0;
        }

        // Fields
        public int P_OXIDX;
        public ushort P_OXXX0;
        public ushort P_OXXX1;
        public ushort P_OXXX2;
    }
}
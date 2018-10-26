/*
 * Copyright © Michael Taylor (P3Net)
 * All Rights Reserved
 * For changes from C++ to C# and .NET.
 *
 * http://www.michaeltaylorp3.net
 */
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
    /// <summary>Extra definition block.</summary>
    /// <remarks>
    /// Holds extra data for torches, rings, and shields: torch timers, ring shot counters and incantation indices,
    /// and shield magical and physical defense values.
    /// </remarks>
    public class Xdb
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Xdb"/> class.</summary>
		public Xdb ()
        {
            //TODO: Not needed
            P_OXIDX = -1;
            P_OXXX0 = 0;
            P_OXXX1 = 0;
            P_OXXX2 = 0;
        }

        /// <summary>Initializes an instance of the <see cref="Xdb"/> class.</summary>
        public Xdb ( int idx, ushort x0, ushort x1, ushort x2 )
        {
            P_OXIDX = idx;
            P_OXXX0 = x0;
            P_OXXX1 = x1;
            P_OXXX2 = x2;
        }
        #endregion

        public int P_OXIDX { get; set; }
        public ushort P_OXXX0 { get; set; }
        public ushort P_OXXX1 { get; set; }
        public ushort P_OXXX2 { get; set; }
    }
}
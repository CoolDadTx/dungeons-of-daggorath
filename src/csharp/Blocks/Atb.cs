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
    /// <summary>Attack Block.</summary>
    /// <remarks>    
    /// Creatures and players use the same algorithm for attacking and for damage infliction.  These
    /// values are the common ones used.
    /// </remarks>
    public class Atb
    {
        //TODO: Make properties
        public ushort P_ATPOW;
        public byte P_ATMGO;
        public byte P_ATMGD;
        public byte P_ATPHO;
        public byte P_ATPHD;
        public ushort P_ATXX1;
        public ushort P_ATXX2;
        public ushort P_ATDAM;
    }
}
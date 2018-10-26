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
    /// <summary>Attack Block.</summary>
    /// <remarks>
    /// Creatures and players use the same algorithm for attacking and for damage infliction. These
    /// values are the common ones used.
    /// </remarks>
    public class Atb
    {
        public ushort P_ATPOW { get; set; }
        public byte P_ATMGO { get; set; }
        public byte P_ATMGD { get; set; }
        public byte P_ATPHO { get; set; }
        public byte P_ATPHD { get; set; }
        public ushort P_ATXX1 { get; set; }
        public ushort P_ATXX2 { get; set; }
        public ushort P_ATDAM { get; set; }
    }
}
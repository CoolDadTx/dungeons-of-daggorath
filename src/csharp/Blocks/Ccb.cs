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
    /// <summary>Creature control block.</summary>
    /// <remarks>
    /// Holds all the data for a particular creature.
    /// </remarks>
    public class Ccb
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Ccb"/> class.</summary>
        public Ccb ()
        {
            Clear();
        }
        #endregion

        public void Clear ()
        {
            P_CCPOW = 0;
            P_CCMGO = 0;
            P_CCMGD = 0;
            P_CCPHO = 0;
            P_CCPHD = 0;
            P_CCTMV = 0;
            P_CCTAT = 0;
            P_CCOBJ = -1;
            P_CCDAM = 0;
            P_CCUSE = 0;
            creature_id = 0;
            P_CCDIR = 0;
            P_CCROW = 0;
            P_CCCOL = 0;
        }

        public ushort P_CCPOW { get; set; }
        public byte P_CCMGO { get; set; }
        public byte P_CCMGD { get; set; }
        public byte P_CCPHO { get; set; }
        public byte P_CCPHD { get; set; }
        public int P_CCTMV { get; set; }
        public int P_CCTAT { get; set; }
        public int P_CCOBJ { get; set; }
        public ushort P_CCDAM { get; set; }
        public byte P_CCUSE { get; set; }
        public byte creature_id { get; set; }
        public byte P_CCDIR { get; set; }
        public byte P_CCROW { get; set; }
        public byte P_CCCOL { get; set; }
    }
}
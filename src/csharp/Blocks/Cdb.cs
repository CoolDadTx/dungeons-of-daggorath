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
    /// <summary>Creature definition block.</summary>
    /// <remarks>
    /// Holds the data for a creature type.
    /// </remarks>
    public class Cdb
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Cdb"/> class.</summary>
        public Cdb ()
        {
            //TODO: Not needed
            P_CDPOW = 0;
            P_CDMGO = 0;
            P_CDMGD = 0;
            P_CDPHO = 0;
            P_CDPHD = 0;
            P_CDTMV = 0;
            P_CDTAT = 0;
        }

        /// <summary>Initializes an instance of the <see cref="Cdb"/> class.</summary>
        public Cdb ( ushort pow, byte mgo, byte mgd, byte pho, byte phd, int tmv, int tat )
        {
            P_CDPOW = pow;
            P_CDMGO = mgo;
            P_CDMGD = mgd;
            P_CDPHO = pho;
            P_CDPHD = phd;
            P_CDTMV = tmv;
            P_CDTAT = tat;
        }
        #endregion

        public ushort P_CDPOW { get; set; }
        public byte P_CDMGO { get; set; }
        public byte P_CDMGD { get; set; }
        public byte P_CDPHO { get; set; }
        public byte P_CDPHD { get; set; }
        public int P_CDTMV { get; set; }
        public int P_CDTAT { get; set; }
    }
}
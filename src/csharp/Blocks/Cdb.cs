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
    /// <summary>Creature definition block.</summary>
    /// <remarks>    
    /// Holds the data for a creature type.
    /// </remarks>
    public class Cdb
    {
        public Cdb ( ushort pow, byte mgo, byte mgd, byte pho, byte phd, int tmv, int tat )
        {
            this.P_CDPOW = pow;
            this.P_CDMGO = mgo;
            this.P_CDMGD = mgd;
            this.P_CDPHO = pho;
            this.P_CDPHD = phd;
            this.P_CDTMV = tmv;
            this.P_CDTAT = tat;
        }

        public Cdb ()
        {
            this.P_CDPOW = 0;
            this.P_CDMGO = 0;
            this.P_CDMGD = 0;
            this.P_CDPHO = 0;
            this.P_CDPHD = 0;
            this.P_CDTMV = 0;
            this.P_CDTAT = 0;
        }

        //TODO: Make properties
        public ushort P_CDPOW;
        public byte P_CDMGO;
        public byte P_CDMGD;
        public byte P_CDPHO;
        public byte P_CDPHD;
        public int P_CDTMV;
        public int P_CDTAT;
    }
}
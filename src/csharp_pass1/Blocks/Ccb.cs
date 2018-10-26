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
    /// <summary>Creature control block.</summary>
    /// <remarks>
    /// Holds all the data for a particular creature.
    /// </remarks>
    public class Ccb
    {        
        public Ccb ()
        {
            Clear();
        }

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

        //TODO: Make properties
        public ushort P_CCPOW;
        public byte P_CCMGO;
        public byte P_CCMGD;
        public byte P_CCPHO;
        public byte P_CCPHD;
        public int P_CCTMV;
        public int P_CCTAT;
        public int P_CCOBJ;
        public ushort P_CCDAM;
        public byte P_CCUSE;
        public byte creature_id;
        public byte P_CCDIR;
        public byte P_CCROW;
        public byte P_CCCOL;
    }
}
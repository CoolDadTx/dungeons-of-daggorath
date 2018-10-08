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
    // Object control block
    // Hold the data for a particular object.
    public class Ocb
    {
        // Default constructor
        public Ocb ()
        {
            Clear();
        }

        public void Clear ()
        {
            P_OCPTR = -1;
            P_OCROW = 0;
            P_OCCOL = 0;
            P_OCLVL = 0;
            P_OCOWN = 0;
            P_OCXX0 = 0;
            P_OCXX1 = 0;
            P_OCXX2 = 0;
            obj_id = 0;
            obj_type = 0;
            obj_reveal_lvl = 0;
            P_OCMGO = 0;
            P_OCPHO = 0;
        }

        // Fields
        public int P_OCPTR;
        public byte P_OCROW;
        public byte P_OCCOL;
        public byte P_OCLVL;
        public byte P_OCOWN;
        public ushort P_OCXX0;
        public ushort P_OCXX1;
        public ushort P_OCXX2;
        public byte obj_id;
        public byte obj_type;
        public byte obj_reveal_lvl;
        public byte P_OCMGO;
        public byte P_OCPHO;
    }
}
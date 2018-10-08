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
    // Object definition block
    // Used for constructing specific objects.
    public class Odb
    {
        // Constructors
        public Odb ( byte cls, byte rev, byte mgo, byte pho )
        {
            this.P_ODCLS = cls;
            this.P_ODREV = rev;
            this.P_ODMGO = mgo;
            this.P_ODPHO = pho;
        }

        public Odb ()
        {
            this.P_ODCLS = 0;
            this.P_ODREV = 0;
            this.P_ODMGO = 0;
            this.P_ODPHO = 0;
        }

        // Fields
        public byte P_ODCLS;
        public byte P_ODREV;
        public byte P_ODMGO;
        public byte P_ODPHO;
    }
}
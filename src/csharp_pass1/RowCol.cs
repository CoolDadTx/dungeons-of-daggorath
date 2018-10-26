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

namespace DoD
{
    /// <summary>This class stores 32x32 row/column values.</summary>
    public class RowCol
    {
        public RowCol ()
        {
        }

        public RowCol ( byte r, byte c )
        {
            row = r;
            col = c;
        }

        public RowCol ( int idx )
        {
            row = (byte)(idx / 32);
            col = (byte)(idx % 32);
        }

        /// <summary>Mutator</summary>
        public void SetRC ( byte r, byte c )
        {
            row = r;
            col = c;
        }

        // TODO: Make properties
        public byte row = 0;
        public byte col = 0;
    }
}
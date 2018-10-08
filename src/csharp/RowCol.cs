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
    // This class stores 32x32 row/column values
    public class RowCol
    {
        // Constructors
        public RowCol ()
        {
            this.row = 0;
            this.col = 0;
        }
        public RowCol ( byte r, byte c )
        {
            this.row = r;
            this.col = c;
        }
        public RowCol ( int idx )
        {
            this.row = idx / 32;
            this.col = idx % 32;
        }

        // Mutator
        public void SetRC ( byte r, byte c )
        {
            row = r;
            col = c;
        }

        // Fields
        public byte row;
        public byte col;
    }
}
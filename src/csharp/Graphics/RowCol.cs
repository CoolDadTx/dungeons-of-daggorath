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

namespace DoD.Graphics
{
    /// <summary>This class stores 32x32 row/column values.</summary>
    public class RowCol
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="RowCol"/> class.</summary>
        public RowCol ()
        {
            row = 0;
            col = 0;
        }

        /// <summary>Initializes an instance of the <see cref="RowCol"/> class.</summary>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
		public RowCol ( byte r, byte c )
        {
            row = r;
            col = c;
        }

        /// <summary>Initializes an instance of the <see cref="RowCol"/> class.</summary>
        /// <param name="idx">Index</param>
		public RowCol ( int idx )
        {
            throw new NotImplementedException();
            //row = idx / 32;
            //col = idx % 32;
        }
        #endregion

        public void SetRC ( byte r, byte c )
        {
            row = r;
            col = c;
        }

        public byte row { get; set; }
        public byte col { get; set; }
    }
}
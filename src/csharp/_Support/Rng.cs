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

namespace DoD
{
    //TODO: Replace with standard Random but perhaps provide option to use original RNG instead.
    [Obsolete("Use standard Random class")]
    /// <summary>This class is a port of Daggorath's custom RNG.</summary>
    public class Rng
    {
        #region Construction

        public Rng ()
        {
            carry = 0;
            SEED[0] = 0;
            SEED[1] = 0;
            SEED[2] = 0;
        }
        #endregion
        
        public byte Random ()
        {
            int x;
            int y;
            byte a;
            byte b;
            carry = 0;
            for (x = 8; x != 0; --x)
            {
                b = 0;
                a = (byte)(SEED[2] & (byte)0xE1);
                for (y = 8; y != 0; --y)
                {
                    a = Lsl(a);
                    if (carry != 0)
                        ++b;
                }
                b = Lsr(b);
                SEED[0] = Rol(SEED[0]);
                SEED[1] = Rol(SEED[1]);
                SEED[2] = Rol(SEED[2]);
            }
            return SEED[0];
        }

        public byte GetSEED ( int idx ) => SEED[idx];

        public void SetSEED ( int idx, byte val ) => SEED[idx] = val;

        public void SetSEED ( byte val0, byte val1, byte val2 )
        {
            SEED[0] = val0;
            SEED[1] = val1;
            SEED[2] = val2;
        }

        public byte[] SEED = new byte[3];
        public byte carry;

        #region Private Members

        private byte Lsl ( byte c )
        {
            carry = (byte)(((c & 128) == 128) ? 1 : 0);
            return (byte)(c << 1);
        }

        private byte Lsr ( byte c )
        {
            carry = (byte)(((c & 1) == 1) ? 1 : 0);
            return (byte)(c >> 1);
        }

        private byte Rol ( byte c )
        {
            byte cry;
            cry = (byte)(((c & 128) == 128) ? 1 : 0);
            c <<= 1;
            c += carry;
            carry = cry;
            return c;
        }
        #endregion
    }
}
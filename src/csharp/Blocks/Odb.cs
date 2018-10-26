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

namespace DoD.Blocks
{
    /// <summary>Object definition block.</summary>
    /// <remarks>
    /// Used for constructing specific objects.
    /// </remarks>
    public class Odb
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Odb"/> class.</summary>
        public Odb ()
        {
        }

        /// <summary>Initializes an instance of the <see cref="Odb"/> class.</summary>
        public Odb ( byte cls, byte rev, byte mgo, byte pho )
        {
            P_ODCLS = cls;
            P_ODREV = rev;
            P_ODMGO = mgo;
            P_ODPHO = pho;
        }
        #endregion

        public byte P_ODCLS { get; set; }
        public byte P_ODREV { get; set; }
        public byte P_ODMGO { get; set; }
        public byte P_ODPHO { get; set; }
    }
}
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
    /// <summary>Object control block.</summary>
    /// <remarks>
    /// Hold the data for a particular object.
    /// </remarks>
    public class Ocb
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Ocb"/> class.</summary>
        public Ocb ()
        {
            //TODO: Not needed
            Clear();
        }
        #endregion

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

        public int P_OCPTR { get; set; }
        public byte P_OCROW { get; set; }
        public byte P_OCCOL { get; set; }
        public byte P_OCLVL { get; set; }
        public byte P_OCOWN { get; set; }
        public ushort P_OCXX0 { get; set; }
        public ushort P_OCXX1 { get; set; }
        public ushort P_OCXX2 { get; set; }
        public byte obj_id { get; set; }
        public byte obj_type { get; set; }
        public byte obj_reveal_lvl { get; set; }
        public byte P_OCMGO { get; set; }
        public byte P_OCPHO { get; set; }
    }
}
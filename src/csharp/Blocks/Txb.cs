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
    /// <summary>Text Block.</summary>
    /// <remarks>
    /// This has been entirely modified from the original for use in the modern system.
    /// </remarks>
    public class Txb
    {
        public void SetVals ( ref string a, int c, int l, int t )
        {
            area = a;
            caret = c;
            len = l;
            top = t;
        }

        // Fields
        public string area { get; set; }
        public int caret { get; set; }
        public int len { get; set; }
        public int top { get; set; }
    }
}
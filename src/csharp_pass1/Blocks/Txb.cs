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

    /// <summary>Text Block.</summary>
    /// <remarks>
    /// This has been entirely modified from the original for use in the modern system.
    /// <para />
    /// The original source has several structured blocks.
    /// They all have their size as the last field, which is probably unnecessary for us.  I've made them into
    /// classes with all public members, and some functions.
    /// </remarks>
    public class Txb
    {
        public Txb ()
        {
        }

        public void SetVals ( ref string a, int c, int l, int t )
        {
            area = a;
            caret = c;
            len = l;
            top = t;
        }

        //TODO: Make properties
        public string area;
        public int caret;
        public int len;
        public int top;
    }
}
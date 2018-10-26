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
using DoD.Sound;

namespace DoD
{
    /// <summary>Not much here at the moment, but it could grow.</summary>
    public static class Utils
    {
        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'char* h', so pointers on this parameter are left unchanged:
        public static void LoadFromHex ( ref byte b, string h )
        {
            throw new NotImplementedException();
            //string hexbuf = new string(new char[3]);
            //string end;
            //hexbuf = hexbuf.Substring(0, 2);
            //int ctr = 0;

            //while (*h != null)
            //{
            //	hexbuf = StringFunctions.ChangeCharacter(hexbuf, 0, *h);
            //	hexbuf = StringFunctions.ChangeCharacter(hexbuf, 1, *(h.Substring(1)));
            //	*(b + ctr) = (byte) strtoul(hexbuf, end, 16);
            //	++ctr;
            //	h += 2;
            //}
        }

        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'char* h', so pointers on this parameter are left unchanged:
        public static void LoadFromHex ( ref int b, string h )
        {
            throw new NotImplementedException();
            //         string hexbuf = new string(new char[3]);
            //string end;
            //hexbuf = hexbuf.Substring(0, 2);
            //int ctr = 0;

            //while (*h != null)
            //{
            //	hexbuf = StringFunctions.ChangeCharacter(hexbuf, 0, *h);
            //	hexbuf = StringFunctions.ChangeCharacter(hexbuf, 1, *(h.Substring(1)));
            //	*(b + ctr) = (int) strtoul(hexbuf, end, 16);
            //	++ctr;
            //	h += 2;
            //}
        }

        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'byte* b', so pointers on this parameter are left unchanged:
        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'char* dd', so pointers on this parameter are left unchanged:
        public static void LoadFromDecDigit ( byte[] b, string dd )
        {
            throw new NotImplementedException();
            //        while (*dd != null)
            //*b++= (*dd ++ - '0');
        }

        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'int* b', so pointers on this parameter are left unchanged:
        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'char* dd', so pointers on this parameter are left unchanged:
        public static void LoadFromDecDigit ( int[] b, string dd )
        {
            throw new NotImplementedException();
            //        while (*dd != null)
            //*b++= (*dd ++ - '0');
        }

        public static Mix_Chunk LoadSound ( ref string snd )
        {
            throw new NotImplementedException();
            //         string fn = new string(new char[256]);
            //fn = string.Format("{0}{1}{2}", GlobalMembers.oslink.soundDir, GlobalMembers.oslink.pathSep, snd);
            //return Mix_LoadWAV(fn);
        }
    }
}
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
using SDL2;

namespace DoD
{
    // Not much here at the moment, but it could grow
    public class Utils
    {        
        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'h', so pointers on this parameter are left unchanged:
        public static void LoadFromHex ( byte[] b, string h )
        {
            string hexbuf = new string(new char[3]);
            string end;
            var hexbuf = hexbuf.Substring(0, 2);
            int ctr = 0;

            while (*h != null)
            {
                hexbuf = StringFunctions.ChangeCharacter(hexbuf, 0, *h);
                hexbuf = StringFunctions.ChangeCharacter(hexbuf, 1, *(h.Substring(1)));
                *(b + ctr) = (byte)strtoul(hexbuf, end, 16);
                ++ctr;
                h += 2;
            }
        }

        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'h', so pointers on this parameter are left unchanged:
        public static void LoadFromHex ( int[] b, string h )
        {
            string hexbuf = new string(new char[3]);
            string end;
            hexbuf = hexbuf.Substring(0, 2);
            int ctr = 0;

            while (*h != null)
            {
                hexbuf = StringFunctions.ChangeCharacter(hexbuf, 0, *h);
                hexbuf = StringFunctions.ChangeCharacter(hexbuf, 1, *(h.Substring(1)));
                *(b + ctr) = (int)strtoul(hexbuf, end, 16);
                ++ctr;
                h += 2;
            }
        }

        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'b', so pointers on this parameter are left unchanged:        
        public static void LoadFromDecDigit ( byte[] b, string dd )
        {
            while (*dd != null)
                *b++ = (*dd++ - '0');
        }

        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'b', so pointers on this parameter are left unchanged:        
        public static void LoadFromDecDigit ( int[] b, string dd )
        {
            while (*dd != null)
                *b++ = (*dd++ - '0');
        }

        public static SDL_mixer.Mix_Chunk LoadSound ( string snd )
        {
            var fn = string.Format("{0}{1}{2}", GlobalMembers.oslink.soundDir, GlobalMembers.oslink.pathSep, snd);
            return SDL_mixer.Mix_LoadWAV(fn);
        }
    }
}
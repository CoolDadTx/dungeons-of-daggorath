/****************************************
Daggorath PC-Port Version 0.2.1
Richard Hunerlach
November 13, 2002

The copyright for Dungeons of Daggorath
is held by Douglas J. Morgan.
(c) 1982, DynaMicro
*****************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoD
{
	public static class GlobalMembers
	{
		public static DodGame game = new DodGame();
		public static Coordinate crd = new Coordinate();
		public static Rng rng = new Rng();
		public static Player player = new Player();
		public static CppObject @object = new CppObject();
		public static Creature creature = new Creature();
		public static Dungeon dungeon = new Dungeon();
		public static Scheduler scheduler = new Scheduler();
		public static Viewer viewer = new Viewer();
		public static OSLink oslink = new OSLink();
		public static Parser parser = new Parser();

		// Could include some command line arguments for
		// various purposes (like configurations) if desired later.
		//
		// However, I think a config file would be nicer
		//

		public static void Printvls()
		{
            throw new NotImplementedException();
   //         Printalpha(viewer.SHIE_VLA, 14, "SHIE_VLA");
			//Printalpha(viewer.SWOR_VLA, 11, "SWOR_VLA");
			//Printalpha(viewer.TORC_VLA, 10, "TORC_VLA");
			//Printalpha(viewer.RING_VLA, 12, "RING_VLA");
			//Printalpha(viewer.SCRO_VLA, 12, "SCRO_VLA");
			//Printalpha(viewer.FLAS_VLA, 10, "FLAS_VLA");		
		}

		//SDL 2.0 change
		//int main(int argc, char * argv[])
		public static int WinMain(IntPtr hInstance, IntPtr hPrevInstance, string lpCmdLine, int nCmdShow)
		{
            throw new NotImplementedException();
   //         Console.Write("Starting DoD.\n");

			//oslink.Init();
			//return 0;
		}

		public static void Printalpha(int[] vl, int len, ref string name)
		{
            throw new NotImplementedException();
   //         int ctr;
			//Console.Write("Utils::LoadFromDecDigit({0}, \"", name);
			//for (ctr = 1; ctr < len; ++ctr)
			//	Console.Write("{0:X2}",vl[ctr]);
			//Console.Write("\");\n");
		}

        public static bool PreTranslateCommand(ref byte str)
		{
            throw new NotImplementedException();
  //          string buffer = new string(new char[256]);
		//	string pBuffer = buffer;
		//	GetDodStr(ref buffer, str);

		//	while (pBuffer[0]
		//		&& (pBuffer[0] <= ' '))
		//		pBuffer = pBuffer.Substring(1);

		//	if (0 == string.Compare(pBuffer, 0, "SETOPT ", 0, 7))
		//	{
		//		if (SetOption(ref pBuffer.Substring(7)))
		//		{
		//			SetDodStr(str, "");
		//			oslink.saveOptFile(); //Save config file change.
		//			return true;
		//		}
		//	} else if (0 == string.Compare(pBuffer, 0, "SO ", 0, 3))
		//	{
		//		if (SetOption(ref pBuffer.Substring(3)))
		//		{
		//			SetDodStr(str, "");
		//			oslink.saveOptFile(); //Save config file change.
		//			return true;
		//		}
		//} else if (0 == string.Compare(pBuffer, 0, "SETCHEAT ", 0, 9))
		//{
		//		if (SetCheat(ref pBuffer.Substring(9)))
		//		{
		//			SetDodStr(str, "");
		//			oslink.saveOptFile();
		//			return true;
		//		}
		//} else if (0 == string.Compare(pBuffer, 0, "SC ", 0, 3))
		//{
		//		if (SetCheat(ref pBuffer.Substring(3)))
		//		{
		//			SetDodStr(str, "");
		//			oslink.saveOptFile();
		//			return true;
		//		}
		//} else if (0 == string.Compare(pBuffer, 0, "RESTART", 0, 7))
		//{
		//		SetDodStr(str, "");
		//		return false;
		//}
		//	return true;
		}

		// these globals hold the options and cheat flag bits
		public static uint g_options = (int)AnonymousEnum4.OptStereo; //OPT_HIRES|OPT_STEREO;
		public static uint g_cheats = 0;

		/// <summary>Translate a DOD string into a standard C string.</summary>        
		public static void GetDodStr(ref string pstr, byte[] dodstr)
		{
            throw new NotImplementedException();
   //         int x;
			//// for each character in dodstr
			//for (x = 0;dodstr[x] != Parser.AnonymousEnum.INull;x++)
			//{
			//	if (dodstr[x] == Parser.AnonymousEnum.ISp)
			//		pstr[x] = ' '; // translate I_SP into ascii
			//	else
			//		pstr[x] = dodstr[x] + 64; // translate into ascii
			//}
			//pstr[x] = '\0';
		}

        /// <summary>Translate a standard C string int a DOD string.</summary>
        public static void SetDodStr(byte[] dodstr, ref string pstr)
		{
            throw new NotImplementedException();
   //         int x;
			//char c;
			//for (x = 0;pstr[x];x++)
			//{ // for each character in pstr
			//	c = toupper(pstr[x]); // convert it to uppercase
			//	if (c >= 'A'
			//		|| c <= 'Z')
			//		dodstr[x] = c - 64;
			//	else
			//		dodstr[x] = Parser.AnonymousEnum.ISp; // replace it with a space

			//}
			//dodstr[x] = Parser.AnonymousEnum.INull;
		}

        /// <summary>Parse out the first keyword(name) and all remaining data(value).</summary>
        /// <remarks>
        /// This lets us parse commands like SETOPT GFX NORMAL.
        /// <para />
        /// The SETOPT part is parsed by PretranslateCommand.
        /// <para />
        /// GFX is the name and NORMAL is the value.
        /// </remarks>
        //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'opt', so pointers on this parameter are left unchanged:
        public static void ParseOpt(string opt, ref string name, ref string val)
		{
            throw new NotImplementedException();
 //           // assume val is empty by default
 //           val[0] = '\0';

	//		// skip leading white space
	//		while (opt[0]
	//			&& (opt[0] <= ' '))
	//			opt = opt.Substring(1);

	//		// search for next space in string
	////C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	////ORIGINAL LINE: char *pDelim=strchr(opt,' ');
	//		char pDelim = StringFunctions.StrChr(opt,' ');
	//		if (pDelim != null)
	//		{
	//			// copy name part before space
	//			name = opt.Substring(0, pDelim - opt);
	//			name[pDelim - opt] = '\0'; // terminate name, strncpy wont

	//			// move opt ptr after next space
	//			opt = pDelim + 1;
	//			// skip white space
	//			while (opt[0]
	//				&& (opt[0] <= ' '))
	//				opt = opt.Substring(1);
	//			// copy any remaining text into val
	//			val = opt;
	//		}
	//		else // no white space, copy it all to name
	//			name = opt;
		}

		public static bool SetOption(ref string opt)
		{
            throw new NotImplementedException();
  //          bool bSuccess = false;
		//	string name = new string(new char[255]);
		//	string value = new string(new char[255]);

		//	ParseOpt(opt, ref name, ref value);

		//	int nlen = name.Length;
		//	if (nlen == 0)
		//		return false; //  no opt name, error
		//	int vlen = value.Length;

		//	if (0 == string.Compare(name, 0, "GFX", 0, nlen)
		//		&& vlen != 0)
		//	{
		//		if (0 == string.Compare(value, 0, "NORMAL", 0, vlen))
		//		{
		//			// turn off all gfx bits
		//			g_options &= ~((int)AnonymousEnum2.OptVector | (int)AnonymousEnum2.OptHires);
		//			bSuccess = true;
		//		} else if (0 == string.Compare(value, 0, "HIRES", 0, vlen))
		//		{
		//			// turn off all gfx bits but HIRES
		//			g_options &= ~(AnonymousEnum2.OptVector);
		//			g_options |= AnonymousEnum2.OptHires;
		//			bSuccess = true;
		//	} else if (0 == string.Compare(value, 0, "VECTOR", 0, vlen))
		//	{
		//			// turn off all gfx bits but VECTOR
		//			g_options &= ~(AnonymousEnum2.OptHires);
		//			g_options |= AnonymousEnum2.OptVector;
		//			bSuccess = true;
		//	}
		//	} else if (name[0] == 'S')
		//	{
		//		if (nlen > 1
		//			&& 0 == string.Compare(name, 1, "ND", 0, nlen - 1)
		//			&& vlen != 0)
		//			{
		//			if (0 == string.Compare(value, 0, "MONO", 0, vlen))
		//			{
		//				// turn off STEREO
		//				g_options &= ~AnonymousEnum2..Pupdat(;
		//				bSuccess = true;
		//			} else if (0 == string.Compare(value, 0, "STEREO", 0, vlen))
		//			{
		//				// turn on STEREO
		//				g_options |= AnonymousEnum2..Pupdat(;
		//				bSuccess = true;
		//		}
		//			} else if (nlen > 1 && 0 == string.Compare(name, 1, "HIELDFIX", 0, nlen - 1) && vlen != 0)
		//			{
		//			if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
		//			{
		//				// turn on shield fix
		//				game.ShieldFix = true;
		//				bSuccess = true;
		//			} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
		//			{
		//				// turn off shield fix
		//				game.ShieldFix = false;
		//				bSuccess = true;
		//		}
		//	}
		//} else if (0 == string.Compare(name, 0, "RANDOMMAZE", 0, nlen) && vlen != 0)
		//{
		//		if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
		//		{
		//			// turn on random mazes
		//			game.RandomMaze = true;
		//			bSuccess = true;
		//		} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
		//		{
		//			// turn off random mazes
		//			game.RandomMaze = false;
		//			bSuccess = true;
		//	}
		//} else if (0 == string.Compare(name, 0, "VISIONSCROLL", 0, nlen) && vlen != 0)
		//{
		//		if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
		//		{
		//			// turn on extra blob w/ vision scroll in level 1
		//			game.VisionScroll = true;
		//			bSuccess = true;
		//		} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
		//		{
		//			// turn off extra blob w/ vision scroll in level 1
		//			game.VisionScroll = false;
		//			bSuccess = true;
		//	}
		//} else if (0 == string.Compare(name, 0, "MARKDOORSONMAPS", 0, nlen) && vlen != 0)
		//{
		//		if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
		//		{
		//			// turn on marking doors on maps
		//			game.MarkDoorsOnScrollMaps = true;
		//			bSuccess = true;
		//		} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
		//		{
		//			// turn off marking doors on maps
		//			game.MarkDoorsOnScrollMaps = false;
		//			bSuccess = true;
		//	}
		//} else if (0 == string.Compare(name, 0, "CRI", 0, 3))
		//{
		//		if (nlen > 3
		//			&& 0 == string.Compare(name, 3, "GNOREOBJECTS", 0, nlen - 3)
		//			&& vlen != 0)
		//			{
		//			if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
		//			{
		//				// turn on creatures ignoring objects when in same room as player
		//				game.CreaturesIgnoreObjects = true;
		//				bSuccess = true;
		//			} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
		//			{
		//				// turn off creatures ignoring objects when in same room as player
		//				game.CreaturesIgnoreObjects = false;
		//				bSuccess = true;
		//		}
		//			} else if (nlen > 3 && 0 == string.Compare(name, 3, "NSTAREGEN", 0, nlen - 3) && vlen != 0)
		//			{
		//			if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
		//			{
		//				// turn on creatures getting reassigned for level no death
		//				game.CreaturesInstaRegen = true;
		//				bSuccess = true;
		//			} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
		//			{
		//				// turn off creatures getting reassigned for level no death
		//				game.CreaturesInstaRegen = false;
		//				bSuccess = true;
		//		}
		//	}
		//}

		//	return bSuccess; // string not parsed, error
		}

		public static bool SetCheat(ref string str)
		{
            throw new NotImplementedException();
  //          string name = new string(new char[255]);
		//	string value = new string(new char[255]);

		//	ParseOpt(str, ref name, ref value);

		//	int len = name.Length;
		//	if (len == 0)
		//		return false; // no cheat name, error

		//	if (0 == string.Compare(name, 0, "NONE", 0, len))
		//	{
		//		g_cheats = 0;
		//		return true;
		//	} else if (0 == string.Compare(name, 0, "TORCH", 0, len))
		//	{
		//		g_cheats |= AnonymousEnum3.CheatTorch;
		//		return true;
		//}

		//	else if (name[0] == 'R')
		//	{
		//		if (len > 1
		//			&& 0 == string.Compare(name, 1, "ING", 0, len - 1))
		//		{
		//			g_cheats |= AnonymousEnum3.CheatRing;
		//			return true;
		//		} else if (len > 1 && 0 == string.Compare(name, 1, "EVEAL", 0, len - 1))
		//		{
		//			g_cheats |= AnonymousEnum3.CheatReveal;
		//			return true;
		//	}
		//	} else if (0 == string.Compare(name, 0, "CRTSCALE", 0, len))
		//	{
		//		g_cheats |= AnonymousEnum3.CheatRegenScaling;
		//		return true;
		//}
		//	else if (name[0] == 'I')
		//	{
		//		if (len > 1
		//			&& 0 == string.Compare(name, 1, "TEMS", 0, len - 1))
		//		{
		//			g_cheats |= AnonymousEnum3.CheatItems;
		//			return true;
		//		} else if (len > 1 && 0 == string.Compare(name, 1, "NVULNERABLE", 0, len - 1))
		//		{
		//			g_cheats |= AnonymousEnum3.CheatInvulnerable;
		//			return true;
		//	}
		//	}

		//	return false;
		}

		public static int ClearColor = 0;
	}
}
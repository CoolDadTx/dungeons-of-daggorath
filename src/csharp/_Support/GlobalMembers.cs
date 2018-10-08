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
			Printalpha(viewer.SHIE_VLA, 14, "SHIE_VLA");
			Printalpha(viewer.SWOR_VLA, 11, "SWOR_VLA");
			Printalpha(viewer.TORC_VLA, 10, "TORC_VLA");
			Printalpha(viewer.RING_VLA, 12, "RING_VLA");
			Printalpha(viewer.SCRO_VLA, 12, "SCRO_VLA");
			Printalpha(viewer.FLAS_VLA, 10, "FLAS_VLA");

		/*
			printalpha(viewer.SP_VLA, 39, "SP_VLA");
			printalpha(viewer.WR_VLA, 42, "WR_VLA");
			printalpha(viewer.SC_VLA, 41, "SC_VLA");
			printalpha(viewer.BL_VLA, 66, "BL_VLA");
			printalpha(viewer.GL_VLA, 141, "GL_VLA");
			printalpha(viewer.VI_VLA, 65, "VI_VLA");
			printalpha(viewer.S1_VLA, 130, "S1_VLA");
			printalpha(viewer.S2_VLA, 126, "S2_VLA");
			printalpha(viewer.K1_VLA, 153, "K1_VLA");
			printalpha(viewer.K2_VLA, 149, "K2_VLA");
			printalpha(viewer.W0_VLA, 133, "W0_VLA");
			printalpha(viewer.W1_VLA, 199, "W1_VLA");
			printalpha(viewer.W2_VLA, 185, "W2_VLA");
			printalpha(viewer.LAD_VLA, 56, "LAD_VLA");
			printalpha(viewer.HUP_VLA, 29, "HUP_VLA");
			printalpha(viewer.HDN_VLA, 19, "HDN_VLA");
			printalpha(viewer.CEI_VLA, 6, "CEI_VLA");
			printalpha(viewer.LPK_VLA, 12, "LPK_VLA");
			printalpha(viewer.RPK_VLA, 12, "RPK_VLA");
			printalpha(viewer.FSD_VLA, 8, "FSD_VLA");
			printalpha(viewer.LSD_VLA, 8, "LSD_VLA");
			printalpha(viewer.RSD_VLA, 8, "RSD_VLA");
			printalpha(viewer.RWAL_VLA, 10, "RWAL_VLA");
			printalpha(viewer.LWAL_VLA, 10, "LWAL_VLA");
			printalpha(viewer.FWAL_VLA, 11, "FWAL_VLA");
			printalpha(viewer.RPAS_VLA, 15, "RPAS_VLA");
			printalpha(viewer.LPAS_VLA, 15, "LPAS_VLA");
			printalpha(viewer.FPAS_VLA, 1, "FPAS_VLA");
			printalpha(viewer.RDOR_VLA, 24, "RDOR_VLA");
			printalpha(viewer.LDOR_VLA, 24, "LDOR_VLA");
			printalpha(viewer.FDOR_VLA, 25, "FDOR_VLA");
		
			printalpha(viewer.A_VLA, 33, "A_VLA");
			printalpha(viewer.B_VLA, 49, "B_VLA");
			printalpha(viewer.C_VLA, 41, "C_VLA");
			printalpha(viewer.D_VLA, 33, "D_VLA");
			printalpha(viewer.E_VLA, 33, "E_VLA");
			printalpha(viewer.F_VLA, 25, "F_VLA");
			printalpha(viewer.G_VLA, 49, "G_VLA");
			printalpha(viewer.H_VLA, 25, "H_VLA");
			printalpha(viewer.I_VLA, 25, "I_VLA");
			printalpha(viewer.J_VLA, 25, "J_VLA");
			printalpha(viewer.K_VLA, 65, "K_VLA");
			printalpha(viewer.L_VLA, 17, "L_VLA");
			printalpha(viewer.M_VLA, 41, "M_VLA");
			printalpha(viewer.N_VLA, 41, "N_VLA");
			printalpha(viewer.O_VLA, 33, "O_VLA");
			printalpha(viewer.P_VLA, 33, "P_VLA");
			printalpha(viewer.Q_VLA, 57, "Q_VLA");
			printalpha(viewer.R_VLA, 57, "R_VLA");
			printalpha(viewer.S_VLA, 57, "S_VLA");
			printalpha(viewer.T_VLA, 33, "T_VLA");
			printalpha(viewer.U_VLA, 25, "U_VLA");
			printalpha(viewer.V_VLA, 41, "V_VLA");
			printalpha(viewer.W_VLA, 41, "W_VLA");
			printalpha(viewer.X_VLA, 73, "X_VLA");
			printalpha(viewer.Y_VLA, 41, "Y_VLA");
			printalpha(viewer.Z_VLA, 57, "Z_VLA");
			printalpha(viewer.PER_VLA, 9, "PER_VLA");
			printalpha(viewer.UND_VLA, 9, "UND_VLA");
			printalpha(viewer.EXP_VLA, 17, "EXP_VLA");
			printalpha(viewer.QSM_VLA, 49, "QSM_VLA");
			printalpha(viewer.SHL_VLA, 9, "SHL_VLA");
			printalpha(viewer.SHR_VLA, 33, "SHR_VLA");
			printalpha(viewer.LHL_VLA, 17, "LHL_VLA");
			printalpha(viewer.LHR_VLA, 41, "LHR_VLA");
		*/
		}
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void Printthem(ref int UnnamedParameter, int UnnamedParameter2, ref string UnnamedParameter3);

		//SDL 2.0 change
		//int main(int argc, char * argv[])
	//C++ TO C# CONVERTER NOTE: CALLBACK is not available in C#:
	//ORIGINAL LINE: int CALLBACK WinMain(System.IntPtr hInstance, System.IntPtr hPrevInstance, string lpCmdLine, int nCmdShow)
		public static int WinMain(IntPtr hInstance, IntPtr hPrevInstance, string lpCmdLine, int nCmdShow)
		{
			//printvls();
			//exit(0);

			Console.Write("Starting DoD.\n");

			oslink.Init();
			return 0;
		}

		public static void Printalpha(int[] vl, int len, ref string name)
		{
			int ctr;
			Console.Write("Utils::LoadFromDecDigit({0}, \"", name);
			for (ctr = 1; ctr < len; ++ctr)
				Console.Write("{0:X2}",vl[ctr]);
			Console.Write("\");\n");
		}




		//extern OS_Link oslink;
		//extern Dungeon dungeon;
		//extern Parser parser;
		//extern Creature creature;
		//extern CppObject @object;
		//extern Player player;
		//extern Viewer viewer;
		//extern Scheduler scheduler;


		/****************************************
		Daggorath PC-Port Version 0.2.1
		Richard Hunerlach
		November 13, 2002
		
		The copyright for Dungeons of Daggorath
		is held by Douglas J. Morgan.
		(c) 1982, DynaMicro
		*****************************************/

		// Dungeons of Daggorath
		// PC-Port
		// Filename: dungeon.cpp
		//
		// Implementation of Dungeon class

		/****************************************
		Daggorath PC-Port Version 0.2.1
		Richard Hunerlach
		November 13, 2002
		
		The copyright for Dungeons of Daggorath
		is held by Douglas J. Morgan.
		(c) 1982, DynaMicro
		*****************************************/

		// Dungeons of Daggorath
		// PC-Port
		// Filename: dungeon.h
		//
		// This class manages the maze data, and includes
		// methods related to row/column calculations.



		//extern RNG rng; // Inculded here for inlines below



		//extern Scheduler scheduler;
		//extern Player player;
		//extern dodGame game;
		public static bool PreTranslateCommand(ref byte str)
		{
			string buffer = new string(new char[256]);
			string pBuffer = buffer;
			GetDodStr(ref buffer, str);

			while (pBuffer[0]
				&& (pBuffer[0] <= ' '))
				pBuffer = pBuffer.Substring(1);

			if (0 == string.Compare(pBuffer, 0, "SETOPT ", 0, 7))
			{
				if (SetOption(ref pBuffer.Substring(7)))
				{
					SetDodStr(str, "");
					oslink.saveOptFile(); //Save config file change.
					return true;
				}
			} else if (0 == string.Compare(pBuffer, 0, "SO ", 0, 3))
			{
				if (SetOption(ref pBuffer.Substring(3)))
				{
					SetDodStr(str, "");
					oslink.saveOptFile(); //Save config file change.
					return true;
				}
		} else if (0 == string.Compare(pBuffer, 0, "SETCHEAT ", 0, 9))
		{
				if (SetCheat(ref pBuffer.Substring(9)))
				{
					SetDodStr(str, "");
					oslink.saveOptFile();
					return true;
				}
		} else if (0 == string.Compare(pBuffer, 0, "SC ", 0, 3))
		{
				if (SetCheat(ref pBuffer.Substring(3)))
				{
					SetDodStr(str, "");
					oslink.saveOptFile();
					return true;
				}
		} else if (0 == string.Compare(pBuffer, 0, "RESTART", 0, 7))
		{
				SetDodStr(str, "");
				return false;
		}
			return true;
		}

		//extern uint g_options;

		//extern uint g_cheats;



		//extern OS_Link oslink;
		//extern dodGame game;

		// these globals hold the options and cheat flag bits
		public static uint g_options = (int)AnonymousEnum2.OptStereo; //OPT_HIRES|OPT_STEREO;
		public static uint g_cheats = 0;

		// translate a DOD string into a standard C string
		public static void GetDodStr(ref string pstr, byte[] dodstr)
		{
			int x;
			// for each character in dodstr
			for (x = 0;dodstr[x] != Parser.AnonymousEnum.INull;x++)
			{
				if (dodstr[x] == Parser.AnonymousEnum.ISp)
					pstr[x] = ' '; // translate I_SP into ascii
				else
					pstr[x] = dodstr[x] + 64; // translate into ascii
			}
			pstr[x] = '\0';
		}

		// translate a standard C string int a DOD string
		public static void SetDodStr(byte[] dodstr, ref string pstr)
		{
			int x;
			char c;
			for (x = 0;pstr[x];x++)
			{ // for each character in pstr
				c = toupper(pstr[x]); // convert it to uppercase
				if (c >= 'A'
					|| c <= 'Z')
					dodstr[x] = c - 64;
				else
					dodstr[x] = Parser.AnonymousEnum.ISp; // replace it with a space

			}
			dodstr[x] = Parser.AnonymousEnum.INull;
		}

		// parse out the first keyword(name) and all remaining data(value)
		// this lets us parse commands like SETOPT GFX NORMAL
		// the SETOPT part is parsed by PretranslateCommand
		// GFX is the name and NORMAL is the value
	//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'opt', so pointers on this parameter are left unchanged:
		public static void ParseOpt(char * opt, ref string name, ref string val)
		{
			// assume val is empty by default
			val[0] = '\0';

			// skip leading white space
			while (opt[0]
				&& (opt[0] <= ' '))
				opt = opt.Substring(1);

			// search for next space in string
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: char *pDelim=strchr(opt,' ');
			char pDelim = StringFunctions.StrChr(opt,' ');
			if (pDelim != null)
			{
				// copy name part before space
				name = opt.Substring(0, pDelim - opt);
				name[pDelim - opt] = '\0'; // terminate name, strncpy wont

				// move opt ptr after next space
				opt = pDelim + 1;
				// skip white space
				while (opt[0]
					&& (opt[0] <= ' '))
					opt = opt.Substring(1);
				// copy any remaining text into val
				val = opt;
			}
			else // no white space, copy it all to name
				name = opt;
		}

		public static bool SetOption(ref string opt)
		{
			bool bSuccess = false;
			string name = new string(new char[255]);
			string value = new string(new char[255]);

			ParseOpt(opt, ref name, ref value);

			int nlen = name.Length;
			if (nlen == 0)
				return false; //  no opt name, error
			int vlen = value.Length;

			if (0 == string.Compare(name, 0, "GFX", 0, nlen)
				&& vlen != 0)
			{
				if (0 == string.Compare(value, 0, "NORMAL", 0, vlen))
				{
					// turn off all gfx bits
					g_options &= ~((int)AnonymousEnum2.OptVector | (int)AnonymousEnum2.OptHires);
					bSuccess = true;
				} else if (0 == string.Compare(value, 0, "HIRES", 0, vlen))
				{
					// turn off all gfx bits but HIRES
					g_options &= ~(AnonymousEnum2.OptVector);
					g_options |= AnonymousEnum2.OptHires;
					bSuccess = true;
			} else if (0 == string.Compare(value, 0, "VECTOR", 0, vlen))
			{
					// turn off all gfx bits but VECTOR
					g_options &= ~(AnonymousEnum2.OptHires);
					g_options |= AnonymousEnum2.OptVector;
					bSuccess = true;
			}
			} else if (name[0] == 'S')
			{
				if (nlen > 1
					&& 0 == string.Compare(name, 1, "ND", 0, nlen - 1)
					&& vlen != 0)
					{
					if (0 == string.Compare(value, 0, "MONO", 0, vlen))
					{
						// turn off STEREO
						g_options &= ~AnonymousEnum2.OptStereo;
						bSuccess = true;
					} else if (0 == string.Compare(value, 0, "STEREO", 0, vlen))
					{
						// turn on STEREO
						g_options |= AnonymousEnum2.OptStereo;
						bSuccess = true;
				}
					} else if (nlen > 1 && 0 == string.Compare(name, 1, "HIELDFIX", 0, nlen - 1) && vlen != 0)
					{
					if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
					{
						// turn on shield fix
						game.ShieldFix = true;
						bSuccess = true;
					} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
					{
						// turn off shield fix
						game.ShieldFix = false;
						bSuccess = true;
				}
			}
		} else if (0 == string.Compare(name, 0, "RANDOMMAZE", 0, nlen) && vlen != 0)
		{
				if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
				{
					// turn on random mazes
					game.RandomMaze = true;
					bSuccess = true;
				} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
				{
					// turn off random mazes
					game.RandomMaze = false;
					bSuccess = true;
			}
		} else if (0 == string.Compare(name, 0, "VISIONSCROLL", 0, nlen) && vlen != 0)
		{
				if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
				{
					// turn on extra blob w/ vision scroll in level 1
					game.VisionScroll = true;
					bSuccess = true;
				} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
				{
					// turn off extra blob w/ vision scroll in level 1
					game.VisionScroll = false;
					bSuccess = true;
			}
		} else if (0 == string.Compare(name, 0, "MARKDOORSONMAPS", 0, nlen) && vlen != 0)
		{
				if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
				{
					// turn on marking doors on maps
					game.MarkDoorsOnScrollMaps = true;
					bSuccess = true;
				} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
				{
					// turn off marking doors on maps
					game.MarkDoorsOnScrollMaps = false;
					bSuccess = true;
			}
		} else if (0 == string.Compare(name, 0, "CRI", 0, 3))
		{
				if (nlen > 3
					&& 0 == string.Compare(name, 3, "GNOREOBJECTS", 0, nlen - 3)
					&& vlen != 0)
					{
					if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
					{
						// turn on creatures ignoring objects when in same room as player
						game.CreaturesIgnoreObjects = true;
						bSuccess = true;
					} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
					{
						// turn off creatures ignoring objects when in same room as player
						game.CreaturesIgnoreObjects = false;
						bSuccess = true;
				}
					} else if (nlen > 3 && 0 == string.Compare(name, 3, "NSTAREGEN", 0, nlen - 3) && vlen != 0)
					{
					if (0 == string.Compare(value, 0, "TRUE", 0, vlen))
					{
						// turn on creatures getting reassigned for level no death
						game.CreaturesInstaRegen = true;
						bSuccess = true;
					} else if (0 == string.Compare(value, 0, "FALSE", 0, vlen))
					{
						// turn off creatures getting reassigned for level no death
						game.CreaturesInstaRegen = false;
						bSuccess = true;
				}
			}
		}

			return bSuccess; // string not parsed, error
		}

		public static bool SetCheat(ref string str)
		{
			string name = new string(new char[255]);
			string value = new string(new char[255]);

			ParseOpt(str, ref name, ref value);

			int len = name.Length;
			if (len == 0)
				return false; // no cheat name, error

			if (0 == string.Compare(name, 0, "NONE", 0, len))
			{
				g_cheats = 0;
				return true;
			} else if (0 == string.Compare(name, 0, "TORCH", 0, len))
			{
				g_cheats |= AnonymousEnum3.CheatTorch;
				return true;
		}
		//	else if (0==strncmp(name,"RING",len)) {
		//		g_cheats|=CHEAT_RING;
		//		return true;
		//	}
			else if (name[0] == 'R')
			{
				if (len > 1
					&& 0 == string.Compare(name, 1, "ING", 0, len - 1))
				{
					g_cheats |= AnonymousEnum3.CheatRing;
					return true;
				} else if (len > 1 && 0 == string.Compare(name, 1, "EVEAL", 0, len - 1))
				{
					g_cheats |= AnonymousEnum3.CheatReveal;
					return true;
			}
			} else if (0 == string.Compare(name, 0, "CRTSCALE", 0, len))
			{
				g_cheats |= AnonymousEnum3.CheatRegenScaling;
				return true;
		}
		//	else if (0==strncmp(name,"REVEAL",len)) {
		//		g_cheats|=CHEAT_REVEAL;
		//		return true;
		//	}
			else if (name[0] == 'I')
			{
				if (len > 1
					&& 0 == string.Compare(name, 1, "TEMS", 0, len - 1))
				{
					g_cheats |= AnonymousEnum3.CheatItems;
					return true;
				} else if (len > 1 && 0 == string.Compare(name, 1, "NVULNERABLE", 0, len - 1))
				{
					g_cheats |= AnonymousEnum3.CheatInvulnerable;
					return true;
			}
			}

			return false;
		}




		//extern OS_Link oslink;
		//extern Parser parser;
		//extern dodGame game;



		//extern Creature creature;
		//extern CppObject @object;
		//extern Dungeon dungeon;
		//extern Player player;
		//extern Coordinate crd;
		//extern Viewer viewer;
		//extern dodGame game;
		//extern Scheduler scheduler;
		//extern Parser parser;



		//extern Viewer viewer;






		//extern OS_Link oslink;
		//extern Creature creature;
		//extern CppObject @object;
		//extern Viewer viewer;
		//extern dodGame game;
		//extern Scheduler scheduler;
		//extern Parser parser;
		//extern Dungeon dungeon;





		//extern CppObject @object;
		//extern RNG rng;
		//extern Dungeon dungeon;
		//extern dodGame game;
		//extern Parser parser;
		//extern Creature creature;
		//extern Player player;
		//extern Viewer viewer;
		//extern OS_Link oslink;

		/****************************************
		Daggorath PC-Port Version 0.2.1
		Richard Hunerlach
		November 13, 2002
		
		The copyright for Dungeons of Daggorath
		is held by Douglas J. Morgan.
		(c) 1982, DynaMicro
		*****************************************/

		// Dungeons of Daggorath
		// PC-Port
		// Filename: viewer.cpp
		//
		// Implementation of the Viewer class

		/****************************************
		Daggorath PC-Port Version 0.2.1
		Richard Hunerlach
		November 13, 2002
		
		The copyright for Dungeons of Daggorath
		is held by Douglas J. Morgan.
		(c) 1982, DynaMicro
		*****************************************/

		// Dungeons of Daggorath
		// PC-Port
		// Filename: viewer.h
		//
		// This class manages drawing to the screen, including
		// setting up the OpenGL data.  It's a work in progress.
		//
		// At the moment it is huge, which means that it really
		// needs to be broken into smaller, more well-defined
		// classes.  But it works for the present.



		//extern dodGame game;




		//extern Creature creature;
		//extern Dungeon dungeon;
		//extern CppObject @object;
		//extern Parser parser;
		//extern Coordinate crd;
		//extern OS_Link oslink;
		//extern Player player;
		//extern Scheduler scheduler;

		public static int ClearColor = 0;

	}
}
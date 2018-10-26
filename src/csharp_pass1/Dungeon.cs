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
    //
    // This class manages the maze data, and includes
    // methods related to row/column calculations.
    public class Dungeon
	{
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Dungeon"/> class.</summary>
        public Dungeon ()
        {
            throw new NotImplementedException();
            //VFTPTR = 0;
            //SetLEVTABOrig(); //Original seed values will be overwritten (in Player::setInitialObjects())
            //                 //if new random map game.

            //MSKTAB[0] = 0x03;
            //MSKTAB[1] = 0x0C;
            //MSKTAB[2] = 0x30;
            //MSKTAB[3] = 0xC0;

            //DORTAB[0] = AnonymousEnum3.HfDor;
            //DORTAB[1] = AnonymousEnum3.HfDor << 2;
            //DORTAB[2] = AnonymousEnum3.HfDor << 4;
            //DORTAB[3] = AnonymousEnum3.HfDor << 6;

            //SDRTAB[0] = AnonymousEnum3.HfSdr;
            //SDRTAB[1] = AnonymousEnum3.HfSdr << 2;
            //SDRTAB[2] = AnonymousEnum3.HfSdr << 4;
            //SDRTAB[3] = AnonymousEnum3.HfSdr << 6;

            //STPTAB[0] = -1;
            //STPTAB[1] = 0;
            //STPTAB[2] = 0;
            //STPTAB[3] = 1;
            //STPTAB[4] = 1;
            //STPTAB[5] = 0;
            //STPTAB[6] = 0;
            //STPTAB[7] = -1;

            //SetVFTTABOrig(); //Original vertical feature table values will be overwritten (in Dungeon::DGNGEN())
            //                 //if new random map game.

            //// Scaffolding Inits
            //NS = StringFunctions.ChangeCharacter(NS, 3, '�');
            //NS = StringFunctions.ChangeCharacter(NS, 2, '=');
            //NS = StringFunctions.ChangeCharacter(NS, 1, '�');
            //NS = StringFunctions.ChangeCharacter(NS, 0, ' ');
            //EW = StringFunctions.ChangeCharacter(EW, 3, '|');
            //EW = StringFunctions.ChangeCharacter(EW, 2, ')');
            //EW = StringFunctions.ChangeCharacter(EW, 1, '|');
            //EW = StringFunctions.ChangeCharacter(EW, 0, ' ');
        }
        #endregion

        /// <summary>Prints a text drawing of the maze.</summary>
        public void PrintMaze()
		{
            throw new NotImplementedException();
   //         int idx;
			//int row;
			//int x;
			//byte val;
			//int n;
			//int e;
			//int s;
			//int w;
			//for (idx = 0; idx < 1024; idx += 32)
			//{
			//	for (x = 0; x < 3; ++x)
			//	{
			//		for (row = 0; row < 32; ++row)
			//		{
			//			val = MAZLND[idx + row];
			//			n = (val & 0x03);
			//			e = (val & 0x0C) >> 2;
			//			s = (val & 0x30) >> 4;
			//			w = (val & 0xC0) >> 6;
			//			switch (x)
			//			{
			//			case 0:
			//				Console.Write("�{0}", NS[n]);
			//				if (row >= 31)
			//					Console.Write("�");
			//				break;
			//			case 1:
			//				Console.Write("{0}", EW[w]);
			//				if (val == 0xFF)
			//					Console.Write("#");
			//				else
			//					Console.Write(" ");
			//				if (row >= 31)
			//					Console.Write("{0}", EW[e]);
			//				break;
			//			case 2:
			//				if (idx >= 992)
			//				{
			//					Console.Write("�{0}", NS[s]);
			//					if (row >= 31)
			//						Console.Write("�");
			//				}
			//				break;
			//			}
			//		}
			//		if (x < 2)
			//			Console.Write("\n");
			//	}
			//}
		}

        /// <summary>Sets original maze seed values.</summary>
        public void SetLEVTABOrig()
		{
            throw new NotImplementedException();
   //         LEVTAB[0] = 0x73;
			//LEVTAB[1] = 0xC7;
			//LEVTAB[2] = 0x5D;
			//LEVTAB[3] = 0x97;
			//LEVTAB[4] = 0xF3;
			//LEVTAB[5] = 0x13;
			//LEVTAB[6] = 0x87;
		}

        /// <summary>Sets original vertical feature table values.</summary>
        public void SetVFTTABOrig()
		{
            throw new NotImplementedException();
   //         VFTTAB[0] = -1;
			//VFTTAB[1] = 1;
			//VFTTAB[2] = 0;
			//VFTTAB[3] = 23;
			//VFTTAB[4] = 0;
			//VFTTAB[5] = 15;
			//VFTTAB[6] = 4;
			//VFTTAB[7] = 0;
			//VFTTAB[8] = 20;
			//VFTTAB[9] = 17;
			//VFTTAB[10] = 1;
			//VFTTAB[11] = 28;
			//VFTTAB[12] = 30;
			//VFTTAB[13] = -1;
			//VFTTAB[14] = 1;
			//VFTTAB[15] = 2;
			//VFTTAB[16] = 3;
			//VFTTAB[17] = 0;
			//VFTTAB[18] = 3;
			//VFTTAB[19] = 31;
			//VFTTAB[20] = 0;
			//VFTTAB[21] = 19;
			//VFTTAB[22] = 20;
			//VFTTAB[23] = 0;
			//VFTTAB[24] = 31;
			//VFTTAB[25] = 0;
			//VFTTAB[26] = -1;
			//VFTTAB[27] = -1;
			//VFTTAB[28] = 0;
			//VFTTAB[29] = 0;
			//VFTTAB[30] = 31;
			//VFTTAB[31] = 0;
			//VFTTAB[32] = 5;
			//VFTTAB[33] = 0;
			//VFTTAB[34] = 0;
			//VFTTAB[35] = 22;
			//VFTTAB[36] = 28;
			//VFTTAB[37] = 0;
			//VFTTAB[38] = 31;
			//VFTTAB[39] = 16;
			//VFTTAB[40] = -1;
			//VFTTAB[41] = -1;
		}

        /// <summary>Override original vertical feature table values with new ones.</summary>
        /// <remarks>Will override other level's col & row when during map generation.
        /// </remarks>
        public void SetVFTTABRandomMap()
		{
            throw new NotImplementedException();
   //         VFTTAB[0] = 0;
			//VFTTAB[1] = 0;
			//VFTTAB[2] = 0;
			//VFTTAB[3] = -1;
			//VFTTAB[4] = 1;
			//VFTTAB[5] = 0;
			//VFTTAB[6] = 0;
			//VFTTAB[7] = -1;
			//VFTTAB[8] = 1;
			//VFTTAB[9] = 0;
			//VFTTAB[10] = 0;
			//VFTTAB[11] = -1;
			//VFTTAB[12] = -1;
			//VFTTAB[13] = 1;
			//VFTTAB[14] = 0;
			//VFTTAB[15] = 0;
			//VFTTAB[16] = -1;
			//VFTTAB[17] = -1;
		}

        /// <summary>Override seeds with true random numbers.</summary>
        public void SetLEVTABRandomMap()
		{
            throw new NotImplementedException();
   //         RandomNumbers.Seed(GetTickCount());
			//LEVTAB[0] = RandomNumbers.NextByte();
			//LEVTAB[1] = RandomNumbers.NextByte();
			//LEVTAB[2] = RandomNumbers.NextByte();
			//LEVTAB[3] = RandomNumbers.NextByte();
			//LEVTAB[4] = RandomNumbers.NextByte();
			//LEVTAB[5] = RandomNumbers.NextByte();
			//LEVTAB[6] = RandomNumbers.NextByte();
		}

        /// <summary>It builds the maze.</summary>
        /// <remarks>
        /// This method can probably be streamlined since it was written very early.  
        /// </remarks>
        public void Dgngen()
		{
            throw new NotImplementedException();
 //           /* Locals */
 //           int mzctr;
	//		int maz_idx;
	//		int cell_ctr;
	//		byte a_row;
	//		byte a_col;
	//		byte b_row;
	//		byte b_col;
	//		byte DIR;
	//		byte DST;
	//		var DROW = new RowCol();
	//		var ROW = new RowCol();
	//		int spin;

	//		/* Phase 1: Create Maze */

	//		/* Set Cells to 0xFF */
	//		for (mzctr = 0; mzctr < 1024; ++mzctr)
	//			MAZLND[mzctr] = 0xFF;

	//		rng.setSEED(LEVTAB[game.LEVEL], LEVTAB[game.LEVEL + 1], LEVTAB[game.LEVEL + 2]); //Initialize Random Number Generator
	//		cell_ctr = 500; // Room Counter

	//		/* Set Starting Room */
	//		if (!game.RandomMaze
	//			|| game.IsDemo)
	//		{ //Is this an original game?  Yes:
	//			a_col = (rng.RANDOM() & 31);
	//			a_row = (rng.RANDOM() & 31);
	//			DROW.SetRC(a_row, a_col);
	//			RndDstDir(ref DIR, ref DST);
	//			SetVFTTABOrig(); //Make sure the vertical feature table isn't overwritten from pervious new game.
	//		} else
	//		{ //Is this an original game?  No:
	//			switch (game.LEVEL)
	//			{
	//				case 0:
	//				case 3:
	//					a_col = (rng.RANDOM() & 31);
	//					a_row = (rng.RANDOM() & 31);
	//					break;
	//				case 1:
	//					a_row = VFTTAB[5];
	//					a_col = VFTTAB[6];
	//					break;
	//				case 2:
	//					a_row = VFTTAB[9];
	//					a_col = VFTTAB[10];
	//					break;
	//				default:
	//					a_row = VFTTAB[14];
	//					a_col = VFTTAB[15];
	//					break;
	//			}

	//			if (player.PROW == 0x10
	//				&& player.PCOL == 0x0B
	//				&& game.LEVEL == 0)
	//			{ //Are we starting a new game?
	//				player.PROW = a_row;
	//				player.PCOL = a_col;

	//				//Override veritical features.
	//				//Will override other level's col & row during map generation.
	//				SetVFTTABRandomMap();
	//				VFTTAB[1] = a_row;
	//				VFTTAB[2] = a_col;
	//			} //Are we starting a new game?

	//			//Original didn't tunnel out original room.
	//			//Need to do it now so that player doesn't start in wall in beginning of game.
	//			//Also need to make sure ladder back up to each level is in a tunneled out room.
	//			DROW.SetRC(a_row, a_col);
	//			RndDstDir(ref DIR, ref DST);
	//			maz_idx = Rc2idx(a_row, a_col);
	//			MAZLND[maz_idx] = 0;
	//			--cell_ctr;
	//		} //Is this an original game?

	//		while (cell_ctr > 0)
	//		{
	//			/* Take a step */
	//			b_row = DROW.row;
	//			b_col = DROW.col;
	//			b_row += STPTAB[DIR * 2];
	//			b_col += STPTAB[(DIR * 2) + 1];

	//			/* Check if it's out of bounds */
	//			if (Border(b_row, b_col) == false)
	//			{
	//				RndDstDir(ref DIR, ref DST);
	//				continue;
	//			}

	//			/* Store index and temp room */
	//			maz_idx = Rc2idx(b_row, b_col);
	//			ROW.SetRC(b_row, b_col);

	//			/* If not yet touched */
	//			if (MAZLND[maz_idx] == 0xFF)
	//			{
	////C++ TO C# CONVERTER TODO TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
	////ORIGINAL LINE: FRIEND(ROW);
	//				Friend(new RowCol(ROW));
	//				if (NEIBOR[3] + NEIBOR[0] + NEIBOR[1] == 0
	//					|| NEIBOR[1] + NEIBOR[2] + NEIBOR[5] == 0
	//					|| NEIBOR[5] + NEIBOR[8] + NEIBOR[7] == 0
	//					|| NEIBOR[7] + NEIBOR[6] + NEIBOR[3] == 0)
	//				{
	//					RndDstDir(ref DIR, ref DST);
	//					continue;
	//				}
	//				MAZLND[maz_idx] = 0;
	//				--cell_ctr;
	//			}
	//			if (cell_ctr > 0)
	//			{
	////C++ TO C# CONVERTER TODO TASK: The following line was determined to be a copy assignment (rather than a reference assignment) - this should be verified and a 'CopyFrom' method should be created:
	////ORIGINAL LINE: DROW = ROW;
	//				DROW.CopyFrom(ROW);
	//				--DST;
	//				if (DST == 0)
	//				{
	//					RndDstDir(ref DIR, ref DST);
	//					continue;
	//				} else
	//				{
	//					continue;
	//				}
	//			}
	//		}

	//		/* Phase 2: Create Walls */

	//		for (DROW.row = 0; DROW.row < 32; ++DROW.row)
	//		{
	//			for (DROW.col = 0; DROW.col < 32; ++DROW.col)
	//			{
	//				maz_idx = Rc2idx(DROW.row, DROW.col);
	//				if (MAZLND[maz_idx] != 0xFF)
	//				{
	////C++ TO C# CONVERTER TODO TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
	////ORIGINAL LINE: FRIEND(DROW);
	//					Friend(new RowCol(DROW));
	//					if (NEIBOR[1] == 0xFF)
	//						MAZLND[maz_idx] |= AnonymousEnum3.NWALL;
	//					if (NEIBOR[3] == 0xFF)
	//						MAZLND[maz_idx] |= AnonymousEnum3.WWALL;
	//					if (NEIBOR[5] == 0xFF)
	//						MAZLND[maz_idx] |= AnonymousEnum3.EWALL;
	//					if (NEIBOR[7] == 0xFF)
	//						MAZLND[maz_idx] |= AnonymousEnum3.SWALL;
	//				}
	//			}
	//		}

	//		/* Phase 3: Create Doors/Secret Doors */

	//		for (mzctr = 0; mzctr < 70; ++mzctr)
	//			Makdor(this.DORTAB);

	//		for (mzctr = 0; mzctr < 45; ++mzctr)
	//			Makdor(this.SDRTAB);

	//		/* Phase 4: Create vertical feature */
	//		if (game.RandomMaze
	//			&& !game.IsDemo
	//			&& (game.LEVEL == 0 || game.LEVEL == 1 || game.LEVEL == 3))
	//		{
	//			do
	//			{
	//				do
	//				{
	//					a_col = (rng.RANDOM() & 31);
	//					a_row = (rng.RANDOM() & 31);
	//					ROW.SetRC(a_row, a_col);
	//					maz_idx = Rc2idx(a_row, a_col);
	//				} while (MAZLND[maz_idx] == 0xFF);
	//			} while ((game.LEVEL == 0 && VFTTAB[1] == a_row && VFTTAB[2] == a_col) || (game.LEVEL == 1 && VFTTAB[5] == a_row && VFTTAB[6] == a_col));
	//			switch (game.LEVEL)
	//			{
	//				case 0:
	//					if (VFTTAB[5] == 0
	//						&& VFTTAB[6] == 0)
	//					{
	//						VFTTAB[5] = a_row;
	//						VFTTAB[6] = a_col;
	//					}
	//					break;
	//				case 1:
	//					if (VFTTAB[9] == 0
	//						&& VFTTAB[10] == 0)
	//					{
	//						VFTTAB[9] = a_row;
	//						VFTTAB[10] = a_col;
	//					}
	//					break;
	//				default:
	//					if (VFTTAB[14] == 0
	//						&& VFTTAB[15] == 0)
	//					{
	//						VFTTAB[14] = a_row;
	//						VFTTAB[15] = a_col;
	//					}
	//					break;
	//			}
	//		}
                       
	//		// Spin the RNG
	//		if (scheduler.curTime == 0)
	//		{
	//			if (game.LEVEL == 0)
	//				spin = 6;
	//			else
	//				spin = 21;
	//		} else
	//		{
	//			spin = (scheduler.curTime % 60);
	//		}

	//		while (spin > 0)
	//		{
	//			rng.RANDOM();
	//			--spin;
	//		}
		}

        /// <summary>Adds vertical features.</summary>
        public void CalcVFI()
		{
            throw new NotImplementedException();
   //         byte lvl = game.LEVEL;
			//byte idx = 0;
			//do
			//{
			//	VFTPTR = idx;
			//	while (VFTTAB[idx++] != 0xFF)
			//		; // loop !!!
			//	--lvl;
			//} while (lvl != 0xFF);
		}

		public int Rc2idx(byte R, byte C)
		{
            throw new NotImplementedException();
   //         R &= 31;
			//C &= 31;
			//return (R * 32 + C);
		}

        /// <summary>Checks if a step can be taken from the given row/col in the given direction.</summary>
        public bool Stepok(byte R, byte C, byte dir)
		{
            throw new NotImplementedException();
   //         R += STPTAB[dir * 2];
			//C += STPTAB[(dir * 2) + 1];
			//if (Border(R, C) == false)
			//	return false;
			//if (MAZLND[Rc2idx(R, C)] == 255)
			//	return false;
			//return true;
		}

        /// <summary>Checks if a hole/ladder is in cell.</summary>
        /// <remarks>
        /// It has to check above and below, since each vertical feature is stored only once in the VFT
        /// </remarks>
        public byte Vfind(RowCol rc)
		{
            throw new NotImplementedException();
   //         int u = VFTPTR;
			//byte a = 0;
			//bool res;
			//res = VFINDsub(ref a, ref u, rc);
			//if (res == true)
			//	return a;
			//res = VFINDsub(ref a, ref u, rc);
			//if (res == true)
			//	return a + 2;
			//else
			//	return -1;
		}

        /// <summary>Checks for a wall in the given direction.</summary>
        public bool TryMove(byte dir)
		{
            throw new NotImplementedException();
   //         int idx;
			//byte a;
			//idx = Rc2idx(player.PROW, player.PCOL);
			//a = ((MAZLND[idx] >> (dir * 2)) & 3);
			//if (a != 3)
			//	return true;
			//else
			//	return false;
		}

		//TODO: Make properties
		public byte[] MAZLND = new byte[1024]; // The Maze
		public byte[] NEIBOR = new byte[9]; // The cells around the player
									// Also used to store the walls/doors
									// of a given cell (for the 3D-Viewer)
		public byte[] LEVTAB = new byte[7]; // The RNG seeds
		public RowCol DROW = new RowCol();
		public int[] STPTAB = new int[8];
		public sbyte[] VFTTAB = new sbyte[42];
		public int VFTPTR;
        
		//public enum AnonymousEnum3
        public static class AnonymousEnum3
        {
			public const int NWALL = 0x03;
			public const int EWALL = 0x0c;
			public const int SWALL = 0x30;
            public const int WWALL = 0xc0;
			public const int HfPas = 0;
			public const int HfDor = 1;
			public const int HfSdr = 2;
            public const int HfWal = 3;

			public const int VfHoleUp = 0;
			public const int VfLadderUp = 1;
			public const int VfHoleDown = 2;
			public const int VfLadderDown = 3;
			public const int VfNull = 255;
		}

        #region Private Members

        private bool Border(byte R, byte C)
		{
            throw new NotImplementedException();
   //         if ((R & 224) != 0)
			//	return false;
			//if ((C & 224) != 0)
			//	return false;
			//return true;
		}

		// Adds doors
		private void Makdor(byte[] table)
		{
            throw new NotImplementedException();
   //         byte a_row;
			//byte a_col;
			//int maz_idx;
			//byte val;
			//byte DIR;
			//RowCol ROW = new RowCol();

			//do
			//{
			//	do
			//	{
			//		a_col = (rng.RANDOM() & 31);
			//		a_row = (rng.RANDOM() & 31);
			//		ROW.SetRC(a_row, a_col);
			//		maz_idx = Rc2idx(a_row, a_col);
			//		val = MAZLND[maz_idx];
			//	} while (val == 0xFF);

			//	DIR = (rng.RANDOM() & 3);
			//} while ((val & MSKTAB[DIR]) != 0);

			//MAZLND[maz_idx] |= table[DIR];

			//ROW.row += STPTAB[DIR * 2];
			//ROW.col += STPTAB[(DIR * 2) + 1];
			//DIR += 2;
			//DIR &= 3;
			//maz_idx = Rc2idx(ROW.row, ROW.col);
			//MAZLND[maz_idx] |= table[DIR];
		}

		// Finds surrounding cells
		private void Friend(RowCol RC)
		{
            throw new NotImplementedException();
   //         byte r3;
			//byte c3;
			//int u = 0;

			//for (r3 = RC.row; r3 <= (RC.row + 2); ++r3)
			//{
			//	for (c3 = RC.col; c3 <= (RC.col + 2); ++c3)
			//	{
			//		if (Border((r3 - 1), (c3 - 1)) == false)
			//			NEIBOR[u] = 0xFF;
			//		else
			//			NEIBOR[u] = MAZLND[Rc2idx((r3 - 1), (c3 - 1))];
			//		++u;
			//	}
			//}
		}

		private void RndDstDir(ref byte DIR, ref byte DST)
		{
            throw new NotImplementedException();
            //DIR = (rng.RANDOM() & 3);
			//DST = (rng.RANDOM() & 7) + 1;
		}

		private bool VFINDsub(ref byte a, ref int u, RowCol rc)
		{
            throw new NotImplementedException();
   //         byte r;
			//byte c;

			//do
			//{
			//	a = VFTTAB[u++];
			//	if (a == 0xFF)
			//		return false;
			//	r = VFTTAB[u++];
			//	c = VFTTAB[u++];
			//} while (!((r == rc.row) && (c == rc.col)));
			//return true;
		}
        		
		private byte[] MSKTAB = new byte[4];
		private byte[] DORTAB = new byte[4];
		private byte[] SDRTAB = new byte[4];
        		
		private string NS = new string(new char[4]);
		private string EW = new string(new char[4]);

        #endregion
    }
}
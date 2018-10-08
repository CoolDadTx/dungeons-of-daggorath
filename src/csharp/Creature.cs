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
    // This class manages the creature data and movement
    public class Creature
	{
		// Constructor

		// Constructor
		public Creature()
		{
			Reset();
		}

		// Public Interface

		// This routine creates a new dungeon level,
		// filling it with objects and creatures.  It
		// should probably be moved to the Dungeon class.
		public void Newlvl()
		{
			byte a;
			byte b;
			int u;
			int idx;
			int tmp;

			CMXPTR = game.LEVEL * AnonymousEnum2.Ctypes;
			dungeon.CalcVFI();
			for (tmp = 0; tmp < 32; ++tmp)
				CCBLND[tmp].Clear();
			scheduler.SYSTCB();
			dungeon.DGNGEN();
			u = CMXPTR;
			a = (int)AnonymousEnum2.Ctypes - 1;
			do
			{
				b = CMXLND[u + a];
				if (b != 0)
				{
					do
					{
						Cbirth(a);
						--b;
					} while (b != 0);
				}
				--a;
			} while (a != 0xFF);

			u = -1;
			@object.OFINDF = 0;
			do
			{
				idx = @object.FNDOBJ();
				if (idx == -1)
					break;
				if (@object.OCBLND[idx].P_OCOWN == 0xFF)
				{
					do
					{
						++u;
						if (u == 32)
							u = 0;
						if (CCBLND[u].P_CCUSE != 0)
						{
							tmp = CCBLND[u].P_CCOBJ;
							CCBLND[u].P_CCOBJ = idx;
							@object.OCBLND[idx].P_OCPTR = tmp;
							break;
						}
					} while (true);
				}
			} while (true);

			// Determine video invert Setting
			viewer.setVidInv((game.LEVEL % 2) ?true: false);
		}

		// This method is called from the scheduler once every five
		// minutes.  It will generate random new creatures.
		public int Cregen()
		{
			// Update Task's next_time
			scheduler.TCBLND[(int)Scheduler.AnonymousEnum5.TidCrtregen].next_time = scheduler.curTime + scheduler.TCBLND[(int)Scheduler.AnonymousEnum5.TidCrtregen].frequency;

			int X = CMXPTR;
			byte B = (int)AnonymousEnum2.Ctypes - 1;
			byte A = 0;
			do
			{
				A += CMXLND[X + B];
				--B;
			} while (B != 255);
			if (A < 32)
			{
				A = rng.RANDOM();
				if ((g_cheats & (int)AnonymousEnum8.CheatRegenScaling) != 0)
				{
					switch (game.LEVEL)
					{
					case 0:
						A %= 4;
						break;
					case 1:
						A %= 5;
						A += 1;
						break;
					case 2:
						A %= 6;
						A += 1;
						break;
					case 3:
						A %= 7;
						A += 2;
						break;
					case 4:
						A %= 7;
						A += 3;
						break;
					}
				} else
				{
					A &= 7;
					A += 2;
				}
				++CMXLND[X + A];
			}
			return 0;
		}

		// This method is called from the scheduler to move the
		// creatures.  This is where most of the creature logic
		// resides.  It's frequency is determined by the creature
		// type, and its location relative to the player.
		public int Cmove(int task, int cidx)
		{
			int oidx;
			int dir;
			int X;
			int loop;
			bool doRandom = false;
			byte r;
			byte c;
			byte rnd;
			byte d;
			byte shA;
			byte shB;
			ushort shD;
			ushort shD2;

			if (FRZFLG == 0)
			{
				// ignore dead creatures
				if (CCBLND[cidx].P_CCUSE == 0)
					return 0;

				// pick up object
				if (CCBLND[cidx].creature_id != (int)AnonymousEnum.CrtScorpion
					&& CCBLND[cidx].creature_id < AnonymousEnum.CrtWizimg
					&& !(game.CreaturesIgnoreObjects && CCBLND[cidx].P_CCROW == player.PROW && CCBLND[cidx].P_CCCOL == player.PCOL))
				{
					@object.OFINDF = 0;
					oidx = @object.OFIND(new RowCol(CCBLND[cidx].P_CCROW, CCBLND[cidx].P_CCCOL));
					if (oidx != -1)
					{
						@object.OCBLND[oidx].P_OCPTR = CCBLND[cidx].P_CCOBJ;
						CCBLND[cidx].P_CCOBJ = oidx;
						--@object.OCBLND[oidx].P_OCOWN;
						viewer.PUPDAT();
						if (CCBLND[cidx].P_CCROW == player.PROW
							&& CCBLND[cidx].P_CCCOL == player.PCOL)
						{
							viewer.PUPDAT();
							viewer.NEWLUK = 0;
							scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTAT;
							return 0;
						} else
						{
							scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTMV;
							return 0;
						}
					}
				}

				// attack player
				if (CCBLND[cidx].P_CCROW == player.PROW
					&& CCBLND[cidx].P_CCCOL == player.PCOL)
				{
					// do creature sound
					Mix_PlayChannel(creChannel, creSound[CCBLND[cidx].creature_id], 0);
					while (Mix_Playing(creChannel) == 1)
					{
						if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
						{
							scheduler.CLOCK();
							if (game.AUTFLG
								&& game.demoRestart == false)
								return 0;
						}
						scheduler.curTime = SDL_GetTicks();
					}

					// set player shielding parameters
					shA = 0x80;
					shB = 0x80;

					if (player.PLHAND != -1
						&& @object.OCBLND[player.PLHAND].obj_type == CppObject.OBJT_SHIELD)
					{
						shD = (((int)shA << 8) | shB);
						shD2 = (((int)@object.OCBLND[player.PLHAND].P_OCXX0 << 8) | @object.OCBLND[player.PLHAND].P_OCXX1);
						if (shD2 < shD)
						{
							shA = (shD2 >> 8);
							shB = (shD2 & 255);
						}
					}

					if (player.PRHAND != -1
						&& @object.OCBLND[player.PRHAND].obj_type == CppObject.OBJT_SHIELD)
					{
						shD = (((int)shA << 8) | shB);
						shD2 = (((int)@object.OCBLND[player.PRHAND].P_OCXX0 << 8) | @object.OCBLND[player.PRHAND].P_OCXX1);
						if (shD2 < shD)
						{
							shA = (shD2 >> 8);
							shB = (shD2 & 255);
						}
					}

					player.PMGD = shA;
					player.PPHD = shB;

					// process attack

					if (((g_cheats & (int)AnonymousEnum8.CheatInvulnerable) == 0)
					{
						if (player.ATTACK(CCBLND[cidx].P_CCPOW, player.PPOW, player.PDAM))
						{
							// make CLANK sound
							Mix_PlayChannel(creChannel, clank, 0);
							while (Mix_Playing(creChannel) == 1)
							{
								if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
								{
									scheduler.CLOCK();
									if (game.AUTFLG
										&& game.demoRestart == false)
										return 0;
								}
								scheduler.curTime = SDL_GetTicks();
							}

							player.DAMAGE(CCBLND[cidx].P_CCPOW, CCBLND[cidx].P_CCMGO, CCBLND[cidx].P_CCPHO, player.PPOW, player.PMGD, player.PPHD, player.PDAM);
						}
					}

					player.HUPDAT();
					scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTMV;
					return 0;
				}

				// look for player along ROW axis
				if (CCBLND[cidx].P_CCROW == player.PROW)
				{
					if (CCBLND[cidx].P_CCCOL < player.PCOL)
						dir = 1;
					else
						dir = 3;
					r = CCBLND[cidx].P_CCROW;
					c = CCBLND[cidx].P_CCCOL;
					do
					{
						if (!dungeon.STEPOK(r, c, dir))
						{
							doRandom = true;
							break;
						}
						r += dungeon.STPTAB[dir * 2];
						c += dungeon.STPTAB[(dir * 2) + 1];
					} while (!(r == player.PROW && c == player.PCOL));
					if (doRandom == false)
					{
						CCBLND[cidx].P_CCDIR = dir;
						Cwalk(0, CCBLND[cidx]);
						if (CCBLND[cidx].P_CCROW == player.PROW
							&& CCBLND[cidx].P_CCCOL == player.PCOL)
						{
							viewer.PUPDAT();
							viewer.NEWLUK = 0;
							scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTAT;
							return 0;
						} else
						{
							scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTMV;
							return 0;
						}
					}
				}

				// look for player along COL axis
				if (CCBLND[cidx].P_CCCOL == player.PCOL)
				{
					if (CCBLND[cidx].P_CCROW < player.PROW)
						dir = 2;
					else
						dir = 0;
					r = CCBLND[cidx].P_CCROW;
					c = CCBLND[cidx].P_CCCOL;
					do
					{
						if (!dungeon.STEPOK(r, c, dir))
						{
							doRandom = true;
							break;
						}
						r += dungeon.STPTAB[dir * 2];
						c += dungeon.STPTAB[(dir * 2) + 1];
					} while (!(r == player.PROW && c == player.PCOL));
					if (doRandom == false)
					{
						CCBLND[cidx].P_CCDIR = dir;
						Cwalk(0, CCBLND[cidx]);
						if (CCBLND[cidx].P_CCROW == player.PROW
							&& CCBLND[cidx].P_CCCOL == player.PCOL)
						{
							viewer.PUPDAT();
							viewer.NEWLUK = 0;
							scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTAT;
							return 0;
						} else
						{
							scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTMV;
							return 0;
						}
					}
				}

				// player not seen so make random move
				if (doRandom
					|| (CCBLND[cidx].P_CCROW != player.PROW && CCBLND[cidx].P_CCCOL != player.PCOL))
				{
					X = 0;
					rnd = rng.RANDOM();
					if ((rnd & 128) == 0)
						X += 3;
					rnd &= 3;
					if (rnd == 0)
						X += 1;
					loop = 3;
					do
					{
						d = MOVTAB[X++];
						if (Cwalk(d, CCBLND[cidx]))
						{
							if (CCBLND[cidx].P_CCROW == player.PROW
								&& CCBLND[cidx].P_CCCOL == player.PCOL)
							{
								viewer.PUPDAT();
								viewer.NEWLUK = 0;
								scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTAT;
								return 0;
							} else
							{
								scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTMV;
								return 0;
							}
						}
						--loop;
					} while (loop != 0);
					Cwalk(2, CCBLND[cidx]);
				}
			}

			if (CCBLND[cidx].P_CCROW == player.PROW
				&& CCBLND[cidx].P_CCCOL == player.PCOL)
			{
				viewer.PUPDAT();
				viewer.NEWLUK = 0;
				scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTAT;
				return 0;
			} else
			{
				scheduler.TCBLND[task].next_time = scheduler.curTime + CCBLND[cidx].P_CCTMV;
				return 0;
			}
		}

		// This routine attempts to move the creature in the
		// given direction.
		public bool Cwalk(byte dir, Ccb cr)
		{
			byte DIR;
			byte r;
			byte c;
			byte rr;
			byte cc;
			byte big;
			byte small;

			dir += cr.P_CCDIR;
			dir &= 3;
			DIR = dir;

			r = cr.P_CCROW;
			c = cr.P_CCCOL;
			if (dungeon.STEPOK(r, c, DIR))
			{
				r += dungeon.STPTAB[DIR * 2];
				c += dungeon.STPTAB[(DIR * 2) + 1];
				if (!Cfind(r, c))
					return false;

				rr = r;
				cc = c;

				if (r > player.PROW)
					r = r - player.PROW;
				else
					r = player.PROW - r;

				if (c > player.PCOL)
					c = c - player.PCOL;
				else
					c = player.PCOL - c;

				if (r > c)
				{
					big = r;
					small = c;
				} else
				{
					big = c;
					small = r;
				}

				if (big > 8)
				{
					cr.P_CCROW = rr;
					cr.P_CCCOL = cc;
					cr.P_CCDIR = DIR;
					return true;
				}

				if (small > 2)
				{
					cr.P_CCROW = rr;
					cr.P_CCCOL = cc;
					cr.P_CCDIR = DIR;
					return true;
				}

				small = (rng.RANDOM() & 1);
				if (small == 1)
				{
					// make sound
					if ((g_options & (int)AnonymousEnum7.OptStereo) != 0)
					{
						// get x / y position of sound relative to player location
						int xpos = cr.P_CCROW - player.PROW;
						int ypos = cr.P_CCCOL - player.PCOL;
						int pan = 128;

						// translate x/y position into x(thru ear axis)
						//position relative to player facing direction
						switch (player.PDIR & 3)
						{
						case 0:
							xpos = ypos;
							break;
						case 1:
							xpos = xpos;
							break;
						case 2:
							xpos = -ypos;
							break;
						case 3:
							xpos = -xpos;
							break;
						}

						// NOTE: this could be improved.
						// distant monsters pan too quickly
						// while nearby monsters pan too slowly
						// the clipping step below should clip to a smaller range
						// for close monsters and a wider range to far monsters

						// clip the pan angle to between -4 and 4
						if (xpos > 2)
							xpos = 2;
						else if (xpos < -2)
							xpos = -2;

						// convert the pan angle into a number from 0 to 255
						pan = 127 + xpos * 63;

						// convert the pan value into L/R volumes with a crossfading algorithm
						// like so:
						//
						// pan  ____....----''''
						//
						// panL ''''''--..______
						//
						// panR ______..--''''''

						int panr = (int)(pan * 1.5f);
						if (panr > 255)
							panr = 255;

						int panl = (int)(511 - (pan * 1.5f));
						if (panl > 255)
							panl = 255;

						// pan the sound effect before playing it
						Mix_SetPanning(creChannelv, panl, panr);
					}

					Mix_Volume(creChannelv, (MIX_MAX_VOLUME / 8) * (9 - big));
					Mix_PlayChannel(creChannelv, creSound[cr.creature_id], 0);
					while (Mix_Playing(creChannelv) == 1)
					{
						if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
							scheduler.CLOCK();
						scheduler.curTime = SDL_GetTicks();
					}
				}

				cr.P_CCROW = rr;
				cr.P_CCCOL = cc;
				cr.P_CCDIR = DIR;

				--viewer.NEWLUK;
				return true;
			}

			return false;
		}

		// These two routines should probably be combined.
		// They check for a creature in the given cell
		public bool Cfind(byte rw, byte cl)
		{
			int ctr = 0;
			while (ctr < 32)
			{
				if (CCBLND[ctr].P_CCROW == rw
					&& CCBLND[ctr].P_CCCOL == cl)
				{
					if (CCBLND[ctr].P_CCUSE != 0)
						return false;
				}
				++ctr;
			}
			return true;
		}

		// These two routines should probably be combined.
		// They check for a creature in the given cell
		public int Cfind2(RowCol rc)
		{
			int ctr = 0;
			while (ctr < 32)
			{
				if (CCBLND[ctr].P_CCROW == rc.row
					&& CCBLND[ctr].P_CCCOL == rc.col)
				{
					if (CCBLND[ctr].P_CCUSE != 0)
						return ctr;
				}
				++ctr;
			}
			return -1;
		}
		public void Reset()
		{
			creChannel = 1;
			creChannelv = 2;
			creSpeedMul = 100;

			CMXPTR = 0;
			FRZFLG = 0;

			CDBTAB[0] = new Cdb(32, 0, 255, 128, 255, 2300, 1100);
			CDBTAB[1] = new Cdb(56, 0, 255, 80, 128, 1500, 700);
			CDBTAB[2] = new Cdb(200, 0, 255, 52, 192, 2900, 2300);
			CDBTAB[3] = new Cdb(304, 0, 255, 96, 167, 3100, 3100);
			CDBTAB[4] = new Cdb(504, 0, 128, 96, 60, 1300, 700);
			CDBTAB[5] = new Cdb(704, 0, 128, 128, 48, 1700, 1300);
			CDBTAB[6] = new Cdb(400, 255, 128, 255, 128, 500, 400);
			CDBTAB[7] = new Cdb(800, 0, 64, 255, 8, 1300, 700);
			CDBTAB[8] = new Cdb(800, 192, 16, 192, 8, 300, 300);
			CDBTAB[9] = new Cdb(1000, 255, 5, 255, 3, 400, 300);
			CDBTAB[10] = new Cdb(1000, 255, 6, 255, 0, 1300, 700);
			CDBTAB[11] = new Cdb(8000, 255, 6, 255, 0, 1300, 700);

			if (game.VisionScroll) //Do we need to replace a snake with a blob w/ a vision scroll?  Yes:
				Utils.LoadFromDecDigit(CMXLND, "984300000000240666000000000406840010000000866400222222244801");
			else //Do we need to replace a snake with a blob w/ a vision scroll?  No:
				Utils.LoadFromDecDigit(CMXLND, "994200000000240666000000000406840010000000866400222222244801");
			Utils.LoadFromDecDigit(MOVTAB, "0310130");
		}
		public void LoadSounds()
		{
			creSound[0] = Utils.LoadSound("00_squeak.wav");
			creSound[1] = Utils.LoadSound("01_rattle.wav");
			creSound[2] = Utils.LoadSound("02_growl.wav");
			creSound[3] = Utils.LoadSound("03_beoop.wav");
			creSound[4] = Utils.LoadSound("04_klank.wav");
			creSound[5] = Utils.LoadSound("05_grawl.wav");
			creSound[6] = Utils.LoadSound("06_pssst.wav");
			creSound[7] = Utils.LoadSound("07_kklank.wav");
			creSound[8] = Utils.LoadSound("08_pssht.wav");
			creSound[9] = Utils.LoadSound("09_snarl.wav");
			creSound[10] = Utils.LoadSound("0A_bdlbdl.wav");
			creSound[11] = Utils.LoadSound("0B_bdlbdl.wav");
			clank = Utils.LoadSound("13_clank.wav");
			kaboom = Utils.LoadSound("16_kaboom.wav");
			buzz = Utils.LoadSound("19_buzz.wav");
		}
		public void UpdateCreSpeed()
		{
			for (int ccc = 0; ccc < 12; ++ccc)
			{
				CDBTAB[ccc].P_CDTMV = ((int)((float)CDBTAB[ccc].P_CDTMV * (float)creSpeedMul / 100.0));
				CDBTAB[ccc].P_CDTAT = ((int)((float)CDBTAB[ccc].P_CDTAT * (float)creSpeedMul / 100.0));
			}
		}

		// Public Data Fields
		public Ccb[] CCBLND = Arrays.InitializeWithDefaultInstances<Ccb>(32);
		public byte FRZFLG;
		public int CMXPTR;
		public byte[] CMXLND = new byte[60];
		public byte[] MOVTAB = new byte[7];
		public Mix_Chunk[] creSound = Arrays.InitializeWithDefaultInstances<Mix_Chunk>(12);
		public Mix_Chunk clank;
		public Mix_Chunk kaboom;
		public Mix_Chunk buzz;
		public int creChannel;
		public int creChannelv;
		public int creSpeedMul;

	//C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named AnonymousEnum:
		public enum AnonymousEnum
		{ // creature ID#s
			CrtSpider = 0,
			CrtViper = 1,
			CrtGiant1 = 2,
			CrtBlob = 3,
			CrtKnight1 = 4,
			CrtGiant2 = 5,
			CrtScorpion = 6,
			CrtKnight2 = 7,
			CrtWraith = 8,
			CrtGaldrog = 9,
			CrtWizimg = 10,
			CrtWizard = 11,
		}

		// Internal Implementation

		// Creates a new creature and places it in the maze
		private void Cbirth(byte typ)
		{
			int u;
			int maz_idx;
			RowCol rndcell = new RowCol();
			byte rw;
			byte cl;
			int TCBindex;

			u = -1;
			do
				++u;
			while (CCBLND[u].P_CCUSE != 0);
			--CCBLND[u].P_CCUSE;

			CCBLND[u].creature_id = typ;
			CCBLND[u].P_CCPOW = CDBTAB[typ].P_CDPOW;
			CCBLND[u].P_CCMGO = CDBTAB[typ].P_CDMGO;
			CCBLND[u].P_CCMGD = CDBTAB[typ].P_CDMGD;
			CCBLND[u].P_CCPHO = CDBTAB[typ].P_CDPHO;
			CCBLND[u].P_CCPHD = CDBTAB[typ].P_CDPHD;
			CCBLND[u].P_CCTMV = CDBTAB[typ].P_CDTMV;
			CCBLND[u].P_CCTAT = CDBTAB[typ].P_CDTAT;

			do
			{
				do
				{
					cl = (rng.RANDOM() & 31);
					rw = (rng.RANDOM() & 31);
					//printf("          %02X, %02X = %02X\n", rw, cl, dungeon.MAZLND[dungeon.RC2IDX(rw, cl)]);
					rndcell.SetRC(rw, cl);
					maz_idx = dungeon.RC2IDX(rw, cl);
				} while (dungeon.MAZLND[maz_idx] == 0xFF);
			} while (Cfind(rw, cl) == false);

			//printf("----- %02X: %02X, %02X -----\n", typ, rw, cl);
			CCBLND[u].P_CCROW = rw;
			CCBLND[u].P_CCCOL = cl;

			TCBindex = scheduler.GETTCB();
			scheduler.TCBLND[TCBindex].data = u;
			scheduler.TCBLND[TCBindex].type = Scheduler.AnonymousEnum5.TidCrtmove;
			scheduler.TCBLND[TCBindex].frequency = CCBLND[u].P_CCTMV;
		}

		// Data Fields
		private Cdb[] CDBTAB = Arrays.InitializeWithDefaultInstances<Cdb>(12);

		// Constants
	//C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named AnonymousEnum2:
		private enum AnonymousEnum2
		{
			Ctypes = 12,
		}
	}
}
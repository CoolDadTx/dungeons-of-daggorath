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
    // Implementation of Player class
    public class Player
	{
		// Constructor

		// Constructor
		public Player()
		{
			this.PPOW = PLRBLK.P_ATPOW;
			this.PMGO = PLRBLK.P_ATMGO;
			this.PMGD = PLRBLK.P_ATMGD;
			this.PPHO = PLRBLK.P_ATPHO;
			this.PPHD = PLRBLK.P_ATPHD;
			this.PDAM = PLRBLK.P_ATDAM;
			this.turnDelay = 20;
			this.moveDelay = 25;
			this.wizDelay = 500;
			Reset();
		}

		// Public Interface

		// This method gets called from the scheduler as often
		// as possible.  It retrieves keyboard input, or commands
		// from the demo data.
		public int Player()
		{
			int tokCnt;
			int tokCtr;
			byte[] objstr = new byte[10];
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: byte * X, * U;
			byte X;
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: byte * U;
			byte U;
			int Xup;

			// Update Task's next_time
			scheduler.TCBLND[(int)Scheduler.AnonymousEnum2.TidPlayer].next_time = scheduler.curTime + scheduler.TCBLND[(int)Scheduler.AnonymousEnum2.TidPlayer].frequency;

			byte c;
			if (game.AUTFLG == 0)
			{
				// Process Keyboard Buffer
				do
				{
					c = parser.KBDGET();
					if (c == 0)
						return 0;
					if (FAINT != 0)
					{
						while (parser.KBDGET() != 0)
							; // loop !!!
						return 0;
					}

					// Convert from ASCII to Internal Codes
					if (c >= (byte)'A'
						&& c <= (byte)'Z')
						c &= 0x1F;
					else if (c == parser.C_BS)
						c = parser.I_BS;
					else if (c == parser.C_CR)
						c = parser.I_CR;
					else
						c = parser.I_SP;

					if (!Human(c))
						return -1;
				} while (true);
			} else
			{
				// Process Autoplay Commands
				tokCnt = game.DEMO_CMDS[game.DEMOPTR++];
				if (tokCnt == 0)
				{
					game.WAIT();
					game.WAIT();
					game.hasWon = true;
					game.demoRestart = true;
					return 0;
				}

				// Feed next autoplay command to HUMAN
				tokCtr = 1;

				do
				{
					if (tokCtr == 1)
						X = parser.CMDTAB[game.DEMO_CMDS[game.DEMOPTR]];
					else if (tokCtr == 2)
						X = parser.DIRTAB[game.DEMO_CMDS[game.DEMOPTR]];
					else
						X = @object.GENTAB[game.DEMO_CMDS[game.DEMOPTR]];
					++game.DEMOPTR;
					U = objstr[1];
					parser.EXPAND(X, Xup, U);
					++U;
					game.WAIT();
					do
					{
						Human(U);
						++U;
					} while (U != 0xFF);
					Human(parser.I_SP);
					++tokCtr;
				} while (tokCtr <= tokCnt);
				--viewer.UPDATE;
				viewer.draw_game();
				Human(parser.I_CR);
			}

			return 0;
		}
		public bool Human(byte c)
		{
			int res;
			byte A;
			byte B;

			// Check if we are displaying the map
			if (HEARTF == 0)
			{
				game.INIVU();
				viewer.PROMPT();
			}
			if (c == parser.I_CR)
			{
		carriage_return:
				viewer.OUTCHR(parser.I_SP);
				parser.LINBUF[parser.LINPTR] = Parser.AnonymousEnum3.INull;
				parser.LINBUF[parser.LINPTR + 1] = Parser.AnonymousEnum3.INull;
				parser.LINPTR = 0;

				if (!PreTranslateCommand(parser.LINBUF[0]))
				{
					game.AUTFLG = true;
					game.demoRestart = true;
					return false;
				}

				// dispatch to proper routine
				res = parser.PARSER(parser.CMDTAB[0], A, B, true);
				if (res == 1)
				{
					// dispatch
					switch (A)
					{
					case Parser.AnonymousEnum3.CmdAttack:
						Pattk();
						break;
					case Parser.AnonymousEnum3.CmdClimb:
						Pclimb();
						break;
					case Parser.AnonymousEnum3.CmdDrop:
						Pdrop();
						break;
					case Parser.AnonymousEnum3.CmdExamine:
						Pexam();
						break;
					case Parser.AnonymousEnum3.CmdGet:
						Pget();
						break;
					case Parser.AnonymousEnum3.CmdIncant:
						Pincan();
						break;
					case Parser.AnonymousEnum3.CmdLook:
						Plook();
						break;
					case Parser.AnonymousEnum3.CmdMove:
						Pmove();
						break;
					case Parser.AnonymousEnum3.CmdPull:
						Ppull();
						break;
					case Parser.AnonymousEnum3.CmdReveal:
						Prevea();
						break;
					case Parser.AnonymousEnum3.CmdStow:
						Pstow();
						break;
					case Parser.AnonymousEnum3.CmdTurn:
						Pturn();
						break;
					case Parser.AnonymousEnum3.CmdUse:
						Puse();
						break;
					case Parser.AnonymousEnum3.CmdZload:
						Pzload();
						break;
					case Parser.AnonymousEnum3.CmdZsave:
						Pzsave();
						break;
					}
				}
				if (res == -1)
					parser.CMDERR();

				if ((HEARTF != 0)
					&& (FAINT == 0))
					viewer.PROMPT();

				parser.LINPTR = 0;
				return true;
			}
			if (c == parser.I_BS)
			{
				if (parser.LINPTR == 0)
					return true;
				--parser.LINPTR;
				viewer.OUTSTR(parser.M_ERAS);
				return true;
			}
			// Buffer normal characters
			viewer.OUTCHR(c);
			parser.LINBUF[parser.LINPTR] = c;
			++parser.LINPTR;
			viewer.OUTSTR(parser.M_CURS);
			if (parser.LINPTR >= 32)
				goto carriage_return;
			return true;
		}

		// This method gets called from the scheduler with a
		// frequency equal to the current heart rate.  It performs
		// damage recovery, indicated by slowing the heartbeat.
		public int Hslow()
		{
			PLRBLK.P_ATDAM -= (PLRBLK.P_ATDAM >> 6);
			if ((PLRBLK.P_ATDAM & 0x8000) != 0)
				PLRBLK.P_ATDAM = 0;
			Hupdat();

			// Update Task's next_time
			scheduler.TCBLND[(int)Scheduler.AnonymousEnum2.TidHrtslow].next_time = scheduler.curTime + (HEARTR * 17);

			return 0;
		}

		// This method is called every five seconds.  It will
		// manage the lit torch's timers.
		//
		// The full burn time is stored in XX0 in 5-second units,
		// so 15 minutes equals 180 5-second units.
		//
		// The magical light values and physical light values are
		// stored in minutes.  Hence the conversion half way thorugh.
		//
		// This is a hack to give the main timer more granularity,
		// so that it doesn't lose a whole minute on each level change,
		// but I had to leave the other values as minutes because they
		// are used elsewhere in a complicated formula to determine
		// the ligthing (line pixelation/fade) values for the 3D viewer.
		//
		public int Burner()
		{
			// Update Task's next_time
			scheduler.TCBLND[(int)Scheduler.AnonymousEnum2.TidTorchburn].next_time = scheduler.curTime + scheduler.TCBLND[(int)Scheduler.AnonymousEnum2.TidTorchburn].frequency;

			ushort A;
			if (PTORCH == -1)
			{
				--viewer.NEWLUK;
				return 0;
			}
			A = @object.OCBLND[PTORCH].P_OCXX0;
			if (A == 0)
			{
				--viewer.NEWLUK;
				return 0;
			}
			--A;
			@object.OCBLND[PTORCH].P_OCXX0 = A;

			// Convert A to minutes
			(A % 12 == 0) ? A /= 12 : A = (A / 12) + 1;

			if (((g_cheats & (int)AnonymousEnum9.CheatTorch) == 0)
			{
				if (A <= 5)
				{
					@object.OCBLND[PTORCH].obj_id = CppObject.OBJ_TORCH_DEAD;
					@object.OCBLND[PTORCH].obj_reveal_lvl = 0;
				}
				if (A < @object.OCBLND[PTORCH].P_OCXX1)
					@object.OCBLND[PTORCH].P_OCXX1 = A;
				if (A < @object.OCBLND[PTORCH].P_OCXX2)
					@object.OCBLND[PTORCH].P_OCXX2 = A;
			}

			--viewer.NEWLUK;
			return 0;
		}

		// Calculates heartbeat based on power level and damage.
		// Also processes fainting and death.
		public void Hupdat()
		{
			uint ticks1;
			SDL_Event event = new SDL_Event();

			// Heartrate in source:
			//
			//               PPOW * 64
			// HEARTR = ------------------- - 19
			//           PPOW + (PDAM * 2)
			//
			// The original division routine added one to the integer quotient
			// so that [(1/5) == 1], [(5/5) == 2], [(10/5) == 3], etc.
			// The formula below reflects that peculiarity by only subtracting 18.
			//
			HEARTR = (((PLRBLK.P_ATPOW) * 64) / ((PLRBLK.P_ATPOW) + ((PLRBLK.P_ATDAM) * 2))) - 18;

			if (FAINT == 0)
			{
				// not in a faint
				if (HEARTR <= 3
					|| (HEARTR & 128) != 0)
				{
					// do faint
					FAINT = -1;
					viewer.clearArea(viewer.TXTPRI);
					viewer.OLIGHT = viewer.RLIGHT;
					do
					{
						--viewer.MLIGHT;
						--viewer.UPDATE;
						viewer.draw_game();
						--viewer.RLIGHT;
						ticks1 = SDL_GetTicks();
						scheduler.curTime = ticks1;
						do
						{
							if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
							{
								scheduler.CLOCK();
								scheduler.EscCheck();
							}
							scheduler.curTime = SDL_GetTicks();
						} while (scheduler.curTime < ticks1 + 750);
					} while (viewer.RLIGHT != 248); // not equal to -8
					--viewer.UPDATE;
					parser.KBDHDR = 0;
					parser.KBDTAL = 0;
				}
			} else
			{
				// in a faint
				if (HEARTR >= 4
					&& (HEARTR & 128) == 0)
				{
					// do recover from faint
					do
					{
						--viewer.UPDATE;
						viewer.draw_game();
						++viewer.MLIGHT;
						++viewer.RLIGHT;
						ticks1 = SDL_GetTicks();
						scheduler.curTime = ticks1;
						do
						{
							if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
							{
								scheduler.CLOCK();
								scheduler.EscCheck();
							}
							scheduler.curTime = SDL_GetTicks();
						} while (scheduler.curTime < ticks1 + 750);
					} while (viewer.RLIGHT != viewer.OLIGHT);
					FAINT = 0;
					viewer.PROMPT();
					--viewer.UPDATE;
				}
			}
			if (PLRBLK.P_ATPOW < PLRBLK.P_ATDAM)
			{
				// Do death
				while (SDL_PollEvent(event))
					; // clear event buffer
				viewer.clearArea(viewer.TXTSTS);
				viewer.clearArea(viewer.TXTPRI);
				viewer.ShowFade(Viewer.AnonymousEnum.FadeDeath);
				//scheduler.deathFadeLoop();
			}
		}

		// Used during initialization to set data for either
		// the built-in demo or starting a live game
		public void SetInitialObjects(bool isDemo)
		{
			int x;
			int y;

			if (isDemo)
			{
				game.IsDemo = true;
				game.LEVEL = 2;
				dungeon.SetLEVTABOrig(); //Make sure the original seeds aren't overwritten from pervious new game.
				// demo: iron sword, pine torch, leather shield

				x = @object.OBIRTH(CppObject.OBJ_SWORD_IRON, 0);
				++@object.OCBLND[x].P_OCOWN;
				@object.OCBFIL(CppObject.OBJ_SWORD_IRON, x);
				@object.OCBLND[x].obj_reveal_lvl = 0;
				BAGPTR = x;
				y = x;

				x = @object.OBIRTH(CppObject.OBJ_TORCH_PINE, 0);
				++@object.OCBLND[x].P_OCOWN;
				@object.OCBFIL(CppObject.OBJ_TORCH_PINE, x);
				@object.OCBLND[x].obj_reveal_lvl = 0;
				@object.OCBLND[y].P_OCPTR = x;
				y = x;

				x = @object.OBIRTH(CppObject.OBJ_SHIELD_LEATHER, 0);
				++@object.OCBLND[x].P_OCOWN;
				@object.OCBFIL(CppObject.OBJ_SHIELD_LEATHER, x);
				@object.OCBLND[x].obj_reveal_lvl = 0;
				@object.OCBLND[y].P_OCPTR = x;
			} else
			{
				game.IsDemo = false;
				game.LEVEL = 0;
				if (!game.RandomMaze) //Do we have an original maze?  Yes:
					dungeon.SetLEVTABOrig(); //Make sure the original seeds aren't overwritten from pervious new game.
				else //Do we have an original maze?  No:
					dungeon.SetLEVTABRandomMap(); //Sets random seeds for maze.
				PROW = 0x10;
				PCOL = 0x0B;
				PLRBLK.P_ATPOW = 160;

				if ((g_cheats & (int)AnonymousEnum9.CheatItems) != 0)
				{
					x = @object.OBIRTH(CppObject.OBJ_SWORD_IRON, 0);
					++@object.OCBLND[x].P_OCOWN;
					@object.OCBFIL(CppObject.OBJ_SWORD_IRON, x);
					@object.OCBLND[x].obj_reveal_lvl = 0;
					BAGPTR = x;
					y = x;

					x = @object.OBIRTH(CppObject.OBJ_SHIELD_MITHRIL, 0);
					++@object.OCBLND[x].P_OCOWN;
					@object.OCBFIL(CppObject.OBJ_SHIELD_MITHRIL, x);
					@object.OCBLND[x].obj_reveal_lvl = 0;
					@object.OCBLND[y].P_OCPTR = x;
					y = x;

					x = @object.OBIRTH(CppObject.OBJ_SCROLL_SEER, 0);
					++@object.OCBLND[x].P_OCOWN;
					@object.OCBFIL(CppObject.OBJ_SCROLL_VISION, x);
					@object.OCBLND[x].obj_reveal_lvl = 0;
					@object.OCBLND[y].P_OCPTR = x;
					y = x;

					x = @object.OBIRTH(CppObject.OBJ_TORCH_LUNAR, 0);
					++@object.OCBLND[x].P_OCOWN;
					@object.OCBFIL(CppObject.OBJ_TORCH_LUNAR, x);
					@object.OCBLND[x].obj_reveal_lvl = 0;
					@object.OCBLND[y].P_OCPTR = x;
				} else
				{
					x = @object.OBIRTH(CppObject.OBJ_TORCH_PINE, 0);
					++@object.OCBLND[x].P_OCOWN;
					@object.OCBFIL(CppObject.OBJ_TORCH_PINE, x);
					@object.OCBLND[x].obj_reveal_lvl = 0;
					BAGPTR = x;
					y = x;

					x = @object.OBIRTH(CppObject.OBJ_SWORD_WOOD, 0);
					++@object.OCBLND[x].P_OCOWN;
					@object.OCBFIL(CppObject.OBJ_SWORD_WOOD, x);
					@object.OCBLND[x].obj_reveal_lvl = 0;
					@object.OCBLND[y].P_OCPTR = x;
				}
			}
		}

		// Processes ATTACK command
		public void Pattk()
		{
			int res;
			int idx;
			int cidx;
			int optr;
			int val;
			Ocb U;
			Ocb Y;
			byte r;
			byte c;
			SDL_Event event = new SDL_Event();
			uint ticks1;
			uint ticks2;

			res = parser.PARHND();
			if (res == -1)
				return;

			if (res == 0)
			{
				idx = PLHAND;
				if (idx == -1)
					U = EMPHND;
				else
					U = @object.OCBLND[idx];
			} else
			{
				idx = PRHAND;
				if (idx == -1)
					U = EMPHND;
				else
					U = @object.OCBLND[idx];
			}

			Y = U;
			PMGO = U.P_OCMGO;
			PPHO = U.P_OCPHO;
			PDAM += ((PPOW * (((int) PMGO + (int) PPHO) / 8)) >> 7);

			// make sound for appropriate object
			Mix_PlayChannel(@object.objChannel, @object.objSound[U.obj_type], 0);
			while (Mix_Playing(@object.objChannel) == 1)
			{
				if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
				{
					scheduler.CLOCK();
					if (game.AUTFLG
						&& game.demoRestart == false)
						return;
				}
				scheduler.curTime = SDL_GetTicks();
			}

			if (U.obj_id >= CppObject.OBJ_RING_ENERGY
				&& U.obj_id <= CppObject.OBJ_RING_FIRE)
			{
				if (((g_cheats & (int)AnonymousEnum9.CheatRing) == 0)
				{
					--U.P_OCXX0;
					if (U.P_OCXX0 == 0)
					{
						U.obj_id = CppObject.OBJ_RING_GOLD;
						@object.OCBFIL(CppObject.OBJ_RING_GOLD, idx);
						U.obj_reveal_lvl = 0;
						viewer.STATUS();
					}
				}
			}

			cidx = creature.CFIND2(new RowCol(PROW, PCOL));
			if (cidx == -1)
			{
				Hupdat();
				return;
			}

			if (!Attack(PLRBLK.P_ATPOW, creature.CCBLND[cidx].P_CCPOW, creature.CCBLND[cidx].P_CCDAM))
			{
				Hupdat();
				return;
			}

			if (PTORCH == -1
				|| @object.OCBLND[PTORCH].obj_id == CppObject.OBJ_TORCH_DEAD)
			{
				if ((rng.RANDOM() & 3) != 0)
				{
					Hupdat();
					return;
				}
			}

			// make KLINK sound
			Mix_PlayChannel(@object.objChannel, klink, 0);
			while (Mix_Playing(@object.objChannel) == 1)
			{
				if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
				{
					scheduler.CLOCK();
					if (game.AUTFLG
						&& game.demoRestart == false)
						return;
				}
				scheduler.curTime = SDL_GetTicks();
			}

			viewer.OUTSTI(viewer.exps);

			// do damage
			if (Damage(PLRBLK.P_ATPOW, PLRBLK.P_ATMGO, PLRBLK.P_ATPHO, creature.CCBLND[cidx].P_CCPOW, creature.CCBLND[cidx].P_CCMGD, creature.CCBLND[cidx].P_CCPHD, creature.CCBLND[cidx].P_CCDAM) == true)
			{
				// Creature still alive
				Hupdat();
				return;
			}

			optr = creature.CCBLND[cidx].P_CCOBJ;
			while (optr != -1)
			{
				@object.OCBLND[optr].P_OCOWN = 0;
				@object.OCBLND[optr].P_OCROW = creature.CCBLND[cidx].P_CCROW;
				@object.OCBLND[optr].P_OCCOL = creature.CCBLND[cidx].P_CCCOL;
				optr = @object.OCBLND[optr].P_OCPTR;
			}

			--creature.CMXLND[creature.CMXPTR + creature.CCBLND[cidx].creature_id];
			creature.CCBLND[cidx].P_CCUSE = 0;
			viewer.PUPDAT();

			// do loud explosion sound
			Mix_PlayChannel(@object.objChannel, bang, 0);
			while (Mix_Playing(@object.objChannel) == 1)
			{
				if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
				{
					scheduler.CLOCK();
					if (game.AUTFLG
						&& game.demoRestart == false)
						return;
				}
				scheduler.curTime = SDL_GetTicks();
			}

			PPOW += (creature.CCBLND[cidx].P_CCPOW >> 3);
			if ((PPOW & 0x8000) != 0)
				PPOW = 0x7FFF;

			if (creature.CCBLND[cidx].creature_id == Creature.AnonymousEnum6.CrtWizimg)
			{
				// Wizard's Image Killed
				// transport to 4th level

				// do fade in with message

				// Pause so player can see scroll
				ticks1 = SDL_GetTicks();
				do
					ticks2 = SDL_GetTicks();
				while (ticks2 < ticks1 + wizDelay);

				while (SDL_PollEvent(event))
					; // clear event buffer
				viewer.clearArea(viewer.TXTSTS);
				viewer.clearArea(viewer.TXTPRI);
				viewer.done = false;
				viewer.fadeVal = -2;
				viewer.VCTFAD = 32;
				viewer.VXSCAL = 0x80;
				viewer.VYSCAL = 0x80;
				viewer.VXSCALf = 128.0f;
				viewer.VYSCALf = 128.0f;
		/*
				// Start buzz
				Mix_Volume(viewer.fadChannel, 0);
				Mix_PlayChannel(viewer.fadChannel, creature.buzz, -1);
		
				while (!viewer.done)
				{
					viewer.enough_fade();
					scheduler.EscCheck();
				}
		
				// Stop buzz
				Mix_HaltChannel(viewer.fadChannel);
		*/
				viewer.ShowFade(Viewer.AnonymousEnum.FadeMiddle);

				BAGPTR = PTORCH;
				if (PTORCH != -1)
					@object.OCBLND[PTORCH].P_OCPTR = -1;

				POBJWT = 200;
				game.LEVEL = 3;
				creature.NEWLVL();

				do
				{
					c = (rng.RANDOM() & 31);
					r = (rng.RANDOM() & 31);
					val = dungeon.MAZLND[dungeon.RC2IDX(r, c)];
				} while (val == 0xFF);

				PROW = r;
				PCOL = c;

				game.INIVU();
			}

			if (creature.CCBLND[cidx].creature_id != Creature.AnonymousEnum6.CrtWizard)
			{
				Hupdat();
				if (game.CreaturesInstaRegen)
					creature.CREGEN(); //Regen creature intantly after death if option selected.
				return;
			}

			// Killed the real Wizard
			--creature.FRZFLG;
			PRLITE = 0x07;
			PMLITE = 0x13;
			@object.OCBPTR = 1;
			BAGPTR = -1;
			PTORCH = -1;
			PRHAND = -1;
			PLHAND = -1;
			game.INIVU();
			Hupdat();
			return;
		}

		// Processes CLIMB command
		public void Pclimb()
		{
			uint ticks1;

			byte vres;
			int res;
			byte A;
			byte B;
			RowCol rc = new RowCol();
			ushort temp;

			rc.SetRC(PROW, PCOL);
			vres = dungeon.VFIND(rc);
			if (vres == (int)Dungeon.AnonymousEnum5.VfNull)
			{
				parser.CMDERR();
				return;
			}
			res = parser.PARSER(parser.DIRTAB, A, B, true);
			if (res <= 0)
			{
				parser.CMDERR();
				return;
			} else
			{
				if (A == (int)Parser.AnonymousEnum3.DirUp)
				{
					// Climb Up
					if (vres == (int)Dungeon.AnonymousEnum5.VfLadderUp // can only clumb up pits after you win
						|| ((vres == (int)Dungeon.AnonymousEnum5.VfHoleUp) && creature.FRZFLG))
				{
						viewer.displayPrepare();
						temp = viewer.display_mode;
						viewer.display_mode = Viewer.AnonymousEnum.ModeTitle;
						viewer.draw_game();
						ticks1 = SDL_GetTicks();
						scheduler.curTime = ticks1;
						do
						{
							if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
								scheduler.CLOCK();
							scheduler.curTime = SDL_GetTicks();
						} while (scheduler.curTime < ticks1 + viewer.prepPause);
						viewer.display_mode = temp;
						--game.LEVEL;
						creature.NEWLVL();
						game.INIVU();
					} else
					{
						parser.CMDERR();
						return;
					}
				} else if (A == (int)Parser.AnonymousEnum3.DirDown)
				{
					// Climb Down
					if (vres == (int)Dungeon.AnonymousEnum5.VfLadderDown
						|| vres == (int)Dungeon.AnonymousEnum5.VfHoleDown)
					{
						viewer.displayPrepare();
						temp = viewer.display_mode;
						viewer.display_mode = Viewer.AnonymousEnum.ModeTitle;
						viewer.draw_game();
						ticks1 = SDL_GetTicks();
						scheduler.curTime = ticks1;
						do
						{
							if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
								scheduler.CLOCK();
							scheduler.curTime = SDL_GetTicks();
						} while (scheduler.curTime < ticks1 + viewer.prepPause);
						viewer.display_mode = temp;
						++game.LEVEL;
						creature.NEWLVL();
						game.INIVU();
					} else
					{
						parser.CMDERR();
						return;
					}
				} else
				{
					parser.CMDERR();
					return;
				}
			}
		}

		// Processes DROP command
		public void Pdrop()
		{
			int res;
			int idx;
			res = parser.PARHND();
			if (res == -1)
				return;
			if (res == 0
				&& PLHAND == -1)
			{
				parser.CMDERR();
				return;
			}
			if (res == 1
				&& PRHAND == -1)
			{
				parser.CMDERR();
				return;
			}

			if (res == 0)
			{
				idx = PLHAND;
				PLHAND = -1;
			} else
			{
				idx = PRHAND;
				PRHAND = -1;
			}

			@object.OCBLND[idx].P_OCOWN = 0;
			@object.OCBLND[idx].P_OCROW = PROW;
			@object.OCBLND[idx].P_OCCOL = PCOL;
			@object.OCBLND[idx].P_OCLVL = game.LEVEL;

			POBJWT -= @object.OBJWGT[@object.OCBLND[idx].obj_type];
			Hupdat();

			viewer.STATUS();
			viewer.PUPDAT();
		}

		// Processes EXAMINE command
		public void Pexam()
		{
			viewer.display_mode = Viewer.AnonymousEnum.ModeExamine;
			viewer.PUPDAT();
		}

		// Processes GET command
		public void Pget()
		{
			int res;
			int idx;
			res = parser.PARHND();
			if (res == -1)
				return;
			if (res == 0
				&& PLHAND != -1)
			{
				parser.CMDERR();
				return;
			}
			if (res == 1
				&& PRHAND != -1)
			{
				parser.CMDERR();
				return;
			}
			if (!@object.PAROBJ())
				return;

			bool match = false;
			@object.OFINDF = 0;
			do
			{
				idx = @object.OFIND(new RowCol(PROW, PCOL));
				if (idx == -1)
				{
					parser.CMDERR();
					return;
				}
				if (@object.SPEFLG == 0)
				{
					if (@object.OBJCLS == @object.OCBLND[idx].obj_type)
						match = true;
				} else
				{
					if (@object.OBJTYP == @object.OCBLND[idx].obj_id)
						match = true;
				}
			} while (match == false);

			if (res == 0)
				PLHAND = idx;
			else
				PRHAND = idx;
			++@object.OCBLND[idx].P_OCOWN;

			POBJWT += @object.OBJWGT[@object.OCBLND[idx].obj_type];
			Hupdat();

			viewer.STATUS();
			viewer.PUPDAT();
		}

		// Processes INCANT command
		public void Pincan()
		{
			int res;
			byte A;
			byte B;
			RowCol rc = new RowCol();
			SDL_Event event = new SDL_Event();
			uint ticks1;
			uint ticks2;

			res = parser.PARSER(@object.ADJTAB, A, B, true);
			if (res <= 0)
				return;

			if (parser.FULFLG == 0)
				return;

			@object.OBJTYP = A;
			@object.OBJCLS = B;

			if (PLHAND != -1)
			{
				if (@object.OCBLND[PLHAND].obj_type == CppObject.OBJT_RING)
				{
					if (@object.OCBLND[PLHAND].P_OCXX1 == @object.OBJTYP)
					{
						@object.OCBLND[PLHAND].obj_id = @object.OBJTYP;
						@object.OCBFIL(@object.OBJTYP, PLHAND);

						// make ring sound
						Mix_PlayChannel(@object.objChannel, @object.objSound[@object.OCBLND[PLHAND].obj_type], 0);
						while (Mix_Playing(@object.objChannel) == 1)
						{
							if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
								scheduler.CLOCK();
							scheduler.curTime = SDL_GetTicks();
						}

						viewer.STATUS();
						viewer.PUPDAT();
						@object.OCBLND[PLHAND].P_OCXX1 = -1;
						if (@object.OBJTYP == 0x12)
						{
							// winner
							while (SDL_PollEvent(event))
								; // clear event buffer

							// Pause so player can see status line
							ticks1 = SDL_GetTicks();
							do
								ticks2 = SDL_GetTicks();
							while (ticks2 < ticks1 + wizDelay);

							viewer.clearArea(viewer.TXTSTS);
							viewer.clearArea(viewer.TXTPRI);
							viewer.ShowFade(Viewer.AnonymousEnum.FadeVictory);
							game.hasWon = true;
						} else
						{
							return;
						}
					}
				}
			}

			if (PRHAND != -1)
			{
				if (@object.OCBLND[PRHAND].obj_type == CppObject.OBJT_RING)
				{
					if (@object.OCBLND[PRHAND].P_OCXX1 == @object.OBJTYP)
					{
						@object.OCBLND[PRHAND].obj_id = @object.OBJTYP;
						@object.OCBFIL(@object.OBJTYP, PRHAND);

						// make ring sound
						Mix_PlayChannel(@object.objChannel, @object.objSound[@object.OCBLND[PRHAND].obj_type], 0);
						while (Mix_Playing(@object.objChannel) == 1)
						{
							if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
								scheduler.CLOCK();
							scheduler.curTime = SDL_GetTicks();
						}

						viewer.STATUS();
						viewer.PUPDAT();
						@object.OCBLND[PRHAND].P_OCXX1 = -1;
						if (@object.OBJTYP == 0x12)
						{
							// Do winner
							while (SDL_PollEvent(event))
								; // clear event buffer

							// Pause so player can see status line
							ticks1 = SDL_GetTicks();
							do
								ticks2 = SDL_GetTicks();
							while (ticks2 < ticks1 + wizDelay);

							viewer.clearArea(viewer.TXTSTS);
							viewer.clearArea(viewer.TXTPRI);
							viewer.ShowFade(Viewer.AnonymousEnum.FadeVictory);
							game.hasWon = true;
						} else
						{
							return;
						}
					}
				}
			}
		}

		// Processes LOOK command
		public void Plook()
		{
			viewer.display_mode = Viewer.AnonymousEnum.Mode_3d;
			viewer.PUPDAT();
		}

		// Processes MOVE command
		public void Pmove()
		{
			int res;
			byte A;
			byte B;
			uint ticks1;

			res = parser.PARSER(parser.DIRTAB, A, B, true);
			if (res < 0)
			{
				parser.CMDERR();
				return;
			} else if (res == 0)
			{
				// Move Forward
				--viewer.HLFSTP;
				viewer.PUPDAT();
				ticks1 = SDL_GetTicks();
				scheduler.curTime = ticks1;
				do
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
					{
						scheduler.CLOCK();
						if (game.AUTFLG
							&& game.demoRestart == false)
							return;
					}
					scheduler.curTime = SDL_GetTicks();
				} while (scheduler.curTime < ticks1 + (moveDelay / 2));
				viewer.HLFSTP = 0;
				Pstep(0);
				PDAM += (POBJWT >> 3) + 3;
				Hupdat();
				--viewer.UPDATE;
				viewer.draw_game();
				ticks1 = SDL_GetTicks();
				scheduler.curTime = ticks1;
				do
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
					{
						scheduler.CLOCK();
						if (game.AUTFLG
							&& game.demoRestart == false)
							return;
					}
					scheduler.curTime = SDL_GetTicks();
				} while (scheduler.curTime < ticks1 + (moveDelay / 2));
				return;
			} else if (A == (int)Parser.AnonymousEnum3.DirBack)
			{
				// Move Back
				--viewer.BAKSTP;
				viewer.PUPDAT();
				ticks1 = SDL_GetTicks();
				scheduler.curTime = ticks1;
				do
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
					{
						scheduler.CLOCK();
						if (game.AUTFLG
							&& game.demoRestart == false)
							return;

					}
					scheduler.curTime = SDL_GetTicks();
				} while (scheduler.curTime < ticks1 + (moveDelay / 2));
				viewer.BAKSTP = 0;
				Pstep(2);
				PDAM += (POBJWT / 8) + 3;
				Hupdat();
				--viewer.UPDATE;
				viewer.draw_game();
				ticks1 = SDL_GetTicks();
				scheduler.curTime = ticks1;
				do
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
					{
						scheduler.CLOCK();
						if (game.AUTFLG
							&& game.demoRestart == false)
							return;
					}
					scheduler.curTime = SDL_GetTicks();
				} while (scheduler.curTime < ticks1 + (moveDelay / 2));
				return;
			} else if (A == (int)Parser.AnonymousEnum3.DirRight)
			{
				// Move Right
				if (Pstep(1))
				{
					if (viewer.display_mode == Viewer.AnonymousEnum.Mode_3d)
						ShowTurn(Parser.AnonymousEnum3.DirRight);
				}
				PDAM += (POBJWT / 8) + 3;
				Hupdat();
				--viewer.UPDATE;
				viewer.draw_game();
				return;
			} else if (A == (int)Parser.AnonymousEnum3.DirLeft)
			{
				// Move Left
				if (Pstep(3))
				{
					if (viewer.display_mode == Viewer.AnonymousEnum.Mode_3d)
						ShowTurn(Parser.AnonymousEnum3.DirLeft);
				}
				PDAM += (POBJWT / 8) + 3;
				Hupdat();
				--viewer.UPDATE;
				viewer.draw_game();
				return;
			} else
			{
				parser.CMDERR();
				return;
			}
		}

		// Processes PULL command
		public void Ppull()
		{
			if (BAGPTR == -1)
			{
				parser.CMDERR();
				return;
			}

			int res;
			res = parser.PARHND();
			if (res == -1)
				return;
			if (res == 0
				&& PLHAND != -1)
			{
				parser.CMDERR();
				return;
			}
			if (res == 1
				&& PRHAND != -1)
			{
				parser.CMDERR();
				return;
			}
			if (!@object.PAROBJ())
				return;

			bool onHead = true;
			bool match = false;
			int curPtr;
			int prevPtr;

			do
			{
				if (onHead)
					curPtr = BAGPTR;
				else
				{
					prevPtr = curPtr;
					curPtr = @object.OCBLND[curPtr].P_OCPTR;
					if (curPtr == -1)
					{
						parser.CMDERR();
						return;
					}
				}

				if (@object.SPEFLG == 0)
				{
					if (@object.OCBLND[curPtr].obj_type == @object.OBJCLS)
						match = true;
				} else
				{
					if (@object.OCBLND[curPtr].obj_id == @object.OBJTYP)
						match = true;
				}
				if (match)
					break;
				if (onHead)
					onHead = false;
			} while (true);

			if (onHead)
				BAGPTR = @object.OCBLND[curPtr].P_OCPTR;
			else
				@object.OCBLND[prevPtr].P_OCPTR = @object.OCBLND[curPtr].P_OCPTR;

			if (res == 0)
				PLHAND = curPtr;
			else
				PRHAND = curPtr;

			if (curPtr == PTORCH)
				PTORCH = -1;

			viewer.STATUS();
			viewer.PUPDAT();
		}

		// Processes REVEAL command
		public void Prevea()
		{
			int res;
			int idx;
			int req;
			res = parser.PARHND();
			if (res == -1)
				return;
			if (res == 0
				&& PLHAND == -1)
				return;
			if (res == 1
				&& PRHAND == -1)
				return;
			if (res == 0)
				idx = PLHAND;
			else
				idx = PRHAND;
			req = @object.OCBLND[idx].obj_reveal_lvl;
			if (req != 0
				&& ((req * 25 <= PPOW) || (g_cheats & (int)AnonymousEnum9.CheatReveal) || (req == 50 && game.VisionScroll && 400 <= PPOW)))
			{
				@object.OCBFIL(@object.OCBLND[idx].obj_id, idx);
				@object.OCBLND[idx].obj_reveal_lvl = 0;
				viewer.STATUS();
			}
		}

		// Processes STOW command
		public void Pstow()
		{
			int res;
			res = parser.PARHND();
			if (res == -1)
				return;
			if (res == 0
				&& PLHAND == -1)
			{
				parser.CMDERR();
				return;
			}
			if (res == 1
				&& PRHAND == -1)
			{
				parser.CMDERR();
				return;
			}

			if (res == 0)
			{
				@object.OCBLND[PLHAND].P_OCPTR = BAGPTR;
				BAGPTR = PLHAND;
				PLHAND = -1;
			} else
			{
				@object.OCBLND[PRHAND].P_OCPTR = BAGPTR;
				BAGPTR = PRHAND;
				PRHAND = -1;
			}
			viewer.STATUS();
			viewer.PUPDAT();
		}

		// Processes TURN command
		public void Pturn()
		{
			int res;
			byte A;
			byte B;

			res = parser.PARSER(parser.DIRTAB, A, B, true);
			if (res != 1)
			{
				parser.CMDERR();
				return;
			}
			if (A == (int)Parser.AnonymousEnum3.DirLeft)
			{
				// Left Turn
				--PDIR;
				PDIR = (PDIR & 3);
				if (viewer.display_mode == Viewer.AnonymousEnum.Mode_3d)
					ShowTurn(Parser.AnonymousEnum3.DirLeft);
				--viewer.UPDATE;
				viewer.draw_game();
				return;
			} else if (A == (int)Parser.AnonymousEnum3.DirRight)
			{
				// Right Turn
				++PDIR;
				PDIR = (PDIR & 3);
				if (viewer.display_mode == Viewer.AnonymousEnum.Mode_3d)
					ShowTurn(Parser.AnonymousEnum3.DirRight);
				--viewer.UPDATE;
				viewer.draw_game();
				return;
			} else if (A == (int)Parser.AnonymousEnum3.DirAround)
			{
				// About Face
				PDIR += 2;
				PDIR = (PDIR & 3);
				if (viewer.display_mode == Viewer.AnonymousEnum.Mode_3d)
					ShowTurn(Parser.AnonymousEnum3.DirAround);
				--viewer.UPDATE;
				viewer.draw_game();
				return;
			} else
			{
				parser.CMDERR();
				return;
			}
		}

		// Processes USE command
		public void Puse()
		{
			int res;
			int idx;
			res = parser.PARHND();
			if (res == -1)
				return;
			if (res == 0
				&& PLHAND == -1)
				return;
			if (res == 1
				&& PRHAND == -1)
				return;
			if (res == 0)
				idx = PLHAND;
			else
				idx = PRHAND;

			if (@object.OCBLND[idx].obj_type == CppObject.OBJT_TORCH)
			{
				PTORCH = idx;
				if (res == 0)
				{
					@object.OCBLND[PLHAND].P_OCPTR = BAGPTR;
					BAGPTR = PLHAND;
					PLHAND = -1;
				} else
				{
					@object.OCBLND[PRHAND].P_OCPTR = BAGPTR;
					BAGPTR = PRHAND;
					PRHAND = -1;
				}
				viewer.STATUS();
				viewer.PUPDAT();

				// make torch sound
				Mix_PlayChannel(@object.objChannel, @object.objSound[@object.OCBLND[idx].obj_type], 0);
				while (Mix_Playing(@object.objChannel) == 1)
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
						scheduler.CLOCK();
					scheduler.curTime = SDL_GetTicks();
				}

				viewer.PUPDAT();
				return;
			} else if (@object.OCBLND[idx].obj_id == CppObject.OBJ_FLASK_THEWS)
			{
				PPOW += 1000;
				@object.OCBLND[idx].obj_id = CppObject.OBJ_FLASK_EMPTY;
				@object.OCBLND[idx].obj_reveal_lvl = 0;

				// make flask sound
				Mix_PlayChannel(@object.objChannel, @object.objSound[@object.OCBLND[idx].obj_type], 0);
				while (Mix_Playing(@object.objChannel) == 1)
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
						scheduler.CLOCK();
					scheduler.curTime = SDL_GetTicks();
				}

				viewer.STATUS();
				Hupdat();
			} else if (@object.OCBLND[idx].obj_id == CppObject.OBJ_FLASK_HALE) // Hale Flask
			{
				PDAM = 0;
				@object.OCBLND[idx].obj_id = CppObject.OBJ_FLASK_EMPTY;
				@object.OCBLND[idx].obj_reveal_lvl = 0;

				// make flask sound
				Mix_PlayChannel(@object.objChannel, @object.objSound[@object.OCBLND[idx].obj_type], 0);
				while (Mix_Playing(@object.objChannel) == 1)
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
						scheduler.CLOCK();
					scheduler.curTime = SDL_GetTicks();
				}

				viewer.STATUS();
				Hupdat();
			} else if (@object.OCBLND[idx].obj_id == CppObject.OBJ_FLASK_ABYE) // Abye Flask
			{
				if (((g_cheats & (int)AnonymousEnum9.CheatInvulnerable) == 0)
					PDAM += (short)((double) PPOW * 0.8);

				@object.OCBLND[idx].obj_id = CppObject.OBJ_FLASK_EMPTY;
				@object.OCBLND[idx].obj_reveal_lvl = 0;

				// make flask sound
				Mix_PlayChannel(@object.objChannel, @object.objSound[@object.OCBLND[idx].obj_type], 0);
				while (Mix_Playing(@object.objChannel) == 1)
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
						scheduler.CLOCK();
					scheduler.curTime = SDL_GetTicks();
				}

				viewer.STATUS();
				Hupdat();
			} else if (@object.OCBLND[idx].obj_id == CppObject.OBJ_SCROLL_SEER)
			{
				viewer.showSeerMap = true;
				if (@object.OCBLND[idx].obj_reveal_lvl != 0)
					return;

				// make scroll sound
				Mix_PlayChannel(@object.objChannel, @object.objSound[@object.OCBLND[idx].obj_type], 0);
				while (Mix_Playing(@object.objChannel) == 1)
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
						scheduler.CLOCK();
					scheduler.curTime = SDL_GetTicks();
				}

				HEARTF = 0;
				viewer.display_mode = Viewer.AnonymousEnum.ModeMap;
				viewer.PUPDAT();
				return;
			} else if (@object.OCBLND[idx].obj_id == CppObject.OBJ_SCROLL_VISION)
			{
				viewer.showSeerMap = false;
				if (@object.OCBLND[idx].obj_reveal_lvl != 0)
					return;

				// make scroll sound
				Mix_PlayChannel(@object.objChannel, @object.objSound[@object.OCBLND[idx].obj_type], 0);
				while (Mix_Playing(@object.objChannel) == 1)
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
						scheduler.CLOCK();
					scheduler.curTime = SDL_GetTicks();
				}

				HEARTF = 0;
				viewer.display_mode = Viewer.AnonymousEnum.ModeMap;
				viewer.PUPDAT();
				return;
			}
		}

		// Processes ZLOAD command
		public void Pzload()
		{
			int tctr = 0;
			int preLen;
	//C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
			memset(parser.TOKEN, -1, 33);
	//C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
			memset(oslink.gamefile,0,oslink.gamefileLen);
			oslink.gamefile = oslink.savedDir;
			oslink.gamefile += oslink.pathSep;
			preLen = oslink.gamefile.Length;
			if (parser.GETTOK())
			{
				oslink.gamefile = oslink.savedDir;
				oslink.gamefile += oslink.pathSep;
				tctr = 0;
				while (parser.TOKEN[tctr] != 0xFF)
				{
					oslink.gamefile[tctr + preLen] = parser.TOKEN[tctr] + 'A' - 1;
					++tctr;
				}
				oslink.gamefile += ".dod";
			} else
			{
				oslink.gamefile += "game.dod";
			}

			if ((oslink.fptr = fopen(oslink.gamefile,"r")) == null)
			{
				parser.CMDERR();
				return;
			} else
			{
				fclose(oslink.fptr);
				--scheduler.ZFLAG;
				return;
			}
		}

		// Processes ZSAVE command
		public void Pzsave()
		{
			int tctr = 0;
			int preLen;
	//C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
			memset(parser.TOKEN, -1, 33);
	//C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
			memset(oslink.gamefile,0,oslink.gamefileLen);
			oslink.gamefile = oslink.savedDir;
			oslink.gamefile += oslink.pathSep;
			preLen = oslink.gamefile.Length;
			if (parser.GETTOK())
			{
				while (parser.TOKEN[tctr] != 0xFF)
				{
					oslink.gamefile[tctr + preLen] = parser.TOKEN[tctr] + 'A' - 1;
					++tctr;
				}
				oslink.gamefile += ".dod";
			} else
			{
				oslink.gamefile += "game.dod";
			}

			++scheduler.ZFLAG;
			return;
		}

		// Attempts to move player in given direction
		public bool Pstep(byte dir)
		{
			byte B;
			B = dir + PDIR;
			B &= 3;
			if (dungeon.STEPOK(PROW, PCOL, B))
			{
				PROW += dungeon.STPTAB[B * 2];
				PCOL += dungeon.STPTAB[(B * 2) + 1];
				return true;
			} else
			{
				// do thud sound
				Mix_PlayChannel(@object.objChannel, thud, 0);
				while (Mix_Playing(@object.objChannel) == 1)
				{
					if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
						scheduler.CLOCK();
					scheduler.curTime = SDL_GetTicks();
				}

				return false;
			}
		}

		// Determines if an attack strikes its target
		public bool Attack(int AP, int DP, int DD)
		{
			int pidx;
			int adjust;
			int ret;
			int T0 = 15;
			int Dval = (DP - DD) * 4;

			do
			{
				Dval -= AP;
				if (Dval < 0)
					break;
				--T0;
			} while (T0 > 0);

			pidx = T0 - 3;
			if (pidx > 0)
				adjust = pidx * 10;
			else
				adjust = pidx * 25;

			ret = rng.RANDOM() + adjust - 127;

			if (ret < 0)
				return false;
			else
				return true;
		}

		// Calculates and assesses damage from a successful attack
	//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'DD', so pointers on this parameter are left unchanged:
		public bool Damage(int AP, int AMO, int APO, int DP, int DMD, int DPD, ushort * DD)
		{
			int a;

			a = ((AP * AMO) >> 7);
			a = ((a * DMD) >> 7);
			*DD += (ushort) a;

			a = ((AP * APO) >> 7);
			a = ((a * DPD) >> 7);
			*DD += (ushort) a;

			if ((ushort) DP > *DD)
				return true;
			else
				return false;
		}
		public void Reset()
		{
			PROW = 12;
			PCOL = 22;
			PPOW = ((0x17 << 8) | 160);
			POBJWT = 35;
			FAINT = 0;
			PRLITE = 0;
			PMLITE = 0;
			PLHAND = -1;
			PRHAND = -1;
			PTORCH = -1;
			BAGPTR = -1;
			EMPHND.obj_type = CppObject.OBJT_WEAPON;
			EMPHND.obj_reveal_lvl = 0;
			EMPHND.P_OCMGO = 0;
			EMPHND.P_OCPHO = 5;
			PDAM = 0;
			PDIR = 0;
			HEARTF = 0;
			HEARTC = 0;
			HEARTR = 0;
			HEARTS = 0;
			HBEATF = 0;
			turning = false;
		}

		// Public Interface

		public void LoadSounds()
		{
			klink = Utils.LoadSound("12_klink.wav");
			thud = Utils.LoadSound("14_thud.wav");
			bang = Utils.LoadSound("15_bang.wav");
		}

		// Turning Animation
		public void ShowTurn(byte A)
		{
			int ctr;
			int times;
			int x;
			int offset;
			int dir;
			int inc = 32;
			int lines = 8;
			int y0 = 17;
			int y1 = 135;
			uint ticks1;
			bool redraw = true;

			switch (A)
			{
			case Parser.AnonymousEnum3.DirLeft:
				offset = 8;
				dir = 1;
				times = 1;
				break;
			case Parser.AnonymousEnum3.DirRight:
				offset = 248;
				dir = -1;
				times = 1;
				break;
			case Parser.AnonymousEnum3.DirAround:
				offset = 248;
				dir = -1;
				times = 2;
				break;
			default:
				break;
			}

			viewer.VXSCAL = 0x80;
			viewer.VYSCAL = 0x80;
			viewer.VXSCALf = 128.0f;
			viewer.VYSCALf = 128.0f;
			viewer.RANGE = 0;
			viewer.SETFAD();
			glColor3fv(viewer.fgColor);
			turning = true;
			for (ctr = 0; ctr < times; ++ctr)
			{
				for (x = 0; x < lines; ++x)
				{
					ticks1 = SDL_GetTicks();
					do
					{
						scheduler.curTime = SDL_GetTicks();
						if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
						{
							scheduler.CLOCK();
							if (game.AUTFLG
								&& game.demoRestart == false)
							{
								turning = false;
								return;
							}
							redraw = true;
						}

						if (redraw)
						{
							glClear(GL_COLOR_BUFFER_BIT);
							glLoadIdentity();
							viewer.drawVectorList(viewer.LINES);

							viewer.drawVector((x * inc * dir) + offset,y0,(x * inc * dir) + offset,y1);
							viewer.drawArea(viewer.TXTSTS);
							viewer.drawArea(viewer.TXTPRI);

							//SDL 2.0 Replaced
							//SDL_GL_SwapBuffers();
							oslink.SwapBuffers();
							redraw = false;
						}
					} while (scheduler.curTime < ticks1 + turnDelay);
				}
			}
			turning = false;
			--HEARTF;
		}

		// Public Data Members
		public byte PROW;
		public byte PCOL;
		public ushort POBJWT;
		public Atb PLRBLK = new Atb();
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to references to value types:
	//ORIGINAL LINE: ushort& PPOW;
		public ushort PPOW;
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to references to value types:
	//ORIGINAL LINE: byte& PMGO;
		public byte PMGO;
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to references to value types:
	//ORIGINAL LINE: byte& PMGD;
		public byte PMGD;
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to references to value types:
	//ORIGINAL LINE: byte& PPHO;
		public byte PPHO;
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to references to value types:
	//ORIGINAL LINE: byte& PPHD;
		public byte PPHD;
		public int PLHAND;
		public int PRHAND;
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to references to value types:
	//ORIGINAL LINE: ushort& PDAM;
		public ushort PDAM;
		public byte PDIR;
		public int PTORCH;
		public byte PRLITE;
		public byte PMLITE;
		public byte FAINT;
		public int BAGPTR;
		public byte HEARTF;
		public byte HEARTC;
		public byte HEARTR;
		public byte HEARTS;
		public byte HBEATF;
		public Ocb EMPHND = new Ocb();

		public int turnDelay;
		public int moveDelay;
		public int wizDelay;
		public bool turning;

		public Mix_Chunk klink;
		public Mix_Chunk thud;
		public Mix_Chunk bang;

	}
}
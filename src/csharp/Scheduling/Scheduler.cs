/*
 * Copyright © Michael Taylor (P3Net)
 * All Rights Reserved
 * For changes from C++ to C# and .NET.
 *
 * http://www.michaeltaylorp3.net
 *//****************************************
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
using DoD.Sound;
using SDL2;

namespace DoD.Scheduling
{
    /// <summary>This class manages the scheduler.</summary>
	public partial class Scheduler
	{
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Scheduler"/> class.</summary>
        public Scheduler ()
		{
			Reset();
		}
        #endregion

        /// <summary>Creates initial Task Blocks.</summary>
        public void Systcb()
		{
            throw new NotImplementedException();
			//int ctr;
			//int TCBindex;

			//for (ctr = 0; ctr < 38; ++ctr)
			//	TCBLND[ctr].Clear();

			//TCBPTR = 0;

			//TCBLND[0].type = (int)AnonymousEnum.TidClock;
			//TCBLND[0].frequency = 17; // One JIFFY
			//TCBindex = Gettcb();

			//TCBLND[1].type = (int)AnonymousEnum.TidPlayer;
			//TCBLND[1].frequency = 17; // One JIFFY
			//TCBindex = Gettcb();

			//TCBLND[2].type = (int)AnonymousEnum.TidRefreshDisp;
			//TCBLND[2].frequency = 300; // Three TENTHs
			//TCBindex = Gettcb();

			//TCBLND[3].type = (int)AnonymousEnum.TidHrtslow;
			//TCBindex = Gettcb();

			//TCBLND[4].type = (int)AnonymousEnum.TidTorchburn;
			//TCBLND[4].frequency = 5000; // Five Seconds
			//TCBindex = Gettcb();

			//TCBLND[5].type = (int)AnonymousEnum.TidCrtregen;
			//TCBLND[5].frequency = 300000; // Five minutes
			//TCBindex = Gettcb();
		}

        //TODO: Need to rename because it has same name as type.
        /// <summary>This is the Main Loop of the game.</summary>
        /// <remarks>
        /// Originally it was a port of the scheduling algorithm used in the source code, but it has been
        /// entirely replaced with a simpler algorithm that works better on modern platforms.
        /// <para />
        /// It uses milliseconds instead of JIFFYs.  And it does not have any queues, but a simple array of <see cref="Task"/> objects.
        /// </remarks>
        public void Sched()
		{
            throw new NotImplementedException();
   //         // Initialization
   //         int result = 0; // not currently being used
			//int ctr = 0;

			//// Main game execution loop
			//do
			//{
			//	curTime = SDL_GetTicks();

			//	if (curTime >= TCBLND[ctr].next_time)
			//	{
			//		switch (TCBLND[ctr].type)
			//		{
			//		case AnonymousEnum.TidClock:
			//			Clock();
			//			break;
			//		case AnonymousEnum.TidPlayer:
			//			result = player.PLAYER();
			//			break;
			//		case AnonymousEnum.TidRefreshDisp:
			//			result = viewer.LUKNEW();
			//			break;
			//		case AnonymousEnum.TidHrtslow:
			//			result = player.HSLOW();
			//			break;
			//		case AnonymousEnum.TidTorchburn:
			//			result = player.BURNER();
			//			break;
			//		case AnonymousEnum.TidCrtregen:
			//			result = creature.CREGEN();
			//			break;
			//		case AnonymousEnum.TidCrtmove:
			//			result = creature.CMOVE(ctr, TCBLND[ctr].data);
			//			break;
			//		default:
			//			// error
			//			break;
			//		}
			//	}

			//	(ctr < TCBPTR) ?++ctr : ctr = 0;

			//	if (ZFLAG != 0) // Saving or Loading
			//	{
			//		if (ZFLAG == 0xFF)
			//			return; // Load game abandons current game
			//		else
			//		{
			//			Save();
			//			ZFLAG = 0;
			//		}
			//	}

			//	if (player.PLRBLK.P_ATPOW < player.PLRBLK.P_ATDAM)
			//		return; // Death

			//	if (game.hasWon)
			//		return; // Victory

			//} while (result == 0);
		}

        /// <summary>This is the heart of the game, literally.</summary>
        /// <remarks>
        /// It manages the heartbeat, calls for the screen to be redrawn, and polls the OS for key strokes.
        /// <para />
        /// This routine is called every 17 milliseconds from the scheduler, and also from the blocking loops after each
        /// sound, which allows the heartbeat to mix in with the other sounds.
        /// </remarks>
        public void Clock()
		{
            throw new NotImplementedException();
 //           // Update Task's next_time
 //           TCBLND[0].next_time = curTime + TCBLND[0].frequency;

	//		// Update elaplsed time
	//		elapsedTime = curTime - TCBLND[0].prev_time;

	//		// Reality check
	//		if (elapsedTime > 126 * 17)
	//			elapsedTime = 126 * 17;

	//		if (elapsedTime >= 17)
	//		{
	//			// Update Task's prev_time
	//			TCBLND[0].prev_time = curTime;
	//			if (player.HBEATF != 0)
	//			{
	//				player.HEARTC -= (elapsedTime / 17);
	//				if ((player.HEARTC & 0x80) != 0)
	//					player.HEARTC = 0;
	//				if (player.HEARTC == 0)
	//				{
	//					player.HEARTC = player.HEARTR;

	//					// make sound
	//					Mix_PlayChannel(hrtChannel, hrtSound[(byte)(player.HEARTS + 1)], 0);
	////C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
	//					while (Mix_Playing(hrtChannel) == 1) // !!!
	//						;

	//					if (player.HEARTF != 0)
	//					{
	//						if ((player.HEARTS & 0x80) != 0)
	//						{
	//							// small
	//							viewer.statArea[15] = '<';
	//							viewer.statArea[16] = '>';
	//							player.HEARTS = 0;
	//						} else
	//						{
	//							// large
	//							viewer.statArea[15] = '{';
	//							viewer.statArea[16] = '}';
	//							player.HEARTS = -1;
	//						}
	//						if (!player.turning)
	//						{
	//							--viewer.UPDATE;
	//							viewer.draw_game();
	//						}
	//					}
	//				}
	//			}
	//		}

	//		if (player.FAINT == 0)
	//		{
	//			if (game.AUTFLG)
	//			{
	//				// Abort demo on keypress
	//				if (KeyCheck())
	//				{
	//					game.hasWon = true;
	//					game.demoRestart = false;
	//				}
	//			} else
	//			{
	//				// Perform Keyboard Input
	//				oslink.process_events();
	//			}
	//		}
		}

        /// <summary>Gets next available Task Block and updates the index.</summary>
        public int Gettcb()
		{
            throw new NotImplementedException();
            //++TCBPTR;
			//return (TCBPTR - 1);
		}

        //TODO:  All the following methods should really be moved to the OS_Link class.

        /// <summary> Used by wizard fade in/out function.</summary>
        public bool FadeLoop()
		{
            throw new NotImplementedException();
   //         SDL_Event event = new SDL_Event();
			//viewer.displayCopyright();
			//viewer.displayWelcomeMessage();

			//// Start buzz
			//Mix_Volume(viewer.fadChannel, 0);
			//Mix_PlayChannel(viewer.fadChannel, creature.buzz, -1);

			//while (true)
			//{
			//	if (KeyCheck())
			//	{
			//		viewer.clearArea(viewer.TXTPRI);
			//		while (SDL_PollEvent(event))
			//			; // clear event buffer

			//		// Stop buzz
			//		Mix_HaltChannel(viewer.fadChannel);

			//		return false; // auto-play mode off == start demo game
			//	}
			//	if (viewer.draw_fade())
			//	{
			//		// Stop buzz
			//		Mix_HaltChannel(viewer.fadChannel);

			//		return true; // auto-play mode on == start regular game
			//	}
			//}
		}

		public void DeathFadeLoop()
		{
            throw new NotImplementedException();
   //         SDL_Event event = new SDL_Event();
			//viewer.displayDeath();
			//viewer.fadeVal = -2;
			//viewer.VXSCAL = 0x80;
			//viewer.VYSCAL = 0x80;
			//viewer.VXSCALf = 128.0f;
			//viewer.VYSCALf = 128.0f;
			//viewer.delay = 0;
			//viewer.VCTFAD = 32;
			//viewer.done = false;

			//while (SDL_PollEvent(event))
			//	; // clear event buffer

			//// Start buzz
			//Mix_Volume(viewer.fadChannel, 0);
			//Mix_PlayChannel(viewer.fadChannel, creature.buzz, -1);

			//while (!viewer.done)
			//{
			//	viewer.death_fade(viewer.W1_VLA);
			//	EscCheck();
			//}

			//// Stop buzz
			//Mix_HaltChannel(viewer.fadChannel);

			//while (SDL_PollEvent(event))
			//	; // clear event buffer

			//while (true)
			//{
			//	viewer.death_fade(viewer.W1_VLA);
			//	if (KeyCheck())
			//	{
			//		viewer.clearArea(viewer.TXTPRI);
			//		while (SDL_PollEvent(event))
			//			; // clear event buffer
			//		return;
			//	}
			//}
		}

		public void WinFadeLoop()
		{
            throw new NotImplementedException();
   //         SDL_Event event = new SDL_Event();
			//bool loopDone = false;
			//viewer.displayWinner();
			//viewer.fadeVal = -2;
			//viewer.VXSCAL = 0x80;
			//viewer.VYSCAL = 0x80;
			//viewer.VXSCALf = 128.0f;
			//viewer.VYSCALf = 128.0f;
			//viewer.delay = 0;
			//viewer.VCTFAD = 32;
			//viewer.done = false;

			//while (SDL_PollEvent(event))
			//	; // clear event buffer

			//// Start buzz
			//Mix_Volume(viewer.fadChannel, 0);
			//Mix_PlayChannel(viewer.fadChannel, creature.buzz, -1);

			//while (!viewer.done)
			//{
			//	viewer.death_fade(viewer.W2_VLA);
			//	EscCheck();
			//}

			//// Stop buzz
			//Mix_HaltChannel(viewer.fadChannel);

			//while (true)
			//{
			//	viewer.death_fade(viewer.W2_VLA);
			//	if (KeyCheck())
			//	{
			//		viewer.clearArea(viewer.TXTPRI);
			//		while (SDL_PollEvent(event))
			//			; // clear event buffer
			//		return;
			//	}
			//}

			//while (SDL_PollEvent(event))
			//	; // clear event buffer
		}

		/// <summary>Used by wizard fade in/out function.</summary>
		public bool KeyCheck()
		{
            throw new NotImplementedException();
   //         SDL_Event event = new SDL_Event();
			//while (SDL_PollEvent(event))
			//{
			//	switch (event.type)
			//	{
			//	case SDL_KEYDOWN:
			//		return (KeyHandler(event.key.keysym));
			//		break;
			//	case SDL_QUIT:
			//		oslink.quitSDL(0); // eventually change to meta-menu
			//		break;

			//	//SDL Cannot find SDL 2.0 replacement
		 // //      case SDL_VIDEOEXPOSE:
			//	//	//SDL_GL_SwapBuffers();
			//	//	break;
			//	}
			//}
			//return false;
		}

        /// <summary>Used by wizard fade in/out function.</summary>
        public bool KeyHandler(SDL.SDL_Keysym keysym)
		{
            throw new NotImplementedException();
   //         bool rc;

			//switch (keysym.sym)
			//{
			//case SDLK_ESCAPE:
			//	Mix_HaltChannel(viewer.fadChannel);

			//	rc = oslink.main_menu(); // calls the meta-menu

			//	Mix_Volume(viewer.fadChannel, 0);
			//	Mix_PlayChannel(viewer.fadChannel, creature.buzz, -1);
			//	return rc;
			//default:
			//	return true;
			//}
		}

		public void Reset()
		{
            throw new NotImplementedException();
   //         curTime = 0;
			//elapsedTime = 0;
			//TCBPTR = 0;
			//KBDHDR = 0;
			//KBDTAL = 0;
			//SLEEP = 0;
			//NOISEF = 0;
			//NOISEV = 0;
			//ZFLAG = 0;
			//hrtChannel = 0;

			//for (int ctr = 0; ctr < 38; ++ctr)
			//	TCBLND[ctr].Clear();
		}

		public void Save()
		{
            throw new NotImplementedException();
   //         ofstream fout = new ofstream();
			//int ctr;
			//string outstr = new string(new char[64]);

			//fout.open(oslink.gamefile, ios.trunc);
			//if (fout == null)
			//{
			//	// DISK ERROR
			//	viewer.OUTSTR(DERR);
			//	viewer.PROMPT();
			//	return;
			//}

			//outstr = string.Format("{0:D}", game.LEVEL);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", dungeon.VFTPTR);
			//fout << outstr << "\n";

			//for (ctr = 0; ctr < 1024; ++ctr)
			//{
			//	outstr = string.Format("{0:D}", dungeon.MAZLND[ctr]);
			//	fout << outstr << "\n";
			//}

			//outstr = string.Format("{0:D}", player.PROW);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.PCOL);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.POBJWT);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.PPOW);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.PLHAND);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.PRHAND);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.PDAM);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.PDIR);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.PTORCH);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.PRLITE);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.PMLITE);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.FAINT);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.BAGPTR);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.HEARTF);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.HEARTC);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.HEARTR);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.HEARTS);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", player.HBEATF);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", rng.SEED[0]);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", rng.SEED[1]);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", rng.SEED[2]);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", rng.carry);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", creature.FRZFLG);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", creature.CMXPTR);
			//fout << outstr << "\n";

			//for (ctr = 0; ctr < 60; ++ctr)
			//{
			//	outstr = string.Format("{0:D}", creature.CMXLND[ctr]);
			//	fout << outstr << "\n";
			//}

			//for (ctr = 0; ctr < 32; ++ctr)
			//{
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCPOW);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCMGO);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCMGD);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCPHO);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCPHD);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCTMV);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCTAT);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCOBJ);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCDAM);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCUSE);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].creature_id);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCDIR);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCROW);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", creature.CCBLND[ctr].P_CCCOL);
			//	fout << outstr << "\n";
			//}

			//outstr = string.Format("{0:D}", @object.OFINDF);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", @object.OCBPTR);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", @object.OFINDP);
			//fout << outstr << "\n";

			//for (ctr = 0; ctr < 72; ++ctr)
			//{
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCPTR);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCROW);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCCOL);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCLVL);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCOWN);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCXX0);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCXX1);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCXX2);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].obj_id);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].obj_type);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].obj_reveal_lvl);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCMGO);
			//	fout << outstr << "\n";
			//	outstr = string.Format("{0:D}", @object.OCBLND[ctr].P_OCPHO);
			//	fout << outstr << "\n";
			//}

			//outstr = string.Format("{0:D}", viewer.RLIGHT);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", viewer.MLIGHT);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", viewer.OLIGHT);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", viewer.VXSCAL);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", viewer.VYSCAL);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", viewer.TXBFLG);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", viewer.tcaret);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", viewer.tlen);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", viewer.NEWLIN);
			//fout << outstr << "\n";

			////Save current game levels' rnd seeds, as they are no longer hard-coded.
			//for (ctr = 0; ctr <= 6; ++ctr)
			//{
			//	outstr = string.Format("{0:D}", dungeon.LEVTAB[ctr]);
			//	fout << outstr << "\n";
			//}
			////Save vertical features table, as they are no longer hard-coded.

			//for (ctr = 0; ctr <= 41; ++ctr)
			//{
			//	outstr = string.Format("{0:D}", dungeon.VFTTAB[ctr]);
			//	fout << outstr << "\n";
			//}
			//outstr = string.Format("{0:D}", game.RandomMaze);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", game.ShieldFix);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", game.VisionScroll);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", game.CreaturesIgnoreObjects);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", game.CreaturesInstaRegen);
			//fout << outstr << "\n";
			//outstr = string.Format("{0:D}", game.MarkDoorsOnScrollMaps);
			//fout << outstr << "\n";

			//fout.close();
		}

		public void Load()
		{
            throw new NotImplementedException();
   //         ifstream fin = new ifstream();
			//int ctr;
			//int in;
			//string instr = new string(new char[64]);

			//fin.open(oslink.gamefile);
			//if (fin == null)
			//{
			//	// DISK ERROR
			//	viewer.OUTSTR(DERR);
			//	viewer.PROMPT();
			//	return;
			//}

			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	game.LEVEL = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	dungeon.VFTPTR = in;

			//for (ctr = 0; ctr < 1024; ++ctr)
			//{
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		dungeon.MAZLND[ctr] = in;
			//}

			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PROW = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PCOL = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.POBJWT = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PPOW = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PLHAND = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PRHAND = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PDAM = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PDIR = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PTORCH = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PRLITE = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.PMLITE = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.FAINT = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.BAGPTR = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.HEARTF = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.HEARTC = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.HEARTR = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.HEARTS = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	player.HBEATF = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	rng.SEED[0] = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	rng.SEED[1] = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	rng.SEED[2] = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	rng.carry = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	creature.FRZFLG = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	creature.CMXPTR = in;

			//for (ctr = 0; ctr < 60; ++ctr)
			//{
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CMXLND[ctr] = in;
			//}

			//for (ctr = 0; ctr < 32; ++ctr)
			//{
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCPOW = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCMGO = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCMGD = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCPHO = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCPHD = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCTMV = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCTAT = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCOBJ = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCDAM = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCUSE = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].creature_id = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCDIR = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCROW = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		creature.CCBLND[ctr].P_CCCOL = in;
			//}

			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	@object.OFINDF = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	@object.OCBPTR = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	@object.OFINDP = in;

			//for (ctr = 0; ctr < 72; ++ctr)
			//{
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCPTR = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCROW = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCCOL = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCLVL = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCOWN = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCXX0 = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCXX1 = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCXX2 = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].obj_id = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].obj_type = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].obj_reveal_lvl = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCMGO = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		@object.OCBLND[ctr].P_OCPHO = in;
			//}

			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	viewer.RLIGHT = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	viewer.MLIGHT = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	viewer.OLIGHT = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	viewer.VXSCAL = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	viewer.VYSCAL = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	viewer.TXBFLG = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	viewer.tcaret = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	viewer.tlen = in;
			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in))
			//	viewer.NEWLIN = in;
			////Original save games ended here.

			//fin >> instr;
			//if (1 == sscanf(instr, "%d", in)) //Do we have more data to load?  Yes:
			//{
			//	//Load current game levels' rnd seeds, as they are no longer hard-coded.
			//	dungeon.LEVTAB[0] = in;
			//	for (ctr = 1; ctr <= 6; ++ctr)
			//	{
			//		fin >> instr;
			//		if (1 == sscanf(instr, "%d", in))
			//			dungeon.LEVTAB[ctr] = in;
			//	}

			//	//Load vertical features table, as they are no longer hard-coded.
			//	for (ctr = 0; ctr <= 41; ++ctr)
			//	{
			//		fin >> instr;
			//		if (1 == sscanf(instr, "%d", in))
			//			dungeon.VFTTAB[ctr] = in;
			//	}
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		game.RandomMaze = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		game.ShieldFix = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		game.VisionScroll = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		game.CreaturesIgnoreObjects = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		game.CreaturesInstaRegen = in;
			//	fin >> instr;
			//	if (1 == sscanf(instr, "%d", in))
			//		game.MarkDoorsOnScrollMaps = in;
			//} else
			//{ //Do we have more data to load?  No:
			//	//Old save game.  Must be old save with original map.
			//	//Put in original rnd seeds & vertical features table.
			//	dungeon.LEVTAB[0] = 0x73;
			//	dungeon.LEVTAB[1] = 0xC7;
			//	dungeon.LEVTAB[2] = 0x5D;
			//	dungeon.LEVTAB[3] = 0x97;
			//	dungeon.LEVTAB[4] = 0xF3;
			//	dungeon.LEVTAB[5] = 0x13;
			//	dungeon.LEVTAB[6] = 0x87;
			//	dungeon.VFTTAB[0] = -1;
			//	dungeon.VFTTAB[1] = 1;
			//	dungeon.VFTTAB[2] = 0;
			//	dungeon.VFTTAB[3] = 23;
			//	dungeon.VFTTAB[4] = 0;
			//	dungeon.VFTTAB[5] = 15;
			//	dungeon.VFTTAB[6] = 4;
			//	dungeon.VFTTAB[7] = 0;
			//	dungeon.VFTTAB[8] = 20;
			//	dungeon.VFTTAB[9] = 17;
			//	dungeon.VFTTAB[10] = 1;
			//	dungeon.VFTTAB[11] = 28;
			//	dungeon.VFTTAB[12] = 30;
			//	dungeon.VFTTAB[13] = -1;
			//	dungeon.VFTTAB[14] = 1;
			//	dungeon.VFTTAB[15] = 2;
			//	dungeon.VFTTAB[16] = 3;
			//	dungeon.VFTTAB[17] = 0;
			//	dungeon.VFTTAB[18] = 3;
			//	dungeon.VFTTAB[19] = 31;
			//	dungeon.VFTTAB[20] = 0;
			//	dungeon.VFTTAB[21] = 19;
			//	dungeon.VFTTAB[22] = 20;
			//	dungeon.VFTTAB[23] = 0;
			//	dungeon.VFTTAB[24] = 31;
			//	dungeon.VFTTAB[25] = 0;
			//	dungeon.VFTTAB[26] = -1;
			//	dungeon.VFTTAB[27] = -1;
			//	dungeon.VFTTAB[28] = 0;
			//	dungeon.VFTTAB[29] = 0;
			//	dungeon.VFTTAB[30] = 31;
			//	dungeon.VFTTAB[31] = 0;
			//	dungeon.VFTTAB[32] = 5;
			//	dungeon.VFTTAB[33] = 0;
			//	dungeon.VFTTAB[34] = 0;
			//	dungeon.VFTTAB[35] = 22;
			//	dungeon.VFTTAB[36] = 28;
			//	dungeon.VFTTAB[37] = 0;
			//	dungeon.VFTTAB[38] = 31;
			//	dungeon.VFTTAB[39] = 16;
			//	dungeon.VFTTAB[40] = -1;
			//	dungeon.VFTTAB[41] = -1;
			//	game.RandomMaze = false;
			//	game.ShieldFix = false;
			//	game.VisionScroll = false;
			//	game.CreaturesIgnoreObjects = false;
			//	game.CreaturesInstaRegen = false;
			//	game.MarkDoorsOnScrollMaps = false;
			//} //Do we have more data to load?

			//fin.close();
		}

		public void LoadSounds()
		{
            throw new NotImplementedException();
            //hrtSound[0] = Utils.LoadSound("17_heart.wav");
			//hrtSound[1] = Utils.LoadSound("18_heart.wav");
		}

        /// <summary>Used during fainting and intermission.</summary>
        public bool EscCheck()
		{
            throw new NotImplementedException();
   //         SDL_Event event = new SDL_Event();
			//while (SDL_PollEvent(event))
			//{
			//	switch (event.type)
			//	{
			//	case SDL_KEYDOWN:
			//		return (KeyHandler(event.key.keysym));
			//		break;
			//	case SDL_QUIT:
			//		oslink.quitSDL(0); // eventually change to meta-menu
			//		break;
			//	//SDL 2.0 Cannot find replacement
			//	/*case SDL_VIDEOEXPOSE:
			//		SDL_GL_SwapBuffers();
			//		break;*/
			//	}
			//}
			//return false;
		}

        /// <summary>Used by wizard fade in/out function.</summary>
        public bool EscHandler(SDL.SDL_Keysym keysym)
		{
            throw new NotImplementedException();
   //         bool rc;

			//switch (keysym.sym)
			//{
			//case SDLK_ESCAPE:
			//	Mix_HaltChannel(viewer.fadChannel);

			//	rc = oslink.main_menu(); // Calls the meta-menu

			//	Mix_Volume(viewer.fadChannel, 0);
			//	Mix_PlayChannel(viewer.fadChannel, creature.buzz, -1);
			//	return (!rc);
			//default:
			//	return false;
			//}
		}

	    //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
		private bool puse_curState = false;
	    //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
		private uint pause_savedTime;

        //TODO: Fix parameter name
        /// <summary>Only saves state of TCBs, no actual sidestepping of execution.</summary>
        /// <param name="state"><see langword="true"/> to pause the game, <see langword="false"/> to unpause the game.</param>
		public void Pause(bool state)
		{
            throw new NotImplementedException();

   //         // The current pause state of the game

   //         if (!pause_curState && state)
		 //  pause_savedTime = curTime;
		 //else if (pause_curState && !state)
		 //{
		 //  curTime = SDL_GetTicks();

		 //  for (int i = 0; i < TCBPTR; i++)
		 //  {
			// TCBLND[i].next_time += (curTime - pause_savedTime);
			// TCBLND[i].prev_time += (curTime - pause_savedTime);
		 //  }
		 //}
		 //return;
		}

        /// <summary>This takes effect after the next creature regen.</summary>
        /// <param name="newTime">The new creature regen time (in minutes).</param>
        public void UpdateCreatureRegen(int newTime)
		{
            throw new NotImplementedException();
            //TCBLND[5].frequency = 60000 * newTime;
		}

		public Task[] TCBLND {get; set;} = Arrays.InitializeWithDefaultInstances<Task>(38);

		public byte[] DERR {get; set;} = new byte[15];

	    [Obsolete("Use TaskId")]
		public enum AnonymousEnum8
		{ // task IDs
			TidClock = 0,
			TidPlayer = 1,
			TidRefreshDisp = 2,
			TidHrtslow = 3,
			TidTorchburn = 4,
			TidCrtregen = 5,
			TidCrtmove = 6,
		}

        public uint curTime {get; set;}
		public uint elapsedTime {get; set;}

		public Mix_Chunk[] hrtSound {get; set;} = Arrays.InitializeWithDefaultInstances<Mix_Chunk>(2);
		public int hrtChannel {get; set;}

		public byte ZFLAG {get; set;}

        #region Private Members

        private int TCBPTR;
		private byte KBDHDR;
		private byte KBDTAL;

		private byte SLEEP;
		private byte NOISEF;
		private byte NOISEV;
        #endregion
    }
}
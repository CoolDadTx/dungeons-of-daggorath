﻿/****************************************
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

using SDL2;

namespace DoD
{
    //
    // This class is intended to be a controller class, but
    // so much of the functionality is closely associated
    // with the primary objects that there is not much going
    // on here.  As the game grows, this may change.
    public class DodGame
	{
        #region Construction

        /// <summary>Initializes an instance of the <see cref="DodGame"/> class.</summary>
        public DodGame ()
        {
            throw new NotImplementedException();
            //LEVEL = 2;
            //AUTFLG = true;
            //hasWon = false;
            //DEMOPTR = 0;
            //demoRestart = true;
            //Utils.LoadFromHex(DEMO_CMDS, DefineConstants.DExamine + DefineConstants.DPullRight + DefineConstants.DTorch + DefineConstants.DUseRight + DefineConstants.DLook +
            //                    DefineConstants.DMove + DefineConstants.DPullLeft + DefineConstants.DShield + DefineConstants.DPullRight + DefineConstants.DSword +
            //                    DefineConstants.DMove + DefineConstants.DMove + DefineConstants.DAttackRight + DefineConstants.DTurnRight + DefineConstants.DMove +
            //                    DefineConstants.DMove + DefineConstants.DMove + DefineConstants.DTurnRight + DefineConstants.DMove + DefineConstants.DMove + DefineConstants.DEnd);
        }
        #endregion

        /// <summary>Game initialization.</summary>
        public void Comini()
		{
            throw new NotImplementedException();
   //         uint ticks1;
			//uint ticks2;

			//scheduler.SYSTCB();
			//@object.CreateAll();
			//player.HBEATF = 0;
			//viewer.clearArea(viewer.TXTSTS);
			//viewer.clearArea(viewer.TXTPRI);
			//viewer.VXSCAL = 0x80;
			//viewer.VYSCAL = 0x80;
			//viewer.VXSCALf = 128.0f;
			//viewer.VYSCALf = 128.0f;
			//AUTFLG = viewer.ShowFade(Viewer.AnonymousEnum2.FadeBegin);
			
			//player.setInitialObjects(AUTFLG);
			//viewer.displayPrepare();
			//viewer.display_mode = Viewer.AnonymousEnum2.ModeTitle;
			//viewer.draw_game();

			//// Delay with "PREPARE!" on screen            
			//ticks1 = SDL.SDL_GetTicks();
			//do
			//{
			//	oslink.process_events();
			//	ticks2 = SDL.SDL_GetTicks();
			//} while (ticks2 < ticks1 + viewer.prepPause);

			//creature.NEWLVL();
			//if (AUTFLG)
			//{
			//	// do map
			//	viewer.display_mode = Viewer.AnonymousEnum2.ModeTitle;
			//	viewer.showSeerMap = true;
			//	--viewer.UPDATE;
			//	viewer.draw_game();
			//	// wait 3 seconds
			//	ticks1 = SDL.SDL_GetTicks();
			//	do
			//	{
			//		oslink.process_events();
			//		ticks2 = SDL.SDL_GetTicks();
			//	} while (ticks2 < ticks1 + 3000);
			//}
			//Inivu();
			//viewer.PROMPT();
		}

        /// <summary>Initializes 3D viewer.</summary>
        public void Inivu()
		{
            throw new NotImplementedException();
   //         viewer.clearArea(viewer.TXTSTS);
			//viewer.clearArea(viewer.TXTPRI);
			//player.HUPDAT();
			//++player.HEARTC;
			//--player.HEARTF;
			//--player.HBEATF;
			//viewer.STATUS();
			//player.PLOOK();
		}
                
		public void Restart()
		{
            throw new NotImplementedException();
   //         uint ticks1;
			//uint ticks2;

			//@object.Reset();
			//creature.Reset();
			//parser.Reset();
			//player.Reset();
			//scheduler.Reset();
			//viewer.Reset();
			//hasWon = false;

			//dungeon.VFTPTR = 0;
			//scheduler.SYSTCB();
			//@object.CreateAll();
			//player.HBEATF = 0;
			//player.setInitialObjects(false);
			//viewer.displayPrepare();
			//viewer.displayCopyright();
			//viewer.display_mode = Viewer.AnonymousEnum2.ModeTitle;
			//viewer.draw_game();

			//// Delay with "PREPARE!" on screen
			//ticks1 = SDL.SDL_GetTicks();
			//do
			//{
			//	oslink.process_events();
			//	ticks2 = SDL.SDL_GetTicks();
			//} while (ticks2 < ticks1 + 2500);

			//creature.NEWLVL();
			//Inivu();
			//viewer.PROMPT();
		}

		public void LoadGame()
		{
            throw new NotImplementedException();
   //         scheduler.LOAD();
			//viewer.setVidInv((game.LEVEL % 2) ?true: false);
			//--viewer.UPDATE;
			//viewer.draw_game();
			//Inivu();
			//viewer.PROMPT();
		}

        /// <summary>Pause 1.5 seconds.</summary>
        public void Wait()
		{
            throw new NotImplementedException();
   //         uint ticks1;
			//ticks1 = SDL.SDL_GetTicks();
			//scheduler.curTime = ticks1;

			//do
			//{
			//	if (scheduler.curTime >= scheduler.TCBLND[0].next_time)
			//	{
			//		scheduler.CLOCK();
			//		if (game.AUTFLG
			//			&& game.demoRestart == false)
			//			return;
			//		scheduler.EscCheck();
			//	}
			//	scheduler.curTime = SDL.SDL_GetTicks();
			//} while (scheduler.curTime < ticks1 + 1500);
		}

		//TODO: Public Data Fields make properties
		public byte LEVEL; // Dungeon level (0-4)
		public bool IsDemo;
		public bool RandomMaze;
		public bool ShieldFix;
		public bool VisionScroll;
		public bool CreaturesIgnoreObjects;
		public bool CreaturesInstaRegen;
		public bool MarkDoorsOnScrollMaps;
		public bool AUTFLG; // Autoplay (demo) flag
		public bool hasWon;
		public bool demoRestart;
		public int DEMOPTR;
		public byte[] DEMO_CMDS = new byte[256];

        #region Private Members

        #endregion
    }
}
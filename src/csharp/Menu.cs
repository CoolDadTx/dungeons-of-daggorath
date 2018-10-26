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
using System.Collections.Generic;
using System.Linq;

namespace DoD
{
    /// <summary>Implements the menus.</summary>
    /// <remarks>
    /// Note: implementation of commands is at OS_Link::menu_return
    /// </remarks>
    public class Menu
	{
        #region Construction

        /// <summary>Initializes an instance of the <see cref="Menu"/> class.</summary>
        public Menu ()
        {
            throw new NotImplementedException();
            //MENU_NAME[DefineConstants.FileMenuSwitch, 0] = "FILE".Substring(0, DefineConstants.NumLength);
            //MENU_NAME[DefineConstants.ConfigMenuSwitch, 0] = "CONFIGURE".Substring(0, DefineConstants.NumLength);
            //MENU_NAME[DefineConstants.HelpMenuSwitch, 0] = "HELP".Substring(0, DefineConstants.NumLength);

            //MENU_SIZE[0] = DefineConstants.NumFile;
            //MENU_SIZE[1] = DefineConstants.NumConfig;
            //MENU_SIZE[2] = DefineConstants.NumHelp;

            //FILE_MENU[DefineConstants.FileMenuNew, 0] = "START NEW GAME".Substring(0, DefineConstants.NumLength);
            //FILE_MENU[DefineConstants.FileMenuReturn, 0] = "RETURN TO GAME".Substring(0, DefineConstants.NumLength);
            //FILE_MENU[DefineConstants.FileMenuAbort, 0] = "ABORT GAME".Substring(0, DefineConstants.NumLength);
            //FILE_MENU[DefineConstants.FileMenuExit, 0] = "EXIT".Substring(0, DefineConstants.NumLength);

            //CONFIG[DefineConstants.ConfigMenuFullScreen, 0] = "FULL SCREEN".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuVideoRes, 0] = "VIDEO RESOLUTION".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuGraphics, 0] = "GRAPHICS MODE".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuColor, 0] = "COLOR MODE".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuVolume, 0] = "SOUND VOLUME".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuSavedir, 0] = "SAVE DIRECTORY".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuCreatureSpeed, 0] = "CREATURE SPEED".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuRegenSpeed, 0] = "REGEN SPEED".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuRandomMaze, 0] = "RANDOM MAZES".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuSndMode, 0] = "SOUND MODES".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuSaveOpt, 0] = "SAVE CURRENT OPTIONS".Substring(0, DefineConstants.NumLength);
            //CONFIG[DefineConstants.ConfigMenuDefaults, 0] = "RESTORE DEFAULTS".Substring(0, DefineConstants.NumLength);

            //HELP[DefineConstants.HelpMenuHowtoplay, 0] = "HOW TO PLAY".Substring(0, DefineConstants.NumLength);
            //HELP[DefineConstants.HelpMenuLicense, 0] = "LICENSE".Substring(0, DefineConstants.NumLength);
            //HELP[DefineConstants.HelpMenuAbout, 0] = "ABOUT DOD".Substring(0, DefineConstants.NumLength);
        }
        #endregion

        /// <summary>Retrieves the menu name based on an id.</summary>
        public string GetMenuName(int menu_id)
		{
            throw new NotImplementedException();
            //return MENU_NAME[menu_id, 0];
		}

        /// <summary>Retrieves the menu item specified.</summary>
        public string GetMenuItem(int menu_id, int item)
		{
            throw new NotImplementedException();
            //switch (menu_id)
            //{
            //    case DefineConstants.FileMenuSwitch:
            //        return FILE_MENU[item, 0];
            //        break;
            //    case DefineConstants.ConfigMenuSwitch:
            //        return CONFIG[item, 0];
            //        break;
            //    case DefineConstants.HelpMenuSwitch:
            //        return HELP[item, 0];
            //        break;
            //}
            //return null;
        }

        /// <summary>Returns the size of the specified menu.</summary>
        public int GetMenuSize(int menu_id)
		{
            throw new NotImplementedException();
            //return MENU_SIZE[menu_id];
		}

        #region Private Members

        //TODO: Fix casing
        private string[] MENU_NAME = new string[DefineConstants.NumMenu];
        private int[] MENU_SIZE = new int[DefineConstants.NumMenu];
        private string[] FILE_MENU = new string[DefineConstants.NumFile];
        private string[] CONFIG = new string[DefineConstants.NumConfig];
        private string[] HELP = new string[DefineConstants.NumHelp];

        #endregion
    }
}
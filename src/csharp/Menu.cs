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

namespace DoD
{
    /*******************************************************************
	  Class: menu
	
	  Function: implements the menus
	
	  Note: implementation of commands is at OS_Link::menu_return
	*******************************************************************/
    public class Menu
    {
        private char[,] MENU_NAME = new char[DefineConstants.NumMenu, DefineConstants.NumLength];
        private int[] MENU_SIZE = new int[DefineConstants.NumMenu];
        private char[,] FILE_MENU = new char[DefineConstants.NumFile, DefineConstants.NumLength];
        private char[,] CONFIG = new char[DefineConstants.NumConfig, DefineConstants.NumLength];
        private char[,] HELP = new char[DefineConstants.NumHelp, DefineConstants.NumLength];


        // Constructor -- initalizes strings 
        public menu ()
        {
            MENU_NAME[DefineConstants.FileMenuSwitch, 0] = "FILE".Substring(0, DefineConstants.NumLength);
            MENU_NAME[DefineConstants.ConfigMenuSwitch, 0] = "CONFIGURE".Substring(0, DefineConstants.NumLength);
            MENU_NAME[DefineConstants.HelpMenuSwitch, 0] = "HELP".Substring(0, DefineConstants.NumLength);

            MENU_SIZE[0] = DefineConstants.NumFile;
            MENU_SIZE[1] = DefineConstants.NumConfig;
            MENU_SIZE[2] = DefineConstants.NumHelp;

            FILE_MENU[DefineConstants.FileMenuNew, 0] = "START NEW GAME".Substring(0, DefineConstants.NumLength);
            FILE_MENU[DefineConstants.FileMenuReturn, 0] = "RETURN TO GAME".Substring(0, DefineConstants.NumLength);
            FILE_MENU[DefineConstants.FileMenuAbort, 0] = "ABORT GAME".Substring(0, DefineConstants.NumLength);
            FILE_MENU[DefineConstants.FileMenuExit, 0] = "EXIT".Substring(0, DefineConstants.NumLength);

            CONFIG[DefineConstants.ConfigMenuFullScreen, 0] = "FULL SCREEN".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuVideoRes, 0] = "VIDEO RESOLUTION".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuGraphics, 0] = "GRAPHICS MODE".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuColor, 0] = "COLOR MODE".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuVolume, 0] = "SOUND VOLUME".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuSavedir, 0] = "SAVE DIRECTORY".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuCreatureSpeed, 0] = "CREATURE SPEED".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuRegenSpeed, 0] = "REGEN SPEED".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuRandomMaze, 0] = "RANDOM MAZES".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuSndMode, 0] = "SOUND MODES".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuSaveOpt, 0] = "SAVE CURRENT OPTIONS".Substring(0, DefineConstants.NumLength);
            CONFIG[DefineConstants.ConfigMenuDefaults, 0] = "RESTORE DEFAULTS".Substring(0, DefineConstants.NumLength);

            HELP[DefineConstants.HelpMenuHowtoplay, 0] = "HOW TO PLAY".Substring(0, DefineConstants.NumLength);
            HELP[DefineConstants.HelpMenuLicense, 0] = "LICENSE".Substring(0, DefineConstants.NumLength);
            HELP[DefineConstants.HelpMenuAbout, 0] = "ABOUT DOD".Substring(0, DefineConstants.NumLength);
        }

        // Retrieves the menu name based on an id
        public string GetMenuName ( int menu_id )
        {
            return MENU_NAME[menu_id, 0];
        }

        // Retrieves the menu item specified
        public string GetMenuItem ( int menu_id, int item )
        {
            switch (menu_id)
            {
                case DefineConstants.FileMenuSwitch:
                    return FILE_MENU[item, 0];
                    break;
                case DefineConstants.ConfigMenuSwitch:
                    return CONFIG[item, 0];
                    break;
                case DefineConstants.HelpMenuSwitch:
                    return HELP[item, 0];
                    break;
            }
            return null;
        }

        // Returns the size of the specified menu
        public int GetMenuSize ( int menu_id )
        {
            return MENU_SIZE[menu_id];
        }
    }
}
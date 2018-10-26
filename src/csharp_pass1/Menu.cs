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
        //TODO: Fix case
        //Changed to strings
        private string[] MENU_NAME = new string[DefineConstants.NumMenu];
        private int[] MENU_SIZE = new int[DefineConstants.NumMenu];
        private string[] FILE_MENU = new string[DefineConstants.NumFile];
        private string[] CONFIG = new string[DefineConstants.NumConfig];
        private string[] HELP = new string[DefineConstants.NumHelp];


        // Constructor -- initializes strings 
        public Menu ()
        {
            MENU_NAME[DefineConstants.FileMenuSwitch] = "FILE";
            MENU_NAME[DefineConstants.ConfigMenuSwitch] = "CONFIGURE";
            MENU_NAME[DefineConstants.HelpMenuSwitch] = "HELP";

            MENU_SIZE[0] = DefineConstants.NumFile;
            MENU_SIZE[1] = DefineConstants.NumConfig;
            MENU_SIZE[2] = DefineConstants.NumHelp;

            FILE_MENU[DefineConstants.FileMenuNew] = "START NEW GAME";
            FILE_MENU[DefineConstants.FileMenuReturn] = "RETURN TO GAME";
            FILE_MENU[DefineConstants.FileMenuAbort] = "ABORT GAME";
            FILE_MENU[DefineConstants.FileMenuExit] = "EXIT";

            CONFIG[DefineConstants.ConfigMenuFullScreen] = "FULL SCREEN";
            CONFIG[DefineConstants.ConfigMenuVideoRes] = "VIDEO RESOLUTION";
            CONFIG[DefineConstants.ConfigMenuGraphics] = "GRAPHICS MODE";
            CONFIG[DefineConstants.ConfigMenuColor] = "COLOR MODE";
            CONFIG[DefineConstants.ConfigMenuVolume] = "SOUND VOLUME";
            CONFIG[DefineConstants.ConfigMenuSavedir] = "SAVE DIRECTORY";
            CONFIG[DefineConstants.ConfigMenuCreatureSpeed] = "CREATURE SPEED";
            CONFIG[DefineConstants.ConfigMenuRegenSpeed] = "REGEN SPEED";
            CONFIG[DefineConstants.ConfigMenuRandomMaze] = "RANDOM MAZES";
            CONFIG[DefineConstants.ConfigMenuSndMode] = "SOUND MODES";
            CONFIG[DefineConstants.ConfigMenuSaveOpt] = "SAVE CURRENT OPTIONS";
            CONFIG[DefineConstants.ConfigMenuDefaults] = "RESTORE DEFAULTS";

            HELP[DefineConstants.HelpMenuHowtoplay] = "HOW TO PLAY";
            HELP[DefineConstants.HelpMenuLicense] = "LICENSE";
            HELP[DefineConstants.HelpMenuAbout] = "ABOUT DOD";
        }

        // Retrieves the menu name based on an id
        public string GetMenuName ( int menu_id )
        {
            return MENU_NAME[menu_id];
        }

        // Retrieves the menu item specified
        public string GetMenuItem ( int menu_id, int item )
        {
            switch (menu_id)
            {
                case DefineConstants.FileMenuSwitch:
                    return FILE_MENU[item];
                case DefineConstants.ConfigMenuSwitch:
                    return CONFIG[item];
                case DefineConstants.HelpMenuSwitch:
                    return HELP[item];
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
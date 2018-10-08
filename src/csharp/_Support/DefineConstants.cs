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
    // All primary objects are declared in global space
    // to minimize dereferencing of pointers.  The main
    // function simply calls init on the oslink object
    // which contains all the SDL setup code.
    //
    // Every other file that uses these primary objects
    // needs to include the objects header and declare
    // an external reference to the object, which will
    // resolve to the declarations below.  This can
    // probably be simplified with some common mechanism.

    //
    // This file contains common definitions of secondary objects
    // used in the game.  It gets included in nearly every other
    // file, so the SDL hearders are included here also.

    // The original source code used mostly 8-bit bytes and 16-bit
    // words for RAM variable storages.  Many of the operations in
    // the source are bit-level so there is a need to have precise
    // types where the number of bits is known.  These types should
    // be used until/unless it is certain that more abstract types
    // (i.e., native C types) will work correctly.
    //typedef unsigned char dodBYTE;
    //typedef unsigned short dodSHORT;

    internal static class DefineConstants
	{
		public const int NumMenu = 3;
		public const int NumFile = 4;
		public const int NumConfig = 12;
		public const int NumHelp = 3;
		public const int NumLength = 35;
		public const int FileMenuSwitch = 0;
		public const int ConfigMenuSwitch = 1;
		public const int HelpMenuSwitch = 2;
		public const int FileMenuNew = 0;
		public const int FileMenuReturn = 1;
		public const int FileMenuAbort = 2;
		public const int FileMenuExit = 3;
		public const int ConfigMenuFullScreen = 0;
		public const int ConfigMenuVideoRes = 1;
		public const int ConfigMenuGraphics = 2;
		public const int ConfigMenuColor = 3;
		public const int ConfigMenuVolume = 4;
		public const int ConfigMenuSavedir = 5;
		public const int ConfigMenuCreatureSpeed = 6;
		public const int ConfigMenuRegenSpeed = 7;
		public const int ConfigMenuRandomMaze = 8;
		public const int ConfigMenuSndMode = 9;
		public const int ConfigMenuSaveOpt = 10;
		public const int ConfigMenuDefaults = 11;
		public const int HelpMenuHowtoplay = 0;
		public const int HelpMenuLicense = 1;
		public const int HelpMenuAbout = 2;
		public const int MaxFilenameLength = 80;
		public const string DExamine = "010f";
		public const string DPullRight = "032605";
		public const string DTorch = "19";
		public const string DUseRight = "023705";
		public const string DLook = "011e";
		public const string DMove = "0122";
		public const string DPullLeft = "032601";
		public const string DShield = "0f";
		public const string DSword = "14";
		public const string DAttackRight = "020105";
		public const string DTurnRight = "023305";
		public const string DEnd = "00";
		public const string VerString = "0.1.1.1";
		public const int VerMajor = 0;
		public const int VerMinor = 1;
		public const int VerRelease = 1;
		public const int VerBuild = 1;
		public const string CompanyName = "";
		public const string FileVersion = "";
		public const string FileDescription = "Developed using the Dev-C++ IDE";
		public const string InternalName = "";
		public const string LegalCopyright = "";
		public const string LegalTrademarks = "";
		public const string OriginalFilename = "";
		public const string ProductName = "";
		public const string ProductVersion = "";
		public const int IdiIcon1 = 101;
		public const int _APS_NEXT_RESOURCE_VALUE = 102;
		public const int _APS_NEXT_COMMAND_VALUE = 40001;
		public const int _APS_NEXT_CONTROL_VALUE = 1000;
		public const int _APS_NEXT_SYMED_VALUE = 101;
	}
}
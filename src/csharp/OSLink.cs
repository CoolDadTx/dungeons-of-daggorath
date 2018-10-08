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
    // This class manages the SDL operations, which abstract
    // the link to the operating system.  By keeping these
    // separate, it will be somewhat easier to change to a
    // different library if necessary.

    // Arbitrary Length of 80, maybe be changed if needed

    public class OSLink
	{
		// Constructor

		// Constructor
		public OS_Link()
		{
			this.width = 0;
			this.height = 0;
			this.bpp = 0;
			this.flags = 0;
			this.audio_rate = 44100;
			this.audio_format = AUDIO_S16;
			this.audio_channels = 2;
			this.audio_buffers = 512;
			this.gamefileLen = 50;
			this.keylayout = 0;
			this.keyLen = 256;
			Console.Write("OS_LINK Constructor");
			//#define MACOSX
#if MACOSX
			pathSep = "/";
#else
			pathSep = "\\";
#endif

			confDir = "conf";
			soundDir = "sound";
			savedDir = "saved";
	//C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
			memset(gamefile, 0, gamefileLen);
		}

		// Public Interface

		// This routine will eventually need updated to allow
		// user customization of screen size and resolution.
		// It currently asks for an 1024x768 screen size.
		// Updated - Now defaults to whatever is in the opts.ini file
		// if opts.ini doesn't exist or has invalid or missing values
		// uses defaults set by loadDefaults function (1024x768)
		public void Init()
		{
			Console.Write("Starting OS_Link::init()\n");
			LoadOptFile();

			uint ticks1;
			uint ticks2;

			//SDL 2.0 change
			//const SDL_VideoInfo * info = '\0';

			if (SDL_Init(SDL_INIT_VIDEO | SDL_INIT_TIMER | SDL_INIT_AUDIO) < 0)
			{
				Console.Error.Write("Video initialization failed: {0}\n", SDL_GetError());
				QuitSDL(1);
			}

			if (Mix_OpenAudio(audio_rate, audio_format, audio_channels, audio_buffers))
			{
				Console.Error.Write("Unable to open audio!\n");
				QuitSDL(1);
			}

			creature.LoadSounds();
			@object.LoadSounds();
			scheduler.LoadSounds();
			player.LoadSounds();

			Mix_AllocateChannels(4);
			Mix_Volume(-1, MIX_MAX_VOLUME);

			//SDL v2 change
			//info = SDL_GetVideoInfo();
			SDL_DisplayMode mode = new SDL_DisplayMode();
			if (SDL_GetDesktopDisplayMode(0, mode) < 0)
			{
				Console.Error.Write("Video query failed: {0}\n", SDL_GetError());
				QuitSDL(1);
			}
			//bpp = info->vfmt->BitsPerPixel;

			SDL_GL_SetAttribute(SDL_GL_RED_SIZE, 5);
			SDL_GL_SetAttribute(SDL_GL_GREEN_SIZE, 5);
			SDL_GL_SetAttribute(SDL_GL_BLUE_SIZE, 5);
			SDL_GL_SetAttribute(SDL_GL_DEPTH_SIZE, 16);
			SDL_GL_SetAttribute(SDL_GL_DOUBLEBUFFER, 1);

			//SDL v2.0 - value change
			flags = SDL_WINDOW_OPENGL;
			screen = SDL_CreateWindow(title, SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, mode.w, mode.h, flags);
			renderer = SDL_CreateRenderer(screen, -1, SDL_RENDERER_ACCELERATED);
			ChangeVideoRes(width); // All changing video res code was moved here

			//SDL v2.0 - obsolete
			//SDL_WM_SetCaption("Dungeons of Daggorath", "");

	//C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
			memset(keys, parser.C_SP, keyLen);

			if (keylayout == 0) // QWERTY
			{
				keys[SDLK_a] = (byte)'A';
				keys[SDLK_b] = (byte)'B';
				keys[SDLK_c] = (byte)'C';
				keys[SDLK_d] = (byte)'D';
				keys[SDLK_e] = (byte)'E';
				keys[SDLK_f] = (byte)'F';
				keys[SDLK_g] = (byte)'G';
				keys[SDLK_h] = (byte)'H';
				keys[SDLK_i] = (byte)'I';
				keys[SDLK_j] = (byte)'J';
				keys[SDLK_k] = (byte)'K';
				keys[SDLK_l] = (byte)'L';
				keys[SDLK_m] = (byte)'M';
				keys[SDLK_n] = (byte)'N';
				keys[SDLK_o] = (byte)'O';
				keys[SDLK_p] = (byte)'P';
				keys[SDLK_q] = (byte)'Q';
				keys[SDLK_r] = (byte)'R';
				keys[SDLK_s] = (byte)'S';
				keys[SDLK_t] = (byte)'T';
				keys[SDLK_u] = (byte)'U';
				keys[SDLK_v] = (byte)'V';
				keys[SDLK_w] = (byte)'W';
				keys[SDLK_x] = (byte)'X';
				keys[SDLK_y] = (byte)'Y';
				keys[SDLK_z] = (byte)'Z';
				keys[SDLK_BACKSPACE] = parser.C_BS;
				keys[SDLK_RETURN] = parser.C_CR;
				keys[SDLK_SPACE] = parser.C_SP;
			} else if (keylayout == 1) // Dvorak
			{
				keys[SDLK_a] = (byte)'A';
				keys[SDLK_n] = (byte)'B';
				keys[SDLK_i] = (byte)'C';
				keys[SDLK_h] = (byte)'D';
				keys[SDLK_d] = (byte)'E';
				keys[SDLK_y] = (byte)'F';
				keys[SDLK_u] = (byte)'G';
				keys[SDLK_j] = (byte)'H';
				keys[SDLK_g] = (byte)'I';
				keys[SDLK_c] = (byte)'J';
				keys[SDLK_v] = (byte)'K';
				keys[SDLK_p] = (byte)'L';
				keys[SDLK_m] = (byte)'M';
				keys[SDLK_l] = (byte)'N';
				keys[SDLK_s] = (byte)'O';
				keys[SDLK_r] = (byte)'P';
				keys[SDLK_x] = (byte)'Q';
				keys[SDLK_o] = (byte)'R';
				keys[SDLK_SEMICOLON] = (byte)'S';
				keys[SDLK_k] = (byte)'T';
				keys[SDLK_f] = (byte)'U';
				keys[SDLK_PERIOD] = (byte)'V';
				keys[SDLK_COMMA] = (byte)'W';
				keys[SDLK_b] = (byte)'X';
				keys[SDLK_t] = (byte)'Y';
				keys[SDLK_SLASH] = (byte)'Z';
				keys[SDLK_BACKSPACE] = parser.C_BS;
				keys[SDLK_RETURN] = parser.C_CR;
				keys[SDLK_SPACE] = parser.C_SP;
			}

			// Delay to wait for monitor to change modes if necessary
			// This ought to be made more intelligent
			ticks1 = SDL_GetTicks();
			do
				ticks2 = SDL_GetTicks();
			while (ticks2 < ticks1 + 2500);
			game.COMINI();
			while (true)
			{
				scheduler.SCHED();
				if (scheduler.ZFLAG == 0xFF)
				{
					game.LoadGame();
					scheduler.ZFLAG = 0;
				} else
				{
					if (game.AUTFLG)
					{
						if (game.demoRestart)
						{
							// Restart demo
							game.hasWon = false;
							game.DEMOPTR = 0;
							@object.Reset();
							creature.Reset();
							parser.Reset();
							player.Reset();
							scheduler.Reset();
							viewer.Reset();
							dungeon.VFTPTR = 0;
							game.COMINI();
						} else
						{
							// Start new game
							game.AUTFLG = false;
							game.Restart();
						}
					} else
					{
						game.Restart();
					}
				}
			}
			Console.Write("Init complete\n");
		}

		// Quits application
		public void QuitSDL(int code)
		{
			Mix_CloseAudio();
			SDL_Quit();
			Environment.Exit(code);
		}

		// Used to check for keystrokes and application termination
		public void ProcessEvents()
		{
			SDL_Event event = new SDL_Event();
			while (SDL_PollEvent(event))
			{
				switch (event.type)
				{
				case SDL_KEYDOWN:
					HandleKeyDown(event.key.keysym);
					break;
				case SDL_QUIT:
					QuitSDL(0);
					break;

					//SDL 2.0 cannot find replacement
					/*case SDL_VIDEOEXPOSE:
					    SDL_GL_SwapBuffers();
					    break;*/
				}
			}
		}

		/*********************************************************
		  Member: main_menu
		
		  Function: Implements the menu, and dispatches commands
		
		  Returns:  true  - If a new game is started
		            false - otherwise
		*********************************************************/
	//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
		private int main_menu_row = 0;
		int col = 0;
	//C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
		private Menu main_menu_mainMenu = new Menu();
		public bool MainMenu()
		{
			bool end = false;
	//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
	//		static int row = 0, col = 0;
	//C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
	//		static menu mainMenu;

			scheduler.pause(true);
			viewer.drawMenu(main_menu_mainMenu, col, main_menu_row);

			do
			{
				SDL_Event event = new SDL_Event();
				while (SDL_PollEvent(event))
				{
					switch (event.type)
					{
					case SDL_KEYDOWN:
						switch (event.key.keysym.sym)
						{
						case SDLK_RETURN:
							end = MenuReturn(col, main_menu_row, main_menu_mainMenu);

							// Used for Wizard fade functions, if it's a new game, it will trigger a key press
							if (col == DefineConstants.FileMenuSwitch
								&& main_menu_row == DefineConstants.FileMenuNew)
								return true;

							break;
						case SDLK_UP:
							(main_menu_row < 1) ? main_menu_row = main_menu_mainMenu.getMenuSize(col) - 1 : main_menu_row--;
							break;
						case SDLK_DOWN:
							(main_menu_row > main_menu_mainMenu.getMenuSize(col) - 2) ? main_menu_row = 0 : main_menu_row++;
							break;
						case SDLK_LEFT:
							(col < 1) ? col = DefineConstants.NumMenu - 1 : col--;
							main_menu_row = 0;
							break;
						case SDLK_RIGHT:
							(col > 1) ? col = 0 : col++;
							main_menu_row = 0;
							break;
						case SDLK_ESCAPE:
							end = true;
							break;
						default:
							break;
						}
						viewer.drawMenu(main_menu_mainMenu, col, main_menu_row);
						break;
					case SDL_QUIT:
						QuitSDL(0);
						break;

					//SDL 2.0 cannot find replacement
					/*case SDL_VIDEOEXPOSE:
					    SDL_GL_SwapBuffers();
					    break;*/
					}
				}
			} while (!end);

			scheduler.pause(false);

			return false;
		}

		/******************************************************************************
		*  Function used to save the options file from current settings
		*
		*  Arguments: None
		*
		*  Returns:   true - file saved successfully, false - file not saved
		******************************************************************************/
		public bool SaveOptFile()
		{
			ofstream fout = new ofstream();
			string fn = new string(new char[DefineConstants.MaxFilenameLength]);

			fn = string.Format("{0}{1}{2}", confDir, pathSep, "opts.ini");

			fout.open(fn);
			if (fout == null)
				return false;

			fout << "creatureSpeed=" << creature.creSpeedMul << "\n";
			fout << "turnDelay=" << player.turnDelay << "\n";
			fout << "moveDelay=" << player.moveDelay << "\n";
			fout << "keylayout=" << keylayout << "\n";
			fout << "volumeLevel=" << volumeLevel << "\n";
			fout << "saveDirectory=" << savedDir << "\n";
			fout << "fullScreen=" << FullScreen << "\n";
			fout << "screenWidth=" << width << "\n";
			fout << "creatureRegen=" << creatureRegen << "\n";

			fout << "graphicsMode=";
			if ((g_options & (int)AnonymousEnum8.OptVector) != 0)
				fout << "VECTOR" << "\n";
			else if (g_options & (int)AnonymousEnum8.OptHires)
				fout << "HIRES" << "\n";
			else
				fout << "NORMAL" << "\n";

			fout << "stereoMode=";
			if ((g_options & (int)AnonymousEnum8.OptStereo) != 0)
				fout << "STEREO" << "\n";
			else
				fout << "MONO" << "\n";

			fout << "RandomMaze=" << game.RandomMaze << "\n";
			fout << "ShieldFix=" << game.ShieldFix << "\n";
			fout << "VisionScroll=" << game.VisionScroll << "\n";
			fout << "CreaturesIgnoreObjects=" << game.CreaturesIgnoreObjects << "\n";
			fout << "CreaturesInstaRegen=" << game.CreaturesInstaRegen << "\n";
			fout << "MarkDoorsOnScrollMaps=" << game.MarkDoorsOnScrollMaps << "\n";

			fout.close();

			return true;
		}

		// Public Data Fields
		public int width; // actual screen width after video setup
		public int height; // same for height
		public int volumeLevel; // Volume level

		public string gamefile = new string(new char[50]);
		public int gamefileLen;
		public string pathSep = new string(new char[2]);
		public FILE fptr;
		public string confDir = new string(new char[5]);
		public string soundDir = new string(new char[6]);
		public string savedDir = new string(new char[DefineConstants.MaxFilenameLength + 1]);
		public byte[] keys = new byte[256];
		public int keylayout; // 0 = QWERTY, 1 = Dvorak
		public int keyLen;

		public int audio_rate;
		public ushort audio_format;
		public int audio_channels;
		public int audio_buffers;

		//SDL 2.0 changes

		//SDL v2.0 obsolete
		//void OS_Link::changeVideoRes(int newWidth)
		// {
		// int newHeight;
		//
		// SDL_Surface * surface;
		// const SDL_VideoInfo * info = NULL;
		// surface = SDL_GetVideoSurface();
		//
		// info = SDL_GetVideoInfo();
		// if(!info)
		//  {
		//  fprintf(stderr, "Video query failed: %s\n", SDL_GetError());
		//  quitSDL(1);
		//  }
		//
		// newHeight = (int) (newWidth * 0.75);
		//
		// if(FullScreen)
		//  {
		//  flags |= SDL_FULLSCREEN;
		//  SDL_ShowCursor(SDL_DISABLE);
		//  }
		// else
		//  {
		//  flags &= ~(SDL_FULLSCREEN);
		//  SDL_ShowCursor(SDL_ENABLE);
		//  }
		//
		// if((surface = SDL_SetVideoMode(newWidth, newHeight, bpp, flags)) == 0)
		//  {
		//  fprintf(stderr, "Video mode set failed: %s\nReturning to old mode\n", SDL_GetError());
		//  if((surface = SDL_SetVideoMode(width, height, bpp, flags)) == 0)
		//    {
		//    fprintf(stderr, "Video mode set failed, this should be impossible\n Debug OS_Link.changeVideoRes\nSDL Reported %s\n", SDL_GetError());
		//    exit(1);
		//    }
		//  }
		// else
		//  {
		//  width  = newWidth;
		//  height = newHeight;
		//  crd.setCurWH((double) width);
		//  }
		//  
		// viewer.setup_opengl();
		// glMatrixMode(GL_MODELVIEW);
		// glLoadIdentity();
		// }

		//SDL 2.0 changes
		public void SwapBuffers()
		{
			SDL_GL_SwapWindow(screen);
		}

		// Internal Implementation
		//SDL 2.0 renamed SDL_Keysym to SDL_Keysym

		// Processes key strokes.
		private void HandleKeyDown(SDL_Keysym keysym)
		{
			byte c;
			if (viewer.display_mode == Viewer.AnonymousEnum.ModeMap)
			{
				switch (keysym.sym)
				{
				case SDLK_ESCAPE:
					MainMenu();
					break;
				default:
					viewer.display_mode = Viewer.AnonymousEnum.Mode_3d;
					--viewer.UPDATE;
					parser.KBDPUT(32); // This is a (necessary ???) hack.
					break;
				}

			} else
			{
				switch (keysym.sym)
				{
				case SDLK_RSHIFT:
				case SDLK_LSHIFT:
				case SDLK_RCTRL:
				case SDLK_LCTRL:
				case SDLK_RALT:
				case SDLK_LALT:
				//SDL 2.0 0 removed
				//case SDLK_RMETA:
				//case SDLK_LMETA:
				case SDLK_LGUI:
				case SDLK_RGUI:
				//case SDLK_LSUPER:
				//case SDLK_RSUPER:
				case SDLK_MODE:
				//case SDLK_COMPOSE:
				//case SDLK_NUMLOCK:
				case SDLK_NUMLOCKCLEAR:
				case SDLK_CAPSLOCK:
				case SDLK_SCROLLLOCK:
					// ignore these keys
					return;

				case SDLK_ESCAPE:
					MainMenu(); // Enter the meta-menu routine
					return;

					//		case SDLK_EXCLAIM: c = '!'; break;
					//		case SDLK_LESS: c = '<'; break;
					//		case SDLK_GREATER: c = '>'; break;
					//		case SDLK_QUESTION: c = '?'; break;
					//		case SDLK_UNDERSCORE: c = '_'; break;
					//		case SDLK_PERIOD: c = '.'; break;
					//		case SDLK_LEFTBRACKET: c = '{'; break;
					//		case SDLK_RIGHTBRACKET: c = '}'; break;

				default:
					c = keys[keysym.sym];
					break;
				}
				parser.KBDPUT(c);
			}
		}

		/* Function to process menu commands
		*
		*  Returns:  false - if menu should be redrawn
		*            true  - otherwise */

		private bool MenuReturn(int menu_id, int item, Menu Menu)
		{
			switch (menu_id)
			{
				// File Menu
			case DefineConstants.FileMenuSwitch:
				switch (item)
				{
				case DefineConstants.FileMenuNew:
					//New Game
					scheduler.pause(false); // Needed so that the game can be paused again later

					if (!game.AUTFLG)
					{
						game.hasWon = true;
						game.demoRestart = false;
					}
					return true;
					break;

				case DefineConstants.FileMenuReturn:
					//Return
					return true;
					break;

				case DefineConstants.FileMenuAbort:
					//Abort (Restart)
					scheduler.pause(false); // Needed so that the game can be paused again later

					if (!game.AUTFLG)
					{
						game.AUTFLG = true;
						game.hasWon = true;
						game.demoRestart = true;
					}
					return true;
					break;

				case DefineConstants.FileMenuExit:
					//Exit
					QuitSDL(0);
					break;
				}

				// Configuration Menu
	//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
			case DefineConstants.ConfigMenuSwitch:
				switch (item)
				{
				case DefineConstants.ConfigMenuFullScreen:
				{
					//Full Screen
					string[] menuList = {"ON", "OFF"};

					switch (MenuList(menu_id * 5, item + 2, ref Menu.GetMenuItem(menu_id, item), menuList, 2))
					{
					case 0:
						if (!FullScreen)
							ChangeFullScreen();
						break;

					case 1:
						if (FullScreen)
							ChangeFullScreen();
						break;

					default:
						return false;
						break;
					}
				}
				return false;
				break;

				case DefineConstants.ConfigMenuVideoRes:
				{
					// Video Res
					string[] menuList = {"640X480", "800X600", "1024X768", "1280X1024"};

					switch (MenuList(menu_id * 5, item + 2, ref Menu.GetMenuItem(menu_id, item), menuList, 4))
					{
					case 0:
						ChangeVideoRes(640);
						break;

					case 1:
						ChangeVideoRes(800);
						break;

					case 2:
						ChangeVideoRes(1024);
						break;

					case 3:
						ChangeVideoRes(1280);
						break;

					default:
						return false;
						break;
					}
				}
				return false;
				break;

				case DefineConstants.ConfigMenuGraphics:
				{
					// Graphics (Normal /HIRes / vect)
					string[] menuList = {"NORMAL GRAPHICS", "HIRES GRAPHICS", "VECTOR GRAPHICS"};

					switch (MenuList(menu_id * 5, item + 2, ref Menu.GetMenuItem(menu_id, item), menuList, 3))
					{
					case 0:
						g_options &= ~((int)AnonymousEnum8.OptVector | (int)AnonymousEnum8.OptHires);
						break;

					case 1:
						g_options &= ~(AnonymousEnum8.OptVector);
						g_options |= AnonymousEnum8.OptHires;
						break;

					case 2:
						g_options &= ~(AnonymousEnum8.OptHires);
						g_options |= AnonymousEnum8.OptVector;
						break;

					default:
						return false;
						break;
					}
				}
				return true;
				break;

				case DefineConstants.ConfigMenuColor:
				{
					// Color (B&W / Art. / Full)
					//C++ Compiler reports this doesn't actually do anything since there are no case labels
					return false;
					/*char *menuList[] = { "BLACK WHITE" };
		
					switch (menu_list(menu_id * 5, item + 2, Menu.getMenuItem(menu_id, item), menuList, 1))
					{
					default:
					    return false;
					    break;
					}*/
				}
				return true;
				break;

				case DefineConstants.ConfigMenuVolume:
				{
					// Volume
					volumeLevel = MenuScrollbar("VOLUME LEVEL", 0, 128, volumeLevel);
					Mix_Volume(-1, volumeLevel);
				}
				return false;
				break;

				case DefineConstants.ConfigMenuSavedir:
				{
					// Save Dir
					// C++ Compiler reports this does nothing because it has no case labels
					return false;
					/*char *menuList[] = { "EDIT OPTS.INI FILE" };
		
					switch (menu_list(menu_id * 5, item + 2, Menu.getMenuItem(menu_id, item), menuList, 1))
					{
					default:
					    return false;
					    break;
					}*/
				}
				return false;
				break;

				case DefineConstants.ConfigMenuCreatureSpeed:
				{
					// Creature Speed
					string[] menuList = {"COCO", "CUSTOM"};

					switch (MenuList(menu_id * 5, item + 2, ref Menu.GetMenuItem(menu_id, item), menuList, 2))
					{
					case 0:
						//Coco Speed
						creature.creSpeedMul = 200;
						creature.UpdateCreSpeed();
						break;
					case 1:
						//Custom Speed
						creature.creSpeedMul = MenuScrollbar("CREATURE SPEED", 50, 200, volumeLevel);
						creature.UpdateCreSpeed();
						return false;
						break;

					default:
						return false;
						break;
					}
				}
				break;

				case DefineConstants.ConfigMenuRegenSpeed:
				{
					// Regen Speed
					string[] menuList = {"5 MINUTES", "3 MINUTES", "1 MINUTE"};

					switch (MenuList(menu_id * 5, item + 2, ref Menu.GetMenuItem(menu_id, item), menuList, 3))
					{
					case 0:
						creatureRegen = 5;
						scheduler.updateCreatureRegen(creatureRegen);
						break;
					case 1:
						creatureRegen = 3;
						scheduler.updateCreatureRegen(creatureRegen);
						break;
					case 2:
						creatureRegen = 1;
						scheduler.updateCreatureRegen(creatureRegen);
						break;
					default:
						return false;
						break;
					}
				}
				return true;
				break;

				case DefineConstants.ConfigMenuRandomMaze:
				{
					// Random Mazes
					string[] menuList = {"ON", "OFF"};

					switch (MenuList(menu_id * 5, item + 2, ref Menu.GetMenuItem(menu_id, item), menuList, 2))
					{
					case 0:
						game.RandomMaze = true;
						break;
					case 1:
						game.RandomMaze = false;
						break;
					default:
						return false;
						break;
					}
				}
				return false;
				break;

				case DefineConstants.ConfigMenuSndMode:
				{
					// Sound Style (Sync, Stereo)
					string[] menuList = {"STEREO", "MONO"};

					switch (MenuList(menu_id * 5, item + 2, ref Menu.GetMenuItem(menu_id, item), menuList, 2))
					{
					case 0:
						g_options |= AnonymousEnum8.OptStereo;
						break;

					case 1:
						g_options &= ~AnonymousEnum8.OptStereo;
						break;

					default:
						return false;
						break;
					}
				}
				break;

				case DefineConstants.ConfigMenuSaveOpt:
					SaveOptFile();
					return true;
					break;

				case DefineConstants.ConfigMenuDefaults:
					LoadDefaults();
					ChangeVideoRes(width);
					return true;
					break;
				}

				// Help menu
			case DefineConstants.HelpMenuSwitch:
				switch (item)
				{
				case DefineConstants.HelpMenuHowtoplay:
				{
					// How to play
					string[] menuList = {"SEE FILE HOWTOPLAY.TXT"};

					MenuList(menu_id * 5, item + 2, ref Menu.GetMenuItem(menu_id, item), menuList, 1);
				}
				return false;
				break;

				case DefineConstants.HelpMenuLicense:
				{
					// License
					string[] menuList = {"SEE FILE README.TXT"};

					MenuList(menu_id * 5, item + 2, ref Menu.GetMenuItem(menu_id, item), menuList, 1);
				}
				return false;
				break;

				case DefineConstants.HelpMenuAbout:
				{
					// About
					SDL_Event event = new SDL_Event();

					viewer.aboutBox();
					while (true)
					{
						while (SDL_PollEvent(event))
						{
							switch (event.type)
							{
							case SDL_KEYDOWN:
								return false;
								break;
							case SDL_QUIT:
								QuitSDL(0); // Quits SDL
								break;

							//SDL 2.0 Cannot find replacement
							/*case SDL_VIDEOEXPOSE:
							    SDL_GL_SwapBuffers();
							    break;*/
							}
						}
					}
					return false;
				}
				break;
				}
			}
			return true;
		}

		/*****************************************************************************
		*  Function used to draw a list, move among that list, and return the item selected
		*
		*  Arguments: x        - The top-left x-coordinate to draw list at
		*             y        - The top-left y-coordinate to draw list at
		*             title    - The title of the list
		*             list     - An array of strings (the list to be chosen from
		*             listSize - The size of the array
		******************************************************************************/
		private int MenuList(int x, int y, ref string title, string[] list, int listSize)
		{
			int currentChoice = 0;

			while (true)
			{
				viewer.drawMenuList(x, y, title, list, listSize, currentChoice);
				SDL_Event event = new SDL_Event();
				while (SDL_PollEvent(event))
				{
					switch (event.type)
					{
					case SDL_KEYDOWN:
						switch (event.key.keysym.sym)
						{
						case SDLK_RETURN:
							return (currentChoice);
							break;

						case SDLK_UP:
							(currentChoice < 1) ? currentChoice = listSize - 1 : currentChoice--;
							break;

						case SDLK_DOWN:
							(currentChoice > listSize - 2) ? currentChoice = 0 : currentChoice++;
							break;

						case SDLK_ESCAPE:
							return (-1);
							break;

						default:
							break;
						}
						break;
					case SDL_QUIT:
						QuitSDL(0);
						break;

					//SDL 2.0 Cannot find replacement
					/*case SDL_VIDEOEXPOSE:
					    SDL_GL_SwapBuffers();
					    break;*/
					}
				}
			} // End of while loop

			return (-1);
		}

		/*****************************************************************************
		*  Function used to draw a box for a string entry, then return it
		*
		*  Arguments: newString - The string to be returned
		*             title     - The title of the entry
		*             maxLength - The maximum size of the entry
		******************************************************************************/
		private void MenuString(ref string newString, ref string title, int maxLength)
		{
			newString = '\0';
			viewer.drawMenuStringTitle(title);
			viewer.drawMenuString(newString);

			while (true)
			{
				SDL_Event event = new SDL_Event();

				while (SDL_PollEvent(event))
				{
					switch (event.type)
					{
					case SDL_KEYDOWN:
						switch (event.key.keysym.sym)
						{
						case SDLK_RETURN:
							return;
							break;

						case SDLK_RSHIFT:
						case SDLK_LSHIFT:
						case SDLK_RCTRL:
						case SDLK_LCTRL:
						case SDLK_RALT:
						case SDLK_LALT:
						//SDL 2.0 removed
						//case SDLK_RMETA:
						//case SDLK_LMETA:
						//case SDLK_LSUPER:
						//case SDLK_RSUPER:
						case SDLK_LGUI:
						case SDLK_RGUI:
						case SDLK_MODE:
						//case SDLK_COMPOSE:
						//case SDLK_NUMLOCK:
						case SDLK_NUMLOCKCLEAR:
						case SDLK_CAPSLOCK:
						case SDLK_SCROLLLOCK:
						case SDLK_UP:
						case SDLK_DOWN:
							// ignore these keys
							break;

						case SDLK_BACKSPACE:
						case SDLK_LEFT:
							if (newString.Length > 0)
							{
								*(newString.Substring(newString.Length) - 1) = '\0';
								viewer.drawMenuStringTitle(title); // Update with the new word
								viewer.drawMenuString(newString);
							}
							break;

						case SDLK_ESCAPE:
							(newString) = '\0';
							return;
							break;

						default:
							//C++ compiler reports signed/unsigned mismatch
							if ((int)newString.Length < maxLength)
							{
								*(newString.Substring(newString.Length) + 1) = '\0';
								*(newString.Substring(newString.Length)) = keys[event.key.keysym.sym];
								viewer.drawMenuStringTitle(title); // Update with the new word
								viewer.drawMenuString(newString);
							}
							break;
						}
						break;
					case SDL_QUIT:
						QuitSDL(0);
						break;
					//SDL 2.0 Cannot find replacement
					/*case SDL_VIDEOEXPOSE:
					    SDL_GL_SwapBuffers();
					    break;*/
					}
				}
			} // End of while loop
		}

		/*****************************************************************************
		*  Function used to draw a scrollbar, and return the value
		*
		*  Arguments: title     - The title of the entry
		*             min       - The minimum value the scroll bar can take
		*             max       - The maximum value the scroll bar can take
		*             current   - The current position of the scrollbar
		*
		*  Returns: The value the user entered, or if they hit escape, the original
		*           value.
		******************************************************************************/
		private int MenuScrollbar(ref string title, int min, int max, int current)
		{
			int oldvalue = current; //Save the old value in case the user escapes
			int increment = (max - min) / 31; // 31 is the number of columns

			  // Calculate a relative max and min and corresponding current number
			int newMax = increment * 31;
			int newMin = 0;
			current = current - min;

			viewer.drawMenuScrollbar(title, (current - newMin) / increment);

			while (true)
			{
				SDL_Event event = new SDL_Event();

				while (SDL_PollEvent(event))
				{
					switch (event.type)
					{
					case SDL_KEYDOWN:
						switch (event.key.keysym.sym)
						{
						case SDLK_RETURN:
							return (current + min); // Readjust back to absolute value
							break;

						case SDLK_LEFT:
							(current > newMin) ? current -= increment : current = newMin;
							break;

						case SDLK_RIGHT:
							(current < newMax) ? current += increment : current = newMax;
							break;

						case SDLK_ESCAPE:
							return (oldvalue);
							break;

						default:
							break;
						}
						viewer.drawMenuScrollbar(title, (current - newMin) / increment);
						break;
					case SDL_QUIT:
						QuitSDL(0);
						break;

					//SDL 2.0 Cannot find replacement
					/*case SDL_VIDEOEXPOSE:
					    SDL_GL_SwapBuffers();
					    break;*/
					}
				}
			}
		}

		/******************************************************************************
		*  Function used to load & parse options file
		*
		*  Arguments: None
		******************************************************************************/
		private void LoadOptFile()
		{
			string inputString = new string(new char[80]);
			string fn = new string(new char[20]);
			int in;
			ifstream fin = new ifstream();
			string breakPoint;

			LoadDefaults(); // In case some variables aren't in the opts file, and if no file exists

			fn = string.Format("{0}{1}{2}", confDir, pathSep, "opts.ini");

			fin.open(fn);
			if (fin == null)
				return;

			fin >> inputString;
			while (fin != null)
			{
				breakPoint = StringFunctions.StrChr(inputString, '=');

				// Ignore strings that have no equals, or are only an equals, or have no end
				if (breakPoint != null
					|| breakPoint == inputString
					|| breakPoint == (inputString.Substring(inputString.Length) - 1))
				{
					(breakPoint) = '\0';
					breakPoint = breakPoint.Substring(1);

					if (!string.Compare(inputString, "creatureSpeed"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							creature.creSpeedMul = in;
					} else if (!string.Compare(inputString, "turnDelay"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							player.turnDelay = in;
					} else if (!string.Compare(inputString, "moveDelay"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							player.moveDelay = in;
					} else if (!string.Compare(inputString, "keylayout"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							keylayout = in;
					} else if (!string.Compare(inputString, "graphicsMode"))
					{
						if (!string.Compare(breakPoint, "NORMAL"))
							g_options &= ~((int)AnonymousEnum8.OptVector | (int)AnonymousEnum8.OptHires);
						else if (!string.Compare(breakPoint, "HIRES"))
						{
							g_options &= ~(AnonymousEnum8.OptVector);
							g_options |= AnonymousEnum8.OptHires;
						} else if (!string.Compare(breakPoint, "VECTOR"))
						{
							g_options &= ~(AnonymousEnum8.OptHires);
							g_options |= AnonymousEnum8.OptVector;
						}
					} else if (!string.Compare(inputString, "stereoMode"))
					{
						if (!string.Compare(breakPoint, "STEREO"))
							g_options |= AnonymousEnum8.OptStereo;
						else if (!string.Compare(breakPoint, "MONO"))
							g_options &= ~AnonymousEnum8.OptStereo;
					} else if (!string.Compare(inputString, "volumeLevel"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							volumeLevel = in;
					} else if (!string.Compare(inputString, "saveDirectory"))
					{
						savedDir = "saved".Substring(0, DefineConstants.MaxFilenameLength);
					} else if (!string.Compare(inputString, "fullScreen"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							FullScreen = in;
					} else if (!string.Compare(inputString, "screenWidth"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							width = in;
					} else if (!string.Compare(inputString, "creatureRegen"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							creatureRegen = in;
					} else if (!string.Compare(inputString, "RandomMaze"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							game.RandomMaze = in;
					} else if (!string.Compare(inputString, "ShieldFix"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							game.ShieldFix = in;
					} else if (!string.Compare(inputString, "VisionScroll"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							game.VisionScroll = in;
					} else if (!string.Compare(inputString, "CreaturesIgnoreObjects"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							game.CreaturesIgnoreObjects = in;
					} else if (!string.Compare(inputString, "CreaturesInstaRegen"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							game.CreaturesInstaRegen = in;
					} else if (!string.Compare(inputString, "MarkDoorsOnScrollMaps"))
					{
						if (1 == sscanf(breakPoint, "%d", in))
							game.MarkDoorsOnScrollMaps = in;
					}
				}

				fin >> inputString;
			}

			fin.close();
			scheduler.updateCreatureRegen(creatureRegen);
			creature.UpdateCreSpeed();
		}

		/******************************************************************************
		*  Function used to load the options file from current settings
		*
		*  Arguments: None
		******************************************************************************/
		private void LoadDefaults()
		{
			player.turnDelay = 37;
			player.moveDelay = 500;
			keylayout = 0;
			volumeLevel = MIX_MAX_VOLUME;
			creature.creSpeedMul = 200;
			creature.UpdateCreSpeed();
			savedDir = "saved";
			FullScreen = false;
			width = 1024;
			creatureRegen = 5;
			scheduler.updateCreatureRegen(creatureRegen);

			g_options &= ~((int)AnonymousEnum8.OptVector | (int)AnonymousEnum8.OptHires);
			g_options |= AnonymousEnum8.OptStereo;
		}

		/******************************************************************************
		*  Function used to swap fullscreen mode
		*
		*  Arguments: None
		******************************************************************************/
		private void ChangeFullScreen()
		{
			FullScreen = !FullScreen;
			ChangeVideoRes(width);
		}

		/******************************************************************************
		*  Function used to change the video resolution
		*
		*  Arguments: newWidth - The screen width to change to
		******************************************************************************/
		private void ChangeVideoRes(int newWidth)
		{
			//SDL v2.0 implementation
			int newHeight = (int)(newWidth * 0.75);

			if (FullScreen)
			{
				flags |= SDL_WINDOW_FULLSCREEN;
				SDL_ShowCursor(SDL_DISABLE);
			} else
			{
				flags &= ~(SDL_WINDOW_FULLSCREEN);
				SDL_ShowCursor(SDL_ENABLE);
			}

			if (!SetResolution(newWidth, newHeight))
			{
				Console.Error.Write("Video mode set failed: {0}\nReturning to old mode\n", SDL_GetError());
				if (!SetResolution(width, height))
				{
					Console.Error.Write("Video mode set failed, this should be impossible\n Debug OS_Link.changeVideoRes\nSDL Reported {0}\n", SDL_GetError());
					Environment.Exit(1);
				}
			} else
			{
				width = newWidth;
				height = newHeight;
				crd.setCurWH((double)width);
			}

			viewer.setup_opengl();
			glMatrixMode(GL_MODELVIEW);
			glLoadIdentity();
		}

		//SDL 2.0 changes
		private bool SetResolution(int width, int height)
		{
			if (FullScreen)
			{
				SDL_DisplayMode mode = new SDL_DisplayMode();
				mode.h = height;
				mode.w = width;

				if (SDL_SetWindowDisplayMode(screen, mode) >= 0)
					return true;
			} else
			{
				SDL_SetWindowSize(screen, width, height);
				return true;
			};

			return false;
		}

		// Data Fields    
		private int bpp; // bits per pixel
		private int flags; // SDL flags
		private bool FullScreen; // FullScreen
		private int creatureRegen; // Creature Regen Speed

		//SDL 2.0 changes
		private SDL_Window screen;
		private SDL_Renderer renderer;
		private string title = "Dungeons of Daggorath";
	}
}
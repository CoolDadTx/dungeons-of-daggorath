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
    // This class manages drawing to the screen, including
    // setting up the OpenGL data.  It's a work in progress.
    //
    // At the moment it is huge, which means that it really
    // needs to be broken into smaller, more well-defined
    // classes.  But it works for the present.
    public class Viewer
	{
		// Constructor

		// Constructor
		public Viewer()
		{
			this.VCNTRX = 128;
			this.VCNTRY = 76;
			this.fadChannel = 3;
			this.buzzStep = 300;
			this.midPause = 2500;
			this.prepPause = 2500;
			Utils.LoadFromDecDigit(A_VLA, "411212717516167572757582823535424");
			Utils.LoadFromDecDigit(B_VLA, "6112128182151522224545525275758285262645455656757");
			Utils.LoadFromDecDigit(C_VLA, "51222271721515222275758285262635356666757");
			Utils.LoadFromDecDigit(D_VLA, "411515212175758181222271752626757");
			Utils.LoadFromDecDigit(E_VLA, "411212818245455252767682821616222");
			Utils.LoadFromDecDigit(F_VLA, "3112128182454552527676828");
			Utils.LoadFromDecDigit(G_VLA, "6122227172767682856666757216162225262635343636444");
			Utils.LoadFromDecDigit(H_VLA, "3112128185161685824545525");
			Utils.LoadFromDecDigit(I_VLA, "3215152222757582832424737");
			Utils.LoadFromDecDigit(J_VLA, "3122223132151522252626858");
			Utils.LoadFromDecDigit(K_VLA, "81121281824343525354546364656574757676858516162524252534333434434");
			Utils.LoadFromDecDigit(L_VLA, "21121281821616222");
			Utils.LoadFromDecDigit(M_VLA, "51121281851616858263637274656574733434636");
			Utils.LoadFromDecDigit(N_VLA, "51121281851616858253536263444453543535444");
			Utils.LoadFromDecDigit(O_VLA, "412222717526267572151522227575828");
			Utils.LoadFromDecDigit(P_VLA, "411212818245455255565675727575828");
			Utils.LoadFromDecDigit(Q_VLA, "712222717214142222757582833434434425253435161625253636757");
			Utils.LoadFromDecDigit(R_VLA, "711212818275758282454552555656757334344344252534351616252");
			Utils.LoadFromDecDigit(S_VLA, "712222313566667572151522224545525275758281525271752626454");
			Utils.LoadFromDecDigit(T_VLA, "416262818566668582757582831414737");
			Utils.LoadFromDecDigit(U_VLA, "3122228185262685821515222");
			Utils.LoadFromDecDigit(V_VLA, "51525281855656858233335254353554531414333");
			Utils.LoadFromDecDigit(W_VLA, "51121281851616858223233234252534333434535");
			Utils.LoadFromDecDigit(X_VLA, "9112123135161635316262818566668582333342443535444344445352535362645555646");
			Utils.LoadFromDecDigit(Y_VLA, "53141453525353626455556461626281856666858");
			Utils.LoadFromDecDigit(Z_VLA, "711616212176768181222231323333424344445354555564656666757");
			Utils.LoadFromDecDigit(NM0_VLA, "422323727373858575767625231515232");
			Utils.LoadFromDecDigit(NM1_VLA, "3316162324252584836464737");
			Utils.LoadFromDecDigit(NM2_VLA, "6116162121222241424545525556567575758282716262717");
			Utils.LoadFromDecDigit(NM3_VLA, "721515222122223135262645454552524556567575758282727261617");
			Utils.LoadFromDecDigit(NM4_VLA, "441515848646515142535362636464737");
			Utils.LoadFromDecDigit(NM5_VLA, "6122223132151522252626555555616151626271717676818");
			Utils.LoadFromDecDigit(NM6_VLA, "52151522252626454122227172454552527575828");
			Utils.LoadFromDecDigit(NM7_VLA, "6112123132333342434444535455556465666675717676818");
			Utils.LoadFromDecDigit(NM8_VLA, "721515222122224145262645424545525152527175565675727575828");
			Utils.LoadFromDecDigit(NM9_VLA, "6114142124252534353636757245455251525271727575828");
			Utils.LoadFromDecDigit(PER_VLA, "131414232");
			Utils.LoadFromDecDigit(UND_VLA, "111616212");
			Utils.LoadFromDecDigit(EXP_VLA, "23141423234444838");
			Utils.LoadFromDecDigit(QSM_VLA, "6314142323343453544545545556567571626271727575828");
			Utils.LoadFromDecDigit(SHL_VLA, "174848676");
			Utils.LoadFromDecDigit(SHR_VLA, "403131707233337271222261634444636");
			Utils.LoadFromDecDigit(LHL_VLA, "26474766673838777");
			Utils.LoadFromDecDigit(LHR_VLA, "50212170711212616223237273343473744545646");
			Utils.LoadFromDecDigit(FSL_VLA, "51121231323333424344445354555564656666858");
			Utils.LoadFromDecDigit(BSL_VLA, "51626281825353626344445354353544451616353");
			Utils.LoadFromDecDigit(PCT_VLA, "711212313233334243444453545555646566668581636381841616343");
			Utils.LoadFromDecDigit(PLS_VLA, "23242473714646515");
			Utils.LoadFromDecDigit(DSH_VLA, "114646515");

			AZ_VLA[1] = A_VLA;
			AZ_VLA[2] = B_VLA;
			AZ_VLA[3] = C_VLA;
			AZ_VLA[4] = D_VLA;
			AZ_VLA[5] = E_VLA;
			AZ_VLA[6] = F_VLA;
			AZ_VLA[7] = G_VLA;
			AZ_VLA[8] = H_VLA;
			AZ_VLA[9] = I_VLA;
			AZ_VLA[10] = J_VLA;
			AZ_VLA[11] = K_VLA;
			AZ_VLA[12] = L_VLA;
			AZ_VLA[13] = M_VLA;
			AZ_VLA[14] = N_VLA;
			AZ_VLA[15] = O_VLA;
			AZ_VLA[16] = P_VLA;
			AZ_VLA[17] = Q_VLA;
			AZ_VLA[18] = R_VLA;
			AZ_VLA[19] = S_VLA;
			AZ_VLA[20] = T_VLA;
			AZ_VLA[21] = U_VLA;
			AZ_VLA[22] = V_VLA;
			AZ_VLA[23] = W_VLA;
			AZ_VLA[24] = X_VLA;
			AZ_VLA[25] = Y_VLA;
			AZ_VLA[26] = Z_VLA;
			AZ_VLA[27] = PER_VLA;
			AZ_VLA[28] = UND_VLA;
			AZ_VLA[29] = EXP_VLA;
			AZ_VLA[30] = QSM_VLA;
			AZ_VLA[31] = SHL_VLA;
			AZ_VLA[32] = SHR_VLA;
			AZ_VLA[33] = LHL_VLA;
			AZ_VLA[34] = LHR_VLA;
			AZ_VLA[35] = NM0_VLA;
			AZ_VLA[36] = NM1_VLA;
			AZ_VLA[37] = NM2_VLA;
			AZ_VLA[38] = NM3_VLA;
			AZ_VLA[39] = NM4_VLA;
			AZ_VLA[40] = NM5_VLA;
			AZ_VLA[41] = NM6_VLA;
			AZ_VLA[42] = NM7_VLA;
			AZ_VLA[43] = NM8_VLA;
			AZ_VLA[44] = NM9_VLA;
			AZ_VLA[45] = FSL_VLA;
			AZ_VLA[46] = BSL_VLA;
			AZ_VLA[47] = PCT_VLA;
			AZ_VLA[48] = PLS_VLA;
			AZ_VLA[49] = DSH_VLA;

			Utils.LoadFromHex(SP_VLA, "020BA07CA474A878B074B878B07CA878B078B878BC74C07C07A87CAA74AC78B07AB478" + "B674B87C");

			Utils.LoadFromHex(WR_VLA, "0303443E58446438095A4A4A46504C5A4A644866405A4A5E565A56075064565A645C6C" + "62625E565E5064");

			Utils.LoadFromHex(SC_VLA, "020D4A704A6C46683E6C42744A765278527C4A7C427446783E78427C065A7C5A785278" + "4A7C4A805280");
			Utils.LoadFromHex(BL_VLA, "0314825272566C646A6E6A7860826A806884727E80808E82948098849A80A2829C7C9A" + "6C945C8A568252088256885C8A6280648256785C7666806403746C76729078");
			Utils.LoadFromHex(GL_VLA, "04157C50725E786E70844E6830844844205458167234805C8E34A816E058B844D084B2" + "709084886E8E5E84500970847A7C7E6E7A64805C8664826E867C90840B7A526A605C5C" + "564C4E48544E4C4E54525860666874641BA816A21AA612A018A01E96268C2E862A8A20" + "8412862080267A207C1276207A2A8036862A802E7A2A742E6A26601E60185A125E1A5816");
			Utils.LoadFromHex(VI_VLA, "020F82847A707C5C7E5E825E845C82708C80888472846C78766A7078747C7E7C107864" + "78607C5C785878547A527E567A5286528256865288548858845C88608864");
			Utils.LoadFromHex(S1_VLA, "050A62687062785C805E846084667E6878687266646A0C846688669470A07AAE7CAA78" + "AE78A274986A8E60825C7658085C4E604662505E565C4E544C58545E560B5A6A566C58" + "6E5E6C6278547E587A507A58764C6650621554565C60666C627056684A5E4C52544C50" + "48544A58445E46604260466C44744878566860645C6E546A4A");
			Utils.LoadFromHex(S2_VLA, "050462687C5E7E60646A108466725C7666726E846688669470A07AAE7CAA78AE78A274" + "986A8E60825C7658085C4E604662505E565C4E544C58545E560B5A6A566C586E5E6C62" + "78547E587A507A58764C6650621554565C60666C627056684A5E4C52544C5048544A58" + "445E46604260466C44744878566860645C6E546A4A");
			Utils.LoadFromHex(K1_VLA, "08057C22842282247E247C22088E508840922E9C408C52884C92408C3A068C509880A0" + "849084907E8254067E546E7E6E845C8466807450118C50805672507840743A6E2E7A2A" + "7C1E801A841E862A922E862A862E80347A2E7A2A07803480147C147E18821884148014" + "0E664A66466A466A405A405A465E465E4A604A60506450644A664A743A096E2E664064" + "40661E62145E1E604062406214");
			Utils.LoadFromHex(K2_VLA, "08047E1E7E287C287C2407962CA634A44C965C884C8634962C068C509880A084908490" + "7E8254067E546E7E6E845C8466807450118C50805672507840743A6E2E7A2A7C1E801A" + "841E862A922E862A862E80347A2E7A2A07803480147C147E188218841480140E664A66" + "466A466A405A405A465E465E4A604A60506450644A664A743A096E2E66406440661E62" + "145E1E604062406214");
			Utils.LoadFromHex(W0_VLA, "080D7C40784878406E4E66406E3A763678327A2E74286C2A781C7E1C08821C881C9224" + "9432882C842E8630882C0986308E36A474848476825E786E5A84846A4805664064425E" + "38603666400566426244664A684C6E5A027058784809843E80147A347A407C3C807282" + "508244843E0B822880267C287E2A8228802E80327E327E2A7C287E2E");
			Utils.LoadFromHex(W1_VLA, "0A0D7C40784878406E4E66406E3A763678327A2E74286C2A781C7E1C08821C881C9224" + "9432882C842E8630882C0986308E36A474848476825E786E5A84846A4805664064425E" + "38603666400566426244664A684C6E5A027058784809843E80147A347A407C3C807282" + "508244843E0B822880267C287E2A8228802E80327E327E2A7C287E2E10622E64326236" + "5C3A5638523056285A265E285C28582A563058345C366232622E109A689C6C9A709474" + "8E728A6A8E6292609662946290648E6A926E96709A6C9A68");
			Utils.LoadFromHex(W2_VLA, "0C0D7C40784878406E4E66406E3A763678327A2E74286C2A781C7E1C08821C881C9224" + "9432882C842E8630882C0986308E36A474848476825E786E5A84846A4805664064425E" + "38603666400566426244664A684C6E5A027058784809843E80147A347A407C3C807282" + "508244843E0B822880267C287E2A8228802E80327E327E2A7C287E2E0656285C40642A" + "523668385628068C428C508644904A864C8C42069260947888649A6A8A749260067450" + "7A5A72567A52745A7450");
			Utils.LoadFromHex(LAD_VLA, "0B0274187480028C188C8002741C8C1C0274288C280274348C340274408C4002744C8C" + "4C0274588C580274648C640274708C7002747B8C7B");
			Utils.LoadFromHex(HUP_VLA, "040664225C18A4189C2264226418029C229C18022F1C601C02A11CD21C");
			Utils.LoadFromHex(HDN_VLA, "020664765C80A4809C7664766480029C769C80");
			Utils.LoadFromHex(CEI_VLA, "01022F1CD11C");
			Utils.LoadFromHex(LPK_VLA, "01051C64246C207024781C80");
			Utils.LoadFromHex(RPK_VLA, "0105E464DC6CE070DC78E480");
			Utils.LoadFromHex(FSD_VLA, "01036C7180439472");
			Utils.LoadFromHex(LSD_VLA, "0103288032423A75");
			Utils.LoadFromHex(RSD_VLA, "0103D880CE42C675");
			Utils.LoadFromHex(RWAL_VLA, "0104E510C026C072E588");
			Utils.LoadFromHex(LWAL_VLA, "01041B10402640721B88");
			Utils.LoadFromHex(FWAL_VLA, "02024026C026024072C072");
			Utils.LoadFromHex(RPAS_VLA, "0204E526C026C072E57202E510C026");
			Utils.LoadFromHex(LPAS_VLA, "02041D26402640721B72021B104026");
			Utils.LoadFromHex(FPAS_VLA, "00");
			Utils.LoadFromHex(RDOR_VLA, "0304E510C026C072E58804D880D841C844C87702D05CCC5D");
			Utils.LoadFromHex(LDOR_VLA, "03041B10402640721B8804288028413844387702305C345D");
			Utils.LoadFromHex(FDOR_VLA, "04024026C026024072C072046C726C4394439472027E5E825E");
			Utils.LoadFromHex(SHIE_VLA, "0106AC86C080BA7AA880A486AC86");
			Utils.LoadFromHex(SWOR_VLA, "02025072647C0252765672");
			Utils.LoadFromHex(TORC_VLA, "01043C764A7448723C76");
			Utils.LoadFromHex(RING_VLA, "01053C7A3E7C3C7E3A7C3C7A");
			Utils.LoadFromHex(SCRO_VLA, "0105C276C078C87ECA7CC276");
			Utils.LoadFromHex(FLAS_VLA, "0104A26EA478A078A26E");

			TXTEXA.SetVals(ref examArea, 0, 32 * 19, 0);
			TXTPRI.SetVals(ref textArea, 0, 32 * 4, 20);
			TXTSTS.SetVals(ref statArea, 0, 32 * 1, 19);

			LArch[0] = LPAS_VLA;
			LArch[1] = LDOR_VLA;
			LArch[2] = LSD_VLA;
			LArch[3] = LWAL_VLA;

			FArch[0] = FPAS_VLA;
			FArch[1] = FDOR_VLA;
			FArch[2] = FSD_VLA;
			FArch[3] = FWAL_VLA;

			RArch[0] = RPAS_VLA;
			RArch[1] = RDOR_VLA;
			RArch[2] = RSD_VLA;
			RArch[3] = RWAL_VLA;

			FLATAB[0] = 3;
			FLATAB[1] = 0;
			FLATAB[2] = 1;

			FLATABv[0] = LArch;
			FLATABv[1] = FArch;
			FLATABv[2] = RArch;

			FWDOBJ[0] = FLAS_VLA;
			FWDOBJ[1] = RING_VLA;
			FWDOBJ[2] = SCRO_VLA;
			FWDOBJ[3] = SHIE_VLA;
			FWDOBJ[4] = SWOR_VLA;
			FWDOBJ[5] = TORC_VLA;

			FWDCRE[0] = SP_VLA;
			FWDCRE[1] = VI_VLA;
			FWDCRE[2] = S1_VLA;
			FWDCRE[3] = BL_VLA;
			FWDCRE[4] = K1_VLA;
			FWDCRE[5] = S2_VLA;
			FWDCRE[6] = SC_VLA;
			FWDCRE[7] = K2_VLA;
			FWDCRE[8] = WR_VLA;
			FWDCRE[9] = GL_VLA;
			FWDCRE[10] = W0_VLA;
			FWDCRE[11] = W1_VLA;

			float start1 = 200.0f;
			float start2 = 256.0f;
			for (int x = 0;x < 9;x++)
			{
				Scalef[x] = start1;
				Scalef[x + 10] = start2;
				start1 *= 0.633f;
				start2 *= 0.633f;
			}
			Scalef[20] = start2;

			Utils.LoadFromHex(Scale, "C88050321F140C080402FF9C6441281A100A060301");
			Utils.LoadFromHex(enough1, "FFC0573EA746C0905132281E6051099820C0E7DEF0");
			Utils.LoadFromHex(enough2, "E8000848B00C8A0A3C0D29680A232023DEDDEF60");
			Utils.LoadFromHex(winner1, "FFC4543D84D80859D12EC80370A693051050202E20");
			Utils.LoadFromHex(winner2, "C80000000003CC0081C5B82E9D0644F7BC");
			Utils.LoadFromHex(death, "FFC192D00173E882C8047966073E809169593BDEF0");
			Utils.LoadFromHex(copyright, "F8DF0CC92745000265C10352393C0068DACC630948");
			Utils.LoadFromHex(welcome1, "9FD2020645064A02BA8597BDEF80");
			Utils.LoadFromHex(welcome2, "F7BDEA20A0255C72BDD303CC0204E77C83446F7B");
			Utils.LoadFromHex(prepstr, "3C24580645D8");
			Utils.LoadFromHex(exam1, "625C0A2133049EF6FC");
			Utils.LoadFromHex(exam2, "56C72286959177F0");
			Utils.LoadFromHex(exam3, "408235C0235FC0");
			Utils.LoadFromHex(exps, "16F7B0");
			Utils.LoadFromHex(LINES, "02020010FF10020088FF88");

			Reset();
		}

		// Public Interface

		// Public Interface
		public void SetupOpengl()
		{
		//	glEnable(GL_LINE_SMOOTH);
			glDisable(GL_LINE_SMOOTH);
			glClearColor(bgColor[0], bgColor[1], bgColor[2], 0.0);
			glViewport(0, 0, oslink.width, oslink.height);
			glMatrixMode(GL_PROJECTION);
			glLoadIdentity();
			//SDL 2.0 Is this the correct replacement?
			//gluOrtho2D(0, oslink.width, 0, oslink.height);
			glOrtho(0, oslink.width, 0, oslink.height, 0, 0);
			GlobalMembers.ClearColor = 1;
		}

		// This is the main renderer routine.  It draws either
		// the map, or the 3D/Examine-Status-Text Area.
		public void DrawGame()
		{
			if (UPDATE == 0)
				return;
			if (display_mode == (int)AnonymousEnum.ModeMap)
			{
				// Draw Map
				glClearColor(1.0, 1.0, 1.0, 0.0);
				glClear(GL_COLOR_BUFFER_BIT);
				glClearColor(bgColor[0], bgColor[1], bgColor[2], 0.0);
				glLoadIdentity();
				Mapper();

				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();
			} else
			{
				// Draw View Port (3D or Examine or Prepare!)
				glClear(GL_COLOR_BUFFER_BIT);

				glLoadIdentity();
				glColor3fv(fgColor);
				switch (display_mode)
				{
				case AnonymousEnum.Mode_3d:
					Viewer();
					break;
				case AnonymousEnum.ModeExamine:
					ClearArea(TXTEXA);
					Examin();
					DrawArea(TXTEXA);
					if (player.PTORCH != -1)
						DrawTorchHighlite();
					break;
				case AnonymousEnum.ModeTitle:
					DrawArea(TXTEXA);
					break;
				default:
					break;
				}

				// Draw Status Line
				DrawArea(TXTSTS);

				// Draw Text Area
				DrawArea(TXTPRI);

				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();
			}
			UPDATE = 0;
		}

		// This is the renderer method used to do the wizard
		// fade in/out.  It's only used during the opening.  It
		// is syncronized with the 30Hz buzz and the wizard
		// crashing sound.
		public bool DrawFade()
		{
			delay1 = delay2 = SDL_GetTicks();

			if ((!done && delay1 > delay + buzzStep)
				&& fadeVal != 0)
				glClear(GL_COLOR_BUFFER_BIT);
			glMatrixMode(GL_MODELVIEW);
			glLoadIdentity();

			DrawArea(TXTSTS);

			glColor3fv(fgColor);

			if ((!done && delay1 > delay + buzzStep)
				&& fadeVal != 0)
			{
				// Set volume of buzz
				Mix_Volume(fadChannel, ((32 - VCTFAD) / 2) * (oslink.volumeLevel / 16));

				glLoadIdentity();
				DrawVectorList(W1_VLA);
				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();
				VCTFAD += fadeVal;
				if ((VCTFAD & 0x80) != 0)
				{
					// do sound crash
					Mix_HaltChannel(fadChannel);
					Mix_Volume(fadChannel, oslink.volumeLevel);
					Mix_PlayChannel(fadChannel, creature.kaboom, 0);
					while (Mix_Playing(fadChannel) == 1)
					{
						// Call keyboard routine ???
					}

					VCTFAD = 0;
					fadeVal = 0;
				}
				if (VCTFAD == 32
					&& fadeVal == 2)
				{
					done = true;
					ClearArea(TXTPRI);
					DrawArea(TXTPRI);
				}
				delay = SDL_GetTicks();
			}

			if (VCTFAD == 0
				&& fadeVal == 0)
			{
				glLoadIdentity();
				DrawVectorList(W1_VLA);
				DrawArea(TXTPRI);
				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();
				delay2 = SDL_GetTicks();
				if (delay2 > delay + midPause)
				{
					// do sound crash
					Mix_PlayChannel(fadChannel, creature.kaboom, 0);
					while (Mix_Playing(fadChannel) == 1)
					{
						// Call keyboard routine ???
					}

					fadeVal = 2;
					delay = SDL_GetTicks();

					Mix_PlayChannel(fadChannel, creature.buzz, -1);
				}
			}

			if (!done)
				delay1 = delay2 = SDL_GetTicks();
			return done;
		}

		// Same as above, but used for the intermission
		public void EnoughFade()
		{
			delay1 = delay2 = SDL_GetTicks();

			if ((!done && delay1 > delay + buzzStep)
				&& fadeVal != 0)
				glClear(GL_COLOR_BUFFER_BIT);
			glMatrixMode(GL_MODELVIEW);
			glLoadIdentity();

			DrawArea(TXTSTS);

			glColor3fv(fgColor);

			if ((!done && delay1 > delay + buzzStep)
				&& fadeVal != 0)
			{
				// Set volume of buzz
				Mix_Volume(fadChannel, ((32 - VCTFAD) / 2) * (oslink.volumeLevel / 16));

				glLoadIdentity();
				DrawVectorList(W1_VLA);
				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();
				VCTFAD += fadeVal;
				if ((VCTFAD & 0x80) != 0)
				{
					DisplayEnough();
					DrawArea(TXTPRI);
					//SDL 2.0 Replaced
					//SDL_GL_SwapBuffers();
					oslink.SwapBuffers();

					// do sound crash
					Mix_HaltChannel(fadChannel);
					Mix_Volume(fadChannel, oslink.volumeLevel);
					Mix_PlayChannel(fadChannel, creature.kaboom, 0);
					while (Mix_Playing(fadChannel) == 1)
					{
						// Call keyboard routine ???
					}

					VCTFAD = 0;
					fadeVal = 0;
				}
				if (VCTFAD == 32
					&& fadeVal == 2)
				{
					done = true;
					ClearArea(TXTPRI);
					DrawArea(TXTPRI);
				}
				delay = SDL_GetTicks();
			}

			if (VCTFAD == 0
				&& fadeVal == 0)
			{
				glLoadIdentity();
				DrawVectorList(W1_VLA);
				VCTFAD += fadeVal;
				DrawArea(TXTPRI);
				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();
				delay2 = SDL_GetTicks();
				if (delay2 > delay + midPause)
				{
					// do sound crash
					Mix_PlayChannel(fadChannel, creature.kaboom, 0);
					while (Mix_Playing(fadChannel) == 1)
					{
						// Call keyboard routine ???
					}

					fadeVal = 2;
					delay = SDL_GetTicks();

					Mix_PlayChannel(fadChannel, creature.buzz, -1);
				}
			}

			if (!done)
				delay1 = delay2 = SDL_GetTicks();
		}

		// Same as above, but used for death & victory
		public void DeathFade(int[] WIZ)
		{
			delay1 = SDL_GetTicks();

			if ((delay1 > delay + buzzStep)
				&& fadeVal != 0)
			{
				// Set volume of buzz
				Mix_Volume(fadChannel, ((32 - VCTFAD) / 2) * (oslink.volumeLevel / 16));

				glClear(GL_COLOR_BUFFER_BIT);
				glMatrixMode(GL_MODELVIEW);
				glLoadIdentity();
				DrawArea(TXTSTS);
				glColor3fv(fgColor);
				glLoadIdentity();
				DrawVectorList(WIZ);
				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();
				VCTFAD += fadeVal;
				if ((VCTFAD & 0x80) != 0)
				{
					// do sound crash
					Mix_HaltChannel(fadChannel);
					Mix_Volume(fadChannel, oslink.volumeLevel);
					glLoadIdentity();
					DrawArea(TXTPRI);
					//SDL 2.0 Replaced
					//SDL_GL_SwapBuffers();
					oslink.SwapBuffers();
					Mix_PlayChannel(fadChannel, creature.kaboom, 0);
					while (Mix_Playing(fadChannel) == 1)
					{
						// Call keyboard routine ???
					}

					VCTFAD = 0;
					fadeVal = 0;
					done = true;
				}
				delay = SDL_GetTicks();
			}

			if (fadeVal == 0)
			{
				glLoadIdentity();
				DrawVectorList(WIZ);
				DrawArea(TXTPRI);
				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();
			}
		}
		public void DisplayCopyright()
		{
			TXB_U = TXTSTS;
			--TXBFLG;
			Outsti(ref copyright);
			TXBFLG = 0;
		}
		public void DisplayWelcomeMessage()
		{
			Outsti(ref welcome1);
			Outsti(ref welcome2);
		}
		public void DisplayDeath()
		{
			Outsti(ref death);
		}
		public void DisplayWinner()
		{
			Outsti(ref winner1);
			Outsti(ref winner2);
		}
		public void DisplayEnough()
		{
			Outsti(ref enough1);
			Outsti(ref enough2);
		}
		public void DisplayPrepare()
		{
			ClearArea(TXTEXA);
			TXB_U = TXTEXA;
			TXB_U.caret = (32 * 9) + 12;
			--TXBFLG;
			Outsti(ref prepstr);
			TXBFLG = 0;
		}
		public void DrawArea(Txb a)
		{
			int cnt = 0;

			if (a.top == 19)
			{
				glLoadIdentity();
				glColor3fv(fgColor);
				glBegin(GL_QUADS);
				glVertex2f(crd.newX(0 * 8), crd.newY(19 * 8));
				glVertex2f(crd.newX(32 * 8), crd.newY(19 * 8));
				glVertex2f(crd.newX(32 * 8), crd.newY((20 * 8)));
				glVertex2f(crd.newX(0 * 8), crd.newY((20 * 8)));
				glEnd();
				glColor3fv(bgColor);
			} else
			{
				glLoadIdentity();
				glColor3fv(bgColor);
				glBegin(GL_QUADS);
				glVertex2f(crd.newX(0 * 8), crd.newY(20 * 8));
				glVertex2f(crd.newX(33 * 8), crd.newY(20 * 8));
				glVertex2f(crd.newX(33 * 8), crd.newY((24 * 8)));
				glVertex2f(crd.newX(0 * 8), crd.newY((24 * 8)));
				glEnd();
				glColor3fv(fgColor);
			}

			while (cnt < a.len)
			{
				DrawString(0, a.top + cnt / 32, ref a.area.Substring(cnt), 32);
				cnt += 32;
			}
		}
		public void ClearArea(Txb a)
		{
			a.area = "                                ";
			int cnt = 32;
			while (cnt < a.len)
			{
				a.area += "                                ";
				cnt += 32;
			}
			a.caret = 0;
		}
		public void DrawTorchHighlite()
		{
			int x1;
			int y1;
			int x2;
			int y2;
			x1 = tcaret - ((tcaret / 32) * 32);
			y1 = tcaret / 32;
			x2 = x1 + tlen;
			y2 = y1 + 1;
			glLoadIdentity();
			glColor3fv(fgColor);
			glBegin(GL_QUADS);
			glVertex2f(crd.newX(x1 * 8), crd.newY(y1 * 8));
			glVertex2f(crd.newX(x2 * 8), crd.newY(y1 * 8));
			glVertex2f(crd.newX(x2 * 8), crd.newY(y2 * 8));
			glVertex2f(crd.newX(x1 * 8), crd.newY(y2 * 8));
			glEnd();
			glColor3fv(bgColor);
			@object.OBJNAM(player.PTORCH);
			DrawStringInternal(x1, y1, ref parser.TOKEN, tlen);
		}
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
//	void Wizin0();

		// This method checks if the screen needs updated.
		// Called from the scheduler every 3 tenths of a second.
		public int Luknew()
		{
			// Update Task's next_time
			scheduler.TCBLND[(int)Scheduler.AnonymousEnum2.TidRefreshDisp].next_time = scheduler.curTime + scheduler.TCBLND[(int)Scheduler.AnonymousEnum2.TidRefreshDisp].frequency;

			if (display_mode != (int)AnonymousEnum.ModeMap)
				return 0;

			NEWLUK = 0;
			Pupdat();
			return 0;
		}

		// Updates the screen.
		public void Pupdat()
		{
			if (player.FAINT != 0)
				return;

			Pupsub();

			--UPDATE;
			DrawGame();
		}

		// Sets lighting values.
		public void Pupsub()
		{
			byte A;
			byte B;
			A = player.PRLITE;
			B = player.PMLITE;

			if (player.PTORCH != -1)
			{
				A += @object.OCBLND[player.PTORCH].P_OCXX1;
				B += @object.OCBLND[player.PTORCH].P_OCXX2;
			}
			RLIGHT = A;
			MLIGHT = B;
		}

		// Updates the Left and Right hand in the status line
		public void Status()
		{
			int ctr;
			int len;
			int offset;
			int idx;
			for (ctr = 0; ctr < 15; ++ctr)
			{
				statArea[ctr] = ' ';
				statArea[ctr + 17] = ' ';
			}
			idx = ((player.PLHAND & 0x8000) != 0) ? -1 : player.PLHAND;
			@object.OBJNAM(idx);
			ctr = 0;
			while (parser.TOKEN[ctr] != 0xFF)
			{
				if (parser.TOKEN[ctr] == 0)
					statArea[ctr] = ' ';
				else
					statArea[ctr] = parser.TOKEN[ctr] | 64;
				++ctr;
			}
			idx = ((player.PRHAND & 0x8000) != 0) ? -1 : player.PRHAND;
			@object.OBJNAM(idx);

			ctr = 0;
			while (parser.TOKEN[ctr] != 0xFF)
				++ctr;

			len = ctr;
			ctr = 32 - len;
			offset = ctr;
			while (ctr < 32)
			{
				if (parser.TOKEN[ctr - offset] == 0)
					statArea[ctr] = ' ';
				else
					statArea[ctr] = parser.TOKEN[ctr - offset] | 64;
				++ctr;
			}
		}
		public void Prompt()
		{
			Outstr(ref parser.M_PROM1);
		}
		public void Examin()
		{
			TXB_U = TXTEXA;
			--TXBFLG;
			NEWLIN = 0;
			TXB_U.caret = 10;
			Outsti(ref exam1);

			// check for creature
			if (creature.CFIND2(new RowCol(player.PROW, player.PCOL)) != -1)
			{
				TXB_U.caret += 11;
				Outsti(ref exam2);
			}

			// check for objects on floor
			int idx;
			@object.OFINDF = 0;
			do
			{
				idx = @object.OFIND(new RowCol(player.PROW, player.PCOL));
				if (idx != -1)
					Prtobj(idx, false);
			} while (idx != -1);

			if (NEWLIN != 0)
				Pcrlf();

			int ctr = 32;
			do
			{
				Outchr(parser.I_EXCL);
				--ctr;
			} while (ctr != 0);

			TXB_U.caret += 12;
			Outsti(ref exam3);

			// bag contents
			ctr = player.BAGPTR;
			while (ctr != -1)
			{
				// check for torch
				if (ctr == player.PTORCH)
					Prtobj(ctr, true);
				else
					Prtobj(ctr, false);
				ctr = @object.OCBLND[ctr].P_OCPTR;
			}

			TXBFLG = 0;
		}
		public void Pcrlf()
		{
			Outchr(parser.I_CR);
			NEWLIN = 0;
		}
		public void Prtobj(int X, bool highlite)
		{
			@object.OBJNAM(X);
			if (highlite)
			{
				tcaret = TXB_U.caret;
				int ctr = 0;
				while (parser.TOKEN[ctr] != 0xFF)
					++ctr;
				tlen = ctr;
			}
			Outstr(ref parser.TOKEN);
			NEWLIN = (~NEWLIN);
			if (NEWLIN != 0)
			{
				TXB_U.caret += 16;
				TXB_U.caret = (TXB_U.caret / 16) * 16;
			} else
			{
				Pcrlf();
			}
		}
		public void Outsti(ref byte comp)
		{
			int c;
			parser.EXPAND(comp, c, 0);
			Outstr(ref parser.STRING[1]);
		}
		public void Outstr(ref byte str)
		{
			int ctr = 0;
			while (*(str + ctr) != 0xFF)
			{
				Outchr(*(str + ctr));
				++ctr;
			}
		}
		public void Outchr(byte c)
		{
			if (TXBFLG == 0)
				TXB_U = TXTPRI;

			Txtxxx(c);
			if (TXB_U.caret == TXB_U.len
				&& TXB_U.top != 19)
				Txtscr();
			--UPDATE;
		}
		public void Txtxxx(byte c)
		{
			if (c == parser.I_BS)
			{
				// backspace
				if (TXB_U.caret > 0)
					TXB_U.caret -= 1;
				return;
			}
			if (c == parser.I_CR)
			{
				// carriage return
				TXB_U.caret += 32;
				TXB_U.caret = 32 * (TXB_U.caret / 32);
				return;
			}

			if (c == parser.I_SP)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, ' ');
			else if (c >= 1
				&& c <= 26)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, (c | 64));
			else if (c == parser.I_EXCL)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, '!');
			else if (c == parser.I_BAR)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, '_');
			else if (c == parser.I_QUES)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, '?');
			else if (c == parser.I_DOT)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, '.');
			else if (c == parser.I_SHL)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, '<');
			else if (c == parser.I_SHR)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, '>');
			else if (c == parser.I_LHL)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, '{');
			else if (c == parser.I_LHR)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, TXB_U.caret, '}');

			++TXB_U.caret;
		}
		public void Txtscr()
		{
			int ctr;
			for (ctr = 0; ctr < TXB_U.len - 32; ++ctr)
				TXB_U.area = StringFunctions.ChangeCharacter(TXB_U.area, ctr, TXB_U.area[ctr + 32]);
			for (ctr = TXB_U.len - 32; ctr < TXB_U.len; ++ctr)
				TXB_U.area = TXB_U.area.Substring(0, ctr);
			TXB_U.caret = TXB_U.len - 32;
			if (player.PTORCH != -1
				&& TXB_U.len > 128)
				tcaret -= 32;
		}

		// This is the 3D-Viewport rendering routine
		public void Viewer()
		{
			byte a;
			byte b;
			byte x;
			byte u;
			byte ftctr;
			byte vft;
			int creNum;
			int objIdx;

			RANGE = 0;
			dungeon.DROW.setRC(player.PROW, player.PCOL);

			do
			{
				Setscl();
				a = dungeon.MAZLND[dungeon.RC2IDX(dungeon.DROW.row, dungeon.DROW.col)];
				u = 0;
				x = 4;
				do
				{
					b = a;
					b = (b & 3);
					dungeon.NEIBOR[u + 4] = b;
					dungeon.NEIBOR[u] = b;
					++u;
					a >>= 2;
					--x;
				} while (x != 0);

				b = player.PDIR;
				u = b;

				for (ftctr = 0; ftctr < 3; ++ftctr)
				{
					b = dungeon.NEIBOR[u + FLATAB[ftctr]];
					if (b == dungeon.HF_SDR)
					{
						--MAGFLG;
						Drawit(ref FLATABv[ftctr][b]);
						b = dungeon.HF_WAL;
					}
					Drawit(ref FLATABv[ftctr][b]);
				}

				creNum = creature.CFIND2(dungeon.DROW);
				if (creNum != -1)
					Cmrdrw(ref FWDCRE[creature.CCBLND[creNum].creature_id], creNum);

				Pdraw(ref LPK_VLA, 3, u);
				Pdraw(ref RPK_VLA, 1, u);

				// Draw vertical features
				vft = dungeon.VFIND(dungeon.DROW);
				if (vft == (int)Dungeon.AnonymousEnum5.VfNull)
					Drawit(ref CEI_VLA);
				else
				{
					switch (vft)
					{
					case Dungeon.AnonymousEnum5.VfHoleUp:
						Drawit(ref HUP_VLA);
						break;
					case Dungeon.AnonymousEnum5.VfLadderUp:
						Drawit(ref LAD_VLA);
						Drawit(ref HUP_VLA);
						break;
					case Dungeon.AnonymousEnum5.VfHoleDown:
						Drawit(ref HDN_VLA);
						Drawit(ref CEI_VLA);
						break;
					case Dungeon.AnonymousEnum5.VfLadderDown:
						Drawit(ref LAD_VLA);
						Drawit(ref HDN_VLA);
						Drawit(ref CEI_VLA);
						break;
					default:
						break; // should never get here
						break;
					}
				}

				// Draw Objects
				@object.OFINDF = 0;
				do
				{
					objIdx = @object.OFIND(dungeon.DROW);
					if (objIdx == -1)
						break;
					--MAGFLG;
					Drawit(ref FWDOBJ[@object.OCBLND[objIdx].obj_type]);
					Drawit(ref FWDOBJ[@object.OCBLND[objIdx].obj_type]);
				} while (true);


				if (dungeon.NEIBOR[u] != 0)
					break;
				dungeon.DROW.row += dungeon.STPTAB[player.PDIR * 2];
				dungeon.DROW.col += dungeon.STPTAB[player.PDIR * 2 + 1];
				++RANGE;
			} while (RANGE <= 9);
		}

		// Sets the perspective scale
		public void Setscl()
		{
			int idx = HLFSCL;
			if (HLFSTP == 0)
			{
				++idx;
				if (BAKSTP == 0)
					idx = 0;
			}
			VXSCAL = Scale[idx + RANGE];
			VYSCAL = Scale[idx + RANGE];
			VXSCALf = Scalef[idx + RANGE];
			VYSCALf = Scalef[idx + RANGE];
		}

		// Used by 3D-Viewer, draws a vector list
		public void Drawit(ref int vl)
		{
			Setfad();
			DrawVectorList(vl);
		}

		// Used by 3D-Viewer, checks for around-the-corner creature
		public void Pdraw(ref int vl, byte dir, byte pdir)
		{
			RowCol side = new RowCol();
			byte DIR;
			int creNum;
			if (dungeon.NEIBOR[pdir + dir] != 0)
				return;
			DIR = ((dir + player.PDIR) & 3);
			side.row = dungeon.DROW.row + dungeon.STPTAB[DIR * 2];
			side.col = dungeon.DROW.col + dungeon.STPTAB[DIR * 2 + 1];
			creNum = creature.CFIND2(side);
			if (creNum == -1)
				return;
			Cmrdrw(ref vl, creNum);
		}

		// Prepares for drawing creature with either magical or physical lighting
		public void Cmrdrw(ref int vl, int creNum)
		{
			if (creature.CCBLND[creNum].P_CCMGO != 0)
				--MAGFLG;
			Drawit(ref vl);
		}

		// Calculates fade (line-pixelation) based on lighting
		public void Setfad()
		{
			byte a;
			byte b;
			a = RLIGHT;
			if (MAGFLG != 0)
			{
				a = MLIGHT;
				MAGFLG = 0;
			}
			b = 0;
			a -= 7;
			a -= RANGE;
			if ((a & 128) != 0)
			{
				--b;
				if ((((a & 128) != 0) && a > 0xF9) //    if (a > -7)
					|| ((a & 128) == 0))
					b = (1 << (-1 - a));
			}
			VCTFAD = b;
		}

		// Scales X-coordinate
		public ushort ScaleX(int x)
		{
			return ((x - VCNTRX) * VXSCAL) / 127;
		}

		// Scales Y-coordinate
		public ushort ScaleY(int y)
		{
			return ((y - VCNTRY) * VYSCAL) / 127;

		}
		public float ScaleXf(float x)
		{
			return ((x - (float)VCNTRX) * VXSCALf) / 127.0f;
		}
		public float ScaleYf(float y)
		{
			return ((y - VCNTRY) * VYSCALf) / 127.0f;
		}

		// Draws the map; showSeerMap bool determines VISION or SEER mode
		public void Mapper()
		{
			int mazIdx;
			int objIdx;
			int creIdx;
			int vftIdx;
			float DoorOffset;
			RowCol rc = new RowCol();
			byte a;
			bool vftOnce;

			dungeon.DROW.row = 31;
			dungeon.DROW.col = 31;
			glColor3f(0.0,0.0,0.0);
			do
			{
				mazIdx = dungeon.RC2IDX(dungeon.DROW.row, dungeon.DROW.col);
				if (dungeon.MAZLND[mazIdx] != 0xFF)
				{
					glBegin(GL_QUADS);
					glVertex2f(crd.newX(dungeon.DROW.col * 8), crd.newY(dungeon.DROW.row * 6));
					glVertex2f(crd.newX(dungeon.DROW.col * 8), crd.newY((dungeon.DROW.row + 1) * 6));
					glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8), crd.newY((dungeon.DROW.row + 1) * 6));
					glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8), crd.newY(dungeon.DROW.row * 6));
					glEnd();
					if (game.MarkDoorsOnScrollMaps)
					{ //Do we need to mark the doors on the scroll maps?
						if ((dungeon.MAZLND[mazIdx] & 0x0c) == (0x01 << 2)
							|| (dungeon.MAZLND[mazIdx] & 0x0c) == (0x02 << 2))
						{ //Do we have a east door or secret door?
							DoorOffset = ((dungeon.MAZLND[mazIdx] | 0xcc) != 0xff); //Move door line over one into next room if we don't have wall on either side.
							DoorOffset = DoorOffset / 4;
							glColor3f(1.0,1.0,1.0);
							if ((dungeon.MAZLND[mazIdx] & 0x0c) == (0x01 << 2))
							{ //Is this a regular door?  Yes:
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + DoorOffset), crd.newY(dungeon.DROW.row * 6));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 2.5));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 4));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + DoorOffset), crd.newY((dungeon.DROW.row + 1) * 6));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 2.5));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 - 1 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 2.5));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 - 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 2.5));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 - 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 4));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 4));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 2.5));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 - 1 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 4));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 4));
								glEnd();
							} else
							{ //Is this a regular door?  No:
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + DoorOffset), crd.newY(dungeon.DROW.row * 6));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 1.75));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 4.5));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + DoorOffset), crd.newY((dungeon.DROW.row + 1) * 6));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 2.25));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 - 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 2.25));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 - 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 2.25));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 - 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 3));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + 0.5 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 3.25));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 - 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 3.25));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 3.25));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + 0.75 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 4));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 - 1 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 4.25));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8 + 0.5 + DoorOffset), crd.newY(dungeon.DROW.row * 6 + 4.25));
								glEnd();
							} //Is this a regular door?
							glColor3f(0.0,0.0,0.0);
						} //Do we have a east door or secret door?
						if ((dungeon.MAZLND[mazIdx] & 0x30) == (0x01 << 4)
							|| (dungeon.MAZLND[mazIdx] & 0x30) == (0x02 << 4))
						{ //Do we have a south door or secret door?
							DoorOffset = ((dungeon.MAZLND[mazIdx] | 0x33) != 0xff); //Move door line over one into next room if we don't have wall on either side.
							DoorOffset = DoorOffset / 4;
							glColor3f(1.0,1.0,1.0);
							if ((dungeon.MAZLND[mazIdx] & 0x30) == (0x01 << 4))
							{ //Is this a regular door?  Yes:
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3.25), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.75), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3), crd.newY((dungeon.DROW.row + 1) * 6 - 0.75 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.75), crd.newY((dungeon.DROW.row + 1) * 6 - 0.75 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.75), crd.newY((dungeon.DROW.row + 1) * 6 - 0.75 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.75), crd.newY((dungeon.DROW.row + 1) * 6 + 0.75 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3.25), crd.newY((dungeon.DROW.row + 1) * 6 + 0.75 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3.25), crd.newY((dungeon.DROW.row + 1) * 6 - 0.75 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3.25), crd.newY((dungeon.DROW.row + 1) * 6 + 0.75 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.75), crd.newY((dungeon.DROW.row + 1) * 6 + 0.75 + DoorOffset));
								glEnd();
							} else
							{ //Is this a regular door?  No:
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 2.75), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 5), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glVertex2f(crd.newX((dungeon.DROW.col + 1) * 8), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3.25), crd.newY((dungeon.DROW.row + 1) * 6 - 1 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.75), crd.newY((dungeon.DROW.row + 1) * 6 - 1 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3.25), crd.newY((dungeon.DROW.row + 1) * 6 - 1 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3.25), crd.newY((dungeon.DROW.row + 1) * 6 - 0.25 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3.25), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.5), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.75), crd.newY((dungeon.DROW.row + 1) * 6 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.75), crd.newY((dungeon.DROW.row + 1) * 6 + 0.75 + DoorOffset));
								glEnd();
								glBegin(GL_LINES);
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 3), crd.newY((dungeon.DROW.row + 1) * 6 + 1 + DoorOffset));
								glVertex2f(crd.newX(dungeon.DROW.col * 8 + 4.5), crd.newY((dungeon.DROW.row + 1) * 6 + 1 + DoorOffset));
								glEnd();

							}
							glColor3f(0.0,0.0,0.0);
						} //Do we have a south door or secret door?
					} //Do we need to mark the doors on the scroll maps?
				}
				--dungeon.DROW.col;
				if (dungeon.DROW.col == 0xFF)
				{
					--dungeon.DROW.row;
					dungeon.DROW.col = 31;
				}
			} while (dungeon.DROW.row != 0xFF);

			glColor3f(1.0,1.0,1.0);
			if (showSeerMap == true)
			{
				// Mark Objects
				@object.OFINDF = 0;
				do
				{
					objIdx = @object.FNDOBJ();
					if (objIdx == -1)
						break;
					if (@object.OCBLND[objIdx].P_OCOWN != 0)
						continue;
					rc.row = @object.OCBLND[objIdx].P_OCROW;
					rc.col = @object.OCBLND[objIdx].P_OCCOL;
					glBegin(GL_QUADS);
					glVertex2f(crd.newX((rc.col * 8) + 4), crd.newY((rc.row * 6) + 2));
					glVertex2f(crd.newX((rc.col * 8) + 4), crd.newY((rc.row * 6) + 4));
					glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 4));
					glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 2));
					glEnd();
				} while (true);

				// Mark Creatures
				creIdx = -1;
				do
				{
					++creIdx;
					if (creIdx == 32)
						break;
					if (creature.CCBLND[creIdx].P_CCUSE == 0)
						continue;
					rc.row = creature.CCBLND[creIdx].P_CCROW;
					rc.col = creature.CCBLND[creIdx].P_CCCOL;
					glBegin(GL_QUADS);
					glVertex2f(crd.newX((rc.col * 8) + 1), crd.newY((rc.row * 6) + 2));
					glVertex2f(crd.newX((rc.col * 8) + 1), crd.newY((rc.row * 6) + 4));
					glVertex2f(crd.newX((rc.col * 8) + 2), crd.newY((rc.row * 6) + 4));
					glVertex2f(crd.newX((rc.col * 8) + 2), crd.newY((rc.row * 6) + 2));

					glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 2));
					glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 4));
					glVertex2f(crd.newX((rc.col * 8) + 6), crd.newY((rc.row * 6) + 4));
					glVertex2f(crd.newX((rc.col * 8) + 6), crd.newY((rc.row * 6) + 2));

					glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 1));
					glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 5));
					glVertex2f(crd.newX((rc.col * 8) + 4), crd.newY((rc.row * 6) + 5));
					glVertex2f(crd.newX((rc.col * 8) + 4), crd.newY((rc.row * 6) + 1));
					glEnd();
				} while (true);
			}

			// Mark Player
			rc.row = player.PROW;
			rc.col = player.PCOL;
			glBegin(GL_QUADS);
			glVertex2f(crd.newX((rc.col * 8) + 2), crd.newY((rc.row * 6) + 1));
			glVertex2f(crd.newX((rc.col * 8) + 2), crd.newY((rc.row * 6) + 2));
			glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 2));
			glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 1));

			glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 1));
			glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 2));
			glVertex2f(crd.newX((rc.col * 8) + 6), crd.newY((rc.row * 6) + 2));
			glVertex2f(crd.newX((rc.col * 8) + 6), crd.newY((rc.row * 6) + 1));

			glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 2));
			glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 4));
			glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 4));
			glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 2));

			glVertex2f(crd.newX((rc.col * 8) + 2), crd.newY((rc.row * 6) + 4));
			glVertex2f(crd.newX((rc.col * 8) + 2), crd.newY((rc.row * 6) + 5));
			glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 5));
			glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 4));

			glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 4));
			glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 5));
			glVertex2f(crd.newX((rc.col * 8) + 6), crd.newY((rc.row * 6) + 5));
			glVertex2f(crd.newX((rc.col * 8) + 6), crd.newY((rc.row * 6) + 4));
			glEnd();

			// Mark Vertical Features
			vftIdx = dungeon.VFTPTR;
			vftOnce = false;
			do
			{
				a = dungeon.VFTTAB[vftIdx++];
				if (a == 0xFF)
				{
					if (vftOnce == false)
					{
						vftOnce = true;
						continue;
					} else
					{
						break;
					}
				}
				rc.row = dungeon.VFTTAB[vftIdx++];
				rc.col = dungeon.VFTTAB[vftIdx++];

				glBegin(GL_QUADS);
				glVertex2f(crd.newX((rc.col * 8) + 2), crd.newY((rc.row * 6) + 1));
				glVertex2f(crd.newX((rc.col * 8) + 2), crd.newY((rc.row * 6) + 5));
				glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 5));
				glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 1));

				glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 1));
				glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 5));
				glVertex2f(crd.newX((rc.col * 8) + 6), crd.newY((rc.row * 6) + 5));
				glVertex2f(crd.newX((rc.col * 8) + 6), crd.newY((rc.row * 6) + 1));

				glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 1));
				glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 2));
				glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 2));
				glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 1));

				glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 4));
				glVertex2f(crd.newX((rc.col * 8) + 3), crd.newY((rc.row * 6) + 5));
				glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 5));
				glVertex2f(crd.newX((rc.col * 8) + 5), crd.newY((rc.row * 6) + 4));
				glEnd();

			} while (true);
		}
		public void SetVidInv(bool inv)
		{
			if (!inv)
			{
				// white on black
				bgColor[0] = 0.0;
				bgColor[1] = 0.0;
				bgColor[2] = 0.0;

				fgColor[0] = 1.0;
				fgColor[1] = 1.0;
				fgColor[2] = 1.0;
			} else
			{
				// black on white
				bgColor[0] = 1.0;
				bgColor[1] = 1.0;
				bgColor[2] = 1.0;

				fgColor[0] = 0.0;
				fgColor[1] = 0.0;
				fgColor[2] = 0.0;
			}
			if (GlobalMembers.ClearColor == 1)
				glClearColor(bgColor[0], bgColor[1], bgColor[2], 0.0);
		}

		// Draws non-font vector lists
		public void DrawVectorList(int[] VLA)
		{
			int numLists = VLA[0];
			int curList = 0;
			int numVertices;
			int curVertex;
			int ctr = 1;

			if (VCTFAD == 0xFF)
				return;

			while (curList < numLists)
			{
				numVertices = VLA[ctr];
				++ctr;
				curVertex = 0;
				while (curVertex < (numVertices - 1))
				{
					if ((g_options & ((int)AnonymousEnum8.OptVector | (int)AnonymousEnum8.OptHires)) != 0)
					{
						float x0;
						float y0;
						float x1;
						float y1;
						x0 = ScaleXf((float)VLA[ctr]) + (float)VCNTRX;
						y0 = ScaleYf((float)VLA[ctr + 1]) + (float)VCNTRY;
						x1 = ScaleXf((float)VLA[ctr + 2]) + (float)VCNTRX;
						y1 = ScaleYf((float)VLA[ctr + 3]) + (float)VCNTRY;
						DrawVector(x0, y0, x1, y1);
					} else
					{
						float x0;
						float y0;
						float x1;
						float y1;
						x0 = ScaleXf((float)VLA[ctr]) + (float)VCNTRX;
						y0 = ScaleYf((float)VLA[ctr + 1]) + (float)VCNTRY;
						x1 = ScaleXf((float)VLA[ctr + 2]) + (float)VCNTRX;
						y1 = ScaleYf((float)VLA[ctr + 3]) + (float)VCNTRY;
						DrawVector((float)(int)x0, (float)(int)y0, (float)(int)x1, (float)(int)y1);
		//				dodSHORT x0, y0, x1, y1;
		//				x0 = ScaleX(VLA[ctr]) + VCNTRX;
		//				y0 = ScaleY(VLA[ctr+1]) + VCNTRY;
		//				x1 = ScaleX(VLA[ctr+2]) + VCNTRX;
		//				y1 = ScaleY(VLA[ctr+3]) + VCNTRY;
		//				drawVector(x0, y0, x1, y1);
					}
					ctr += 2;
					++curVertex;
				}
				++curList;
				ctr += 2;
			}
		}

		// Draws a line
		public void DrawVector(float X0, float Y0, float X1, float Y1)
		{
			if ((g_options & (int)AnonymousEnum8.OptVector) != 0)
			{ // draw using GL vectors
				GLfloat[] clrLine = Arrays.InitializeWithDefaultInstances<GLfloat>(3);

				if (VCTFAD == 0xff)
					return; // do not draw lines with VCTFAD=255

				// calculate line color from VCTFAD
				float flBirghtness = 1.0f / (VCTFAD / 2.0f + 1.0f);
				// calculate color between FG and BG
				clrLine[0] = fgColor[0] * flBirghtness + bgColor[0] * (1.0f - flBirghtness);
				clrLine[1] = fgColor[1] * flBirghtness + bgColor[1] * (1.0f - flBirghtness);
				clrLine[2] = fgColor[2] * flBirghtness + bgColor[2] * (1.0f - flBirghtness);

				// draw the vector
				glBegin(GL_LINES);
				glColor3fv(clrLine);
				glVertex2f(crd.newX(X0),crd.newY(Y0));
				glVertex2f(crd.newX(X1),crd.newY(Y1));
				glColor3fv(fgColor);
				glEnd();
			} else
			{
				float XL;
				float YL;
				float L;
				int FADCNT;
				double DX;
				double DY;
				double XX;
				double YY;

				if (VCTFAD == 0xFF)
					return;
				FADCNT = VCTFAD + 1;
				XL = (X1 > X0) ? (X1 - X0) : (X0 - X1);
				YL = (Y1 > Y0) ? (Y1 - Y0) : (Y0 - Y1);
				L = (XL > YL) ? XL : YL;
				if (L == 0F)
					return;
				DX = ((double) XL / (double) L) * ((X0 < X1) ? 1 : -1);
				DY = ((double) YL / (double) L) * ((Y0 < Y1) ? 1 : -1);
				if ((g_options & (int)AnonymousEnum8.OptHires) != 0)
				{ // prepare to draw a HIRES line
					// in hires mode, all we need to do is increase the # pixels per line.
					// we are scaling up accoring to the screen width
					int scale = oslink.width >> 8;
					DX /= (double)scale;
					DY /= (double)scale;
					L *= scale;
				}
				XX = X0 + 0.5;
				YY = Y0 + 0.5;
				do
				{
					if (--FADCNT == 0)
					{
						FADCNT = VCTFAD + 1;
						if (XX >= 0.0
							&& XX < 256.0
							&& YY >= 0.0
							&& YY < 152.0)
						{
							if ((g_options & (int)AnonymousEnum8.OptHires) != 0)
								PlotPoint(XX, YY);
							else
								PlotPoint((int)XX, (int)YY);
						}
					}
					XX += DX;
					YY += DY;
					--L;
				} while (L > 0F);
			}
		}
		public void Reset()
		{
			showSeerMap = true;
			SetVidInv(false);
			UPDATE = 0;
			display_mode = (int)AnonymousEnum.ModeTitle;
			HLFSTP = 0;
			BAKSTP = 0;
			MAGFLG = 0;
			PASFLG = 0;
			NORSCL = 0;
			HLFSCL = 10;
			BAKSCL = 11;
			TXBFLG = 0;
			TXB_U = null;
			tcaret = 0;
			tlen = 0;
			RLIGHT = 0;
			MLIGHT = 0;
			VCTFAD = 32;
			delay = 0;
			done = false;
			fadeVal = -2;
			ClearArea(TXTPRI);
			ClearArea(TXTEXA);
			ClearArea(TXTSTS);
		}

		// This method renders the wizard fade in/out animations.
		// The parameter fadeMode indicates which of the four fades
		// to do:
		//   1 = Beginning before game starts
		//   2 = Intermission after killing wizards image
		//   3 = Death
		//   4 = Victory
		public bool ShowFade(int fadeMode)
		{
			uint ticks1;
			uint ticks2;
			SDL_Event event = new SDL_Event();
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: int * wiz;
			int wiz;
			VXSCAL = 0x80;
			VYSCAL = 0x80;

			ClearArea(TXTPRI);

			switch (fadeMode)
			{
			case 1:
				wiz = W1_VLA;
				DisplayCopyright();
				DisplayWelcomeMessage();
				break;
			case 2:
				wiz = W1_VLA;
				ClearArea(TXTSTS);
				DisplayEnough();
				break;
			case 3:
				wiz = W1_VLA;
				ClearArea(TXTSTS);
				DisplayDeath();
				break;
			case 4:
				wiz = W2_VLA;
				ClearArea(TXTSTS);
				DisplayWinner();
				break;
			}

	//C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
			while (SDL_PollEvent(event)) // clear event buffer
				;

			RANGE = 1;
			Setscl();

			// Start buzz
			Mix_Volume(fadChannel, 0);
			Mix_PlayChannel(fadChannel, creature.buzz, -1);

			for (VCTFAD = 32; (VCTFAD & 128) == 0; VCTFAD -= 2)
			{
				// Set volume of buzz
				Mix_Volume(fadChannel, ((32 - VCTFAD) / 2) * (oslink.volumeLevel / 16));

				glClear(GL_COLOR_BUFFER_BIT);
				glMatrixMode(GL_MODELVIEW);
				glLoadIdentity();
				DrawArea(TXTSTS);
				glColor3fv(fgColor);
				glLoadIdentity();
				DrawVectorList(wiz);
				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();

				ticks1 = SDL_GetTicks();
				do
				{
					ticks2 = SDL_GetTicks();
					if (fadeMode == 1
						&& scheduler.keyCheck())
					{
						Mix_HaltChannel(fadChannel);
						ClearArea(TXTPRI);
	//C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
						while (SDL_PollEvent(event)) // clear event buffer
							;
						return false;
					}
				} while (ticks2 < ticks1 + buzzStep);
			}

			VCTFAD = 0;

			// do crash
			Mix_HaltChannel(fadChannel);
			Mix_Volume(fadChannel, oslink.volumeLevel);
			Mix_PlayChannel(fadChannel, creature.kaboom, 0);
			while (Mix_Playing(fadChannel) == 1)
			{
				if (fadeMode == 1
					&& scheduler.keyCheck())
				{
					Mix_HaltChannel(fadChannel);
					ClearArea(TXTPRI);
	//C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
					while (SDL_PollEvent(event)) // clear event buffer
						;
					return false;
				}
			}

			// show message
			glClear(GL_COLOR_BUFFER_BIT);
			glMatrixMode(GL_MODELVIEW);
			glLoadIdentity();
			DrawArea(TXTSTS);
			glColor3fv(fgColor);
			glLoadIdentity();
			DrawVectorList(wiz);
			DrawArea(TXTPRI);
			//SDL 2.0 Replaced
			//SDL_GL_SwapBuffers();
			oslink.SwapBuffers();

			if (fadeMode < 3)
			{
				// pause with wiz, status, and message
				ticks1 = SDL_GetTicks();
				do
				{
					ticks2 = SDL_GetTicks();

					glClear(GL_COLOR_BUFFER_BIT);
					glMatrixMode(GL_MODELVIEW);
					glLoadIdentity();
					DrawArea(TXTSTS);
					glColor3fv(fgColor);
					glLoadIdentity();
					DrawVectorList(wiz);
					DrawArea(TXTPRI);
					//SDL 2.0 Replaced
					//SDL_GL_SwapBuffers();
					oslink.SwapBuffers();

					if (fadeMode != 2
						&& scheduler.keyCheck())
					{
						ClearArea(TXTPRI);
	//C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
						while (SDL_PollEvent(event)) // clear event buffer
							;
						return false;
					}
				} while (ticks2 < ticks1 + midPause);

				// erase message
				glClear(GL_COLOR_BUFFER_BIT);
				glMatrixMode(GL_MODELVIEW);
				glLoadIdentity();
				DrawArea(TXTSTS);
				glColor3fv(fgColor);
				glLoadIdentity();
				DrawVectorList(wiz);
				//SDL 2.0 Replaced
				//SDL_GL_SwapBuffers();
				oslink.SwapBuffers();

				// do crash
				Mix_PlayChannel(fadChannel, creature.kaboom, 0);
				while (Mix_Playing(fadChannel) == 1)
				{
					if (fadeMode != 2
						&& scheduler.keyCheck())
					{
						Mix_HaltChannel(fadChannel);
						ClearArea(TXTPRI);
	//C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
						while (SDL_PollEvent(event)) // clear event buffer
							;
						return false;
					}
				}

				// start buzz again
				Mix_Volume(fadChannel, 0);
				Mix_PlayChannel(fadChannel, creature.buzz, -1);

				for (VCTFAD = 0; VCTFAD <= 32; VCTFAD += 2)
				{
					// Set volume of buzz
					Mix_Volume(fadChannel, ((32 - VCTFAD) / 2) * (oslink.volumeLevel / 16));

					glClear(GL_COLOR_BUFFER_BIT);
					glMatrixMode(GL_MODELVIEW);
					glLoadIdentity();
					DrawArea(TXTSTS);
					glColor3fv(fgColor);
					glLoadIdentity();
					DrawVectorList(wiz);
					//SDL 2.0 Replaced
					//SDL_GL_SwapBuffers();
					oslink.SwapBuffers();

					ticks1 = SDL_GetTicks();
					do
					{
						ticks2 = SDL_GetTicks();
						if (fadeMode != 2
							&& scheduler.keyCheck())
						{
							Mix_HaltChannel(fadChannel);
							ClearArea(TXTPRI);
	//C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
							while (SDL_PollEvent(event)) // clear event buffer
								;
							return false;
						}
					} while (ticks2 < ticks1 + buzzStep);
				}
			}

			Mix_HaltChannel(fadChannel);

			if (fadeMode < 3)
			{
				ClearArea(TXTPRI);
	//C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
				while (SDL_PollEvent(event)) // clear event buffer
					;
				return true;
			} else
			{
				while (!scheduler.keyCheck()) // Wait for a key
				{
					glClear(GL_COLOR_BUFFER_BIT);
					glMatrixMode(GL_MODELVIEW);
					glLoadIdentity();
					DrawArea(TXTSTS);
					glColor3fv(fgColor);
					glLoadIdentity();
					DrawVectorList(wiz);
					DrawArea(TXTPRI);
					//SDL 2.0 Replaced
					//SDL_GL_SwapBuffers();
					oslink.SwapBuffers();
				}
				ClearArea(TXTPRI);
	//C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
				while (SDL_PollEvent(event)) // clear event buffer
					;
				return false;
			}
		}

		/****************************************************************
		  Member: drawMenu
		
		  Vars:   menu_id   - the menu number to draw
		          highlight - the menu item to highlight
		
		  Function: Draws the menu
		****************************************************************/
		public void DrawMenu(Menu mainMenu, int menu_id, int highlight)
		{
		 int x;
		 int y;
		 int length;

		 // Clear screen
		 glColor3fv(bgColor);
		 glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

		  // Draw Boxes for menu
		 glColor3fv(fgColor);
		 glLoadIdentity();

		  // Draw Menu Items
		 DrawString(menu_id * 5, 0, ref mainMenu.GetMenuName(menu_id), Convert.ToString(mainMenu.GetMenuName(menu_id)).Length);

		 for (int i = 0; i < mainMenu.GetMenuSize(menu_id); i++)
		 {
		   x = menu_id * 5;
		   y = i + 2;
		   length = Convert.ToString(mainMenu.GetMenuItem(menu_id, i)).Length;

		   if (i == highlight)
		   {
			 glColor3fv(fgColor);
			 glLoadIdentity();
			 glBegin(GL_QUADS);
			 glVertex2f(crd.newX(x * 8), crd.newY(y * 8));
			 glVertex2f(crd.newX((x + length) * 8), crd.newY(y * 8));
			 glVertex2f(crd.newX((x + length) * 8), crd.newY((y + 1) * 8));
			 glVertex2f(crd.newX(x * 8), crd.newY((y + 1) * 8));
			 glEnd();
			 glColor3fv(bgColor);
		   }

		   DrawString(x, y, ref mainMenu.GetMenuItem(menu_id, i), length);
		   glColor3fv(fgColor);
		 }

		  // Update the screen
		  //SDL 2.0 Replaced
		  //SDL_GL_SwapBuffers();
		  oslink.SwapBuffers();
		}

		/****************************************************************
		  Member: drawMenuList
		
		  Vars:   x         - the top-left x-coordinate
		          y         - the top-left y-coordinate
			  title     - the title of the list
			  list      - the list to be drawn
			  listSize  - the size of the list
			  highlight - the item that's highlighted
		
		  Function: Draws a menu list
		****************************************************************/
		public void DrawMenuList(int x, int y, ref string title, string[] list, int listSize, int highlight)
		{
		 int length;

		  // Clear screen
		 glColor3fv(bgColor);
		 glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		 glColor3fv(fgColor);

		 DrawString(x, y, ref title, title.Length);
		 y += 2;

		  // Draw Menu Items
		 for (int i = 0; i < listSize; i++, y++)
		 {
		   length = list[i].Length;

		   if (i == highlight)
		   {
			 glColor3fv(fgColor);
			 glLoadIdentity();
			 glBegin(GL_QUADS);
			 glVertex2f(crd.newX(x * 8), crd.newY(y * 8));
			 glVertex2f(crd.newX((x + length) * 8), crd.newY(y * 8));
			 glVertex2f(crd.newX((x + length) * 8), crd.newY((y + 1) * 8));
			 glVertex2f(crd.newX(x * 8), crd.newY((y + 1) * 8));
			 glEnd();
			 glColor3fv(bgColor);
		   }

		   DrawString(x, y, ref list[i], length);
		   glColor3fv(fgColor);
		 }

		  // Update the screen
		  //SDL 2.0 Replaced
		  //SDL_GL_SwapBuffers();
		  oslink.SwapBuffers();
		}

		/****************************************************************
		  Member: drawMenuScrollbar
		
		  Vars:   title   - the title of the scrollbar
		          current - the current percentage
		
		  Function: Draws a menu scroll bar
		****************************************************************/
		public void DrawMenuScrollbar(ref string title, int current)
		{
		 int x;

			// Clear screen
		 glColor4fv(bgColor);
		 glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		 glColor4fv(fgColor);

		 DrawString(0, 0, ref title, title.Length);
		 DrawString(0, 2, "USE ARROW KEYS TO NAVIGATE", 26);
		 DrawString(0, 3, "PRESS ENTER WHEN FINISHED", 25);
		 DrawString(0, 4, "OR ESCAPE TO CANCEL", 19);
		 DrawString(0, 6, "MIN", 3);
		 DrawString(29, 6, "MAX", 3);

		 for (x = 0; x < current; x++)
		  DrawString(x, 7, "-", 1);

		 DrawString(current, 7, "+", 1);

		 for (x = current + 1; x < 32; x++)
		  DrawString(x, 7, "-", 1);

		  // Update the screen
		  //SDL 2.0 Replaced
		  //SDL_GL_SwapBuffers();
		  oslink.SwapBuffers();
		}

		/****************************************************************
		  Member: drawMenuStringTitle
		
		  Vars:   title - the title of the string box
		
		  Function: Draws a menu string box
		****************************************************************/
		public void DrawMenuStringTitle(ref string title)
		{
		  // Clear screen
		 glColor4fv(bgColor);
		 glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		 glColor4fv(fgColor);

		 DrawString(0, 0, ref title, title.Length);

		  // Update the screen
		  //SDL 2.0 Replaced
		  //SDL_GL_SwapBuffers();
		  oslink.SwapBuffers();
		}

		/****************************************************************
		  Member: drawMenuString
		
		  Vars:   title - the title of the string box
		
		  Function: Draws a menu string box
		****************************************************************/
		public void DrawMenuString(ref string currentString)
		{
		 DrawString(0, 2, ref currentString, currentString.Length);
		 DrawString(currentString.Length, 2, "_", 1);

		  // Update the screen
		  //SDL 2.0 Replaced
		  //SDL_GL_SwapBuffers();
		  oslink.SwapBuffers();
		}

		/****************************************************************
		  Member: aboutBox
		
		  Function: Draws the "About" Box
		****************************************************************/
		public void AboutBox()
		{
		  // Clear screen
		 glColor4fv(bgColor);
		 glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		 glColor4fv(fgColor);

		 DrawString(0, 3, "ABOUT DUNGEONS OF DAGGORATH", 27);
		 DrawString(0, 4, "COPYRIGHT 1982 DYNAMICRO", 24);
		 DrawString(0, 5, "ORIGINAL DESIGN. DOUGLAS MORGAN", 31);
		 DrawString(0, 6, "PC PORT BY RICHARD HUNERLACH", 28);
		 DrawString(0, 7, "VARIOUS OTHER CONTRIBUTIONS BY", 30);
		 DrawString(1, 8, "TIM LINDNER", 11);
		 DrawString(1, 9, "AARON OLIVER", 12);
		 DrawString(1, 10, "ANTHONY BUTTIGIEG", 17);
		 DrawString(1, 11, "BRUCE", 5);
		 DrawString(1, 12, "JOE LAVIGNE", 11);
		 DrawString(1, 13, "KEN THOMPSON", 12);
		 DrawString(1, 14, "ERICK RITCHIE", 13);
		 DrawString(1, 15, "MATTHEW EYSTER", 14);
		 DrawString(1, 16, "DAN GENDREAU", 12);
		 DrawString(1, 17, "JOSH ALBRIGHT", 13);
		 DrawString(1, 18, "MANY OTHERS NOT MENTIONED HERE!", 31);

		  // Update the screen
		  //SDL 2.0 Replaced
		  //SDL_GL_SwapBuffers();
		  oslink.SwapBuffers();
		}

		// Public Data Fields
		public byte VCTFAD;
		public byte RANGE;
		public bool showSeerMap;
		public uint delay;
		public uint delay1;
		public uint delay2;
		public bool done;
		public int fadeVal;
		public byte UPDATE;
		public ushort display_mode; // 0 = map, 1 = 3D, 2 = Examine, 3 = Prepare
		public int fadChannel;

		public int buzzStep;
		public int midPause;
		public int prepPause;

		public byte[] Scale = new byte[21];
		public float[] Scalef = new float[21];
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: int * LArch[4];
		public int[] LArch = new int[4];
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: int * FArch[4];
		public int[] FArch = new int[4];
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: int * RArch[4];
		public int[] RArch = new int[4];

	//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
		char textArea[(32 * 4) + 1];
	//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
		char examArea[(32 * 19) + 1];
	//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
		char statArea[(32 * 1) + 1];

		public Txb TXTPRI = new Txb();
		public Txb TXTEXA = new Txb();
		public Txb TXTSTS = new Txb();

		public GLfloat[] bgColor = Arrays.InitializeWithDefaultInstances<GLfloat>(3);
		public GLfloat[] fgColor = Arrays.InitializeWithDefaultInstances<GLfloat>(3);
		public byte RLIGHT;
		public byte MLIGHT;
		public byte OLIGHT;
		public byte VXSCAL;
		public byte VYSCAL;
		public float VXSCALf;
		public float VYSCALf;

		public byte TXBFLG;
		public Txb TXB_U;
		public int tcaret;
		public int tlen;

		public byte[] enough1 = new byte[21];
		public byte[] enough2 = new byte[20];
		public byte[] winner1 = new byte[21];
		public byte[] winner2 = new byte[17];
		public byte[] death = new byte[21];
		public byte[] copyright = new byte[21];
		public byte[] welcome1 = new byte[14];
		public byte[] welcome2 = new byte[20];
		public byte[] prepstr = new byte[6];
		public byte[] exps = new byte[3];
		public byte[] exam1 = new byte[9];
		public byte[] exam2 = new byte[8];
		public byte[] exam3 = new byte[7];
		public byte NEWLUK;

		public int[] LINES = new int[11];

		public byte HLFSTP;
		public byte BAKSTP;
		public byte NEWLIN;

	//C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named AnonymousEnum9:
		public enum AnonymousEnum9
		{
			ModeMap = 0,
			Mode_3d,
			ModeExamine,
			ModeTitle,

			FadeBegin = 1,
			FadeMiddle,
			FadeDeath,
			FadeVictory,
		}

		// Internal Implementation

		// Draws font vectors
		private void DrawVectorListAQ(int[] VLA)
		{
			int numQuads = VLA[0];
			int curQuad = 0;
			int ctr = 1;

			glBegin(GL_QUADS);
			while (curQuad < numQuads)
			{
				glVertex2f(crd.newXa((double) VLA[ctr]),crd.newYa((double) VLA[ctr + 1]));
				glVertex2f(crd.newXa((double) VLA[ctr + 2]),crd.newYa((double) VLA[ctr + 3]));
				glVertex2f(crd.newXa((double) VLA[ctr + 4]),crd.newYa((double) VLA[ctr + 5]));
				glVertex2f(crd.newXa((double) VLA[ctr + 6]),crd.newYa((double) VLA[ctr + 7]));
				ctr += 8;
				++curQuad;
			}
			glEnd();
		}

		// Draws a character
		private void DrawCharacter(char c)
		{
			if (c >= 'A'
				&& c <= 'Z')
				DrawVectorListAQ(AZ_VLA[c - 64]);
			if (c >= '0'
				&& c <= '9')
				DrawVectorListAQ(AZ_VLA[c - 13]); //Dependent on ASCII values
			switch (c)
			{
			case ('<'):
				DrawVectorListAQ(AZ_VLA[31]);
				break;
			case ('>'):
				DrawVectorListAQ(AZ_VLA[32]);
				break;
			case ('{'):
				DrawVectorListAQ(AZ_VLA[33]);
				break;
			case ('}'):
				DrawVectorListAQ(AZ_VLA[34]);
				break;
			case (' '):
				break;
			case ('.'):
				DrawVectorListAQ(AZ_VLA[27]);
				break;
			case ('_'):
				DrawVectorListAQ(AZ_VLA[28]);
				break;
			case ('!'):
				DrawVectorListAQ(AZ_VLA[29]);
				break;
			case ('?'):
				DrawVectorListAQ(AZ_VLA[30]);
				break;
			case ('/'):
				DrawVectorListAQ(AZ_VLA[45]);
				break;
			case ('\\'):
				DrawVectorListAQ(AZ_VLA[46]);
				break;
			case ('%'):
				DrawVectorListAQ(AZ_VLA[47]);
				break;
			case ('+'):
				DrawVectorListAQ(AZ_VLA[48]);
				break;
			case ('-'):
				DrawVectorListAQ(AZ_VLA[49]);
				break;
			default:
				break;
			}
		}

		// Draws a string
		private void DrawString(int x, int y, ref string str, int len)
		{
			int ctr;
			glLoadIdentity();
			glTranslatef(crd.newX(x * 8), crd.newY(((y + 1) * 8)), 0.0);
			for (ctr = 0; ctr < len; ++ctr)
			{
				DrawCharacter(*(str.Substring(ctr)));
				glTranslatef(crd.newXa(8), 0.0, 0.0);
			}
		}
		private void DrawStringInternal(int x, int y, ref byte str, int len)
		{
			int ctr;
			char c;
			glLoadIdentity();
			glTranslatef(crd.newX(x * 8), crd.newY(((y + 1) * 8)), 0.0);
			for (ctr = 0; ctr < len; ++ctr)
			{
				c = DodToAscii(*(str + ctr));
				DrawCharacter(c);
				glTranslatef(crd.newXa(8), 0.0, 0.0);
			}
		}

		// Draws one pixel
		private void PlotPoint(double X, double Y)
		{
			if ((g_options & (int)AnonymousEnum8.OptHires) != 0)
			{ // draw a single pixel
				glBegin(GL_POINTS);
				float x;
				float y;
				x = crd.newX(X);
				y = crd.newY(Y);
				glVertex2f(x,y);
				glEnd();
			} else
			{ // draw a COCO pixel (square)
				glBegin(GL_QUADS);
				glVertex2f(crd.newX(X), crd.newY(Y));
				glVertex2f(crd.newX(X + 1), crd.newY(Y));
				glVertex2f(crd.newX(X + 1), crd.newY(Y + 1));
				glVertex2f(crd.newX(X), crd.newY(Y + 1));
				glEnd();
			}
		}
		private char DodToAscii(byte c)
		{
			if (c >= 1
				&& c <= 26)
				return (c | 64);
			if (c == parser.I_SP)
				return ' ';
			if (c == parser.I_EXCL)
				return '!';
			if (c == parser.I_BAR)
				return '_';
			if (c == parser.I_QUES)
				return '?';
			if (c == parser.I_DOT)
				return '.';
			if (c == parser.I_SHL)
				return '<';
			if (c == parser.I_SHR)
				return '>';
			if (c == parser.I_LHL)
				return '{';
			if (c == parser.I_LHR)
				return '}';
			return ' ';
		}

		// Data Fields
		private ushort VCNTRX;
		private ushort VCNTRY;
		private byte OROW;
		private byte OCOL;
		private byte MAGFLG;
		private byte PASFLG;
		private int HLFSCL;
		private int BAKSCL;
		private int NORSCL;
		public int[] A_VLA = new int[33];
		public int[] B_VLA = new int[49];
		public int[] C_VLA = new int[41];
		public int[] D_VLA = new int[33];
		public int[] E_VLA = new int[33];
		public int[] F_VLA = new int[25];
		public int[] G_VLA = new int[49];
		public int[] H_VLA = new int[25];
		public int[] I_VLA = new int[25];
		public int[] J_VLA = new int[25];
		public int[] K_VLA = new int[65];
		public int[] L_VLA = new int[17];
		public int[] M_VLA = new int[41];
		public int[] N_VLA = new int[41];
		public int[] O_VLA = new int[33];
		public int[] P_VLA = new int[33];
		public int[] Q_VLA = new int[57];
		public int[] R_VLA = new int[57];
		public int[] S_VLA = new int[57];
		public int[] T_VLA = new int[33];
		public int[] U_VLA = new int[25];
		public int[] V_VLA = new int[41];
		public int[] W_VLA = new int[41];
		public int[] X_VLA = new int[73];
		public int[] Y_VLA = new int[41];
		public int[] Z_VLA = new int[57];
		public int[] NM0_VLA = new int[33];
		public int[] NM1_VLA = new int[25];
		public int[] NM2_VLA = new int[49];
		public int[] NM3_VLA = new int[57];
		public int[] NM4_VLA = new int[33];
		public int[] NM5_VLA = new int[49];
		public int[] NM6_VLA = new int[41];
		public int[] NM7_VLA = new int[49];
		public int[] NM8_VLA = new int[57];
		public int[] NM9_VLA = new int[49];
		public int[] PER_VLA = new int[9];
		public int[] UND_VLA = new int[9];
		public int[] EXP_VLA = new int[17];
		public int[] QSM_VLA = new int[49];
		public int[] SHL_VLA = new int[9];
		public int[] SHR_VLA = new int[33];
		public int[] LHL_VLA = new int[17];
		public int[] LHR_VLA = new int[41];
		public int[] FSL_VLA = new int[41]; //Forward Slash
		public int[] BSL_VLA = new int[41]; //Back Slash
		public int[] PCT_VLA = new int[57]; //Percent
		public int[] PLS_VLA = new int[17]; //Plus
		public int[] DSH_VLA = new int[9]; //Dash
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: int * AZ_VLA[50];
		public int[] AZ_VLA = new int[50];

		public int[] SP_VLA = new int[39];
		public int[] WR_VLA = new int[42];
		public int[] SC_VLA = new int[41];
		public int[] BL_VLA = new int[66];
		public int[] GL_VLA = new int[141];
		public int[] VI_VLA = new int[65];
		public int[] S1_VLA = new int[130];
		public int[] S2_VLA = new int[126];
		public int[] K1_VLA = new int[153];
		public int[] K2_VLA = new int[149];
		public int[] W0_VLA = new int[133];

		public int[] W1_VLA = new int[199];
		public int[] W2_VLA = new int[185];

	//private:
		public int[] LAD_VLA = new int[56];
		public int[] HUP_VLA = new int[29];
		public int[] HDN_VLA = new int[19];
		public int[] CEI_VLA = new int[6];
		public int[] LPK_VLA = new int[12];
		public int[] RPK_VLA = new int[12];
		public int[] FSD_VLA = new int[8];
		public int[] LSD_VLA = new int[8];
		public int[] RSD_VLA = new int[8];
		public int[] RWAL_VLA = new int[10];
		public int[] LWAL_VLA = new int[10];
		public int[] FWAL_VLA = new int[11];
		public int[] RPAS_VLA = new int[15];
		public int[] LPAS_VLA = new int[15];
		public int[] FPAS_VLA = new int[1];
		public int[] RDOR_VLA = new int[24];
		public int[] LDOR_VLA = new int[24];
		public int[] FDOR_VLA = new int[25];

		public int[] FLATAB = new int[3];
		public int[] * FLATABv[0] = new int[3];
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: int * FWDOBJ[6];
		public int[] FWDOBJ = new int[6];
	//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
	//ORIGINAL LINE: int * FWDCRE[12];
		public int[] FWDCRE = new int[12];

		public int[] SHIE_VLA = new int[14];
		public int[] SWOR_VLA = new int[11];
		public int[] TORC_VLA = new int[10];
		public int[] RING_VLA = new int[12];
		public int[] SCRO_VLA = new int[12];
		public int[] FLAS_VLA = new int[10];
	}
}
/****************************************
Daggorath PC-Port Version 0.2.1
Richard Hunerlach
November 13, 2002

The copyright for Dungeons of Daggorath
is held by Douglas J. Morgan.
(c) 1982, DynaMicro
*****************************************/
using System;

namespace DoD
{
    //
    // This class manages the objects (torches, etc.) in the
    // game.
    public class CppObject
	{
		public CppObject ()
		{
			Reset();
		}

		public void Reset()
		{
			OFINDP = 0;
			OFINDF = 0;
			OCBPTR = 0;
			OBJTYP = 0;
			OBJCLS = 0;
			SPEFLG = 0;
			objChannel = 1;
    
			ODBTAB[0] = new Odb(OBJT_RING, 255, 0, 5); // Supreme Ring
			ODBTAB[1] = new Odb(OBJT_RING, 170, 0, 5); // Joule Ring
			ODBTAB[2] = new Odb(OBJT_WEAPON, 150, 64, 64); // Elvish Sword
			ODBTAB[3] = new Odb(OBJT_SHIELD, 140, 13, 26); // Mithril Shield
			ODBTAB[4] = new Odb(OBJT_SCROLL, 130, 0, 5); // Seer Scroll
			ODBTAB[5] = new Odb(OBJT_FLASK, 70, 0, 5); // Thews Flask
			ODBTAB[6] = new Odb(OBJT_RING, 52, 0, 5); // Rime Ring
			ODBTAB[7] = new Odb(OBJT_SCROLL, 50, 0, 5); // Vision Scroll
			ODBTAB[8] = new Odb(OBJT_FLASK, 48, 0, 5); // Abye Flask
			ODBTAB[9] = new Odb(OBJT_FLASK, 40, 0, 5); // Hale Flask
			ODBTAB[10] = new Odb(OBJT_TORCH, 70, 0, 5); // Solar Torch
			ODBTAB[11] = new Odb(OBJT_SHIELD, 25, 0, 26); // Bronze Shield
			ODBTAB[12] = new Odb(OBJT_RING, 13, 0, 5); // Vulcan Ring
			ODBTAB[13] = new Odb(OBJT_WEAPON, 13, 0, 40); // Iron Sword
			ODBTAB[14] = new Odb(OBJT_TORCH, 25, 0, 5); // Lunar Torch
			ODBTAB[15] = new Odb(OBJT_TORCH, 5, 0, 5); // Pine Torch
			ODBTAB[16] = new Odb(OBJT_SHIELD, 5, 0, 10); // Leather Shield
			ODBTAB[17] = new Odb(OBJT_WEAPON, 5, 0, 16); // Wooden Sword
			ODBTAB[18] = new Odb(OBJT_RING, 0, 0, 0); // Incanted Supreme Ring
			ODBTAB[19] = new Odb(OBJT_RING, 0, 255, 255); // Incanted Joule Ring
			ODBTAB[20] = new Odb(OBJT_RING, 0, 255, 255); // Incanted Rime Ring
			ODBTAB[21] = new Odb(OBJT_RING, 0, 255, 255); // Incanted Vulcan Ring
			ODBTAB[22] = new Odb(OBJT_RING, 0, 0, 5); // Gold Ring
			ODBTAB[23] = new Odb(OBJT_FLASK, 0, 0, 5); // Empty Flask
			ODBTAB[24] = new Odb(OBJT_TORCH, 5, 0, 5); // Dead Torch
    
			XXXTAB[0] = new Xdb(0x00, 0x03, 0x12, 0x00); // Supreme Ring
			XXXTAB[1] = new Xdb(0x01, 0x03, 0x13, 0x00); // Joule Ring
			XXXTAB[2] = new Xdb(0x03, 0x40, 0x40, 0x00); // Mithril Shield
			XXXTAB[3] = new Xdb(0x06, 0x03, 0x14, 0x00); // Rime Ring
			XXXTAB[4] = new Xdb(0x0A, 0x02D0, 0x0D, 0x0B); // Solar Torch
			XXXTAB[5] = new Xdb(0x0B, 0x60, 0x80, 0x00); // Bronze Shield
			XXXTAB[6] = new Xdb(0x0C, 0x03, 0x15, 0x00); // Vulcan Ring
			XXXTAB[7] = new Xdb(0x0E, 0x0168, 0x0A, 0x04); // Lunar Torch
			XXXTAB[8] = new Xdb(0x0F, 0x00B4, 0x07, 0x00); // Pine Torch
			XXXTAB[9] = new Xdb(0x10, 0x6C, 0x80, 0x00); // Leather Shield
			XXXTAB[10] = new Xdb(0x18, 0x00, 0x00, 0x00); // Dead Torch
			if (game.ShieldFix)
			{ //Do they want the shield fix?
				XXXTAB[5] = new Xdb(0x0B, 0x80, 0x60, 0x00); // Bronze Shield
				XXXTAB[9] = new Xdb(0x10, 0x80, 0x6C, 0x00); // Leather Shield
			} //Do they want the shield fix?:
    
			if (game.VisionScroll) //Do we need an extra vision scroll in level 1?  Yes:
				Utils.LoadFromHex(OMXTAB, "413131322323110416141416010408080304");
			else //Do we need an extra vision scroll in level 1?  No:
				Utils.LoadFromHex(OMXTAB, "413131322323111316141416010408080304");
			Utils.LoadFromHex(OBJWGT, "05010A19190A");
			Utils.LoadFromHex(GENVAL, "FFFFFF10110F");
			Utils.LoadFromHex(ADJTAB, "1938675848AD282854FAB0A0310ACB266838DA9A22496020A652C8282882DE60" + "2064969430AC99A5EE20022C94201016142966F6064030C527BB45306D560C2E" + "211327B829595706402160971438D850D10590312EF790AE284C970580304AE2" + "C8F918523280204C9914204EF610280AD8532021485090");
			Utils.LoadFromHex(GENTAB, "06280CC0CD602064971C30A6393D8C30E6849584292777C8802968F90D00");
		}

		public void LoadSounds()
		{
			objSound[0] = Utils.LoadSound("0C_gluglg.wav");
			objSound[1] = Utils.LoadSound("0D_phaser.wav");
			objSound[2] = Utils.LoadSound("0E_whoop.wav");
			objSound[3] = Utils.LoadSound("0F_clang.wav");
			objSound[4] = Utils.LoadSound("10_whoosh.wav");
			objSound[5] = Utils.LoadSound("11_chuck.wav");
		}

		public void CreateAll()
		{
			byte a = 0;
			byte b;
			byte x;
			byte OBJCNT;
			byte OBJLVL;
    
			for (x = 0; x < 72; ++x)
				OCBLND[x].clear();
    
			do
			{
				OBJCNT = (OMXTAB[a] & 0x0F);
				OBJLVL = (OMXTAB[a] >> 4);
				b = OBJLVL;
    
				do
				{
					x = OBIRTH(a, b);
					OCBLND[x].P_OCOWN = 0xFF;
					++b;
					if (b > 4)
						b = OBJLVL;
					--OBJCNT;
				} while (OBJCNT != 0);
    
				++a;
			} while (a < 18);
		}

		public void OBJNAM(int idx)
		{
			if (idx == -1)
			{
				// return "EMPTY"
				parser.TOKEN[0] = 0x05;
				parser.TOKEN[1] = 0x0D;
				parser.TOKEN[2] = 0x10;
				parser.TOKEN[3] = 0x14;
				parser.TOKEN[4] = 0x19;
				parser.TOKEN[5] = Parser.AnonymousEnum2.INull;
				return;
			}
    
			int ctr = 0;
		//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
			byte * X;
			int Xup;
			byte A;
    
			if (OCBLND[idx].obj_reveal_lvl == 0)
			{
				X = &ADJTAB[1];
				A = OCBLND[idx].obj_id;
				while (A != 0xFF)
				{
					parser.EXPAND(X, Xup, 0);
					X += Xup;
					--A;
				}
    
				do
					parser.TOKEN[ctr] = parser.STRING[ctr + 2];
				while (parser.STRING[ctr + ++2] != Parser.AnonymousEnum2.INull);
    
				parser.TOKEN[ctr - 1] = 0;
			}
    
			X = &GENTAB[1];
			A = OCBLND[idx].obj_type;
			while (A != 0xFF)
			{
				parser.EXPAND(X, Xup, 0);
				X += Xup;
				--A;
			}
    
			int offset = ctr;
    
			do
				parser.TOKEN[ctr] = parser.STRING[ctr - offset + 2];
			while (parser.STRING[ctr++ - offset + 2] != Parser.AnonymousEnum2.INull);
		}

		public void OCBFIL(byte OBJTYP, int ptr)
		{
			int ctr = 0;
    
			OCBLND[ptr].obj_type = ODBTAB[OBJTYP].P_ODCLS;
			OCBLND[ptr].obj_reveal_lvl = ODBTAB[OBJTYP].P_ODREV;
			OCBLND[ptr].P_OCMGO = ODBTAB[OBJTYP].P_ODMGO;
			OCBLND[ptr].P_OCPHO = ODBTAB[OBJTYP].P_ODPHO;
    
			while (ctr < 11)
			{
				if (OBJTYP == XXXTAB[ctr].P_OXIDX)
				{
					OCBLND[ptr].P_OCXX0 = XXXTAB[ctr].P_OXXX0;
					OCBLND[ptr].P_OCXX1 = XXXTAB[ctr].P_OXXX1;
					OCBLND[ptr].P_OCXX2 = XXXTAB[ctr].P_OXXX2;
				}
				++ctr;
			}
		}

        // Finds objects in the OCB table
        public int Fndobj ()
        {
            int x = OFINDP;
            if (OFINDF == 0)
            {
                x = -1;
                OFINDF = -1;
            }

            do
            {
                ++x;
                OFINDP = x;
                if (x == OCBPTR)
                    return -1;
            } while (OCBLND[x].P_OCLVL != game.LEVEL);
            return x;
        }

        // Finds object on the floor in a cell
        public int Ofind ( RowCol rc )
        {
            int idx;
            do
            {
                idx = Fndobj();
                if (idx == -1)
                    return -1;
            } while ((!((OCBLND[idx].P_OCROW == rc.row) && (OCBLND[idx].P_OCCOL == rc.col))) || (OCBLND[idx].P_OCOWN != 0));
            return idx;
        }

        // Creates new object
        public int Obirth ( byte OBJTYP, byte OBJLVL )
        {
            byte tmp;
            int originalOCBPTR = OCBPTR;
            OCBLND[OCBPTR].obj_id = OBJTYP;
            OCBLND[OCBPTR].P_OCLVL = OBJLVL;
            Ocbfil(OBJTYP, OCBPTR);
            if (GENVAL[OCBLND[OCBPTR].obj_type] != 0xFF)
            {
                tmp = OCBLND[OCBPTR].obj_reveal_lvl;
                OBJTYP = GENVAL[OCBLND[OCBPTR].obj_type];
                Ocbfil(OBJTYP, OCBPTR);
                OCBLND[OCBPTR].obj_reveal_lvl = tmp;
            }
            ++OCBPTR;
            return originalOCBPTR;
        }

        // Parses an object name
        public bool Parobj ()
        {
            int res;
            byte A;
            byte B;

            SPEFLG = 0;
            res = parser.PARSER(GENTAB, A, B, true);
            if (res == 0)
            {
                parser.CMDERR();
                return false;
            }
            if (res > 0)
            {
                OBJTYP = A;
                OBJCLS = B;
                return true;
            }

            --SPEFLG;
            res = parser.PARSER(ADJTAB, A, B, false);
            if (res <= 0)
            {
                parser.CMDERR();
                return false;
            }
            OBJTYP = A;
            OBJCLS = B;
            res = parser.PARSER(GENTAB, A, B, true);
            if (res <= 0)
            {
                parser.CMDERR();
                return false;
            }
            if (B != OBJCLS)
            {
                parser.CMDERR();
                return false;
            }
            return true;
        }

        // Public Data Membes
        public Ocb[] OCBLND = Arrays.InitializeWithDefaultInstances<Ocb>(72); // Holds most of the object data
        public int OFINDF;
        public byte[] ADJTAB = new byte[119];
        public byte[] GENTAB = new byte[30];
        public byte OBJTYP;
        public byte OBJCLS;
        public byte SPEFLG;
        public int[] OBJWGT = new int[6];
        public int objChannel;
        public Mix_Chunk[] objSound = Arrays.InitializeWithDefaultInstances<Mix_Chunk>(6);
        int OCBPTR;
        int OFINDP;

        enum _Undefined {

            OBJ_SWORD_WOOD = 17,
            OBJ_SWORD_IRON = 13,
            OBJ_SWORD_ELVISH = 2,

            OBJ_SHIELD_LEATHER = 16,
            OBJ_SHIELD_BRONZE = 11,
            OBJ_SHIELD_MITHRIL = 3,

            OBJ_SCROLL_SEER = 4,
            OBJ_SCROLL_VISION = 7,

            OBJ_RING_JOULE = 1,
            OBJ_RING_ENERGY = 19, // incanted
            OBJ_RING_RIME = 6,
            OBJ_RING_ICE = 20,  // incanted
            OBJ_RING_VULCAN = 12,
            OBJ_RING_FIRE = 21, // incanted
            OBJ_RING_SUPREME = 0,
            OBJ_RING_FINAL = 18,    // incanted
            OBJ_RING_GOLD = 22,

            OBJ_FLASK_THEWS = 5,
            OBJ_FLASK_ABYE = 8,
            OBJ_FLASK_HALE = 9,
            OBJ_FLASK_EMPTY = 23,

            OBJ_TORCH_SOLAR = 10,
            OBJ_TORCH_LUNAR = 14,
            OBJ_TORCH_PINE = 15,
            OBJ_TORCH_DEAD = 24,

            OBJT_FLASK = 0,
            OBJT_RING = 1,
            OBJT_SCROLL = 2,
            OBJT_SHIELD = 3,
            OBJT_WEAPON = 4,
            OBJT_TORCH = 5,
        };

        public enum AnonymousEnum6
        {

            ObjSwordWood = 17,
            ObjSwordIron = 13,
            ObjSwordElvish = 2,

            ObjShieldLeather = 16,
            ObjShieldBronze = 11,
            ObjShieldMithril = 3,

            ObjScrollSeer = 4,
            ObjScrollVision = 7,

            ObjRingJoule = 1,
            ObjRingEnergy = 19, // incanted
            ObjRingRime = 6,
            ObjRingIce = 20, // incanted
            ObjRingVulcan = 12,
            ObjRingFire = 21, // incanted
            ObjRingSupreme = 0,
            ObjRingFinal = 18, // incanted
            ObjRingGold = 22,

            ObjFlaskThews = 5,
            ObjFlaskAbye = 8,
            ObjFlaskHale = 9,
            ObjFlaskEmpty = 23,

            ObjTorchSolar = 10,
            ObjTorchLunar = 14,
            ObjTorchPine = 15,
            ObjTorchDead = 24,

            ObjtFlask = 0,
            ObjtRing = 1,
            ObjtScroll = 2,
            ObjtShield = 3,
            ObjtWeapon = 4,
            ObjtTorch = 5,
        }

        public int OCBPTR;
        public int OFINDP;

        // Data Fields
        private Odb[] ODBTAB = Arrays.InitializeWithDefaultInstances<Odb>(25);
        private Xdb[] XXXTAB = Arrays.InitializeWithDefaultInstances<Xdb>(11);
        private byte[] OMXTAB = new byte[18];
        private byte[] GENVAL = new byte[6];
    }
}
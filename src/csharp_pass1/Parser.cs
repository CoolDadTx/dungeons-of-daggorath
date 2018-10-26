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
    /// <summary>This class will manage the command parser.</summary>
    public class Parser
	{
        #region Construction

        public Parser()
		{
            throw new NotImplementedException();
			//LINPTR = 0;
			//PARFLG = 0;
			//PARCNT = 0;
			//VERIFY = 0;
			//FULFLG = 0;
			//KBDHDR = 0;
			//KBDTAL = 0;
			//BUFFLG = 0;
			//LINEND = 0;
			//TOKEND = 0;
			//int ctr;
			//for (ctr = 0; ctr < 33; ++ctr)
			//{
			//	KBDBUF[ctr] = 0;
			//	LINBUF[ctr] = 0;
			//	TOKEN[ctr] = 0;
			//	OBJSTR[ctr] = 0;
			//	STRING[ctr] = 0;
			//}
			//STRING[33] = 0;
			//STRING[34] = 0;
			//for (ctr = 0; ctr < 11; ++ctr)
			//	SWCHAR[ctr] = 0;

			//M_PROM1[0] = (int)AnonymousEnum.ICr;
			//M_PROM1[1] = (int)AnonymousEnum.IDot;
			//M_PROM1[2] = (int)AnonymousEnum.IBar;
			//M_PROM1[3] = (int)AnonymousEnum.IBs;
			//M_PROM1[4] = (int)AnonymousEnum.INull;

			//M_CURS[0] = (int)AnonymousEnum.IBar;
			//M_CURS[1] = (int)AnonymousEnum.IBs;
			//M_CURS[2] = (int)AnonymousEnum.INull;

			//M_ERAS[0] = (int)AnonymousEnum.ISp;
			//M_ERAS[1] = (int)AnonymousEnum.IBs;
			//M_ERAS[2] = (int)AnonymousEnum.IBs;
			//M_ERAS[3] = (int)AnonymousEnum.IBar;
			//M_ERAS[4] = (int)AnonymousEnum.IBs;
			//M_ERAS[5] = (int)AnonymousEnum.INull;

			//Utils.LoadFromHex(CERR, "177BD0");
			//Utils.LoadFromHex(CMDTAB, "0F30034A046B2806C4B440200927C0380B80B52E28180E5A003012E185D42018F7AC201AFB142021563030245B142C202747DC20295938182B32802834C78480283530D8A0");
			//Utils.LoadFromHex(DIRTAB, "0620185350282493A280200411AC300327D5C4102B002008FBB8");		
		}
        #endregion
        
        /// <summary>This method puts a character into the DoD buffer.</summary>
        public void Kbdput(byte c)
		{
            throw new NotImplementedException();
   //         KBDBUF[KBDTAL] = c;
			//++KBDTAL;
			//KBDTAL &= 31;
		}

        /// <summary>This method gets a character from the DoD buffer.</summary>
        public byte Kbdget()
		{
            throw new NotImplementedException();
   //         byte c = 0;
			//if (KBDHDR == KBDTAL)
			//	return c;
			//c = KBDBUF[KBDHDR];
			//++KBDHDR;
			//KBDHDR &= 31;
			//return c;
		}

	//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'X', so pointers on this parameter are left unchanged:
	//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'Xup', so pointers on this parameter are left unchanged:
	//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'U', so pointers on this parameter are left unchanged:
		public void Expand(byte * X, int * Xup, byte * U)
		{
            throw new NotImplementedException();
  //          //C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
  //          //ORIGINAL LINE: byte * Y;
  //          byte Y;
		//	byte A;
		//	byte B;
		//	int Xup2;

		//	*Xup = 0;

		//	if (U != 0)
		//		Y = (U - 1);
		//	else
		//	{
		//		Y = STRING[0];
		//		U = Y + 1;
		//	}
		//	Y = null;
		//	B = Getfiv(X, ref Xup2, ref Y);
		//	X += Xup2;
		//	A = B;

		//EXPAN10:
		//	B = Getfiv(X, ref Xup2, ref Y);
		//	X += Xup2;
		//	*Xup += Xup2;
		//	*U = B;
		//	++U;
		//	--A;
		//	if (A != 0xFF)
		//		goto EXPAN10;
		//	*U = A;

		//	if (Y != 0)
		//	{
		//		++X;
		//		++*Xup;
		//	}
		}

	//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'X', so pointers on this parameter are left unchanged:
		public byte Getfiv(byte * X, ref int Xup, ref byte zeroY)
		{
            throw new NotImplementedException();
   //         byte A;
			//byte B;

			//Xup = null;

			//A = zeroY;

			//switch (A)
			//{
			//case 0:
			//	B = X;
			//	B = (B >> 3);
			//	break;
			//case 1:
			//	A = X;
			//	++X;
			//	++Xup;
			//	B = X;
			//	Asrd(ref A, ref B, 6);
			//	break;
			//case 2:
			//	B = X;
			//	B = (B >> 1);
			//	break;
			//case 3:
			//	A = X;
			//	++X;
			//	++Xup;
			//	B = X;
			//	Asrd(ref A, ref B, 4);
			//	break;
			//case 4:
			//	A = X;
			//	++X;
			//	++Xup;
			//	B = X;
			//	Asrd(ref A, ref B, 7);
			//	break;
			//case 5:
			//	B = X;
			//	B = (B >> 2);
			//	break;
			//case 6:
			//	A = X;
			//	++X;
			//	++Xup;
			//	B = X;
			//	Asrd(ref A, ref B, 5);
			//	break;
			//case 7:
			//	B = X;
			//	++X;
			//	++Xup;
			//	break;
			//}

			//A = zeroY;
			//++A;
			//A = (A & 7);
			//zeroY = A;

			//return (B & 0x1F);
		}

		public void Asrd(ref byte A, ref byte B, int num)
		{
            throw new NotImplementedException();
   //         short D = ((short)A << 8) + B;
			//short sign = D & 0x8000;

			//while (num-- != 0)
			//	D = (D >> 1) | sign;

			//A = D >> 8;
			//B = (byte)D;
		}

		public bool Gettok()
		{
            throw new NotImplementedException();
  //          int U = 0;
		//	int X = LINPTR;
		//	byte A;

		//	do
		//		A = LINBUF[X++];
		//	while (A == 0);
		//	goto GTOK22;

		//GTOK20:
		//	A = LINBUF[X++];

		//GTOK22:
		//	if (A == 0
		//		|| A == 0xFF)
		//		goto GTOK30;
		//	TOKEN[U++] = A;
		//	if (U < 32)
		//		goto GTOK20;

		//GTOK30:
		//	TOKEN[U++] = 0xFF;
		//	LINPTR = X;

		//	if (TOKEN[0] == 0xFF)
		//		return false;
		//	else
		//		return true;
		}

		// The rest of these methods are direct ports from the source,
		// including all the GOTOs.  Someday, these should probably be
		// updated to a more C/C++ programming style, but for the moment
		// they work just fine.
		
	    //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 'byte* pTABLE', so pointers on this parameter are left unchanged:
		public int Parser(byte[] pTABLE, ref byte A, ref byte B, bool norm)
		{
            throw new NotImplementedException();
  //          bool tok;
		//	int U;
		//	int Xup;
		//	int Y;
		//	byte retA;
		//	byte retB;

		//	if (norm)
		//	{
		//		A = 0;
		//		B = 0;
		//		tok = Gettok();
		//		if (tok == false)
		//			return 0;
		//	} else
		//	{
		//		A = 0;
		//	}

		//	PARFLG = 0;
		//	FULFLG = 0;
		//	B = pTABLE;
		//	++pTABLE;
		//	PARCNT = B;

		//PARS10:
		//	U = 0;
		//	Expand(pTABLE, Xup, 0);
		//	pTABLE += Xup;
		//	Y = 2;

		//PARS12:
		//	B = TOKEN[U++];
		//	if (B == 0xFF)
		//		goto PARS20;
		//	if (B != STRING[Y++])
		//		goto PARS30;
		//	if (STRING[Y] != (int)AnonymousEnum.INull
		//		&& STRING[Y] != 0)
		//		goto PARS12;
		//	if (TOKEN[U] != 0xFF
		//		&& TOKEN[U] != 0)
		//		goto PARS30;
		//	--FULFLG;

		//PARS20:
		//	if (PARFLG != 0)
		//		goto PARS90;
		//	++PARFLG;
		//	B = STRING[1];
		//	retA = A;
		//	retB = B;

		//PARS30:
		//	++A;
		//	--PARCNT;
		//	if (PARCNT != 0)
		//		goto PARS10;

		//	if (PARFLG != 0)
		//	{
		//		A = retA;
		//		B = retB;
		//		return 1;
		//	}

		//PARS90:
		//	A = 0xFF;
		//	B = 0xFF;
		//	return -1;
		}

		public void Cmderr()
		{
            throw new NotImplementedException();
            //viewer.OUTSTI(CERR);
		}

		public int Parhnd()
		{
            throw new NotImplementedException();
   //         int res;
			//byte A;
			//byte B;

			//res = Parser(DIRTAB, ref A, ref B, true);
			//if (res != 1)
			//{
			//	Cmderr();
			//	return -1;
			//}
			//if (A == 0
			//	|| A == 1)
			//	return A;
			//else
			//{
			//	Cmderr();
			//	return -1;
			//}
		}

		public void Reset()
		{
            throw new NotImplementedException();
   //         LINPTR = 0;
			//PARFLG = 0;
			//PARCNT = 0;
			//VERIFY = 0;
			//FULFLG = 0;
			//KBDHDR = 0;
			//KBDTAL = 0;
			//BUFFLG = 0;
			//LINEND = 0;
			//TOKEND = 0;
			//int ctr;
			//for (ctr = 0; ctr < 33; ++ctr)
			//{
			//	KBDBUF[ctr] = 0;
			//	LINBUF[ctr] = 0;
			//	TOKEN[ctr] = 0;
			//	OBJSTR[ctr] = 0;
			//	STRING[ctr] = 0;
			//}
			//STRING[33] = 0;
			//STRING[34] = 0;
			//for (ctr = 0; ctr < 11; ++ctr)
			//	SWCHAR[ctr] = 0;
		}

		// TODO: Make properties
		public ushort LINPTR;
		public byte PARFLG;
		public byte PARCNT;
		public byte VERIFY;
		public byte FULFLG;
		public byte KBDHDR;
		public byte KBDTAL;
		public byte BUFFLG;
		public byte[] KBDBUF = new byte[33];
		public byte[] LINBUF = new byte[33];
		public ushort LINEND;
		public byte[] TOKEN = new byte[33];
		public byte TOKEND;
		public byte[] STRING = new byte[35];
		public byte[] SWCHAR = new byte[11];
		public byte[] OBJSTR = new byte[33];
		public byte[] CMDTAB = new byte[69];
		public byte[] DIRTAB = new byte[26];

		public enum AnonymousEnum7
		{
			CBS = 0x08,
			CCR = 0x0D,
			CSP = 0x20,

			ISP = 0x00,
			IBAR = 0x1C,
			IDOT = 0x1E,
			ICR = 0x1F,
			IEXCL = 0x1B,
			IQUES = 0x1D,
			ISHL = 0x20,
			ISHR = 0x21,
			ILHL = 0x22,
			ILHR = 0x23,
			IBS = 0x24,
			INULL = 0xff, // string terminator char

			CmdAttack = 0,
			CmdClimb,
			CmdDrop,
			CmdExamine,
			CmdGet,
			CmdIncant,
			CmdLook,
			CmdMove,
			CmdPull,
			CmdReveal,
			CmdStow,
			CmdTurn,
			CmdUse,
			CmdZload,
			CmdZsave,

			DirLeft = 0,
			DirRight,
			DirBack,
			DirAround,
			DirUp,
			DirDown,
		}

		public byte[] M_PROM1 = new byte[5];
		public byte[] M_CURS = new byte[3];
		public byte[] M_ERAS = new byte[6];
		public byte[] CERR = new byte[3];

        #region Private Members
        
        #endregion
    }
}
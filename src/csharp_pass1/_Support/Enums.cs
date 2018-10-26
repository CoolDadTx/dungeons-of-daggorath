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
    //C++ TO C# CONVERTER NOTE: Enums must be named in C#, so the following enum has been named AnonymousEnum4:
    public enum AnonymousEnum4
	{
		OptVector = 1,
		OptHires = 2,
		OptStereo = 4,
	}

	public enum CheatCodes
	{
		CHEATTORCH = 0x01,
		CHEATRING = 0x02,
		CHEATREGENSCALING = 0x04,
		CHEATITEMS = 0x08,
		CHEATREVEAL = 0x10,
		CHEATINVULNERABLE = 0x20,
	}
}
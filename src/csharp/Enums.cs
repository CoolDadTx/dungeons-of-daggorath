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

namespace DoD
{
    [Obsolete("Use GraphicOptions")]
	public enum AnonymousEnum4
	{
		OptVector = 1,
		OptHires = 2,
		OptStereo = 4,
	}

    [Obsolete("Use CheatCodes")]
	public enum AnonymousEnum5
	{
		CHEATTORCH = 0x01,
		CHEATRING = 0x02,
		CHEATREGENSCALING = 0x04,
		CHEATITEMS = 0x08,
		CHEATREVEAL = 0x10,
		CHEATINVULNERABLE = 0x20,
	}
}
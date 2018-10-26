/*
 * Copyright © Michael Taylor (P3Net)
 * All Rights Reserved
 * For changes from C++ to C# and .NET.
 *
 * http://www.michaeltaylorp3.net
 *//****************************************
Daggorath PC-Port Version 0.2.1
Richard Hunerlach
November 13, 2002

The copyright for Dungeons of Daggorath
is held by Douglas J. Morgan.
(c) 1982, DynaMicro
*****************************************/
using System;

namespace DoD.Scheduling
{
    //TODO: Fix names
    public enum TaskId
    {         
        TidClock = 0,
        TidPlayer = 1,
        TidRefreshDisp = 2,
        TidHrtslow = 3,
        TidTorchburn = 4,
        TidCrtregen = 5,
        TidCrtmove = 6,
    }
}
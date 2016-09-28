/*
 * Program : Ultrapowa Clash Server
 * Description : A C# Writted 'Clash of Clans' Server Emulator !
 *
 * Authors:  Jean-Baptiste Martin <Ultrapowa at Ultrapowa.com>,
 *           And the Official Ultrapowa Developement Team
 *
 * Copyright (c) 2016  UltraPowa
 * All Rights Reserved.
 */

using System;
using UCS.Core;
using UCS.Files.Logic;

namespace UCS.Helpers
{
    internal static class GamePlayUtil
    {
        #region Public Methods

        public static int CalculateResourceCost(int sup, int inf, int supCost, int infCost, int amount) => 
            (int)Math.Round((supCost - infCost) * (long)(amount - inf) / (sup - inf * 1.0)) + infCost;

        public static int CalculateSpeedUpCost(int sup, int inf, int supCost, int infCost, int amount) => 
            (int)Math.Round((supCost - infCost) * (long)(amount - inf) / (sup - inf * 1.0)) + infCost;

        public static int GetResourceDiamondCost(int resourceCount, ResourceData resourceData) => 
            Globals.GetResourceDiamondCost(resourceCount, resourceData);

        public static int GetSpeedUpCost(int seconds) => 
            Globals.GetSpeedUpCost(seconds);

        #endregion Public Methods
    }
}

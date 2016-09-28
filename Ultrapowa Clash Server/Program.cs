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

using UCS.Core.Threading;

namespace UCS
{
    internal class Program
    {
        #region Public Methods

        public static void Main(string[] args)
        {
            ConsoleThread.Start();
        }

        #endregion Public Methods
    }
}
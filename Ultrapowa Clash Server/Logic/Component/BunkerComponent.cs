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

namespace UCS.Logic
{
    internal class BunkerComponent : Component
    {
        #region Private Fields

        const int m_vType = 0x01AB3F00;

        #endregion Private Fields

        #region Public Properties

        public override int Type => 7;

        #endregion Public Properties
    }
}

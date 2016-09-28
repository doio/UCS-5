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

using System.IO;
using UCS.Helpers;

namespace UCS.PacketProcessing.Commands
{
    internal class SpeedUpHeroHealthCommand : Command
    {
        #region Private Fields

        int m_vBuildingId;

        #endregion Private Fields

        #region Public Constructors

        public SpeedUpHeroHealthCommand(CoCSharpPacketReader br)
        {
            /*
            m_vBuildingId = br.ReadInt32WithEndian();
            br.ReadInt32WithEndian();
            */
        }

        #endregion Public Constructors
    }
}
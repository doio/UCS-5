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
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    internal class SpeedUpHeroUpgradeCommand : Command
    {
        #region Public Constructors

        public SpeedUpHeroUpgradeCommand(CoCSharpPacketReader br)
        {
            m_vBuildingId = br.ReadInt32WithEndian(); //buildingId - 0x1DCD6500;
            m_vUnknown1 = br.ReadInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var ca = level.GetPlayerAvatar();
            var go = level.GameObjectManager.GetGameObjectByID(m_vBuildingId);

            if (go != null)
            {
                var b = (Building) go;
                var hbc = b.GetHeroBaseComponent();
                if (hbc != null)
                    hbc.SpeedUpUpgrade();
            }
        }

        #endregion Public Methods

        #region Private Fields

        readonly int m_vBuildingId;
        int m_vUnknown1;

        #endregion Private Fields
    }
}
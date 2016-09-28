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
    internal class SpeedUpUpgradeUnitCommand : Command
    {
        #region Private Fields

        readonly int m_vBuildingId;

        #endregion Private Fields

        #region Public Constructors

        public SpeedUpUpgradeUnitCommand(CoCSharpPacketReader br)
        {
            m_vBuildingId = br.ReadInt32WithEndian();
            br.ReadInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var ca = level.GetPlayerAvatar();
            var go = level.GameObjectManager.GetGameObjectByID(m_vBuildingId);
            if (go != null)
            {
                if (go.ClassId == 0)
                {
                    var b = (Building) go;
                    var uuc = b.GetUnitUpgradeComponent();
                    if (uuc != null)
                    {
                        if (uuc.GetCurrentlyUpgradedUnit() != null)
                        {
                            uuc.SpeedUp();
                        }
                    }
                }
            }
        }

        #endregion Public Methods
    }
}
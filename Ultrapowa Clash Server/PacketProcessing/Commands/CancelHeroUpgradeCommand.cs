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
    internal class CancelHeroUpgradeCommand : Command
    {
        #region Private Fields

        readonly int m_vBuildingId;

        #endregion Private Fields

        #region Public Constructors

        public CancelHeroUpgradeCommand(CoCSharpPacketReader br)
        {
            m_vBuildingId = br.ReadInt32WithEndian();
            br.ReadInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var go = level.GameObjectManager.GetGameObjectByID(m_vBuildingId);
            if (go != null)
            {
                if (go.ClassId == 0)
                {
                    var b = (Building) go;
                    var hbc = b.GetHeroBaseComponent();
                    if (hbc != null)
                    {
                        hbc.CancelUpgrade();
                    }
                }
            }
        }

        #endregion Public Methods
    }
}
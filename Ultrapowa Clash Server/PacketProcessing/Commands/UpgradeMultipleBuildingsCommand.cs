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

using System.Collections.Generic;
using System.IO;
using UCS.Files.Logic;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    internal class UpgradeMultipleBuildingsCommand : Command
    {
        #region Public Constructors

        public UpgradeMultipleBuildingsCommand(CoCSharpPacketReader br)
        {
            m_vIsAltResource = br.ReadByte();
            m_vBuildingIdList = new List<int>();
            var buildingCount = br.ReadInt32WithEndian();
            for (var i = 0; i < buildingCount; i++)
            {
                var buildingId = br.ReadInt32WithEndian();
                m_vBuildingIdList.Add(buildingId);
            }
            br.ReadInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var ca = level.GetPlayerAvatar();

            foreach (var buildingId in m_vBuildingIdList)
            {
                var b = (Building) level.GameObjectManager.GetGameObjectByID(buildingId);
                if (b.CanUpgrade())
                {
                    var bd = b.GetBuildingData();
                    var cost = bd.GetBuildCost(b.GetUpgradeLevel() + 1);
                    ResourceData rd;
                    if (m_vIsAltResource == 0)
                        rd = bd.GetBuildResource(b.GetUpgradeLevel() + 1);
                    else
                        rd = bd.GetAltBuildResource(b.GetUpgradeLevel() + 1);
                    if (ca.HasEnoughResources(rd, cost))
                    {
                        if (level.HasFreeWorkers())
                        {
                            ca.SetResourceCount(rd, ca.GetResourceCount(rd) - cost);
                            b.StartUpgrading();
                        }
                    }
                }
            }
        }

        #endregion Public Methods

        #region Private Fields

        readonly List<int> m_vBuildingIdList;
        readonly byte m_vIsAltResource;

        #endregion Private Fields
    }
}
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
    internal class UpgradeBuildingCommand : Command
    {
        #region Public Constructors

        public UpgradeBuildingCommand(CoCSharpPacketReader br)
        {
            BuildingId = br.ReadInt32WithEndian();
            Unknown2 = br.ReadByte();
            Unknown1 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var ca = level.GetPlayerAvatar();
            var go = level.GameObjectManager.GetGameObjectByID(BuildingId);
            if (go !=null)
            {
                var b = (ConstructionItem)go;
                if (b.CanUpgrade())
                {
                    var bd = b.GetConstructionItemData();
                    if (ca.HasEnoughResources(bd.GetBuildResource(b.GetUpgradeLevel() + 1),
                        bd.GetBuildCost(b.GetUpgradeLevel() + 1)))
                    {
                        if (level.HasFreeWorkers())
                        {
                            var rd = bd.GetBuildResource(b.GetUpgradeLevel() + 1);
                            ca.SetResourceCount(rd, ca.GetResourceCount(rd) - bd.GetBuildCost(b.GetUpgradeLevel() + 1));
                            b.StartUpgrading();
                        }
                    }
                }
            }
        }

        #endregion Public Methods

        #region Public Properties

        public int BuildingId { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }

        #endregion Public Properties
    }
}

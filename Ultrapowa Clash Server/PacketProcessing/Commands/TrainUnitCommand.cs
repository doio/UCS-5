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
using UCS.Core;
using UCS.Files.Logic;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing
{
    class TrainUnitCommand : Command
    {
        #region Public Constructors

        public TrainUnitCommand(CoCSharpPacketReader br)
        {
            BuildingId = br.ReadInt32WithEndian();
            Unknown1 = br.ReadUInt32WithEndian();
            UnitType = br.ReadInt32WithEndian();
            Count = br.ReadInt32WithEndian();
            Unknown3 = br.ReadUInt32WithEndian();
            br.ReadInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Properties

        public int BuildingId { get; set; }
        public int Count { get; set; }
        public int UnitType { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown3 { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override void Execute(Level level)
        {
            var go = level.GameObjectManager.GetGameObjectByID(BuildingId);
            var b = (Building)go;
            var c = b.GetUnitProductionComponent();
            var cid = (CombatItemData)ObjectManager.DataTables.GetDataById(UnitType);
            var co = level.GetHomeOwnerAvatar();
            var trainingResource = cid.GetTrainingResource();
            while (Count > 0)
            {
                if (!c.CanAddUnitToQueue(cid))
                    break;
                int trainingCost = cid.GetTrainingCost(co.GetUnitUpgradeLevel(cid));
                if (!co.HasEnoughResources(trainingResource, trainingCost))
                    break;
                co.SetResourceCount(trainingResource, co.GetResourceCount(trainingResource) - trainingCost);
                c.AddUnitToProductionQueue(cid);
                Count--;
            }
        }
    }
    #endregion Public Methods
}
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

namespace UCS.PacketProcessing.Commands
{
    internal class BuyBuildingCommand : Command
    {
        #region Public Constructors

        public BuyBuildingCommand(CoCSharpPacketReader br)
        {
            X = br.ReadInt32WithEndian();
            Y = br.ReadInt32WithEndian();
            BuildingId = br.ReadInt32WithEndian();
            Unknown1 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var ca = level.GetPlayerAvatar();

            var bd = (BuildingData) ObjectManager.DataTables.GetDataById(BuildingId);
            var b = new Building(bd, level);

            if (ca.HasEnoughResources(bd.GetBuildResource(0), bd.GetBuildCost(0)))
            {
                if (bd.IsWorkerBuilding() || level.HasFreeWorkers())
                {
                    var rd = bd.GetBuildResource(0);
                    ca.CommodityCountChangeHelper(0, rd, -bd.GetBuildCost(0));

                    b.StartConstructing(X, Y);
                    level.GameObjectManager.AddGameObject(b);
                }
            }
        }

        #endregion Public Methods

        #region Public Properties

        public int BuildingId { get; set; }
        public uint Unknown1 { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        #endregion Public Properties
    }
}
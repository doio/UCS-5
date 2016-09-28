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
    internal class BuyTrapCommand : Command
    {
        #region Public Constructors

        public BuyTrapCommand(CoCSharpPacketReader br)
        {
            X = br.ReadInt32WithEndian();
            Y = br.ReadInt32WithEndian();
            TrapId = br.ReadInt32WithEndian();
            Unknown1 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var ca = level.GetPlayerAvatar();

            var td = (TrapData) ObjectManager.DataTables.GetDataById(TrapId);
            var t = new Trap(td, level);

            if (ca.HasEnoughResources(td.GetBuildResource(0), td.GetBuildCost(0)))
            {
                if (level.HasFreeWorkers())
                {
                    var rd = td.GetBuildResource(0);
                    ca.CommodityCountChangeHelper(0, rd, -td.GetBuildCost(0));

                    t.StartConstructing(X, Y);
                    level.GameObjectManager.AddGameObject(t);
                }
            }
        }

        #endregion Public Methods

        #region Public Properties

        public int TrapId { get; set; }
        public uint Unknown1 { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        #endregion Public Properties
    }
}
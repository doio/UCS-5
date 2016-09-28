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
    internal class BuyDecoCommand : Command
    {
        #region Public Constructors

        public BuyDecoCommand(CoCSharpPacketReader br)
        {
            X = br.ReadInt32WithEndian();
            Y = br.ReadInt32WithEndian();
            DecoId = br.ReadInt32WithEndian();
            Unknown1 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var ca = level.GetPlayerAvatar();

            var dd = (DecoData) ObjectManager.DataTables.GetDataById(DecoId);

            if (ca.HasEnoughResources(dd.GetBuildResource(), dd.GetBuildCost()))
            {
                var rd = dd.GetBuildResource();
                ca.CommodityCountChangeHelper(0, rd, -dd.GetBuildCost());

                var d = new Deco(dd, level);
                d.SetPositionXY(X, Y);
                level.GameObjectManager.AddGameObject(d);
            }
        }

        #endregion Public Methods

        #region Public Properties

        public int DecoId { get; set; }
        public uint Unknown1 { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        #endregion Public Properties
    }
}
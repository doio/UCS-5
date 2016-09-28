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
    internal class MoveBuildingCommand : Command
    {
        #region Public Constructors

        public MoveBuildingCommand(CoCSharpPacketReader br)
        {
            X = br.ReadInt32WithEndian();
            Y = br.ReadInt32WithEndian();
            BuildingId = br.ReadInt32WithEndian(); //buildingId - 0x1DCD6500;
            Unknown1 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var go = level.GameObjectManager.GetGameObjectByID(BuildingId);
            go.SetPositionXY(X, Y);
        }

        #endregion Public Methods

        #region Public Properties

        public int BuildingId { get; set; }

        //1D CD 65 06 some unique id
        public uint Unknown1 { get; set; }

        public int X { get; set; } //00 00 00 13
        public int Y { get; set; }

        #endregion Public Properties
    }
}
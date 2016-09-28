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
    internal class CancelUnitProductionCommand : Command
    {
        #region Public Constructors

        public CancelUnitProductionCommand(CoCSharpPacketReader br)
        {
            BuildingId = br.ReadInt32WithEndian(); //buildingId - 0x1DCD6500;
            Unknown1 = br.ReadUInt32WithEndian();
            UnitType = br.ReadInt32WithEndian();
            Count = br.ReadInt32WithEndian();
            Unknown3 = br.ReadUInt32WithEndian();
            Unknown4 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var go = level.GameObjectManager.GetGameObjectByID(BuildingId);
            if (Count > 0)
            {
                var b = (Building) go;
                var c = b.GetUnitProductionComponent();
                var cd = (CombatItemData) ObjectManager.DataTables.GetDataById(UnitType);
                do
                {
                    //Ajouter gestion remboursement ressources
                    c.RemoveUnit(cd);
                    Count--;
                }
                while (Count > 0);
            }
        }

        #endregion Public Methods

        #region Public Properties

        public int BuildingId { get; set; }
        public int Count { get; set; }
        public int UnitType { get; set; }
        public uint Unknown1 { get; set; } //00 00 00 00

        //00 3D 09 00
        //00 00 00 01
        public uint Unknown3 { get; set; } //00 00 00 00

        public uint Unknown4 { get; set; }

        #endregion Public Properties
    }
}
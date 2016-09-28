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
    internal class CancelConstructionCommand : Command
    {
        #region Public Constructors

        public CancelConstructionCommand(CoCSharpPacketReader br)
        {
            BuildingId = br.ReadInt32WithEndian(); 
            Unknown1 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var go = level.GameObjectManager.GetGameObjectByID(BuildingId);
            if (go != null)
            {
                if (go.ClassId == 0 || go.ClassId == 4)
                {
                    var constructionItem = (ConstructionItem) go;
                    if (constructionItem.IsConstructing())
                    {
                        constructionItem.CancelConstruction();
                    }
                }
                else if (go.ClassId == 3)
                {
                }
            }
        }

        #endregion Public Methods

        #region Public Properties

        public int BuildingId { get; set; }
        public uint Unknown1 { get; set; }

        #endregion Public Properties
    }
}

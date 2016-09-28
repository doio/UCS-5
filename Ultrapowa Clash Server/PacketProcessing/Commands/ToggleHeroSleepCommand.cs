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

namespace UCS.PacketProcessing.Commands
{
    //Commande 0x0211
    internal class ToggleHeroSleepCommand : Command
    {
        #region Public Constructors

        public ToggleHeroSleepCommand(CoCSharpPacketReader br)
        {
            BuildingId = br.ReadUInt32WithEndian(); //buildingId - 0x1DCD6500;
            FlagSleep = br.ReadByte();
            Unknown1 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        //00 00 02 11 1D CD 65 06 00 00 01 04 CA

        #region Public Properties

        public uint BuildingId { get; set; }
        public byte FlagSleep { get; set; }
        public uint Unknown1 { get; set; }

        #endregion Public Properties
    }
}
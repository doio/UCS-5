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

using System;
using System.IO;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    internal class BuyShieldCommand : Command
    {
        #region Public Constructors

        public BuyShieldCommand(CoCSharpPacketReader br)
        {
            ShieldId = br.ReadInt32WithEndian(); //= shieldId - 0x01312D00;
            Unknown1 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            //Console.WriteLine(ShieldId);
            //Console.WriteLine(Unknown1);
        }

        #endregion Public Methods

        #region Public Properties

        public int ShieldId { get; set; }
        public uint Unknown1 { get; set; }

        #endregion Public Properties
    }
}

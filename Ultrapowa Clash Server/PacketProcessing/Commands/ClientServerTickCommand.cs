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
    internal class ClientServerTickCommand : Command
    {
        #region Public Constructors

        public ClientServerTickCommand(CoCSharpPacketReader br)
        {
            Unknown1 = br.ReadInt32();
            Tick = br.ReadInt32();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
        }

        #endregion Public Methods

        #region Public Properties

        public static int Tick { get; set; }
        public static int Unknown1 { get; set; }

        #endregion Public Properties
    }
}
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
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Commands
{
    internal class MyLeagueCommand : Command
    {
        #region Public Constructors

        public MyLeagueCommand(CoCSharpPacketReader br)
        {

        }

        public override void Execute(Level level)
        {
            //PacketManager.ProcessOutgoingPacket(new LeaguePlayersMessage(level.GetClient()));
        }

        #endregion Public Constructors
    }
}

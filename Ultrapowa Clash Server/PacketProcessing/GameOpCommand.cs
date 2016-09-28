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
using UCS.Core;
using UCS.Core.Network;
using UCS.Logic;
//using static UCS.Core.Debugger;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing
{
    internal class GameOpCommand
    {
        #region Private Fields

        byte m_vRequiredAccountPrivileges;

        #endregion Private Fields

        #region Public Methods

        public static void SendCommandFailedMessage(Client c)
        {
            Console.WriteLine("GameOp command failed. Insufficient privileges. Requster ID -> " + c.GetLevel().GetPlayerAvatar().GetId());
            var p = new GlobalChatLineMessage(c);
            p.SetChatMessage("GameOp command failed. Insufficient privileges.");
            p.SetPlayerId(0);
            p.SetLeagueId(2);
            p.SetPlayerName("Ultrapowa Clash Server");
            PacketManager.ProcessOutgoingPacket(p);
        }

        public virtual void Execute(Level level)
        {
        }

        public byte GetRequiredAccountPrivileges()
        {
            return m_vRequiredAccountPrivileges;
        }

        public void SetRequiredAccountPrivileges(byte level)
        {
            m_vRequiredAccountPrivileges = level;
        }

        #endregion Public Methods
    }
}
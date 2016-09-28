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

using UCS.Core;
using UCS.Core.Network;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.GameOpCommands
{
    internal class BecomeLeaderGameOpCommand : GameOpCommand
    {
        #region Private Fields

        readonly string[] m_vArgs;

        #endregion Private Fields

        #region Public Constructors

        public BecomeLeaderGameOpCommand(string[] args)
        {
            m_vArgs = args;
            SetRequiredAccountPrivileges(5);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            if (level.GetAccountPrivileges() >= GetRequiredAccountPrivileges())
            {
                var clanid = level.GetPlayerAvatar().GetAllianceId();
                if (clanid != 0)
                {
                    foreach (
                        var pl in
                            ObjectManager.GetAlliance(level.GetPlayerAvatar().GetAllianceId()).GetAllianceMembers())
                        if (pl.GetRole() == 2)
                        {
                            pl.SetRole(4);
                            break;
                        }
                    level.GetPlayerAvatar().SetAllianceRole(2);
                }
            }
            else
            {
                var p = new GlobalChatLineMessage(level.GetClient());
                p.SetChatMessage("GameOp command failed. Access to Admin GameOP is prohibited.");
                p.SetPlayerId(0);
                p.SetLeagueId(22);
                p.SetPlayerName("UCS Bot");
                PacketManager.ProcessOutgoingPacket(p);
            }
        }

        #endregion Public Methods
    }
}
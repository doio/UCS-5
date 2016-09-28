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
using UCS.Core.Network;
using UCS.Logic;
using UCS.Logic.AvatarStreamEntry;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.GameOpCommands
{
    internal class GetIdGameopCommand : GameOpCommand
    {
        #region Private Fields

        readonly string[] m_vArgs;

        #endregion Private Fields

        #region Public Constructors

        public GetIdGameopCommand(string[] args)
        {
            m_vArgs = args;
            SetRequiredAccountPrivileges(0);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            if (level.GetAccountPrivileges() >= GetRequiredAccountPrivileges())
            {
                if (m_vArgs.Length >= 1)
                {
                    var avatar = level.GetPlayerAvatar();
                    var mail = new AllianceMailStreamEntry();
                    mail.SetId((int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                    mail.SetSenderId(avatar.GetId());
                    mail.SetSenderAvatarId(avatar.GetId());
                    mail.SetSenderName(avatar.GetAvatarName());
                    mail.SetIsNew(0);
                    mail.SetAllianceId(1);
                    mail.SetAllianceBadgeData(0);
                    mail.SetAllianceName("UCS Information");
                    mail.SetMessage("Your Player ID: " + level.GetPlayerAvatar().GetId());
                    mail.SetSenderLevel(avatar.GetAvatarLevel());
                    mail.SetSenderLeagueId(avatar.GetLeagueId());

                    var p = new AvatarStreamEntryMessage(level.GetClient());
                    p.SetAvatarStreamEntry(mail);
                    PacketManager.ProcessOutgoingPacket(p);
                }
            }
            else
            {
                SendCommandFailedMessage(level.GetClient());
            }
        }

        #endregion Public Methods
    }
}
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
using System.Linq;
using UCS.Core;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.Logic.StreamEntry;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    class LeaveAllianceMessage : Message
    {
        #region Public Fields

        public static bool done;

        #endregion Public Fields

        #region Public Constructors

        public LeaveAllianceMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {

        }

        #endregion Public Constructors

        #region Public Methods

        public override void Decode()
        {

        }

        public override void Process(Level level)
        {
            var avatar = level.GetPlayerAvatar();
            var alliance = ObjectManager.GetAlliance(level.GetPlayerAvatar().GetAllianceId());

            if (avatar.GetAllianceRole() == 2 && alliance.GetAllianceMembers().Count > 1)
            {
                var members = alliance.GetAllianceMembers();
                foreach (AllianceMemberEntry player in members.Where(player => player.GetRole() >= 3))
                {
                    player.SetRole(2);
                    done = true;
                    break;
                }
                if (!done)
                {
                    var count = alliance.GetAllianceMembers().Count;
                    var rnd = new Random();
                    var id = rnd.Next(1, count);
                    while (id != level.GetPlayerAvatar().GetId())
                        id = rnd.Next(1, count);
                    var loop = 0;
                    foreach (AllianceMemberEntry player in members)
                    {
                        loop++;
                        if (loop == id)
                        {
                            player.SetRole(2);
                            break;
                        }
                    }
                }
            }

            alliance.RemoveMember(avatar.GetId());
            avatar.SetAllianceId(0);

            if (alliance.GetAllianceMembers().Count > 0)
            {
                var eventStreamEntry = new AllianceEventStreamEntry();
                eventStreamEntry.SetId((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                eventStreamEntry.SetAvatar(avatar);
                eventStreamEntry.SetEventType(4);
                eventStreamEntry.SetAvatarId(avatar.GetId());
                eventStreamEntry.SetAvatarName(avatar.GetAvatarName());
                alliance.AddChatMessage(eventStreamEntry);
                foreach (Level onlinePlayer in ResourcesManager.GetOnlinePlayers())
                    if (onlinePlayer.GetPlayerAvatar().GetAllianceId() == alliance.GetAllianceId())
                    {
                        AllianceStreamEntryMessage p = new AllianceStreamEntryMessage(onlinePlayer.GetClient());
                        p.SetStreamEntry(eventStreamEntry);
                        PacketManager.ProcessOutgoingPacket(p);
                    }
            }
            else
            {
                DatabaseManager.Singelton.RemoveAlliance(alliance);
            }
            PacketManager.ProcessOutgoingPacket(new LeaveAllianceOkMessage(Client, alliance));
        }
        #endregion Public Methods
    }
}

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
using UCS.Core;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.Logic.StreamEntry;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class EditClanSettingsMessage : Message
    {
        #region Public Constructors

        public EditClanSettingsMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Private Fields

        int m_vAllianceBadgeData;
        string m_vAllianceDescription;
        int m_vAllianceOrigin;
        int m_vAllianceType;
        int m_vRequiredScore;
        int m_vWarFrequency;
        byte m_vWarLogPublic;      
        int Unknown;

        #endregion Private Fields

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader (new MemoryStream(GetData())))
            {
                m_vAllianceDescription = br.ReadScString();
                Unknown = br.ReadInt32WithEndian();
                m_vAllianceBadgeData = br.ReadInt32WithEndian();
                m_vAllianceType = br.ReadInt32WithEndian();
                m_vRequiredScore = br.ReadInt32WithEndian();
                m_vWarFrequency = br.ReadInt32WithEndian();
                m_vAllianceOrigin = br.ReadInt32WithEndian();
                m_vWarLogPublic = br.ReadByte();
            }
        }

        public override void Process(Level level)
        {
            //Clans Edit Manager
            var alliance = ObjectManager.GetAlliance(level.GetPlayerAvatar().GetAllianceId());
            if (alliance != null)
            {
                alliance.SetAllianceDescription(m_vAllianceDescription);
                alliance.SetAllianceBadgeData(m_vAllianceBadgeData);
                alliance.SetAllianceType(m_vAllianceType);
                alliance.SetRequiredScore(m_vRequiredScore);
                alliance.SetWarFrequency(m_vWarFrequency);
                alliance.SetAllianceOrigin(m_vAllianceOrigin);
                alliance.SetWarPublicStatus(m_vWarLogPublic);

                var avatar = level.GetPlayerAvatar();
                var allianceId = avatar.GetAllianceId();
                var eventStreamEntry = new AllianceEventStreamEntry();
                eventStreamEntry.SetId((int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                eventStreamEntry.SetAvatar(avatar);
                eventStreamEntry.SetEventType(10);
                eventStreamEntry.SetAvatarId(avatar.GetId());
                eventStreamEntry.SetAvatarName(avatar.GetAvatarName());
                eventStreamEntry.SetSenderId(avatar.GetId());
                eventStreamEntry.SetSenderName(avatar.GetAvatarName());
                alliance.AddChatMessage(eventStreamEntry);

                foreach (var onlinePlayer in ResourcesManager.GetOnlinePlayers())
                    if (onlinePlayer.GetPlayerAvatar().GetAllianceId() == allianceId)
                    {
                        var p = new AllianceStreamEntryMessage(onlinePlayer.GetClient());
                        p.SetStreamEntry(eventStreamEntry);
                        PacketManager.ProcessOutgoingPacket(p);
                        PacketManager.ProcessOutgoingPacket(new OwnHomeDataMessage(Client, level));
                        PacketManager.ProcessOutgoingPacket(new AllianceDataMessage(Client, alliance));
                    }

                DatabaseManager.Singelton.Save(alliance);
            }
        }

        #endregion Public Methods
    }
}

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
using UCS.Core;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Commands;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class JoinAllianceMessage : Message
    {
        #region Private Fields

        long m_vAllianceId;

        #endregion Private Fields

        #region Public Constructors

        public JoinAllianceMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
                m_vAllianceId = br.ReadInt64WithEndian();
            }
        }

        public override void Process(Level level)
        {
            var alliance = ObjectManager.GetAlliance(m_vAllianceId);
            if (alliance != null)
            {
                if (!alliance.IsAllianceFull())
                {
                    level.GetPlayerAvatar().SetAllianceId(alliance.GetAllianceId());
                    var member = new AllianceMemberEntry(level.GetPlayerAvatar().GetId());
                    member.SetRole(1);
                    alliance.AddAllianceMember(member);

                    var joinAllianceCommand = new JoinAllianceCommand();
                    joinAllianceCommand.SetAlliance(alliance);
                    var availableServerCommandMessage = new AvailableServerCommandMessage(Client);
                    availableServerCommandMessage.SetCommandId(1);
                    availableServerCommandMessage.SetCommand(joinAllianceCommand);
                    PacketManager.ProcessOutgoingPacket(availableServerCommandMessage);
                    PacketManager.ProcessOutgoingPacket(new OwnHomeDataMessage(Client, level));
                    PacketManager.ProcessOutgoingPacket(new AllianceStreamMessage(Client, alliance));
                    PacketManager.ProcessOutgoingPacket(new AllianceFullEntryMessage(Client, alliance));
                }
            }
        }

        #endregion Public Methods
    }
}

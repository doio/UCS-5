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
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class AskForAvatarProfileMessage : Message
    {
        #region Public Constructors

        public AskForAvatarProfileMessage(PacketProcessing.Client client, CoCSharpPacketReader br)
            : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Private Fields

        long m_vAvatarId;
        long m_vCurrentHomeId;

        #endregion Private Fields

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
                m_vAvatarId = br.ReadInt64WithEndian();
                m_vCurrentHomeId = br.ReadInt64WithEndian();
            }
        }

        public override void Process(Level level)
        {
            var targetLevel = ResourcesManager.GetPlayer(m_vAvatarId);
            if (targetLevel != null)
            {
                targetLevel.Tick();
                var p = new AvatarProfileMessage(Client);
                p.SetLevel(targetLevel);
                PacketManager.ProcessOutgoingPacket(p);
            }
        }

        #endregion Public Methods
    }
}
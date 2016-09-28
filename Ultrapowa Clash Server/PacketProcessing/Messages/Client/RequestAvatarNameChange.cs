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
    internal class RequestAvatarNameChange : Message
    {
        #region Public Constructors

        public RequestAvatarNameChange(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public string PlayerName { get; set; }

        public byte Unknown1 { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
                PlayerName = br.ReadScString();
            }
        }

        public override void Process(Level level)
        {
            var id = level.GetPlayerAvatar().GetId();
            var l = ResourcesManager.GetPlayer(id, true);
            if (l != null)
            {
                l.GetPlayerAvatar().SetName(PlayerName);
                var p = new AvatarNameChangeOkMessage(l.GetClient());
                p.SetAvatarName(PlayerName);
                PacketManager.ProcessOutgoingPacket(p);
            }
        }

        #endregion Public Methods
    }
}
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

namespace UCS.PacketProcessing.Messages.Client
{
    internal class JoinRequestAllianceMessage : Message
    {
        #region Public Constructors

        public JoinRequestAllianceMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public static string Message { get; set; }
        public static bool Unknown1 { get; set; }
        public static long Unknown2 { get; set; }
        public static int Unknown3 { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
                Unknown1 = br.ReadBoolean();
                Unknown2 = br.ReadInt64();
                Unknown3 = br.ReadInt16();
                Message = br.ReadString();
            }
        }

        public override void Process(Level level)
        {
            PacketManager.ProcessOutgoingPacket(new AnswerJoinRequestAllianceMessage(Client));
        }

        #endregion Public Methods
    }
}
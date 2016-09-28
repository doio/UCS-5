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
    internal class HandshakeRequest : Message
    {

        public HandshakeRequest(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        public string Hash;
        public int MajorVersion;
        public int MinorVersion;
        public int Unknown1;
        public int Unknown2;
        public int Unknown4;
        public int Unknown6;
        public int Unknown7;

        public override void Decode()
        {
            using (var reader = new BinaryReader(new MemoryStream(GetData())))
            {
                Unknown1 = reader.ReadInt32();
                Unknown2 = reader.ReadInt32();
                MajorVersion = reader.ReadInt32();
                Unknown4 = reader.ReadInt32();
                MinorVersion = reader.ReadInt32();
                Hash = reader.ReadString();
                Unknown6 = reader.ReadInt32();
                Unknown7 = reader.ReadInt32();
            }
            if (MajorVersion == 8)
                Client.CState = 1; // Clash of Clans 8.x
            else
                Client.CState = 0; // Old Clash of Clans client
        }

        public override void Process(Level level)
        {
            PacketManager.ProcessOutgoingPacket(new HandshakeSuccess(Client, this));
        }

    }
}
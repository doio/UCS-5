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
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Client
{
    class NewsSeenMessage : Message
    {
        public NewsSeenMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {

        }

        public override void Decode()
        {

        }

        public override void Process(Level level)
        {

        }
    }
}

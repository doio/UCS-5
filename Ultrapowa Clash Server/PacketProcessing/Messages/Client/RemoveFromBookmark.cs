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
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class RemoveFromBookmarkMessage : Message
    {
        #region Public Constructors

        public RemoveFromBookmarkMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())));
                //Console.WriteLine("ID OF CLAN -> " + br.ReadInt32());
        }

        public override void Process(Level level)
        {
            PacketManager.ProcessOutgoingPacket(new BookmarkRemoveAllianceMessage(Client));
        }

        #endregion Public Methods
    }
}
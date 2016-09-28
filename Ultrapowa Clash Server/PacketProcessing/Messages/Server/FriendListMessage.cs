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

using System.Collections.Generic;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Server
{
    //Packet 20105
    internal class FriendListMessage : Message
    {
        #region Public Constructors

        public FriendListMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(20105);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();
            pack.AddInt32(0);
            pack.AddInt32(0);
            pack.AddDataSlots(new List<DataSlot>());
            Encrypt(pack.ToArray());
        }

        #endregion Public Methods
    }
}
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
using UCS.PacketProcessing.Messages.Client;

namespace UCS.PacketProcessing.Messages.Server
{
    //Packet 20108
    internal class KeepAliveOkMessage : Message
    {
        #region Public Constructors

        public KeepAliveOkMessage(PacketProcessing.Client client, KeepAliveMessage cka) : base(client)
        {
            SetMessageType(20108);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var data = new List<byte>();
            Encrypt(data.ToArray());
        }

        #endregion Public Methods
    }
}
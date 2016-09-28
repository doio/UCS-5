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

namespace UCS.PacketProcessing.Messages.Server
{
    internal class BookmarkAddAllianceMessage : Message
    {
        #region Public Constructors

        public BookmarkAddAllianceMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24343);
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
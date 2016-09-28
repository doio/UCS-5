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

namespace UCS.PacketProcessing.Messages.Server
{
    internal class BookmarkMessage : Message
    {
        #region Public Constructors

        public BookmarkMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24340);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var data = new List<byte>();
            data.AddInt64(1);
            data.AddInt64(2);
            Encrypt(data.ToArray());
        }

        #endregion Public Methods
    }
}
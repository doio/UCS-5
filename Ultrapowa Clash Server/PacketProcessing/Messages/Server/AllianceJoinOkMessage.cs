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
    internal class AllianceJoinOkMessage : Message
    {
        #region Public Constructors

        public AllianceJoinOkMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24303);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();
            Encrypt(pack.ToArray());
        }

        #endregion Public Methods
    }
}
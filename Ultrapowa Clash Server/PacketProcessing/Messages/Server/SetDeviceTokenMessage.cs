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
    //Packet 20113
    internal class SetDeviceTokenMessage : Message
    {
        readonly Level level;

        #region Public Constructors

        public SetDeviceTokenMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(20113);
            level = client.GetLevel();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();
            pack.AddString(level.GetPlayerAvatar().GetUserToken());
            Encrypt(pack.ToArray());
        }

        #endregion Public Methods
    }
}
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
using UCS.Core;
using UCS.Helpers;
using UCS.Logic.AvatarStreamEntry;

namespace UCS.PacketProcessing.Messages.Server
{
    //Packet 24411
    internal class AvatarStreamMessage : Message
    {
        #region Private Fields

        AvatarStreamEntry m_vAvatarStreamEntry;

        #endregion Private Fields

        #region Public Constructors

        public AvatarStreamMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24411);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var pl = Client.GetLevel().GetPlayerAvatar();
            var pack = new List<byte>();
            pack.AddInt32(2);
            pack.AddInt64(pl.GetId());
            pack.Add(0);
            pack.AddInt64(pl.GetAllianceId());
            pack.AddString(ObjectManager.GetAlliance(pl.GetAllianceId()).GetAllianceName());
            pack.AddInt32(0);
            pack.AddInt32(0);
            pack.AddInt32(0);
            pack.Add(0);
            pack.AddString("Win");
            pack.Add(0);
            pack.AddInt32(0);
            pack.AddInt32(0);
            pack.AddInt32(0);
            Encrypt(pack.ToArray());
        }

        #endregion Public Methods
    }
}
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
using System.Linq;
using UCS.Core;
using UCS.Helpers;

namespace UCS.PacketProcessing.Messages.Server
{
    internal class BookmarkListMessage : Message
    {
        #region Public Constructors

        public BookmarkListMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24341);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var data = new List<byte>();
            var packet1 = new List<byte>();
            var i = 1;
            foreach (var alliance in ObjectManager.GetInMemoryAlliances().OrderByDescending(t => t.GetScore()))
            {
                packet1.AddInt64(alliance.GetAllianceId());
                packet1.AddString(alliance.GetAllianceName());
                packet1.AddInt32(alliance.GetAllianceBadgeData());
                packet1.AddInt32(alliance.GetAllianceType());
                packet1.AddInt32(alliance.GetAllianceMembers().Count);
                packet1.AddInt32(alliance.GetScore());
                packet1.AddInt64(0); // ?
                packet1.AddInt64(0); // ?
                packet1.AddInt64(0); // ?
                packet1.AddInt64(0); // ?
                packet1.AddInt32(alliance.GetAllianceLevel()); //lvl du clan
                packet1.AddInt32(0); // ?
                i++;
            }
            data.AddInt32(i - 1);
            data.AddRange(packet1);
            Encrypt(data.ToArray());
        }

        #endregion Public Methods
    }
}
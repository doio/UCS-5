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
using System.Collections.Generic;
using System.Linq;
using UCS.Core;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Server
{
    internal class GlobalAlliancesMessage : Message
    {
        #region Private Fields

        List<Alliance> m_vAlliances;

        #endregion Private Fields

        #region Public Constructors

        public GlobalAlliancesMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24401);
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
                packet1.AddString(alliance.GetAllianceName() + " #" + alliance.GetAllianceId());
                packet1.AddInt32(i);
                packet1.AddInt32(alliance.GetScore());
                packet1.AddInt32(i);
                packet1.AddInt32(alliance.GetAllianceBadgeData());
                packet1.AddInt32(alliance.GetAllianceMembers().Count);
                packet1.AddInt32(0);
                packet1.AddInt32(alliance.GetAllianceLevel());
                if (i >= 101)
                    break;
                i++;
            }

            data.AddInt32(i - 1);
            data.AddRange(packet1);

            data.AddInt32((int) TimeSpan.FromDays(1).TotalSeconds);
            data.AddInt32(3);
            data.AddInt32(50000);
            data.AddInt32(30000);
            data.AddInt32(15000);
            Encrypt(data.ToArray());
        }

        #endregion Public Methods
    }
}

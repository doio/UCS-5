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
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Server
{
    //Packet 24113
    internal class VisitedHomeDataMessage : Message
    {
        #region Public Constructors

        public VisitedHomeDataMessage(PacketProcessing.Client client, Level ownerLevel, Level visitorLevel) : base(client)
        {
            SetMessageType(24113);
            m_vOwnerLevel = ownerLevel;
            m_vVisitorLevel = visitorLevel;
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var data = new List<byte>();

            data.AddRange(BitConverter.GetBytes(m_vOwnerLevel.GetPlayerAvatar().GetSecondsFromLastUpdate()).Reverse());
            //data.AddInt32(0); //replace previous after patch

            var ch = new ClientHome(m_vOwnerLevel.GetPlayerAvatar().GetId());
            ch.SetShieldDurationSeconds(m_vOwnerLevel.GetPlayerAvatar().RemainingShieldTime);
            ch.SetHomeJSON(m_vOwnerLevel.SaveToJSON());

            data.AddRange(ch.Encode());
            data.AddRange(m_vOwnerLevel.GetPlayerAvatar().Encode());

            data.Add(1);
            data.AddRange(m_vVisitorLevel.GetPlayerAvatar().Encode());
            data.AddInt32(200);
            data.AddInt32(100);
            data.AddInt32(0);
            data.AddInt32(0);
            data.Add(0);
            Encrypt(data.ToArray());
        }

        #endregion Public Methods

        #region Private Fields

        readonly Level m_vOwnerLevel;
        readonly Level m_vVisitorLevel;

        #endregion Private Fields
    }
}
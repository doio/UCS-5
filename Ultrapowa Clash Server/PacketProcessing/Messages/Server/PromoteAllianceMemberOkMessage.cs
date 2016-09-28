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
using UCS.PacketProcessing.Messages.Client;

namespace UCS.PacketProcessing.Messages.Server
{
    //Packet 24340
    internal class PromoteAllianceMemberOkMessage : Message
    {
        #region Public Constructors

        public PromoteAllianceMemberOkMessage(PacketProcessing.Client client, Level level, PromoteAllianceMemberMessage pam)
            : base(client)
        {
            SetMessageType(24306);
            m_vId = pam.m_vId;
            m_vRole = pam.m_vRole;
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();
            pack.AddInt64(m_vId);
            pack.AddInt32(m_vRole);
            Encrypt(pack.ToArray());
        }

        #endregion Public Methods

        #region Private Fields

        readonly long m_vId;
        readonly int m_vRole;

        #endregion Private Fields
    }
}
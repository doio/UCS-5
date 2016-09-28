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
    //Packet 24111
    internal class LeaveAllianceOkMessage : Message
    {
        #region Public Constructors

        public LeaveAllianceOkMessage(PacketProcessing.Client client, Alliance alliance)
            : base(client)
        {
            SetMessageType(24111);

            m_vServerCommandType = 0x02;
            m_vAlliance = alliance;
        }

        #endregion Public Constructors

        #region Public Methods

        //00 00 00 02 00 00 00 3B 00 0A 40 1E 00 00 00 01 FF FF FF FF
        public override void Encode()
        {
            var pack = new List<byte>();
            pack.AddInt32(m_vServerCommandType);
            pack.AddInt64(m_vAlliance.GetAllianceId());
            pack.AddInt32(1); //reason? 1= leave, 2=kick
            pack.AddInt32(-1);
            Encrypt(pack.ToArray());
        }

        #endregion Public Methods

        #region Private Fields

        readonly Alliance m_vAlliance;
        readonly int m_vServerCommandType;

        #endregion Private Fields
    }
}
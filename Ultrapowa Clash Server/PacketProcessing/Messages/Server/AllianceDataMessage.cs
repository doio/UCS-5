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
    internal class AllianceDataMessage : Message
    {
        #region Private Fields

        readonly Alliance m_vAlliance;

        #endregion Private Fields

        #region Public Constructors

        public AllianceDataMessage(PacketProcessing.Client client, Alliance alliance)
            : base(client)
        {
            SetMessageType(24301);
            m_vAlliance = alliance;
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();

            var allianceMembers = m_vAlliance.GetAllianceMembers(); //avoid concurrent access issues
            pack.AddRange(m_vAlliance.EncodeFullEntry());
            pack.AddString(m_vAlliance.GetAllianceDescription());
            pack.AddInt32(0);
            pack.Add(0);

            pack.AddInt32(allianceMembers.Count);
            foreach (var allianceMember in allianceMembers)
                pack.AddRange(allianceMember.Encode());
            Encrypt(pack.ToArray());
        }

        #endregion Public Methods
    }
}
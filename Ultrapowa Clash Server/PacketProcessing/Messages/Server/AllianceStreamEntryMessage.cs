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
using UCS.Logic.StreamEntry;

namespace UCS.PacketProcessing.Messages.Server
{
    internal class AllianceStreamEntryMessage : Message
    {
        #region Private Fields

        StreamEntry m_vStreamEntry;

        #endregion Private Fields

        #region Public Constructors

        public AllianceStreamEntryMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24312);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();
            pack.AddRange(m_vStreamEntry.Encode());
            Encrypt(pack.ToArray());
        }

        public void SetStreamEntry(StreamEntry entry)
        {
            m_vStreamEntry = entry;
        }

        #endregion Public Methods
    }
}
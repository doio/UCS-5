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
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Server
{
    internal class AllianceStreamMessage : Message
    {
        #region Private Fields

        readonly Alliance m_vAlliance;

        #endregion Private Fields

        #region Public Constructors

        public AllianceStreamMessage(PacketProcessing.Client client, Alliance alliance) : base(client)
        {
            SetMessageType(24311);
            m_vAlliance = alliance;
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();
            var chatMessages = m_vAlliance.GetChatMessages().ToList();
            pack.AddInt32(chatMessages.Count);
            foreach (var chatMessage in chatMessages)
            {
                pack.AddRange(chatMessage.Encode());
            }
            Encrypt(pack.ToArray());
        }

        #endregion Public Methods
    }
}
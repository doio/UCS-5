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
    internal class AllianceListMessage : Message
    {
        #region Public Constructors

        public AllianceListMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24310);
            m_vAlliances = new List<Alliance>();
        }

        #endregion Public Constructors

        #region Private Fields

        List<Alliance> m_vAlliances;
        string m_vSearchString;

        #endregion Private Fields

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();
            pack.AddString(m_vSearchString);
            pack.AddInt32(m_vAlliances.Count);
            foreach (var alliance in m_vAlliances)
            {
                pack.AddRange(alliance.EncodeFullEntry());
            }
            Encrypt(pack.ToArray());
        }

        public void SetAlliances(List<Alliance> alliances)
        {
            m_vAlliances = alliances;
        }

        public void SetSearchString(string searchString)
        {
            m_vSearchString = searchString;
        }

        #endregion Public Methods
    }
}
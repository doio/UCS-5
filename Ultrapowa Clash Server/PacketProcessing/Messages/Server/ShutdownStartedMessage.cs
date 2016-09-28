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

namespace UCS.PacketProcessing.Messages.Server
{
    //Packet 20161
    internal class ShutdownStartedMessage : Message
    {
        #region Private Fields

        int m_vCode;

        #endregion Private Fields

        #region Public Constructors

        public ShutdownStartedMessage(PacketProcessing.Client client)
            : base(client)
        {
            SetMessageType(20161);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var data = new List<byte>();
            data.AddInt32(m_vCode);
            Encrypt(data.ToArray());
        }

        public void SetCode(int code)
        {
            m_vCode = code;
        }

        #endregion Public Methods
    }
}
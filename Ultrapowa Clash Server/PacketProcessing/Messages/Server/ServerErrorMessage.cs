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
    //Packet 24115
    internal class ServerErrorMessage : Message
    {
        #region Private Fields

        string m_vErrorMessage;

        #endregion Private Fields

        #region Public Constructors

        public ServerErrorMessage(PacketProcessing.Client client)
            : base(client)
        {
            SetMessageType(24115);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var data = new List<byte>();
            data.AddString(m_vErrorMessage);
            Encrypt(data.ToArray());
        }

        public void SetErrorMessage(string message)
        {
            m_vErrorMessage = message;
        }

        #endregion Public Methods
    }
}
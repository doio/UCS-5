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
    //Packet 24111
    internal class AvailableServerCommandMessage : Message
    {
        #region Public Constructors

        public AvailableServerCommandMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24111);
        }

        #endregion Public Constructors

        #region Private Fields

        Command m_vCommand;
        int m_vServerCommandId;

        #endregion Private Fields

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();
            pack.AddInt32(m_vServerCommandId);
            pack.AddRange(m_vCommand.Encode());
            Encrypt(pack.ToArray());
        }

        public void SetCommand(Command c)
        {
            m_vCommand = c;
        }

        public void SetCommandId(int id)
        {
            m_vServerCommandId = id;
        }

        #endregion Public Methods
    }
}
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
    //Packet 24334
    internal class AvatarProfileMessage : Message
    {
        #region Private Fields

        Level m_vLevel;

        #endregion Private Fields

        #region Public Constructors

        public AvatarProfileMessage(PacketProcessing.Client client)
            : base(client)
        {
            SetMessageType(24334);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var pack = new List<byte>();
            var ch = new ClientHome(m_vLevel.GetPlayerAvatar().GetId());
            ch.SetHomeJSON(m_vLevel.SaveToJSON());

            pack.AddRange(m_vLevel.GetPlayerAvatar().Encode());
            pack.AddInt32(ch.GetHomeJSON().Length + 4);
            pack.AddInt32(unchecked((int) 0xFFFF0000));
            pack.AddRange(ch.GetHomeJSON());

            pack.AddInt32(200);
            pack.AddInt32(100);
            pack.AddInt32(0);
            pack.AddInt32(0);
            pack.Add(0);
            Encrypt(pack.ToArray());
        }

        public void SetLevel(Level level)
        {
            m_vLevel = level;
        }

        #endregion Public Methods
    }
}
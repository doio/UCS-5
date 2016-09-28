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
    internal class AllianceWarDataMessage : Message
    {
        #region Public Constructors

        public AllianceWarDataMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24331);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var data = new List<byte>();
            data.AddInt32(0);
            data.AddInt32(0);

            data.AddInt64(1); // Team ID
            data.AddString("Ultrapowa");
            data.AddInt32(0);
            data.AddInt32(1);
            data.Add(0);
            data.AddRange(new List<byte> { 1, 2, 3, 4 });
            data.AddInt32(0);
            data.AddInt32(0);
            data.AddInt32(0);
            data.AddInt32(0);
            data.AddInt32(0);

            data.AddInt64(1); // Team ID
            data.AddString("Ultrapowa");
            data.AddInt32(0);
            data.AddInt32(1);
            data.Add(0);
            data.AddRange(new List<byte> { 1, 2, 3, 4 });
            data.AddInt32(0);
            data.AddInt32(0);
            data.AddInt32(0);
            data.AddInt32(0);
            data.AddInt32(0);

            data.AddInt64(11);

            data.AddInt32(0);
            data.AddInt32(0);

            data.AddInt32(1);
            data.AddInt32(3600);
            data.AddInt64(1);
            data.AddInt64(1);
            data.AddInt64(2);
            data.AddInt64(2);

            data.AddString("Ultra");
            data.AddString("Powa");

            data.AddInt32(2);
            data.AddInt32(1);
            data.AddInt32(50);

            data.AddInt32(0);

            data.AddInt32(8);
            data.AddInt32(0);
            data.AddInt32(0);
            data.Add(0);
            data.AddInt32(0);
            data.AddInt32(0);
            data.AddInt32(0);
            data.AddInt32(0);

            Encrypt(data.ToArray());
        }

        #endregion Public Methods
    }
}

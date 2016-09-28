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

using System.IO;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class ReportPlayerMessage : Message
    {
        #region Public Constructors

        public ReportPlayerMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
            }
        }

        public override void Process(Level level)
        {
        }

        #endregion Public Methods
    }
}
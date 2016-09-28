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
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class AskForAllianceWarHistoryMessage : Message
    {
        #region Public Constructors

        public AskForAllianceWarHistoryMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Private Properties

        static long AllianceID { get; set; }
        static long WarID { get; set; }

        #endregion Private Properties

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
                AllianceID = br.ReadInt64();
                WarID = br.ReadInt64();
            }
        }

        public override void Process(Level level)
        {
            PacketManager.ProcessOutgoingPacket(new AllianceWarHistoryMessage(Client));
        }

        #endregion Public Methods
    }
}
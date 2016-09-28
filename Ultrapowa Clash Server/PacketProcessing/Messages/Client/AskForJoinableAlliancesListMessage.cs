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
using System.IO;
using System.Linq;
using UCS.Core;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class AskForJoinableAlliancesListMessage : Message
    {
        #region Private Fields

        const int m_vAllianceLimit = 40;

        #endregion Private Fields

        #region Public Constructors

        public AskForJoinableAlliancesListMessage(PacketProcessing.Client client, CoCSharpPacketReader br)
            : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Decode()
        {
        }

        public override void Process(Level level)
        {
            var alliances = ObjectManager.GetInMemoryAlliances();
            var joinableAlliances = new List<Alliance>();
            var i = 0;
            var j = 0;
            while (j < m_vAllianceLimit && i < alliances.Count)
            {
                if (alliances[i].GetAllianceMembers().Count != 0 && !alliances[i].IsAllianceFull())
                {
                    joinableAlliances.Add(alliances[i]);
                    j++;
                }
                i++;
            }
            joinableAlliances = joinableAlliances.ToList();

            var p = new JoinableAllianceListMessage(Client);
            p.SetJoinableAlliances(joinableAlliances);
            PacketManager.ProcessOutgoingPacket(p);
        }

        #endregion Public Methods
    }
}
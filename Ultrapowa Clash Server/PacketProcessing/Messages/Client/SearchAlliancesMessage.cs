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
    internal class SearchAlliancesMessage : Message
    {
        #region Public Constructors

        public SearchAlliancesMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Private Fields

        const int m_vAllianceLimit = 60;
        int m_vAllianceOrigin;
        int m_vAllianceScore;
        int m_vMaximumAllianceMembers;
        int m_vMinimumAllianceLevel;
        int m_vMinimumAllianceMembers;
        string m_vSearchString;
        byte m_vShowOnlyJoinableAlliances;
        int m_vWarFrequency;

        #endregion Private Fields

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
                m_vSearchString = br.ReadScString();
                m_vWarFrequency = br.ReadInt32WithEndian();
                m_vAllianceOrigin = br.ReadInt32WithEndian();
                m_vMinimumAllianceMembers = br.ReadInt32WithEndian();
                m_vMaximumAllianceMembers = br.ReadInt32WithEndian();
                m_vAllianceScore = br.ReadInt32WithEndian();
                m_vShowOnlyJoinableAlliances = br.ReadByte();
                br.ReadInt32WithEndian();
                m_vMinimumAllianceLevel = br.ReadInt32WithEndian();
            }
        }

        public override void Process(Level level)
        {
            var alliances = ObjectManager.GetInMemoryAlliances();
            var joinableAlliances = new List<Alliance>();
            var i = 0;
            var j = 0;
            while (j < m_vAllianceLimit && i < alliances.Count)
            {
                if (alliances[i].GetAllianceMembers().Count != 0
                    && alliances[i].GetAllianceName().Contains(m_vSearchString))
                {
                    joinableAlliances.Add(alliances[i]);
                    j++;
                }
                i++;
            }
            joinableAlliances = joinableAlliances.ToList();

            var p = new AllianceListMessage(Client);
            p.SetAlliances(joinableAlliances);
            p.SetSearchString(m_vSearchString);
            PacketManager.ProcessOutgoingPacket(p);
        }

        #endregion Public Methods
    }
}
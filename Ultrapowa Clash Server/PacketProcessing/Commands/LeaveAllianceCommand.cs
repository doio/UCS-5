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
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    internal class LeaveAllianceCommand : Command
    {
        #region Private Fields

        Alliance m_vAlliance;
        int m_vReason;

        #endregion Private Fields

        #region Public Constructors

        public LeaveAllianceCommand()
        {
        }

        public LeaveAllianceCommand(CoCSharpPacketReader br)
        {
            br.ReadInt64WithEndian();
            br.ReadInt32WithEndian();
            br.ReadInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override byte[] Encode()
        {
            var data = new List<byte>();
            data.AddInt64(m_vAlliance.GetAllianceId());
            data.AddInt32(m_vReason);
            data.AddInt32(-1);
            return data.ToArray();
        }

        public void SetAlliance(Alliance alliance)
        {
            m_vAlliance = alliance;
        }

        public void SetReason(int reason)
        {
            m_vReason = reason;
        }

        #endregion Public Methods
    }
}
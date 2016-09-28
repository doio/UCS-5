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
using UCS.Core;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    internal class LoadTurretCommand : Command
    {
        #region Public Constructors

        public LoadTurretCommand(CoCSharpPacketReader br)
        {
            m_vUnknown1 = br.ReadUInt32WithEndian();
            m_vBuildingId = br.ReadInt32WithEndian();
            m_vUnknown2 = br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var go = level.GameObjectManager.GetGameObjectByID(m_vBuildingId);
            if (go != null)
                if (go.GetComponent(1, true) != null)
                    ((CombatComponent) go.GetComponent(1, true)).FillAmmo();
        }

        #endregion Public Methods

        #region Public Properties

        public int m_vBuildingId { get; set; }

        public uint m_vUnknown1 { get; set; }

        public uint m_vUnknown2 { get; set; }

        #endregion Public Properties
    }
}
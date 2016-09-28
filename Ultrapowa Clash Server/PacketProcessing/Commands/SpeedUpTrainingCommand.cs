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

using System;
using System.IO;
using UCS.Core;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    internal class SpeedUpTrainingCommand : Command
    {
        #region Private Fields

        readonly int m_vBuildingId;

        #endregion Private Fields

        #region Public Constructors

        public SpeedUpTrainingCommand(CoCSharpPacketReader br)
        {
            m_vBuildingId = br.ReadInt32WithEndian();
            br.ReadInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var ca = level.GetPlayerAvatar();
            var go = level.GameObjectManager.GetGameObjectByID(m_vBuildingId);

            if (go != null)
            {
                if (go.ClassId == 0)
                {
                    var b = (Building) go;
                    var upc = b.GetUnitProductionComponent();
                    if (upc != null)
                    {
                        var totalRemainingTime = upc.GetTotalRemainingSeconds();
                        var cost = GamePlayUtil.GetSpeedUpCost(totalRemainingTime);
                        if (upc.IsSpellForge())
                        {
                            var multiplier =
                                ObjectManager.DataTables.GetGlobals()
                                             .GetGlobalData("SPELL_SPEED_UP_COST_MULTIPLIER")
                                             .NumberValue;
                            cost = (int) ((cost * (long) multiplier * 1374389535) >> 32);
                            cost = Math.Max((cost >> 5) + (cost >> 31), 1);
                        }
                        if (ca.HasEnoughDiamonds(cost))
                        {
                            if (upc.HasHousingSpaceForSpeedUp())
                            {
                                ca.UseDiamonds(cost);
                                upc.SpeedUp();
                            }
                        }
                    }
                }
            }
        }

        #endregion Public Methods
    }
}
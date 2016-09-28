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

namespace UCS.PacketProcessing.Commands
{
    internal class SellBuildingCommand : Command
    {
        #region Private Fields

        readonly int m_vBuildingId;

        #endregion Private Fields

        #region Public Constructors

        public SellBuildingCommand(CoCSharpPacketReader br)
        {
            m_vBuildingId = br.ReadInt32WithEndian();
            br.ReadUInt32WithEndian();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            var ca = level.GetPlayerAvatar();
            var go = level.GameObjectManager.GetGameObjectByID(m_vBuildingId);

            if (go != null)
            {
                if (go.ClassId == 4)
                {
                    var t = (Trap) go;
                    var upgradeLevel = t.GetUpgradeLevel();
                    var rd = t.GetTrapData().GetBuildResource(upgradeLevel);
                    var sellPrice = t.GetTrapData().GetSellPrice(upgradeLevel);
                    ca.CommodityCountChangeHelper(0, rd, sellPrice);
                    level.GameObjectManager.RemoveGameObject(t);
                }
                else if (go.ClassId == 6)
                {
                    var d = (Deco) go;
                    var rd = d.GetDecoData().GetBuildResource();
                    var sellPrice = d.GetDecoData().GetSellPrice();
                    if (rd.PremiumCurrency)
                    {
                        ca.SetDiamonds(ca.GetDiamonds() + sellPrice);
                    }
                    else
                    {
                        ca.CommodityCountChangeHelper(0, rd, sellPrice);
                    }
                    level.GameObjectManager.RemoveGameObject(d);
                }
            }
        }

        #endregion Public Methods
    }
}
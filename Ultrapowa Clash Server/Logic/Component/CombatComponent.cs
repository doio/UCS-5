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

using Newtonsoft.Json.Linq;
using UCS.Core;
using UCS.Files.Logic;

namespace UCS.Logic
{
    internal class CombatComponent : Component
    {
        #region Public Constructors

        public CombatComponent(ConstructionItem ci, Level level) : base(ci)
        {
            var bd = (BuildingData) ci.GetData();
            if (bd.AmmoCount != 0)
            {
                m_vAmmo = bd.AmmoCount;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public override int Type => 1;

        #endregion Public Properties

        #region Private Fields

        const int m_vType = 0x01AB3F00;

        int m_vAmmo;

        #endregion Private Fields

        #region Public Methods

        public void FillAmmo()
        {
            var ca = GetParent().GetLevel().GetPlayerAvatar();
            var bd = (BuildingData) GetParent().GetData();
            var rd = ObjectManager.DataTables.GetResourceByName(bd.AmmoResource);

            if (ca.HasEnoughResources(rd, bd.AmmoCost))
            {
                ca.CommodityCountChangeHelper(0, rd, bd.AmmoCost);
                m_vAmmo = bd.AmmoCount;
            }
        }

        public override void Load(JObject jsonObject)
        {
            if (jsonObject["ammo"] != null)
            {
                m_vAmmo = jsonObject["ammo"].ToObject<int>();
            }
        }

        public override JObject Save(JObject jsonObject)
        {
            if (m_vAmmo != null)
            {
                jsonObject.Add("ammo", m_vAmmo);
            }
            return jsonObject;
        }

        #endregion Public Methods
    }
}

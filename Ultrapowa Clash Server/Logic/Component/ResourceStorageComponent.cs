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
using UCS.Core;

namespace UCS.Logic
{
    internal class ResourceStorageComponent : Component
    {
        #region Public Constructors

        public ResourceStorageComponent(GameObject go) : base(go)
        {
            m_vCurrentResources = new List<int>();
            m_vMaxResources = new List<int>();
            m_vStolenResources = new List<int>();

            var table = ObjectManager.DataTables.GetTable(2);
            var resourceCount = table.GetItemCount();
            for (var i = 0; i < resourceCount; i++)
            {
                m_vCurrentResources.Add(0);
                m_vMaxResources.Add(0);
                m_vStolenResources.Add(0);
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public override int Type => 6;

        #endregion Public Properties

        #region Private Fields

        readonly List<int> m_vCurrentResources;
        readonly List<int> m_vStolenResources;
        List<int> m_vMaxResources;

        #endregion Private Fields

        #region Public Methods

        public int GetCount(int resourceIndex) => m_vCurrentResources[resourceIndex];

        public int GetMax(int resourceIndex) => m_vMaxResources[resourceIndex];

        public void SetMaxArray(List<int> resourceCaps)
        {
            m_vMaxResources = resourceCaps;
            GetParent().GetLevel().GetComponentManager().RefreshResourcesCaps();
        }

        #endregion Public Methods
    }
}

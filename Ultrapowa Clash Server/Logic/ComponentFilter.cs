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

namespace UCS.Logic
{
    internal class ComponentFilter : GameObjectFilter
    {
        #region Public Fields

        public int Type;

        #endregion Public Fields

        #region Public Constructors

        public ComponentFilter(int type)
        {
            Type = type;
        }

        #endregion Public Constructors

        #region Public Methods

        public override bool IsComponentFilter()
        {
            return true;
        }

        public bool TestComponent(Component c)
        {
            var go = c.GetParent();
            return TestGameObject(go);
        }

        public new bool TestGameObject(GameObject go)
        {
            var result = false;
            var c = go.GetComponent(Type, true);
            if (c != null)
                result = base.TestGameObject(go);
            return result;
        }

        #endregion Public Methods
    }
}
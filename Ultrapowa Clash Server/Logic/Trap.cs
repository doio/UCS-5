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

using UCS.Files.Logic;

namespace UCS.Logic
{
    internal class Trap : ConstructionItem
    {
        #region Public Constructors

        public Trap(Data data, Level l) : base(data, l)
        {
            AddComponent(new TriggerComponent());
        }

        #endregion Public Constructors

        #region Public Properties

        public override int ClassId
        {
            get { return 4; }
        }

        #endregion Public Properties

        #region Public Methods

        public TrapData GetTrapData() => (TrapData)GetData();

        #endregion Public Methods
    }
}

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

using UCS.Files.CSV;

namespace UCS.Files.Logic
{
    internal class ConstructionItemData : Data
    {
        #region Public Constructors

        public ConstructionItemData(CSVRow row, DataTable dt) : base(row, dt)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public virtual int GetBuildCost(int level) => -1;

        public virtual ResourceData GetBuildResource(int level) => null;

        public virtual int GetConstructionTime(int level) => -1;

        public virtual int GetRequiredTownHallLevel(int level) => -1;

        public virtual int GetUpgradeLevelCount() => -1;

        public virtual bool IsTownHall() => false;

        #endregion Public Methods
    }
}

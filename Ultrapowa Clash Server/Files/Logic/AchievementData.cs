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
    internal class AchievementData : Data
    {
        #region Public Constructors

        public AchievementData(CSVRow row, DataTable dt) : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public string Action { get; set; }
        public int ActionCount { get; set; }
        public string ActionData { get; set; }
        public string AndroidID { get; set; }
        public string CompletedTID { get; set; }
        public int DiamondReward { get; set; }
        public int ExpReward { get; set; }
        public string IconExportName { get; set; }
        public string IconSWF { get; set; }
        public string InfoTID { get; set; }
        public int Level { get; set; }
        public bool ShowValue { get; set; }
        public string TID { get; set; }

        #endregion Public Properties
    }
}
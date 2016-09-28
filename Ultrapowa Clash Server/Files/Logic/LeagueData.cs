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
using UCS.Files.CSV;

namespace UCS.Files.Logic
{
    internal class LeagueData : Data
    {
        #region Public Constructors

        public LeagueData(CSVRow row, DataTable dt)
            : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public List<int> BucketPlacementHardLimit { get; set; }
        public List<int> BucketPlacementRangeHigh { get; set; }
        public List<int> BucketPlacementRangeLow { get; set; }
        public List<int> BucketPlacementSoftLimit { get; set; }
        public int DarkElixirReward { get; set; }
        public bool DemoteEnabled { get; set; }
        public int DemoteLimit { get; set; }
        public int ElixirReward { get; set; }
        public int GoldReward { get; set; }
        public string IconExportName { get; set; }
        public string IconSWF { get; set; }
        public bool IgnoredByServer { get; set; }
        public string LeagueBannerIcon { get; set; }
        public string LeagueBannerIconNum { get; set; }
        public int PlacementLimitHigh { get; set; }
        public int PlacementLimitLow { get; set; }
        public bool PromoteEnabled { get; set; }
        public int PromoteLimit { get; set; }
        public string TID { get; set; }
        public string TIDShort { get; set; }

        #endregion Public Properties
    }
}
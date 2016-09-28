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
    internal class AllianceLevelsData : Data
    {
        #region Public Constructors

        public AllianceLevelsData(CSVRow row, DataTable dt) : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public int BadgeLevel { get; set; }
        public string BannerSWF { get; set; }
        public int ExpPoints { get; set; }
        public bool IsVisible { get; set; }
        public string Name { get; set; }
        public int TroopDonationLimit { get; set; }
        public int TroopDonationRefund { get; set; }
        public int TroopDonationUpgrade { get; set; }
        public int TroopRequestCooldown { get; set; }
        public int WarLootCapacityPercent { get; set; }
        public int WarLootMultiplierPercent { get; set; }

        #endregion Public Properties
    }
}
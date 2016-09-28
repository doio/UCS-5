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
    internal class ResourceData : Data
    {
        #region Public Constructors

        public ResourceData(CSVRow row, DataTable dt)
            : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public string CapFullTID { get; set; }
        public string CollectEffect { get; set; }
        public string HudInstanceName { get; set; }
        public bool PremiumCurrency { get; set; }
        public string ResourceIconExportName { get; set; }
        public string StealEffect { get; set; }
        public string SWF { get; set; }
        public int TextBlue { get; set; }
        public int TextGreen { get; set; }
        public int TextRed { get; set; }
        public string TID { get; set; }
        public string WarRefResource { get; set; }

        #endregion Public Properties
    }
}
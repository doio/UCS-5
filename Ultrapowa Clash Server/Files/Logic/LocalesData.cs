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
    internal class LocalesData : Data
    {
        #region Public Constructors

        public LocalesData(CSVRow row, DataTable dt) : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public string Description { get; set; }
        public bool HasEvenSpaceCharacters { get; set; }
        public string HelpshiftSDKLanguage { get; set; }
        public string HelpshiftSDKLanguageAndroid { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string TestExcludes { get; set; }
        public bool TestLanguage { get; set; }
        public string UsedSystemFont { get; set; }

        #endregion Public Properties
    }
}
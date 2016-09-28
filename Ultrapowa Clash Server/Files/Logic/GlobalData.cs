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
    internal class GlobalData : Data
    {
        #region Public Constructors

        public GlobalData(CSVRow row, DataTable dt)
            : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public string AltStringArray { get; set; }
        public bool BooleanValue { get; set; }
        public int NumberArray { get; set; }
        public int NumberValue { get; set; }
        public string StringArray { get; set; }
        public string TextValue { get; set; }

        #endregion Public Properties
    }
}
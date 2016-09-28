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
    internal class WarData : Data
    {
        #region Public Constructors

        public WarData(CSVRow row, DataTable dt) : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public bool DisableProduction { get; set; }
        public string Name { get; set; }
        public int PreparationMinutes { get; set; }
        public int TeamSize { get; set; }
        public int WarMinutes { get; set; }

        #endregion Public Properties
    }
}
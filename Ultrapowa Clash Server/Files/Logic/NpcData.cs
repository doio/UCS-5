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
    internal class NpcData : Data
    {
        #region Public Constructors

        public NpcData(CSVRow row, DataTable dt)
            : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public bool AlwaysUnlocked { get; set; }
        public int Elixir { get; set; }
        public int ExpLevel { get; set; }
        public int Gold { get; set; }
        public string LevelFile { get; set; }
        public string MapDependencies { get; set; }
        public string MapInstanceName { get; set; }
        public string TID { get; set; }
        public int UnitCount { get; set; }
        public string UnitType { get; set; }

        #endregion Public Properties
    }
}
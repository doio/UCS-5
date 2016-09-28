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
    internal class ProjectilesData : Data
    {
        #region Public Constructors

        public ProjectilesData(CSVRow row, DataTable dt) : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public string Effect { get; set; }
        public string ExportName { get; set; }
        public bool IsBallistic { get; set; }
        public string Name { get; set; }
        public string ParticleEmitter { get; set; }
        public bool PlayOnce { get; set; }
        public bool RandomHitPosition { get; set; }
        public int Scale { get; set; }
        public string ShadowExportName { get; set; }
        public string ShadowSWF { get; set; }
        public int Speed { get; set; }
        public int StartHeight { get; set; }
        public int StartOffset { get; set; }
        public string SWF { get; set; }
        public bool UseRotate { get; set; }
        public bool UseTopLayer { get; set; }

        #endregion Public Properties
    }
}
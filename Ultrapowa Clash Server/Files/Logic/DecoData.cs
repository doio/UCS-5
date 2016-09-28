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

using UCS.Core;
using UCS.Files.CSV;

namespace UCS.Files.Logic
{
    internal class DecoData : Data
    {
        #region Public Constructors

        public DecoData(CSVRow row, DataTable dt)
            : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public int BuildCost { get; set; }

        public string BuildResource { get; set; }

        public string ExportName { get; set; }

        public string ExportNameBase { get; set; }

        public string ExportNameBaseNpc { get; set; }

        public string ExportNameBaseWar { get; set; }

        public string ExportNameConstruction { get; set; }

        public int Height { get; set; }

        public string Icon { get; set; }

        public string InfoTID { get; set; }

        public int MaxCount { get; set; }

        public int RequiredExpLevel { get; set; }

        public string SWF { get; set; }

        public string TID { get; set; }

        public int Width { get; set; }

        #endregion Public Properties

        #region Public Methods

        public int GetBuildCost()
        {
            return BuildCost;
        }

        public ResourceData GetBuildResource()
        {
            return ObjectManager.DataTables.GetResourceByName(BuildResource);
        }

        public int GetSellPrice()
        {
            var calculation = (int) ((BuildCost * (long) 1717986919) >> 32);
            return (calculation >> 2) + (calculation >> 31);
        }

        #endregion Public Methods
    }
}
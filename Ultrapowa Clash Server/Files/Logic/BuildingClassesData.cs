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
    internal class BuildingClassesData : Data
    {
        #region Public Constructors

        public BuildingClassesData(CSVRow row, DataTable dt) : base(row, dt)
        {
            LoadData(this, GetType(), row);
        }

        #endregion Public Constructors

        #region Public Properties

        public bool CanBuy { get; set; }
        public string Name { get; set; }
        public bool ShopCategoryArmy { get; set; }
        public bool ShopCategoryDefense { get; set; }
        public bool ShopCategoryResource { get; set; }
        public string TID { get; set; }

        #endregion Public Properties
    }
}
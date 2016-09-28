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

namespace UCS.Files.CSV
{
    internal class CSVColumn
    {
        #region Private Fields

        readonly List<string> m_vValues;

        #endregion Private Fields

        #region Public Constructors

        public CSVColumn()
        {
            m_vValues = new List<string>();
        }

        #endregion Public Constructors

        #region Public Methods

        public static int GetArraySize(int currentOffset, int nextOffset) => nextOffset - currentOffset;

        public void Add(string value)
        {
            m_vValues.Add(value);
        }

        public string Get(int row) => m_vValues[row];

        public int GetSize() => m_vValues.Count;

        #endregion Public Methods
    }
}

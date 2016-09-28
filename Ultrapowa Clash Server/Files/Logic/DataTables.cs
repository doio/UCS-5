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
using UCS.Files.CSV;

namespace UCS.Files.Logic
{
    internal class DataTables
    {
        #region Private Fields

        readonly List<DataTable> m_vDataTables;

        #endregion Private Fields

        #region Public Constructors

        public DataTables()
        {
            m_vDataTables = new List<DataTable>();
            for (var i = 0; i < 41; i++)
                m_vDataTables.Add(new DataTable());
        }

        #endregion Public Constructors

        #region Public Methods

        public CharacterData GetCharacterByName(string name)
        {
            var dt = m_vDataTables[3];
            return (CharacterData) dt.GetDataByName(name);
        }

        public Data GetDataById(int id)
        {
            var classId = GlobalID.GetClassID(id) - 1;
            var dt = m_vDataTables[classId];
            return dt.GetItemById(id);
        }

        public Globals GetGlobals()
        {
            return (Globals) m_vDataTables[13];
        }

        public HeroData GetHeroByName(string name)
        {
            var dt = m_vDataTables[27];
            return (HeroData) dt.GetDataByName(name);
        }

        public ResourceData GetResourceByName(string name)
        {
            var dt = m_vDataTables[2];
            return (ResourceData) dt.GetDataByName(name);
        }

        public DataTable GetTable(int i)
        {
            return m_vDataTables[i];
        }

        public void InitDataTable(CSVTable t, int index)
        {
            if (index == 13)
                m_vDataTables[index] = new Globals(t, index);
            else
                m_vDataTables[index] = new DataTable(t, index);
        }

        #endregion Public Methods
    }
}
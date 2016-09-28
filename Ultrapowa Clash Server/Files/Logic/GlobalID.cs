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

namespace UCS.Files.Logic
{
    public static class GlobalID
    {
        #region Public Methods

        public static int CreateGlobalID(int index, int count)
        {
            return count + 1000000 * index;
        }

        public static int GetClassID(int commandType)
        {
            /*
             * Resource:
             * commandeType: 3000000 (2DC6C0)
             * commandType: 786432
             * return 3 + 0
             */

            var r1 = 1125899907;
            commandType = (int) ((r1 * (long) commandType) >> 32);
            return (commandType >> 18) + (commandType >> 31);
        }

        public static int GetInstanceID(int globalID)
        {
            /*
             * Resource:
             * globalID: 3000000 (2DC6C0)
             * r1: 1125899907
             * r1: 786432
             * return 3000000 - 1000000 * (3 + 0)
             */

            var r1 = 1125899907;
            r1 = (int) ((r1 * (long) globalID) >> 32);
            return globalID - 1000000 * ((r1 >> 18) + (r1 >> 31));
        }

        #endregion Public Methods
    }
}
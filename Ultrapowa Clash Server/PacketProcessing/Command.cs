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
using UCS.Logic;

namespace UCS.PacketProcessing
{
    internal class Command
    {
        #region Public Fields

        public const int MaxEmbeddedDepth = 10;

        #endregion Public Fields

        #region Internal Properties

        internal int Depth { get; set; }

        #endregion Internal Properties

        #region Public Methods

        public virtual byte[] Encode() => new List<byte>().ToArray();

        public virtual void Execute(Level level)
        {
        }

        #endregion Public Methods
    }
}

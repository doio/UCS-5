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

using System;
using System.IO;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Commands
{
    internal class FreeWorkerCommand : Command
    {
        #region Public Fields

        public int m_vTimeLeftSeconds;

        #endregion Public Fields

        #region Public Constructors

        public FreeWorkerCommand(CoCSharpPacketReader br)
        {
            m_vTimeLeftSeconds = br.ReadInt32WithEndian();
            m_vIsCommandEmbedded = br.ReadBoolean();
            if (m_vIsCommandEmbedded)
            {
                Depth++;
                if (Depth >= MaxEmbeddedDepth)
                    throw new ArgumentException(
                        "A command contained embedded command depth was greater than max embedded commands.");
                m_vCommand = CommandFactory.Read(br);
            }
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            if (level.WorkerManager.GetFreeWorkers() == 0)
            {
                level.WorkerManager.FinishTaskOfOneWorker();
                if (m_vIsCommandEmbedded)
                {
                    Depth++;

                    if (Depth >= MaxEmbeddedDepth)
                        throw new ArgumentException(
                            "A command contained embedded command depth was greater than max embedded commands.");

                    ((Command) m_vCommand).Execute(level);
                }
            }
        }

        #endregion Public Methods

        #region Private Fields

        readonly object m_vCommand;
        readonly bool m_vIsCommandEmbedded;

        #endregion Private Fields
    }
}
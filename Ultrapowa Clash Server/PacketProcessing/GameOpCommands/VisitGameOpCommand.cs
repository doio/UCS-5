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
using UCS.Core;
using UCS.Core.Network;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.GameOpCommands
{
    internal class VisitGameOpCommand : GameOpCommand
    {
        #region Private Fields

        readonly string[] m_vArgs;

        #endregion Private Fields

        #region Public Constructors

        public VisitGameOpCommand(string[] args)
        {
            m_vArgs = args;
            SetRequiredAccountPrivileges(2);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            if (level.GetAccountPrivileges() >= GetRequiredAccountPrivileges())
            {
                if (m_vArgs.Length >= 2)
                {
                    try
                    {
                        var id = Convert.ToInt64(m_vArgs[1]);
                        var l = ResourcesManager.GetPlayer(id);
                        if (l != null)
                        {
                            l.Tick();
                            var p = new VisitedHomeDataMessage(level.GetClient(), l, level);
                            PacketManager.ProcessOutgoingPacket(p);
                        }
                        else
                        {
                            //Debugger.WriteLine("Visit failed: id " + id + " not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        //Debugger.WriteLine("Visit failed with error: " + ex);
                    }
                }
            }
            else
            {
                SendCommandFailedMessage(level.GetClient());
            }
        }

        #endregion Public Methods
    }
}
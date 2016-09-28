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
using UCS.Logic;

namespace UCS.PacketProcessing.GameOpCommands
{
    internal class SetPrivilegesGameOpCommand : GameOpCommand
    {
        #region Private Fields

        readonly string[] m_vArgs;

        #endregion Private Fields

        #region Public Constructors

        public SetPrivilegesGameOpCommand(string[] args)
        {
            m_vArgs = args;
            SetRequiredAccountPrivileges(4);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            if (level.GetAccountPrivileges() >= GetRequiredAccountPrivileges())
            {
                if (m_vArgs.Length >= 3)
                {
                    try
                    {
                        var id = Convert.ToInt64(m_vArgs[1]);
                        var accountPrivileges = Convert.ToByte(m_vArgs[2]);
                        var l = ResourcesManager.GetPlayer(id);
                        if (accountPrivileges < level.GetAccountPrivileges())
                        {
                            if (l != null)
                            {
                                l.SetAccountPrivileges(accountPrivileges);
                            }
                            else
                            {
                                //Debugger.WriteLine("SetPrivileges failed: id " + id + " not found");
                            }
                        }
                        else
                        {
                            //Debugger.WriteLine("SetPrivileges failed: target privileges too high");
                        }
                    }
                    catch (Exception ex)
                    {
                        ////Debugger.WriteLine("SetPrivileges failed with error: " + ex);
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
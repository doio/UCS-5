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
    internal class RenameAvatarGameOpCommand : GameOpCommand
    {
        #region Private Fields

        readonly string[] m_vArgs;

        #endregion Private Fields

        #region Public Constructors

        public RenameAvatarGameOpCommand(string[] args)
        {
            m_vArgs = args;
            SetRequiredAccountPrivileges(1);
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
                        var l = ResourcesManager.GetPlayer(id, true);
                        if (l != null)
                        {
                            l.GetPlayerAvatar().SetName(m_vArgs[2]);
                            if (ResourcesManager.IsPlayerOnline(l))
                            {
                                var p = new AvatarNameChangeOkMessage(l.GetClient());
                                p.SetAvatarName(m_vArgs[2]);
                                PacketManager.ProcessOutgoingPacket(p);
                            }
                        }
                        else
                        {
                            //Debugger.WriteLine("RenameAvatar failed: id " + id + " not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        //Debugger.WriteLine("RenameAvatar failed with error: " + ex);
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
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
    internal class BanIpGameOpCommand : GameOpCommand
    {
        #region Private Fields

        readonly string[] m_vArgs;

        #endregion Private Fields

        #region Public Constructors

        public BanIpGameOpCommand(string[] args)
        {
            m_vArgs = args;
            SetRequiredAccountPrivileges(3);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            if (level.GetAccountPrivileges() >= GetRequiredAccountPrivileges())
                if (m_vArgs.Length >= 1)
                    try
                    {
                        var id = Convert.ToInt64(m_vArgs[1]);
                        var l = ResourcesManager.GetPlayer(id);
                        if (l != null)
                            if (l.GetAccountPrivileges() < level.GetAccountPrivileges())
                            {
                                //l.BanIP();
                                l.SetAccountStatus(99);
                                l.SetAccountPrivileges(0);
                                if (ResourcesManager.IsPlayerOnline(l))
                                {
                                    var p = new OutOfSyncMessage(l.GetClient());
                                    PacketManager.ProcessOutgoingPacket(p);
                                }
                                //ObjectManager.LoadBannedIPs();
                            }
                            else
                                Console.WriteLine("Ban IP failed: insufficient privileges");
                        else
                            Console.WriteLine("Ban IP failed: id " + id + " not found");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ban IP failed with error: " + ex);
                    }
                else
                    SendCommandFailedMessage(level.GetClient());
        }

        #endregion Public Methods
    }
}
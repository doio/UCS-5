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
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using UCS.Core;
using UCS.Core.Network;
using UCS.PacketProcessing;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.Helpers
{
    internal class CommandParser
    {
        #region Public Methods

        public static void Parse(string Command)
        {
            switch (Command)
            {
                case "/help":
                    Console.WriteLine("[UCS][MENU]  -> /status      - Shows the actual UCS status.");
                    Console.WriteLine("[UCS][MENU]  -> /clear       - Clears the console screen.");
                    Console.WriteLine("[UCS][MENU]  -> /shutdown    - Shuts UCS down instantly.");
                    Console.WriteLine("[UCS][MENU]  -> /startx      - Shows the UCS interface.");
                    break;

                case "/status":
                    Console.WriteLine("");
                    Console.WriteLine("[UCS][INFO]  -> IP Address:     " +
                                      Dns.GetHostByName(Dns.GetHostName()).AddressList[0]);
                    Console.WriteLine("[UCS][INFO]  -> Online players:         " +
                                      ResourcesManager.GetOnlinePlayers().Count);
                    Console.WriteLine("[UCS][INFO]  -> Connected players:      " +
                                      ResourcesManager.GetConnectedClients().Count);
                    Console.WriteLine("[UCS][INFO]  -> Clash Version: 8.332.16");
                    break;

                case "/clear":
                    Console.Clear();
                    break;

                case "/shutdown":
                    Environment.Exit(0);
                    break;
                case "/startx":
                    Application.Run(new UCSUI());

                    break;

                default:
                    Console.WriteLine(
                        "[UCS]    Unknown command, type \"/help\" for a list containing all available commands.");
                    break;
            }
        }

        #endregion Public Methods
    }
}

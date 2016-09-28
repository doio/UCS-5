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
using System.Threading;
using static System.Configuration.ConfigurationManager;
using static UCS.Helpers.Utils;
using static UCS.Helpers.CommandParser;
using static System.Console;
using static System.Environment;
using UCS.Core.Web;
using System.IO;

namespace UCS.Core.Threading
{
    internal class ConsoleThread
    {
        #region Private Fields
        static string Command;
        static string Title, Ta;

        #endregion Private Fields

        #region Private Properties

        static Thread T { get; set; }

        #endregion Private Properties

        #region Public Methods

        internal static void Start()
        {
            T = new Thread(() =>
            {
                Title = "Ultrapowa Clash Server v0.7.1.0 - © 2016";
                foreach (char t in Title)
                {
                    Ta += t;
                    Console.Title = Ta;
                    Thread.Sleep(20);
                }
                ForegroundColor = ConsoleColor.Red;
                WriteLine(
                    @"
      ____ ___.__   __                                              
     |    |   \  |_/  |_____________  ______   ______  _  _______   
     |    |   /  |\   __\_  __ \__  \ \____ \ /  _ \ \/ \/ /\__  \  
     |    |  /|  |_|  |  |  | \// __ \|  |_> >  <_> )     /  / __ \_
     |______/ |____/__|  |__|  (____  /   __/ \____/ \/\_/  (____  /
                                    \/|__|                       \/
                  ");

                ResetColor();
                WriteLine("[UCS]    -> This program is made by the Ultrapowa Network development team.");
                WriteLine("[UCS]    -> You can find the source at www.ultrapowa.com");
                WriteLine("[UCS]    -> Don't forget to visit www.ultrapowa.com daily for updates!");
                VersionChecker.VersionMain();
                WriteLine("");
                WriteLine("[UCS]    -> UCS is now starting...");
                WriteLine("");
               if(!File.Exists("restarter.bat"))
                    using (StreamWriter sw = new StreamWriter("restarter.bat"))
                    {
                        sw.WriteLine("echo off");
                        sw.WriteLine("echo.");
                        sw.WriteLine("taskkill /f /im ucs.exe -t");
                        sw.WriteLine("start ucs.exe");
                        sw.WriteLine("exit");  

                    }
                MemoryThread.Start();
                NetworkThread.Start();
                while ((Command = ReadLine()) != null)
                    Parse(Command);
            });
            T.Start();
        }

        public static void Stop()
        {
            if (T.ThreadState == ThreadState.Running)
                T.Abort();
        }

        #endregion Public Methods
    }
}

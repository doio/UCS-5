using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using Microsoft.Win32;

namespace UCS.Core.Web
{
    internal class VersionChecker
    {
        internal static void VersionMain()
        {
            try
            {
                WebClient wc = new WebClient();
                string Version = wc.DownloadString("https://clashoflights.cf/UCS/version.txt");
                if (Version == "0.7.1.0")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[UCS]    -> Your UCS is up-to-date!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[UCS][ERROR]  ->  UCS has a new update. Download the latest version from GitHub");
                    Console.WriteLine("[UCS][ERROR]  ->  Current new version is : " + Version);
                    Console.ResetColor();
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[UCS][ERROR]  ->  Problem by checking UCS version, check your Network");
                Console.ResetColor();
            }
        }
    }
}
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
using System.Text;
using UCS.Helpers;
using UCS.Logic;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class FacebookLinkMessage : Message
    {
        #region Public Constructors

        public FacebookLinkMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
                /*
                Console.WriteLine("Boolean -> " + br.ReadBoolean());
                Console.WriteLine("Unknown 1 -> " + br.ReadInt32());
                Console.WriteLine("Unknown 2 -> " + br.ReadInt32());
                Console.WriteLine("Unknown 3 -> " + br.ReadInt32());
                Console.WriteLine("Unknown 4 -> " + br.ReadInt16());
                Console.WriteLine("Token -> " + br.ReadString());
                */
                Console.WriteLine(Encoding.ASCII.GetString(br.ReadAllBytes()));
            }
        }

        public override void Process(Level level)
        {
        }

        #endregion Public Methods
    }
}
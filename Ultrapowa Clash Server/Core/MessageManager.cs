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
using System.Collections.Concurrent;
using System.Threading;
using UCS.PacketProcessing;

namespace UCS.Core
{
    internal class MessageManager
    {
        #region Private Fields

        private static BlockingCollection<Message> m_vPackets = new BlockingCollection<Message>(); // new Method
        
        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     The loader of the MessageManager class.
        /// </summary>
        public MessageManager()
        {
            PacketProcessingDelegate packetProcessing = PacketProcessing;
            packetProcessing.BeginInvoke(null, null);
            Console.WriteLine("[UCS]    Message manager has been successfully started !");
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        ///     This function process packets.
        /// </summary>
        void PacketProcessing()
        {
            while (true)
            {
                var p = m_vPackets.Take();
                ThreadPool.QueueUserWorkItem(state =>
                {
                    var m = (Message)state;
                    var m2 = m.Client.GetLevel();
                    try
                    {
                        m.Decode();
                        m.Process(m2);
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine("ERROR: " + e); //just for testing but works fine
                    }
                }, p);
            }
        }

        #endregion Private Methods

        #region Private Delegates

        private delegate void PacketProcessingDelegate();

        #endregion Private Delegates

        #region Public Methods

        /// <summary>
        ///     This function handle the packet by enqueue him.
        /// </summary>
        /// <param name="p">The message/packet.</param>
        public static void ProcessPacket(Message p)
        {
            m_vPackets.Add(p);
        }
        #endregion Public Methods
    }
}

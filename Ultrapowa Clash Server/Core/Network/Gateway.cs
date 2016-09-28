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
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UCS.PacketProcessing;

namespace UCS.Core.Network
{
    internal class Gateway
    {
        public static Socket Socket { get; set; }

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public void Start()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            {
                var port = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]);
                try
                {
                    Socket.Bind(new IPEndPoint(IPAddress.Any, port));
                    Socket.Listen(1000);
                    Console.WriteLine("[UCS]    Gateway started on Port " + port);
                    Console.WriteLine("[UCS]    Server started succesfully! Let's Play Clash of Clans!");
                    while (true)
                    {
                        allDone.Reset();
                        Socket.BeginAccept(new AsyncCallback(OnClientConnect), Socket);
                        allDone.WaitOne();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[UCS]    Exception when attempting to host the server : " + e);
                    Socket = null;
                }
            }
        }

        static void OnReceive(SocketRead read, byte[] data)
        {
            try
            {
                Client c = ResourcesManager.GetClient(read.Socket.Handle.ToInt64());
                c.DataStream.AddRange(data);
                Message p;
                while (c.TryGetPacket(out p))
                    PacketManager.ProcessIncomingPacket(p);
            }
            catch (Exception ex)
            {
            }
        }

        static void OnReceiveError(SocketRead read, Exception exception)
        {
        }

        void OnClientConnect(IAsyncResult ar)
        {
            allDone.Set();
            try
            {
                Socket listener = (Socket)ar.AsyncState;
                Socket clientSocket = listener.EndAccept(ar);
                Console.WriteLine("[UCS]    Player connected -> " + ((IPEndPoint) clientSocket.RemoteEndPoint).Address + "");
                ResourcesManager.AddClient(new Client(clientSocket), ((IPEndPoint) clientSocket.RemoteEndPoint).Address.ToString());
                SocketRead.Begin(clientSocket, OnReceive, OnReceiveError);
            }
            catch (Exception e)
            {
            }
        }
    }

    public class SocketRead
    {
        SocketRead(Socket socket, IncomingReadHandler readHandler, IncomingReadErrorHandler errorHandler = null)
        {
            Socket = socket;
            _readHandler = readHandler;
            _errorHandler = errorHandler;
            BeginReceive();
        }

        public Socket Socket { get; }

        public static SocketRead Begin(Socket socket, IncomingReadHandler readHandler, IncomingReadErrorHandler errorHandler = null) 
            => new SocketRead(socket, readHandler, errorHandler);

        readonly byte[] _buffer = new byte[1024];

        readonly IncomingReadErrorHandler _errorHandler;

        readonly IncomingReadHandler _readHandler;

        public delegate void IncomingReadErrorHandler(SocketRead read, Exception exception);

        public delegate void IncomingReadHandler(SocketRead read, byte[] data);

        void BeginReceive()
        {
            Socket.BeginReceive(_buffer, 0, 1024, SocketFlags.None, OnReceive, this);
        }

        void OnReceive(IAsyncResult result)
        {
            try
            {
                if (result.IsCompleted)
                {
                    var bytesRead = Socket.EndReceive(result);
                    if (bytesRead > 0)
                    {
                        var read = new byte[bytesRead];
                        Array.Copy(_buffer, 0, read, 0, bytesRead);

                        _readHandler(this, read);
                        Begin(Socket, _readHandler, _errorHandler);
                    }
                }
            }
            catch (Exception e)
            {
                _errorHandler?.Invoke(this, e);
            }
        }
    }
}

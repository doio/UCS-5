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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using UCS.Core;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class SendGlobalChatLineMessage : Message
    {
        #region Public Constructors

        public SendGlobalChatLineMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public string Message { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
                Message = br.ReadScString();
            }
        }

        public override void Process(Level level)
        {
            if (Message.Length > 0)
            {
                if (Message[0] == '/')
                {
                    var obj = GameOpCommandFactory.Parse(Message);
                    if (obj != null)
                    {
                        var player = "";
                        if (level != null)
                            player += " (" + level.GetPlayerAvatar().GetId() + ", " +
                                      level.GetPlayerAvatar().GetAvatarName() + ")";
                        ((GameOpCommand) obj).Execute(level);
                    }
                }
                else
                {
                    if (File.Exists(@"filter.ucs"))
                    {
                        var senderId = level.GetPlayerAvatar().GetId();
                        var senderName = level.GetPlayerAvatar().GetAvatarName();

                        var badwords = new List<string>();
                        var r = new StreamReader(@"filter.ucs");
                        var line = "";
                        while ((line = r.ReadLine()) != null)
                        {
                            badwords.Add(line);
                        }
                        var badword = badwords.Any(s => Message.Contains(s));

                        if (badword)
                        {
                            var p = new GlobalChatLineMessage(level.GetClient());
                            p.SetPlayerId(0);
                            p.SetPlayerName("UCS Chat Filter System");
                            p.SetLeagueId(22);
                            p.SetChatMessage("DETECTED BAD WORD! PLEASE AVOID USING BAD WORDS!");
                            PacketManager.ProcessOutgoingPacket(p);
                            return;
                        }

                        foreach (var onlinePlayer in ResourcesManager.GetOnlinePlayers())
                        {
                            var p = new GlobalChatLineMessage(onlinePlayer.GetClient());
                            if (onlinePlayer.GetAccountPrivileges() > 0)
                                p.SetPlayerName(senderName + " #" + senderId);
                            else
                                p.SetPlayerName(senderName);

                            p.SetChatMessage(Message);
                            p.SetPlayerId(senderId);
                            p.SetLeagueId(level.GetPlayerAvatar().GetLeagueId());
                            p.SetAlliance(ObjectManager.GetAlliance(level.GetPlayerAvatar().GetAllianceId()));
                            PacketManager.ProcessOutgoingPacket(p);
                        }
                    }
                    else
                    {
                        var p = new GlobalChatLineMessage(level.GetClient());
                        p.SetPlayerId(0);
                        p.SetPlayerName("UCS Chat System");
                        p.SetChatMessage(
                            "The Global Chat is currently disabled. Please try again later! For more Informations, check the Server Status!");
                        PacketManager.ProcessOutgoingPacket(p);
                    }
                }
            }
        }

        #endregion Public Methods
    }
}
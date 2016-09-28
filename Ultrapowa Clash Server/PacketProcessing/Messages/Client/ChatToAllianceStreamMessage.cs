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
using UCS.Core;
using UCS.Core.Network;
using UCS.Helpers;
using UCS.Logic;
using UCS.Logic.StreamEntry;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.Messages.Client
{
    internal class ChatToAllianceStreamMessage : Message
    {
        #region Private Fields

        string m_vChatMessage;

        #endregion Private Fields

        #region Public Constructors

        public ChatToAllianceStreamMessage(PacketProcessing.Client client, CoCSharpPacketReader br) : base(client, br)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Decode()
        {
            using (var br = new BinaryReader(new MemoryStream(GetData())))
            {
                m_vChatMessage = br.ReadScString();
            }
        }

        public override void Process(Level level)
        {
            if (m_vChatMessage.Length > 0)
            {
                if (m_vChatMessage[0] == '/')
                {
                    var obj = GameOpCommandFactory.Parse(m_vChatMessage);
                    if (obj != null)
                    {
                        var player = "";
                        if (level != null)
                            player += " (" + level.GetPlayerAvatar().GetId() + ", " +
                                      level.GetPlayerAvatar().GetAvatarName() + ")";
                        //Debugger.WriteLine("\t" + obj.GetType().Name + player);
                        ((GameOpCommand) obj).Execute(level);
                    }
                }
                else
                {
                    var avatar = level.GetPlayerAvatar();
                    var allianceId = avatar.GetAllianceId();
                    if (allianceId > 0)
                    {
                        var cm = new ChatStreamEntry();
                        cm.SetId((int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                        cm.SetAvatar(avatar);
                        cm.SetMessage(m_vChatMessage);

                        var alliance = ObjectManager.GetAlliance(allianceId);
                        if (alliance != null)
                        {
                            alliance.AddChatMessage(cm);

                            foreach (var onlinePlayer in ResourcesManager.GetOnlinePlayers())
                            {
                                if (onlinePlayer.GetPlayerAvatar().GetAllianceId() == allianceId)
                                {
                                    var p = new AllianceStreamEntryMessage(onlinePlayer.GetClient());
                                    p.SetStreamEntry(cm);
                                    PacketManager.ProcessOutgoingPacket(p);
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion Public Methods
    }
}
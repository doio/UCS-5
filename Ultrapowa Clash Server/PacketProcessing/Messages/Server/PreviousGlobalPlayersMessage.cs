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
using System.Collections.Generic;
using UCS.Core;
using UCS.Helpers;

namespace UCS.PacketProcessing.Messages.Server
{
    internal class PreviousGlobalPlayersMessage : Message
    {
        #region Public Constructors

        public PreviousGlobalPlayersMessage(PacketProcessing.Client client) : base(client)
        {
            SetMessageType(24405);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var data = new List<byte>();
            var packet1 = new List<byte>();

            var i = 1;
            foreach (var player in ResourcesManager.GetOnlinePlayers())
            {
                var pl = player.GetPlayerAvatar();
                packet1.AddInt64(pl.GetId()); // The ID of the player
                packet1.AddString(pl.GetAvatarName()); // THe Name of the Player
                packet1.AddInt32(i); // Rank of the player
                packet1.AddInt32(pl.GetScore()); // Number of Trophies of the player
                packet1.AddInt32(i); // Up/Down from previous rank -> (int - 1)
                packet1.AddInt32(pl.GetAvatarLevel()); // The score of the player
                packet1.AddInt32(100); // The number of successed attack
                packet1.AddInt32(1); // Unknown1 Int32
                packet1.AddInt32(100); // Number of successed defenses
                packet1.AddInt32(1); // Activation of successed attacks
                packet1.AddInt32(pl.GetLeagueId()); // League of the player
                packet1.AddString("EN"); // Locales
                packet1.AddInt64(pl.GetId()); // Clan ID
                packet1.AddInt32(1); // Unknown2
                packet1.AddInt32(1); // Unknown3
                if (pl.GetAllianceId() > 0)
                {
                    packet1.Add(1); // 1 = Have an alliance | 0 = No alliance
                    packet1.AddInt64(pl.GetAllianceId()); // Alliance ID
                    packet1.AddString(ObjectManager.GetAlliance(pl.GetAllianceId()).GetAllianceName()); // Alliance Name
                    packet1.AddInt32(ObjectManager.GetAlliance(pl.GetAllianceId()).GetAllianceBadgeData()); // Unknown4
                }
                else
                    packet1.Add(0);
                if (i >= 200)
                    break;
                i++;
            }
            data.AddInt32(i - 1);
            data.AddRange(packet1);
            data.AddInt32(DateTime.Now.Month - 1);
            data.AddInt32(DateTime.Now.Year);
            Encrypt(data.ToArray());
        }

        #endregion Public Methods
    }
}
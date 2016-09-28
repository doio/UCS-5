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
using System.Text;
using UCS.Core;
using UCS.Helpers;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Client;

namespace UCS.PacketProcessing.Messages.Server
{
    //Packet 24133
    internal class NpcDataMessage : Message
    {
        #region Public Constructors

        public NpcDataMessage(PacketProcessing.Client client, Level level, AttackNpcMessage cnam) : base(client)
        {
            SetMessageType(24133);
            Player = level;
            LevelId = cnam.LevelId;
            JsonBase = ObjectManager.NpcLevels[LevelId];
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Encode()
        {
            var data = new List<byte>();

            data.AddInt32(0);
            data.AddInt32(JsonBase.Length);
            data.AddRange(Encoding.ASCII.GetBytes(JsonBase));
            data.AddRange(Player.GetPlayerAvatar().Encode());
            data.AddInt32(0);
            data.AddInt32(LevelId);

            Encrypt(data.ToArray());
        }

        #endregion Public Methods

        #region Public Properties

        public string JsonBase { get; set; }

        public int LevelId { get; set; }

        public Level Player { get; set; }

        #endregion Public Properties
    }
}
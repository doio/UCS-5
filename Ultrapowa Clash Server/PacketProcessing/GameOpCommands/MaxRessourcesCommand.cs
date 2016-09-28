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

using UCS.Core;
using UCS.Core.Network;
using UCS.Logic;
using UCS.PacketProcessing.Messages.Server;

namespace UCS.PacketProcessing.GameOpCommands
{
    internal class MaxRessourcesCommand : GameOpCommand
    {
        #region Public Constructors

        public MaxRessourcesCommand(string[] Args)
        {
            SetRequiredAccountPrivileges(0);
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Execute(Level level)
        {
            if (level.GetAccountPrivileges() >= GetRequiredAccountPrivileges())
            {
                var p = level.GetPlayerAvatar();
                p.SetResourceCount(ObjectManager.DataTables.GetResourceByName("Gold"), 999999999);
                p.SetResourceCount(ObjectManager.DataTables.GetResourceByName("Elixir"), 999999999);
                p.SetResourceCount(ObjectManager.DataTables.GetResourceByName("DarkElixir"), 999999999);
                p.SetDiamonds(999999);
                var own = new OwnHomeDataMessage(level.GetClient(), level);
                PacketManager.ProcessOutgoingPacket(own);
            }
            else
                SendCommandFailedMessage(level.GetClient());
        }

        #endregion Public Methods
    }
}
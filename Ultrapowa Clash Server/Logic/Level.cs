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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UCS.Logic.Manager;
using UCS.PacketProcessing;

namespace UCS.Logic
{
    internal class Level
    {
        #region Public Fields

        public GameObjectManager GameObjectManager;
        public WorkerManager WorkerManager;

        #endregion Public Fields

        #region Private Fields

        readonly ClientAvatar m_vClientAvatar;
        byte m_vAccountPrivileges;

        byte m_vAccountStatus;
        Client m_vClient;
        string m_vIPAddress;
        DateTime m_vTime;

        #endregion Private Fields

        #region Public Constructors

        public Level()
        {
            WorkerManager = new WorkerManager();
            GameObjectManager = new GameObjectManager(this);
            m_vClientAvatar = new ClientAvatar();
            m_vAccountPrivileges = 0;
            m_vAccountStatus = 0;
            m_vIPAddress = "0.0.0.0";
        }

        public Level(long id, string token)
        {
            WorkerManager = new WorkerManager();
            GameObjectManager = new GameObjectManager(this);
            m_vClientAvatar = new ClientAvatar(id, token);
            m_vTime = DateTime.UtcNow;
            m_vAccountPrivileges = 0;
            m_vAccountStatus = 0;
            m_vIPAddress = "0.0.0.0";
        }

        #endregion Public Constructors

        #region Public Methods

        public byte GetAccountPrivileges() => m_vAccountPrivileges;

        public bool Banned() => m_vAccountStatus > 99;

        public byte GetAccountStatus() => m_vAccountStatus;

        public Client GetClient() => m_vClient;

        public ComponentManager GetComponentManager() => GameObjectManager.GetComponentManager();

        public ClientAvatar GetHomeOwnerAvatar() => m_vClientAvatar;

        public string GetIPAddress() => m_vIPAddress;

        public ClientAvatar GetPlayerAvatar() => m_vClientAvatar;

        public DateTime GetTime() => m_vTime;

        public bool HasFreeWorkers() => WorkerManager.GetFreeWorkers() > 0;

        public void LoadFromJSON(string jsonString)
        {
            JObject jsonObject = JObject.Parse(jsonString);
            GameObjectManager.Load(jsonObject);
        }

        public string SaveToJSON() => JsonConvert.SerializeObject(GameObjectManager.Save(), Formatting.Indented);

        public void SetAccountPrivileges(byte privileges) => m_vAccountPrivileges = privileges;

        public void SetAccountStatus(byte status) => m_vAccountStatus = status;

        public void SetClient(Client client) => m_vClient = client;

        public void SetHome(string jsonHome) => GameObjectManager.Load(JObject.Parse(jsonHome));

        public void SetIPAddress(string IP) => m_vIPAddress = IP;

        public void SetTime(DateTime t) => m_vTime = t;

        public void Tick()
        {
            SetTime(DateTime.UtcNow);
            GameObjectManager.Tick();
        }

        #endregion Public Methods
    }
}

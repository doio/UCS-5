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
using Newtonsoft.Json.Linq;
using UCS.Helpers;

namespace UCS.Logic.StreamEntry
{
    internal class ChatStreamEntry : StreamEntry
    {
        #region Private Fields

        string m_vMessage;

        #endregion Private Fields

        #region Public Methods

        public override byte[] Encode()
        {
            var data = new List<byte>();
            data.AddRange(base.Encode());
            data.AddString(m_vMessage);
            return data.ToArray();
        }

        public string GetMessage() => m_vMessage;

        public override int GetStreamEntryType() => 2;

        public override void Load(JObject jsonObject)
        {
            base.Load(jsonObject);
            m_vMessage = jsonObject["message"].ToObject<string>();
        }

        public override JObject Save(JObject jsonObject)
        {
            jsonObject = base.Save(jsonObject);
            jsonObject.Add("message", m_vMessage);
            return jsonObject;
        }

        public void SetMessage(string message)
        {
            m_vMessage = message;
        }

        #endregion Public Methods
    }
}

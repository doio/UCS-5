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
using Newtonsoft.Json.Linq;
using UCS.Core;
using UCS.Files.Logic;
using UCS.Helpers;

namespace UCS.Logic
{
    internal class DataSlot
    {
        public DataSlot(Data d, int value)
        {
            Data = d;
            Value = value;
        }

        public Data Data;
        public int Value;

        public void Decode(BinaryReader br)
        {
            Data = br.ReadDataReference();
            Value = br.ReadInt32WithEndian();
        }

        public byte[] Encode()
        {
            var data = new List<byte>();
            data.AddInt32(Data.GetGlobalID());
            data.AddInt32(Value);
            return data.ToArray();
        }

        public void Load(JObject jsonObject)
        {
            Data = ObjectManager.DataTables.GetDataById(jsonObject["global_id"].ToObject<int>());
            Value = jsonObject["value"].ToObject<int>();
        }

        public JObject Save(JObject jsonObject)
        {
            jsonObject.Add("global_id", Data.GetGlobalID());
            jsonObject.Add("value", Value);
            return jsonObject;
        }

    }
    internal class TroopDataSlot
    {
        public TroopDataSlot(Data d, int value, int value1)
        {
            Data = d;
            Value = value;
            Value1 = value1;
        }

        public Data Data;
        public int Value;
        public int Value1;

        public void Decode(BinaryReader br)
        {
            Data = br.ReadDataReference();
            Value = br.ReadInt32WithEndian();
            Value1 = br.ReadInt32WithEndian();
        }

        public byte[] Encode()
        {
            var data = new List<byte>();
            data.AddInt32(Data.GetGlobalID());
            data.AddInt32(Value);
            data.AddInt32(Value1);
            return data.ToArray();
        }

        public void Load(JObject jsonObject)
        {
            Data = ObjectManager.DataTables.GetDataById(jsonObject["global_id"].ToObject<int>());
            Value = jsonObject["count"].ToObject<int>();
            Value1 = jsonObject["level"].ToObject<int>();
        }

        public JObject Save(JObject jsonObject)
        {
            jsonObject.Add("global_id", Data.GetGlobalID());
            jsonObject.Add("count", Value);
            jsonObject.Add("level", Value1);
            return jsonObject;
        }
    }
}
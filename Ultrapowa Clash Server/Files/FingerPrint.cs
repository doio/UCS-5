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
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UCS.Files
{
    internal class FingerPrint
    {
        #region Public Constructors

        public FingerPrint(string filePath)
        {
            files = new List<GameFile>();
            string fpstring = null;

            if (File.Exists(filePath))
            {
                using (var sr = new StreamReader(filePath))
                    fpstring = sr.ReadToEnd();
                LoadFromJson(fpstring);
                Console.WriteLine("[UCS]    ObjectManager: fingerprint loaded");
            }
            else
                Console.WriteLine(
                    "[UCS]    LoadFingerPrint: error! tried to load FingerPrint without file, run gen_patch first");
        }

        #endregion Public Constructors

        #region Public Properties

        public List<GameFile> files { get; set; }
        public string sha { get; set; }
        public string version { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void LoadFromJson(string jsonString)
        {
            var jsonObject = JObject.Parse(jsonString);

            var jsonFilesArray = (JArray) jsonObject["files"];
            foreach (JObject jsonFile in jsonFilesArray)
            {
                var gf = new GameFile();
                gf.Load(jsonFile);
                files.Add(gf);
            }
            sha = jsonObject["sha"].ToObject<string>();
            version = jsonObject["version"].ToObject<string>();
        }

        public string SaveToJson()
        {
            var jsonData = new JObject();

            var jsonFilesArray = new JArray();
            foreach (var file in files)
            {
                var jsonObject = new JObject();
                file.SaveToJson(jsonObject);
                jsonFilesArray.Add(jsonObject);
            }
            jsonData.Add("files", jsonFilesArray);
            jsonData.Add("sha", sha);
            jsonData.Add("version", version);

            return JsonConvert.SerializeObject(jsonData).Replace("/", @"\/");
        }

        #endregion Public Methods
    }

    internal class GameFile
    {
        #region Public Properties

        public string file { get; set; }
        public string sha { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void Load(JObject jsonObject)
        {
            sha = jsonObject["sha"].ToObject<string>();
            file = jsonObject["file"].ToObject<string>();
        }

        public string SaveToJson(JObject fingerPrint)
        {
            fingerPrint.Add("sha", sha);
            fingerPrint.Add("file", file);

            return JsonConvert.SerializeObject(fingerPrint);
        }

        #endregion Public Methods
    }
}
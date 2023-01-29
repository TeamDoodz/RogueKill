﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RogueKill.Utils;
using UnityEngine;

namespace RogueKill.SaveSystem
{
    public sealed class SaveFile
    {
        public const string MAIN_SAVE_NAME = "save_data";

        public static string GlobalSavePath => Path.Combine(Application.persistentDataPath, "RogueKill");

        public static SaveFile Main { get; } = new(MAIN_SAVE_NAME, new(SaveUtil.AllModules));

        public SaveData Data { get; private set; }
        public string Name { get; private set; }

        public string FilePath => Path.Combine(GlobalSavePath, Name + ".json");

        public SaveFile(string name, SaveData data)
        {
            Name = name;
            Data = data;

            Application.quitting += Save;
        }

        public void Save()
        {
            Plugin.logger.LogInfo($"Saving to {FilePath}");
            Catcher.Try(() =>
            {
                SaveDataConverter converter = new(Array.Empty<Type>()); // dont specify any types since we are just saving
                using (StreamWriter writer = File.CreateText(FilePath))
                {
                    converter.WriteJson(new JsonTextWriter(writer), Data, JsonSerializer.CreateDefault());
                }
            }, "Save Data", Plugin.logger);
        }

        public static SaveFile Load(string name)
        {
            SaveFile retVal = new(name, null);

            if (!File.Exists(retVal.FilePath))
            {
                retVal.Data = new SaveData(SaveUtil.AllModules);
                return retVal;
            }

            Plugin.logger.LogInfo($"Loading save data from {retVal.FilePath}");

            SaveDataConverter converter = new(Array.Empty<Type>()); // dont specify any types because why not
            using (StreamReader reader = File.OpenText(retVal.FilePath))
            {
                retVal.Data = converter.ReadJson(new JsonTextReader(reader), typeof(SaveData), retVal.Data, JsonSerializer.CreateDefault()) as SaveData ?? new SaveData(SaveUtil.AllModules);
            }

            return retVal;
        }
    }
}

/*
using System.IO;
using HarmonyLib;
using UnityEngine;

namespace RogueKill.Utils
{
    public static class CustomSaveData
    {
        public static string path = $"{Application.persistentDataPath}\\achievements.rkuc";


        public static void WriteToSave(string key, string value)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            string[] lines = File.ReadAllLines(path);
            int currentLine = 0;
            foreach (string line in lines)
            {
                if (line.Contains(key))
                {
                    lines[currentLine] = $"{key}:{value}";
                    File.WriteAllLines(path, lines);
                    return;
                }
                currentLine++;
            }
            lines.AddItem($"{key}:{value}");
            File.WriteAllLines(path, lines);
        }
        public static string ReadFromSave(string key)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
                return null;
            }
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.Contains(key))
                {
                    string[] values = line.Split(':');
                    return values[1];
                }
            }
            return null;
        }
    }
}
*/

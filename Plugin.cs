using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace RogueKill
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource logger;
        public static AssetBundle commonBundle = null;
        private void Awake()
        {
            logger = Logger;
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
        private void Start()
        {
            Harmony harmony = new("UltraCrypt");
            harmony.PatchAll();
        }
        private void Update()
        {
            if (commonBundle == null)
            {
                IEnumerable<AssetBundle> bundles = AssetBundle.GetAllLoadedAssetBundles();
                foreach (AssetBundle bundle in bundles)
                {
                    if (bundle.name.Contains("common"))
                    {
                        commonBundle = bundle;
                    }
                }
            }
        }
    }
}

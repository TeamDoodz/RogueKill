using BepInEx;
using HarmonyLib;
using RogueKill.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RogueKill
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static AssetBundle commonBundle = null;
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
        private void Start()
        {
            Harmony harmony = new Harmony("UltraCrypt");
            harmony.PatchAll();
        }
        private void Update()
        {
            if (commonBundle == null)
            {
                IEnumerable<AssetBundle> bundles = AssetBundle.GetAllLoadedAssetBundles();
                foreach (AssetBundle bundle in bundles)
                {
                    if (bundle.name.Contains("common")){
                        commonBundle = bundle;
                    }
                }
            }
            if(Input.GetKeyDown(KeyCode.L))
            {
                Vector3 localPos = new Vector3(-1f, 1f, 0f);
                Color color = new Color(0.6f, 0.6f, 0.6f);
                GameObject terminal = Terminal.SpawnTerminal(localPos, null, color);
            }
        }
    }
}

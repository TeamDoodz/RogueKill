using HarmonyLib;
using RogueKill.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RogueKill.Skill_Tree
{
    [HarmonyPatch(typeof(ShopZone), "Start")]
    public static class Skills
    {
        //CREATES AN INFINITE LOOP, DO NOT UNCOMMENT

        /*public static void Postfix(ShopZone __instance)
        {
            Vector3 localPos = new Vector3(-1f, 1f, 0f);
            Color color = new Color(0.6f, 0.6f, 0.6f);
            GameObject terminal = Terminal.SpawnTerminal(localPos, __instance.transform.parent, color);
            Canvas canvas = terminal.GetComponentInChildren<Canvas>();

        }
        */
    }
}

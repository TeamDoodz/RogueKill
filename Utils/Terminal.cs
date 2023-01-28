using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameConsole;

namespace RogueKill.Utils
{
    public static class Terminal
    {
        static GameObject terminalTemplate = null;
        public static GameObject SpawnTerminal(Vector3 localPos, Transform parent, Color color)
        {
            if (terminalTemplate == null)
            {
                if (Plugin.commonBundle != null)
                {
                    terminalTemplate = Plugin.commonBundle.LoadAsset<GameObject>("Shop.prefab");
                }
            }
            if (terminalTemplate != null)
            {
                GameObject terminal = GameObject.Instantiate(terminalTemplate);
                if (parent != null)
                {
                    terminal.transform.parent = parent;
                }
                terminal.transform.localPosition = localPos;
                if (color != null)
                {

                    MeshRenderer meshRenderer = terminal.GetComponentInChildren<MeshRenderer>();
                    meshRenderer.material.color = color;
                }
                GameConsole.Console.print(terminal.transform.position);
                return terminal;
            }
            return null;
        }
    }
}

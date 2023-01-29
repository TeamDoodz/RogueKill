using UnityEngine;

namespace RogueKill.Utils
{
    public static class Terminal
    {
        private static GameObject terminalTemplate = null;
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
                GameObject terminal = Object.Instantiate(terminalTemplate);
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
                return terminal;
            }
            return null;
        }
    }
}

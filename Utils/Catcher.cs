using System;
using BepInEx.Logging;

namespace RogueKill.Utils
{
    public static class Catcher
    {
        public static bool Try(Action action, string actionName, ManualLogSource logger)
        {
            if (action is null)
            {
                return false;
            }

            try
            {
                action?.Invoke();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError($"Failed action \"{actionName}\" ({e.Message}). See LogOutput.log for more information.");
                logger.LogDebug(e);
                return false;
            }
        }
    }
}

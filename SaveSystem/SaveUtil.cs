using System.Collections.Generic;

namespace RogueKill.SaveSystem
{
    public static class SaveUtil
    {
        public static IEnumerable<SaveSystemModule> AllModules
        {
            get
            {
                yield return new CurrencyData();
            }
        }
    }
}

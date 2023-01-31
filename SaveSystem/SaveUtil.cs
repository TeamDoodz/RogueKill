using System.Collections.Generic;
using RogueKill.Currency;

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

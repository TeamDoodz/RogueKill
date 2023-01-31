using RogueKill.SaveSystem;

namespace RogueKill.Currency
{
    public static class CustomCurrency
    {
        public static int baseAmount = 100;
        public static int levelsCompleted = 0;

        public static void AddCurrency(bool bossLevel)
        {
            CurrencyData data = SaveFile.Main.Data.GetModule<CurrencyData>();

            StatsManager stats = MonoSingleton<StatsManager>.Instance;
            int kills = stats.kills;

            int addedAmount = baseAmount + (levelsCompleted * 25) + kills;

            if (bossLevel)
            {
                addedAmount += 100;
            }

            data.Credits += addedAmount;
        }
        public static void RemoveCurrency(int amount)
        {
            CurrencyData data = SaveFile.Main.Data.GetModule<CurrencyData>();

            data.Credits -= amount;
        }
    }
}

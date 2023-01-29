using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using GameConsole;
using RogueKill.Utils;

namespace RogueKill.Currency
{
    public static class CustomCurrency
    {
        public static int baseAmount = 100;
        public static int levelsCompleted = 0;
        public static int currentAmount = 0;

        public static void AddCurrency(bool bossLevel)
        {
            if(CustomSaveData.ReadFromSave("credit") != null)
            {
                currentAmount = int.Parse(CustomSaveData.ReadFromSave("credit"));  
            }
            
            StatsManager stats = MonoSingleton<StatsManager>.Instance;
            int kills = stats.kills;

            if (currentAmount <= 0)
            {
                currentAmount = 0;
            }
            
            int addedAmount = baseAmount + (levelsCompleted * 25) + (kills);
            
            if (bossLevel) {
                addedAmount += 100;
            }
            
            currentAmount += addedAmount;
            CustomSaveData.WriteToSave("credit", currentAmount.ToString());
        }
        public static void RemoveCurrency(int amount) {
            
            if (CustomSaveData.ReadFromSave("credit") != null)
            {
                currentAmount = int.Parse(CustomSaveData.ReadFromSave("credit"));
            }
            
            currentAmount -= amount;
            CustomSaveData.WriteToSave("credit", currentAmount.ToString());
        }
    }
}

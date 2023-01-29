using System;

namespace RogueKill.SaveSystem
{
    /// <summary>
    /// Manages serialization for currency data.
    /// </summary>
    public sealed class CurrencyData : SaveSystemModule
    {
        public override string Name => "credits";

        protected override Type DataType => typeof(long);

        /// <summary>
        /// The amount of credits the player has.
        /// </summary>
        public long Credits
        {
            get
            {
                if (Data is not long)
                {
                    Plugin.logger.LogWarning($"{nameof(CurrencyData)}.{nameof(Data)} is not of type {nameof(Int64)}!");
                    Data = 0L;
                }
                return (long)Data;
            }
            set
            {
                Data = value;
                SetDirty();
            }
        }
    }
}

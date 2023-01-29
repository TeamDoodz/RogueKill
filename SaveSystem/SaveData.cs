using System.Collections.Generic;
using System.Linq;

namespace RogueKill.SaveSystem
{
    public sealed class SaveData
    {
        private readonly List<SaveSystemModule> modules = new();

        public IEnumerable<SaveSystemModule> Modules => modules;

        public T GetModule<T>() where T : SaveSystemModule
        {
            return Modules.FirstOrDefault((m) => typeof(T).IsAssignableFrom(m.GetType())) as T;
        }

        public SaveData(IEnumerable<SaveSystemModule> modules)
        {
            this.modules.AddRange(modules);
        }
    }
}

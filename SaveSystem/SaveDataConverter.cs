using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RogueKill.SaveSystem
{
    public class SaveDataConverter : JsonConverter<SaveData>
    {
        private readonly List<Type> moduleTypes = new();

        public override SaveData ReadJson(JsonReader reader, Type objectType, SaveData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.StartObject)
            {
                throw new Exception($"Unexpected token {reader.TokenType}.");
            }

            List<SaveSystemModule> modules = null;

            if (!hasExistingValue)
            {
                modules = moduleTypes.Select((t) => (SaveSystemModule)Activator.CreateInstance(t)).ToList();
                existingValue = new SaveData(modules);
            }
            else
            {
                modules = existingValue.Modules.ToList();
            }

            while (reader.Read())
            {
                string key = reader.Value?.ToString();

                SaveSystemModule module = modules.FirstOrDefault((m) => m.Name == key);
                if (module == null)
                {
                    Plugin.logger.LogWarning($"Save file key {key} was not expected.");
                    serializer.Deserialize(reader); // skip any object data after the key
                    continue;
                }

                module.LoadData(reader, serializer);
            }

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, SaveData value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (SaveSystemModule module in value.Modules)
            {
                writer.WriteComment(module.GetType().FullName);
                writer.WritePropertyName(module.Name);
                module.SaveData(writer, serializer);
            }
            writer.WriteEndObject();
        }

        public SaveDataConverter(IEnumerable<Type> moduleTypes)
        {
            this.moduleTypes.AddRange(moduleTypes);
        }
    }
}

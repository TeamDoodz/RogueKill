﻿using System;
using Newtonsoft.Json;

namespace RogueKill.SaveSystem
{
    /// <summary>
    /// Represents a module of the save system that is responsible for serializing a section of the save file.
    /// </summary>
    public abstract class SaveSystemModule
    {
        /// <summary>
        /// The type that this instance will expect during serialization.
        /// </summary>
        protected abstract Type DataType { get; }

        /// <summary>
        /// The data that this instance composes. This can be <see langword="null"/>.
        /// </summary>
        protected object Data { get; set; }

        /// <summary>
        /// The name to use when saving this instance to the save file.
        /// </summary>
        public abstract string Name { get; }

        public bool IsDirty { get; set; }

        public void SetDirty()
        {

        }

        /// <summary>
        /// Saves this instance's data using the provided writer.
        /// </summary>
        /// <param name="writer">The writer to write to when saving.</param>
        /// <param name="serializer">The serializer to use.</param>
        public virtual void SaveData(JsonWriter writer, JsonSerializer serializer)
        {
            serializer.Serialize(writer, Data);
        }

        /// <summary>
        /// Loads data to this instance using the specified reader
        /// </summary>
        /// <param name="reader">The reader to read from when loading.</param>
        /// <param name="serializer">The serializer to use.</param>
        public virtual void LoadData(JsonReader reader, JsonSerializer serializer)
        {
            Data = serializer.Deserialize(reader, DataType);
        }
    }
}

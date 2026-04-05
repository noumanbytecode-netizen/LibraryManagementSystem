using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace LibraryManagementSystem.Storage
{
    public static class JsonStore
    {
        public static void Save<T>(string fileName, List<T> data)
        {
            Directory.CreateDirectory("DataFiles");
            string path = Path.Combine("DataFiles", fileName);

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static List<T> Load<T>(string fileName)
        {
            Directory.CreateDirectory("DataFiles");
            string path = Path.Combine("DataFiles", fileName);

            if (!File.Exists(path))
                return new List<T>();

            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }
    }
}

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BYZ.Data.Infrastructure
{
    public class JsonReader
    {
        public List<T> Read<T>(string fileName)
        {
            var json = File.ReadAllText(fileName);

            var result = JsonConvert.DeserializeObject<List<T>>(json, settings: new JsonSerializerSettings()
            {
                ContractResolver = new SnakeCaseContractResolver()
            });

            return result;
        }
    }
}
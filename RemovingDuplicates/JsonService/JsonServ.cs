using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RemovingDuplicates.JsonService.Converters;

namespace RemovingDuplicates.JsonService
{
    public class JsonServ
    {
        public static T CreateEntityFromJsonFile<T>(string path)
        {
            T res;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(path))
            {
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    res = serializer.Deserialize<T>(jsonTextReader);
                }
            }
            return res;
        }

        public static List<JsonObj> CreateNonDuplicatesList(JsonObj[] arr)
        {
            var list = new List<JsonObj>();
            var group = arr.GroupBy(x => new { x.rec_id, x.timestamp });

            foreach (var item in group)
            {
                list.Add(item.Select(x => x).FirstOrDefault());
            }
            return list;
        }

        public static void SaveListToJsonFile(string path, List<JsonObj> list)
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "yyyy-MM-dd hh:mm:ss";
            jsonSettings.Converters.Add(new DoubleJsonConverter());
            string data = JsonConvert.SerializeObject(list, Formatting.Indented, jsonSettings);
            File.WriteAllText(path, data);
        }
    }
}

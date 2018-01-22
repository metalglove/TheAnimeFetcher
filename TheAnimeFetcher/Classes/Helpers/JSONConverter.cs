using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAnimeFetcher.Classes.Helpers
{
    public static class JSONConverter
    {
        public static T DeserializeJSon<T>(string Json)
        {
            return JsonConvert.DeserializeObject<T>(Json);
        }
        public static object DeserializeJSon(string Json, Type type)
        {
            return JsonConvert.DeserializeObject(Json, type);
        }
    }
}

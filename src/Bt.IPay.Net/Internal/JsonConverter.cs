using Newtonsoft.Json;

namespace Bt.IPay.Net.Internal
{
    internal class JsonConverter
    {
        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static string SerializeObject<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
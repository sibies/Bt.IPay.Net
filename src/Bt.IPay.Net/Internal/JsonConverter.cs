using Newtonsoft.Json;

namespace Bt.IPay.Net.Internal
{
    internal class JsonConverter
    {
        /// <summary>
        /// Poate fi inlocuit din Newtonsoft.Json cu System.Text.Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// Poate fi inlocuit din Newtonsoft.Json cu System.Text.Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(T data)
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(data, settings);
        }
    }
}
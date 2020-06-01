using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class Attribute
    {
        /// <summary>
        /// Numele atributului – “mdOrder”
        /// </summary>
        [StringLength(7)]
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Valoarea atributului - identificator de comandă în sistemul de plăți (unic în sistem).
        /// </summary>
        [StringLength(36)]
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
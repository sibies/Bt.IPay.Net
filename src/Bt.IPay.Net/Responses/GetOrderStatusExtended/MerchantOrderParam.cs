using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class MerchantOrderParam
    {
        /// <summary>
        /// Numele parametrului suplimentar.
        /// </summary>
        [StringLength(20)]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Valoarea parametrului suplimentar.
        /// </summary>
        [StringLength(1024)]
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

using Newtonsoft.Json;

namespace Bt.IPay.Net.Responses.GetOrderStatusExtended
{
    public class Interest
    {
        [JsonProperty("interestType")]
        public string InterestType { get; set; }
        [JsonProperty("interestValue")]
        public string InterestValue { get; set; }
    }
}